Public Class FormWHSvcLevel
    Dim id_design_selected As String = "-1"
    Public id_comp_selected As String = "-1"
    Private Sub FormWHSvcLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromCode.EditValue = data_dt.Rows(0)("dt")
        DEUntilCode.EditValue = data_dt.Rows(0)("dt")
        DEFromAcc.EditValue = data_dt.Rows(0)("dt")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewSvcBySO()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_so('" + date_from_selected + "','" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBySO.DataSource = data
        GVBySO.BestFitColumns()
    End Sub

    Sub viewSvcByCode()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromCode.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilCode.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_code('" + date_from_selected + "','" + date_until_selected + "', '" + id_design_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByCode.DataSource = data
    End Sub

    Sub viewSvcByAcc()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_acc('" + date_from_selected + "', '" + date_until_selected + "', '" + id_comp_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByAcco.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSvcBySO()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormWHSvcLevel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        checkFocus()
    End Sub

    Private Sub FormWHSvcLevel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnAcc_Click(sender As Object, e As EventArgs) Handles BtnAcc.Click
        Cursor = Cursors.WaitCursor
        viewSvcByAcc()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewCode_Click(sender As Object, e As EventArgs) Handles BtnViewCode.Click
        Cursor = Cursors.WaitCursor
        viewSvcByCode()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCSvcLelel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLelel.SelectedPageChanged
        checkFocus()
    End Sub

    Sub checkFocus()
        If XTCSvcLelel.SelectedTabPageIndex = 0 Then
            DEFrom.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 1 Then
            TxtDesignCode.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 2 Then
            TxtCompID.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 3 Then
            DEFromReturn.Focus()
        End If
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcBySO()
            BtnView.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEFromCode_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilCode.Focus()
        End If
    End Sub

    Private Sub DEUntilCode_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcByCode()
            BtnViewCode.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEFromAcc_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilAcc.Focus()
        End If
    End Sub

    Private Sub DEUntilAcc_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcByAcc()
            BtnAcc.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        Cursor = Cursors.WaitCursor
        viewSvcReturn()
        Cursor = Cursors.Default
    End Sub

    Sub viewSvcReturn()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_return('" + date_from_selected + "','" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReturn.DataSource = data
        GVReturn.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFromReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturn.Focus()
        End If
    End Sub

    Private Sub DEUntilReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturn.Focus()
        End If
    End Sub

    Private Sub TextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesignCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name
            FROM tb_m_design d 
            WHERE d.design_code='" + addSlashes(TxtDesignCode.Text) + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Or TxtDesignCode.Text = "" Then
                stopCustom("Design not found !")
                id_design_selected = "-1"
                TxtDesign.Text = ""
                TxtDesignCode.Text = ""
                GCByCode.DataSource = Nothing
                TxtDesignCode.Focus()
            Else
                id_design_selected = data.Rows(0)("id_design").ToString.ToUpper
                TxtDesign.Text = data.Rows(0)("design_display_name").ToString.ToUpper
                DEFromCode.Focus()
            End If
            GCByCode.DataSource = Nothing
            Cursor = Cursors.Default
        Else
            id_design_selected = "-1"
            TxtDesign.Text = ""
            GCByCode.DataSource = Nothing
        End If
    End Sub

    Private Sub TextEdit2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCompID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCompID.Text)
            Dim data As DataTable = get_company_by_code_no_limit(code, "AND !ISNULL(comp.id_drawer_def) AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
            If data.Rows.Count = 0 Or code = "" Then
                stopCustom("Account not found!")
                id_comp_selected = "-1"
                TxtComp.Text = ""
                TxtCompID.Text = ""
                TxtCompID.Focus()
            Else
                If data.Rows.Count = 1 Then
                    id_comp_selected = data.Rows(0)("id_comp").ToString
                    TxtComp.Text = data.Rows(0)("comp_name").ToString
                    DEFromAcc.Focus()
                Else
                    FormMasterCompanyDouble.dt = data
                    FormMasterCompanyDouble.ShowDialog()
                    If id_comp_selected <> "-1" Then
                        DEFromAcc.Focus()
                    Else
                        TxtCompID.Focus()
                    End If
                End If
            End If
            Cursor = Cursors.Default
        Else
            id_comp_selected = "-1"
            TxtComp.Text = ""
            GCByAcco.DataSource = Nothing
        End If
    End Sub

    Private Sub GVReturn_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVReturn.CustomColumnDisplayText
        If e.Column.FieldName = "diff_qty" Then
            If e.Value > 0 Then
                e.DisplayText = "+" + e.Value.ToString
            Else
                e.DisplayText = e.Value.ToString
            End If
            ' e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CEHighlightNonList_CheckedChanged(sender As Object, e As EventArgs) Handles CEHighlightNonList.CheckedChanged
        AddHandler GVReturn.RowStyle, AddressOf custom_cell
        GCReturn.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEHighlightNonList.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim diff As Integer = 0
            Try
                diff = currview.GetRowCellValue(e.RowHandle, "diff_qty")
            Catch ex As Exception
                diff = "0"
            End Try

            If diff > 0 Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub BtnExportToXLSSO_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSSO.Click
        If GVBySO.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sl_so.xlsx"
            exportToXLS(path, "svc level by order", GCBySO)
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
End Class