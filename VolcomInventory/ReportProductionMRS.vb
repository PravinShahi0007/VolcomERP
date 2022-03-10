Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportProductionMRS
    Public Shared id_mrs As String = "-1"
    Public Shared id_comp_req_from As String = "-1"
    Public Shared id_comp_req_to As String = "-1"
    Public Shared is_pre As String = "-1"
    Public Shared is_auto As Boolean = False
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

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_mrs()
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT tip.pl_mat_type,mrs.memo_number,po.prod_order_number,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name,mrs.prod_order_mrs_number,mrs.id_prod_order,mrs.id_prod_order_wo,mrs.prod_order_mrs_note,mrs.id_report_status,mrs.id_comp_contact_req_from,mrs.id_comp_contact_req_to,DATE_FORMAT(mrs.prod_order_mrs_date,'%Y-%m-%d') AS prod_order_mrs_datex 
FROM tb_prod_order_mrs mrs
INNER JOIN tb_prod_order po ON mrs.id_prod_order=po.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.id_prod_demand_design=pdd.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
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
INNER JOIN tb_pl_mat_type tip ON tip.id_pl_mat_type=mrs.id_pl_mat_type
WHERE id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_prod_order_wo").ToString = "" Then
            LWONo.Visible = False
            LLWONo.Visible = False
            LTWONo.Visible = False
        Else
            LWONo.Text = get_prod_wo_x(data.Rows(0)("id_prod_order_wo").ToString, "1")
        End If

        If data.Rows(0)("id_prod_order").ToString = "" Then
            LPONo.Visible = False
            LLPoNo.Visible = False
            LTPONo.Visible = False
            '
            LDesignName.Visible = False
            LLDesign.Visible = False
            LTDesign.Visible = False
            '
            LLMRSType.Text = "Other"
        Else
            LPONo.Text = data.Rows(0)("prod_order_number").ToString
            LDesignName.Text = data.Rows(0)("design_display_name").ToString
        End If

        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        LReqFromName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        LToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")

        LMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString
        LMRSDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)
        LNote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        LPONo.Text = data.Rows(0)("prod_order_number").ToString

        LType.Text = data.Rows(0)("pl_mat_type").ToString
        LMemo.Text = data.Rows(0)("memo_number").ToString
    End Sub

    Private Sub ReportMatWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_auto Then
            pre_load_list_horz("29", 2, 1, XrTable1)
        Else
            If is_pre = "1" Then
                pre_load_mark_horz("29", id_mrs, "2", "1", XrTable1)
            Else
                load_mark_horz("29", id_mrs, "2", "1", XrTable1)
            End If
        End If
    End Sub
End Class