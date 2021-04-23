Public Class FormProposePriceMKDDet
    Public action As String = ""
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "306"

    Private Sub FormProposePriceMKDDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPriceType()
        viewDisc()
        actionLoad()
    End Sub

    Private Sub FormProposePriceMKDDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDisc()
        Dim query As String = "SELECT CAST(d.value AS DECIMAL(5,0)) AS `propose_disc`, CONCAT((SELECT propose_disc),'%') AS `propose_disc_display`
        FROM tb_lookup_disc_type d
        WHERE d.id_disc_type>1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemDisc.DataSource = Nothing
        RepositoryItemDisc.DataSource = data
        RepositoryItemDisc.DisplayMember = "propose_disc_display"
        RepositoryItemDisc.ValueMember = "propose_disc"
    End Sub

    Sub viewPriceType()
        Dim query As String = "SELECT pt.id_design_price_type, pt.design_price_type 
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>2 "
        viewLookupQuery(LEPriceType, query, 0, "design_price_type", "id_design_price_type")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'option
            Width = 501
            Height = 250
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If

            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)
            'default date
            Dim curr_date As DateTime = getTimeDB()
            DEEffectDate.EditValue = curr_date
            DESOHDate.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim mkd As New ClassProposePriceMKD()
            Dim query As String = mkd.queryMain("AND  p.id_pp_change='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            LEPriceType.ItemIndex = LEPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", data.Rows(0)("id_design_price_type").ToString)
            DEEffectDate.EditValue = data.Rows(0)("effective_date")
            DESOHDate.EditValue = data.Rows(0)("soh_sal_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            'detail
            viewDetail()
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim is_show_all As String = ""
        If is_confirm = "2" Then
            is_show_all = "1"
        Else
            is_show_all = "2"
        End If
        Dim query As String = "CALL view_pp_change(" + id + "," + is_show_all + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        DEEffectDate.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            PanelControlSelAll.Visible = True
            GVData.OptionsBehavior.ReadOnly = False
            BtnChangeEffectiveDate.Enabled = True
            DESOHDate.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            PanelControlSelAll.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
            BtnChangeEffectiveDate.Enabled = False
            DESOHDate.Enabled = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            PanelControlShowNonActive.Visible = True
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            PanelControlSelAll.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Sub saveHead()
        'head
        Dim id_design_price_type As String = LEPriceType.EditValue.ToString
        Dim effective_date As String = DateTime.Parse(DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim soh_sal_date As String = DateTime.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_pp_change(id_design_price_type, created_date, effective_date, soh_sal_date, note, id_report_status)
            VALUES('" + id_design_price_type + "', NOW(), '" + effective_date + "', '" + soh_sal_date + "','" + note + "', 1); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');CALL gen_pp_change(" + id + ", '" + effective_date + "');", True, "", "", "", "")
            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            FormProposePriceMKD.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_pp_change SET id_design_price_type='" + id_design_price_type + "',
            soh_sal_date='" + soh_sal_date + "', note='" + note + "' WHERE id_pp_change='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            actionLoad()
        End If
    End Sub

    Sub saveChangesDetail()

    End Sub

    Function checkHead()
        If LEPriceType.EditValue <> Nothing And DEEffectDate.EditValue <> Nothing And DESOHDate.EditValue <> Nothing And MENote.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If Not checkHead() Then
            warningCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If

    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Or Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose Price ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_pp_change SET is_confirm=1 WHERE id_pp_change='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose Price submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        If Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'head
                saveHead()

                'detail
                saveChangesDetail()

                actionLoad()
                FormProposePriceMKD.viewSummary()
                FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            End If
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_pp_change SET is_confirm=2 WHERE id_pp_change=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormProposePriceMKD.viewSummary()
                FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_pp_change SET id_report_status=5 WHERE id_pp_change='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'gv = GVData
            'ReportFGProposePriceDetail.dt = GCData.DataSource
            'ReportFGProposePriceDetail.id = id
            'If id_report_status <> "6" Then
            '    ReportFGProposePriceDetail.is_pre = "1"
            'Else
            '    ReportFGProposePriceDetail.is_pre = "-1"
            'End If
            'ReportFGProposePriceDetail.id_report_status = LEReportStatus.EditValue.ToString

            'ReportFGProposePriceDetail.rmt = rmt
            'Dim Report As New ReportFGProposePriceDetail()

            ''... 
            '' creating And saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''style
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            'Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
            'Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            'Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
            'Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            'Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            'Report.GVData.OptionsPrint.ExpandAllDetails = True
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.OptionsPrint.PrintDetails = True
            'Report.GVData.OptionsPrint.PrintFooter = True

            'Report.LabelNumber.Text = TxtNumber.Text
            'Report.LabelSeason.Text = SLESeason.Text
            'Report.LabelDivision.Text = TxtDivision.Text
            'Report.LabelSource.Text = TxtSource.Text.ToUpper
            'Report.LabelType.Text = TxtType.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToUpper
            'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            'Report.LNote.Text = MENote.Text

            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        End If
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

    Private Sub BtnChangeEffectiveDate_Click(sender As Object, e As EventArgs) Handles BtnChangeEffectiveDate.Click
        Cursor = Cursors.WaitCursor
        FormProposePriceChangeEffective.id = id
        FormProposePriceChangeEffective.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class