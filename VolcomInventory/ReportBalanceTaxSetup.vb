Public Class ReportBalanceTaxSetup
    Public id_setup_tax As String = "-1"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportBalanceTaxSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSetupTax.DataSource = data
        GVSetupTax.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz("288", id_setup_tax, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("288", id_setup_tax, "2", "2", XrTable1)
        End If
    End Sub
End Class