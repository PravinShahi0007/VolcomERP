Imports System.Data.OleDb

Public Class FormFGCompareStockCard
    Public file_path As String = ""
    Public copy_file_path As String = ""

    Private Sub FormFGCompareStockCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_ws As String = "Sheet1"

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            file_path = ""
            file_path = fdlg.FileName
            If file_path <> "" Then
                copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(file_path)
                IO.File.Copy(file_path, copy_file_path, True)

                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
                oledbconn.ConnectionString = strConn
                Dim MyCommand As OleDbDataAdapter
                MyCommand = New OleDbDataAdapter("select * from [" & bof_xls_ws & "] WHERE NOT ([code]='')", oledbconn)

                'Try
                MyCommand.Fill(data_temp)
                MyCommand.Dispose()
                GCData.DataSource = data_temp
            End If
        End If
        fdlg.Dispose()
    End Sub
End Class