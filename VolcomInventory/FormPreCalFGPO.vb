Public Class FormPreCalFGPO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPreCalFGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Sub load_list()
        Dim q As String = "SELECT c.comp_name,cf.comp_name AS forwarder,cal.id_report_status,sts.report_status,cal.id_pre_cal_fgpo,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.id_comp=cal.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=cal.id_report_status " & If(CENoCancel.Checked = True, " AND cal .id_report_status !=5 ", "") & "
LEFT JOIN tb_m_comp cf ON cf.id_comp=cal.choosen_id_comp
ORDER BY cal.id_pre_cal_fgpo DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPreCal.DataSource = dt
        GVPreCal.BestFitColumns()

        check_menu()
    End Sub

    Private Sub GVPreCal_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPreCal.RowStyle
        Try
            If GVPreCal.GetRowCellValue(e.RowHandle, "id_report_status").ToString = "5" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
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

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list()
    End Sub
End Class