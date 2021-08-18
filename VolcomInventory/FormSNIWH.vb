Public Class FormSNIWH
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
            If GVSNIWaitRec.RowCount < 1 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCInOut.SelectedTabPageIndex = 1 Then
            If GVRecList.RowCount < 1 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCInOut.SelectedTabPageIndex = 2 Then
            If GVWaitDel.RowCount < 1 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCInOut.SelectedTabPageIndex = 3 Then
            If GVDelList.RowCount < 1 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        End If
    End Sub

    Private Sub FormSNIWH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_list()
        If XTCInOut.SelectedTabPageIndex = 0 Then
            'waiting to rec
            Dim q As String = "SELECT qco.id_qc_sni_out,emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_out qco
INNER JOIN tb_m_user usr ON qco.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qco.id_report_status AND qco.id_report_status=6 AND qco.is_rec_wh=2
ORDER BY qco.id_qc_sni_out DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSNIWaitRec.DataSource = dt
            GVSNIWaitRec.BestFitColumns()
        ElseIf XTCInOut.SelectedTabPageIndex = 1 Then
            'rec list
            Dim q As String = "SELECT qco.id_qc_sni_out,emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_out qco
INNER JOIN tb_m_user usr ON qco.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qco.id_report_status AND qco.id_report_status=6 AND qco.is_rec_wh=1
ORDER BY qco.id_qc_sni_out DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCRecList.DataSource = dt
            GVRecList.BestFitColumns()
        ElseIf XTCInOut.SelectedTabPageIndex = 3 Then
            'waiting to del
            Dim q As String = "SELECT qco.id_qc_sni_out,emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_out qco
INNER JOIN tb_m_user usr ON qco.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qco.id_report_status AND qco.id_report_status=6 AND qco.is_rec_wh=1 AND qco.is_del_wh=2
ORDER BY qco.id_qc_sni_out DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCWaitDel.DataSource = dt
            GVWaitDel.BestFitColumns()
        ElseIf XTCInOut.SelectedTabPageIndex = 4 Then
            'del list
            Dim q As String = "SELECT qco.id_qc_sni_out,emp.employee_name,qco.number,qco.`created_date`,qco.`id_comp_to`,sts.report_status
FROM tb_qc_sni_out qco
INNER JOIN tb_m_user usr ON qco.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qco.id_report_status AND qco.id_report_status=6 AND qco.is_rec_wh=1 AND qco.is_del_wh=1
ORDER BY qco.id_qc_sni_out DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCDelList.DataSource = dt
            GVDelList.BestFitColumns()
        End If
        check_menu()
    End Sub

    Private Sub XTCInOut_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCInOut.SelectedPageChanged
        load_list()
    End Sub
End Class