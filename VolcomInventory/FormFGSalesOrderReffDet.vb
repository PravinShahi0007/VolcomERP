Public Class FormFGSalesOrderReffDet 
    Public id_fg_so_reff As String = "-1"
    Public id_fg_so_reff_fk As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_so_reff_det_list As New List(Of String)
    Public data_edit As New DataTable
    Public id_comp_contact_par As String = "-1"


    Private Sub FormFGSalesOrderReffDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewSeason()
        _view_division_fg(LESampleDivision)
        _view_rec_note(LERecNote)
        viewReportStatus()

        'initialisation datatable edit
        Try
            data_edit.Columns.Add("id_product")
            data_edit.Columns.Add("id_comp")
            data_edit.Columns.Add("id_fg_ds_store")
            data_edit.Columns.Add("fg_so_reff_det_qty")
        Catch ex As Exception
        End Try

        actionLoad()
        WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default
    End Sub

    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.is_md='1' "
        query += "ORDER BY b.range DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season_printed_name", "id_season")
    End Sub

    'view del
    Sub viewDel()
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT del.id_delivery, del.delivery FROM tb_season_delivery del WHERE del.id_season = '" + id_season + "' ORDER BY del.delivery ASC "
        viewSearchLookupQuery(SLEDel, query, "id_delivery", "delivery", "id_delivery")
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        Cursor = Cursors.WaitCursor
        viewDel()
        Cursor = Cursors.Default
    End Sub

    'load
    Sub actionLoad()
        If action = "ins" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            BtnSave.Text = "Save Changes"
            BMark.Enabled = True
            Dim query_c As ClassFGSalesOrderReff = New ClassFGSalesOrderReff()
            Dim query As String = query_c.queryMain("AND so.id_fg_so_reff = ''" + id_fg_so_reff + "'' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GroupControlList.Enabled = True
            PanelControlNav.Visible = True
            SLESeason.EditValue = data.Rows(0)("id_season").ToString
            LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", data.Rows(0)("id_division"))
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtProdDemandNumber.Text = data.Rows(0)("fg_so_reff_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_so_reff_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_so_reff_note").ToString
            ButtonEdit1.Text = data.Rows(0)("fg_so_reff_fk_number").ToString
            id_fg_so_reff_fk = data.Rows(0)("id_fg_so_reff_fk").ToString
            id_comp_contact_par = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString

            viewDetail()
            allow_status()
            check_but()
        End If
    End Sub

    Sub viewDetail()
        Dim query_c As ClassDesign = New ClassDesign()
        query_c.loadDS(SLESeason.EditValue.ToString, "3", GCDesign, GVDesign, id_fg_so_reff, "2")
    End Sub

    Sub allow_status()
        'Based on report status
        If check_edit_report_status(id_report_status, "75", id_fg_so_reff) Then
            'MsgBox("Masih Boleh")
            BtnBrowseContactTo.Enabled = True
            ' PanelControlNav.Enabled = True
            BtnSave.Enabled = True
            BtnEdit.Enabled = True
            BtnProduct.Enabled = True
            BtnDelete.Enabled = True
            LESampleDivision.Enabled = False
            LERecNote.Enabled = True
            SLESeason.Enabled = False
            SLEDel.Enabled = False
            MENote.Enabled = True
            BtnDelRef.Enabled = True
            ButtonEdit1.Enabled = True
            CheckEditSelAll.Enabled = True
            GVDesign.OptionsBehavior.ReadOnly = False
        Else
            'MsgBox("Nggak Boleh")
            BtnBrowseContactTo.Enabled = False
            '  PanelControlNav.Enabled = False
            BtnSave.Enabled = False
            BtnEdit.Enabled = False
            BtnProduct.Enabled = False
            BtnDelete.Enabled = False
            LESampleDivision.Enabled = False
            LERecNote.Enabled = False
            SLESeason.Enabled = False
            SLEDel.Enabled = False
            MENote.Enabled = False
            BtnDelRef.Enabled = False
            ButtonEdit1.Enabled = False
            CheckEditSelAll.Enabled = False
            GVDesign.OptionsBehavior.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "75", id_fg_so_reff) Then
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
            id_cek = GVDesign.GetFocusedRowCellValue("id_fg_propose_price_det").ToString
        Catch ex As Exception
        End Try

        'If GVDesign.RowCount > 0 And id_cek <> "-1" Then
        '    BtnDelete.Enabled = True
        'Else
        '    BtnDelete.Enabled = False
        'End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Cursor = Cursors.WaitCursor
        check_but()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGSalesOrderReffDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim div_1st_char As String = LESampleDivision.Text.Substring(0, 1)
        Dim fg_so_reff_number As String = ""
        Dim id_division As String = LESampleDivision.EditValue.ToString
        Dim id_delivery As String = SLEDel.EditValue.ToString
        Dim id_rec_note As String = LERecNote.EditValue.ToString
        Dim fg_so_reff_note As String = MENote.Text.ToString


        'action
        If id_comp_contact_par = "-1" Then
            stopCustom("Data can't blank!")
        Else
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to create new analysis SO ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    fg_so_reff_number = SLESeason.Text + "D" + SLEDel.Text + "/" + header_number_sales("21") + div_1st_char
                    Try
                        Dim query As String = "INSERT INTO tb_fg_so_reff(id_fg_so_reff_fk, fg_so_reff_number, fg_so_reff_date, id_division, id_delivery, id_rec_note, id_report_status, fg_so_reff_note,id_comp_contact_to) "
                        query += "VALUES( "
                        If id_fg_so_reff_fk = "-1" Then
                            query += "NULL, "
                        Else
                            query += "'" + id_fg_so_reff_fk + "', "
                        End If
                        query += "'" + fg_so_reff_number + "', NOW(), '" + id_division + "', '" + id_delivery + "', '" + id_rec_note + "', '1', '" + fg_so_reff_note + "', '" + id_comp_contact_par + "' "
                        query += "); SELECT LAST_INSERT_ID(); "
                        id_fg_so_reff = execute_query(query, 0, True, "", "", "", "")

                        'inc number & gen mark
                        increase_inc_sales("21")
                        insert_who_prepared("75", id_fg_so_reff, id_user)

                        'refresh
                        infoCustom(fg_so_reff_number + " was created successfully. Please fill item list!")
                        FormFGSalesOrderReff.viewSOReff()
                        FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_fg_so_reff)
                        action = "upd"
                        id_report_status = LEReportStatus.EditValue.ToString
                        actionLoad()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save these changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    fg_so_reff_number = TxtProdDemandNumber.Text
                    Try
                        Dim query As String = "UPDATE tb_fg_so_reff SET id_rec_note='" + id_rec_note + "', fg_so_reff_note='" + fg_so_reff_note + "',id_comp_contact_to='" + id_comp_contact_par + "', "
                        If id_fg_so_reff_fk = "-1" Then
                            query += "id_fg_so_reff_fk=NULL "
                        Else
                            query += "id_fg_so_reff_fk='" + id_fg_so_reff_fk + "' "
                        End If
                        query += "WHERE id_fg_so_reff = '" + id_fg_so_reff + "' "
                        execute_non_query(query, True, "", "", "", "")
                        infoCustom(fg_so_reff_number + " was changed successfully.")
                        FormFGSalesOrderReff.viewSOReff()
                        FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_fg_so_reff)
                        action = "upd"
                        id_report_status = LEReportStatus.EditValue.ToString
                        actionLoad()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BtnBasic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBasic.Click
        BtnBasic.Visible = False
        BtnBasicHide.Visible = False
        SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
    End Sub

    Private Sub BtnBasicHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBasicHide.Click
        BtnBasic.Visible = False
        BtnBasicHide.Visible = False
        SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If GVDesign.RowCount > 0 Then
            'edit
            SLESeason.Enabled = False
            BtnEdit.Visible = False
            BtnProduct.Visible = False
            BtnDelete.Visible = False
            BtnDoneEditing.Visible = True
            BtnDiscard.Visible = True
            BtnAdvanced.Visible = False
            'BtnBasic.Visible = False
            PCSelAll.Visible = False
            PBC.Visible = True
            PBC.EditValue = 0
            GVDesign.Columns("SELECT").Visible = False
            BtnSave.Enabled = False
            For j As Integer = 0 To GVDesign.Columns.Count - 1
                Dim col As String = GVDesign.Columns(j).FieldName.ToString
                If col.Contains("#id#") Then
                    GVDesign.Columns(GVDesign.Columns(j).FieldName.ToString).OptionsColumn.ReadOnly = False
                End If
            Next
        Else
            stopCustom("There is no data. Please add some product to item list!")
        End If
    End Sub

    Private Sub BtnProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProduct.Click
        Cursor = Cursors.WaitCursor
        FormPopUpProduct.id_pop_up = "1"
        FormPopUpProduct.id_season_par = SLESeason.EditValue.ToString
        FormPopUpProduct.data_par = GCDesign.DataSource
        FormPopUpProduct.id_trans = id_fg_so_reff
        FormPopUpProduct.Text = "Pop Up Product - Season " + SLESeason.Text.ToString
        FormPopUpProduct.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If GVDesign.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim i_val As Integer = 0
                Dim val As String = ""
                For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                    If GVDesign.GetRowCellValue(i, "SELECT").ToString = "Yes" Then
                        If i_val > 0 Then
                            val += "OR "
                        End If
                        val += "tb_fg_so_reff_det.id_product='" + GVDesign.GetRowCellValue(i, "id_product").ToString + "' "
                        i_val += 1
                    End If
                Next

                If i_val = 0 Then
                    stopCustom("There is no data was selected")
                Else
                    Dim query As String = ""
                    query += "DELETE "
                    query += "FROM tb_fg_so_reff_det "
                    query += "WHERE id_fg_so_reff_det IN ( "
                    query += "SELECT * FROM ( "
                    query += "Select id_fg_so_reff_det "
                    query += "FROM tb_fg_so_reff_det "
                    query += "WHERE tb_fg_so_reff_det.id_fg_so_reff = '" + id_fg_so_reff + "' AND  "
                    query += "(" + val + ") "
                    query += ") a "
                    query += ") "
                    execute_non_query(query, True, "", "", "", "")
                    viewDetail()
                End If
            End If
        Else
            stopCustom("There is no data was selected")
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVDesign.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                If cek Then
                    GVDesign.SetRowCellValue(i, "SELECT", "Yes")
                Else
                    GVDesign.SetRowCellValue(i, "SELECT", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscard.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SLESeason.Enabled = True
            BtnEdit.Visible = True
            BtnProduct.Visible = True
            BtnDelete.Visible = True
            BtnDoneEditing.Visible = False
            BtnDiscard.Visible = False
            PCSelAll.Visible = True
            PBC.Visible = False
            BtnSave.Enabled = True
            BtnAdvanced.Visible = True

            'btn ref
            If SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2 Then
                BtnBasic.Visible = False
            Else
                BtnBasic.Visible = False
            End If

            viewDetail()
        End If
    End Sub

    Private Sub BtnDoneEditing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDoneEditing.Click
        Cursor = Cursors.WaitCursor
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try

        For i As Integer = 0 To data_edit.Rows.Count - 1
            Dim query_ds As String = "UPDATE tb_fg_so_reff_det SET fg_so_reff_det_qty='" + data_edit.Rows(i)("fg_so_reff_det_qty").ToString + "' WHERE id_fg_so_reff='" + id_fg_so_reff + "' AND id_product='" + data_edit.Rows(i)("id_product").ToString + "' AND id_fg_ds_store='" + data_edit.Rows(i)("id_fg_ds_store").ToString + "' "
            execute_non_query(query_ds, True, "", "", "", "")
            PBC.PerformStep()
            PBC.Update()
        Next
        data_edit.Clear()
        SLESeason.Enabled = True
        BtnEdit.Visible = True
        BtnProduct.Visible = True
        BtnDelete.Visible = True
        BtnDoneEditing.Visible = False
        BtnDiscard.Visible = False
        PBC.Visible = False
        PCSelAll.Visible = True
        BtnSave.Enabled = True
        BtnAdvanced.Visible = True

        'bnt ref
        If SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2 Then
            BtnBasic.Visible = False
        Else
            BtnBasic.Visible = False
        End If

        viewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDesign_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDesign.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        If e.Column.FieldName.ToString.Contains("#id#") Then
            Dim col_foc_str As String() = Split(e.Column.FieldName.ToString, "#id#")
            Dim col_foc As String = col_foc_str(1)
            Dim col_id_fg_ds_store_foc As String = col_foc_str(2)
            Dim id_product_foc As String = GVDesign.GetRowCellValue(row_foc, "id_product").ToString
            Dim val_foc As String = decimalSQL(e.Value.ToString)
            Dim soh As Integer = GVDesign.GetRowCellValue(row_foc, "SOH#total#")
            Dim jum_old As Integer = GVDesign.GetRowCellValue(row_foc, "TOTAL DISTRIBUTION#total#")

            'total distribution jum all store
            Dim jum As Integer = 0
            For j As Integer = 0 To GVDesign.Columns.Count - 1
                If GVDesign.Columns(j).FieldName.ToString.Contains("#id#") Then
                    Dim val_ As Integer = 0
                    Try
                        val_ = GVDesign.GetRowCellValue(row_foc, GVDesign.Columns(j).FieldName.ToString)
                    Catch ex As Exception
                    End Try
                    jum += val_
                End If
            Next

            Dim R As DataRow = data_edit.NewRow
            R("id_product") = id_product_foc
            R("id_comp") = col_foc
            R("id_fg_ds_store") = col_id_fg_ds_store_foc
            R("fg_so_reff_det_qty") = val_foc
            data_edit.Rows.Add(R)
            GVDesign.SetRowCellValue(row_foc, "TOTAL DISTRIBUTION#total#", jum)
            'condition
            'If jum <= (soh + jum_old) Then
            '    Dim R As DataRow = data_edit.NewRow
            '    R("id_product") = id_product_foc
            '    R("id_comp") = col_foc
            '    R("id_fg_ds_store") = col_id_fg_ds_store_foc
            '    R("fg_so_reff_det_qty") = val_foc
            '    data_edit.Rows.Add(R)
            '    GVDesign.SetRowCellValue(row_foc, "TOTAL DISTRIBUTION#total#", jum)
            'Else
            'stopCustom("Qty not allowed exceed SOH.")
            'GVDesign.SetRowCellValue(row_foc, e.Column.FieldName.ToString, GVDesign.ActiveEditor.OldEditValue)
            'End If
        ElseIf e.Column.FieldName.ToString = "TOTAL DISTRIBUTION#total#" Then
            Dim val_new As Integer = GVDesign.GetRowCellValue(row_foc, "RECEIVING#total#") - GVDesign.GetRowCellValue(row_foc, "CREATED#total#") - e.Value.ToString
            GVDesign.SetRowCellValue(row_foc, "SOH#total#", val_new)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDesign_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDesign.CellValueChanging

    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_fg_so_reff
        FormDocumentUpload.report_mark_type = "75"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_reff
        FormReportMark.report_mark_type = "75"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRef.Click
        id_fg_so_reff_fk = "-1"
        ButtonEdit1.Text = "-"
    End Sub

    Private Sub ButtonEdit1_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        Cursor = Cursors.WaitCursor
        FormPopUpFGSalesOrderReff.id_pop_up = "1"
        FormPopUpFGSalesOrderReff.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit1.EditValueChanged
        
    End Sub

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormDataReff.id_pop_up = "2"
        FormDataReff.report_mark_type = "74"
        FormDataReff.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormProcessing.id_process = "4"
        FormProcessing.dtx2 = GCDesign.DataSource
        FormProcessing.idx = id_fg_so_reff
        FormProcessing.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "60"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGSalesOrderReff.id_report = id_fg_so_reff
        ReportFGSalesOrderReff.dt = GCDesign.DataSource
        Dim Report As New ReportFGSalesOrderReff()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVDesign)

        Report.LabelNo.Text = TxtProdDemandNumber.Text
        Report.LabelReff.Text = ButtonEdit1.Text
        Report.LabelWH.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelCat.Text = LERecNote.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelDate.Text = DEForm.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDesign_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVDesign.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "SOH#total#") Then
                If sender.GetRowCellValue(e.RowHandle, sender.Columns("SOH#total#")) > 0 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.White
                ElseIf sender.GetRowCellValue(e.RowHandle, sender.Columns("SOH#total#")) < 0 Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.White
                Else
                    e.Appearance.BackColor = Color.White
                    e.Appearance.BackColor2 = Color.White
                End If
            End If
        End If
    End Sub

    Private Sub BBExportExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBExportExcel.ItemClick
        Cursor = Cursors.WaitCursor
        If countColumn() > 0 And countRow() > 0 Then
            viewDetail()
            GVDesign.Columns("CLASS").GroupIndex = -1
            GVDesign.Columns("DESCRIPTION").GroupIndex = -1
            GVDesign.Columns("TOTAL DISTRIBUTION#total#").Visible = False
            GVDesign.Columns("PRICE").Visible = False
            GVDesign.Columns("VARIANCE#total#").Visible = False
            GVDesign.Columns("ORDER#total#").Visible = False
            GVDesign.Columns("RECEIVING#total#").Visible = False
            GVDesign.Columns("CREATED ORDER#total#").Visible = False
            GVDesign.Columns("SOH#total#").Visible = False
            GVDesign.Columns("SELECT").Visible = False
            GVDesign.OptionsPrint.PrintFooter = False

            'export excel
            Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
            Dim path_root As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path_root) Then
                System.IO.Directory.CreateDirectory(path_root)
            End If
            Dim fileName As String = "soreff_" + id_fg_so_reff + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Dim opt As DevExpress.XtraPrinting.XlsExportOptions = New DevExpress.XtraPrinting.XlsExportOptions()
            opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text
            printableComponentLink1.Component = GCDesign
            printableComponentLink1.CreateDocument()
            printableComponentLink1.ExportToXls(exp, opt)
            Process.Start(exp)
            viewDetail()
        Else
            stopCustom("Export is not available for this time.")
        End If
        Cursor = Cursors.Default
    End Sub

    Function countColumn()
        Dim jum_cek As String = execute_query("SELECT COUNT(*) FROM tb_fg_ds_store WHERE id_season='" + SLESeason.EditValue.ToString + "' ", 0, True, "", "", "", "")
        Return jum_cek
    End Function

    Function countRow()
        Dim jum_cek As String = execute_query("SELECT COUNT(*) FROM tb_fg_so_reff_det WHERE id_fg_so_reff='" + id_fg_so_reff + "'", 0, True, "", "", "", "")
        Return jum_cek
    End Function

    Private Sub BBImportExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBImportExcel.ItemClick
        Cursor = Cursors.WaitCursor
        If countRow() > 0 And countColumn() > 0 Then
            FormImportExcel.id_pop_up = "10"
            FormImportExcel.ShowDialog()
        Else
            stopCustom("Import is not available for this time.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class