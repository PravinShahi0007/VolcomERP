﻿Public Class FormPurcReceiveDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_purc_order As String = "-1"
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Public id_coa_tag As String = "1"

    Private Sub FormPurcReceiveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If get_opt_purchasing_field("is_freeze_stock_og") = "1" Then
            warningCustom("Stock Take sedang berlangsung")
            Close()
        Else
            viewReportStatus()
            actionLoad()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            Dim err_coa As String = ""

            'cek coa persediaan dan hutang
            Dim cond_coa As Boolean = True

            If id_coa_tag = "1" Then
                Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc d ON d.id_acc = o.acc_coa_receive 
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_vat_in 
            WHERE !ISNULL(d.id_acc) AND !ISNULL(k.id_acc) "
                Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
                If dcoa.Rows.Count <= 0 Then
                    err_coa += "- COA : Vat In & Inventory " + System.Environment.NewLine
                    cond_coa = False
                End If

                'cek coa biaya
                Dim cond_coa_biaya As Boolean = True
                Dim qcoa_biaya As String = "SELECT itm.`id_item_cat`,cat.`item_cat`,coa.`id_item_coa`,dep.`departement` FROM tb_purc_order_det pod
INNER JOIN tb_purc_req_det rd ON rd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=rd.`id_purc_req`
INNER JOIN tb_item itm ON rd.`id_item`=itm.`id_item`
INNER JOIN `tb_item_cat` cat ON cat.`id_item_cat` = itm.`id_item_cat`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
LEFT JOIN tb_item_coa coa ON coa.`id_item_cat`=itm.`id_item_cat` AND req.`id_departement`=coa.`id_departement`
WHERE pod.`id_purc_order`='1' AND ISNULL(coa.id_item_coa)"
                Dim dcoa_biaya As DataTable = execute_query(qcoa_biaya, -1, True, "", "", "", "")
                If dcoa_biaya.Rows.Count > 0 Then
                    For i = 0 To dcoa_biaya.Rows.Count - 1
                        err_coa += "- COA : Mapping Category " & dcoa_biaya.Rows(i)("item_cat").ToString & " for Departement " & dcoa_biaya.Rows(i)("departement").ToString & System.Environment.NewLine
                    Next
                    cond_coa_biaya = False
                End If

                'cek coa vendor
                Dim cond_coa_vendor As Boolean = True
                Dim qcoa_vendor As String = "SELECT c.id_comp, ap.id_acc 
            FROM tb_m_comp c
            LEFT JOIN tb_a_acc ap ON ap.id_acc = c.id_acc_ap
            WHERE c.id_comp=" + id_comp + "
            AND !ISNULL(ap.id_acc) "
                Dim dcoa_vendor As DataTable = execute_query(qcoa_vendor, -1, True, "", "", "", "")
                If dcoa_vendor.Rows.Count <= 0 Then
                    err_coa += "- COA Vendor : AP " & TxtVendor.Text & " " + System.Environment.NewLine
                    cond_coa_vendor = False
                End If

                If Not cond_coa Or Not cond_coa_vendor Or Not cond_coa_biaya Then
                    warningCustom("Hubungi Departemen Akunting untuk setup : " + System.Environment.NewLine + err_coa)
                    Close()
                End If
            Else
                'cabang
                Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc d ON d.id_acc = o.acc_coa_receive_cabang
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_vat_in_cabang 
            WHERE !ISNULL(d.id_acc) AND !ISNULL(k.id_acc) "
                Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
                If dcoa.Rows.Count <= 0 Then
                    err_coa += "- COA : Vat In & Inventory " + System.Environment.NewLine
                    cond_coa = False
                End If

                'cek coa biaya
                Dim cond_coa_biaya As Boolean = True
                Dim qcoa_biaya As String = "SELECT itm.`id_item_cat`,cat.`item_cat`,coa.`id_item_coa`,dep.`departement` FROM tb_purc_order_det pod
