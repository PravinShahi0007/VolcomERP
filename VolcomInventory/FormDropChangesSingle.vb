Public Class FormDropChangesSingle
    Public id As String = "-1"
    Public id_season As String = "-1"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormDropChangesSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/dropchanges-product/" + id_season + "")
        viewData()
        viewStt()
        viewSeasonMove()
    End Sub

    Sub viewStt()
        viewSearchLookupQueryO(SLEStatus, volcomErpApiGetDT(dt_json, 0), "id_lookup_status_order", "lookup_status_order", "id_lookup_status_order")
        'SLEStatus.EditValue = Nothing
    End Sub

    Sub viewSeasonMove()
        viewSearchLookupQueryO(SLESeasonMove, volcomErpApiGetDT(dt_json, 1), "id_delivery", "season_del", "id_delivery")
        SLESeasonMove.EditValue = Nothing
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'No' AS `is_select`,d.id_design, d.design_code, cd.class AS `design_class`, d.design_display_name AS `design_desc`,
        cd.sht AS `design_sht`,  cd.color AS `design_color`, cp.id_critical_product, cp.critical_product AS `tags`, d.id_delivery,sd.delivery,
        po.id_prod_order, SUM(pod.prod_order_qty) AS `total_qty`, IFNULL(ppd.price,0.00) AS `final_price`, pdd.prod_demand_design_propose_price AS `estimate_price`
        FROM tb_m_design d 
        INNER JOIN tb_lookup_critical_product cp ON cp.id_critical_product = d.id_critical_product
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_design = d.id_design AND pdd.is_void=2
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.id_report_status=6
        INNER JOIN tb_prod_order po ON po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status=6
        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
        LEFT JOIN tb_fg_propose_price_detail ppd ON ppd.id_design = d.id_design AND ppd.is_active=1
        LEFT JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price AND pp.id_report_status=6
        LEFT JOIN tb_drop_changes_det dd ON dd.id_design = d.id_design AND dd.id_drop_changes=" + id + "
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        WHERE d.id_season=" + id_season + " AND ISNULL(dd.id_design) AND d.id_lookup_status_order!=2
        GROUP BY d.id_design
        ORDER BY id_critical_product ASC,design_class ASC, design_desc ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStatus_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStatus.EditValueChanged
        Dim id_stt As String = "0"
        Try
            id_stt = SLEStatus.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_stt = "3" Then
            PanelControlMove.Visible = True
        Else
            PanelControlMove.Visible = False
        End If
    End Sub

    Sub resetView()
        Cursor = Cursors.WaitCursor
        CESelectAll.EditValue = False
        viewData()
        SLESeasonMove.EditValue = Nothing
        DEInStoreDate.EditValue = Nothing
        MEReason.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i As Integer = 0 To GVData.RowCount - 1
            If CESelectAll.EditValue = True Then
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub SLESeasonMove_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeasonMove.EditValueChanged
        Dim id_ss As String = "0"
        Try
            id_ss = SLESeasonMove.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_ss = "0" Then
            DEInStoreDate.EditValue = Nothing
        Else
            Try
                DEInStoreDate.EditValue = SLESeasonMove.Properties.View.GetFocusedRowCellValue("in_store_date")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnAddProduct_Click(sender As Object, e As EventArgs) Handles BtnAddProduct.Click
        Dim id_stt As String = SLEStatus.EditValue.ToString
        Dim reason As String = addSlashes(MEReason.Text)
        GVData.ActiveFilterString = "[is_select]='Yes' "

        'cek note
        If reason = "" Or GVData.RowCount <= 0 Or SLESeasonMove.EditValue = Nothing Then
            warningCustom("Please input all data")
            GVData.ActiveFilterString = ""
            Exit Sub
        End If

        'cek gk ada yg dicentang
        If GVData.RowCount <= 0 Then
            warningCustom("Please select product first")
            GVData.ActiveFilterString = ""
            Exit Sub
        End If

        'cek delivery sama
        Dim design_same_del As String = ""
        Dim id_del_select As String = SLESeasonMove.EditValue.ToString
        For d As Integer = 0 To GVData.RowCount - 1
            Dim id_del_cek As String = GVData.GetRowCellValue(d, "id_delivery").ToString
            If id_del_cek = id_del_select Then
                design_same_del += "=> " + GVData.GetRowCellValue(d, "design_class").ToString + " - " + GVData.GetRowCellValue(d, "design_desc").ToString + " - " + GVData.GetRowCellValue(d, "design_color").ToString + System.Environment.NewLine
            End If
        Next
        If design_same_del <> "" Then
            warningCustom("Please select different delivery : " + System.Environment.NewLine + design_same_del)
            GVData.ActiveFilterString = ""
            Exit Sub
        End If

        'select
        Cursor = Cursors.WaitCursor
        Dim query_ins As String = "INSERT INTO tb_drop_changes_det(id_drop_changes, id_design, id_season_from, id_delivery_from, id_season_to, id_delivery_to, id_lookup_status_order, reason, id_prod_order, total_qty, final_price, estimate_price) VALUES "
        For a As Integer = 0 To GVData.RowCount - 1
            If a > 0 Then
                query_ins += ","
            End If

            Dim id_design As String = GVData.GetRowCellValue(a, "id_design").ToString
            Dim id_season_from As String = id_season
            Dim id_delivery_from As String = GVData.GetRowCellValue(a, "id_delivery").ToString
            Dim id_season_to As String = ""
            Dim id_delivery_to As String = ""
            If id_stt = 2 Then
                'drop
                id_season_to = id_season_from
                id_delivery_to = id_delivery_from
            Else
                'move
                id_season_to = SLESeasonMove.Properties.View.GetFocusedRowCellValue("id_season").ToString
                id_delivery_to = SLESeasonMove.EditValue.ToString
            End If
            Dim id_prod_order As String = GVData.GetRowCellValue(a, "id_prod_order").ToString
            Dim total_qty As String = decimalSQL(GVData.GetRowCellValue(a, "total_qty").ToString)
            Dim final_price As String = decimalSQL(GVData.GetRowCellValue(a, "final_price").ToString)
            Dim estimate_price As String =decimalSQL(GVData.GetRowCellValue(a, "estimate_price").ToString)
            query_ins += "(" + id + ", '" + id_design + "', '" + id_season_from + "', '" + id_delivery_from + "', '" + id_season_to + "', '" + id_delivery_to + "', '" + id_stt + "', '" + reason + "', '" + id_prod_order + "', '" + total_qty + "', '" + final_price + "', '" + estimate_price + "') "
        Next
        If GVData.RowCount > 0 Then
            execute_non_query(query_ins, True, "", "", "", "")
        End If
        FormDropChangesDet.viewDetail()
        GVData.ActiveFilterString = ""
        resetView()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDropChangesSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub RepoBtnHistory_Click(sender As Object, e As EventArgs) Handles RepoBtnHistory.Click
        If GVData.RowCount > 0 And GVData.FocusedRowModified >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDropChangesMoveHistory.id_design = GVData.GetFocusedRowCellValue("id_design").ToString
            FormDropChangesMoveHistory.id_exclude = id
            FormDropChangesMoveHistory.Text = FormDropChangesMoveHistory.Text + " : " + GVData.GetFocusedRowCellValue("design_code").ToString + " - " + GVData.GetFocusedRowCellValue("design_class").ToString + " - " + GVData.GetFocusedRowCellValue("design_desc").ToString + " - " + GVData.GetFocusedRowCellValue("design_color").ToString
            FormDropChangesMoveHistory.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class