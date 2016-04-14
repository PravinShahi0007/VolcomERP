Public Class FormInfoSRS 
    Public id_sample_requisition As String = "0"
    Private Sub FormInfoSRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDetailReq()
    End Sub
    Sub viewDetailReq()
        Dim query As String = "CALL view_sample_req_det_limit('" + id_sample_requisition + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        viewPLSrs()
    End Sub
    Sub viewPLSrs()
        Dim id_srs_det As String = GVRetDetail.GetFocusedRowCellValue("id_sample_requisition_det")
        Dim query As String = "CALL view_pl_sample_del_srs('" + id_srs_det + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCreatedPLDetail.DataSource = data
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        viewPLSrs()
    End Sub
End Class