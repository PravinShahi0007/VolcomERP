﻿Public Class FormProductionSampleOrder
    Public id As String = "-1"
    Public is_locked As String = "2"
    Public is_purc_mat As String = "2"

    Private Sub FormProductionSampleOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub

    Sub action_load()
        load_revision()

        load_head()
    End Sub

    Sub load_revision()
        Dim query As String = "SELECT id_prod_order_cps2,LPAD(revision,2,'0') as revision,id_prod_order_cps2_reff FROM tb_prod_order_cps2 WHERE id_prod_order_cps2_reff=(SELECT id_prod_order_cps2_reff FROM tb_prod_order_cps2 WHERE id_prod_order_cps2='" & id & "' LIMIT 1) ORDER BY id_prod_order_cps2 DESC"
        viewSearchLookupQuery(SLERevision, query, "id_prod_order_cps2", "revision", "id_prod_order_cps2")
    End Sub

    Private Sub FormProductionSampleOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_head()
        'view yang revisi terakhir
        Dim query As String = "SELECT kp.is_locked,kp.is_purc_mat,c.phone,c.fax,kp.number,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,kp.`date_created`,LPAD(kp.`revision`,2,'0') AS revision
FROM tb_prod_order_cps2 kp
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=kp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE id_prod_order_cps2='" & id & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_purc_mat = data.Rows(0)("is_purc_mat").ToString
            '
            TEKPNumber.Text = data.Rows(0)("number").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            MECompAddress.Text = data.Rows(0)("address_primary").ToString
            TECompAttn.Text = data.Rows(0)("contact_person").ToString
            '
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            '
            TETelp.EditValue = data.Rows(0)("phone")
            TEFax.EditValue = data.Rows(0)("fax")

            is_locked = data.Rows(0)("is_locked").ToString
            'load_det
            load_det()
            '
        End If

        If is_locked = "1" Then
            'locked
            BLock.Visible = False
            BUpdate.Visible = False
            BRevise.Visible = True
            Bdel.Enabled = False
            PCDel.Visible = False
        Else
            BLock.Visible = True
            BUpdate.Visible = True
            BRevise.Visible = False
            Bdel.Enabled = True
            PCDel.Visible = True
        End If

        'prevent edit lead time
        If is_locked = "1" Then
            GridColumnProto2Sample.OptionsColumn.ReadOnly = True
        Else
            GridColumnProto2Sample.OptionsColumn.ReadOnly = False
        End If
        '
    End Sub

    Sub load_det()
        load_size()
        Dim query As String = ""

        If is_purc_mat = "1" Then
            'query = "SELECT kpd.sample_proto_2,kpd.revision,kpd.id_prod_order_kp_det,'' AS `no`,po.`mat_purc_number` AS prod_order_number,md.mat_det_display_name AS class_dsg,cd.`display_name` AS color
            ',SUM(pod.mat_purc_det_qty) AS qty_order,pod.mat_purc_det_price AS bom_unit,SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty) AS po_amount_rp
            ',kpd.lead_time_prod AS lead_time,po.mat_purc_date AS prod_order_wo_del_date,DATE_ADD(po.mat_purc_date,INTERVAL kpd.lead_time_prod DAY) AS esti_del_date
            ',IFNULL(revtimes.revision_times,0) AS revision_times
            'FROM `tb_prod_order_kp_det` kpd
            'INNER JOIN tb_mat_purc po ON po.id_mat_purc=kpd.id_purc_order
            'INNER JOIN  tb_mat_purc_det pod ON po.id_mat_purc=pod.id_mat_purc
            'INNER JOIN tb_m_mat_det_price mdp ON mdp.`id_mat_det_price`=pod.`id_mat_det_price`
            'INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=mdp.`id_mat_det`
            'INNER JOIN `tb_m_mat_det_code` mdc ON mdc.id_mat_det = md.id_mat_det
            'INNER JOIN `tb_m_code_detail` cd ON cd.id_code_detail=mdc.id_code_detail AND cd.id_code='1'
            'LEFT JOIN(
            '    SELECT revtimes.id_purc_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
            '    (
            '	    SELECT kpd.id_purc_order,kpd.revision FROM tb_prod_order_kp_det kpd
            '	    INNER JOIN tb_prod_order_kp kp ON kp.`id_prod_order_kp`=kpd.`id_prod_order_kp`
            '	    WHERE kpd.revision!=0 AND kpd.id_prod_order_kp<='" & id & "' AND kp.`id_prod_order_kp_reff`=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id & "' LIMIT 1)
            '	    GROUP BY kpd.id_purc_order,kpd.revision
            '    ) revtimes GROUP BY revtimes.id_purc_order
            ')revtimes ON revtimes.id_purc_order=po.id_mat_purc
            'WHERE kpd.id_prod_order_kp='" & id & "'
            'GROUP BY po.id_mat_purc
            'ORDER BY po.`id_mat_purc` ASC"
        Else
            query = "SELECT kpd.eta_copy_proto_2,kpd.revision,kpd.id_prod_order_cps2_det,'' AS `no`,po.`prod_order_number`
