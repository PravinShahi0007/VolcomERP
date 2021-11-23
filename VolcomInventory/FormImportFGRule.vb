Public Class FormImportFGRule

    Private Sub FormImportFGRule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SetNonActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetNonActiveToolStripMenuItem.Click
        If GVRule.RowCount > 0 Then
            Dim q As String = "DELETE FROM tb_import_rule WHERE id_import='" & addSlashes(TERuleName.Text) & "'"
            execute_non_query(q, True, "", "", "", "")
            refresh_rule()
        End If
    End Sub

    Private Sub BAddRule_Click(sender As Object, e As EventArgs) Handles BAddRule.Click
        If Not TERuleName.Text = "" Then
            Dim q As String = "INSERT INTO tb_import_rule(import_rule,is_active) VALUES('" & addSlashes(TERuleName.Text) & "','1')"
            execute_non_query(q, True, "", "", "", "")
            '
            refresh_rule()
        End If
    End Sub

    Sub refresh_rule()
        Dim q As String = "SELECT import_rule,IF(is_active=1,'Active','Not Active') AS active_sts FROM tb_import_rule ORDER BY id_import_rule DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCRule.DataSource = dt
        If GVRule.RowCount > 0 Then
            refresh_vendor()
            refresh_det()
        End If
    End Sub

    Sub refresh_vendor()

    End Sub

    Sub refresh_det()

    End Sub

End Class