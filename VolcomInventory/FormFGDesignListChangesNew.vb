Public Class FormFGDesignListChangesNew
    Public is_md As String = "1"
    Private Sub FormFGDesignListChangesNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormFGDesignListChangesNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        If MENote.Text = "" Then
            stopCustom("All field are required")
        Else
            Dim query As String = "INSERT INTO tb_m_design_changes(created_date, note, id_report_status,is_md)
            VALUES(NOW(),'" + addSlashes(MENote.Text.ToString) + "',1, '" + is_md + "'); SELECT LAST_INSERT_ID(); "
            Dim id As String = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id + ", 200);", True, "", "", "", "")

            'open detil
            FormFGDesignListChanges.id = id
            FormFGDesignListChanges.ShowDialog()

            'refresh
            FormFGDesignList.viewPropose()
            FormFGDesignList.GVPropose.FocusedRowHandle = find_row(FormFGDesignList.GVPropose, "id_changes", id)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class