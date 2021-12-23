Public Class FormProposePriceMKDMail
    Public id_comp_group As String = "-1"

    Private Sub FormProposePriceMKDMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkMail()
        listMailStore()
        listInternal()
    End Sub

    Private Sub FormProposePriceMKDMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub checkMail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description, COUNT(mtg.id_comp_group) AS `jum`
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_mail_to_group mtg ON mtg.id_comp_group = cg.id_comp_group AND mtg.report_mark_type IN (373)
        WHERE c.id_comp_cat=6 AND c.is_active=1 AND c.id_store_type=1 AND c.id_commerce_type=1 AND c.id_comp_group!=59 "
        If id_comp_group <> "-1" Then
            query += "AND c.id_comp_group='" + id_comp_group + "' "
        End If
        query += "GROUP BY c.id_comp_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCheck.DataSource = data
        GVCheck.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub listMailStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT mtg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`,  IF(mtg.is_to=1,'To', 'CC') AS `type`,mtg.email, mtg.`name`
        FROM tb_mail_to_group mtg
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = mtg.id_comp_group
        WHERE mtg.report_mark_type=373 "
        If id_comp_group <> "-1" Then
            query += "AND mtg.id_comp_group='" + id_comp_group + "' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStoreEmail.DataSource = data
        GVStoreEmail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub listInternal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT IF(mtg.is_to=1,'To', 'CC') AS `type`,e.email_external AS `email`, e.employee_name AS `name`
        FROM tb_mail_to mtg
        LEFT JOIN tb_m_user u ON u.id_user = mtg.id_user
        LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE mtg.report_mark_type=373 AND !ISNULL(u.id_user)
        UNION ALL
        SELECT IF(mtg.is_to=1,'To', 'CC') AS `type`,SUBSTRING_INDEX(mtg.external_recipient, ';', -1) AS `email`, SUBSTRING_INDEX(mtg.external_recipient, ';', 1) AS `name`
        FROM tb_mail_to mtg
        WHERE mtg.report_mark_type=373 AND mtg.id_user=0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInternalEmail.DataSource = data
        GVInternalEmail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSetupMailStore.Click
        Cursor = Cursors.WaitCursor
        FormCompGroupEmail.rmt = "373"
        FormCompGroupEmail.ShowDialog()
        listMailStore()
        checkMail()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSetupMailInternal_Click(sender As Object, e As EventArgs) Handles BtnSetupMailInternal.Click
        Cursor = Cursors.WaitCursor
        listInternal()
        Cursor = Cursors.Default
    End Sub
End Class