Public Class FormEmpPayrollPeriode
    Public id_payroll As String = "-1"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollPeriode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollPeriode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type_payroll()

        If Not id_payroll = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_emp_payroll WHERE id_payroll='" & id_payroll & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            DEStart.EditValue = data.Rows(0)("periode_start")
            DEEnd.EditValue = data.Rows(0)("periode_end")

            DEStartOt.EditValue = data.Rows(0)("ot_periode_start")
            DEEndOt.EditValue = data.Rows(0)("ot_periode_end")

            MEPayrollNote.Text = data.Rows(0)("note").ToString

            LEPayrollType.ItemIndex = LEPayrollType.Properties.GetDataSourceRowIndex("id_payroll_type", data.Rows(0)("id_payroll_type").ToString)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim date_start, date_end, ot_date_start, ot_date_end, note, id_payroll_type As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_end = Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        ot_date_start = Date.Parse(DEStartOt.EditValue.ToString).ToString("yyyy-MM-dd")
        ot_date_end = Date.Parse(DEEndOt.EditValue.ToString).ToString("yyyy-MM-dd")
        note = addSlashes(MEPayrollNote.Text)
        id_payroll_type = LEPayrollType.EditValue.ToString

        If id_payroll = "-1" Then
            Dim query As String = "INSERT INTO tb_emp_payroll(periode_start,periode_end,ot_periode_start,ot_periode_end,note,last_upd,id_user_upd,id_payroll_type) VALUES('" & date_start & "','" & date_end & "','" & ot_date_start & "','" & ot_date_end & "','" & note & "',NOW(),'" & id_user & "','" & id_payroll_type & "'); SELECT LAST_INSERT_ID();"
            id_payroll = execute_query(query, 0, True, "", "", "", "")
            '
            FormEmpPayroll.load_payroll()
            FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_payroll)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_emp_payroll SET periode_start='" & date_start & "',periode_end='" & date_end & "',ot_periode_start='" & ot_date_start & "',ot_periode_end='" & ot_date_end & "',note='" & note & "',last_upd=NOW(),id_user_upd='" & id_user & "',id_payroll_type='" & id_payroll_type & "' WHERE id_payroll='" & id_payroll & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            FormEmpPayroll.load_payroll()
            FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_payroll)
            Close()
        End If
    End Sub

    Sub load_type_payroll()
        Dim query As String = "SELECT id_payroll_type,payroll_type FROM tb_emp_payroll_type"
        viewLookupQuery(LEPayrollType, query, 0, "payroll_type", "id_payroll_type")
    End Sub
End Class