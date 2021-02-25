Public Class FormStockCardPickPR
    Sub load_store()
        Dim q As String = "SELECT 0 AS id_comp,'-' AS comp_number,'-' AS comp_name
UNION ALL
SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE is_active=1 AND id_comp_cat='6'"
        viewSearchLookupQuery(SLEStore, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormStockCardPickPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_store()
    End Sub

    Private Sub FormStockCardPickPR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_rec()
    End Sub

    Sub load_rec()
        Dim qw As String = ""

        If Not SLEStore.EditValue.ToString = "0" Then
            qw = " WHERE reqd.`ship_to`='" & SLEStore.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT rec.`id_purc_rec`,rec.`purc_rec_number`,rec.`date_arrived`,reqd.ship_to,c.comp_name
FROM `tb_stock_card_dep` stk
INNER JOIN tb_purc_rec_det recd ON recd.`id_purc_rec_det`=stk.`id_report_det` AND stk.`report_mark_type`=148
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec`
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det` AND reqd.`is_dep_stock_card`=1 
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req AND req.id_departement='" & id_departement_user & "'
INNER JOIN tb_m_comp c ON c.id_comp=reqd.ship_to
" & qw & "
GROUP BY recd.`id_purc_rec`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPurcReq.DataSource = dt
        load_det()
    End Sub

    Sub load_det()
        If GVPurcReq.RowCount > 0 Then
            Dim q As String = "SELECT rec.`id_purc_rec`,rec.`purc_rec_number`,rec.`date_arrived`,stk.`id_item_detail`,it.item_desc,stk.qty,its.qty AS qty_available
,CONCAT(itd.item_detail,IF(ISNULL(itd.remark) OR itd.remark='','',CONCAT('\r\n',itd.remark))) AS item_detail
FROM `tb_stock_card_dep` stk
LEFT JOIN (
	SELECT id_item_detail,SUM(qty) AS qty
	FROM `tb_stock_card_dep`
	WHERE id_departement='" & id_departement_user & "'
	GROUP BY id_item_detail
)its ON its.id_item_detail=stk.`id_item_detail`
INNER JOIN tb_stock_card_dep_item itd ON itd.id_item_detail=stk.`id_item_detail`
INNER JOIN tb_item it ON it.id_item=itd.id_item
INNER JOIN tb_purc_rec_det recd ON recd.`id_purc_rec_det`=stk.`id_report_det` AND stk.`report_mark_type`=148
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec`
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det` AND reqd.`is_dep_stock_card`=1 
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req AND req.id_departement='" & id_departement_user & "'
WHERE rec.id_purc_rec='" & GVPurcReq.GetFocusedRowCellValue("id_purc_rec").ToString & "' AND reqd.ship_to='" & GVPurcReq.GetFocusedRowCellValue("ship_to").ToString & "'
GROUP BY itd.`id_item_detail`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCItemList.DataSource = dt
            GVItemList.BestFitColumns()
        End If
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If GVItemList.RowCount > 0 Then
            'delete all row
            FormStockCardDepDet.delete_all_row()
            'input purc rec
            FormStockCardDepDet.id_purc_rec = GVPurcReq.GetFocusedRowCellValue("id_purc_rec").ToString
            FormStockCardDepDet.TERec.Text = GVPurcReq.GetFocusedRowCellValue("purc_rec_number").ToString
            FormStockCardDepDet.SLEStore.EditValue = GVPurcReq.GetFocusedRowCellValue("ship_to").ToString

            FormStockCardDepDet.check_but()
            '
            For i As Integer = 0 To GVItemList.RowCount - 1

                Dim newRow As DataRow = (TryCast(FormStockCardDepDet.GCItemDetail.DataSource, DataTable)).NewRow()
                newRow("id_item_detail") = GVItemList.GetRowCellValue(i, "id_item_detail").ToString()
                newRow("item_detail") = GVItemList.GetRowCellValue(i, "item_detail").ToString()
                newRow("qty_available") = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_available").ToString())
                newRow("qty") = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty").ToString())
                TryCast(FormStockCardDepDet.GCItemDetail.DataSource, DataTable).Rows.Add(newRow)
                FormStockCardDepDet.GCItemDetail.RefreshDataSource()
                FormStockCardDepDet.GVItemDetail.RefreshData()
            Next

            FormStockCardDepDet.GVItemDetail.RefreshData()
            Close()
        End If
    End Sub

    Private Sub GVPurcReq_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPurcReq.FocusedRowChanged
        load_det()
    End Sub

    Private Sub GVPurcReq_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVPurcReq.ColumnFilterChanged
        load_det()
    End Sub
End Class