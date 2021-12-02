Public Class FormProposePriceMKDDet
    Public action As String = ""
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "306"
    Dim dvs As System.IO.Stream

    Private Sub FormProposePriceMKDDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'save default view
        dvs = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(dvs, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        dvs.Seek(0, System.IO.SeekOrigin.Begin)

        viewReportStatus()
        viewMKDType()
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

    Sub viewMKDType()
        Dim query As String = "SELECT mkd.id_design_mkd, mkd.design_mkd FROM tb_lookup_design_mkd mkd"
        viewLookupQuery(LEMKDType, query, 0, "design_mkd", "id_design_mkd")
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
            'cek on process
            Dim qcek As String = "SELECT * FROM tb_pp_change c WHERE c.id_report_status<5 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                Cursor = Cursors.Default
                stopCustom("Please complete all pending propose first")
                Close()
            End If

            'option
            BtnCreateNew.Visible = True
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
            LEMKDType.ItemIndex = LEMKDType.Properties.GetDataSourceRowIndex("id_design_mkd", data.Rows(0)("id_design_mkd").ToString)
            LEPriceType.ItemIndex = LEPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", data.Rows(0)("id_design_price_type").ToString)
            DEEffectDate.EditValue = data.Rows(0)("effective_date")
            DESOHDate.EditValue = data.Rows(0)("soh_sal_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            DEConfirmDate.EditValue = data.Rows(0)("confirm_date")
            DEPlanEndDate.EditValue = data.Rows(0)("plan_end_date")
            Dim is_show_all As String = ""
            If is_confirm = "2" And id_report_status = "1" Then
                is_show_all = "1"
            Else
                is_show_all = "2"
            End If

            'detail
            viewDetail(is_show_all)
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail(ByVal is_show_all As String)
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading detail")
        Cursor = Cursors.WaitCursor

        Dim query As String = "CALL view_pp_change(" + id + "," + is_show_all + ")"
        Dim data As DataTable = execute_query_no_pooling(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        'option jika eos
        If LEMKDType.EditValue.ToString <> "1" Then
            BandedGridColumnextended_eos.Visible = False
            BandedGridColumncurr_extended_eos.Visible = False
        End If

        'column option
        If is_show_all = "1" Then
            GVData.RestoreLayoutFromStream(dvs, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            dvs.Seek(0, System.IO.SeekOrigin.Begin)
        Else
            gridBandAction.Visible = False
            gridBandOther.Visible = False
            gridBandHistory.Visible = False
            BandedGridColumnno.Visible = False
            BandedGridColumndisc_desc.Visible = False
            BandedGridColumnmkd_normal_view.Visible = False
            BandedGridColumnmkd_30_view.Visible = False
            BandedGridColumnmkd_50_view.Visible = False
            BandedGridColumnmkd_70_view.Visible = False
            BandedGridColumndesign_cat.Visible = False
            BandedGridColumndesign_price_normal.Visible = False
            BandedGridColumnerp_discount.Visible = False
            BandedGridColumnpropose_status.Visible = False
        End If
        GVData.BestFitColumns()
        Cursor = Cursors.Default
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        DEEffectDate.Enabled = False
        LEMKDType.Enabled = False
        LEPriceType.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            BtnChangeEffectiveDate.Enabled = True
            DESOHDate.Enabled = True
            DEPlanEndDate.Enabled = True
            BtnAllProduct.Visible = False
            BtnFinalPropose.Visible = False
            gridBandAction.Visible = True
            BtnBulkEdit.Visible = True
            BtnUseERPRecom.Visible = True
            PanelOpt.Visible = True
            If LEMKDType.EditValue = "1" Then
                BtnExtendedEOS.Visible = True
            End If
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            BtnChangeEffectiveDate.Enabled = False
            DESOHDate.Enabled = False
            DEPlanEndDate.Enabled = False
            BtnAllProduct.Visible = True
            BtnFinalPropose.Visible = True
            gridBandAction.Visible = False
            BtnBulkEdit.Visible = False
            BtnUseERPRecom.Visible = False
            PanelOpt.Visible = False
            BtnExtendedEOS.Visible = False
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
            BtnAllProduct.Visible = False
            BtnFinalPropose.Visible = False
            gridBandAction.Visible = False
            LEPriceType.Enabled = False
            BtnBulkEdit.Visible = False
            BtnUseERPRecom.Visible = False
            PanelOpt.Visible = False
            BtnExtendedEOS.Visible = False
        End If
    End Sub

    Sub saveHead()
        'head
        Dim id_design_mkd As String = LEMKDType.EditValue.ToString
        Dim id_design_price_type As String = LEPriceType.EditValue.ToString
        Dim effective_date As String = DateTime.Parse(DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim plan_end_date As String = DateTime.Parse(DEPlanEndDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim soh_sal_date As String = DateTime.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_pp_change(id_design_mkd,id_design_price_type, created_date, effective_date, soh_sal_date, note, id_report_status, plan_end_date)
            VALUES('" + id_design_mkd + "','" + id_design_price_type + "', NOW(), '" + effective_date + "', '" + soh_sal_date + "','" + note + "', 1, '" + plan_end_date + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');CALL gen_pp_change(" + id + ", '" + effective_date + "');", True, "", "", "", "")
            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            FormProposePriceMKD.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_pp_change SET id_design_price_type='" + id_design_price_type + "',
            soh_sal_date='" + soh_sal_date + "', note='" + note + "', plan_end_date='" + plan_end_date + "' WHERE id_pp_change='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Sub saveChangesDetail()
        If action = "upd" Then
            GVData.ApplyFindFilter("")
            GVData.ActiveFilterString = ""
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            GVData.ActiveFilterString = "[id_pp_change_det]>0 AND ([propose_disc]<>[propose_disc_old] OR [propose_price]<>[propose_price_old] OR [propose_price_final]<>[propose_price_final_old] OR [note]<>[note_old] OR [id_extended_eos]<>[id_extended_eos_old]) "
            For u As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Update Detail " + (u + 1).ToString + "/" + GVData.RowCount.ToString)
                Dim id_pp_change_det As String = GVData.GetRowCellValue(u, "id_pp_change_det").ToString
                Dim propose_discount As String = decimalSQL(GVData.GetRowCellValue(u, "propose_disc").ToString)
                If propose_discount = "" Then
                    propose_discount = "NULL"
                End If
                Dim propose_price As String = decimalSQL(GVData.GetRowCellValue(u, "propose_price").ToString)
                If propose_price = "" Then
                    propose_price = "NULL"
                End If
                Dim propose_price_final As String = decimalSQL(GVData.GetRowCellValue(u, "propose_price_final").ToString)
                If propose_price_final = "" Then
                    propose_price_final = "NULL"
                End If
                Dim note As String = addSlashes(GVData.GetRowCellValue(u, "note").ToString)
                Dim id_extended_eos As String = GVData.GetRowCellValue(u, "id_extended_eos").ToString
                Dim qupd As String = "UPDATE tb_pp_change_det SET propose_discount=" + propose_discount + ",
                propose_price=" + propose_price + ", propose_price_final=" + propose_price_final + ", 
                note='" + note + "',id_extended_eos='" + id_extended_eos + "' WHERE id_pp_change_det='" + id_pp_change_det + "'"
                execute_non_query_long(qupd, True, "", "", "", "")
                Cursor = Cursors.Default
            Next
            GVData.ActiveFilterString = ""
            FormMain.SplashScreenManager1.CloseWaitForm()

            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            GVData.ActiveFilterString = "[id_pp_change_det]=0 AND ([propose_disc]>0 OR [propose_price]>0 OR [propose_price_final]>0 OR [note]<>'' OR [id_extended_eos]<>2) "
            Dim qins As String = "INSERT INTO tb_pp_change_det(id_pp_change, id_design, id_design_price, design_price, age, erp_discount, propose_discount, propose_price, propose_price_final, note, id_extended_eos) VALUES "
            For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing new detail " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                Dim id_design As String = GVData.GetRowCellValue(i, "id_design").ToString
                Dim id_design_price As String = GVData.GetRowCellValue(i, "id_design_price").ToString
                Dim design_price As String = decimalSQL(GVData.GetRowCellValue(i, "design_price").ToString)
                Dim age As String = decimalSQL(GVData.GetRowCellValue(i, "age").ToString)
                Dim erp_discount As String = decimalSQL(GVData.GetRowCellValue(i, "erp_discount").ToString)
                If erp_discount = "" Then
                    erp_discount = "NULL"
                End If
                Dim propose_discount As String = decimalSQL(GVData.GetRowCellValue(i, "propose_disc").ToString)
                If propose_discount = "" Then
                    propose_discount = "NULL"
                End If
                Dim propose_price As String = decimalSQL(GVData.GetRowCellValue(i, "propose_price").ToString)
                If propose_price = "" Then
                    propose_price = "NULL"
                End If
                Dim propose_price_final As String = decimalSQL(GVData.GetRowCellValue(i, "propose_price_final").ToString)
                If propose_price_final = "" Then
                    propose_price_final = "NULL"
                End If
                Dim note As String = addSlashes(GVData.GetRowCellValue(i, "note").ToString)
                Dim id_extended_eos As String = GVData.GetRowCellValue(i, "id_extended_eos").ToString
                If i > 0 Then
                    qins += ","
                End If
                qins += "('" + id + "', '" + id_design + "', '" + id_design_price + "', '" + design_price + "', '" + age + "', " + erp_discount + ", " + propose_discount + ", " + propose_price + ", " + propose_price_final + ", '" + note + "', '" + id_extended_eos + "') "
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
        If LEPriceType.EditValue <> Nothing And DEEffectDate.EditValue <> Nothing And DEPlanEndDate.EditValue <> Nothing And DESOHDate.EditValue <> Nothing And MENote.Text <> "" Then
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
        GVData.ActiveFilterString = ""
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
                Dim query As String = "UPDATE tb_pp_change SET is_confirm=1, confirm_date=NOW(), confirm_by='" + id_user + "' WHERE id_pp_change='" + id + "'"
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
                UPDATE tb_pp_change SET is_confirm=2, confirm_date=NULL, confirm_by=NULL WHERE id_pp_change=" + id + "; "
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
        GVData.ActiveFilterString = "[id_pp_change_det]=0"
        If GVData.RowCount > 1 Then
            viewDetail(2)
        End If
        GVData.ActiveFilterString = ""
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        gv = GVData
        ReportProposePriceMKD.dt = GCData.DataSource
        ReportProposePriceMKD.id = id
        If id_report_status <> "6" Then
            ReportProposePriceMKD.is_pre = "1"
        Else
            ReportProposePriceMKD.is_pre = "-1"
        End If
        ReportProposePriceMKD.id_report_status = LEReportStatus.EditValue.ToString
        ReportProposePriceMKD.rmt = rmt
        Dim Report As New ReportProposePriceMKD()

        'option col
        BandedGridColumndesign_code.Width = 44
        BandedGridColumnname.Width = 84
        BandedGridColumnclass.Width = 26
        BandedGridColumnage.Width = 20
        BandedGridColumndesign_cop.Width = 45
        BandedGridColumndesign_price.Width = 40
        BandedGridColumnprice_type.Width = 20
        BandedGridColumndesign_cat.Width = 26
        BandedGridColumndesign_price_normal.Width = 43
        BandedGridColumncurr_disc.Width = 30
        BandedGridColumnpropose_disc.Width = 43
        BandedGridColumnpropose_price.Width = 62
        BandedGridColumnpropose_price_final.Width = 70
        BandedGridColumnpropose_disc_group.Width = 40
        BandedGridColumntotal_sal.Width = 38
        BandedGridColumntotal_soh.Width = 38
        BandedGridColumntotal_bos.Width = 38
        BandedGridColumnsas.Width = 45
        BandedGridColumntotal_normal_value.Width = 87
        BandedGridColumntotal_current_value.Width = 100
        BandedGridColumntotal_propose_value.Width = 100
        BandedGridColumntotal_cost.Width = 87
        BandedGridColumnmarked_down_value.Width = 114
        If LEMKDType.EditValue = "1" Then
            BandedGridColumncurr_extended_eos.Width = 65
            BandedGridColumnextended_eos.Width = 65
        End If
        BandedGridColumnmark_up.Width = 59
        BandedGridColumnpropose_price_final.AppearanceCell.Font = New Font("Tahoma", 5.3, FontStyle.Bold)
        BandedGridColumnpropose_price_final.AppearanceCell.ForeColor = Color.Black
        For Each c In GVData.FormatRules
            c.Enabled = False
        Next

        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVData.OptionsPrint.UsePrintStyles = True
        Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        Report.GVData.OptionsPrint.ExpandAllDetails = True
        Report.GVData.OptionsPrint.UsePrintStyles = True
        Report.GVData.OptionsPrint.PrintDetails = True
        Report.GVData.OptionsPrint.PrintFooter = True

        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelType.Text = LEMKDType.Text
        Report.LabelEffectiveDate.Text = DEEffectDate.Text.ToUpper
        Report.LabelSOHSalDate.Text = DESOHDate.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        BandedGridColumnpropose_price_final.AppearanceCell.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
        For Each c In GVData.FormatRules
            c.Enabled = True
        Next

        'If Not check_allow_print(id_report_status, rmt, id) Then
        '    warningCustom("Can't print, please complete all approval on system first")
        'Else

        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        'For i As Integer = 0 To GVData.Columns.Count - 1
        '    If GVData.Columns(i).Visible = True Then
        '        Console.WriteLine(GVData.Columns(i).FieldName.ToString + " : " + GVData.Columns(i).Width.ToString)
        '    End If
        'Next
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
        'Dim rh As Integer = e.RowHandle
        'If e.Column.FieldName.ToString = "propose_disc" Then
        '    Cursor = Cursors.WaitCursor
        '    Dim disc_old As Decimal = GVData.ActiveEditor.OldEditValue
        '    Dim curr_disc As Decimal = GVData.GetRowCellValue(rh, "curr_disc")
        '    If e.Value <= curr_disc Then
        '        stopCustom("Diskon tidak valid")
        '        GVData.SetRowCellValue(rh, "propose_disc", disc_old)
        '        Exit Sub
        '    End If

        '    If e.Value > 0 Then
        '        'calculate price
        '        Dim disc As Decimal = e.Value
        '        Dim normal_price As Decimal = GVData.GetRowCellValue(rh, "design_price_normal")
        '        Dim propose_price As Decimal = normal_price * ((100 - disc) / 100)
        '        Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
        '        GVData.SetRowCellValue(rh, "propose_price", propose_price)
        '        GVData.SetRowCellValue(rh, "propose_price_final", propose_price_final)
        '        If disc > 0 Then
        '            GVData.SetRowCellValue(rh, "propose_disc_group", "Up to " + Decimal.Parse(disc.ToString).ToString("N0") + "%")
        '            GVData.SetRowCellValue(rh, "propose_status", "Turun")
        '        Else
        '            GVData.SetRowCellValue(rh, "propose_disc_group", "")
        '            GVData.SetRowCellValue(rh, "propose_status", "")
        '        End If

        '        GCData.RefreshDataSource()
        '        GVData.RefreshData()
        '        GVData.BestFitColumns()
        '    Else
        '        GVData.SetRowCellValue(rh, "propose_price", 0)
        '        GVData.SetRowCellValue(rh, "propose_price_final", 0)
        '        GVData.SetRowCellValue(rh, "propose_disc_group", "")
        '        GVData.SetRowCellValue(rh, "propose_status", "")
        '        GCData.RefreshDataSource()
        '        GVData.RefreshData()
        '        GVData.BestFitColumns()
        '    End If
        '    Cursor = Cursors.Default
        'End If
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

    Dim tot_sal As Decimal
    Dim tot_bos As Decimal
    Dim tot_sal_grp As Decimal
    Dim tot_bos_grp As Decimal
    Dim tot_price As Decimal
    Dim tot_cost As Decimal
    Dim tot_price_grp As Decimal
    Dim tot_cost_grp As Decimal
    Dim is_enable_custom_calc As Boolean = True
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        If is_enable_custom_calc Then
            Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_sal = 0.0
                tot_bos = 0.0
                tot_sal_grp = 0.0
                tot_bos_grp = 0.0

                tot_price = 0.0
                tot_cost = 0.0
                tot_price_grp = 0.0
                tot_cost_grp = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim sal As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_sal").ToString, "0.00"))
                Dim bos As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_bos").ToString, "0.00"))
                Dim price As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_propose_value").ToString, "0.00"))
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost").ToString, "0.00"))
                Select Case summaryID
                    Case "sas_sum"
                        tot_sal += sal
                        tot_bos += bos
                    Case "sas_grp_sum"
                        tot_sal_grp += sal
                        tot_bos_grp += bos
                    Case "markup_sum"
                        tot_price += price
                        tot_cost += cost
                    Case "markup_grp_sum"
                        tot_price_grp += price
                        tot_cost_grp += cost
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case "sas_sum" 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = (tot_sal / tot_bos) * 100
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "sas_grp_sum" 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = (tot_sal_grp / tot_bos_grp) * 100
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "markup_sum"
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = (tot_price / tot_cost)
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "markup_grp_sum"
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = (tot_price_grp / tot_cost_grp)
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case "class_sum"
                        e.TotalValue = GVData.GetGroupRowValue(e.RowHandle).ToString + " Total"
                End Select
            End If
        End If
    End Sub

    Private Sub BtnAllProduct_Click(sender As Object, e As EventArgs) Handles BtnAllProduct.Click
        viewDetail(1)
        allowStatus()
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl3.Paint

    End Sub

    Private Sub BtnFinalPropose_Click(sender As Object, e As EventArgs) Handles BtnFinalPropose.Click
        viewDetail(2)
        allowStatus()
    End Sub

    Private Sub RepoBtnEditPropose_Click(sender As Object, e As EventArgs) Handles RepoBtnEditPropose.Click

    End Sub

    Private Sub RepoBtnEditPropose_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnEditPropose.ButtonClick
        Cursor = Cursors.WaitCursor
        FormProposePriceMKDSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle

    End Sub

    Private Sub LEMKDType_EditValueChanged(sender As Object, e As EventArgs) Handles LEMKDType.EditValueChanged
        If action = "ins" Then
            If LEMKDType.EditValue.ToString = "1" Then
                LEPriceType.ItemIndex = LEPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", "3")
            Else
                LEPriceType.ItemIndex = LEPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", "4")
            End If
        End If
    End Sub

    Private Sub GVData_CustomDrawFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVData.CustomDrawFooter

    End Sub

    Private Sub BtnBulkEdit_Click(sender As Object, e As EventArgs) Handles BtnBulkEdit.Click
        Cursor = Cursors.WaitCursor
        Dim last_filter As String = GVData.ActiveFilterString.ToString
        Dim ftr As String = "[is_select]='Yes' "
        If last_filter <> "" Then
            ftr += "AND " + last_filter
        End If
        GVData.ActiveFilterString = ftr
        If GVData.RowCount > 0 Then
            is_enable_custom_calc = False
            FormProposePriceMKDBulk.ShowDialog()
            is_enable_custom_calc = True
            GCData.RefreshDataSource()
            GVData.RefreshData()
        Else
            stopCustom("No selected items")
        End If
        CESelectAll.EditValue = False
        GVData.ActiveFilterString = "" + last_filter
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkHist_Click(sender As Object, e As EventArgs) Handles RepoLinkHist.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And GVData.GetFocusedRowCellValue("id_pp_change_hist").ToString <> "0" Then
            Cursor = Cursors.WaitCursor
            Dim mkd As New FormProposePriceMKDDet()
            mkd.is_view = "1"
            mkd.action = "upd"
            mkd.id = GVData.GetFocusedRowCellValue("id_pp_change_hist").ToString
            mkd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnHist_Click(sender As Object, e As EventArgs) Handles RepoBtnHist.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormProposePriceMKDHist.id = id
            FormProposePriceMKDHist.id_design = GVData.GetFocusedRowCellValue("id_design").ToString
            FormProposePriceMKDHist.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        For i As Integer = 0 To GVData.RowCount - 1
            If CESelectAll.EditValue = True Then
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                FormMain.SplashScreenManager1.SetWaitFormDescription("Unchecking " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkDesignCode_Click(sender As Object, e As EventArgs) Handles LinkDesignCode.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDesignInfo.id_design = GVData.GetFocusedRowCellValue("id_design").ToString
            FormDesignInfo.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnUseERPRecom_Click(sender As Object, e As EventArgs) Handles BtnUseERPRecom.Click
        Dim id_mkd_type As String = LEMKDType.EditValue.ToString
        If id_mkd_type <> "3" Then 'slain internal sale
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose Price ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                is_enable_custom_calc = False
                Dim last_filter As String = GVData.ActiveFilterString.ToString
                Dim ftr As String = "[is_select]='Yes' "
                If last_filter <> "" Then
                    ftr += "AND " + last_filter
                End If
                GVData.ActiveFilterString = ftr
                If GVData.RowCount > 0 Then
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    For i As Integer = (GVData.RowCount - 1) - GetGroupRowCount(GVData) To 0 Step -1
                        Dim normal_price As Decimal = GVData.GetRowCellValue(i, "design_price_normal")
                        Dim erp_discount_cek As String = GVData.GetRowCellValue(i, "erp_discount").ToString
                        If erp_discount_cek = "" Then
                            GVData.SetRowCellValue(i, "propose_disc", Nothing)
                            GVData.SetRowCellValue(i, "propose_price", Nothing)
                            GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                            GVData.SetRowCellValue(i, "propose_disc_group", "")
                            GVData.SetRowCellValue(i, "propose_status", "")
                        Else
                            Dim erp_discount As Decimal = GVData.GetRowCellValue(i, "erp_discount")
                            Dim propose_disc As Decimal = GVData.GetRowCellValue(i, "erp_discount")
                            Dim propose_price As Decimal = normal_price * ((100 - propose_disc) / 100)
                            Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                            GVData.SetRowCellValue(i, "propose_disc", propose_disc)
                            GVData.SetRowCellValue(i, "propose_price", propose_price)
                            GVData.SetRowCellValue(i, "propose_price_final", propose_price_final)
                            GVData.SetRowCellValue(i, "propose_disc_group", "Up to " + Decimal.Parse(propose_disc.ToString).ToString("N0") + "%")
                            GVData.SetRowCellValue(i, "propose_status", "Turun")
                            'old
                            'If id_mkd_type = "1" Then
                            '    'eos
                            '    If erp_discount > 30 Then
                            '        GVData.SetRowCellValue(i, "propose_disc", Nothing)
                            '        GVData.SetRowCellValue(i, "propose_price", Nothing)
                            '        GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                            '        GVData.SetRowCellValue(i, "propose_disc_group", "")
                            '        GVData.SetRowCellValue(i, "propose_status", "")
                            '    Else
                            '        Dim propose_disc As Decimal = GVData.GetRowCellValue(i, "erp_discount")
                            '        Dim propose_price As Decimal = normal_price * ((100 - propose_disc) / 100)
                            '        Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                            '        GVData.SetRowCellValue(i, "propose_disc", propose_disc)
                            '        GVData.SetRowCellValue(i, "propose_price", propose_price)
                            '        GVData.SetRowCellValue(i, "propose_price_final", propose_price_final)
                            '        GVData.SetRowCellValue(i, "propose_disc_group", "Up to " + Decimal.Parse(propose_disc.ToString).ToString("N0") + "%")
                            '        GVData.SetRowCellValue(i, "propose_status", "Turun")
                            '    End If
                            'Else
                            '    Dim propose_disc As Decimal = GVData.GetRowCellValue(i, "erp_discount")
                            '    Dim propose_price As Decimal = normal_price * ((100 - propose_disc) / 100)
                            '    Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                            '    GVData.SetRowCellValue(i, "propose_disc", propose_disc)
                            '    GVData.SetRowCellValue(i, "propose_price", propose_price)
                            '    GVData.SetRowCellValue(i, "propose_price_final", propose_price_final)
                            '    GVData.SetRowCellValue(i, "propose_disc_group", "Up to " + Decimal.Parse(propose_disc.ToString).ToString("N0") + "%")
                            '    GVData.SetRowCellValue(i, "propose_status", "Turun")
                            'End If
                        End If
                        GVData.SetRowCellValue(i, "check_stt", "2")
                        GVData.SetRowCellValue(i, "is_select", "No")
                    Next
                    GCData.Refresh()
                    GVData.RefreshData()
                    FormMain.SplashScreenManager1.CloseWaitForm()
                Else
                    stopCustom("No selected items")
                End If
                CESelectAll.EditValue = False
                GVData.ActiveFilterString = "" + last_filter
                is_enable_custom_calc = True
                Cursor = Cursors.Default
            End If
        Else
            warningCustom("Fitur ini tidak tersedia untuk pengajuan internal sale")
        End If
    End Sub

    Private Sub FormProposePriceMKDDet_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If is_confirm = 2 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Make sure you are already save changes your proposal. Are you sure you want to exit this form ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BtnExtendedEOS_Click(sender As Object, e As EventArgs) Handles BtnExtendedEOS.Click
        Dim id_mkd_type As String = LEMKDType.EditValue.ToString
        If id_mkd_type = "1" Then
            'check ud extended ato belum
            Cursor = Cursors.WaitCursor
            is_enable_custom_calc = False
            Dim last_filter As String = GVData.ActiveFilterString.ToString
            Dim ftr As String = "[is_select]='Yes' "
            If last_filter <> "" Then
                ftr += "AND " + last_filter
            End If
            GVData.ActiveFilterString = ftr
            If GVData.RowCount > 0 Then
                'check ud extended ato belum
                Dim id_design_selected As String = ""
                For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                    If i > 0 Then
                        id_design_selected += ","
                    End If
                    id_design_selected = GVData.GetRowCellValue(i, "id_design").ToString
                Next
                Dim qcek As String = "SELECT d.design_code, d.design_display_name 
                FROM tb_design_extended_eos e 
                INNER JOIN tb_m_design d ON d.id_design = e.id_design
                WHERE e.is_active=1 AND e.id_design IN(" + id_design_selected + ") "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")

                If dcek.Rows.Count > 0 Then
                    Dim err As String = "These item already set as extended EOS : " + System.Environment.NewLine
                    For s As Integer = 0 To dcek.Rows.Count - 1
                        If s > 0 Then
                            err += System.Environment.NewLine
                        End If
                        err += dcek.Rows(s)("design_code").ToString + " - " + dcek.Rows(s)("design_display_name").ToString
                    Next
                    stopCustom(err)
                Else
                    FormProposePriceMKDExtendedEOS.ShowDialog()
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                End If
            Else
                stopCustom("No selected items")
            End If
            GVData.ActiveFilterString = "" + last_filter
            is_enable_custom_calc = True
            Cursor = Cursors.Default
        End If
    End Sub
End Class