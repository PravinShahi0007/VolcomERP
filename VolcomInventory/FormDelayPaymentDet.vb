Public Class FormDelayPaymentDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_submit As String = "-1"
    Dim rmt As String = "233"
    Public id_comp_group As String = "-1"

    Private Sub FormDelayPaymentDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormDelayPaymentDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim query_c As ClassDelayPayment = New ClassDelayPayment()
        Dim query As String = query_c.queryMain("AND dp.id_propose_delay_payment=" + id + " ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DEDueDate.EditValue = data.Rows(0)("due_date")
        id_comp_group = data.Rows(0)("id_comp_group").ToString
        TxtStoreGroup.Text = data.Rows(0)("group").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_submit = data.Rows(0)("is_submit").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        viewDetail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dd.id_propose_delay_payment_det, dd.id_propose_delay_payment, 
        dd.id_sales_pos, sp.sales_pos_number, CONCAT(dd.comp_number, ' - ', dd.comp_name) AS `store`, 
        sp.sales_pos_date, sp.sales_pos_due_date, CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`, dd.amount, 
        dd.remark 
        FROM tb_propose_delay_payment_det dd
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = dd.id_sales_pos
        WHERE dd.id_propose_delay_payment=" + id + "
        ORDER BY dd.id_propose_delay_payment_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_submit = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Properties.ReadOnly = False
            GVData.OptionsBehavior.ReadOnly = False
            DEDueDate.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            DEDueDate.Enabled = False
        End If

        'reset propose
        If is_view = "-1" And is_submit = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            DEDueDate.Enabled = False
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormDelayPaymentPick.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item(s) ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_propose_delay_payment_det As String = GVData.GetFocusedRowCellValue("id_propose_delay_payment_det").ToString
                Dim query As String = "DELETE FROM tb_propose_delay_payment_det WHERE id_propose_delay_payment_det=" + id_propose_delay_payment_det + " "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_propose_delay_payment SET id_report_status=5, updated_date=NOW(), updated_by='" + id_user + "' WHERE id_propose_delay_payment='" + id + "'; "
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormDelayPayment.SLEStoreGroup.EditValue = id_comp_group
            FormDelayPayment.viewData()
            FormDelayPayment.GVData.FocusedRowHandle = find_row(FormDelayPayment.GVData, "id_propose_delay_payment", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_submit = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'RepoLinkPD.LinkColor = Color.Black
        'If Not check_allow_print(id_report_status, rmt, id) Then
        '    warningCustom("Can't print, please complete all approval on system first")
        'Else
        '    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    gv = GVData
        '    ReportFGDesignListChanges.dt = GCData.DataSource
        '    ReportFGDesignListChanges.id = id
        '    If id_report_status <> "6" Then
        '        ReportFGDesignListChanges.is_pre = "1"
        '    Else
        '        ReportFGDesignListChanges.is_pre = "-1"
        '    End If
        '    ReportFGDesignListChanges.id_report_status = LEReportStatus.EditValue.ToString

        '    ReportFGDesignListChanges.rmt = rmt
        '    Dim Report As New ReportFGDesignListChanges()

        '    '... 
        '    ' creating And saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'style
        '    Report.GVData.AppearancePrint.BandPanel.BorderColor = Color.Black
        '    Report.GVData.AppearancePrint.BandPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.BandPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.BandPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        '    Report.GVData.OptionsPrint.UsePrintStyles = True
        '    Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)

        '    Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        '    Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 7, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 7, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.HeaderPanel.BorderColor = Color.Black
        '    Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        '    Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7.3, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.Row.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 7.3, FontStyle.Regular)

        '    Report.GVData.AppearancePrint.Lines.BackColor = Color.Black

        '    Report.GVData.OptionsPrint.ExpandAllDetails = True
        '    Report.GVData.OptionsPrint.UsePrintStyles = True
        '    Report.GVData.OptionsPrint.PrintDetails = True
        '    Report.GVData.OptionsPrint.PrintFooter = True

        '    Report.LabelNumber.Text = TxtNumber.Text
        '    Report.LabelDate.Text = DECreated.Text.ToUpper
        '    Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        '    Report.LNote.Text = MENote.Text

        '    ' Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "5" Then
            Dim query_check As String = "SELECT * FROM tb_report_mark rm WHERE id_report='" + id + "' AND rm.report_mark_type='" + rmt + "' "
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub saveHead()
        'head
        Dim note As String = addSlashes(MENote.Text)
        Dim due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query_head As String = "UPDATE tb_propose_delay_payment SET due_date='" + due_date + "',note='" + note + "', updated_date=NOW(), updated_by='" + id_user + "'
        WHERE id_propose_delay_payment='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Sub saveChangesDetail()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        For i As Integer = 0 To GVData.RowCount - 1
            Dim query As String = "UPDATE tb_propose_delay_payment_det SET remark='" + addSlashes(GVData.GetRowCellValue(i, "remark").ToString) + "' 
            WHERE id_propose_delay_payment_det='" + GVData.GetRowCellValue(i, "id_propose_delay_payment_det").ToString + "'; "
            execute_non_query(query, True, "", "", "", "")
        Next
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            saveHead()

            'detail
            saveChangesDetail()

            'refresh
            FormDelayPayment.SLEStoreGroup.EditValue = id_comp_group
            FormDelayPayment.viewData()
            FormDelayPayment.GVData.FocusedRowHandle = find_row(FormDelayPayment.GVData, "id_propose_delay_payment", id)
            actionLoad()
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this memo ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_propose_delay_payment SET is_submit=1 WHERE id_propose_delay_payment='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
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
                UPDATE tb_propose_delay_payment SET is_submit=2 WHERE id_propose_delay_payment=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormDelayPayment.SLEStoreGroup.EditValue = id_comp_group
                FormDelayPayment.viewData()
                FormDelayPayment.GVData.FocusedRowHandle = find_row(FormDelayPayment.GVData, "id_propose_delay_payment", id)
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class