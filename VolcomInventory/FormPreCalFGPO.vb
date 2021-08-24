Public Class FormPreCalFGPO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPreCalFGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_list()
        Dim q As String = "SELECT c.comp_name,cal.id_pre_cal_fgpo,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.id_comp=cal.id_comp"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPreCal.DataSource = dt
        GVPreCal.BestFitColumns()

        check_menu()
    End Sub

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVPreCal.RowCount < 1 Then
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
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub
End Class