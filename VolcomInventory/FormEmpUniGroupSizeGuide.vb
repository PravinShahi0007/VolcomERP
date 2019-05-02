Public Class FormEmpUniGroupSizeGuide
    Private Sub FormEmpUniGroupSizeGuide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewGroupSize()
    End Sub

    Sub viewGroupSize()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.id_emp_uni_size_template, t.template_name, t.id_sex, sex.sex, cm.class_member, sm.size_member
        FROM tb_emp_uni_size_template t
        INNER JOIN tb_lookup_sex sex ON sex.id_sex = t.id_sex
        LEFT JOIN (
	        SELECT cls.id_emp_uni_size_template, GROUP_CONCAT(DISTINCT cd.display_name ORDER BY cd.display_name ASC SEPARATOR ', ') AS `class_member`
	        FROM tb_emp_uni_size_template_class cls
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = cls.id_class
	        GROUP BY cls.id_emp_uni_size_template
        ) cm ON cm.id_emp_uni_size_template = t.id_emp_uni_size_template
        LEFT JOIN (
	        SELECT sz.id_emp_uni_size_template, GROUP_CONCAT(DISTINCT cd.display_name ORDER BY cd.id_code_detail ASC SEPARATOR ', ') AS `size_member`
	        FROM tb_emp_uni_size_template_det sz
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = sz.id_size
	        GROUP BY sz.id_emp_uni_size_template
        ) sm ON sm.id_emp_uni_size_template = t.id_emp_uni_size_template
        ORDER BY t.id_sex ASC, t.id_emp_uni_size_template ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpUniGroupSizeGuide_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub
End Class