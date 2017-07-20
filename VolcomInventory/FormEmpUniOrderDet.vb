Public Class FormEmpUniOrderDet
    Public id_sales_order As String = "-1"

    Private Sub FormEmpUniOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassEmpUni()
        Dim query As String = query_c.queryMainOrder("AND so.id_sales_order=" + id_sales_order + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNIK.Text = data.Rows(0)("employee_code").ToString
        TxtName.Text = data.Rows(0)("employee_name").ToString
        TxtDept.Text = data.Rows(0)("departement").ToString
        TxtLevel.Text = data.Rows(0)("employee_level").ToString
        TxtOrderNumber.Text = data.Rows(0)("sales_order_number").ToString
        TxtPeriodName.Text = data.Rows(0)("period_name").ToString
        MENote.Text = data.Rows(0)("sales_order_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        If data.Rows(0)("id_report_status").ToString = 5 Or data.Rows(0)("id_report_status").ToString = 6 Then
            BtnAccept.Visible = False
            BtnCancelOrder.Visible = False
        End If
        viewDetail()
    End Sub


    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()

    End Sub
    Private Sub FormEmpUniOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class