Public Class FormProductionKO
    Public id_ko As String = "-1"
    Public is_locked As String = "2"
    Public is_submit As String = "2"
    Dim is_void As String = "2"
    Public is_view As String = "-1"
    Public is_purc_mat As String = "2"
    Public is_popup As Boolean = False

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

        SLEContractTemplate.Focus()

        load_head()
    End Sub

    Sub load_head()
        'view yang revisi terakhir
        Dim query As String = "SELECT ko.is_locked,ko.is_purc_mat,c.phone,c.fax,ko.number,ko.vat,ko.id_ko_template,too.term_production,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,ko.`date_created`,LPAD(ko.`revision`,2,'0') AS revision,ko.is_void,ko.is_submit
FROM tb_prod_order_ko ko
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ko.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_lookup_term_production too ON too.id_term_production=ko.id_term_production
WHERE id_prod_order_ko='" & id_ko & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_purc_mat = data.Rows(0)("is_purc_mat").ToString
            is_void = data.Rows(0)("is_void").ToString
            '
            TEKONumber.Text = data.Rows(0)("number").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            MECompAddress.Text = data.Rows(0)("address_primary").ToString
            TECompAttn.Text = data.Rows(0)("contact_person").ToString
            '
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            TETermOrder.Text = data.Rows(0)("term_production").ToString
            '
            SLEContractTemplate.EditValue = data.Rows(0)("id_ko_template").ToString
            TEVat.EditValue = data.Rows(0)("vat")
            TETelp.EditValue = data.Rows(0)("phone")
            TEFax.EditValue = data.Rows(0)("fax")

            is_locked = data.Rows(0)("is_locked").ToString
            is_submit = data.Rows(0)("is_submit").ToString
            'load_det
            load_det()
            '
        End If

        'void
        If is_void = "1" Then
            PCDel.Visible = False
            PCControl.Visible = False
        Else
            PCControl.Visible = True
        End If

        If is_submit = "1" Then
            'submit
            BLock.Visible = False
            BUpdate.Visible = False
            BRevise.Visible = True
            PCDel.Visible = False
            '
            BPrintKO.Visible = True
            '
            BMark.Visible = True
        Else
            BLock.Visible = True
            BUpdate.Visible = True
            BRevise.Visible = False
            PCDel.Visible = True
            'ttp true karena harus bisa nyetak
            BPrintKO.Visible = True
            '
            BMark.Visible = False
        End If

        'prevent edit lead time
        If SLERevision.Text = "00" Or is_locked = "1" Then
            GridColumnLeadTime.OptionsColumn.ReadOnly = True
        Else
            GridColumnLeadTime.OptionsColumn.ReadOnly = False
        End If

        If is_popup Then
            BRevise.Visible = False
            PCControl.Visible = False
            BrefreshTemplateContract.Visible = False
            BManageContractVendor.Visible = False
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
        'METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), "1")
        METotSay.Text = ConvertCurrencyToIndonesian(total)
    End Sub

    Sub load_det()
        Dim query As String = ""

        If is_purc_mat = "1" Then
            query = "SELECT kod.revision,kod.id_prod_order_ko_det,'' AS `no`,po.`mat_purc_number` AS prod_order_number,md.mat_det_display_name AS class_dsg,cd.`display_name` AS color
