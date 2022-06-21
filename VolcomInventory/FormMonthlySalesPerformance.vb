Public Class FormMonthlySalesPerformance
    Public month As List(Of String) = New List(Of String)

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        If CENewView.EditValue = True Then
            viewNewReport()
        Else
            'viewOldReport()
        End If
    End Sub

    Sub viewNewReport()
        'filter date
        Dim year_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(0))
        Dim year_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(0))
        Dim month_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(1))
        Dim month_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(1))
        Dim fromDate As String = "" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01"
        Dim untilDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + "-01"

        'validasi
        'jika store blm dipilih
        If CEAllStore.EditValue = False Then
            GVStore.ActiveFilterString = ""
            GVStore.ActiveFilterString = "[is_select]='Yes' "
            If GVStore.RowCount <= 0 Then
                stopCustom("Please select store first")
                GVStore.ActiveFilterString = ""
                Cursor = Cursors.Default
                Exit Sub
            End If
            GVStore.ActiveFilterString = ""
        End If
        'jika blm clsing
        Dim yp As String = year_from.ToString + "," + year_to.ToString
        Dim mp As String = month_from.ToString + "," + month_to.ToString
        checkClosingSOHSalPeriod(mp, yp)

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Build query")

        'rmt 
        Dim rmt_sal As String = execute_query("SELECT GROUP_CONCAT(DISTINCT sp.report_mark_type) AS `rmt` FROM tb_sales_pos sp WHERE sp.id_report_status=6", 0, True, "", "", "", "")

        'filter product
        'join design
        Dim join_design As String = "INNER JOIN tb_m_design d ON d.id_design = soh.id_design
        LEFT JOIN (
	        SELECT c.id_design, 
	        MAX(CASE WHEN d.id_code=32 THEN d.id_code_detail END) AS `id_division`,
            MAX(CASE WHEN d.id_code=32 THEN d.code_detail_name END) AS `division`,
            MAX(CASE WHEN d.id_code=4 THEN d.id_code_detail END) AS `id_category`,
	        MAX(CASE WHEN d.id_code=4 THEN d.display_name END) AS `category`,
            MAX(CASE WHEN d.id_code=30 THEN d.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN d.id_code=30 THEN d.display_name END) AS `class`,
            MAX(CASE WHEN d.id_code=14 THEN d.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN d.id_code=14 THEN d.code_detail_name END) AS `color`,
            MAX(CASE WHEN d.id_code=5 THEN d.id_code_detail END) AS `id_source`,
	        MAX(CASE WHEN d.id_code=5 THEN d.display_name END) AS `source`,
            MAX(CASE WHEN d.id_code=43 THEN d.id_code_detail END) AS `id_sht`,
		    MAX(CASE WHEN d.id_code=43 THEN d.code_detail_name END) AS `sht`
	        FROM tb_m_design_code AS c
	        LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	        WHERE d.id_code IN (32,4,30,14,5, 43)
	        GROUP BY c.id_design
        ) i ON i.id_design = d.id_design
        INNER JOIN tb_season AS season ON d.id_season = season.id_season
        INNER JOIN tb_range AS `range` ON season.id_range = range.id_range
        INNER JOIN tb_season_delivery AS delivery ON d.id_delivery = delivery.id_delivery "
        'where
        Dim where_prod As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_prod += " AND d.id_season IN (" + CCBESeason.EditValue.ToString + ")"
        End If
        If Not CCBEDivision.EditValue.ToString = "" Then
            where_prod += " AND i.id_division IN (" + CCBEDivision.EditValue.ToString + ")"
        End If
        If Not CCBECategory.EditValue.ToString = "" Then
            where_prod += " AND i.id_category IN (" + CCBECategory.EditValue.ToString + ")"
        End If
        If Not CCBEClass.EditValue.ToString = "" Then
            where_prod += " AND i.id_class IN (" + CCBEClass.EditValue.ToString + ")"
        End If
        If Not TxtIdProduct.Text.ToString = "" Then
            where_prod += " AND d.id_design IN (" + TxtIdProduct.Text + ")"
        End If
        'filter product SOH
        Dim join_design_soh As String = ""
        Dim where_prod_soh As String = ""
        If Not CCBESeason.EditValue.ToString = "" Or Not CCBEDivision.EditValue.ToString = "" Or Not CCBECategory.EditValue.ToString = "" Or Not CCBEClass.EditValue.ToString = "" Or Not TxtIdProduct.Text.ToString = "" Then
            join_design_soh = join_design
            where_prod_soh = where_prod
        End If

        ' filter store
        Dim where_store As String = ""
        'category store
        Dim id_cat As String = LECat.EditValue.ToString
        If id_cat = "1" Then
            'wholesale
            where_store += "AND c.id_comp_group='59' AND c.id_commerce_type='1 ' "
        ElseIf id_cat = "2" Then
            'consingment
            where_store += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='1' "
        ElseIf id_cat = "3" Then
            'online
            where_store += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='2' "
        ElseIf id_cat = "4" Then
            'b&b wholesale
            where_store += "AND c.id_comp_group<>'59' AND c.id_comp_group='7' AND c.id_commerce_type='1' "
        Else
            where_store += ""
        End If
        'area 
        If CCBEArea.EditValue.ToString <> "" Then
            where_store += "AND c.id_area IN (" + CCBEArea.EditValue.ToString + ") "
        End If
        'country
        where_store += "AND cry.id_country='" + SLUENational.EditValue.ToString + "' "
        'province
        If CCBEProvince.EditValue.ToString <> "" Then
            where_store += "AND state.id_state IN (" + CCBEProvince.EditValue.ToString + ") "
        End If
        'group
        If CCBEGroupStore.EditValue.ToString <> "" Then
            where_store += "AND c.id_comp_group IN(" + CCBEGroupStore.EditValue.ToString + ") "
        End If
        'comp
        If CEAllStore.EditValue = False Then
            GVStore.ActiveFilterString = "[is_select]='Yes' "
            Dim id_store_in As String = ""
            For s As Integer = 0 To GVStore.RowCount - 1
                If s > 0 Then
                    id_store_in += ","
                End If
                id_store_in += GVStore.GetRowCellValue(s, "id_comp").ToString
            Next
            where_store += "AND c.id_comp IN (" + id_store_in + ") "
            GVStore.ActiveFilterString = ""
        End If
        'active
        If CEActiveStore.Checked Then
            where_store += "AND c.is_active = 1"
        End If

        'set del account ol store
        Dim id_del_online_store = ""
        id_del_online_store = execute_query("SELECT IFNULL(GROUP_CONCAT(DISTINCT olc.id_wh),0) AS `id_wh` 
        FROM tb_ol_store_comp olc
        INNER JOIN tb_m_comp c ON c.id_comp = olc.id_store
        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
        INNER JOIN tb_m_state state ON state.id_state = cty.id_state
        INNER JOIN tb_m_region reg ON reg.id_region = state.id_region
        INNER JOIN tb_m_country cry ON cry.id_country = reg.id_country
        WHERE 1=1 " + where_store, 0, True, "", "", "", "")

        'penetuan store rec
        Dim col_store_received As String = ""
        Dim col_receive_raw As String = "wh_rec"
        Dim col_receive As String = "WH Received|Normal (BOS)"
        Dim col_join_store_rec As String = ""
        If Not LECat.EditValue.ToString = "0" Or Not CCBEArea.EditValue.ToString = "" Or Not SLUEIsland.EditValue.ToString = "ALL" Or Not CCBEProvince.EditValue.ToString = "" Or Not CCBEGroupStore.EditValue.ToString = "" Or Not CEAllStore.EditValue = True Then
            col_store_received = "IFNULL(store_rec.qty_normal,0) AS `Store Received|Total`, "
            col_receive_raw = "store_rec"
            col_receive = "Store Received|Total"
            col_join_store_rec = "LEFT JOIN (
                SELECT p.id_design, SUM(p.qty_normal) AS `qty_normal`
                FROM (
                    SELECT p.id_design, SUM(d.pl_sales_order_del_det_qty) AS qty_normal
                    FROM tb_pl_sales_order_del AS s
                    INNER JOIN tb_pl_sales_order_del_det AS d ON d.id_pl_sales_order_del = s.id_pl_sales_order_del
                    INNER JOIN tb_m_comp_contact w ON w.id_comp_contact = s.id_store_contact_to
                    INNER JOIN tb_m_comp c ON c.id_comp = w.id_comp
                    INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
                    INNER JOIN tb_m_state state ON state.id_state = cty.id_state
                    INNER JOIN tb_m_region reg ON reg.id_region = state.id_region
                    INNER JOIN tb_m_country cry ON cry.id_country = reg.id_country
                    INNER JOIN tb_m_product p ON p.id_product = d.id_product
                    WHERE s.id_pl_sales_order_del > 0 AND s.id_report_status = 6 AND c.id_commerce_type=1 " + where_store + "
                    GROUP BY p.id_design
                    UNION ALL
                    SELECT p.id_design, SUM(td.fg_trf_det_qty) AS `qty_normal` 
                    FROM tb_fg_trf t
                    INNER JOIN tb_fg_trf_det td ON td.id_fg_trf = t.id_fg_trf
                    INNER JOIN tb_m_product p ON p.id_product = td.id_product
                    INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = t.id_comp_contact_to
                    WHERE t.id_report_status=6 AND sc.id_comp IN (" + id_del_online_store + ")
                    GROUP BY p.id_design 
                ) p
                GROUP BY p.id_design
            ) store_rec ON store_rec.id_design = d.id_design "
        End If

        'filter wh
        Dim compG78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 371", 0, True, "", "", "", "")
        Dim compGON As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1251", 0, True, "", "", "", "")
        Dim compS78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 429", 0, True, "", "", "", "")
        Dim compGOS As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1255", 0, True, "", "", "", "")
        Dim compREJ As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_type IN (3)", 0, True, "", "", "", "")


        'var
        Dim col_sal1 As String = ""
        Dim col_sal2 As String = ""
        Dim col_sal_total1 As String = ""
        Dim col_sal_total2 As String = ""
        Dim col_soh1 As String = ""
        Dim col_soh2 As String = ""
        Dim col_sas1 As String = ""
        Dim col_sell_thru As String = ""
        Dim add_sell_thru As String = ""
        Dim col_rts1 As String = ""
        Dim col_rts2 As String = ""
        Dim col_del1 As String = ""
        Dim col_del2 As String = ""

        For y = year_from To year_to
            If y > year_from Then
                col_sal1 += ","
                col_sal2 += ","
                col_sal_total1 += ","
                col_sal_total2 += ","
                col_soh1 += ","
                col_soh2 += ","
                col_sas1 += ","
                col_sell_thru += ","
                col_rts1 += ","
                col_rts2 += ","
                col_del1 += ","
                col_del2 += ","
            End If

            Dim last_month As Integer = 0
            Dim j As Integer = 0
            If y = year_from Then
                j = month_from
            Else
                j = 1
            End If
            For m = j To 12
                last_month = m
                If m > j Then
                    col_sal1 += ","
                    col_sal2 += ","
                    col_soh1 += ","
                    col_soh2 += ","
                    col_sas1 += ","
                    col_sell_thru += ","
                    col_rts1 += ","
                    col_rts2 += ","
                    col_del1 += ","
                    col_del2 += ","
                End If
                col_sal1 += "IFNULL(SUM(CASE WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND soh.report_mark_type IN(" + rmt_sal + ") " + where_store + " THEN soh.qty END),0)*-1 AS `Sales " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_sal2 += "soh.`Sales " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_soh1 += "IFNULL(SUM(
                    CASE
                        WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND c.id_comp_cat!=6 AND soh.id_comp IN(" + id_del_online_store + ")  THEN soh.qty
                        WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND c.id_comp_cat=6 AND c.id_commerce_type=1 " + where_store + " THEN soh.qty
                    END
                ),0) AS `Monthly SOH " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_soh2 += "soh.`Monthly SOH " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_sas1 += "(soh.`Sales " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "`/(soh.`Monthly SOH " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "`+soh.`Sales " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "`))*100 AS `Monthly SAS " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_rts1 += "ABS(IFNULL(SUM(CASE WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND soh.report_mark_type IN(46,120) " + where_store + " THEN soh.qty END),0)) AS `Monthly Return " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_rts2 += "soh.`Monthly Return " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_del1 += "IFNULL(SUM(
		            CASE
			            WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND c.id_comp_cat!=6 AND soh.report_mark_type=58 AND soh.id_comp IN(" + id_del_online_store + ") THEN soh.qty 
			            WHEN soh.soh_date='" + y.ToString + "-" + m.ToString + "-01' AND c.id_comp_cat=6 AND c.id_commerce_type=1 AND soh.report_mark_type IN(43,103) " + where_store + " THEN soh.qty 
		            END
	            ),0) AS `Monthly Delivery " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "
                col_del2 += "soh.`Monthly Delivery " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "

                'sell thru
                If y = year_from And m = month_from Then
                    add_sell_thru = "IFNULL(sal_beg.qty_sal_beg,0)"
                End If
                add_sell_thru += " + soh.`Sales " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "`"
                col_sell_thru += "((" + add_sell_thru + ")/(SELECT  `" + col_receive + "`))*100 AS `Monthly Sell Thru " + y.ToString + "|" + month(m - 1) + " " + y.ToString + "` "

                If y = year_to And m = month_to Then
                    Exit For
                End If
            Next
            col_sal_total1 += "IFNULL(SUM(CASE WHEN soh.soh_date>='" + y.ToString + "-" + j.ToString + "-01' AND soh.soh_date<='" + y.ToString + "-" + last_month.ToString + "-01' AND soh.report_mark_type IN(" + rmt_sal + ") " + where_store + " THEN soh.qty END),0)*-1 AS `Total Sales|" + y.ToString + "` "
            col_sal_total2 += "soh.`Total Sales|" + y.ToString + "` "
        Next

        'where
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading data")
        Dim query As String = "SELECT d.design_code AS `Product Info|Code`, d.design_display_name AS `Product Info|Description`, i.division AS `Product Info|Division`, 
        i.category AS `Product Info|Category`, i.class AS `Product Info|Class`, i.color AS `Product Info|Color`, i.sht AS `Product Info|Silhouette`, i.source AS `Product Info|Source`,
        season.season AS `Product Info|Season`, delivery.delivery AS `Product Info|Delivery`, range.year_range AS `Product Info|Year`,
        DATE_FORMAT(d.design_first_rec_wh, '%d %M %Y') AS `Product Age|WH Date`,
        DATE_FORMAT(first_del.first_del, '%d %M %Y') AS `Product Age|Del Date`,
        TIMESTAMPDIFF(MONTH, d.design_first_rec_wh, NOW()) AS `Product Age|WH Age`,
        TIMESTAMPDIFF(MONTH, first_del.first_del, NOW()) AS `Product Age|Del Age`,
        price_normal.design_price AS `Price|Normal`,
        IF(price_current.design_price = price_normal.design_price, 0, price_current.design_price) AS `Price|Current`,
        DATE_FORMAT(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 1), '%d %M %Y') AS `Price Update Dates|Price U1`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 2), 12), '%d %M %Y') AS `Price Update Dates|Price U2`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 3), 23), '%d %M %Y') AS `Price Update Dates|Price U3`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 4), 34), '%d %M %Y') AS `Price Update Dates|Price U4`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 5), 45), '%d %M %Y') AS `Price Update Dates|Price U5`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 6), 56), '%d %M %Y') AS `Price Update Dates|Price U6`,
        price_current.design_price_type AS `Price Update Dates|Current Status`,
        IFNULL(wh_rec.qty_normal,0) AS `WH Received|Normal (BOS)`, IFNULL(wh_rec.qty_defect,0) AS `WH Received|Defect`,
        (IFNULL(wh_rec.qty_normal,0) + IFNULL(wh_rec.qty_defect,0)) AS `WH Received|Total`,
        " + col_store_received + "
        " + col_sal2 + ",
        " + col_sal_total2 + ",
        soh.`Total Sales|Sales Toko Normal`, soh.`Total Sales|Sales Toko Sale`, soh.`Total Sales|Grand Total`,
        (soh.`Total Sales|Sales Toko Normal`/IFNULL(" + col_receive_raw + ".qty_normal,0))*100 AS `Sell Thru|Normal`, 
        (soh.`Total Sales|Sales Toko Sale`/(IFNULL(" + col_receive_raw + ".qty_normal,0)-soh.`Total Sales|Sales Toko Normal`))*100 AS `Sell Thru|Sale`, 
        (soh.`Total Sales|Grand Total`/IFNULL(" + col_receive_raw + ".qty_normal,0))*100 AS `Sell Thru|Total`,
        " + col_soh2 + ",
        " + col_sas1 + ",
        " + col_sell_thru + ",
        " + col_del2 + ",
        " + col_rts2 + ",
        soh.`Stock Gudang Normal|G78`,
        soh.`Stock Gudang Normal|GON`,
        soh.`Stock Gudang Sale|S78`,
        soh.`Stock Gudang Sale|GOS`,
        soh.`Stock Gudang Non Active|Reject`
        FROM (
	        SELECT soh.id_design,
	        " + col_sal1 + ",
	        " + col_sal_total1 + ",
            IFNULL(SUM(CASE WHEN soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' AND c.id_store_type IN(1) AND soh.report_mark_type IN(" + rmt_sal + ") " + where_store + " THEN soh.qty END),0)*-1 AS `Total Sales|Sales Toko Normal`,
	        IFNULL(SUM(CASE WHEN soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' AND c.id_store_type IN(2,3) AND soh.report_mark_type IN(" + rmt_sal + ") " + where_store + " THEN soh.qty END),0)*-1 AS `Total Sales|Sales Toko Sale`,
	        IFNULL(SUM(CASE WHEN soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' AND soh.report_mark_type IN(" + rmt_sal + ") " + where_store + " THEN soh.qty END),0)*-1 AS `Total Sales|Grand Total`,
            " + col_soh1 + ",
            " + col_del1 + ",
            " + col_rts1 + ",
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compG78 + ") THEN soh.qty END),0) AS `Stock Gudang Normal|G78`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compGON + ") THEN soh.qty END),0) AS `Stock Gudang Normal|GON`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compS78 + ") THEN soh.qty END),0) AS `Stock Gudang Sale|S78`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compGOS + ") THEN soh.qty END),0) AS `Stock Gudang Sale|GOS`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compREJ + ") THEN soh.qty END),0) AS `Stock Gudang Non Active|Reject`
	        FROM tb_soh_sal_period soh
	        INNER JOIN tb_m_comp c ON c.id_comp = soh.id_comp
	        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
            INNER JOIN tb_m_state state ON state.id_state = cty.id_state
            INNER JOIN tb_m_region reg ON reg.id_region = state.id_region
            INNER JOIN tb_m_country cry ON cry.id_country = reg.id_country
            " + join_design_soh + "
	        WHERE soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' 
            " + where_prod_soh + "
	        GROUP BY soh.id_design 
        ) soh
        LEFT JOIN (
	        SELECT soh.id_design,ABS(SUM(soh.qty)) AS `qty_sal_beg`
	        FROM tb_soh_sal_period soh
            INNER JOIN tb_m_comp c ON c.id_comp = soh.id_comp
	        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
            INNER JOIN tb_m_state state ON state.id_state = cty.id_state
            INNER JOIN tb_m_region reg ON reg.id_region = state.id_region
            INNER JOIN tb_m_country cry ON cry.id_country = reg.id_country
	        WHERE soh.soh_date<'" + fromDate + "' AND  is_del_online_store!=1 AND soh.report_mark_type IN (" + rmt_sal + ")
            " + where_store + "
	        GROUP BY soh.id_design 
        ) sal_beg ON sal_beg.id_design = soh.id_design
        " + join_design + "
        LEFT JOIN (
          SELECT d.id_design, MIN(d.first_del) AS first_del
          FROM tb_m_design_first_del AS d
          INNER JOIN tb_m_comp AS c ON c.id_comp = d.id_comp
          WHERE c.id_store_type = 1 AND c.id_commerce_type = 1 AND c.id_comp_group != 59
          GROUP BY d.id_design
        ) AS first_del ON  first_del.id_design =d.id_design
        LEFT JOIN (
          SELECT id_design, ROUND(design_price) AS design_price, tb_m_design_price.id_design_price_type, tb_lookup_design_price_type.design_price_type
          FROM tb_m_design_price
          INNER JOIN tb_lookup_design_price_type ON tb_lookup_design_price_type.id_design_price_type = tb_m_design_price.id_design_price_type
          WHERE id_design_price IN (
           SELECT MAX(id_design_price) AS id_design_price
           FROM tb_m_design_price
           WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
           GROUP BY id_design
          )
        ) AS price_current ON price_current.id_design = d.id_design
        LEFT JOIN (
          SELECT id_design, ROUND(design_price) AS design_price
          FROM tb_m_design_price
          WHERE id_design_price IN (
           SELECT MAX(id_design_price) AS id_design_price
           FROM tb_m_design_price
           WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
           GROUP BY id_design
          )
        ) AS price_normal ON price_normal.id_design = d.id_design
        LEFT JOIN (
          SELECT id_design, GROUP_CONCAT(design_price_start_date ORDER BY design_price_start_date ASC) AS design_price_start_date
          FROM tb_m_design_price
          WHERE is_active_wh = 1 AND is_design_cost = 0
          GROUP BY id_design
        ) AS price_date ON  price_date.id_design = d.id_design
        LEFT JOIN (
          SELECT s.id_design, SUM(CASE WHEN l.id_pl_category=1 THEN d.pl_prod_order_rec_det_qty END) AS `qty_normal`,
          SUM(CASE WHEN l.id_pl_category!=1 THEN d.pl_prod_order_rec_det_qty END) AS `qty_defect`
          FROM tb_pl_prod_order_rec_det AS d
          LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
          LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
          LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
          LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
          WHERE r.id_report_status = 6
          GROUP BY s.id_design
        ) AS wh_rec ON wh_rec.id_design = d.id_design " + col_join_store_rec
        query += "WHERE 1=1 " + where_prod
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")


        'clear column/band
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading column")
        GVData.Bands.Clear()
        GVData.Columns.Clear()

        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next

        'setu band
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVData.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If data.Columns(j).Caption = "Product Info|Division" Or data.Columns(j).Caption = "Product Info|Category" Or data.Columns(j).Caption = "Product Info|Class" Then
                        col.Group()
                    End If

                    If bandName.Contains("WH Received") Or bandName.Contains("Store Received") Or bandName.Contains("Sales") Or bandName.Contains("SOH") Or bandName.Contains("Monthly Delivery") Or bandName.Contains("Monthly Return") Or bandName.Contains("Stock Gudang") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"

                        'summary
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        col.SummaryItem.DisplayFormat = "{0:n0}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N0}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVData.GroupSummary.Add(summary)
                    End If

                    If bandName.Contains("Sell Thru") Or bandName.Contains("Monthly SAS") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n2}%"
                    End If

                    If bandName = "Price" Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"
                    End If

                    If bandName = "Product Info" Then
                        band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End If
                End If
            Next
        Next

        'data to gv
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading view")
        GCData.DataSource = data
        'FormMain.SplashScreenManager1.SetWaitFormDescription("Bestfit all column")
        'GVData.BestFitColumns()

        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    'Sub viewOldReport()
    '    FormMain.SplashScreenManager1.ShowWaitForm()

    '    Dim selectDate1 As String = ""
    '    Dim selectDate2 As String = ""

    '    Dim selectYear1 As String = ""
    '    Dim selectYear2 As String = ""

    '    Dim selectDateAll As String = ""
    '    Dim selectYearAll As String = ""

    '    Dim selectSellThruMonth As String = ""
    '    Dim selectSellThruAll As String = ""

    '    Dim selectDeliveryAll As String = ""
    '    Dim selectReturnAll As String = ""

    '    Dim year_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(0))
    '    Dim year_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(0))
    '    Dim month_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(1))
    '    Dim month_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(1))

    '    Dim i As Integer = 0
    '    Dim j As Integer = 0

    '    i = year_from
    '    j = month_from

    '    Dim column_receive As String = "wh_rec_normal"

    '    If Not SLUEStore.EditValue.ToString = "0" Or Not SLUECompGroup.EditValue.ToString = "0" Or Not SLUEProvince.EditValue.ToString = "0" Or Not SLUEIsland.EditValue.ToString = "ALL" Then
    '        column_receive = "store_rec"
    '    End If

    '    While i <= year_to
    '        selectDate1 += "IF(`year` = " + i.ToString + " AND `month` = " + j.ToString + ", qty, 0) AS `" + month(j - 1) + " " + i.ToString + "`, "
    '        selectDate2 += "MAX(`" + month(j - 1) + " " + i.ToString + "`) AS `" + month(j - 1) + " " + i.ToString + "`, "

    '        selectDateAll += "IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) AS `Sales " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

    '        selectSellThruMonth += "+ IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0)"

    '        selectSellThruAll += "CONCAT(ROUND((((IFNULL(sales_month_beg.qty, 0) " + selectSellThruMonth + ") / " + column_receive + ".qty) * 100), 2), '%') AS `Monthly Sell Thru " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

    '        selectDeliveryAll += "ROUND(IFNULL(delivery.`" + month(j - 1) + " " + i.ToString + "`, 0)) AS `Monthly Delivery " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

    '        selectReturnAll += "ROUND(IFNULL(`return`.`" + month(j - 1) + " " + i.ToString + "`, 0)) AS `Monthly Return " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

    '        If j = 12 Then
    '            j = 1

    '            i = i + 1
    '        Else
    '            j = j + 1
    '        End If

    '        If i = year_to And j > month_to Then
    '            Exit While
    '        End If
    '    End While

    '    For i = year_from To year_to
    '        selectYear1 += "IF(`year` = " + i.ToString + ", qty, 0) AS `" + i.ToString + "`, "
    '        selectYear2 += "MAX(`" + i.ToString + "`) AS `" + i.ToString + "`, "

    '        selectYearAll += "IFNULL(sales_year.`" + i.ToString + "`, 0) AS `Total Sales|" + i.ToString + "`, "
    '    Next

    '    selectDate1 = selectDate1.Substring(0, selectDate1.Length - 2)
    '    selectDate2 = selectDate2.Substring(0, selectDate2.Length - 2)

    '    selectDateAll = selectDateAll.Substring(0, selectDateAll.Length - 2)

    '    selectYear1 = selectYear1.Substring(0, selectYear1.Length - 2)
    '    selectYear2 = selectYear2.Substring(0, selectYear2.Length - 2)

    '    selectYearAll = selectYearAll.Substring(0, selectYearAll.Length - 2)

    '    selectSellThruAll = selectSellThruAll.Substring(0, selectSellThruAll.Length - 2)

    '    selectDeliveryAll = selectDeliveryAll.Substring(0, selectDeliveryAll.Length - 2)

    '    selectReturnAll = selectReturnAll.Substring(0, selectReturnAll.Length - 2)

    '    'stock date
    '    Dim dateStockDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(year_to, month_to).ToString + ""

    '    Dim queryStockDate As String = "
    '        SELECT STR_TO_DATE(CONCAT(YEAR('" + dateStockDate + "'), '-', MONTH('" + dateStockDate + "'), '-', '01'), '%Y-%m-%d') AS cm_beg_startd, STR_TO_DATE(DATE_SUB(CONCAT(YEAR('" + dateStockDate + "'), '-', MONTH('" + dateStockDate + "'), '-', '01'), INTERVAL 1 DAY), '%Y-%m-%d') AS beg_date, YEAR((SELECT beg_date)) AS beg_year, MONTH((SELECT beg_date)) AS beg_month
    '    "

    '    Dim dataStockDate As DataTable = execute_query(queryStockDate, -1, True, "", "", "", "")

    '    Dim compG78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 371", 0, True, "", "", "", "")
    '    Dim compGON As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1251", 0, True, "", "", "", "")
    '    Dim compS78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 429", 0, True, "", "", "", "")
    '    Dim compGOS As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1255", 0, True, "", "", "", "")
    '    Dim compREJ As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_type IN (3)", 0, True, "", "", "", "")

    '    'stock month
    '    i = year_from
    '    j = month_from

    '    Dim stockMonthQuery1 As String = ""
    '    Dim stockMonthQuery2 As String = ""
    '    Dim stockMonthQuery3 As String = ""
    '    Dim stockMonthQueryAll As String = ""
    '    Dim sohMonthQueryAll As String = ""
    '    Dim sohMonthQueryWhere As String = ""

    '    Dim whereComp As String = ""
    '    Dim whereComp2 As String = ""

    '    If Not SLUECompGroup.EditValue.ToString = "0" Then
    '        whereComp += " AND c.id_comp_group = " + SLUECompGroup.EditValue.ToString
    '        whereComp2 += " AND c.id_comp_group = " + SLUECompGroup.EditValue.ToString
    '    End If

    '    If Not SLUEStore.EditValue.ToString = "0" Then
    '        whereComp += " AND c.id_comp = " + SLUEStore.EditValue.ToString
    '        whereComp2 += " AND c.id_comp = " + SLUEStore.EditValue.ToString
    '    End If

    '    'volcom
    '    If SLUECompGroup.EditValue.ToString = "76" Then
    '        whereComp = " AND c.id_comp IN (1252, 1210, 1256, 1211)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1212" Then
    '        whereComp = " AND c.id_comp IN (1252, 1210)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1213" Then
    '        whereComp = " AND c.id_comp IN (1256, 1211)"
    '    End If

    '    'zalora
    '    If SLUECompGroup.EditValue.ToString = "64" Then
    '        whereComp = " AND c.id_comp IN (1254, 968, 1258, 1012)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "989" Then
    '        whereComp = " AND c.id_comp IN (1254, 968)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1014" Then
    '        whereComp = " AND c.id_comp IN (1258, 1012)"
    '    End If

    '    'blibli
    '    If SLUECompGroup.EditValue.ToString = "75" Then
    '        whereComp = " AND c.id_comp IN (1253, 1180, 1257, 1181)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1177" Then
    '        whereComp = " AND c.id_comp IN (1253, 1180)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1179" Then
    '        whereComp = " AND c.id_comp IN (1257, 1181)"
    '    End If

    '    'shopee
    '    If SLUECompGroup.EditValue.ToString = "77" Then
    '        whereComp = " AND c.id_comp IN (1284, 1285)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1286" Then
    '        whereComp = " AND c.id_comp IN (1284)"
    '    End If

    '    If SLUEStore.EditValue.ToString = "1287" Then
    '        whereComp = " AND c.id_comp IN (1285)"
    '    End If

    '    Dim whereLocation As String = ""

    '    If Not SLUENational.EditValue.ToString = "0" Then
    '        whereLocation += " AND g.id_country = " + SLUENational.EditValue.ToString
    '    End If

    '    If Not SLUEIsland.EditValue.ToString = "ALL" Then
    '        whereLocation += " AND t.island = '" + SLUEIsland.EditValue.ToString + "'"
    '    End If

    '    If Not SLUEProvince.EditValue.ToString = "0" Then
    '        whereLocation += " AND t.id_state = " + SLUEProvince.EditValue.ToString
    '    End If

    '    While i <= year_to
    '        Dim stockMonthFirst As String = "" + i.ToString + "-" + j.ToString.PadLeft(2, "0") + "-01"
    '        Dim stockMonthDate As String = "" + i.ToString + "-" + j.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(i, j).ToString + ""

    '        Dim queryMonthDate As String = "
    '            SELECT STR_TO_DATE(CONCAT(YEAR('" + stockMonthDate + "'), '-', MONTH('" + stockMonthDate + "'), '-', '01'), '%Y-%m-%d') AS cm_beg_startd, STR_TO_DATE(DATE_SUB(CONCAT(YEAR('" + stockMonthDate + "'), '-', MONTH('" + stockMonthDate + "'), '-', '01'), INTERVAL 1 DAY), '%Y-%m-%d') AS beg_date, YEAR((SELECT beg_date)) AS beg_year, MONTH((SELECT beg_date)) AS beg_month
    '        "

    '        Dim dataMonthDate As DataTable = execute_query(queryMonthDate, -1, True, "", "", "", "")

    '        stockMonthQuery1 += "
    '            (
    '                SELECT d.id_design, IFNULL(inv.inv_qty_ttl, 0) AS inv_qty_ttl, " + i.ToString + " AS `year`, " + j.ToString + " AS `month`
    '                FROM tb_m_design d
    '                LEFT JOIN (
    '                    SELECT p.id_design, SUM(a.qty_ttl) AS inv_qty_ttl
    '                    FROM (
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, f.qty_ttl
    '                            FROM tb_storage_fg_" + dataMonthDate.Rows(0)("beg_year").ToString + " AS f
    '                            WHERE f.month = '" + dataMonthDate.Rows(0)("beg_month").ToString + "'
    '                        )
    '                        UNION ALL 
    '                        -- beginning sal tanpa online
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '                            FROM (
    '                                SELECT * FROM tb_storage_fg AS f
    '                                WHERE f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.id_stock_status = 1
    '                                AND f.report_mark_type IN (48, 66, 54, 67, 118, 117, 183, 116, 292)
    '                            ) AS f
    '                            INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
    '                            INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
    '                            INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
    '                            WHERE sp.id_report_status = 6
    '                            AND c.id_comp NOT IN (1212, 1213)
    '                            AND sp.sales_pos_end_period < '" + stockMonthFirst + "' 
    '                            GROUP BY f.id_product, f.id_wh_drawer
    '                        )
    '                        UNION ALL
    '                        -- beginning CN VIOS
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '                            FROM (
    '                                SELECT * FROM tb_storage_fg f
    '                                WHERE f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.id_stock_status = 1
    '                                AND f.report_mark_type = 118
    '                            ) f
    '                            INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
    '                            INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
    '                            INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
    '                            WHERE sp.id_report_status = 6
    '                            AND c.id_comp IN (1212, 1213)
    '                            AND sp.sales_pos_end_period < '" + stockMonthFirst + "' 
    '                            GROUP BY f.id_product, f.id_wh_drawer
    '                        )
    '                        UNION ALL 
    '                        -- stok tanpa sal
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS qty_ttl
    '                            FROM tb_storage_fg AS f
    '                            WHERE f.id_stock_status = 1 
    '                            AND (f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.storage_product_datetime <= '" + stockMonthDate + " 23:59:59')
    '                            AND f.report_mark_type NOT IN (48, 66, 54, 67, 118, 117, 183, 116, 292)
    '                            GROUP BY f.id_product, f.id_wh_drawer 
    '                        )
    '                        -- sal 
    '                        UNION ALL
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '                            FROM tb_storage_fg AS f
    '                            INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
    '                            INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact= IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
    '                            INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
    '                            WHERE f.id_stock_status = 1
    '                            AND f.report_mark_type IN (48, 66, 54, 67, 118, 117, 183, 116, 292) AND sp.id_report_status = 6
    '                            AND c.id_comp NOT IN (1212, 1213)
    '                            AND sp.sales_pos_end_period >= '" + stockMonthFirst + "' AND sp.sales_pos_end_period <= '" + stockMonthDate + "' 
    '                            GROUP BY f.id_product, f.id_wh_drawer
    '                        )
    '                        -- CN VIOS
    '                        UNION ALL 
    '                        (
    '                            SELECT f.id_product, f.id_wh_drawer, 
    '                            SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl 
    '                            FROM tb_storage_fg AS f
    '                            INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
    '                            INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
    '                            INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
    '                            WHERE f.id_stock_status = 1
    '                            AND f.report_mark_type = 118 AND sp.id_report_status=6
    '                            AND c.id_comp IN (1212, 1213)
    '                            AND sp.sales_pos_end_period >= '" + stockMonthFirst + "' AND sp.sales_pos_end_period <= '" + stockMonthDate + "' 
    '                            GROUP BY f.id_product, f.id_wh_drawer
    '                        )
    '                    ) a
    '                    INNER JOIN tb_m_product p ON p.id_product = a.id_product
    '                    INNER JOIN tb_m_wh_drawer AS d ON d.id_wh_drawer = a.id_wh_drawer
    '                    INNER JOIN tb_m_wh_rack AS r ON d.id_wh_rack = r.id_wh_rack
    '                    INNER JOIN tb_m_wh_locator AS l ON r.id_wh_locator = l.id_wh_locator
    '                    INNER JOIN tb_m_comp AS c ON l.id_comp = c.id_comp
    '                    INNER JOIN tb_m_city AS t ON c.id_city = t.id_city
    '                    INNER JOIN tb_m_state AS e ON t.id_state = e.id_state
    '                    INNER JOIN tb_m_region AS g ON e.id_region = g.id_region
    '                    WHERE (c.id_wh_type IN (1, 2) OR c.id_wh_type IS NULL) " + whereComp + " " + whereLocation + "
    '                    GROUP BY p.id_design
    '                ) inv ON inv.id_design = d.id_design
    '                WHERE d.id_lookup_status_order <> 2
    '                GROUP BY d.id_design
    '            )
    '            UNION ALL
    '        "

    '        stockMonthQuery2 += "IF(t.year = " + i.ToString + " AND t.month = " + j.ToString + ", inv_qty_ttl, 0) AS `" + month(j - 1) + " " + i.ToString + "`, "
    '        stockMonthQuery3 += "MAX(`" + month(j - 1) + " " + i.ToString + "`) AS `" + month(j - 1) + " " + i.ToString + "`, "
    '        stockMonthQueryAll += "CONCAT((ROUND((IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) / (IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) + IFNULL(stock_month.`" + month(j - 1) + " " + i.ToString + "`, 0))) * 100, 2)), '%') AS `Monthly SAS " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "
    '        sohMonthQueryAll += "IFNULL(stock_month.`" + month(j - 1) + " " + i.ToString + "`, 0) AS `Monthly SOH " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "
    '        sohMonthQueryWhere += " OR (tb.`Monthly SOH " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "` <> 0)"

    '        If j = 12 Then
    '            j = 1

    '            i = i + 1
    '        Else
    '            j = j + 1
    '        End If

    '        If i = year_to And j > month_to Then
    '            Exit While
    '        End If
    '    End While

    '    stockMonthQuery1 = stockMonthQuery1.Substring(0, stockMonthQuery1.Length - 25)
    '    stockMonthQuery2 = stockMonthQuery2.Substring(0, stockMonthQuery2.Length - 2)
    '    stockMonthQuery3 = stockMonthQuery3.Substring(0, stockMonthQuery3.Length - 2)
    '    stockMonthQueryAll = stockMonthQueryAll.Substring(0, stockMonthQueryAll.Length - 2)
    '    sohMonthQueryAll = sohMonthQueryAll.Substring(0, sohMonthQueryAll.Length - 2)

    '    'where
    '    Dim where As String = ""

    '    If Not CCBESeason.EditValue.ToString = "" Then
    '        where += " AND design.id_season IN (" + CCBESeason.EditValue.ToString + ")"
    '    End If

    '    If Not CCBEDivision.EditValue.ToString = "" Then
    '        where += " AND division.id_code_detail IN (" + CCBEDivision.EditValue.ToString + ")"
    '    End If

    '    If Not CCBECategory.EditValue.ToString = "" Then
    '        where += " AND category.id_code_detail IN (" + CCBECategory.EditValue.ToString + ")"
    '    End If

    '    If Not CCBEClass.EditValue.ToString = "" Then
    '        where += " AND class.id_code_detail IN (" + CCBEClass.EditValue.ToString + ")"
    '    End If

    '    If Not TEProductCode.EditValue.ToString = "" Then
    '        where += " AND design.design_code IN ('" + String.Join("','", TEProductCode.EditValue.ToString.Split(",")) + "')"
    '    End If

    '    Dim whereSalesPos As String = " AND s.sales_pos_end_period BETWEEN '" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01' AND '" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(year_to, month_to).ToString + "'"

    '    If Not SLUENational.EditValue.ToString = "0" Then
    '        whereSalesPos += " AND r.id_country = " + SLUENational.EditValue.ToString
    '    End If

    '    If Not SLUEIsland.EditValue.ToString = "ALL" Then
    '        whereSalesPos += " AND y.island = '" + SLUEIsland.EditValue.ToString + "'"
    '    End If

    '    If Not SLUEProvince.EditValue.ToString = "0" Then
    '        whereSalesPos += " AND y.id_state = " + SLUEProvince.EditValue.ToString
    '    End If

    '    If Not SLUEStore.EditValue.ToString = "0" Then
    '        whereSalesPos += " AND t.id_comp = " + SLUEStore.EditValue.ToString
    '    End If

    '    If Not SLUECompGroup.EditValue.ToString = "0" Then
    '        whereSalesPos += " AND t.id_comp_group = " + SLUECompGroup.EditValue.ToString
    '    End If

    '    Dim fromDate As String = "" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01"
    '    Dim untilDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(year_to, month_to).ToString + ""

    '    Dim query As String = "
    '        SELECT *
    '        FROM (
    '            SELECT design.design_code AS `Product Info|Code`, division.display_name AS `Product Info|Division`,
    '             category.display_name AS `Product Info|Category`, class.display_name AS `Product Info|Class`,
    '             design.design_display_name AS `Product Info|Description`, color.code_detail_name AS `Product Info|Color`,
    '             season.season AS `Product Info|Season`, delivery.delivery AS `Product Info|Delivery`, range.year_range AS `Product Info|Year`,
    '             source.display_name AS `Product Info|Source`,
    '             DATE_FORMAT(design.design_first_rec_wh, '%d %M %Y') AS `Product Age|WH Date`,
    '             DATE_FORMAT(first_del.first_del, '%d %M %Y') AS `Product Age|Del Date`,
    '             TIMESTAMPDIFF(MONTH, design.design_first_rec_wh, NOW()) AS `Product Age|WH Age`,
    '             TIMESTAMPDIFF(MONTH, first_del.first_del, NOW()) AS `Product Age|Del Age`,
    '             FORMAT(price_normal.design_price, 2) AS `Price|Normal`,
    '             FORMAT(IF(price_current.design_price = price_normal.design_price, '', price_current.design_price), 2) AS `Price|Current`,
    '             DATE_FORMAT(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 1), '%d %M %Y') AS `Price Update Dates|Price U1`,
    '             DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 2), 12), '%d %M %Y') AS `Price Update Dates|Price U2`,
    '             DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 3), 23), '%d %M %Y') AS `Price Update Dates|Price U3`,
    '             DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 4), 34), '%d %M %Y') AS `Price Update Dates|Price U4`,
    '             DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 5), 45), '%d %M %Y') AS `Price Update Dates|Price U5`,
    '             DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 6), 56), '%d %M %Y') AS `Price Update Dates|Price U6`,
    '             price_type.design_price_type AS `Price Update Dates|Current Status`, ROUND(wh_rec_normal.qty) AS `WH Received|Normal (BOS)`, ROUND(wh_rec_defect.qty) AS `WH Received|Defect`,
    '             ROUND((wh_rec_normal.qty + wh_rec_defect.qty)) AS `WH Received|Total`, 
    '                " + If(Not SLUEStore.EditValue.ToString = "0" Or Not SLUECompGroup.EditValue.ToString = "0" Or Not SLUEProvince.EditValue.ToString = "0" Or Not SLUEIsland.EditValue.ToString = "ALL", "ROUND(store_rec.qty) AS `Store Received|Total`, ", "") + "
    '                " + selectDateAll + ", " + selectYearAll + ", 
    '                ROUND(IFNULL(sales_normal.qty, 0)) AS `Total Sales|Sales Toko Normal`, ROUND(IFNULL(sales_sale.qty, 0)) AS `Total Sales|Sales Toko Sale`,
    '                ROUND((IFNULL(sales_normal.qty, 0) + IFNULL(sales_sale.qty, 0))) AS `Total Sales|Grand Total`,
    '                CONCAT(ROUND((IFNULL(sales_normal.qty, 0) / IFNULL(" + column_receive + ".qty, 0) * 100), 2), '%') AS `Sell Thru|Normal`, 
    '                CONCAT(ROUND((IFNULL(sales_sale.qty, 0) / (IFNULL(" + column_receive + ".qty, 0) - IFNULL(sales_normal.qty, 0)) * 100), 2), '%') AS `Sell Thru|Sale`,
    '                CONCAT(ROUND(((IFNULL(sales_normal.qty, 0) + IFNULL(sales_sale.qty, 0)) / IFNULL(" + column_receive + ".qty, 0) * 100), 2), '%') AS `Sell Thru|Total`, 
    '                " + sohMonthQueryAll + ",
    '                " + stockMonthQueryAll + ",
    '                " + selectSellThruAll + ",
    '                " + selectDeliveryAll + ",
    '                " + selectReturnAll + ",
    '                ROUND(IFNULL(stock_g78.qty, 0)) AS `Stock Gudang Normal|G78`, ROUND(IFNULL(stock_gon.qty, 0)) AS `Stock Gudang Normal|GON`, ROUND(IFNULL(stock_s78.qty, 0)) AS `Stock Gudang Sale|S78`, ROUND(IFNULL(stock_gos.qty, 0)) AS `Stock Gudang Sale|GOS`, ROUND(IFNULL(stock_rej.qty, 0)) AS `Stock Gudang Non Aktive|Reject`
    '            FROM tb_m_design AS design
    '            LEFT JOIN (
    '             SELECT c.id_design, d.id_code_detail, d.display_name
    '             FROM tb_m_design_code AS c
    '             LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
    '             WHERE d.id_code = 32
    '            ) AS division ON design.id_design = division.id_design
    '            LEFT JOIN (
    '             SELECT c.id_design, d.id_code_detail, d.display_name
    '             FROM tb_m_design_code AS c
    '             LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
    '             WHERE d.id_code = 4
    '            ) AS category ON design.id_design = category.id_design
    '            LEFT JOIN (
    '             SELECT c.id_design, d.id_code_detail, d.display_name
    '             FROM tb_m_design_code AS c
    '             LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
    '             WHERE d.id_code = 30
    '            ) AS class ON design.id_design = class.id_design
    '            LEFT JOIN (
    '             SELECT c.id_design, d.code_detail_name
    '             FROM tb_m_design_code AS c
    '             LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
    '             WHERE d.id_code = 14
    '            ) AS color ON design.id_design = color.id_design
    '            LEFT JOIN (
    '             SELECT c.id_design, d.display_name
    '             FROM tb_m_design_code AS c
    '             LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
    '             WHERE d.id_code = 5
    '            ) AS source ON design.id_design = source.id_design
    '            LEFT JOIN tb_season AS season ON design.id_season = season.id_season
    '            LEFT JOIN tb_range AS `range` ON season.id_range = range.id_range
    '            LEFT JOIN tb_season_delivery AS delivery ON design.id_delivery = delivery.id_delivery
    '            LEFT JOIN (
    '             SELECT d.id_design, MIN(d.first_del) AS first_del
    '             FROM tb_m_design_first_del AS d
    '             INNER JOIN tb_m_comp AS c ON c.id_comp = d.id_comp
    '             WHERE c.id_store_type = 1 AND c.id_commerce_type = 1 AND c.id_comp_group != 59
    '             GROUP BY d.id_design
    '            ) AS first_del ON design.id_design = first_del.id_design
    '            LEFT JOIN (
    '             SELECT id_design, ROUND(design_price) AS design_price, id_design_price_type
    '             FROM tb_m_design_price
    '             WHERE id_design_price IN (
    '              SELECT MAX(id_design_price) AS id_design_price
    '              FROM tb_m_design_price
    '              WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
    '              GROUP BY id_design
    '             )
    '            ) AS price_current ON design.id_design = price_current.id_design
    '            LEFT JOIN (
    '             SELECT id_design, ROUND(design_price) AS design_price
    '             FROM tb_m_design_price
    '             WHERE id_design_price IN (
    '              SELECT MAX(id_design_price) AS id_design_price
    '              FROM tb_m_design_price
    '              WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
    '              GROUP BY id_design
    '             )
    '            ) AS price_normal ON design.id_design = price_normal.id_design
    '            LEFT JOIN (
    '             SELECT id_design, GROUP_CONCAT(design_price_start_date ORDER BY design_price_start_date ASC) AS design_price_start_date
    '             FROM tb_m_design_price
    '             WHERE is_active_wh = 1 AND is_design_cost = 0
    '             GROUP BY id_design
    '            ) AS price_date ON design.id_design = price_date.id_design
    '            LEFT JOIN tb_lookup_design_price_type AS price_type ON price_current.id_design_price_type = price_type.id_design_price_type
    '            LEFT JOIN (
    '             SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
    '             FROM tb_pl_prod_order_rec_det AS d
    '             LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
    '             LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
    '             LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
    '             LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
    '             WHERE r.id_report_status = 6 AND l.id_pl_category = 1
    '             GROUP BY s.id_design
    '            ) AS wh_rec_normal ON design.id_design = wh_rec_normal.id_design
    '            LEFT JOIN (
    '             SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
    '             FROM tb_pl_prod_order_rec_det AS d
    '             LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
    '             LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
    '             LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
    '             LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
    '             WHERE r.id_report_status = 6 AND l.id_pl_category <> 1
    '             GROUP BY s.id_design
    '            ) AS wh_rec_defect ON design.id_design = wh_rec_defect.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(ROUND(d.sales_pos_det_qty)) AS qty
    '                FROM tb_sales_pos_det AS d
    '                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
    '                LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
    '                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
    '                LEFT JOIN tb_m_city AS t ON c.id_city = t.id_city
    '                LEFT JOIN tb_m_state AS e ON t.id_state = e.id_state
    '                LEFT JOIN tb_m_region AS g ON e.id_region = g.id_region
    '                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
    '                WHERE s.id_report_status = 6 " + whereComp2 + " " + whereLocation + " AND s.sales_pos_end_period < '" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01'
    '                GROUP BY p.id_design
    '            ) sales_month_beg ON sales_month_beg.id_design = design.id_design
    '            LEFT JOIN (
    '                SELECT id_design, " + selectDate2 + "
    '                FROM (
    '                 SELECT id_design, " + selectDate1 + "
    '                 FROM (
    '                  SELECT p.id_design, YEAR(s.sales_pos_end_period) AS `year`, MONTH(s.sales_pos_end_period) AS `month`, SUM(ROUND(d.sales_pos_det_qty)) AS qty
    '                  FROM tb_sales_pos_det AS d
    '                  LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
    '                        LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
    '                        LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
    '                        LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
    '                        LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
    '                        LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
    '                  LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
    '                  WHERE s.id_report_status = 6 " + whereSalesPos + "
    '                  GROUP BY p.id_design, YEAR(s.sales_pos_end_period), MONTH(s.sales_pos_end_period)
    '                 ) AS t
    '                ) AS t
    '                GROUP BY id_design
    '            ) AS sales_month ON sales_month.id_design = design.id_design
    '            LEFT JOIN (
    '                SELECT id_design, " + selectYear2 + "
    '                FROM (
    '                 SELECT id_design, " + selectYear1 + "
    '                 FROM (
    '                  SELECT p.id_design, YEAR(s.sales_pos_end_period) AS `year`, SUM(ROUND(d.sales_pos_det_qty)) AS qty
    '                  FROM tb_sales_pos_det AS d
    '                  LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
    '                        LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
    '                        LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
    '                        LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
    '                        LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
    '                        LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
    '                  LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
    '                  WHERE s.id_report_status = 6 " + whereSalesPos + "
    '                  GROUP BY p.id_design, YEAR(s.sales_pos_end_period)
    '                 ) AS t
    '                ) AS t
    '                GROUP BY id_design
    '            ) AS sales_year ON sales_year.id_design = design.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(ROUND(d.sales_pos_det_qty)) AS qty
    '                FROM tb_sales_pos_det AS d
    '                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
    '                LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
    '                LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
    '                LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
    '                LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
    '                LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
    '                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
    '                WHERE s.id_report_status = 6 AND t.id_store_type = 1 " + whereSalesPos + "
    '                GROUP BY p.id_design
    '            ) AS sales_normal ON design.id_design = sales_normal.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(ROUND(d.sales_pos_det_qty)) AS qty
    '                FROM tb_sales_pos_det AS d
    '                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
    '                LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
    '                LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
    '                LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
    '                LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
    '                LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
    '                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
    '                WHERE s.id_report_status = 6 " + whereSalesPos + " AND (t.id_store_type <> 1 OR t.id_store_type IS NULL)
    '                GROUP BY p.id_design
    '            ) AS sales_sale ON design.id_design = sales_sale.id_design
    '            LEFT JOIN (
    '                SELECT t.id_design, " + stockMonthQuery3 + "
    '                FROM (
    '                    SELECT t.id_design, " + stockMonthQuery2 + "
    '                    FROM (
    '                        " + stockMonthQuery1 + "
    '                    ) AS t
    '                ) AS t
    '                GROUP BY t.id_design
    '            ) AS stock_month ON design.id_design = stock_month.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(a.qty_ttl) AS qty
    '    FROM (
    '	    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
    '	    FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
    '	    WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
    '	    UNION ALL
    '	    SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '	    FROM tb_storage_fg AS f
    '	    WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
    '	    GROUP BY f.id_wh_drawer, f.id_product
    '    ) AS a
    '    INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
    '    INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
    '    INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compG78 + ")
    '    INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
    '                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
    '    GROUP BY p.id_design
    '            ) AS stock_g78 ON design.id_design = stock_g78.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(a.qty_ttl) AS qty
    '    FROM (
    '	    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
    '	    FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
    '	    WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
    '	    UNION ALL
    '	    SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '	    FROM tb_storage_fg AS f
    '	    WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
    '	    GROUP BY f.id_wh_drawer, f.id_product
    '    ) AS a
    '    INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
    '    INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
    '    INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compGON + ")
    '    INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
    '                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
    '    GROUP BY p.id_design
    '            ) AS stock_gon ON design.id_design = stock_gon.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(a.qty_ttl) AS qty
    '    FROM (
    '	    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
    '	    FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
    '	    WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
    '	    UNION ALL
    '	    SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '	    FROM tb_storage_fg AS f
    '	    WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
    '	    GROUP BY f.id_wh_drawer, f.id_product
    '    ) AS a
    '    INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
    '    INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
    '    INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compS78 + ")
    '    INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
    '                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
    '    GROUP BY p.id_design
    '            ) AS stock_s78 ON design.id_design = stock_s78.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(a.qty_ttl) AS qty
    '    FROM (
    '	    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
    '	    FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
    '	    WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
    '	    UNION ALL
    '	    SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '	    FROM tb_storage_fg AS f
    '	    WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
    '	    GROUP BY f.id_wh_drawer, f.id_product
    '    ) AS a
    '    INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
    '    INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
    '    INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compGOS + ")
    '    INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
    '                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
    '    GROUP BY p.id_design
    '            ) AS stock_gos ON design.id_design = stock_gos.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(a.qty_ttl) AS qty
    '    FROM (
    '	    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
    '	    FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
    '	    WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
    '	    UNION ALL
    '	    SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
    '	    FROM tb_storage_fg AS f
    '	    WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
    '	    GROUP BY f.id_wh_drawer, f.id_product
    '    ) AS a
    '    INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
    '    INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
    '    INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compREJ + ")
    '    INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
    '                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
    '    GROUP BY p.id_design
    '            ) AS stock_rej ON design.id_design = stock_rej.id_design
    '            LEFT JOIN (
    '                SELECT p.id_design, SUM(d.pl_sales_order_del_det_qty) AS qty
    '                FROM tb_pl_sales_order_del AS s
    '                LEFT JOIN tb_pl_sales_order_del_det AS d ON d.id_pl_sales_order_del = s.id_pl_sales_order_del
    '                LEFT JOIN tb_m_comp_contact w ON w.id_comp_contact = s.id_store_contact_to
    '                LEFT JOIN tb_m_comp c ON c.id_comp = w.id_comp
    '                LEFT JOIN tb_m_product p ON p.id_product = d.id_product
    '                LEFT JOIN tb_m_city AS t ON c.id_city = t.id_city
    '                LEFT JOIN tb_m_state AS e ON t.id_state = e.id_state
    '                LEFT JOIN tb_m_region AS g ON e.id_region = g.id_region
    '                WHERE s.id_pl_sales_order_del > 0 AND s.id_report_status = 6 " + whereComp2 + " " + whereLocation + "
    '                GROUP BY p.id_design
    '            ) AS store_rec ON store_rec.id_design = design.id_design
    '            LEFT JOIN (
    '                SELECT id_design, " + selectDate2 + "
    '                FROM (
    '                 SELECT id_design, " + selectDate1 + "
    '                 FROM (
    '                        SELECT p.id_design, YEAR(d.pl_sales_order_del_date) AS `year`, MONTH(d.pl_sales_order_del_date) AS `month`, SUM(o.pl_sales_order_del_det_qty) AS qty
    '                        FROM tb_pl_sales_order_del_det AS o
    '                        LEFT JOIN tb_pl_sales_order_del AS d ON o.id_pl_sales_order_del = d.id_pl_sales_order_del
    '                        LEFT JOIN tb_m_product AS p ON o.id_product = p.id_product
    '                        LEFT JOIN tb_m_comp_contact AS w ON d.id_store_contact_to = w.id_comp_contact
    '                        LEFT JOIN tb_m_comp AS c ON c.id_comp = w.id_comp
    '                        LEFT JOIN tb_m_city AS t ON c.id_city = t.id_city
    '                        LEFT JOIN tb_m_state AS e ON t.id_state = e.id_state
    '                        LEFT JOIN tb_m_region AS g ON e.id_region = g.id_region
    '                        WHERE d.id_report_status = 6 AND d.pl_sales_order_del_date BETWEEN '" + fromDate + "' AND '" + untilDate + "' " + whereComp2 + " " + whereLocation + "
    '                        GROUP BY p.id_design, YEAR(d.pl_sales_order_del_date), MONTH(d.pl_sales_order_del_date)
    '                    ) AS t
    '                ) AS t
    '                GROUP BY id_design
    '            ) AS delivery ON design.id_design = delivery.id_design
    '            LEFT JOIN (
    '                SELECT id_design, " + selectDate2 + "
    '                FROM (
    '                 SELECT id_design, " + selectDate1 + "
    '                 FROM (
    '                        SELECT p.id_design, YEAR(r.sales_return_date) AS `year`, MONTH(r.sales_return_date) AS `month`, SUM(o.sales_return_det_qty) AS qty
    '                        FROM tb_sales_return_det AS o
    '                        LEFT JOIN tb_sales_return AS r ON o.id_sales_return = r.id_sales_return
    '                        LEFT JOIN tb_m_product AS p ON o.id_product = p.id_product
    '                        LEFT JOIN tb_m_comp_contact AS w ON r.id_comp_contact_to = w.id_comp_contact
    '                        LEFT JOIN tb_m_comp AS c ON c.id_comp = w.id_comp
    '                        LEFT JOIN tb_m_city AS t ON c.id_city = t.id_city
    '                        LEFT JOIN tb_m_state AS e ON t.id_state = e.id_state
    '                        LEFT JOIN tb_m_region AS g ON e.id_region = g.id_region
    '                        WHERE r.id_report_status = 6 AND r.sales_return_date BETWEEN '" + fromDate + "' AND '" + untilDate + "' " + whereComp2 + " " + whereLocation + "
    '                        GROUP BY p.id_design, YEAR(r.sales_return_date), MONTH(r.sales_return_date)
    '                    ) AS t
    '                ) AS t
    '                GROUP BY id_design
    '            ) AS `return` ON design.id_design = `return`.id_design
    '            WHERE design.id_lookup_status_order <> 2 AND design.design_code <> '' " + where + "
    '            ORDER BY design.design_first_rec_wh ASC
    '        ) AS tb
    '        WHERE tb.`Total Sales|Grand Total` <> 0 " + sohMonthQueryWhere + " 
    '    "

    '    Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")

    '    GVData.Bands.Clear()
    '    GVData.Columns.Clear()

    '    Dim column As List(Of String) = New List(Of String)

    '    For i = 0 To data.Columns.Count - 1
    '        Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

    '        If Not column.Contains(bandName) Then
    '            column.Add(bandName)
    '        End If
    '    Next

    '    For i = 0 To column.Count - 1
    '        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

    '        band.Caption = column(i)

    '        GVData.Bands.Add(band)

    '        For j = 0 To data.Columns.Count - 1
    '            Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
    '            Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

    '            If bandName = column(i) Then
    '                Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

    '                col.Caption = coluName
    '                col.VisibleIndex = j
    '                col.FieldName = data.Columns(j).Caption

    '                band.Columns.Add(col)

    '                If data.Columns(j).Caption = "Product Info|Division" Or data.Columns(j).Caption = "Product Info|Category" Or data.Columns(j).Caption = "Product Info|Class" Then
    '                    col.Group()
    '                End If

    '                If bandName.Contains("WH Received") Or bandName.Contains("Store Received") Or bandName.Contains("Sales") Or bandName.Contains("Stock Gudang") Then
    '                    Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

    '                    summary.DisplayFormat = "{0:N0}"
    '                    summary.FieldName = data.Columns(j).Caption
    '                    summary.ShowInGroupColumnFooter = col
    '                    summary.SummaryType = DevExpress.Data.SummaryItemType.Sum

    '                    GVData.GroupSummary.Add(summary)
    '                End If

    '                If bandName.Contains("Sell Thru") Or bandName.Contains("Monthly SAS") Or bandName = "Price" Then
    '                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '                End If

    '                If bandName = "Product Info" Then
    '                    band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
    '                End If
    '            End If
    '        Next
    '    Next

    '    GCData.DataSource = data

    '    GVData.BestFitColumns()

    '    FormMain.SplashScreenManager1.CloseWaitForm()
    'End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
    End Sub

    Private Sub FormMonthlySalesPerformance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMonthlySalesPerformance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        month.Add("Jan")
        month.Add("Feb")
        month.Add("Mar")
        month.Add("Apr")
        month.Add("May")
        month.Add("Jun")
        month.Add("Jul")
        month.Add("Aug")
        month.Add("Sep")
        month.Add("Oct")
        month.Add("Nov")
        month.Add("Dec")

        view_month()
        view_category_store()
        viewArea()
        view_national()
        view_island()
        view_province()
        view_group_store()
        view_store()
        view_season()
        view_division()
        view_category()
        view_class()
    End Sub
    Sub viewArea()
        Dim query As String = "SELECT a.id_area, a.`area` FROM tb_m_area a 
