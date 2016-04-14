Public Class FormSampleDelRecInfo 
    Public id_sample_del As String = ""
    Public is_mode_check As Boolean = False
    Public qty_check As Decimal = 0.0
    Public id_sample_del_det_cek As String = "-1"

    Private Sub FormSampleDelRecInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleDelDet()
    End Sub

    Sub viewSampleDelDet()
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryDetail(id_sample_del)
        If Not is_mode_check Then
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSampleDelList.DataSource = data
        Else
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_sample_del_det = '" + id_sample_del_det_cek + "' "
            Dim data As DataTable = dtd_temp.DefaultView.ToTable
            GCSampleDelList.DataSource = data
            Try
                GVSampleDelList.SetFocusedRowCellValue("sample_del_det_qty_receiving", qty_check)
                GCSampleDelList.RefreshDataSource()
                GVSampleDelList.RefreshData()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FormSampleDelRecInfo_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVSampleDelList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSampleDelList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class