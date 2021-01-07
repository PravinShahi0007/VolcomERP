Public Class FormSalesPOSClosingNoStock
    Public id As String = "-1"
    Dim rmt As String = "283"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "2"
    Public is_view As String = "-1"

    Private Sub FormSalesPOSClosingNoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub FormSalesPOSClosingNoStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Dim query As String = "SELECT r.id_sales_pos_oos_recon, r.number, r.created_date, r.note, r.id_report_status, rs.report_status, r.is_confirm 
        FROM tb_sales_pos_oos_recon r
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE r.id_sales_pos_oos_recon='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        MENote.Text = data.Rows(0)("note").ToString
        viewSummary()
        viewDetail()
        allowStatus()
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT prd.id_sales_pos_oos_recon,p.id_sales_pos_prob, sp.id_sales_pos, c.id_comp, sp.sales_pos_number, c.comp_number, c.comp_name,
        prod.id_product, prod.product_full_code As `code`, prod.product_display_name As `name`, cd.code_detail_name As `size`,
        p.id_design_price_valid AS `id_design_price`, p.design_price_valid AS `design_price`,sp.report_mark_type AS `rmt_inv`
        FROM tb_sales_pos_oos_recon_prob prd
        INNER JOIN tb_sales_pos_prob p ON p.id_sales_pos_prob = prd.id_sales_pos_prob
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        WHERE prd.id_sales_pos_oos_recon='" + id + "'
        GROUP BY prd.id_sales_pos_prob "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "Select rd.id_sales_pos_oos_recon_det, rd.id_sales_pos_oos_recon,
rd.id_sales_pos_prob, rd.id_sales_pos, rd.id_comp, sp.sales_pos_number, c.comp_number, c.comp_name,
rd.id_product, p.product_full_code As `code`, p.product_display_name As `name`, cd.code_detail_name As `size`, rd.qty,
rd.id_design_price, rd.design_price,
rd.id_product_valid, pv.product_full_code As `code_valid`, pv.product_display_name As `name_valid`, cdv.code_detail_name As `size_valid`, rd.qty_valid,
rd.id_design_price_valid, rd.design_price_valid, rd.note, 
sp.report_mark_type AS `rmt_inv`
FROM tb_sales_pos_oos_recon_det rd
INNER JOIN tb_m_product p ON p.id_product = rd.id_product
INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
INNER JOIN tb_m_product pv ON pv.id_product = rd.id_product_valid
INNER JOIN tb_m_product_code pcv ON pcv.id_product = pv.id_product
INNER JOIN tb_m_code_detail cdv ON cdv.id_code_detail = pcv.id_code_detail
INNER JOIN tb_m_comp c ON c.id_comp = rd.id_comp
INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_sales_pos
WHERE rd.id_sales_pos_oos_recon='" + id + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        If is_confirm = "2" And is_view = "-1" Then
            MENote.Properties.ReadOnly = False
            BtnCreate.Visible = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
        Else
            MENote.Properties.ReadOnly = True
            BtnCreate.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
        End If
        BtnAttachment.Visible = True
        BtnCancell.Visible = True

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "-1" Then
            SBPrint.Visible = False
        Else
            SBPrint.Visible = True
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class