ORDER BY area ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("area").ToString
            c.Value = data.Rows(i)("id_area").ToString

            CCBEArea.Properties.Items.Add(c)
        Next
    End Sub


    Sub view_category_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_cat`, 'All' AS `cat`
        UNION ALL 
        SELECT 1 AS `id_cat`, 'Wholesale' AS `cat` 
        UNION ALL
        SELECT 2 AS `id_cat`, 'Consignment' AS `cat`
        UNION ALL
        SELECT 3 AS `id_cat`, 'Online' AS `cat`
        UNION ALL
        SELECT 4 AS `id_cat`, 'B&B Wholesale' AS `cat` "
        viewLookupQuery(LECat, query, 0, "cat", "id_cat")
        Cursor = Cursors.Default
    End Sub

    Sub view_season()
        Dim query As String = "
            SELECT a.id_season, a.season
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_division()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEDivision.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_category()
        Dim query As String = "
            SELECT id_code_detail, display_name AS `code`
            FROM tb_m_code_detail
            WHERE id_code = 4
            ORDER BY display_name ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBECategory.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_class()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 30
            ORDER BY `code` ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEClass.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_month()
        Dim data As DataTable = New DataTable

        data.Columns.Add("month_code", GetType(String))
        data.Columns.Add("month", GetType(String))

        Dim first_year As Integer = 2020
        Dim last_year As Integer = Date.Now.Year

        For i = last_year To first_year Step -1
            If i = last_year Then
                For j = Date.Now.Month To 1 Step -1
                    data.Rows.Add(i.ToString + "-" + j.ToString, month(j - 1) + " " + i.ToString)
                Next
            Else
                For j = 12 To 1 Step -1
                    data.Rows.Add(i.ToString + "-" + j.ToString, month(j - 1) + " " + i.ToString)
                Next
            End If
        Next

        SLUEMonthFrom.Properties.DataSource = data
        SLUEMonthFrom.Properties.DisplayMember = "month"
        SLUEMonthFrom.Properties.ValueMember = "month_code"

        SLUEMonthTo.Properties.DataSource = data
        SLUEMonthTo.Properties.DisplayMember = "month"
        SLUEMonthTo.Properties.ValueMember = "month_code"

        SLUEMonthFrom.EditValue = Date.Now.Year.ToString + "-1"
        SLUEMonthTo.EditValue = Date.Now.Year.ToString + "-" + Date.Now.Month.ToString
    End Sub

    Sub view_national()
        Dim query As String = "
            SELECT id_country AS id_national, country AS national
            FROM tb_m_country 
            WHERE is_domestic = 1
        "

        viewSearchLookupQuery(SLUENational, query, "id_national", "national", "id_national")
    End Sub

    Sub view_island()
        Dim query As String = "
            (SELECT 'ALL' AS island)
            UNION ALL
            (SELECT DISTINCT(island) AS island
            FROM tb_m_city AS c
            LEFT JOIN tb_m_state AS s ON c.id_state = s.id_state
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = " + SLUENational.EditValue.ToString + " AND island IS NOT NULL)
        "

        viewSearchLookupQuery(SLUEIsland, query, "island", "island", "island")
    End Sub

    Sub view_province()
        Dim where As String = ""

        'If Not SLUEIsland.EditValue = "ALL" Then
        '    where = " AND s.id_state IN (SELECT id_state FROM tb_m_city WHERE island = '" + SLUEIsland.EditValue.ToString + "')"
        'End If

        Dim query As String = "
            (SELECT s.id_state AS id_province, s.state AS province
            FROM tb_m_state AS s
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = " + SLUENational.EditValue.ToString + where + ")
            ORDER BY province ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("province").ToString
            c.Value = data.Rows(i)("id_province").ToString

            CCBEProvince.Properties.Items.Add(c)
        Next
    End Sub

    Sub defaultView()
        GCData.DataSource = Nothing
    End Sub


    Sub view_store()
        Cursor = Cursors.WaitCursor
        defaultView()

        'filter
        Dim where As String = ""
        Dim id_cat As String = "-1"
        Try
            id_cat = LECat.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_cat = "1" Then
            'wholesale
            where += "AND c.id_comp_group='59' AND c.id_commerce_type='1 ' "
        ElseIf id_cat = "2" Then
            'consingment
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='1' "
        ElseIf id_cat = "3" Then
            'online
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='2' "
        ElseIf id_cat = "4" Then
            'b&b wholesale
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group='7' AND c.id_commerce_type='1' "
        Else
            where += ""
        End If
        Dim id_area As String = ""
        Try
            id_area = CCBEArea.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_area <> "" Then
            where += "AND c.id_area IN (" + id_area + ") "
        End If
        Dim id_province As String = ""
        Try
            id_province = CCBEProvince.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_province <> "" Then
            where += "AND cty.id_state IN(" + id_province + ") "
        End If
        Dim id_group_store As String = ""
        Try
            id_group_store = CCBEGroupStore.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_group_store <> "" Then
            where += "AND c.id_comp_group IN(" + id_group_store + ") "
        End If
        If CEActiveStore.Checked Then
            where += "AND c.is_active = 1"
        End If

        'view
        Dim query As String = "SELECT c.id_comp, c.comp_name, c.comp_number, c.id_commerce_type, IFNULL(olc.id_wh_ol,0) AS `id_wh_ol`, 'No' AS `is_select` 
        FROM tb_m_comp c 
        LEFT JOIN (
            SELECT olc.id_store,GROUP_CONCAT(DISTINCT olc.id_wh) AS `id_wh_ol` 
            FROM tb_ol_store_comp olc
            GROUP BY olc.id_store
        ) olc ON olc.id_store = c.id_comp
        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
        WHERE c.id_comp_cat=6 " + where + " ORDER BY c.comp_number ASC "
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")
        GCStore.DataSource = data
        GVStore.BestFitColumns()
        Cursor = Cursors.Default
        'Dim where As String = ""

        'If Not SLUEProvince.EditValue.ToString = "0" Then
        '    where += " AND s.id_state = " + SLUEProvince.EditValue.ToString
        'End If

        'If Not SLUECompGroup.EditValue.ToString = "0" Then
        '    where += " AND p.id_comp_group = " + SLUECompGroup.EditValue.ToString
        'End If

        'If Not SLUEIsland.EditValue.ToString = "ALL" Then
        '    where += " AND c.island = '" + SLUEIsland.EditValue.ToString + "'"
        'End If

        'Dim query As String = "
        '    (SELECT 0 AS id_comp, 'ALL' AS comp_name)
        '    UNION ALL
        '    (SELECT p.id_comp, CONCAT(p.comp_number, ' - ', p.comp_name) AS comp_name
        '    FROM tb_m_comp AS p
        '    LEFT JOIN tb_m_city AS c ON p.id_city = c.id_city
        '    LEFT JOIN tb_m_state AS s ON c.id_state = s.id_state
        '    WHERE 1 " + where + " AND p.id_comp_cat = 6)
        '"

        'viewSearchLookupQuery(SLUEStore, query, "id_comp", "comp_name", "id_comp")

    End Sub

    Sub view_group_store()
        Dim where As String = ""

        'If Not SLUEProvince.EditValue.ToString = "0" Then
        '    where += "
        '        AND id_comp_group IN (SELECT p.id_comp_group FROM tb_m_comp AS p LEFT JOIN tb_m_city AS c ON p.id_city = c.id_city LEFT JOIN tb_m_state AS s ON c.id_state = s.id_state WHERE s.id_state = " + SLUEProvince.EditValue.ToString + " AND p.id_comp_cat = 6)
        '    "
        'End If

        'If Not SLUEIsland.EditValue.ToString = "ALL" Then
        '    where += "
        '        AND id_comp_group IN (SELECT p.id_comp_group FROM tb_m_comp AS p LEFT JOIN tb_m_city AS c ON p.id_city = c.id_city WHERE c.island = '" + SLUEIsland.EditValue.ToString + "' AND p.id_comp_cat = 6)
        '    "
        'End If

        Dim query As String = "
            (SELECT id_comp_group, CONCAT(comp_group, ' - ', description) AS comp_group
            FROM tb_m_comp_group
            WHERE 1 " + where + ")
            ORDER BY comp_group ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("comp_group").ToString
            c.Value = data.Rows(i)("id_comp_group").ToString

            CCBEGroupStore.Properties.Items.Add(c)
        Next
    End Sub

    Private Sub SBSearch_Click(sender As Object, e As EventArgs) Handles SBSearch.Click
        FormMonthlySalesPerformancePick.ShowDialog()
    End Sub

    Private Sub SBClear_Click(sender As Object, e As EventArgs) Handles SBClear.Click
        TEProductCode.EditValue = ""
    End Sub

    Private Sub SLUENational_EditValueChanged(sender As Object, e As EventArgs) Handles SLUENational.EditValueChanged
        view_island()
        view_province()
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub SLUEProvince_EditValueChanged(sender As Object, e As EventArgs)
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub SLUECompGroup_EditValueChanged(sender As Object, e As EventArgs)
        view_store()
        defaultView()
    End Sub

    Private Sub SLUEIsland_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEIsland.EditValueChanged
        view_province()
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub FormMonthlySalesPerformance_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormMonthlySalesPerformance_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub LEArea_EditValueChanged(sender As Object, e As EventArgs)
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub CEAllStore_EditValueChanged(sender As Object, e As EventArgs) Handles CEAllStore.EditValueChanged
        If CEAllStore.EditValue = True Then
            GCStore.Enabled = False
        Else
            GCStore.Enabled = True
        End If
        defaultView()
    End Sub

    Private Sub SLUEMonthFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEMonthFrom.EditValueChanged
        defaultView()
    End Sub

    Private Sub SLUEMonthTo_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEMonthTo.EditValueChanged
        defaultView()
    End Sub

    Private Sub CCBESeason_EditValueChanged(sender As Object, e As EventArgs) Handles CCBESeason.EditValueChanged
        defaultView()
    End Sub

    Private Sub CCBEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEDivision.EditValueChanged
        defaultView()
    End Sub

    Private Sub CCBECategory_EditValueChanged(sender As Object, e As EventArgs) Handles CCBECategory.EditValueChanged
        defaultView()
    End Sub

    Private Sub CCBEClass_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEClass.EditValueChanged
        defaultView()
    End Sub

    Private Sub TEProductCode_EditValueChanged(sender As Object, e As EventArgs) Handles TEProductCode.EditValueChanged
        defaultView()
    End Sub

    Private Sub GVStore_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVStore.CellValueChanged
        defaultView()
    End Sub

    Private Sub XTCOption_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCOption.SelectedPageChanged
        If XTCOption.SelectedTabPageIndex = 0 Then
            XTCOption.Width = 412
        Else
            XTCOption.Width = 25
        End If
    End Sub

    Private Sub CCBEArea_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEArea.EditValueChanged
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub CCBEProvince_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEProvince.EditValueChanged
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub CCBEGroupStore_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEGroupStore.EditValueChanged
        view_group_store()
        view_store()
        defaultView()
    End Sub

    Private Sub CEActiveStore_EditValueChanged(sender As Object, e As EventArgs) Handles CEActiveStore.EditValueChanged
        view_store()
        defaultView()
    End Sub
End Class