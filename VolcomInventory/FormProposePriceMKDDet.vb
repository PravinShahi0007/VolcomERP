﻿Public Class FormProposePriceMKDDet
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
        FROM tb_lookup_disc_type d "
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
        FormMain.SplashScreenManager1.ShowWaitForm()
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
        FormMain.SplashScreenManager1.CloseWaitForm()
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
        End If
    End Sub

    Sub saveChangesDetail()
        If action = "upd" Then
            FormMain.SplashScreenManager1.ShowWaitForm()
            GVData.ActiveFilterString = "[id_pp_change_det]>0 AND ([propose_disc]<>[propose_disc_old] OR [propose_price]<>[propose_price_old] OR [propose_price_final]<>[propose_price_final_old] OR [note]<>[note_old]) "
            For u As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Update Detail " + (u + 1).ToString + "/" + GVData.RowCount.ToString)
                Dim id_pp_change_det As String = GVData.GetRowCellValue(u, "id_pp_change_det").ToString
                Dim propose_discount As String = decimalSQL(GVData.GetRowCellValue(u, "propose_disc").ToString)
                Dim propose_price As String = decimalSQL(GVData.GetRowCellValue(u, "propose_price").ToString)
                Dim propose_price_final As String = decimalSQL(GVData.GetRowCellValue(u, "propose_price_final").ToString)
                Dim note As String = addSlashes(GVData.GetRowCellValue(u, "note").ToString)
                Dim qupd As String = "UPDATE tb_pp_change_det SET propose_discount='" + propose_discount + "',
                propose_price='" + propose_price + "', propose_price_final='" + propose_price_final + "', 
                note='" + note + "' WHERE id_pp_change_det='" + id_pp_change_det + "'"
                execute_non_query_long(qupd, True, "", "", "", "")
                Cursor = Cursors.Default
            Next
            GVData.ActiveFilterString = ""
            FormMain.SplashScreenManager1.CloseWaitForm()

            FormMain.SplashScreenManager1.ShowWaitForm()
            GVData.ActiveFilterString = "[id_pp_change_det]=0 AND ([propose_disc]>0 OR [propose_price]>0 OR [propose_price_final]>0 OR [note]<>'') "
            Dim qins As String = "INSERT INTO tb_pp_change_det(id_pp_change, id_design, id_design_price, design_price, age, erp_discount, propose_discount, propose_price, propose_price_final, note) VALUES "
            For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing new detail " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                Dim id_design As String = GVData.GetRowCellValue(i, "id_design").ToString
                Dim id_design_price As String = GVData.GetRowCellValue(i, "id_design_price").ToString
                Dim design_price As String = decimalSQL(GVData.GetRowCellValue(i, "design_price").ToString)
                Dim age As String = decimalSQL(GVData.GetRowCellValue(i, "age").ToString)
                Dim erp_discount As String = decimalSQL(GVData.GetRowCellValue(i, "erp_discount").ToString)
                Dim propose_discount As String = decimalSQL(GVData.GetRowCellValue(i, "propose_disc").ToString)
                Dim propose_price As String = decimalSQL(GVData.GetRowCellValue(i, "propose_price").ToString)
                Dim propose_price_final As String = decimalSQL(GVData.GetRowCellValue(i, "propose_price_final").ToString)
                Dim note As String = addSlashes(GVData.GetRowCellValue(i, "note").ToString)
                If i > 0 Then
                    qins += ","
                End If
                qins += "('" + id + "', '" + id_design + "', '" + id_design_price + "', '" + design_price + "', '" + age + "', '" + erp_discount + "', '" + propose_discount + "', '" + propose_price + "', '" + propose_price_final + "', '" + note + "') "
                Cursor = Cursors.Default
            Next
            If GVData.RowCount > 0 Then
                FormMain.SplashScreenManager1.SetWaitFormDescription("Bulk insert")
                execute_non_query_long(qins, True, "", "", "", "")
            End If
            GVData.ActiveFilterString = ""
            FormMain.SplashScreenManager1.CloseWaitForm()
        End If
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
                Try
                    'head
                    saveHead()

                    'detail
                    saveChangesDetail()

                    'actionLoad()
                    FormProposePriceMKD.viewSummary()
                    FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
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
    Dim t As Integer = 0
    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Dim rh As Integer = e.RowHandle
        If e.Column.FieldName.ToString = "propose_disc" Then
            Cursor = Cursors.WaitCursor
            Dim disc_old As Decimal = GVData.ActiveEditor.OldEditValue
            Dim curr_disc As Decimal = GVData.GetRowCellValue(rh, "curr_disc")
            If e.Value <= curr_disc Then
                stopCustom("Diskon tidak valid")
                GVData.SetRowCellValue(rh, "propose_disc", disc_old)
                Exit Sub
            End If

            If e.Value > 0 Then
                'calculate price
                Dim disc As Decimal = e.Value
                Dim normal_price As Decimal = GVData.GetRowCellValue(rh, "design_price_normal")
                Dim propose_price As Decimal = normal_price * ((100 - disc) / 100)
                Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                GVData.SetRowCellValue(rh, "propose_price", propose_price)
                GVData.SetRowCellValue(rh, "propose_price_final", propose_price_final)
                If disc > 0 Then
                    GVData.SetRowCellValue(rh, "propose_disc_group", "Up to " + Decimal.Parse(disc.ToString).ToString("N0") + "%")
                    GVData.SetRowCellValue(rh, "propose_status", "Turun")
                Else
                    GVData.SetRowCellValue(rh, "propose_disc_group", "")
                    GVData.SetRowCellValue(rh, "propose_status", "")
                End If

                GCData.RefreshDataSource()
                GVData.RefreshData()
                GVData.BestFitColumns()
            Else
                GVData.SetRowCellValue(rh, "propose_price", 0)
                GVData.SetRowCellValue(rh, "propose_price_final", 0)
                GVData.SetRowCellValue(rh, "propose_disc_group", "")
                GVData.SetRowCellValue(rh, "propose_status", "")
                GCData.RefreshDataSource()
                GVData.RefreshData()
                GVData.BestFitColumns()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Function getPP(ByVal normal_price As Decimal, ByVal disc As Decimal) As DataTable
        Dim query As String = "SELECT CAST(" + decimalSQL(normal_price.ToString) + " * ((100-" + decimalSQL(disc.ToString) + ")/100) AS DECIMAL(15,0)) AS `propose_price`,
        TRUNCATE((SELECT propose_price),-3) AS `propose_price_final` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "pth_" + id + ".xlsx"
            exportToXLS(path, "pth_" + id, GCData)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class