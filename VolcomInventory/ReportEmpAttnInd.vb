﻿Public Class ReportEmpAttnInd
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"

    Private Sub ReportEmpAttnInd_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = dt
    End Sub
End Class