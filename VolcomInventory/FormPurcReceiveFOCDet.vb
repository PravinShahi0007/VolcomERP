Public Class FormPurcReceiveFOCDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_purc_order As String = "-1"
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Private Sub FormPurcReceiveFOCDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'purc order detail
            TxtDO.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            DEArrivalDate.EditValue = getTimeDB()
            DEArrivalDate.Properties.MaxValue = DECreated.EditValue
            viewSummary()
            XTCReceive.SelectedTabPageIndex = 2
        Else
            XTCReceive.SelectedTabPageIndex = 0

            Dim r As New ClassPurcReceive()
            Dim query As String = r.queryMainFOC("AND r.id_purc_rec_foc='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            '
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtNumber.Text = data.Rows(0)("purc_rec_foc_number").ToString
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

    Sub viewSummary()
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT 0 AS `id_purc_rec_foc_det`,0 AS `id_purc_rec_foc`,
            pod.id_item, i.item_desc, i.id_uom, u.uom, CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail,
            pod.id_purc_order_det, pod.`value`, SUM(pod.qty) AS `qty_order`, 0.00 AS qty, 0.00 AS amount, (SUM(pod.qty)-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_rem`, '' AS  `note`, '' AS `stt`
            ,u_st.uom AS uom_stock,i.stock_convertion, CONCAT('1:',i.stock_convertion) AS stock_convertion_view, 0.00 AS `qty_stock`
            FROM tb_purc_order_det pod
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            LEFT JOIN (
	            SELECT rd.id_item, SUM(rd.qty) AS `qty` ,rd.`id_purc_order_det`
	            FROM tb_purc_rec_foc_det rd
	            INNER JOIN tb_purc_rec_foc r ON r.id_purc_rec_foc = rd.id_purc_rec_foc
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
            GROUP BY pod.id_item, BINARY CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) "
        ElseIf action = "upd" Then
            query = "SELECT rd.id_purc_rec_foc_det, rd.id_purc_rec_foc,  
            rd.id_item, i.item_desc, i.id_uom, u.uom, CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail,
            rd.id_purc_order_det, pod.`value`, SUM(pod.qty) AS `qty_order`, SUM(rd.qty) AS `qty`, 0.00 AS amount, rd.note,  '' AS `stt`
            ,u_st.uom AS uom_stock,i.stock_convertion, CONCAT('1:',i.stock_convertion) AS stock_convertion_view, SUM(rd.qty*i.stock_convertion) AS `qty_stock`
            FROM tb_purc_rec_foc_det rd
            INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
            INNER JOIN tb_item i ON i.id_item = rd.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            INNER JOIN tb_m_uom u_st ON u_st.id_uom = i.id_uom_stock
            WHERE rd.id_purc_rec_foc=" + id + " 
            GROUP BY rd.id_item,BINARY CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) "
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
        TxtDO.Enabled = False
        DEArrivalDate.Enabled = False

        If check_edit_report_status(id_report_status, "300", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormPurcReceiveFOCDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancel this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_purc_rec_foc SET id_report_status=5 WHERE id_purc_rec_foc='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 300, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormPurcReceive.viewListFOC()
            FormPurcReceive.GVReceive.FocusedRowHandle = find_row(FormPurcReceive.GVReceiveFOC, "id_purc_rec_foc", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            If XTCReceive.SelectedTabPageIndex = 0 Then
                gcx = GCSummary
                gvx = GVSummary
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
        Else
            If XTCReceive.SelectedTabPageIndex = 0 Then
                print_raw_no_export(GCSummary)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "300"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "300", id) Then
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
            FormReportMark.report_mark_type = "300"
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
        Dim id_purc_rec_foc_det As String = GVSummary.GetRowCellValue(rh, "id_purc_rec_foc_det").ToString
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
	                FROM tb_purc_rec_foc_det rd
	                INNER JOIN tb_purc_rec_foc r ON r.id_purc_rec_foc = rd.id_purc_rec_foc
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVSummary.Columns("qty").SummaryItem.SummaryValue <= 0 Or TxtDO.Text = "" Or DEArrivalDate.EditValue = Nothing Then
            warningCustom("Please complete all data")
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

                Dim qm As String = "INSERT INTO tb_purc_rec_foc(id_purc_order, purc_rec_foc_number, date_created, created_by, note, is_confirm, do_vendor_number, date_arrived, is_delivered) VALUES 
                ('" + id_purc_order + "', '', NOW(),'" + id_user + "', '" + note + "', 1, '" + do_vendor_number + "', '" + date_arrived + "', '" + is_delivered + "'); SELECT LAST_INSERT_ID(); "

                id = execute_query(qm, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id + ", 300); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_purc_rec_foc_det(id_purc_rec_foc, id_item, id_purc_order_det, qty, qty_stock, note) VALUES "

                For d As Integer = 0 To GVSummary.RowCount - 1
                    Dim id_item As String = GVSummary.GetRowCellValue(d, "id_item").ToString
                    Dim id_purc_order_det As String = GVSummary.GetRowCellValue(d, "id_purc_order_det").ToString
                    Dim qty As String = decimalSQL(GVSummary.GetRowCellValue(d, "qty").ToString)
                    Dim qty_stock As String = decimalSQL(GVSummary.GetRowCellValue(d, "qty_stock").ToString)
                    Dim note_detail As String = ""

                    qd += "('" + id + "', '" + id_item + "', '" + id_purc_order_det + "', '" + qty + "', '" + qty_stock + "', '" + note_detail + "'), "
                Next

                If GVSummary.RowCount > 0 Then
                    execute_non_query(qd.Substring(0, qd.Length - 2), True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(300, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                FormPurcReceive.viewOrder()

                infoCustom("Purchase Receive FOC : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")

                Cursor = Cursors.Default
            Else
                XTCReceive.SelectedTabPageIndex = 0
            End If
        End If
    End Sub

    Sub update_changes()
        Dim id_purc_store As String = get_purc_setup_field("id_purc_store")

        Dim qs As String = "INSERT INTO tb_storage_item (
                    `id_departement`,
	                `id_storage_category`,
	                `id_item`,
	                `value`,
	                `report_mark_type`,
	                `id_report`,
	                `storage_item_qty`,
	                `storage_item_datetime`,
	                `storage_item_notes`,
	                `id_stock_status`
                )
                SELECT '" & id_purc_store & "' AS id_departement, 1, rd.id_item, 0.00 AS `value`, 300, " + id + ", rd.qty_stock, NOW(),'', 1
                FROM tb_purc_rec_foc_det rd
                INNER JOIN tb_purc_rec_foc r ON r.id_purc_rec_foc=rd.id_purc_rec_foc
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.qty_stock > 0 AND rd.id_purc_rec_foc=" + id + " AND cat.id_expense_type=1 AND i.id_item_type='1' AND r.is_delivered='2'; "
        execute_non_query(qs, True, "", "", "", "")
    End Sub
End Class