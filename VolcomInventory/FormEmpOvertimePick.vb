Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"
    Public overtime_date As DateTime = Now
    Public overtime_start_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 8, 30, 0)
    Public overtime_end_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 17, 30, 0)
    Public overtime_break As Decimal = 0.0
    Public id_payroll As String = "-1"

    Private Sub FormEmpOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Pick"
        Else
            Text = "Overtime Management Pick"
        End If

        'load
        DEOvertimeDate.EditValue = overtime_date
        TEOvertimeStart.EditValue = overtime_start_time
        TEOvertimeEnd.EditValue = overtime_end_time
        TEOvertimeBreak.EditValue = overtime_break

        Dim whereHrd As String = If(is_hrd = "-1", "AND e.id_departement = " + id_departement_user + "", "")

        Dim whereNotInclude As String = ""

        For i = 0 To FormEmpOvertimeDet.GVEmployee.RowCount - 1
            If FormEmpOvertimeDet.GVEmployee.IsValidRowHandle(i) Then
                Dim date_1 As String = Date.Parse(FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "date").ToString).ToString("yyyy-MM-dd")
                Dim date_2 As String = Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd")

                If date_2 = date_1 Then
                    whereNotInclude += FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", "
                End If
            End If
        Next

        If Not whereNotInclude = "" Then
            whereNotInclude = "AND e.id_employee NOT IN (" + whereNotInclude.Substring(0, whereNotInclude.Length - 2) + ")"
        End If

        Dim query As String = "
            SELECT e.id_employee, 'no' AS is_checked, e.id_departement, IFNULL(e.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = e.id_departement LIMIT 1)) AS id_departement_sub, d.departement, d.is_store, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, st.employee_status, e.id_employee_active, la.employee_active, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no') AS only_dp
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_status AS st ON e.id_employee_status = st.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
            LEFT JOIN (
                SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                FROM tb_m_employee
            ) AS salary ON e.id_employee = salary.id_employee
            WHERE 1 " + whereHrd + " " + whereNotInclude + "
            ORDER BY e.id_employee_level ASC, e.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        ' find Active by id
        Dim active As String = ""

        For i = 1 To data.Rows.Count - 1
            If data.Rows(i)("id_employee_active").ToString = "1" Then
                active = data.Rows(i)("employee_active").ToString

                Exit For
            End If
        Next

        GVList.ActiveFilter.Add(GVList.Columns("employee_active"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[employee_active] = '" + active + "'"))

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        pick()
    End Sub

    Sub pick()
        GVList.ApplyFindFilter("")

        GVList.ExpandAllGroups()

        Dim data As DataTable = FormEmpOvertimeDet.GCEmployee.DataSource

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "is_checked") = "yes" Then
                Dim conversion_type As String = If(GVList.GetRowCellValue(i, "only_dp") = "yes", "2", "1")

                data.Rows.Add(GVList.GetRowCellValue(i, "id_employee"),
                              GVList.GetRowCellValue(i, "only_dp"),
                              GVList.GetRowCellValue(i, "id_departement"),
                              GVList.GetRowCellValue(i, "id_departement_sub"),
                              GVList.GetRowCellValue(i, "departement"),
                              Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("dd MMM yyyy"),
                              GVList.GetRowCellValue(i, "employee_code"),
                              GVList.GetRowCellValue(i, "employee_name"),
                              GVList.GetRowCellValue(i, "employee_position"),
                              GVList.GetRowCellValue(i, "id_employee_status"),
                              GVList.GetRowCellValue(i, "employee_status"),
                              conversion_type,
                              TEOvertimeStart.EditValue,
                              TEOvertimeEnd.EditValue,
                              TEOvertimeBreak.EditValue,
                              TETotalHours.EditValue)
            End If
        Next

        FormEmpOvertimeDet.GCEmployee.DataSource = data

        FormEmpOvertimeDet.GCEmployee.RefreshDataSource()

        FormEmpOvertimeDet.GVEmployee.BestFitColumns()

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Sub calculateTotalHours()
        Dim ot_start As DateTime = TEOvertimeStart.EditValue
        Dim ot_end As DateTime = TEOvertimeEnd.EditValue

        Dim diff As TimeSpan = ot_end.Subtract(ot_start)

        Dim total As Decimal = 0.0

        total = Math.Round(Math.Round(diff.TotalHours, 1) - TEOvertimeBreak.EditValue, 1)

        TETotalHours.EditValue = total
    End Sub

    Private Sub DEOvertimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEOvertimeDate.EditValueChanged
        'time
        Dim ot_date As DateTime = DEOvertimeDate.EditValue

        Dim ot_start As DateTime = TEOvertimeStart.EditValue
        Dim ot_end As DateTime = TEOvertimeEnd.EditValue

        Dim plus_days As Integer = ot_end.Subtract(ot_start).TotalDays

        'disable time
        TEOvertimeStart.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)
        TEOvertimeStart.Properties.MaxValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 23, 59, 59)

        TEOvertimeEnd.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)

        'change time date
        TEOvertimeStart.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_start.Hour, ot_start.Minute, ot_start.Second)
        TEOvertimeEnd.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_end.Hour, ot_end.Minute, ot_end.Second).AddDays(plus_days)
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeBreak.EditValueChanged
        calculateTotalHours()
    End Sub
End Class