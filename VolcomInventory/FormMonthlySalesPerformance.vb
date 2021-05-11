Public Class FormMonthlySalesPerformance
    Public month As List(Of String) = New List(Of String)

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        FormMain.SplashScreenManager1.ShowWaitForm()

        Dim selectDate1 As String = ""
        Dim selectDate2 As String = ""

        Dim selectYear1 As String = ""
        Dim selectYear2 As String = ""

        Dim selectDateAll As String = ""
        Dim selectYearAll As String = ""

        Dim year_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(0))
        Dim year_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(0))
        Dim month_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(1))
        Dim month_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(1))

        Dim i As Integer = 0
        Dim j As Integer = 0

        i = year_from
        j = month_from

        While i <= year_to
            selectDate1 += "IF(`year` = " + i.ToString + " AND `month` = " + j.ToString + ", qty, 0) AS `" + month(j - 1) + " " + i.ToString + "`, "
            selectDate2 += "MAX(`" + month(j - 1) + " " + i.ToString + "`) AS `" + month(j - 1) + " " + i.ToString + "`, "

            selectDateAll += "IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) AS `Sales " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

            If j = 12 Then
                j = 1

                i = i + 1
            Else
                j = j + 1
            End If

            If i = year_to And j > month_to Then
                Exit While
            End If
        End While

        For i = year_from To year_to
            selectYear1 += "IF(`year` = " + i.ToString + ", qty, 0) AS `" + i.ToString + "`, "
            selectYear2 += "MAX(`" + i.ToString + "`) AS `" + i.ToString + "`, "

            selectYearAll += "IFNULL(sales_year.`" + i.ToString + "`, 0) AS `Total Sales|" + i.ToString + "`, "
        Next

        selectDate1 = selectDate1.Substring(0, selectDate1.Length - 2)
        selectDate2 = selectDate2.Substring(0, selectDate2.Length - 2)

        selectDateAll = selectDateAll.Substring(0, selectDateAll.Length - 2)

        selectYear1 = selectYear1.Substring(0, selectYear1.Length - 2)
        selectYear2 = selectYear2.Substring(0, selectYear2.Length - 2)

        selectYearAll = selectYearAll.Substring(0, selectYearAll.Length - 2)

        'stock date
        Dim dateStockDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(year_to, month_to).ToString + ""

        Dim queryStockDate As String = "
            SELECT STR_TO_DATE(CONCAT(YEAR('" + dateStockDate + "'), '-', MONTH('" + dateStockDate + "'), '-', '01'), '%Y-%m-%d') AS cm_beg_startd, STR_TO_DATE(DATE_SUB(CONCAT(YEAR('" + dateStockDate + "'), '-', MONTH('" + dateStockDate + "'), '-', '01'), INTERVAL 1 DAY), '%Y-%m-%d') AS beg_date, YEAR((SELECT beg_date)) AS beg_year, MONTH((SELECT beg_date)) AS beg_month
        "

        Dim dataStockDate As DataTable = execute_query(queryStockDate, -1, True, "", "", "", "")

        Dim compG78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 371", 0, True, "", "", "", "")
        Dim compGON As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1251", 0, True, "", "", "", "")
        Dim compS78 As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 429", 0, True, "", "", "", "")
        Dim compGOS As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_group = 1255", 0, True, "", "", "", "")
        Dim compREJ As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_comp) AS `comp` FROM tb_m_comp c WHERE c.id_wh_type IN (3, 4)", 0, True, "", "", "", "")

        'stock month
        i = year_from
        j = month_from

        Dim stockMonthQuery1 As String = ""
        Dim stockMonthQuery2 As String = ""
        Dim stockMonthQuery3 As String = ""
        Dim stockMonthQueryAll As String = ""

        While i <= year_to
            Dim stockMonthFirst As String = "" + i.ToString + "-" + j.ToString.PadLeft(2, "0") + "-01"
            Dim stockMonthDate As String = "" + i.ToString + "-" + j.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(i, j).ToString + ""

            Dim queryMonthDate As String = "
                SELECT STR_TO_DATE(CONCAT(YEAR('" + stockMonthDate + "'), '-', MONTH('" + stockMonthDate + "'), '-', '01'), '%Y-%m-%d') AS cm_beg_startd, STR_TO_DATE(DATE_SUB(CONCAT(YEAR('" + stockMonthDate + "'), '-', MONTH('" + stockMonthDate + "'), '-', '01'), INTERVAL 1 DAY), '%Y-%m-%d') AS beg_date, YEAR((SELECT beg_date)) AS beg_year, MONTH((SELECT beg_date)) AS beg_month
            "

            Dim dataMonthDate As DataTable = execute_query(queryMonthDate, -1, True, "", "", "", "")

            stockMonthQuery1 += "
                (
                    SELECT d.id_design, IFNULL(inv.inv_qty_ttl, 0) AS inv_qty_ttl, " + i.ToString + " AS `year`, " + j.ToString + " AS `month`
                    FROM tb_m_design d
                    LEFT JOIN (
                        SELECT p.id_design, SUM(a.qty_ttl) AS inv_qty_ttl
                        FROM (
                            (
                                SELECT f.id_product, f.id_wh_drawer, f.qty_ttl
                                FROM tb_storage_fg_" + dataMonthDate.Rows(0)("beg_year").ToString + " AS f
                                WHERE f.month = '" + dataMonthDate.Rows(0)("beg_month").ToString + "'
                            )
                            UNION ALL 
                            -- beginning sal tanpa online
                            (
                                SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
                                FROM (
                                    SELECT * FROM tb_storage_fg AS f
                                    WHERE f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.id_stock_status = 1
                                    AND f.report_mark_type IN (48, 66, 54, 67, 118, 117, 183, 116, 292)
                                ) AS f
                                INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
                                INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
                                INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
                                WHERE sp.id_report_status = 6
                                AND c.id_comp NOT IN (1212, 1213)
                                AND sp.sales_pos_end_period < '" + stockMonthFirst + "' 
                                GROUP BY f.id_product, f.id_wh_drawer
                            )
                            UNION ALL
                            -- beginning CN VIOS
                            (
                                SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
                                FROM (
                                    SELECT * FROM tb_storage_fg f
                                    WHERE f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.id_stock_status = 1
                                    AND f.report_mark_type = 118
                                ) f
                                INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
                                INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
                                INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
                                WHERE sp.id_report_status = 6
                                AND c.id_comp IN (1212, 1213)
                                AND sp.sales_pos_end_period < '" + stockMonthFirst + "' 
                                GROUP BY f.id_product, f.id_wh_drawer
                            )
                            UNION ALL 
                            -- stok tanpa sal
                            (
                                SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS qty_ttl
                                FROM tb_storage_fg AS f
                                WHERE f.id_stock_status = 1 
                                AND (f.storage_product_datetime >= '" + stockMonthFirst + " 00:00:00' AND f.storage_product_datetime <= '" + stockMonthDate + " 23:59:59')
                                AND f.report_mark_type NOT IN (48, 66, 54, 67, 118, 117, 183, 116, 292)
                                GROUP BY f.id_product, f.id_wh_drawer 
                            )
                            -- sal 
                            UNION ALL
                            (
                                SELECT f.id_product, f.id_wh_drawer, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
                                FROM tb_storage_fg AS f
                                INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
                                INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact= IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
                                INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
                                WHERE f.id_stock_status = 1
                                AND f.report_mark_type IN (48, 66, 54, 67, 118, 117, 183, 116, 292) AND sp.id_report_status = 6
                                AND c.id_comp NOT IN (1212, 1213)
                                AND sp.sales_pos_end_period >= '" + stockMonthFirst + "' AND sp.sales_pos_end_period <= '" + stockMonthDate + "' 
                                GROUP BY f.id_product, f.id_wh_drawer
                            )
                            -- CN VIOS
                            UNION ALL 
                            (
                                SELECT f.id_product, f.id_wh_drawer, 
                                SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl 
                                FROM tb_storage_fg AS f
                                INNER JOIN tb_sales_pos AS sp ON sp.id_sales_pos = f.id_report AND sp.report_mark_type = f.report_mark_type
                                INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
                                INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
                                WHERE f.id_stock_status = 1
                                AND f.report_mark_type = 118 AND sp.id_report_status=6
                                AND c.id_comp IN (1212, 1213)
                                AND sp.sales_pos_end_period >= '" + stockMonthFirst + "' AND sp.sales_pos_end_period <= '" + stockMonthDate + "' 
                                GROUP BY f.id_product, f.id_wh_drawer
                            )
                        ) a
                        INNER JOIN tb_m_product p ON p.id_product = a.id_product
                        GROUP BY p.id_design
                    ) inv ON inv.id_design = d.id_design
                    WHERE d.id_lookup_status_order <> 2
                    GROUP BY d.id_design
                )
                UNION ALL
            "

            stockMonthQuery2 += "IF(t.year = " + i.ToString + " AND t.month = " + j.ToString + ", inv_qty_ttl, 0) AS `" + month(j - 1) + " " + i.ToString + "`, "
            stockMonthQuery3 += "MAX(`" + month(j - 1) + " " + i.ToString + "`) AS `" + month(j - 1) + " " + i.ToString + "`, "
            stockMonthQueryAll += "CONCAT((ROUND((IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) / (IFNULL(sales_month.`" + month(j - 1) + " " + i.ToString + "`, 0) + IFNULL(stock_month.`" + month(j - 1) + " " + i.ToString + "`, 0))) * 100)), '%') AS `Monthly SAS " + i.ToString + "|" + month(j - 1) + " " + i.ToString + "`, "

            If j = 12 Then
                j = 1

                i = i + 1
            Else
                j = j + 1
            End If

            If i = year_to And j > month_to Then
                Exit While
            End If
        End While

        stockMonthQuery1 = stockMonthQuery1.Substring(0, stockMonthQuery1.Length - 25)
        stockMonthQuery2 = stockMonthQuery2.Substring(0, stockMonthQuery2.Length - 2)
        stockMonthQuery3 = stockMonthQuery3.Substring(0, stockMonthQuery3.Length - 2)
        stockMonthQueryAll = stockMonthQueryAll.Substring(0, stockMonthQueryAll.Length - 2)

        'where
        Dim where As String = ""

        If Not SLUESeason.EditValue.ToString = "0" Then
            where += " AND design.id_season = " + SLUESeason.EditValue.ToString
        End If

        If Not SLUEDivision.EditValue.ToString = "0" Then
            where += " AND division.id_code_detail = " + SLUEDivision.EditValue.ToString
        End If

        If Not SLUECategory.EditValue.ToString = "0" Then
            where += " AND category.id_code_detail = " + SLUECategory.EditValue.ToString
        End If

        If Not SLUEClass.EditValue.ToString = "0" Then
            where += " AND class.id_code_detail = " + SLUEClass.EditValue.ToString
        End If

        If Not TEProductCode.EditValue.ToString = "" Then
            where += " AND design.design_code IN ('" + String.Join("','", TEProductCode.EditValue.ToString.Split(",")) + "')"
        End If

        Dim whereSalesPos As String = " AND s.sales_pos_end_period BETWEEN '" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01' AND '" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-" + Date.DaysInMonth(year_to, month_to).ToString + "'"

        If Not SLUENational.EditValue.ToString = "0" Then
            whereSalesPos += " AND r.id_country = " + SLUENational.EditValue.ToString
        End If

        If Not SLUEProvince.EditValue.ToString = "0" Then
            whereSalesPos += " AND y.id_state = " + SLUEProvince.EditValue.ToString
        End If

        If Not SLUEStore.EditValue.ToString = "0" Then
            whereSalesPos += " AND t.id_comp = " + SLUEStore.EditValue.ToString
        End If

        Dim query As String = "
            SELECT design.design_code AS `Product Info|Code`, division.display_name AS `Product Info|Division`,
	            category.display_name AS `Product Info|Category`, class.display_name AS `Product Info|Class`,
	            design.design_display_name AS `Product Info|Description`, color.code_detail_name AS `Product Info|Color`,
	            season.season AS `Product Info|Season`, delivery.delivery AS `Product Info|Delivery`, range.year_range AS `Product Info|Year`,
	            source.display_name AS `Product Info|Source`,
	            DATE_FORMAT(design.design_first_rec_wh, '%d %M %Y') AS `Product Age|WH Date`,
	            DATE_FORMAT(first_del.first_del, '%d %M %Y') AS `Product Age|Del Date`,
	            TIMESTAMPDIFF(MONTH, design.design_first_rec_wh, NOW()) AS `Product Age|WH Age`,
	            TIMESTAMPDIFF(MONTH, first_del.first_del, NOW()) AS `Product Age|Del Age`,
	            price_normal.design_price AS `Price|Normal`,
	            IF(price_current.design_price = price_normal.design_price, '', price_current.design_price) AS `Price|Current`,
	            DATE_FORMAT(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 1), '%d %M %Y') AS `Price Update Dates|Price U1`,
	            DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 2), 12), '%d %M %Y') AS `Price Update Dates|Price U2`,
	            DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 3), 23), '%d %M %Y') AS `Price Update Dates|Price U3`,
	            DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 4), 34), '%d %M %Y') AS `Price Update Dates|Price U4`,
	            DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 5), 45), '%d %M %Y') AS `Price Update Dates|Price U5`,
	            DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 6), 56), '%d %M %Y') AS `Price Update Dates|Price U6`,
	            price_type.design_price_type AS `Price Update Dates|Current Status`, ROUND(wh_rec_normal.qty) AS `WH Received|Normal (BOS)`, ROUND(wh_rec_defect.qty) AS `WH Received|Defect`,
	            ROUND((wh_rec_normal.qty + wh_rec_defect.qty)) AS `WH Received|Total`,
	            0 AS `Store Received|Total`,
                " + selectDateAll + ", " + selectYearAll + ", 
                ROUND(IFNULL(sales_normal.qty, 0)) AS `Total Sales|Sales Toko Normal`, ROUND(IFNULL(sales_sale.qty, 0)) AS `Total Sales|Sales Toko Sale`,
                ROUND((IFNULL(sales_normal.qty, 0) + IFNULL(sales_sale.qty, 0))) AS `Total Sales|Grand Total`,
                CONCAT(ROUND((IFNULL(sales_normal.qty, 0) / IFNULL(wh_rec_normal.qty, 0) * 100)), '%') AS `Sell Thru|Normal`, 
                CONCAT(ROUND((IFNULL(sales_sale.qty, 0) / (IFNULL(wh_rec_normal.qty, 0) - IFNULL(sales_normal.qty, 0)) * 100)), '%') AS `Sell Thru|Sale`,
                CONCAT(ROUND(((IFNULL(sales_normal.qty, 0) + IFNULL(sales_sale.qty, 0)) / IFNULL(wh_rec_normal.qty, 0) * 100)), '%') AS `Sell Thru|Total`, 
                " + stockMonthQueryAll + ",
                ROUND(IFNULL(stock_g78.qty, 0)) AS `Stock Gudang Normal|G78`, ROUND(IFNULL(stock_gon.qty, 0)) AS `Stock Gudang Normal|GON`, ROUND(IFNULL(stock_s78.qty, 0)) AS `Stock Gudang Sale|S78`, ROUND(IFNULL(stock_gos.qty, 0)) AS `Stock Gudang Sale|GOS`, ROUND(IFNULL(stock_rej.qty, 0)) AS `Stock Gudang Non Aktive|Reject`
            FROM tb_m_design AS design
            LEFT JOIN (
	            SELECT c.id_design, d.id_code_detail, d.display_name
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 32
            ) AS division ON design.id_design = division.id_design
            LEFT JOIN (
	            SELECT c.id_design, d.id_code_detail, d.display_name
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 4
            ) AS category ON design.id_design = category.id_design
            LEFT JOIN (
	            SELECT c.id_design, d.id_code_detail, d.display_name
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 30
            ) AS class ON design.id_design = class.id_design
            LEFT JOIN (
	            SELECT c.id_design, d.code_detail_name
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 14
            ) AS color ON design.id_design = color.id_design
            LEFT JOIN (
	            SELECT c.id_design, d.display_name
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 5
            ) AS source ON design.id_design = source.id_design
            LEFT JOIN tb_season AS season ON design.id_season = season.id_season
            LEFT JOIN tb_range AS `range` ON season.id_range = range.id_range
            LEFT JOIN tb_season_delivery AS delivery ON design.id_delivery = delivery.id_delivery
            LEFT JOIN (
	            SELECT d.id_design, MIN(d.first_del) AS first_del
	            FROM tb_m_design_first_del AS d
	            INNER JOIN tb_m_comp AS c ON c.id_comp = d.id_comp
	            WHERE c.id_store_type = 1 AND c.id_commerce_type = 1 AND c.id_comp_group != 59
	            GROUP BY d.id_design
            ) AS first_del ON design.id_design = first_del.id_design
            LEFT JOIN (
	            SELECT id_design, ROUND(design_price) AS design_price, id_design_price_type
	            FROM tb_m_design_price
	            WHERE id_design_price IN (
		            SELECT MAX(id_design_price) AS id_design_price
		            FROM tb_m_design_price
		            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
		            GROUP BY id_design
	            )
            ) AS price_current ON design.id_design = price_current.id_design
            LEFT JOIN (
	            SELECT id_design, ROUND(design_price) AS design_price
	            FROM tb_m_design_price
	            WHERE id_design_price IN (
		            SELECT MAX(id_design_price) AS id_design_price
		            FROM tb_m_design_price
		            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
		            GROUP BY id_design
	            )
            ) AS price_normal ON design.id_design = price_normal.id_design
            LEFT JOIN (
	            SELECT id_design, GROUP_CONCAT(design_price_start_date ORDER BY design_price_start_date ASC) AS design_price_start_date
	            FROM tb_m_design_price
	            WHERE is_active_wh = 1 AND is_design_cost = 0
	            GROUP BY id_design
            ) AS price_date ON design.id_design = price_date.id_design
            LEFT JOIN tb_lookup_design_price_type AS price_type ON price_current.id_design_price_type = price_type.id_design_price_type
            LEFT JOIN (
	            SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
	            FROM tb_pl_prod_order_rec_det AS d
	            LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
	            LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
	            LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
	            LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
	            WHERE r.id_report_status = 6 AND l.id_pl_category = 1
	            GROUP BY s.id_design
            ) AS wh_rec_normal ON design.id_design = wh_rec_normal.id_design
            LEFT JOIN (
	            SELECT s.id_design, SUM(d.pl_prod_order_rec_det_qty) AS qty
	            FROM tb_pl_prod_order_rec_det AS d
	            LEFT JOIN tb_pl_prod_order_rec AS r ON d.id_pl_prod_order_rec = r.id_pl_prod_order_rec
	            LEFT JOIN tb_pl_prod_order AS l ON r.id_pl_prod_order = l.id_pl_prod_order
	            LEFT JOIN tb_prod_order AS p ON l.id_prod_order = p.id_prod_order
	            LEFT JOIN tb_prod_demand_design AS s ON p.id_prod_demand_design = s.id_prod_demand_design
	            WHERE r.id_report_status = 6 AND l.id_pl_category <> 1
	            GROUP BY s.id_design
            ) AS wh_rec_defect ON design.id_design = wh_rec_defect.id_design
            LEFT JOIN (
                SELECT id_design, " + selectDate2 + "
                FROM (
	                SELECT id_design, " + selectDate1 + "
	                FROM (
		                SELECT p.id_design, YEAR(s.sales_pos_end_period) AS `year`, MONTH(s.sales_pos_end_period) AS `month`, SUM(ROUND(d.sales_pos_det_qty)) AS qty
		                FROM tb_sales_pos_det AS d
		                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
                        LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
                        LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
                        LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
                        LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
                        LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
		                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
		                WHERE s.id_report_status = 6 " + whereSalesPos + "
		                GROUP BY p.id_design, YEAR(s.sales_pos_end_period), MONTH(s.sales_pos_end_period)
	                ) AS t
                ) AS t
                GROUP BY id_design
            ) AS sales_month ON sales_month.id_design = design.id_design
            LEFT JOIN (
                SELECT id_design, " + selectYear2 + "
                FROM (
	                SELECT id_design, " + selectYear1 + "
	                FROM (
		                SELECT p.id_design, YEAR(s.sales_pos_end_period) AS `year`, SUM(ROUND(d.sales_pos_det_qty)) AS qty
		                FROM tb_sales_pos_det AS d
		                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
                        LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
                        LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
                        LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
                        LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
                        LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
		                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
		                WHERE s.id_report_status = 6 " + whereSalesPos + "
		                GROUP BY p.id_design, YEAR(s.sales_pos_end_period)
	                ) AS t
                ) AS t
                GROUP BY id_design
            ) AS sales_year ON sales_year.id_design = design.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(ROUND(d.sales_pos_det_qty)) AS qty
                FROM tb_sales_pos_det AS d
                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
                LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
                LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
                LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
                LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
                LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
                WHERE s.id_report_status = 6 AND t.id_store_type = 1 " + whereSalesPos + "
                GROUP BY p.id_design
            ) AS sales_normal ON design.id_design = sales_normal.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(ROUND(d.sales_pos_det_qty)) AS qty
                FROM tb_sales_pos_det AS d
                LEFT JOIN tb_sales_pos AS s ON d.id_sales_pos = s.id_sales_pos
                LEFT JOIN tb_m_comp_contact c ON c.id_comp_contact = IF(s.id_memo_type = 8 OR s.id_memo_type = 9, s.id_comp_contact_bill, s.id_store_contact_from)
                LEFT JOIN tb_m_comp AS t ON c.id_comp = t.id_comp
                LEFT JOIN tb_m_city AS `y` ON t.id_city = y.id_city
                LEFT JOIN tb_m_state AS a ON y.id_state = a.id_state
                LEFT JOIN tb_m_region AS r ON a.id_region = r.id_region
                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
                WHERE s.id_report_status = 6 " + whereSalesPos + " AND (t.id_store_type <> 1 OR t.id_store_type IS NULL)
                GROUP BY p.id_design
            ) AS sales_sale ON design.id_design = sales_sale.id_design
            LEFT JOIN (
                SELECT t.id_design, " + stockMonthQuery3 + "
                FROM (
                    SELECT t.id_design, " + stockMonthQuery2 + "
                    FROM (
                        " + stockMonthQuery1 + "
                    ) AS t
                ) AS t
                GROUP BY t.id_design
            ) AS stock_month ON design.id_design = stock_month.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(a.qty_ttl) AS qty
				FROM (
					SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
					FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
					WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
					UNION ALL
					SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
					FROM tb_storage_fg AS f
					WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
					GROUP BY f.id_wh_drawer, f.id_product
				) AS a
				INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
				INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
				INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compG78 + ")
				INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
				GROUP BY p.id_design
            ) AS stock_g78 ON design.id_design = stock_g78.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(a.qty_ttl) AS qty
				FROM (
					SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
					FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
					WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
					UNION ALL
					SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
					FROM tb_storage_fg AS f
					WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
					GROUP BY f.id_wh_drawer, f.id_product
				) AS a
				INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
				INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
				INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compGON + ")
				INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
				GROUP BY p.id_design
            ) AS stock_gon ON design.id_design = stock_gon.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(a.qty_ttl) AS qty
				FROM (
					SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
					FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
					WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
					UNION ALL
					SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
					FROM tb_storage_fg AS f
					WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
					GROUP BY f.id_wh_drawer, f.id_product
				) AS a
				INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
				INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
				INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compS78 + ")
				INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
				GROUP BY p.id_design
            ) AS stock_s78 ON design.id_design = stock_s78.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(a.qty_ttl) AS qty
				FROM (
					SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
					FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
					WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
					UNION ALL
					SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
					FROM tb_storage_fg AS f
					WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
					GROUP BY f.id_wh_drawer, f.id_product
				) AS a
				INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
				INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
				INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compGOS + ")
				INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
				GROUP BY p.id_design
            ) AS stock_gos ON design.id_design = stock_gos.id_design
            LEFT JOIN (
                SELECT p.id_design, SUM(a.qty_ttl) AS qty
				FROM (
					SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
					FROM tb_storage_fg_" + dataStockDate.Rows(0)("beg_year").ToString + " AS f
					WHERE f.month = '" + dataStockDate.Rows(0)("beg_month").ToString + "'
					UNION ALL
					SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_stock_status = 1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl
					FROM tb_storage_fg AS f
					WHERE f.storage_product_datetime >= '" + Date.Parse(dataStockDate.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd") + " 00:00:00'  AND f.storage_product_datetime <= '" + dateStockDate + " 23:59:59' 
					GROUP BY f.id_wh_drawer, f.id_product
				) AS a
				INNER JOIN tb_m_wh_drawer AS d ON  d.id_wh_drawer= a.id_wh_drawer
				INNER JOIN tb_m_wh_rack AS r ON r.id_wh_rack = d.id_wh_rack
				INNER JOIN tb_m_wh_locator AS l ON l.id_wh_locator = r.id_wh_locator AND l.id_comp IN (" + compREJ + ")
				INNER JOIN tb_m_comp AS c ON c.id_comp = l.id_comp
                INNER JOIN tb_m_product AS p ON p.id_product = a.id_product
				GROUP BY p.id_design
            ) AS stock_rej ON design.id_design = stock_rej.id_design
            WHERE design.id_lookup_status_order <> 2 AND design.design_code <> '' " + where + "
            ORDER BY design.design_first_rec_wh ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVData.Bands.Clear()
        GVData.Columns.Clear()

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

                    If bandName.Contains("WH Received") Or bandName.Contains("Store Received") Or bandName.Contains("Sales") Or bandName.Contains("Stock Gudang") Then
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                        summary.DisplayFormat = "{0:N0}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum

                        GVData.GroupSummary.Add(summary)
                    End If

                    If bandName = "Price" Then
                        col.DisplayFormat.FormatString = "N2"
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    End If

                    If bandName.Contains("Sell Thru") Or bandName.Contains("Monthly SAS") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    End If
                End If
            Next
        Next

        GCData.DataSource = data

        GVData.BestFitColumns()

        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

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
        view_national()
        'view_island()
        view_province()
        view_store()
        view_season()
        view_division()
        view_category()
        view_class()
    End Sub

    Sub view_season()
        Dim query As String = "
            (SELECT 0 AS id_season, 'ALL' AS season, 0 AS id_range, 'ALL' AS `range`)
            UNION ALL
            (SELECT a.id_season, a.season, b.id_range, b.range
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC)
        "

        viewSearchLookupQuery(SLUESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division()
        Dim query As String = "
            (SELECT 0 AS id_code_detail, 'ALL' AS code)
            UNION ALL
            (SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC)
        "

        viewSearchLookupQuery(SLUEDivision, query, "id_code_detail", "code", "id_code_detail")
    End Sub

    Sub view_category()
        Dim query As String = "
            (SELECT 0 AS id_code_detail, 'ALL' AS code)
            UNION ALL
            (SELECT id_code_detail, display_name AS `code`
            FROM tb_m_code_detail
            WHERE id_code = 4
            ORDER BY id_code_detail ASC)
        "

        viewSearchLookupQuery(SLUECategory, query, "id_code_detail", "code", "id_code_detail")
    End Sub

    Sub view_class()
        Dim query As String = "
            (SELECT 0 AS id_code_detail, 'ALL' AS code)
            UNION ALL
            (SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 30
            ORDER BY id_code_detail ASC)
        "

        viewSearchLookupQuery(SLUEClass, query, "id_code_detail", "code", "id_code_detail")
    End Sub

    Sub view_month()
        Dim data As DataTable = New DataTable

        data.Columns.Add("month_code", GetType(String))
        data.Columns.Add("month", GetType(String))

        Dim first_year As Integer = 2019
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

    Sub view_province()
        Dim query As String = "
            (SELECT 0 AS id_province, 'ALL' AS province)
            UNION ALL
            (SELECT s.id_state AS id_province, s.state AS province
            FROM tb_m_state AS s
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = " + SLUENational.EditValue.ToString + ")
        "

        viewSearchLookupQuery(SLUEProvince, query, "id_province", "province", "id_province")
    End Sub

    Sub view_store()
        Dim where As String = ""

        If Not SLUEProvince.EditValue.ToString = "0" Then
            where = " AND s.id_state = " + SLUEProvince.EditValue.ToString
        End If

        Dim query As String = "
            (SELECT 0 AS id_comp, 'ALL' AS comp_name)
            UNION ALL
            (SELECT p.id_comp, p.comp_name
            FROM tb_m_comp AS p
            LEFT JOIN tb_m_city AS c ON p.id_city = c.id_city
            LEFT JOIN tb_m_state AS s ON c.id_state = s.id_state
            WHERE 1 " + where + " AND p.id_comp_cat = 6)
        "

        viewSearchLookupQuery(SLUEStore, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBSearch_Click(sender As Object, e As EventArgs) Handles SBSearch.Click
        FormMonthlySalesPerformancePick.ShowDialog()
    End Sub

    Private Sub SBClear_Click(sender As Object, e As EventArgs) Handles SBClear.Click
        TEProductCode.EditValue = ""
    End Sub

    Private Sub SLUENational_EditValueChanged(sender As Object, e As EventArgs) Handles SLUENational.EditValueChanged
        view_province()
    End Sub

    Private Sub SLUEProvince_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEProvince.EditValueChanged
        view_store()
    End Sub
End Class