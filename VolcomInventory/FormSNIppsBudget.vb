Public Class FormSNIppsBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVList.RowCount < 1 Then
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

    Private Sub FormSNIppsBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,sts.report_status
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,sts.report_status,cp.number AS cop_pps_number
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_design_cop_propose cp ON cp.id_design_cop_propose=pps.id_design_cop_propose
WHERE pps.is_need_confirm=1 AND pps.is_confirmed=2 AND pps.id_report_status=6"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCConfirm.DataSource = dt
        GVConfirm.BestFitColumns()
    End Sub

    Private Sub GCList_DoubleClick(sender As Object, e As EventArgs) Handles GCList.DoubleClick
        If GVList.RowCount > 0 Then
            FormSNIppsDet.id_pps = GVList.GetFocusedRowCellValue("id_sni_pps").ToString
            FormSNIppsDet.ShowDialog()
        End If
    End Sub

    Private Sub GVConfirm_DoubleClick(sender As Object, e As EventArgs) Handles GVConfirm.DoubleClick
        If GVConfirm.RowCount > 0 Then
            FormSNIppsDet.id_pps = GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString
            FormSNIppsDet.is_view = "1"
            FormSNIppsDet.ShowDialog()
        End If
    End Sub

    Private Sub RINoChanges_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RINoChanges.ButtonClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Choosing no changes, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                'update ecop SNI yang kena changes
                Dim q As String = "SELECT l.id_sni_pps,l.id_design 
FROM `tb_sni_pps_list` l
INNER JOIN tb_sni_pps p ON p.id_sni_pps=l.id_sni_pps ON l.id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'
INNER JOIN `tb_design_cop_propose_det` cd ON cd.id_design_cop_propose=p.id_design_cop_propose AND l.id_design=cd.id_design"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                'notif ke MD

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class