INNER JOIN tb_purc_req_det rd ON rd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=rd.`id_purc_req`
INNER JOIN tb_item itm ON rd.`id_item`=itm.`id_item`
INNER JOIN `tb_item_cat` cat ON cat.`id_item_cat` = itm.`id_item_cat`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
LEFT JOIN tb_item_coa coa ON coa.`id_item_cat`=itm.`id_item_cat` AND req.`id_departement`=coa.`id_departement`
WHERE pod.`id_purc_order`='1' AND ISNULL(coa.id_item_coa)"
                Dim dcoa_biaya As DataTable = execute_query(qcoa_biaya, -1, True, "", "", "", "")
                If dcoa_biaya.Rows.Count > 0 Then
                    For i = 0 To dcoa_biaya.Rows.Count - 1
                        err_coa += "- COA : Mapping Category " & dcoa_biaya.Rows(i)("item_cat").ToString & " for Departement " & dcoa_biaya.Rows(i)("departement").ToString & System.Environment.NewLine
                    Next
                    cond_coa_biaya = False
                End If

                'cek coa vendor
                Dim cond_coa_vendor As Boolean = True
                Dim qcoa_vendor As String = "SELECT c.id_comp, ap.id_acc 
            FROM tb_m_comp c
            LEFT JOIN tb_a_acc ap ON ap.id_acc = c.id_acc_cabang_ap
            WHERE c.id_comp=" + id_comp + "
            AND !ISNULL(ap.id_acc) "
                Dim dcoa_vendor As DataTable = execute_query(qcoa_vendor, -1, True, "", "", "", "")
                If dcoa_vendor.Rows.Count <= 0 Then
                    err_coa += "- COA Vendor : AP (Cabang) " + System.Environment.NewLine
                    cond_coa_vendor = False
                End If

                If Not cond_coa Or Not cond_coa_vendor Or Not cond_coa_biaya Then
                    warningCustom("Hubungi Departemen Akunting untuk setup : " + System.Environment.NewLine + err_coa)
                    Close()
                End If
            End If

            'cek DP udah complete belum
            Dim q_pn As String = "SELECT pnd.number FROM tb_pn_det pnd
