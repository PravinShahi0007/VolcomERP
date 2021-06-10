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
        Dim query As String = "SELECT 0 AS `id_area`, 'All' AS `area`
UNION ALL
(SELECT a.id_area, a.`area` FROM tb_m_area a )
ORDER BY area ASC"
        viewLookupQuery(LEArea, query, 0, "area", "id_area")
    End Sub

    Sub viewProvince()
        Dim where As String = ""

        'If Not SLUEIsland.EditValue = "ALL" Then
        '    where = " AND s.id_state IN (SELECT id_state FROM tb_m_city WHERE island = '" + SLUEIsland.EditValue.ToString + "')"
        'End If

        Dim query As String = "
            (SELECT 0 AS id_province, 'ALL' AS province)
            UNION ALL
            (SELECT s.id_state AS id_province, s.state AS province
            FROM tb_m_state AS s
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = 5" + where + ")
        "

        viewSearchLookupQuery(SLUEProvince, query, "id_province", "province", "id_province")
    End Sub

    Sub view_group_store()
        Dim where As String = ""

        Dim query As String = "
            (SELECT 0 AS id_comp_group, 'ALL' AS comp_group)
            UNION ALL
            (SELECT id_comp_group, CONCAT(comp_group, ' - ', description) AS comp_group
            FROM tb_m_comp_group
            WHERE 1 " + where + ")
        "

        viewSearchLookupQuery(SLUECompGroup, query, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Private Sub FormProductPerform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCData.TabPages
            XTCData.SelectedTabPage = t
        Next t
        XTCData.SelectedTabPage = XTCData.TabPages(0)

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
        viewArea()
        viewProvince()
    End Sub

    Private Sub FormProductPerform_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProductPerform_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        'filter month
        Dim year_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(0))
        Dim year_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(0))
        Dim month_from As Integer = Integer.Parse(SLUEMonthFrom.EditValue.ToString.Split("-")(1))
        Dim month_to As Integer = Integer.Parse(SLUEMonthTo.EditValue.ToString.Split("-")(1))
        Dim fromDate As String = "" + year_from.ToString + "-" + month_from.ToString.PadLeft(2, "0") + "-01"
        Dim untilDate As String = "" + year_to.ToString + "-" + month_to.ToString.PadLeft(2, "0") + "-01"

        'rmt 
        Dim rmt_sal As String = execute_query("SELECT GROUP_CONCAT(DISTINCT sp.report_mark_type) AS `rmt` FROM tb_sales_pos sp WHERE sp.id_report_status=6", 0, True, "", "", "", "")

        Dim query As String = "SELECT d.design_code AS `Product Info|Code`, d.design_display_name AS `Product Info|Description`, division.display_name AS `Product Info|Division`, 
        category.display_name AS `Product Info|Category`, class.display_name AS `Product Info|Class`, color.code_detail_name AS `Product Info|Color`, source.display_name AS `Product Info|Source`,
        season.season AS `Product Info|Season`, delivery.delivery AS `Product Info|Delivery`, range.year_range AS `Product Info|Year`,
        DATE_FORMAT(d.design_first_rec_wh, '%d %M %Y') AS `Product Age|WH Date`,
        DATE_FORMAT(first_del.first_del, '%d %M %Y') AS `Product Age|Del Date`,
        TIMESTAMPDIFF(MONTH, d.design_first_rec_wh, NOW()) AS `Product Age|WH Age`,
        TIMESTAMPDIFF(MONTH, first_del.first_del, NOW()) AS `Product Age|Del Age`,
        FORMAT(price_normal.design_price, 0) AS `Price|Normal`,
        FORMAT(IF(price_current.design_price = price_normal.design_price, '', price_current.design_price), 0) AS `Price|Current`,
        DATE_FORMAT(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 1), '%d %M %Y') AS `Price Update Dates|Price U1`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 2), 12), '%d %M %Y') AS `Price Update Dates|Price U2`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 3), 23), '%d %M %Y') AS `Price Update Dates|Price U3`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 4), 34), '%d %M %Y') AS `Price Update Dates|Price U4`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 5), 45), '%d %M %Y') AS `Price Update Dates|Price U5`,
        DATE_FORMAT(SUBSTRING(SUBSTRING_INDEX(price_date.design_price_start_date, ',', 6), 56), '%d %M %Y') AS `Price Update Dates|Price U6`,
        price_type.design_price_type AS `Price Update Dates|Current Status`,
        ROUND(wh_rec_normal.qty) AS `WH Received|Normal (BOS)`, ROUND(wh_rec_defect.qty) AS `WH Received|Defect`,
        ROUND((wh_rec_normal.qty + wh_rec_defect.qty)) AS `WH Received|Total`, 
        IFNULL(SUM(CASE WHEN soh.report_mark_type IN(43,103) AND soh.id_comp IN(549) THEN soh.qty END),0) AS `STORE : WBF|DEL`,
        IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") AND soh.id_comp IN(549) THEN soh.qty END)),0) AS `STORE : WBF|SAL`,
        IFNULL(SUM(CASE WHEN soh.soh_date='2020-12-01' AND soh.id_comp IN(549) THEN soh.qty END),0) AS `STORE : WBF|SOH`,
        (IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") AND soh.id_comp IN(549) THEN soh.qty END)),0)/IFNULL(SUM(CASE WHEN soh.report_mark_type IN(43,103) AND soh.id_comp IN(549) THEN soh.qty END),0))*100 AS `STORE : WBF|Sales Thru`,
        IFNULL(SUM(CASE WHEN soh.report_mark_type IN(43,103) THEN soh.qty END),0) AS `TOTAL|DEL`,
        IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") THEN soh.qty END)),0) AS `TOTAL|SAL`,
        IFNULL(SUM(CASE WHEN soh.soh_date='" + untilDate + "' THEN soh.qty END),0) AS `TOTAL|SOH`,
        (IFNULL(ABS(SUM(CASE WHEN soh.report_mark_type IN(" + rmt_sal + ") THEN soh.qty END)),0)/IFNULL(SUM(CASE WHEN soh.report_mark_type IN(43,103) THEN soh.qty END),0))*100 AS `TOTAL|Sales Thru`
        FROM tb_soh_sal_period soh
        INNER JOIN tb_m_product p ON p.id_product = soh.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        LEFT JOIN (
	         SELECT c.id_design, d.id_code_detail, d.display_name
	         FROM tb_m_design_code AS c
	         LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	         WHERE d.id_code = 32
        ) AS division ON d.id_design = division.id_design
        LEFT JOIN (
	        SELECT c.id_design, d.id_code_detail, d.display_name
	        FROM tb_m_design_code AS c
	        LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	        WHERE d.id_code = 4
        ) AS category ON d.id_design = category.id_design
        LEFT JOIN (
	        SELECT c.id_design, d.id_code_detail, d.display_name
	        FROM tb_m_design_code AS c
	        LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	        WHERE d.id_code = 30
        ) AS class ON d.id_design = class.id_design
        LEFT JOIN (
	        SELECT c.id_design, d.code_detail_name
	        FROM tb_m_design_code AS c
	        LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	        WHERE d.id_code = 14
        ) AS color ON d.id_design = color.id_design
        LEFT JOIN (
	        SELECT c.id_design, d.display_name
	        FROM tb_m_design_code AS c
	        LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	        WHERE d.id_code = 5
        ) AS source ON d.id_design = source.id_design
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
	        SELECT id_design, ROUND(design_price) AS design_price, id_design_price_type
	        FROM tb_m_design_price
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
        ) AS wh_rec_defect ON wh_rec_defect.id_design = d.id_design
        WHERE soh.soh_date>='" + fromDate + "' AND soh.soh_date<='" + untilDate + "' 
        AND soh.id_comp IN(549)
        GROUP BY p.id_design "
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")
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

                    If bandName.Contains("WH Received") Or bandName.Contains("Store Received") Or bandName.Contains("TOTAL") Or bandName.Contains("STORE :") Then
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

                    If bandName = "Product Info" Then
                        band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End If
                End If
            Next
        Next

        GCData.DataSource = data
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub LEArea_EditValueChanged(sender As Object, e As EventArgs) Handles LEArea.EditValueChanged
        view_group_store()
        viewStore()
    End Sub

    Private Sub SLUEProvince_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEProvince.EditValueChanged
        view_group_store()
        viewStore()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        CESelectAllStore.EditValue = False
        MESelectedStore.Text = ""

        'filter
        Dim where As String = ""
        If LEArea.EditValue.ToString <> "0" Then
            where += "AND c.id_area='" + LEArea.EditValue.ToString + "' "
        End If
        If SLUEProvince.EditValue.ToString <> "0" Then
            where += "AND cty.id_state='" + SLUEProvince.EditValue.ToString + "' "
        End If
        If SLUECompGroup.EditValue.ToString <> "0" Then
            where += "AND c.id_comp_group='" + SLUECompGroup.EditValue.ToString + "' "
        End If

        'view
        Dim query As String = "SELECT c.id_comp, c.comp_name, c.comp_number, 'No' AS `is_select` FROM tb_m_comp c WHERE c.id_comp_cat=6 ORDER BY c.comp_number ASC " + where
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")
        GCStore.DataSource = data
        GVStore.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLUECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLUECompGroup.EditValueChanged
        viewStore()
    End Sub

    Private Sub CESelectAllStore_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAllStore.EditValueChanged
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To GVStore.RowCount - 1
            If CESelectAllStore.EditValue = True Then
                GVStore.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVStore.SetRowCellValue(i, "is_select", "No")
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Cursor = Cursors.WaitCursor
        viewStore()
        Cursor = Cursors.Default
    End Sub
End Class