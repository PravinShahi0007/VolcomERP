Public Class FormSampleDelOrderInfo 
    Public id_sample_order As String = ""
    Public is_mode_check As Boolean = False
    Public qty_check As Decimal = 0.0
    Public id_sample_order_det_cek As String = "-1"
    Public id_pl_sample_order_del As String = "-1"

    Private Sub FormSampleDelOrderInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleOrder()
    End Sub

    Sub viewSampleOrder()
        Dim id_pl_param As String = ""
        If id_pl_sample_order_del = "-1" Then
            id_pl_param = "0"
        Else
            id_pl_param = id_pl_sample_order_del
        End If

        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryDetailLimit(id_sample_order, id_pl_param)
        If Not is_mode_check Then
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSampleOrder.DataSource = data
        Else
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_sample_order_det = '" + id_sample_order_det_cek + "' "
            Dim data As DataTable = dtd_temp.DefaultView.ToTable
            GCListSampleOrder.DataSource = data
            Try
                GVListSampleOrder.SetFocusedRowCellValue("sample_order_det_qty_delivering", qty_check)
                GCListSampleOrder.RefreshDataSource()
                GVListSampleOrder.RefreshData()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FormSampleDelOrderInfo_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVListSampleOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class