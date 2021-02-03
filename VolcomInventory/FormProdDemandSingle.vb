Public Class FormProdDemandSingle
    Public id_season As String
    Public id_prod_demand As String = "-1"
    Public id_prod_demand_ref As String = "-1"
    Public action As String
    Public id_report_status As String = "-1"
    Public id_division As String = "-1"
    Public id_pd_type As String = "-1"
    Public id_pd As String = "-1"
    Public id_design_list As New List(Of String)
    Dim vmenu As New System.Windows.Forms.ContextMenuStrip
    Dim short_name_ss As String = "-1"
    Public type_line_list As String = "-1"
    Public dsg_line_list As String = "-1"
    Public ss_line_list As String = "-1"
    Public id_pd_kind As String = "-1"
    Public id_pd_budget As String = "-1"

    Dim id_role_super_admin As String = "-1"
    Public data_column As New DataTable
    Public is_confirm As String = "2"
    Dim is_load_break_size As Boolean = False
    Public report_mark_type As String = ""
    Public rate_current As Decimal = 0.00

    '----------------GENERAL------------------------
    'Form Close
    Private Sub FormProdDemandSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Validating PD Number 
    Private Sub TEOVHCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtProdDemandNumber.Validating
        validatingPDNumber()
    End Sub
    'Procedure validating PD Number
    Sub validatingPDNumber()
        'Dim query As String = "SELECT COUNT(*) FROM tb_prod_demand WHERE prod_demand_number = '" + TxtProdDemandNumber.Text + "' "
        'If action = "upd" Then
        '    query += "AND id_prod_demand != '" + id_prod_demand + "' "
        'End If
        'Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        'If jml > 0 Then
        '    EP_TE_already_used(EPProdDemand, TxtProdDemandNumber, "1")
        'Else
        '    EP_TE_cant_blank(EPProdDemand, TxtProdDemandNumber)
        'End If
    End Sub
    'Form Load
    Private Sub FormProdDemandSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initial role super admin
        id_role_super_admin = get_setup_field("id_role_super_admin")

        viewBudget()
        viewCategory()
        viewSeason()
        viewKind()
        viewPDType()
        _view_division_fg(LESampleDivision)
        viewReportStatus()

        'menu design info
        Dim vmenu_prop As ClassOwnMenu = New ClassOwnMenu()
        vmenu_prop.createDesignInfoForPD(vmenu, GVDesign)

        'from line list
        If dsg_line_list <> "-1" Then
            SLESeason.EditValue = ss_line_list
        End If

        'non md default type
        If SLEKind.EditValue.ToString <> "1" Then
            LECat.ItemIndex = LECat.Properties.GetDataSourceRowIndex("id_pd", "1")
            GVDesign.OptionsView.ColumnAutoWidth = True
        End If

        actionLoad()

        'divisi non md - tidak punya divisi biarkan stelah action load
        'If SLEKind.EditValue.ToString <> "1" Then
        'LESampleDivision.EditValue = Nothing
        'LESampleDivision.Enabled = False
        'End If



        'custom column template inisialisasi
        'initialisation datatable edit
        Try
            data_column.Columns.Add("options_view_det_band")
            data_column.Columns.Add("options_view_det_caption")
            data_column.Columns.Add("options_view_det_column")
            data_column.Columns.Add("options_view_det_visible")
        Catch ex As Exception
        End Try
    End Sub

    'budget
    Sub viewBudget()
        Dim query As String = "SELECT * FROM tb_lookup_pd_budget ORDER BY id_pd_budget ASC"
        viewLookupQuery(LEBudget, query, 0, "pd_budget", "id_pd_budget")
    End Sub

    'type
    Sub viewKind()
        Dim query As String = "SELECT * FROM tb_lookup_pd_kind "
        If id_role_login <> id_role_super_admin And id_role_login <> "18" Then
            query += "WHERE id_departement='" + id_departement_user + "' "
        End If
        query += "ORDER BY id_pd_kind ASC "
        viewSearchLookupQuery(SLEKind, query, "id_pd_kind", "pd_kind", "id_pd_kind")
    End Sub

    'phase
    Sub viewCategory()
        Dim query As String = "SELECT * FROM tb_lookup_pd WHERE id_pd!='2' ORDER BY id_pd ASC"
        viewLookupQuery(LECat, query, 0, "pd", "id_pd")
    End Sub

    'view PD Type
    Sub viewPDType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type ORDER BY id_pd_type ASC "
        viewLookupQuery(LEPDType, query, 0, "pd_type", "id_pd_type")
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
        query += "WHERE b.id_departement='" + id_departement_user + "' "
        query += "ORDER BY b.range DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLESeason.Properties.DataSource = Nothing
        SLESeason.Properties.DataSource = data
        SLESeason.Properties.DisplayMember = "season"
        SLESeason.Properties.ValueMember = "id_season"
        If data.Rows.Count.ToString >= 1 Then
            SLESeason.EditValue = data.Rows(0)("id_season").ToString
            short_name_ss = data.Rows(0)("season_printed_name").ToString
        Else
            SLESeason.EditValue = Nothing
        End If
    End Sub
    'action load
    Sub actionLoad()
        If action = "ins" Then
            'LabelPD.Text = "New Production Demand"
            BtnResetPropose.Visible = False
            BtnPrint.Enabled = False
            BMark.Visible = False
            BtnAttachment.Enabled = False
            GroupControlList.Enabled = False

            Dim query_now As String = "SELECT NOW();"
            Dim data As DataTable = execute_query(query_now, -1, True, "", "", "", "")
            DEForm.EditValue = data.Rows(0)("now()")

            'get rate current
            Dim qrc As String = "SELECT rate_management FROM tb_opt "
            Dim drc As DataTable = execute_query(qrc, -1, True, "", "", "", "")
            TxtRateCurrent.EditValue = drc.Rows(0)("rate_management")
        ElseIf action = "upd" Then
            'Edit genneral
            GroupControlList.Enabled = True
            BtnSave.Text = "Save Changes"
            BtnCancel.Text = "Close"
            SLESeason.EditValue = id_season

            LECat.ItemIndex = LECat.Properties.GetDataSourceRowIndex("id_pd", id_pd)
            SLEKind.EditValue = id_pd_kind
            LEPDType.ItemIndex = LEPDType.Properties.GetDataSourceRowIndex("id_pd_type", id_pd_type)
            LEBudget.ItemIndex = LEBudget.Properties.GetDataSourceRowIndex("id_pd_budget", id_pd_budget)
            If id_division = "0" Then
                LESampleDivision.EditValue = Nothing
            End If
            LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", id_division)
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_report_status)
            TxtRateCurrent.EditValue = rate_current

            ButtonEdit1.Enabled = False
            BtnDelRef.Enabled = False

            'rmt
            If SLEKind.EditValue.ToString = "1" Then 'MD
                report_mark_type = "9"
            ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
                report_mark_type = "80"
            ElseIf SLEKind.EditValue.ToString = "3" Then 'HRD
                report_mark_type = "81"
            ElseIf SLEKind.EditValue.ToString = "4" Then 'SALES
                report_mark_type = "206"
            End If

            'Design tab
            viewDesignDemand()
            allow_status()
        End If
    End Sub

    Sub allow_status()
        'Based on report status
        BtnCancellPropose.Visible = True
        BtnSave.Visible = False
        LEBudget.Enabled = False
        BtnAttachment.Enabled = True
        SLEKind.Enabled = False
        PanelControlCompleted.Visible = True
        LEPDType.Enabled = False
        LESampleDivision.Enabled = False
        SLESeason.Enabled = False
        If is_confirm = "2" And check_edit_report_status(id_report_status, report_mark_type, id_prod_demand) Then
            'MsgBox("Masih Boleh"
            BtnPrint.Enabled = False
            BtnConfirm.Visible = True
            BMark.Visible = False
            PanelControlNav.Visible = True
            MENote.Enabled = True
            LECat.Enabled = True
        Else
            'MsgBox("Nggak Boleh"
            BtnPrint.Enabled = True
            BtnConfirm.Visible = False
            BMark.Visible = True
            PanelControlNav.Visible = False
            MENote.Enabled = False
            LECat.Enabled = False
        End If

        'reset propose
        If is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            PanelControlCENONActive.Visible = True
            XTPRevision.PageVisible = True
            BtnCancellPropose.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancellPropose.Visible = False
            BtnResetPropose.Visible = False
        End If
    End Sub

    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        validatingPDNumber()

        'cek
        Dim rmt As String = ""
        If SLEKind.EditValue.ToString = "1" Then 'MD
            rmt = "9"
        ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
            rmt = "80"
        ElseIf SLEKind.EditValue.ToString = "3" Then 'HRD
            rmt = "81"
        ElseIf SLEKind.EditValue.ToString = "4" Then 'SALES
            rmt = "206"
        End If

        If Not formIsValidInPanel(EPProdDemand, GroupGeneralHeader) Then
            errorInput()
        Else
            Dim query As String
            Dim prod_demand_number As String = addSlashes(TxtProdDemandNumber.Text)
            Dim id_seasonx As String = SLESeason.EditValue
            Dim prod_demand_note As String = MENote.Text.ToString
            Dim id_pd_type As String = "2" 'LEPDType.EditValue.ToString
            Dim id_divisionx As String = "0"
            Try
                id_divisionx = LESampleDivision.EditValue.ToString
            Catch ex As Exception
            End Try
            Dim is_pd As String = LECat.EditValue.ToString
            Dim id_pd_kindx As String = SLEKind.EditValue.ToString
            Dim id_pd_budgetx As String = LEBudget.EditValue.ToString

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'get PD Number
                    'prod_demand_number = execute_query("SELECT gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kind + "')", 0, True, "", "", "", "")

                    'query new
                    '***get rate tersimpan
                    Dim qrc As String = "SELECT rate_management FROM tb_opt "
                    Dim drc As DataTable = execute_query(qrc, -1, True, "", "", "", "")
                    rate_current = drc.Rows(0)("rate_management")
                    If id_prod_demand_ref = "-1" Then
                        query = "INSERT INTO tb_prod_demand(prod_demand_number, id_season, prod_demand_note, id_pd_type, id_pd_kind, prod_demand_date, id_division, is_pd, id_pd_budget, is_confirm,rate_current) "
                        query += "VALUES(gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kindx + "'), '" + id_seasonx + "', '" + prod_demand_note + "', '" + id_pd_type + "', '" + id_pd_kindx + "', NOW(), " + id_divisionx + ", '" + is_pd + "', '" + id_pd_budgetx + "', 2, '" + decimalSQL(rate_current.ToString) + "'); SELECT LAST_INSERT_ID(); "
                    Else
                        query = "INSERT INTO tb_prod_demand(prod_demand_number, id_season, prod_demand_note, id_prod_demand_ref, id_pd_type, id_pd_kind, prod_demand_date, id_division, is_pd, id_pd_budget, is_confirm,rate_current) "
                        query += "VALUES(gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kindx + "'), '" + id_seasonx + "', '" + prod_demand_note + "', '" + id_prod_demand_ref + "', '" + id_pd_type + "', '" + id_pd_kindx + "', NOW(), '" + id_divisionx + "', '" + is_pd + "','" + id_pd_budgetx + "', 2, '" + decimalSQL(rate_current.ToString) + "'); SELECT LAST_INSERT_ID(); "
                    End If
                    id_prod_demand = execute_query(query, 0, True, "", "", "", "")


                    insert_who_prepared("9", id_prod_demand, id_user)
                    '
                    logData("tb_prod_demand", 1)

                    'duplicate - Updated 3 Feb 2015
                    If id_prod_demand_ref <> "-1" And id_prod_demand_ref <> "" Then
                        'Dim query_ref As String = "CALL generate_pd_duplicate('" + id_prod_demand + "', '" + id_prod_demand_ref + "') "
                        'execute_non_query(query_ref, True, "", "", "", "")
                    End If

                    'detail
                    If dsg_line_list <> "-1" Then
                        Dim query_det_new As String = "CALL generate_pd_line_list('" + id_prod_demand + "', '" + type_line_list + "', '" + dsg_line_list + "')"
                        execute_non_query(query_det_new, True, "", "", "", "")
                    End If


                    FormProdDemand.viewProdDemand()
                    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                    action = "upd"
                    id_season = id_seasonx
                    id_report_status = LEReportStatus.EditValue.ToString
                    id_division = id_divisionx
                    id_pd = is_pd
                    id_pd_kind = id_pd_kindx
                    id_pd_budget = id_pd_budgetx

                    actionLoad()
                    prod_demand_number = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
                    TxtProdDemandNumber.Text = prod_demand_number
                    infoCustom("PD : " + prod_demand_number + ", created successfully.")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to confirm this PD ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    If id_prod_demand_ref = "-1" Or id_prod_demand_ref = "" Then
                        query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_prod_demand_ref = NULL, id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "' "
                        query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
                    Else
                        query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_prod_demand_ref = '" + id_prod_demand_ref + "', id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "'  "
                        query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
                    End If
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_prod_demand", 2)
                    FormProdDemand.viewProdDemand()
                    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                    action = "upd"
                    id_season = id_seasonx
                    id_report_status = LEReportStatus.EditValue.ToString
                    id_pd = is_pd
                    actionLoad()
                    infoCustom("PD : " + prod_demand_number + ", updated successfully.")
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
    '-----------------DESIGN---------------------------------
    Sub viewDesignDemand()
        ''initial u/ mengatasi tag yang belum terpanggil
        'Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        'prod_demand_report.printReportLess("-1", GVDesign, GCDesign)

        ''build report
        'prod_demand_report.printReportLess(id_prod_demand + " AND is_void=2 ", GVDesign, GCDesign)
        Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + " AND is_void=2 ')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        If GVDesign.RowCount < 1 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
            BBom.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
            BBom.Enabled = True
        End If

        'tampung
        If GVDesign.RowCount > 0 Then
            id_design_list.Clear()
            For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                id_design_list.Add(GVDesign.GetRowCellValue(i, "id_design_desc_report_column").ToString)
            Next
        End If

        'custom view
        'optionsViewBanded(GVDesign, "FormProdDemandSingle", "GVDesign", "1")

        GCDesign.RefreshDataSource()
        GVDesign.RefreshData()

        'bestfit
        'GVDesign.BestFitColumns()
        check_but()
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("AND r.id_prod_demand=" + id_prod_demand + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    'Add Design
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormProdDemandAdd.ShowDialog()
        Cursor = Cursors.Default
        'FormProdDemandDesignSingle.action = "ins"
        'FormProdDemandDesignSingle.ShowDialog()
    End Sub
    'Edit Design
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMasterDesignSingle.id_pop_up = "-1"
            FormMasterDesignSingle.form_name = "FormFGLineList"
            FormMasterDesignSingle.id_design = GVDesign.GetFocusedRowCellValue("id_design_desc_report_column").ToString
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.ShowDialog()
            Cursor = Cursors.Default
        End If
        'FormProdDemandDesignSingle.action = "upd"
        'FormProdDemandDesignSingle.id_prod_demand_design = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        'FormProdDemandDesignSingle.ShowDialog()
    End Sub

    Private Sub BBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBom.Click
        '
        FormViewBOMFull.id_prod_demand_design = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        FormViewBOMFull.ShowDialog()
    End Sub
    'Delete Design
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this design?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim query As String
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_dsg As String = GVDesign.GetFocusedRowCellValue("id_design_desc_report_column").ToString
                    Dim id_prod_demand_design As String = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                    query = String.Format("DELETE FROM tb_prod_demand_design WHERE id_prod_demand_design = '{0}'", id_prod_demand_design)
                    execute_non_query(query, True, "", "", "", "")
                    check_but()
                    logData("tb_prod_demand_design", 3)
                    viewDesignDemand()
                    FormProdDemand.viewProdDemand()
                    id_design_list.Remove(id_dsg)
                    GCDesign.RefreshDataSource()
                    GVDesign.RefreshData()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    'Row Click
    'Private Sub GVDesign_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDesign.RowClick
    '    If Not first_load Then
    '        Try
    '            Dim parse_data As String = GVDesign.GetFocusedRowCellDisplayText("id_prod_demand_design")
    '            If Not parse_data = "" Then
    '                If BtnEdit.Enabled = True Then
    '                    BtnEdit.Enabled = True
    '                End If
    '                If BtnDelete.Enabled = True Then
    '                    BtnDelete.Enabled = True
    '                End If
    '            Else
    '                BtnEdit.Enabled = False
    '                BtnDelete.Enabled = False
    '            End If
    '        Catch ex As Exception
    '            BtnEdit.Enabled = False
    '            BtnDelete.Enabled = False
    '        End Try
    '    End If
    'End Sub
    'Focus Row Changed
    'Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
    '    Dim focusedRowHandle As Integer = -1
    '    If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        Return
    '    End If
    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    If e.FocusedRowHandle < 0 Then
    '        If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
    '            focusedRowHandle = 0
    '        ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
    '            focusedRowHandle = e.PrevFocusedRowHandle
    '        Else
    '            Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
    '            Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
    '            If prevRow > currRow Then
    '                focusedRowHandle = e.PrevFocusedRowHandle - 1
    '            Else
    '                focusedRowHandle = e.PrevFocusedRowHandle + 1
    '            End If
    '            If focusedRowHandle < 0 Then
    '                focusedRowHandle = 0
    '            End If
    '            If focusedRowHandle >= view.DataRowCount Then
    '                focusedRowHandle = view.DataRowCount - 1
    '            End If
    '        End If
    '        If focusedRowHandle < 0 Then
    '            view.FocusedRowHandle = 0
    '        Else
    '            view.FocusedRowHandle = focusedRowHandle
    '        End If
    '    End If
    'End Sub

    Private Sub ButtonEdit1_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        Cursor = Cursors.WaitCursor
        FormProdDemandRefSingle.id_pop_up = "1"
        FormProdDemandRefSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRef.Click
        ButtonEdit1.EditValue = ""
        id_prod_demand_ref = "-1"
    End Sub

    'sub check_but
    Sub check_but()
        'Dim id_prod_demand_designx As String = "-1"
        'Try
        '    id_prod_demand_designx = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        'Catch ex As Exception
        'End Try

        'If GVDesign.RowCount > 0 And id_prod_demand_designx <> "-1" And id_prod_demand_designx <> "" Then
        '    BtnEdit.Enabled = True
        '    BtnDelete.Enabled = True
        '    BBom.Enabled = True
        'Else
        '    BtnEdit.Enabled = False
        '    BtnDelete.Enabled = False
        '    BBom.Enabled = False
        'End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        check_but()
    End Sub

    Private Sub GVDesign_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDesign.ColumnFilterChanged
        check_but()
        If GVDesign.ActiveFilterString = "" Then
            CheckEditShowNonActive.EditValue = False
        End If

    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_prod_demand
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        openAttach()
    End Sub

    Sub openAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_demand
        FormDocumentUpload.report_mark_type = report_mark_type

        'cek ud submit ato blm
        If id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_no_delete = "1"
        End If

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub



    Private Sub GVDesign_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDesign.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub printStyleReport(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        gv.OptionsPrint.UsePrintStyles = True
        gv.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        gv.AppearancePrint.FilterPanel.ForeColor = Color.Black
        gv.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        gv.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        gv.AppearancePrint.GroupFooter.ForeColor = Color.Black
        gv.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        gv.AppearancePrint.GroupRow.BackColor = Color.Transparent
        gv.AppearancePrint.GroupRow.ForeColor = Color.Black
        gv.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        gv.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        gv.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        gv.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        gv.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        gv.AppearancePrint.FooterPanel.ForeColor = Color.Black
        gv.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        gv.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        gv.OptionsPrint.ExpandAllDetails = True
        gv.OptionsPrint.UsePrintStyles = True
        gv.OptionsPrint.PrintDetails = True
        gv.OptionsPrint.PrintFooter = True
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, report_mark_type, id_prod_demand) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            If CEBreakSizeDetail.EditValue = False Then
                ReportProdDemandNew.dt = GCDesign.DataSource
                ReportProdDemandNew.id_prod_demand = id_prod_demand
                If id_report_status <> "6" Then
                    ReportProdDemandNew.is_pre = "1"
                Else
                    ReportProdDemandNew.is_pre = "1"
                End If
                ReportProdDemandNew.id_report_status = LEReportStatus.EditValue.ToString

                ReportProdDemandNew.rmt = report_mark_type
                Dim Report As New ReportProdDemandNew()

                '' '... 
                '' ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                'style
                printStyleReport(Report.GVDesign)

                'value
                Report.LabelNumber.Text = TxtProdDemandNumber.Text
                Report.LabelDate.Text = DEForm.Text.ToUpper
                Report.LabelSeason.Text = SLESeason.Text
                Report.LabelDivision.Text = LESampleDivision.Text
                Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
                Report.LabelRateCurrent.Text = TxtRateCurrent.Text
                Report.LNote.Text = MENote.Text

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            Else
                'with break down size detail
                XTCDetail.SelectedTabPageIndex = 1
                ReportProdDemandNewBreakSize.dt = GCDesign.DataSource
                ReportProdDemandNewBreakSize.dt2 = GCSize.DataSource
                ReportProdDemandNewBreakSize.id_prod_demand = id_prod_demand
                If id_report_status <> "6" Then
                    ReportProdDemandNewBreakSize.is_pre = "1"
                Else
                    ReportProdDemandNewBreakSize.is_pre = "1"
                End If
                ReportProdDemandNewBreakSize.id_report_status = LEReportStatus.EditValue.ToString

                ReportProdDemandNewBreakSize.rmt = report_mark_type
                Dim Report As New ReportProdDemandNewBreakSize()

                '' '... 
                '' ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                str = New System.IO.MemoryStream()
                GVSize.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GVSize.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                'style
                printStyleReport(Report.GVDesign)
                printStyleReport(Report.GVSize)

                'value
                Report.LabelNumber.Text = TxtProdDemandNumber.Text
                Report.LabelDate.Text = DEForm.Text.ToUpper
                Report.LabelSeason.Text = SLESeason.Text
                Report.LabelDivision.Text = LESampleDivision.Text
                Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
                Report.LabelRateCurrent.Text = TxtRateCurrent.Text
                Report.LNote.Text = MENote.Text

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            End If



            'set default
            If CEBreakSizeDetail.EditValue = True Then
                XTCDetail.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        viewDesignDemand()
    End Sub

    Private Sub BtnAddFromLineList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFromLineList.Click
        Cursor = Cursors.WaitCursor
        FormProdDemandLineList.id_season_par = SLESeason.EditValue
        FormProdDemandLineList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLESeason.Properties.View
            Dim rowhandle As Integer = view.FocusedRowHandle
            short_name_ss = view.GetRowCellValue(rowhandle, "season_printed_name").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged

    End Sub

    'Private Sub GVDesign_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
    '    If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
    '        Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

    '        If Not menu.Column Is Nothing Then
    '            menu.Items.Add(CreateCheckItem("Options View", menu.Column))
    '        End If
    '    End If

    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
    '    If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
    '        view.FocusedRowHandle = hitInfo.RowHandle
    '        vmenu.Show(view.GridControl, e.Point)
    '    End If
    'End Sub

    ' Creates a menu item.
    'Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
    '    Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
    '    item.Tag = New MenuColumnInfo(column)
    '    Return item
    'End Function

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    ' Menu item click handler.
    'Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
    '    data_column.Clear()
    '    For i As Integer = 0 To GVDesign.Columns.Count - 1
    '        Dim R As DataRow = data_column.NewRow
    '        R("options_view_det_band") = GVDesign.Columns(i).OwnerBand.ToString
    '        R("options_view_det_caption") = GVDesign.Columns(i).Caption.ToString
    '        R("options_view_det_column") = GVDesign.Columns(i).FieldName.ToString
    '        R("options_view_det_visible") = GVDesign.Columns(i).Visible.ToString
    '        data_column.Rows.Add(R)
    '    Next
    '    FormOptView.frm_opt_name = "FormProdDemandSingle"
    '    FormOptView.gv_opt_name = "GVDesign"
    '    FormOptView.tag_opt_name = "1"
    '    FormOptView.dt = data_column
    '    FormOptView.ShowDialog()
    'End Sub

    Private Sub SLEKind_EditValueChanged(sender As Object, e As EventArgs) Handles SLEKind.EditValueChanged
        'If SLEKind.EditValue.ToString <> "1" Then
        '    LESampleDivision.EditValue = Nothing
        '    LESampleDivision.Enabled = False
        'Else
        '    LESampleDivision.EditValue = 3823
        '    LESampleDivision.Enabled = True
        'End If
    End Sub

    Private Sub CheckEditShowActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowNonActive.CheckedChanged
        Cursor = Cursors.WaitCursor
        If CheckEditShowNonActive.EditValue = True Then
            GridColumndrop_ref.VisibleIndex = GridColumnMoveDrop.VisibleIndex + 1
            Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
        Else
            GridColumndrop_ref.Visible = False
            Dim query As String = "CALL view_prod_demand_list_less('" + id_prod_demand + " AND is_void=2 ')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
        End If
        'cek breakdown size
        is_load_break_size = False
        checkBreakSize()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCPD_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPD.SelectedPageChanged
        If XTCPD.SelectedTabPageIndex = 1 Then
            viewRevision()
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.id_report = GVData.GetFocusedRowCellValue("id_prod_demand_rev").ToString
            m.report_mark_type = report_mark_type
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewBreakdownSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBreakdownSizeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Dim id_prod_demand_design As String = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
            FormProdDemandBreakSize.LabelTitle.Text = GVDesign.GetFocusedRowCellValue("DESCRIPTION_desc_report_column").ToString
            FormProdDemandBreakSize.LabelSubTitle.Text = GVDesign.GetFocusedRowCellValue("CODE_desc_report_column").ToString
            FormProdDemandBreakSize.id_pdd = id_prod_demand_design
            FormProdDemandBreakSize.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To GVDesign.Columns.Count - 1
            Console.WriteLine(GVDesign.Columns(i).FieldName.ToString)
        Next
        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to confirm this PD ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        'If confirm = Windows.Forms.DialogResult.Yes Then
        '    Cursor = Cursors.WaitCursor
        '    Dim query As String = ""
        '    Dim is_pd As String = LECat.EditValue.ToString
        '    Dim id_seasonx As String = SLESeason.EditValue
        '    Dim prod_demand_note As String = addSlashes(MENote.Text)
        '    Dim id_divisionx As String = "0"
        '    Try
        '        id_divisionx = LESampleDivision.EditValue.ToString
        '    Catch ex As Exception
        '    End Try
        '    If id_prod_demand_ref = "-1" Or id_prod_demand_ref = "" Then
        '        query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_prod_demand_ref = NULL, id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "' "
        '        query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
        '    Else
        '        query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_prod_demand_ref = '" + id_prod_demand_ref + "', id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "'  "
        '        query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
        '    End If
        '    execute_non_query(query, True, "", "", "", "")
        '    logData("tb_prod_demand", 2)
        '    FormProdDemand.viewProdDemand()
        '    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
        '    action = "upd"
        '    id_season = id_seasonx
        '    id_report_status = LEReportStatus.EditValue.ToString
        '    id_pd = is_pd
        '    actionLoad()
        '    infoCustom("PD submitted. Waiting for approval.")
        '    Cursor = Cursors.Default
        'End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancellPropose.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_prod_demand SET id_report_status=5 WHERE id_prod_demand='" + id_prod_demand + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_prod_demand, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormProdDemand.viewProdDemand()
            FormProdDemand.GVProdDemand.FocusedRowHandle = find_row_as_is(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
            id_report_status = "5"
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub GVDesign_CustomSummaryCalculate_1(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVDesign.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL_add_report_column"), "0.00"))
            Select Case summaryID
                Case 46
                    tot_cost += cost
                    tot_prc += prc
                Case 47
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 46 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 47 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub CEBreakSize_CheckedChanged(sender As Object, e As EventArgs) Handles CEBreakSize.CheckedChanged
        checkBreakSize()
    End Sub

    Sub checkBreakSize()
        Cursor = Cursors.WaitCursor
        Dim pd As New ClassProdDemand
        If CEBreakSize.EditValue = True Then
            'jika belum load
            If Not is_load_break_size Then
                pd.generateBreakSize(id_prod_demand, GVDesign)
            End If

            'show column
            pd.showBreakSize(GVDesign)
            is_load_break_size = True
        Else
            'hide
            pd.hideBreakSize(GVDesign)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click_1(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount <= 0 Then
            stopCustom("Detailed data not found. If you want to cancel this revision, please click 'Cancel Propose'")
        Else
            Dim prod_demand_note As String = addSlashes(MENote.Text)
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this PD ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update confirm
                Dim query As String = "UPDATE tb_prod_demand SET is_confirm=1,prod_demand_note='" + prod_demand_note + "'  WHERE id_prod_demand='" + id_prod_demand + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit
                submit_who_prepared(report_mark_type, id_prod_demand, id_user)

                'refresh
                FormProdDemand.viewProdDemand()
                FormProdDemand.GVProdDemand.FocusedRowHandle = find_row_as_is(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                is_confirm = "1"
                action = "upd"
                actionLoad()
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id_prod_demand + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim query_upd As String = "-- delete report mark
                    DELETE FROM tb_report_mark WHERE report_mark_type=" + report_mark_type + " AND id_report=" + id_prod_demand + "; 
                    -- reset confirm
                    UPDATE tb_prod_demand SET is_confirm=2 WHERE id_prod_demand=" + id_prod_demand + "; "
                    execute_non_query(query_upd, True, "", "", "", "")
                Catch ex As Exception
                    stopCustom(ex.ToString)
                    Close()
                End Try


                'refresh
                FormProdDemand.viewProdDemand()
                FormProdDemand.GVProdDemand.FocusedRowHandle = find_row_as_is(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                is_confirm = "2"
                action = "upd"
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub RepoLinkDropRef_Click(sender As Object, e As EventArgs) Handles RepoLinkDropRef.Click
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Dim type_drop_ref As String = "0"
            Try
                type_drop_ref = GVDesign.GetFocusedRowCellValue("type_drop_ref").ToString
            Catch ex As Exception
                type_drop_ref = "0"
            End Try

            If type_drop_ref <> "0" Then

                Dim id_drop_ref As String = "-1"
                Try
                    id_drop_ref = GVDesign.GetFocusedRowCellValue("id_drop_ref").ToString
                Catch ex As Exception
                End Try


                If type_drop_ref = "1" Then
                    FormProdDemandRevDet.id = id_drop_ref
                    FormProdDemandRevDet.is_view = "1"
                    FormProdDemandRevDet.ShowDialog()
                ElseIf type_drop_ref = "2" Then
                    FormFGDesignListChanges.id = id_drop_ref
                    FormFGDesignListChanges.is_view = "1"
                    FormFGDesignListChanges.ShowDialog()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSizeDetail_Click(sender As Object, e As EventArgs) Handles BtnSizeDetail.Click
        Cursor = Cursors.WaitCursor
        FormProdDemandSize.rmt = report_mark_type
        FormProdDemandSize.id_report_status = id_report_status
        FormProdDemandSize.status = LEReportStatus.Text.ToUpper
        FormProdDemandSize.season = SLESeason.Text
        FormProdDemandSize.created_date = DEForm.Text.ToUpper
        FormProdDemandSize.division = LESampleDivision.Text
        FormProdDemandSize.id = id_prod_demand
        FormProdDemandSize.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewBreakdownSize()
        Cursor = Cursors.WaitCursor
        Dim pd As New ClassProdDemand()
        pd.viewBreakSizeDetail(id_prod_demand, GCSize, GVSize)
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCDetail_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDetail.SelectedPageChanged
        If XTCDetail.SelectedTabPageIndex = 1 Then
            viewBreakdownSize()
        End If
    End Sub

    Private Sub GVSize_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSize.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class