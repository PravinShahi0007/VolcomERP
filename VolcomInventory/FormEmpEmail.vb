Public Class FormEmpEmail
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee("-1")
    End Sub

    Sub viewEmployee(ByVal cond_param As String)
        'Dim query As String = "CALL view_employee('" + cond_param + "', '2')"
        Dim query As String = "SELECT emp.id_employee,  0 AS `id_other_email`, emp.employee_name, emp.id_departement , dept.departement, 
        emp.email_lokal, emp.email_lokal_pass, emp.email_external, emp.email_external_pass, emp.email_other, emp.email_other_pass,'1' AS `type`
        FROM tb_m_employee emp
        INNER JOIN tb_m_departement dept ON dept.id_departement = emp.id_departement
        UNION ALL
        SELECT 0 AS `id_employee`, oth.id_other_email, oth.name AS `employee_name`, oth.id_departement, dept_oth.departement,
        oth.email_lokal, oth.email_lokal_pass, oth.email_external, oth.email_external_pass, oth.email_other, oth.email_other_pass, '2' AS `type`
        FROM tb_m_other_email oth
        INNER JOIN tb_m_departement dept_oth ON dept_oth.id_departement = oth.id_departement 
        ORDER BY departement ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmail.DataSource = data
    End Sub

    Private Sub FormEmpEmail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormEmpEmail_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVEmail.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            indeks = GVEmail.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVEmail_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVEmail.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVEmail_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVEmail.FocusedRowChanged
        noManipulating()
        ' MsgBox(GVEmail.ActiveFilterString.ToString)
    End Sub

    Private Sub GVEmail_DoubleClick(sender As Object, e As EventArgs) Handles GVEmail.DoubleClick
        If GVEmail.RowCount > 0 And GVEmail.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class