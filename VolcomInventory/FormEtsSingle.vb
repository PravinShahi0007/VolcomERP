Public Class FormEtsSingle
    Public id_ets As String = FormEtsDet.id

    Private Sub FormEtsSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.number, p.effective_date, p.plan_end_date "
        query += qryFrom()
        query += "GROUP BY p.id_pp_change "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEtsSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function qryFrom()
        Dim effective_date As String = DateTime.Parse(FormEtsDet.DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim body As String = " FROM tb_pp_change p 
        INNER JOIN tb_pp_change_det pd ON pd.id_pp_change = p.id_pp_change AND (pd.propose_price_final>0 AND !ISNULL(pd.propose_price_final))
        LEFT JOIN (
	        SELECT p.* , LEFT(pt.design_price_type,1) AS `price_type`, cat.id_design_cat, LEFT(cat.design_cat,1) AS `design_cat`
	        FROM tb_m_design_price p
	        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
	        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = pt.id_design_cat
	        WHERE p.id_design_price IN (
		        SELECT MAX(p.id_design_price) FROM tb_m_design_price p
		        WHERE p.design_price_start_date<='" + effective_date + "' AND is_active_wh=1 AND is_design_cost=0
		        GROUP BY p.id_design
	        )
        ) prc ON prc.id_design = pd.id_design
        LEFT JOIN (
	         SELECT de.*, e.extended_eos
	         FROM tb_design_extended_eos de
	         INNER JOIN tb_lookup_extended_eos e ON e.id_extended_eos = de.id_extended_eos
	         WHERE de.id_design_extended_eos IN (
	            SELECT MAX(de.id_design_extended_eos) FROM tb_design_extended_eos de
	            WHERE de.start_date<='" + effective_date + "'
	            GROUP BY de.id_design
	         )
        ) de ON de.id_design = pd.id_design 
        LEFT JOIN tb_ets_det ed ON ed.id_pp_change_det = pd.id_pp_change_det AND ed.id_propose_type=1
        LEFT JOIN tb_ets ets ON ets.id_ets=ed.id_ets AND ets.id_report_status!=5
        WHERE p.id_design_mkd=1 AND p.id_report_status=6 AND p.id_pp_change>1 AND ISNULL(ets.id_ets) 
        AND IFNULL(prc.id_design_price_type,0)=3 AND IFNULL(de.id_extended_eos,2)=2 "
        Return body
    End Function

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        Dim id_pp_change As String = GVData.GetFocusedRowCellValue("id_pp_change").ToString
        Dim query As String = "INSERT INTO tb_ets_det(id_ets, id_pp_change_det, id_pp_change, id_design, id_design_price, design_price, id_propose_type) 
        SELECT '" + id_ets + "', pd.id_pp_change_det, pd.id_pp_change, pd.id_design, prc.id_design_price, prc.design_price, 1 "
        query += qryFrom()
        execute_non_query(query, True, "", "", "", "")
        FormEtsDet.viewDetailPTH()
        FormEtsDet.viewDetail(1)
        viewData()
        Cursor = Cursors.Default
    End Sub
End Class