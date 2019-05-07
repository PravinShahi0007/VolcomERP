Public Class FormEmpUniSizeMain
    Public id_employee As String = "-1"
    Private Sub FormEmpUniSizeMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Text + FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("employee_name").ToString
        id_employee = FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("id_employee").ToString

        viewGroupSize()
    End Sub

    Private Sub FormEmpUniSizeMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewGroupSize()
        Cursor = Cursors.WaitCursor
        Dim cond_sex As String = ""
        If FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("id_sex").ToString = "1" Then
            cond_sex = "AND t.id_sex=1 "
        End If

        Dim query As String = "SELECT t.id_emp_uni_size_template, t.template_name, t.id_sex, sex.sex, cm.class_member, sm.size_member,  IFNULL(ss.selected_size,'-') AS `selected_size`
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
        LEFT JOIN (
	        SELECT s.id_emp_uni_size_template, GROUP_CONCAT(DISTINCT cd.display_name ORDER BY cd.id_code_detail ASC SEPARATOR ', ') AS `selected_size`
	        FROM tb_emp_uni_size s
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
	        WHERE s.id_employee=" + id_employee + "
	        GROUP BY s.id_emp_uni_size_template 
        ) ss ON ss.id_emp_uni_size_template = t.id_emp_uni_size_template
        WHERE t.id_emp_uni_size_template>0
        " + cond_sex + "
        ORDER BY t.id_sex ASC, t.id_emp_uni_size_template ASC  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub ResetSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetSizeToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset your selected size in " + GVData.GetFocusedRowCellValue("template_name") + ". Are you sure want to continue this action ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_emp_uni_size_template As String = GVData.GetFocusedRowCellValue("id_emp_uni_size_template").ToString
                Dim query As String = "DELETE FROM tb_emp_uni_size WHERE id_employee=" + id_employee + " AND id_emp_uni_size_template=" + id_emp_uni_size_template + "; "
                execute_non_query(query, True, "", "", "", "")

                'refresh
                viewGroupSize()
                GVData.FocusedRowHandle = find_row(GVData, "id_emp_uni_size_template", id_emp_uni_size_template)
                FormEmpUniPeriodDet.viewSizeProfile()
                FormEmpUniPeriodDet.GVSizeProfile.FocusedRowHandle = find_row(FormEmpUniPeriodDet.GVSizeProfile, "id_employee", id_employee)
            End If
        End If
    End Sub

    Private Sub AddSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSizeToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormEmpUniSize.ShowDialog()
        End If
    End Sub
End Class