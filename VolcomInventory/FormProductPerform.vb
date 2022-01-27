Public Class FormProductPerform
    Public month As List(Of String) = New List(Of String)

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

    Sub viewArea()
        Dim query As String = "
(SELECT a.id_area, a.`area` FROM tb_m_area a )
ORDER BY area ASC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("area").ToString
            c.Value = data.Rows(i)("id_area").ToString

            CCBEArea.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewProvince()
        Dim where As String = ""

        'If Not SLUEIsland.EditValue = "ALL" Then
        '    where = " AND s.id_state IN (SELECT id_state FROM tb_m_city WHERE island = '" + SLUEIsland.EditValue.ToString + "')"
        'End If

        Dim query As String = "
            (SELECT s.id_state AS id_province, s.state AS province
            FROM tb_m_state AS s
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = 5" + where + ")
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

    Sub view_group_store()
        Dim where As String = ""

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
            SELECT id_code_detail, CONCAT(display_name,'-',code_detail_name) AS `code`
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

    Private Sub FormProductPerform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        view_category_store()
        view_month()
        view_season()
        view_division()
        view_category()
        view_class()
        viewArea()
        viewProvince()
        view_group_store()
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

    Private Sub FormProductPerform_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProductPerform_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        'filter month
        Dim year_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(0))
        Dim year_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(0))
        Dim month_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(1))
        Dim month_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(1))
        Dim fromDate As String = "" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01"
        Dim untilDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-01"

        'validasi
        'jika store blm dipilih
        GVStore.ActiveFilterString = ""
        GVStore.ActiveFilterString = "[is_select]='Yes' "
        If GVStore.RowCount <= 0 Then
            stopCustom("Please select store first")
            GVStore.ActiveFilterString = ""
            Cursor = Cursors.Default
            Exit Sub
        End If
        GVStore.ActiveFilterString = ""
        'jika blm clsing
        Dim yp As String = year_from.ToString + "," + year_to.ToString
        Dim mp As String = month_from.ToString + "," + month_to.ToString
        checkClosingSOHSalPeriod(mp, yp)

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

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
	        WHERE d.id_code IN (32,4,30,14,5,43)
	        GROUP BY c.id_design
        ) i ON i.id_design = d.id_design "
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

        'filter wh
        Dim id_acc_selected As String = ""
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading WH")
        Dim compG78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 371", 0, True, "", "", "", "")
        Dim compGON As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1251", 0, True, "", "", "", "")
        Dim compS78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 429", 0, True, "", "", "", "")
        Dim compGOS As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1255", 0, True, "", "", "", "")
        Dim compREJ As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_type IN (3)", 0, True, "", "", "", "")
        id_acc_selected = compG78 + "," + compGON + "," + compS78 + "," + compGOS + "," + compREJ

        'filter store 
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading store")
        Dim id_store_selected As String = ""
        Dim id_comp_online As String = ""
        Dim id_comp_offline As String = ""
        Dim ion As Integer = 0
        Dim iof As Integer = 0
        Dim col_store As String = ""
        Dim col_store2 As String = ""
        GVStore.ActiveFilterString = "[is_select]='Yes'"
        For s As Integer = 0 To GVStore.RowCount - 1
            Dim comp_number As String = GVStore.GetRowCellValue(s, "comp_number").ToString
            Dim comp_name As String =GVStore.GetRowCellValue(s, "comp_name").ToString
            Dim id_comp As String = GVStore.GetRowCellValue(s, "id_comp").ToString
            Dim id_commerce_type As String = GVStore.GetRowCellValue(s, "id_commerce_type").ToString
            Dim id_wh_ol As String = GVStore.GetRowCellValue(s, "id_wh_ol").ToString
            Dim id_comp_soh As String = ""
            Dim rmt_del As String = ""
            If id_commerce_type = "1" Then
                'offline
                id_comp_soh = id_comp
                rmt_del = "43,103"
            Else
                'online
                id_comp_soh = id_wh_ol
                rmt_del = "58"
            End If

            If s > 0 Then
                id_store_selected += ","
                col_store += ","
                col_store2 += ","
            End If

            id_store_selected += GVStore.GetRowCellValue(s, "id_comp").ToString
            col_store += "IFNULL(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_del + ") AND soh.id_comp IN(" + id_comp_soh + ") THEN soh.qty END),0) AS `STORE : " + comp_number + " - " + comp_name + "|DEL`,
            IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") AND soh.id_comp IN(" + id_comp + ") THEN soh.qty END)),0) AS `STORE : " + comp_number + " - " + comp_name + "|SAL`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + id_comp_soh + ") THEN soh.qty END),0) AS `STORE : " + comp_number + " - " + comp_name + "|SOH`,
            (IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") AND soh.id_comp IN(" + id_comp + ") THEN soh.qty END)),0)/IFNULL(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_del + ") AND soh.id_comp IN(" + id_comp_soh + ") THEN soh.qty END),0))*100 AS `STORE : " + comp_number + " - " + comp_name + "|Sales Thru` "
            col_store2 += "soh.`STORE : " + comp_number + " - " + comp_name + "|DEL`, soh.`STORE : " + comp_number + " - " + comp_name + "|SAL`,soh.`STORE : " + comp_number + " - " + comp_name + "|SOH`, soh.`STORE : " + comp_number + " - " + comp_name + "|Sales Thru` "
            If id_commerce_type = "1" Then
                'offline
                If iof > 0 Then
                    id_comp_offline += ","
                End If
                id_comp_offline += id_comp
                iof += 1
            Else
                'online
                If ion > 0 Then
                    id_comp_online += ","
                End If
                id_comp_online += id_wh_ol
                ion += 1
            End If
        Next
        GVStore.ActiveFilterString = ""
        id_acc_selected += "," + id_store_selected
        If id_comp_offline <> "" Then
            id_acc_selected += "," + id_comp_offline
        Else
            id_comp_offline = "0"
        End If
        If id_comp_online <> "" Then
            id_acc_selected += "," + id_comp_online
        Else
            id_comp_online = "0"
        End If


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
        ROUND(wh_rec_normal.qty) AS `WH Received|Normal (BOS)`, ROUND(wh_rec_defect.qty) AS `WH Received|Defect`,
        ROUND((wh_rec_normal.qty + wh_rec_defect.qty)) AS `WH Received|Total`, 
        soh.`Stock Gudang Normal|G78`,soh.`Stock Gudang Normal|GON`,soh.`Stock Gudang Sale|S78`,soh.`Stock Gudang Sale|GOS`,soh.`Stock Gudang Non Active|Reject`,
        " + col_store2 + ",
        soh.`TOTAL|DEL`, soh.`TOTAL|SAL`,soh.`TOTAL|SOH`, soh.`TOTAL|Sales Thru`
        FROM (
            SELECT soh.id_design, soh.id_comp,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compG78 + ") THEN soh.qty END),0) AS `Stock Gudang Normal|G78`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compGON + ") THEN soh.qty END),0) AS `Stock Gudang Normal|GON`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compS78 + ") THEN soh.qty END),0) AS `Stock Gudang Sale|S78`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compGOS + ") THEN soh.qty END),0) AS `Stock Gudang Sale|GOS`,
            IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' AND soh.id_comp IN(" + compREJ + ") THEN soh.qty END),0) AS `Stock Gudang Non Active|Reject`,
            " + col_store + ",
            IFNULL(
                SUM(CASE 
                    WHEN soh.id_comp IN(" + id_comp_offline + ") AND soh.report_mark_type IN(43,103) THEN soh.qty 
                    WHEN soh.id_comp IN(" + id_comp_online + ") AND soh.report_mark_type IN(58) THEN soh.qty 
                END)
            ,0) AS `TOTAL|DEL`,
            IFNULL(ABS(SUM(CASE WHEN soh.id_comp IN(" + id_store_selected + ") AND soh.report_mark_type IN(" + rmt_sal + ") THEN soh.qty END)),0) AS `TOTAL|SAL`,
            IFNULL(
                SUM(CASE 
                    WHEN soh.id_comp IN(" + id_comp_offline + ") AND soh.soh_date='" + untilDate + "' THEN soh.qty 
                    WHEN soh.id_comp IN(" + id_comp_online + ") AND soh.soh_date='" + untilDate + "' THEN soh.qty 
                END)
            ,0) AS `TOTAL|SOH`,
            (IFNULL(ABS(SUM(CASE WHEN soh.id_comp IN(" + id_store_selected + ") AND soh.report_mark_type IN(" + rmt_sal + ") THEN soh.qty END)),0)/
            IFNULL(
                SUM(CASE 
                    WHEN soh.id_comp IN(" + id_comp_offline + ") AND soh.report_mark_type IN(43,103) THEN soh.qty 
                    WHEN soh.id_comp IN(" + id_comp_online + ") AND soh.report_mark_type IN(58) THEN soh.qty 
                END)
            ,0))*100 AS `TOTAL|Sales Thru`
            FROM tb_soh_sal_period soh
            " + join_design_soh + "
            INNER JOIN tb_m_comp c ON c.id_comp = soh.id_comp
            WHERE soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' 
            AND soh.id_comp IN(" + id_acc_selected + ")
            " + where_prod + "
            " + where_prod_soh + "
            GROUP BY soh.id_design 
        ) soh 
        " + join_design + "
        INNER JOIN tb_season AS season ON d.id_season = season.id_season
        INNER JOIN tb_range AS `range` ON season.id_range = range.id_range
        INNER JOIN tb_season_delivery AS delivery ON d.id_delivery = delivery.id_delivery
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
	        SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
	        FROM tb_pl_prod_order_rec_det AS d
	        LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
	        LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
	        LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
	        LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
	        WHERE r.id_report_status = 6 AND l.id_pl_category = 1
	        GROUP BY s.id_design
        ) AS wh_rec_normal ON wh_rec_normal.id_design = d.id_design
        LEFT JOIN (
	        SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
	        FROM tb_pl_prod_order_rec_det AS d
	        LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
	        LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
	        LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
	        LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
	        WHERE r.id_report_status = 6 AND l.id_pl_category <> 1
	        GROUP BY s.id_design
        ) AS wh_rec_defect ON wh_rec_defect.id_design = d.id_design "
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")
        GVData.Bands.Clear()
        GVData.Columns.Clear()

        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading column")
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next
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

                    If bandName.Contains("WH Received") Or bandName.Contains("Store Received") Or bandName.Contains("TOTAL") Or bandName.Contains("STORE :") Or bandName.Contains("Stock") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        If col.FieldName.Contains("Thru") Then
                            col.DisplayFormat.FormatString = "{0:n0}%"
                        Else
                            col.DisplayFormat.FormatString = "{0:n0}"
                        End If

                        'summary
                        If col.FieldName.Contains("Thru") Then
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None
                        Else
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        End If
                        col.SummaryItem.DisplayFormat = "{0:n0}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N0}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        If col.FieldName.Contains("Thru") Then
                            summary.SummaryType = DevExpress.Data.SummaryItemType.None
                        Else
                            summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        End If
                        GVData.GroupSummary.Add(summary)
                    ElseIf bandName = "Price" Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"
                    End If

                    If bandName = "Product Info" Then
                        band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End If
                End If
            Next
        Next
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading view")
        GCData.DataSource = data
        'slow bro
        'FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit all column")
        'GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub LEArea_EditValueChanged(sender As Object, e As EventArgs)
        view_group_store()
        viewStore()
    End Sub

    Private Sub SLUEProvince_EditValueChanged(sender As Object, e As EventArgs)
        view_group_store()
        viewStore()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        defaultView()
        CESelectAllStore.EditValue = False
        MESelectedStore.Text = ""
        acc.Clear()

        'filter
        Dim where As String = ""
        Dim id_cat As String = ""
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
            where += "AND c.id_area IN(" + id_area + ") "
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
    End Sub

    Private Sub SLUECompGroup_EditValueChanged(sender As Object, e As EventArgs)
        viewStore()
    End Sub

    Private Sub CESelectAllStore_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAllStore.EditValueChanged
        Cursor = Cursors.WaitCursor
        acc.Clear()
        For i As Integer = 0 To GVStore.RowCount - 1
            If CESelectAllStore.EditValue = True Then
                GVStore.SetRowCellValue(i, "is_select", "Yes")
                acc.Add(GVStore.GetRowCellValue(i, "comp_number").ToString)
            Else
                GVStore.SetRowCellValue(i, "is_select", "No")
                acc.Remove(GVStore.GetRowCellValue(i, "comp_number").ToString)
            End If
        Next
        showSelectedStore()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Cursor = Cursors.WaitCursor
        viewStore()
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelectAllStore_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllStore.CheckedChanged

    End Sub

    Private Sub GVStore_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVStore.CellValueChanged
        If e.Column.FieldName.ToString = "is_select" Then

        End If
    End Sub

    Sub setSelectedStore()
        Cursor = Cursors.WaitCursor
        Dim selected As String = ""
        Dim s As Integer = 0
        For i As Integer = 0 To GVStore.RowCount - 1
            If GVStore.GetRowCellValue(i, "is_select").ToString = "Yes" Then
                If s > 0 Then
                    selected += ","
                End If
                selected += GVStore.GetRowCellValue(i, "comp_number").ToString
                s += 1
            End If
        Next
        GCStore.RefreshDataSource()
        GCStore.Refresh()
        GVStore.RefreshData()
        MESelectedStore.Text = selected
        Cursor = Cursors.Default
    End Sub

    Dim tot_sal As Decimal
    Dim tot_del As Decimal
    Dim tot_sal_grp As Decimal
    Dim tot_del_grp As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        'belum ketemu utk yang kolom dinamis
    End Sub

    Private Sub SBClear_Click(sender As Object, e As EventArgs) Handles SBClear.Click
        TEProductCode.EditValue = ""
        TxtIdProduct.Text = ""
    End Sub

    Private Sub SBSearch_Click(sender As Object, e As EventArgs) Handles SBSearch.Click
        FormProductPerformProductPick.ShowDialog()
    End Sub

    Sub defaultView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub SLUEMonthFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEMonthFrom.EditValueChanged
        defaultView()
    End Sub

    Private Sub SLUEMonthTo_DragOver(sender As Object, e As DragEventArgs) Handles SLUEMonthTo.DragOver

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

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVStore_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVStore.ColumnFilterChanged

    End Sub

    Private Sub XtraScrollableControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        view_group_store()
        viewStore()
    End Sub

    Dim acc As New List(Of String)
    Private Sub RepositoryItemCheckEdit1_EditValueChanged_1(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim SpSelect As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        Dim is_select As String = SpSelect.EditValue.ToString
        Dim comp_number As String = GVStore.GetFocusedRowCellValue("comp_number").ToString
        If is_select = "Yes" Then
            'MsgBox("Checked : " + comp_number)
            acc.Add(comp_number)
        Else
            'MsgBox("Unchecked : " + comp_number)
            acc.Remove(comp_number)
        End If
    End Sub

    Sub showSelectedStore()
        Dim i As Integer = 0
        Dim acc_col As String = ""
        For Each res As String In acc
            If i > 0 Then
                acc_col += ","
            End If
            acc_col += res
            i += 1
        Next
        MESelectedStore.Text = acc_col
    End Sub

    Private Sub RepositoryItemCheckEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.Click

    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckStateChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckStateChanged

    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged

    End Sub

    Private Sub XTCOption_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCOption.SelectedPageChanged
        If XTCOption.SelectedTabPageIndex = 0 Then
            XTCOption.Width = 378
        Else
            XTCOption.Width = 25
        End If
    End Sub

    Private Sub CCBEArea_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEArea.EditValueChanged
        view_group_store()
        viewStore()
    End Sub

    Private Sub CCBEProvince_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEProvince.EditValueChanged
        view_group_store()
        viewStore()
    End Sub

    Private Sub CCBEGroupStore_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEGroupStore.EditValueChanged
        view_group_store()
        viewStore()
    End Sub
End Class