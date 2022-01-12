Public Class FormDeviden
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormDeviden_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_deviden()
        Dim q As String = "SELECT d.*,emp.employee_name,sts.report_status 
FROM tb_deviden d
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=d.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=d.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
ORDER BY id_deviden DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub FormItemExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCExpense.SelectedTabPageIndex = 0 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub
End Class