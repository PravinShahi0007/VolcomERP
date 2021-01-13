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
rd.id_design_price, rd.design_price, rd.id_oos_final_cat, cat.oos_final_cat,
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
INNER JOIN tb_oos_final_cat cat ON cat.id_oos_final_cat = rd.id_oos_final_cat
WHERE rd.id_sales_pos_oos_recon='" + id + "' ORDER BY rd.id_sales_pos_oos_recon_det ASC "
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
            GCSummary.ContextMenuStrip = CMSSummary
            GCDetail.ContextMenuStrip = CMSSummary
        Else
            MENote.Properties.ReadOnly = True
            BtnCreate.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GCSummary.ContextMenuStrip = Nothing
            GCDetail.ContextMenuStrip = Nothing
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

            'non aktif
            MENote.Properties.ReadOnly = True
            BtnCreate.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GCSummary.ContextMenuStrip = Nothing
            GCDetail.ContextMenuStrip = Nothing
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

    Private Sub CMSSummary_Opened(sender As Object, e As EventArgs) Handles CMSSummary.Opened
        If XTCClosing.SelectedTabPageIndex = 0 Then
            AddDetailToolStripMenuItem.Visible = True
            DeleteDetailToolStripMenuItem.Visible = False
        ElseIf XTCClosing.SelectedTabPageIndex = 1 Then
            AddDetailToolStripMenuItem.Visible = False
            DeleteDetailToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub AddDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDetailToolStripMenuItem.Click
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 And is_confirm = 2 Then
            Cursor = Cursors.WaitCursor
            FormSalesPOSClosingNoStockDetail.id = id
            FormSalesPOSClosingNoStockDetail.id_sales_pos_prob = GVSummary.GetFocusedRowCellValue("id_sales_pos_prob").ToString
            FormSalesPOSClosingNoStockDetail.id_comp = GVSummary.GetFocusedRowCellValue("id_comp").ToString
            FormSalesPOSClosingNoStockDetail.id_sales_pos = GVSummary.GetFocusedRowCellValue("id_sales_pos").ToString
            FormSalesPOSClosingNoStockDetail.LinkInvoice.Text = GVSummary.GetFocusedRowCellValue("sales_pos_number").ToString
            FormSalesPOSClosingNoStockDetail.TxtStore.Text = GVSummary.GetFocusedRowCellValue("comp_number").ToString
            FormSalesPOSClosingNoStockDetail.TxtStoreName.Text = GVSummary.GetFocusedRowCellValue("comp_name").ToString
            FormSalesPOSClosingNoStockDetail.id_product = GVSummary.GetFocusedRowCellValue("id_product").ToString
            FormSalesPOSClosingNoStockDetail.TxtSKU.Text = GVSummary.GetFocusedRowCellValue("code").ToString
            FormSalesPOSClosingNoStockDetail.TxtName.Text = GVSummary.GetFocusedRowCellValue("name").ToString
            FormSalesPOSClosingNoStockDetail.TxtSize.Text = GVSummary.GetFocusedRowCellValue("size").ToString
            FormSalesPOSClosingNoStockDetail.id_design_price = GVSummary.GetFocusedRowCellValue("id_design_price").ToString
            FormSalesPOSClosingNoStockDetail.TxtPrice.EditValue = GVSummary.GetFocusedRowCellValue("design_price")
            FormSalesPOSClosingNoStockDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DeleteDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteDetailToolStripMenuItem.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_det As String = GVDetail.GetFocusedRowCellValue("id_sales_pos_oos_recon_det").ToString
                Dim query As String = "DELETE FROM tb_sales_pos_oos_recon_det WHERE id_sales_pos_oos_recon_det='" + id_det + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        'chek file
        Dim cond_file As Boolean = False
        Dim qf As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type='" + rmt + "' AND d.id_report='" + id + "' "
        Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
        If df.Rows.Count > 0 Then
            cond_file = True
        Else
            cond_file = False
        End If

        If Not cond_file Then
            stopCustom("Please attach document first")
            showAttach()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to propose this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                saveChangesHead()
                Dim query As String = "UPDATE tb_sales_pos_oos_recon SET is_confirm=1 WHERE id_sales_pos_oos_recon='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                submit_who_prepared(rmt, id, id_user)

                actionLoad()
                infoCustom("Propose submitted")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        Cursor = Cursors.WaitCursor
        saveChangesHead()
        Cursor = Cursors.Default
    End Sub

    Sub saveChangesHead()
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_sales_pos_oos_recon SET note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_pos_oos_recon='" + id + "'"
        execute_non_query(query, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_sales_pos_oos_recon SET id_report_status=5 WHERE id_sales_pos_oos_recon='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            Try
                FormSalesProbTransHistory.viewClosingNoStock()
            Catch ex As Exception
            End Try
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=3
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_sales_pos_oos_recon SET is_confirm=2 WHERE id_sales_pos_oos_recon=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                Try
                    FormSalesProbTransHistory.viewClosingNoStock()
                Catch ex As Exception
                End Try
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        showAttach()
    End Sub

    Sub showAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_confirm = "1" Or is_view = "1" Or id_report_status = 5 Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Cursor = Cursors.WaitCursor
        RepoLinkInvoice.LinkColor = Color.Black
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        gv = GVDetail
        ReportPOSClosingNoStock.dt = GCDetail.DataSource
        ReportPOSClosingNoStock.id = id
        ReportPOSClosingNoStock.is_pre = "-1"
        ReportPOSClosingNoStock.id_report_status = LEReportStatus.EditValue.ToString
        ReportPOSClosingNoStock.rmt = rmt
        Dim Report As New ReportPOSClosingNoStock()

        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVDetail.AppearancePrint.BandPanel.BorderColor = Color.Black
        Report.GVDetail.AppearancePrint.BandPanel.BackColor = Color.Transparent
        Report.GVDetail.AppearancePrint.BandPanel.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.BandPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        Report.GVDetail.OptionsPrint.UsePrintStyles = True
        Report.GVDetail.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVDetail.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)

        Report.GVDetail.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        Report.GVDetail.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 7, FontStyle.Bold)

        Report.GVDetail.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVDetail.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.GroupRow.Font = New Font("Tahoma", 7, FontStyle.Bold)

        Report.GVDetail.AppearancePrint.HeaderPanel.BorderColor = Color.Black
        Report.GVDetail.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVDetail.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        Report.GVDetail.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        Report.GVDetail.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7.3, FontStyle.Bold)

        Report.GVDetail.AppearancePrint.Row.ForeColor = Color.Black
        Report.GVDetail.AppearancePrint.Row.Font = New Font("Tahoma", 7.3, FontStyle.Regular)

        Report.GVDetail.AppearancePrint.Lines.BackColor = Color.Black

        Report.GVDetail.OptionsPrint.ExpandAllDetails = True
        Report.GVDetail.OptionsPrint.UsePrintStyles = True
        Report.GVDetail.OptionsPrint.PrintDetails = True
        Report.GVDetail.OptionsPrint.PrintFooter = True

        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
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

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            showRef(GVDetail.GetFocusedRowCellValue("id_sales_pos").ToString)
        End If
    End Sub

    Sub showRef(ByVal id_inv As String)
        Cursor = Cursors.WaitCursor
        Dim inv As New FormViewSalesPOS()
        inv.id_sales_pos = id_inv
        inv.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkInvSummary_Click(sender As Object, e As EventArgs) Handles RepoLinkInvSummary.Click
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            showRef(GVSummary.GetFocusedRowCellValue("id_sales_pos").ToString)
        End If
    End Sub
End Class