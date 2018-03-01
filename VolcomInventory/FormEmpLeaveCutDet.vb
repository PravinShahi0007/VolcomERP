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
            If data_hdr.Rows(0)("is_process").ToString = "1" Then
                BMark.Visible = False
                Bload.Visible = False
                BGetEmployee.Visible = False
                BSetup.Visible = False
            Else
                BMark.Visible = True
                Bload.Visible = True
                BGetEmployee.Visible = True
                BSetup.Visible = True
            End If
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

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        'FormReportMark.id_report = id_leave_cut
        'FormReportMark.report_mark_type = "125"
        'FormReportMark.ShowDialog()
        If GVLeaveAdj.RowCount > 0 Then
            For i As Integer = 0 To GVLeaveAdj.RowCount - 1
                If GVLeaveAdj.GetRowCellValue(i, "adjustment_final") > 0 Then
                    Dim id_employee As String = GVLeaveAdj.GetRowCellValue(i, "id_employee").ToString
                    Dim adj_leave As Integer = GVLeaveAdj.GetRowCellValue(i, "adjustment_final")
                    'adjust
                    Dim query As String = "SELECT id_emp,SUM(IF(plus_minus=1,qty,-qty))/60 AS qty,`type`,IF(`type`=1,'Leave','DP') as type_ket,date_expired FROM tb_emp_stock_leave
                                WHERE id_emp='" & id_employee & "'
                                GROUP BY id_emp,date_expired,`type`
                                HAVING SUM(IF(plus_minus=1,qty,-qty)) > 0
                                ORDER BY `type` DESC,date_expired ASC"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    For j As Integer = 0 To data.Rows.Count - 1
                        Dim cuti_sisa As Integer = data.Rows(j)("qty")
                        If adj_leave > cuti_sisa Then
                            adj_leave = adj_leave - cuti_sisa
                            'insert cuti
                            Dim query_pot_cuti As String = "INSERT tb_emp_stock_leave()"
                        Else
                            Exit For
                        End If
                    Next
                    '
                    If adj_leave > 0 Then
                        'advance leave here
                    End If
                End If
            Next
        End If

        Dim query_upd As String = "UPDATE tb_emp_leave_cut SET is_process='1' WHERE id_leave_cut='" & id_leave_cut & "'"
        infoCustom("Stock Leave Adjusted")
        load_det()
    End Sub
End Class