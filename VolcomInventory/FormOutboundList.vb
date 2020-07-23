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

    Dim is_load As Boolean = False

    Sub load_list(ByVal id As String)
        Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) As qty,dis.sub_district,c.comp_name
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_store
WHERE awb.id_report_status!=5 AND awb.id_report_status!=6 AND awb.is_old_ways!=1 AND awb.step=1"
        If Not id = "" Then
            q += " AND awb.id_awbill='" & id & "' "
        End If
        q += " GROUP BY awb.id_awbill"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCOutbound.DataSource = dt
        GVOutbound.BestFitColumns()

        If Not id = "" And Not dt.Rows.Count > 0 Then
            warningCustom("Outbound number not found")
            TEOutboundNumber.Text = ""
        End If

        If dt.Rows.Count > 0 Then
            If Not id = "" Then
                'popup detail
                FormOutboundListDet.id_awb = addSlashes(TEOutboundNumber.Text)
                FormOutboundListDet.ShowDialog()
            End If
        End If
    End Sub

    Private Sub FormOutboundList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TEOutboundNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyUp
        If Not TEOutboundNumber.Text = "" Then
            If e.KeyCode = Keys.Enter Then
                load_list(addSlashes(TEOutboundNumber.Text))
            End If
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list("")
    End Sub
End Class