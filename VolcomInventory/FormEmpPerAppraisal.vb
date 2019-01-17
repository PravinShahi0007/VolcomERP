Public Class FormEmpPerAppraisal
    Public is_dephead As String = "-1"

    Sub load_employee()
        Dim query As String = "
            SELECT emp.id_employee, emp.id_departement, dept.departement,
	            emp.id_employee_status, stt.employee_status,
	            emp.employee_code, emp.employee_name,
	            emp.employee_position, emp.id_employee_level, lvl.employee_level, IF(lvl.grup_penilaian = 0, 1, lvl.grup_penilaian) grup_penilaian,
	            DATE_FORMAT(emp.employee_join_date, '%d %M %Y') employee_join_date,
	            DATE_FORMAT(emp2.start_period, '%d %M %Y') start_period,
	            DATE_FORMAT(emp2.end_period, '%d %M %Y') end_period,
	            IFNULL(qp.id_question_period, '-1') id_question_period
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
            LEFT JOIN tb_question_period qp ON emp.id_employee = qp.id_employee AND emp2.start_period = qp.from_period AND emp2.end_period = qp.until_period
            WHERE emp.id_employee_active = 1 AND (CURDATE() >= (emp2.end_period - INTERVAL 45 DAY) AND CURDATE() <= emp2.end_period)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpPerAppraisal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()
    End Sub

    Private Sub FormEmpPerAppraisal_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormEmpPerAppraisal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormEmpPerAppraisalDet.id_employee = GVList.GetFocusedRowCellValue("id_employee").ToString
        FormEmpPerAppraisalDet.id_question_period = GVList.GetFocusedRowCellValue("id_question_period").ToString
        FormEmpPerAppraisalDet.ShowDialog()
    End Sub
End Class