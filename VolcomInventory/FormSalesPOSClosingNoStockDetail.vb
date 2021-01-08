Public Class FormSalesPOSClosingNoStockDetail
    Public id As String = "-1"
    Public id_sales_pos_prob As String = "-1"
    Public id_sales_pos As String = "-1"
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
        'set 0 type
        SLEType.EditValue = 0
        'reset
        resetControl()
        'focus
        ActiveControl = TxtQty
    End Sub

    Sub resetControl()
        id_product_valid = "-1"
        TXTSKUValid.Text = ""
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
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click

    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        If SLEType.EditValue.ToString = "1" Then
            'cancel sales
            resetControl()
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
            resetControl()
            TXTSKUValid.Properties.ReadOnly = False
        Else
            resetControl()
            TXTSKUValid.Properties.ReadOnly = True
        End If
    End Sub

    Private Sub TXTSKUValid_EditValueChanged(sender As Object, e As EventArgs) Handles TXTSKUValid.EditValueChanged

    End Sub

    Private Sub TXTSKUValid_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTSKUValid.KeyDown
        If SLEType.EditValue.ToString = "2" And TxtSKU.Text <> "" Then
            'get product
            'get stock
        End If
    End Sub
End Class