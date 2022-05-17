Public Class FormDropChangesSingle
    Public id As String = "-1"
    Public id_season As String = "-1"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormDropChangesSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/dropchanges-product/" + id_season + "")
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
        cd.sht AS `design_sht`,  cd.color AS `design_color`, cp.id_critical_product, cp.critical_product AS `tags`
        FROM tb_m_design d 
        LEFT JOIN tb_drop_changes_det dd ON dd.id_design = d.id_design AND dd.id_drop_changes=1
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
End Class