Public Class FormEmpPerAppraisalDet
    Public id_employee As String = "-1"
    Public grup_penilaian As String = "-1"
    Public id_question_period As String = "-1"

    Public id_question_gen_res As Integer = 0
    Public id_question_pri_res As Integer = 0

    Public row_result = 0

    Sub load_employee()
        Dim query As String = "
            SELECT emp.id_employee, emp.id_departement, dept.departement,
                emp.id_employee_status, stt.employee_status,
                emp.employee_code, emp.employee_name,
                emp.employee_position, emp.id_employee_level, lvl.employee_level, IF(lvl.grup_penilaian = 0, 1, lvl.grup_penilaian) grup_penilaian,
                DATE_FORMAT(emp.employee_join_date, '%d %M %Y') employee_join_date,
                DATE_FORMAT(emp2.start_period, '%d %M %Y') start_period,
                DATE_FORMAT(emp2.end_period, '%d %M %Y') end_period
            FROM tb_m_employee emp
            LEFT JOIN tb_m_departement dept ON dept.id_departement = emp.id_departement 
            LEFT JOIN tb_lookup_employee_status stt ON stt.id_employee_status = emp.id_employee_status 
            LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level
            LEFT JOIN (
	            SELECT emp2_1.id_employee, 
		            IF(CURDATE() >= emp2_2.first_evaluation_start AND CURDATE() <= emp2_2.first_evaluation_end, emp2_2.first_evaluation_start, emp2_2.second_evaluation_start) start_period,
		            IF(CURDATE() >= emp2_2.first_evaluation_start AND CURDATE() <= emp2_2.first_evaluation_end, emp2_2.first_evaluation_end, emp2_2.second_evaluation_end) end_period,
		            emp2_2.first_evaluation_start,
		            emp2_2.first_evaluation_end,
		            emp2_2.second_evaluation_start,
		            emp2_2.second_evaluation_end
	            FROM tb_m_employee emp2_1
	            LEFT JOIN (
		            SELECT id_employee,
			            DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR) first_evaluation_start,
			            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 6 MONTH) - INTERVAL 1 DAY first_evaluation_end,
			            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 6 MONTH) second_evaluation_start,
			            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 12 MONTH) - INTERVAL 1 DAY second_evaluation_end
		            FROM tb_m_employee
	            ) emp2_2 ON emp2_1.id_employee = emp2_2.id_employee
            ) emp2 ON emp.id_employee = emp2.id_employee
            WHERE emp.id_employee = '" + id_employee + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        grup_penilaian = data.Rows(0)("grup_penilaian").ToString

        TEEmployeeName.EditValue = data.Rows(0)("employee_name").ToString
        TEEmployeePosition.EditValue = data.Rows(0)("employee_position").ToString
        TEDepartement.EditValue = data.Rows(0)("departement").ToString
        TECompany.EditValue = "PT. Volcom Indonesia"
        TEEmployeeJoinDate.EditValue = data.Rows(0)("employee_join_date").ToString
        TEEmployeeStatus.EditValue = data.Rows(0)("employee_status").ToString
        TEStartPeriod.EditValue = data.Rows(0)("start_period").ToString
        TEEndPeriod.EditValue = data.Rows(0)("end_period").ToString
        If data.Rows(0)("id_employee_status").ToString = "1" Then
            TEPurpose.EditValue = "Review kontrak kerja"
        Else
            TEPurpose.EditValue = "Reguler"
        End If
    End Sub

    Sub load_question()
        Dim query As String = ""

        If id_question_period <> "-1" Then
            query = "
                SELECT 0 no, qg.id_question_gen_app, qg.question, CONCAT('(', qg.question_detail, ')') question_detail, qg.id_question_gen_app_group, CONCAT(qg.id_question_gen_app_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, IFNULL(qgr.id_question_gen_app_res, 0) id_question_gen_app_res, IFNULL(qgr.value, 0) value, IFNULL(qgr.information, '') information
                FROM tb_question_gen_app qg
                LEFT JOIN tb_question_gen_app_group qgg ON qg.id_question_gen_app_group = qgg.id_question_gen_app_group
                LEFT JOIN tb_question_gen_app_res qgr ON qg.id_question_gen_app = qgr.id_question_gen_app
                WHERE qgr.id_question_period = '" + id_question_period + "'
                ORDER BY qg.id_question_gen_app_group ASC
            "
        Else
            query = "
                SELECT 0 no, qg.id_question_gen_app, qg.question, CONCAT('(', qg.question_detail, ')') question_detail, qg.id_question_gen_app_group, CONCAT(qg.id_question_gen_app_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, 0 id_question_gen_app_res, 0 value, '' information
                FROM tb_question_gen_app qg
                LEFT JOIN tb_question_gen_app_group qgg ON qg.id_question_gen_app_group = qgg.id_question_gen_app_group
                WHERE qg.grup_penilaian <= '" + grup_penilaian + "'
                ORDER BY qg.id_question_gen_app_group ASC
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCListQuestion.DataSource = data
        GVListQuestion.BestFitColumns()

        Dim query_value As String = "SELECT value FROM tb_lookup_question_value"

        viewLookupRepositoryQuery(LUEValue, query_value, 0, "value", "value")
    End Sub

    Sub load_conclusion()
        Dim query As String = ""

        'gen
        If id_question_period <> "-1" Then
            query = "
                SELECT 0 no, qc.id_question_gen_con, qc.question, IFNULL(qcr.id_question_gen_con_res, 0) id_question_gen_con_res, IFNULL(qcr.conclusion, '') conclusion
                FROM tb_question_gen_con qc
                LEFT JOIN tb_question_gen_con_res qcr ON qc.id_question_gen_con = qcr.id_question_gen_con
                WHERE qcr.id_question_period = '" + id_question_period + "'
            "
        Else
            query = "
                SELECT 0 no, qc.id_question_gen_con, qc.question, 0 id_question_gen_con_res, '' conclusion 
                FROM tb_question_gen_con qc
            "
        End If

        Dim data_gen As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCConclusion.DataSource = data_gen
        GVConclusion.BestFitColumns()

        'pri
        If id_question_period <> "-1" Then
            query = "
                SELECT 0 no, qc.id_question_pri_con, qc.question, IFNULL(qcr.id_question_pri_con_res, 0) id_question_pri_con_res, IFNULL(qcr.conclusion, '') conclusion
                FROM tb_question_pri_con qc
                LEFT JOIN tb_question_pri_con_res qcr ON qc.id_question_pri_con = qcr.id_question_pri_con
                WHERE qcr.id_question_period = '" + id_question_period + "'
            "
        Else
            query = "
                SELECT 0 no, qc.id_question_pri_con, qc.question, 0 id_question_pri_con_res, '' conclusion 
                FROM tb_question_pri_con qc
            "
        End If

        Dim data_pri As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCComment.DataSource = data_pri
        GVComment.BestFitColumns()
    End Sub

    Sub load_result()
        Dim query As String = ""

        'recommendation lookup
        query = "
                SELECT lqr.id_result, lqr.result, lqr.information
                FROM tb_lookup_question_result lqr
            "

        ''gen
        viewSearchLookupQuery(SLUERec, query, "id_result", "result", "id_result")
        ''pri
        viewSearchLookupQuery(SLUERecPri, query, "id_result", "result", "id_result")

        'result
        ''gen
        query = "
                SELECT qgr.id_question_gen_res, qgr.id_result, lqr.information, qgr.result_information, qgr.employee_note, qgr.hrd_note
                FROM tb_question_gen_res qgr
                LEFT JOIN tb_lookup_question_result lqr ON qgr.id_result = lqr.id_result
                WHERE qgr.id_question_period = '" + id_question_period + "'
            "
        Dim data_gen As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''pri
        query = "
                SELECT qpr.id_question_pri_res, qpr.id_result, lqr.information, qpr.result_information, qpr.hrd_note
                FROM tb_question_pri_res qpr
                LEFT JOIN tb_lookup_question_result lqr ON qpr.id_result = lqr.id_result
                WHERE qpr.id_question_period = '" + id_question_period + "'
            "
        Dim data_pri As DataTable = execute_query(query, -1, True, "", "", "", "")

        If id_question_period <> "-1" Then
            ''gen
            id_question_gen_res = data_gen.Rows(0)("id_question_gen_res")

            MEEmployeeNote.EditValue = data_gen.Rows(0)("employee_note")
            MEHRDNote.EditValue = data_gen.Rows(0)("hrd_note")

            ''pri
            id_question_pri_res = data_pri.Rows(0)("id_question_pri_res")

            MEHRDNotePri.EditValue = data_pri.Rows(0)("hrd_note")
        End If

        If id_question_period <> "-1" Then
            ''gen
            SLUERec.EditValue = data_gen.Rows(0)("id_result")
            TERec.EditValue = data_gen.Rows(0)("result_information")

            If data_gen.Rows(0)("information") = "1" Then
                TERec.Visible = True
            Else
                TERec.Visible = False
            End If

            ''pri
            SLUERecPri.EditValue = data_pri.Rows(0)("id_result")
            TERecPri.EditValue = data_pri.Rows(0)("result_information")

            If data_pri.Rows(0)("information") = "1" Then
                TERecPri.Visible = True
            Else
                TERecPri.Visible = False
            End If
        End If
    End Sub

    Private Sub FormEmpPerAppraisalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()

        load_question()

        load_conclusion()

        load_result()

        calculate_total()

        'is_appraiser()
        'is_staff()
        'is_hrd()
    End Sub

    Sub calculate_total()
        'all group
        Dim query_group As String = "
            SELECT id_question_gen_app_group, CONCAT(id_question_gen_app_group, '. ', group_name) group_name, group_weight FROM tb_question_gen_app_group ORDER BY id_question_gen_app_group ASC
        "

        Dim data_group As DataTable = execute_query(query_group, -1, True, "", "", "", "")

        'last id
        Dim query_group_id As String = "
            SELECT id_question_gen_app_group FROM tb_question_gen_app_group ORDER BY id_question_gen_app_group DESC LIMIT 1
        "

        Dim last_group_id As Integer = execute_query(query_group_id, 0, True, "", "", "", "")

        'declare array
        Dim tot() As Decimal
        Dim count() As Integer

        'array dimension using last id
        ReDim tot(last_group_id)
        ReDim count(last_group_id)

        'variable
        Dim id_group As Integer = 0
        Dim group_name As String = ""
        Dim group_weight As Integer = 0

        Dim total As Decimal = 0.00
        Dim total_score As Decimal = 0.00

        Dim formula As String = ""

        Dim total_detail As New DataTable
        Dim result As New DataTable

        'calculate total & count each group
        For i As Integer = 0 To GVListQuestion.RowCount - 1
            If GVListQuestion.IsValidRowHandle(i) Then
                id_group = GVListQuestion.GetRowCellValue(i, "id_question_gen_app_group")

                tot(id_group) += GVListQuestion.GetRowCellValue(i, "value")
                count(id_group) += 1
            End If
        Next

        'datatable column
        total_detail.Columns.Add("group_name", GetType(String))
        total_detail.Columns.Add("formula", GetType(String))
        total_detail.Columns.Add("total", GetType(String))

        'total calculation
        For i As Integer = 0 To data_group.Rows.Count - 1
            id_group = data_group.Rows(i)("id_question_gen_app_group")
            group_name = data_group.Rows(i)("group_name")
            group_weight = data_group.Rows(i)("group_weight")

            'total each group
            total = group_weight * (tot(id_group) / (count(id_group) * 10))

            'formula string
            formula = group_weight.ToString + " X (" + tot(id_group).ToString + "/" + (count(id_group) * 10).ToString + ")"

            'datatable each group
            total_detail.Rows.Add(group_name, formula, Format(total, "0.00"))

            'total all
            total_score += total
        Next

        'datatable total all
        total_detail.Rows.Add("", "Total Nilai", Format(total_score, "0.00"))

        'datatable result
        Dim query_result = "
            SELECT IF(" + decimalSQL(total_score) + " >= `from` AND " + decimalSQL(total_score) + " <= `to`, '(X)', '') `result`, `name`, CONCAT(`from`, ' - ', `to`) `range` FROM `tb_lookup_question_range` ORDER BY `from` DESC
        "

        Dim data_result As DataTable = execute_query(query_result, -1, True, "", "", "", "")

        GCGroupQuestion.DataSource = total_detail
        GVGroupQuestion.BestFitColumns()

        GCResult.DataSource = data_result
        GVResult.BestFitColumns()

        'row result
        For i = 0 To GVResult.RowCount - 1
            If GVResult.GetRowCellValue(i, "result").ToString = "(X)" Then
                row_result = i
            End If
        Next
    End Sub

    Sub save_data()
        GVListQuestion.ExpandAllGroups()

        Dim query As String = ""

        If id_question_period = "-1" Then
            Dim start_period As String = Date.Parse(TEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim end_period As String = Date.Parse(TEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd")

            query = "INSERT INTO tb_question_period (id_employee, from_period, until_period, created_date) VALUES ('" + id_employee + "', '" + start_period + "', '" + end_period + "', NOW()); SELECT LAST_INSERT_ID();"

            id_question_period = execute_query(query, 0, True, "", "", "", "")
        End If

        'app
        For i As Integer = 0 To GVListQuestion.RowCount - 1
            If GVListQuestion.IsValidRowHandle(i) Then
                If GVListQuestion.GetRowCellValue(i, "id_question_gen_app_res").ToString = "0" Then
                    query = "INSERT INTO tb_question_gen_app_res (id_question_period, id_question_gen_app, value, information) VALUES ('" + id_question_period + "', '" + GVListQuestion.GetRowCellValue(i, "id_question_gen_app").ToString + "', '" + GVListQuestion.GetRowCellValue(i, "value").ToString + "', '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "')"
                Else
                    query = "UPDATE tb_question_gen_app_res SET id_question_period = '" + id_question_period + "', id_question_gen_app = '" + GVListQuestion.GetRowCellValue(i, "id_question_gen_app").ToString + "', value = '" + GVListQuestion.GetRowCellValue(i, "value").ToString + "', information = '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "' WHERE id_question_gen_app_res = '" + GVListQuestion.GetRowCellValue(i, "id_question_gen_app_res").ToString + "'"
                End If

                execute_non_query(query, True, "", "", "", "")
            End If
        Next

        'con
        ''gen
        For i As Integer = 0 To GVConclusion.RowCount - 1
            If GVConclusion.GetRowCellValue(i, "id_question_gen_con_res").ToString = "0" Then
                query = "INSERT INTO tb_question_gen_con_res (id_question_period, id_question_gen_con, conclusion) VALUES ('" + id_question_period + "', '" + GVConclusion.GetRowCellValue(i, "id_question_gen_con").ToString + "', '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "')"
            Else
                query = "UPDATE tb_question_gen_con_res SET id_question_period = '" + id_question_period + "', id_question_gen_con = '" + GVConclusion.GetRowCellValue(i, "id_question_gen_con").ToString + "', conclusion = '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "' WHERE id_question_gen_con_res = '" + GVConclusion.GetRowCellValue(i, "id_question_gen_con_res").ToString + "'"
            End If

            execute_non_query(query, True, "", "", "", "")
        Next

        ''pri
        For i As Integer = 0 To GVComment.RowCount - 1
            If GVComment.GetRowCellValue(i, "id_question_pri_con_res").ToString = "0" Then
                query = "INSERT INTO tb_question_pri_con_res (id_question_period, id_question_pri_con, conclusion) VALUES ('" + id_question_period + "', '" + GVComment.GetRowCellValue(i, "id_question_pri_con").ToString + "', '" + addSlashes(GVComment.GetRowCellValue(i, "conclusion").ToString) + "')"
            Else
                query = "UPDATE tb_question_pri_con_res SET id_question_period = '" + id_question_period + "', id_question_pri_con = '" + GVComment.GetRowCellValue(i, "id_question_pri_con").ToString + "', conclusion = '" + addSlashes(GVComment.GetRowCellValue(i, "conclusion").ToString) + "' WHERE id_question_pri_con_res = '" + GVComment.GetRowCellValue(i, "id_question_pri_con_res").ToString + "'"
            End If

            execute_non_query(query, True, "", "", "", "")
        Next

        'res
        ''gen
        If id_question_gen_res <> 0 Then
            query = "UPDATE tb_question_gen_res SET id_question_period = '" + id_question_period + "', id_result = '" + SLUERec.EditValue.ToString + "', employee_note = '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', hrd_note = '" + addSlashes(MEHRDNote.EditValue.ToString) + "', result_information = '" + addSlashes(TERec.EditValue.ToString) + "' WHERE id_question_gen_res = '" + id_question_gen_res.ToString + "'"
        Else
            query = "INSERT INTO tb_question_gen_res (id_question_period, id_result, employee_note, hrd_note, result_information) VALUES ('" + id_question_period + "', '" + SLUERec.EditValue.ToString + "', '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', '" + addSlashes(MEHRDNote.EditValue.ToString) + "', '" + addSlashes(TERec.EditValue.ToString) + "')"
        End If

        execute_non_query(query, True, "", "", "", "")

        ''pri
        If id_question_pri_res <> 0 Then
            query = "UPDATE tb_question_pri_res SET id_question_period = '" + id_question_period + "', id_result = '" + SLUERecPri.EditValue.ToString + "', hrd_note = '" + addSlashes(MEHRDNotePri.EditValue.ToString) + "', result_information = '" + addSlashes(TERecPri.EditValue.ToString) + "' WHERE id_question_pri_res = '" + id_question_pri_res.ToString + "'"
        Else
            query = "INSERT INTO tb_question_pri_res (id_question_period, id_result, hrd_note, result_information) VALUES ('" + id_question_period + "', '" + SLUERecPri.EditValue.ToString + "', '" + addSlashes(MEHRDNotePri.EditValue.ToString) + "', '" + addSlashes(TERecPri.EditValue.ToString) + "')"
        End If

        execute_non_query(query, True, "", "", "", "")
    End Sub

    Sub is_appraiser()
        GCValue.OptionsColumn.AllowEdit = True
        GCInformation.OptionsColumn.AllowEdit = True
        GCConclusionResult.OptionsColumn.AllowEdit = True
        SLUERec.Properties.ReadOnly = False
        TERec.Properties.ReadOnly = False
        MEEmployeeNote.Properties.ReadOnly = True
        MEHRDNote.Properties.ReadOnly = True
        GCPConclusionResult.OptionsColumn.AllowEdit = True
        SLUERecPri.Properties.ReadOnly = False
        TERecPri.Properties.ReadOnly = False
        MEHRDNotePri.Properties.ReadOnly = True
        XTPPAP.PageVisible = True
    End Sub

    Sub is_staff()
        GCValue.OptionsColumn.AllowEdit = False
        GCInformation.OptionsColumn.AllowEdit = False
        GCConclusionResult.OptionsColumn.AllowEdit = False
        SLUERec.Properties.ReadOnly = True
        TERec.Properties.ReadOnly = True
        MEEmployeeNote.Properties.ReadOnly = False
        MEHRDNote.Properties.ReadOnly = True
        GCPConclusionResult.OptionsColumn.AllowEdit = False
        SLUERecPri.Properties.ReadOnly = True
        TERecPri.Properties.ReadOnly = True
        MEHRDNotePri.Properties.ReadOnly = True
        XTPPAP.PageVisible = False
    End Sub

    Sub is_hrd()
        GCValue.OptionsColumn.AllowEdit = False
        GCInformation.OptionsColumn.AllowEdit = False
        GCConclusionResult.OptionsColumn.AllowEdit = False
        SLUERec.Properties.ReadOnly = True
        TERec.Properties.ReadOnly = True
        MEEmployeeNote.Properties.ReadOnly = True
        MEHRDNote.Properties.ReadOnly = False
        GCPConclusionResult.OptionsColumn.AllowEdit = False
        SLUERecPri.Properties.ReadOnly = True
        TERecPri.Properties.ReadOnly = True
        MEHRDNotePri.Properties.ReadOnly = False
        XTPPAP.PageVisible = True
    End Sub

    Private Sub LUEValue_EditValueChanged(sender As Object, e As EventArgs) Handles LUEValue.EditValueChanged
        GVListQuestion.CloseEditor()
        GVListQuestion.UpdateCurrentRow()

        calculate_total()
    End Sub

    Private Sub FormEmpPerAppraisalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormEmpPerAppraisal.load_employee()

        FormEmpPerAppraisal.GVList.FocusedRowHandle = find_row(FormEmpPerAppraisal.GVList, "id_employee", id_employee)

        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        save_data()

        Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        ReportEmpPerAppraisalDet.dt_question = GCListQuestion.DataSource
        ReportEmpPerAppraisalDet.dt_group_question = GCGroupQuestion.DataSource
        ReportEmpPerAppraisalDet.dt_result = GCResult.DataSource
        ReportEmpPerAppraisalDet.dt_conclusion = GCConclusion.DataSource

        Dim Report As New ReportEmpPerAppraisalDet()

        If (grup_penilaian = "2") Then
            Report.XLLevelStaff.Text = "(Level Assistant Supervisor s/d Senior Manager)"
        Else
            Report.XLLevelStaff.Text = "(Level Staff s/d Team Leader)"
        End If

        Report.XLNama.Text = TEEmployeeName.EditValue.ToString
        Report.XLPosition.Text = TEEmployeePosition.EditValue.ToString
        Report.XLDept.Text = TEDepartement.EditValue.ToString
        Report.XLComp.Text = TECompany.EditValue.ToString
        Report.XLJoinDate.Text = TEEmployeeJoinDate.EditValue.ToString
        Report.XLStatus.Text = TEEmployeeStatus.EditValue.ToString
        Report.XLPeriod.Text = TEStartPeriod.EditValue.ToString + " s/d " + TEEndPeriod.EditValue.ToString
        Report.XLPurpose.Text = TEPurpose.EditValue.ToString

        Report.XLRecommend.Text = SLUERec.Text + "" + TERec.EditValue.ToString
        Report.XLEmpNote.Text = MEEmployeeNote.EditValue.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub SLUERec_EditValueChanged(sender As Object, e As EventArgs) Handles SLUERec.EditValueChanged
        If SLUERec.Properties.View.GetFocusedRowCellValue("information") = "1" Then
            TERec.Visible = True
        Else
            TERec.Visible = False
            TERec.EditValue = ""
        End If
    End Sub

    Private Sub SLUERecPri_EditValueChanged(sender As Object, e As EventArgs) Handles SLUERecPri.EditValueChanged
        If SLUERecPri.Properties.View.GetFocusedRowCellValue("information") = "1" Then
            TERecPri.Visible = True
        Else
            TERecPri.Visible = False
            TERecPri.EditValue = ""
        End If
    End Sub

    Private Sub GVResult_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVResult.RowCellStyle
        If e.RowHandle = row_result Then
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If
    End Sub

    Private Sub GVGroupQuestion_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVGroupQuestion.RowCellStyle
        If e.RowHandle = GVGroupQuestion.RowCount - 1 Then
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If
    End Sub
End Class