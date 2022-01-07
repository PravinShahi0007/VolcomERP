Public Class ReportSalesOrderViewRef
    Public Shared dt As DataTable

    Private Sub ReportSalesOrderViewRef_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'fill
        GCNewPrepare.DataSource = dt
        GVNewPrepare.BestFitColumns()

        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date`, '" + name_user + "' AS `print_user` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd


    End Sub

    Private Sub GVNewPrepare_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNewPrepare.CustomColumnDisplayText
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName <> "NO" Then Return
        If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
            Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
            e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
        End If
    End Sub
End Class