Public Class FormOLStoreRestock
    Public id_product As String = "-1"
    Public product_code As String = ""
    Public product_name As String = ""
    Public product_size As String = ""
    Public id_design_cat As String = "-1"
    Public id_comp_group As String = "-1"
    Dim id_gol_use As String = "-1"

    Private Sub FormOLStoreRestock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'info
        TxtCode.Text = product_code
        TxtDescription.Text = product_name
        TxtSize.Text = product_size
        'cek gudang induk online
        Dim query_gol As String = "SELECT wh_normal.id_wh_group AS `id_comp_normal`, wh_sale.id_wh_group AS `id_comp_sale`
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp_contact whc_normal ON whc_normal.id_comp_contact = cg.id_wh_order_contact_normal
        INNER JOIN tb_m_comp wh_normal ON wh_normal.id_comp = whc_normal.id_comp
        INNER JOIN tb_m_comp_contact whc_sale ON whc_sale.id_comp_contact = cg.id_wh_order_contact_sale
        INNER JOIN tb_m_comp wh_sale ON wh_sale.id_comp = whc_sale.id_comp
        WHERE cg.id_comp_group='" + id_comp_group + "'; "
        Dim data_gol As DataTable = execute_query(query_gol, -1, True, "", "", "", "")
        If id_design_cat = "1" Then
            id_gol_use = data_gol.Rows(0)("id_comp_normal").ToString
        Else
            id_gol_use = data_gol.Rows(0)("id_comp_sale").ToString
        End If
        'gudang omline
        viewStockGOL()
        'gudang lain
        viewStockOther()
        Cursor = Cursors.Default
    End Sub

    Sub viewStockGOL()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT fg.id_wh_drawer, wh.id_comp, wh.comp_number, wh.comp_name, 
        SUM(IF(fg.id_storage_category='2', CONCAT('-', fg.storage_product_qty), fg.storage_product_qty)) AS `total_stock`, 0 AS `total_order`
        FROM tb_storage_fg fg 
        INNER JOIN tb_m_wh_drawer drw ON fg.id_wh_drawer = drw.id_wh_drawer 
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator 
        INNER JOIN tb_m_comp wh ON wh.id_comp = loc.id_comp AND wh.id_wh_group='" + id_gol_use + "'
        WHERE fg.id_product='" + id_product + "'
        GROUP BY fg.id_wh_drawer
        HAVING total_stock>0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOnlineWH.DataSource = data
        GVOnlineWH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewStockOther()

    End Sub

    Private Sub FormOLStoreRestock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 0 Then

        ElseIf XTCData.SelectedTabPageIndex = 1 Then

        End If
    End Sub

    Private Sub RepoSP_EditValueChanged(sender As Object, e As EventArgs) Handles RepoSP.EditValueChanged
        Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        Dim qty_rec As Decimal = SpQty.EditValue
        Dim qty_limit As Decimal = GVOnlineWH.GetFocusedRowCellValue("total_stock")
        If qty_rec > qty_limit Then
            stopCustom("Cannot exceed " + qty_limit.ToString + "")
            GVOnlineWH.SetFocusedRowCellValue("total_order", 0)
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewStockGOL()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCOnlineWH, "ONLINE WH STOCK LIST")
        Cursor = Cursors.Default
    End Sub
End Class