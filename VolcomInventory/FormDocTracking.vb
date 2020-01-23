Public Class FormDocTracking
    Private Sub FormDocTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim dt As DateTime = getTimeDB()
        DEFrom.EditValue = dt
        DEUntil.EditValue = dt

        loadComp()
    End Sub

    Sub loadComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name, c.id_comp_cat
        FROM tb_m_comp c
        WHERE (c.id_comp_cat='5' OR c.id_comp_cat='6') "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
        SLEComp.EditValue = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDocTracking_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDocTracking_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Cursor = Cursors.WaitCursor
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

        'comp
        Dim id_comp As String = "0"
        If SLEComp.EditValue = Nothing Then
            stopCustom("Please select account first")
            Cursor = Cursors.Default
            Exit Sub
        Else
            id_comp = SLEComp.EditValue.ToString
        End If
        Dim query As String = "CALL view_doc_tracking(" + id_comp + ", '" + date_from_selected + "', '" + date_until_selected + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLink_Click(sender As Object, e As EventArgs) Handles RepoLink.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_report As String = "0"
            Try
                id_report = GVData.GetFocusedRowCellValue("id_report").ToString
            Catch ex As Exception
            End Try
            myCoalesce(id_report, "0")
            Dim rmt As String = "0"
            Try
                rmt = GVData.GetFocusedRowCellValue("report_mark_type").ToString
            Catch ex As Exception
            End Try
            myCoalesce(rmt, "0")
            Dim sm As New ClassShowPopUp()
            sm.id_report = id_report
            sm.report_mark_type = rmt
            sm.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GVData.Columns.Count - 1
                Dim ob As String = ""
                Try
                    ob = GVData.Columns(i).OwnerBand.ToString
                Catch ex As Exception
                End Try
                If ob = "gridBand2" Or ob = "gridBand13" Then
                    ob = ""
                End If
                GVData.Columns(i).Caption = ob + " " + GVData.Columns(i).Caption
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "doc_tracking.xlsx"
            exportToXLS(path, "document tracking", GCData)

            'restore column opt
            GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
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