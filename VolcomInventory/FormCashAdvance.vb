Public Class FormCashAdvance
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormCashAdvance_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormCashAdvance_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bedit_active = "1"
        bdel_active = "1"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCashAdvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_dep()
        load_employee()
        '
    End Sub

    Sub load_type()
        Dim query As String = "SELECT 0 as id_cash_advance_type,'All type' as cash_advance_type
UNION
SELECT id_cash_advance_type,cash_advance_type FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 as id_departement,'All Departement' as departement
UNION
SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT 0 as id_employee,'All Employee' as employee_name
UNION
SELECT id_employee,employee_name FROM tb_m_employee"

        If Not SLEDepartement.EditValue.ToString = "0" Then
            query += " WHERE tb_m_employee.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        End If

        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_cash_advance()
    End Sub

    Sub load_cash_advance()
        Dim where_string As String = ""

        If Not SLEType.EditValue.ToString = "0" Then
            where_string += " AND ca.id_cash_advance_type='" & SLEType.EditValue.ToString & "' "
        End If

        If SLEEmployee.EditValue.ToString = "0" Then 'all employee
            If Not SLEDepartement.EditValue.ToString = "0" Then 'from spesific departement
                where_string += " AND ca.id_departement='" & SLEDepartement.EditValue.ToString & "' "
            End If
        Else 'spesific employee
            where_string += " AND ca.id_employee='" & SLEEmployee.EditValue.ToString & "' "
        End If

        Dim query As String = "SELECT 'no' AS is_check,ca.`id_cash_advance`,ca.`number`,ca.`id_cash_advance_type`,cat.`cash_advance_type`,ca.`date_created`,ca.`created_by`,emp_created.`employee_name` AS emp_created
,ca.`id_employee`,emp.`employee_name`,ca.`id_departement`,dep.`departement`,ca.`val_ca`,ca.`note`,ca.`id_report_status`,sts.`report_status`,sts_rb.report_status AS report_back_status
FROM tb_cash_advance ca
INNER JOIN tb_lookup_cash_advance_type cat ON cat.`id_cash_advance_type`=ca.`id_cash_advance_type`
INNER JOIN tb_m_user usr_created ON usr_created.`id_user`=ca.`created_by`
INNER JOIN tb_m_employee emp_created ON emp_created.`id_employee`=usr_created.`id_employee`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=ca.`id_departement`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=ca.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=ca.`id_report_status`
INNER JOIN tb_lookup_report_status sts_rb PN sts_rb.id_report_status=ca.rb_id_report_status
WHERE 1=1 " & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListOpen.DataSource = data
        GVListOpen.BestFitColumns()
    End Sub

    Private Sub SLEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDepartement.EditValueChanged
        load_employee()
    End Sub
End Class