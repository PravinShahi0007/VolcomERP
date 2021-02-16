Public Class FormOLReturnRefuseDet
    Public is_view As String = "-1"
    Public action As String = "-1"
    Public id As String = "-1"
    Public id_sales_order As String = "-1"
    Dim scan_mode As String = ""
    Dim dt As DataTable
    Dim id_report_status As String = "-1"
    Public rmt As String = "290"

    Private Sub FormOLReturnRefuseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewType()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim dt_now As DateTime = getTimeDB()
            DECreated.EditValue = dt_now
            TxtStoreAcc.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("comp_number").ToString
            TxtStore.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("comp_name").ToString
            TxtOrderNumber.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
            viewDetail()
            viewCollectionCode()
        ElseIf action = "upd" Then
            'main
            'Dim query_c As ClassRetOLStore = New ClassRetOLStore()
            'Dim query As String = query_c.queryMain("AND r.id_ol_store_ret=" + id + " ", "2")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'TxtNumber.Text = data.Rows(0)("number").ToString
            'DECreated.EditValue = data.Rows(0)("created_date")
            'TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            'SLECompGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            'TxtOrderNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            'id_ret_req = data.Rows(0)("id_ol_store_ret_req").ToString
            'TxtRetRequest.Text = data.Rows(0)("ret_req_number").ToString
            'DERecDate.EditValue = data.Rows(0)("rec_date")
            'MENote.Text = data.Rows(0)("note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'id_report_status = data.Rows(0)("id_report_status").ToString

            ''detail
            'viewDetail()
            'allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.id_refuse_type, t.refuse_type FROM tb_lookup_refuse_type t ORDER BY t.id_refuse_type ASC"
        viewSearchLookupQuery(SLEType, query, "id_refuse_type", "refuse_type", "id_refuse_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '' AS `no`,d.id_return_refuse_det, d.id_return_refuse, 
        IFNULL(d.id_sales_order_det,0) AS `id_sales_order_det`, sod.item_id, sod.ol_store_id,
        IFNULL(d.id_sales_return_order_det,0) AS `id_sales_return_order_det`, IFNULL(d.id_sales_pos_det_cn,0) AS `id_sales_pos_det_cn`,
        d.id_product, p.product_name AS `name`, cd.display_name AS `size`,
        IFNULL(d.id_pl_prod_order_rec_det_unique,0) AS `id_pl_prod_order_rec_det_unique`, d.scanned_code, d.qty, 
        d.id_design_price, d.design_price 
        FROM tb_ol_store_return_refuse_det d
        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
        LEFT JOIN tb_m_product p ON p.id_product = d.id_product
        LEFT JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        LEFT JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE d.id_return_refuse='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewCollectionCode()
        Cursor = Cursors.WaitCursor
        Try
            dt.Clear()
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT a.*, (a.qty-IFNULL(s.qty_save,0)) AS `qty_limit`, '2' AS is_used
        FROM (
         SELECT sod.id_sales_order_det, dc.id_pl_sales_order_del_det_counting,  
         sod.id_product,CONCAT(p.product_full_code, dc.pl_sales_order_del_det_counting) AS `code_list`, 
         p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id, 
         COUNT(CONCAT(p.product_full_code, dc.pl_sales_order_del_det_counting)) AS `qty`, dd.id_design_price, dd.design_price
         FROM tb_sales_order so
         INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
         INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
         INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
         INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
         LEFT JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
         INNER JOIN tb_m_product p ON p.id_product = dd.id_product
         INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
         INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
         WHERE so.id_sales_order='" + id_sales_order + "' 
         GROUP BY code_list,sod.id_sales_order_det
        ) a
        LEFT JOIN (
         SELECT rd.scanned_code,rd.id_sales_order_det, COUNT(rd.scanned_code) AS `qty_save` 
          FROM tb_ol_store_return_refuse r
          INNER JOIN tb_ol_store_return_refuse_det rd ON rd.id_return_refuse = r.id_return_refuse
          WHERE r.id_sales_order='" + id_sales_order + "' 
          AND r.id_report_status!=5
          GROUP BY rd.scanned_code,rd.id_sales_order_det
        ) s ON s.scanned_code = a.code_list AND s.id_sales_order_det=a.id_sales_order_det
        HAVING qty_limit>0 "
        dt = execute_query(query, -1, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLEType.Enabled = False
        MENote.Enabled = False
        BtnSaveChanges.Visible = False
        PanelControlNav.Visible = False
        BtnMark.Visible = True
        BtnPrint.Visible = True
        MENote.Enabled = False

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        TxtScannedCode.Enabled = True
        scan_mode = "add"
        LabelScannedCode.Appearance.ForeColor = Color.Green
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Green
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        scan_mode = "delete"
        LabelScannedCode.Appearance.ForeColor = Color.Red
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Red
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLReturnRefuseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this transaction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_store_return_refuse SET id_report_status=5 WHERE id_return_refuse='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormOLReturnRefuse.viewData()
            FormOLReturnRefuse.GVData.FocusedRowHandle = find_row(FormOLReturnRefuse.GVData, "id_return_refuse", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor

        'Dim report As ReportRetOLStoreDet = New ReportRetOLStoreDet

        'report.id = id
        'report.id_pre = If(id_report_status = "6", "-1", "1")
        'report.data = GCData.DataSource
        'report.report_mark_type = rmt

        'report.LabelNumber.Text = "NO. " + TxtNumber.Text.ToUpper
        'report.LabelStoreGroup.Text = SLECompGroup.Text.ToUpper
        'report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
        'report.LabelRetRequest.Text = TxtRetRequest.Text.ToUpper
        'report.LabelReceivedDate.Text = DERecDate.Text.ToUpper
        'report.LabelCreatedDate.Text = DECreated.Text.ToUpper
        'report.LabelStatus.Text = LEReportStatus.Text.ToUpper

        'report.LabelRemark.Text = MENote.Text

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        'Tool.ShowPreview()

        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        makeSafeGV(GVData)
        'check cn ror
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking CN/ROR")
        Dim id_sales_order_det_in As String = ""

        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking RTS")
        FormMain.SplashScreenManager1.CloseWaitForm()
        If GVData.RowCount <= 0 Then
            warningCustom("Please complete all data")
        Else

        End If
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyData = Keys.Enter Then
            Dim code As String = addSlashes(TxtScannedCode.Text)
            If scan_mode = "add" Then
                ' add scan
                Dim dtf As DataRow() = dt.Select("[code_list]='" + code + "' AND [is_used]='2'")
                If dtf.Length <= 0 Then
                    stopCustomDialog("Code : " + code + " not found or already scanned.")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    makeSafeGV(GVData)
                    Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                    newRow("id_return_refuse_det") = "0"
                    newRow("id_return_refuse") = "0"
                    newRow("id_sales_order_det") = dtf(0)("id_sales_order_det").ToString
                    newRow("id_sales_return_order_det") = "0"
                    newRow("id_sales_pos_det_cn") = "0"
                    newRow("id_product") = dtf(0)("id_product").ToString
                    newRow("id_pl_prod_order_rec_det_unique") = dtf(0)("id_pl_sales_order_del_det_counting").ToString
                    newRow("scanned_code") = dtf(0)("code_list").ToString
                    newRow("name") = dtf(0)("name").ToString
                    newRow("size") = dtf(0)("size").ToString
                    newRow("item_id") = dtf(0)("item_id").ToString
                    newRow("ol_store_id") = dtf(0)("ol_store_id").ToString
                    newRow("id_design_price") = dtf(0)("id_design_price").ToString
                    newRow("design_price") = dtf(0)("design_price")

                    TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    '
                    dtf(0)("is_used") = "1"
                    '
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                End If
            Else
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[scanned_code]='" + code + "'"
                If GVData.RowCount > 0 Then
                    Dim dtf As DataRow() = dt.Select("[code_list]='" + GVData.GetFocusedRowCellValue("scanned_code").ToString + "' AND [id_sales_order_det]='" + GVData.GetFocusedRowCellValue("id_sales_order_det").ToString + "'")
                    dtf(0)("is_used") = "2"

                    GVData.DeleteSelectedRows()
                    '
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    stopCustomDialog("Code : " + code + " not found. ")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                End If
                GVData.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class