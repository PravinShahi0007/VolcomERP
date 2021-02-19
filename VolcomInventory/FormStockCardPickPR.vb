Public Class FormStockCardPickPR
    Sub load_store()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE is_active=1 AND id_comp_cat='6'"
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
        Dim q As String = "SELECT rec.`id_purc_rec`,rec.`purc_rec_number`,rec.`date_arrived`
FROM `tb_stock_card_dep` stk
INNER JOIN tb_purc_rec_det recd ON recd.`id_purc_rec_det`=stk.`id_report_det` AND stk.`report_mark_type`=148
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec`
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det` AND reqd.`is_dep_stock_card`=1 
WHERE reqd.`ship_to`='" & SLEStore.EditValue.ToString & "'
GROUP BY recd.`id_purc_rec`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPurcReq.DataSource = dt
        If GVPurcReq.RowCount > 0 Then
            load_det()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT rec.`id_purc_rec`,rec.`purc_rec_number`,rec.`date_arrived`,stk.`id_item_detail`,it.item_desc,itd.item_detail,itd.remark,stk.qty
FROM `tb_stock_card_dep` stk
INNER JOIN tb_stock_card_dep_item itd ON itd.id_item_detail=stk.`id_item_detail`
INNER JOIN tb_item it ON it.id_item=itd.id_item
INNER JOIN tb_purc_rec_det recd ON recd.`id_purc_rec_det`=stk.`id_report_det` AND stk.`report_mark_type`=148
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec`
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det` AND reqd.`is_dep_stock_card`=1 
WHERE reqd.`ship_to`='" & SLEStore.EditValue.ToString & "'
GROUP BY itd.`id_item_detail`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItemList.DataSource = dt
        GVItemList.BestFitColumns()
    End Sub
End Class