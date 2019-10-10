Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"
    Public overtime_date As DateTime = Now
    Public overtime_start_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 8, 30, 0)
    Public overtime_end_time As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 17, 30, 0)
    Public overtime_break As Decimal = 0.0
    Public overtime_propose As String = ""

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
        MEOvertimeNote.EditValue = overtime_propose

        Dim include_all_dept As String = execute_query("SELECT include_all_dept FROM tb_lookup_ot_type WHERE id_ot_type = " + FormEmpOvertimeDet.LUEOvertimeType.EditValue.ToString, 0, True, "", "", "", "")

        Dim whereDept As String = ""

        'sales dept include sogo
        If FormEmpOvertimeDet.LEDepartement.EditValue.ToString = "11" Then
            whereDept = "AND e.id_departement IN (" + FormEmpOvertimeDet.LEDepartement.EditValue.ToString + ", 17)"
        Else
            whereDept = "AND e.id_departement = " + FormEmpOvertimeDet.LEDepartement.EditValue.ToString
        End If

        If include_all_dept = "1" Then
            whereDept = ""
        End If

        'not include employee
        Dim whereNotInclude As String = ""

        For i = 0 To FormEmpOvertimeDet.GVEmployee.RowCount - 1
            If FormEmpOvertimeDet.GVEmployee.IsValidRowHandle(i) Then
                Dim ot_start_time As DateTime = FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "ot_start_time")
                Dim ot_end_time As DateTime = FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "ot_end_time")

                If ((ot_start_time > TEOvertimeStart.EditValue And ot_start_time < TEOvertimeEnd.EditValue) Or (ot_end_time > TEOvertimeStart.EditValue And ot_end_time < TEOvertimeEnd.EditValue)) Or ((TEOvertimeStart.EditValue > ot_start_time And TEOvertimeStart.EditValue < ot_end_time) Or (TEOvertimeEnd.EditValue > ot_start_time And TEOvertimeEnd.EditValue < ot_end_time)) Or ((ot_start_time = TEOvertimeStart.EditValue And ot_end_time = TEOvertimeEnd.EditValue)) Then
                    whereNotInclude += FormEmpOvertimeDet.GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", "
                End If
            End If
        Next

        Dim time_start As String = DateTime.Parse(TEOvertimeStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim time_end As String = DateTime.Parse(TEOvertimeEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")

        'not include employee from other propose
        Dim query_not_include As String = "
            SELECT ot_det.id_employee
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            WHERE ot.id_report_status <> 5
	            AND ((('" + time_start + "' > ot_det.ot_start_time AND '" + time_start + "' < ot_det.ot_end_time) OR ('" + time_end + "' > ot_det.ot_start_time AND  '" + time_end + "' < ot_det.ot_end_time))
	            OR ((ot_det.ot_start_time > '" + time_start + "' AND ot_det.ot_start_time < '" + time_end + "') OR (ot_det.ot_end_time > '" + time_start + "' AND ot_det.ot_end_time < '" + time_end + "'))
                OR (ot_det.ot_start_time = '" + time_start + "' AND ot_det.ot_end_time = '" + time_end + "'))
        "

        Dim data_not_include As DataTable = execute_query(query_not_include, -1, True, "", "", "", "")

        For i = 0 To data_not_include.Rows.Count - 1
            whereNotInclude += data_not_include.Rows(i)("id_employee").ToString + ", "
        Next

        If Not whereNotInclude = "" Then
            whereNotInclude = "AND e.id_employee NOT IN (" + whereNotInclude.Substring(0, whereNotInclude.Length - 2) + ")"
        End If

        Dim query As String = "
            SELECT 'no' AS is_checked, e.id_employee, e.id_departement, ds.id_departement_sub, d.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, st.employee_status, e.id_employee_active, la.employee_active, IF(salary.salary > (ds.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)), '2', '1') AS to_salary, IF((sch.id_schedule_type = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + Date.Parse(overtime_date.ToString).ToString("yyyy-MM-dd") + "' AND id_religion IN (0, IF(d.is_store = 1, 0, e.id_religion))) IS NULL), 2, 1) AS is_day_off
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_m_departement_sub AS ds ON IFNULL(e.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = e.id_departement LIMIT 1)) = ds.id_departement_sub
            LEFT JOIN tb_lookup_employee_status AS st ON e.id_employee_status = st.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
            LEFT JOIN (
	            SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
	            FROM tb_m_employee
            ) AS salary ON e.id_employee = salary.id_employee
            LEFT JOIN tb_emp_schedule AS sch ON sch.id_employee = e.id_employee AND sch.date = '" + Date.Parse(overtime_date.ToString).ToString("yyyy-MM-dd") + "'
            WHERE 1 " + whereDept + " " + whereNotInclude + "
            ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        'find Active by id
        Dim active As String = ""

        For i = 1 To data.Rows.Count - 1
            If data.Rows(i)("id_employee_active").ToString = "1" Then
                active = data.Rows(i)("employee_active").ToString

                Exit For
            End If
        Next

        GVList.ActiveFilter.Add(GVList.Columns("employee_active"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[employee_active] = '" + active + "'"))

        'filter employee get overtime
        Dim ot_min_spv As Decimal = get_opt_emp_field("ot_min_spv")

        If TETotalHours.EditValue < ot_min_spv Then
            GVList.ActiveFilter.Add(GVList.Columns("to_salary"), New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[to_salary] = '1'"))
        End If

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormEmpOvertimeDate.Close()

        pick()
    End Sub

    Sub pick()
        GVList.ApplyFindFilter("")

        GVList.ExpandAllGroups()

        Dim data As DataTable = FormEmpOvertimeDet.GCEmployee.DataSource

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "is_checked") = "yes" Then
                Dim conversion_type As String = If(GVList.GetRowCellValue(i, "to_salary") = "1", "1", If(GVList.GetRowCellValue(i, "is_day_off") = "1", "2", "3"))

                data.Rows.Add(GVList.GetRowCellValue(i, "id_employee"),
                            GVList.GetRowCellValue(i, "id_departement"),
                            GVList.GetRowCellValue(i, "id_departement_sub"),
                            GVList.GetRowCellValue(i, "departement"),
                            Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("dd MMM yyyy"),
                            GVList.GetRowCellValue(i, "employee_code"),
                            GVList.GetRowCellValue(i, "employee_name"),
                            GVList.GetRowCellValue(i, "employee_position"),
                            GVList.GetRowCellValue(i, "id_employee_status"),
                            GVList.GetRowCellValue(i, "employee_status"),
                            GVList.GetRowCellValue(i, "to_salary"),
                            conversion_type,
                            GVList.GetRowCellValue(i, "is_day_off"),
                            TEOvertimeStart.EditValue,
                            TEOvertimeEnd.EditValue,
                            TEOvertimeBreak.EditValue,
                            TETotalHours.EditValue,
                            MEOvertimeNote.EditValue.ToString)
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