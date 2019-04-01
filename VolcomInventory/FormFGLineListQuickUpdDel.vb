Public Class FormFGLineListQuickUpdDel
    Private Sub FormFGLineListQuickUpdDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDel()
        viewRetCode()
        viewData()
    End Sub

    Private Sub FormFGLineListQuickUpdDel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDel()
        Dim query As String = "SELECT * FROM tb_season_delivery WHERE id_season='" + FormFGLineList.SLESeason.EditValue.ToString + "' ORDER BY id_delivery ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoDel.DataSource = Nothing
        RepoDel.DataSource = data
        RepoDel.DisplayMember = "delivery"
        RepoDel.ValueMember = "id_delivery"
    End Sub

    Sub viewRetCode()
        Dim query As String = "SELECT * FROM tb_lookup_ret_code ORDER BY id_ret_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoRetCode.DataSource = Nothing
        RepoRetCode.DataSource = data
        RepoRetCode.DisplayMember = "ret_code"
        RepoRetCode.ValueMember = "id_ret_code"
    End Sub

    Sub viewData()
        Dim query As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name`, 
        d.id_delivery, del.delivery, NULL AS `id_delivery_new`,
        d.id_ret_code , ret.ret_code, NULL AS `id_ret_code_new`,
        cls.class, dv.division
        FROM tb_m_design d
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_lookup_ret_code ret ON ret.id_ret_code = d.id_ret_code
        LEFT JOIN (
            SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
            FROM tb_m_design d
            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
            INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
            GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
            SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `division` 
            FROM tb_m_design d
            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
            INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=32
            GROUP BY d.id_design
        ) dv ON dv.id_design = d.id_design
        WHERE d.id_season='" + FormFGLineList.SLESeason.EditValue.ToString + "'
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub
End Class