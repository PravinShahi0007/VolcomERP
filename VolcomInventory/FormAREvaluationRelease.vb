Public Class FormAREvaluationRelease
    Public id As String = "-1"
    Public id_ar_eval_pps As String = "-1"
    Public action As String = ""
    Public rmt As String = "338"
    Dim id_report_status As String = "1"

    Private Sub FormAREvaluationRelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        actionLoad()
    End Sub

    Private Sub FormAREvaluationRelease_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description
        FROM tb_ar_eval e
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = e.id_comp_group
        WHERE e.id_ar_eval_pps='" + id_ar_eval_pps + "' AND cg.is_ar_special_rule=1 AND e.is_active=1
        GROUP BY e.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            id_ar_eval_pps = FormAREvaluation.id_ar_eval_pps
            TxtAREvalNumber.Text = FormAREvaluation.TxtAREvalNumber.Text
            TxtAREvalDate.Text = FormAREvaluation.BtnBrowseEval.Text
        ElseIf action = "upd" Then
            BtnSave.Enabled = False
            BtnAttach.Enabled = True
            BtnRelease.Enabled = True

            'query
            Dim query As String = "SELECT r.id_ar_eval_release, r.id_ar_eval_pps, p.`number`, p.eval_date, r.id_comp_group, r.created_date, r.created_by, 
            r.memo_number, r.note, r.id_report_status
            FROM tb_ar_eval_release r 
            INNER JOIN tb_ar_eval_pps p ON p.id_ar_eval_pps = r.id_ar_eval_pps
            WHERE r.id_ar_eval_release=" + id + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtAREvalNumber.Text = data.Rows(0)("number").ToString
            TxtAREvalDate.Text = DateTime.Parse(data.Rows(0)("eval_date").ToString).ToString("dd MMMM yyyy")
            TxtMemoNo.Text = data.Rows(0)("memo_number").ToString
            SLECompGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            MENote.Text = data.Rows(0)("note").ToString
            id_ar_eval_pps = data.Rows(0)("id_ar_eval_pps").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString

            'permision
            TxtAREvalNumber.Enabled = False
            TxtAREvalDate.Enabled = False
            TxtMemoNo.Enabled = False
            SLECompGroup.Enabled = False
            MENote.Enabled = False
            If id_report_status = "6" Or id_report_status = "5" Then
                BtnRelease.Enabled = False
            End If
        End If
            Cursor = Cursors.Default
    End Sub

    Private Sub BtnRelease_Click(sender As Object, e As EventArgs) Handles BtnRelease.Click
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString
        Dim note As String = addSlashes(MENote.Text.ToString)
        Dim query As String = "UPDATE tb_ar_eval e SET release_date=NOW(), is_manual_release=1,note='" + note + "',e.is_active=2, id_ar_eval_release='" + id + "' WHERE e.id_ar_eval_pps='" + id_ar_eval_pps + "' AND e.is_active=1 AND e.id_comp_group='" + id_comp_group + "'; 
        UPDATE tb_ar_eval_release SET id_report_status=6 WHERE id_ar_eval_release='" + id + "'; "
        execute_non_query(query, True, "", "", "", "")
        Dim ev As New ClassAREvaluation()
        Dim data_cek_email_release As DataTable = ev.dtCekEmailRelease(id_comp_group)
        If data_cek_email_release.Rows.Count > 0 Then
            'jika ada yg dibayar semua maka kirim email
            Dim mm As New ClassMailManage()
            Dim id_mail As String = "-1"
            Dim mail_subject As String = get_setup_field("mail_subject_release_del")
            Dim mail_title As String = get_setup_field("mail_title_release_del")
            Dim mail_content As String = get_setup_field("mail_content_release_del")
            Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                                FROM tb_opt o
                                INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
            Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

            'send paramenter class
            mm.mail_subject = mail_subject
            mm.mail_title = mail_title
            mm.par1 = id_comp_group
            mm.rmt = "230"
            mm.createEmail(id_comp_group, id_user, "NULL", "NULL", "NULL")
            id_mail = mm.id_mail_manage

            'email
            Try
                Dim em As New ClassSendEmail()
                em.report_mark_type = "230"
                em.id_report = id_mail
                em.design_code = mail_title
                em.design = mail_subject
                em.comment_by = mail_content_to
                em.comment = mail_content
                em.dt = mm.getDetailData
                em.send_email()

                Dim query_log As String = mm.queryInsertLog(id_user, "2", "Sent Successfully")
                execute_non_query(query_log, True, "", "", "", "")
            Catch ex As Exception
                Dim query_log As String = mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
                execute_non_query(query_log, True, "", "", "", "")
            End Try
        End If
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString
        Dim note As String = addSlashes(MENote.Text.ToString)
        Dim memo_number As String = addSlashes(TxtMemoNo.Text)

        Dim query As String = "INSERT INTO tb_ar_eval_release(id_ar_eval_pps, id_comp_group, created_date, created_by, memo_number, note, id_report_status)
        VALUES('" + id_ar_eval_pps + "', '" + id_comp_group + "', NOW(), '" + id_user + "', '" + memo_number + "', '" + note + "', '1'); SELECT LAST_INSERT_ID();"
        id = execute_query(query, 0, True, "", "", "", "")

        action = "upd"
        actionLoad()
        infoCustom("Please attach file & Release")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If id_report_status = "5" Or id_report_status = "6" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class