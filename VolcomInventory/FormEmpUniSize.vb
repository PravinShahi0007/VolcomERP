Public Class FormEmpUniSize
    Dim id_employee As String = FormEmpUniSizeMain.id_employee
    Dim id_emp_uni_size_template As String = FormEmpUniSizeMain.GVData.GetFocusedRowCellValue("id_emp_uni_size_template").ToString

    Private Sub FormEmpUniSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'info
        LabelEmpName.Text = FormEmpUniPeriodDet.GVSizeProfile.GetFocusedRowCellValue("employee_name").ToString
        LabelGroupName.Text = FormEmpUniSizeMain.GVData.GetFocusedRowCellValue("template_name").ToString
        LabelClass.Text = FormEmpUniSizeMain.GVData.GetFocusedRowCellValue("class_member").ToString

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
            WHERE s.id_emp_uni_size_template=" + id_emp_uni_size_template + " AND s.id_size<" + id_size + "
            ORDER BY s.id_size DESC LIMIT 1)
            UNION ALL
            (SELECT s.id_size, cd.code_detail_name AS `size` 
            FROM tb_emp_uni_size_template_det s
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
            WHERE s.id_emp_uni_size_template=" + id_emp_uni_size_template + " AND s.id_size>" + id_size + "
            ORDER BY s.id_size ASC LIMIT 1) "
            Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
            GCData.DataSource = ds
            GVData.BestFitColumns()
        Else
            Dim qs As String = "SELECT s.id_size, cd.code_detail_name AS `size` 
            FROM tb_emp_uni_size_template_det s
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = s.id_size
            WHERE s.id_emp_uni_size_template=" + id_emp_uni_size_template + " 
            ORDER BY s.id_size ASC "
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
        choose()
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_size As String = GVData.GetFocusedRowCellValue("id_size").ToString
            Dim query As String = "INSERT INTO tb_emp_uni_size(id_employee, id_emp_uni_size_template, id_size) VALUES 
            ('" + id_employee + "', '" + id_emp_uni_size_template + "', '" + id_size + "'); "
            execute_non_query(query, True, "", "", "", "")

            'refresh
            FormEmpUniSizeMain.viewGroupSize()
            FormEmpUniSizeMain.GVData.FocusedRowHandle = find_row(FormEmpUniSizeMain.GVData, "id_emp_uni_size_template", id_emp_uni_size_template)
            FormEmpUniPeriodDet.viewSizeProfile()
            FormEmpUniPeriodDet.GVSizeProfile.FocusedRowHandle = find_row(FormEmpUniPeriodDet.GVSizeProfile, "id_employee", id_employee)

            'cek 
            Dim dtc As DataTable = checkInput()
            If dtc.Rows.Count <= "1" Then
                infoCustom("Silahkan pilih 1 size lagi")
                actionLoad()
            Else
                Close()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub
End Class