Public Class FormTargetSAS
    Dim last_date As DateTime
    Public month As List(Of String) = New List(Of String)


    Private Sub BtnImportFromXLS_Click(sender As Object, e As EventArgs) Handles BtnImportFromXLS.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "69"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`, LAST_DAY(DATE(NOW())) AS `last_date` ", -1, True, "", "", "", "")
        last_date = data_dt.Rows(0)("last_date")
        DEFrom.EditValue = last_date
        DEUntil.EditValue = last_date

        'add month
        month.Add("Jan")
        month.Add("Feb")
        month.Add("Mar")
        month.Add("Apr")
        month.Add("May")
        month.Add("Jun")
        month.Add("Jul")
        month.Add("Aug")
        month.Add("Sep")
        month.Add("Oct")
        month.Add("Nov")
        month.Add("Dec")
    End Sub

    Private Sub FormTargetSAS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormTargetSAS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTargetSAS_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim year_from As Integer = Integer.Parse(DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy"))
        Dim year_to As Integer = Integer.Parse(DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy"))
        Dim month_from As Integer = Integer.Parse(DateTime.Parse(DEFrom.EditValue.ToString).ToString("MM"))
        Dim month_to As Integer = Integer.Parse(DateTime.Parse(DEUntil.EditValue.ToString).ToString("MM"))
        Dim startd As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + " 00:00:00"
        Dim endd As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + " 00:00:00"

        FormMain.SplashScreenManager1.SetWaitFormDescription("Build query")
        Dim col_sth As String = ""
        Dim col_sas As String = ""
        For y = year_from To year_to
            If y > year_from Then
                col_sth += ","
                col_sas += ","
            End If

            Dim last_month As Integer = 0
            Dim j As Integer = 0
            If y = year_from Then
                j = month_from
            Else
                j = 1
            End If
            For m = j To 12
                last_month = m
                If m > j Then
                    col_sth += ","
                    col_sas += ","
                End If
                col_sth += "IFNULL(SUM(CASE WHEN a.period='" + y.ToString + "-" + m.ToString + "-01 00:00:00' AND a.typ=1 THEN a.val END),0.00) AS `SAL THRU|" + month(m - 1) + " " + y.ToString + "` "
                col_sas += "IFNULL(SUM(CASE WHEN a.period='" + y.ToString + "-" + m.ToString + "-01 00:00:00' AND a.typ=2 THEN a.val END),0.00) AS `SAS|" + month(m - 1) + " " + y.ToString + "` "


                If y = year_to And m = month_to Then
                    Exit For
                End If
            Next
        Next

        FormMain.SplashScreenManager1.SetWaitFormDescription("Processing data")
        Dim query As String = "SELECT a.id_class AS `PRODUCT INFO|id_class`, cls.display_name AS `PRODUCT INFO|CLASS`, a.id_delivery AS `PRODUCT INFO|id_delivery`, CONCAT(ss.season,' D',sd.delivery) AS `PRODUCT INFO|SEASON`,
        " + col_sth + ",
        " + col_sas + "
        FROM (
	        SELECT sth.id_class, sth.id_delivery, sth.sth_period AS `period`, sth.sth_value AS `val`, '1' AS `typ`
	        FROM tb_tg_sth sth
	        WHERE sth.is_active=1 AND (sth.sth_period>='2023-01-01 00:00:00' AND sth.sth_period<='2023-12-01 00:00:00')
	        UNION ALL 
	        SELECT sas.id_class, sas.id_delivery, sas.sas_period AS `period`, sas.sas_value AS `val`, '2' AS `typ`
	        FROM tb_tg_sas sas
	        WHERE sas.is_active=1 AND (sas.sas_period>='" + startd + "' AND sas.sas_period<='" + endd + "')
        ) a
        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = a.id_class
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = a.id_delivery
        INNER JOIN tb_season ss ON ss.id_season  = sd.id_season
        GROUP BY a.id_class, a.id_delivery 
        ORDER BY sd.delivery_date ASC, cls.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'clear column/band
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading column")
        GVData.Bands.Clear()
        GVData.Columns.Clear()
        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next
        'setup band
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVData.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    'If data.Columns(j).Caption = "Product Info|Division" Or data.Columns(j).Caption = "Product Info|Category" Or data.Columns(j).Caption = "Product Info|Class" Then
                    '    col.Group()
                    'End If

                    If bandName.Contains("SAL THRU") Or bandName.Contains("SAS") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n1}%"
                    End If

                    If bandName = "PRODUCT INFO" Then
                        band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End If
                End If
            Next
        Next
        GVData.Columns("PRODUCT INFO|id_class").Visible = False
        GVData.Columns("PRODUCT INFO|id_delivery").Visible = False
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading view")
        GCData.DataSource = data
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        resetView()
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        resetView()
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnExportXls.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim save As SaveFileDialog = New SaveFileDialog

            save.Filter = "Excel File | *.xlsx"
            save.ShowDialog()

            If Not save.FileName = "" Then
                Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

                op.ExportType = DevExpress.Export.ExportType.WYSIWYG

                GVData.ExportToXlsx(save.FileName, op)

                infoCustom("File saved.")
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class