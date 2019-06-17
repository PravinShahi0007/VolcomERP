Public Class FormSalesReturnDetNew
    Public allow As Boolean = True

    Private Sub FormSalesReturnDetNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        'jika return ol store
        If FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_order") <> "0" Then
            query = "SELECT * FROM tb_lookup_ret_type a WHERE a.id_ret_type=4 ORDER BY a.id_ret_type ASC "
        Else
            query = "SELECT * FROM tb_lookup_ret_type a WHERE a.id_ret_type<>4 ORDER BY a.id_ret_type ASC "
        End If

        viewLookupQuery(LookUpEdit1, query, 0, "ret_type", "id_ret_type")



        ActiveControl = LookUpEdit1
    End Sub

    Private Sub FormSalesReturnDetNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub chooses()
        Cursor = Cursors.WaitCursor

        If LookUpEdit1.EditValue.ToString = "2" Then
            FormMenuAuth.type = "1"
            FormMenuAuth.ShowDialog()
            If Not allow Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim is_non_list As String = "-1"
        If CENonList.EditValue = True Then
            is_non_list = "1"

            'cek limit qty
            Dim id_ror As String = FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            Dim query As String = "SELECT ro.id_store_contact_to,rod.id_sales_return_order_det, rod.sales_return_order_det_qty, r.qty, (rod.sales_return_order_det_qty-IFNULL(r.qty,0)) AS `limit_qty`
            FROM tb_sales_return_order_det rod
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order
            LEFT JOIN(
	            SELECT rd.id_sales_return_order_det, SUM(rd.sales_return_det_qty) AS `qty` 
	            FROM tb_sales_return_det rd
	            INNER JOIN tb_sales_return r ON r.id_sales_return = rd.id_sales_return
	            WHERE r.id_sales_return_order=" + id_ror + " AND r.id_report_status!=5
	            GROUP BY rd.id_sales_return_order_det
            ) r ON r.id_sales_return_order_det = rod.id_sales_return_order_det
            WHERE rod.id_sales_return_order=" + id_ror + "
            HAVING limit_qty<=0 "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                stopCustom("Please complete the return on list first")
                Exit Sub
            End If
        Else
            is_non_list = "2"
        End If

        FormSalesReturnDet.id_sales_return_order = FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
        FormSalesReturnDet.action = "ins"
        FormSalesReturnDet.id_ret_type = LookUpEdit1.EditValue.ToString
        FormSalesReturnDet.is_non_list = is_non_list
        FormSalesReturnDet.TxtReturnType.Text = LookUpEdit1.Text.ToString
        FormSalesReturnDet.ShowDialog()
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        chooses()
    End Sub

    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit1.EditValueChanged
        Dim typ As String = "0"
        Try
            typ = LookUpEdit1.EditValue.ToString
        Catch ex As Exception
        End Try
        If typ = "1" Or typ = "3" Then
            CENonList.Enabled = True
            CENonList.EditValue = False
        Else
            CENonList.EditValue = False
            CENonList.Enabled = False
        End If
    End Sub
End Class