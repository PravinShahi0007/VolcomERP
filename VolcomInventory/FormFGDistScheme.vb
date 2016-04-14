Public Class FormFGDistScheme 
    Public data_edit As New DataTable
    Public is_editing As Boolean = False

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range AND b.is_md='1' "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    'distribution schema type
    Sub viewDSType()
        Dim query As String = "SELECT * FROM tb_lookup_ds_type a ORDER BY a.id_ds_type ASC "
        viewSearchLookupQuery(SLEType, query, "id_ds_type", "ds_type", "id_ds_type")
    End Sub

    'load form
    Private Sub FormFGDistScheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        viewDSType()

        'initialisation datatable edit
        Try
            data_edit.Columns.Add("id_product")
            data_edit.Columns.Add("id_comp")
            data_edit.Columns.Add("id_fg_ds_store")
            data_edit.Columns.Add("fg_ds_qty")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub FormFGDistScheme_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGDistScheme_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        Dim id_season_par As String = "-1"
        Try
            id_season_par = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_type_par As String = "-1"
        Try
            id_type_par = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try
        loadDS(id_season_par, id_type_par, GCDS, GVDS)
        Cursor = Cursors.Default
    End Sub


    Sub loadDS(ByVal id_season_par As String, ByVal id_type_par As String, ByVal GCDS As DevExpress.XtraGrid.GridControl, ByVal GVDS As DevExpress.XtraGrid.Views.Grid.GridView)
        'declare class
        Dim ds As ClassDesign = New ClassDesign()
        ds.loadDS(id_season_par, id_type_par, GCDS, GVDS, "-1", "1")

        If GVDS.RowCount > 0 Then
            BtnEdit.Enabled = True
        Else
            BtnEdit.Enabled = False
        End If
    End Sub


    Private Sub BtnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        BtnEdit.Enabled = False
        GCDS.DataSource = Nothing
        GVDS.Columns.Clear()

        Try
            If SLEType.EditValue.ToString = "3" Then
                BBCreateSO.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                BBCreateSO.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GVDS_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDS.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As String = e.RowHandle.ToString
        If e.Column.FieldName.ToString.Contains("#id#") Then
            Dim col_foc_str As String() = Split(e.Column.FieldName.ToString, "#id#")
            Dim col_foc As String = col_foc_str(1)
            Dim col_id_fg_ds_store_foc As String = col_foc_str(2)
            Dim id_product_foc As String = GVDS.GetRowCellValue(row_foc, "id_product").ToString
            Dim val_foc As String = decimalSQL(e.Value.ToString)
            Dim rec_wh As Integer = GVDS.GetRowCellValue(row_foc, "RECEIVING WH#total#")

            'total distribution
            Dim jum As Integer = 0
            For j As Integer = 0 To GVDS.Columns.Count - 1
                If GVDS.Columns(j).FieldName.ToString.Contains("#id#") Then
                    Dim val_ As Integer = 0
                    Try
                        val_ = GVDS.GetRowCellValue(row_foc, GVDS.Columns(j).FieldName.ToString)
                    Catch ex As Exception
                    End Try
                    jum += val_
                End If
            Next

            Dim R As DataRow = data_edit.NewRow
            R("id_product") = id_product_foc
            R("id_comp") = col_foc
            R("id_fg_ds_store") = col_id_fg_ds_store_foc
            R("fg_ds_qty") = val_foc
            data_edit.Rows.Add(R)
            GVDS.SetRowCellValue(row_foc, "TOTAL DISTRIBUTION#total#", jum)

            'MsgBox("Row Product: " + id_product_foc.ToString + "/Col : " + col_foc.ToString + "/Val : " + val_foc.ToString)
        ElseIf e.Column.FieldName.ToString = "TOTAL DISTRIBUTION#total#" Then
            Dim val_new As Integer = GVDS.GetRowCellValue(row_foc, "RECEIVING#total#") - e.Value.ToString
            GVDS.SetRowCellValue(row_foc, "SOH#total#", val_new)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        SLESeason.Enabled = False
        SLEType.Enabled = False
        BtnView.Visible = False
        BtnEdit.Visible = False
        BtnDoneEditing.Visible = True
        BtnDiscard.Visible = True
        'BtnBasic.Visible = True
        BtnDropQuickMenu.Visible = False

        GVDS.Columns("SELECT").Visible = False
        For j As Integer = 0 To GVDS.Columns.Count - 1
            Dim col As String = GVDS.Columns(j).FieldName.ToString
            If col.Contains("#id#") Then
                GVDS.Columns(GVDS.Columns(j).FieldName.ToString).OptionsColumn.ReadOnly = False
            End If
        Next
    End Sub

    Private Sub BtnDoneEditing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDoneEditing.Click
        Cursor = Cursors.WaitCursor
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_type As String = "-1"
        Try
            id_type = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try

        For i As Integer = 0 To data_edit.Rows.Count - 1
            Dim query_ds As String = "CALL generate_fg_ds('" + SLEType.EditValue.ToString + "', '" + data_edit.Rows(i)("id_fg_ds_store").ToString + "', '" + data_edit.Rows(i)("id_product").ToString + "', '" + data_edit.Rows(i)("fg_ds_qty").ToString + "') "
            execute_non_query(query_ds, True, "", "", "", "")
            progres_bar_update(i, data_edit.Rows.Count - 1)
        Next
        data_edit.Clear()
        SLESeason.Enabled = True
        SLEType.Enabled = True
        BtnView.Visible = True
        BtnEdit.Visible = True
        BtnDoneEditing.Visible = False
        BtnDiscard.Visible = False
        BtnDropQuickMenu.Visible = True
        FormMain.BEProgress.EditValue = 0

        loadDS(SLESeason.EditValue.ToString, SLEType.EditValue.ToString, GCDS, GVDS)
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEType.EditValueChanged
        resetView()
    End Sub

    Private Sub BtnDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscard.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SLESeason.Enabled = True
            SLEType.Enabled = True
            BtnView.Visible = True
            BtnEdit.Visible = True
            BtnDoneEditing.Visible = False
            BtnDiscard.Visible = False
            BtnDropQuickMenu.Visible = True

            loadDS(SLESeason.EditValue.ToString, SLEType.EditValue.ToString, GCDS, GVDS)
        End If
    End Sub

    Private Sub BtnCopyDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GVDS_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVDS.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "RECEIVING WH-NORMAL#total#" Or e.Column.FieldName = "TOTAL DISTRIBUTION#total#") And SLEType.EditValue = "2" Then
                If sender.GetRowCellValue(e.RowHandle, sender.Columns("RECEIVING WH-NORMAL#total#")) > sender.GetRowCellValue(e.RowHandle, sender.Columns("TOTAL DISTRIBUTION#total#")) Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.White
                ElseIf sender.GetRowCellValue(e.RowHandle, sender.Columns("RECEIVING WH-NORMAL#total#")) < sender.GetRowCellValue(e.RowHandle, sender.Columns("TOTAL DISTRIBUTION#total#")) Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.White
                End If
            End If
        End If
    End Sub

    Sub SynchronizeLeftCoord(ByVal leftCoord As Integer)
        GVDS.LeftCoord = leftCoord
        GVCompare.LeftCoord = leftCoord
    End Sub

    Sub SynchronizeTopRowIndex(ByVal topRowIndex As Integer)
        GVDS.TopRowIndex = topRowIndex
        GVCompare.TopRowIndex = topRowIndex
    End Sub


    Private Sub GVDS_LeftCoordChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDS.LeftCoordChanged
        'SynchronizeLeftCoord(CType(sender, DevExpress.XtraGrid.Views.Grid.GridView).LeftCoord)
    End Sub


    Private Sub GVDS_TopRowChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDS.TopRowChanged
        ' SynchronizeTopRowIndex(CType(sender, DevExpress.XtraGrid.Views.Grid.GridView).TopRowIndex)
    End Sub

    Private Sub BtnBasic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBasic.Click
        BtnBasic.Visible = False
        BtnBasicHide.Visible = True
        SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
    End Sub

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormDataReff.id_pop_up = "1"
        FormDataReff.report_mark_type = "74"
        FormDataReff.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBasicHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBasicHide.Click
        BtnBasic.Visible = True
        BtnBasicHide.Visible = False
        SCCDs.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    End Sub

    Private Sub BBCreateSO_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBCreateSO.ItemClick
        Cursor = Cursors.WaitCursor
        If GVDS.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            If jum_tot > 0 Then
                If checkPrice() Then
                    FormFGDSSONew.id_season_par = SLESeason.EditValue.ToString
                    FormFGDSSONew.ShowDialog()
                Else
                    stopCustom("Some item doesn't have price, please complete these data first!")
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BBCopyFrom_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBCopyFrom.ItemClick
        Cursor = Cursors.WaitCursor
        FormFGDistSchemeType.id_season_par = SLESeason.EditValue.ToString
        FormFGDistSchemeType.id_pop_up = "2"
        FormFGDistSchemeType.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAccountList_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBAccountList.ItemClick
        Cursor = Cursors.WaitCursor
        Dim id_season_par As String = "-1"
        Try
            id_season_par = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        FormFGDistSchemeStore.GroupControl1.Text = "Account List - " + SLESeason.Text
        FormFGDistSchemeStore.id_season_par = id_season_par
        FormFGDistSchemeStore.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BBMasterSeason_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMasterSeason.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.MdiParent = FormMain
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBSalesOrder_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBSalesOrder.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrder.MdiParent = FormMain
            FormSalesOrder.Show()
            FormSalesOrder.WindowState = FormWindowState.Maximized
            FormSalesOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Function getTotalSelected() As Integer
        Dim jum_tot As Integer = 0
        For i As Integer = 0 To ((GVDS.RowCount - 1) - GetGroupRowCount(GVDS))
            If GVDS.GetRowCellValue(i, "SELECT") = "Yes" Then
                jum_tot += 1
                If jum_tot > 0 Then
                    Exit For
                End If
            End If
        Next
        Return jum_tot
    End Function

    Private Function checkPrice() As Integer
        Dim jum_tot As Integer = 0
        For i As Integer = 0 To ((GVDS.RowCount - 1) - GetGroupRowCount(GVDS))
            If GVDS.GetRowCellValue(i, "SELECT") = "Yes" Then
                If GVDS.GetRowCellValue(i, "id_design_price").ToString = "0" Then
                    jum_tot += 1
                    If jum_tot > 0 Then
                        Exit For
                    End If
                End If
            End If
        Next
        If jum_tot > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub BBExportToExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBExportToExcel.ItemClick
        Cursor = Cursors.WaitCursor
        If countColumn() > 0 And countRow() > 0 Then
            Dim id_season_par As String = "-1"
            Try
                id_season_par = SLESeason.EditValue.ToString
            Catch ex As Exception
            End Try
            Dim id_type_par As String = "-1"
            Try
                id_type_par = SLEType.EditValue.ToString
            Catch ex As Exception
            End Try
            loadDS(id_season_par, id_type_par, GCDS, GVDS)
            GVDS.Columns("CLASS").GroupIndex = -1
            GVDS.Columns("DESCRIPTION").GroupIndex = -1
            GVDS.Columns("TOTAL DISTRIBUTION#total#").Visible = False
            GVDS.Columns("RECEIVING WH-NORMAL#total#").Caption = "RECEIVING WH NORMAL"
            GVDS.OptionsPrint.PrintFooter = False

            'export excel
            Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
            Dim path_root As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path_root) Then
                System.IO.Directory.CreateDirectory(path_root)
            End If
            Dim fileName As String = "ds_" + SLESeason.EditValue.ToString + SLEType.EditValue.ToString + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Dim opt As DevExpress.XtraPrinting.XlsExportOptions = New DevExpress.XtraPrinting.XlsExportOptions()
            opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text
            printableComponentLink1.Component = GCDS
            printableComponentLink1.CreateDocument()
            printableComponentLink1.ExportToXls(exp, opt)
            Process.Start(exp)
            loadDS(id_season_par, id_type_par, GCDS, GVDS)
        Else
            stopCustom("Export is not available for this time.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BBImportFromExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBImportFromExcel.ItemClick
        Cursor = Cursors.WaitCursor
        If countRow() > 0 And countColumn() > 0 Then
            FormImportExcel.id_pop_up = "9"
            FormImportExcel.ShowDialog()
        Else
            stopCustom("View is not available for this time.")
        End If
        Cursor = Cursors.Default
    End Sub

    Function countColumn()
        Dim jum_cek As String = execute_query("SELECT COUNT(*) FROM tb_fg_ds_store WHERE id_season='" + SLESeason.EditValue.ToString + "' ", 0, True, "", "", "", "")
        Return jum_cek
    End Function

    Function countRow()
        Dim jum_cek As String = execute_query("SELECT COUNT(*) FROM tb_m_design d INNER JOIN tb_m_product p ON p.id_design = d.id_design WHERE d.id_season='" + SLESeason.EditValue.ToString + "' ", 0, True, "", "", "", "")
        Return jum_cek
    End Function
End Class