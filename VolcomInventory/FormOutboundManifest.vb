Public Class FormOutboundManifest
    Public dt As DataTable

    Private Sub FormOutboundManifest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCManifest.DataSource = dt
        For i As Integer = 0 To GVManifest.Columns.Count - 1
            GVManifest.Columns(i).Visible = False
        Next

        GVManifest.Columns("no").Caption = "NO"
        GVManifest.Columns("do_no").Caption = "DELIVERY SLIP"
        GVManifest.Columns("scan_date").Caption = "SCANNED DATE"
        GVManifest.Columns("account").Caption = "STORE ACCOUNT"
        GVManifest.Columns("reff").Caption = "REFF"
        GVManifest.Columns("account_name").Caption = "STORE NAME"
        GVManifest.Columns("qty").Caption = "QTY"
        GVManifest.Columns("comp_group").Caption = "GROUP STORE"
        GVManifest.Columns("weight").Caption = "P"
        GVManifest.Columns("length").Caption = "L"
        GVManifest.Columns("height").Caption = "T"
        GVManifest.Columns("volume").Caption = "DIM"
        GVManifest.Columns("c_weight").Caption = "FINAL WEIGHT"
        GVManifest.Columns("cargo").Caption = "BPL"
        GVManifest.Columns("rmk").Caption = "REMARK"

        GVManifest.Columns("no").VisibleIndex = 0
        GVManifest.Columns("do_no").VisibleIndex = 1
        GVManifest.Columns("account").VisibleIndex = 2
        GVManifest.Columns("account_name").VisibleIndex = 3
        GVManifest.Columns("qty").VisibleIndex = 4
        GVManifest.Columns("comp_group").VisibleIndex = 5
        GVManifest.Columns("weight").VisibleIndex = 6
        GVManifest.Columns("length").VisibleIndex = 7
        GVManifest.Columns("height").VisibleIndex = 8
        GVManifest.Columns("volume").VisibleIndex = 9
        GVManifest.Columns("c_weight").VisibleIndex = 10
        GVManifest.Columns("cargo").VisibleIndex = 11
        GVManifest.Columns("rmk").VisibleIndex = 12
        GVManifest.ColumnPanelRowHeight = 50
    End Sub

    Private Sub FormOutboundManifest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVManifest_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVManifest.CellMerge
        If (e.Column.FieldName = "id_awbill" Or e.Column.FieldName = "weight" Or e.Column.FieldName = "length" Or e.Column.FieldName = "width" Or e.Column.FieldName = "height" Or e.Column.FieldName = "volume" Or e.Column.FieldName = "c_weight" Or e.Column.FieldName = "c_tot_price" Or e.Column.FieldName = "a_weight" Or e.Column.FieldName = "a_tot_price" Or e.Column.FieldName = "weight_diff" Or e.Column.FieldName = "amount_diff") Then
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

    Private Sub GVManifest_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVManifest.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class