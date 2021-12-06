Public Class FormRetExosDet
    Public action As String
    Public id As String = "-1"
    Public id_store As String = "-1"
    Public id_report_status As String
    Dim date_start As Date
    Dim lead_time_ro As String = "0"
    Public dt As DataTable
    Dim rmt As String = "363"
    Public is_view = "1"

    Private Sub FormRetExosDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOrderType()
        view_clasification()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewOrderType()
        Dim query As String = "SELECT ot.id_order_type, ot.order_type, ot.description
        FROM tb_lookup_order_type ot
        WHERE ot.type=1
        ORDER BY ot.id_order_type ASC "
        viewLookupQuery(LEOrderType, query, 0, "order_type", "id_order_type")
    End Sub

    Sub view_clasification()
        Dim qry As String = "SELECT * FROM tb_lookup_return_clasification WHERE 1=1 "
        If action = "ins" Then
            qry += "AND is_extended_eos=1 "
        End If
        viewSearchLookupQuery(SLUEClasification, qry, "id_return_clasification", "return_clasification", "id_return_clasification")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            lead_time_ro = get_setup_field("lead_time_ro")
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`, DATE_ADD(NOW(),INTERVAL " + lead_time_ro + " DAY) AS `tgl_ret`, DATE_ADD(NOW(),INTERVAL 1 MONTH) AS `tgl_del` ", -1, True, "", "", "", "")
            DERetDueDate.EditValue = data.Rows(0)("tgl_ret")
            DEDelDate.EditValue = data.Rows(0)("tgl_del")
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactTo.Enabled = False
            BMark.Enabled = True

            'query view based on edit id's
            Dim r As New ClassRetExos()
            Dim query As String = r.queryMain("AND r.id_ret_exos='" + id + "'", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store = data.Rows(0)("id_store").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_acc").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store").ToString
            DEForm.EditValue = data.Rows(0)("created_date")
            TxtSalesOrderNumber.Text = data.Rows(0)("number").ToString
            MENote.Text = data.Rows(0)("note").ToString
            DERetDueDate.EditValue = data.Rows(0)("return_est_date")
            DEDelDate.EditValue = data.Rows(0)("return_del_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            SLUEClasification.EditValue = data.Rows(0)("id_return_clasification")
            If data.Rows(0)("id_order_type").ToString = "0" Then
                LEOrderType.EditValue = Nothing
            Else
                LEOrderType.ItemIndex = LEOrderType.Properties.GetDataSourceRowIndex("id_order_type", data.Rows(0)("id_order_type").ToString)
            End If


            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Private Sub FormRetExosDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_ret_exos('" + id + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        LEOrderType.Enabled = False
        BtnAdd.Visible = False
        BtnDel.Visible = False
        If check_edit_report_status(id_report_status, rmt, id) Then
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            DERetDueDate.Enabled = False
            DEDelDate.Enabled = True
            TxtCodeCompTo.Properties.ReadOnly = True
        Else
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            DERetDueDate.Enabled = False
            DEDelDate.Enabled = False
            TxtCodeCompTo.Properties.ReadOnly = True
        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "96"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel data changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        If Not id_store = "-1" Then
            FormRetExosItemList.id_comp = id_store
            FormRetExosItemList.ShowDialog()
        Else
            stopCustom("Please select store first")
        End If
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

    Private Sub LEOrderType_EditValueChanged(sender As Object, e As EventArgs) Handles LEOrderType.EditValueChanged
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            Dim value As String = row("description").ToString
            TxtOrderType.Text = value
        Catch ex As Exception
            TxtOrderType.Text = ""
        End Try

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
        'ReportSalesReturnOrder.id_sales_return_order = id_sales_return_order
        'ReportSalesReturnOrder.dt = GCItemList.DataSource
        'Dim Report As New ReportSalesReturnOrder()

        ''... 
        '' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        'ReportStyleGridview(Report.GridView1)

        'Parse val
        'Report.LRecNumber.Text = TxtSalesOrderNumber.Text
        'Report.LRecDate.Text = DEForm.Text
        'Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        'Report.LabelAddress.Text = MEAdrressCompTo.Text
        'Report.LabelEstReturn.Text = DERetDueDate.Text
        'Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
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
                Dim return_est_date As String = DateTime.Parse(DERetDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim return_del_date As String = DateTime.Parse(DEDelDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim id_order_type As String = LEOrderType.EditValue.ToString
                Dim id_return_clasification As String = SLUEClasification.EditValue.ToString

                'head
                Dim query As String = "INSERT INTO tb_ret_exos(number, created_date, return_est_date, return_del_date, id_store, id_order_type, id_return_clasification, id_report_status, note)
                VALUES('', NOW(), '" + return_est_date + "', '" + return_del_date + "', '" + id_store + "', '" + id_order_type + "', '" + id_return_clasification + "', 1, '" + note + "');SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", " + rmt + "); ", True, "", "", "", "")

                'detail
                Dim jum_ins_i As Integer = 0
                Dim query_detail As String = ""
                If GVItemList.RowCount > 0 Then
                    query_detail = "INSERT INTO tb_ret_exos_det(id_ret_exos,id_product, id_design_price, design_price, qty) VALUES "
                End If
                For i As Integer = 0 To (GVItemList.RowCount - 1)
                    Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                    Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                    Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Dim qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString)

                    If jum_ins_i > 0 Then
                        query_detail += ", "
                    End If
                    query_detail += "('" + id + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + qty + "') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_detail, True, "", "", "", "")
                End If

                submit_who_prepared(rmt, id, id_user)

                FormRetExos.viewData()
                FormRetExos.GVData.FocusedRowHandle = find_row(FormRetExos.GVData, "id_ret_exos", id)
                action = "upd"
                actionLoad()
                infoCustom("Document #" + TxtSalesOrderNumber.Text + " was created successfully. Waiting for approval")
            End If
        End If
    End Sub
End Class