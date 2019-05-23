Public Class ReportProposeEmpSalary
    Public id_employee_sal_pps As String = "-1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = data

        If is_pre = "-1" Then
            load_mark_horz("197", id_employee_sal_pps, "2", "1", XrTable1)
        Else
            load_mark_horz("197", id_employee_sal_pps, "2", "2", XrTable1)
        End If
    End Sub
End Class