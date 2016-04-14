Public Class FormMarkAssignUserSingle
    Public id_mark_asg As String = "-1"
    Private Sub FormMarkAssignUserSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_user()
    End Sub

    Sub view_user()
        Dim query As String = "SELECT * FROM tb_m_user a "
        query += "INNER JOIN tb_m_employee b ON a.id_employee = b.id_employee  "
        query += "INNER JOIN tb_m_departement c ON b.id_departement = c.id_departement  "
        query += "INNER JOIN tb_m_role d ON a.id_role = d.id_role "
        query += "INNER JOIN tb_lookup_answer e ON a.is_change = e.id_answer "
        query += "ORDER BY employee_name ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
        If data.Rows.Count > 0 Then
            GVUser.FocusedRowHandle = 0
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim time_fix As String = ""
        time_fix = TEHour.Text & ":" & TEMin.Text & ":" & TESec.Text
        If GVUser.RowCount > 0 Then
            Try
                Dim query As String = String.Format("INSERT tb_mark_asg_user(id_mark_asg,id_user,level,lead_time) VALUES('{0}','{1}',((SELECT COUNT(a.id_mark_asg_user) FROM tb_mark_asg_user a WHERE a.id_mark_asg='{0}')+1),'{2}')", id_mark_asg, GVUser.GetFocusedRowCellDisplayText("id_user").ToString, time_fix)
                execute_non_query(query, True, "", "", "", "")
                FormMarkAssignUser.view_user()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            stopCustom("No user selected")
        End If
    End Sub

    Private Sub FormMarkAssignUserSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class