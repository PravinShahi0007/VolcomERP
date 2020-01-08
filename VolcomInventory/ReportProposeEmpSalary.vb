Public Class ReportProposeEmpSalary
    Public id_employee_sal_pps As String = "-1"
    Public type As String = "1"
    Public category As String = "1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = data

        GCEmployeeStatus.Caption = GCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        GCLengthOfWork.Caption = "Length of Work" + Environment.NewLine + "(Year)"
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

            GCIncreaseRp.UnboundExpression = "[basic_salary] - [basic_salary_current]"
        End If

        If category = "1" Then
            GBSalary.Caption = "Salary"

            GBSalaryCurrent.Visible = False
            GBIncrease.Visible = False

            GBNote.Visible = False
        ElseIf category = "2" Then
            If type = "1" Then
                GCBasicSalary.Visible = False
            ElseIf type = "2" Then
                GCTotalSalary.Visible = False
            End If

            GCJobAllowance.Visible = False
            GCMealAllowance.Visible = False
            GCTransportAllowance.Visible = False
            GCHouseAllowance.Visible = False
            GCAttendanceAllowance.Visible = False

            If type = "1" Then
                GCBasicSalaryCurrent.Visible = False
            ElseIf type = "2" Then
                GCTotalSalaryCurrent.Visible = False
            End If

            GCJobAllowanceCurrent.Visible = False
            GCMealAllowanceCurrent.Visible = False
            GCTransportAllowanceCurrent.Visible = False
            GCHouseAllowanceCurrent.Visible = False
            GCAttendanceAllowanceCurrent.Visible = False

            GBNote.Visible = True
        End If

        GVEmployee.BestFitColumns()

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps, 0, True, "", "", "", "")

        If id_report_status = "0" Then
            XrTable1.Visible = False
        Else
            If is_pre = "-1" Then
                load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "1", XrTable1)
            Else
                pre_load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "2", XrTable1)
            End If
        End If
    End Sub

    Private Sub GVEmployee_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVEmployee.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "increase" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim percentage As Decimal = 0.00

                    Try
                        If e.IsGroupSummary Then
                            If type = "2" Then
                                percentage = e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(14)) / e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(7)) * 100
                            Else
                                percentage = e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(14)) / e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(13)) * 100
                            End If

                            Dim percentage_str As String = Decimal.Round(percentage, 2).ToString.Replace(",", ".")

                            e.TotalValue = percentage_str + If(Not percentage_str.Contains("."), ".00", "") + "%"
                        ElseIf e.IsTotalSummary Then
                            If type = "2" Then
                                percentage = (GVEmployee.Columns("basic_salary").SummaryItem.SummaryValue - GVEmployee.Columns("basic_salary_current").SummaryItem.SummaryValue) / GVEmployee.Columns("basic_salary_current").SummaryItem.SummaryValue * 100
                            Else
                                percentage = (GVEmployee.Columns("total_salary").SummaryItem.SummaryValue - GVEmployee.Columns("total_salary_current").SummaryItem.SummaryValue) / GVEmployee.Columns("total_salary_current").SummaryItem.SummaryValue * 100
                            End If

                            Dim percentage_str As String = Decimal.Round(percentage, 2).ToString.Replace(",", ".")

                            e.TotalValue = percentage_str + If(Not percentage_str.Contains("."), ".00", "") + "%"
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub
End Class