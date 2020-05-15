Public Class FormOlStoreReturnInputAWB
    Private Sub FormOlStoreReturnInputAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRequest()
    End Sub

    Private Sub FormOlStoreReturnInputAWB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewRequest()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassRequestRetOLStore()
        Dim query As String = r.queryMain(" AND r.id_report_status = 6", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRequest.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub SBInputAWB_Click(sender As Object, e As EventArgs) Handles SBInputAWB.Click
        'validating
        Dim msg As String = ""

        If TEInputAWB.Text = "" Then
            msg = "AWB number can't blank."
        End If

        If Not GVRequest.GetFocusedRowCellValue("awb_number").ToString = "" Then
            msg = "AWB number already input."
        End If

        'input awb
        If msg = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to input AWB ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                execute_non_query("UPDATE tb_ol_store_ret_req SET awb_number = '" + addSlashes(TEInputAWB.EditValue.ToString) + "' WHERE id_ol_store_ret_req = '" + GVRequest.GetFocusedRowCellValue("id_ol_store_ret_req").ToString + "'", True, "", "", "", "")

                TEInputAWB.EditValue = ""

                infoCustom("AWB number saved.")
            End If
        Else
            errorCustom(msg)
        End If

        viewRequest()
    End Sub
End Class