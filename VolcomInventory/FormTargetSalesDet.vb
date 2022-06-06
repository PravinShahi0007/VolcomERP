Public Class FormTargetSalesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "414"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormTargetSalesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormTargetSalesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        viewLookupQueryO(LEReportStatus, volcomErpApiGetDT(dt_json, 0), 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnCreateNew.Visible = True
            Width = 459
            Height = 170
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

            'detail
            viewDetail()
            allowStatus()
        End If
    End Sub

    Sub viewDetail()
        'Cursor = Cursors.WaitCursor
        'Dim query As String = ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
        'GVData.BestFitColumns()
        'Cursor = Cursors.Default
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
        'Cursor = Cursors.WaitCursor
        'ReportDropChanges.id = id
        'ReportDropChanges.dt = GCData.DataSource
        'ReportDropChanges.rmt = rmt
        'Dim Report As New ReportDropChanges()

        ''... 
        '' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVData)

        ''Parse Val
        'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        'Report.LabelDate.Text = DECreated.Text.ToUpper
        'Report.LNote.Text = MENote.Text
        'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        'Report.LabelSeason.Text = SLESeason.Text.ToUpper

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
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

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDeletePTH_Click(sender As Object, e As EventArgs) Handles BtnDeletePTH.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_store As String = GVData.GetFocusedRowCellValue("id_store").ToString
                Dim query As String = "DELETE FROM tb_b_revenue_propose_det WHERE id_b_revenue_propose='" + id + "' AND id_store='" + id_store + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub
End Class