﻿Public Class FormEmpLeaveDet
    Public id_emp_leave As String = "-1"
    Public id_employee As String = "-1"
    Public id_employee_change As String = "-1"
    '
    Public is_view As String = "-1"
    Public report_mark_type As String = "-1"
    '
    Dim file_address As String = ""
    Dim file_name As String = ""
    Dim file_ext As String = ""
    '
    Public is_hrd As String = "-1"
    Public is_reload As String = "2"

    Public adv_leave As Integer = 0

    'id for attachment
    Private id_attachment As String = "-1"

    Private Sub FormEmpLeaveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_emp_leave = "-1" Then
            execute_non_query("UPDATE tb_opt_emp SET id_attachment = (id_attachment + 1)", True, "", "", "", "")

            id_attachment = get_opt_emp_field("id_attachment")
        End If

        If get_opt_emp_field("is_leave_hour") = "2" Then
            TERemainingLeave.Properties.DisplayFormat.FormatString = "N1"
            TERemainingLeave.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TERemainingLeave.Properties.EditFormat.FormatString = "N1"
            TERemainingLeave.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TERemainingLeave.Properties.Mask.EditMask = "N1"
            TERemainingLeave.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            TETotLeave.Properties.DisplayFormat.FormatString = "N1"
            TETotLeave.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TETotLeave.Properties.EditFormat.FormatString = "N1"
            TETotLeave.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TETotLeave.Properties.Mask.EditMask = "N1"
            TETotLeave.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            TERemainingLeaveAfter.Properties.DisplayFormat.FormatString = "N1"
            TERemainingLeaveAfter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TERemainingLeaveAfter.Properties.EditFormat.FormatString = "N1"
            TERemainingLeaveAfter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TERemainingLeaveAfter.Properties.Mask.EditMask = "N1"
            TERemainingLeaveAfter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            TEAdvLeaveTot.Properties.DisplayFormat.FormatString = "N1"
            TEAdvLeaveTot.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TEAdvLeaveTot.Properties.EditFormat.FormatString = "N1"
            TEAdvLeaveTot.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            TEAdvLeaveTot.Properties.Mask.EditMask = "N1"
            TEAdvLeaveTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            GVLeaveDet.Columns("hours_total").DisplayFormat.FormatString = "N1"
            GVLeaveDet.Columns("hours_total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            GVLeaveRemaining.Columns("qty").DisplayFormat.FormatString = "N1"
            GVLeaveRemaining.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            GVLeaveUsage.Columns("qty").DisplayFormat.FormatString = "N1"
            GVLeaveUsage.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            GVMutasi.Columns("qty_hr").DisplayFormat.FormatString = "N1"
            GVMutasi.Columns("qty_hr").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            GVMutasi.Columns("bal_hr").DisplayFormat.FormatString = "N1"
            GVMutasi.Columns("bal_hr").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        End If

        load_form()

        If FormEmpLeave.is_single_user And id_emp_leave = "-1" Then
            Dim data_emp As DataTable = execute_query("SELECT *, (SELECT departement FROM tb_m_departement WHERE id_departement = tb_m_employee.id_departement) AS departement FROM tb_m_employee WHERE id_employee = " + id_employee_user, -1, True, "", "", "", "")

            id_employee = id_employee_user
            TEEmployeeCode.Text = data_emp.Rows(0)("employee_code").ToString
            TEEmployeeName.Text = data_emp.Rows(0)("employee_name").ToString
            TEDept.Text = data_emp.Rows(0)("departement").ToString
            TEPosition.Text = data_emp.Rows(0)("employee_position").ToString
            DEJoinDate.EditValue = data_emp.Rows(0)("employee_join_date")
            load_emp_detail()

            BPickEmployee.Enabled = False
            TEEmployeeCode.Properties.ReadOnly = True
        End If
    End Sub

    Sub load_form()
        '
        is_hrd = FormEmpLeave.is_hrd
        '
        TERemainingLeave.EditValue = 0
        TEAdvLeaveTot.EditValue = 0
        TETotLeave.EditValue = 0
        TERemainingLeaveAfter.EditValue = 0
        '
        is_reload = "1"
        load_leave_type()
        is_reload = "2"

        load_form_dc()
        TENumber.Text = header_number_emp("1")
        '
        SBAttachment.Visible = False
        SBSubmit.Visible = False
        If id_emp_leave = "-1" Then 'new
            TEEmployeeCode.Properties.ReadOnly = False
            BPickEmployee.Visible = True

            DEDateCreated.EditValue = getTimeDB()

            BMark.Visible = False
            BPrint.Visible = False
            '
            load_emp_leave()
            load_but_calc()
            load_emp_leave_usage()
        Else
            XTPLeaveRemaining.PageVisible = False
            PCAddDelLeave.Visible = False
            ' 
            TEEmployeeCode.Properties.ReadOnly = True
            TEEMployeeChange.Properties.ReadOnly = True
            '
            MELeavePurpose.ReadOnly = True
            BPickEmployee.Visible = False
            LELeaveType.Enabled = False
            BSave.Visible = False
            BCancel.Text = "Close"
            '
            BMark.Visible = True
            BPrint.Visible = True
            '
            Dim query As String = "SELECT empl.*,emp.*,empx.employee_code as change_code,empx.employee_name as change_name FROM tb_emp_leave empl
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                    INNER JOIN tb_m_employee empx ON empx.id_employee=empl.id_emp_change
                                    WHERE empl.id_emp_leave='" & id_emp_leave & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            id_employee = data.Rows(0)("id_employee").ToString
            TENumber.Text = data.Rows(0)("emp_leave_number").ToString
            DEDateCreated.EditValue = data.Rows(0)("emp_leave_date")
            '
            report_mark_type = data.Rows(0)("report_mark_type").ToString
            is_reload = "1"
            LELeaveType.ItemIndex = LELeaveType.Properties.GetDataSourceRowIndex("id_leave_type", data.Rows(0)("id_leave_type").ToString)
            is_reload = "2"
            LEFormDC.ItemIndex = LEFormDC.Properties.GetDataSourceRowIndex("id_form_dc", data.Rows(0)("id_form_dc").ToString)
            '
            TEEmployeeCode.Text = data.Rows(0)("employee_code").ToString
            load_emp_detail()
            '
            BPickChange.Visible = False
            TEEMployeeChange.Text = data.Rows(0)("change_code").ToString
            TEEmployeeChangeName.Text = data.Rows(0)("change_name").ToString
            '
            MELeavePurpose.Text = data.Rows(0)("leave_purpose").ToString
            '
            load_emp_leave()
            load_but_calc()
            load_emp_leave_usage()
            '
            TERemainingLeave.EditValue = data.Rows(0)("leave_remaining") / 60
            TETotLeave.EditValue = data.Rows(0)("leave_total") / 60

            If data.Rows(0)("id_attachment").ToString = "" Then
                id_attachment = "-1"
            Else
                id_attachment = data.Rows(0)("id_attachment").ToString
            End If
            'search adv leave this report and before
            Dim query_adv As String = "SELECT id_adv_leave FROM tb_emp_stock_leave_adv WHERE id_emp_leave='" & id_emp_leave & "'"
            Dim data_adv As DataTable = execute_query(query_adv, -1, True, "", "", "", "")
            If data_adv.Rows.Count > 0 Then
                Dim query_adv2 As String = "SELECT id_emp,SUM(qty) AS qty FROM `tb_emp_stock_leave_adv`
                                        WHERE id_emp='" & id_employee & "' AND id_adv_leave<='" & data_adv.Rows(0)("id_adv_leave").ToString & "'
                                        GROUP BY id_emp;"

                Dim data_adv2 As DataTable = execute_query(query_adv2, -1, True, "", "", "", "")
                If data_adv2.Rows.Count > 0 Then
                    adv_leave = data_adv2.Rows(0)("qty") / 60
                    TEAdvLeaveTot.EditValue = adv_leave
                    If TEAdvLeaveTot.EditValue > Integer.Parse(get_opt_emp_field("notif_max_adv_hour")) Then
                        ToolTipController1.ShowHint("Advance Leave sudah melebihi batas yang ditentukan.", TEAdvLeaveTot, DevExpress.Utils.ToolTipLocation.RightCenter)
                    Else
                        ToolTipController1.HideHint()
                    End If
                End If
            End If

            '
            If LELeaveType.EditValue.ToString = "1" Then
                TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue - TETotLeave.EditValue
            Else
                TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue
            End If

            If data.Rows(0)("id_report_status").ToString = "5" Or data.Rows(0)("id_report_status").ToString = "6" Then
                BMark.Visible = False
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    If FormEmpLeave.is_hrd = 1 Then
                        BCancelPropose.Visible = True
                    End If
                End If
            Else
                BMark.Visible = True
                BCancelPropose.Visible = False
            End If

            If LELeaveType.EditValue.ToString = "7" Then
                If data.Rows(0)("id_report_status").ToString = "0" Then
                    SBSubmit.Visible = True
                    SBAttachment.Visible = True
                    BMark.Visible = False
                Else
                    SBSubmit.Visible = False
                    SBAttachment.Visible = True
                    BMark.Visible = True
                    If data.Rows(0)("id_report_status").ToString = "5" Or data.Rows(0)("id_report_status").ToString = "6" Then
                        BMark.Visible = False
                    End If
                End If
            End If

            'button attachment for DC
            If LEFormDC.EditValue.ToString = "3" Then
                SBAttachment.Visible = True
            End If
        End If
        '
    End Sub

    Sub load_form_dc()
        Dim query As String = "SELECT id_form_dc,form_dc FROM tb_lookup_form_dc WHERE is_active = 1"
        viewLookupQuery(LEFormDC, query, 0, "form_dc", "id_form_dc")
    End Sub

    Sub load_leave_type()
        Dim query As String = "SELECT id_leave_type,leave_type FROM tb_lookup_leave_type"
        If Not is_hrd = "1" Then
            query += " WHERE is_hrd='2'"
        End If
        'add other type
        Dim id_leave_type As String = execute_query("SELECT IFNULL((SELECT id_leave_type FROM tb_emp_leave WHERE id_emp_leave = " + id_emp_leave + "), 0 )", 0, True, "", "", "", "")
        If Not id_emp_leave = "-1" Then
            query += " UNION SELECT id_leave_type,leave_type FROM tb_lookup_leave_type WHERE id_leave_type = " + id_leave_type
        End If
        viewLookupQuery(LELeaveType, query, 0, "leave_type", "id_leave_type")
    End Sub

    Sub load_remaining()
        TERemainingLeave.EditValue = 0
        Dim query As String = "SELECT id_emp,SUM(IF(plus_minus=1,qty,-qty))/60 AS qty,`type`,IF(`type`=1,'Leave','DP') as type_ket,date_expired FROM tb_emp_stock_leave
                                WHERE id_emp='" & id_employee & "'
                                GROUP BY id_emp,date_expired,`type`
                                HAVING SUM(IF(plus_minus=1,qty,-qty)) > 0
                                ORDER BY date_expired ASC,`type` DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLeaveRemaining.DataSource = data
        If data.Rows.Count > 0 Then
            TERemainingLeave.EditValue = GVLeaveRemaining.Columns("qty").SummaryItem.SummaryValue
        End If
    End Sub
    Sub load_adv_leave()
        TEAdvLeaveTot.EditValue = 0
        Dim query As String = "SELECT id_emp,SUM(qty)/60 AS qty FROM `tb_emp_stock_leave_adv`
                                WHERE id_emp='" & id_employee & "'
                                GROUP BY id_emp"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            adv_leave = data.Rows(0)("qty")
            TEAdvLeaveTot.EditValue = adv_leave
        End If
    End Sub
    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "1"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Sub load_but_calc()
        If GVLeaveDet.RowCount > 0 Then
            BDelLeave.Visible = True
        Else
            BDelLeave.Visible = False
        End If
        'calc
        If GVLeaveDet.RowCount > 0 Then
            TETotLeave.EditValue = GVLeaveDet.Columns("hours_total").SummaryItem.SummaryValue
            If LELeaveType.EditValue.ToString = "1" Then 'leave
                TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue - TETotLeave.EditValue
                'calculate fifo new only
                If id_emp_leave = "-1" And TERemainingLeaveAfter.EditValue >= 0 And GVLeaveDet.RowCount > 0 And GVLeaveRemaining.RowCount > 0 Then
                    Dim j As Integer = 0
                    Dim total_leave As Integer = TETotLeave.EditValue
                    '
                    clear_grid()
                    '
                    For i As Integer = 0 To GVLeaveRemaining.RowCount - 1
                        Dim leave_remaining As Integer = 0
                        leave_remaining = GVLeaveRemaining.GetRowCellValue(i, "qty")
                        If total_leave - leave_remaining >= 0 Then
                            'use row qty = leave_remaining
                            Dim newRow As DataRow = (TryCast(GCLeaveUsage.DataSource, DataTable)).NewRow()
                            newRow("type") = GVLeaveRemaining.GetRowCellValue(i, "type").ToString
                            newRow("type_ket") = GVLeaveRemaining.GetRowCellValue(i, "type_ket").ToString
                            newRow("date_expired") = GVLeaveRemaining.GetRowCellValue(i, "date_expired")
                            newRow("qty") = GVLeaveRemaining.GetRowCellValue(i, "qty")

                            TryCast(GCLeaveUsage.DataSource, DataTable).Rows.Add(newRow)
                            GCLeaveUsage.RefreshDataSource()
                            '
                            total_leave = total_leave - leave_remaining
                        Else
                            'use row with qty = total leave
                            Dim newRow As DataRow = (TryCast(GCLeaveUsage.DataSource, DataTable)).NewRow()
                            newRow("type") = GVLeaveRemaining.GetRowCellValue(i, "type").ToString
                            newRow("type_ket") = GVLeaveRemaining.GetRowCellValue(i, "type_ket").ToString
                            newRow("date_expired") = GVLeaveRemaining.GetRowCellValue(i, "date_expired")
                            newRow("qty") = total_leave

                            TryCast(GCLeaveUsage.DataSource, DataTable).Rows.Add(newRow)
                            GCLeaveUsage.RefreshDataSource()
                            '
                            total_leave = 0
                            Exit For
                        End If
                    Next
                    TEAdvLeaveTot.EditValue = 0
                End If
            ElseIf LELeaveType.EditValue.ToString = "4" Then 'advance leave
                clear_grid()
                TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue

                If id_emp_leave = "-1" Then 'new
                    TEAdvLeaveTot.EditValue = TETotLeave.EditValue + adv_leave

                    Dim query_adv As String = "SELECT notif_max_adv_hour FROM tb_opt_emp"
                    Dim data_adv As DataTable = execute_query(query_adv, -1, True, "", "", "", "")

                    If TEAdvLeaveTot.EditValue > data_adv.Rows(0)("notif_max_adv_hour") Then
                        ToolTipController1.ShowHint("Advance Leave sudah melebihi batas yang ditentukan.", TEAdvLeaveTot, DevExpress.Utils.ToolTipLocation.RightCenter)
                    Else
                        ToolTipController1.HideHint()
                    End If
                End If
            Else 'sick, special leave, dinas
                '
                clear_grid()
                TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue
            End If
        Else
            clear_grid()
            TETotLeave.EditValue = 0
            TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue
        End If
    End Sub

    Sub clear_grid()
        For i As Integer = GVLeaveUsage.RowCount - 1 To 0 Step -1
            GVLeaveUsage.DeleteRow(i)
        Next
    End Sub

    Private Sub BAddLeave_Click(sender As Object, e As EventArgs) Handles BAddLeave.Click
        pick_load()
    End Sub

    Sub pick_load()
        If id_employee = "-1" Then
            stopCustom("Pilih karyawan terlebih dahulu.")
        Else
            FormEmpLeavePick.id_schedule = "-1"
            FormEmpLeavePick.id_employee = id_employee
            FormEmpLeavePick.ShowDialog()
        End If
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            load_but_calc()
        End If
    End Sub

    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp 
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                                WHERE employee_code='" & TEEmployeeCode.Text & "'"

        If FormEmpLeave.is_departement_sub Then
            query += " AND emp.id_departement_sub IN (SELECT id_departement_sub_map FROM tb_emp_leave_mapping WHERE id_departement_sub = " + id_departement_sub_user + ") "
        End If

        If FormEmpLeave.is_propose = "1" Then
            'Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
            'If id_user_admin_management = id_user Then
            '    Dim id_min_lvl As String = get_opt_emp_field("leave_asst_mgr_level").ToString
            '    query += " AND lvl.id_employee_level>0 AND lvl.id_employee_level <'" & id_min_lvl & "' "
            'Else
            '    query += " AND (dep.id_user_admin='" & id_user & "' OR dep.id_user_admin_backup='" & id_user & "')"
            'End If
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            TEDept.Text = data.Rows(0)("departement").ToString
            TEPosition.Text = data.Rows(0)("employee_position").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            DEJoinDate.EditValue = data.Rows(0)("employee_join_date")
            load_remaining()
            load_adv_leave()
            load_emp_leave()
            load_but_calc()
            '
            If Not XTCDet.SelectedTabPageIndex = 1 Then
                XTCDet.SelectedTabPageIndex = 1
            Else
                XTCDet.SelectedTabPageIndex = 0
                BAddLeave.Focus()
            End If
        Else
            stopCustom("Karyawan tidak ditemukan.")
        End If
    End Sub

    Sub load_emp_leave()
        Dim query As String = "SELECT id_emp_leave_det,id_schedule,datetime_start,datetime_until,IF(is_full_day=1,'yes','no') as is_full_day,minutes_total,(minutes_total/60) as hours_total FROM tb_emp_leave_det where id_emp_leave='" + id_emp_leave + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveDet.DataSource = data
    End Sub

    Sub load_emp_leave_usage()
        Dim query As String = "SELECT id_emp_leave_usage,type,IF(`type`=1,'Leave','DP') as type_ket,date_expired,(qty/60) as qty FROM tb_emp_leave_usage where id_emp_leave='" + id_emp_leave + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveUsage.DataSource = data
    End Sub

    Private Sub BDelLeave_Click(sender As Object, e As EventArgs) Handles BDelLeave.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            GVLeaveDet.DeleteSelectedRows()
            load_but_calc()
        End If
    End Sub

    Private Sub FormEmpLeaveDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        Dim problem As Boolean = False
        Dim check_input As Boolean = True
        Dim leave_type As String = LELeaveType.EditValue.ToString

        'propose max
        Dim max_propose As Integer = 99
        Try
            max_propose = CType(execute_query("
            SELECT sub.max_leave
            FROM tb_m_employee AS emp
            LEFT JOIN tb_m_departement_sub AS sub ON emp.id_departement_sub = sub.id_departement_sub
            WHERE emp.id_employee = " + id_employee + "
        ", 0, True, "", "", "", ""), Integer)
        Catch ex As Exception

        End Try

        Dim check_max_propose As String = ""

        If leave_type = "1" And Not is_hrd = "1" And TETotLeave.EditValue > 0 Then
            Dim data_all As DataTable = CType(GCLeaveDet.DataSource, DataTable).Copy

            'included month
            Dim month_include As List(Of String) = New List(Of String)

            For i = 0 To data_all.Rows.Count - 1
                Dim month As String = "'" + Date.Parse(data_all.Rows(i)("datetime_start").ToString).ToString("yyyy-M") + "'"

                If Not month_include.Contains(month) Then
                    month_include.Add(month)
                End If
            Next

            Dim query_check_max As String = "
                SELECT ld.id_emp_leave_det, ld.id_schedule, ld.datetime_start, ld.datetime_until, IF(ld.is_full_day = 1, 'yes', 'no') AS is_full_day, ld.minutes_total, (ld.minutes_total / 60) AS hours_total
                FROM tb_emp_leave_det AS ld
                LEFT JOIN tb_emp_leave AS l ON ld.id_emp_leave = l.id_emp_leave
                WHERE CONCAT(YEAR(datetime_start), '-', MONTH(datetime_start)) IN (" + String.Join(",", month_include) + ") AND l.id_emp = " + id_employee + " AND l.id_leave_type = " + leave_type + " AND id_report_status <> 5
            "

            data_all.Merge(execute_query(query_check_max, -1, True, "", "", "", ""))

            'check
            Dim total_minutes As DataTable = New DataTable

            total_minutes.Columns.Add("date", GetType(String))
            total_minutes.Columns.Add("total", GetType(Integer))

            For i = 0 To data_all.Rows.Count - 1
                Dim month As String = Date.Parse(data_all.Rows(i)("datetime_start").ToString).ToString("MMMM yyyy")
                Dim minutes_total As Integer = data_all.Rows(i)("minutes_total")

                Dim index As Integer = -1

                For j = 0 To total_minutes.Rows.Count - 1
                    If total_minutes.Rows(j)("date").ToString = month Then
                        index = j

                        Exit For
                    End If
                Next

                If index = -1 Then
                    total_minutes.Rows.Add(month, minutes_total)
                Else
                    total_minutes.Rows(index)("total") = total_minutes.Rows(index)("total") + minutes_total
                End If
            Next

            For i = 0 To total_minutes.Rows.Count - 1
                If total_minutes.Rows(i)("total") > max_propose Then
                    check_max_propose += total_minutes.Rows(i)("date") + ", "
                End If
            Next
        End If

        'continue days
        Dim max_continues As Integer = 5
        Dim check_max_continues As List(Of String) = New List(Of String)

        If leave_type = "1" And Not is_hrd = "1" And TETotLeave.EditValue > 0 Then
            Dim data_all As DataTable = CType(GCLeaveDet.DataSource, DataTable).Copy

            'included months & days
            Dim months_included As List(Of String) = New List(Of String)

            For i = 0 To data_all.Rows.Count - 1
                Dim months As String = Date.Parse(data_all.Rows(i)("datetime_start").ToString).ToString("yyyy-MM-01")

                Dim months_pre As String = Date.Parse(months).AddMonths(-1).ToString("yyyy-MM-01")
                Dim months_nex As String = Date.Parse(months).AddMonths(1).ToString("yyyy-MM-01")

                If Not months_included.Contains(months.Substring(0, months.Length - 3)) Then
                    months_included.Add(months.Substring(0, months.Length - 3))
                End If

                If Not months_included.Contains(months_pre.Substring(0, months.Length - 3)) Then
                    months_included.Add(months_pre.Substring(0, months.Length - 3))
                End If

                If Not months_included.Contains(months_nex.Substring(0, months.Length - 3)) Then
                    months_included.Add(months_nex.Substring(0, months.Length - 3))
                End If
            Next

            'get schedule
            Dim query_in As String = ""

            For i = 0 To months_included.Count - 1
                query_in += "sch.date LIKE '" + months_included(i) + "%' OR "
            Next

            Dim query_schedule As String = "
                SELECT sch.date, IF(lv.id_leave_type = 1, 1, 0) AS is_leave
                FROM tb_emp_schedule AS sch
                LEFT JOIN tb_emp_leave_det AS lvd ON sch.id_schedule = lvd.id_schedule
                LEFT JOIN tb_emp_leave AS lv ON lvd.id_emp_leave = lv.id_emp_leave
                WHERE sch.id_schedule_type = 1 AND (" + query_in.Substring(0, query_in.Length - 4) + ") AND sch.id_employee = " + id_employee + "
                GROUP BY sch.date
            "

            Dim data_sch As DataTable = execute_query(query_schedule, -1, True, "", "", "", "")

            'check match
            For i = 0 To data_sch.Rows.Count - 1
                For j = 0 To data_all.Rows.Count - 1
                    If Date.Parse(data_sch.Rows(i)("date").ToString).ToString("yyyy-MM-dd") = Date.Parse(data_all.Rows(j)("datetime_start").ToString).ToString("yyyy-MM-dd") Then
                        data_sch.Rows(i)("is_leave") = 1
                    End If
                Next
            Next

            'check max continues
            Dim curr_continues As Integer = 0

            For i = 0 To data_sch.Rows.Count - 1
                If data_sch.Rows(i)("is_leave") = 1 Then
                    curr_continues = curr_continues + 1

                    check_max_continues.Add(Date.Parse(data_sch.Rows(i)("date").ToString).ToString("dd MMMM yyyy"))
                Else
                    If curr_continues > max_continues Then
                        'in propose
                        Dim in_propose As Boolean = False

                        For j = 0 To data_all.Rows.Count - 1
                            If check_max_continues.Contains(Date.Parse(data_all.Rows(j)("datetime_start").ToString).ToString("dd MMMM yyyy")) Then
                                in_propose = True
                            End If
                        Next

                        If in_propose Then
                            Exit For
                        End If
                    End If

                    curr_continues = 0

                    check_max_continues = New List(Of String)
                End If

            Next

            If curr_continues <= max_continues Then
                check_max_continues = New List(Of String)
            End If
        End If

        If id_employee = "-1" Or id_employee_change = "-1" Or TETotLeave.EditValue <= 0 Or MELeavePurpose.Text = "" Then
            stopCustom("Lengkapi isian dengan lengkap !")

            check_input = False
        ElseIf TERemainingLeaveAfter.EditValue < 0 Then
            'Dim confirm As DialogResult

            'confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Sisa cuti tidak mencukupi, apakah anda ingin mengajukan unpaid leave?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            ''change to unpaid leave
            'If confirm = DialogResult.Yes Then
            '    leave_type = "7"
            '    TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue

            '    check_input = True
            'Else
            '    check_input = False
            'End If

            stopCustom("Sisa cuti tidak mencukupi.")

            check_input = False
        ElseIf leave_type = "2" And LEFormDC.EditValue.ToString = "1" Then
            stopCustom("Sakit harus menggunakan form atau DC.")

            check_input = False
        ElseIf TEAdvLeaveTot.EditValue > Integer.Parse(get_opt_emp_field("notif_max_adv_hour")) And leave_type = "4" Then
            stopCustom("Advance Leave sudah melebihi batas yang ditentukan.")

            check_input = False
        ElseIf Not check_max_propose = "" Then
            check_max_propose = check_max_propose.Substring(0, check_max_propose.Length - 2)

            stopCustom("Cuti bulan " + check_max_propose + " anda melebihi " + (max_propose / 60).ToString + " jam. Hubungi HRD untuk mengajukan cuti lebih dari " + (max_propose / 60).ToString + " jam.")

            check_input = False
        ElseIf check_max_continues.Count > 0 Then
            stopCustom("Maksimal cuti " + max_continues.ToString + " hari berturut-turut. Tanggal anda cuti dari " + check_max_continues(0) + " - " + check_max_continues(check_max_continues.Count - 1) + ". Hubungi HRD untuk mengajukan cuti lebih dari " + max_continues.ToString + " hari berturut-turut.")

            check_input = False
        Else
            check_input = True
        End If

        If check_input Then
            If leave_type = "2" Then 'sick
                If get_setup_field("is_sick_must_dc") = "1" Then
                    If Not LEFormDC.EditValue.ToString = "3" Then
                        stopCustom("Hanya dapat mengajukan sakit dengan surat keterangan sakit dari dokter (DC).")
                        problem = True
                    End If
                Else
                    If leave_type = "2" And LEFormDC.EditValue.ToString = "2" And GVLeaveDet.RowCount > 1 Then
                        'lebih dari 1 hari sakit pakai form
                        stopCustom("Hanya dapat mengajukan sakit dengan form satu hari dalam satu bulan." & vbNewLine & "Ajukan surat keterangan sakit dari dokter (DC) untuk pengajuan sakit.")
                        problem = True
                    ElseIf leave_type = "2" And LEFormDC.EditValue.ToString = "2" Then
                        'check if sudah form sekali dalam sebulan.
                        Dim date_sick As String = Date.Parse(GVLeaveDet.GetRowCellValue(0, "datetime_start")).ToString("yyyy-MM-dd")
                        '
                        Dim query_cek As String = "SELECT COUNT(lvd.id_emp_leave) FROM tb_emp_leave_det lvd
                                        INNER JOIN tb_emp_leave lv ON lv.id_emp_leave=lvd.id_emp_leave
                                        WHERE DATE_FORMAT(lvd.datetime_start, '%Y-%m') = DATE_FORMAT('" & date_sick & "', '%Y-%m') AND lv.id_emp='" & id_employee & "' AND lv.id_form_dc='2' AND lv.id_leave_type='2' AND lv.id_report_status!='5' "
                        Dim cek As String = execute_query(query_cek, 0, True, "", "", "", "")
                        If Not cek.ToString = "0" Then
                            stopCustom("Hanya dapat mengajukan sakit dengan form satu hari dalam satu bulan." & vbNewLine & "Ajukan surat keterangan sakit dari dokter (DC) untuk pengajuan sakit.")
                            problem = True
                        End If
                    End If
                End If

                If LEFormDC.EditValue.ToString = "3" And Not is_hrd = "1" Then
                    Dim count_attachment As String = execute_query("SELECT COUNT(*) FROM tb_doc WHERE id_report = " + id_attachment + " AND report_mark_type = 411", 0, True, "", "", "", "")

                    If count_attachment = "0" And get_opt_emp_field("required_dc") = "1" Then
                        stopCustom("Mohon scan/upload DC anda pada tombol 'Attachment'.")
                        problem = True
                    End If
                End If
            End If

            If leave_type = "6" Then
                'check if sudah lebih dari 2 jam dalam sebulan.
                Dim query_cek As String = "SELECT SUM(minutes_total) AS total_min FROM tb_emp_leave_det ld
                                        INNER JOIN tb_emp_leave l ON l.id_emp_leave=ld.id_emp_leave
                                        WHERE l.id_leave_type='6' 
                                        AND id_emp='" & id_employee & "' 
                                        AND id_report_status!='5' AND DATE_FORMAT(ld.datetime_start, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')
                                        GROUP BY l.`id_emp`"
                Dim cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")

                Dim total_min As Integer

                If cek.Rows.Count = 0 Then
                    total_min = TETotLeave.EditValue * 60
                Else
                    total_min = cek.Rows(0)("total_min") + (TETotLeave.EditValue * 60)
                End If

                If total_min > get_opt_emp_field("ijin_in_month") Then
                    stopCustom("Hanya dapat mengajukan ijin maksimal 2 jam dalam sebulan.")
                    problem = True
                End If
            End If
            If problem = False Then
                'add parent
                Dim number As String = header_number_emp("1")
                query = "INSERT INTO tb_emp_leave(emp_leave_number,id_emp,emp_leave_date,id_report_status,id_emp_change,leave_purpose,leave_remaining,leave_total,id_leave_type,id_form_dc,id_user_who_create) VALUES('" & number & "','" & id_employee & "',NOW()," + If(leave_type = "7" And Not is_hrd = "1", "0", "1") + ",'" & id_employee_change & "','" & addSlashes(MELeavePurpose.Text) & "','" & (TERemainingLeave.EditValue * 60) & "','" & (TETotLeave.EditValue * 60) & "','" & leave_type & "','" & LEFormDC.EditValue.ToString & "','" & id_user & "');SELECT LAST_INSERT_ID(); "
                id_emp_leave = execute_query(query, 0, True, "", "", "", "")
                increase_inc_emp("1")
                'add detail
                query = "INSERT INTO tb_emp_leave_det(id_emp_leave,id_schedule,datetime_start,datetime_until,is_full_day,minutes_total) VALUES"
                For i As Integer = 0 To GVLeaveDet.RowCount - 1
                    Dim is_full_day As String = "1"
                    If GVLeaveDet.GetRowCellValue(i, "is_full_day").ToString = "yes" Then
                        is_full_day = "1"
                    Else
                        is_full_day = "2"
                    End If
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_emp_leave & "','" & GVLeaveDet.GetRowCellValue(i, "id_schedule").ToString & "','" & Date.Parse(GVLeaveDet.GetRowCellValue(i, "datetime_start").ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(GVLeaveDet.GetRowCellValue(i, "datetime_until").ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & is_full_day & "','" & GVLeaveDet.GetRowCellValue(i, "minutes_total").ToString & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                If leave_type = "1" Then
                    'add usage
                    query = "INSERT INTO tb_emp_leave_usage(id_emp_leave,`type`,date_expired,qty) VALUES"
                    For i As Integer = 0 To GVLeaveUsage.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_emp_leave & "','" & GVLeaveUsage.GetRowCellValue(i, "type").ToString & "','" & Date.Parse(GVLeaveUsage.GetRowCellValue(i, "date_expired").ToString).ToString("yyyy-MM-dd") & "','" & (GVLeaveUsage.GetRowCellValue(i, "qty") * 60).ToString & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    'add to stock leave
                    query = "INSERT INTO tb_emp_stock_leave(id_emp_leave,id_emp,qty,plus_minus,date_leave,date_expired,is_process_exp,note,`type`) VALUES"
                    For i As Integer = 0 To GVLeaveUsage.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_emp_leave & "','" & id_employee & "','" & (GVLeaveUsage.GetRowCellValue(i, "qty") * 60).ToString & "',2,NOW(),'" & Date.Parse(GVLeaveUsage.GetRowCellValue(i, "date_expired").ToString).ToString("yyyy-MM-dd") & "',2,'" & number & "','" & GVLeaveUsage.GetRowCellValue(i, "type").ToString & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                End If

                'store id_attachment dc
                If leave_type = "2" Then
                    Dim count_attachment As String = execute_query("SELECT COUNT(*) FROM tb_doc WHERE id_report = " + id_attachment + " AND report_mark_type = 411", 0, True, "", "", "", "")

                    If Not count_attachment = "0" Then
                        query = "UPDATE tb_emp_leave SET id_attachment = '" + id_attachment + "' WHERE id_emp_leave='" & id_emp_leave & "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If

                If is_hrd = "1" Then
                    submit_who_prepared("102", id_emp_leave, id_user)

                    query = "UPDATE tb_emp_leave SET report_mark_type='102' WHERE id_emp_leave='" & id_emp_leave & "'"
                    execute_non_query(query, True, "", "", "", "")
                Else
                    'if HRM propose
                    If get_opt_emp_field("id_emp_hrd_manager").ToString = id_employee Then
                        If Not leave_type = "7" Then
                            submit_who_prepared_no_user("104", id_emp_leave, id_employee)
                        End If
                        query = "UPDATE tb_emp_leave SET report_mark_type='104' WHERE id_emp_leave='" & id_emp_leave & "'"
                        execute_non_query(query, True, "", "", "", "")
                    Else
                        Dim query_kkunit As String = "SELECT `is_kk_unit`,`is_store` FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.`id_departement`=emp.`id_departement` WHERE id_employee='" & id_employee & "'"
                        Dim data As DataTable = execute_query(query_kkunit, -1, True, "", "", "", "")

                        If data.Rows(0)("is_kk_unit") = 1 Then
                            Dim jum_check_dept_head As String = ""
                            query = "SELECT COUNT(*) as jum FROM tb_m_departement dep
                                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head
                                    WHERE usr.id_employee='" & id_employee & "'"
                            jum_check_dept_head = execute_query(query, 0, True, "", "", "", "")
                            'check if sub dep head
                            Dim jum_check_sub_dept_head As String = ""
                            query = "SELECT COUNT(*) as jum FROM tb_m_departement_sub dep
                                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_usr_head_sub_dept
                                    WHERE usr.id_employee='" & id_employee & "'"
                            jum_check_sub_dept_head = execute_query(query, 0, True, "", "", "", "")
                            'filter by level
                            Dim jum_check As String = ""
                            query = "SELECT IF(id_employee_level >= " & get_opt_emp_field("leave_spv_level").ToString & ",3,IF(id_employee_level < " & get_opt_emp_field("leave_spv_level").ToString & " AND id_employee_level >= " & get_opt_emp_field("leave_asst_mgr_level").ToString & ",2,1)) as jum_cek FROM tb_m_employee WHERE id_employee='" & id_employee & "'"
                            jum_check = execute_query(query, 0, True, "", "", "", "")
                            '1 = mgr up
                            '2 = coordinator - asst mgr
                            '3 = staff - spv
                            If jum_check = "1" Or Not jum_check_dept_head = "0" Then
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("110", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='110' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            ElseIf jum_check = "2" Or Not jum_check_sub_dept_head = "0" Then
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("109", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='109' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("108", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='108' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        ElseIf data.Rows(0)("is_store").ToString = "1" Then
                            Dim query_pic As String = "SELECT is_pic FROM tb_m_employee WHERE id_employee='" & id_employee & "'"
                            Dim data_pic As DataTable = execute_query(query_pic, -1, True, "", "", "", "")
                            If data_pic.Rows(0)("is_pic").ToString = "1" Then 'pic
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("164", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='164' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            Else 'non pic
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("165", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='165' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Else
                            'check if dep head
                            Dim jum_check_dept_head As String = ""
                            query = "SELECT COUNT(*) as jum FROM tb_m_departement dep
                                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head
                                    WHERE usr.id_employee='" & id_employee & "'"
                            jum_check_dept_head = execute_query(query, 0, True, "", "", "", "")
                            'check if sub dep head
                            Dim jum_check_sub_dept_head As String = ""
                            query = "SELECT COUNT(*) as jum FROM tb_m_departement_sub dep
                                    INNER JOIN tb_m_user usr ON usr.id_user=dep.id_usr_head_sub_dept
                                    WHERE usr.id_employee='" & id_employee & "'"
                            jum_check_sub_dept_head = execute_query(query, 0, True, "", "", "", "")
                            'filter by level
                            Dim jum_check As String = ""
                            query = "SELECT IF(id_employee_level >= " & get_opt_emp_field("leave_spv_level").ToString & ",3,IF(id_employee_level < " & get_opt_emp_field("leave_spv_level").ToString & " AND id_employee_level >= " & get_opt_emp_field("leave_asst_mgr_level").ToString & ",2,1)) as jum_cek FROM tb_m_employee WHERE id_employee='" & id_employee & "'"
                            jum_check = execute_query(query, 0, True, "", "", "", "")
                            '1 = mgr up
                            '2 = coordinator - asst mgr
                            '3 = staff - spv
                            If jum_check = "1" Or Not jum_check_dept_head = "0" Then
                                If id_employee = get_opt_emp_field("id_emp_admin_mng").ToString Then
                                    If Not leave_type = "7" Then
                                        submit_who_prepared_no_user("124", id_emp_leave, id_employee)
                                    End If
                                    query = "UPDATE tb_emp_leave SET report_mark_type='124' WHERE id_emp_leave='" & id_emp_leave & "'"
                                    execute_non_query(query, True, "", "", "", "")
                                Else
                                    If Not leave_type = "7" Then
                                        submit_who_prepared_no_user("99", id_emp_leave, id_employee)
                                    End If
                                    query = "UPDATE tb_emp_leave SET report_mark_type='99' WHERE id_emp_leave='" & id_emp_leave & "'"
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            ElseIf jum_check = "2" Or Not jum_check_sub_dept_head = "0" Then
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("96", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='96' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                If Not leave_type = "7" Then
                                    submit_who_prepared_no_user("95", id_emp_leave, id_employee)
                                End If
                                query = "UPDATE tb_emp_leave SET report_mark_type='95' WHERE id_emp_leave='" & id_emp_leave & "'"
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    End If

                    'after 2017/2/22 admin Manager still approved by HRD
                    'filter by level
                    'Dim jum_check_dept_head As String = ""
                    'query = "SELECT COUNT(*) as jum FROM tb_m_departement dep
                    '            INNER JOIN tb_m_user usr ON usr.id_user=dep.id_user_head
                    '            WHERE usr.id_employee='" & id_employee & "'"
                    'jum_check_dept_head = execute_query(query, 0, True, "", "", "", "")
                    ''1 = Dept Head
                    'If jum_check_dept_head = "1" Then
                    '    submit_who_prepared_no_user("99", id_emp_leave, id_employee)
                    '    query = "UPDATE tb_emp_leave SET report_mark_type='99' WHERE id_emp_leave='" & id_emp_leave & "'"
                    '    execute_non_query(query, True, "", "", "", "")
                    'Else
                    '    Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
                    '    If get_id_employee(id_user_admin_management) = id_employee Then
                    '        'if admin Head Dept
                    '        submit_who_prepared_no_user("104", id_emp_leave, id_employee)
                    '        query = "UPDATE tb_emp_leave SET report_mark_type='104' WHERE id_emp_leave='" & id_emp_leave & "'"
                    '        execute_non_query(query, True, "", "", "", "")
                    '    Else
                    '        'if staff biasa
                    '        submit_who_prepared_no_user("95", id_emp_leave, id_employee)
                    '        query = "UPDATE tb_emp_leave SET report_mark_type='95' WHERE id_emp_leave='" & id_emp_leave & "'"
                    '        execute_non_query(query, True, "", "", "", "")
                    '    End If
                    'End If
                End If
                '
                If leave_type = "7" And Not is_hrd = "1" Then
                    infoCustom("Unpaid leave disimpan. Mohon untuk mencetak memo untuk meminta persetujuan HRD dan Management.")
                Else
                    infoCustom("Cuti diajukan. Menunggu persetujuan.")
                End If
                '
                FormEmpLeave.DEStart.EditValue = getTimeDB()
                FormEmpLeave.DEUntil.EditValue = getTimeDB()
                FormEmpLeave.load_sum()
                FormEmpLeave.GVLeave.FocusedRowHandle = find_row(FormEmpLeave.GVLeave, "id_emp_leave", id_emp_leave)
                '
                '
                If is_hrd = "1" Or leave_type = "7" Then
                    load_form()
                Else
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BRecalculate_Click(sender As Object, e As EventArgs) Handles BRecalculate.Click
        load_but_calc()
    End Sub

    Private Sub FormEmpLeaveDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LELeaveType.Focus()
    End Sub

    Private Sub BAddLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles BAddLeave.KeyDown
        If e.KeyCode = Keys.Multiply Then
            TEEMployeeChange.Focus()
        End If
    End Sub

    Private Sub TEEMployeeChange_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEMployeeChange.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEMployeeChange.Text & "'"
            If FormEmpLeave.is_propose = "1" Then
                'query += " AND (dep.id_user_admin='" & id_user & "' OR dep.id_user_admin_backup='" & id_user & "')"
            End If
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                TEEMployeeChange.Text = data.Rows(0)("employee_code")
                TEEmployeeChangeName.Text = data.Rows(0)("employee_name").ToString
                id_employee_change = data.Rows(0)("id_employee").ToString
                '
                MELeavePurpose.Focus()
            Else
                stopCustom("Karyawan tidak ditemukan.")
            End If
        End If
    End Sub

    Private Sub BDelLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles BDelLeave.KeyDown
        If e.KeyCode = Keys.Multiply Then
            TEEMployeeChange.Focus()
        End If
    End Sub

    Private Sub MELeavePurpose_KeyDown(sender As Object, e As KeyEventArgs) Handles MELeavePurpose.KeyDown
        If e.KeyCode = Keys.Multiply Then
            e.SuppressKeyPress = True
            LEFormDC.Focus()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        'sakit upload dc
        Dim already_upload As Boolean = True

        If LEFormDC.EditValue.ToString = "3" Then
            Dim is_approve As String = execute_query("SELECT COUNT(*) FROM tb_report_mark WHERE id_report = " + id_emp_leave + " AND id_user = " + id_user + " AND id_report_status = 3 AND report_mark_type = " + report_mark_type, 0, True, "", "", "", "")

            If Not is_approve = "0" Then
                Dim attachment As String = execute_query("SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = " + report_mark_type + " AND id_report = " + id_emp_leave, 0, True, "", "", "", "")

                If Not attachment = "0" Then
                    already_upload = False
                End If
            End If
        End If

        If already_upload Then
            FormReportMark.report_mark_type = report_mark_type
            FormReportMark.is_view = is_view
            FormReportMark.id_report = id_emp_leave
            FormReportMark.ShowDialog()
        Else
            stopCustom("Please upload DC.")
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim data As DataTable = execute_query("SELECT id_report_status, id_leave_type FROM tb_emp_leave WHERE id_emp_leave = " + id_emp_leave, -1, True, "", "", "", "")

        If data.Rows(0)("id_leave_type").ToString = "7" And data.Rows(0)("id_report_status").ToString = "0" Then
            ReportMemoUnpaidLeave.id_report = id_emp_leave
            ReportMemoUnpaidLeave.report_mark_type = report_mark_type

            Dim Report As New ReportMemoUnpaidLeave()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        Else
            ReportEmpLeave.id_report = id_emp_leave
            ReportEmpLeave.report_mark_type = report_mark_type

            Dim Report As New ReportEmpLeave()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
    End Sub

    Private Sub LEpayment_KeyDown(sender As Object, e As KeyEventArgs) Handles LELeaveType.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEEmployeeCode.Focus()
        End If
    End Sub

    Private Sub LEpayment_EditValueChanged(sender As Object, e As EventArgs) Handles LELeaveType.EditValueChanged
        If Not LELeaveType.EditValue = LELeaveType.OldEditValue And is_reload = "2" Then
            If GVLeaveDet.RowCount > 0 Then
                Dim confirm As DialogResult
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Jam pengambilan cuti harus diinput ulang, lanjutkan ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = DialogResult.Yes Then
                    clear_all_leave()
                    load_but_calc()
                Else
                    LELeaveType.EditValue = LELeaveType.OldEditValue
                End If
            Else
                load_but_calc()
            End If
        End If
        If id_emp_leave = "-1" And LELeaveType.EditValue.ToString = "2" And LEFormDC.EditValue.ToString = "3" Then 'sick
            SBAttachment.Visible = True
        Else
            SBAttachment.Visible = False
        End If
        is_reload = "2"
    End Sub

    Sub clear_all_leave()
        For i As Integer = GVLeaveDet.RowCount - 1 To 0 Step -1
            GVLeaveDet.DeleteRow(i)
        Next
        '
        If LELeaveType.EditValue.ToString = "2" Then 'sick
            LEFormDC.ItemIndex = LEFormDC.Properties.GetDataSourceRowIndex("id_form_dc", "2")
        Else
            LEFormDC.ItemIndex = LEFormDC.Properties.GetDataSourceRowIndex("id_form_dc", "1")
        End If
    End Sub

    Private Sub BPickChange_Click(sender As Object, e As EventArgs) Handles BPickChange.Click
        FormPopUpEmployee.id_popup = "2"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Sub path_file(ByVal TextEdit As DevExpress.XtraEditors.TextEdit)
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            file_name = IO.Path.GetFileNameWithoutExtension(fd.SafeFileName)
            file_address = fd.FileName
            file_ext = IO.Path.GetExtension(fd.SafeFileName)
        End If

        TextEdit.Text = file_address
    End Sub

    Private Sub LEFormDC_KeyDown(sender As Object, e As KeyEventArgs) Handles LEFormDC.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub BCancelPropose_Click(sender As Object, e As EventArgs) Handles BCancelPropose.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to cancel this proposal ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            'update schedule
            Dim query As String = "UPDATE tb_emp_schedule emp
            INNER JOIN tb_emp_leave_det ld ON emp.id_schedule=ld.id_schedule
            SET emp.id_leave_type=NULL,emp.info_leave=NULL
            WHERE ld.id_emp_leave='" & id_emp_leave & "'"
            execute_non_query(query, True, "", "", "", "")
            query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_emp_leave, "5")
            execute_non_query(query, True, "", "", "", "")
            'set cancel
            FormReportMark.report_mark_type = report_mark_type
            FormReportMark.id_report = id_emp_leave
            FormReportMark.change_status("5")
            '
            infoCustom("Cuti dibatalkan")
            load_form()
        End If
    End Sub

    Private Sub BViewMutasi_Click(sender As Object, e As EventArgs) Handles BViewMutasi.Click
        Dim query As String = ""
        Try
            Dim date_until As Date = DEUntil.EditValue
            query = "CALL view_leave_mutasi('" & id_employee & "','" & date_until.ToString("yyyy-MM-dd") & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMutasi.DataSource = data
        Catch ex As Exception
            stopCustom("Pastikan anda telah menginput karyawan dan tanggal awal mutasi.")
        End Try
    End Sub

    Private Sub SMEditEcopPD_Click(sender As Object, e As EventArgs) Handles SMEditEcopPD.Click
        If GVMutasi.RowCount > 0 Then
            If Not GVMutasi.GetFocusedRowCellValue("id_emp_leave").ToString = "" Then
                Dim id_leave, report_type As String
                Dim query As String = ""
                query = "SELECT * FROM tb_emp_leave WHERE id_emp_leave='" & GVMutasi.GetFocusedRowCellValue("id_emp_leave").ToString & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                id_leave = GVMutasi.GetFocusedRowCellValue("id_emp_leave").ToString
                report_type = data.Rows(0)("report_mark_type")

                ReportEmpLeave.id_report = id_leave
                ReportEmpLeave.report_mark_type = report_type

                Dim Report As New ReportEmpLeave()
                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            Else
                infoCustom("This record created by system without document.")
            End If
        End If
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        If LELeaveType.EditValue.ToString = "2" Then
            FormDocumentUpload.is_no_delete = "1"
            FormDocumentUpload.is_view = If(id_emp_leave = "-1", "-1", "1")
            FormDocumentUpload.report_mark_type = "411"
            FormDocumentUpload.id_report = id_attachment
            FormDocumentUpload.ShowDialog()
        Else
            Dim data As DataTable = execute_query("SELECT id_report_status, report_mark_type FROM tb_emp_leave WHERE id_emp_leave = " + id_emp_leave, -1, True, "", "", "", "")

            FormDocumentUpload.is_no_delete = "2"
            FormDocumentUpload.is_view = If(LEFormDC.EditValue.ToString = "3", If(data.Rows(0)("id_report_status").ToString = "6", "1", If(is_hrd = "1", "-1", "1")), If(data.Rows(0)("id_report_status").ToString = "0", "-1", "1"))
            FormDocumentUpload.id_report = id_emp_leave
            FormDocumentUpload.report_mark_type = data.Rows(0)("report_mark_type").ToString
            FormDocumentUpload.ShowDialog()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim data As DataTable = execute_query("SELECT id_report_status, report_mark_type FROM tb_emp_leave WHERE id_emp_leave = " + id_emp_leave, -1, True, "", "", "", "")

        'check attachment
        Dim attachment As String = execute_query("SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = " + data.Rows(0)("report_mark_type").ToString + " AND id_report = " + id_emp_leave, 0, True, "", "", "", "")

        If Not attachment = "0" Then
            If data.Rows(0)("report_mark_type").ToString = "102" Then
                submit_who_prepared(data.Rows(0)("report_mark_type").ToString, id_emp_leave, id_user)
            Else
                submit_who_prepared_no_user(data.Rows(0)("report_mark_type").ToString, id_emp_leave, id_employee)
            End If

            execute_non_query("UPDATE tb_emp_leave SET id_report_status = 1 WHERE id_emp_leave = " + id_emp_leave, True, "", "", "", "")

            infoCustom("Cuti diajukan. Menunggu persetujuan.")

            Close()
        Else
            stopCustom("Mohon lampirkan memo yg telah disetujui Management.")
        End If
    End Sub

    Private Sub LEFormDC_EditValueChanged(sender As Object, e As EventArgs) Handles LEFormDC.EditValueChanged
        If id_emp_leave = "-1" And LELeaveType.EditValue.ToString = "2" And LEFormDC.EditValue.ToString = "3" Then 'sick
            SBAttachment.Visible = True
        Else
            SBAttachment.Visible = False
        End If
    End Sub
End Class