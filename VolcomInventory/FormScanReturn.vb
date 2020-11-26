Public Class FormScanReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProductionRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCScanReturn.SelectedTabPageIndex = 0 Then
            If GVAwb.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Else
            If GVBAP.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub FormScanReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        DEStartBAP.EditValue = Now
        DEUntilBAP.EditValue = Now
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view()
    End Sub

    Sub load_view()

    End Sub

    Private Sub FormScanReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BViewBAP_Click(sender As Object, e As EventArgs) Handles BViewBAP.Click
        load_bap()
    End Sub

    Sub load_bap()
        Dim date_start As String = Date.Parse(DEStartBAP.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntilBAP.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim q As String = "SELECT IFNULL(c.comp_name,'Warehouse') AS comp_name,id_scan_return_bap,bap_number,`bap_date`,`is_lubang`,`is_seal_rusak`,`is_basah`,`is_other_cond`,`other_cond`,emp.employee_name,bap.created_date
FROM tb_scan_return_bap bap 
LEFT JOIN tb_m_comp c ON c.id_comp=bap.id_3pl
INNER JOIN tb_m_user usr ON usr.id_user=bap.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE DATE(bap.`created_date`)>='" & date_start & "' AND DATE(bap.`created_date`)<='" & date_until & "'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBAP.DataSource = dt
        GVBAP.BestFitColumns()
    End Sub

    Private Sub GVBAP_DoubleClick(sender As Object, e As EventArgs) Handles GVBAP.DoubleClick
        FormScanReturnBAP.id_bap = GVBAP.GetFocusedRowCellValue("id_scan_return_bap").ToString
        FormScanReturnBAP.ShowDialog()
    End Sub
End Class