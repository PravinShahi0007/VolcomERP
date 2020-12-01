﻿Public Class FormOLStoreRestock
    Public id_oos As String = "-1"
    Public id_web_order As String = "-1"
    Public id_product As String = "-1"
    Public product_code As String = ""
    Public product_name As String = ""
    Public product_size As String = ""
    Public id_design_cat As String = "-1"
    Public id_comp_group As String = "-1"
    Dim id_gol_use_induk As String = "-1"
    Dim id_gol As String = "-1"

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
        Dim query_gol As String = "SELECT wh_normal.id_wh_group AS `id_comp_normal_induk`,wh_normal.id_comp AS `id_comp_normal`,
        wh_sale.id_wh_group AS `id_comp_sale_induk`, wh_sale.id_comp AS `id_comp_sale`
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp_contact whc_normal ON whc_normal.id_comp_contact = cg.id_wh_order_contact_normal
        INNER JOIN tb_m_comp wh_normal ON wh_normal.id_comp = whc_normal.id_comp
        INNER JOIN tb_m_comp_contact whc_sale ON whc_sale.id_comp_contact = cg.id_wh_order_contact_sale
        INNER JOIN tb_m_comp wh_sale ON wh_sale.id_comp = whc_sale.id_comp
        WHERE cg.id_comp_group='" + id_comp_group + "'; "
        Dim data_gol As DataTable = execute_query(query_gol, -1, True, "", "", "", "")
        If id_design_cat = "1" Then
            id_gol_use_induk = data_gol.Rows(0)("id_comp_normal_induk").ToString
            id_gol = data_gol.Rows(0)("id_comp_normal").ToString
        Else
            id_gol_use_induk = data_gol.Rows(0)("id_comp_sale_induk").ToString
            id_gol = data_gol.Rows(0)("id_comp_sale").ToString
        End If
        'gudang omline
        viewStockGOL()
        'gudang lain
        viewStockOther()
        Cursor = Cursors.Default
    End Sub

    Sub viewStockGOL()
        Cursor = Cursors.WaitCursor
        GCOnlineWH.DataSource = dataStockGOL()
        GVOnlineWH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewStockOther()

    End Sub

    Function dataStockGOL() As DataTable
        Dim query As String = "SELECT fg.id_wh_drawer, wh.id_comp, wh.comp_number, wh.comp_name, 
        SUM(IF(fg.id_storage_category='2', CONCAT('-', fg.storage_product_qty), fg.storage_product_qty)) AS `total_stock`, 0 AS `total_order`, 'OK' AS `note`
        FROM tb_storage_fg fg 
        INNER JOIN tb_m_wh_drawer drw ON fg.id_wh_drawer = drw.id_wh_drawer 
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator 
        INNER JOIN tb_m_comp wh ON wh.id_comp = loc.id_comp AND wh.id_wh_group='" + id_gol_use_induk + "'
        WHERE fg.id_product='" + id_product + "'
        GROUP BY wh.id_comp
        HAVING total_stock>0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

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

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVOnlineWH)
            GCOnlineWH.RefreshDataSource()
            GVOnlineWH.RefreshData()


            If checkValidQtyRestock() Then
                'check stock
                Dim dts As DataTable = dataStockGOL()
                For c As Integer = 0 To GVOnlineWH.RowCount - 1
                    Dim id_drawer_cek As String = GVOnlineWH.GetRowCellValue(c, "id_wh_drawer").ToString
                    Dim dts_filter As DataRow() = dts.Select("[id_wh_drawer]='" + id_drawer_cek + "' ")
                    If dts_filter.Length <= 0 Then
                        GVOnlineWH.SetRowCellValue(c, "total_stock", 0)
                    Else
                        GVOnlineWH.SetRowCellValue(c, "total_stock", dts_filter(0)("total_stock"))
                    End If

                    If GVOnlineWH.GetRowCellValue(c, "total_order") <= GVOnlineWH.GetRowCellValue(c, "total_stock") Then
                        GVOnlineWH.SetRowCellValue(c, "note", "OK")
                    Else
                        GVOnlineWH.SetRowCellValue(c, "note", "Not Valid")
                    End If
                Next
                Dim cond_stock As Boolean = True
                GVOnlineWH.ActiveFilterString = "[note]<>'OK'"
                If GVOnlineWH.RowCount > 0 Then
                    cond_stock = False
                Else
                    cond_stock = True
                End If
                makeSafeGV(GVOnlineWH)

                If cond_stock Then
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    For i As Integer = 0 To GVOnlineWH.RowCount - 1
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Restock " + (i + 1).ToString + "/" + GVOnlineWH.RowCount.ToString)
                        Dim id_wh_from As String = GVOnlineWH.GetRowCellValue(i, "id_comp").ToString
                        Dim id_product As String = id_product
                        Dim qty As String = decimalSQL(GVOnlineWH.GetRowCellValue(i, "total_order").ToString)
                        execute_non_query_long("CALL create_oos_restock_wh_ol_grp(" + id_oos + ", " + id_wh_from + ", " + id_gol + ", " + id_product + ", '" + qty + "');", True, "", "", "", "")
                    Next
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    Close()
                Else
                    stopCustom("Qty restock exceed available qty")
                End If
            Else
                stopCustom("Already on process restock")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Function checkValidQtyRestock() As Boolean
        Dim total_order As Decimal = GVOnlineWH.Columns("total_order").SummaryItem.SummaryValue
        Dim query_tot As String = "SELECT IFNULL(SUM(od.ol_order_qty - od.sales_order_det_qty),0) AS `total_oos`, 
        IFNULL(op.total_restock_open,0) AS `total_restock_open`,
        IFNULL(cl.total_restock_close,0) AS `total_restock_close`,
        CAST(((SUM(od.ol_order_qty - od.sales_order_det_qty))-(IFNULL(op.total_restock_open,0) + IFNULL(cl.total_restock_close,0))) AS DECIMAL(10,0)) AS `total_allowed`
        FROM tb_ol_store_order od 
        LEFT JOIN (
	        SELECT sod.id_product, SUM(sod.sales_order_det_qty) AS `total_restock_open`
	        FROM tb_sales_order so
	        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        WHERE so.id_report_status=6 AND so.id_prepare_status=1 AND so.id_ol_store_oos='" + id_oos + "' AND sod.id_product='" + id_product + "'
        ) op ON op.id_product = od.id_product
        LEFT JOIN (
	        SELECT td.id_product, SUM(td.fg_trf_det_qty) AS `total_restock_close`
	        FROM tb_sales_order so
	        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        INNER JOIN tb_fg_trf_det td ON td.id_sales_order_det = sod.id_sales_order_det
	        INNER JOIN tb_fg_trf t ON t.id_fg_trf = td.id_fg_trf
	        WHERE so.id_report_status=6 AND so.id_prepare_status=2
	        AND t.id_report_status=6  
	        AND so.id_ol_store_oos='" + id_oos + "' AND td.id_product='" + id_product + "'
        ) cl ON cl.id_product = od.id_product
        WHERE od.id='" + id_web_order + "' AND od.id_comp_group='" + id_comp_group + "' AND od.id_product='" + id_product + "' "
        Dim data_tot As DataTable = execute_query(query_tot, -1, True, "", "", "", "")
        If total_order <= data_tot.Rows(0)("total_allowed") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class