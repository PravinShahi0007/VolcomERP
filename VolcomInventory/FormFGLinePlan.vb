Public Class FormFGLinePlan
    Private Sub FormFGLinePlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub FormFGLinePlan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGLinePlan_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT 'No' AS `is_select`,l.id_fg_line_plan, l.id_season, ss.season, l.id_delivery, del.delivery,
        l.id_division, UPPER(dv.display_name) AS `division`,
        l.id_category, cat.display_name AS `category`,
        l.id_source, UPPER(src.display_name) AS `source`,
        l.id_class, cls.display_name AS `class`,
        l.id_color, col.display_name AS `color`,
        l.description, l.`benchmark`, 
        l.qty, l.target_cost, l.target_price
        FROM tb_fg_line_plan l
        INNER JOIN tb_season ss ON ss.id_season = l.id_season
        INNER JOIN tb_season_delivery del ON del.id_delivery = l.id_delivery
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = l.id_division
        INNER JOIN tb_m_code_detail cat ON cat.id_code_detail = l.id_category
        INNER JOIN tb_m_code_detail src ON src.id_code_detail = l.id_source
        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = l.id_class
        INNER JOIN tb_m_code_detail col ON col.id_code_detail = l.id_color
        WHERE l.id_season=" + SLESeason.EditValue.ToString + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCData.DataSource = Nothing
    End Sub
End Class