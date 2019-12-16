Public Class ReportProposeEmpSalary
    Public id_employee_sal_pps As String = "-1"
    Public type As String = "1"
    Public category As String = "1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = data

        GCEmployeeStatus.Caption = GCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        GCBasicSalary.Caption = GCBasicSalary.Caption.Replace(" ", Environment.NewLine)
        GCJobAllowance.Caption = GCJobAllowance.Caption.Replace(" ", Environment.NewLine)
        GCMealAllowance.Caption = GCMealAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTransportAllowance.Caption = GCTransportAllowance.Caption.Replace(" ", Environment.NewLine)
        GCHouseAllowance.Caption = GCHouseAllowance.Caption.Replace(" ", Environment.NewLine)
        GCAttendanceAllowance.Caption = GCAttendanceAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalary.Caption = GCTotalSalary.Caption.Replace(" ", Environment.NewLine)
        GCBasicSalaryCurrent.Caption = GCBasicSalaryCurrent.Caption.Replace(" ", Environment.NewLine)
        GCJobAllowanceCurrent.Caption = GCJobAllowanceCurrent.Caption.Replace(" ", Environment.NewLine)
        GCMealAllowanceCurrent.Caption = GCMealAllowanceCurrent.Caption.Replace(" ", Environment.NewLine)
        GCTransportAllowanceCurrent.Caption = GCTransportAllowanceCurrent.Caption.Replace(" ", Environment.NewLine)
        GCHouseAllowanceCurrent.Caption = GCHouseAllowanceCurrent.Caption.Replace(" ", Environment.NewLine)
        GCAttendanceAllowanceCurrent.Caption = GCAttendanceAllowanceCurrent.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalaryCurrent.Caption = GCTotalSalaryCurrent.Caption.Replace(" ", Environment.NewLine)
        GCFixedSalary.Caption = GCFixedSalary.Caption.Replace(" ", Environment.NewLine)
        GCNonFixedSalary.Caption = GCNonFixedSalary.Caption.Replace(" ", Environment.NewLine)

        If type = "2" Then
            GCBasicSalary.Caption = "Daily" + Environment.NewLine + "Salary"
            GCBasicSalaryCurrent.Caption = "Daily" + Environment.NewLine + "Salary"

            GCJobAllowance.VisibleIndex = -1
            GCMealAllowance.VisibleIndex = -1
            GCTransportAllowance.VisibleIndex = -1
            GCHouseAllowance.VisibleIndex = -1
            GCAttendanceAllowance.VisibleIndex = -1
            GCTotalSalary.VisibleIndex = -1
        End If

        If category = "1" Then
            GBSalary.Caption = "Salary"

            GBSalaryCurrent.Visible = False
            GBIncrease.Visible = False
        ElseIf category = "2" Then
            GCBasicSalary.Visible = False
            GCJobAllowance.Visible = False
            GCMealAllowance.Visible = False
            GCTransportAllowance.Visible = False
            GCHouseAllowance.Visible = False
            GCAttendanceAllowance.Visible = False

            If type = "1" Then
                GCBasicSalaryCurrent.Visible = False
                GCJobAllowanceCurrent.Visible = False
                GCMealAllowanceCurrent.Visible = False
                GCTransportAllowanceCurrent.Visible = False
                GCHouseAllowanceCurrent.Visible = False
                GCAttendanceAllowanceCurrent.Visible = False
            End If
        End If

        GVEmployee.BestFitColumns()

        If is_pre = "-1" Then
            load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "2", XrTable1)
        End If
    End Sub
End Class