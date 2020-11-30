Public Class FormOLStoreOOSDetail
    Public id As String = "-1"
    Public id_type As String = "-1"
    Dim is_sent_email As String = "-1"
    Dim id_comp_group As String = "-1"
    Dim id_order As String = "-1"


    Private Sub FormOLStoreOOSDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim oos As New ClassOLStore()
        Dim data As DataTable = oos.viewListOOS("", "AND os.id_ol_store_oos='" + id + "' ")
        TxtOOSNo.Text = data.Rows(0)("number").ToString
        TxtMarketplaceName.Text = data.Rows(0)("comp_group").ToString
        TxtOrderNo.Text = data.Rows(0)("order_number").ToString
        TxtCustomer.Text = data.Rows(0)("customer_name").ToString
        is_sent_email = data.Rows(0)("is_sent_email").ToString
        id_comp_group = data.Rows(0)("id_comp_group").ToString
        id_order = data.Rows(0)("id_order").ToString
        allowStatus()
        viewProductList()
        viewRestockList()
        Cursor = Cursors.Default
    End Sub

    Sub viewProductList()

    End Sub

    Sub viewRestockList()

    End Sub

    Sub allowStatus()
        'show button email
        If is_sent_email = "2" And id_type = "2" Then
            BtnSendEmail.Visible = True
        End If
        'show button close order
        If is_sent_email = "1" And id_type = "3" Then
            BtnSendEmail.Visible = True
        End If
    End Sub

    Sub viewSyncInfo()

    End Sub

    Private Sub FormOLStoreOOSDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSendEmail_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreOOSManualEmail.id_order = id_order
        FormOLStoreOOSManualEmail.id_comp_group = id_comp_group
        FormOLStoreOOSManualEmail.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreLog.id_order = id_order
        FormOLStoreLog.id_comp_group = id_comp_group
        FormOLStoreLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class