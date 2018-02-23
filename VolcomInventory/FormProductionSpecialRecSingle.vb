Public Class FormProductionSpecialRecSingle
    Public id_pop_up As String = "-1"
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormProductionSpecialRecSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BOpenLock_Click(sender As Object, e As EventArgs) Handles BOpenLock.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to disable receving tolerance for this PO ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            If Not TEMemoNumber.Text = "" Then

                'attach
                uploadDoc()

                'check document
                Dim qry_c As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=114 AND d.id_report='" + FormProdClosing.GVProd.GetFocusedRowCellValue("id_prod_order").ToString + "' "
                Dim dt_c As DataTable = execute_query(qry_c, -1, True, "", "", "", "")
                If dt_c.Rows.Count > 0 Then
                    Dim id_prod_order As String = ""
                    If id_pop_up = "1" Then
                        id_prod_order = FormProdClosing.GVProd.GetFocusedRowCellValue("id_prod_order").ToString()
                    Else
                        id_prod_order = FormProductionSpecialRec.GVProd.GetFocusedRowCellValue("id_prod_order").ToString()
                    End If
                    Dim query As String = "UPDATE tb_prod_order SET is_special_rec='1',special_rec_memo='" & addSlashes(TEMemoNumber.Text) & "',special_rec_datetime=NOW() WHERE id_prod_order='" & id_prod_order & "'"
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Receving tolerance disabled")

                    If id_pop_up = "1" Then
                        FormProdClosing.view_production_order()
                        FormProdClosing.GVProd.FocusedRowHandle = find_row(FormProdClosing.GVProd, "id_prod_order", id_prod_order)
                    Else
                        FormProductionSpecialRec.view_production_order()
                        FormProductionSpecialRec.GVProd.FocusedRowHandle = find_row(FormProductionSpecialRec.GVProd, "id_prod_order", id_prod_order)
                    End If
                    Close()
                Else
                    stopCustom("Data can't be saved, please upload attachment !")
                End If
            Else
                stopCustom("Number can't blank")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        uploadDoc()
    End Sub

    Sub uploadDoc()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = FormProdClosing.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        FormDocumentUpload.report_mark_type = "114"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class