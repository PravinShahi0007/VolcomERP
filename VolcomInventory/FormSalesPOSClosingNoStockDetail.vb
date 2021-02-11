Public Class FormSalesPOSClosingNoStockDetail
    Public id As String = "-1"
    Public id_sales_pos_prob As String = "-1"
    Public id_sales_pos As String = "-1"
    Public id_comp As String = "-1"
    Public id_product As String = "-1"
    Public id_design_price As String = "-1"
    Public id_product_valid As String = "-1"
    Public id_design_price_valid As String = "-1"
    Dim qty_max As Integer = 0

    Private Sub FormSalesPOSClosingNoStockDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
        actionLoad()
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_oos_final_cat`, '- Select Category -' AS `oos_final_cat`
        UNION ALL
        SELECT c.id_oos_final_cat, c.oos_final_cat 
        FROM tb_oos_final_cat c "
        viewSearchLookupQuery(SLEType, query, "id_oos_final_cat", "oos_final_cat", "id_oos_final_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Sub actionLoad()
        'get avail qty
        getMaxQty()
        TxtQty.EditValue = qty_max
        'set 0 type
        SLEType.EditValue = 0
        'reset
        resetControl(False)
        'focus
        ActiveControl = TxtQty
    End Sub

    Sub resetControl(ByVal is_not_include_sku As Boolean)
        id_product_valid = "-1"
        If Not is_not_include_sku Then
            TXTSKUValid.Text = ""
        End If
        TxtNameValid.Text = ""
        TxtSizeValid.Text = ""
        id_design_price_valid = "-1"
        TxtPriceValid.EditValue = 0.00
        MeNote.Text = ""
    End Sub

    Sub getMaxQty()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_sales_pos_prob, (p.no_stock_qty-IFNULL(rcn.qty_on_process,0)) AS `avail_qty`
        FROM tb_sales_pos_prob p
        LEFT JOIN (
          SELECT rd.id_sales_pos_prob, SUM(rd.qty) AS `qty_on_process`
          FROM tb_sales_pos_oos_recon_det rd
          INNER JOIN tb_sales_pos_oos_recon r ON r.id_sales_pos_oos_recon = rd.id_sales_pos_oos_recon
          WHERE rd.id_sales_pos_prob=" + id_sales_pos_prob + " AND r.id_report_status!=5 
          GROUP BY rd.id_sales_pos_prob
        ) rcn ON rcn.id_sales_pos_prob = p.id_sales_pos_prob
        WHERE p.id_sales_pos_prob=" + id_sales_pos_prob + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        qty_max = data.Rows(0)("avail_qty")
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty.EditValueChanged
        Dim old_value As Integer = TxtQty.OldEditValue
        If TxtQty.EditValue > qty_max Then
            stopCustom("Can't exceed " + qty_max.ToString)
            TxtQty.EditValue = old_value
        End If
        SLEType.EditValue = 0
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If TxtQty.EditValue <= 0 Then
            stopCustom("Please input qty")
        ElseIf id_product_valid = "-1" Or id_design_price_valid = "-1" Or SLEType.EditValue = 0 Then
            stopCustom("Please input all field")
        Else
            'insert
            Dim query As String = "INSERT INTO tb_sales_pos_oos_recon_det(id_sales_pos_oos_recon, id_sales_pos_prob, id_sales_pos, id_comp, id_product, id_design_price, design_price, qty, id_oos_final_cat, id_product_valid, id_design_price_valid, design_price_valid, qty_valid, note)
            VALUES('" + id + "', '" + id_sales_pos_prob + "', '" + id_sales_pos + "', '" + id_comp + "', '" + id_product + "', '" + id_design_price + "', '" + decimalSQL(TxtPrice.EditValue.ToString) + "', '" + decimalSQL(TxtQty.EditValue.ToString) + "', '" + SLEType.EditValue.ToString + "', '" + id_product_valid + "', '" + id_design_price_valid + "', '" + decimalSQL(TxtPriceValid.EditValue.ToString) + "', '" + decimalSQL(TxtQty.EditValue.ToString) + "', '" + addSlashes(MeNote.Text.ToString) + "'); "
            execute_non_query(query, True, "", "", "", "")
            'refresh main view
            FormSalesPOSClosingNoStock.XTCClosing.SelectedTabPageIndex = 1
            FormSalesPOSClosingNoStock.viewDetail()
            'refresh form
            actionLoad()
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        If SLEType.EditValue.ToString = "1" Then
            'cancel sales
            resetControl(False)
            TXTSKUValid.Properties.ReadOnly = True
            'isi dengan product yang sama
            id_product_valid = id_product
            TXTSKUValid.Text = TxtSKU.Text
            TxtNameValid.Text = TxtName.Text
            TxtSizeValid.Text = TxtSize.Text
            id_design_price_valid = id_design_price
            TxtPriceValid.EditValue = TxtPrice.EditValue
        ElseIf SLEType.EditValue.ToString = "2" Then
            'changes item
            resetControl(False)
            TXTSKUValid.Properties.ReadOnly = False
        Else
            resetControl(False)
            TXTSKUValid.Properties.ReadOnly = True
        End If
    End Sub

    Private Sub TXTSKUValid_EditValueChanged(sender As Object, e As EventArgs) Handles TXTSKUValid.EditValueChanged

    End Sub

    Private Sub TXTSKUValid_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTSKUValid.KeyDown
        If e.KeyCode = Keys.Enter Then
            If SLEType.EditValue.ToString = "2" And TxtSKU.Text <> "" Then
                'get product
                Dim qp As String = "SELECT p.id_product, p.id_design, p.product_name, cd.code_detail_name AS `size`
                FROM tb_m_product p 
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                INNER JOIN tb_m_design d ON d.id_design = p.id_design
                WHERE p.product_full_code='" + addSlashes(TXTSKUValid.Text) + "' AND d.id_lookup_status_order!=2 "
                Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
                If dp.Rows.Count <= 0 Then
                    stopCustom("Product not found")
                    TXTSKUValid.Text = ""
                Else
                    Dim id_design_found As String = dp.Rows(0)("id_design").ToString
                    Dim id_product_found As String = dp.Rows(0)("id_product").ToString
                    'check price
                    Dim cond_price As Boolean = True
                    Dim query_prc As String = "SELECT IFNULL(prc.id_design_price,0) AS `id_design_price`, prc.design_price 
                    FROM tb_m_design_price prc 
                    WHERE prc.id_design=" + id_design_found + " 
                    AND prc.design_price_start_date<=(SELECT sp.sales_pos_end_period FROM tb_sales_pos sp WHERE sp.id_sales_pos=" + id_sales_pos + ")
                    ORDER BY prc.id_design_price DESC LIMIT 1 "
                    Dim data_prc As DataTable = execute_query(query_prc, -1, True, "", "", "", "")
                    If data_prc.Rows.Count <= 0 Then
                        cond_price = False
                    Else
                        If data_prc.Rows(0)("id_design_price").ToString = "0" Then
                            cond_price = False
                        End If
                    End If

                    'check stock
                    Dim cond_stock As Boolean = True
                    Dim qst As String = "SELECT IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `qty_avail`
                    FROM tb_storage_fg f
                    WHERE f.id_product='" + id_product_found + "' AND f.id_wh_drawer=(SELECT c.id_drawer_def FROM tb_m_comp c WHERE c.id_comp=" + id_comp + ") "
                    Dim dst As DataTable = execute_query(qst, -1, True, "", "", "", "")
                    Dim qty_avail As Integer = 0
                    If dst.Rows.Count <= 0 Then
                        qty_avail = 0
                    Else
                        qty_avail = dst.Rows(0)("qty_avail")
                    End If
                    If TxtQty.EditValue > qty_avail Then
                        cond_stock = False
                    End If
                    'MsgBox(qty_avail.ToString)
                    'MsgBox(qty_max.ToString)

                    If Not cond_price Then
                        stopCustom("Price not found")
                    ElseIf Not cond_stock Then
                        stopCustom("Stock not available")
                    Else
                        id_product_valid = id_product_found
                        TxtNameValid.Text = dp.Rows(0)("product_name").ToString
                        TxtSizeValid.Text = dp.Rows(0)("size").ToString
                        id_design_price_valid = data_prc.Rows(0)("id_design_price").ToString
                        TxtPriceValid.EditValue = data_prc.Rows(0)("design_price")
                        MeNote.Focus()
                    End If
                End If
            End If
        Else
            resetControl(True)
        End If
    End Sub
End Class