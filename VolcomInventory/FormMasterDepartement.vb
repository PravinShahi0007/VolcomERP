Public Class FormMasterDepartement
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterDepartement_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDepartement_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub view_department()
        Dim data As DataTable = execute_query("SELECT dept.*,emp.employee_name,emp_asst.employee_name AS employee_name_asst,emp_adm.employee_name AS employee_name_adm,emp_admbu.employee_name as employee_name_admbu FROM tb_m_departement dept 
                                                LEFT JOIN tb_m_user usr ON usr.id_user = dept.id_user_head 
                                                LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                                LEFT JOIN tb_m_user usr_asst ON usr_asst.id_user = dept.id_user_asst_head 
                                                LEFT JOIN tb_m_employee emp_asst ON emp_asst.id_employee=usr_asst.id_employee 
                                                LEFT JOIN tb_m_user usr_adm ON usr_adm.id_user = dept.id_user_admin 
                                                LEFT JOIN tb_m_employee emp_adm ON emp_adm.id_employee=usr_adm.id_employee 
                                                LEFT JOIN tb_m_user usr_admbu ON usr_admbu.id_user = dept.id_user_admin_backup
                                                LEFT JOIN tb_m_employee emp_admbu ON emp_admbu.id_employee=usr_admbu.id_employee 
                                                ORDER BY dept.departement", -1, True, "", "", "", "")
        GCDepartement.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        GVDepartment.BestFitColumns()
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterDepartement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        apply_skin()
        view_department()
    End Sub

    Private Sub FormMasterDepartement_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class