Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_vendor_contact As String = ""
    '
    Public is_pick As String = "2"
    '
    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_term()
        load_det()

        If id_po = "-1" Then 'new
            TEPONumber.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            TEReqBy.Text = get_user_identify(id_user, "1")
            '
            If is_pick = "1" Then
                Console.WriteLine("1")
                For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                    Console.WriteLine(i.ToString)
                    Dim newRow As DataRow = (TryCast(GCPurcReq.DataSource, DataTable)).NewRow()
                    newRow("departement") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "departement").ToString
                    newRow("id_purc_req_det") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "id_purc_req_det").ToString
                    newRow("purc_req_number") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "purc_req_number").ToString
                    newRow("date_created") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "date_created").ToString
                    newRow("item_desc") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "item_desc").ToString
                    newRow("qty_req") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "qty_req").ToString
                    newRow("val_req") = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "val_req").ToString

                    TryCast(GCPurcReq.DataSource, DataTable).Rows.Add(newRow)
                Next
            End If
        Else 'edit

        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`
                                ,itm.`item_desc`,pod.`qty` AS qty_req,pod.`value` AS val_req 
                                ,dep.`departement`
                                ,req.`date_created`
                                ,req.`purc_req_number`
                                ,0.00 AS qty_po
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_item itm ON itm.`id_item`=pod.`id_item`
                                INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                WHERE pod.id_purc_order='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
    End Sub

    Sub load_term()
        Dim query As String = "SELECT id_payment_purchasing,payment_purchasing FROM `tb_lookup_payment_purchasing` WHERE is_active='1'"
        viewLookupQuery(LEPaymentTerm, query, "id_payment_purchasing", "payment_purchasing", "id_payment_purchasing")
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