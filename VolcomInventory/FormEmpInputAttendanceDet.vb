Public Class FormEmpInputAttendanceDet
    Public id As String = "0"

    Private Sub FormEmpInputAttendanceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_report_status()

        load_data()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormEmpInputAttendancePick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVEmployee.DeleteSelectedRows()
    End Sub

    Sub load_data()
        Dim query As String = "
            (SELECT att.number, att.id_report_status, DATE_FORMAT(att.created_at, '%d %M %Y %H:%i:%s') AS created_at, created_by.employee_name AS created_by
            FROM tb_emp_attn_input AS att
            LEFT JOIN tb_m_employee AS created_by ON att.created_by = created_by.id_employee
            WHERE id_emp_attn_input = " + id + ")
            UNION ALL
            (SELECT '[autogenerate]' AS number, 0 AS id_report_status, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at, '" + addSlashes(get_emp(id_employee_user, "2")) + "' AS created_by)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedAt.EditValue = data.Rows(0)("created_at").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString

        LUEReportStatus.Properties.ReadOnly = False
        LUEReportStatus.ItemIndex = LUEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status"))
        LUEReportStatus.Properties.ReadOnly = True

        'detail
        Dim query_detail As String = "
            SELECT att_det.id_emp_attn_input_det, att_det.id_departement, departement.departement, att_det.id_employee, employee.employee_code, employee.employee_name, att_det.employee_position, att_det.id_employee_status, sts.employee_status, att_det.date, att_det.time_in, att_det.time_out
            FROM tb_emp_attn_input_det AS att_det
            LEFT JOIN tb_m_employee AS employee ON att_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON att_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS sts ON att_det.id_employee_status = sts.id_employee_status
            WHERE id_emp_attn_input = " + id + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_detail

        GVEmployee.BestFitColumns()

        'controls
        If id = "0" Then
            DDBImportExcel.Enabled = True
            SBRemove.Enabled = True
            SBAdd.Enabled = True
            SBSubmit.Enabled = True
            SBMark.Enabled = False

            GCTimeIn.OptionsColumn.AllowEdit = True
            GCTimeOut.OptionsColumn.AllowEdit = True
        Else
            DDBImportExcel.Enabled = False
            SBRemove.Enabled = False
            SBAdd.Enabled = False
            SBSubmit.Enabled = False
            SBMark.Enabled = True

            GCTimeIn.OptionsColumn.AllowEdit = False
            GCTimeOut.OptionsColumn.AllowEdit = False
        End If
    End Sub

    Sub load_report_status()
        Dim query As String = "
            (SELECT 0 AS id_report_status, '' AS report_status)
            UNION ALL
            (SELECT id_report_status, report_status
            FROM tb_lookup_report_status)
        "

        viewLookupQuery(LUEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "INSERT INTO tb_emp_attn_input (id_report_status, created_by, created_at) VALUES (1, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

            id = execute_query(query, 0, True, "", "", "", "")

            For i = 0 To GVEmployee.RowCount - 1
                If GVEmployee.IsValidRowHandle(i) Then
                    Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                    Dim id_departement As String = GVEmployee.GetRowCellValue(i, "id_departement").ToString
                    Dim employee_position As String = GVEmployee.GetRowCellValue(i, "employee_position").ToString
                    Dim id_employee_status As String = GVEmployee.GetRowCellValue(i, "id_employee_status").ToString
                    Dim date_att As String = Date.Parse(GVEmployee.GetRowCellValue(i, "date").ToString).ToString("yyyy-MM-dd")
                    Dim time_in As String = Date.Parse(GVEmployee.GetRowCellValue(i, "time_in").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim time_out As String = Date.Parse(GVEmployee.GetRowCellValue(i, "time_out").ToString).ToString("yyyy-MM-dd HH:mm:ss")

                    Dim query_detail As String = "INSERT INTO tb_emp_attn_input_det (id_emp_attn_input, id_employee, id_departement, employee_position, id_employee_status, date, time_in, time_out) VALUES (" + id + ", " + id_employee + ", " + id_departement + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", '" + date_att + "', '" + time_in + "', '" + time_out + "')"

                    execute_non_query(query_detail, True, "", "", "", "")
                End If
            Next

            submit_who_prepared("211", id, id_user)

            execute_non_query("CALL gen_number(" + id + ", '211')", True, "", "", "", "")

            Close()
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "211"
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpInputAttendanceDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormEmpInputAttendance.view_attendance()

            FormEmpInputAttendance.GVList.FocusedRowHandle = find_row(FormEmpInputAttendance.GVList, "id_emp_attn_input", id)
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub GVEmployee_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVEmployee.RowCellClick
        If e.Column.FieldName.ToString = "time_in" Then
            RIDETime.MinValue = GVEmployee.GetFocusedRowCellValue("date")
        ElseIf e.Column.FieldName.ToString = "time_out" Then
            RIDETime.MaxValue = GVEmployee.GetFocusedRowCellValue("date")
        End If
    End Sub

    Private Sub BBINIKSogo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBINIKSogo.ItemClick
        FormImportExcel.id_pop_up = "45"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub BBINIPVolcom_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBINIPVolcom.ItemClick
        FormImportExcel.id_pop_up = "46"
        FormImportExcel.ShowDialog()
    End Sub
End Class