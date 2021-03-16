﻿Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FormImportExcel
    Private dataset_field As DataSet
    Public id_pop_up As String = "-1"
    Public dt_add As DataTable
    '
    Public copy_file_path As String = ""
    Public is_save_as As Boolean = False
    ' List of id popup
    ' 1 = Sample Purchase
    ' 2 = Sample Planning
    Private Sub TBFileAddress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFileAddress.EditValueChanged
        If Not TBFileAddress.Text = "" Then
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub CBWorksheetName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBWorksheetName.EditValueChanged
        If Not CBWorksheetName.EditValue = "" Then
            Cursor = Cursors.WaitCursor
            fill_field_grid()
            Cursor = Cursors.Default
        End If
    End Sub
    Sub fill_combo_worksheet()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim ExcelTables As DataTable
        'Try
        copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(TBFileAddress.Text)
            IO.File.Copy(TBFileAddress.Text, copy_file_path, True)

            Dim extension As String = IO.Path.GetExtension(copy_file_path)
            If extension.ToLower = ".xlsx" Then
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
            ElseIf extension.ToLower = ".xls" Then
                strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;""", copy_file_path.ToLower)
                'strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
            Else
                stopCustom("Make sure your file in .xls or .xlsx format.")
                Exit Sub
            End If

            oledbconn.ConnectionString = strConn
            oledbconn.Open()
            ExcelTables = oledbconn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            oledbconn.Close()
            oledbconn.Dispose()
            Dim dr As DataRow
            Dim i As Integer = 0
            CBWorksheetName.Properties.Items.Clear()
            CBWorksheetName.EditValue = ""
            For Each dr In ExcelTables.Rows
                If dr.Item(3).ToString = "TABLE" Then
                    If InStr(dr.Item(2), "$") > 0 Then
                        i += 1
                        CBWorksheetName.Properties.Items.Add(dr.Item(2).ToString)
                        If i = 1 Then
                            CBWorksheetName.SelectedItem = dr.Item(2).ToString
                        End If
                    End If
                End If
            Next
            ExcelTables.Dispose()
            'Catch ex As Exception
        '   stopCustom("- Please make sure your file not open and available to read." & vbNewLine & ex.ToString)
        'End Try
    End Sub
    Sub fill_field_grid()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        GCData.DataSource = Nothing

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        If id_pop_up = "6" Or id_pop_up = "7" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] GROUP BY code", oledbconn)
        ElseIf id_pop_up = "8" Then
            MyCommand = New OleDbDataAdapter("select kode_barang, ket_barang, no_faktur, nama_toko, npwp, alamat, total, ppn, dpp, referensi from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([no_faktur]='')", oledbconn)
        ElseIf id_pop_up = "11" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code", oledbconn)
        ElseIf id_pop_up = "13" Or id_pop_up = "19" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='')", oledbconn)
        ElseIf id_pop_up = "14" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([reg_no]='')", oledbconn)
        ElseIf id_pop_up = "15" Or id_pop_up = "56" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code", oledbconn)
        ElseIf id_pop_up = "17" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='')", oledbconn)
        ElseIf id_pop_up = "20" Then
            MyCommand = New OleDbDataAdapter("select code, wh, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code,wh", oledbconn)
        ElseIf id_pop_up = "21" Then
            MyCommand = New OleDbDataAdapter("select code, wh, store, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code,wh,store", oledbconn)
        ElseIf id_pop_up = "23" Or id_pop_up = "24" Then
            MyCommand = New OleDbDataAdapter("select VENDOR, KODE, NAMA, SIZETYP, `xxs/1`, `xs/2`, `s/3`, `m/4`, `ml/5`, `l/6`, `xl/7`, `xxl/8`, `all/9`, `~/0` from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        ElseIf id_pop_up = "25" Or id_pop_up = "29" Then
            MyCommand = New OleDbDataAdapter("select KODE, NAMA, SIZETYP, `xxs/1`, `xs/2`, `s/3`, `m/4`, `ml/5`, `l/6`, `xl/7`, `xxl/8`, `all/9`, `~/0` from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([KODE]='')", oledbconn)
        ElseIf id_pop_up = "26" Then
            MyCommand = New OleDbDataAdapter("select no_faktur, nama_toko, npwp, alamat, id_keterangan_tambahan, kode_barang, ket_barang, jumlah_barang, harga_satuan, harga_total, diskon, ppn, dpp, jumlah_ppn, jumlah_dpp, referensi from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([no_faktur]='')", oledbconn)
        ElseIf id_pop_up = "33" Then
            MyCommand = New OleDbDataAdapter("select KODE from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([KODE]='') GROUP BY KODE ", oledbconn)
        ElseIf id_pop_up = "35" Then
            MyCommand = New OleDbDataAdapter("select [awb] AS awb_no,[rec date] AS rec_date,[rec by] AS rec_by,[inv no] as inv_no,[berat kargo] as a_weight from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([awb]='') ", oledbconn)
        ElseIf id_pop_up = "42" Then
            Dim is_import_all_order As String = get_setup_field("is_import_all_order")
            If is_import_all_order = "1" Then
                MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([Order Item Id]='') ", oledbconn)
            Else
                Dim qry As String = "SELECT DATE_FORMAT(MAX(s.status_date),'%Y-%m-%d') as `st_date` FROM tb_sales_order_det_status s"
                Dim data As DataTable = execute_query(qry, -1, True, "", "", "", "")
                MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([Order Item Id]='') AND (DateValue(LEFT([Updated at],10))>=DateValue('" & data.Rows(0)("st_date").ToString & "'))", oledbconn)
            End If
        ElseIf id_pop_up = "43" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([SEX]='')", oledbconn)
        ElseIf id_pop_up = "44" Then
            MyCommand = New OleDbDataAdapter("select [awb] AS awb_no,[inv no] as inv_no,[berat kargo] as a_weight from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([awb]='') ", oledbconn)
        ElseIf id_pop_up = "50" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([Order]='') ", oledbconn)
        ElseIf id_pop_up = "51" Then
            MyCommand = New OleDbDataAdapter("select `KODE`,MAX(REPLACE_STOCK) AS `replace_stock` from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([KODE]='') GROUP BY KODE ", oledbconn)
        ElseIf id_pop_up = "52" Then
            MyCommand = New OleDbDataAdapter("select city,`sub district`,`minimum weight`,`lead time`,`rate` from [" & CBWorksheetName.SelectedItem.ToString & "] GROUP BY `city`,`sub district` ", oledbconn)
        ElseIf id_pop_up = "53" Then
            Dim dtb As DataTable = execute_query("SELECT column_name,payment_type FROM tb_virtual_acc WHERE id_virtual_acc='" + FormBankDeposit.SLEBank.EditValue.ToString + "' ", -1, True, "", "", "", "")
            Dim col_name As String = dtb.Rows(0)("column_name").ToString
            Dim payment_type As String = dtb.Rows(0)("payment_type").ToString
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] WHERE not ([" + col_name + "]='') AND [Payment Type]='" + payment_type + "' AND [Transaction status]='settlement' ", oledbconn)
        ElseIf id_pop_up = "54" Then
            If FormOLStore.SLEOLStore.EditValue = "77" Then
                'shopee
                MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] WHERE not ([No# Pesanan]='')", oledbconn)
            End If
        Else
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        End If

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        If id_pop_up = "1" Then
            'sample purchase
            Dim id_sample, id_sample_price, name As String
            Dim total As Double

            id_sample = "0"
            id_sample_price = "0"
            name = ""

            total = 0

            dataset_field = New DataSet()
            dataset_field.Tables.Add("data_field")
            dataset_field.Tables("data_field").Columns.Add("id_sample_purc_det")
            dataset_field.Tables("data_field").Columns.Add("code")
            dataset_field.Tables("data_field").Columns.Add("name")
            dataset_field.Tables("data_field").Columns.Add("price")
            dataset_field.Tables("data_field").Columns.Add("qty")
            dataset_field.Tables("data_field").Columns.Add("discount")
            dataset_field.Tables("data_field").Columns.Add("total")
            dataset_field.Tables("data_field").Columns.Add("id_sample_price")
            '
            Try
                For i As Integer = 0 To data_temp.Rows.Count - 1
                    total = (Double.Parse(data_temp.Rows(i).Item("price").ToString) * Double.Parse(data_temp.Rows(i).Item("qty").ToString)) - Double.Parse(data_temp.Rows(i).Item("discount").ToString)
                    Try
                        id_sample = get_id_sample_fcode(data_temp.Rows(i).Item("code").ToString)
                        id_sample_price = get_sample_x(id_sample, "1")
                        name = get_sample_x(id_sample, "2")
                    Catch ex As Exception
                        id_sample_price = "0"
                        name = "Sample not found"
                    End Try
                    '
                    dataset_field.Tables("data_field").Rows.Add("0", data_temp.Rows(i).Item("code").ToString, name, data_temp.Rows(i).Item("price").ToString, data_temp.Rows(i).Item("qty").ToString, data_temp.Rows(i).Item("discount").ToString, total.ToString, id_sample_price)
                    '
                    GCData.DataSource = dataset_field.Tables("data_field")
                    GVData.Columns("id_sample_purc_det").Visible = False
                    GVData.Columns("id_sample_price").Visible = False
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "2" Then
            'sample planning
            Dim id_sample, name, sizex As String

            id_sample = "0"
            name = ""

            dataset_field = New DataSet()
            dataset_field.Tables.Add("data_field")
            dataset_field.Tables("data_field").Columns.Add("id_sample")
            dataset_field.Tables("data_field").Columns.Add("code")
            dataset_field.Tables("data_field").Columns.Add("name")
            dataset_field.Tables("data_field").Columns.Add("size")
            dataset_field.Tables("data_field").Columns.Add("qty")
            dataset_field.Tables("data_field").Columns.Add("note")
            '
            Try
                For i As Integer = 0 To data_temp.Rows.Count - 1
                    Try
                        id_sample = get_id_sample_fcode(data_temp.Rows(i).Item("code").ToString)
                        name = get_sample_x(id_sample, "2")
                        sizex = get_sample_x(id_sample, "3")
                    Catch ex As Exception
                        id_sample = "0"
                        name = "Sample not found"
                        sizex = "-"
                    End Try
                    '
                    dataset_field.Tables("data_field").Rows.Add(id_sample, data_temp.Rows(i).Item("code").ToString, name, sizex, data_temp.Rows(i).Item("qty").ToString, data_temp.Rows(i).Item("note").ToString)
                    '
                    GCData.DataSource = dataset_field.Tables("data_field")
                    GVData.Columns("id_sample").Visible = False
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "3" Then
            ''SOH Volcom
            'Dim id_sample, name As String

            'id_sample = "0"
            'name = ""

            'dataset_field = New DataSet()
            'dataset_field.Tables.Add("data_field")
            'dataset_field.Tables("data_field").Columns.Add("prod_code")
            'dataset_field.Tables("data_field").Columns.Add("style_code")
            'dataset_field.Tables("data_field").Columns.Add("prod_class")
            'dataset_field.Tables("data_field").Columns.Add("prod_desc")
            'dataset_field.Tables("data_field").Columns.Add("prod_aging")
            'dataset_field.Tables("data_field").Columns.Add("prod_source")
            'dataset_field.Tables("data_field").Columns.Add("prod_size")
            'dataset_field.Tables("data_field").Columns.Add("qty")
            'dataset_field.Tables("data_field").Columns.Add("prod_price")
            'dataset_field.Tables("data_field").Columns.Add("prod_sale")
            'dataset_field.Tables("data_field").Columns.Add("prod_cost")
            'dataset_field.Tables("data_field").Columns.Add("prod_margin")
            'dataset_field.Tables("data_field").Columns.Add("prod_date")
            'dataset_field.Tables("data_field").Columns.Add("prod_range")
            'dataset_field.Tables("data_field").Columns.Add("prod_reff")
            'dataset_field.Tables("data_field").Columns.Add("prod_status")

            ''
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "4" Then
            ''SOH Store
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "5" Then
            ''SOH Store
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "6" Then
            'SALES INVOICE
            Try
                Dim dt As DataTable = FormSalesPOSDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price_retail")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Price").VisibleIndex = 5
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("design_price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "7" Then
            'SALES INVOICE
            Try
                Dim dt As DataTable = FormFGMissingDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("design_price").VisibleIndex = 5
                GVData.Columns("design_price").Caption = "Price"
                GVData.Columns("design_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("design_price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("Price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "8" Then
            'FAKTUR KELUARAN
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "9" Then
            ''DISTRIBUTION SCHEME
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "10" Then
            ''SO NEW
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "11" Then
            'RETURN ORDER
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_ro_single_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ro_single_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                If qry_det <> "" Then
                    qry_det += "UNION ALL "
                End If
                qry_det += "SELECT '" + FormSalesReturnOrderDet.id_comp + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("code").ToString + "' AS `code`, '" + data_temp.Rows(d)("qty").ToString + "' AS `qty` "
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_ro_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_return_order_single_temp(" + FormSalesReturnOrderDet.id_comp + ", '" + id_user + "')", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            Dim data_par As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            connection.Close()
            connection.Dispose()

            'Customize column
            GVData.Columns("id_design_price_retail").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("SOH").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Qty").VisibleIndex = 3
            GVData.Columns("Amount").VisibleIndex = 4
            GVData.Columns("Price").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("SOH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("SOH").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
            GVData.Columns("Amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Amount").DisplayFormat.FormatString = "{0:n2}"
            ' old
            'Try
            '    Dim dt As DataTable = execute_query("CALL view_stock_fg('" + FormSalesReturnOrderDet.id_comp + "', '" + FormSalesReturnOrderDet.id_wh_locator + "', '" + FormSalesReturnOrderDet.id_wh_rack + "', '" + FormSalesReturnOrderDet.id_wh_drawer + "', '0', '4', '9999-01-01') ", -1, True, "", "", "", "")
            '    Dim tb1 = data_temp.AsEnumerable()
            '    Dim tb2 = dt.AsEnumerable()
            '    Dim query = From table1 In tb1
            '                Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("code").ToString
            '                Into Group
            '                From y1 In Group.DefaultIfEmpty()
            '                Select New With
            '                {
            '                    .Code = table1.Field(Of String)("code"),
            '                    .Style = If(y1 Is Nothing, "", y1("name")),
            '                    .Size = If(y1 Is Nothing, "", y1("size")),
            '                    .Amount = If(y1 Is Nothing, 0, If(table1("qty").ToString = "", If(y1 Is Nothing, 0, y1("qty_all_product")), CType(table1("qty"), Decimal)) * y1("design_price_retail")),
            '                    .SOH = If(y1 Is Nothing, 0, y1("qty_all_product")),
            '                    .Qty = If(table1("qty").ToString = "", If(y1 Is Nothing, 0, y1("qty_all_product")), CType(table1("qty"), Decimal)),
            '                    .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
            '                    .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
            '                    .id_design = If(y1 Is Nothing, 0, y1("id_design")),
            '                    .id_product = If(y1 Is Nothing, 0, y1("id_product")),
            '                    .Color = If(y1 Is Nothing, "", y1("color")),
            '                    .Status = If(y1 Is Nothing, "Not found", "OK")
            '                }
            '    '.Note = table1.Field(Of String)("note"),
            '    GCData.DataSource = Nothing
            '    GCData.DataSource = query.ToList()
            '    GCData.RefreshDataSource()
            '    GVData.PopulateColumns()

            '    'Customize column
            '    GVData.Columns("id_design_price_retail").Visible = False
            '    GVData.Columns("id_design").Visible = False
            '    GVData.Columns("id_product").Visible = False
            '    GVData.Columns("Color").Visible = False
            '    GVData.Columns("Amount").Visible = False
            '    GVData.Columns("Price").Visible = False
            '    GVData.Columns("SOH").Visible = False
            '    GVData.Columns("Code").VisibleIndex = 0
            '    GVData.Columns("Style").VisibleIndex = 1
            '    GVData.Columns("Size").VisibleIndex = 2
            '    GVData.Columns("Qty").VisibleIndex = 3
            '    ' GVData.Columns("Note").VisibleIndex = 4
            '    GVData.Columns("Status").VisibleIndex = 5
            '    GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
            '    GVData.Columns("SOH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    GVData.Columns("SOH").DisplayFormat.FormatString = "{0:n0}"

            '    'check duplicate
            '    Dim dt_check As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            '    For i As Integer = 0 To GVData.RowCount - 1
            '        Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVData.GetRowCellValue(i, "id_product").ToString + "' ")
            '        If dt_filter.Length > 0 Then
            '            GVData.SetRowCellValue(i, "Status", "Already in order list")
            '        End If
            '    Next
            'Catch ex As Exception
            '    stopCustom("Incorrect format on table.")
            'End Try
        ElseIf id_pop_up = "12" Then
            Try
                Dim query_size As String = "SELECT id_code_detail,display_name FROM tb_m_code_detail WHERE id_code='13'"
                Dim data_size As DataTable = execute_query(query_size, -1, True, "", "", "", "")

                Dim query_color As String = "SELECT id_code_detail,display_name,id_code FROM tb_m_code_detail WHERE id_code='1'"
                Dim data_color As DataTable = execute_query(query_color, -1, True, "", "", "", "")

                Dim query_vendor As String = "SELECT c.id_comp as id_comp,cc.id_comp_contact,comp_number,c.comp_name FROM tb_m_comp c LEFT JOIN tb_m_comp_contact cc ON cc.id_comp=c.id_comp AND cc.is_default = '1' WHERE c.id_comp_cat='1'"
                Dim data_vendor As DataTable = execute_query(query_vendor, -1, True, "", "", "", "")

                Dim query_mat_det As String = "SELECT id_mat_det,mat_det_code FROM tb_m_mat_det"
                Dim data_mat_det As DataTable = execute_query(query_mat_det, -1, True, "", "", "", "")

                Dim query_year As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='12'"
                Dim data_year As DataTable = execute_query(query_year, -1, True, "", "", "", "")

                Dim query_counting As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='10'"
                Dim data_counting As DataTable = execute_query(query_counting, -1, True, "", "", "", "")

                Dim query_lot As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='11'"
                Dim data_lot As DataTable = execute_query(query_lot, -1, True, "", "", "", "")

                Dim query_mat As String = "SELECT id_mat,mat_code,id_mat_cat,mat_name FROM tb_m_mat WHERE is_old!='1'"
                Dim data_mat As DataTable = execute_query(query_mat, -1, True, "", "", "", "")

                Dim query_range As String = "SELECT id_range,`range` FROM tb_range"
                Dim data_range As DataTable = execute_query(query_range, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_size.AsEnumerable()
                Dim tb3 = data_color.AsEnumerable()
                Dim tb4 = data_vendor.AsEnumerable()
                Dim tb5 = data_mat_det.AsEnumerable()
                Dim tb6 = data_year.AsEnumerable()
                Dim tb7 = data_counting.AsEnumerable()
                Dim tb8 = data_lot.AsEnumerable()
                Dim tb9 = data_mat.AsEnumerable()
                Dim tb10 = data_range.AsEnumerable()
                Dim tb11 = data_curr.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join size In tb2
                            On xls("size") Equals size("display_name") Into sizejoin = Group
                            From resultsize In sizejoin.DefaultIfEmpty()
                            Group Join color In tb3 'left join xls dgn color menjadi colorjoin 'On xls("color").ToString.ToLower Equals color("display_name").ToString.ToLower And New {ID = trans.id, Flow = (Byte)1} Into colorjoin = Group
                            On xls("color").ToString.ToLower Equals color("display_name").ToString.ToLower Into colorjoin = Group
                            From resultcolor In colorjoin.DefaultIfEmpty()
                            Group Join vendor In tb4 'left join xls dgn vendor menjadi vendorjoin
                            On xls("vendor").ToString.ToLower Equals vendor("comp_number").ToString.ToLower Into vendorjoin = Group
                            From resultvendor In vendorjoin.DefaultIfEmpty()
                            Group Join mat_det In tb5 'left join xls dgn matdet menjadi matdetjoin
                            On xls("code").ToString.ToLower Equals mat_det("mat_det_code").ToString.ToLower Into matdetjoin = Group
                            From resultMatDet In matdetjoin.DefaultIfEmpty()
                            Group Join year In tb6 'left join xls dgn year menjadi yearjoin
                            On xls("code").ToString.ToLower.Substring(2, 2) Equals year("code").ToString.ToLower Into yearjoin = Group
                            From resultyear In yearjoin.DefaultIfEmpty()
                            Group Join count In tb7 'left join xls dgn count menjadi countjoin
                            On xls("code").ToString.ToLower.Substring(7, 2) Equals count("code").ToString.ToLower Into countjoin = Group
                            From resultcount In countjoin.DefaultIfEmpty()
                            Group Join lot In tb8 'left join xls dgn lot menjadi lotjoin
                            On xls("code").ToString.ToLower.Substring(11, 1) Equals lot("code").ToString.ToLower Into lotjoin = Group
                            From resultlot In lotjoin.DefaultIfEmpty()
                            Group Join mat In tb9 'left join xls dgn mat menjadi matjoin
                            On xls("code").ToString.ToLower.Substring(0, 2) Equals mat("mat_code").ToString.ToLower And xls("cat").ToString Equals mat("id_mat_cat").ToString Into matjoin = Group
                            From resultmat In matjoin.DefaultIfEmpty()
                            Group Join range In tb10 'left join xls dgn range menjadi rangejoin
                            On xls("range").ToString Equals range("range").ToString Into rangejoin = Group
                            From resultrange In rangejoin.DefaultIfEmpty()
                            Group Join curr In tb11 'left join xls dgn range menjadi currjoin
                            On xls("currency").ToString.ToLower Equals curr("currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                        {
                            .Code = xls("code").ToString,
                            .id_mat_det = If(resultMatDet Is Nothing, "", resultMatDet("id_mat_det")),
                            .id_mat = If(resultmat Is Nothing, "", resultmat("id_mat")),
                            .Type = If(resultmat Is Nothing, "", resultmat("mat_name")),
                            .Description = xls("desc").ToString,
                            .Size = xls("size").ToString,
                            .id_code_detail_size = If(resultsize Is Nothing, "", resultsize("id_code_detail")),
                            .Color = xls("color").ToString,
                            .id_code_detail_color = If(resultcolor Is Nothing, "", resultcolor("id_code_detail")),
                            .id_range = If(resultrange Is Nothing, "", resultrange("id_range")),
                            .Range = xls("range").ToString,
                            .Vendor = xls("vendor").ToString,
                            .id_comp_contact = If(resultvendor Is Nothing, "", resultvendor("id_comp_contact")),
                            .id_code_detail_year = If(resultyear Is Nothing, "", resultyear("id_code_detail")),
                            .id_code_detail_count = If(resultcount Is Nothing, "", resultcount("id_code_detail")),
                            .id_code_detail_lot = If(resultlot Is Nothing, "", resultlot("id_code_detail")),
                            .Currency = xls("currency").ToString,
                            .id_currency = If(resultcurr Is Nothing, "", resultcurr("id_currency")),
                            .Price = If(xls("price").ToString = "", 0, xls("price")),
                            .err_format = If(resultMatDet Is Nothing, "", "This code already on database; ") + If(resultmat Is Nothing, "Material Type not found; ", "") + If(resultrange Is Nothing, "Range not found; ", "") + If(resultsize Is Nothing, "Size not found; ", "") + If(resultcolor Is Nothing, "Color not found; ", "") + If(resultyear Is Nothing, "Year code not found; ", "") + If(resultcount Is Nothing, "Count code not found; ", "") + If(resultlot Is Nothing, "Lot code not found; ", "") + If(resultvendor Is Nothing, "Vendor code not found; ", "") + If(resultcurr Is Nothing, "Currency not found; ", "")
                        }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                    If filteredList.Count > 1 Then
                        GVData.SetRowCellValue(j, "err_format", "Duplicate in import list; " + GVData.GetRowCellValue(j, "err_format").ToString)
                    End If
                Next

                'Customize column
                GVData.Columns("Type").VisibleIndex = 0
                GVData.Columns("Code").VisibleIndex = 1
                GVData.Columns("Description").VisibleIndex = 2
                GVData.Columns("Size").VisibleIndex = 3
                GVData.Columns("Color").VisibleIndex = 4
                GVData.Columns("Vendor").VisibleIndex = 5
                GVData.Columns("Range").VisibleIndex = 6
                '
                GVData.Columns("err_format").Caption = "Error Format"
                '
                GVData.Columns("id_code_detail_size").Visible = False
                GVData.Columns("id_code_detail_color").Visible = False
                GVData.Columns("id_code_detail_year").Visible = False
                GVData.Columns("id_code_detail_count").Visible = False
                GVData.Columns("id_code_detail_lot").Visible = False
                GVData.Columns("id_comp_contact").Visible = False
                GVData.Columns("id_mat").Visible = False
                GVData.Columns("id_mat_det").Visible = False
                GVData.Columns("id_range").Visible = False
                GVData.Columns("id_currency").Visible = False

                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "13" Then
            ''MASTER PRICE
            Try
                Dim dt As DataTable = execute_query("call view_all_design_param('AND f1.id_active=1 ')", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("design_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Style = If(y1 Is Nothing, "", y1("design_display_name")),
                                .Class = If(y1 Is Nothing, "", y1("product_class_display")),
                                .PriceName = table1.Field(Of String)("price_name").ToString,
                                .Price = table1("price"),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_currency = "1",
                                .is_print = If(table1("is_print").ToString > "0", "1", "0"),
                                .PrintOnTag = If(table1("is_print").ToString > "0", "Yes", "No"),
                                .Status = If(y1 Is Nothing, "Not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("is_print").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("PriceName").VisibleIndex = 3
                GVData.Columns("Price").VisibleIndex = 4
                GVData.Columns("PrintOnTag").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"

                'check duplicate in - sementara gk dipake karena tiap import delete all dan tdk ada editing di item list
                'Dim dt_check As DataTable = FormMasterPriceSingle.GCItemList.DataSource
                'For i As Integer = 0 To GVData.RowCount - 1
                '    Dim dt_filter As DataRow() = dt_check.Select("[id_design]='" + GVData.GetRowCellValue(i, "id_design").ToString + "' ")
                '    If dt_filter.Length > 0 Then
                '        GVData.SetRowCellValue(i, "Status", "Already in item list")
                '    End If
                'Next

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "14" Then
            Try
                Dim query_do As String = "SELECT * FROM tb_wh_awb_do"
                Dim data_do As DataTable = execute_query(query_do, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_do.AsEnumerable()
                Dim query = From xls In tb1
                            Group Join dox In tb2
                                On xls("reg_no") Equals dox("do_no") Into dojoin = Group
                            From doresult In dojoin.DefaultIfEmpty()
                            Select New With {
                                    .DO = xls("reg_no").ToString,
                                    .ERP = xls("reg_erpno").ToString,
                                    .Date = xls("reg_dt").ToString,
                                    .StoreNumber = xls("reg_cuscd").ToString,
                                    .StoreName = xls("reg_name").ToString,
                                    .Reff = xls("reg_reff").ToString,
                                    .Qty = xls("reg_qty").ToString,
                                    .Status = If(doresult Is Nothing, "OK", "This code already on database")
                                }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "15" Then
            'RETURN ORDER
            Try
                Dim dt As DataTable = execute_query("CALL view_sales_order_prod_list_less('0', '" + FormSalesOrderDet.id_comp_par + "')", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Style = If(y1 Is Nothing, "", y1("design_display_name")),
                                .Size = If(y1 Is Nothing, "", y1("Size")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .Available = If(y1 Is Nothing, 0, y1("total_allow")),
                                .Qty = If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .id_design_cat = If(y1 Is Nothing, 0, y1("id_design_cat")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_design_type = If(y1 Is Nothing, 0, y1("id_design_type")),
                                .design_price_type = If(y1 Is Nothing, 0, y1("design_price_type")),
                                .Status = If(y1 Is Nothing, "Not found", If(If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)) > If(y1 Is Nothing, 0, y1("total_allow")), "Input qty exceed available qty", "OK")),
                                .DesignType = If(y1 Is Nothing, "", y1("design_type"))
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("id_design_cat").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_design_type").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Price").VisibleIndex = 3
                GVData.Columns("Available").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("DesignType").VisibleIndex = 7
                GVData.Columns("Available").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Available").DisplayFormat.FormatString = "{0:n0}"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"

                'check duplicate
                Dim dt_check As DataTable = FormSalesOrderDet.GCItemList.DataSource
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVData.GetRowCellValue(i, "id_product").ToString + "' ")
                    If dt_filter.Length > 0 Then
                        GVData.SetRowCellValue(i, "Status", "Already in order list")
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "16" Then
            'import bom ecop
            Try
                Dim id_ovh_estimate As String = get_setup_field("id_ovh_estimate")

                Dim query_master As String = "CALL view_all_design_param('AND f1.id_active=1 ')"
                Dim data_master As DataTable = execute_query(query_master, -1, True, "", "", "", "")

                Dim query_vendor_ovh As String = "SELECT ovhp.id_ovh_price,c.id_comp AS id_comp,cc.id_comp_contact,comp_number,c.comp_name,cur.currency FROM tb_m_ovh_price ovhp INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact INNER JOIN  tb_m_comp c ON cc.id_comp=c.id_comp INNER JOIN tb_lookup_currency cur ON cur.id_currency=ovhp.id_currency WHERE ovhp.id_ovh='" + id_ovh_estimate + "'"
                Dim data_vendor_ovh As DataTable = execute_query(query_vendor_ovh, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_master.AsEnumerable()
                Dim tb3 = data_vendor_ovh.AsEnumerable()
                Dim tb4 = data_curr.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join master In tb2
                            On xls("code") Equals master("design_code") Into masterjoin = Group
                            From resultmaster In masterjoin.DefaultIfEmpty()
                            Group Join vendor In tb3 'left join xls dgn vendor menjadi vendorjoin
                            On xls("vendor").ToString.ToLower Equals vendor("comp_number").ToString.ToLower And xls("currency").ToString.ToLower Equals vendor("currency").ToString.ToLower Into vendorjoin = Group
                            From resultvendor In vendorjoin.DefaultIfEmpty()
                            Group Join curr In tb4 'left join xls dgn range menjadi currjoin
                            On xls("currency").ToString.ToLower Equals curr("currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_design = If(resultmaster Is Nothing, "", resultmaster("id_design")),
                                .Description = If(resultmaster Is Nothing, "", resultmaster("design_name")),
                                .Size = If(resultmaster Is Nothing, "", resultmaster("size_chart")),
                                .Color = If(resultmaster Is Nothing, "", resultmaster("color")),
                                .id_ovh_price = If(resultvendor Is Nothing, "", resultvendor("id_ovh_price")),
                                .VendorCode = xls("vendor").ToString,
                                .Vendor = If(resultvendor Is Nothing, "", resultvendor("comp_name")),
                                .Currency = xls("currency").ToString,
                                .id_currency = If(resultcurr Is Nothing, "", resultcurr("id_currency")),
                                .Kurs = If(xls("kurs").ToString = "", 0, xls("kurs")),
                                .ECOP = If(xls("ecop").ToString = "", 0, xls("ecop")),
                                .err_format = If(resultmaster Is Nothing Or resultvendor Is Nothing Or resultcurr Is Nothing, If(resultmaster Is Nothing, "This design code is not registered; ", "") + If(resultvendor Is Nothing, "Please check if vendor registered in master overhead estimate; ", "") + If(resultcurr Is Nothing, "Currency not registered; ", ""), "OK")
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()


                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Color").VisibleIndex = 3
                GVData.Columns("VendorCode").VisibleIndex = 4
                GVData.Columns("Vendor").VisibleIndex = 5
                GVData.Columns("Currency").VisibleIndex = 6
                GVData.Columns("ECOP").VisibleIndex = 7
                GVData.Columns("Kurs").VisibleIndex = 8
                GVData.Columns("err_format").VisibleIndex = 9
                '
                GVData.Columns("err_format").Caption = "Error Format"
                '
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_ovh_price").Visible = False
                GVData.Columns("id_currency").Visible = False
                '
                GVData.Columns("Kurs").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Kurs").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("ECOP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("ECOP").DisplayFormat.FormatString = "{0:n2}"
                '
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "17" Then
            'import est price
            Try
                'master design
                Dim query_master As String = "SELECT dsg.design_display_name AS `name`, det.color, dsg.id_design,pd_dsg.id_prod_demand_design AS `id`, dsg.design_code as `code`, pd_dsg.prod_demand_design_propose_price AS `est_price`, "
                query_master += "pd_dsg.rate_current, pd_dsg.msrp, dsg.design_eos "
                query_master += "FROM tb_m_design dsg "
                query_master += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = "
                If FormFGLineList.SLETypeLineList.EditValue.ToString = "1" Then
                    query_master += "id_prod_demand_design_line "
                ElseIf FormFGLineList.SLETypeLineList.EditValue.ToString = "2" Then
                    query_master += "id_prod_demand_design_line_upd "
                ElseIf FormFGLineList.SLETypeLineList.EditValue.ToString = "3" Then
                    query_master += "id_prod_demand_design_line_final "
                End If
                query_master += "Left Join( "
                query_master += "Select b.code_detail_name As color, a.id_design FROM tb_m_design_code a "
                query_master += "INNER Join tb_m_code_detail b ON a.id_code_detail = b.id_code_detail And b.id_code = '14' "
                query_master += "GROUP BY a.id_design "
                query_master += ") det ON det.id_design = dsg.id_design "
                query_master += "WHERE dsg.id_season = '" + FormFGLineList.SLESeason.EditValue.ToString + "' AND dsg.id_active=1 "
                query_master += "ORDER BY dsg.id_design ASC "
                Dim data_master As DataTable = execute_query(query_master, -1, True, "", "", "", "")

                'master delivery
                Dim query_del = "SELECT del.id_delivery, del.delivery 
                FROM tb_season_delivery del
                WHERE del.id_season=" + FormFGLineList.SLESeason.EditValue.ToString + " "
                Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")

                'master return
                Dim query_ret = "SELECT rc.id_ret_code, rc.ret_code, rc.ret_date FROM tb_lookup_ret_code rc "
                Dim data_ret As DataTable = execute_query(query_ret, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_master.AsEnumerable()
                Dim tb3 = data_del
                Dim tb4 = data_ret
                Dim query = From xls In tb1
                            Group Join dox In tb2
                            On xls("code").ToString Equals dox("code").ToString Into dojoin = Group
                            From doresult In dojoin.DefaultIfEmpty()
                            Group Join del In tb3
                            On xls("delivery").ToString Equals del("delivery").ToString Into deljoin = Group
                            From delresult In deljoin.DefaultIfEmpty()
                            Group Join ret In tb4
                            On xls("ret_code").ToString Equals ret("ret_code").ToString Into retjoin = Group
                            From retresult In retjoin.DefaultIfEmpty()
                            Select New With {
                                        .id = If(doresult Is Nothing, "", doresult("id")),
                                        .id_design = If(doresult Is Nothing, "0", doresult("id_design")),
                                        .code = If(doresult Is Nothing, "", doresult("code")),
                                        .name = If(doresult Is Nothing, "", doresult("name")),
                                        .color = If(doresult Is Nothing, "", doresult("color")),
                                        .rate_current = If(doresult Is Nothing, 0, xls("rate_current")),
                                        .msrp = If(doresult Is Nothing, 0, xls("msrp")),
                                        .msrp_rp = If(doresult Is Nothing, 0, xls("msrp") * xls("rate_current")),
                                        .est_price = If(doresult Is Nothing, 0, xls("est_price")),
                                        .id_delivery = If(delresult Is Nothing, "0", delresult("id_delivery").ToString),
                                        .delivery = xls("delivery").ToString,
                                        .id_ret_code = If(retresult Is Nothing, "0", retresult("id_ret_code").ToString),
                                        .ret_code = xls("ret_code").ToString,
                                        .ret_date = If(retresult Is Nothing, Nothing, retresult("ret_date")),
                                        .design_eos = xls("design_eos"),
                                        .Status = If(doresult Is Nothing Or delresult Is Nothing Or retresult Is Nothing, If(doresult Is Nothing, "Product not found; ", "") + If(delresult Is Nothing, "Delivery not found; ", "") + If(retresult Is Nothing, "Return code not found", ""), "OK")
                                    }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'hide column
                GVData.Columns("id").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_delivery").Visible = False
                GVData.Columns("id_ret_code").Visible = False


                GVData.Columns("code").VisibleIndex = 0
                GVData.Columns("name").VisibleIndex = 1
                GVData.Columns("color").VisibleIndex = 2
                GVData.Columns("rate_current").VisibleIndex = 3
                GVData.Columns("msrp").VisibleIndex = 4
                GVData.Columns("msrp_rp").VisibleIndex = 5
                GVData.Columns("est_price").VisibleIndex = 6
                GVData.Columns("delivery").VisibleIndex = 7
                GVData.Columns("ret_code").VisibleIndex = 8
                GVData.Columns("ret_date").VisibleIndex = 9
                GVData.Columns("design_eos").VisibleIndex = 10
                GVData.Columns("Status").VisibleIndex = 11
                GVData.BestFitColumns()

                GVData.Columns("rate_current").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("rate_current").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("msrp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("msrp").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("msrp_rp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("msrp_rp").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("est_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("est_price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("design_eos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("design_eos").DisplayFormat.FormatString = "{0:dd MMMM yyyy}"
                GVData.Columns("ret_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("ret_date").DisplayFormat.FormatString = "{0:dd MMMM yyyy}"
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "18" Then
            'SALES PROMO
            Try
                Dim dt As DataTable = FormSalesPromoDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price_retail")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Price").VisibleIndex = 5
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("design_price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "19" Then
            ''MASTER SAMPLE PRICE
            Try
                Dim dt As DataTable = execute_query("call view_sample_master()", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("sample_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Style = If(y1 Is Nothing, "", y1("sample_display_name")),
                                .Class = If(y1 Is Nothing, "", y1("class")),
                                .PriceName = table1.Field(Of String)("price_name").ToString,
                                .Price = table1("price"),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_currency = "1",
                                .is_print = If(table1("is_print").ToString > "0", "1", "0"),
                                .PrintOnTag = If(table1("is_print").ToString > "0", "Yes", "No"),
                                .Status = If(y1 Is Nothing, "Not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("is_print").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("PriceName").VisibleIndex = 3
                GVData.Columns("Price").VisibleIndex = 4
                GVData.Columns("PrintOnTag").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "20" Then
            Try
                Dim query_product As String = "CALL view_product_per_season(0)"
                Dim data_product As DataTable = execute_query(query_product, -1, True, "", "", "", "")

                Dim query_comp As String = "SELECT id_comp, comp_number, comp_name,id_drawer_def FROM tb_m_comp WHERE id_comp_cat='" + get_setup_field("id_comp_cat_wh") + "' "
                Dim data_comp As DataTable = execute_query(query_comp, -1, True, "", "", "", "")

                ' Dim query_exist As String = "CALL view_fg_wh_alloc('" + FormFGWHAllocDet.id_fg_wh_alloc + "') "
                ' Dim data_exist As DataTable = execute_query(query_exist, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'xls
                Dim tb2 = data_product.AsEnumerable()
                Dim tb3 = data_comp.AsEnumerable()
                ' Dim tb4 = data_exist.AsEnumerable()
                'Group Join exist In tb4
                '            On xls("code") Equals exist("code").ToString().ToUpper() And xls("wh") Equals exist("comp_number").ToString().ToUpper() Into existjoin = Group
                '            From resultexist In existjoin.DefaultIfEmpty()

                Dim query = From xls In tb1 'left join xls dgn prod menjadi prodjoin
                            Group Join prod In tb2
                            On xls("code") Equals prod("product_full_code") Into prodjoin = Group
                            From resultprod In prodjoin.DefaultIfEmpty()
                            Group Join comp In tb3 'left join xls dgn comp menjadi compjoin
                            On xls("wh").ToString.ToUpper Equals comp("comp_number").ToString.ToUpper Into compjoin = Group
                            From resultcomp In compjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_product = If(resultprod Is Nothing, "", resultprod("id_product").ToString),
                                .Style = If(resultprod Is Nothing, "", resultprod("design_display_name").ToString),
                                .Size = If(resultprod Is Nothing, "", resultprod("Size").ToString),
                                .To = If(resultcomp Is Nothing, "", resultcomp("comp_number").ToString + " - " + resultcomp("comp_name").ToString),
                                .id_comp_to = If(resultcomp Is Nothing, "", resultcomp("id_comp").ToString),
                                .id_wh_drawer_to = If(resultcomp Is Nothing, "", resultcomp("id_drawer_def").ToString),
                                .Qty = xls("qty"),
                                .Status = If(resultprod Is Nothing Or resultcomp Is Nothing, If(resultprod Is Nothing, "This product code is not registered; ", "") + If(resultcomp Is Nothing, "Account is not registered; ", If(resultcomp("id_drawer_def").ToString = "", "Drawer not found; ", "")), "OK")
                            }

                '+ If(Not resultexist Is Nothing, "This item is already exist; ", "")
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_comp_to").Visible = False
                GVData.Columns("id_wh_drawer_to").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("To").VisibleIndex = 3
                GVData.Columns("Qty").VisibleIndex = 4
                GVData.Columns("Status").VisibleIndex = 5
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "21" Then
            Try
                Dim query_stock As String = "CALL view_product_per_season(0)"
                Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")

                'Dim query_store As String = "SELECT a.id_comp AS `id_store`, b.id_comp_contact AS `id_store_contact`, a.comp_number AS `store_number`, a.comp_name AS `store_name` FROM tb_m_comp a "
                'query_store += "INNER JOIN tb_m_comp_contact b ON a.id_comp = b.id_comp AND b.is_default=1 "
                'Dim data_store As DataTable = execute_query(query_store, -1, True, "", "", "", "")

                Dim query_comp As String = "SELECT a.id_comp , b.id_comp_contact , a.comp_number , a.comp_name FROM tb_m_comp a "
                query_comp += "INNER JOIN tb_m_comp_contact b ON a.id_comp = b.id_comp AND b.is_default=1 "
                Dim data_comp As DataTable = execute_query(query_comp, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'xls
                Dim tb2 = data_stock.AsEnumerable()
                Dim tb3 = data_comp.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn prod menjadi prodjoin
                            Group Join prod In tb2
                            On xls("code") Equals prod("product_full_code") Into prodjoin = Group
                            From resultprod In prodjoin.DefaultIfEmpty()
                            Group Join store In tb3 'left join xls dgn store menjadi compjoin
                            On xls("store").ToString.ToUpper Equals store("comp_number").ToString.ToUpper Into storejoin = Group
                            From resultstore In storejoin.DefaultIfEmpty()
                            Group Join wh In tb3 'left join dgn comp-wh
                            On xls("wh").ToString.ToUpper Equals wh("comp_number").ToString.ToUpper Into whjoin = Group
                            From resultwh In whjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_product = If(resultprod Is Nothing, "", resultprod("id_product").ToString),
                                .Style = If(resultprod Is Nothing, "", resultprod("design_display_name").ToString),
                                .Size = If(resultprod Is Nothing, "", resultprod("Size").ToString),
                                .From = If(resultwh Is Nothing, "", resultwh("comp_number").ToString + " - " + resultwh("comp_name").ToString),
                                .id_comp_from = If(resultwh Is Nothing, "", resultwh("id_comp").ToString),
                                .id_comp_contact_from = If(resultwh Is Nothing, "", resultwh("id_comp_contact").ToString),
                                .To = If(resultstore Is Nothing, "", resultstore("comp_number").ToString + " - " + resultstore("comp_name").ToString),
                                .id_comp_to = If(resultstore Is Nothing, "", resultstore("id_comp").ToString),
                                .id_comp_contact_to = If(resultstore Is Nothing, "", resultstore("id_comp_contact").ToString),
                                .Qty = xls("qty"),
                                .Status = If(resultprod Is Nothing Or resultstore Is Nothing Or resultwh Is Nothing, If(resultprod Is Nothing, "This product code is not registered; ", "") + If(resultstore Is Nothing, "Store account is not registered; ", "") + If(resultwh Is Nothing, "Warehouse account is not registered; ", ""), "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_comp_to").Visible = False
                GVData.Columns("id_comp_from").Visible = False
                GVData.Columns("id_comp_contact_from").Visible = False
                GVData.Columns("id_comp_contact_to").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("From").VisibleIndex = 3
                GVData.Columns("To").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "22" Then
            ''Return sample from internal sale
            Try
                Dim dt As DataTable = execute_query("CALL view_sample_master()", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("sample_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Description = If(y1 Is Nothing, "", y1("sample_display_name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .Color = If(y1 Is Nothing, "", y1("Color")),
                                .Class = If(y1 Is Nothing, "", y1("class")),
                                .Qty = table1("qty"),
                                .id_sample = If(y1 Is Nothing, "", y1("id_sample")),
                                .code_us = If(y1 Is Nothing, "", y1("sample_us_code")),
                                .id_season = If(y1 Is Nothing, "", y1("id_season")),
                                .id_season_orign = If(y1 Is Nothing, "", y1("id_season_orign")),
                                .season = If(y1 Is Nothing, "", y1("season")),
                                .season_orign = If(y1 Is Nothing, "", y1("season_orign")),
                                .id_cost = If(y1 Is Nothing, "", y1("id_sample_price")),
                                .cost = If(y1 Is Nothing, 0, y1("sample_price")),
                                .id_price = If(y1 Is Nothing, "", y1("id_sample_ret_price")),
                                .price = If(y1 Is Nothing, 0, y1("sample_ret_price")),
                                .Status = If(y1 Is Nothing, "Code not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("code_us").Visible = False
                GVData.Columns("id_season").Visible = False
                GVData.Columns("id_season_orign").Visible = False
                GVData.Columns("season").Visible = False
                GVData.Columns("season_orign").Visible = False
                GVData.Columns("id_cost").Visible = False
                GVData.Columns("cost").Visible = False
                GVData.Columns("id_price").Visible = False
                GVData.Columns("price").Visible = False
                '
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("Size").VisibleIndex = 3
                GVData.Columns("Color").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "23" Then
            'SO Generate New
            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_so_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 4 To 13
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 13 Then
                            size = c - 3
                        End If
                        qry_det += "SELECT '" + id_sales_order_gen + "' AS `id`, '" + data_temp.Rows(d)("VENDOR").ToString + "' AS `store`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`,  '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_so_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            Command.ExecuteNonQuery()
            command.Dispose()

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_sales_order_temp(" + id_sales_order_gen + ")", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            GCData.DataSource = data

            connection.Close()
            connection.Dispose()

            GVData.Columns("id").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp_contact_from").Visible = False
            GVData.Columns("id_comp_contact_to").Visible = False
            GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("From").VisibleIndex = 3
            GVData.Columns("To").VisibleIndex = 4
            GVData.Columns("Qty").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
        ElseIf id_pop_up = "24" Then
            'INVENTORY ALLOCATION
            Dim id_fg_wh_alloc As String = FormFGWHAllocDet.id_fg_wh_alloc
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_fg_wh_alloc_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_fg_wh_alloc_temp AS ( SELECT * FROM ("
            For d As Integer = 0 To data_temp.Rows.Count - 1
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT '" + id_fg_wh_alloc + "' AS `id`, '" + data_temp.Rows(d)("VENDOR").ToString + "' AS `store`, '" + data_temp.Rows(d)("KODE").ToString + "' AS `code`, '" + data_temp.Rows(d)("SIZETYP").ToString + "' AS `sizetype`,  '" + data_temp.Rows(d)("xxs/1").ToString + "' AS `1`, '" + data_temp.Rows(d)("xs/2").ToString + "' AS `2`, '" + data_temp.Rows(d)("s/3").ToString + "' AS `3`, '" + data_temp.Rows(d)("m/4").ToString + "' AS `4`, '" + data_temp.Rows(d)("ml/5").ToString + "' AS `5`, '" + data_temp.Rows(d)("l/6").ToString + "' AS `6`, '" + data_temp.Rows(d)("xl/7").ToString + "' AS `7`, '" + data_temp.Rows(d)("xxl/8").ToString + "' AS `8`, '" + data_temp.Rows(d)("all/9").ToString + "' AS `9`, '" + data_temp.Rows(d)("~/0").ToString + "' AS `0` "
            Next
            qry += ") a ); ALTER TABLE tb_fg_wh_alloc_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_fg_wh_alloc_temp(" + id_fg_wh_alloc + ")", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            GCData.DataSource = data

            connection.Close()
            connection.Dispose()

            GVData.Columns("id").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp_contact_to").Visible = False
            GVData.Columns("id_wh_drawer_to").Visible = False
            GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("To").VisibleIndex = 3
            GVData.Columns("Qty").VisibleIndex = 4
            GVData.Columns("Status").VisibleIndex = 5
        ElseIf id_pop_up = "25" Then
            'sales order 9
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_so_single_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_single_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 3 To 12
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 12 Then
                            size = c - 2
                        End If
                        qry_det += "SELECT '" + FormSalesOrderDet.id_comp_par + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`, '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_so_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "

            'For d As Integer = 0 To data_temp.Rows.Count - 1
            '    If d > 0 Then
            '        qry += "UNION ALL "
            '    End If
            '    qry += "SELECT '" + FormSalesOrderDet.id_comp_par + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + "' AS `code`, '" + data_temp.Rows(d)("SIZETYP").ToString + "' AS `sizetype`,  '" + data_temp.Rows(d)("xxs/1").ToString + "' AS `1`, '" + data_temp.Rows(d)("xs/2").ToString + "' AS `2`, '" + data_temp.Rows(d)("s/3").ToString + "' AS `3`, '" + data_temp.Rows(d)("m/4").ToString + "' AS `4`, '" + data_temp.Rows(d)("ml/5").ToString + "' AS `5`, '" + data_temp.Rows(d)("l/6").ToString + "' AS `6`, '" + data_temp.Rows(d)("xl/7").ToString + "' AS `7`, '" + data_temp.Rows(d)("xxl/8").ToString + "' AS `8`, '" + data_temp.Rows(d)("all/9").ToString + "' AS `9`, '" + data_temp.Rows(d)("~/0").ToString + "' AS `0` "
            'Next
            'qry += ") a ); ALTER TABLE tb_so_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_sales_order_single_temp(" + FormSalesOrderDet.id_comp_par + ", '" + id_user + "')", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            Dim data_par As DataTable = FormSalesOrderDet.GCItemList.DataSource
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            connection.Close()
            connection.Dispose()

            'Customize column
            GVData.Columns("id_design_price").Visible = False
            GVData.Columns("id_design_cat").Visible = False
            GVData.Columns("design_price_type").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_wh").Visible = False
            GVData.Columns("id_user").Visible = False
            GVData.Columns("id_design_type").Visible = False
            'GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Price").VisibleIndex = 3
            GVData.Columns("Available").VisibleIndex = 4
            GVData.Columns("Qty").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
            GVData.Columns("Design Type").VisibleIndex = 7
            GVData.Columns("Available").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Available").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
        ElseIf id_pop_up = "26" Then
            'FAKTUR KELUARAN
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "27" Then
            'holiday list
            Dim queryx As String = "SELECT id_religion,religion FROM tb_lookup_religion"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("religion") Equals table_tmp("religion")
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .Date = table1("date"),
                                .IdReligion = If(y1 Is Nothing, "0", y1("id_religion")),
                                .Religion = table1("religion"),
                                .Description = table1("nama_libur")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdReligion").Visible = False
            GVData.Columns("Date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("Date").DisplayFormat.FormatString = "{0:dd MMM yyyy}"
        ElseIf id_pop_up = "28" Then
            'vendor code 
            Dim queryx As String = "SELECT id_product,product_full_code,product_name FROM tb_m_product"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("pr_code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .IdProduct = If(y1 Is Nothing, "0", y1("id_product")),
                                .Code = If(y1 Is Nothing, "0", y1("product_full_code")),
                                .Description = If(y1 Is Nothing, "0", y1("product_name")),
                                .Color = table1("pr_colnm"),
                                .UPC = table1("pr_upc")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdProduct").Visible = False
        ElseIf id_pop_up = "29" Then
            'return order 9
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_ro_single_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ro_single_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 3 To 12
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 12 Then
                            size = c - 2
                        End If
                        qry_det += "SELECT '" + FormSalesReturnOrderDet.id_comp + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`, '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_ro_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_return_order_single_temp(" + FormSalesReturnOrderDet.id_comp + ", '" + id_user + "')", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            Dim data_par As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            connection.Close()
            connection.Dispose()

            'Customize column
            GVData.Columns("id_design_price_retail").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("Amount").Visible = False
            GVData.Columns("Price").Visible = False
            GVData.Columns("SOH").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Qty").VisibleIndex = 3
            GVData.Columns("Status").VisibleIndex = 4
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("SOH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("SOH").DisplayFormat.FormatString = "{0:n0}"
        ElseIf id_pop_up = "30" Then 'import duty
            Try
                Dim queryx As String = "SELECT po.`prod_order_number`,po.`id_prod_order`,dsg.`design_code_import`,dsg.`design_display_name`,dsg.`design_code`,comp.`comp_name`,comp.`comp_number`
                                    FROM tb_prod_order po
                                    INNER JOIN
                                    (
	                                    SELECT wo.*,ovhp.`id_comp_contact` FROM tb_prod_order_wo wo 
	                                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
	                                    WHERE wo.`is_main_vendor`='1'
                                    ) wo ON wo.id_prod_order=po.`id_prod_order`
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=wo.`id_comp_contact`
                                    INNER JOIN tb_m_comp comp ON comp.`id_comp`=cc.`id_comp`
                                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                    WHERE po.`id_report_status`!='5' AND po.`id_po_type`='2'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim tb3 = data_curr.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                            On table1("kode").ToString.ToLower Equals table_tmp("design_code").ToString.ToLower Into prod = Group
                            From result_prod In prod.DefaultIfEmpty()
                            Group Join curr In tb3
                            On table1("currency").ToString.ToLower Equals curr("id_currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .IdPO = If(result_prod Is Nothing, "0", result_prod("id_prod_order")),
                                .CodeImport = If(result_prod Is Nothing, "0", result_prod("design_code_import")),
                                .Code = If(result_prod Is Nothing, "0", result_prod("design_code")),
                                .Description = If(result_prod Is Nothing, "0", result_prod("design_display_name")),
                                .hs_code = table1("hs_kode"),
                                .AjuNumber = table1("aju_number"),
                                .PibNumber = table1("pib_number"),
                                .PibDate = table1("pib_date"),
                                .Duty = table1("duty"),
                                .Royalty = table1("royalty"),
                                .StoreDiscount = table1("store_discount"),
                                .SalesThru = table1("sales_through"),
                                .SalesVat = table1("ppn"),
                                .SalesPPH = table1("pph"),
                                .isPR = table1("payment_request"),
                                .isPay = table1("payment"),
                                .id_isPR = If(table1("payment_request").ToString.ToUpper = "YES", "1", "2"),
                                .id_isPay = If(table1("payment").ToString.ToUpper = "YES", "1", "2"),
                                .Source = table1("negara_asal"),
                                .DestPort = table1("pelabuhan_tujuan"),
                                .ppjk = table1("ppjk"),
                                .ppjk_inv = table1("ppjk_inv"),
                                .volume = table1("volume"),
                                .uom = table1("uom"),
                                .ls_no = table1("ls_no"),
                                .ls_date = table1("ls_date"),
                                .coo = table1("coo"),
                                .currency = If(resultcurr Is Nothing, "2", resultcurr("currency")),
                                .id_currency = table1("currency"),
                                .kurs = table1("kurs"),
                                .cif = table1("cif"),
                                .freight_cost_rp = table1("freight_cost_rp"),
                                .penalty_percent = table1("penalty_percent"),
                                .royalty_pib = table1("royalty_pib_rp")
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdPO").Visible = False
                GVData.Columns("hs_code").Caption = "HS Code"
                GVData.Columns("CodeImport").Caption = "Code Import"
                GVData.Columns("AjuNumber").Caption = "Aju Number"
                GVData.Columns("PibNumber").Caption = "PIB Number"
                GVData.Columns("PibDate").Caption = "PIB Date"
                GVData.Columns("PibDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("PibDate").DisplayFormat.FormatString = "dd MMM yyyy"
                GVData.Columns("Duty").Caption = "Duty %"
                GVData.Columns("Royalty").Caption = "Royalty %"
                GVData.Columns("SalesVat").Caption = "PPN %"
                GVData.Columns("SalesPPH").Caption = "PPH %"
                GVData.Columns("StoreDiscount").Caption = "Store Discount %"
                GVData.Columns("SalesThru").Caption = "Sales Through %"
                GVData.Columns("isPR").Caption = "Payment Requested"
                GVData.Columns("isPay").Caption = "Payment"
                GVData.Columns("id_isPR").Visible = False
                GVData.Columns("id_isPay").Visible = False
                GVData.Columns("Source").Caption = "Source Country"
                GVData.Columns("DestPort").Caption = "Destination Port"
                GVData.Columns("ppjk").Caption = "PPJK"
                GVData.Columns("ppjk_inv").Caption = "PPJK Invoice Number"
                GVData.Columns("volume").Caption = "Volume"
                GVData.Columns("uom").Caption = "UOM"
                GVData.Columns("ls_no").Caption = "L/S Number"
                GVData.Columns("ls_date").Caption = "L/S Date"
                GVData.Columns("ls_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("ls_date").DisplayFormat.FormatString = "dd MMM yyyy"
                GVData.Columns("coo").Caption = "COO"
                GVData.Columns("currency").Caption = "Currency"
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("kurs").Caption = "Kurs"
                GVData.Columns("cif").Caption = "CIF"
                GVData.Columns("freight_cost_rp").Caption = "Freight Cost (Rp)"
                GVData.Columns("penalty_percent").Caption = "Penalty %"
                GVData.Columns("royalty_pib").Caption = "Royalty PIB (Rp)"
                GVData.Columns("Duty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Duty").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("Royalty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Royalty").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("StoreDiscount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("StoreDiscount").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesThru").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesThru").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesVat").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesVat").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesPPH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesPPH").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("volume").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("volume").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("kurs").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("kurs").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("cif").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("cif").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("freight_cost_rp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("freight_cost_rp").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("penalty_percent").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("penalty_percent").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("royalty_pib").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("royalty_pib").DisplayFormat.FormatString = "{0:n4}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "31" Then
            Dim id_emp_uni_period As String = FormEmpUniPeriodDet.id_emp_uni_period

            'master emp
            Dim queryx As String = "SELECT e.id_employee, e.id_departement, e.id_employee_level, IFNULL(so.id_sales_order,0) AS `id_sales_order`, e.employee_code, e.employee_name, e.employee_position, dept.departement 
            FROM tb_m_employee e 
            LEFT JOIN tb_emp_uni_budget b ON b.id_employee = e.id_employee AND b.id_emp_uni_period=" + id_emp_uni_period + "
            LEFT JOIN(
	            SELECT so.id_sales_order,so.id_emp_uni_budget  
	            FROM tb_sales_order so
	            WHERE !ISNULL(so.id_emp_uni_budget) AND so.id_emp_uni_period = " + id_emp_uni_period + "
	            GROUP BY so.id_emp_uni_budget
            ) so ON so.id_emp_uni_budget = b.id_emp_uni_budget
            INNER JOIN tb_m_departement dept ON dept.id_departement = e.id_departement
            WHERE e.id_employee_active=1 "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("nik").ToString Equals table_tmp("employee_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .IdEmp = If(y1 Is Nothing, "0", y1("id_employee").ToString),
                                .IdDept = If(y1 Is Nothing, "0", y1("id_departement").ToString),
                                .IdLevel = If(y1 Is Nothing, "0", y1("id_employee_level").ToString),
                                .IdSO = If(y1 Is Nothing, "0", y1("id_sales_order").ToString),
                                .NIK = table1("nik"),
                                .Name = If(y1 Is Nothing, "-", y1("employee_name").ToString),
                                .Dept = If(y1 Is Nothing, "-", y1("departement").ToString),
                                .Position = If(y1 Is Nothing, "-", y1("employee_position").ToString),
                                .Budget = table1("budget"),
                                .IdDeptHead = table1("is_dept_head").ToString,
                                .DeptHead = If(table1("is_dept_head").ToString = "1", "Yes", If(table1("is_dept_head").ToString = "2", "No", "-")),
                                .Status = If(y1 Is Nothing Or (table1("is_dept_head").ToString <> "1" And table1("is_dept_head").ToString <> "2"), If(y1 Is Nothing, "Karyawan tidak ditemukan; ", "") + If(table1("is_dept_head").ToString <> "1" And table1("is_dept_head").ToString <> "2", "Harap mengisi kolom Dept Head dengan benar; ", ""), If(y1("id_sales_order").ToString = 0, "OK", "Order already processed"))
                            }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()
            '.Budget = If(FormEmpUniBudgetSet.CheckEdit1.EditValue.ToString = "True", FormEmpUniBudgetSet.TxtBudget.EditValue, table1("budget")),

            'Customize column
            GVData.Columns("IdEmp").Visible = False
            GVData.Columns("IdDept").Visible = False
            GVData.Columns("IdDeptHead").Visible = False
            GVData.Columns("IdLevel").Visible = False
            GVData.Columns("IdSO").Visible = False
            GVData.Columns("Budget").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Budget").DisplayFormat.FormatString = "{0:n2}"
        ElseIf id_pop_up = "32" Then 'import duty sales
            Try
                Dim queryx As String = "SELECT po.`prod_order_number`,po.`id_prod_order`,dsg.`design_code_import`,dsg.`design_display_name`,dsg.`design_code`,comp.`comp_name`,comp.`comp_number`
                                    FROM tb_prod_order po
                                    INNER JOIN
                                    (
	                                    SELECT wo.*,ovhp.`id_comp_contact` FROM tb_prod_order_wo wo 
	                                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
	                                    WHERE wo.`is_main_vendor`='1'
                                    ) wo ON wo.id_prod_order=po.`id_prod_order`
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=wo.`id_comp_contact`
                                    INNER JOIN tb_m_comp comp ON comp.`id_comp`=cc.`id_comp`
                                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                    WHERE po.`id_report_status`!='5' AND po.`id_po_type`='2'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                            On table1("kode").ToString.ToLower Equals table_tmp("design_code").ToString.ToLower Into prod = Group
                            From result_prod In prod.DefaultIfEmpty()
                            Select New With
                            {
                                .IdPO = If(result_prod Is Nothing, "0", result_prod("id_prod_order")),
                                .CodeImport = If(result_prod Is Nothing, "0", result_prod("design_code_import")),
                                .Code = If(result_prod Is Nothing, "0", result_prod("design_code")),
                                .Description = If(result_prod Is Nothing, "0", result_prod("design_display_name")),
                                .sales_actual_qty = table1("sales_actual_qty"),
                                .amount_after_discount = table1("amount_after_discount")
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdPO").Visible = False
                GVData.Columns("CodeImport").Caption = "Code Import"
                GVData.Columns("amount_after_discount").Caption = "Amount After Discount"
                GVData.Columns("amount_after_discount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("amount_after_discount").DisplayFormat.FormatString = "{0:n0}"
                GVData.Columns("sales_actual_qty").Caption = "Sales Actual Qty"
                GVData.Columns("sales_actual_qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("sales_actual_qty").DisplayFormat.FormatString = "{0:n0}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "33" Then
            'import list uni


            'master design
            Dim queryx As String = "SELECT * FROM tb_m_design d WHERE d.id_active=1 "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            'list
            Dim ql As String = "SELECT dd.id_design, dm.design_code
            FROM tb_emp_uni_design_det dd
            INNER JOIN tb_m_design dm ON dm.id_design = dd.id_design
            INNER JOIN tb_emp_uni_design d ON d.id_emp_uni_design = dd.id_emp_uni_design
            WHERE d.id_emp_uni_period=" + FormEmpUniListDet.LEPeriodx.EditValue.ToString + "
            AND d.id_report_status!=5 "
            Dim dl As DataTable = execute_query(ql, -1, True, "", "", "", "")
            Dim tb3 = dl.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("KODE").ToString Equals table_tmp("design_code").ToString Into designjoin = Group
                        From rd In designjoin.DefaultIfEmpty()
                        Group Join list In tb3 On table1("KODE").ToString Equals list("design_code").ToString Into listjoin = Group
                        From rl In listjoin.DefaultIfEmpty()
                        Select New With
                            {
                                .IdDesign = If(rd Is Nothing, "0", rd("id_design").ToString),
                                .Code = If(rd Is Nothing, table1("KODE"), rd("design_code").ToString),
                                .Description = If(rd Is Nothing, "-", rd("design_display_name").ToString),
                                .Status = If(rd Is Nothing, "Not Found", If(rl Is Nothing, "OK", "Already exist on this period"))
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()
            GVData.Columns("IdDesign").Visible = False
        ElseIf id_pop_up = "34" Then 'import salary
            Try
                Dim queryx As String = "SELECT * FROM tb_m_employee"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                                On table1("nik").ToString.ToLower Equals table_tmp("employee_code").ToString.ToLower Into emp = Group
                            From result_emp In emp.DefaultIfEmpty()
                            Select New With
                                {
                                    .IdEmployee = If(result_emp Is Nothing, "0", result_emp("id_employee")),
                                    .NIK = If(result_emp Is Nothing, "0", result_emp("employee_code")),
                                    .Name = If(result_emp Is Nothing, "0", result_emp("employee_name")),
                                    .basic_salary = If(table1("basic_salary").ToString = "", 0, table1("basic_salary")),
                                    .allow_job = If(table1("job_allowance").ToString = "", 0, table1("job_allowance")),
                                    .allow_meal = If(table1("meal_allowance").ToString = "", 0, table1("meal_allowance")),
                                    .allow_trans = If(table1("transport_allowance").ToString = "", 0, table1("transport_allowance")),
                                    .allow_house = If(table1("house_allowance").ToString = "", 0, table1("house_allowance")),
                                    .allow_car = If(table1("car_allowance").ToString = "", 0, table1("car_allowance")),
                                    .effective_date = If(table1("effective_date").ToString = "", 0, table1("effective_date"))
                                }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdEmployee").Visible = False
                GVData.Columns("NIK").Caption = "NIK"
                GVData.Columns("basic_salary").Caption = "Basic Salary"
                GVData.Columns("allow_job").Caption = "Job Allowance"
                GVData.Columns("allow_meal").Caption = "Meal Allowance"
                GVData.Columns("allow_trans").Caption = "Transport Allowance"
                GVData.Columns("allow_house").Caption = "House Allowance"
                GVData.Columns("allow_car").Caption = "Attendance Allowance"
                GVData.Columns("effective_date").Caption = "Effective Date"

                GVData.Columns("basic_salary").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("allow_job").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("allow_meal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("allow_trans").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("allow_house").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("allow_car").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                GVData.Columns("basic_salary").DisplayFormat.FormatString = "{0:N2}"
                GVData.Columns("allow_job").DisplayFormat.FormatString = "{0:N2}"
                GVData.Columns("allow_meal").DisplayFormat.FormatString = "{0:N2}"
                GVData.Columns("allow_trans").DisplayFormat.FormatString = "{0:N2}"
                GVData.Columns("allow_house").DisplayFormat.FormatString = "{0:N2}"
                GVData.Columns("allow_car").DisplayFormat.FormatString = "{0:N2}"

                GVData.Columns("effective_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("effective_date").DisplayFormat.FormatString = "{0:dd MMM yyyy}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "35" Then 'import awb receiving data
            Try
                Dim queryx As String = "SELECT id_awbill,awbill_no,rec_by_store_date,rec_by_store_person,awbill_inv_no,cargo_min_weight,cargo_rate,a_weight,a_tot_price FROM tb_wh_awbill 
                                        WHERE awbill_no != '' AND awbill_type='1' AND is_lock='2'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                                On table1("awb_no").ToString.ToLower Equals table_tmp("awbill_no").ToString.ToLower Into awb = Group
                            From result_awb In awb.DefaultIfEmpty()
                            Select New With
                                {
                                    .IdAwb = If(result_awb Is Nothing, "0", result_awb("id_awbill")),
                                    .AWB = If(result_awb Is Nothing, table1("awb_no"), result_awb("awbill_no")),
                                    .rec_date_old = If(result_awb Is Nothing, "0", result_awb("rec_by_store_date")),
                                    .rec_by_old = If(result_awb Is Nothing, "0", result_awb("rec_by_store_person")),
                                    .inv_no_old = If(result_awb Is Nothing, "0", result_awb("awbill_inv_no")),
                                    .a_weight_old = If(result_awb Is Nothing, "0", result_awb("a_weight")),
                                    .a_tot_price_old = If(result_awb Is Nothing, "0", result_awb("a_tot_price")),
                                    .rec_date_new = If(table1("rec_date").ToString = "", If(result_awb Is Nothing, "0", result_awb("rec_by_store_date")), table1("rec_date")),
                                    .rec_by_new = If(table1("rec_by").ToString = "", If(result_awb Is Nothing, "0", result_awb("rec_by_store_person")), table1("rec_by")),
                                    .inv_no_new = If(table1("inv_no").ToString = "", If(result_awb Is Nothing, "0", result_awb("awbill_inv_no")), table1("inv_no")),
                                    .a_weight_new = If(table1("a_weight").ToString = "", If(result_awb Is Nothing, 0, result_awb("a_weight")), table1("a_weight")),
                                    .a_tot_price_new = If(table1("a_weight").ToString = "", If(result_awb Is Nothing, 0, result_awb("a_tot_price")), If(result_awb Is Nothing, table1("a_weight"), If(table1("a_weight") < result_awb("cargo_min_weight"), result_awb("cargo_min_weight"), table1("a_weight"))) * If(result_awb Is Nothing, 0, result_awb("cargo_rate"))),
                                    .note = If(result_awb Is Nothing, "AWB Number not found", "OK")
                                }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdAwb").Visible = False
                GVData.Columns("AWB").Caption = "AWB Number"
                GVData.Columns("rec_date_old").Caption = "(Old) Receive Date"
                GVData.Columns("rec_by_old").Caption = "(Old) Receive By"
                GVData.Columns("inv_no_old").Caption = "(Old) Invoice Number"
                GVData.Columns("rec_date_new").Caption = "Receive Date"
                GVData.Columns("rec_by_new").Caption = "Receive By"
                GVData.Columns("inv_no_new").Caption = "Invoice Number"
                GVData.Columns("note").Caption = "Note"

                GVData.Columns("a_weight_old").Caption = "(Old) Cargo Weight"
                GVData.Columns("a_tot_price_old").Caption = "(Old) Invoice Amount"
                GVData.Columns("a_weight_new").Caption = "Cargo Weight"
                GVData.Columns("a_tot_price_new").Caption = "Invoice Amount"

                GVData.Columns("rec_date_old").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("rec_date_new").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                GVData.Columns("a_weight_old").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_weight_old").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_tot_price_old").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_tot_price_old").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_weight_new").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_weight_new").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_tot_price_new").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_tot_price_new").DisplayFormat.FormatString = "N2"

                GVData.Columns("rec_date_old").DisplayFormat.FormatString = "{0:dd MMM yyyy}"
                GVData.Columns("rec_date_new").DisplayFormat.FormatString = "{0:dd MMM yyyy}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "36" Then 'import koperasi cicilan
            Try
                Dim queryx As String = "SELECT employee_code,employee_name,dep.departement,emp.id_employee FROM tb_m_employee emp 
                                        INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                        WHERE emp.id_employee_active='1'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                                On table1("NIK").ToString.ToLower Equals table_tmp("employee_code").ToString.ToLower Into emp = Group
                            From result_emp In emp.DefaultIfEmpty()
                            Select New With
                                {
                                    .IdEmployee = If(result_emp Is Nothing, "0", result_emp("id_employee")),
                                    .NIK = If(result_emp Is Nothing, "0", result_emp("employee_code")),
                                    .Name = If(result_emp Is Nothing, "0", result_emp("employee_name")),
                                    .Departement = If(result_emp Is Nothing, "0", result_emp("departement")),
                                    .Deduction = table1("cicilan"),
                                    .Note = table1("note")
                                }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdEmployee").Visible = False
                GVData.Columns("NIK").Caption = "NIK"

                GVData.Columns("Deduction").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Deduction").DisplayFormat.FormatString = "{0:N0}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "37" Then
            'target sales
            Dim queryx As String = "SELECT c.id_comp,c.comp_number AS `code`, c.comp_name AS `name` FROM tb_m_comp c WHERE c.is_active=1 AND c.id_comp_cat=6 "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("code").ToString.ToLower Equals table_tmp("code").ToString.ToLower Into comp = Group
                        From result_comp In comp.DefaultIfEmpty()
                        Select New With
                        {
                            .id_comp = If(result_comp Is Nothing, "0", result_comp("id_comp")),
                            .Code = table1("Code"),
                            .Store = If(result_comp Is Nothing, "", result_comp("name").ToString),
                            .January = If(table1("1").ToString = "", 0, table1("1")),
                            .February = If(table1("2").ToString = "", 0, table1("2")),
                            .March = If(table1("3").ToString = "", 0, table1("3")),
                            .April = If(table1("4").ToString = "", 0, table1("4")),
                            .May = If(table1("5").ToString = "", 0, table1("5")),
                            .June = If(table1("6").ToString = "", 0, table1("6")),
                            .July = If(table1("7").ToString = "", 0, table1("7")),
                            .August = If(table1("8").ToString = "", 0, table1("8")),
                            .September = If(table1("9").ToString = "", 0, table1("9")),
                            .October = If(table1("10").ToString = "", 0, table1("10")),
                            .November = If(table1("11").ToString = "", 0, table1("11")),
                            .December = If(table1("12").ToString = "", 0, table1("12")),
                            .Status = If(result_comp Is Nothing, "Code not found", "OK")
                        }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'show footer
            GVData.OptionsView.ShowFooter = True


            'create unbound column
            Dim col_total As New DevExpress.XtraGrid.Columns.GridColumn()
            col_total.Caption = "Total"
            col_total.FieldName = "Total"
            col_total.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            col_total.UnboundExpression = "[January]+[February]+[March]+[April]+[May]+[June]+[July]+[August]+[September]+[October]+[November]+[December]"
            col_total.Visible = True
            GVData.Columns.Add(col_total)

            'Customize column
            GVData.Columns("id_comp").Visible = False
            GVData.Columns("Status").VisibleIndex = 100

            'display format
            GVData.Columns("January").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("February").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("March").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("April").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("May").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("June").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("July").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("August").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("September").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("October").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("November").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("December").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("January").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("February").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("March").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("April").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("May").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("June").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("July").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("August").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("September").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("October").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("November").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("December").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("Total").DisplayFormat.FormatString = "{0:N2}"

            'summary
            GVData.Columns("January").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("February").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("March").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("April").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("May").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("June").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("July").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("August").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("September").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("October").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("November").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("December").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("Total").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("January").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("February").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("March").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("April").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("May").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("June").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("July").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("August").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("September").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("October").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("November").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("December").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("Total").SummaryItem.DisplayFormat = "{0:n2}"

            'best fit
            GVData.OptionsView.ColumnAutoWidth = False
            GVData.BestFitColumns()
        ElseIf id_pop_up = "38" Then
            Dim id_bex As String = FormBudgetExpenseProposeDet.id
            Dim id_dept As String = FormBudgetExpenseProposeDet.id_departement
            Dim bex_year As String = FormBudgetExpenseProposeDet.TxtYear.Text
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_bex_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_bex_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT " + id_bex + " AS `id`,'" + id_dept + "' AS `id_dept`, '" + bex_year + "' AS `year` , '" + data_temp.Rows(d)("Code").ToString + "' AS `code`, " + decimalSQL(data_temp.Rows(d)("Value").ToString) + " AS `val` "
            Next
            qry += ") a ); ALTER TABLE tb_bex_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            'view
            Dim ds As New DataTable
            Dim qs As String = "CALL view_b_expense_temp(" + id_bex + ")"
            Dim adapter As New MySqlDataAdapter(qs, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(ds)
            adapter.Dispose()
            ds.Dispose()
            GCData.DataSource = ds
            connection.Close()
            connection.Dispose()

            'hide column 
            GVData.Columns("year").Visible = False
            GVData.Columns("id_item_coa").Visible = False
            GVData.Columns("id_b_expense_propose_year").Visible = False

            GVData.BestFitColumns()
            GVData.OptionsView.ShowFooter = True



            'display format
            GVData.Columns("Value").Caption = "Test"
            GVData.Columns("Value").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Value").DisplayFormat.FormatString = "{0:N2}"

            'summary
            GVData.Columns("Value").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("Value").SummaryItem.DisplayFormat = "{0:n2}"

            'notice - smentara belum kepake
            'If GVData.RowCount <= 0 Then
            'stopCustom("Can't import data. Please make sure total value is not exceed yearly total budget.")
            'End If
        ElseIf id_pop_up = "39" Then
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim id_bex As String = FormBudgetExpenseProposeDet.id
            Dim bex_year As String = FormBudgetExpenseProposeDet.TxtYear.Text
            Dim id_dept As String = FormBudgetExpenseProposeDet.id_departement
            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_bex_month_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_bex_month_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            Dim j As Integer = 0
            For d As Integer = 0 To data_temp.Rows.Count - 1
                Dim code As String = data_temp.Rows(d)("Code").ToString
                For e As Integer = 1 To 12
                    If j > 0 Then
                        qry += "UNION ALL "
                    End If
                    Dim mth As String = ""
                    If e < 10 Then
                        mth = "0" + e.ToString
                    Else
                        mth = e.ToString
                    End If
                    qry += "SELECT " + id_bex + " AS `id`,'" + id_dept + "' AS `id_dept`, '" + code + "' AS `code`, '" + bex_year + "-" + mth + "-01' AS `month` , " + decimalSQL(data_temp.Rows(d)(e.ToString).ToString) + " AS `val` "
                    j += 1
                Next
            Next
            qry += ") a ); ALTER TABLE tb_bex_month_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            'Console.WriteLine(qry)
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()

            'view
            Dim ds As New DataTable
            Dim qs As String = "CALL view_b_expense_month_temp(" + id_bex + ")"
            Dim adapter As New MySqlDataAdapter(qs, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(ds)
            adapter.Dispose()
            ds.Dispose()
            GCData.DataSource = ds
            connection.Close()
            connection.Dispose()

            'hide column 
            GVData.Columns("id").Visible = False
            GVData.Columns("id_b_expense_propose_year").Visible = False
            GVData.Columns("id_b_expense_propose_month").Visible = False
            GVData.Columns("mth").Visible = False

            GVData.BestFitColumns()
            GVData.OptionsView.ShowFooter = True



            'display format
            GVData.Columns("Value").Caption = "Test"
            GVData.Columns("Value").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Value").DisplayFormat.FormatString = "{0:N2}"

            'summary
            GVData.Columns("Value").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("Value").SummaryItem.DisplayFormat = "{0:n2}"
        ElseIf id_pop_up = "40" Then
            'omport excel budget
            'Try
            Dim queryx As String = "SELECT  c.id_item_coa,
            coa.acc_name AS `code`,coa.acc_description AS `exp_description`, cat.item_cat
            FROM tb_item_coa c
            INNER JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
            INNER JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
            WHERE c.id_departement=" + FormBudgetExpenseProposeDet.id_departement + " "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("code").ToString.ToLower Equals table_tmp("code").ToString.ToLower Into coa = Group
                        From result_coa In coa.DefaultIfEmpty()
                        Select New With
                        {
                            .id_item_coa = If(result_coa Is Nothing, "0", result_coa("id_item_coa")),
                            .Code = table1("Code"),
                            .Description = If(result_coa Is Nothing, "", result_coa("exp_description").ToString),
                            .Category = If(result_coa Is Nothing, "", result_coa("item_cat")),
                            .January = If(table1("1").ToString = "", 0, table1("1")),
                            .February = If(table1("2").ToString = "", 0, table1("2")),
                            .March = If(table1("3").ToString = "", 0, table1("3")),
                            .April = If(table1("4").ToString = "", 0, table1("4")),
                            .May = If(table1("5").ToString = "", 0, table1("5")),
                            .June = If(table1("6").ToString = "", 0, table1("6")),
                            .July = If(table1("7").ToString = "", 0, table1("7")),
                            .August = If(table1("8").ToString = "", 0, table1("8")),
                            .September = If(table1("9").ToString = "", 0, table1("9")),
                            .October = If(table1("10").ToString = "", 0, table1("10")),
                            .November = If(table1("11").ToString = "", 0, table1("11")),
                            .December = If(table1("12").ToString = "", 0, table1("12")),
                            .Status = If(result_coa Is Nothing, "Code not found", "OK")
                        }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'show footer
            GVData.OptionsView.ShowFooter = True


            'create unbound column
            Dim col_total As New DevExpress.XtraGrid.Columns.GridColumn()
            col_total.Caption = "Total"
            col_total.FieldName = "Total"
            col_total.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            col_total.UnboundExpression = "[January]+[February]+[March]+[April]+[May]+[June]+[July]+[August]+[September]+[October]+[November]+[December]"
            col_total.Visible = True
            GVData.Columns.Add(col_total)

            'Customize column
            GVData.Columns("id_item_coa").Visible = False
            GVData.Columns("Status").VisibleIndex = 100

            'display format
            GVData.Columns("January").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("February").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("March").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("April").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("May").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("June").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("July").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("August").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("September").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("October").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("November").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("December").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("January").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("February").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("March").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("April").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("May").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("June").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("July").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("August").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("September").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("October").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("November").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("December").DisplayFormat.FormatString = "{0:N2}"
            GVData.Columns("Total").DisplayFormat.FormatString = "{0:N2}"

            'summary
            GVData.Columns("January").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("February").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("March").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("April").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("May").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("June").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("July").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("August").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("September").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("October").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("November").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("December").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("Total").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("January").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("February").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("March").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("April").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("May").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("June").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("July").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("August").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("September").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("October").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("November").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("December").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("Total").SummaryItem.DisplayFormat = "{0:n2}"

            'best fit
            GVData.OptionsView.ColumnAutoWidth = False
            GVData.BestFitColumns()

            'Catch ex As Exception
            '    stopCustom(ex.ToString)
            'End Try
        ElseIf id_pop_up = "41" Then
            'check format generate OL store order
            Try
                dt_add.Clear()
            Catch ex As Exception
            End Try
            BtnAction.Enabled = False

            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_so_ol_store; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_ol_store AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                If qry_det <> "" Then
                    qry_det += "UNION ALL "
                End If
                Dim size_check As String = ""
                If Not isNumber(data_temp.Rows(d)("Variation").ToString) Then
                    size_check = "'" + data_temp.Rows(d)("Variation").ToString + "'"
                Else
                    size_check = "LPAD('" + data_temp.Rows(d)("Variation").ToString + "',2,'0')"
                End If
                qry_det += "SELECT '" + data_temp.Rows(d)("Order Number").ToString + "' AS `order_number`,'" + data_temp.Rows(d)("Order Item Id").ToString + "' AS `item_id`,  '" + data_temp.Rows(d)("Zalora Id").ToString + "' AS `ol_store_id`, LEFT('" + data_temp.Rows(d)("Seller SKU").ToString + "',9) AS `design_code`, IF(" + size_check + "<'10',LPAD('" + data_temp.Rows(d)("Variation").ToString + "',2,'0'),IF('" + data_temp.Rows(d)("Variation").ToString + "'='One Size', 'ALL', REPLACE('" + data_temp.Rows(d)("Variation").ToString + "',' in',''))) AS `size`,
                '" + DateTime.Parse(data_temp.Rows(d)("Created at").ToString).ToString("yyyy-MM-dd HH:mm:ss") + "' AS `created_date_ol_store`, '" + addSlashes(data_temp.Rows(d)("Customer Name").ToString) + "' AS `customer_name`, '" + addSlashes(data_temp.Rows(d)("Shipping Name").ToString) + "' AS `shipping_name`, '" + addSlashes(data_temp.Rows(d)("Shipping Address").ToString) + "' AS `shipping_address`,
                '" + addSlashes(data_temp.Rows(d)("Shipping Phone Number").ToString) + "' AS `shipping_phone`, '" + addSlashes(data_temp.Rows(d)("Shipping City").ToString) + "' AS `shipping_city`, '" + data_temp.Rows(d)("Shipping Postcode").ToString + "' AS `shipping_post_code`, '" + addSlashes(data_temp.Rows(d)("Shipping Region").ToString) + "' AS `shipping_region`,  '" + addSlashes(data_temp.Rows(d)("Payment Method").ToString) + "' AS `payment_method`,  '" + data_temp.Rows(d)("Tracking Code").ToString + "' AS `tracking_code`,'" + data_temp.Rows(d)("Zalora SKU").ToString + "' AS `ol_store_sku`, '" + id_user + "' AS `id_user` "
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_so_ol_store CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            '---- FOR VIEW
            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_ol_store_order_temp(" + FormOLStoreDet.SLECompGroup.EditValue.ToString + ", " + id_user + ")", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            'data
            GCData.DataSource = data
            GVData.OptionsView.ColumnAutoWidth = False
            If GVData.RowCount > 0 Then
                BtnAction.Enabled = True
            End If
            'data view dispose
            data.Dispose()

            '---- FOR SUMMARY PRODUCT
            Dim data_prod As New DataTable
            Dim adapter_prod As New MySqlDataAdapter("CALL view_ol_store_order_product_temp(" + FormOLStoreDet.SLECompGroup.EditValue.ToString + ", " + id_user + ")", connection)
            adapter_prod.SelectCommand.CommandTimeout = 300
            adapter_prod.Fill(data_prod)
            adapter_prod.Dispose()
            'data
            dt_add = data_prod
            'data summary prod dispose
            data_prod.Dispose()


            '------ dispose conn
            connection.Close()
            connection.Dispose()

            'pemenuhan stok (belum jadi)
            'makeSafeGV(GVData)
            'For d As Integer = 0 To data_prod.Rows.Count - 1
            '    Dim qty As Decimal = data_prod.Rows(d)("available_qty")
            '    Dim qty_fulfil As Decimal = 0
            '    For r As Integer = 0 To GVData.RowCount - 1
            '        If GVData.GetRowCellValue(r, "stock_availability").ToString = "NO STOCK" And GVData.GetRowCellValue(r, "id_product").ToString = data_prod.Rows(d)("id_product").ToString Then
            '            GVData.SetRowCellValue(r, "stock_availability", "OK")
            '            qty_fulfil += 1
            '        End If
            '        If qty_fulfil = qty Then
            '            Exit For
            '        End If
            '    Next
            'Next

            'column position
            GVData.Columns("Status").Caption = "Format Import"
            GVData.Columns("Status").VisibleIndex = 0
            GVData.Columns("Status").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'GVData.Columns("stock_availability").Caption = "Stock Status"
            'GVData.Columns("stock_availability").VisibleIndex = 2
            'GVData.Columns("stock_availability").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            'option
            GVData.OptionsView.ShowFooter = True
            GVData.OptionsCustomization.AllowSort = False
            GVData.OptionsCustomization.AllowFilter = False

            'hide
            GVData.Columns("id_comp_contact_from").Visible = False
            GVData.Columns("id_wh_drawer").Visible = False
            GVData.Columns("id_store_contact_to").Visible = False
            GVData.Columns("id_store_drawer").Visible = False
            GVData.Columns("id_so_type").Visible = False
            GVData.Columns("id_so_status").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_design_price").Visible = False

            'best fit
            GVData.BestFitColumns()

            'display format
            GVData.Columns("sales_order_ol_shop_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("sales_order_ol_shop_date").DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
            GVData.Columns("sales_order_det_qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("sales_order_det_qty").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("design_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("design_price").DisplayFormat.FormatString = "{0:n2}"

            'summary
            GVData.Columns("sales_order_det_qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("sales_order_det_qty").SummaryItem.DisplayFormat = "{0:n0}"
        ElseIf id_pop_up = "42" Then
            Dim date_from_selected As String = DateTime.Parse(FormOLStore.DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_until_selected As String = DateTime.Parse(FormOLStore.DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim queryx As String = "SELECT so.id_sales_order, sod.id_sales_order_det,so.sales_order_ol_shop_number, sod.item_id, sod.ol_store_id, so.sales_order_date,
            prod.product_full_code AS `code`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`
            FROM tb_sales_order_det sod
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
            INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodcode.id_code_detail
            WHERE c.id_commerce_type=2 AND so.id_report_status='6' AND so.sales_order_ol_shop_number!='' AND sod.item_id!='' AND sod.ol_store_id!='' "
            'AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') 
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()
            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("Order Item Id").ToString.Trim Equals table_tmp("item_id").ToString.Trim And table1("Zalora Id").ToString.Trim Equals table_tmp("ol_store_id").ToString.Trim And table1("Order Number").ToString.Trim Equals table_tmp("sales_order_ol_shop_number").ToString.Trim Into ord = Group
                        From result_ord In ord.DefaultIfEmpty()
                        Select New With
                        {
                            .id_sales_order = If(result_ord Is Nothing, "0", result_ord("id_sales_order").ToString),
                            .id_sales_order_det = If(result_ord Is Nothing, "0", result_ord("id_sales_order_det").ToString),
                            .OrderNumber = table1("Order Number").ToString,
                            .OLStoreId = table1("Zalora Id").ToString,
                            .ItemId = table1("Order Item Id").ToString,
                            .Code = If(result_ord Is Nothing, "-", result_ord("code").ToString),
                            .Description = If(result_ord Is Nothing, "-", result_ord("name").ToString),
                            .Size = If(result_ord Is Nothing, "-", result_ord("size").ToString),
                            .OrderStatus = table1("Status").ToString,
                            .UpdatedAt = table1("Updated at"),
                            .Status = If(result_ord Is Nothing, "Order not found", "OK")
                        }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()
            GVData.BestFitColumns()

            'column
            GVData.Columns("id_sales_order").Visible = False
            GVData.Columns("id_sales_order_det").Visible = False

            'display format
            GVData.Columns("UpdatedAt").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("UpdatedAt").DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        ElseIf id_pop_up = "43" Then
            'master division
            Dim qdv As String = "SELECT cd.id_code_detail, cd.display_name 
            FROM tb_m_code_detail cd
            WHERE cd.id_code=32; "
            Dim ddv As DataTable = execute_query(qdv, -1, True, "", "", "", "")

            'mmaster cat
            Dim qcat As String = "SELECT cd.id_code_detail, cd.display_name, LEFT(cd.code_detail_name,3) AS `src`
            FROM tb_m_code_detail cd
            WHERE cd.id_code=4; "
            Dim dcat As DataTable = execute_query(qcat, -1, True, "", "", "", "")

            'master source
            Dim qsr As String = "SELECT cd.id_code_detail, UPPER(cd.display_name) AS `display_name`
            FROM tb_m_code_detail cd
            WHERE cd.id_code=5; "
            Dim dsr As DataTable = execute_query(qsr, -1, True, "", "", "", "")

            'master class
            Dim qcl As String = "SELECT cd.id_code_detail, UPPER(cd.display_name) AS `display_name`
            FROM tb_m_code_detail cd
            WHERE cd.id_code=30; "
            Dim dcl As DataTable = execute_query(qcl, -1, True, "", "", "", "")

            'master color
            Dim qcol As String = "SELECT cd.id_code_detail, UPPER(cd.display_name) AS `display_name`
            FROM tb_m_code_detail cd
            WHERE cd.id_code=14; "
            Dim dcol As DataTable = execute_query(qcol, -1, True, "", "", "", "")

            'master delivery
            Dim qdel As String = "SELECT * FROM tb_season_delivery d WHERE d.id_season=" + FormFGLinePlan.SLESeason.EditValue.ToString + "; "
            Dim ddel As DataTable = execute_query(qdel, -1, True, "", "", "", "")

            'line plan type
            Dim qtyp As String = "SELECT * FROM tb_lookup_line_plan_cat "
            Dim dtyp As DataTable = execute_query(qtyp, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable() 'datatable xls
            Dim tb2 = ddv.AsEnumerable() 'datatable division
            Dim tb3 = dcat.AsEnumerable() 'datatable cat
            Dim tb4 = dsr.AsEnumerable() 'datatable src
            Dim tb5 = dcl.AsEnumerable() 'datatable class
            Dim tb6 = dcol.AsEnumerable() 'datatable color
            Dim tb7 = ddel.AsEnumerable()
            Dim tb8 = dtyp.AsEnumerable()

            Dim query = From xls In tb1
                        Group Join div In tb2
                        On xls("SEX").ToString.ToUpper Equals div("display_name").ToString.ToUpper Into divjoin = Group
                        From divresult In divjoin.DefaultIfEmpty()
                        Group Join cat In tb3
                        On xls("CAT").ToString.ToUpper Equals cat("display_name").ToString.ToUpper And cat("src").ToString.ToUpper Equals xls("PROD ORIGIN").ToString.ToUpper Into catjoin = Group
                        From catresult In catjoin.DefaultIfEmpty()
                        Group Join src In tb4
                        On xls("PROD ORIGIN").ToString.ToUpper Equals src("display_name").ToString.ToUpper Into srcjoin = Group
                        From srcresult In srcjoin.DefaultIfEmpty()
                        Group Join cls In tb5
                        On xls("CLASS").ToString.ToUpper Equals cls("display_name").ToString.ToUpper Into clsjoin = Group
                        From clsresult In clsjoin.DefaultIfEmpty()
                        Group Join col In tb6
                        On xls("COL").ToString.ToUpper Equals col("display_name").ToString.ToUpper Into coljoin = Group
                        From colresult In coljoin.DefaultIfEmpty()
                        Group Join del In tb7
                        On xls("DEL").ToString Equals del("delivery").ToString Into deljoin = Group
                        From delresult In deljoin.DefaultIfEmpty()
                        Group Join typ In tb8
                        On xls("TYPE").ToString.ToUpper Equals typ("line_plan_cat").ToString.ToUpper Into typjoin = Group
                        From typresult In typjoin.DefaultIfEmpty()
                        Select New With {
                                    .id_line_plan_cat = If(typresult Is Nothing, "0", typresult("id_line_plan_cat").ToString),
                                    .PlanType = If(typresult Is Nothing, "", typresult("line_plan_cat").ToString),
                                    .id_division = If(divresult Is Nothing, "0", divresult("id_code_detail").ToString),
                                    .Division = If(divresult Is Nothing, "", divresult("display_name").ToString),
                                    .id_category = If(catresult Is Nothing, "0", catresult("id_code_detail").ToString),
                                    .Category = If(catresult Is Nothing, "", catresult("display_name").ToString),
                                    .id_delivery = If(delresult Is Nothing, "0", delresult("id_delivery").ToString),
                                    .Del = If(delresult Is Nothing, "", delresult("delivery").ToString),
                                    .id_source = If(srcresult Is Nothing, "0", srcresult("id_code_detail").ToString),
                                    .ProdOrigin = If(srcresult Is Nothing, "", srcresult("display_name").ToString),
                                    .id_class = If(clsresult Is Nothing, "0", clsresult("id_code_detail").ToString),
                                    .Class = If(clsresult Is Nothing, "", clsresult("display_name").ToString),
                                    .Description = xls("DESCRIPTION").ToString,
                                    .id_color = If(colresult Is Nothing, "0", colresult("id_code_detail").ToString),
                                    .COL = If(colresult Is Nothing, "", colresult("display_name").ToString),
                                    .Benchmark = xls("BENCHMARK").ToString,
                                    .Qty = If(xls("QTY").ToString = "", 0, xls("QTY")),
                                    .MarkUp = If(xls("QTY").ToString = "", 0, xls("MARK UP")),
                                    .TargetPrice = If(xls("TARGET PRICE").ToString = "", 0, xls("TARGET PRICE")),
                                    .Status = If(divresult Is Nothing Or catresult Is Nothing Or srcresult Is Nothing Or clsresult Is Nothing Or delresult Is Nothing Or typresult Is Nothing, If(divresult Is Nothing, "Sex not found; ", "") + If(catresult Is Nothing, "Category not found; ", "") + If(srcresult Is Nothing, "Product origin  not found", "") + If(clsresult Is Nothing, "Class not found", "") + If(delresult Is Nothing, "Delivery not found", "") + If(typresult Is Nothing, "Plan Type not found", ""), "OK")
                                }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'hide
            GVData.Columns("id_line_plan_cat").Visible = False
            GVData.Columns("id_delivery").Visible = False
            GVData.Columns("id_division").Visible = False
            GVData.Columns("id_category").Visible = False
            GVData.Columns("id_source").Visible = False
            GVData.Columns("id_class").Visible = False
            GVData.Columns("id_color").Visible = False

            'format
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("MarkUp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("MarkUp").DisplayFormat.FormatString = "{0:n2}"
            GVData.Columns("TargetPrice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("TargetPrice").DisplayFormat.FormatString = "{0:n0}"

            'bestfit
            GVData.OptionsView.ColumnAutoWidth = False
            GVData.BestFitColumns()
        ElseIf id_pop_up = "44" Then 'import awb receiving data inbound
            Try
                Dim queryx As String = "SELECT id_awbill,awbill_no,rec_by_store_date,rec_by_store_person,awbill_inv_no,cargo_min_weight,cargo_rate,a_weight,a_tot_price FROM tb_wh_awbill 
                                        WHERE awbill_no != '' AND awbill_type='2' AND is_lock='2'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                                On table1("awb_no").ToString.ToLower Equals table_tmp("awbill_no").ToString.ToLower Into awb = Group
                            From result_awb In awb.DefaultIfEmpty()
                            Select New With
                                {
                                    .IdAwb = If(result_awb Is Nothing, "0", result_awb("id_awbill")),
                                    .AWB = If(result_awb Is Nothing, table1("awb_no"), result_awb("awbill_no")),
                                    .inv_no_old = If(result_awb Is Nothing, "0", result_awb("awbill_inv_no")),
                                    .a_weight_old = If(result_awb Is Nothing, "0", result_awb("a_weight")),
                                    .a_tot_price_old = If(result_awb Is Nothing, "0", result_awb("a_tot_price")),
                                    .inv_no_new = If(table1("inv_no").ToString = "", If(result_awb Is Nothing, "0", result_awb("awbill_inv_no")), table1("inv_no")),
                                    .a_weight_new = If(table1("a_weight").ToString = "", If(result_awb Is Nothing, 0, result_awb("a_weight")), table1("a_weight")),
                                    .a_tot_price_new = If(table1("a_weight").ToString = "", If(result_awb Is Nothing, 0, result_awb("a_tot_price")), If(result_awb Is Nothing, table1("a_weight"), If(table1("a_weight") < result_awb("cargo_min_weight"), result_awb("cargo_min_weight"), table1("a_weight"))) * If(result_awb Is Nothing, 0, result_awb("cargo_rate"))),
                                    .note = If(result_awb Is Nothing, "AWB Number not found", "OK")
                                }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdAwb").Visible = False
                GVData.Columns("AWB").Caption = "AWB Number"
                GVData.Columns("inv_no_old").Caption = "(Old) Invoice Number"
                GVData.Columns("inv_no_new").Caption = "Invoice Number"
                GVData.Columns("note").Caption = "Note"

                GVData.Columns("a_weight_old").Caption = "(Old) Cargo Weight"
                GVData.Columns("a_tot_price_old").Caption = "(Old) Invoice Amount"
                GVData.Columns("a_weight_new").Caption = "Cargo Weight"
                GVData.Columns("a_tot_price_new").Caption = "Invoice Amount"

                GVData.Columns("a_weight_old").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_weight_old").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_tot_price_old").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_tot_price_old").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_weight_new").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_weight_new").DisplayFormat.FormatString = "N2"
                GVData.Columns("a_tot_price_new").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("a_tot_price_new").DisplayFormat.FormatString = "N2"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "45" Or id_pop_up = "46" Then 'import att nip volcom & nik sogo
            Try
                Dim queryx As String = "
                    SELECT emp.id_employee, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_departement, dep.departement, dep_sub.departement_sub, emp.id_employee_status, sts.employee_status" + If(id_pop_up = "45", ",emp.employee_nik_sogo", "") + "
                    FROM tb_m_employee emp
                    LEFT JOIN tb_m_departement dep ON dep.id_departement = emp.id_departement
                    LEFT JOIN tb_m_departement_sub dep_sub ON dep_sub.id_departement_sub = emp.id_departement_sub
                    LEFT JOIN tb_lookup_employee_status sts ON emp.id_employee_status = sts.id_employee_status
                "
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                'trim nik
                For i = 0 To data_temp.Rows.Count - 1
                    data_temp.Rows(i)("EMPLOYEE NIK") = data_temp.Rows(i)("EMPLOYEE NIK").ToString.Replace("'", "").Replace(" ", "")
                Next

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                If id_pop_up = "45" Then
                    Dim query = From table1 In tb1
                                Group Join table_tmp In tb2
                                On table1("EMPLOYEE NIK").ToString.ToLower Equals table_tmp("employee_nik_sogo").ToString.ToLower Into emp = Group
                                From result_emp In emp.DefaultIfEmpty()
                                Select New With
                            {
                                .IdEmployee = If(result_emp Is Nothing, "", result_emp("id_employee")),
                                .NIK = If(result_emp Is Nothing, "", result_emp("employee_code")),
                                .NIKSogo = If(result_emp Is Nothing, "", result_emp("employee_nik_sogo")),
                                .Name = If(result_emp Is Nothing, "", result_emp("employee_name")),
                                .Position = If(result_emp Is Nothing, "", result_emp("employee_position")),
                                .IdDepartement = If(result_emp Is Nothing, "", result_emp("id_departement")),
                                .Departement = If(result_emp Is Nothing, "", result_emp("departement")),
                                .DepartementSub = If(result_emp Is Nothing, "", result_emp("departement_sub")),
                                .IdEmployeeStatus = If(result_emp Is Nothing, "", result_emp("id_employee_status")),
                                .EmployeeStatus = If(result_emp Is Nothing, "", result_emp("employee_status")),
                                .Date = table1("DATE"),
                                .TimeIn = table1("TIME IN"),
                                .TimeOut = table1("TIME OUT")
                            }

                    GCData.DataSource = Nothing
                    GCData.DataSource = query.ToList()
                Else
                    Dim query = From table1 In tb1
                                Group Join table_tmp In tb2
                                On table1("EMPLOYEE NIK").ToString.ToLower Equals table_tmp("employee_code").ToString.ToLower Into emp = Group
                                From result_emp In emp.DefaultIfEmpty()
                                Select New With
                            {
                                .IdEmployee = If(result_emp Is Nothing, "", result_emp("id_employee")),
                                .NIK = If(result_emp Is Nothing, "", result_emp("employee_code")),
                                .Name = If(result_emp Is Nothing, "", result_emp("employee_name")),
                                .Position = If(result_emp Is Nothing, "", result_emp("employee_position")),
                                .IdDepartement = If(result_emp Is Nothing, "", result_emp("id_departement")),
                                .Departement = If(result_emp Is Nothing, "", result_emp("departement")),
                                .DepartementSub = If(result_emp Is Nothing, "", result_emp("departement_sub")),
                                .IdEmployeeStatus = If(result_emp Is Nothing, "", result_emp("id_employee_status")),
                                .EmployeeStatus = If(result_emp Is Nothing, "", result_emp("employee_status")),
                                .Date = table1("DATE"),
                                .TimeIn = table1("TIME IN"),
                                .TimeOut = table1("TIME OUT")
                            }

                    GCData.DataSource = Nothing
                    GCData.DataSource = query.ToList()
                End If

                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdEmployee").Visible = False
                GVData.Columns("IdDepartement").Visible = False
                GVData.Columns("IdEmployeeStatus").Visible = False
                GVData.Columns("NIK").Caption = "NIK"

                If id_pop_up = "45" Then
                    GVData.Columns("NIKSogo").Caption = "NIK Sogo"
                End If

                GVData.Columns("Departement").Caption = "Departement"
                GVData.Columns("DepartementSub").Caption = "Sub Departement"
                GVData.Columns("EmployeeStatus").Caption = "Employee Status"

                GVData.Columns("Date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("Date").DisplayFormat.FormatString = "dd MMMM yyyy"

                GVData.Columns("TimeIn").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("TimeIn").DisplayFormat.FormatString = "HH:mm:ss"

                GVData.Columns("TimeOut").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("TimeOut").DisplayFormat.FormatString = "HH:mm:ss"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "47" Then 'adj inn
            'vendor code 
            Dim queryx As String = "SELECT p.id_product,p.product_full_code,p.product_name,dsg.design_cop, cd.code_detail_name AS `size`
            FROM tb_m_product p 
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design dsg ON dsg.id_design=p.id_design 
            WHERE dsg.`id_lookup_status_order`!='2'"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("product_code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .id_product = If(y1 Is Nothing, "0", y1("id_product")),
                                .code = table1("product_code").ToString,
                                .name = If(y1 Is Nothing, "0", y1("product_name")),
                                 .size = If(y1 Is Nothing, "0", y1("size")),
                                .qty = table1("qty"),
                                .retail_price = table1("retail_price"),
                                .design_cop = If(y1 Is Nothing, "0", y1("design_cop")),
                                .id_comp = FormFGAdjInDet.id_comp,
                                .comp = FormFGAdjInDet.comp_name,
                                .id_locator = FormFGAdjInDet.id_locator,
                                .locator = FormFGAdjInDet.locator_name,
                                .id_rack = FormFGAdjInDet.id_rack,
                                .rack = FormFGAdjInDet.rack_name,
                                .id_drawer = FormFGAdjInDet.id_drawer,
                                .drawer = FormFGAdjInDet.drawer_name,
                                .note = table1("note"),
                                .Status = If(y1 Is Nothing, "Master product not found", "OK")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp").Visible = False
            GVData.Columns("id_locator").Visible = False
            GVData.Columns("id_rack").Visible = False
            GVData.Columns("id_drawer").Visible = False

            GVData.Columns("code").Caption = "Code"
            GVData.Columns("name").Caption = "Description"
            GVData.Columns("qty").Caption = "Qty"
            GVData.Columns("design_cop").Caption = "Cost"
            GVData.Columns("retail_price").Caption = "Retail Price"
            GVData.Columns("comp").Caption = "Warehouse"
            GVData.Columns("locator").Caption = "Locator"
            GVData.Columns("rack").Caption = "Rack"
            GVData.Columns("drawer").Caption = "Drawer"

            GVData.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("qty").DisplayFormat.FormatString = "N0"
            GVData.Columns("design_cop").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("design_cop").DisplayFormat.FormatString = "N2"
            GVData.Columns("retail_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("retail_price").DisplayFormat.FormatString = "N0"

            'summary
            GVData.OptionsView.ShowFooter = True
            GVData.Columns("qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("qty").SummaryItem.DisplayFormat = "{0:n0}"
        ElseIf id_pop_up = "48" Then
            'vendor code 
            Dim queryx As String = "SELECT p.id_product,p.product_full_code,p.product_name,dsg.design_cop, cd.code_detail_name AS `size`
            FROM tb_m_product p 
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design dsg ON dsg.id_design=p.id_design 
            WHERE dsg.`id_lookup_status_order`!='2' "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("product_code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .id_product = If(y1 Is Nothing, "0", y1("id_product")),
                                .code = table1("product_code").ToString,
                                .name = If(y1 Is Nothing, "0", y1("product_name")),
                                .size = If(y1 Is Nothing, "0", y1("size")),
                                .qty = table1("qty"),
                                .retail_price = table1("retail_price"),
                                .design_cop = If(y1 Is Nothing, "0", y1("design_cop")),
                                .id_comp = FormFGAdjOutDet.id_comp,
                                .comp = FormFGAdjOutDet.comp_name,
                                .id_locator = FormFGAdjOutDet.id_locator,
                                .locator = FormFGAdjOutDet.locator_name,
                                .id_rack = FormFGAdjOutDet.id_rack,
                                .rack = FormFGAdjOutDet.rack_name,
                                .id_drawer = FormFGAdjOutDet.id_drawer,
                                .drawer = FormFGAdjOutDet.drawer_name,
                                .note = table1("note"),
                                .Status = If(y1 Is Nothing, "Master product not found", "OK")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp").Visible = False
            GVData.Columns("id_locator").Visible = False
            GVData.Columns("id_rack").Visible = False
            GVData.Columns("id_drawer").Visible = False

            GVData.Columns("code").Caption = "Code"
            GVData.Columns("name").Caption = "Description"
            GVData.Columns("size").Caption = "Size"
            GVData.Columns("qty").Caption = "Qty"
            GVData.Columns("design_cop").Caption = "Cost"
            GVData.Columns("retail_price").Caption = "Retail Price"
            GVData.Columns("comp").Caption = "Warehouse"
            GVData.Columns("locator").Caption = "Locator"
            GVData.Columns("rack").Caption = "Rack"
            GVData.Columns("drawer").Caption = "Drawer"

            GVData.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("qty").DisplayFormat.FormatString = "N0"
            GVData.Columns("design_cop").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("design_cop").DisplayFormat.FormatString = "N2"
            GVData.Columns("retail_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("retail_price").DisplayFormat.FormatString = "N0"

            'summary
            GVData.OptionsView.ShowFooter = True
            GVData.Columns("qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("qty").SummaryItem.DisplayFormat = "{0:n0}"
        ElseIf id_pop_up = "49" Then 'import tracking number collection
            Dim queryx As String = "SELECT id_track_no,track_no FROM tb_3pl_track_no
            WHERE `id_comp`='" & FormWHAwbillTrackCollection.SLECargo.EditValue.ToString & "' "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("track_no").ToString Equals table_tmp("track_no").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .Vendor = FormWHAwbillTrackCollection.SLECargo.Text,
                                .track_no = table1("track_no"),
                                .status = If(y1 Is Nothing, "OK", "Tracking Number already registered")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("track_no").Caption = "Tracking Number"
            GVData.Columns("status").Caption = "Description"
        ElseIf id_pop_up = "50" Then
            Dim id_vios As String = get_setup_field("shopify_comp_group")
            Dim queryx As String = "(SELECT ol.id_list_payout, ol.id AS `id_order`, ol.checkout_id,ol.sales_order_ol_shop_number, ol.payment AS curr_payout,
            ol.trans_fee AS curr_fee,ol.pay_type AS curr_pay_type,SUM(((pos.`sales_pos_total`*((100-pos.sales_pos_discount)/100))-pos.`sales_pos_potongan`))+IFNULL(sh.ship_amo,0)+IFNULL(v.value,0.00) AS amount,IFNULL(v.value,0.00) AS `other_price`,
            GROUP_CONCAT(DISTINCT(pos.`sales_pos_number`)) AS inv_number, sh.ship_number AS `ship_inv_number`, v.number AS `ver_number`,
            GROUP_CONCAT(DISTINCT(pos.`id_sales_pos`)) AS id_sales_pos, IFNULL(sh.id_invoice_ship,0) AS `id_invoice_ship`, IFNULL(v.id_list_payout_ver,0) AS `id_list_payout_ver`
            FROM
            (
	            SELECT ol.*,lp.`payment`,lp.`trans_fee`,lp.pay_type, lp.id_list_payout, SUM(ol.other_price * ol.sales_order_det_qty) AS `other_price_sum`
	            FROM tb_ol_store_order ol
	            LEFT JOIN tb_list_payout lp ON lp.id=ol.`id`
                LEFT JOIN tb_list_payout_trans tr ON tr.id_list_payout_trans = lp.id_list_payout_trans AND tr.id_report_status!=5
	            WHERE NOT ISNULL(ol.`checkout_id`) AND ol.id_comp_group=" + id_vios + "
	            GROUP BY ol.`id`
            ) ol
            INNER JOIN tb_sales_order so ON so.`id_sales_order_ol_shop`=ol.`id`
            INNER JOIN `tb_pl_sales_order_del` del ON del.`id_sales_order`=so.`id_sales_order`
            INNER JOIN tb_sales_pos pos ON pos.`id_pl_sales_order_del`=del.`id_pl_sales_order_del` AND pos.id_report_status=6 AND pos.is_close_rec_payment=2
            LEFT JOIN (
                SELECT s.id_invoice_ship, s.id_report, s.`number` AS `ship_number`, s.`value` AS `ship_amo`
                FROM tb_invoice_ship s
                WHERE s.id_report_status=6
                GROUP BY s.id_report
            ) sh ON sh.id_report = ol.id
            LEFT JOIN (
                SELECT v.id_list_payout_ver, v.id_web_order, v.number, SUM(IF(d.id_dc=1,(d.value * -1),d.value)) AS `value`
                FROM tb_list_payout_ver_det d
                INNER JOIN tb_list_payout_ver v ON v.id_list_payout_ver = d.id_list_payout_ver
                WHERE v.is_existing_order=1
                GROUP BY v.checkout_id
            ) v ON v.id_web_order = ol.id
            GROUP BY ol.id )
            UNION ALL
            (SELECT ol.id_list_payout, 0 AS `id_order`, ol.checkout_id AS `checkout_id`,ol.order_number AS sales_order_ol_shop_number, ol.payment AS curr_payout,
            ol.trans_fee AS curr_fee,ol.pay_type AS curr_pay_type,SUM(IFNULL(ol.value,0.00)) AS amount,IFNULL(ol.value,0.00) AS `other_price`,
            '' AS inv_number, '' AS `ship_inv_number`, ol.number AS `ver_number`,
            0 AS id_sales_pos, 0 AS `id_invoice_ship`, IFNULL(ol.id_list_payout_ver,0) AS `id_list_payout_ver`
            FROM (
	            SELECT v.*,lp.`payment`,
	            lp.`trans_fee`,lp.pay_type, lp.id_list_payout, SUM(IF(d.id_dc=1,(d.value * -1),d.value)) AS `value`
	            FROM tb_list_payout_ver v 
	            INNER JOIN tb_list_payout_ver_det d ON d.id_list_payout_ver = v.id_list_payout_ver
	            LEFT JOIN tb_list_payout lp ON lp.checkout_id = v.checkout_id
	            WHERE v.is_existing_order=2 AND v.type_ver=1
	            GROUP BY v.checkout_id
            ) ol
            GROUP BY ol.checkout_id) "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable() 'ini tabel excel table1
            Dim tb2 = dt.AsEnumerable()

            'formula type
            Dim qf As String = "SELECT f.id_payout_fee, f.payout_fee_name, f.payout_multiply, f.payout_add, f.minimum FROM tb_lookup_payout_fee f "
            Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
            Dim tb3 = df.AsEnumerable


            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("Order").ToString Equals table_tmp("checkout_id").ToString
                            Into ord = Group
                        From y1 In ord.DefaultIfEmpty()
                        Group Join table_typ In tb3 On table1("Payment Type").ToString Equals table_typ("payout_fee_name").ToString
                            Into typ = Group
                        From f1 In typ.DefaultIfEmpty()
                        Select New With
                            {
                                .checkout_id = table1("Order"),
                                .id_order = If(y1 Is Nothing, "0", y1("id_order")),
                                .id_sales_pos = If(y1 Is Nothing, "0", y1("id_sales_pos")),
                                .id_invoice_ship = If(y1 Is Nothing, "0", y1("id_invoice_ship")),
                                .id_list_payout_ver = If(y1 Is Nothing, "0", y1("id_list_payout_ver")),
                                .order_ol_shop_number = If(y1 Is Nothing, "0", y1("sales_order_ol_shop_number")),
                                .inv_number = If(y1 Is Nothing, "0", y1("inv_number")),
                                .ship_inv_number = If(y1 Is Nothing, "0", y1("ship_inv_number")),
                                .curr_payout = If(y1 Is Nothing, "0", y1("curr_payout")),
                                .curr_fee = If(y1 Is Nothing, 0, y1("curr_fee")),
                                .curr_pay_type = If(y1 Is Nothing, "0", y1("curr_pay_type")),
                                .id_pay_type = If(f1 Is Nothing, "0", f1("id_payout_fee")),
                                .pay_type = table1("Payment Type").ToString,
                                .bank = table1("Acquiring Bank").ToString,
                                .payout = table1("Amount"),
                                .fee = table1("Transaction Fee"),
                                .amount_inv = If(y1 Is Nothing, 0, y1("amount")),
                                .calc_fee = If(f1 Is Nothing, 0, If((If(y1 Is Nothing, 0, y1("amount")) * f1("payout_multiply") + f1("payout_add")) <= f1("minimum"), f1("minimum"), (If(y1 Is Nothing, 0, y1("amount")) * f1("payout_multiply") + f1("payout_add")))),
                                .other_price = If(y1 Is Nothing, 0.00, y1("other_price")),
                                .settle_datetime = Date.Parse(table1("Settlement Time").ToString.Split(",")(0).Trim & " " & table1("Settlement Time").ToString.Split(",")(1).Trim),
                                .Status = If(f1 Is Nothing, "Fee type not found", If(y1 Is Nothing, "Checkout id Not Found", If(y1("curr_fee").ToString = "", If(table1("Amount") = If(y1 Is Nothing, 0, y1("amount")), If(Decimal.Parse(table1("Transaction Fee").ToString) = Decimal.Parse((If(f1 Is Nothing, 0, If((If(y1 Is Nothing, 0, y1("amount")) * f1("payout_multiply") + f1("payout_add")) <= f1("minimum"), f1("minimum"), (If(y1 Is Nothing, 0, y1("amount")) * f1("payout_multiply") + f1("payout_add"))))).ToString), "OK", "Fee Not Match"), "Amount not match"), "Already imported")))
                                }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_sales_pos").Visible = False
            GVData.Columns("id_invoice_ship").Visible = False
            GVData.Columns("id_list_payout_ver").Visible = False

            GVData.Columns("order_ol_shop_number").Caption = "Order#"
            GVData.Columns("inv_number").Caption = "Invoice Number"
            GVData.Columns("ship_inv_number").Caption = "Shipping Invoice"
            GVData.Columns("amount_inv").Caption = "Amount Invoice"

            GVData.Columns("curr_payout").Caption = "Current Payout"
            GVData.Columns("curr_fee").Caption = "Current Fee"
            GVData.Columns("curr_pay_type").Caption = "Current Pay Type"
            GVData.Columns("curr_payout").Visible = False
            GVData.Columns("curr_fee").Visible = False
            GVData.Columns("curr_pay_type").Visible = False

            GVData.Columns("pay_type").Caption = "Pay Type"
            GVData.Columns("bank").Caption = "Bank"
            GVData.Columns("payout").Caption = "Payout"
            GVData.Columns("fee").Caption = "Fee"
            GVData.Columns("calc_fee").Caption = "System Calculated Fee"
            GVData.Columns("Status").Caption = "Status"
            GVData.Columns("settle_datetime").Caption = "Settlement Time"

            GVData.Columns("settle_datetime").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("settle_datetime").DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"

            GVData.Columns("payout").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("payout").DisplayFormat.FormatString = "N2"
            GVData.Columns("fee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("fee").DisplayFormat.FormatString = "N2"
            GVData.Columns("calc_fee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("calc_fee").DisplayFormat.FormatString = "N2"

            GVData.Columns("curr_payout").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("curr_payout").DisplayFormat.FormatString = "N2"
            GVData.Columns("curr_fee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("curr_fee").DisplayFormat.FormatString = "N2"
            GVData.Columns("amount_inv").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("amount_inv").DisplayFormat.FormatString = "N2"
            GVData.Columns("other_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("other_price").DisplayFormat.FormatString = "N2"

            'summary
            GVData.OptionsView.ShowFooter = True
            GVData.Columns("payout").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("payout").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("fee").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("amount_inv").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("amount_inv").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("calc_fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("calc_fee").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("other_price").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("other_price").SummaryItem.DisplayFormat = "{0:n2}"
        ElseIf id_pop_up = "51" Then
            Dim tb1 = data_temp.AsEnumerable() 'ini tabel excel table1
            Dim query_prod As String = "SELECT d.id_design, prod.id_product, d.design_code AS `code`, prod.product_full_code AS `sku`, 
            d.design_display_name AS `description`, cd.code_detail_name AS `size`,
            IFNULL(p.id_design_price,0) AS `id_design_price`, IFNULL(p.design_price,0) AS `design_price`
            FROM tb_m_design d 
            INNER JOIN tb_m_product prod ON prod.id_design = d.id_design
            INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
            LEFT JOIN (
				SELECT prc.id_design, prc.id_design_price, prc.design_price , prc.id_design_cat, prc.design_cat, prc.`price_type`
				FROM (
					SELECT prc.id_design, prc.id_design_price, prc.design_price, cat.id_design_cat, cat.design_cat, prct.design_price_type AS `price_type`  
					FROM tb_m_design_price prc
					INNER JOIN tb_lookup_design_price_type prct ON prct.id_design_price_type = prc.id_design_price_type
					INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = prct.id_design_cat
					WHERE design_price_start_date<=DATE(NOW()) AND is_active_wh = 1 AND is_design_cost=0
					ORDER BY design_price_start_date DESC, id_design_price DESC
				) prc
				GROUP BY id_design
			) p ON p.id_design = d.id_design
            WHERE d.id_lookup_status_order!=2 
            ORDER BY d.design_display_name ASC, cd.id_code_detail ASC "
            Dim dt As DataTable = execute_query(query_prod, -1, True, "", "", "", "")
            Dim tb2 = dt.AsEnumerable() 'ini tabel excel table1
            'get shopify
            FormPromoCollectionDet.getProductShopify()
            Dim tb3 = FormPromoCollectionDet.dt
            'data stock
            Dim qgt As String = "SET @startd = DATE(NOW());
            SET @cm_beg_startd = "";
	        SET @beg_date="";
	        SET @beg_year ="";
	        SET @beg_month ="";
            SELECT STR_TO_DATE(CONCAT(YEAR(@startd),'-', MONTH(@startd),'-', '01'),'%Y-%m-%d') AS `cm_beg_startd`,
	        STR_TO_DATE(DATE_SUB(CONCAT(YEAR(@startd),'-', MONTH(@startd),'-', '01'),INTERVAL 1 DAY),'%Y-%m-%d') AS `beg_date`, 
	        YEAR((SELECT beg_date)) AS `beg_year`, MONTH((SELECT beg_date)) AS `beg_month`, @startd AS `end_date` "
            Dim dgt As DataTable = execute_query(qgt, -1, True, "", "", "", "")
            Dim beg_month As String = dgt.Rows(0)("beg_month").ToString
            Dim beg_year As String = dgt.Rows(0)("beg_year").ToString
            Dim start_time As String = DateTime.Parse(dgt.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd")
            Dim end_time As String = DateTime.Parse(dgt.Rows(0)("end_date").ToString).ToString("yyyy-MM-dd")
            Dim id_ol As String = execute_query("SELECT GROUP_CONCAT(DISTINCT d.id_comp) FROM tb_m_comp_volcom_ol d", 0, True, "", "", "", "")
            Dim query_stc As String = "SELECT p.product_full_code AS `code`, a.qty_ttl AS `qty` 
            FROM (
                SELECT a.id_product,
                SUM(qty_ttl) AS `qty_ttl`
                FROM (
	                SELECT f.id_wh_drawer, f.id_product, f.`qty_ttl`
	                FROM tb_storage_fg_" + beg_year + " f
	                WHERE f.month='" + beg_month + "'
	                UNION ALL
	                SELECT f.id_wh_drawer, f.id_product, 
	                SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `qty_ttl` 
	                FROM tb_storage_fg f
	                WHERE f.storage_product_datetime>='" + start_time + " 00:00:00'  AND f.storage_product_datetime<='" + end_time + " 23:59:59' 
	                GROUP BY f.id_wh_drawer, f.id_product
                ) a
                INNER JOIN tb_m_wh_drawer drw ON  drw.id_wh_drawer= a.id_wh_drawer
                INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
                INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
                WHERE loc.id_comp IN (" + id_ol + ")
                GROUP BY a.id_product 
                HAVING qty_ttl>0
            ) a
            INNER JOIN tb_m_product p ON p.id_product = a.id_product "
            Dim data_stc As DataTable = execute_query(query_stc, -1, True, "", "", "", "")
            Dim tb4 = data_stc.AsEnumerable

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("KODE").ToString Equals table_tmp("code").ToString
                        Into ord = Group
                        From y1 In ord.DefaultIfEmpty()
                        Group Join table_web In tb3 On If(y1 Is Nothing, "", y1("sku").ToString) Equals table_web("sku").ToString
                        Into web = Group
                        From w1 In web.DefaultIfEmpty()
                        Group Join table_stock In tb4 On If(y1 Is Nothing, "", y1("sku").ToString) Equals table_stock("code").ToString
                        Into stc = Group
                        From s1 In stc.DefaultIfEmpty
                        Select New With
                            {
                                .id_design = If(y1 Is Nothing, "0", y1("id_design").ToString),
                                .id_product = If(y1 Is Nothing, "0", y1("id_product").ToString),
                                .id_prod_shopify = If(w1 Is Nothing, "0", w1("product_id").ToString),
                                .code = table1("KODE").ToString,
                                .sku = If(y1 Is Nothing, "", y1("sku").ToString),
                                .description = If(y1 Is Nothing, "", y1("description").ToString),
                                .size = If(y1 Is Nothing, "", y1("size").ToString),
                                .id_design_price = If(y1 Is Nothing, "0", y1("id_design_price").ToString),
                                .design_price = If(y1 Is Nothing, 0, y1("design_price")),
                                .qty = If(s1 Is Nothing, 0, s1("qty")),
                                .is_block = table1("replace_stock").ToString,
                                .replace = If(table1("replace_stock").ToString = "1", "Not Active", "Active"),
                                .Status = If(y1 Is Nothing Or w1 Is Nothing, If(y1 Is Nothing, "Not found in ERP;", "") + If(w1 Is Nothing, "Not found in Shopify;", ""), "OK")
                            }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_prod_shopify").Visible = False
            GVData.Columns("id_design_price").Visible = False
            GVData.Columns("is_block").Visible = False

            'display format
            GVData.Columns("design_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("design_price").DisplayFormat.FormatString = "N0"
            GVData.Columns("qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("qty").DisplayFormat.FormatString = "N0"
        ElseIf id_pop_up = "52" Then 'import rate
            Dim queryx As String = "SELECT sd.`id_sub_district`,ct.`city`,sd.`sub_district`
FROM tb_m_sub_district sd 
INNER JOIN tb_m_city ct ON ct.`id_city`=sd.`id_city`"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("city").ToString Equals table_tmp("city").ToString And table1("sub_district").ToString Equals table_tmp("sub district").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .id_sub_district = FormWHAwbillTrackCollection.SLECargo.Text,
                                .min_weight = table1("minimum weight"),
                                .city = If(y1 Is Nothing, "", y1("city").ToString),
                                .sub_district = If(y1 Is Nothing, "", y1("sub_district").ToString),
                                .lead_time = table1("lead time"),
                                .rate = table1("rate"),
                                .status = If(y1 Is Nothing, "Sub District not found", "OK")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_sub_district").Visible = False
        ElseIf id_pop_up = "53" Then 'import VA BBM
            Dim id_vios As String = get_setup_field("shopify_comp_group")
            Dim queryx As String = "(SELECT ol.id_virtual_acc_trans, ol.id AS `id_order`, ol.checkout_id, IFNULL(v.value,0.00) AS `other_price`,ol.sales_order_ol_shop_number,
            SUM(CAST(((pos.`sales_pos_total`*((100-pos.sales_pos_discount)/100))-pos.`sales_pos_potongan`) AS DECIMAL(15,2)))+IFNULL(sh.ship_amo,0)+IFNULL(v.value,0.00) AS amount,
            GROUP_CONCAT(DISTINCT(pos.`sales_pos_number`)) AS inv_number, sh.ship_number AS `ship_inv_number`,v.number AS `ver_number`,
            GROUP_CONCAT(DISTINCT(pos.`id_sales_pos`)) AS id_sales_pos, IFNULL(sh.id_invoice_ship,0) AS `id_invoice_ship`,  IFNULL(v.id_list_payout_ver,0) AS `id_list_payout_ver`
            FROM (
	            SELECT ol.id, ol.checkout_id,ol.sales_order_ol_shop_number,
	            IFNULL(lp.id_virtual_acc_trans,0) AS `id_virtual_acc_trans`, SUM(ol.other_price * ol.sales_order_det_qty) AS `other_price_sum`
	            FROM tb_ol_store_order ol
	            LEFT JOIN tb_virtual_acc_trans_det lp ON lp.id =ol.`id`
                LEFT JOIN tb_virtual_acc_trans l ON l.id_virtual_acc_trans = lp.id_virtual_acc_trans AND l.id_report_status!=5
	            WHERE NOT ISNULL(ol.`checkout_id`) AND ol.id_comp_group=" + id_vios + "
	            GROUP BY ol.`id`
            ) ol
            INNER JOIN tb_sales_order so ON so.`id_sales_order_ol_shop`=ol.`id`
            INNER JOIN `tb_pl_sales_order_del` del ON del.`id_sales_order`=so.`id_sales_order`
            INNER JOIN tb_sales_pos pos ON pos.`id_pl_sales_order_del`=del.`id_pl_sales_order_del` AND pos.id_report_status=6 AND pos.is_close_rec_payment=2
            LEFT JOIN (
                SELECT s.id_invoice_ship, s.id_report, s.`number` AS `ship_number`, s.`value` AS `ship_amo`
                FROM tb_invoice_ship s
                WHERE s.id_report_status=6
                GROUP BY s.id_report
            ) sh ON sh.id_report = ol.id
            LEFT JOIN (
                SELECT v.id_list_payout_ver, v.id_web_order, v.number, SUM(IF(d.id_dc=1,(d.value * -1),d.value)) AS `value`
                FROM tb_list_payout_ver_det d
                INNER JOIN tb_list_payout_ver v ON v.id_list_payout_ver = d.id_list_payout_ver
                WHERE v.is_existing_order=1
                GROUP BY v.checkout_id
            ) v ON v.id_web_order = ol.id
            GROUP BY ol.id) 
            UNION ALL
            (SELECT ol.id_virtual_acc_trans, 0 AS `id_order`, ol.checkout_id AS `checkout_id`, IFNULL(ol.value,0.00) AS `other_price`,ol.order_number AS sales_order_ol_shop_number,
            SUM(IFNULL(ol.value,0.00)) AS amount,
            '' AS inv_number, '' AS `ship_inv_number`, ol.number AS `ver_number`,
            0 AS id_sales_pos, 0 AS `id_invoice_ship`, IFNULL(ol.id_list_payout_ver,0) AS `id_list_payout_ver`
            FROM (
                SELECT v.*,lp.`amount`,
                IFNULL(lp.id_virtual_acc_trans,0) AS `id_virtual_acc_trans`, SUM(IF(d.id_dc=1,(d.value * -1),d.value)) AS `value`
                FROM tb_list_payout_ver v 
                INNER JOIN tb_list_payout_ver_det d ON d.id_list_payout_ver = v.id_list_payout_ver
                LEFT JOIN tb_virtual_acc_trans_det lp ON lp.checkout_id = v.checkout_id
                WHERE v.is_existing_order=2 AND v.type_ver=2
                GROUP BY v.checkout_id
            ) ol
            GROUP BY ol.checkout_id) "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable() 'ini tabel excel table1
            Dim tb2 = dt.AsEnumerable()

            'data virtual
            Dim dv As DataTable = execute_query("SELECT column_name,payout_multiply,payout_add, minimum FROM tb_virtual_acc WHERE id_virtual_acc='" + FormBankDeposit.SLEBank.EditValue.ToString + "' ", -1, True, "", "", "", "")
            Dim col_name As String = dv.Rows(0)("column_name").ToString
            Dim payout_multiply As Decimal = dv.Rows(0)("payout_multiply")
            Dim payout_add As Decimal = dv.Rows(0)("payout_add")
            Dim minimum As Decimal = dv.Rows(0)("minimum")

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("Order ID").ToString.Replace("'", "") Equals table_tmp("checkout_id").ToString
                        Into ord = Group
                        From y1 In ord.DefaultIfEmpty()
                        Select New With {
                            .checkout_id = table1("Order ID").ToString.Replace("'", ""),
                            .virtual_acc_no = table1(col_name).ToString.Replace("'", ""),
                            .id_order = If(y1 Is Nothing, "0", y1("id_order").ToString),
                            .id_virtual_acc_trans = If(y1 Is Nothing, "0", y1("id_virtual_acc_trans").ToString),
                            .id_sales_pos = If(y1 Is Nothing, "0", y1("id_sales_pos").ToString),
                            .id_invoice_ship = If(y1 Is Nothing, "0", y1("id_invoice_ship").ToString),
                            .id_list_payout_ver = If(y1 Is Nothing, "0", y1("id_list_payout_ver").ToString),
                            .order_ol_shop_number = If(y1 Is Nothing, "0", y1("sales_order_ol_shop_number").ToString),
                            .inv_number = If(y1 Is Nothing, "0", y1("inv_number").ToString),
                            .ship_inv_number = If(y1 Is Nothing, "0", y1("ship_inv_number").ToString),
                            .payment_type = table1("Payment Type").ToString,
                            .transaction_status = table1("Transaction status").ToString,
                            .transaction_time = table1("Transaction time").ToString,
                            .amount = table1("Amount"),
                            .amount_inv = If(y1 Is Nothing, 0, y1("amount")),
                            .transaction_fee = table1("Amount") * payout_multiply + payout_add,
                            .other_price = If(y1 Is Nothing, 0, y1("other_price")),
                            .Status = If(y1 Is Nothing Or If(y1 Is Nothing, "0", y1("id_virtual_acc_trans").ToString) <> "0" Or table1("Amount") <> If(y1 Is Nothing, 0, y1("amount")), If(y1 Is Nothing, "Checkout id not found;", "") + If(If(y1 Is Nothing, "0", y1("id_virtual_acc_trans").ToString) <> "0", "Already imported;", "") + If(table1("Amount") <> If(y1 Is Nothing, 0, y1("amount")), "Amount not match;", ""), "OK")
                        }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_sales_pos").Visible = False
            GVData.Columns("id_invoice_ship").Visible = False
            GVData.Columns("id_list_payout_ver").Visible = False
            GVData.Columns("id_virtual_acc_trans").Visible = False
            GVData.Columns("id_order").Visible = False

            GVData.Columns("checkout_id").Caption = "Checkout ID"
            GVData.Columns("virtual_acc_no").Caption = "Virtual Acc No"
            GVData.Columns("order_ol_shop_number").Caption = "Order#"
            GVData.Columns("inv_number").Caption = "Invoice Number"
            GVData.Columns("ship_inv_number").Caption = "Shipping Invoice"
            GVData.Columns("other_price").Caption = "Other Price"
            GVData.Columns("amount_inv").Caption = "Amount Invoice (Include Other Price)"
            GVData.Columns("amount").Caption = "Amount Payment Gateway"
            GVData.Columns("transaction_fee").Caption = "Fee"
            GVData.Columns("payment_type").Caption = "Payment Type"

            'display form
            GVData.Columns("other_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("other_price").DisplayFormat.FormatString = "N2"
            GVData.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("amount").DisplayFormat.FormatString = "N2"
            GVData.Columns("amount_inv").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("amount_inv").DisplayFormat.FormatString = "N2"
            GVData.Columns("transaction_fee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("transaction_fee").DisplayFormat.FormatString = "N2"

            'summary
            GVData.OptionsView.ShowFooter = True
            GVData.Columns("other_price").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("other_price").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("amount").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("amount_inv").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("amount_inv").SummaryItem.DisplayFormat = "{0:n2}"
            GVData.Columns("transaction_fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("transaction_fee").SummaryItem.DisplayFormat = "{0:n2}"
        ElseIf id_pop_up = "54" Then
            If FormOLStore.SLEOLStore.EditValue = "77" Then
                'SHOPEE
                'get size
                Dim query_size As String = "SELECT d.id_code_detail, d.id_code, d.code, IF(d.code_detail_name='ALL', 'One Size', d.code_detail_name) AS  code_detail_name
                FROM tb_m_code_detail d WHERE d.id_code IN (SELECT o.id_code_product_size FROM tb_opt o) "
                Dim dt_size As DataTable = execute_query(query_size, -1, True, "", "", "", "")
                'get order yang tersimpan
                Dim query_order As String = "SELECT d.sales_order_ol_shop_number 
                FROM tb_ol_store_order d WHERE d.id_comp_group=77
                GROUP BY d.sales_order_ol_shop_number "
                Dim dt_order As DataTable = execute_query(query_order, -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable() 'ini tabel excel table1
                Dim tb2 = dt_size.AsEnumerable()
                Dim tb3 = dt_order.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_ord In tb3 On table_ord("sales_order_ol_shop_number").ToString Equals table1("No# Pesanan").ToString
                            Into join_ord = Group
                            From o1 In join_ord.DefaultIfEmpty()
                            Select New With {
                                .id_comp_group = "77",
                                .sales_order_ol_shop_number = table1("No# Pesanan").ToString,
                                .ol_store_sku = table1("Nomor Referensi SKU").ToString,
                                .ol_store_id = table1("No# Pesanan").ToString + table1("Nomor Referensi SKU").ToString,
                                .item_id = "",
                                .checkout_id = "",
                                .tracking_code = table1("No# Resi").ToString,
                                .sales_order_ol_shop_date = DateTime.ParseExact(table1("Waktu Pesanan Dibuat").ToString, "yyyy-MM-dd HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                                .main_code = table1("SKU Induk").ToString,
                                .product_name = table1("Nama Produk").ToString,
                                .size = table1("Nama Variasi").ToString,
                                .sku = table1("Nomor Referensi SKU").ToString,
                                .design_price = Decimal.Parse(Trim(table1("Harga Setelah Diskon").ToString.Replace("Rp", "").Replace(".", "").Replace(",", ""))),
                                .sales_order_det_qty = Decimal.Parse(table1("Jumlah").ToString),
                                .grams = Decimal.Parse(table1("Berat Produk").ToString.Replace("gr", "").Replace(".", "").Replace(",", "").Trim),
                                .total_disc_order = Decimal.Parse(Trim(table1("Total Diskon").ToString.Replace("Rp", "").Replace(".", "").Replace(",", ""))),
                                .discount_allocations_amo = 0,
                                .discount_allocations_ol_shop = Decimal.Parse(Trim(table1("Diskon Dari Shopee").ToString.Replace("Rp", "").Replace(".", "").Replace(",", ""))),
                                .customer_name = table1("Username (Pembeli)").ToString,
                                .shipping_name = table1("Nama Penerima").ToString,
                                .shipping_address = table1("Alamat Pengiriman").ToString,
                                .shipping_address1 = "",
                                .shipping_address2 = "",
                                .shipping_phone = table1("No# Telepon").ToString,
                                .shipping_city = table1("Kota/Kabupaten").ToString,
                                .shipping_post_code = "",
                                .shipping_region = table1("Provinsi").ToString,
                                .shipping_district = "",
                                .payment_method = "",
                                .Status = If(Not o1 Is Nothing Or table1("Status Pesanan").ToString <> "Perlu Dikirim" Or table1("Jumlah") = 0 Or table1("Jumlah").ToString = "", If(Not o1 Is Nothing, "Order already exist;", "") + If(table1("Status Pesanan").ToString <> "Perlu Dikirim", "Invalid status;", "") + If(table1("Jumlah") = 0 Or table1("Jumlah").ToString = "", "Qty not valid;", ""), "OK")
                            }
                '.discount_allocations_amo = Decimal.Parse(Trim(table1("Diskon Dari Penjual").ToString.Replace("Rp", "").Replace(".", "").Replace(",", ""))),

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            End If
            'Customize column
            GVData.Columns("id_comp_group").Visible = False
            GVData.Columns("sales_order_ol_shop_number").Caption = "Order No."
            GVData.Columns("sales_order_ol_shop_date").Caption = "Order Date"
            GVData.Columns("sales_order_det_qty").Caption = "Qty"
            GVData.Columns("total_disc_order").Caption = "Total Discount"
            GVData.Columns("discount_allocations_amo").Caption = "Discount Allocation (Seller)"
            GVData.Columns("discount_allocations_ol_shop").Caption = "Discount Allocation (Shopee)"
            GVData.Columns("Status").Caption = "Format Status"
            'display form
            GVData.Columns("design_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("design_price").DisplayFormat.FormatString = "N2"
            GVData.Columns("grams").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("grams").DisplayFormat.FormatString = "N2"
            GVData.Columns("total_disc_order").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("total_disc_order").DisplayFormat.FormatString = "N2"
            GVData.Columns("discount_allocations_amo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("discount_allocations_amo").DisplayFormat.FormatString = "N2"
            GVData.Columns("discount_allocations_ol_shop").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("discount_allocations_ol_shop").DisplayFormat.FormatString = "N2"
            GVData.Columns("sales_order_ol_shop_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("sales_order_ol_shop_date").DisplayFormat.FormatString = "{dd MMMM yyyy HH:mm:ss}"
            'summary
            GVData.OptionsView.ShowFooter = True
            GVData.OptionsCustomization.AllowSort = False
            GVData.OptionsCustomization.AllowFilter = False
            GVData.OptionsView.ColumnAutoWidth = False
            GVData.BestFitColumns()
            GVData.Columns("sales_order_det_qty").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVData.Columns("sales_order_det_qty").SummaryItem.DisplayFormat = "{0:n2}"
        ElseIf id_pop_up = "55" Then
            GCData.DataSource = Nothing
            GCData.DataSource = data_temp
            GCData.RefreshDataSource()
            GVData.PopulateColumns()
        ElseIf id_pop_up = "56" Then
            'import excel ol promo replace
            Dim dt_promo As DataTable = execute_query("SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
            prod.id_design, prod.id_product, d.design_code,prod.product_full_code AS `code`, d.design_display_name AS `name`, 
            cd.code_detail_name AS `size`, pd.id_prod_shopify, pd.current_tag, pd.id_design_price,pd.design_price, design_price_type AS `price_type`, pd.qty,
            pd.is_block, IF(pd.is_block=1,'Not Active', 'Active') AS `is_block_view`, 0.00 AS order_qty
            FROM tb_ol_promo_collection_sku pd
            INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
            INNER JOIN tb_m_design d ON d.id_design = prod.id_design
            INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
            LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
            LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
            WHERE pd.id_ol_promo_collection=" + FormSalesOrderDet.id_ol_promo + " AND pd.is_block=2
            ORDER BY d.design_display_name ASC, prod.product_full_code ASC", -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable() 'ini tabel excel table1
            Dim tb2 = FormSalesOrderDet.dt.AsEnumerable()
            Dim tb3 = dt_promo.AsEnumerable
            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("product_full_code").ToString
                        Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Group Join table_prm In tb3 On table1("code").ToString Equals table_prm("code").ToString
                        Into join_prm = Group
                        From y2 In join_prm.DefaultIfEmpty()
                        Select New With
                        {
                            .Code = table1.Field(Of String)("code"),
                            .Style = If(y1 Is Nothing, "", y1("design_display_name")),
                            .Size = If(y1 Is Nothing, "", y1("Size")),
                            .Price = If(y1 Is Nothing, 0.0, y1("design_price")),
                            .Available = If(y1 Is Nothing, 0, y1("total_allow")),
                            .Qty = If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)),
                            .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                            .id_design_cat = If(y1 Is Nothing, 0, y1("id_design_cat")),
                            .id_product = If(y2 Is Nothing, 0, y2("id_product")),
                            .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                            .id_design_type = If(y1 Is Nothing, 0, y1("id_design_type")),
                            .design_price_type = If(y1 Is Nothing, 0, y1("design_price_type")),
                            .Status = If(y2 Is Nothing, "Not found", If(If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)) > If(y1 Is Nothing, 0, y1("total_allow")), "Input qty exceed available qty", "OK")),
                            .DesignType = If(y1 Is Nothing, "", y1("design_type")),
                            .id_ol_promo_collection_sku_replace = If(y2 Is Nothing, 0, y2("id_ol_promo_collection_sku"))
                        }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("id_design_price").Visible = False
            GVData.Columns("id_design_cat").Visible = False
            GVData.Columns("design_price_type").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_design_type").Visible = False
            GVData.Columns("id_ol_promo_collection_sku_replace").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Price").VisibleIndex = 3
            GVData.Columns("Available").VisibleIndex = 4
            GVData.Columns("Qty").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
            GVData.Columns("DesignType").VisibleIndex = 7
            GVData.Columns("Available").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Available").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
        End If
        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub
    Private Sub BBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowse.Click
        Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            'use save as
            Dim open_file As String = ""
            If is_save_as Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "file_temp.xls"
                Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                Dim temp As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)
                'delete file
                Try
                    My.Computer.FileSystem.DeleteFile(path)
                Catch ex As Exception
                End Try
                temp.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
                temp.Close()
                app.Quit()
                open_file = path
                Cursor = Cursors.Default
            Else
                open_file = fdlg.FileName
            End If
            TBFileAddress.Text = ""
            TBFileAddress.Text = open_file
        End If
        fdlg.Dispose()
    End Sub

    Private Sub GVData_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If id_pop_up = "1" Then
            Dim id_sample_price As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_sample_price"))
            'condition
            If Not id_sample_price = "" Then
                If id_sample_price = "0" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        ElseIf id_pop_up = "2" Then
            Dim id_sample As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_sample"))
            'condition
            If Not id_sample = "" Then
                If id_sample = "0" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        ElseIf id_pop_up = "6" Or id_pop_up = "7" Then
            Dim diff As Decimal = sender.GetRowCellValue(e.RowHandle, sender.Columns("Diff"))
            If diff > 0.0 Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        ElseIf id_pop_up = "11" Or id_pop_up = "13" Or id_pop_up = "14" Or id_pop_up = "15" Or id_pop_up = "17" Or id_pop_up = "19" Or id_pop_up = "20" Or id_pop_up = "21" Or id_pop_up = "25" Or id_pop_up = "31" Or id_pop_up = "33" Or id_pop_up = "37" Or id_pop_up = "40" Or id_pop_up = "42" Or id_pop_up = "43" Or id_pop_up = "47" Or id_pop_up = "48" Or id_pop_up = "50" Or id_pop_up = "51" Or id_pop_up = "53" Or id_pop_up = "54" Or id_pop_up = "56" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If

            If id_pop_up = "25" Or id_pop_up = "15" Then
                If sender.GetRowCellValue(e.RowHandle, sender.Columns("id_design_type")).ToString = "2" Then
                    e.Appearance.BackColor = Color.SkyBlue
                    e.Appearance.BackColor2 = Color.SkyBlue
                End If
            End If
        ElseIf id_pop_up = "12" Then
            'condition
            If GVData.RowCount > 0 Then
                If Not sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("err_format")) = "" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        ElseIf id_pop_up = "35" Or id_pop_up = "44" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("note")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        ElseIf id_pop_up = "41" Then
            If e.Column.FieldName.ToString = "Status" Then
                Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
                If stt <> "OK" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            ElseIf e.Column.FieldName.ToString = "stock_availability" Then
                Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("stock_availability")).ToString
                If stt <> "OK" Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.Yellow
                End If
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormImportExcel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        Cursor = Cursors.WaitCursor
        Try

        Catch ex As Exception
            stopCustom("Import failed. Please make sure : " & vbNewLine & "- Row data not empty" & vbNewLine & "- Value in correct format")
        End Try
        If Not GVData.RowCount > 0 Then
            infoCustom("No data imported.")
            Close()
        Else
            If id_pop_up = "1" Then
                For i As Integer = 0 To (GVData.RowCount - 1)
                    If Not GVData.GetRowCellValue(i, "id_sample_price").ToString() = "0" Then
                        Dim newRow As DataRow = (TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable)).NewRow()
                        newRow("id_sample_price") = GVData.GetRowCellValue(i, "id_sample_price").ToString()
                        newRow("code") = GVData.GetRowCellValue(i, "code").ToString()
                        newRow("name") = GVData.GetRowCellValue(i, "name").ToString()
                        newRow("price") = GVData.GetRowCellValue(i, "price").ToString()
                        newRow("discount") = GVData.GetRowCellValue(i, "discount").ToString()
                        newRow("qty") = GVData.GetRowCellValue(i, "qty").ToString()
                        newRow("total") = GVData.GetRowCellValue(i, "total").ToString()

                        TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                        FormSamplePurchaseDet.GCListPurchase.RefreshDataSource()
                    End If
                Next
                Close()
            ElseIf id_pop_up = "2" Then
                Dim check_match As Boolean = False
                Dim match_index As Integer = 0
                For i As Integer = 0 To (GVData.RowCount - 1)
                    If Not GVData.GetRowCellValue(i, "id_sample").ToString() = "0" Then
                        'check first
                        check_match = False
                        match_index = 0
                        For j As Integer = 0 To FormSamplePlanDet.GVListPurchase.RowCount - 1
                            If Not FormSamplePlanDet.GVListPurchase.GetRowCellValue(j, "id_sample").ToString = "" Then
                                If FormSamplePlanDet.GVListPurchase.GetRowCellValue(j, "id_sample").ToString = GVData.GetRowCellValue(i, "id_sample").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    Exit For
                                End If
                            End If
                        Next
                        '
                        If check_match = False Then
                            Dim newRow As DataRow = (TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable)).NewRow()
                            newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                            newRow("code") = GVData.GetRowCellValue(i, "code").ToString()
                            newRow("name") = GVData.GetRowCellValue(i, "name").ToString()
                            newRow("size") = GVData.GetRowCellValue(i, "size").ToString()
                            newRow("qty") = GVData.GetRowCellValue(i, "qty").ToString()
                            newRow("sample_plan_det_note") = GVData.GetRowCellValue(i, "note").ToString()

                            TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                            FormSamplePlanDet.GCListPurchase.RefreshDataSource()
                        Else
                            FormSamplePlanDet.GVListPurchase.SetRowCellValue(match_index, "qty", (Decimal.Parse(FormSamplePlanDet.GVListPurchase.GetRowCellValue(match_index, "qty").ToString) + Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString())))
                        End If
                        '
                    End If
                Next
                FormSamplePlanDet.check_gv_but()
                Close()
            ElseIf id_pop_up = "3" Then 'import SOH on hand
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh As String = FormSOHDet.id_soh

                    Dim del_query As String = "DELETE FROM tb_soh_on_hand WHERE id_soh='" + id_soh + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_on_hand(id_soh,prod_code,style_code,prod_source,prod_size,qty) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _prod_code As String = GVData.GetRowCellValue(i, "code1")
                        Dim _style_code As String = GVData.GetRowCellValue(i, "code")
                        Dim _source As String = GVData.GetRowCellValue(i, "source")
                        Dim _size As String = GVData.GetRowCellValue(i, "size")
                        Dim _qty As String = GVData.GetRowCellValue(i, "qtyt")

                        bulk_query += "('" + id_soh + "','" + _prod_code + "','" + _style_code + "','" + _source + "','" + _size + "','" + decimalSQL(_qty.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHDet.load_self()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "4" Then 'import SOH Store
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh As String = FormSOHDet.id_soh

                    Dim del_query As String = "DELETE FROM tb_soh_store WHERE id_soh='" + id_soh + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_store(id_soh,prod_code,style_code,prod_desc,soh_store_qty) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _style_code As String = GVData.GetRowCellValue(i, "style_code")
                        Dim _prod_code As String = GVData.GetRowCellValue(i, "barcode")
                        Dim _desc As String = GVData.GetRowCellValue(i, "desc")
                        Dim _qty As String = GVData.GetRowCellValue(i, "stock")

                        bulk_query += "('" + id_soh + "','" + _prod_code + "','" + _style_code + "','" + addSlashes(_desc) + "','" + decimalSQL(_qty.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHDet.load_store()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "5" Then 'SOH Price
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh_periode As String = FormSOHPriceDet.id_soh_periode

                    Dim del_query As String = "DELETE FROM tb_soh_price WHERE id_soh_periode='" + id_soh_periode + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_price(id_soh_periode,style_code,prod_class,prod_desc,prod_price,prod_cost) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _style_code As String = GVData.GetRowCellValue(i, "code").ToString
                        Dim _prod_class As String = GVData.GetRowCellValue(i, "class").ToString
                        Dim _desc As String = GVData.GetRowCellValue(i, "desc").ToString
                        Dim _price As String = GVData.GetRowCellValue(i, "price").ToString
                        Dim _cost As String = GVData.GetRowCellValue(i, "cost").ToString
                        'MsgBox(decimalSQL(_cost.ToString))
                        bulk_query += "('" + id_soh_periode + "','" + _style_code + "','" + _prod_class + "','" + addSlashes(_desc) + "','" + decimalSQL(_price.ToString) + "','" + decimalSQL(_cost.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHPriceDet.view_list_price()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "6" Then
                'SALES INVOICE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormSalesPOSDet.GVItemList.RowCount - 1
                                If FormSalesPOSDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                'If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                'qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                'Else
                                'qty_choose = GVData.GetRowCellValue(i, "Qty")
                                'End If
                                'mau lebih atau tidak dibiarkan
                                qty_choose = GVData.GetRowCellValue(i, "Qty")
                                '
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                'newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()

                                TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormSalesPOSDet.GCItemList.RefreshDataSource()
                                FormSalesPOSDet.GVItemList.RefreshData()
                                FormSalesPOSDet.check_but()
                                FormSalesPOSDet.getDiscount()
                                FormSalesPOSDet.getNetto()
                                FormSalesPOSDet.getVat()
                                FormSalesPOSDet.getTaxBase()
                                FormSalesPOSDet.DEStart.Properties.ReadOnly = True
                                FormSalesPOSDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("Not meet condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "7" Then
                'MISSING STORE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormFGMissingDet.GVItemList.RowCount - 1
                                If FormFGMissingDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormFGMissingDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                    qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                Else
                                    qty_choose = GVData.GetRowCellValue(i, "Qty")
                                End If
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "design_price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()


                                TryCast(FormFGMissingDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormFGMissingDet.GCItemList.RefreshDataSource()
                                FormFGMissingDet.GVItemList.RefreshData()
                                FormFGMissingDet.check_but()
                                FormFGMissingDet.getDiscount()
                                FormFGMissingDet.getNetto()
                                FormFGMissingDet.getVat()
                                FormFGMissingDet.getTaxBase()
                                FormFGMissingDet.DEStart.Properties.ReadOnly = True
                                FormFGMissingDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("No fullfill condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "8" Then 'import faktur keluaran
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_acc_fak_scan As String = FormAccountingFakturScanSingle.id_acc_fak_scan

                    Dim del_query As String = "DELETE FROM tb_a_acc_fak_scan_fk_det WHERE id_acc_fak_scan='" + id_acc_fak_scan + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_a_acc_fak_scan_fk_det(id_acc_fak_scan, kd_jenis_transaksi, fg_pengganti, nomor_faktur, masa_pajak, tahun_pajak, tanggal_faktur, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, id_keterangan_tambahan, fg_uang_muka, uang_muka_dpp, uang_muka_ppn, uang_muka_ppnbm, referensi, of, kode_objek, nama3, harga_satuan, jumlah_barang, harga_total, diskon, dpp, ppn, tarif_ppnbm, ppnbm) VALUES "
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'number
                        Dim total As Decimal = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "total").ToString))
                        Dim ppn As String = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "ppn").ToString))
                        Dim dpp As String = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "dpp").ToString))


                        'no faktur
                        Dim no_faktur_ori As String = GVData.GetRowCellValue(i, "no_faktur").ToString
                        Dim col_foc_str As String() = Split(no_faktur_ori, ".")
                        Dim kd_jenis_transaksi As String = col_foc_str(0).Substring(0, 2).ToString
                        Dim fg_pengganti As String = col_foc_str(0).Substring(2, 1)
                        Dim no_faktur As String = col_foc_str(1).Replace("-", "").Replace(".", "") + col_foc_str(2).ToString

                        'query
                        bulk_query += "('" + id_acc_fak_scan + "','" + kd_jenis_transaksi + "','" + fg_pengganti + "','" + addSlashes(no_faktur) + "','" + FormAccountingFakturScanSingle.TxtPeriod.Text + "','" + FormAccountingFakturScanSingle.TxtYear.Text + "', '" + FormAccountingFakturScanSingle.TxtFakturDate.Text + "', '" + addSlashes(GVData.GetRowCellValue(i, "npwp").Replace(".", "").Replace("-", "")) + "', '" + addSlashes(GVData.GetRowCellValue(i, "nama_toko").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "alamat").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '','0','0', '0', '0', '" + addSlashes(GVData.GetRowCellValue(i, "referensi").ToString) + "', 'OF', '" + addSlashes(GVData.GetRowCellValue(i, "kode_barang").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "ket_barang").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '1', '" + decimalSQL(dpp.ToString) + "', '0', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '0') "
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormAccountingFakturScanSingle.viewDetail()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "9" Or id_pop_up = "10" Then 'import distribution scheme
                Dim data_edit As New DataTable
                'initialisation datatable edit
                Try
                    data_edit.Columns.Add("id_fg_ds_store")
                    data_edit.Columns.Add("store_name")
                Catch ex As Exception
                End Try

                'identify column
                Dim jum_store As Integer = 0
                For i As Integer = 0 To (GVData.Columns.Count - 1)
                    If GVData.Columns(i).FieldName.Contains("-") Then
                        Dim col_foc_str As String() = Split(GVData.Columns(i).FieldName.ToString, " - ")
                        Dim code As String = col_foc_str(0)
                        Dim name As String = col_foc_str(1)
                        Dim query_str As String = "SELECT str.id_fg_ds_store FROM tb_fg_ds_store str "
                        query_str += "INNER JOIN tb_m_comp comp ON comp.id_comp = str.id_comp "
                        query_str += "WHERE comp.comp_number='" + code + "' AND comp.comp_name='" + name + "' "
                        If id_pop_up = "9" Then
                            query_str += "AND str.id_season='" + FormFGDistScheme.SLESeason.EditValue.ToString + "' LIMIT 1 "
                        ElseIf id_pop_up = "10" Then
                            query_str += "AND str.id_season='" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' LIMIT 1 "
                        End If

                        Dim data As DataTable = execute_query(query_str, -1, True, "", "", "", "")
                        If data.Rows.Count > 0 Then
                            Dim R As DataRow = data_edit.NewRow
                            R("id_fg_ds_store") = data.Rows(0)("id_fg_ds_store").ToString
                            R("store_name") = GVData.Columns(i).FieldName.ToString
                            data_edit.Rows.Add(R)
                            jum_store += 1
                        End If
                    End If
                Next

                If jum_store = 0 Then
                    stopCustom("Can't identify store. Please make sure your input.")
                Else
                    For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                        Dim code_product As String = "0"
                        Try
                            code_product = GVData.GetRowCellValue(i, "CODE").ToString
                        Catch ex As Exception
                        End Try
                        Dim id_product As String = execute_query("SELECT id_product FROM tb_m_product WHERE product_full_code='" + code_product + "' ", 0, True, "", "", "", "")

                        If id_pop_up = "9" Then
                            Dim type_ds As String = FormFGDistScheme.SLEType.EditValue.ToString
                            For j As Integer = 0 To (data_edit.Rows.Count - 1)
                                Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, data_edit.Rows(j)("store_name").ToString).ToString)
                                Dim query_ds As String = "CALL generate_fg_ds('" + type_ds + "', '" + data_edit.Rows(j)("id_fg_ds_store").ToString + "', '" + id_product + "', '" + qty + "') "
                                execute_non_query(query_ds, True, "", "", "", "")
                            Next
                        ElseIf id_pop_up = "10" Then
                            For j As Integer = 0 To (data_edit.Rows.Count - 1)
                                Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, data_edit.Rows(j)("store_name").ToString).ToString)
                                Dim query_ds As String = "UPDATE tb_fg_so_reff_det SET fg_so_reff_det_qty='" + qty + "' WHERE id_fg_so_reff='" + FormFGSalesOrderReffDet.id_fg_so_reff + "' AND id_product='" + id_product + "' AND id_fg_ds_store='" + data_edit.Rows(j)("id_fg_ds_store").ToString + "' "
                                execute_non_query(query_ds, True, "", "", "", "")
                            Next
                        End If


                        PBC.PerformStep()
                        PBC.Update()
                    Next
                End If
                data_edit.Dispose()

                If id_pop_up = "9" Then
                    FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
                ElseIf id_pop_up = "10" Then
                    FormFGSalesOrderReffDet.viewDetail()
                End If
                Close()
            ElseIf id_pop_up = "11old" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_return_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_return_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("design_price_type") = ""
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("id_return_cat") = "1"
                            newRow("return_cat") = "Return"
                            newRow("amount") = GVData.GetRowCellValue(i, "Amount")
                            newRow("sales_return_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("id_sample") = "0"
                            TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                            FormSalesReturnOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "12" Then
                'check
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[err_format] = ''"
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'insert mat_det
                        Dim id_mat_det As String = ""
                        Dim query As String = ""
                        query = "INSERT INTO tb_m_mat_det(id_mat,mat_det_display_name,mat_det_name,mat_det_code,mat_det_date,id_range) "
                        query += "VALUES('" + GVData.GetRowCellValue(i, "id_mat").ToString + "','" + GVData.GetRowCellValue(i, "Description").ToString + "','" + GVData.GetRowCellValue(i, "Description").ToString + "','" + GVData.GetRowCellValue(i, "Code").ToString + "',NOW(),'" + GVData.GetRowCellValue(i, "id_range").ToString + "')"
                        query += "; SELECT LAST_INSERT_ID();"

                        id_mat_det = execute_query(query, 0, True, "", "", "", "")
                        'insert code
                        query = "INSERT INTO tb_m_mat_det_code(id_mat_det,id_code_detail) VALUES"
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_year").ToString + "')," 'year
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_color").ToString + "')," 'color
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_count").ToString + "')," 'counting
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_size").ToString + "')," 'size
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_lot").ToString + "');" 'lot
                        execute_non_query(query, True, "", "", "", "")

                        'insert harga
                        query = "INSERT INTO tb_m_mat_det_price(id_mat_det,id_comp_contact,mat_det_price_name,id_currency,mat_det_price,mat_det_price_date,is_default_cost)"
                        query += "VALUES('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_comp_contact").ToString + "','Normal Price','" + GVData.GetRowCellValue(i, "id_currency").ToString + "','" + decimalSQL(GVData.GetRowCellValue(i, "Price").ToString) + "',NOW(),1)"
                        execute_non_query(query, True, "", "", "", "")

                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "13" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_fg_price As String = FormMasterPriceSingle.id_fg_price
                        Dim query_del As String = "DELETE FROM tb_fg_price_det WHERE id_fg_price='" + id_fg_price + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_fg_price_det(id_fg_price, id_design, design_price_name, id_currency, design_price, is_print) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_design As String = GVData.GetRowCellValue(l, "id_design").ToString
                            Dim design_price_name As String = GVData.GetRowCellValue(l, "PriceName").ToString
                            Dim id_currency As String = GVData.GetRowCellValue(l, "id_currency").ToString
                            Dim design_price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)
                            Dim is_print As String = GVData.GetRowCellValue(l, "is_print").ToString

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_fg_price + "', '" + id_design + "', '" + design_price_name + "', '" + id_currency + "', '" + design_price + "', '" + is_print + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormMasterPriceSingle.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "14" Then 'import delivery order
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_wh_awb_do(do_no, erp_no, scan_date, store_number, store_name, qty, reff) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim do_no As String = addSlashes(GVData.GetRowCellValue(l, "DO").ToString)
                            Dim erp_no As String = addSlashes(GVData.GetRowCellValue(l, "ERP").ToString)
                            Dim scan_date As String = addSlashes(GVData.GetRowCellValue(l, "Date").ToString)
                            Dim store_number As String = addSlashes(GVData.GetRowCellValue(l, "StoreNumber").ToString)
                            Dim store_name As String = addSlashes(GVData.GetRowCellValue(l, "StoreName").ToString)
                            Dim reff As String = addSlashes(GVData.GetRowCellValue(l, "Reff").ToString)
                            Dim qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + do_no + "', '" + erp_no + "', '" + scan_date + "', '" + store_number + "', '" + store_name + "', '" + qty + "', '" + reff + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormWHImportDO.viewDOList()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "15" Or id_pop_up = "25" Then 'SALES ORDER
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)

                    'kondisi jika tujuan normal/sale
                    Dim cond_acc As String = ""
                    If (FormSalesOrderDet.id_account_type = "1" Or FormSalesOrderDet.id_account_type = "2") And FormSalesOrderDet.is_transfer_data = 2 Then
                        cond_acc = "AND [id_design_cat]='" + FormSalesOrderDet.id_account_type + "' "
                    End If


                    GVData.ActiveFilterString = "[Status] = 'OK' " + cond_acc
                    If GVData.RowCount > 0 Then
                        FormSalesOrderDet.delNotFoundMyRow()
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("qty_avail") = GVData.GetRowCellValue(i, "Available")
                            If FormSalesOrderDet.LEStatusSO.EditValue.ToString = "8" And FormSalesOrderDet.id_store_type = "1" Then 'jika cat claim dan toko normal => harga normal
                                Dim dtp As DataTable = getNormalPrice(GVData.GetRowCellValue(i, "id_design").ToString)
                                If dtp.Rows.Count > 0 Then
                                    newRow("id_design_price") = dtp(0)("id_design_price").ToString
                                    newRow("design_price") = dtp(0)("design_price")
                                    newRow("design_price_type") = dtp(0)("design_price_type").ToString
                                    newRow("amount") = dtp(0)("design_price") * GVData.GetRowCellValue(i, "Qty")
                                Else
                                    newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                                    newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                                    newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString
                                    newRow("amount") = GVData.GetRowCellValue(i, "Price") * GVData.GetRowCellValue(i, "Qty")
                                End If
                            Else
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                                newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString
                                newRow("amount") = GVData.GetRowCellValue(i, "Price") * GVData.GetRowCellValue(i, "Qty")
                            End If


                            newRow("sales_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("is_found") = "1"
                            TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesOrderDet.GCItemList.RefreshDataSource()
                            FormSalesOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.check_but()

                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "16" Then 'ECOP
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please keep in mind :" + System.Environment.NewLine + "- Only 'OK' status data will be imported." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[err_format] = 'OK'"
                    If GVData.RowCount > 0 Then
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim query As String = ""
                            Dim id_bom As String = ""
                            Dim id_bom_approve As String = ""
                            'update default bom
                            query = "UPDATE "
                            query += " tb_bom bom "
                            query += " INNER JOIN tb_m_product m_p ON m_p.id_product=bom.id_product"
                            query += " SET bom.is_default = 2"
                            query += " WHERE m_p.id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "'"
                            execute_non_query(query, True, "", "", "", "")

                            'create bom report
                            query = "INSERT INTO tb_bom_approve(id_report_status) VALUES('1'); SELECT LAST_INSERT_ID();"
                            id_bom_approve = execute_query(query, 0, True, "", "", "", "")

                            'insert bom
                            'query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,id_user_last_update,is_default,id_report_status)"
                            'query += " VALUES('" + GVData.GetRowCellValue(i, "id_product").ToString + "','1','ECOP','" + GVData.GetRowCellValue(i, "id_currency").ToString + "','" + decimalSQL(GVData.GetRowCellValue(i, "Kurs").ToString) + "','" + decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) + "',NOW(),'" + id_user + "','1','1')"
                            'query += "; SELECT LAST_INSERT_ID();"

                            'id_bom = execute_query(query, 0, True, "", "", "", "")

                            'insert bom det
                            'query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,kurs,bom_price,component_qty,is_cost,is_ovh_main)"
                            'query += " VALUES('" + id_bom + "','2','" + GVData.GetRowCellValue(i, "id_ovh_price").ToString + "','0','" + decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) + "','1','1','1')"
                            'execute_non_query(query, True, "", "", "", "")

                            'insert bom default
                            query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,is_default,id_bom_approve,id_user_last_update,bom_date_updated)"
                            query += " SELECT "
                            query += " id_product"
                            query += " ,'1' AS id_term_production"
                            query += " ,'Estimate COP' AS bom_name"
                            query += " ,'" & GVData.GetRowCellValue(i, "id_currency").ToString & "' AS id_currency"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "Kurs").ToString) & "' AS kurs"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) & "' AS bom_unit_price"
                            query += " ,NOW() AS bom_date_created"
                            query += " ,'1' AS is_default"
                            query += " ,'" & id_bom_approve & "'"
                            query += " ,'" & id_user & "' AS id_user_last_update"
                            query += " ,NOW() AS bom_last_updated"
                            query += " FROM tb_m_product"
                            query += " WHERE id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "'"
                            execute_non_query(query, True, "", "", "", "")

                            'insert det
                            query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,bom_price,component_qty,is_ovh_main)"
                            query += " SELECT "
                            query += " id_bom"
                            query += " ,'2' AS id_component_category"
                            query += " ,'" & GVData.GetRowCellValue(i, "id_ovh_price").ToString & "' AS id_ovh_price"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) & "' AS bom_price"
                            query += " ,'1' AS component_qty"
                            query += " ,'1' AS is_ovh_main"
                            query += " FROM tb_bom bom"
                            query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                            query += " WHERE m_p.id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "' AND bom.is_default='1'"
                            execute_non_query(query, True, "", "", "", "")

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "17" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id As String = addSlashes(GVData.GetRowCellValue(l, "id").ToString)
                            Dim id_design As String = GVData.GetRowCellValue(l, "id_design").ToString
                            Dim price As String = decimalSQL(GVData.GetRowCellValue(l, "est_price").ToString)
                            Dim rate As String = decimalSQL(GVData.GetRowCellValue(l, "rate_current").ToString)
                            Dim msrp_rp As String = decimalSQL(GVData.GetRowCellValue(l, "msrp_rp").ToString)
                            Dim msrp As String = decimalSQL(GVData.GetRowCellValue(l, "msrp").ToString)
                            Dim id_delivery As String = addSlashes(GVData.GetRowCellValue(l, "id_delivery").ToString)
                            Dim id_ret_code As String = addSlashes(GVData.GetRowCellValue(l, "id_ret_code").ToString)
                            Dim design_eos As String = "NULL"
                            Try
                                design_eos = "'" + DateTime.Parse(GVData.GetRowCellValue(l, "design_eos").ToString).ToString("yyyy-MM-dd") + "'"
                            Catch ex As Exception
                            End Try
                            If design_eos = "" Then
                                design_eos = "NULL"
                            End If

                            'query master
                            Dim qum As String = "UPDATE tb_m_design SET id_delivery='" + id_delivery + "', id_ret_code='" + id_ret_code + "', design_eos=" + design_eos + " WHERE id_design=" + id_design + " "
                            execute_non_query(qum, True, "", "", "", "")

                            'query pd
                            Dim query_upd As String = "UPDATE tb_prod_demand_design SET prod_demand_design_propose_price ='" + price + "', rate_current='" + rate + "', msrp='" + msrp + "', msrp_rp='" + msrp_rp + "' WHERE id_prod_demand_design='" + id + "' "
                            execute_non_query(query_upd, True, "", "", "", "")
                            PBC.PerformStep()
                            PBC.Update()
                        Next

                        FormFGLineList.viewLineList()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "18" Then
                'SALES Promo
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormSalesPOSDet.GVItemList.RowCount - 1
                                If FormSalesPOSDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormSalesPromoDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                'If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                'qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                'Else
                                'qty_choose = GVData.GetRowCellValue(i, "Qty")
                                'End If
                                'mau lebih atau tidak dibiarkan
                                qty_choose = GVData.GetRowCellValue(i, "Qty")
                                '
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()

                                TryCast(FormSalesPromoDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormSalesPromoDet.GCItemList.RefreshDataSource()
                                FormSalesPromoDet.GVItemList.RefreshData()
                                FormSalesPromoDet.check_but()
                                FormSalesPromoDet.getNetto()
                                FormSalesPromoDet.getVat()
                                FormSalesPromoDet.getTaxBase()
                                FormSalesPromoDet.DEStart.Properties.ReadOnly = True
                                FormSalesPromoDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("Not meet condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "19" Then
                ' MASTER SAMPLE PRICE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_sample_price As String = FormMasterPriceSampleSingle.id_sample_price
                        Dim query_del As String = "DELETE FROM tb_sample_price_det WHERE id_sample_price='" + id_sample_price + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sample_price_det(id_sample_price, id_sample, sample_price_name, id_currency, sample_price, is_print) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sample As String = GVData.GetRowCellValue(l, "id_sample").ToString
                            Dim design_price_name As String = addSlashes(GVData.GetRowCellValue(l, "PriceName").ToString)
                            Dim id_currency As String = GVData.GetRowCellValue(l, "id_currency").ToString
                            Dim sample_price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)
                            Dim is_print As String = GVData.GetRowCellValue(l, "is_print").ToString

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sample_price + "', '" + id_sample + "', '" + design_price_name + "', '" + id_currency + "', '" + sample_price + "', '" + is_print + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormMasterPriceSampleSingle.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "20" Or id_pop_up = "24" Then
                'inventory allocation
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_fg_wh_alloc_det WHERE id_fg_wh_alloc='" + FormFGWHAllocDet.id_fg_wh_alloc + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_fg_wh_alloc_det(id_fg_wh_alloc, id_product, id_wh_drawer_to, fg_wh_alloc_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_fg_wh_alloc As String = FormFGWHAllocDet.id_fg_wh_alloc
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_wh_drawer_to As String = GVData.GetRowCellValue(l, "id_wh_drawer_to").ToString
                            Dim fg_wh_alloc_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_fg_wh_alloc + "', '" + id_product + "', '" + id_wh_drawer_to + "', '" + fg_wh_alloc_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormFGWHAllocDet.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "21" Then
                'generate SO
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_sales_order_gen_det WHERE id_sales_order_gen='" + FormSalesOrderGen.id_sales_order_gen + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sales_order_gen_det(id_sales_order_gen, id_product, id_comp_contact_from, id_comp_contact_to, sales_order_gen_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_comp_contact_from As String = GVData.GetRowCellValue(l, "id_comp_contact_from").ToString
                            Dim id_comp_contact_to As String = GVData.GetRowCellValue(l, "id_comp_contact_to").ToString
                            Dim sales_order_gen_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sales_order_gen + "', '" + id_product + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + sales_order_gen_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormSalesOrderGen.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "22" Then
                'sample Return Internal sale
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please note :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim newRow As DataRow = (TryCast(FormSampleReturnPLDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sample_pl_det") = "0"
                            newRow("id_sample") = GVData.GetRowCellValue(l, "id_sample").ToString
                            newRow("id_sample_price") = GVData.GetRowCellValue(l, "id_cost").ToString
                            newRow("sample_price") = GVData.GetRowCellValue(l, "cost")
                            newRow("id_sample_ret_price") = GVData.GetRowCellValue(l, "id_price").ToString
                            newRow("sample_ret_price") = GVData.GetRowCellValue(l, "price")
                            newRow("code") = GVData.GetRowCellValue(l, "Code").ToString
                            newRow("code_us") = GVData.GetRowCellValue(l, "code_us").ToString
                            newRow("name") = GVData.GetRowCellValue(l, "Description").ToString
                            newRow("size") = GVData.GetRowCellValue(l, "Size").ToString
                            newRow("color") = GVData.GetRowCellValue(l, "Color").ToString
                            newRow("class") = GVData.GetRowCellValue(l, "Class").ToString
                            newRow("id_season") = GVData.GetRowCellValue(l, "id_season").ToString
                            newRow("season") = GVData.GetRowCellValue(l, "season").ToString
                            newRow("id_season_orign") = GVData.GetRowCellValue(l, "id_season_orign").ToString
                            newRow("season_orign") = GVData.GetRowCellValue(l, "season_orign").ToString
                            newRow("sample_pl_det_qty") = GVData.GetRowCellValue(l, "Qty").ToString
                            TryCast(FormSampleReturnPLDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSampleReturnPLDet.GCItemList.RefreshDataSource()
                            FormSampleReturnPLDet.GVItemList.RefreshData()
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSampleReturnPLDet.BtnSave.Focus()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "23" Then
                'generate SO new
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_sales_order_gen_det WHERE id_sales_order_gen='" + FormSalesOrderGen.id_sales_order_gen + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sales_order_gen_det(id_sales_order_gen, id_product, id_comp_contact_from, id_comp_contact_to, sales_order_gen_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_comp_contact_from As String = GVData.GetRowCellValue(l, "id_comp_contact_from").ToString
                            Dim id_comp_contact_to As String = GVData.GetRowCellValue(l, "id_comp_contact_to").ToString
                            Dim sales_order_gen_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sales_order_gen + "', '" + id_product + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + sales_order_gen_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormSalesOrderGen.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "26" Then
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_acc_fak_scan As String = FormAccountingFakturScanSingle.id_acc_fak_scan

                    Dim del_query As String = "DELETE FROM tb_a_acc_fak_scan_fk_det WHERE id_acc_fak_scan='" + id_acc_fak_scan + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_a_acc_fak_scan_fk_det(id_acc_fak_scan, kd_jenis_transaksi, fg_pengganti, nomor_faktur, masa_pajak, tahun_pajak, tanggal_faktur, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, id_keterangan_tambahan, fg_uang_muka, uang_muka_dpp, uang_muka_ppn, uang_muka_ppnbm, referensi, of, kode_objek, nama3, harga_satuan, jumlah_barang, harga_total, diskon, dpp, ppn, tarif_ppnbm, ppnbm) VALUES "
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'number
                        Dim harga_total As Decimal = GVData.GetRowCellValue(i, "harga_total").ToString
                        Dim diskon As Decimal = GVData.GetRowCellValue(i, "diskon").ToString
                        Dim ppn As String = GVData.GetRowCellValue(i, "ppn").ToString
                        Dim dpp As String = GVData.GetRowCellValue(i, "dpp").ToString
                        Dim jumlah_ppn As String = GVData.GetRowCellValue(i, "jumlah_ppn").ToString
                        Dim jumlah_dpp As String = GVData.GetRowCellValue(i, "jumlah_dpp").ToString

                        'no faktur
                        Dim no_faktur_ori As String = GVData.GetRowCellValue(i, "no_faktur").ToString
                        Dim col_foc_str As String() = Split(no_faktur_ori, ".")
                        Dim kd_jenis_transaksi As String = col_foc_str(0).Substring(0, 2).ToString
                        Dim fg_pengganti As String = col_foc_str(0).Substring(2, 1)
                        Dim no_faktur As String = col_foc_str(1).Replace("-", "").Replace(".", "") + col_foc_str(2).ToString

                        'query
                        bulk_query += "('" + id_acc_fak_scan + "','" + kd_jenis_transaksi + "','" + fg_pengganti + "','" + addSlashes(no_faktur) + "','" + FormAccountingFakturScanSingle.TxtPeriod.Text + "','" + FormAccountingFakturScanSingle.TxtYear.Text + "', '" + FormAccountingFakturScanSingle.TxtFakturDate.Text + "', '" + addSlashes(GVData.GetRowCellValue(i, "npwp").Replace(".", "").Replace("-", "")) + "', '" + addSlashes(GVData.GetRowCellValue(i, "nama_toko").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "alamat").ToString) + "', '" + decimalSQL(jumlah_dpp.ToString) + "', '" + decimalSQL(jumlah_ppn.ToString) + "', '0', '" + addSlashes(GVData.GetRowCellValue(i, "id_keterangan_tambahan").ToString) + "','0','0', '0', '0', '" + addSlashes(GVData.GetRowCellValue(i, "referensi").ToString) + "', 'OF', '" + addSlashes(GVData.GetRowCellValue(i, "kode_barang").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "ket_barang").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "harga_satuan").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "jumlah_barang").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "harga_total").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "diskon").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '0') "
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormAccountingFakturScanSingle.viewDetail()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "27" Then 'import holiday
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        Dim date_var As Date = GVData.GetRowCellValue(i, "Date")
                        '
                        Dim query_del As String = "DELETE FROM tb_emp_holiday WHERE emp_holiday_date='" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "' AND id_religion='" & GVData.GetRowCellValue(i, "IdReligion").ToString & "'"
                        execute_non_query(query_del, True, "", "", "", "")
                        '
                        Dim query_exec As String = "INSERT INTO tb_emp_holiday(id_religion,emp_holiday_date,emp_holiday_desc) VALUES('" & GVData.GetRowCellValue(i, "IdReligion").ToString & "','" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "','" & GVData.GetRowCellValue(i, "Description").ToString & "')"
                        execute_non_query(query_exec, True, "", "", "", "")
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    FormEmpHoliday.load_year()
                    FormEmpHoliday.SLEYear.EditValue = execute_query("SELECT YEAR(MAX(emp_holiday_date)) AS year FROM tb_emp_holiday", 0, True, "", "", "", "")
                    FormEmpHoliday.view_holiday()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "28" Then 'import UPC
                GVData.ActiveFilterString = "[IdProduct] <> '0' AND [UPC] <> ''"
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdProduct").ToString = "0" And Not GVData.GetRowCellValue(i, "UPC").ToString = "" Then
                            Dim query_exec As String = "UPDATE tb_m_product SET product_ean_code='" & GVData.GetRowCellValue(i, "UPC").ToString & "' WHERE id_product='" & GVData.GetRowCellValue(i, "IdProduct").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "11" Or id_pop_up = "29" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        FormSalesReturnOrderDet.delNotFoundMyRow()
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_return_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_return_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("qty_avail") = GVData.GetRowCellValue(i, "SOH")
                            newRow("design_price_type") = ""
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("id_return_cat") = "1"
                            newRow("return_cat") = "Return"
                            newRow("amount") = GVData.GetRowCellValue(i, "Amount")
                            newRow("sales_return_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("id_sample") = "0"
                            newRow("id_detail_on_hold") = "0"
                            TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                            FormSalesReturnOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "30" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdPO").ToString = "0" Then
                            Dim date_ls_string As String = ""
                            If Not GVData.GetRowCellValue(i, "ls_date").ToString() = "" Then
                                date_ls_string = DateTime.Parse(GVData.GetRowCellValue(i, "ls_date").ToString()).ToString("yyyy-MM-dd")
                            End If

                            Dim query_exec As String = "UPDATE tb_prod_order SET 
                                                        hs_code='" & GVData.GetRowCellValue(i, "hs_code").ToString & "',
                                                        aju_no='" & GVData.GetRowCellValue(i, "AjuNumber").ToString & "',
                                                        pib_no='" & GVData.GetRowCellValue(i, "PibNumber").ToString & "', 
                                                        pib_date='" & DateTime.Parse(GVData.GetRowCellValue(i, "PibDate").ToString()).ToString("yyyy-MM-dd") & "', 
                                                        duty_percent='" & decimalSQL(GVData.GetRowCellValue(i, "Duty").ToString) & "', 
                                                        duty_royalty='" & decimalSQL(GVData.GetRowCellValue(i, "Royalty").ToString) & "', 
                                                        duty_sales_vat='" & decimalSQL(GVData.GetRowCellValue(i, "SalesVat").ToString) & "', 
                                                        duty_pph='" & decimalSQL(GVData.GetRowCellValue(i, "SalesPPH").ToString) & "', 
                                                        duty_store_disc='" & decimalSQL(GVData.GetRowCellValue(i, "StoreDiscount").ToString) & "', 
                                                        duty_sales_thru='" & decimalSQL(GVData.GetRowCellValue(i, "SalesThru").ToString) & "',
                                                        duty_is_pr_proposed='" & GVData.GetRowCellValue(i, "id_isPR").ToString & "',
                                                        duty_is_pay='" & GVData.GetRowCellValue(i, "id_isPay").ToString & "',
                                                        country_source='" & GVData.GetRowCellValue(i, "Source").ToString & "',
                                                        dest_port='" & GVData.GetRowCellValue(i, "DestPort").ToString & "',
                                                        ppjk='" & GVData.GetRowCellValue(i, "ppjk").ToString & "',
                                                        ppjk_inv_no='" & GVData.GetRowCellValue(i, "ppjk_inv").ToString & "',
                                                        pib_volume='" & decimalSQL(GVData.GetRowCellValue(i, "volume").ToString) & "',
                                                        pib_uom='" & GVData.GetRowCellValue(i, "uom").ToString & "',
                                                        cif='" & decimalSQL(GVData.GetRowCellValue(i, "cif").ToString) & "',
                                                        ls_no='" & GVData.GetRowCellValue(i, "ls_no").ToString & "',
                                                        ls_date='" & date_ls_string & "',
                                                        coo_no='" & GVData.GetRowCellValue(i, "coo").ToString & "',
                                                        pib_kurs='" & decimalSQL(GVData.GetRowCellValue(i, "kurs").ToString) & "',
                                                        pib_id_currency='" & GVData.GetRowCellValue(i, "id_currency").ToString & "',
                                                        tot_freight_cost='" & decimalSQL(GVData.GetRowCellValue(i, "freight_cost_rp").ToString) & "',
                                                        penalty_percent='" & decimalSQL(GVData.GetRowCellValue(i, "penalty_percent").ToString) & "',
                                                        royalty_pib='" & decimalSQL(GVData.GetRowCellValue(i, "royalty_pib").ToString) & "'
                                                        WHERE id_prod_order='" & GVData.GetRowCellValue(i, "IdPO").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    FormProdDuty.view_production_order()
                    Close()
                End If
            ElseIf id_pop_up = "31" Then
                'uniform budget
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_emp_uni_period As String = FormEmpUniPeriodDet.id_emp_uni_period
                        Dim query_del As String = "DELETE FROM tb_emp_uni_budget WHERE id_emp_uni_budget IN (
	                    SELECT * FROM (
		                    SELECT b.id_emp_uni_budget FROM tb_emp_uni_budget b
		                    LEFT JOIN tb_sales_order so ON so.id_emp_uni_budget = b.id_emp_uni_budget
		                    WHERE b.id_emp_uni_period=" + id_emp_uni_period + " AND ISNULL(so.id_emp_uni_budget)
	                    ) AS p
) "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_emp_uni_budget(id_emp_uni_period, id_employee, id_departement, id_employee_level, budget, is_dept_head) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_employee As String = GVData.GetRowCellValue(l, "IdEmp").ToString
                            Dim id_departement As String = GVData.GetRowCellValue(l, "IdDept").ToString
                            Dim is_dept_head As String = GVData.GetRowCellValue(l, "IdDeptHead").ToString
                            Dim id_employee_level As String = GVData.GetRowCellValue(l, "IdLevel").ToString
                            Dim budget As String = decimalSQL(GVData.GetRowCellValue(l, "Budget").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_emp_uni_period + "', '" + id_employee + "', '" + id_departement + "', '" + id_employee_level + "', '" + budget + "','" + is_dept_head + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If

                        'update point
                        'execute_non_query("CALL set_emp_uni_point(" + FormEmpUniPeriodDet.id_emp_uni_period + ")", True, "", "", "", "")

                        FormEmpUniPeriodDet.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "32" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdPO").ToString = "0" Then
                            Dim query_exec As String = "UPDATE tb_prod_order SET 
                                                        act_sales_qty='" & decimalSQL(GVData.GetRowCellValue(i, "sales_actual_qty").ToString) & "'
                                                        ,act_sales_amount_after_disc='" & decimalSQL(GVData.GetRowCellValue(i, "amount_after_discount").ToString) & "'
                                                        WHERE id_prod_order='" & GVData.GetRowCellValue(i, "IdPO").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    FormProdDuty.view_production_order()
                    Close()
                End If
            ElseIf id_pop_up = "33" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_emp_uni_design As String = FormEmpUniListDet.id_emp_uni_design
                Dim is_dept_head As String = FormEmpUniListDet.is_dept_head
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        'delete old
                        Dim qd As String = "DELETE FROM tb_emp_uni_design_det WHERE id_emp_uni_design='" + id_emp_uni_design + "' "
                        execute_non_query(qd, True, "", "", "", "")

                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '

                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_design As String = GVData.GetRowCellValue(i, "IdDesign").ToString
                            Dim query As String = "INSERT INTO tb_emp_uni_design_det(id_emp_uni_design, id_design, is_dept_head) VALUES('" + id_emp_uni_design + "', '" + id_design + "', '" + is_dept_head + "'); "
                            execute_non_query(query, True, "", "", "", "")
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormEmpUniListDet.viewDetailList()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "34" Then 'import salary
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdEmployee").ToString = "0" Then
                            Dim query_exec As String = "INSERT INTO tb_m_employee_salary(id_employee,basic_salary,allow_job,allow_meal,allow_trans,allow_house,allow_car,effective_date)
                                                        VALUES('" & GVData.GetRowCellValue(i, "IdEmployee").ToString & "','" & decimalSQL(GVData.GetRowCellValue(i, "basic_salary").ToString) & "','" & decimalSQL(GVData.GetRowCellValue(i, "allow_job").ToString) & "','" & decimalSQL(GVData.GetRowCellValue(i, "allow_meal").ToString) & "','" & decimalSQL(GVData.GetRowCellValue(i, "allow_trans").ToString) & "','" & decimalSQL(GVData.GetRowCellValue(i, "allow_house").ToString) & "','" & decimalSQL(GVData.GetRowCellValue(i, "allow_car").ToString) & "','" & Date.Parse(GVData.GetRowCellValue(i, "effective_date").ToString).ToString("yyyy-MM-dd") & "')"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    FormMasterEmployee.viewEmployee("-1")
                    Close()
                End If
            ElseIf id_pop_up = "35" Then 'import awb receiving outbound
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? Only 'OK' data will updated.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdAwb").ToString = "0" Then
                            Dim date_new As String = ""
                            '
                            If GVData.GetRowCellValue(i, "rec_date_new").ToString = "" Then
                                date_new = "NULL"
                            Else
                                date_new = "'" & Date.Parse(GVData.GetRowCellValue(i, "rec_date_new").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            '
                            Dim query_exec As String = "UPDATE tb_wh_awbill SET rec_by_store_date=" & date_new & ",rec_by_store_person='" & addSlashes(GVData.GetRowCellValue(i, "rec_by_new").ToString) & "',awbill_inv_no='" & addSlashes(GVData.GetRowCellValue(i, "inv_no_new").ToString) & "',a_weight='" & decimalSQL(GVData.GetRowCellValue(i, "a_weight_new").ToString) & "',a_tot_price='" & decimalSQL(GVData.GetRowCellValue(i, "a_tot_price_new").ToString) & "' WHERE id_awbill='" & GVData.GetRowCellValue(i, "IdAwb").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    Close()
                End If
            ElseIf id_pop_up = "36" Then 'import koperasi pinjaman
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
                    Dim id_deduction_type As String = "5"
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdEmployee").ToString = "0" Then
                            Dim query_exec As String = "INSERT INTO tb_emp_payroll_deduction(id_payroll,id_salary_deduction,id_employee,deduction,note)
                                                        VALUES('" & id_payroll & "','" & id_deduction_type & "','" & GVData.GetRowCellValue(i, "IdEmployee").ToString & "',ROUND(" & decimalSQL(GVData.GetRowCellValue(i, "Deduction").ToString) & ",0),'" & addSlashes(GVData.GetRowCellValue(i, "Note").ToString) & "')"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    FormEmpPayrollDeduction.load_deduction()
                    Close()
                End If
            ElseIf id_pop_up = "37" Then
                'import rev budget
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[Status] = 'OK'"
                If GVData.RowCount > 0 Then
                    If GVData.Columns("Total").SummaryItem.SummaryValue <> FormBudgetRevProposeDet.TxtTotal.EditValue Then
                        warningCustom("Total input tidak sama dengan total Anggaran Tahunan yang sudah ditetapkan. Mohon periksa kembali.")
                        makeSafeGV(GVData)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("PERHATIAN :" + System.Environment.NewLine + "- Hanya status 'OK' yang akan diimport." + System.Environment.NewLine + "Anda yakin akan melanjutkan proses import?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id As String = FormBudgetRevProposeDet.id
                    Dim year As String = FormBudgetRevProposeDet.TxtYear.Text
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'delete all
                        Dim qd As String = "DELETE FROM tb_b_revenue_propose_det WHERE id_b_revenue_propose='" + id + "' "
                        execute_non_query(qd, True, "", "", "", "")
                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_store As String = GVData.GetRowCellValue(i, "id_comp").ToString

                            'inset detil month
                            Dim query As String = "INSERT INTO tb_b_revenue_propose_det(id_b_revenue_propose, id_store, month, b_revenue_propose) VALUES "
                            Dim month As String = ""
                            Dim n As Integer = 0
                            For j As Integer = 1 To 12
                                If j = 1 Then
                                    month = "January"
                                ElseIf j = 2 Then
                                    month = "February"
                                ElseIf j = 3 Then
                                    month = "March"
                                ElseIf j = 4 Then
                                    month = "April"
                                ElseIf j = 5 Then
                                    month = "May"
                                ElseIf j = 6 Then
                                    month = "June"
                                ElseIf j = 7 Then
                                    month = "July"
                                ElseIf j = 8 Then
                                    month = "August"
                                ElseIf j = 9 Then
                                    month = "September"
                                ElseIf j = 10 Then
                                    month = "October"
                                ElseIf j = 11 Then
                                    month = "November"
                                ElseIf j = 12 Then
                                    month = "December"
                                End If

                                If GVData.GetRowCellValue(i, month) > 0 Then
                                    If n > 0 Then
                                        query += ", "
                                    End If

                                    query += "('" + id + "', '" + id_store + "', '" + j.ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, month).ToString) + "') "
                                    n += 1
                                End If
                            Next
                            If n > 0 Then
                                execute_non_query(query, True, "", "", "", "")
                            End If

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormBudgetRevProposeDet.viewDetail()
                        Close()
                    End If
                Else
                    stopCustom("Tidak ada data yang diimport. Hanya yang berstatus 'OK' yang bisa diimport. Mohon periksa kembali ")
                    makeSafeGV(GVData)
                End If
            ElseIf id_pop_up = "38" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id As String = FormBudgetExpenseProposeDet.id
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '

                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim year As String = GVData.GetRowCellValue(i, "year").ToString
                            Dim id_item_coa As String = GVData.GetRowCellValue(i, "id_item_coa").ToString
                            Dim value_expense As String = decimalSQL(GVData.GetRowCellValue(i, "Value").ToString)
                            Dim idy As String = GVData.GetRowCellValue(i, "id_b_expense_propose_year").ToString

                            If idy = "0" Then
                                ' insert
                                Dim qd As String = "INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year,id_item_coa, value_expense) VALUES
                                ('" + id + "', '" + year + "', '" + id_item_coa + "', '" + value_expense + "'); "
                                execute_non_query(qd, True, "", "", "", "")
                            Else
                                Dim qu As String = "UPDATE tb_b_expense_propose_year SET value_expense='" + value_expense + "' 
                                WHERE id_b_expense_propose_year='" + idy + "'; "
                                execute_non_query(qu, True, "", "", "", "")
                            End If


                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormBudgetExpenseProposeDet.viewDetailYearly()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "39" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id As String = FormBudgetExpenseProposeDet.id
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '

                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim idm As String = GVData.GetRowCellValue(i, "id_b_expense_propose_month").ToString
                            Dim idy As String = GVData.GetRowCellValue(i, "id_b_expense_propose_year").ToString
                            Dim month As String = GVData.GetRowCellValue(i, "mth").ToString
                            Dim value_expense As String = decimalSQL(GVData.GetRowCellValue(i, "Value").ToString)

                            If idm = "0" Then
                                ' insert
                                Dim qd As String = "INSERT INTO tb_b_expense_propose_month(id_b_expense_propose_year, month, value_expense) VALUES
                                ('" + idy + "', '" + month + "', '" + value_expense + "'); "
                                execute_non_query(qd, True, "", "", "", "")
                            Else
                                Dim qu As String = "UPDATE tb_b_expense_propose_month SET value_expense='" + value_expense + "' 
                                WHERE id_b_expense_propose_month='" + idm + "'; "
                                execute_non_query(qu, True, "", "", "", "")
                            End If


                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormBudgetExpenseProposeDet.viewDetailMonthly()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "40" Then
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[Status] = 'OK'"
                If GVData.RowCount > 0 Then
                    If GVData.Columns("Total").SummaryItem.SummaryValue <> FormBudgetExpenseProposeDet.TxtTotal.EditValue Then
                        warningCustom("Total input tidak sama dengan total Anggaran Tahunan yang sudah ditetapkan. Mohon periksa kembali.")
                        makeSafeGV(GVData)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("PERHATIAN :" + System.Environment.NewLine + "- Hanya status 'OK' yang akan diimport." + System.Environment.NewLine + "Anda yakin akan melanjutkan proses import?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id As String = FormBudgetExpenseProposeDet.id
                    Dim year As String = FormBudgetExpenseProposeDet.TxtYear.Text
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'delete all
                        Dim qd As String = "DELETE FROM tb_b_expense_propose_year WHERE id_b_expense_propose='" + id + "' "
                        execute_non_query(qd, True, "", "", "", "")

                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_item_coa As String = GVData.GetRowCellValue(i, "id_item_coa").ToString

                            'inset tahunan
                            Dim qins_year As String = "INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year, id_item_coa, value_expense) 
                            VALUES('" + id + "', '" + year + "', '" + id_item_coa + "', '" + decimalSQL(GVData.GetRowCellValue(i, "Total").ToString) + "'); SELECT LAST_INSERT_ID(); "
                            Dim id_b_expense_propose_year As String = execute_query(qins_year, 0, True, "", "", "", "")

                            'inset detil month
                            Dim query As String = "INSERT INTO tb_b_expense_propose_month(id_b_expense_propose_year, month, value_expense) VALUES "
                            Dim month As String = ""
                            Dim month_db As String = ""
                            Dim n As Integer = 0
                            For j As Integer = 1 To 12
                                If j = 1 Then
                                    month = "January"
                                    month_db = year + "-01-" + "01"
                                ElseIf j = 2 Then
                                    month = "February"
                                    month_db = year + "-02-" + "01"
                                ElseIf j = 3 Then
                                    month = "March"
                                    month_db = year + "-03-" + "01"
                                ElseIf j = 4 Then
                                    month = "April"
                                    month_db = year + "-04-" + "01"
                                ElseIf j = 5 Then
                                    month = "May"
                                    month_db = year + "-05-" + "01"
                                ElseIf j = 6 Then
                                    month = "June"
                                    month_db = year + "-06-" + "01"
                                ElseIf j = 7 Then
                                    month = "July"
                                    month_db = year + "-07-" + "01"
                                ElseIf j = 8 Then
                                    month = "August"
                                    month_db = year + "-08-" + "01"
                                ElseIf j = 9 Then
                                    month = "September"
                                    month_db = year + "-09-" + "01"
                                ElseIf j = 10 Then
                                    month = "October"
                                    month_db = year + "-10-" + "01"
                                ElseIf j = 11 Then
                                    month = "November"
                                    month_db = year + "-11-" + "01"
                                ElseIf j = 12 Then
                                    month = "December"
                                    month_db = year + "-12-" + "01"
                                End If

                                If GVData.GetRowCellValue(i, month) > 0 Then
                                    If n > 0 Then
                                        query += ", "
                                    End If

                                    query += "('" + id_b_expense_propose_year + "', '" + month_db + "', '" + decimalSQL(GVData.GetRowCellValue(i, month).ToString) + "') "
                                    n += 1
                                End If
                            Next
                            If n > 0 Then
                                execute_non_query(query, True, "", "", "", "")
                            End If

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If FormBudgetExpenseProposeDet.XTCBudget.SelectedTabPageIndex = 1 Then
                            FormBudgetExpenseProposeDet.viewDetailYearly()
                        ElseIf FormBudgetExpenseProposeDet.XTCBudget.SelectedTabPageIndex = 2 Then
                            FormBudgetExpenseProposeDet.viewDetailMonthly()
                        End If
                        Close()
                    End If
                Else
                    stopCustom("Tidak ada data yang diimport. Hanya yang berstatus 'OK' yang bisa diimport. Mohon periksa kembali ")
                    makeSafeGV(GVData)
                End If
            ElseIf id_pop_up = "41" Then
                'generate order OL Store
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        'chek stok
                        Dim data_stok_cek As DataRow() = dt_add.Select("[status]<>'OK' ")
                        If data_stok_cek.Count > 0 Then
                            stopCustom("Some products doesn't have stock. Please make sure stock availability.")
                            makeSafeGV(GVData)
                            FormOLStoreDetCheckStockvb.dt = dt_add
                            FormOLStoreDetCheckStockvb.ShowDialog()
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        'delete all in main form
                        FormOLStoreDet.viewDetail()

                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True

                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormOLStoreDet.GCDetail.DataSource, DataTable)).NewRow()
                            newRow("id_sales_order") = "0"
                            newRow("id_sales_order_det") = "0"
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("sales_order_ol_shop_number") = GVData.GetRowCellValue(i, "sales_order_ol_shop_number").ToString
                            newRow("sales_order_ol_shop_date") = GVData.GetRowCellValue(i, "sales_order_ol_shop_date")
                            newRow("sales_order_number") = ""
                            newRow("code") = GVData.GetRowCellValue(i, "code").ToString
                            newRow("name") = GVData.GetRowCellValue(i, "name").ToString
                            newRow("item_id") = GVData.GetRowCellValue(i, "item_id").ToString
                            newRow("ol_store_id") = GVData.GetRowCellValue(i, "ol_store_id").ToString
                            newRow("sales_order_det_qty") = GVData.GetRowCellValue(i, "sales_order_det_qty")
                            newRow("id_design_cat") = GVData.GetRowCellValue(i, "id_design_cat").ToString
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                            newRow("design_cop") = GVData.GetRowCellValue(i, "design_cop")
                            newRow("ol_store_sku") = GVData.GetRowCellValue(i, "ol_store_sku").ToString
                            newRow("customer_name") = GVData.GetRowCellValue(i, "customer_name").ToString
                            newRow("shipping_name") = GVData.GetRowCellValue(i, "shipping_name").ToString
                            newRow("shipping_address") = GVData.GetRowCellValue(i, "shipping_address").ToString
                            newRow("shipping_phone") = GVData.GetRowCellValue(i, "shipping_phone").ToString
                            newRow("shipping_city") = GVData.GetRowCellValue(i, "shipping_city").ToString
                            newRow("shipping_post_code") = GVData.GetRowCellValue(i, "shipping_post_code").ToString
                            newRow("shipping_region") = GVData.GetRowCellValue(i, "shipping_region").ToString
                            newRow("payment_method") = GVData.GetRowCellValue(i, "payment_method").ToString
                            newRow("tracking_code") = GVData.GetRowCellValue(i, "tracking_code").ToString
                            newRow("id_warehouse_contact_to") = GVData.GetRowCellValue(i, "id_comp_contact_from").ToString
                            newRow("id_wh_drawer") = GVData.GetRowCellValue(i, "id_wh_drawer").ToString
                            newRow("id_store_contact_to") = GVData.GetRowCellValue(i, "id_store_contact_to").ToString
                            newRow("comp") = GVData.GetRowCellValue(i, "comp").ToString
                            newRow("store") = GVData.GetRowCellValue(i, "store").ToString
                            newRow("status") = ""
                            TryCast(FormOLStoreDet.GCDetail.DataSource, DataTable).Rows.Add(newRow)
                            FormOLStoreDet.GCDetail.RefreshDataSource()
                            FormOLStoreDet.GVDetail.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormOLStoreDet.GVDetail.BestFitColumns()
                        FormOLStoreDet.GCProduct.DataSource = dt_add
                        FormOLStoreDet.GVProduct.BestFitColumns()
                        FormOLStoreDet.PanelControlAction.Visible = True
                        Close()
                    Else
                        stopCustom("There Is no data For import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "42" Then
                'update status
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :            " + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True

                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                            Dim status As String = GVData.GetRowCellValue(i, "OrderStatus").ToString
                            Dim status_date As String = DateTime.Parse(GVData.GetRowCellValue(i, "UpdatedAt").ToString).ToString("yyyy-MM-dd HH:mm")

                            Dim query_ins As String = "INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, status, status_date, input_status_date) 
                            VALUES('" + id_sales_order_det + "', '" + status + "', '" + status_date + "', NOW()) "
                            execute_non_query(query_ins, True, "", "", "", "")

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormOLStoreDet.viewDetail()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "43" Then
                'line plan
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :            " + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True

                        Dim id_season As String = FormFGLinePlan.SLESeason.EditValue.ToString
                        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_line_plan_cat As String = GVData.GetRowCellValue(i, "id_line_plan_cat").ToString
                            Dim id_delivery As String = GVData.GetRowCellValue(i, "id_delivery").ToString
                            Dim id_division As String = GVData.GetRowCellValue(i, "id_division").ToString
                            Dim id_category As String = GVData.GetRowCellValue(i, "id_category").ToString
                            Dim id_source As String = GVData.GetRowCellValue(i, "id_source").ToString
                            Dim id_class As String = GVData.GetRowCellValue(i, "id_class").ToString
                            Dim id_color As String = GVData.GetRowCellValue(i, "id_color").ToString
                            If id_color = "0" Then
                                id_color = "NULL "
                            End If
                            Dim description As String = GVData.GetRowCellValue(i, "Description").ToString
                            Dim benchmark As String = GVData.GetRowCellValue(i, "Benchmark").ToString
                            Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, "Qty").ToString)
                            Dim mark_up As String = decimalSQL(GVData.GetRowCellValue(i, "MarkUp").ToString)
                            Dim target_price As String = decimalSQL(GVData.GetRowCellValue(i, "TargetPrice").ToString)

                            'query
                            Dim query_ins As String = "INSERT INTO tb_fg_line_plan (
                                `id_line_plan_cat`,
	                            `id_season` ,
	                            `id_delivery` ,
	                            `id_division`,
	                            `id_category` ,
	                            `id_source` ,
	                            `id_class` ,
	                            `id_color`,
	                            `description` ,
	                            `benchmark` ,
	                            `qty` ,
	                            `mark_up` ,
	                            `target_price`,
                                `input_date`
                            ) 
                            VALUES(
                                '" + id_line_plan_cat + "',
                                '" + id_season + "' ,
                                '" + id_delivery + "' ,
                                '" + id_division + "',
                                '" + id_category + "' ,
                                '" + id_source + "' ,
                                '" + id_class + "' ,
                                " + id_color + ",
                                '" + description + "' ,
                                '" + benchmark + "' ,
                                '" + qty + "' ,
                                '" + mark_up + "' ,
                                '" + target_price + "',
                                NOW()
                            ) "
                            execute_non_query(query_ins, True, "", "", "", "")

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormFGLinePlan.viewlinePlanCat()
                        FormFGLinePlan.viewData()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "44" Then 'import awb receiving inbound
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? Only 'OK' data will updated.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdAwb").ToString = "0" Then
                            '
                            Dim query_exec As String = "UPDATE tb_wh_awbill SET awbill_inv_no='" & addSlashes(GVData.GetRowCellValue(i, "inv_no_new").ToString) & "',a_weight='" & decimalSQL(GVData.GetRowCellValue(i, "a_weight_new").ToString) & "',a_tot_price='" & decimalSQL(GVData.GetRowCellValue(i, "a_tot_price_new").ToString) & "' WHERE id_awbill='" & GVData.GetRowCellValue(i, "IdAwb").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    Close()
                End If
            ElseIf id_pop_up = "45" Or id_pop_up = "46" Then 'import att nip volcom & nik sogo
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim data_employee As DataTable = FormEmpInputAttendanceDet.GCEmployee.DataSource

                    Dim allow_dept As DataTable = execute_query("SELECT allow_input_departement AS id_departement FROM tb_emp_attn_input_dep WHERE id_departement = " + id_departement_user, -1, True, "", "", "", "")

                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdEmployee").ToString = "" Then
                            Dim include_database As String = execute_query("SELECT IFNULL((SELECT input_det.id_employee FROM tb_emp_attn_input_det AS input_det LEFT JOIN tb_emp_attn_input AS input ON input_det.id_emp_attn_input = input.id_emp_attn_input WHERE input_det.id_employee = " + GVData.GetRowCellValue(i, "IdEmployee").ToString + " AND input_det.date = '" + Date.Parse(GVData.GetRowCellValue(i, "Date").ToString).ToString("yyyy-MM-dd") + "' AND input.id_report_status <> 5), 0)", 0, True, "", "", "", "")

                            FormEmpInputAttendanceDet.GVEmployee.ActiveFilterString = "[id_employee] = '" + GVData.GetRowCellValue(i, "IdEmployee").ToString + "' AND [date] = #" + Date.Parse(GVData.GetRowCellValue(i, "Date").ToString).ToString("dd MMMM yyyy") + "#"

                            If include_database = "0" And FormEmpInputAttendanceDet.GVEmployee.RowCount = 0 Then
                                Dim check_allow_dept As Boolean = True

                                If Not FormEmpInputAttendance.is_hrd = "1" Then
                                    If allow_dept.Rows.Count <= 0 Then
                                        check_allow_dept = False
                                    Else
                                        For j = 0 To allow_dept.Rows.Count - 1
                                            If Not allow_dept.Rows(j)("id_departement").ToString = GVData.GetRowCellValue(i, "IdDepartement").ToString Then
                                                check_allow_dept = False
                                            End If
                                        Next
                                    End If
                                End If

                                If check_allow_dept Then
                                    Dim time_in As Nullable(Of DateTime) = Nothing
                                    Dim time_out As Nullable(Of DateTime) = Nothing

                                    Try
                                        time_in = DateTime.Parse(Date.Parse(GVData.GetRowCellValue(i, "Date").ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(GVData.GetRowCellValue(i, "TimeIn").ToString).ToString("HH:mm:ss"))
                                    Catch ex As Exception
                                    End Try

                                    Try
                                        time_out = DateTime.Parse(Date.Parse(GVData.GetRowCellValue(i, "Date").ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(GVData.GetRowCellValue(i, "TimeOut").ToString).ToString("HH:mm:ss"))
                                    Catch ex As Exception
                                    End Try

                                    data_employee.Rows.Add("0",
                                                       GVData.GetRowCellValue(i, "IdDepartement").ToString,
                                                       GVData.GetRowCellValue(i, "Departement").ToString,
                                                       GVData.GetRowCellValue(i, "IdEmployee").ToString,
                                                       GVData.GetRowCellValue(i, "NIK").ToString,
                                                       GVData.GetRowCellValue(i, "Name").ToString,
                                                       GVData.GetRowCellValue(i, "Position").ToString,
                                                       GVData.GetRowCellValue(i, "IdEmployeeStatus").ToString,
                                                       GVData.GetRowCellValue(i, "EmployeeStatus").ToString,
                                                       GVData.GetRowCellValue(i, "Date"),
                                                       time_in,
                                                       time_out)
                                End If

                                FormEmpInputAttendanceDet.GVEmployee.ActiveFilterString = ""
                            End If
                        End If
                    Next

                    FormEmpInputAttendanceDet.GCEmployee.DataSource = data_employee
                    FormEmpInputAttendanceDet.GVEmployee.BestFitColumns()

                    infoCustom("Import Success")
                    Close()
                End If
            ElseIf id_pop_up = "47" Then 'adj inn
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :            " + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + " Are you sure want to import this " & GVData.RowCount.ToString & " data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '
                        For i As Integer = 0 To GVData.RowCount - 1
                            If Not GVData.GetRowCellValue(i, "id_product").ToString = "0" Then
                                Dim R As DataRow = (TryCast(FormFGAdjInDet.GCDetail.DataSource, DataTable)).NewRow()
                                R("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                                R("name") = GVData.GetRowCellValue(i, "name").ToString
                                R("size") = GVData.GetRowCellValue(i, "size").ToString
                                R("uom") = "pcs"
                                R("code") = GVData.GetRowCellValue(i, "code").ToString
                                R("adj_in_fg_det_qty") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString)
                                R("retail_price") = Decimal.Parse(GVData.GetRowCellValue(i, "retail_price").ToString)
                                R("adj_in_fg_det_price") = Decimal.Parse(GVData.GetRowCellValue(i, "design_cop").ToString)
                                R("adj_in_fg_det_amount") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString) * Decimal.Parse(GVData.GetRowCellValue(i, "design_cop").ToString)
                                R("retail_price_amount") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString) * Decimal.Parse(GVData.GetRowCellValue(i, "retail_price").ToString)
                                R("adj_in_fg_det_note") = GVData.GetRowCellValue(i, "note").ToString
                                R("id_wh_drawer") = GVData.GetRowCellValue(i, "id_drawer").ToString
                                R("id_wh_rack") = GVData.GetRowCellValue(i, "id_rack").ToString
                                R("id_wh_locator") = GVData.GetRowCellValue(i, "id_locator").ToString
                                R("id_comp") = GVData.GetRowCellValue(i, "id_comp").ToString
                                R("comp") = GVData.GetRowCellValue(i, "comp").ToString
                                R("wh_drawer") = GVData.GetRowCellValue(i, "drawer").ToString
                                R("wh_rack") = GVData.GetRowCellValue(i, "rack").ToString
                                R("wh_locator") = GVData.GetRowCellValue(i, "locator").ToString
                                R("comp_name") = GVData.GetRowCellValue(i, "comp").ToString
                                TryCast(FormFGAdjInDet.GCDetail.DataSource, DataTable).Rows.Add(R)
                                FormFGAdjInDet.GCDetail.RefreshDataSource()
                                FormFGAdjInDet.GVDetail.RefreshData()
                            End If
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        infoCustom("Import Success")
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "48" Then 'adj inn
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :            " + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + " Are you sure want to import this " & GVData.RowCount.ToString & " data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '
                        For i As Integer = 0 To GVData.RowCount - 1
                            If Not GVData.GetRowCellValue(i, "id_product").ToString = "0" Then
                                Dim R As DataRow = (TryCast(FormFGAdjOutDet.GCDetail.DataSource, DataTable)).NewRow()
                                R("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                                R("name") = GVData.GetRowCellValue(i, "name").ToString
                                R("size") = GVData.GetRowCellValue(i, "size").ToString
                                R("uom") = "pcs"
                                R("code") = GVData.GetRowCellValue(i, "code").ToString
                                R("adj_out_fg_det_qty") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString)
                                R("retail_price") = Decimal.Parse(GVData.GetRowCellValue(i, "retail_price").ToString)
                                R("adj_out_fg_det_price") = Decimal.Parse(GVData.GetRowCellValue(i, "design_cop").ToString)
                                R("adj_out_fg_det_amount") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString) * Decimal.Parse(GVData.GetRowCellValue(i, "design_cop").ToString)
                                R("retail_price_amount") = Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString) * Decimal.Parse(GVData.GetRowCellValue(i, "retail_price").ToString)
                                R("adj_out_fg_det_note") = GVData.GetRowCellValue(i, "note").ToString
                                R("id_wh_drawer") = GVData.GetRowCellValue(i, "id_drawer").ToString
                                R("id_wh_rack") = GVData.GetRowCellValue(i, "id_rack").ToString
                                R("id_wh_locator") = GVData.GetRowCellValue(i, "id_locator").ToString
                                R("id_comp") = GVData.GetRowCellValue(i, "id_comp").ToString
                                R("comp") = GVData.GetRowCellValue(i, "comp").ToString
                                R("wh_drawer") = GVData.GetRowCellValue(i, "drawer").ToString
                                'R("wh_rack") = GVData.GetRowCellValue(i, "rack").ToString
                                'R("wh_locator") = GVData.GetRowCellValue(i, "locator").ToString
                                'R("comp_name") = GVData.GetRowCellValue(i, "comp").ToString
                                TryCast(FormFGAdjOutDet.GCDetail.DataSource, DataTable).Rows.Add(R)
                                FormFGAdjOutDet.GCDetail.RefreshDataSource()
                                FormFGAdjOutDet.GVDetail.RefreshData()
                            End If
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        infoCustom("Import Success")
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "49" Then 'import tracking number collection
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Only 'OK' data will imported, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"

                    If GVData.RowCount > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                        '
                        Dim q As String = "INSERT INTO tb_3pl_track_no(id_comp,track_no) VALUES"

                        For i As Integer = 0 To GVData.RowCount - 1
                            If Not i = 0 Then
                                q += ","
                            End If
                            '
                            q += "('" & FormWHAwbillTrackCollection.SLECargo.EditValue.ToString & "','" & GVData.GetRowCellValue(i, "track_no").ToString & "')"
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next

                        execute_non_query(q, True, "", "", "", "")
                        infoCustom("Import Success")
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "50" Then
                GVData.ActiveFilterString = "[status] <> 'OK' "
                If GVData.RowCount > 0 Then
                    stopCustom("Data not valid, please make sure again")
                    makeSafeGV(GVData)
                Else
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[status] = 'OK' "
                    If GVData.RowCount > 0 Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Only status 'OK' will imported, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            PBC.Properties.Minimum = 0
                            PBC.Properties.Maximum = GVData.RowCount - 1
                            PBC.Properties.Step = 1
                            PBC.Properties.PercentView = True

                            'main
                            Dim query_main As String = "INSERT INTO tb_list_payout_trans(number, generate_date,id_report_status) VALUES ('" + addSlashes(FormBankDeposit.TEPayoutNumber.Text.Trim) + "', NOW(),1); SELECT LAST_INSERT_ID(); "
                            Dim id_list_payout_trans As String = execute_query(query_main, 0, True, "", "", "", "")

                            'detail data
                            Dim q As String = "INSERT INTO tb_list_payout(id_list_payout_trans,`settlement_date`, `id_pay_type`,`pay_type`, `bank`,`id`,`sales_order_ol_shop_number`,`checkout_id`,`payment`,`trans_fee`, `invoice_amount`, `calculate_fee`, `other_price`) VALUES"
                            Dim id_sales_pos As String = ""
                            Dim id_invoice_ship As String = ""
                            Dim id_list_payout_ver As String = ""

                            For i As Integer = 0 To GVData.RowCount - 1
                                If Not i = 0 Then
                                    q += ","
                                    id_sales_pos += ","
                                    id_invoice_ship += ","
                                    id_list_payout_ver += ","
                                End If
                                '
                                Dim id_order As String = GVData.GetRowCellValue(i, "id_order").ToString
                                If id_order = "0" Then
                                    id_order = "NULL"
                                End If
                                q += "('" + id_list_payout_trans + "', '" + DateTime.Parse(GVData.GetRowCellValue(i, "settle_datetime").ToString).ToString("yyyy-MM-dd HH:mm:ss") + "','" + GVData.GetRowCellValue(i, "id_pay_type").ToString + "', '" + addSlashes(GVData.GetRowCellValue(i, "pay_type").ToString) + "','" + addSlashes(GVData.GetRowCellValue(i, "bank").ToString) + "', " + id_order + ",'" + addSlashes(GVData.GetRowCellValue(i, "order_ol_shop_number").ToString) + "','" + addSlashes(GVData.GetRowCellValue(i, "checkout_id").ToString) + "','" + decimalSQL(GVData.GetRowCellValue(i, "payout").ToString) + "','" + decimalSQL(GVData.GetRowCellValue(i, "fee").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amount_inv").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "calc_fee").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "other_price").ToString) + "') "
                                id_sales_pos += GVData.GetRowCellValue(i, "id_sales_pos").ToString
                                id_invoice_ship += GVData.GetRowCellValue(i, "id_invoice_ship").ToString
                                id_list_payout_ver += GVData.GetRowCellValue(i, "id_list_payout_ver").ToString

                                '
                                PBC.PerformStep()
                                PBC.Update()
                            Next
                            'detail payout
                            execute_non_query(q, True, "", "", "", "")

                            'detail sales pos
                            Dim query_det_pos As String = "INSERT INTO tb_list_payout_det(id_list_payout_trans, id_sales_pos) 
                            SELECT '" + id_list_payout_trans + "', sp.id_sales_pos 
                            FROM tb_sales_pos sp 
                            WHERE sp.id_sales_pos IN (" + id_sales_pos + ");
                            INSERT INTO tb_list_payout_det(id_list_payout_trans, id_invoice_ship) 
                            SELECT '" + id_list_payout_trans + "', sh.id_invoice_ship 
                            FROM tb_invoice_ship sh 
                            WHERE sh.id_invoice_ship IN(" + id_invoice_ship + "); 
                            INSERT INTO tb_list_payout_det(id_list_payout_trans, id_list_payout_ver) 
                            SELECT '" + id_list_payout_trans + "',v.id_list_payout_ver 
                            FROM tb_list_payout_ver v
                            WHERE v.id_list_payout_ver IN(" + id_list_payout_ver + ");"
                            execute_non_query(query_det_pos, True, "", "", "", "")

                            'perlu approval FC
                            GVData.ActiveFilterString = "[other_price]>0"
                            If GVData.RowCount > 0 Then
                                submit_who_prepared(264, id_list_payout_trans, id_user)
                            Else
                                execute_non_query("UPDATE tb_list_payout_trans SET id_report_status=6 WHERE id_list_payout_trans='" + id_list_payout_trans + "'", True, "", "", "", "")
                            End If

                            FormBankDeposit.TEPayoutNumber.Text = ""
                            FormBankDeposit.load_payout()
                            infoCustom("Import Success")
                            Close()
                        End If
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "51" Then
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[status] = 'OK' "
                If GVData.RowCount > 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Only status 'OK' will imported, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True


                        'detail data
                        Dim id_prm As String = FormPromoCollectionDet.id
                        Dim q As String = "DELETE FROM tb_ol_promo_collection_sku WHERE id_ol_promo_collection='" + id_prm + "';INSERT INTO tb_ol_promo_collection_sku(id_ol_promo_collection, id_product, id_prod_shopify, id_design_price, design_price,qty, is_block) VALUES "
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim id_design_price As String = GVData.GetRowCellValue(i, "id_design_price").ToString
                            Dim is_block As String = GVData.GetRowCellValue(i, "is_block").ToString
                            If id_design_price = "0" Then
                                id_design_price = "NULL"
                            End If

                            If Not i = 0 Then
                                q += ","
                            End If
                            '
                            q += "('" + id_prm + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '" + GVData.GetRowCellValue(i, "id_prod_shopify").ToString + "', " + id_design_price + ", '" + decimalSQL(GVData.GetRowCellValue(i, "design_price").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "qty").ToString) + "', '" + is_block + "') "

                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        'detail 
                        If GVData.RowCount > 0 Then
                            execute_non_query(q, True, "", "", "", "")
                        End If


                        'refresh
                        FormPromoCollectionDet.refreshData()
                        FormPromoCollectionDet.viewDetail()
                        infoCustom("Import Success")
                        Close()
                    End If
                Else
                    stopCustom("There is no data for import process, please make sure your input !")
                    makeSafeGV(GVData)
                End If
            ElseIf id_pop_up = "53" Then
                'import VA
                GVData.ActiveFilterString = "[status] <> 'OK' "
                If GVData.RowCount > 0 Then
                    stopCustom("Data not valid, please make sure again")
                    makeSafeGV(GVData)
                Else
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[status] = 'OK' "
                    If GVData.RowCount > 0 Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Only status 'OK' will imported, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            PBC.Properties.Minimum = 0
                            PBC.Properties.Maximum = GVData.RowCount - 1
                            PBC.Properties.Step = 1
                            PBC.Properties.PercentView = True

                            'main
                            Dim query_main As String = "INSERT INTO tb_virtual_acc_trans(id_virtual_acc, transaction_date, generate_date) VALUES('" + FormBankDeposit.SLEBank.EditValue.ToString + "','" + DateTime.Parse(FormBankDeposit.DEVA.EditValue.ToString).ToString("yyyy-MM-dd") + "', NOW()); SELECT LAST_INSERT_ID(); "
                            Dim id_virtual_acc_trans As String = execute_query(query_main, 0, True, "", "", "", "")
                            execute_non_query("CALL gen_number(" + id_virtual_acc_trans + ", 265)", True, "", "", "", "")

                            'detail data
                            Dim q As String = "INSERT INTO tb_virtual_acc_trans_det(id_virtual_acc_trans, id, sales_order_ol_shop_number, checkout_id, payment_type, amount, amount_inv, transaction_fee, transaction_status, transaction_time, virtual_acc_no, other_price) VALUES "
                            Dim id_sales_pos As String = ""
                            Dim id_invoice_ship As String = ""
                            Dim id_list_payout_ver As String = ""
                            For i As Integer = 0 To GVData.RowCount - 1
                                If Not i = 0 Then
                                    q += ","
                                    id_sales_pos += ","
                                    id_invoice_ship += ","
                                    id_list_payout_ver += ","
                                End If
                                '
                                q += "('" + id_virtual_acc_trans + "', '" + GVData.GetRowCellValue(i, "id_order").ToString + "', '" + GVData.GetRowCellValue(i, "order_ol_shop_number").ToString + "', '" + GVData.GetRowCellValue(i, "checkout_id").ToString + "', '" + GVData.GetRowCellValue(i, "payment_type").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amount").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amount_inv").ToString) + "','" + decimalSQL(GVData.GetRowCellValue(i, "transaction_fee").ToString) + "', '" + GVData.GetRowCellValue(i, "transaction_status").ToString + "', '" + DateTime.Parse(GVData.GetRowCellValue(i, "transaction_time").ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + GVData.GetRowCellValue(i, "virtual_acc_no").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "other_price").ToString) + "') "
                                id_sales_pos += GVData.GetRowCellValue(i, "id_sales_pos").ToString
                                id_invoice_ship += GVData.GetRowCellValue(i, "id_invoice_ship").ToString
                                id_list_payout_ver += GVData.GetRowCellValue(i, "id_list_payout_ver").ToString

                                '
                                PBC.PerformStep()
                                PBC.Update()
                            Next
                            'detail payout
                            execute_non_query(q, True, "", "", "", "")

                            'detail sales pos
                            Dim query_det_pos As String = "INSERT INTO tb_virtual_acc_trans_inv(id_virtual_acc_trans, id_sales_pos) 
                            SELECT '" + id_virtual_acc_trans + "', sp.id_sales_pos 
                            FROM tb_sales_pos sp 
                            WHERE sp.id_sales_pos IN (" + id_sales_pos + ");
                            INSERT INTO tb_virtual_acc_trans_inv(id_virtual_acc_trans, id_invoice_ship) 
                            SELECT '" + id_virtual_acc_trans + "', sh.id_invoice_ship 
                            FROM tb_invoice_ship sh 
                            WHERE sh.id_invoice_ship IN(" + id_invoice_ship + "); 
                            INSERT INTO tb_virtual_acc_trans_inv(id_virtual_acc_trans, id_list_payout_ver) 
                            SELECT '" + id_virtual_acc_trans + "',v.id_list_payout_ver 
                            FROM tb_list_payout_ver v
                            WHERE v.id_list_payout_ver IN(" + id_list_payout_ver + ");"
                            execute_non_query(query_det_pos, True, "", "", "", "")

                            'perlu approval FC
                            GVData.ActiveFilterString = "[other_price]>0"
                            If GVData.RowCount > 0 Then
                                submit_who_prepared(265, id_virtual_acc_trans, id_user)
                            Else
                                execute_non_query("UPDATE tb_virtual_acc_trans SET id_report_status=6 WHERE id_virtual_acc_trans='" + id_virtual_acc_trans + "'", True, "", "", "", "")
                            End If

                            FormBankDeposit.TEPayoutNumber.Text = ""
                            FormBankDeposit.load_vacc()
                            infoCustom("Import Success")
                            Close()
                        End If
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "54" Then
                'XLS order sync
                GVData.ActiveFilterString = "[status] <> 'OK' "
                If GVData.RowCount > 0 Then
                    stopCustom("Data not valid, please make sure again")
                    makeSafeGV(GVData)
                Else
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[status] = 'OK' "
                    If GVData.RowCount > 0 Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Only status 'OK' will imported, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            PBC.Properties.Minimum = 0
                            PBC.Properties.Maximum = GVData.RowCount - 1
                            PBC.Properties.Step = 1
                            PBC.Properties.PercentView = True

                            'main
                            Dim last_order As String = ""
                            Dim id As String = ""
                            Dim id_in As String = ""
                            For i As Integer = 0 To GVData.RowCount - 1
                                Dim curr_order As String = GVData.GetRowCellValue(i, "sales_order_ol_shop_number").ToString
                                If last_order <> curr_order Then
                                    last_order = curr_order
                                    Dim query_get_id As String = "UPDATE tb_opt SET xls_order_inc=xls_order_inc+1; SELECT xls_order_inc FROM tb_opt;"
                                    id = execute_query(query_get_id, 0, True, "", "", "", "")

                                    If id_in <> "" Then
                                        id_in += ","
                                    End If
                                    id_in += id
                                End If
                                Dim id_comp_group As String = FormOLStore.SLEOLStore.EditValue.ToString
                                Dim sales_order_ol_shop_number As String = GVData.GetRowCellValue(i, "sales_order_ol_shop_number").ToString
                                Dim ol_store_sku As String = GVData.GetRowCellValue(i, "ol_store_sku").ToString
                                Dim ol_store_id As String = GVData.GetRowCellValue(i, "ol_store_id").ToString
                                Dim item_id As String = GVData.GetRowCellValue(i, "item_id").ToString
                                Dim checkout_id As String = GVData.GetRowCellValue(i, "checkout_id").ToString
                                Dim tracking_code As String = GVData.GetRowCellValue(i, "tracking_code").ToString
                                Dim sales_order_ol_shop_date As String = DateTime.Parse(GVData.GetRowCellValue(i, "sales_order_ol_shop_date").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                                Dim sku As String = GVData.GetRowCellValue(i, "sku").ToString
                                Dim design_price As String = decimalSQL(GVData.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_order_det_qty As String = decimalSQL(GVData.GetRowCellValue(i, "sales_order_det_qty").ToString)
                                Dim grams As String = decimalSQL(GVData.GetRowCellValue(i, "grams").ToString)
                                Dim total_disc_order As String = decimalSQL(GVData.GetRowCellValue(i, "total_disc_order").ToString)
                                Dim discount_allocations_amo As String = decimalSQL(GVData.GetRowCellValue(i, "discount_allocations_amo").ToString)
                                Dim discount_allocations_ol_shop As String = decimalSQL(GVData.GetRowCellValue(i, "discount_allocations_ol_shop").ToString)
                                Dim customer_name As String = addSlashes(GVData.GetRowCellValue(i, "customer_name").ToString)
                                Dim shipping_name As String = addSlashes(GVData.GetRowCellValue(i, "shipping_name").ToString)
                                Dim shipping_address As String = addSlashes(GVData.GetRowCellValue(i, "shipping_address").ToString)
                                Dim shipping_address1 As String = addSlashes(GVData.GetRowCellValue(i, "shipping_address1").ToString)
                                Dim shipping_address2 As String = addSlashes(GVData.GetRowCellValue(i, "shipping_address2").ToString)
                                Dim shipping_phone As String = addSlashes(GVData.GetRowCellValue(i, "shipping_phone").ToString)
                                Dim shipping_post_code As String = addSlashes(GVData.GetRowCellValue(i, "shipping_post_code").ToString)
                                Dim shipping_city As String = addSlashes(GVData.GetRowCellValue(i, "shipping_city").ToString)
                                Dim shipping_region As String = addSlashes(GVData.GetRowCellValue(i, "shipping_region").ToString)
                                Dim shipping_district As String = addSlashes(GVData.GetRowCellValue(i, "shipping_district").ToString)
                                Dim payment_method As String = addSlashes(GVData.GetRowCellValue(i, "payment_method").ToString)
                                Dim query As String = "INSERT INTO tb_ol_store_order(
                                id,
                                id_comp_group, 
                                sales_order_ol_shop_number, 
                                ol_store_sku , 
                                ol_store_id, 
                                item_id,
                                checkout_id ,
                                tracking_code ,
                                sales_order_ol_shop_date ,
                                sku,
                                design_price ,
                                sales_order_det_qty,
                                grams ,
                                total_disc_order ,
                                discount_allocations_amo ,
                                discount_allocations_ol_shop ,
                                customer_name,
                                shipping_name ,
                                shipping_address ,
                                shipping_address1 ,
                                shipping_address2 ,
                                shipping_phone ,
                                shipping_post_code ,
                                shipping_city ,
                                shipping_region ,
                                shipping_district ,
                                payment_method 
                                )
                                VALUES(
                                '" + id + "',
                                '" + id_comp_group + "', 
                                '" + sales_order_ol_shop_number + "', 
                                '" + ol_store_sku + "' , 
                                '" + ol_store_id + "', 
                                '" + item_id + "',
                                '" + checkout_id + "' ,
                                '" + tracking_code + "' ,
                                '" + sales_order_ol_shop_date + "' ,
                                '" + sku + "',
                                '" + design_price + "' ,
                                '" + sales_order_det_qty + "',
                                '" + grams + "' ,
                                '" + total_disc_order + "' ,
                                '" + discount_allocations_amo + "' ,
                                '" + discount_allocations_ol_shop + "' ,
                                '" + customer_name + "',
                                '" + shipping_name + "' ,
                                '" + shipping_address + "' ,
                                '" + shipping_address1 + "',
                                '" + shipping_address2 + "',
                                '" + shipping_phone + "',
                                '" + shipping_post_code + "' ,
                                '" + shipping_city + "',
                                '" + shipping_region + "',
                                '" + shipping_district + "',
                                '" + payment_method + "' 
                                );"
                                execute_non_query(query, True, "", "", "", "")
                                PBC.PerformStep()
                                PBC.Update()
                            Next
                            FormOLStore.syncOrder()

                            Close()
                        End If
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "55" Then
                'payout zalora
                makeSafeGV(GVData)
                If GVData.RowCount > 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This process will be replace data that was previously imported. Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = GVData.RowCount - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True

                        'main
                        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                            FormMain.SplashScreenManager1.ShowWaitForm()
                        End If
                        Dim id_payout_zalora As String = FormPayoutZaloraDet.id
                        Dim query_del As String = "DELETE FROM tb_payout_zalora_det WHERE  id_payout_zalora='" + id_payout_zalora + "'; "
                        execute_non_query(query_del, True, "", "", "", "")
                        Dim allow_packet As String = get_setup_field("allow_packet")
                        Dim query As String = ""
                        Dim p As Integer = 0
                        Dim lim As Integer = 1000
                        For i As Integer = 0 To GVData.RowCount - 1
                            FormMain.SplashScreenManager1.SetWaitFormDescription("Build query " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                            Dim transaction_date As String = DateTime.Parse(GVData.GetRowCellValue(i, "Transaction Date").ToString).ToString("yyyy-MM-dd")
                            Dim transaction_type As String = addSlashes(GVData.GetRowCellValue(i, "Transaction Type").ToString)
                            Dim transaction_number As String = addSlashes(GVData.GetRowCellValue(i, "Transaction Number").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(i, "Amount").ToString)
                            Dim vat_in_amount As String = decimalSQL(GVData.GetRowCellValue(i, "VAT in Amount").ToString)
                            Dim wht_amount As String = decimalSQL(GVData.GetRowCellValue(i, "WHT Amount").ToString)
                            Dim order_number As String = GVData.GetRowCellValue(i, "Order No#").ToString
                            Dim item_id As String = GVData.GetRowCellValue(i, "Order Item No#").ToString
                            Dim ol_store_id As String = GVData.GetRowCellValue(i, "Zalora Item No#").ToString
                            Dim order_status As String = addSlashes(GVData.GetRowCellValue(i, "Order Item Status").ToString)
                            Dim reference As String = addSlashes(GVData.GetRowCellValue(i, "Reference").ToString)
                            Dim comment As String = addSlashes(GVData.GetRowCellValue(i, "Comment").ToString)
                            Dim zalora_sku As String = addSlashes(GVData.GetRowCellValue(i, "Seller SKU").ToString)
                            Dim zalora_product_name As String = addSlashes(GVData.GetRowCellValue(i, "Details").ToString)

                            If p <= 0 Then
                                query = "INSERT INTO tb_payout_zalora_det(
                                id_payout_zalora, 
                                transaction_date, 
                                transaction_type, 
                                transaction_number, 
                                amount, 
                                vat_in_amount, 
                                wht_amount, 
                                order_number, 
                                item_id, 
                                ol_store_id, 
                                order_status,
                                reference,
                                comment,
                                zalora_sku,
                                zalora_product_name
                                ) VALUES "
                            Else
                                query += ", "
                            End If

                            query += "(
                            '" + id_payout_zalora + "',
                            '" + transaction_date + "',
                            '" + transaction_type + "',
                            '" + transaction_number + "',
                            '" + amount + "',
                            '" + vat_in_amount + "', 
                            '" + wht_amount + "',
                            '" + order_number + "',
                            '" + item_id + "',
                            '" + ol_store_id + "',
                            '" + order_status + "',
                            '" + reference + "',
                            '" + comment + "',
                            '" + zalora_sku + "',
                            '" + zalora_product_name + "'
                            ) "

                            PBC.PerformStep()
                            PBC.Update()

                            If p = lim Or i = (GVData.RowCount - 1) Then
                                FormMain.SplashScreenManager1.SetWaitFormDescription("Importing data")
                                execute_non_query_long(query, True, "", "", "", "")
                                p = 0
                            Else
                                p += 1
                            End If
                        Next
                        FormMain.SplashScreenManager1.CloseWaitForm()
                        FormPayoutZaloraDet.validate_payout(True)
                        Close()
                    End If
                Else
                    stopCustom("There is no data for import process, please make sure your input !")
                    makeSafeGV(GVData)
                End If
            ElseIf id_pop_up = "56" Then
                'too for product promo
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    FormSalesOrderDet.viewDetail(FormSalesOrderDet.id_sales_order)

                    GVData.ActiveFilterString = "[Status] = 'OK' "
                    If GVData.RowCount > 0 Then
                        FormSalesOrderDet.delNotFoundMyRow()
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("qty_avail") = GVData.GetRowCellValue(i, "Available")
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString
                            newRow("amount") = GVData.GetRowCellValue(i, "Price") * GVData.GetRowCellValue(i, "Qty")
                            newRow("sales_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("is_found") = "1"
                            newRow("id_ol_promo_collection_sku_replace") = GVData.GetRowCellValue(i, "id_ol_promo_collection_sku_replace").ToString
                            TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesOrderDet.GCItemList.RefreshDataSource()
                            FormSalesOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesOrderDet.BtnAddV2.Visible = False
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "List Import Excel")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GVData.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currentDataView As DataView = TryCast(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).DataSource, DataView)
        If view.FocusedColumn.FieldName = "Code" Then
            'check duplicate code
            Dim currentCode As String = e.Value.ToString()
            For i As Integer = 0 To currentDataView.Count - 1
                If i <> view.GetDataSourceRowIndex(view.FocusedRowHandle) Then
                    If currentDataView(i)("Code").ToString() = currentCode Then
                        MsgBox("Duplicate Code detected.")
                        e.ErrorText = "Duplicate Code detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FormImportExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        If id_pop_up = "6" Or id_pop_up = "18" Then
            TBFileAddress.Text = My.Application.Info.DirectoryPath.ToString & "\import\sales_pos.xlsx"
            fill_combo_worksheet()
        End If

        'enable button other action
        If id_pop_up = "41" Then
            BtnAction.Visible = True
            BtnAction.Enabled = False
            BtnAction.Text = "Check Stock"
        Else
            BtnAction.Visible = False
        End If

        'enable dropmenu
        If id_pop_up = "50" Or id_pop_up = "53" Then
            GCData.ContextMenuStrip = CMSImport
            OtherActionToolStripMenuItem.Text = "Reconcile && Upload BAP"
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.DeleteSelectedRows()
            GCData.RefreshDataSource()
            GVData.RefreshData()
        End If
    End Sub


    Private Sub BtnAction_Click(sender As Object, e As EventArgs) Handles BtnAction.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "41" Then
            FormOLStoreDetCheckStockvb.dt = dt_add
            FormOLStoreDetCheckStockvb.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub OtherActionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherActionToolStripMenuItem.Click
        If id_pop_up = "50" Or id_pop_up = "53" Then
            'cek delivery
            Dim id_sales_pos As String = GVData.GetFocusedRowCellValue("id_sales_pos").ToString
            Dim id_web_order As String = GVData.GetFocusedRowCellValue("id_order").ToString
            Dim order_number As String = GVData.GetFocusedRowCellValue("order_ol_shop_number").ToString
            Dim checkout_id As String = GVData.GetFocusedRowCellValue("checkout_id").ToString
            Dim type_ver As String = ""
            If id_pop_up = "50" Then
                type_ver = "1"
            ElseIf id_pop_up = "53" Then
                type_ver = "2"
            End If
            Dim is_existing_order As String = ""
            If id_web_order = "0" Then
                is_existing_order = "2"
            Else
                is_existing_order = "1"
            End If
            Dim status_import As String = GVData.GetFocusedRowCellValue("Status").ToString

            'cek sudah ada ato belum
            Dim qex As String = "SELECT * FROM tb_list_payout_ver v WHERE v.checkout_id='" + checkout_id + "' AND type_ver='" + type_ver + "' "
            Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
            If dex.Rows.Count <= 0 Then
                If status_import <> "OK" Then
                    Dim query_cek As String = "SELECT so.* FROM tb_sales_order so 
                    LEFT JOIN tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order
                    WHERE so.id_report_status=6 AND so.id_sales_order_ol_shop=" + id_web_order + " 
                    AND (so.id_prepare_status=1 OR (so.id_prepare_status=2 AND !ISNULL(del.id_sales_order))) "
                    Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                    If data_cek.Rows.Count > 0 And id_sales_pos = "0" Then
                        stopCustom("Order on process")
                    Else
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to verify this order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim query As String = "INSERT INTO tb_list_payout_ver(id_web_order, order_number, checkout_id, created_date, created_by, type_ver, is_existing_order) 
                            VALUES('" + id_web_order + "', '" + order_number + "','" + checkout_id + "', NOW(), '" + id_user + "', '" + type_ver + "', '" + is_existing_order + "'); SELECT LAST_INSERT_ID(); "
                            Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
                            execute_non_query("CALL gen_number(" + id_new + ", 266)", True, "", "", "", "")
                            FormPayoutVerDet.id = id_new
                            FormPayoutVerDet.ShowDialog()
                        End If
                    End If
                Else
                    stopCustom("Only for problem order")
                End If
            Else
                FormPayoutVerDet.id = dex.Rows(0)("id_list_payout_ver").ToString
                FormPayoutVerDet.ShowDialog()
            End If
            fill_combo_worksheet()
        End If
    End Sub
End Class