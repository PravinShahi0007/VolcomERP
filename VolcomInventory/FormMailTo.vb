Public Class FormMailTo
    Public id_rmt As String = "-1"

    Sub viewRmt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT rmt.report_mark_type, rmt.report_mark_type_name
        FROM tb_lookup_report_mark_type
        where 1=1 "
        If id_rmt <> "-1" Then
            query += "AND rmt.report_mark_type='" + id_rmt + "' "
        End If
        query += "GROUP BY m.report_mark_type "
        viewSearchLookupQuery(SLERMT, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMailTo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRmt()
    End Sub

    Private Sub FormMailTo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim rmt As String = SLERMT.EditValue.ToString
        Dim query As String = "SELECT m.id_mail, e.employee_name AS `recipient_name`, e.email_external AS `email`, IF(m.is_to=1,'To', 'CC') AS `type`
        FROM tb_mail_to m
        INNER JOIN tb_m_user us ON us.id_user = m.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = us.id_employee
        WHERE m.report_mark_type=" + rmt + " AND m.id_user>0
        UNION ALL
        SELECT m.id_mail, SUBSTRING_INDEX(m.external_recipient, ";", 1), SUBSTRING_INDEX(m.external_recipient, ";", -1) AS `email`, IF(m.is_to=1,'To', 'CC') AS `type`
        FROM tb_mail_to m
        WHERE m.report_mark_type="+rmt+" AND m.id_user=0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLERMT_EditValueChanged(sender As Object, e As EventArgs) Handles SLERMT.EditValueChanged
        viewList()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_mail As String = GVData.GetFocusedRowCellValue("id_mail").ToString
                Dim query As String = "DELETE FROM tb_mail_to WHERE id_mail='" + id_mail + "' "
                execute_non_query(query, True, "", "", "", "")
                viewList()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub
End Class