Public Class FormOutboundList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormOutboundList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOutboundList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormOutboundList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_list(ByVal id As String)
        Dim q As String = "SELECT * FROM `tb_wh_awbill` WHERE id_report_status!=5 AND id_report_status!=6 AND is_old_ways!=1 AND step=1"
        If Not id = "" Then
            q += " AND id_awbill='" & id & "'"
        End If
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        If dt.Rows.Count > 0 Then
            GCOutbound.DataSource = dt
            GVOutbound.BestFitColumns()
            '
            If Not id = "" Then
                'popup detail
                FormOutboundListDet.id_awb = ""
                FormOutboundListDet.ShowDialog()
            End If
            '
        Else
            warningCustom("Outbound number not found")
        End If
    End Sub

    Private Sub FormOutboundList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TEOutboundNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            load_list(addSlashes(TEOutboundNumber.Text))
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list("")
    End Sub
End Class