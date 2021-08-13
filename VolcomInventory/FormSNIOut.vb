Public Class FormSNIOut
    Public id As String = "-1"
    Private Sub FormSNIOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_vendor()
        view_barcode_list()
        viewReportStatus()

        load_det()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_vendor()
        Dim query As String = "SELECT comp.id_comp,comp.comp_number, comp.comp_name FROM tb_m_comp comp WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormSNIOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '' AS `no`,qco.`id_qc_sni_out_det`,pdp.`id_product`,po.`id_prod_order`,pod.id_prod_order_det,recd.`id_prod_order_rec`,po.`prod_order_number`,rec.`prod_order_rec_number`,p.`product_full_code`,dsg.`design_display_name` AS name,cd.`display_name` AS size,qco.qty
FROM `tb_qc_sni_out_det` qco
INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec_det`=qco.`id_prod_order_rec_det`
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE qco.id_qc_sni_out='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Private Sub BAddProduct_Click(sender As Object, e As EventArgs) Handles BAddProduct.Click
        FormPopUpRecQC.id_pop_up = "5"
        FormPopUpRecQC.ShowDialog()
    End Sub

    Private Sub BDeleteProduct_Click(sender As Object, e As EventArgs) Handles BDeleteProduct.Click
        If GVDetail.RowCount > 0 Then
            GVDetail.DeleteSelectedRows()
            can_scan()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVDetail.OptionsBehavior.Editable = False
        ControlBox = False
        BAddProduct.Enabled = False
        BDeleteProduct.Enabled = False
        newRowsBc()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "product_full_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BAddProduct.Enabled = True
        BDeleteProduct.Enabled = True
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
            PanelControl1.Visible = True
        Else
            BDelete.Enabled = True
            PanelControl1.Visible = False
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
            deleteRowsBc()
            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_prod_order_det)
            End If
            allowDelete()
        End If
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_prod_order_det", id_prod_order_detx)
        GVDetail.SetFocusedRowCellValue("qty", tot)
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS product_full_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
        allowDelete()
    End Sub

    Private Sub GVBarcode_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("product_full_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        For i As Integer = 0 To (GVDetail.RowCount - 1)
            Dim code As String = GVDetail.GetRowCellValue(i, "product_full_code").ToString
            id_prod_order_det = GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("product_full_code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            countQty(id_prod_order_det)
            newRowsBc()
            allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub can_scan()
        If GVDetail.RowCount > 0 Then
            GroupControlListBarcode.Enabled = True
            SLEVendor.Properties.ReadOnly = True
        Else
            GroupControlListBarcode.Enabled = False
            SLEVendor.Properties.ReadOnly = False
        End If
    End Sub

    Dim cond_check As Boolean = True
    Dim sample_check As String
    Dim qty_pl As Decimal
    Dim allow_sum As Decimal
    Dim id_rec_check As String
    Dim id_po_check As String

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal id_prod_order_rec_cek As String, ByVal id_prod_order_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name

        'Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '" + id_prod_order_ret_out + "', '0','0', '0', '0') "
        'Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")

        Dim q_check As String = "CALL view_limit_prod_rec('" + id_prod_order_rec_cek + "','" + id_prod_order_cek + "', '" + id_prod_order_det_cek + "', '0', '0','0', '0', '0')"
        Dim data As DataTable = execute_query(q_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpProdDet.id_pop_up = "6"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order_rec = id_rec_check
        FormPopUpProdDet.id_prod_order = id_po_check
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek dengan requisition di DB
        For i As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
            Dim id_prod_order_det_cekya As String = GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim id_prod_order_rec_cekya As String = GVDetail.GetRowCellValue(i, "id_prod_order_rec").ToString
            id_rec_check = GVDetail.GetRowCellValue(i, "id_prod_order_rec").ToString
            Dim id_prod_order_cekya As String = GVDetail.GetRowCellValue(i, "id_prod_order").ToString
            id_po_check = GVDetail.GetRowCellValue(i, "id_prod_order").ToString
            Dim qty_plya As String = GVDetail.GetRowCellValue(i, "qty").ToString
            Dim sample_checkya As String = GVDetail.GetRowCellValue(i, "name").ToString + " / Size : " + GVDetail.GetRowCellValue(i, "size").ToString
            isAllowRequisition(sample_checkya, id_prod_order_det_cekya, id_prod_order_rec_cekya, id_prod_order_cekya, qty_plya)
            If Not cond_check Then
                Exit For
            End If
        Next

        If GVDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            errorCustom("Product : '" + sample_check + "' cannot exceed " + allow_sum.ToString("F2") + ", please check ! ")
            infoQty()
        Else
            Dim query As String = ""

            If id = "-1" Then 'new
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'BtnSave.Enabled = False
                        'prod_order_ret_out_number = header_number_prod("4")

                        ''Main tbale
                        'query = "INSERT INTO tb_prod_order_ret_out(id_prod_order,id_prod_order_rec, prod_order_ret_out_number, id_comp_contact_to, id_comp_contact_from, prod_order_ret_out_date, prod_order_ret_out_due_date, prod_order_ret_out_note, id_report_status,id_ovh_price,id_return_qc_type) "
                        'query += "VALUES('" + id_prod_order + "','" + id_prod_order_rec + "', '" + prod_order_ret_out_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + prod_order_ret_out_due_date + "', '" + prod_order_ret_out_note + "', '" + id_report_status + "'," & id_ovh_price & ",'" & id_return_qc_type & "') ; SELECT LAST_INSERT_ID(); "
                        'id_prod_order_ret_out = execute_query(query, 0, True, "", "", "", "")

                        ''insert who prepared
                        'increase_inc_prod("4")
                        'insert_who_prepared("31", id_prod_order_ret_out, id_user)

                        ''Detail return
                        'For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                        '    Try
                        '        id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                        '        prod_order_ret_out_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_qty").ToString)
                        '        prod_order_ret_out_det_note = GVRetDetail.GetRowCellValue(j, "prod_order_ret_out_det_note").ToString
                        '        query = "INSERT tb_prod_order_ret_out_det(id_prod_order_ret_out, id_prod_order_det, prod_order_ret_out_det_qty,ovh_price, prod_order_ret_out_det_note) "
                        '        query += "VALUES('" + id_prod_order_ret_out + "', '" + id_prod_order_det + "', '" + prod_order_ret_out_det_qty + "','" + decimalSQL(GVRetDetail.GetRowCellValue(j, "ovh_price").ToString) + "', '" + prod_order_ret_out_det_note + "') "
                        '        execute_non_query(query, True, "", "", "", "")
                        '    Catch ex As Exception
                        '        stopCustom(ex.ToString)
                        '    End Try
                        'Next

                        ''submit
                        'submit_who_prepared("31", id_prod_order_ret_out, id_user)

                        'FormProductionRet.viewRetOut()
                        'FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", id_prod_order_ret_out)
                        'actionLoad()
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try
                    Cursor = Cursors.Default
                End If
            Else 'update
                'you cant update
            End If
        End If
    End Sub

    Private Sub GVDetail_DoubleClick(sender As Object, e As EventArgs) Handles GVDetail.DoubleClick
        If GVDetail.RowCount > 0 Then
            id_rec_check = GVDetail.GetFocusedRowCellValue("id_prod_order_rec").ToString
            id_po_check = GVDetail.GetFocusedRowCellValue("id_prod_order").ToString
            infoQty()
        End If
    End Sub
End Class