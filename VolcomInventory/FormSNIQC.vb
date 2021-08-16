Public Class FormSNIQC
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub formsniqc_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub formsniqc_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCInOut.SelectedTabPageIndex = 0 Then
            If GVSNIOut.RowCount < 1 Then
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
        Else
            If GVSNIIn.RowCount < 1 Then
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
        End If
    End Sub

    Private Sub FormSNIQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_list()
        If XTCInOut.SelectedTabPageIndex = 0 Then
            'SNI Out
            Dim q As String = "SELECT qco.id_qc_sni_out,emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_out qco
INNER JOIN tb_m_user usr ON qco.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qco.id_report_status
ORDER BY qco.id_qc_sni_out DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSNIOut.DataSource = dt
            GVSNIOut.BestFitColumns()
        ElseIf XTCInOut.SelectedTabPageIndex = 1 Then
            'SNI In
            Dim q As String = "SELECT emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_in qci
INNER JOIN tb_m_user usr ON qci.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qci.id_report_status
ORDER BY qci.id_qc_sni_in DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSNIOut.DataSource = dt
            GVSNIOut.BestFitColumns()
        End If
        check_menu()
    End Sub

    Private Sub XTCInOut_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCInOut.SelectedPageChanged
        load_list()
    End Sub
End Class