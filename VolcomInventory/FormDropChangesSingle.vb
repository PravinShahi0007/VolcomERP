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
        SLEStatus.EditValue = Nothing
    End Sub

    Sub viewSeasonMove()
        viewSearchLookupQueryO(SLESeasonMove, volcomErpApiGetDT(dt_json, 1), "id_delivery", "season_del", "id_delivery")
        SLESeasonMove.EditValue = Nothing
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'No' AS `is_select`,d.id_design, d.design_code, cd.class AS `design_class`, d.design_display_name AS `design_desc`,
        cd.sht AS `design_sht`,  cd.color AS `design_color`, cp.id_critical_product, cp.critical_product AS `tags`, d.id_delivery
        FROM tb_m_design d 
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
        INNER JOIN tb_lookup_critical_product cp ON cp.id_critical_product = d.id_critical_product
        WHERE d.id_season=1 AND ISNULL(dd.id_design) AND d.id_lookup_status_order!=2
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
        SLEStatus.EditValue = Nothing
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
        If reason = "" Then
            warningCustom("Please input reason")
            Exit Sub
        End If

        'cek gk ada yg dicentang
        If GVData.RowCount <= 0 Then
            warningCustom("Please select product first")
            Exit Sub
        End If

        'cek pd jika drop
        Dim id_design_drop As String = ""
        If id_stt = "2" Then
            Cursor = Cursors.WaitCursor
            For d As Integer = 0 To GVData.RowCount - 1
                If d > 0 Then
                    id_design_drop += ","
                End If
                id_design_drop += GVData.GetRowCellValue(d, "id_design").ToString
            Next

            Dim qpd As String = "SELECT pdd.id_design, CONCAT(d.design_code,' -' ,cd.`class`,' - ',d.design_display_name,' - ', cd.color) AS `design_label`
            FROM tb_prod_demand_design pdd
            INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_report_status!=5
            INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
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
            WHERE pdd.is_void=2 AND pdd.id_design IN(" + id_design_drop + ")
            ORDER BY cd.`class` ASC, d.design_display_name ASC "
            Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
            If dpd.Rows.Count > 0 Then
                Dim drop_invalid As String = ""
                For i As Integer = 0 To dpd.Rows.Count - 1
                    If i > 0 Then
                        drop_invalid += System.Environment.NewLine
                    End If
                    drop_invalid += dpd.Rows(i)("design_label").ToString
                Next
                warningCustom("Please drop via PD Revision : " + System.Environment.NewLine + drop_invalid)
                Cursor = Cursors.Default
                Exit Sub
            End If
            Cursor = Cursors.Default
        End If

        'select
        Cursor = Cursors.WaitCursor
        Dim query_ins As String = "INSERT INTO tb_drop_changes_det(id_drop_changes, id_design, id_season_from, id_delivery_from, id_season_to, id_delivery_to, id_lookup_status_order, reason) VALUES "
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
            query_ins += "(" + id + ", '" + id_design + "', '" + id_season_from + "', '" + id_delivery_from + "', '" + id_season_to + "', '" + id_delivery_to + "', '" + id_stt + "', '" + reason + "') "
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