INNER JOIN tb_pn pn ON pn.id_pn=pnd.`id_pn`
WHERE pn.`id_report_status`!=6 AND pn.`id_report_status`!=5 AND (pnd.`report_mark_type`='148' OR pnd.`report_mark_type`='139') AND pnd.`id_report`='" & id_purc_order & "'"
            Dim dt_pn As DataTable = execute_query(q_pn, -1, True, "", "", "", "")
            If dt_pn.Rows.Count > 0 Then
                stopCustom("Please contact accounting, please complete DP for PO number : " & dt_pn.Rows(0)("number").ToString)
                Close()
            End If

            'purc order detail
            TxtDO.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            DEArrivalDate.EditValue = getTimeDB()
            DEArrivalDate.Properties.MaxValue = DECreated.EditValue
            viewSummary()
            XTCReceive.SelectedTabPageIndex = 2
            CEShowHighlight.Checked = True
        Else
            XTCReceive.SelectedTabPageIndex = 0

            Dim r As New ClassPurcReceive()
            Dim query As String = r.queryMain("AND r.id_purc_rec='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            '
            If data.Rows(0)("is_delivered").ToString = "1" Then
                CEAlreadyDeliver.Checked = True
            Else
                CEAlreadyDeliver.Checked = False
            End If
            '
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtNumber.Text = data.Rows(0)("purc_rec_number").ToString
            created_date = DateTime.Parse(data.Rows(0)("date_created")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("date_created")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_purc_order = data.Rows(0)("id_purc_order").ToString
            TxtOrderNumber.Text = data.Rows(0)("purc_order_number").ToString
            TxtVendor.Text = data.Rows(0)("vendor").ToString
            TxtDO.Text = data.Rows(0)("do_vendor_number").ToString
            DEArrivalDate.EditValue = data.Rows(0)("date_arrived")

            viewSummary()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        If action = "ins" Then
            Dim po As New ClassPurcOrder()
            query = po.queryOrderDetails(id_purc_order, "HAVING qty_remaining>0 AND is_drop='2'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data

            'isi qty
            For i As Integer = 0 To ((GVSummary.RowCount - 1) - GetGroupRowCount(GVSummary))
                If GVSummary.GetRowCellValue(i, "qty") > 0 Then
                    Dim id_item As String = GVSummary.GetRowCellValue(i, "id_item").ToString
                    Dim item_detail As String = GVSummary.GetRowCellValue(i, "item_detail").ToString
                    Dim qty_total As Decimal = GVSummary.GetRowCellValue(i, "qty")
                    makeSafeGV(GVDetail)
                    GVDetail.ActiveFilterString = String.Format("[id_item]='{0}' AND [item_detail] LIKE '{1}'", id_item, item_detail.Replace("'", "''"))
                    For j As Integer = 0 To (GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail)
                        If qty_total > 0 Then
                            Dim qty As Decimal = GVDetail.GetRowCellValue(j, "qty_remaining")
                            Dim qty_input As Decimal = 0.00
                            If qty <= qty_total Then
                                qty_input = qty
                            Else
                                qty_input = qty_total
                            End If
                            GVDetail.SetRowCellValue(j, "qty", qty_input)
                            GVDetail.SetRowCellValue(j, "qty_stock", qty_input * GVDetail.GetRowCellValue(j, "stock_convertion"))
                            qty_total = qty_total - qty_input
                        Else
                            Exit For
                        End If
                    Next
                End If
            Next
            makeSafeGV(GVDetail)
            GVDetail.BestFitColumns()
        ElseIf action = "upd" Then
            query = "SELECT rd.id_purc_order_det,reqd.ship_destination,reqd.ship_address,req.purc_req_number,d.departement, 
            rd.id_item, i.item_desc, i.id_uom, u.uom, pod.`value`, rd.qty ,CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail
            ,CONCAT('1:',i.stock_convertion) AS stock_convertion_view, (rd.qty*i.stock_convertion) AS `qty_stock`,u_st.uom AS uom_stock
            FROM tb_purc_rec_det rd
            INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            INNER JOIN tb_m_uom u_st ON u_st.id_uom = i.id_uom_stock
            INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
            INNER JOIN tb_purc_req req ON req.id_purc_req = reqd.id_purc_req
            INNER JOIN tb_m_departement d ON d.id_departement = req.id_departement
            WHERE rd.id_purc_rec=" + id + "
            ORDER BY req.id_purc_req ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            GVDetail.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewOrderDetails()
        Cursor = Cursors.WaitCursor
        Dim po As New ClassPurcOrder()
        Dim query As String = po.queryOrderDetails(id_purc_order, "")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrderDetail.DataSource = data
        GVOrderDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewSummary()
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT 0 AS `id_purc_rec_det`,0 AS `id_purc_rec`,
            pod.id_item, i.item_desc, i.id_uom, u.uom, CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail,
            pod.id_purc_order_det, pod.`value`, SUM(pod.qty) AS `qty_order`, 0.00 AS qty,(SUM(pod.qty)-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_rem`, '' AS  `note`, '' AS `stt`
            ,u_st.uom AS uom_stock,i.stock_convertion, CONCAT('1:',i.stock_convertion) AS stock_convertion_view, 0.00 AS `qty_stock`
            FROM tb_purc_order_det pod
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            LEFT JOIN (
	            SELECT rd.id_item, SUM(rd.qty) AS `qty` ,rd.`id_purc_order_det`
	            FROM tb_purc_rec_det rd
	            INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
	            WHERE r.id_purc_order=" + id_purc_order + " AND r.id_report_status!=5 
	            GROUP BY rd.id_item,rd.`id_purc_order_det`
            ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
            LEFT JOIN (
	            SELECT retd.id_item, SUM(retd.qty) AS `qty`
	            FROM tb_purc_return_det retd
	            INNER JOIN tb_purc_return ret ON ret.id_purc_return = retd.id_purc_return
	            WHERE ret.id_purc_order=" + id_purc_order + " AND ret.id_report_status=6
	            GROUP BY retd.id_item
            ) retd ON retd.id_item = pod.id_item
            INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
            INNER JOIN tb_m_uom u_st ON u_st.id_uom = i.id_uom_stock
            WHERE pod.is_drop='2' AND pod.id_purc_order=" + id_purc_order + "
            GROUP BY pod.id_item, BINARY CONCAT(LOWER(reqd.item_detail),IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) "
        ElseIf action = "upd" Then
            query = "SELECT rd.id_purc_rec_det, rd.id_purc_rec,  
            rd.id_item, i.item_desc, i.id_uom, u.uom, CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail,
            rd.id_purc_order_det, pod.`value`, SUM(pod.qty) AS `qty_order`, SUM(rd.qty) AS `qty`, rd.note,  '' AS `stt`
            ,u_st.uom AS uom_stock,i.stock_convertion, CONCAT('1:',i.stock_convertion) AS stock_convertion_view, SUM(rd.qty*i.stock_convertion) AS `qty_stock`
            FROM tb_purc_rec_det rd
            INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
            INNER JOIN tb_item i ON i.id_item = rd.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            INNER JOIN tb_m_uom u_st ON u_st.id_uom = i.id_uom_stock
            WHERE rd.id_purc_rec=" + id + " 
            GROUP BY rd.id_item,BINARY CONCAT(LOWER(reqd.item_detail),IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVSummary.OptionsBehavior.Editable = False
        GVDetail.OptionsBehavior.Editable = False
        TxtDO.Enabled = False
        DEArrivalDate.Enabled = False

        If check_edit_report_status(id_report_status, "148", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormPurcReceiveDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancel this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_purc_rec SET id_report_status=5 WHERE id_purc_rec='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 148, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormPurcReceive.viewReceive()
            FormPurcReceive.GVReceive.FocusedRowHandle = find_row(FormPurcReceive.GVReceive, "id_purc_rec", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        'If id_report_status = "6" Then
        '    Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
        '    Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    If XTCReceive.SelectedTabPageIndex = 0 Then
        '        gcx = GCSummary
        '        gvx = GVSummary
        '    ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
        '        gcx = GCDetail
        '        gvx = GVDetail
        '    ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
        '        gcx = GCOrderDetail
        '        gvx = GVOrderDetail
        '    End If
        '    ReportPurcReceive.id = id
        '    ReportPurcReceive.dt = gcx.DataSource
        '    Dim Report As New ReportPurcReceive()

        '    ' '... 
        '    ' ' creating and saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'Grid Detail
        '    ReportStyleGridview(Report.GVData)

        '    'Parse val
        '    Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        '    Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
        '    Report.LabelVendor.Text = TxtVendor.Text.ToUpper
        '    Report.LabelDate.Text = DECreated.Text.ToString
        '    Report.LNote.Text = MENote.Text.ToString
        '    Report.LabelDONumber.Text = TxtDO.Text
        '    Report.LabelArrivalDate.Text = DEArrivalDate.Text
        '    If XTCReceive.SelectedTabPageIndex = 2 Then
        '        Report.LabelNumber.Visible = False
        '        Report.LabelDate.Visible = False
        '        Report.LNote.Visible = False
        '        Report.LNotex.Visible = False
        '        Report.XrLabel11.Visible = False
        '        Report.XrLabel10.Visible = False
        '        Report.XrLabel18.Visible = False
        '        Report.LabelTitle.Text = "ORDER DETAILS"
        '        Report.XrTable1.Visible = False   '
        '        Report.LabelDONumber.Visible = False
        '        Report.LabelDotDONumber.Visible = False
        '        Report.LabelTitleDONumber.Visible = False
        '        Report.LabelArrivalDate.Visible = False
        '        Report.LabelDotArrivalDate.Visible = False
        '        Report.LabelTitleArrivalDate.Visible = False
        '    End If

        '    'Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'Else
        '    If XTCReceive.SelectedTabPageIndex = 0 Then
        '        print_raw_no_export(GCSummary)
        '    ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
        '        print_raw_no_export(GCDetail)
        '    ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
        '        print_raw_no_export(GCOrderDetail)
        '    End If
        'End If

        Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
        Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        If XTCReceive.SelectedTabPageIndex = 0 Then
            gcx = GCSummary
            gvx = GVSummary
        ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
            gcx = GCDetail
            gvx = GVDetail
        ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
            gcx = GCOrderDetail
            gvx = GVOrderDetail
        End If
        ReportPurcReceive.id = id
        ReportPurcReceive.dt = gcx.DataSource
        Dim Report As New ReportPurcReceive()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVData)

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
        Report.LabelVendor.Text = TxtVendor.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString
        Report.LNote.Text = MENote.Text.ToString
        Report.LabelDONumber.Text = TxtDO.Text
        Report.LabelArrivalDate.Text = DEArrivalDate.Text
        If XTCReceive.SelectedTabPageIndex = 2 Then
            Report.LabelNumber.Visible = False
            Report.LabelDate.Visible = False
            Report.LNote.Visible = False
            Report.LNotex.Visible = False
            Report.XrLabel11.Visible = False
            Report.XrLabel10.Visible = False
            Report.XrLabel18.Visible = False
            Report.LabelTitle.Text = "ORDER DETAILS"
            Report.XrTable1.Visible = False   '
            Report.LabelDONumber.Visible = False
            Report.LabelDotDONumber.Visible = False
            Report.LabelTitleDONumber.Visible = False
            Report.LabelArrivalDate.Visible = False
            Report.LabelDotArrivalDate.Visible = False
            Report.LabelTitleArrivalDate.Visible = False
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "148"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "148", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        'check attachment
        Dim qc As String = "SELECT * FROM tb_doc WHERE report_mark_type='148' AND id_report='" & id & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            FormReportMark.report_mark_type = "148"
            FormReportMark.id_report = id
            FormReportMark.is_view = is_view
            FormReportMark.form_origin = Name
            FormReportMark.ShowDialog()
        Else
            warningCustom("No attachment found")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSummary.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle
        Dim id_purc_order_det As String = GVSummary.GetRowCellValue(rh, "id_purc_order_det").ToString
        Dim id_purc_rec_det As String = GVSummary.GetRowCellValue(rh, "id_purc_rec_det").ToString
        Dim id_item As String = GVSummary.GetRowCellValue(rh, "id_item").ToString
        Dim item_detail As String = addSlashes(GVSummary.GetRowCellValue(rh, "item_detail").ToString)
        If e.Column.FieldName = "qty" Then
            If e.Value >= 0 Then
                Dim old_value As Decimal = 0.00
                Try
                    old_value = sender.ActiveEditor.OldEditValue
                Catch ex As Exception

                End Try
                Dim qcek As String = "SELECT pod.id_purc_order,pod.id_item, SUM(pod.qty) AS `qty_order`, IFNULL(rd.qty,0) AS `qty_rec`,
                (SUM(pod.qty)-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_remaining`,
                pod.`value` 
                FROM tb_purc_order_det pod
                LEFT JOIN (
	                SELECT rd.id_item, SUM(rd.qty) AS `qty`,rd.id_purc_order_det
	                FROM tb_purc_rec_det rd
	                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
	                WHERE r.id_purc_order=" + id_purc_order + " AND rd.id_item=" + id_item + " AND r.id_report_status!=5 
	                GROUP BY rd.id_item,rd.id_purc_order_det
                ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
                LEFT JOIN (
	                SELECT retd.id_item, SUM(retd.qty) AS `qty`
	                FROM tb_purc_return_det retd
	                INNER JOIN tb_purc_return ret ON ret.id_purc_return = retd.id_purc_return
	                WHERE ret.id_purc_order=" + id_purc_order + " AND retd.id_item=" + id_item + " AND ret.id_report_status=6
	                GROUP BY retd.id_item
                ) retd ON retd.id_item = pod.id_item
                INNER JOIN tb_purc_req_det prd ON prd.id_purc_req_det=pod.id_purc_req_det
                WHERE pod.id_purc_order=" + id_purc_order + " AND pod.id_item=" + id_item + " AND CONCAT(prd.item_detail,IF(ISNULL(prd.remark) OR prd.remark='','',CONCAT('\r\n',prd.remark)))='" & item_detail & "'
                GROUP BY pod.id_item, CONCAT(prd.item_detail,IF(ISNULL(prd.remark) OR prd.remark='','',CONCAT('\r\n',prd.remark))) "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                If e.Value > dcek.Rows(0)("qty_remaining") Then
                    warningCustom("Qty can't exceed " + dcek.Rows(0)("qty_remaining").ToString)
                    GVSummary.SetRowCellValue(rh, "qty", old_value)
                End If
                GVSummary.BestFitColumns()
            Else
                GVSummary.SetRowCellValue(rh, "qty", 0)
            End If
            GVSummary.SetRowCellValue(rh, "qty_stock", Decimal.Parse(GVSummary.GetRowCellValue(rh, "stock_convertion").ToString) * Decimal.Parse(GVSummary.GetRowCellValue(rh, "qty").ToString))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCReceive_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReceive.SelectedPageChanged
        If XTCReceive.SelectedTabPageIndex = 0 Then
        ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
            viewDetail()
        ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
            viewOrderDetails()
        End If
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim qty_remaining As String = "0"
            Try
                qty_remaining = currview.GetRowCellValue(e.RowHandle, "qty_remaining")
            Catch ex As Exception
                qty_remaining = "0"
            End Try

            If qty_remaining > 0 Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVOrderDetail.RowStyle, AddressOf custom_cell
        GVOrderDetail.Focus()
    End Sub

    Private Sub GVOrderDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVOrderDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek stock
        XTCReceive.SelectedTabPageIndex = 0
        GridColumnStatus.Visible = False
        Dim cond_data As Boolean = True
        Dim qcs As String = "SELECT pod.id_purc_order,pod.id_item, SUM(pod.qty) AS `qty_order`, IFNULL(rd.qty,0) AS `qty_rec`,
        (SUM(pod.qty)-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_remaining`,
        pod.`value` 
        FROM tb_purc_order_det pod
        LEFT JOIN (
	        SELECT rd.id_item, SUM(rd.qty) AS `qty` 
	        FROM tb_purc_rec_det rd
	        INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
	        WHERE r.id_purc_order=" + id_purc_order + " AND r.id_report_status!=5 
	        GROUP BY rd.id_item
        ) rd ON rd.id_item = pod.id_item
        LEFT JOIN (
	        SELECT retd.id_item, SUM(retd.qty) AS `qty`
	        FROM tb_purc_return_det retd
	        INNER JOIN tb_purc_return ret ON ret.id_purc_return = retd.id_purc_return
	        WHERE ret.id_purc_order=" + id_purc_order + " AND ret.id_report_status=6
	        GROUP BY retd.id_item
        ) retd ON retd.id_item = pod.id_item
        WHERE pod.id_purc_order=" + id_purc_order + " 
        GROUP BY pod.id_item "
        Dim dcs As DataTable = execute_query(qcs, -1, True, "", "", "", "")
        makeSafeGV(GVSummary)
        For i As Integer = 0 To ((GVSummary.RowCount - 1) - GetGroupRowCount(GVSummary))
            Dim id_item_cek As String = GVSummary.GetRowCellValue(i, "id_item").ToString
            Dim qty_cek As Decimal = GVSummary.GetRowCellValue(i, "qty")
            Dim data_filter_cek As DataRow() = dcs.Select("[id_item]='" + id_item_cek + "' ")
            If qty_cek > data_filter_cek(0)("qty_remaining") Then
                GVSummary.SetRowCellValue(i, "stt", "Qty can't exceed " + data_filter_cek(0)("qty_remaining").ToString + ";")
                cond_data = False
            Else
                GVSummary.SetRowCellValue(i, "stt", "OK")
            End If
        Next

        If GVSummary.Columns("qty").SummaryItem.SummaryValue <= 0 Or TxtDO.Text = "" Or DEArrivalDate.EditValue = Nothing Then
            warningCustom("Please complete all data")
        ElseIf Not cond_data Then
            GridColumnStatus.VisibleIndex = 100
            warningCustom("Can't save, some item exceed limit qty")
        Else
            XTCReceive.SelectedTabPageIndex = 1
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'query main
                Dim do_vendor_number As String = addSlashes(TxtDO.Text)
                Dim date_arrived As String = DateTime.Parse(DEArrivalDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text.ToString)
                Dim is_delivered As String = "2"
                If CEAlreadyDeliver.Checked = True Then
                    is_delivered = "1"
                Else
                    is_delivered = "2"
                End If
                Dim qm As String = "INSERT INTO tb_purc_rec(id_purc_order, purc_rec_number, date_created, created_by, note,is_confirm, do_vendor_number,date_arrived,is_delivered) VALUES 
                ('" + id_purc_order + "', '', NOW(),'" + id_user + "','" + note + "',1, '" + do_vendor_number + "', '" + date_arrived + "','" & is_delivered & "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ",148); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_purc_rec_det(id_purc_rec, id_item, id_purc_order_det, qty, qty_stock, note) VALUES "
                For d As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
                    Dim id_item As String = GVDetail.GetRowCellValue(d, "id_item").ToString
                    Dim id_purc_order_det As String = GVDetail.GetRowCellValue(d, "id_purc_order_det").ToString
                    Dim qty As String = decimalSQL(GVDetail.GetRowCellValue(d, "qty").ToString)
                    Dim qty_stock As String = decimalSQL(GVDetail.GetRowCellValue(d, "qty_stock").ToString)
                    Dim note_detail As String = ""

                    If d > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id + "', '" + id_item + "', '" + id_purc_order_det + "', '" + qty + "', '" + qty_stock + "','" + note_detail + "') "
                Next
                If GVDetail.RowCount > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(148, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                FormPurcReceive.viewOrder()

                infoCustom("Purchase Receive : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                Cursor = Cursors.Default
            Else
                XTCReceive.SelectedTabPageIndex = 0
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=148 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class