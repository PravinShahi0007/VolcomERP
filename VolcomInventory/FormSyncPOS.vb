Public Class FormSyncPOS
    Private Sub FormSyncPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_user()
    End Sub

    Private Sub FormSyncPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSyncMaster_Click(sender As Object, e As EventArgs) Handles SBSyncMaster.Click
        Dim c As ClassApiPos = New ClassApiPos

        c.syncMaster()
    End Sub

    Private Sub SBSyncUser_Click(sender As Object, e As EventArgs) Handles SBSyncUser.Click
        Dim c As ClassApiPos = New ClassApiPos

        c.syncEmployeeUser()
    End Sub

    Private Sub SBRole_Click(sender As Object, e As EventArgs) Handles SBRole.Click
        FormSyncPOSRole.ShowDialog()
    End Sub

    Sub load_user()
        Dim query_user As String = "
            SELECT u.id_pos_user, u.username, e.employee_name, d.departement, r.role
            FROM tb_pos_user AS u
            LEFT JOIN tb_pos_role AS r ON u.id_pos_role = r.id_pos_role
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            ORDER BY u.username
        "

        Dim data_user As DataTable = execute_query(query_user, -1, True, "", "", "", "")

        GCUser.DataSource = data_user

        GVUser.BestFitColumns()
    End Sub
End Class