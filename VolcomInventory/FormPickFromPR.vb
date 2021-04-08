Public Class FormPickFromPR
    Public id_departement As String = ""

    Private Sub FormPickFromPR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPickFromPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pr()
    End Sub

    Sub load_pr()
        Dim q As String = "SELECT 0 AS id_purc_req,'ALL' AS purc_req_number
UNION ALL
(SELECT req.id_purc_req,req.purc_req_number FROM tb_purc_req req 
INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req=req.id_purc_req AND reqd.ship_to>1
WHERE req.id_departement='" & id_departement & "' AND req.`id_report_status` = 6 AND req.`is_store_purchase`=2 AND req.`is_fixed_asset`=2 
GROUP BY req.id_purc_req
ORDER BY `id_purc_req` DESC)"
        viewSearchLookupQuery(SLEPR, q, "id_purc_req", "purc_req_number", "id_purc_req")
    End Sub

    Sub load_item()
        Dim qwhere As String = ""
        If Not SLEPR.EditValue.ToString = "0" Then
            qwhere = " AND req.id_purc_req='" & SLEPR.EditValue.ToString & "'"
        End If
        Dim q As String = "SELECT 'yes' AS is_check,req.`id_purc_req`,req.`purc_req_number`,it.`item_desc`,reqd.`item_detail`,reqd.`ship_to` AS id_comp,c.`comp_number`,c.`comp_name`,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS store,it.`id_item`,reqd.`qty` AS qty_pr,IFNULL(SUM(recd.`qty_stock`),0) AS qty_rec,IFNULL(SUM(recd.`qty_stock`),0) AS qty_req
FROM  tb_purc_req_det reqd
LEFT JOIN tb_purc_order_det pod ON pod.`id_purc_req_det`=reqd.`id_purc_req_det`
LEFT JOIN tb_purc_rec_det recd ON recd.`id_purc_order_det`=pod.`id_purc_order_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req` AND req.`id_report_status` = 6 AND req.`is_store_purchase`=2 AND req.`is_fixed_asset`=2
AND req.`id_departement`='" & id_departement & "' " & qwhere & "
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.`id_purc_rec` AND rec.`id_report_status` = 6
INNER JOIN tb_item it ON it.`id_item`=reqd.`id_item` 
INNER JOIN tb_m_comp c ON c.`id_comp`=reqd.`ship_to` AND reqd.ship_to > 1
GROUP BY reqd.`id_purc_req_det`
ORDER BY req.`id_purc_req` DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItem.DataSource = dt
        GVItem.BestFitColumns()
    End Sub

    Private Sub BLoadItem_Click(sender As Object, e As EventArgs) Handles BLoadItem.Click
        load_item()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        GVItem.ActiveFilterString = "[is_check] = 'yes' AND [qty_req]>0"
        If GVItem.RowCount > 0 Then
            'pick
            For i = 0 To GVItem.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormItemReqDet.GCDetail.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVItem.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVItem.GetRowCellValue(i, "item_desc").ToString
                newRow("id_comp") = GVItem.GetRowCellValue(i, "id_comp").ToString
                newRow("comp_number") = GVItem.GetRowCellValue(i, "comp_number").ToString
                newRow("comp_name") = GVItem.GetRowCellValue(i, "comp_name").ToString
                newRow("qty") = GVItem.GetRowCellValue(i, "qty_req")
                '
                newRow("is_store_request") = "no"
                '
                newRow("remark") = GVItem.GetRowCellValue(i, "item_detail").ToString
                TryCast(FormItemReqDet.GCDetail.DataSource, DataTable).Rows.Add(newRow)
                FormItemReqDet.GCDetail.RefreshDataSource()
                FormItemReqDet.GVDetail.RefreshData()
            Next
            Close()
        Else
            warningCustom("Please fill qty and choose the item")
        End If
        GVItem.ActiveFilterString = ""
    End Sub

    Private Sub GVItem_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItem.CellValueChanged
        If e.Column.FieldName.ToString = "qty_req" Then
            If GVItem.GetFocusedRowCellValue("qty_rec") < e.Value Then
                warningCustom("Qty exceed receiving qty")
                GVItem.SetFocusedRowCellValue("qty_req", GVItem.GetFocusedRowCellValue("qty_rec"))
            End If
        End If
    End Sub
End Class