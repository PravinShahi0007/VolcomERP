Public Class FormInfoSalesReturn 
    Public id_sales_return As String = "-1"
    Public id_sales_return_det As String = "-1"
    Public id_sales_return_qc As String = "0"
    Public id_pop_up As String

    Private Sub FormInfoSalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_sales_return WHERE id_sales_return = '" + id_sales_return + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Return No. :" + data.Rows(0)("sales_return_number").ToString
        view_list_so(id_sales_return)
    End Sub

    Sub view_list_so(ByVal id_sales_return_order As String)
        Dim query As String = ""
        If id_pop_up = "1" Then
            query = "CALL view_sales_return_limit('" + id_sales_return + "', '" + id_sales_return_det + "', '" + id_sales_return_qc + "')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub FormInfoSalesReturn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class