,(pod.mat_purc_det_qty) AS qty_order,pod.mat_purc_det_price AS bom_unit,(pod.mat_purc_det_price*pod.mat_purc_det_qty) AS po_amount_rp
,kod.lead_time_prod AS lead_time,kod.lead_time_payment,po.mat_purc_date AS prod_order_wo_del_date,DATE_ADD(po.mat_purc_date,INTERVAL kod.lead_time_prod DAY) AS esti_del_date
,DATE_ADD(po.mat_purc_date,INTERVAL kod.lead_time_prod_before DAY) AS esti_del_date_before
,IF(DATE_ADD(po.mat_purc_date,INTERVAL kod.lead_time_prod_before DAY) > dte_limit.working_date,true,false) AS ok_edit
,IFNULL(revtimes.revision_times,0) AS revision_times
FROM `tb_prod_order_ko_det` kod
INNER JOIN tb_mat_purc po ON po.id_mat_purc=kod.id_purc_order
INNER JOIN  tb_mat_purc_det pod ON po.id_mat_purc=pod.id_mat_purc
INNER JOIN tb_m_mat_det_price mdp ON mdp.`id_mat_det_price`=pod.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=mdp.`id_mat_det`
INNER JOIN `tb_m_mat_det_code` mdc ON mdc.id_mat_det = md.id_mat_det
INNER JOIN `tb_m_code_detail` cd ON cd.id_code_detail=mdc.id_code_detail AND cd.id_code='1'
INNER JOIN
(
    SELECT wd.id_working_day,wd.working_date FROM `tb_working_date` wd
    INNER JOIN tb_prod_order_ko ko ON wd.working_date>=DATE(ko.date_created) AND ko.id_prod_order_ko='" & id_ko & "' ORDER BY wd.working_date ASC LIMIT 2,1
)dte_limit
LEFT JOIN(
    SELECT revtimes.id_purc_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kod.id_purc_order,kod.revision FROM tb_prod_order_ko_det kod
	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko`
	    WHERE kod.revision!=0 AND kod.id_prod_order_ko<='" & id_ko & "' AND ko.`id_prod_order_ko_reff`=(SELECT id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "' LIMIT 1)
	    GROUP BY kod.id_purc_order,kod.revision
    ) revtimes GROUP BY revtimes.id_purc_order
)revtimes ON revtimes.id_purc_order=po.id_mat_purc
WHERE kod.id_prod_order_ko='" & id_ko & "'
-- GROUP BY po.id_mat_purc
ORDER BY po.`id_mat_purc` ASC"
            GCAttachment.Visible = False
            GridColumnBefore.Visible = False
        Else
            query = "SELECT kod.revision,kod.id_prod_order_ko_det,'' AS `no`,po.`prod_order_number`,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name) AS class_dsg,cd.color AS color
,wo_price.qty_po AS qty_order,wo_price.prod_order_wo_det_price AS bom_unit,wo_price.price_amount AS po_amount_rp
,kod.lead_time_prod AS lead_time,kod.lead_time_payment,wo_price.prod_order_wo_del_date
,DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL kod.lead_time_prod DAY) AS esti_del_date
,DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL kod.lead_time_prod_before DAY) AS esti_del_date_before
,IF(DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL kod.lead_time_prod_before DAY) > dte_limit.working_date,true,false) AS ok_edit
,IFNULL(revtimes.revision_times,0) AS revision_times
,IF(ISNULL(att.id_prod_order),'Not Complete','Complete') AS att_sts
FROM `tb_prod_order_ko_det` kod
INNER JOIN tb_prod_order po ON po.id_prod_order=kod.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
INNER JOIN
(
    SELECT wd.id_working_day,wd.working_date FROM `tb_working_date` wd
    INNER JOIN tb_prod_order_ko ko ON wd.working_date>=DATE(ko.date_created) AND ko.id_prod_order_ko='" & id_ko & "' ORDER BY wd.working_date ASC LIMIT 2,1
)dte_limit
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
	AND cd.id_code IN (32,30,14,43,34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
LEFT JOIN(
    SELECT revtimes.id_prod_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kod.id_prod_order,kod.revision FROM tb_prod_order_ko_det kod
	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko`
	    WHERE kod.revision!=0 AND kod.id_prod_order_ko<='" & id_ko & "' AND ko.`id_prod_order_ko_reff`=(SELECT id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "' LIMIT 1)
	    GROUP BY kod.id_prod_order,kod.revision
    ) revtimes GROUP BY revtimes.id_prod_order
)revtimes ON revtimes.id_prod_order=po.id_prod_order
LEFT JOIN
(
    SELECT id_prod_order
    FROM `tb_prod_order_attach`
    WHERE id_report_status=6
    GROUP BY id_prod_order    
)att ON att.id_prod_order=po.id_prod_order
WHERE kod.id_prod_order_ko='" & id_ko & "'
ORDER BY po.`id_prod_order` ASC"
            GridColumnBefore.Visible = True
            GCAttachment.Visible = True
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
        '
        calculate()
    End Sub


    Sub load_contract_template()
        Dim query As String = "SELECT id_ko_template,description,year FROM tb_ko_template"
        viewSearchLookupQuery(SLEContractTemplate, query, "id_ko_template", "description", "id_ko_template")
    End Sub
    Sub load_revision()
        Dim query As String = "SELECT id_prod_order_ko,LPAD(revision,2,'0') as revision,id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko_reff=(SELECT id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "' LIMIT 1) ORDER BY id_prod_order_ko DESC"
        viewSearchLookupQuery(SLERevision, query, "id_prod_order_ko", "revision", "id_prod_order_ko")
    End Sub

    Private Sub BrefreshTemplateContract_Click(sender As Object, e As EventArgs) Handles BrefreshTemplateContract.Click
        Dim id_template As String = SLEContractTemplate.EditValue.ToString
        load_contract_template()
        SLEContractTemplate.EditValue = id_template
    End Sub

    Private Sub BManageContractVendor_Click(sender As Object, e As EventArgs) Handles BManageContractVendor.Click
        FormProdTemplateKO.ShowDialog()
    End Sub

    Private Sub BPrintKO_Click(sender As Object, e As EventArgs) Handles BPrintKO.Click
        Dim id_ko_template As String = execute_query("SELECT id_ko_template FROM tb_prod_order_ko WHERE id_prod_order_ko = " & id_ko, 0, True, "", "", "", "")
        If Not id_ko_template = "0" Then
            Dim query As String = "SELECT ko.is_purc_mat,kot.upper_part,kot.bottom_part,c.phone,c.fax,ko.number,ko.vat,ko.id_ko_template,too.term_production,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,DATE_FORMAT(ko.`date_created`,'%d %M %Y') AS date_created,LPAD(ko.`revision`,2,'0') AS revision
