Public Class FormTargetSalesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "414"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()
    Dim id_proposal_type As String = "-1"

    Private Sub FormTargetSalesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
        viewReportStatus()
        viewOption()
        actionLoad()
    End Sub

    Private Sub FormTargetSalesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        viewLookupQueryO(LEReportStatus, volcomErpApiGetDT(dt_json, 0), 0, "report_status", "id_report_status")
    End Sub

    Sub viewOption()
        viewSearchLookupQueryO(SLEOptionView, volcomErpApiGetDT(dt_json, 2), "id_type_view", "type_view", "id_type_view")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnCreateNew.Visible = True
            Width = 459
            Height = 150
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            StartPosition = FormStartPosition.CenterScreen
            PanelControlBottom.Visible = False
            PanelControl1.Visible = False
            PanelControlNav.Visible = False

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
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim data As DataTable = volcomErpApiGetDT(dt_json, 1)
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtYear.EditValue = data.Rows(0)("year").ToString
            MENote.Text = data.Rows(0)("note").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtType.Text = data.Rows(0)("proposal_type").ToString
            id_proposal_type = data.Rows(0)("id_proposal_type").ToString
            If id_proposal_type = "1" Then
                SLEOptionView.Enabled = False
                PanelControlOptionView.Visible = False
            End If
            If is_confirm = "1" Then
                SLEOptionView.EditValue = "2"
            End If

            'detail
            allowStatus()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Build query")
        Dim id_option_view As String = ""
        Try
            id_option_view = SLEOptionView.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim qm As String = "SELECT m.id_month, UPPER(m.`month_short`) AS `month` FROM tb_lookup_month m ORDER BY m.id_month ASC "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        Dim col_curr As String = ""
        Dim col_new As String = ""
        For m As Integer = 0 To dm.Rows.Count - 1
            If m > 0 Then
                col_curr += ","
                col_new += ","
            End If
            col_curr += "SUM(CASE WHEN ptd.`month`=" + dm.Rows(m)("id_month").ToString + " THEN ptd.value_before END) AS `CURRENT|" + dm.Rows(m)("month").ToString + "` "
            col_new += "SUM(CASE WHEN ptd.`month`=" + dm.Rows(m)("id_month").ToString + " THEN ptd.value_propose END) AS `NEW PROPOSE|" + dm.Rows(m)("month").ToString + "` "
        Next

        FormMain.SplashScreenManager1.SetWaitFormDescription("Load data")
        Dim query As String = "SELECT ptd.id_store AS `INFO|id_store`, MAX(c.comp_number) AS `INFO|ACC.`, MAX(c.comp_name) AS `INFO|STORE`,ptd.type_view AS `INFO|type_view`,
        " + col_curr + ",
        SUM(ptd.value_before) AS `CURRENT|TTL`,
        " + col_new + ",
        SUM(ptd.value_propose) AS `NEW PROPOSE|TTL`
        FROM (
	        SELECT ptd.id_store, ptd.`month`, ptd.value_before, ptd.value_propose, 1 AS `type_view` 
	        FROM tb_b_revenue_propose_det ptd
	        WHERE ptd.id_b_revenue_propose='" + id + "' "
        If id_option_view = "2" Then
            query += "UNION ALL
	        SELECT t.id_store, t.`month`, t.b_revenue AS `value_before`, 0.00 AS `value_propose`, 2 AS `type_view` 
	        FROM tb_b_revenue t 
	        LEFT JOIN tb_b_revenue_propose_det ptd ON ptd.id_store = t.id_store AND ptd.id_b_revenue_propose='" + id + "'
	        WHERE t.`year`='" + TxtYear.Text + "' AND t.is_active=1 AND ISNULL(ptd.id_store) "
        End If
        query += ") ptd
        INNER JOIN tb_m_comp c ON c.id_comp = ptd.id_store
        GROUP BY ptd.id_store
        ORDER BY `INFO|type_view` ASC, `INFO|ACC.` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        FormMain.SplashScreenManager1.SetWaitFormDescription("Setup view data")
        'clear band
        GVData.Bands.Clear()
        GVData.Columns.Clear()
        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next
        'setu band
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVData.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If Not bandName.Contains("INFO") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"

                        'summary
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        col.SummaryItem.DisplayFormat = "{0:n0}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N0}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVData.GroupSummary.Add(summary)
                    Else
                        col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    End If
                End If
            Next
        Next
        'hide column
        GVData.Columns("INFO|id_store").Visible = False
        GVData.Columns("INFO|type_view").Visible = False

        'hide band current
        If id_proposal_type = "1" Then
            For i As Integer = 0 To GVData.Bands.VisibleBandCount - 1
                Try
                    If GVData.Bands.GetVisibleBand(i).Caption.ToString = "CURRENT" Then
                        GVData.Bands.GetVisibleBand(i).Visible = False
                    End If
                Catch ex As Exception

                End Try
            Next i
        End If

        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        TxtYear.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            PanelControlNav.Visible = False
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
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            PanelControlNav.Visible = False
        End If
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If TxtYear.Text = "" Or TxtYear.Text.Length < 4 Then
            warningCustom("Year not valid.")
            Exit Sub
        End If

        Dim qcek As String = "SELECT * FROM tb_b_revenue_propose p WHERE p.year='" + TxtYear.Text + "' AND p.id_report_status!=5 "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")

        If dcek.Rows.Count > 0 Then
            warningCustom("Please complete all pending propose first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Sub saveHead()
        Dim year As String = TxtYear.Text.ToString
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_b_revenue_propose(year, total, created_date, id_created_user, note, id_report_status, is_confirm)
            VALUES('" + year + "', '0', NOW(), '" + id_user + "', '" + note + "',1,2); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")

            'cek type
            Dim qc As String = "SELECT * FROM tb_b_revenue_propose WHERE year='" + year + "' AND id_b_revenue_propose!='" + id + "' AND id_report_status!=5 "
            Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dc.Rows.Count > 0 Then
                execute_non_query("UPDATE tb_b_revenue_propose SET id_proposal_type=2 WHERE id_b_revenue_propose='" + id + "'", True, "", "", "", "")
            End If

            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');", True, "", "", "", "")
            FormTargetSales.refreshProposeList(True)
            FormTargetSales.GVPropose.FocusedRowHandle = find_row(FormTargetSales.GVPropose, "id_b_revenue_propose", id)
            FormTargetSales.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_b_revenue_propose SET note='" + note + "' WHERE id_b_revenue_propose='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Function checkHead()
        If TxtYear.Text <> "" And TxtYear.Text.Length = 4 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        GVData.ActiveFilterString = ""
        If GVData.RowCount <= 0 Or Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_b_revenue_propose SET is_confirm=1 WHERE id_b_revenue_propose='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
                actionLoad()
                infoCustom("Proposal submitted. Waiting for approval.")
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
                Try
                    'head
                    saveHead()

                    'actionLoad()
                    FormTargetSales.refreshProposeList(False)
                    FormTargetSales.GVPropose.FocusedRowHandle = find_row(FormTargetSales.GVPropose, "id_b_revenue_propose", id)
                    dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
                    actionLoad()
                    infoCustom("Save changes success")
                Catch ex As Exception
                    stopCustom("Error save changes, please contact administrator. " + ex.ToString)
                End Try
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
                UPDATE tb_b_revenue_propose SET is_confirm=2 WHERE id_b_revenue_propose=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormTargetSales.refreshProposeList(False)
                FormTargetSales.GVPropose.FocusedRowHandle = find_row(FormTargetSales.GVPropose, "id_b_revenue_propose", id)
                dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
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
            Dim query As String = "UPDATE tb_b_revenue_propose SET id_report_status=5 WHERE id_b_revenue_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormTargetSales.refreshProposeList(False)
            FormTargetSales.GVPropose.FocusedRowHandle = find_row(FormTargetSales.GVPropose, "id_b_revenue_propose", id)
            dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
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
        ReportTargetSales.id = id
        ReportTargetSales.dt = GCData.DataSource
        ReportTargetSales.rmt = rmt
        Dim Report As New ReportTargetSales()

        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        Report.GVData.OptionsPrint.UsePrintStyles = True
        GVData.AppearancePrint.BandPanel.Font = New Font(Report.GVData.Appearance.Row.Font.FontFamily, Report.GVData.Appearance.Row.Font.Size, FontStyle.Bold)

        Report.GVData.AppearancePrint.BandPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.BandPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.BandPanel.Font = New Font("Segoe UI", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Segoe UI", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupRow.Font = New Font("Segoe UI", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.Row.Font = New Font("Segoe UI", 5, FontStyle.Regular)
        Report.GVData.OptionsPrint.ExpandAllDetails = True
        Report.GVData.OptionsPrint.UsePrintStyles = True
        Report.GVData.OptionsPrint.PrintDetails = True
        Report.GVData.OptionsPrint.PrintFooter = True

        'Parse Val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LNote.Text = MENote.Text
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LabelYear.Text = TxtYear.Text.ToUpper
        Report.LabelType.Text = TxtType.Text.ToUpper

        'Show the report's preview. 
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

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDeletePTH_Click(sender As Object, e As EventArgs) Handles BtnDeletePTH.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_store As String = GVData.GetFocusedRowCellValue("INFO|id_store").ToString
                Dim query As String = "DELETE FROM tb_b_revenue_propose_det WHERE id_b_revenue_propose='" + id + "' AND id_store='" + id_store + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnAddPTH_Click(sender As Object, e As EventArgs) Handles BtnAddPTH.Click
        Cursor = Cursors.WaitCursor
        FormTargetSalesSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEOptionView_EditValueChanged(sender As Object, e As EventArgs) Handles SLEOptionView.EditValueChanged
        Dim id_option_view As String = ""
        Try
            id_option_view = SLEOptionView.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_option_view = "1" Then
            BtnAddPTH.Enabled = True
            BtnDeletePTH.Enabled = True
        Else
            BtnAddPTH.Enabled = False
            BtnDeletePTH.Enabled = False
        End If
        viewDetail()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And id_report_status = "1" And is_confirm = "2" And SLEOptionView.EditValue.ToString = "1" Then
            'edit link
            FormTargetSalesSingle.id_store = GVData.GetFocusedRowCellValue("INFO|id_store").ToString
            FormTargetSalesSingle.ShowDialog()
        End If
    End Sub
End Class