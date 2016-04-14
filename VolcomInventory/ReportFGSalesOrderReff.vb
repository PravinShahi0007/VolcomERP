Public Class ReportFGSalesOrderReff
    Public Shared dt As DataTable
    Public Shared id_report As String = "-1"


    Private Sub ReportFGSalesOrderReff_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDesign.DataSource = dt

        'mark
        load_mark_horz("75", id_report, "2", "1", XrTable1)
    End Sub
End Class