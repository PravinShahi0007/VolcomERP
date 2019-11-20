Public Class FormInvoiceFGPONew
    Private Sub FormInvoiceFGPONew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub view_type()
        Dim query As String = "SELECT id_type,pn_type FROM tb_pn_type WHERE is_payment =1"
        viewSearchLookupQuery(SLETypeInvoice, query, "id_type", "pn_type", "id_type")
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "design_display_name", "id_prod_order")
    End Sub

    Sub fill_grid()
        If SLETypeInvoice.EditValue.ToString = "2" Then 'payment
            'search qty order - qty after paid
            Dim query As String = "SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_po 
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.`id_report_status`=6
LEFT JOIN 
(
	SELECT rec.`id_prod_order`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`type`='2' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=pnd.`id_report`
	WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY rec.`id_prod_order`
)pn ON pn.id_prod_order=po.id_prod_order
WHERE po.id_prod_order='" & SLEFGPO.EditValue.ToString & "'
GROUP BY pod.`id_prod_order`
HAVING qty_po > 0"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows(0)("qty_po") > 0 Then
                Dim q_det As String = "-- normal
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining ,prc.prod_order_wo_det_price, prc.prod_order_wo_vat, prc.kurs
,dsg.design_display_name
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='2' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=2
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
                '
                Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                '
                Dim qty_po As Integer = data.Rows(0)("qty_po")
                Dim qty_rec As Integer = 0
                '
                Try
                    For i As Integer = 0 To dt_det.Rows.Count - 1
                        Dim qty_used As Integer = 0

                        Console.WriteLine(qty_po.ToString & " - " & dt_det.Rows(i)("qty_rec_remaining").ToString)

                        If (qty_po - dt_det.Rows(i)("qty_rec_remaining")) < 0 Then
                            qty_used = dt_det.Rows(i)("qty_rec_remaining") - qty_po
                        Else
                            qty_used = dt_det.Rows(i)("qty_rec_remaining")
                        End If

                        'input ke grid
                        Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                        newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                        newRow("report_mark_type") = "28"
                        newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                        newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                        newRow("qty") = qty_used
                        newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                        newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                        '
                        qty_rec += qty_used
                        qty_po = qty_po - dt_det.Rows(i)("qty_rec_remaining")
                        If qty_po <= 0 Then
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                '
                'If qty_rec > 0 Then
                '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                '    Close()
                'Else
                '    warningCustom("There is no available qty receiving.")
                'End If
            Else
                warningCustom("There is no remaining payment for this payment type.")
            End If
        ElseIf SLETypeInvoice.EditValue.ToString = "3" Then 'Extra hingga 2%
            'search qty order - qty after paid
            Dim query As String = "SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty_po
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.`id_report_status`=6
WHERE po.id_prod_order='" & SLEFGPO.EditValue.ToString & "'
GROUP BY pod.`id_prod_order`"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows(0)("qty_po") > 0 Then
                Dim q_det As String = "-- extra
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining,prc.prod_order_wo_det_price, prc.prod_order_wo_vat, prc.kurs
,dsg.design_display_name
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='3' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=2
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
                '
                Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                '
                Dim qty_po As Integer = data.Rows(0)("qty_po")
                Dim qty_po_old As Integer = 0
                Dim qty_rec As Integer = 0
                '
                For i As Integer = 0 To dt_det.Rows.Count - 1
                    Dim qty_used As Integer = 0
                    '
                    qty_po_old = qty_po
                    qty_po = qty_po - dt_det.Rows(i)("qty_rec_remaining")
                    '
                    If qty_po < 0 Then
                        If qty_po_old >= 0 Then 'masih ada yang tidak extra
                            qty_used = dt_det.Rows(i)("qty_rec_remaining") - qty_po_old
                        Else 'extra only
                            qty_used = dt_det.Rows(i)("qty_rec_remaining")
                        End If
                        'input ke grid
                        Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                        newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                        newRow("report_mark_type") = "28"
                        newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                        newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                        newRow("qty") = qty_used
                        newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                        newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                        '
                        qty_rec += qty_used
                    End If
                Next
                '
                'If qty_rec > 0 Then
                '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                '    Close()
                'Else
                '    warningCustom("There is no available extra qty receiving to invoice.")
                'End If
            Else
                warningCustom("There is 0 remaining qty for this payment type.")
            End If
        ElseIf SLETypeInvoice.EditValue.ToString = "4" Then 'over memo
            Dim q_det As String = "-- extra
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining,prc.prod_order_wo_det_price, prc.prod_order_wo_vat, prc.kurs
,dsg.design_display_name
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='4' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=1
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
            '
            Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
            Dim qty_rec As Integer = 0
            '
            For i As Integer = 0 To dt_det.Rows.Count - 1
                Dim qty_used As Integer = 0
                qty_used = dt_det.Rows(i)("qty_rec_remaining")
                '
                Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                newRow("report_mark_type") = "28"
                newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                newRow("qty") = qty_used
                newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                newRow("inv_number") = ""
                newRow("note") = ""
                TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                '
                qty_rec += qty_used
            Next
            '
            'If qty_rec > 0 Then
            '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
            '    Close()
            'Else
            '    warningCustom("There is no available extra qty receiving to invoice.")
            'End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If GVInvoice.RowCount > 0 Then
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = GVInvoice.GetFocusedRowCellValue("id_report")
            newRow("report_mark_type") = GVInvoice.GetFocusedRowCellValue("report_mark_type")
            newRow("report_number") = GVInvoice.GetFocusedRowCellValue("report_number")
            newRow("info_design") = GVInvoice.GetFocusedRowCellValue("info_design")
            newRow("qty") = GVInvoice.GetFocusedRowCellValue("qty")
            newRow("value") = GVInvoice.GetFocusedRowCellValue("value")
            newRow("vat") = GVInvoice.GetFocusedRowCellValue("vat")
            newRow("inv_number") = ""
            newRow("note") = ""
            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)

            Close()
        Else
            warningCustom("No receiving")
        End If
    End Sub

    Private Sub FormInvoiceFGPONew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_det()

        view_type()
        view_fgpo()
    End Sub

    Sub view_det()
        Dim query As String = "
Select pnd.`id_report` As id_report,pnd.report_mark_type, pnd.`report_number`, pnd.`info_design`, pnd.`id_pn_fgpo_det`, pnd.`qty`,pnd.`value`,pnd.`vat`, pnd.`inv_number`, pnd.`note` 
FROM tb_pn_fgpo_det pnd
WHERE pnd.`id_pn_fgpo`='-1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoice.DataSource = data
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        For i = GVInvoice.RowCount - 1 To 0 Step -1
            GVInvoice.DeleteRow(i)
        Next
        fill_grid()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        If GVInvoice.RowCount > 0 Then
            For i As Integer = 0 To GVInvoice.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = GVInvoice.GetRowCellValue(i, "id_report")
                newRow("report_mark_type") = GVInvoice.GetRowCellValue(i, "report_mark_type")
                newRow("report_number") = GVInvoice.GetRowCellValue(i, "report_number")
                newRow("info_design") = GVInvoice.GetRowCellValue(i, "info_design")
                newRow("qty") = GVInvoice.GetRowCellValue(i, "qty")
                newRow("value") = GVInvoice.GetRowCellValue(i, "value")
                newRow("vat") = GVInvoice.GetRowCellValue(i, "vat")
                newRow("inv_number") = ""
                newRow("note") = ""
                TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            Next
            Close()
        Else
            warningCustom("No receiving")
        End If
    End Sub
End Class