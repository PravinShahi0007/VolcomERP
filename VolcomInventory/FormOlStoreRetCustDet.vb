Public Class FormOlStoreRetCustDet
    Public id_ret As String = "-1"
    Dim is_scan As Boolean = False
    Dim order_id As String = ""
    Dim id_comp_group As String = ""

    Private Sub FormOlStoreRetCustDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT 0 AS id_comp_group,'ALL' AS comp_group,'ALL' AS description
UNION
SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM `tb_ol_store_ret_list` rl
INNER JOIN `tb_ol_store_ret_det` retd ON retd.`id_ol_store_ret`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret ret ON retd.id_ol_store_ret=ret.id_ol_store_ret
WHERE ret.id_report_status=6 AND (rl.`id_ol_store_ret_stt`=4 OR rl.id_ol_store_ret_stt=5)
GROUP BY ret.sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Private Sub FormOlStoreRetCustDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp_group()
        view_order()

        If id_ret = "-1" Then 'new
            SLECompGroup.EditValue = FormOlStoreRetCust.SLECompGroup.EditValue
            SLEOrder.EditValue = FormOlStoreRetCust.SLEOrder.EditValue
            '
            DEDateCreated.EditValue = Now
            TENumberRetCust.Text = "[auto generate]"
            '
            If FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "is_ret_to_cust").ToString = "1" Or FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "is_ret_to_cust").ToString = "True" Then
                '
                TERetTo.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_name").ToString
                MEAddress1.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_address").ToString
                '
                TEShipPhone.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_phone").ToString
                TEShipCity.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_city").ToString
                TEPostalCode.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_postal_code").ToString
                TERegion.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "cust_region").ToString
            Else
                TERetTo.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_name").ToString
                MEAddress1.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_address").ToString
                '
                TEShipPhone.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_phone").ToString
                TEShipCity.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_city").ToString
                TEPostalCode.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_postal_code").ToString
                TERegion.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "group_region").ToString
            End If
        Else
            Dim q As String = "SELECT * FROM `tb_ol_store_cust_ret` WHERE id_ol_store_cust_ret='" & id_ret & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLECompGroup.EditValue = dt.Rows(0)("id_comp_group").ToString
                SLEOrder.EditValue = dt.Rows(0)("sales_order_ol_shop_number").ToString
                '
                DEDateCreated.EditValue = dt.Rows(0)("created_date")
                TENumberRetCust.Text = dt.Rows(0)("number").ToString
                '
                TERetTo.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_name").ToString
                MEAddress1.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_address").ToString
                '
                TEShipPhone.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_phone").ToString
                TEShipCity.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_city").ToString
                TEPostalCode.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_post_code").ToString
                TERegion.Text = FormOlStoreRetCust.GVRetReq.GetRowCellValue(0, "shipping_region").ToString
            End If
        End If

        load_det()
        load_barcode()
    End Sub

    Sub load_det()
        Dim q As String = ""

        If id_ret = "-1" Then 'new
            q = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
,0 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit
FROM tb_ol_store_ret_list rl
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret`
INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
LEFT JOIN 
(
	SELECT id_ol_store_ret_list 
	FROM `tb_ol_store_cust_ret_det` crd
	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
) retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
WHERE rl.id_ol_store_ret_stt='4' AND r.id_comp_group='" & SLECompGroup.EditValue.ToString & "' AND r.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "' "
        Else 'edit
            q = "SELECT rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
,1 AS qty_scan,IF(ISNULL(retc.id_ol_store_ret_list),1,0) AS qty_limit
FROM `tb_ol_store_cust_ret_det` retd
INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=retd.id_ol_store_ret_list
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
LEFT JOIN 
(
	SELECT id_ol_store_ret_list 
	FROM `tb_ol_store_cust_ret_det` crd
	INNER JOIN tb_ol_store_cust_ret cr ON cr.`id_ol_store_cust_ret`=crd.`id_ol_store_cust_ret` AND cr.`id_report_status`!=5
	WHERE NOT crd.`id_ol_store_cust_ret`='" & id_ret & "'
) retc ON retc.id_ol_store_ret_list=rl.`id_ol_store_ret_list`
WHERE retd.id_ol_store_cust_ret='" & id_ret & "'"
        End If

        GroupControlListItem.Enabled = True

        Dim data As DataTable = execute_query(q, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub

    Sub load_barcode()
        Dim q As String = "SELECT retd.id_ol_store_cust_ret_det,rl.`id_ol_store_ret_list`,p.`id_product`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS code,p.`product_display_name` AS name,cd.`code_detail_name` AS size
FROM `tb_ol_store_cust_ret_det` retd
INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=retd.id_ol_store_ret_list
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
WHERE retd.id_ol_store_cust_ret='" & id_ret & "'"

        Dim data As DataTable = execute_query(q, "-1", True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.BestFitColumns()
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDeleteScan.KeyDown
        If e.KeyCode = Keys.Enter And TxtDeleteScan.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            GVBarcode.ActiveFilterString = "[code]='" + TxtDeleteScan.Text + "'"
            If GVBarcode.RowCount <= 0 Then
                stopCustomDialog("Code not found.")
                GVBarcode.ActiveFilterString = ""
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            Else
                Dim id_ol_store_cust_ret_det As String = "-1"
                Try
                    id_ol_store_cust_ret_det = GVBarcode.GetFocusedRowCellValue("id_ol_store_cust_ret_det").ToString
                Catch ex As Exception
                End Try

                If id_ret = "-1" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_ol_store_ret_list As String = GVBarcode.GetFocusedRowCellValue("id_ol_store_ret_list").ToString
                        deleteRowsBc()

                        GVBarcode.ActiveFilterString = ""
                        countQty(id_ol_store_ret_list)

                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                Else
                    If id_ol_store_cust_ret_det = "0" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_ol_store_ret_list As String = GVBarcode.GetFocusedRowCellValue("id_ol_store_ret_list").ToString
                            deleteRowsBc()

                            GVBarcode.ActiveFilterString = ""
                            countQty(id_ol_store_ret_list)

                            allowDelete()
                        End If
                    Else
                        errorCustom("This data already locked and can't delete.")
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub
    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Sub countQty(ByVal id_ret_list As String)
        GVBarcode.ActiveFilterString = "[id_ol_store_ret_list]='" + id_ret_list + "' "
        Dim tot As Integer = GVBarcode.RowCount
        GVBarcode.ActiveFilterString = ""

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_ol_store_ret_list", id_ret_list)
        GVItemList.SetFocusedRowCellValue("qty_scan", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub
    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub disableControl()
        is_scan = True
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        ControlBox = False
        BtnVerify.Enabled = False

        If Not id_ret = "-1" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DDBPrint.Enabled = False
        End If
    End Sub
    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()
    End Sub
End Class