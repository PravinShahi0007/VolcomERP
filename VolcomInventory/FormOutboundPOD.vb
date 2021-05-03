Public Class FormOutboundPOD
    Private Sub FormOutboundPOD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        view_type()
        view3pl()
        load_group_store()
        view_city()
    End Sub

    Sub view_type()
        Dim q2 As String = "
            SELECT 3 AS id_type, 'Offline + Online' `type` UNION ALL
            SELECT 1 AS id_type, 'Offline' `type` UNION ALL
            SELECT 2 AS id_type, 'Online' `type`
        "
        viewSearchLookupQuery(SLEOnlineOffline, q2, "id_type", "type", "id_type")
    End Sub

    Sub view3pl()
        Dim query As String = "
            SELECT 0 AS id_3pl, 'All' AS 3pl
            UNION ALL
            SELECT id_comp AS id_3pl, comp_name AS 3pl
            FROM tb_m_comp
            WHERE id_comp_cat = 7
        "

        viewSearchLookupQuery(SLUE3PL, query, "id_3pl", "3pl", "id_3pl")
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub view_city()
        Dim query As String = "SELECT 0 AS `id_city`, 'All' AS `city`
UNION ALL
SELECT c.id_city, c.city 
FROM tb_m_city c "
        viewSearchLookupQuery(SLECity, query, "id_city", "city", "id_city")
    End Sub

    Sub viewData()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim condition As String = "AND (d.pl_sales_order_del_date>='" + date_from_selected + "'AND d.pl_sales_order_del_date<='" + date_until_selected + "') "

        'cond type
        If SLEOnlineOffline.EditValue.ToString <> "3" Then
            condition += "AND c.id_commerce_type='" + SLEOnlineOffline.EditValue.ToString + "' "
        End If
        'cond 3pl
        If SLUE3PL.EditValue.ToString <> "0" Then
            condition += "AND tpl.id_comp='" + SLUE3PL.EditValue.ToString + "' "
        End If
        'comp group
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            condition += "AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "' "
        End If
        'city
        If SLECity.EditValue.ToString <> "0" Then
            condition += "AND ct.id_city='" + SLECity.EditValue.ToString + "' "
        End If

        Dim query As String = "CALL view_outbound_pod(""" + condition + """)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormOutboundPOD_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormOutboundPOD_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBViewOutbound_Click(sender As Object, e As EventArgs) Handles SBViewOutbound.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub DETo_EditValueChanged(sender As Object, e As EventArgs) Handles DETo.EditValueChanged
        resetView()
    End Sub

    Private Sub SLEOnlineOffline_EditValueChanged(sender As Object, e As EventArgs) Handles SLEOnlineOffline.EditValueChanged
        resetView()
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        resetView()
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        resetView()
    End Sub

    Private Sub SLECity_EditValueChanged(sender As Object, e As EventArgs) Handles SLECity.EditValueChanged
        resetView()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class