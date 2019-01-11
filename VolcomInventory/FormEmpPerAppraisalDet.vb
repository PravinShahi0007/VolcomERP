Public Class FormEmpPerAppraisalDet
    Public id_employee As String = "-1"
    Public id_question_period As String = "-1"

    Public id_question_res As Integer = 0

    Sub load_employee()
        Dim query As String = "
            SELECT emp.id_employee, emp.id_departement, dept.departement,
                emp.id_employee_status, stt.employee_status,
                emp.employee_code, emp.employee_name,
                emp.employee_position, emp.id_employee_level, lvl.employee_level,
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
                SELECT 0 no, qg.id_question_gen, qg.question, qg.question_detail, qg.id_question_gen_group, CONCAT(qg.id_question_gen_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, IFNULL(qgr.id_question_gen_res, 0) id_question_gen_res, IFNULL(qgr.value, 0) value, IFNULL(qgr.information, '') information
                FROM tb_question_gen qg
                LEFT JOIN tb_question_gen_group qgg ON qg.id_question_gen_group = qgg.id_question_gen_group
                LEFT JOIN tb_question_gen_res qgr ON qg.id_question_gen = qgr.id_question_gen
                WHERE qgr.id_question_period = '" + id_question_period + "'
                ORDER BY qg.id_question_gen_group ASC
            "
        Else
            query = "
                SELECT 0 no, qg.id_question_gen, qg.question, qg.question_detail, qg.id_question_gen_group, CONCAT(qg.id_question_gen_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, 0 id_question_gen_res, 0 value, '' information
                FROM tb_question_gen qg
                LEFT JOIN tb_question_gen_group qgg ON qg.id_question_gen_group = qgg.id_question_gen_group
                ORDER BY qg.id_question_gen_group ASC
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

        If id_question_period <> "-1" Then
            query = "
                SELECT 0 no, qc.id_question_con, qc.question, IFNULL(qcr.id_question_con_res, 0) id_question_con_res, IFNULL(qcr.conclusion, '') conclusion
                FROM tb_question_con qc
                LEFT JOIN tb_question_con_res qcr ON qc.id_question_con = qcr.id_question_con
                WHERE qcr.id_question_period = '" + id_question_period + "'
            "
        Else
            query = "
                SELECT 0 no, qc.id_question_con, qc.question, 0 id_question_con_res, '' conclusion 
                FROM tb_question_con qc
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCConclusion.DataSource = data

        GVConclusion.BestFitColumns()
    End Sub

    Sub load_result()
        Dim query As String = "
                SELECT qr.id_question_res, qr.id_result, lqr.information, qr.result_information, qr.employee_note, qr.hrd_note
                FROM tb_question_res qr
                LEFT JOIN tb_lookup_question_result lqr ON qr.id_result = lqr.id_result
                WHERE qr.id_question_period = '" + id_question_period + "'
            "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'note
        If id_question_period <> "-1" Then
            id_question_res = data.Rows(0)("id_question_res")

            MEEmployeeNote.EditValue = data.Rows(0)("employee_note")
            MEHRDNote.EditValue = data.Rows(0)("hrd_note")
        End If

        'recommendation
        Dim select_result As String = "0"

        If id_question_period <> "-1" Then
            select_result = "IFNULL((SELECT id_result FROM tb_question_res WHERE id_result = lqr.id_result AND id_question_period = '3'), 0)"
        End If

        query = "
                SELECT lqr.id_result, lqr.result, lqr.information, " + select_result + " is_select
                FROM tb_lookup_question_result lqr
            "

        viewSearchLookupQuery(SLUERec, query, "id_result", "result", "id_result")

        If id_question_period <> "-1" Then
            SLUERec.EditValue = data.Rows(0)("id_result")
            TERec.EditValue = data.Rows(0)("result_information")

            If data.Rows(0)("information") = "1" Then
                TERec.Visible = True
            Else
                TERec.Visible = False
            End If
        End If
    End Sub

    Private Sub FormEmpPerAppraisalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()

        load_question()

        load_conclusion()

        load_result()

        calculate_total()
    End Sub

    Sub calculate_total()
        'all group
        Dim query_group As String = "
            SELECT id_question_gen_group, CONCAT(id_question_gen_group, '. ', group_name) group_name, group_weight FROM tb_question_gen_group ORDER BY id_question_gen_group ASC
        "

        Dim data_group As DataTable = execute_query(query_group, -1, True, "", "", "", "")

        'last id
        Dim query_group_id As String = "
            SELECT id_question_gen_group FROM tb_question_gen_group ORDER BY id_question_gen_group DESC LIMIT 1
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
                id_group = GVListQuestion.GetRowCellValue(i, "id_question_gen_group")

                tot(id_group) += GVListQuestion.GetRowCellValue(i, "value")
                count(id_group) += 1
            End If
        Next

        'datatable column
        total_detail.Columns.Add("group_name", GetType(String))
        total_detail.Columns.Add("formula", GetType(String))
        total_detail.Columns.Add("total", GetType(String))

        result.Columns.Add("result", GetType(String))
        result.Columns.Add("detail", GetType(String))
        result.Columns.Add("score", GetType(String))

        'total calculation
        For i As Integer = 0 To data_group.Rows.Count - 1
            id_group = data_group.Rows(i)("id_question_gen_group")
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
        If total_score > 90 Then
            result.Rows.Add("(X)", "Memuaskan", "90,01 - 100,00")
        Else
            result.Rows.Add("()", "Memuaskan", "90,01 - 100,00")
        End If

        If total_score > 80 And total_score <= 90 Then
            result.Rows.Add("(X)", "Baik Sekali", "80,01 - 90,00")
        Else
            result.Rows.Add("()", "Baik Sekali", "80,01 - 90,00")
        End If

        If total_score > 60 And total_score <= 80 Then
            result.Rows.Add("(X)", "Baik", "60,01 - 80,00")
        Else
            result.Rows.Add("()", "Baik", "60,01 - 80,00")
        End If

        If total_score > 40 And total_score <= 60 Then
            result.Rows.Add("(X)", "Perlu Perbaikan", "40,01 - 60,00")
        Else
            result.Rows.Add("()", "Perlu Perbaikan", "40,01 - 60,00")
        End If

        If total_score < 40 Then
            result.Rows.Add("(X)", "Kurang", "00,00 - 40,00")
        Else
            result.Rows.Add("()", "Kurang", "00,00 - 40,00")
        End If

        GCGroupQuestion.DataSource = total_detail
        GVGroupQuestion.BestFitColumns()

        GCResult.DataSource = result
        GVResult.BestFitColumns()
    End Sub

    Sub save_data()
        Dim query As String = ""

        If id_question_period = "-1" Then
            Dim start_period As String = Date.Parse(TEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim end_period As String = Date.Parse(TEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd")

            query = "INSERT INTO tb_question_period (id_employee, from_period, until_period, created_date) VALUES ('" + id_employee + "', '" + start_period + "', '" + end_period + "', NOW()); SELECT LAST_INSERT_ID();"

            id_question_period = execute_query(query, 0, True, "", "", "", "")
        End If

        'gen
        For i As Integer = 0 To GVListQuestion.RowCount - 1
            If GVListQuestion.IsValidRowHandle(i) Then
                If GVListQuestion.GetRowCellValue(i, "id_question_gen_res").ToString = "0" Then
                    query = "INSERT INTO tb_question_gen_res (id_question_period, id_question_gen, value, information) VALUES ('" + id_question_period + "', '" + GVListQuestion.GetRowCellValue(i, "id_question_gen").ToString + "', '" + GVListQuestion.GetRowCellValue(i, "value").ToString + "', '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "')"
                Else
                    query = "UPDATE tb_question_gen_res SET id_question_period = '" + id_question_period + "', id_question_gen = '" + GVListQuestion.GetRowCellValue(i, "id_question_gen").ToString + "', value = '" + GVListQuestion.GetRowCellValue(i, "value").ToString + "', information = '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "' WHERE id_question_gen_res = '" + GVListQuestion.GetRowCellValue(i, "id_question_gen_res").ToString + "'"
                End If

                execute_non_query(query, True, "", "", "", "")
            End If
        Next

        'con
        For i As Integer = 0 To GVConclusion.RowCount - 1
            If GVConclusion.GetRowCellValue(i, "id_question_con_res").ToString = "0" Then
                query = "INSERT INTO tb_question_con_res (id_question_period, id_question_con, conclusion) VALUES ('" + id_question_period + "', '" + GVConclusion.GetRowCellValue(i, "id_question_con").ToString + "', '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "')"
            Else
                query = "UPDATE tb_question_con_res SET id_question_period = '" + id_question_period + "', id_question_con = '" + GVConclusion.GetRowCellValue(i, "id_question_con").ToString + "', conclusion = '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "' WHERE id_question_con_res = '" + GVConclusion.GetRowCellValue(i, "id_question_con_res").ToString + "'"
            End If

            execute_non_query(query, True, "", "", "", "")
        Next

        'res
        If id_question_res <> 0 Then
            query = "UPDATE tb_question_res SET id_question_period = '" + id_question_period + "', id_result = '" + SLUERec.EditValue.ToString + "', employee_note = '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', hrd_note = '" + addSlashes(MEHRDNote.EditValue.ToString) + "', result_information = '" + addSlashes(TERec.EditValue.ToString) + "' WHERE id_question_res = '" + id_question_res.ToString + "'"
        Else
            query = "INSERT INTO tb_question_res (id_question_period, id_result, employee_note, hrd_note, result_information) VALUES ('" + id_question_period + "', '" + SLUERec.EditValue.ToString + "', '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', '" + addSlashes(MEHRDNote.EditValue.ToString) + "', '" + addSlashes(TERec.EditValue.ToString) + "')"
        End If

        execute_non_query(query, True, "", "", "", "")
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

    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click

    End Sub

    Private Sub SLUERec_EditValueChanged(sender As Object, e As EventArgs) Handles SLUERec.EditValueChanged
        If SLUERec.Properties.View.GetFocusedRowCellValue("information") = "1" Then
            TERec.Visible = True
        Else
            TERec.Visible = False
            TERec.EditValue = ""
        End If
    End Sub
End Class