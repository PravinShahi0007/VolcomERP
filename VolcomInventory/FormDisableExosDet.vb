Public Class FormDisableExosDet
    Public action As String
    Public id As String = "-1"
    Public id_report_status As String
    Dim rmt As String = "364"
    Public is_view = "-1"

    Private Sub FormDisableExosDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormDisableExosDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim r As New ClassDisableExos()
            Dim query As String = r.queryMain("AND r.id_disable_exos='" + id + "'", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            DEForm.EditValue = data.Rows(0)("created_date")
            TxtSalesOrderNumber.Text = data.Rows(0)("number").ToString
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_disable_exos('" + id + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        BtnAdd.Visible = False
        BtnDel.Visible = False
        BtnSave.Enabled = False
        MENote.Properties.ReadOnly = True
        If check_edit_report_status(id_report_status, rmt, id) Then
            PanelControlNav.Enabled = True
        Else
            PanelControlNav.Enabled = False

        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormDisableExosList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                CType(GCItemList.DataSource, DataTable).AcceptChanges()
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnExportAsFile_Click(sender As Object, e As EventArgs) Handles BtnExportAsFile.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCItemList, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = rmt
        FormReportMark.form_origin = Name
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportRetExos.id = id
        'ReportRetExos.dt = GCItemList.DataSource
        'ReportRetExos.rmt = rmt
        'Dim Report As New ReportRetExos()

        ''... 
        '' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVItemList)

        ''Parse Val
        'Report.LabelNumber.Text = TxtSalesOrderNumber.Text.ToUpper
        'Report.LabelDate.Text = DEForm.Text.ToUpper
        'Report.LabelStore.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        'Report.LabelReason.Text = SLUEClasification.Text.ToUpper
        'Report.LabelReturnDate.Text = DERetDueDate.Text.ToUpper
        'Report.LabelDelDate.Text = DEDelDate.Text.ToUpper
        'Report.LNote.Text = MENote.Text
        'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = rmt
        If id_report_status = 6 Then
            FormDocumentUpload.is_no_delete = "1"
        ElseIf id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVItemList)
        If GVItemList.RowCount <= 0 Or MENote.Text = "" Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to propose this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim note As String = addSlashes(MENote.Text)

                'head
                Dim query As String = "INSERT INTO tb_disable_exos(number, created_date, id_report_status, note)
                VALUES('', NOW(), 1, '" + note + "');SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", " + rmt + "); ", True, "", "", "", "")

                'detail
                Dim jum_ins_i As Integer = 0
                Dim query_detail As String = ""
                If GVItemList.RowCount > 0 Then
                    query_detail = "INSERT INTO tb_disable_exos_det(id_disable_exos,id_design) VALUES "
                End If
                For i As Integer = 0 To (GVItemList.RowCount - 1)
                    Dim id_design As String = GVItemList.GetRowCellValue(i, "id_design").ToString

                    If jum_ins_i > 0 Then
                        query_detail += ", "
                    End If
                    query_detail += "('" + id + "', '" + id_design + "') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                submit_who_prepared(rmt, id, id_user)

                FormDisableExos.viewData()
                FormDisableExos.GVData.FocusedRowHandle = find_row(FormDisableExos.GVData, "id_disable_exos", id)
                action = "upd"
                actionLoad()
                infoCustom("Document #" + TxtSalesOrderNumber.Text + " was created successfully. Waiting for approval")
            End If
        End If
    End Sub
End Class