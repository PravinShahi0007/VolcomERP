Public Class FormMasterPriceSampleSingle
    Public action As String = ""
    Public id_sample_price As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_price_det_list As New List(Of String)
    Public id_pre As String = "-1"

    Private Sub FormMasterPriceSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPriceType()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormMasterPriceSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnImport.Enabled = False
            BtnSave.Text = "Create New"
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            BtnImport.Enabled = True
            BtnSave.Text = "Save Changes"
            GroupControlListItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

            '    'query view based on edit id's
            Dim query_c As ClassSample = New ClassSample()
            Dim query As String = query_c.queryPriceExcelMain("AND prc.id_sample_price='" + id_sample_price + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_sample_price = data.Rows(0)("id_sample_price").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEPriceType.ItemIndex = LEPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", data.Rows(0)("id_design_price_type").ToString)
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("sample_price_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sample_price_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sample_price_note").ToString

            '    'detail2
            viewDetail()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewPriceType()
        Dim query As String = "SELECT * FROM tb_lookup_design_price_type a ORDER BY a.id_design_price_type "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPriceType, query, 0, "design_price_type", "id_design_price_type")
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_samplex <> "0" Then
            BtnImport.Enabled = True
        Else
            BtnImport.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "86", id_sample_price) Then
            BtnImport.Enabled = True
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnSave.Enabled = True
            LEPriceType.Enabled = False
        Else
            BtnImport.Enabled = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnSave.Enabled = False
            LEPriceType.Enabled = False
        End If

        'ATTACH
        If check_attach_report_status(id_report_status, "86", id_sample_price) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub viewDetail()
        Dim query_c As ClassSample = New ClassSample()
        Dim query As String = query_c.queryPriceExcelDetail(id_sample_price)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_price_det_list.Add(data.Rows(i)("id_sample_price_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "86"
        FormReportMark.id_report = id_sample_price
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVItemList)

        Cursor = Cursors.WaitCursor
        ValidateChildren()

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sample_price_number As String = TxtNumber.Text
                Dim sample_price_note As String = MENote.Text.ToString
                Dim id_design_price_type As String = LEPriceType.EditValue.ToString
                Dim id_currency As String = get_setup_field("id_currency_default")
                If action = "ins" Then
                    'query main table
                    Dim query_main As String = "INSERT tb_sample_price(id_design_price_type, sample_price_number, sample_price_date, sample_price_note, id_report_status) "
                    query_main += "VALUES('" + id_design_price_type + "','" + header_number("20") + "', NOW(), '" + sample_price_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id_sample_price = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc("20")

                    'insert who prepared
                    insert_who_prepared("86", id_sample_price, id_user)

                    FormMasterPriceSample.viewPrice()
                    FormMasterPriceSample.GVPrice.FocusedRowHandle = find_row(FormMasterPriceSample.GVPrice, "id_sample_price", id_sample_price)
                    action = "upd"
                    actionLoad()
                    sample_price_number = TxtNumber.Text
                    infoCustom("Document #" + sample_price_number + " was created successfully.")
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_sample_price SET id_design_price_type='" + id_design_price_type + "', sample_price_number = '" + sample_price_number + "', sample_price_note = '" + sample_price_note + "' WHERE id_sample_price = '" + id_sample_price + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    FormMasterPriceSample.viewPrice()
                    FormMasterPriceSample.GVPrice.FocusedRowHandle = find_row(FormMasterPriceSample.GVPrice, "id_sample_price", id_sample_price)
                    action = "upd"
                    actionLoad()
                    sample_price_number = TxtNumber.Text
                    infoCustom("Document #" + sample_price_number + " was edited successfully.")
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "19"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "86"
        FormDocumentUpload.id_report = id_sample_price
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        ReportMasterPriceSample.id_sample_price = id_sample_price
        ReportMasterPriceSample.dt = GCItemList.DataSource
        Dim Report As New ReportMasterPriceSample()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelPriceType.Text = LEPriceType.Text.ToUpper
        Report.LabelCreated.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportMasterPriceSample.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportMasterPriceSample.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        Cursor = Cursors.WaitCursor
        prePrinting()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        Cursor = Cursors.WaitCursor
        printing()
        Cursor = Cursors.Default
    End Sub
End Class