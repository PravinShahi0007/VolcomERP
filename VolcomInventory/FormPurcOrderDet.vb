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
            DEEstReceiveDate.EditValue = Now
            '
            Try
                If is_pick = "1" Then
                    For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCPurcReq.DataSource, DataTable)).NewRow()
                        newRow("id_item") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_item").ToString
                        newRow("departement") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "departement").ToString
                        newRow("id_purc_req_det") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString
                        newRow("purc_req_number") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "purc_req_number").ToString
                        newRow("pr_created") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "pr_created")
                        newRow("item_desc") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                        newRow("uom") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "uom")
                        newRow("qty_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_pr")
                        newRow("val_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "val_pr")
                        newRow("qty_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_po")
                        TryCast(GCPurcReq.DataSource, DataTable).Rows.Add(newRow)
                    Next
                End If
                'create summary
                load_summary()
            Catch ex As Exception
                infoCustom(ex.ToString)
            End Try
        Else 'edit

        End If
    End Sub

    Sub load_summary()
        'delete all row
        For j As Integer = GVSummary.RowCount - 1 To 0 Step -1
            GVSummary.DeleteRow(j)
        Next
        'add
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            Dim is_found As Boolean = False
            For k As Integer = 0 To GVSummary.RowCount - 1
                If GVSummary.GetRowCellValue(k, "id_item").ToString = GVPurcReq.GetRowCellValue(i, "id_item").ToString Then
                    is_found = True
                    'add qty
                    GVSummary.SetRowCellValue(k, "qty_po", (GVSummary.GetRowCellValue(k, "qty_po") + GVPurcReq.GetRowCellValue(i, "qty_po")))
                End If
            Next
            If is_found = False Then 'add new row
                Dim newRow As DataRow = (TryCast(GCSummary.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVPurcReq.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                newRow("uom") = GVPurcReq.GetRowCellValue(i, "uom")
                newRow("qty_po") = GVPurcReq.GetRowCellValue(i, "qty_po")
                TryCast(GCSummary.DataSource, DataTable).Rows.Add(newRow)
            End If
        Next
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`
                                ,itm.`item_desc`,pod.`qty` AS qty_pr,pod.`value` AS val_pr
                                ,dep.`departement`
                                ,req.`date_created` as pr_created
                                ,req.`purc_req_number`
                                ,0.00 AS qty_po
                                ,0.0 AS val_po
                                ,uom.uom
                                ,itm.id_item
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_item itm ON itm.`id_item`=pod.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
                                INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                WHERE pod.id_purc_order='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
        'summary_query
        Dim query_sum As String = "SELECT '' AS id_item,'' AS item_desc,0.00 AS qty_po,'' AS uom,0.00 AS val_po,0.00 as discount_percent,0.00 as discount,0.00 as sub_total"
        Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
        GCSummary.DataSource = data_sum
    End Sub

    Sub load_term()
        Dim query As String = "SELECT id_payment_purchasing,payment_purchasing FROM `tb_lookup_payment_purchasing` WHERE is_active='1'"
        viewLookupQuery(LEPaymentTerm, query, 0, "payment_purchasing", "id_payment_purchasing")
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

    Private Sub GVSummary_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSummary.CellValueChanged
        If e.Column.FieldName.ToString = "val_po" Then
            GVSummary.GetFocusedRowCellValue("id_item")
        End If
    End Sub
End Class