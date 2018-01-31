Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

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
        Dim bof_xls_ws As String = "card$"

        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            file_path = ""
            file_path = fdlg.FileName
            If file_path <> "" Then
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & file_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
                oledbconn.ConnectionString = strConn
                Dim MyCommand As OleDbDataAdapter
                MyCommand = New OleDbDataAdapter("select * from [" & bof_xls_ws & "]", oledbconn)

                'Try
                MyCommand.Fill(data_temp)
                MyCommand.Dispose()

                Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
                Dim connection As New MySqlConnection(connection_string)
                connection.Open()

                Dim command As MySqlCommand = connection.CreateCommand()
                Dim qry As String = "DROP TABLE IF EXISTS tb_sc_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_sc_temp AS ( SELECT * FROM ("
                For d As Integer = 0 To data_temp.Rows.Count - 1
                    If d > 0 Then
                        qry += "UNION ALL "
                    End If
                    qry += "SELECT '" + data_temp.Rows(d)(1).ToString + "' AS `code`, '" + data_temp.Rows(d)(2).ToString + "' AS `trstyp`, '" + data_temp.Rows(d)(3).ToString + "' AS `reff`, '" + data_temp.Rows(d)(4).ToString + "' AS `req`, '" + data_temp.Rows(d)(5).ToString + "' AS `source`, '" + DateTime.Parse(data_temp.Rows(d)(6).ToString).ToString("yyyy-MM-dd") + "' AS `date`, '" + data_temp.Rows(d)(7).ToString + "' AS `sizetyp`, ABS('" + data_temp.Rows(d)(8).ToString + "') AS `qty1`, ABS('" + data_temp.Rows(d)(9).ToString + "') AS `qty2`, ABS('" + data_temp.Rows(d)(10).ToString + "') AS `qty3`, ABS('" + data_temp.Rows(d)(11).ToString + "') AS `qty4`, ABS('" + data_temp.Rows(d)(12).ToString + "') AS `qty5`, ABS('" + data_temp.Rows(d)(13).ToString + "') AS `qty6`, ABS('" + data_temp.Rows(d)(14).ToString + "') AS `qty7`, ABS('" + data_temp.Rows(d)(15).ToString + "') AS `qty8`, ABS('" + data_temp.Rows(d)(16).ToString + "') AS `qty9`, ABS('" + data_temp.Rows(d)(17).ToString + "') AS `qty10`, '" + data_temp.Rows(d)(28).ToString + "' AS `invtyp` "
                Next
                qry += ") a ); ALTER TABLE tb_sc_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
                command.CommandText = qry
                command.ExecuteNonQuery()
                command.Dispose()
                Console.WriteLine(qry)

                Dim data As New DataTable
                Dim adapter As New MySqlDataAdapter("CALL view_compare_sc()", connection)
                adapter.SelectCommand.CommandTimeout = 300
                adapter.Fill(data)
                adapter.Dispose()
                data.Dispose()
                GCData.DataSource = data

                connection.Close()
                connection.Dispose()
            End If
            Cursor = Cursors.Default
        End If
        fdlg.Dispose()
    End Sub
End Class