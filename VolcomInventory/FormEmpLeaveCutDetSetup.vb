Public Class FormEmpLeaveCutDetSetup
    Public id_leave_cut As String = "-1"
    Dim id_dep_old As String = "-1"
    Private Sub FormEmpLeaveCutDetSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_dept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.id_departement "
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
    End Sub
    '
    Private Sub FormEmpLeaveCutDetSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        load_dept()
        load_payroll_periode()

        If Not id_leave_cut = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_emp_leave_cut WHERE id_leave_cut='" & id_leave_cut & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                LEPayrollPeriode.ItemIndex = LEPayrollPeriode.Properties.GetDataSourceRowIndex("id_payroll", data.Rows(0)("id_payroll").ToString)
                LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
                id_dep_old = data.Rows(0)("id_departement").ToString
                MENote.Text = data.Rows(0)("note").ToString
            End If
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Sub load_payroll_periode()
        Dim query As String = "SELECT p.id_payroll,p.periode_start,p.periode_end,DATE_FORMAT(`periode_end`,'%M %Y') as periode FROM tb_emp_payroll p"
        viewLookupQuery(LEPayrollPeriode, query, 0, "periode", "id_payroll")
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        Dim note As String = addSlashes(MENote.Text)
        Dim id_periode As String = LEPayrollPeriode.EditValue.ToString
        Dim id_dep As String = LEDepartement.EditValue.ToString
        If id_leave_cut = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_emp_leave_cut(id_payroll,id_departement,date_created,date_upd,id_user_last_upd,id_report_status,note)
                                    VALUES('" & id_periode & "','" & id_dep & "',NOW(),NOW(),'" & id_user & "','1','" & note & "'); SELECT LAST_INSERT_ID(); "
            id_leave_cut = execute_query(query, 0, True, "", "", "", "")
            FormEmpLeaveCutDet.id_leave_cut = id_leave_cut
            Close()
        Else 'edit
            If Not id_dep = id_dep_old Then
                Dim confirm As DialogResult
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Changing departement will reset all employee listed, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_emp_leave_cut_det WHERE id_leave_cut='" & id_leave_cut & "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    Dim query As String = "UPDATE tb_emp_leave_cut SET id_payroll='" & id_periode & "',id_departement='" & id_dep & "',date_upd=NOW(),id_user_last_upd='" & id_user & "',note='" & note & "' WHERE id_leave_cut='" & id_leave_cut & "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpLeaveCutDet.load_det()
                    Close()
                End If
            Else
                Dim query As String = "UPDATE tb_emp_leave_cut SET id_payroll='" & id_periode & "',id_departement='" & id_dep & "',date_upd=NOW(),id_user_last_upd='" & id_user & "',note='" & note & "' WHERE id_leave_cut='" & id_leave_cut & "'"
                execute_non_query(query, True, "", "", "", "")
                FormEmpLeaveCutDet.load_det()
                Close()
            End If

        End If
    End Sub
End Class