,dsg.design_display_name,cd.color AS color
,IFNULL(revtimes.revision_times,0) AS revision_times
,kpd.id_prod_order
,kpd.eta_copy_proto_2
,kpd.qty_order
,kpd.size
FROM `tb_prod_order_cps2_det` kpd
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
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
LEFT JOIN(
    SELECT revtimes.id_prod_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kpd.id_prod_order,kpd.revision 
	    FROM tb_prod_order_cps2_det kpd
	    INNER JOIN tb_prod_order_cps2 kp ON kp.`id_prod_order_cps2`=kpd.`id_prod_order_cps2`
	    WHERE kpd.revision!=0 AND kp.`id_prod_order_cps2_reff`=(SELECT id_prod_order_cps2_reff FROM tb_prod_order_cps2 WHERE id_prod_order_cps2='" & id & "' LIMIT 1)
	    GROUP BY kpd.id_prod_order,kpd.revision
    ) revtimes GROUP BY revtimes.id_prod_order
)revtimes ON revtimes.id_prod_order=po.id_prod_order
WHERE kpd.id_prod_order_cps2='" & id & "'
ORDER BY po.`id_prod_order` ASC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        'update lead time
        Dim query As String = ""
        For i As Integer = 0 To GVProd.RowCount - 1
            Dim eta_copy_proto_2 As String = Date.Parse(GVProd.GetRowCellValue(i, "eta_copy_proto_2").ToString).ToString("yyyy-MM-dd")
            Dim size As String = GVProd.GetRowCellValue(i, "size").ToString
            query = "UPDATE tb_prod_order_cps2_det SET eta_copy_proto_2='" & eta_copy_proto_2 & "',size='" & addSlashes(size) & "' WHERE id_prod_order_cps2_det='" & GVProd.GetRowCellValue(i, "id_prod_order_cps2_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
        Next
        infoCustom("Order updated")
        load_head()
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        'check size
        Dim size_ok As Boolean = True
        For i As Integer = 0 To GVProd.RowCount - 1
            If GVProd.GetRowCellValue(i, "size").ToString = "" Then
                size_ok = False
                Exit For
            End If
        Next
        If size_ok Then
            Dim query As String = "UPDATE tb_prod_order_cps2 SET is_locked='1' WHERE id_prod_order_cps2='" & id & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Order locked")
            load_head()
        Else
            warningCustom("Please fill all data")
        End If
    End Sub

    Private Sub SLERevision_EditValueChanged(sender As Object, e As EventArgs) Handles SLERevision.EditValueChanged
        SLERevision.Refresh()
        id = SLERevision.EditValue.ToString
        load_head()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = "261"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BRevise_Click(sender As Object, e As EventArgs) Handles BRevise.Click
        Dim check As String = "SELECT * FROM tb_prod_order_cps2 WHERE number='" & addSlashes(TEKPNumber.Text) & "' ORDER BY id_prod_order_cps2 DESC"
        Dim data_check As DataTable = execute_query(check, -1, True, "", "", "", "")
        If id = data_check.Rows(0)("id_prod_order_cps2").ToString Then
            'check attachment
            Dim qc As String = "SELECT * FROM `tb_doc` WHERE id_report='" & id & "' AND report_mark_type='261'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                Dim query As String = "INSERT INTO tb_prod_order_cps2(`id_prod_order_cps2_reff`,`number`,`revision`,`id_comp_contact`,`date_created`,`created_by`,`id_user_purc_mngr`,`id_user_sample_mngr`,`id_user_sample`,`is_purc_mat`)
SELECT `id_prod_order_cps2_reff`,`number`,(SELECT COUNT(id_prod_order_cps2) FROM tb_prod_order_cps2 WHERE id_prod_order_cps2_reff=(SELECT id_prod_order_cps2_reff FROM tb_prod_order_cps2 WHERE id_prod_order_cps2='" & id & "')),`id_comp_contact`,`date_created`,`created_by`,`id_user_purc_mngr`,`id_user_sample_mngr`,`id_user_sample`,`is_purc_mat` FROM tb_prod_order_cps2 WHERE id_prod_order_cps2='" & id & "'; SELECT LAST_INSERT_ID(); "
                Dim new_id_cps2 As String = execute_query(query, 0, True, "", "", "", "")
                'det
                'loop
                Dim q_det As String = "SELECT cps2d.`revision`,cps2d.`id_prod_order`,cps2d.`id_purc_order`,2 AS qty_order,cps2d.size,cps2d.`eta_copy_proto_2`
FROM tb_prod_order_cps2_det cps2d
WHERE id_prod_order_cps2='" & id & "'"
                Dim data_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                query = ""
                For i As Integer = 0 To data_det.Rows.Count - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & new_id_cps2 & "','" & data_det.Rows(i)("revision").ToString & "','" & data_det.Rows(i)("id_prod_order").ToString & "','" & data_det.Rows(i)("id_purc_order").ToString & "','" & data_det.Rows(i)("size").ToString & "','" & data_det.Rows(i)("qty_order").ToString & "','" & Date.Parse(data_det.Rows(i)("eta_copy_proto_2").ToString).ToString("yyyy-MM-dd") & "')"
                Next

                If Not query = "" Then
                    query = "INSERT INTO tb_prod_order_cps2_det(`id_prod_order_cps2`,`revision`,`id_prod_order`,`id_purc_order`,`size`,`qty_order`,`eta_copy_proto_2`)
VALUES" + query
                    execute_non_query(query, True, "", "", "", "")
                End If
                '
                infoCustom("Order revised")
                id = new_id_cps2
                action_load()
            Else
                warningCustom("Please attach Old Order file first")
            End If
        Else
            warningCustom("This is not the latest revision")
        End If
    End Sub

    Private Sub Bdel_Click(sender As Object, e As EventArgs) Handles Bdel.Click
        If is_locked = "2" Then
            Dim query As String = "DELETE FROM tb_prod_order_cps2_det WHERE id_prod_order_cps2_det='" & GVProd.GetFocusedRowCellValue("id_prod_order_cps2_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Order updated")
            load_head()
        Else
            warningCustom("Order locked")
        End If
    End Sub

    Private Sub BPrintKP_Click(sender As Object, e As EventArgs) Handles BPrintKP.Click
        Dim query As String = "SELECT c.phone,c.fax,cps2.number,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,DATE_FORMAT(cps2.`date_created`,'%d %M %Y') AS date_created,LPAD(cps2.`revision`,2,'0') AS revision
,emp_created.employee_name AS emp_name_created,emp_created.`employee_position` AS created_pos
,emp_purc_mngr.employee_name AS emp_name_purc_mngr,emp_purc_mngr.`employee_position` AS purc_mngr_pos
,emp_sample_mngr.employee_name AS emp_name_sample_mngr,emp_sample_mngr.`employee_position` AS sample_mngr_pos
FROM tb_prod_order_cps2 cps2
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=cps2.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_user usr_created ON usr_created.`id_user`=cps2.`id_user_sample`
INNER JOIN tb_m_user usr_purc_mngr ON usr_purc_mngr.`id_user`=cps2.`id_user_purc_mngr`
INNER JOIN tb_m_user usr_sample_mngr ON usr_sample_mngr.`id_user`=cps2.`id_user_sample_mngr`
INNER JOIN tb_m_employee emp_created ON emp_created.`id_employee`=usr_created.`id_employee`
INNER JOIN tb_m_employee emp_purc_mngr ON emp_purc_mngr.`id_employee`=usr_purc_mngr.`id_employee`
INNER JOIN tb_m_employee emp_sample_mngr ON emp_sample_mngr.`id_employee`=usr_sample_mngr.`id_employee`
WHERE id_prod_order_cps2='" & SLERevision.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        ReportProductionSampleProto2Order.dt_head = data
        '
        ReportProductionSampleProto2Order.dt_det = GCProd.DataSource


        Dim Report As New ReportProductionSampleProto2Order()
        '
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        If Not is_locked = "1" Then
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Print, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
        End If
        Tool.ShowPreview()
    End Sub

    Private Sub GVProd_ShownEditor(sender As Object, e As EventArgs) Handles GVProd.ShownEditor

    End Sub

    Private Sub RepositoryItemSearchLookUpEdit1_Popup(sender As Object, e As EventArgs) Handles RISLESize.Popup
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = TryCast(GVProd.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
        editor.Properties.View.ActiveFilterString = "[id_prod_order] = '" + GVProd.GetFocusedRowCellValue("id_prod_order").ToString + "'"
    End Sub

    Sub load_size()
        Dim q As String = "SELECT cpsd.`id_prod_order`,cd.`display_name` AS size 
FROM tb_prod_order_cps2_det cpsd
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order`=cpsd.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code` ='33'
WHERE cpsd.id_prod_order_cps2='" & id & "'
GROUP BY cd.`display_name`,cpsd.`id_prod_order`"
        viewSearchLookupRepositoryQuery(RISLESize, q, 0, "size", "size")
    End Sub
End Class