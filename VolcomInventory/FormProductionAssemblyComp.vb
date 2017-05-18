Public Class FormProductionAssemblyComp
    Public id_prod_ass_det As String = "-1"

    Private Sub FormProductionAssemblyComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Sub viewDesign()
        Dim query As String = "SELECT po.id_prod_order, pdd.id_design, d.design_code AS `code`, d.design_display_name AS `name`
        FROM tb_prod_order po 
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        WHERE po.id_report_status=3 OR po.id_report_status=4 
        ORDER BY po.id_prod_order ASC "
        viewSearchLookupQuery(SLEDesignStockStore, query, "id_prod_order", "name", "id_prod_order")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Focus()
        GVData.FocusedColumn = GVData.Columns("qty_sel")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProductionAssemblyComp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[qty_sel]>0"
        If GVData.RowCount > 0 Then
            'cek
            Dim dt_cek As DataTable = execute_query("CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)", -1, True, "", "", "", "")
            Dim cond_check_data As Boolean = True
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                Dim id_prod_order_det_cekya As String = GVData.GetRowCellValue(i, "id_prod_order_det").ToString
                Dim qty_cek As Integer = GVData.GetRowCellValue(i, "qty_sel")
                Dim info_str As String = ""

                Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
                If qty_cek > data_filter_cek(0)("qty") Then
                    info_str = "Can't exceed " + Decimal.Parse(data_filter_cek(0)("qty").ToString).ToString("n0") + ";"
                    cond_check_data = False
                Else
                    GVData.SetRowCellValue(i, "info", "")
                End If
                GVData.SetRowCellValue(i, "info", info_str)
            Next
            GCData.RefreshDataSource()
            GVData.RefreshData()

            If Not cond_check_data Then
                GridColumnInfo.VisibleIndex = 100
                stopCustom("Please see notice in 'info' column.")
            Else
                GridColumnInfo.Visible = False
                infoCustom("ok")
            End If
        Else
            stopCustom("No item selected")
            makeSafeGV(GVData)
        End If
        Cursor = Cursors.Default
    End Sub
End Class