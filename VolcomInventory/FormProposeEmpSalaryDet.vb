Public Class FormProposeEmpSalaryDet
    Public id_employee_sal_pps As String = "-1"
    Public is_duplicate As String = "-1"

    Private Sub FormProposeEmpSalaryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()

        permission_load()
    End Sub

    Private Sub FormProposeEmpSalaryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormProposeEmpSalary.load_pps()

        If Not id_employee_sal_pps = "-1" Then
            FormProposeEmpSalary.GVList.FocusedRowHandle = find_row(FormProposeEmpSalary.GVList, "id_employee_sal_pps", id_employee_sal_pps)
        End If

        Dispose()
    End Sub

    Sub form_load()
        'load
        Dim query As String = "
            SELECT sal.id_employee_sal_pps, DATE_FORMAT(sal.effective_date, '%d %M %Y') AS effective_date, sal.id_report_status, sal.number, sal.note, emp.employee_name AS created_by, DATE_FORMAT(sal.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_employee_sal_pps AS sal
            LEFT JOIN tb_m_employee AS emp ON sal.created_by = emp.id_employee
            WHERE sal.id_employee_sal_pps = " + id_employee_sal_pps + "
            
            UNION ALL
            
            #default value
            SELECT -1 AS id_employee_sal_pps, DATE_FORMAT(NOW(), '%d %M %Y') AS effective_date, -1 AS id_report_status, '[autogenerate]' AS number, '' AS note, (SELECT employee_name FROM tb_m_employee WHERE id_employee = " + id_employee_user + ") AS created_by, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        MENote.EditValue = data.Rows(0)("note").ToString
        DEEffectiveDate.EditValue = data.Rows(0)("effective_date")
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        DECreatedAt.EditValue = data.Rows(0)("created_at")

        'load detail
        Dim query_detail As String = "
            SELECT det.id_employee, emp.employee_code, emp.employee_name, det.id_departement, dp.departement, det.employee_position, det.id_employee_level, lv.employee_level, det.id_employee_status, sts.employee_status, ROUND(det.basic_salary, 0) AS basic_salary, ROUND(det.allow_job, 0) AS allow_job, ROUND(det.allow_meal, 0) AS allow_meal, ROUND(det.allow_trans, 0) AS allow_trans, ROUND(det.allow_house, 0) AS allow_house, ROUND(det.allow_car, 0) AS allow_car
            FROM tb_employee_sal_pps_det AS det
            LEFT JOIN tb_m_employee AS emp ON det.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dp ON det.id_departement = dp.id_departement
            LEFT JOIN tb_lookup_employee_level AS lv ON det.id_employee_level = lv.id_employee_level
            LEFT JOIN tb_lookup_employee_status AS sts ON det.id_employee_status = sts.id_employee_status
            WHERE det.id_employee_sal_pps = " + id_employee_sal_pps + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_detail

        GVEmployee.BestFitColumns()

        'duplicate
        If is_duplicate = "1" Then
            TENumber.EditValue = "[autogenerate]"
        End If
    End Sub

    Sub permission_load()
        If id_employee_sal_pps = "-1" Then
            SBMark.Enabled = False
            SBPrint.Enabled = False
        Else
            SBSubmit.Enabled = False
            SBInsertEmployee.Enabled = False
            SBRemoveEmployee.Enabled = False

            DEEffectiveDate.ReadOnly = True
            MENote.ReadOnly = True
            RITESalary.ReadOnly = True

            RemoveEmployeeToolStripMenuItem.Visible = False
        End If

        'duplicate
        If is_duplicate = "1" Then
            SBMark.Enabled = False
            SBPrint.Enabled = False

            SBSubmit.Enabled = True
            SBInsertEmployee.Enabled = True
            SBRemoveEmployee.Enabled = True

            DEEffectiveDate.ReadOnly = False
            MENote.ReadOnly = False
            RITESalary.ReadOnly = False

            RemoveEmployeeToolStripMenuItem.Visible = True
        End If
    End Sub

    Sub update_changes()
        Dim query As String = "
            SELECT pps_det.id_employee
            FROM tb_employee_sal_pps_det AS pps_det
            LEFT JOIN tb_employee_sal_pps AS pps ON pps_det.id_employee_sal_pps = pps.id_employee_sal_pps
            WHERE pps.id_employee_sal_pps = " + id_employee_sal_pps + "
        "

        Dim pps_salary As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To pps_salary.Rows.Count - 1
            Dim id_employee As String = pps_salary.Rows(i)("id_employee").ToString

            execute_non_query("
                UPDATE tb_m_employee SET 
                    basic_salary = (SELECT basic_salary FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_job = (SELECT allow_job FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_meal = (SELECT allow_meal FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_trans = (SELECT allow_trans FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_house = (SELECT allow_house FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_car = (SELECT allow_car FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + ")
                WHERE id_employee = " + id_employee + "
            ", True, "", "", "", "")

            execute_non_query("
                INSERT INTO tb_m_employee_salary (id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date)
                SELECT id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date 
                FROM tb_employee_sal_pps_det AS pps_det
                LEFT JOIN tb_employee_sal_pps AS pps ON pps_det.id_employee_sal_pps = pps.id_employee_sal_pps 
                WHERE pps.id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "
            ", True, "", "", "", "")
        Next
    End Sub

    Sub remove_employee()
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to remove selected employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            GVEmployee.DeleteSelectedRows()
        End If
    End Sub

    Private Sub SBInsertEmployee_Click(sender As Object, e As EventArgs) Handles SBInsertEmployee.Click
        'check included employee
        Dim not_included As String = ""

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                not_included += GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", "
            End If
        Next

        If Not not_included = "" Then
            not_included = not_included.Substring(0, not_included.Length - 2)
        End If

        'form pick employee
        FormProposeEmpSalaryPick.not_included = not_included

        FormProposeEmpSalaryPick.ShowDialog()
    End Sub

    Private Sub SBRemoveEmployee_Click(sender As Object, e As EventArgs) Handles SBRemoveEmployee.Click
        remove_employee()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        GVEmployee.ApplyFindFilter("")

        If GVEmployee.RowCount = 0 Then
            errorCustom("No employee inserted.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit propose employee salary?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim query As String = ""

                'insert tb_employee_sal_pps
                Dim effective_date As String = DateTime.Parse(DEEffectiveDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)

                query = "
                    INSERT INTO tb_employee_sal_pps (effective_date, id_report_status, note, created_by, created_at) 
                    VALUES ('" + effective_date + "', 1, '" + note + "', " + id_employee_user + ", NOW());
                    SELECT LAST_INSERT_ID();
                "

                id_employee_sal_pps = execute_query(query, 0, True, "", "", "", "")

                'insert tb_employee_sal_pps_det
                Dim values As String = ""

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                        Dim id_departement As String = GVEmployee.GetRowCellValue(i, "id_departement").ToString
                        Dim employee_position As String = addSlashes(GVEmployee.GetRowCellValue(i, "employee_position").ToString)
                        Dim id_employee_level As String = GVEmployee.GetRowCellValue(i, "id_employee_level").ToString
                        Dim id_employee_status As String = GVEmployee.GetRowCellValue(i, "id_employee_status").ToString
                        Dim basic_salary As String = GVEmployee.GetRowCellValue(i, "basic_salary").ToString
                        Dim allow_job As String = GVEmployee.GetRowCellValue(i, "allow_job").ToString
                        Dim allow_meal As String = GVEmployee.GetRowCellValue(i, "allow_meal").ToString
                        Dim allow_trans As String = GVEmployee.GetRowCellValue(i, "allow_trans").ToString
                        Dim allow_house As String = GVEmployee.GetRowCellValue(i, "allow_house").ToString
                        Dim allow_car As String = GVEmployee.GetRowCellValue(i, "allow_car").ToString

                        values += "(" + id_employee_sal_pps + ", " + id_employee + ", " + id_departement + ", '" + employee_position + "', " + id_employee_level + ", " + id_employee_status + ", " + basic_salary + ", " + allow_job + ", " + allow_meal + ", " + allow_trans + ", " + allow_house + ", " + allow_car + "), "
                    End If
                Next

                values = values.Substring(0, values.Length - 2)

                query = "INSERT INTO tb_employee_sal_pps_det (id_employee_sal_pps, id_employee, id_departement, employee_position, id_employee_level, id_employee_status, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car) VALUES " + values + ""

                execute_non_query(query, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_employee_sal_pps + ", 197)", True, "", "", "", "")

                submit_who_prepared("197", id_employee_sal_pps, id_user)

                Cursor = Cursors.Default

                Close()
            End If
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps + "", 0, True, "", "", "", "")

        Dim report As ReportProposeEmpSalary = New ReportProposeEmpSalary

        report.id_employee_sal_pps = id_employee_sal_pps
        report.data = GCEmployee.DataSource
        report.is_pre = If(id_report_status = "6", "-1", "1")

        report.XLNumber.Text = TENumber.Text
        report.XLEffectiveDate.Text = DEEffectiveDate.Text
        report.XLNote.Text = MENote.Text

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "197"
        FormReportMark.id_report = id_employee_sal_pps

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub RemoveEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveEmployeeToolStripMenuItem.Click
        remove_employee()
    End Sub

    Private Sub RITESalary_EditValueChanged(sender As Object, e As EventArgs) Handles RITESalary.EditValueChanged
        GCEmployee.Refresh()
    End Sub
End Class