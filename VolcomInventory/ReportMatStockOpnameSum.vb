Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatStockOpnameSum
    Public Shared id_mat_so As String
    Public id_comp_contact As String
    Sub view_inventory_mat()
        Try
            Dim query As String = "CALL view_stock_mat_so_result('" & id_mat_so & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatList.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub ReportSampleReturnIn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Dim query As String = "SELECT a.id_mat_so,a.id_comp_contact,a.mat_so_number,a.id_report_status,DATE_FORMAT(a.mat_so_date_created,'%Y-%m-%d') AS mat_so_date_created,DATE_FORMAT(a.mat_so_last_update,'%Y-%m-%d') AS mat_so_last_update,b.report_status,a.id_lock FROM tb_mat_so a INNER JOIN tb_lookup_report_status b ON b.id_report_status=a.id_report_status WHERE a.id_mat_so='" & id_mat_so & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            LabelNo.Text = data.Rows(0)("mat_so_number").ToString
            LabelDate.Text = view_date_from(data.Rows(0)("mat_so_date_created").ToString, 0)
            LLastUpd.Text = view_date_from(data.Rows(0)("mat_so_last_update").ToString, 0)

            id_comp_contact = data.Rows(0)("id_comp_contact").ToString
            LSource.Text = get_company_x(get_id_company(id_comp_contact), "1")
            LSourceAddress.Text = get_company_x(get_id_company(id_comp_contact), "3")

            view_inventory_mat()

            load_mark_horz("52", id_mat_so, "2", "1", XrTable1)
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub GVMatList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class