,emp_created.employee_name AS emp_name_created,emp_created.`employee_position` AS created_pos
,emp_purc_mngr.employee_name AS emp_name_purc_mngr,emp_purc_mngr.`employee_position` AS purc_mngr_pos
,emp_fc.employee_name AS emp_name_fc,emp_fc.`employee_position` AS fc_pos
,emp_director.employee_name AS emp_name_director,emp_director.`employee_position` AS director_pos
,emp_vice.employee_name AS emp_name_vice_director
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
INNER JOIN tb_m_employee emp_vice ON emp_vice.`id_employee`=ko.`id_emp_vice_director`
WHERE id_prod_order_ko='" & SLERevision.EditValue.ToString & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            ReportProductionKO.dt_head = data
            ReportProductionKO.is_po_mat = data.Rows(0)("is_purc_mat").ToString
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

            'Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Print, DevExpress.XtraPrinting.CommandVisibility.None)
            'Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect, DevExpress.XtraPrinting.CommandVisibility.None)
            'Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)

            Tool.ShowPreview()
        Else
            warningCustom("Please choose KO template")
        End If
    End Sub

    Private Sub BRevise_Click(sender As Object, e As EventArgs) Handles BRevise.Click
        Dim check As String = "SELECT * FROM tb_prod_order_ko WHERE number='" & addSlashes(TEKONumber.Text) & "' ORDER BY id_prod_order_ko DESC"
        Dim data_check As DataTable = execute_query(check, -1, True, "", "", "", "")
        If id_ko = data_check.Rows(0)("id_prod_order_ko").ToString Then
            'check attachment
            Dim qc As String = "SELECT * FROM `tb_doc` WHERE id_report='" & id_ko & "' AND report_mark_type='252'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                'konfirmasi QC
                'cek konfirmasi QC sudah ada belum
                Dim qqc As String = "SELECT * FROM tb_prod_order_ko_app WHERE id_prod_order_ko='" & id_ko & "' AND id_report_status!=5"
                Dim dtqc As DataTable = execute_query(qqc, -1, True, "", "", "", "")
                If dtqc.Rows.Count > 0 Then
                    warningCustom("Proposal revisi sudah pernah diajukan.")
                Else
                    qqc = "INSERT INTO `tb_prod_order_ko_app`(`id_prod_order_ko`,`created_date`,`created_by`,`id_report_status`) VALUES('" & id_ko & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID(); "
                    Dim id_pps As String = execute_query(qqc, 0, True, "", "", "", "")
                    submit_who_prepared("405", id_pps, id_user)
                    infoCustom("Proposal revisi diajukan, menunggu persetujuan")
                End If

                'Dim query As String = "INSERT INTO tb_prod_order_ko(`id_prod_order_ko_reff`,`number`,`revision`,`id_ko_template`,`id_comp_contact`,`vat`,`id_term_production`,`date_created`,`created_by`,`id_emp_purc_mngr`,`id_emp_fc`,`id_emp_director`,`id_emp_vice_director`,`is_purc_mat`)
                'SELECT `id_prod_order_ko_reff`,`number`,(SELECT COUNT(id_prod_order_ko) FROM tb_prod_order_ko WHERE id_prod_order_ko_reff=(SELECT id_prod_order_ko_reff FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "')),`id_ko_template`,`id_comp_contact`,`vat`,`id_term_production`,`date_created`,`created_by`,`id_emp_purc_mngr`,`id_emp_fc`,`id_emp_director`,`id_emp_vice_director`,`is_purc_mat` FROM tb_prod_order_ko WHERE id_prod_order_ko='" & id_ko & "'; SELECT LAST_INSERT_ID(); "
                'Dim new_id_ko As String = execute_query(query, 0, True, "", "", "", "")
                ''det
                'query = "INSERT INTO tb_prod_order_ko_det(`id_prod_order_ko`,`revision`,`id_prod_order`,`id_purc_order`,`lead_time_prod`,`lead_time_prod_before`,`lead_time_payment`)
                'SELECT '" & new_id_ko & "' AS id_ko,`revision`,`id_prod_order`,`id_purc_order`,`lead_time_prod`,`lead_time_prod`,`lead_time_payment` FROM tb_prod_order_ko_det WHERE id_prod_order_ko='" & id_ko & "'"
                'execute_non_query(query, True, "", "", "", "")
                ''
                'infoCustom("KO revised")
                'id_ko = new_id_ko
                'action_load()
            Else
                warningCustom("Please attach file SKO first")
            End If
        Else
            warningCustom("This is not the latest revision")
        End If
    End Sub

    Private Sub BUpdateLeadTime_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If Not SLEContractTemplate.EditValue.ToString = "0" Then
            Dim query As String = "UPDATE tb_prod_order_ko SET id_ko_template='" & SLEContractTemplate.EditValue.ToString & "' WHERE id_prod_order_ko='" & id_ko & "'"
            execute_non_query(query, True, "", "", "", "")
            'update lead time
            For i As Integer = 0 To GVProd.RowCount - 1
                query = "UPDATE tb_prod_order_ko_det SET lead_time_prod='" & GVProd.GetRowCellValue(i, "lead_time").ToString & "' WHERE id_prod_order_ko_det='" & GVProd.GetRowCellValue(i, "id_prod_order_ko_det").ToString & "'"
                execute_non_query(query, True, "", "", "", "")
            Next
            infoCustom("KO updated")
            load_head()
        Else
            stopCustom("Please select Contract Template")
        End If
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        Dim is_attach_ok As Boolean = True
        'cek attachment
        Dim qc As String = "SELECT * FROM tb_prod_order_ko_det kod
