Public Class FormFGDistSchemaSetupAllocDet 
    Public action As String = "-1"
    Public id_pd_alloc As String = "-1"

    Private Sub FormFGDistSchemaSetupAllocDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewAnswer()
        Dim query As String = "SELECT * FROM tb_lookup_answer ORDER BY id_answer ASC "
        viewLookupQuery(LEAnswer, query, 0, "answer", "id_answer")
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub TxtAllocation_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAllocation.Validating
        EP_TE_cant_blank(EPForm, TxtAllocation)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPForm) Then
            errorInput()
        Else
            Dim pd_alloc As String = TxtAllocation.Text.ToString
            Dim is_include_so As String = LEAnswer.EditValue.ToString
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_lookup_pd_alloc(pd_alloc, is_include_so) "
                    query += "VALUES('" + pd_alloc + "', '" + is_include_so + "') "
                    execute_non_query(query, True, "", "", "", "")
                    FormFGDistSchemaSetup.viewPDAlloc()
                    FormFGDistSchemaSetup.GVAlloc.FocusedRowHandle = find_row(FormFGDistSchemaSetup.GVAlloc, "id_pd_alloc", id_pd_alloc)
                    Close()
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_lookup_pd_alloc SET pd_alloc = '" + pd_alloc + "', is_include_so = '" + is_include_so + "' WHERE id_pd_alloc='" + id_pd_alloc + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormFGDistSchemaSetup.viewPDAlloc()
                    FormFGDistSchemaSetup.GVAlloc.FocusedRowHandle = find_row(FormFGDistSchemaSetup.GVAlloc, "id_pd_alloc", id_pd_alloc)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub FormFGDistSchemaSetupAllocDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewAnswer()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_lookup_pd_alloc WHERE id_pd_alloc = '" + id_pd_alloc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtAllocation.Text = data.Rows(0)("pd_alloc").ToString
            LEAnswer.ItemIndex = LEAnswer.Properties.GetDataSourceRowIndex("id_answer", data.Rows(0)("is_include_so").ToString)
        End If
    End Sub
End Class