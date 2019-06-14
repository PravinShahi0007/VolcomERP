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

        If LookUpEdit1.EditValue.ToString = "5" Then
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
            If data.Rows.Count > 0 Then
                'create non list return
                Dim id_store_cc As String = data.Rows(0)("id_store_contact_to").ToString
                Dim id_comp As String = get_setup_field("wh_temp")
                Dim qcomp As String = "SELECT c.id_comp, c.id_drawer_def, cc.id_comp_contact, c.is_use_unique_code
                FROM tb_m_comp c 
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp 
                WHERE c.id_comp=" + id_comp + " AND cc.is_default=1 "
                Dim dcomp As DataTable = execute_query(qcomp, -1, True, "", "", "", "")
                Dim id_comp_cc As String = dcomp.Rows(0)("id_comp_contact").ToString
                Dim id_drawer As String = dcomp.Rows(0)("id_drawer_def").ToString
                Dim is_use_unique_code As String = dcomp.Rows(0)("is_use_unique_code").ToString
                Dim sales_return_number As String = header_number_sales("5")
                Dim query_main As String = "INSERT tb_sales_return(id_store_contact_from, id_comp_contact_to, id_sales_return_order, sales_return_number, sales_return_store_number, sales_return_date, sales_return_note,id_wh_drawer ,id_report_status, last_update, last_update_by, id_ret_type, is_use_unique_code) "
                query_main += "VALUES('" + id_store_cc + "', '" + id_comp_cc + "', '" + id_ror + "', '" + sales_return_number + "', '', NOW(), '','" + id_drawer + "', '1', NOW(), " + id_user + ",'5', '" + is_use_unique_code + "');SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query_main, 0, True, "", "", "", "")

                'submit_who_prepared("198", id, id_user)
                Close()
                FormSalesReturnNonListDet.id = "1"
                FormSalesReturnNonListDet.ShowDialog()
            Else
                Cursor = Cursors.Default
                stopCustom("Please complete the regular process first")
                Exit Sub
            End If
        Else
            FormSalesReturnDet.id_sales_return_order = FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            FormSalesReturnDet.action = "ins"
            FormSalesReturnDet.id_ret_type = LookUpEdit1.EditValue.ToString
            FormSalesReturnDet.TxtReturnType.Text = LookUpEdit1.Text.ToString
            FormSalesReturnDet.ShowDialog()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        chooses()
    End Sub
End Class