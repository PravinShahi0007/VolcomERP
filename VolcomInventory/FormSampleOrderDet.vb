Public Class FormSampleOrderDet 
    Public action As String
    Public id_sample_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sample_order_det_list As New List(Of String)
    Public id_so_type As String = "-1"

    Private Sub FormSampleOrderDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        actionLoad()
    End Sub

    Private Sub FormSampleOrderDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtNumber.Text = header_number("16")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True

            'query view based on edit id's
            Dim query_c As ClassSampleOrder = New ClassSampleOrder
            Dim query As String = query_c.queryMain("AND so.id_sample_order=''" + id_sample_order + "'' ", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sample_order_datex").ToString, 0)
            TxtNumber.Text = data.Rows(0)("sample_order_number").ToString
            MENote.Text = data.Rows(0)("sample_order_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            'detail2
            viewDetail()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryDetail(id_sample_order)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_order_det_list.Add(data.Rows(i)("id_sample_order_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub check_but()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_samplex <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "62", id_sample_order) Then
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            LETypeSO.Enabled = True
            LEStatusSO.Enabled = True
        Else
            TxtNameCompTo.Properties.Buttons.Clear() 'clear browse button
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            LETypeSO.Enabled = False
            LEStatusSO.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    'Validating
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 10)
    End Sub


    Private Sub TxtNameCompTo_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNameCompTo.ButtonClick
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "53"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormSampleOrderSingle.action_pop = "ins"
        FormSampleOrderSingle.ShowDialog()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormSampleOrderSingle.action_pop = "upd"
        FormSampleOrderSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSampleOrderSingle.id_sample_edit = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        FormSampleOrderSingle.sample_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSampleOrderSingle.id_sample_ret_price_edit = GVItemList.GetFocusedRowCellValue("id_sample_ret_price")
        FormSampleOrderSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sample_order_det_qty")
        FormSampleOrderSingle.remark_edit = GVItemList.GetFocusedRowCellValue("sample_order_det_note").ToString
        FormSampleOrderSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        GVItemList.ApplyFindFilter("")
        GVItemList.ActiveFilter.Clear()
        ValidateChildren()
        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Then
            stopCustom("Item list can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sample_order_number As String = TxtNumber.Text
                Dim sample_order_note As String = MENote.Text
                Dim id_so_type As String = LETypeSO.EditValue.ToString
                Dim id_so_status As String = LEStatusSO.EditValue.ToString
                Dim id_report_status As String = LEReportStatus.EditValue

                If action = "ins" Then
                    'Main tbale
                    Dim query As String = "INSERT INTO tb_sample_order(id_store_contact_to, sample_order_number, sample_order_date, sample_order_note, id_so_type, id_report_status, id_so_status) "
                    query += "VALUES('" + id_store_contact_to + "', '" + sample_order_number + "', NOW(), '" + sample_order_note + "', '" + id_so_type + "', '" + id_report_status + "', '" + id_so_status + "'); SELECT LAST_INSERT_ID(); "
                    id_sample_order = execute_query(query, 0, True, "", "", "", "")

                    increase_inc("16")

                    'insert who prepared
                    insert_who_prepared("62", id_sample_order, id_user)

                    'Detail 
                    Dim jum_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sample_order_det(id_sample_order, id_sample, id_sample_ret_price, sample_ret_price, sample_order_det_qty, sample_order_det_note) VALUES "
                    End If
                    For i As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample As String = GVItemList.GetRowCellValue(i, "id_sample").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(i, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "sample_ret_price").ToString)
                            Dim sample_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sample_order_det_qty").ToString)
                            Dim sample_order_det_note As String = GVItemList.GetRowCellValue(i, "sample_order_det_note").ToString

                            If jum_i > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sample_order + "', '" + id_sample + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "', '" + sample_order_det_qty + "', '" + sample_order_det_note + "') "
                            jum_i = jum_i + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_sample_order SET id_store_contact_to='" + id_store_contact_to + "', sample_order_number = '" + sample_order_number + "', sample_order_note='" + sample_order_note + "', id_so_type='" + id_so_type + "', id_so_status = '" + id_so_status + "' WHERE id_sample_order='" + id_sample_order + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    Dim jum_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sample_order_det(id_sample_order, id_sample, id_sample_ret_price, sample_ret_price, sample_order_det_qty, sample_order_det_note) VALUES "
                    End If
                    For i As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample_order_det As String = GVItemList.GetRowCellValue(i, "id_sample_order_det").ToString
                            Dim id_sample As String = GVItemList.GetRowCellValue(i, "id_sample").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(i, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "sample_ret_price").ToString)
                            Dim sample_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sample_order_det_qty").ToString)
                            Dim sample_order_det_note As String = GVItemList.GetRowCellValue(i, "sample_order_det_note").ToString
                            If id_sample_order_det = "0" Then
                                If jum_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sample_order + "', '" + id_sample + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "', '" + sample_order_det_qty + "', '" + sample_order_det_note + "') "
                                jum_i = jum_i + 1
                            Else
                                Dim query_edit As String = "UPDATE tb_sample_order_det SET id_sample = '" + id_sample + "', id_sample_ret_price='" + id_sample_ret_price + "', sample_ret_price = '" + sample_ret_price + "', sample_order_det_qty = '" + sample_order_det_qty + "', sample_order_det_note='" + sample_order_det_note + "' WHERE id_sample_order_det = '" + id_sample_order_det + "' "
                                execute_non_query(query_edit, True, "", "", "", "")
                                id_sample_order_det_list.Remove(id_sample_order_det)
                            End If
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_i > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'delete sisa
                    For k As Integer = 0 To (id_sample_order_det_list.Count - 1)
                        Try
                            Dim querydel As String = "DELETE FROM tb_sample_order_det WHERE id_sample_order_det = '" + id_sample_order_det_list(k) + "' "
                            execute_non_query(querydel, True, "", "", "", "")
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next
                End If

                FormSampleOrder.viewSampleOrder()
                FormSampleOrder.GVSampleOrder.FocusedRowHandle = find_row(FormSampleOrder.GVSampleOrder, "id_sample_order", id_sample_order)
                Cursor = Cursors.Default
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSampleOrder.id_sample_order_param = id_sample_order
        ReportSampleOrder.dt = GCItemList.DataSource
        Dim Report As New ReportSampleOrder()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)


        Report.LabelTo.Text = TxtNameCompTo.Text
        Report.LabelNo.Text = TxtNumber.Text
        Report.LabelDate.Text = DEForm.Text
        Report.LabelSOType.Text = LETypeSO.Properties.GetDisplayText(LETypeSO.EditValue)
        Report.LabelSOStatus.Text = LEStatusSO.Properties.GetDisplayText(LEStatusSO.EditValue)
        Report.LabelNote.Text = MENote.Text


        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_order
        FormReportMark.report_mark_type = "62"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        
    End Sub
End Class