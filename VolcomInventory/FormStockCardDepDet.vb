Public Class FormStockCardDepDet
    Public id_trans As String = "-1"

    Private Sub FormStockCardDepDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEProposedDate.EditValue = Now()
        load_store()
        load_type()
        '
        load_item_pil()
        load_det()
        '
        If id_trans = "-1" Then 'new
            TEDepartement.Text = get_departement_x(id_departement_user, "1")
        Else 'edit

        End If
    End Sub

    Sub load_item_pil()
        Dim q As String = "SELECT itd.`id_item_detail`,it.`item_desc`,CONCAT(itd.item_detail,IF(ISNULL(itd.remark) OR itd.remark='','',CONCAT('\r\n',itd.remark))) AS item_detail,IFNULL(its.qty,0.00) AS qty_available
FROM `tb_stock_card_dep_item` itd
INNER JOIN tb_item it ON it.`id_item`=itd.`id_item`
LEFT JOIN (
	SELECT id_item_detail,SUM(qty) AS qty
	FROM `tb_stock_card_dep`
	WHERE id_departement='" & id_departement_user & "'
	GROUP BY id_item_detail
)its ON its.id_item_detail=itd.`id_item_detail`
WHERE IFNULL(its.qty,0.00)>0"
        viewSearchLookupRepositoryQuery(RISLEItemDetail, q, 0, "item_desc", "id_item_detail")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT trsd.`id_item_detail`,it.`item_desc`,itd.`item_detail`,itd.`remark`,trsd.`qty`,trsd.`note`
FROM tb_item_card_trs_det trsd
INNER JOIN `tb_stock_card_dep_item` itd ON itd.`id_item_detail`=trsd.`id_item_detail`
INNER JOIN tb_item it ON it.`id_item`=itd.`id_item`
WHERE trsd.`id_item_card_trs`='" & id_trans & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItemDetail.DataSource = dt
        GVItemDetail.BestFitColumns()
    End Sub

    Sub load_store()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE is_active=1 AND id_comp_cat='6'"
        viewSearchLookupQuery(SLEStore, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'Delivery' AS type
UNION ALL
SELECT '2' AS id_type,'Receiving' AS type"
        viewSearchLookupQuery(SLEStore, q, "id_type", "type", "id_type")
    End Sub

    Private Sub FormStockCardDepDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVItemDetail.RowCount > 0 Then
            GVItemDetail.DeleteSelectedRows()
        End If
        check_but()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        check_but()
    End Sub

    Sub check_but()
        If GVItemDetail.RowCount > 0 Then
            BtnDelete.Visible = True
        Else
            BtnDelete.Visible = False
        End If
    End Sub
End Class