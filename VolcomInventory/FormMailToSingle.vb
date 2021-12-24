Public Class FormMailToSingle
    Public id_rmt As String = "-1"

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Close()
    End Sub

    Private Sub FormMailToSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

    End Sub

    Private Sub FormMailToSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee()
        viewType()
        viewRMT
    End Sub

    Private Sub CEExternal_EditValueChanged(sender As Object, e As EventArgs) Handles CEExternal.EditValueChanged
        If CEExternal.EditValue = True Then
            SLEEmployee.Enabled = False
            SLEEmployee.EditValue = Nothing
        Else
            SLEEmployee.Enabled = True
            SLEEmployee.EditValue = Nothing
        End If
    End Sub

    Sub viewEmployee()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT u.id_user, e.employee_name, e.email_external 
        FROM tb_m_user u
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE e.id_employee_active=1 AND !ISNULL(e.email_external) AND e.email_external<>''
        ORDER BY e.employee_name ASC "
        viewSearchLookupQuery(SLEEmployee, query, "id_user", "employee_name", "id_user")
        SLEEmployee.EditValue = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmployee.EditValueChanged
        If CEExternal.EditValue = False Then
            Dim name As String = ""
            Dim email As String = ""
            Try
                name = SLEEmployee.Properties.View.GetFocusedRowCellValue("employee_name").ToString
                email = SLEEmployee.Properties.View.GetFocusedRowCellValue("email_external").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_type`,  'To' AS `type`
        UNION ALL 
        SELECT '2' AS `id_type`,  'CC' AS `type` "
        viewSearchLookupQuery(SLEType, query, "id_type", "type", "id_type")
        Cursor = Cursors.Default
    End Sub

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
End Class