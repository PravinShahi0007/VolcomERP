Public Class FormDelayPaymentNew
    Private Sub FormDelayPaymentNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        DEDueDate.EditValue = getTimeDB()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg WHERE cg.id_comp_group>1 "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDelayPaymentNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        If MENote.Text = "" Then
            stopCustom("All field are required")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new this memo ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim query As String = "INSERT INTO tb_propose_delay_payment(id_comp_group, number, created_date, created_by, updated_date, updated_by, due_date, note, id_report_status)
                VALUES('" + SLEStoreGroup.EditValue.ToString + "', '', NOW(), '" + id_user + "', NOW(), '" + id_user + "', '" + due_date + "', '" + addSlashes(MENote.Text) + "', 1); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", 233);", True, "", "", "", "")

                'open detil
                FormDelayPaymentDet.id = id
                FormDelayPaymentDet.ShowDialog()

                'refresh
                FormDelayPayment.SLEStoreGroup.EditValue = SLEStoreGroup.EditValue.ToString
                FormDelayPayment.viewData()
                FormDelayPayment.GVData.FocusedRowHandle = find_row(FormDelayPayment.GVData, "id_propose_delay_payment", id)
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class