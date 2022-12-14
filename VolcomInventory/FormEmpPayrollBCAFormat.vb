Imports Microsoft.Office.Interop

Public Class FormEmpPayrollBCAFormat
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollBCAFormat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        Dim query As String = "CALL view_payroll_bca_format('" & id_payroll & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBCAFormat.DataSource = data
        GVBCAFormat.BestFitColumns()

        If FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
            CESamePeriod.Visible = False
        End If

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            BPrint.Enabled = False
            BExcel.Enabled = False
            BBrowse.Enabled = False
        Else
            BPrint.Enabled = True
            BExcel.Enabled = True
            BBrowse.Enabled = True
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print_raw(GCBCAFormat, "Export To BCA")
    End Sub

    Private Sub BExcel_Click(sender As Object, e As EventArgs) Handles BExcel.Click
        export_bof(True)
    End Sub
    Sub export_bof(ByVal show_msg As Boolean)
        Dim groups As DataTable = GCBCAFormat.DataSource.DefaultView.ToTable(True, "group_name")

        GVBCAFormat.ClearGrouping()

        GridColumn7.Visible = False

        For i = 0 To groups.Rows.Count - 1
            'export excel
            Dim filepath As String = IO.Path.Combine(TBFileAddress.Text)

            If filepath = "" Then
                stopCustom("Please close your excel file first then try again later")
            Else
                Dim options As DevExpress.XtraPrinting.CsvExportOptionsEx = New DevExpress.XtraPrinting.CsvExportOptionsEx

                options.ExportType = DevExpress.Export.ExportType.WYSIWYG

                GVBCAFormat.ActiveFilterString = "[group_name]='" + groups.Rows(i)("group_name").ToString + "'"

                filepath = filepath.Replace(".csv", " " + groups.Rows(i)("group_name").ToString + ".csv")

                GVBCAFormat.ExportToCsv(filepath, options)
            End If
        Next

        GVBCAFormat.ActiveFilterString = ""

        GridColumn7.SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        GridColumn7.GroupIndex = 0

        'Try
        '    ExportToExcel(GVBCAFormat, filepath, show_msg)
        '    '
        '    IO.File.Open(filepath, IO.FileMode.Open)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    stopCustom("Please close your excel file first then try again later")
        'End Try
    End Sub
    '
    Public Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If IO.File.Exists(strFileName) Then
            IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        ' If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        ' End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "employee_code").ToString
                ElseIf j = 1 Then 'name
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "employee_name").ToString
                ElseIf j = 2 Then 'departement
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "departement").ToString
                ElseIf j = 3 Then 'no_rek
                    wSheet.Cells(rowIndex + 1, colIndex) = "'" & dtTemp.GetRowCellValue(i, "employee_no_rek").ToString
                ElseIf j = 4 Then 'gaji
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "grand_total")
                Else 'incentive
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "incentive").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fdlg As FolderBrowserDialog = New FolderBrowserDialog()
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            Dim type As String = If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "DW ", "")
            Dim is_thr As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString

            TBFileAddress.Text = fdlg.SelectedPath & "\Salary " + type + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy") + ".csv"

            If is_thr = "1" Then
                TBFileAddress.Text = fdlg.SelectedPath & "\" + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString + " " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy") + ".csv"
            End If
        End If
        fdlg.Dispose()
    End Sub

    Private Sub CESamePeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CESamePeriod.EditValueChanged
        GCBCAFormat.DataSource = execute_query("CALL view_payroll_bca_format('" & id_payroll & "')", -1, True, "", "", "", "")

        If CESamePeriod.EditValue Then
            Dim query As String = "SELECT IFNULL((SELECT id_payroll FROM tb_emp_payroll WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND id_payroll_type = 4), 0) AS id_payroll"

            Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

            If is_thr = "1" Then
                query = "
                    SELECT py.id_payroll 
                    FROM tb_emp_payroll AS py 
                    LEFT JOIN tb_emp_payroll_type AS pytype ON py.id_payroll_type = pytype.id_payroll_type 
                    WHERE py.periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND pytype.is_thr = 1 AND pytype.is_dw = 1 AND pytype.id_religion = (SELECT id_religion FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + "))
                "
            End If

            Dim id_payroll_before As String = execute_query(query, 0, True, "", "", "", "")

            If Not id_payroll_before = "0" Then
                Dim query_before As String = "CALL view_payroll_bca_format('" & id_payroll_before & "')"
                Dim data_before As DataTable = execute_query(query_before, -1, True, "", "", "", "")

                Dim data As DataTable = GCBCAFormat.DataSource

                data.Merge(data_before)

                GCBCAFormat.DataSource = data
            End If
        End If

        GVBCAFormat.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollBCAFormat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class