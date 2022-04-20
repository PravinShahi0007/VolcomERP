Public Class FormViewProductionMRS
    Public id_mrs As String = "-1"
    Public id_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp_req_from As String = "-1"
    Public id_comp_req_to As String = "-1"
    Public id_report_status_g As String = "-1"
    '
    Sub load_type()
        Dim q As String = "SELECT id_pl_mat_type,pl_mat_type 
FROM `tb_pl_mat_type`"
        viewSearchLookupQuery(SLEType, q, "id_pl_mat_type", "pl_mat_type", "id_pl_mat_type")
        '
        SLEType.Properties.ReadOnly = True
        TEMemo.Properties.ReadOnly = True
    End Sub

    Private Sub FormViewProductionMRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mrs()
        load_type()

        Dim query As String = String.Format("SELECT mrs.*,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name,dsg.design_code,po.prod_order_number,SUM(pod.prod_order_qty) AS qty_po ,DATE_FORMAT(prod_order_mrs_date,'%Y-%m-%d') AS prod_order_mrs_datex 
FROM tb_prod_order_mrs mrs
LEFT JOIN tb_prod_order po ON mrs.id_prod_order=po.id_prod_order
LEFT JOIN tb_prod_order_det pod ON pod.id_prod_order=po.id_prod_order
LEFT JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
LEFT JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
LEFT JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design
WHERE mrs.id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_prod_order_wo").ToString = "" Then
            TEWONumber.Visible = False
            LWONumber.Visible = False
        Else
            TEWONumber.Text = get_prod_wo_x(data.Rows(0)("id_prod_order_wo").ToString, "1")
        End If

        If data.Rows(0)("id_prod_order").ToString = "" Then
            TEPONumber.Visible = False
            TEDesign.Visible = False
            TEDesignCode.Visible = False
            TEQty.Visible = False
            LQty.Visible = False
            LPONumber.Visible = False
            LDesignName.Visible = False
            LDesignCode.Visible = False
        Else
            TEQty.EditValue = data.Rows(0)("qty_po")
            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEDesign.Text = data.Rows(0)("design_display_name").ToString
            TEDesignCode.Text = data.Rows(0)("design_code").ToString
        End If

        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        TECompName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_req_from), "2")
        TECompToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")
        TECompToCode.Text = get_company_x(get_id_company(id_comp_req_to), "2")

        id_report_status_g = data.Rows(0)("id_report_status").ToString
        TEDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)
        MENote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        TEMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString
        '
        SLEType.EditValue = data.Rows(0)("id_pl_mat_type").ToString
        TEMemo.Text = data.Rows(0)("memo_number").ToString
    End Sub
    Sub view_mrs()
        Try
            Dim query As String
            query = "CALL view_prod_order_mrs('" & id_mrs & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVMat_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMat.RowStyle
        If GVMat.GetRowCellValue(e.RowHandle, "qty") > GVMat.GetRowCellValue(e.RowHandle, "qty_left") Then
            'GVMat.FocusedRowHandle()
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Bold)
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Regular)
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mrs
        FormReportMark.report_mark_type = "29"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub
End Class