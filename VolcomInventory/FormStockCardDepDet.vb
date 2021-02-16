Public Class FormStockCardDepDet
    Public id_trans As String = "-1"
    Public id_report_status As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormStockCardDepDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
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
            Dim q As String = "SELECT * 
FROM `tb_item_card_trs` trx
INNER JOIN tb_m_departement dep ON dep.id_departement=trx.id_departement
WHERE id_item_card_trs='" & id_trans & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLEType.EditValue = dt.Rows(0)("id_type").ToString
                TEDepartement.Text = dt.Rows(0)("departement").ToString
                SLEStore.EditValue = dt.Rows(0)("id_store").ToString
                TENumber.Text = dt.Rows(0)("number").ToString
                DEProposedDate.EditValue = dt.Rows(0)("created_date")
                MENote.Text = dt.Rows(0)("note").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
            End If
        End If

        check_but()
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
        Dim q As String = "SELECT trsd.id_item_card_trs_det,trsd.`id_item_detail`,it.`item_desc`,itd.`item_detail`,itd.`remark`,trsd.`qty_available`,trsd.`qty`,trsd.`note`
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
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
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
        GVItemDetail.AddNewRow()
        GVItemDetail.FocusedRowHandle = GVItemDetail.RowCount - 1
        load_item_pil()
        check_but()
    End Sub

    Sub check_but()
        If GVItemDetail.RowCount > 0 Then
            BtnDelete.Visible = True
        Else
            BtnDelete.Visible = False
        End If

        If id_report_status = "-1" Then
            'new
            BtnPrint.Visible = False
            BtnMark.Visible = False
        Else
            'edit
            BtnPrint.Visible = False
            BtnMark.Visible = True
            '
            BtnAdd.Visible = False
            BtnDelete.Visible = False
            '
            SLEType.ReadOnly = True
            SLEStore.ReadOnly = True
        End If
    End Sub

    Private Sub RISLEItemDetail_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEItemDetail.EditValueChanged
        Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        GVItemDetail.SetFocusedRowCellValue("item_detail", sle.Properties.View.GetFocusedRowCellValue("item_detail").ToString())
        GVItemDetail.SetFocusedRowCellValue("qty_available", Decimal.Parse(sle.Properties.View.GetFocusedRowCellValue("qty_available").ToString()))
        GVItemDetail.SetFocusedRowCellValue("qty", Decimal.Parse(sle.Properties.View.GetFocusedRowCellValue("qty_available").ToString()))
        GVItemDetail.SetFocusedRowCellValue("id_item_detail", sle.Properties.View.GetFocusedRowCellValue("id_item_detail").ToString())
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVItemDetail.RowCount > 0 Then
            If id_trans = "-1" Then
                'new
                Dim q As String = ""
                q = "INSERT INTO tb_item_card_trs(`id_type`,`id_store`,`id_departement`,`created_date`,`created_by`,`note`,`id_report_status`)
VALUES('" & SLEType.EditValue.ToString & "','" & SLEStore.EditValue.ToString & "','" & id_departement_user & "',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID();"
                id_trans = execute_query(q, 0, True, "", "", "", "")
                'detail
                q = "INSERT INTO tb_item_card_trs_det(`id_item_card_trs`,`id_item_detail`,`qty_available`,`qty`)
VALUES"
                For i As Integer = 0 To GVItemDetail.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    q += "('" & id_trans & "','" & GVItemDetail.GetRowCellValue(i, "id_item_detail").ToString & "','" & decimalSQL(Decimal.Parse(GVItemDetail.GetRowCellValue(i, "qty_available").ToString)) & "','" & decimalSQL(Decimal.Parse(GVItemDetail.GetRowCellValue(i, "qty").ToString)) & "')"
                Next
                '
                execute_query(q, -1, True, "", "", "", "")

                submit_who_prepared("289", id_trans, id_user)
                execute_query("CALL gen_number('" & id_trans & "','289')", -1, True, "", "", "", "")

                'reserved
                q = "INSERT INTO `tb_stock_card_dep`(id_departement,id_item_detail,id_report,report_mark_type,qty)
SELECT it.id_departement,itd.id_item_detail,it.id_item_card_trs,'289' AS rmt,IF(it.id_type=1,-1,1)*SUM(qty) AS qty
FROM tb_item_card_trs_det itd
INNER JOIN tb_item_card_trs it ON it.id_item_card_trs=itd.id_item_card_trs
WHERE it.id_item_card_trs='" & id_trans & "'
GROUP BY itd.id_item_detail"
                execute_query(q, -1, True, "", "", "", "")

                infoCustom("Doucment created, waiting for approval.")
                load_form()
            Else
                'edit
                'no edit plz
            End If
        Else
            warningCustom("Please put item first.")
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        FormReportMark.report_mark_type = "289"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_trans
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'soon
    End Sub
End Class