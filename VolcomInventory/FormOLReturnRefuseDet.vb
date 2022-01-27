Public Class FormOLReturnRefuseDet
    Public is_view As String = "-1"
    Public action As String = "-1"
    Public id As String = "-1"
    Public id_sales_order As String = "-1"
    Dim scan_mode As String = ""
    Public dt As DataTable
    Dim id_report_status As String = "-1"
    Public rmt As String = "290"
    Public id_store_contact As String = "-1"
    Dim form_title As String
    Dim is_non_fisik As String = "-1"

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
        Dim rrf As New ClassOLReturnRefuse()
        form_title = rrf.getFormName(rmt)
        Text = form_title
        If action = "ins" Then
            Dim dt_now As DateTime = getTimeDB()
            DECreated.EditValue = dt_now
            TxtStoreAcc.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("comp_number").ToString
            TxtStore.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("comp_name").ToString
            TxtOrderNumber.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
            TxtCustomerName.Text = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("customer_name").ToString
            viewDetail()
            viewCollectionCode()
        ElseIf action = "upd" Then
            'main
            Dim query_c As ClassOLReturnRefuse = New ClassOLReturnRefuse()
            Dim query As String = query_c.queryMain("AND r.id_return_refuse=" + id + " ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            TxtStoreAcc.Text = data.Rows(0)("comp_number").ToString
            TxtStore.Text = data.Rows(0)("comp_name").ToString
            TxtOrderNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            TxtCustomerName.Text = data.Rows(0)("customer_name").ToString
            SLEType.EditValue = data.Rows(0)("id_refuse_type").ToString
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString

            'detail
            viewDetail()
            allow_status()
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
         SELECT sod.id_sales_order_det, dc.id_pl_sales_order_del_det_counting, IFNULL(dc.id_pl_prod_order_rec_det_unique,0) AS `id_pl_prod_order_rec_det_unique`,
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
        If is_non_fisik = "1" Then
            FormOLReturnRefuseAddNonFisik.ShowDialog()
        Else
            TxtScannedCode.Enabled = True
            scan_mode = "add"
            LabelScannedCode.Appearance.ForeColor = Color.Green
            TxtScannedCode.Properties.Appearance.ForeColor = Color.Green
            TxtScannedCode.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        If is_non_fisik = "1" Then
            If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
                Dim dtf As DataRow() = dt.Select("[code_list]='" + GVData.GetFocusedRowCellValue("scanned_code").ToString + "' AND [id_sales_order_det]='" + GVData.GetFocusedRowCellValue("id_sales_order_det").ToString + "'")
                dtf(0)("is_used") = "2"

                GVData.DeleteSelectedRows()
                '
                GCData.RefreshDataSource()
                GVData.RefreshData()
                GVData.FocusedRowHandle = GVData.RowCount - 1
            End If
        Else
            scan_mode = "delete"
            LabelScannedCode.Appearance.ForeColor = Color.Red
            TxtScannedCode.Properties.Appearance.ForeColor = Color.Red
            TxtScannedCode.Focus()
        End If
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
        Cursor = Cursors.WaitCursor

        Dim report As ReportOLReturnRefuse = New ReportOLReturnRefuse

        report.id = id
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.data = GCData.DataSource
        report.report_mark_type = rmt

        report.LTitle.Text = form_title.ToUpper
        report.LabelNumber.Text = "NO. " + TxtNumber.Text.ToUpper
        report.LabelStore.Text = TxtStoreAcc.Text.ToUpper + " - " + TxtStore.Text.ToUpper
        report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
        report.LabelCustomer.Text = TxtCustomerName.Text.ToUpper
        report.LabelType.Text = SLEType.Text.ToUpper
        report.LabelCreatedDate.Text = DECreated.Text.ToUpper
        report.LabelStatus.Text = LEReportStatus.Text.ToUpper

        report.LabelRemark.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
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
        For d As Integer = 0 To GVData.RowCount - 1
            If d > 0 Then
                id_sales_order_det_in += ","
            End If
            id_sales_order_det_in += GVData.GetRowCellValue(d, "id_sales_order_det").ToString
        Next
        Dim qcek As String = "SELECT sod.id_sales_order_det, IFNULL(cnd.id_sales_pos_det,0) AS `id_sales_pos_det_cn` ,
        IFNULL(rod.id_sales_return_order_det,0) AS `id_sales_return_order_det`, IFNULL(r.id_sales_return,0) AS `id_sales_return`
        FROM tb_sales_order_det sod
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        LEFT JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos_det_ref = spd.id_sales_pos_det
        LEFT JOIN tb_sales_return_order_det rod ON rod.id_sales_order_det = sod.id_sales_order_det AND rod.is_void=2
        LEFT JOIN tb_sales_return_det rd ON rd.id_sales_return_order_det = rod.id_sales_return_order_det
        LEFT JOIN tb_sales_return r ON r.id_sales_return = rd.id_sales_return AND r.id_report_status!=5
        WHERE sod.id_sales_order_det IN(" + id_sales_order_det_in + ") "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        Dim err As String = ""
        For c As Integer = 0 To GVData.RowCount - 1
            Dim id_sales_order_det_cek As String = GVData.GetRowCellValue(c, "id_sales_order_det").ToString
            Dim dcek_filter As DataRow() = dcek.Select("[id_sales_order_det]='" + id_sales_order_det_cek + "' ")
            If dcek_filter.Length > 0 Then
                Dim id_ror_det As String = dcek_filter(0)("id_sales_return_order_det").ToString
                Dim id_cn_det As String = dcek_filter(0)("id_sales_pos_det_cn").ToString
                Dim id_sales_return_cek As String = dcek_filter(0)("id_sales_return").ToString
                GVData.SetRowCellValue(c, "id_sales_return_order_det", id_ror_det)
                GVData.SetRowCellValue(c, "id_sales_pos_det_cn", id_cn_det)
                If id_sales_return_cek <> "0" Then
                    err += GVData.GetRowCellValue(c, "item_id").ToString + " - " + GVData.GetRowCellValue(c, "name").ToString + " Size " + GVData.GetRowCellValue(c, "size").ToString + System.Environment.NewLine
                End If
            End If
        Next

        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking RTS")
        FormMain.SplashScreenManager1.CloseWaitForm()
        If GVData.RowCount <= 0 Then
            warningCustom("Please complete all data")
        ElseIf err <> "" Then
            stopCustom("Return (RTS) already process : " + System.Environment.NewLine + err.ToString)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this transaction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSaveChanges.Enabled = False
                Dim id_refuse_type As String = SLEType.EditValue.ToString
                Dim note As String = addSlashes(MENote.Text)


                'main 
                Dim query As String = "INSERT INTO tb_ol_store_return_refuse(id_refuse_type, number, id_store_contact, id_sales_order,created_date, created_by, note, id_report_status)
                VALUES('" + id_refuse_type + "','','" + id_store_contact + "', '" + id_sales_order + "', NOW(), '" + id_user + "', '" + note + "', 1);SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", " + rmt + "); ", True, "", "", "", "")

                'detail
                Dim query_det As String = "INSERT INTO tb_ol_store_return_refuse_det(id_return_refuse, id_sales_order_det, id_sales_return_order_det, id_sales_pos_det_cn, id_product, id_pl_prod_order_rec_det_unique, scanned_code, qty, id_design_price, design_price) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                    Dim id_sales_return_order_det As String = GVData.GetRowCellValue(i, "id_sales_return_order_det").ToString
                    If id_sales_return_order_det = "0" Then
                        id_sales_return_order_det = "NULL"
                    End If
                    Dim id_sales_pos_det_cn As String = GVData.GetRowCellValue(i, "id_sales_pos_det_cn").ToString
                    If id_sales_pos_det_cn = "0" Then
                        id_sales_pos_det_cn = "NULL"
                    End If
                    Dim id_product As String = GVData.GetRowCellValue(i, "id_product").ToString
                    Dim id_pl_prod_order_rec_det_unique As String = GVData.GetRowCellValue(i, "id_pl_prod_order_rec_det_unique").ToString
                    If id_pl_prod_order_rec_det_unique = "0" Then
                        id_pl_prod_order_rec_det_unique = "NULL"
                    End If
                    Dim scanned_code As String = GVData.GetRowCellValue(i, "scanned_code").ToString
                    Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, "qty").ToString)
                    Dim id_design_price As String = GVData.GetRowCellValue(i, "id_design_price").ToString
                    Dim design_price As String = decimalSQL(GVData.GetRowCellValue(i, "design_price").ToString)

                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id + "', '" + id_sales_order_det + "', " + id_sales_return_order_det + ", " + id_sales_pos_det_cn + ",'" + id_product + "', " + id_pl_prod_order_rec_det_unique + ", '" + scanned_code + "', '" + qty + "', '" + id_design_price + "', '" + design_price + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(rmt, id, id_user)

                'refresh
                FormOLReturnRefuse.viewData()
                FormOLReturnRefuse.GVData.FocusedRowHandle = find_row(FormOLReturnRefuse.GVData, "id_return_refuse", id)
                action = "upd"
                actionLoad()
                infoCustom("Transaction success. Waiting for approval")
                Cursor = Cursors.Default
            End If
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
                    newRow("qty") = 1

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

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim id_type As String = "-1"
        Try
            id_type = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim qry As String = "SELECT rt.is_non_fisik FROM tb_lookup_refuse_type rt WHERE rt.id_refuse_type='" + id_type + "' "
        is_non_fisik = execute_query(qry, 0, True, "", "", "", "")
        TxtScannedCode.Text = ""
        TxtScannedCode.Enabled = False
        viewDetail()
        viewCollectionCode()
        Cursor = Cursors.Default
    End Sub
End Class