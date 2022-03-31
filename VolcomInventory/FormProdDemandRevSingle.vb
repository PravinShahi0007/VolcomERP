Public Class FormProdDemandRevSingle
    Private Sub FormProdDemandRevSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type WHERE id_pd_type<3 ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Sub actionLoad()
        viewLineType()
        TxtReason.Text = ""
        Dim query As String = "SELECT  dp.id_prod_demand_design_rev, pdd.id_prod_demand_design, pdd.id_design,d.design_code AS `code`, d.design_display_name AS `name`, po.prod_order_number,
        IFNULL(po.ordered,0) AS `ordered`,
        IFNULL(rec.received,0) AS `received`,
        pd_det.current_qty, pd_det.current_cost, pd_det.current_add_cost, pd_det.current_size_chart,
        'No' AS `is_select`
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        LEFT JOIN (
	        SELECT pdd.id_prod_demand_design, pdd.id_design, SUM(pdp.prod_demand_product_qty) AS `current_qty`, pdd.prod_demand_design_total_cost AS `current_cost`, 
	        pdd.additional_cost AS `current_add_cost`,
            GROUP_CONCAT(DISTINCT cd.`code_detail_name` ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `current_size_chart`
	        FROM tb_prod_demand_product pdp
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = pdp.id_prod_demand_design
            INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
	        WHERE pdd.id_prod_demand=" + FormProdDemandRevDet.id_prod_demand + " AND pdp.prod_demand_product_qty>0
	        GROUP BY pdd.id_prod_demand_design
        ) pd_det ON pd_det.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, po.prod_order_number, SUM(pod.prod_order_qty) AS `ordered`
	        FROM tb_prod_order po 
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        WHERE po.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, SUM(rd.prod_order_rec_det_qty) AS `received` 
	        FROM tb_prod_order_rec_det rd
	        INNER JOIN tb_prod_order_rec r ON r.id_prod_order_rec = rd.id_prod_order_rec
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = rd.id_prod_order_det
	        INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	        WHERE r.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) rec ON rec.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT rd.id_prod_demand_design, rd.id_prod_demand_design_rev
	        FROM tb_prod_demand_design_rev rd
	        INNER JOIN tb_prod_demand_rev r ON r.id_prod_demand_rev = rd.id_prod_demand_rev
	        WHERE r.id_prod_demand_rev=" + FormProdDemandRevDet.id + "
        ) dp ON dp.id_prod_demand_design = pdd.id_prod_demand_design
        WHERE pdd.id_prod_demand=" + FormProdDemandRevDet.id_prod_demand + " AND ISNULL(dp.id_prod_demand_design_rev) AND pdd.is_void=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
    End Sub

    Private Sub FormProdDemandRevSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnRevise_Click(sender As Object, e As EventArgs) Handles BtnRevise.Click
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            'cek
            Dim cancel_po_note As String = ""
            Dim is_cancel_po As String = "2"
            Dim id_design As String = GVDesign.GetFocusedRowCellValue("id_design").ToString
            Dim qcek As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name`,  
            GROUP_CONCAT(DISTINCT cd.`code_detail_name` ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`,
            pdd.prod_demand_design_total_cost AS `cost`,  pdd.additional_cost AS `add_cost`,
            SUM(pdp.prod_demand_product_qty) AS `total_qty`
            FROM tb_m_design d 
            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = d.id_prod_demand_design_line
            INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
            INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            WHERE d.id_design=" + id_design + " AND pdp.prod_demand_product_qty>0
            GROUP BY pdd.id_design "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                'total qty
                If dcek.Rows(0)("total_qty") <> GVDesign.GetFocusedRowCellValue("current_qty") Then
                    is_cancel_po = "1"
                    cancel_po_note = "total qty; "
                End If

                'size chart
                If dcek.Rows(0)("size_chart") <> GVDesign.GetFocusedRowCellValue("current_size_chart") Then
                    is_cancel_po = "1"
                    cancel_po_note = "size chart; "
                End If

                'cop
                If dcek.Rows(0)("cost") <> GVDesign.GetFocusedRowCellValue("current_cost") Then
                    is_cancel_po = "1"
                    cancel_po_note = "cost; "
                End If

                'add cop
                If dcek.Rows(0)("add_cost") <> GVDesign.GetFocusedRowCellValue("current_add_cost") Then
                    is_cancel_po = "1"
                    cancel_po_note = "additional cost; "
                End If

                'cek qty per size
                If is_cancel_po = "2" Then
                    Dim qcp As String = "SELECT pdp.id_product, SUM(pdp.prod_demand_product_qty) AS `qty`, IFNULL(pdc.qty,0) AS `current_qty`
                    FROM tb_m_design d 
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = d.id_prod_demand_design_line
                    INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
                    LEFT JOIN (
	                    SELECT pdp.id_product, SUM(pdp.prod_demand_product_qty) AS `qty`
	                    FROM tb_prod_demand_design pdd
	                    INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
	                    WHERE pdd.id_prod_demand=" + FormProdDemandRevDet.id_prod_demand + " AND pdd.id_design=" + id_design + " AND pdp.prod_demand_product_qty>0 AND pdd.is_void=2
	                    GROUP BY pdp.id_product
                    ) pdc ON pdc.id_product = pdp.id_product
                    WHERE d.id_design=" + id_design + " AND pdp.prod_demand_product_qty>0 
                    GROUP BY pdp.id_product
                    HAVING qty<>current_qty "
                    Dim dcp As DataTable = execute_query(qcp, -1, True, "", "", "", "")
                    If dcp.Rows.Count > 0 Then
                        is_cancel_po = "1"
                        cancel_po_note = "qty per size; "
                    End If
                End If
            Else
                stopCustom("This product not found on line list")
                Exit Sub
            End If

            If is_cancel_po = "1" Then
                If GVDesign.GetFocusedRowCellValue("received") > 0 Then
                    stopCustom("Can't revise because " + GVDesign.GetFocusedRowCellValue("name").ToString + " already received in QC")
                Else
                    'insert detail
                    Dim query_det_new As String = "CALL generate_pd_rev_line_list('" + FormProdDemandRevDet.id + "','" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "', '" + SLETypeLineList.EditValue.ToString + "', '" + GVDesign.GetFocusedRowCellValue("id_design").ToString + "', " + is_cancel_po + ", '" + cancel_po_note + "')"
                    execute_non_query(query_det_new, True, "", "", "", "")

                    'update reason
                    Dim note As String = TxtReason.Text
                    Dim pd As New ClassProdDemand()
                    pd.updateNotePDRevDetail(FormProdDemandRevDet.id, GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString, note)

                    FormProdDemandRevDet.viewDetail()
                    actionLoad()
                End If
            ElseIf is_cancel_po = "2" Then
                'insert detail
                Dim query_det_new As String = "CALL generate_pd_rev_line_list('" + FormProdDemandRevDet.id + "','" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "', '" + SLETypeLineList.EditValue.ToString + "', '" + GVDesign.GetFocusedRowCellValue("id_design").ToString + "', " + is_cancel_po + ", '" + cancel_po_note + "')"
                execute_non_query(query_det_new, True, "", "", "", "")

                'update reason
                Dim note As String = TxtReason.Text
                Dim pd As New ClassProdDemand()
                pd.updateNotePDRevDetail(FormProdDemandRevDet.id, GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString, note)

                FormProdDemandRevDet.viewDetail()
                actionLoad()
            End If
        Else
            stopCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDrop_Click(sender As Object, e As EventArgs) Handles BtnDrop.Click
        If TxtReason.Text = "" Then
            warningCustom("Please input reason")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            If GVDesign.GetFocusedRowCellValue("received") > 0 Then
                stopCustom("Can't revise because " + GVDesign.GetFocusedRowCellValue("name").ToString + " already received in QC")
            Else
                'drop - data pake existing pd
                'insert detail
                Dim query_det_new As String = "CALL generate_pd_drop_line_list('" + FormProdDemandRevDet.id + "','" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "')"
                execute_non_query(query_det_new, True, "", "", "", "")

                'update reason
                Dim note As String = TxtReason.Text
                Dim pd As New ClassProdDemand()
                Dim id_pd_rev As String = FormProdDemandRevDet.id
                Dim id_pdd As String = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                pd.updateNotePDRevDetail(id_pd_rev, id_pdd, note)

                FormProdDemandRevDet.viewDetail()
                actionLoad()
            End If
        Else
            stopCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub
End Class