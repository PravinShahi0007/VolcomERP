Public Class FormEmpUniSize
    Dim id_employee As String = FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("id_employee").ToString
    Dim id_emp_uni_size_template As String = FormEmpUniPeriodDet.SLEGroupSize.EditValue.ToString

    Private Sub FormEmpUniSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'info
        LabelEmpName.Text = FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("employee_name").ToString
        LabelGroupName.Text = FormEmpUniPeriodDet.SLEGroupSize.Text.ToString
        LabelClass.Text = FormEmpUniPeriodDet.SLEGroupSize.Properties.View.GetFocusedRowCellValue("class_member").ToString

        'cek input
        Dim dcek As DataTable = checkInput()
        If dcek.Rows.Count >= 2 Then
            stopCustom("Maksimal pilihan size hanya 2")
            Cursor = Cursors.Default
            Close()
            Exit Sub
        ElseIf dcek.Rows.Count = 1 Then
            Dim id_size As String = dcek.Rows(0)("id_size").ToString
            Dim qs As String = "(SELECT s.id_size, cd.code_detail_name AS `size` 
            FROM tb_emp_uni_size_template_det s
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
            WHERE s.id_emp_uni_size_template=1 AND s.id_size<" + id_size + "
            ORDER BY s.id_size DESC LIMIT 1)
            UNION ALL
            (SELECT s.id_size, cd.code_detail_name AS `size` 
            FROM tb_emp_uni_size_template_det s
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
            WHERE s.id_emp_uni_size_template=1 AND s.id_size>" + id_size + "
            ORDER BY s.id_size ASC LIMIT 1) "
            Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
            GCData.DataSource = ds
            GVData.BestFitColumns()
        Else
            Dim qs As String = "SELECT s.id_size, cd.code_detail_name AS `size` 
            FROM tb_emp_uni_size_template_det s
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
            WHERE s.id_emp_uni_size_template=" + id_emp_uni_size_template + " "
            Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
            GCData.DataSource = ds
            GVData.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Function checkInput() As DataTable
        'cek
        Dim qcek As String = "SELECT * FROM tb_emp_uni_size s WHERE s.id_employee=" + id_employee + " AND s.id_emp_uni_size_template=" + id_emp_uni_size_template + " "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        Return dcek
    End Function

    Private Sub FormEmpUniSize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click

    End Sub

    Sub choose()

    End Sub
End Class