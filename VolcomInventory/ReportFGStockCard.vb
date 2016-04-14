Public Class ReportFGStockCard
    Public Shared id_design As String = "-1"
    Public Shared code_design As String = ""
    Public Shared desc_design As String = ""
    Public Shared id_wh As String = "-1"
    Public Shared code_wh As String = ""
    Public Shared wh As String = ""
    Public Shared componentLink As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
    Public Shared GC As DevExpress.XtraGrid.GridControl
    Public Shared GV As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Public Shared dt As DataTable
    Public Shared str_param As System.IO.Stream

    Private Sub ReportFGStockCard_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub
End Class