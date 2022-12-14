Public Class FormAgingProductList
    Public id_design_soh As String = "-1"

    Private Sub FormAgingProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAccount()
        DEUntilAcc.EditValue = getTimeDB()
    End Sub

    Private Sub FormAgingProductList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewAccount()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('All') AS comp_number, ('All Account') AS comp_name, ('All Account') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "9"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CEFindAllProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        id_design_soh = "-1"
        TxtProduct.Text = ""
        resetViewSOH()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Sub resetViewSOH()
        GCList.DataSource = Nothing
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub TxtProduct_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProduct.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetViewSOH()
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim id_comp As String = SLEAccount.EditValue.ToString
        Dim id_design_sel As String = ""
        If id_design_soh = "-1" Then
            id_design_sel = 0
        Else
            id_design_sel = id_design_soh
        End If
        Dim until_date As String = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "CALL view_aging_product_list('" + id_comp + "', '" + id_design_sel + "','" + until_date + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        'GVList.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        If CEFindAllProduct.EditValue = False And id_design_soh = "-1" Then
            warningCustom("Please input product code first")
            Exit Sub
        End If

        viewList()
    End Sub

    Private Sub BtnExportToXLSAcc_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSAcc.Click
        If GVList.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "age_prod_list.xlsx"
            exportToXLS(path, "list", GCList)
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

    Private Sub FormAgingProductList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAgingProductList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class