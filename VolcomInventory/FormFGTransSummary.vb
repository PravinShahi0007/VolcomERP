Public Class FormFGTransSummary
    Private Sub FormFGTransSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`, LAST_DAY(DATE(NOW())) AS `last_date` ", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEUntil.Properties.MaxValue = data_dt.Rows(0)("last_date")
        viewAmoType()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()
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
        Dim id_typ As String = LEAmoType.EditValue.ToString
        If id_typ = "1" Then
            GridColumnPrice.VisibleIndex = GridColumnEnd.VisibleIndex + 1
        ElseIf id_typ = "2" Then
            GridColumnCost.VisibleIndex = GridColumnEnd.VisibleIndex + 1
        Else
            GridColumnPrice.Visible = False
            GridColumnCost.Visible = False
        End If

        Dim query As String = "CALL view_trans_summary_less('" + date_from_selected + "','" + date_until_selected + "'," + id_typ + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewAmoType()
        Dim query As String = "SELECT 0 AS `id_typ`, 'No Amount' AS `typ`
        UNION
        SELECT 1 AS `id_typ`, 'Retail Price' AS `typ`
        UNION
        SELECT 2 AS `id_typ`, 'Cost Price' AS `typ` "
        viewLookupQuery(LEAmoType, query, 0, "typ", "id_typ")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub FormFGTransSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGTransSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "trans_sum.xlsx"
            exportToXLS(path, "transaction summary", GCData)
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

    Dim tot_sal As Decimal
    Dim tot_end As Decimal
    Dim tot_sal_grp As Decimal
    Dim tot_end_grp As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_sal = 0.0
            tot_end = 0.0
            tot_sal_grp = 0.0
            tot_end_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim sal As Decimal = View.GetRowCellValue(e.RowHandle, "qty_sal")
            Dim endd As Decimal = View.GetRowCellValue(e.RowHandle, "qty_end")
            Select Case summaryID
                Case "a"
                    tot_sal += sal
                    tot_end += endd
                Case "b"
                    tot_sal_grp += sal
                    tot_end_grp += endd
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "a" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = Math.Abs((tot_sal / tot_end) * 100)
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "b" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = Math.Abs((tot_sal_grp / tot_end_grp) * 100)
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("qty") Or e.Column.FieldName.Contains("amount") Or e.Column.FieldName.Contains("pros")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        End If
    End Sub
End Class