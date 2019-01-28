Public Class FormProductionKO
    Public id_ko As String = "-1"
    Private Sub FormProductionKO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionKO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    '
    Sub action_load()
        load_revision()
        load_contract_template()

        'view yang revisi terakhir
        Dim query As String = "SELECT c.phone,c.fax,ko.number,ko.vat,ko.id_ko_template,too.term_production,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,ko.`date_created`,LPAD(ko.`revision`,2,'0') AS revision
FROM tb_prod_order_ko ko
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ko.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_lookup_term_production too ON too.id_term_production=ko.id_term_production
WHERE id_prod_order_ko='" & SLERevision.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then

            TEKONumber.Text = data.Rows(0)("number").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            MECompAddress.Text = data.Rows(0)("address_primary").ToString
            TECompAttn.Text = data.Rows(0)("contact_person").ToString
            '
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            TETermOrder.Text = data.Rows(0)("term_production").ToString
            '
            LEContractTemplate.EditValue = data.Rows(0)("id_ko_template").ToString
            TEVat.EditValue = data.Rows(0)("vat")
            TETelp.EditValue = data.Rows(0)("phone")
            TEFax.EditValue = data.Rows(0)("fax")
            'load_det
            load_det()
            '
        End If
    End Sub

    Sub calculate()
        GVProd.RefreshData()

        Dim total, sub_tot, gross_tot, vat As Decimal

        Try
            sub_tot = GVProd.Columns("po_amount_rp").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * sub_tot
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat

        gross_tot = sub_tot

        total = sub_tot + vat
        TETot.EditValue = total
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), "1")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT '' AS `no`,po.`prod_order_number`,LEFT(dsg.design_display_name,LENGTH(dsg.design_display_name)-3) AS class_dsg,RIGHT(dsg.design_display_name,3) AS color
,wo_price.qty_po AS qty_order,wo_price.prod_order_wo_det_price AS bom_unit,wo_price.price_amount AS po_amount_rp
,kod.lead_time_prod AS lead_time,kod.lead_time_payment, DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL wo_price.prod_order_wo_lead_time DAY) AS est_del_date
FROM `tb_prod_order_ko_det` kod
INNER JOIN tb_prod_order po ON po.id_prod_order=kod.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN (
	SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,wod.prod_order_wo_det_price
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs) AS `price_amount`
	,SUM(pod.prod_order_qty) AS qty_po
    ,wo.prod_order_wo_del_date,wo.prod_order_wo_lead_time
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order= po.id_prod_order
WHERE id_prod_order_ko='" & id_ko & "'
ORDER BY po.`id_prod_order` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
        '
        calculate()
    End Sub


    Sub load_contract_template()
        Dim query As String = "SELECT id_ko_template,description,`year` FROM `tb_ko_template`"
        viewSearchLookupQuery(LEContractTemplate, query, "id_ko_template", "description", "id_ko_template")
    End Sub
    Sub load_revision()
        Dim query As String = "SELECT id_prod_order_ko,LPAD(revision,2,'0') as revision FROM tb_prod_order_ko WHERE id_prod_order_ko_reff=(SELECT id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "' LIMIT 1) ORDER BY id_prod_order_ko DESC"
        viewSearchLookupQuery(SLERevision, query, "id_prod_order_ko", "revision", "id_prod_order_ko")
    End Sub

    Private Sub BrefreshTemplateContract_Click(sender As Object, e As EventArgs) Handles BrefreshTemplateContract.Click
        Dim id_template As String = LEContractTemplate.EditValue.ToString
        load_contract_template()
        LEContractTemplate.EditValue = id_template
    End Sub

    Private Sub BManageContractVendor_Click(sender As Object, e As EventArgs) Handles BManageContractVendor.Click
        FormProdTemplateKO.ShowDialog()
    End Sub

    Private Sub BPrintKO_Click(sender As Object, e As EventArgs) Handles BPrintKO.Click
        Dim query As String = "SELECT kot.upper_part,kot.bottom_part,c.phone,c.fax,ko.number,ko.vat,ko.id_ko_template,too.term_production,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,DATE_FORMAT(ko.`date_created`,'%d %M %Y') AS date_created,LPAD(ko.`revision`,2,'0') AS revision
,emp_created.employee_name AS emp_name_created,emp_created.`employee_position` AS created_pos
,emp_purc_mngr.employee_name AS emp_name_purc_mngr,emp_purc_mngr.`employee_position` AS purc_mngr_pos
,emp_fc.employee_name AS emp_name_fc,emp_fc.`employee_position` AS fc_pos
,emp_director.employee_name AS emp_name_director,emp_director.`employee_position` AS director_pos
FROM tb_prod_order_ko ko
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ko.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_lookup_term_production too ON too.id_term_production=ko.id_term_production
INNER JOIN tb_ko_template kot ON kot.`id_ko_template`=ko.`id_ko_template`
INNER JOIN tb_m_user usr_created ON usr_created.`id_user`=ko.`created_by`
INNER JOIN tb_m_employee emp_created ON emp_created.`id_employee`=usr_created.`id_employee`
INNER JOIN tb_m_employee emp_purc_mngr ON emp_purc_mngr.`id_employee`=ko.`id_emp_purc_mngr`
INNER JOIN tb_m_employee emp_fc ON emp_fc.`id_employee`=ko.`id_emp_fc`
INNER JOIN tb_m_employee emp_director ON emp_director.`id_employee`=ko.`id_emp_director`
WHERE id_prod_order_ko='" & SLERevision.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        ReportProductionKO.dt_head = data
        '
        ReportProductionKO.dt_det = GCProd.DataSource

        Dim Report As New ReportProductionKO()
        '
        Report.LAmountVat.Text = Decimal.Parse(TEVatTot.EditValue.ToString).ToString("N2")
        Report.LPOAmountRp.Text = Decimal.Parse(GVProd.Columns("po_amount_rp").SummaryItem.SummaryValue.ToString).ToString("N2")
        Report.LAmountWithVat.Text = Decimal.Parse(TETot.EditValue.ToString).ToString("N2")
        Report.LQtyOrder.Text = Decimal.Parse(GVProd.Columns("qty_order").SummaryItem.SummaryValue.ToString).ToString("N0")
        Report.LSay.Text = METotSay.Text
        Report.XRichUpper.Rtf = data.Rows(0)("upper_part").ToString
        Report.XRichBottom.Rtf = data.Rows(0)("bottom_part").ToString
        '

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class