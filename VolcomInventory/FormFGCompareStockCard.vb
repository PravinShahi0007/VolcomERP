Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FormFGCompareStockCard
    Public file_path As String = ""
    Public copy_file_path As String = ""

    Sub viewWHStockCard()
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label FROM tb_storage_fg a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "GROUP BY e.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEWH.Properties.DataSource = Nothing
        SLEWH.Properties.DataSource = data
        SLEWH.Properties.DisplayMember = "comp_name_label"
        SLEWH.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWH.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWH.EditValue = Nothing
        End If
    End Sub

    Private Sub FormFGCompareStockCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewWHStockCard()
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
                Dim adapter As New MySqlDataAdapter("CALL view_compare_sc('" + SLEWH.EditValue.ToString + "')", connection)
                adapter.SelectCommand.CommandTimeout = 300
                adapter.Fill(data)
                adapter.Dispose()
                data.Dispose()
                GCData.DataSource = data
                GVData.Columns("qty1").Caption = "1" + System.Environment.NewLine + "XXS"
                GVData.Columns("qtyerp1").Caption = "1" + System.Environment.NewLine + "XXS"
                GVData.Columns("qty2").Caption = "2" + System.Environment.NewLine + "XS"
                GVData.Columns("qtyerp2").Caption = "2" + System.Environment.NewLine + "XS"
                GVData.Columns("qty3").Caption = "3" + System.Environment.NewLine + "S"
                GVData.Columns("qtyerp3").Caption = "3" + System.Environment.NewLine + "S"
                GVData.Columns("qty4").Caption = "4" + System.Environment.NewLine + "M"
                GVData.Columns("qtyerp4").Caption = "4" + System.Environment.NewLine + "M"
                GVData.Columns("qty5").Caption = "5" + System.Environment.NewLine + "ML"
                GVData.Columns("qtyerp5").Caption = "5" + System.Environment.NewLine + "ML"
                GVData.Columns("qty6").Caption = "6" + System.Environment.NewLine + "L"
                GVData.Columns("qtyerp6").Caption = "6" + System.Environment.NewLine + "L"
                GVData.Columns("qty7").Caption = "7" + System.Environment.NewLine + "XL"
                GVData.Columns("qtyerp7").Caption = "7" + System.Environment.NewLine + "XL"
                GVData.Columns("qty8").Caption = "8" + System.Environment.NewLine + "XXL"
                GVData.Columns("qtyerp8").Caption = "8" + System.Environment.NewLine + "XXL"
                GVData.Columns("qty9").Caption = "9" + System.Environment.NewLine + "ALL"
                GVData.Columns("qtyerp9").Caption = "9" + System.Environment.NewLine + "ALL"
                GVData.Columns("qty10").Caption = "0" + System.Environment.NewLine + "SM"
                GVData.Columns("qtyerp10").Caption = "0" + System.Environment.NewLine + "SM"

                connection.Close()
                connection.Dispose()
            End If
            Cursor = Cursors.Default
        End If
        fdlg.Dispose()
    End Sub

    Private Sub FormFGCompareStockCard_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGCompareStockCard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        'Dim note As String = sender.GetRowCellvalue(e.RowHandle, sender.Columns("note").ToString)
        ''condition
        'If note = "Data Match" Then
        '    e.Appearance.BackColor = Color.White
        '    e.Appearance.BackColor2 = Color.White
        '    e.Appearance.ForeColor = Color.Black
        'Else
        '    e.Appearance.BackColor = Color.OrangeRed
        '    e.Appearance.BackColor2 = Color.OrangeRed
        '    e.Appearance.ForeColor = Color.White
        'End If
    End Sub
End Class