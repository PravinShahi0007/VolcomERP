Public Class ReportPLMat
    Public pl_sample_purc_number As String
    Public pl_sample_purc_date As String
    Public source As String
    Public comp_from As String
    Public comp_to As String
    Public address_to As String
    Public Shared id_pl_mrs As String
    Public pl_sample_purc_note As String
    Public is_pre As String = "-1"
    Public is_sell As String = "-1"

    Sub viewPLMRS()
        Dim query As String = "CALL view_pl_mrs('" + id_pl_mrs + "','2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'query = "CALL view_pl_mrs_pcs('" & id_pl_mrs & "')"
        'Dim data_piece As DataTable = execute_query(query, -1, True, "", "", "", "")

        'Dim ds As New DataSet()
        'ds.Tables.AddRange(New DataTable() {data, data_piece})
        'ds.Relations.Add("Detail", data.Columns("id_mat_det"), data_piece.Columns("id_mat_det"))

        GCDetail.DataSource = data
        ExpandAllRows(GVDetail)
        '
        If is_sell = "1" Then
            GridColumnMatDetPrice.Visible = True
            GridColumnTotPrice.Visible = True
            GVDetail.OptionsView.ShowFooter = True
        Else
            GridColumnMatDetPrice.Visible = False
            GridColumnTotPrice.Visible = False
            GVDetail.OptionsView.ShowFooter = False
        End If
        '
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportPLSample_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'Fetch from db main
        Dim query As String = "SELECT i.id_prod_order,i.prod_order_mrs_number,m.design_name,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',m.design_name,' ',cd.color) AS design_display_name,k.prod_order_number,j.prod_order_wo_number,a.id_prod_order_mrs, a.id_pl_mrs ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_mrs_date, a.pl_mrs_note, a.pl_mrs_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_to, a.id_report_status, "
        query += "DATE_FORMAT(a.pl_mrs_date,'%Y-%m-%d') as pl_mrs_datex, k.prod_order_number "
        query += "FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "LEFT JOIN tb_prod_order_wo j ON j.id_prod_order_wo = i.id_prod_order_wo "
        query += "LEFT JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
        query += "LEFT JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "LEFT JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "LEFT JOIN tb_season s ON s.id_season=m.id_season
LEFT JOIN tb_range r ON r.id_range=s.id_range
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
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = m.id_design "
        query += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim start_date_arr As String = view_date_from(data.Rows(0)("pl_mrs_datex").ToString, 0)
        LPLDate.Text = "Date : " & start_date_arr
        'tampung ke form
        LMrs.Text = data.Rows(0)("prod_order_mrs_number").ToString
        LabelFrom.Text = data.Rows(0)("comp_name_from").ToString
        LTo.Text = data.Rows(0)("comp_name_to").ToString
        LToAddress.Text = data.Rows(0)("comp_address_to").ToString

        If data.Rows(0)("id_prod_order").ToString = "" Then
            LLDesign.Visible = False
            LTDesign.Visible = False
            LDesign.Visible = False
            '
            LLPoNo.Visible = False
            LTPONo.Visible = False
            LabelPDONo.Visible = False
            '
            LType.Text = "Other Request"
        Else
            LDesign.Text = data.Rows(0)("design_display_name").ToString
            'LabelPDONo.Text = data.Rows(0)("prod_order_wo_number").ToString
            LabelPDONo.Text = data.Rows(0)("prod_order_number").ToString
        End If

        LPLNumber.Text = data.Rows(0)("pl_mrs_number").ToString
        LabelNote.Text = data.Rows(0)("pl_mrs_note").ToString

        viewPLMRS()
        If is_pre = "1" Then
            pre_load_mark_horz("30", id_pl_mrs, LTo.Text, "2", XrTable1)
        Else
            load_mark_horz("30", id_pl_mrs, LTo.Text, "1", XrTable1)
        End If
    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub
End Class