Public Class FormSetupDBStockTake
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        GVData.DeleteSelectedRows()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To GVData.RowCount - 1
            Dim db As String = ""
            db = GVData.GetRowCellValue(i, "Database").ToString
            Try
                Dim qry1 As String = "ALTER TABLE `tb_st_user`
	ADD COLUMN `role` TINYINT NULL DEFAULT '1' AFTER `st_user_code`; "
                execute_non_query(qry1, False, TxtHost.Text, TxtUsername.Text, TxtPass.Text, db)
            Catch ex As Exception
                Console.WriteLine("User " + db.ToString + System.Environment.NewLine + ex.ToString)
            End Try
            Try
                Dim qry2 As String = "ALTER TABLE `tb_st_trans`
            ADD COLUMN `is_pre` TINYINT UNSIGNED NULL DEFAULT '2' AFTER `approved_by`;"
                execute_non_query(qry2, False, TxtHost.Text, TxtUsername.Text, TxtPass.Text, db)
            Catch ex As Exception
                Console.WriteLine("Trans " + db.ToString + System.Environment.NewLine + ex.ToString)
            End Try
        Next
        Cursor = Cursors.Default
        infoCustom("end")
    End Sub

    Private Sub FormSetupDBStockTake_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim data As DataTable = execute_query("SHOW DATABASES;", -1, False, TxtHost.Text, TxtUsername.Text, TxtPass.Text, "db_opt")
        GCData.DataSource = data
    End Sub
End Class