Public Class ReportEmpPayrollOvertime
    Public id_payroll As String
    Public id_pre As String

    Private Sub ReportEmpPayrollOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "
            SELECT * 
            FROM (
                SELECT IFNULL(dep.departement, dep_ori.departement) AS `Departement`, IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS `Sub Departement`, emp.`employee_code` AS `NIP`, emp.`employee_name` AS `Employee`, emp.`employee_position` AS `Employee Position`, sts.`employee_status` AS `Employee Status`, ot.reg_total_point AS `Point Reguler`, ot.reg_total_wages AS `Overtime Reguler`, (ot.mkt_total_point + ot.ia_total_point + ot.sales_total_point + ot.prod_total_point + ot.hrd_total_point + ot.general_total_point) AS `Point Event`, (IFNULL(ot.mkt_total_wages, 0) + IFNULL(ot.ia_total_wages, 0) + IFNULL(ot.sales_total_wages, 0) + IFNULL(ot.prod_total_wages, 0) + IFNULL(ot.hrd_total_wages, 0)) AS `Overtime Event`, ((SELECT IFNULL(`Overtime Reguler`, 0)) + (SELECT IFNULL(`Overtime Event`, 0))) AS `Total Overtime`, IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) AS is_office_payroll
                FROM tb_emp_payroll_det pyd
                LEFT JOIN tb_emp_payroll py ON py.id_payroll=pyd.id_payroll
                LEFT JOIN tb_m_employee emp ON pyd.id_employee=emp.id_employee
                LEFT JOIN (
                    SELECT * FROM (
                        SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                        FROM tb_m_employee_position
                        WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "')
                        ORDER BY id_employee_position DESC
                    ) AS tab
                    GROUP BY id_employee
                ) AS emp_pos ON pyd.id_employee = emp_pos.id_employee
                LEFT JOIN tb_m_departement dep ON dep.`id_departement`=emp_pos.`id_departement`
                LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
                LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
                LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
                LEFT JOIN `tb_lookup_employee_status` sts ON sts.`id_employee_status`=emp.`id_employee_status`
                LEFT JOIN
                (
                    SELECT ot.id_employee AS id_emp
                    ,SUM(IF(ot.id_ot_type=1,total_hour,0)) AS reg_total_hour,SUM(IF(ot.id_ot_type=1,total_point,0)) AS reg_total_point,SUM(IF(ot.id_ot_type=1,ROUND(((IF(ot.increase = 0.00,IF((SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")=1,(SELECT ot_sal.basic_salary + ot_sal.allow_job + ot_sal.allow_meal + ot_sal.allow_trans),IFNULL(ot_py.dw_overtime_var,(ot_sal.basic_salary*ot_dep.total_workdays))),ot.increase)*(ot_py.ot_reg_pembilang/ot_py.ot_reg_penyebut)*total_point)),10),0)) AS reg_total_wages
                    ,SUM(IF(ot.id_ot_type=2,total_hour,0)) AS mkt_total_hour,SUM(IF(ot.id_ot_type=2,total_point,0)) AS mkt_total_point,SUM(IF(ot.id_ot_type=2,total_point*wages_per_point,0)) AS mkt_total_wages
                    ,SUM(IF(ot.id_ot_type=3,total_hour,0)) AS ia_total_hour,SUM(IF(ot.id_ot_type=3,total_point,0)) AS ia_total_point,SUM(IF(ot.id_ot_type=3,total_point*wages_per_point,0)) AS ia_total_wages
                    ,SUM(IF(ot.id_ot_type=4,total_hour,0)) AS sales_total_hour,SUM(IF(ot.id_ot_type=4,total_point,0)) AS sales_total_point,SUM(IF(ot.id_ot_type=4,total_point*wages_per_point,0)) AS sales_total_wages
                    ,SUM(IF(ot.id_ot_type=5,total_hour,0)) AS prod_total_hour,SUM(IF(ot.id_ot_type=5,total_point,0)) AS prod_total_point,SUM(IF(ot.id_ot_type=5,total_point*wages_per_point,0)) AS prod_total_wages
                    ,SUM(IF(ot.id_ot_type=6,total_hour,0)) AS hrd_total_hour,SUM(IF(ot.id_ot_type=6,total_point,0)) AS hrd_total_point,SUM(IF(ot.id_ot_type=6,total_point*wages_per_point,0)) AS hrd_total_wages
                    ,SUM(IF(ot.id_ot_type=7,total_hour,0)) AS general_total_hour,SUM(IF(ot.id_ot_type=7,total_point,0)) AS general_total_point,SUM(IF(ot.id_ot_type=7,total_point*wages_per_point,0)) AS general_total_wages
                    FROM tb_emp_payroll_ot ot
                    LEFT JOIN tb_emp_payroll AS ot_py ON ot.id_payroll = ot_py.id_payroll
                    LEFT JOIN tb_emp_payroll_det AS ot_py_det ON ot_py.id_payroll = ot_py_det.id_payroll AND ot.id_employee = ot_py_det.id_employee
                    LEFT JOIN tb_m_employee AS ot_emp ON ot.id_employee = ot_emp.id_employee
                    LEFT JOIN tb_m_departement AS ot_dep ON ot_emp.id_departement = ot_dep.id_departement
                    LEFT JOIN (
                        SELECT *
                        FROM tb_m_employee_salary
                        WHERE id_employee_salary IN (SELECT id_salary FROM tb_emp_payroll_det WHERE id_payroll = " + id_payroll + ")
                    ) AS ot_sal ON ot.id_employee = ot_sal.id_employee
                    WHERE ot.id_payroll=IF((SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) = 4, (SELECT id_payroll FROM tb_emp_payroll WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + " LIMIT 1) AND id_payroll_type = 1 LIMIT 1), " + id_payroll + ")
                    GROUP BY ot.id_payroll,ot.id_employee
                ) ot ON ot.id_emp = pyd.`id_employee`
                WHERE pyd.id_payroll = " + id_payroll + "
                ORDER BY emp.id_employee_level ASC, emp.employee_code ASC
            ) AS overtime
            WHERE overtime.`Total Overtime` > 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'departement naming
        data.DefaultView.Sort = "Departement ASC, Sub Departement ASC"
        data = data.DefaultView.ToTable

        Dim alphabet As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        Dim iAlphabet As Integer = 1
        Dim iInterger As Integer = 0

        Dim last_departement As String = ""
        Dim last_departement_sub As String = ""

        For i = 0 To data.Rows.Count - 1
            Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("Departement").ToString, "\(([A-Z])\)", "").ToString()
            Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("Sub Departement").ToString, "\(([A-Z])\)", "").ToString()

            If i = 0 Then
                last_departement = curr_departement
                last_departement_sub = curr_departement_sub
            End If

            If Not last_departement = curr_departement Then
                iAlphabet += 1
                iInterger = 0
            End If

            If Not last_departement_sub = curr_departement_sub Then
                iInterger += 1
            End If

            data.Rows(i)("Departement") = curr_departement + " (" + alphabet(iAlphabet) + ")"
            data.Rows(i)("Sub Departement") = curr_departement_sub + " (" + alphabet(iAlphabet) + iInterger.ToString + ")"

            last_departement = curr_departement
            last_departement_sub = curr_departement_sub
        Next

        'separate store & office
        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        'office
        Dim data_payroll_office As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_office.ImportRow(data.Rows(j))
            End If
        Next

        'store
        Dim data_payroll_store As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_store.ImportRow(data.Rows(j))
            End If
        Next

        GCOvertimeOffice.DataSource = data_payroll_office
        GCOvertimeStore.DataSource = data_payroll_store

        GridColumn3.SummaryItem.DisplayFormat = "Grand Total: " + XLLocationOffice.Text.ToUpper
        GridColumn15.SummaryItem.DisplayFormat = "Grand Total: " + XLLocationStore.Text.ToUpper

        If Not already_office Then
            DetailReportOffice.Visible = False
        End If

        If Not already_store Then
            DetailReportStore.Visible = False
        End If

        'mark
        If id_pre = "-1" Then
            load_mark_horz_plain("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz_plain("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    'office
    Private Sub GVOvertimeOffice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVOvertimeOffice.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    'store
    Private Sub GVOvertimeStore_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVOvertimeStore.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Dim sum_point_reg_office As Double = 0
    Dim sum_ot_reg_office As Double = 0
    Dim sum_point_evt_office As Double = 0
    Dim sum_ot_evt_office As Double = 0
    Dim sum_tot_office As Double = 0

    Dim sum_point_reg_store As Double = 0
    Dim sum_ot_reg_store As Double = 0
    Dim sum_point_evt_store As Double = 0
    Dim sum_ot_evt_store As Double = 0
    Dim sum_tot_store As Double = 0

    Private Sub GVOvertimeOffice_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVOvertimeOffice.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        summary_custom(item, e, GVOvertimeOffice)
    End Sub

    Private Sub GVOvertimeStore_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVOvertimeStore.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        summary_custom(item, e, GVOvertimeStore)
    End Sub

    Sub summary_custom(item As DevExpress.XtraGrid.GridSummaryItem, e As DevExpress.Data.CustomSummaryEventArgs, gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        If item.FieldName.ToString = "Point Reguler" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_point_reg_office = 0
                    Else
                        sum_point_reg_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_point_reg_office += e.FieldValue
                    Else
                        sum_point_reg_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVOvertimeOffice" Then
                            e.TotalValue = sum_point_reg_office
                        Else
                            e.TotalValue = sum_point_reg_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVOvertimeOffice" Then
                                e.TotalValue = sum_point_reg_office
                            Else
                                e.TotalValue = sum_point_reg_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Overtime Reguler" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_ot_reg_office = 0
                    Else
                        sum_point_reg_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_ot_reg_office += e.FieldValue
                    Else
                        sum_point_reg_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVOvertimeOffice" Then
                            e.TotalValue = sum_ot_reg_office
                        Else
                            e.TotalValue = sum_point_reg_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVOvertimeOffice" Then
                                e.TotalValue = sum_ot_reg_office
                            Else
                                e.TotalValue = sum_point_reg_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Point Event" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_point_evt_office = 0
                    Else
                        sum_point_evt_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_point_evt_office += e.FieldValue
                    Else
                        sum_point_evt_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVOvertimeOffice" Then
                            e.TotalValue = sum_point_evt_office
                        Else
                            e.TotalValue = sum_point_evt_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVOvertimeOffice" Then
                                e.TotalValue = sum_point_evt_office
                            Else
                                e.TotalValue = sum_point_evt_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Overtime Event" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_ot_evt_office = 0
                    Else
                        sum_ot_evt_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_ot_evt_office += e.FieldValue
                    Else
                        sum_ot_evt_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVOvertimeOffice" Then
                            e.TotalValue = sum_ot_evt_office
                        Else
                            e.TotalValue = sum_ot_evt_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVOvertimeOffice" Then
                                e.TotalValue = sum_ot_evt_office
                            Else
                                e.TotalValue = sum_ot_evt_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Total Overtime" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_tot_office = 0
                    Else
                        sum_tot_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVOvertimeOffice" Then
                        sum_tot_office += e.FieldValue
                    Else
                        sum_tot_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVOvertimeOffice" Then
                            e.TotalValue = sum_tot_office
                        Else
                            e.TotalValue = sum_tot_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVOvertimeOffice" Then
                                e.TotalValue = sum_tot_office
                            Else
                                e.TotalValue = sum_tot_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "Employee" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Try
                        Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(gridView.GetRowCellValue(e.RowHandle, "Departement").ToString, "\(([A-Z])\)", "").ToString()
                        Dim alphabet As String = gridView.GetRowCellValue(e.RowHandle, "Departement").ToString.Replace(curr_departement, "")

                        Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString, "\(([A-Z][0-9])\)", "").ToString()
                        Dim alphabet_sub As String = gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Replace(curr_departement_sub, "")

                        If gridView.GetRowCellValue(e.RowHandle, "Sub Departement").ToString.Contains("SOGO") Then
                            If e.GroupLevel = 1 Then
                                e.TotalValue = "Total: " + alphabet_sub.Replace("(", "").Replace(")", "")
                            Else
                                e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                            End If
                        Else
                            If e.GroupLevel = 0 Then
                                e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub
End Class