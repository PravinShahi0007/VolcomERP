Public Class FormMailManageLog
    Public id As String = "-1"

    Private Sub FormMailManageLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT m.id_mail_manage, m.number,l.log_date, l.id_user, e.employee_name, l.id_mail_status, stt.mail_status, l.note
        FROM tb_mail_manage_log l
        INNER JOIN tb_mail_manage m ON m.id_mail_manage = l.id_mail_manage
        INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = l.id_mail_status
        INNER JOIN tb_m_user u ON u.id_user = l.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE l.id_mail_manage=" + id + "
        ORDER BY l.log_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        TxtEmailNo.Text = data.Rows(0)("number").ToString
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMailManageLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class