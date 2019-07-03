Public Class FormSalesReturnSelectRetType

    Private Sub FormSalesReturnSelectRetType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        query = "SELECT * FROM tb_lookup_ret_type a WHERE a.id_ret_type=1 OR a.id_ret_type=3 ORDER BY a.id_ret_type ASC "
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