Public Class FormAREvalNoteAdd
    Public id_ar_eval_note_store As String = "-1"
    Public id_ar_eval_note_det As String = "-1"
    Public id_comp_group As String = "-1"
    Public action As String = "-1"

    Private Sub FormAREvalNoteAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        actionLoad()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        SLEStoreGroup.EditValue = id_comp_group
        SLEStoreGroup.Enabled = False
        If action = "ins" Then
            MENote.Text = ""
            MENote.Focus()
            BtnSave.Text = "Add Note"
        Else
            Dim query As String = "SELECT nd.note FROM tb_ar_eval_note_det nd
            WHERE nd.id_ar_eval_note_det=" + id_ar_eval_note_det + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            MENote.Text = data.Rows(0)("note").ToString
            BtnSave.Text = "Save changes"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormAREvalNoteAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim note As String = addSlashes(MENote.Text)
        If note = "" Then
            warningCustom("Please input all data")
        Else
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_ar_eval_note_det(id_ar_eval_note_store, note) 
                VALUES(" + id_ar_eval_note_store + ",'" + note + "'); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
                FormAREvalNote.viewDetail()
                FormAREvalNote.GVData.FocusedRowHandle = find_row(FormAREvalNote.GVData, "id_ar_eval_note_det", id_new)
                actionLoad()
            Else
                Dim query As String = "UPDATE tb_ar_eval_note_det SET note='" + note + "' WHERE id_ar_eval_note_det='" + id_ar_eval_note_det + "' "
                execute_non_query(query, True, "", "", "", "")
                FormAREvalNote.viewDetail()
                FormAREvalNote.GVData.FocusedRowHandle = find_row(FormAREvalNote.GVData, "id_ar_eval_note_det", id_ar_eval_note_det)
                Close()
            End If
        End If
    End Sub
End Class