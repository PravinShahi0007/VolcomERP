Public Class FormAREvalNoteBulk
    Public id_ar_eval_note As String = "-1"
    Private Sub FormAREvalNoteBulk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ns.id_ar_eval_note_store, cg.description AS `store_group`, 'No' AS `is_select`
        FROM tb_ar_eval_note_store ns
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = ns.id_comp_group
        WHERE ns.id_ar_eval_note=" + id_ar_eval_note + " AND ns.overdue_inv>0
        GROUP BY ns.id_ar_eval_note_store ORDER BY cg.description ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        viewStore()
        MENote.Text = ""
    End Sub

    Private Sub FormAREvalNoteBulk_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVData.ActiveFilterString = "[is_select]='Yes' "
        Dim cond_store As Boolean = True
        If GVData.RowCount <= 0 Then
            cond_store = False
        End If
        GVData.ActiveFilterString = ""

        If MENote.Text = "" Or Not cond_store Then
            warningCustom("Please input all data")
        Else
            GVData.ActiveFilterString = "[is_select]='Yes' "
            Dim note As String = MENote.Text
            Dim query As String = "INSERT INTO tb_ar_eval_note_det(id_ar_eval_note_store, note) VALUES "
            For i As Integer = 0 To GVData.RowCount - 1
                If i > 0 Then
                    query += ","
                End If
                query += "('" + GVData.GetRowCellValue(i, "id_ar_eval_note_store").ToString + "', '" + note + "') "
            Next
            If GVData.RowCount > 0 Then
                execute_non_query(query, True, "", "", "", "")
            End If
            GVData.ActiveFilterString = ""
            FormAREvalNote.viewDetail()
            actionLoad()
        End If
    End Sub
End Class