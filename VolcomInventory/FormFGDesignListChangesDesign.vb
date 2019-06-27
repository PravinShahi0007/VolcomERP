Public Class FormFGDesignListChangesDesign
    Private Sub FormFGDesignListChangesDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Private Sub FormFGDesignListChangesDesign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = ""
        'query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        'query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.is_md='" + FormFGDesignListChanges.is_md + "' "
        query += "ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name AS `name`, dr.id_design,
        pdd.id_prod_demand_design, IFNULL(po.id_prod_order,0) AS `id_prod_order`, IFNULL(po.id_report_status,0) AS `id_status_po`
        FROM tb_m_design d
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_design = d.id_design AND pdd.is_void=2
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1
        LEFT JOIN tb_prod_order po ON po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status!=5
        LEFT JOIN tb_m_design dr ON dr.id_design_rev_from = d.id_design AND dr.id_lookup_status_order=1
        WHERE d.id_season=" + id_ss + " AND ISNULL(dr.id_design) 
        HAVING id_status_po<>6 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMasterDesignSingle.id_pop_up = "5"
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.form_name = Name
            FormMasterDesignSingle.dupe = "1"
            Dim id_dsg_param As String = "-1"
            Try
                id_dsg_param = GVData.GetFocusedRowCellValue("id_design").ToString
            Catch ex As Exception
            End Try

            FormMasterDesignSingle.id_changes = FormFGDesignListChanges.id
            FormMasterDesignSingle.id_design_rev_from = id_dsg_param
            FormMasterDesignSingle.is_pcd = "1"
            FormMasterDesignSingle.id_design = id_dsg_param
            FormMasterDesignSingle.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class