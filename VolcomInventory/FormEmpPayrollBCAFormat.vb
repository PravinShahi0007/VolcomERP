Imports Microsoft.Office.Interop

Public Class FormEmpPayrollBCAFormat
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollBCAFormat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        Dim query As String = "CALL view_payroll_bca_format('" & id_payroll & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBCAFormat.DataSource = data
        GVBCAFormat.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print_raw(GCBCAFormat, "Export To BCA")
    End Sub

    Private Sub BExcel_Click(sender As Object, e As EventArgs) Handles BExcel.Click
        export_bof(True)
    End Sub
    Sub export_bof(ByVal show_msg As Boolean)
        'export excel
        Dim filepath As String = IO.Path.Combine(TBFileAddress.Text)

        Try
            ExportToExcel(GVBCAFormat, filepath, show_msg)
            '
            IO.File.Open(filepath, IO.FileMode.Open)
        Catch ex As Exception
            stopCustom("Please close your excel file first then try again later")
        End Try
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
            TBFileAddress.Text = fdlg.SelectedPath & "BCA Payroll.xls"
        End If
        fdlg.Dispose()
    End Sub
End Class