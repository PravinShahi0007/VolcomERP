Public Class FormPurcReqICApproval
    Public id_report As String = "-1"
    Public step_approve As String = "-1"
    '
    Public id_user_created As String = "-1"
    Public id_departement_pr As String = "-1"

    Private Sub FormPurcReqICApproval_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReqICApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEEmployee.Text = get_user_identify(id_user, "1")
    End Sub

    Private Sub BRefuse_Click(sender As Object, e As EventArgs) Handles BRefuse.Click
        If MEComment.Text = "" Then
            warningCustom("Please input comment first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to not approve ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query As String = ""
                If step_approve = "1" Then
                    query = "UPDATE tb_purc_req pr SET pr.ic_approval='3',ic_note='" & addSlashes(MEComment.Text) & "',ic_approve_by='" & id_user & "',ic_approve_date=NOW() WHERE id_purc_req='" & id_report & "'"
                ElseIf step_approve = "2" Then
                    query = "UPDATE tb_purc_req pr SET pr.ia_approval='3',ia_note='" & addSlashes(MEComment.Text) & "',ia_approve_by='" & id_user & "' WHERE id_purc_req='" & id_report & "'"
                End If
                execute_non_query(query, True, "", "", "", "")
                '
                If step_approve = "1" Then
                    submit_pr()
                End If
                '
                Close()
            End If
        End If
    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        If MEComment.Text = "" Then
            warningCustom("Please input comment first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to approve ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query As String = ""
                If step_approve = "1" Then
                    query = "UPDATE tb_purc_req pr SET pr.ic_approval='2',pr.ic_note='" & addSlashes(MEComment.Text) & "',pr.ic_approve_by='" & id_user & "',ic_approve_date=NOW() WHERE pr.id_purc_req='" & id_report & "'"
                ElseIf step_approve = "2" Then
                    query = "UPDATE tb_purc_req pr SET pr.ia_approval='2',pr.ia_note='" & addSlashes(MEComment.Text) & "',pr.ia_approve_by='" & id_user & "' WHERE pr.id_purc_req='" & id_report & "'"
                End If
                execute_non_query(query, True, "", "", "", "")
                '
                If step_approve = "1" Then
                    submit_pr()
                End If
                '
                Close()
            End If
        End If
    End Sub

    Sub submit_pr()
        'Dim query As String = "SELECT ic_approval,ia_approval FROM tb_purc_req WHERE id_purc_req='" & id_report & "'"
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'If data.Rows.Count > 0 Then
        '    If data.Rows(0)("ic_approval").ToString = "1" Or data.Rows(0)("ia_approval").ToString = "1" Then
        '        'do nothing
        '    ElseIf data.Rows(0)("ic_approval").ToString = "2" And data.Rows(0)("ia_approval").ToString = "2" Then
        '        'sama - sama setuju
        '        Dim query_upd As String = "UPDATE tb_purc_req SET is_submit='1' WHERE id_purc_req='" & id_report & "'"
        '        execute_non_query(query_upd, True, "", "", "", "")
        '        submit_who_prepared("201", id_report, id_user_created)
        '    ElseIf data.Rows(0)("ic_approval").ToString = "3" And data.Rows(0)("ia_approval").ToString = "3" Then
        '        'sama - sama gk setuju
        '        Dim query_upd As String = "UPDATE tb_purc_req SET id_report_status='5' WHERE id_purc_req='" & id_report & "'"
        '        execute_non_query(query_upd, True, "", "", "", "")
        '    Else
        '        'bentrok
        '        Dim query_upd As String = "UPDATE tb_purc_req SET is_submit='1' WHERE id_purc_req='" & id_report & "'"
        '        execute_non_query(query_upd, True, "", "", "", "")
        '        submit_who_prepared("218", id_report, id_user_created)
        '        'submit_who_prepared("201", id_report, id_user_created)
        '    End If
        'End If

        'pindah ke awal
        'Dim query_upd As String = "UPDATE tb_purc_req SET is_submit='1' WHERE id_purc_req='" & id_report & "'"
        'execute_non_query(query_upd, True, "", "", "", "")

        'submit_who_prepared_pr("201", id_report, id_user_created, id_departement_pr)
    End Sub

    Private Sub BViewDocument_Click(sender As Object, e As EventArgs) Handles BViewDocument.Click
        Cursor = Cursors.WaitCursor
        Dim report_mark_type As String = "-1"

        report_mark_type = "201"

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = report_mark_type
        showpopup.id_report = id_report
        showpopup.show()
        Cursor = Cursors.Default
    End Sub
End Class