Public Class FormInfoMRSPord
    Public id_mrs As String = "0"
    Private Sub FormInfoMRSPord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDetailReq()
    End Sub
    Sub viewDetailReq()
        Dim query As String = "CALL view_prod_order_mrs_limit('" + id_mrs + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        If data.Rows.Count > 0 Then
            viewPLMrs()
        End If
    End Sub
    Sub viewPLMrs()
        Dim id_srs_det As String = GVRetDetail.GetFocusedRowCellValue("id_prod_order_mrs_det")
        Dim query As String = "CALL view_pl_mrs_mrs('" + id_srs_det + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCreatedPLDetail.DataSource = data
    End Sub
    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        viewPLMrs()
    End Sub
End Class