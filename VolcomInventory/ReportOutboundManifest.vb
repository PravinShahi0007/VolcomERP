Public Class ReportOutboundManifest
    Public Shared dt As DataTable

    Private Sub ReportOutboundManifest_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCManifest.DataSource = dt
    End Sub

    Private Sub GVManifest_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVManifest.CellMerge
        If (e.Column.FieldName = "id_awbill" Or e.Column.FieldName = "weight" Or e.Column.FieldName = "length" Or e.Column.FieldName = "width" Or e.Column.FieldName = "height" Or e.Column.FieldName = "volume" Or e.Column.FieldName = "c_weight") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_awbill")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_awbill")
            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub
End Class