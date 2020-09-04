Public Class FormProductionSampleOrder
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
    End Sub

    Sub load_det()
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
            query = "SELECT kpd.eta_copy_proto_2,kpd.revision,kpd.id_prod_order_cps2_det,'' AS `no`,po.`prod_order_number`,LEFT(dsg.design_display_name,LENGTH(dsg.design_display_name)-3) AS class_dsg,RIGHT(dsg.design_display_name,3) AS color
,IFNULL(revtimes.revision_times,0) AS revision_times
,kpd.eta_copy_proto_2
,kpd.qty_order
FROM `tb_prod_order_cps2_det` kpd
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
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
            query = "UPDATE tb_prod_order_cps2_det SET eta_copy_proto_2='" & eta_copy_proto_2 & "' WHERE id_prod_order_cps2_det='" & GVProd.GetRowCellValue(i, "id_prod_order_cps2_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
        Next
        infoCustom("Order updated")
        load_head()
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        Dim query As String = "UPDATE tb_prod_order_cps2 SET is_locked='1' WHERE id_prod_order_cps='" & id & "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Order locked")
        load_head()
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
                Dim q_det As String = "SELECT cps2d.`revision`,cps2d.`id_prod_order`,cps2d.`id_purc_order`,2 AS qty_order,cps2d.`eta_copy_proto_2`
FROM tb_prod_order_cps2_det cps2d
WHERE id_prod_order_cps2='" & id & "'"
                Dim data_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                query = ""
                For i As Integer = 0 To data_det.Rows.Count - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & new_id_cps2 & "','" & data_det.Rows(i)("revision").ToString & "','" & data_det.Rows(i)("id_prod_order").ToString & "','" & data_det.Rows(i)("id_purc_order").ToString & "','" & data_det.Rows(i)("qty_order").ToString & "','" & Date.Parse(data_det.Rows(i)("eta_copy_proto_2").ToString).ToString("yyyy-MM-dd") & "')"
                Next

                If Not query = "" Then
                    query = "INSERT INTO tb_prod_order_cps2_det(`id_prod_order_cps2`,`revision`,`id_prod_order`,`id_purc_order`,`qty_order`,`eta_copy_proto_2`)
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
End Class