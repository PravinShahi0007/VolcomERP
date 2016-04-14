Public Class FormFGBorrowQCReqSingle
    Public action As String = "-1"
    Public id_borrow_qc_req As String = "-1"
    Public id_report_status As String = "-1"
    Public id_borrow_qc_req_det_list As New List(Of String)

    Private Sub FormFGBorrowQCReqSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewReportStatus()
        actionLoad()
        Cursor = Cursors.Default
    End Sub

    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'load
    Sub actionLoad()
        If action = "ins" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = False

            'get user 
            TxtNumber.Text = "-"
            TxtApplicant.Text = get_user_identify(id_user, "1")
            TxtPosition.Text = get_user_identify(id_user, "6")
            TxtDept.Text = get_user_identify(id_user, "4")

            'get date now
            Dim query_dt As String = "SELECT DATE(NOW()) AS `dt_now` "
            Dim data As DataTable = execute_query(query_dt, -1, True, "", "", "", "")
            Dim date_now As Date = data.Rows(0)("dt_now")
            DECreated.EditValue = date_now

            'initial duration 
            TxtDuration.EditValue = 0

            viewDetail()
            check_but()
        ElseIf action = "upd" Then
            BtnSave.Text = "Save Changes"
            BMark.Enabled = True
            'Dim query_c As ClassFGSalesOrderReff = New ClassFGSalesOrderReff()
            'Dim query As String = query_c.queryMain("AND so.id_fg_so_reff = ''" + id_fg_so_reff + "'' ", "1")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'GroupControlList.Enabled = True
            'PanelControlNav.Visible = True
            'SLESeason.EditValue = data.Rows(0)("id_season").ToString
            'LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", data.Rows(0)("id_division"))
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'id_report_status = data.Rows(0)("id_report_status").ToString
            'TxtProdDemandNumber.Text = data.Rows(0)("fg_so_reff_number").ToString
            'DEForm.Text = view_date_from(data.Rows(0)("fg_so_reff_datex").ToString, 0)
            'MENote.Text = data.Rows(0)("fg_so_reff_note").ToString
            'ButtonEdit1.Text = data.Rows(0)("fg_so_reff_fk_number").ToString
            'id_fg_so_reff_fk = data.Rows(0)("id_fg_so_reff_fk").ToString
            'id_comp_contact_par = data.Rows(0)("id_comp_contact_to").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
            'TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString

            viewDetail()
            allow_status()
            check_but()
        End If
    End Sub

    Sub viewDetail()
        Dim query_c As ClassFGBorrowQCReq = New ClassFGBorrowQCReq()
        Dim query As String = query_c.queryDetailReq(id_borrow_qc_req)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBorrow.DataSource = data
        If action = "upd" Then
            For i As Integer = 0 To data.Rows.Count - 1
                id_borrow_qc_req_det_list.Add(data.Rows(i)("id_borrow_qc_req_det").ToString)
            Next
        End If
    End Sub

    Sub allow_status()
        'Based on report status
        If check_edit_report_status(id_report_status, "78", id_borrow_qc_req) Then
            'MsgBox("Masih Boleh")
            PanelControlNav.Enabled = True
            BtnSave.Enabled = True
            BtnDel.Enabled = True
            MENote.Enabled = True
            GVBorrow.OptionsBehavior.ReadOnly = False
        Else
            'MsgBox("Nggak Boleh")
            PanelControlNav.Enabled = False
            BtnSave.Enabled = False
            BtnDel.Enabled = False
            MENote.Enabled = False
            GVBorrow.OptionsBehavior.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "78", id_borrow_qc_req) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    'enable/disable Edit/Delete Detail
    Sub check_but()
        Dim id_cek As String = "-1"
        Try
            id_cek = GVBorrow.GetFocusedRowCellValue("id_borrow_qc_req").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVBorrow_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBorrow.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGBorrowQCReqSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPopUpProduct.id_pop_up = "2"
        FormPopUpProduct.id_season_par = "-1"
        FormPopUpProduct.data_par = GCBorrow.DataSource
        FormPopUpProduct.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVBorrow.DeleteSelectedRows()
            GCBorrow.RefreshDataSource()
            GVBorrow.RefreshData()
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_borrow_qc_req
        FormDocumentUpload.report_mark_type = "78"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_borrow_qc_req
        FormReportMark.report_mark_type = "78"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportFGSalesOrderReff.id_report = id_fg_so_reff
        'ReportFGSalesOrderReff.dt = GCDesign.DataSource
        'Dim Report As New ReportFGSalesOrderReff()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVDesign)

        'Report.LabelNo.Text = TxtProdDemandNumber.Text
        'Report.LabelReff.Text = ButtonEdit1.Text
        'Report.LabelWH.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        'Report.LabelCat.Text = LERecNote.Text
        'Report.LabelNote.Text = MENote.Text
        'Report.LabelDate.Text = DEForm.Text

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.Default
    End Sub

    Private Sub TxtDuration_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDuration.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim created As String = DateTime.Parse(DECreated.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dr As String = TxtDuration.EditValue.ToString
        Dim query As String = "SELECT DATE_ADD('" + created + "',INTERVAL " + dr + " DAY) AS `res_date`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim res As Date = data.Rows(0)("res_date")
        DEReturn.EditValue = res
        Cursor = Cursors.Default
    End Sub

    Private Sub SMImg_Click(sender As Object, e As EventArgs) Handles SMImg.Click
        pre_viewImages("2", Nothing, GVBorrow.GetFocusedRowCellValue("id_design").ToString, True)
    End Sub

    Private Sub GVBorrow_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVBorrow.PopupMenuShowing
        If GVBorrow.RowCount > 0 And GVBorrow.FocusedRowHandle >= 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub GVBorrow_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBorrow.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

End Class