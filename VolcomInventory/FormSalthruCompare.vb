Public Class FormSalthruCompare
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormSalthruCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/salthru-compare")
        DEUntil.EditValue = volcomErpApiGetDT(dt_json, 0).Rows(0)("current_date")
        viewSeason()
        viewType()
    End Sub

    Private Sub FormSalthruCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSeason()
        Dim data As DataTable = volcomErpApiGetDT(dt_json, 1)

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewType()
        viewSearchLookupQueryO(SLEType, volcomErpApiGetDT(dt_json, 2), "id_salthru_type", "salthru_type", "id_salthru_type")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'cek closing
        Dim y As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy") + "," + DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy")
        Dim m As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("MM") + "," + DateTime.Parse(DEUntil.EditValue.ToString).ToString("MM")
        checkClosingSOHSalPeriod(m, y)

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        'cek date
        Dim date_until_selected As String = "0000-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'season
        Dim where_string As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_string += "AND d.id_season IN(" + CCBESeason.EditValue.ToString + ") "
        End If

        'type
        Dim id_salthru_type As String = SLEType.EditValue.ToString


        If XTCData.SelectedTabPageIndex = 0 Then
            Dim query As String = "CALL view_compare_sal_thru('" + date_until_selected + "','" + id_salthru_type + "', '" + where_string + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
        Else
            Dim query As String = "CALL view_compare_sal_thru_product('" + date_until_selected + "','" + id_salthru_type + "', '" + where_string + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
        End If

        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Dim tot_sal As Decimal
    Dim tot_soh As Decimal
    Dim tot_sal_grp As Decimal
    Dim tot_soh_grp As Decimal

    Dim tot_sal2 As Decimal
    Dim tot_soh2 As Decimal
    Dim tot_sal_grp2 As Decimal
    Dim tot_soh_grp2 As Decimal

    Dim tot_st_target As Decimal
    Dim tot_st_target_grp As Decimal

    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_sal = 0.0
            tot_soh = 0.0
            tot_sal_grp = 0.0
            tot_soh_grp = 0.0

            tot_sal2 = 0.0
            tot_soh2 = 0.0
            tot_sal_grp2 = 0.0
            tot_soh_grp2 = 0.0

            tot_st_target = 0.00
            tot_st_target_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim sal As Decimal = myCoalesce(View.GetRowCellValue(e.RowHandle, "sal_qty"), 0.00)
            Dim soh As Decimal = myCoalesce(View.GetRowCellValue(e.RowHandle, "soh_qty"), 0.00)
            Dim st_actual As Decimal = myCoalesce(View.GetRowCellValue(e.RowHandle, "actual_salthru"), 0.00)
            Dim st_target As Decimal = myCoalesce(View.GetRowCellValue(e.RowHandle, "target_salthru"), 0.00)

            Select Case summaryID
                Case "act_salthru_sum"
                    tot_sal += sal
                    tot_soh += soh
                Case "act_salthru_groupsum"
                    tot_sal_grp += sal
                    tot_soh_grp += soh
                Case "sum_diff_salthru"
                    tot_sal2 += sal
                    tot_soh2 += soh
                    tot_st_target = st_target
                Case "group_sum_diff_salthru"
                    tot_sal_grp2 += sal
                    tot_soh_grp2 += soh
                    tot_st_target_grp = st_target
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "act_salthru_sum" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_sal / (tot_sal + tot_soh)) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "act_salthru_groupsum" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_sal_grp / (tot_sal_grp + tot_soh_grp)) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "sum_diff_salthru"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = ((tot_sal2 / (tot_sal2 + tot_soh2)) * 100) - tot_st_target
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "group_sum_diff_salthru"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = ((tot_sal_grp2 / (tot_sal_grp2 + tot_soh_grp2)) * 100) - tot_st_target_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
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

    Private Sub BtnExportXls_Click(sender As Object, e As EventArgs) Handles BtnExportXls.Click
        If XTCData.SelectedTabPageIndex = 0 Then
            If GVData.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "sth_acc_product.xlsx"
                exportToXLS(path, "list", GCData)
                Cursor = Cursors.Default
            End If
        Else
            If GVProduct.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "sth_product.xlsx"
                exportToXLS(path, "list", GCProduct)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
        GCProduct.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        resetView()
    End Sub

    Private Sub CCBESeason_EditValueChanged(sender As Object, e As EventArgs) Handles CCBESeason.EditValueChanged
        resetView()
    End Sub

    Private Sub FormSalthruCompare_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalthruCompare_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class