LEFT JOIN
(
    SELECT id_prod_order FROM `tb_prod_order_attach` WHERE id_report_status=6 GROUP BY id_prod_order
)att ON att.id_prod_order=kod.`id_prod_order`
WHERE kod.`id_prod_order_ko`='" & id_ko & "'
AND ISNULL(att.id_prod_order)"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            is_attach_ok = False
        End If

        qc = "SELECT * FROM tb_doc WHERE id_report='" & id_ko & "' AND report_mark_type='252'"
        dtc = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count <= 0 Then
            is_attach_ok = False
        End If

        'cek ko template
        Dim id_ko_template As String = execute_query("SELECT id_ko_template FROM tb_prod_order_ko WHERE id_prod_order_ko = " & id_ko, 0, True, "", "", "", "")
        If Not id_ko_template = "0" And is_attach_ok Then
            Dim query As String = "UPDATE tb_prod_order_ko SET is_submit='1' WHERE id_prod_order_ko='" & id_ko & "'"
            execute_non_query(query, True, "", "", "", "")
            'submit
            submit_who_prepared("252", id_ko, id_user)
            '
            infoCustom("KO Submitted")
            load_head()
        Else
            stopCustom("Please make sure template contract selected, all FGPO have attachment, and KO have attached signed copy")
        End If

        'If Not id_ko_template = "0" Then
        '    Dim query As String = "UPDATE tb_prod_order_ko SET is_locked='1' WHERE id_prod_order_ko='" & id_ko & "'"
        '    execute_non_query(query, True, "", "", "", "")
        '    infoCustom("KO locked")
        '    load_head()
        'Else
        '    stopCustom("Please select Contract Template and Update")
        'End If
    End Sub

    Private Sub SLERevision_EditValueChanged(sender As Object, e As EventArgs) Handles SLERevision.EditValueChanged
        SLERevision.Refresh()
        id_ko = SLERevision.EditValue.ToString
        load_head()
    End Sub

    Private Sub Bdel_Click(sender As Object, e As EventArgs) Handles Bdel.Click
        If is_locked = "2" Then
            Dim query As String = "DELETE FROM tb_prod_order_ko_det WHERE id_prod_order_ko_det='" & GVProd.GetFocusedRowCellValue("id_prod_order_ko_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("KO updated")
            load_head()
        Else
            warningCustom("KO locked")
        End If
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_ko
        FormDocumentUpload.report_mark_type = "252"
        FormDocumentUpload.ShowDialog()
        If is_submit = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_ko
        FormReportMark.report_mark_type = "252"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVData_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GVProd.ShowingEditor
        If GVProd.GetFocusedRowCellValue("ok_edit") Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
End Class