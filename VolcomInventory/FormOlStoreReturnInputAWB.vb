Public Class FormOlStoreReturnInputAWB
    Private Sub FormOlStoreReturnInputAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRequest()
    End Sub

    Private Sub FormOlStoreReturnInputAWB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewRequest()
        Cursor = Cursors.WaitCursor
        'check in
        Dim w_in As String = "0, "
        For i = 0 To FormWHAWBillIn.GVDO.RowCount - 1
            w_in += If(FormWHAWBillIn.GVDO.GetRowCellValue(i, "id_ol_store_ret_req").ToString = "", "0", FormWHAWBillIn.GVDO.GetRowCellValue(i, "id_ol_store_ret_req").ToString) + ", "
        Next

        Dim r As New ClassRequestRetOLStore()
        Dim query As String = r.queryMain(" AND r.id_report_status = 6 AND r.id_ol_store_ret_req NOT IN (" + w_in.Substring(0, w_in.Length - 2) + ") AND r.id_ol_store_ret_req NOT IN (SELECT IFNULL(id_ol_store_ret_req, 0) AS id_ol_store_ret_req FROM tb_wh_awbill_det_in) ", "2")
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

    Private Sub GVRequest_DoubleClick(sender As Object, e As EventArgs) Handles GVRequest.DoubleClick
        Dim newRow As DataRow = (TryCast(FormWHAWBillIn.GCDO.DataSource, DataTable)).NewRow()
        newRow("id_wh_awb_det") = "0"
        newRow("do_no") = GVRequest.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
        newRow("qty") = GVRequest.GetFocusedRowCellValue("qty_fisik")
        newRow("act_qty") = GVRequest.GetFocusedRowCellValue("qty_fisik")
        newRow("id_ol_store_ret_req") = GVRequest.GetFocusedRowCellValue("id_ol_store_ret_req")
        TryCast(FormWHAWBillIn.GCDO.DataSource, DataTable).Rows.Add(newRow)
        FormWHAWBillIn.GCDO.RefreshDataSource()
        FormWHAWBillIn.GVDO.RefreshData()

        Close()
    End Sub
End Class