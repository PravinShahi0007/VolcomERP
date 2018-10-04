Public Class ReportPurcOrder
    Public Shared id_po As String
    Public Shared dt As DataTable

    Private Sub ReportHeader_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles ReportHeader.BeforePrint

    End Sub

    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = dt
    End Sub
End Class