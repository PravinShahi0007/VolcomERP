Public Class FormEmpLeaveCutDet
    Public id_leave_cut As String = "-1"
    Public id_dep As String = "-1"
    Private Sub FormEmpLeaveCutDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_leave_cut = "-1" Then
            FormEmpLeaveCutDetSetup.ShowDialog()
        End If
        If id_leave_cut = "-1" Then
            Close()
        Else
            load_det()
        End If
    End Sub

    Private Sub BGetEmployee_Click(sender As Object, e As EventArgs) Handles BGetEmployee.Click
        FormEmpLeaveCutEmp.id_leave_cut = id_leave_cut
        FormEmpLeaveCutEmp.id_departement = id_dep
        FormEmpLeaveCutEmp.ShowDialog()
    End Sub

    Sub load_det()
        Dim query_hdr As String = "SELECT dep.id_departement,dep.`departement`,lc.`leave_cut_number` FROM tb_emp_leave_cut lc
                                    INNER JOIN tb_m_departement dep ON dep.`id_departement`=lc.`id_departement`
                                    WHERE lc.id_leave_cut='" & id_leave_cut & "'"
        Dim data_hdr As DataTable = execute_query(query_hdr, -1, True, "", "", "", "")
        If data_hdr.Rows.Count > 0 Then
            TENumber.Text = data_hdr.Rows(0)("leave_cut_number").ToString
            TEDept.Text = data_hdr.Rows(0)("departement").ToString
            id_dep = data_hdr.Rows(0)("id_departement").ToString
        End If
        '
        Dim query As String = "CALL view_leave_cut('" & id_leave_cut & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveAdj.DataSource = data
        GVLeaveAdj.BestFitColumns()
    End Sub

    Private Sub BSetup_Click(sender As Object, e As EventArgs) Handles BSetup.Click
        FormEmpLeaveCutDetSetup.id_leave_cut = id_leave_cut
        FormEmpLeaveCutDetSetup.ShowDialog()
    End Sub

    Private Sub Bload_Click(sender As Object, e As EventArgs) Handles Bload.Click
        Dim query As String = "CALL load_total_leave_cut('" & id_leave_cut & "')"
        execute_non_query(query, True, "", "", "", "")
        load_det()
    End Sub

    Private Sub CMDelEmp_Click(sender As Object, e As EventArgs) Handles CMDelEmp.Click
        Dim query As String = "DELETE FROM tb_emp_leave_cut_det WHERE id_leave_cut_det='" & GVLeaveAdj.GetFocusedRowCellValue("id_leave_cut_det").ToString & "'"
        execute_non_query(query, True, "", "", "", "")
        load_det()
    End Sub

    Private Sub ViewAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAttendanceToolStripMenuItem.Click
        FormEmpAttnIndView.id_employee = GVLeaveAdj.GetFocusedRowCellValue("id_employee").ToString
        FormEmpAttnIndView.DEStart.EditValue = ""
        FormEmpAttnIndView.DEUntil.EditValue = ""
    End Sub
End Class