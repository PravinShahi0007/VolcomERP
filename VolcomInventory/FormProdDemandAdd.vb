Public Class FormProdDemandAdd
    Dim id_season As String = FormProdDemandSingle.id_season
    Dim id_division As String = FormProdDemandSingle.LESampleDivision.EditValue.ToString

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name`, dv.id_division, dv.division
        FROM tb_m_design d
        INNER JOIN (
	        SELECT dc.id_design, cd.id_code_detail AS `id_division`,UPPER(cd.display_name) AS `division` 
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=32
	        GROUP BY dc.id_design
        ) dv ON dv.id_design = d.id_design
        WHERE d.id_lookup_status_order<>2
        AND d.id_season=" + id_season + "
        AND dv.id_division=" + id_division + "
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormProdDemandAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormProdDemandAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        Dim dsg_cek As String = "pdd.id_design=" + GVData.GetFocusedRowCellValue("id_design").ToString + " "

        'cek design yg ada di PD
        Dim qd As String = "SELECT pd.prod_demand_number, d.design_code AS `code`, d.design_display_name AS `name` 
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
        WHERE pd.is_pd=1 AND pd.id_report_status!=5 AND pdd.is_void=2
        AND (" + dsg_cek + ")
        ORDER BY pd.id_prod_demand ASC "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        If dd.Rows.Count > 0 Then
            FormFGLineListPDExist.dt = dd
            FormFGLineListPDExist.ShowDialog()
            Cursor = Cursors.Default
            Exit Sub
        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        choose()
    End Sub
End Class