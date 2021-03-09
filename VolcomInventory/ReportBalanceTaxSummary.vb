Public Class ReportBalanceTaxSummary
    Public id_summary As String = "-1"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportBalanceTaxSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz("284", id_summary, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("284", id_summary, "2", "2", XrTable1)
        End If

        For i = 0 To XrTable1.Rows(1).Cells.Count - 1
            If XrTable1.Rows(1).Cells(i).Text = "Approved By," Then
                XrTable1.Rows(1).Cells(i).Text = "Acknowledge By,"
            End If
        Next
    End Sub
End Class