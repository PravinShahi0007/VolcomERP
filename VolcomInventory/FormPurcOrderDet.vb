Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_vendor_contact As String = ""
    '
    Public is_pick As String = "2"
    '
    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_term()

        If id_po = "-1" Then 'new
            TEPONumber.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            TEReqBy.Text = get_user_identify(id_user, "1")
            '
            If is_pick = "1" Then
                For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                    GVPurcReq.AddNewRow()
                    GVPurcReq.SetFocusedRowCellValue("id_purc_req_det", FormPurcOrder.GVPurcReq.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                    GVPurcReq.SetFocusedRowCellValue("id_item", FormPurcOrder.GVPurcReq.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                    GVPurcReq.CloseEditor()
                    GCPurcReq.RefreshDataSource()
                    GVPurcReq.RefreshData()
                Next
            End If
        Else 'edit

        End If
    End Sub

    Sub load_term()
        Dim query As String = "SELECT id_payment_term_purc,payment_term_purc FROM tb_lookup_payment_term_purc"
        viewLookupQuery(LEPaymentTerm, query, "id_payment_term_purc", "payment_term_purc", "id_payment_term_purc")
    End Sub

    Private Sub FormPurcOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BPickVendor_Click(sender As Object, e As EventArgs) Handles BPickVendor.Click
        FormPopUpContact.id_pop_up = "86"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

    End Sub
End Class