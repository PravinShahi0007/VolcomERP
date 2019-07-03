Public Class FormSalesReturnSelectRetType

    Private Sub FormSalesReturnSelectRetType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cek tipe return
        Dim query As String = ""
        Dim qgt As String = "SELECT s.id_ret_type 
        FROM tb_sales_return s 
        WHERE s.id_store_contact_from=" + FormSalesReturnDet.id_store_contact_from + " AND TRIM(s.sales_return_store_number)='" + addSlashes(FormSalesReturnDet.TxtStoreReturnNumber.Text) + "' AND s.id_ret_type!=2
        GROUP BY s.id_ret_type "
        Dim dgt As DataTable = execute_query(qgt, -1, True, "", "", "", "")
        If dgt.Rows.Count > 0 Then
            query = "SELECT * FROM tb_lookup_ret_type a WHERE a.id_ret_type=" + dgt.Rows(0)("id_ret_type").ToString + " ORDER BY a.id_ret_type ASC "
        Else
            query = "SELECT * FROM tb_lookup_ret_type a WHERE a.id_ret_type=1 OR a.id_ret_type=3 ORDER BY a.id_ret_type ASC "
        End If
        viewLookupQuery(LookUpEdit1, query, 0, "ret_type", "id_ret_type")
        ActiveControl = LookUpEdit1
    End Sub

    Private Sub FormSalesReturnSelectRetType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormSalesReturnDet.id_ret_type = LookUpEdit1.EditValue.ToString
        Close()
    End Sub
End Class