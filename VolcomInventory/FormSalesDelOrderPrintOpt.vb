Public Class FormSalesDelOrderPrintOpt 
    Dim id_season_default As String = "-1"
    Dim id_sales_number_default As String = "-1"

    Private Sub FormSalesDelOrderPrintOpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSoStatus(ByVal id_so_status As String)
        If id_so_status = "0" Or id_so_status = "-1" Or id_so_status = "" Then
            Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
            viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
        Else
            Dim query As String = "SELECT * FROM tb_lookup_so_status a WHERE a.id_so_status ='" + id_so_status + "' ORDER BY a.id_so_status "
            viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
        End If
    End Sub

    Sub viewSalesOrder(ByVal id_delivery As String)
        Dim query As String = ""
        query += "SELECT ('-') AS so_status, ('-') AS so_type, ('0') AS id_sales_order, ('-') AS id_store_contact_to, ('-') AS store_name_to, ('-') AS id_report_status, ('-') AS report_status, "
        query += "('-') AS sales_order_note, ('-') AS id_delivery, ('-') AS delivery, ('-') AS id_season, ('-') AS season, ('-') AS sales_order_note, ('All Sales Order') AS sales_order_number, "
        query += "('-') AS sales_order_date, ('0') AS id_so_type, ('0') AS id_so_status "
        query += "UNION ALL "
        query += "SELECT g.so_status, h.so_type, a.id_sales_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_order_note, a.id_delivery, e.delivery, e1.id_season, e1.season, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%d %M %Y') AS sales_order_date, a.id_so_type, a.id_so_status "
        query += "FROM tb_sales_order a "
        'query += "INNER JOIN tb_sales_order_det b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_season_delivery e ON e.id_delivery = a.id_delivery "
        query += "INNER JOIN tb_season e1 ON e.id_season = e1.id_season "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_status g ON g.id_so_status = a.id_so_status "
        query += "INNER JOIN tb_lookup_so_type h ON h.id_so_type = a.id_so_type "
        query += "WHERE (a.id_report_status = '3' OR a.id_report_status = '4') "
        If id_delivery <> "-1" Then
            query += "AND a.id_delivery = '" + id_delivery + "' "
        End If
        viewSearchLookupQuery(SLESalesOrder, query, "id_sales_order", "sales_order_number", "id_sales_order")
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT a.id_season, a.id_range, a.season, b.range, "
        query += "DATE_FORMAT(a.date_season_start, '%d %M %Y') AS date_season_start,  "
        query += "DATE_FORMAT(a.date_season_end, '%d %M %Y') AS date_season_end "
        query += "FROM tb_season a  "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY a.date_season_start ASC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewDelivery()
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim query As String = "SELECT id_delivery, delivery FROM tb_season_delivery a WHERE a.id_season = '" + id_season + "' "
        viewSearchLookupQuery(SLEDelivery, query, "id_delivery", "delivery", "id_delivery")
    End Sub

    Private Sub LEStatusSO_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEStatusSO.EditValueChanged
        
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesDelOrderPrintOpt_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        If SLESeason.EditValue = Nothing Then
            SLESeason.EditValue = id_season_default
        Else
            id_season_default = SLESeason.EditValue.ToString
        End If
        viewDelivery()
    End Sub

    Private Sub SLEDelivery_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDelivery.EditValueChanged
        Dim id_delivery As String = "-1"
        Try
            id_delivery = SLEDelivery.EditValue
        Catch ex As Exception

        End Try
        viewSalesOrder(id_delivery)
    End Sub

    Private Sub SLESalesOrder_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESalesOrder.EditValueChanged
        Dim id_so_status As String = "-1"
        Try
            id_so_status = SLESalesOrder.Properties.View.GetFocusedRowCellValue("id_so_status")
        Catch ex As Exception

        End Try
        viewSoStatus(id_so_status)
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        Dim id_delivery As String = SLEDelivery.EditValue.ToString
        Dim id_sales_order As String = SLESalesOrder.EditValue.ToString
        Dim id_so_status As String = LEStatusSO.EditValue.ToString
        If id_sales_order = "0" Then
            ReportSalesOrderAll.id_sales_order = id_sales_order
            ReportSalesOrderAll.id_delivery = id_delivery
            ReportSalesOrderAll.id_so_status = id_so_status
            Dim Report As New ReportSalesOrderAll()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        Else
            ReportSalesOrder.id_sales_order = id_sales_order
            Dim Report As New ReportSalesOrder()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub
End Class