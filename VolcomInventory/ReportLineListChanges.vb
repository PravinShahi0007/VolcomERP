Public Class ReportLineListChanges
    Public Shared id_design_rev As String
    Public Shared id_pre As String
    Public Shared dt As DataTable

    Private Sub ReportLineListChanges_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If id_pre = "-1" Then
            load_mark_horz("176", id_design_rev, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("176", id_design_rev, "2", "2", XrTable1)
        End If
    End Sub
End Class