Imports System.Data.OleDb

Public Class FormAWBOtherInv

    Public id_verification As String = "-1"
    Public copy_file_path As String = ""
    Public is_view As String = "-1"

    Private Sub FormAWBInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_3pl()
        '
        load_form()
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 3 AS id_type,'Office' AS type"
        viewSearchLookupQuery(SLETypeImport, q, "id_type", "type", "id_type")
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
    End Sub

    Sub load_form()
        If id_verification = "-1" Then
            'new
            BSubmit.Visible = False
            XTPImport.PageVisible = True
            XTPVerification.PageVisible = False
        Else
            'edit
            XTPImport.PageVisible = False
            XTPVerification.PageVisible = True

            Dim q As String = "SELECT * 
FROM `tb_awb_inv_sum`
WHERE id_awb_inv_sum='" & id_verification & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLE3PL.EditValue = dt.Rows(0)("id_comp").ToString
                TEInvoiceNumber.EditValue = dt.Rows(0)("inv_number").ToString
                SLEType.EditValue = dt.Rows(0)("id_type").ToString
                load_det()
                '
                XTPImport.PageVisible = False
                SLE3PL.Properties.ReadOnly = True
                SLEType.Properties.ReadOnly = True
                TEInvoiceNumber.Enabled = False
                '
                If dt.Rows(0)("is_submit").ToString = "1" Then
                    BSaveDraft.Visible = False
                    BSubmit.Visible = False
                    BMark.Visible = True
                    BtnPrint.Visible = True
                Else
                    BSubmit.Visible = True
                    BSaveDraft.Visible = True
                End If
                '
                If Not dt.Rows(0)("id_report_status") = "6" And Not dt.Rows(0)("id_report_status") = "5" Then
                    BCancel.Visible = True
                Else
                    BCancel.Visible = False
                    BSaveDraft.Visible = False
                    BSubmit.Visible = False
                End If
            End If
        End If
    End Sub

    Sub load_det()
        Dim q As String = ""
        If SLEType.EditValue.ToString = "3" Then 'office
            q = "(
	SELECT '' AS `no`,id.`id_awb_office_det`,dis.sub_district,id.id_departement,dep.departement AS departement
	,id.awb_no AS `awbill_no`
	,d.pickup_date
	,dd.`jml_koli` AS jml_koli
	,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
	,id.note_wh,id.berat_final,id.amount_final
	,id.rate_cargo
	FROM tb_awb_inv_sum_other id
	INNER JOIN tb_awb_office_det dd ON id.id_awb_office_det=dd.id_awb_office_det
	INNER JOIN `tb_awb_office` d ON dd.`id_awb_office`=d.`id_awb_office`
	INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=dd.id_sub_district AND d.`is_void`=2
	INNER JOIN tb_m_departement dep ON dep.id_departement=id.id_departement 
	WHERE id.id_awb_inv_sum='" & id_verification & "' AND NOT ISNULL(id.id_awb_office_det)
	GROUP BY id.`id_awb_office_det`
)
UNION ALL
(
	SELECT '' AS `no`,'' AS `id_awb_office_det`,'' AS sub_district,IFNULL(id.id_departement,'') AS id_departement,IFNULL(dep.departement,'') AS departement
	,id.awb_no AS `awbill_no`
	,NULL AS pickup_date
	,1 AS jml_koli
	,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
	,id.note_wh,id.berat_final,id.amount_final
	,id.rate_cargo
	FROM tb_awb_inv_sum_other id
    LEFT JOIN tb_m_departement dep ON dep.id_departement=id.id_departement 
	WHERE id.id_awb_inv_sum='" & id_verification & "' AND ISNULL(id.id_awb_office_det)
)"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Sub load_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLE3PL, query, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLE3PLImport, query, "id_comp", "comp_name", "id_comp")
    End Sub

    '    Private Sub Bload_Click(sender As Object, e As EventArgs)
    '        Dim q As String = "SELECT '' AS no,d.`id_del_manifest`,dis.sub_district,d.id_comp,IF(d.`is_ol_shop`=1,cg.comp_group,store.comp_number) AS comp_number,IF(d.`is_ol_shop`=1,cg.description,store.comp_name) AS comp_name
    ',d.`awbill_inv_no`,d.`awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
    ',d.`cargo_rate`
    ',odm.created_date AS pickup_date
    ',COUNT(dd.`id_del_manifest_det`) AS collie
    ',d.`c_weight`,d.`c_tot_price`,d.`a_weight`,d.`a_tot_price`
    ','' AS note_wh
    'FROM tb_del_manifest_det dd 
    'INNER JOIN `tb_del_manifest` d ON dd.`id_del_manifest`=d.`id_del_manifest`
    'INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district AND d.`id_report_status`=6
    'INNER JOIN tb_m_comp store ON store.id_comp=id_store_offline 
    'INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=d.id_comp_group
    'INNER JOIN tb_odm_sc_det odmd ON odmd.id_del_manifest=d.`id_del_manifest`
    'INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc
    'WHERE d.id_comp='" & SLE3PL.EditValue.ToString & "' AND d.awbill_inv_no='" & SLEInvoice.EditValue.ToString & "'
    'GROUP BY d.`id_del_manifest`"
    '        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
    '        GCInvoice.DataSource = dt
    '        GVInvoice.BestFitColumns()
    '    End Sub

    Private Sub FormAWBInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        If GVInvoice.RowCount > 0 Then
            save()

            Dim is_no_departement As Boolean = False
            For i = 0 To GVInvoice.RowCount - 1
                If GVInvoice.GetRowCellValue(i, "id_departement").ToString = "" Then
                    is_no_departement = True
                    Exit For
                End If
            Next

            If is_no_departement Then
                warningCustom("Please choose empty departement.")
            Else
                Dim is_zero_ok As Boolean = True

                Dim q As String = "UPDATE tb_awb_inv_sum SET is_submit='1' WHERE id_awb_inv_sum='" & id_verification & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("318", id_verification, id_user)
                '
                infoCustom("Verification submitted")
                '
                load_form()
                'FormAWBOther.load_verification()
            End If
        Else
            warningCustom("No awb found")
        End If
    End Sub

    Private Sub BSaveDraft_Click(sender As Object, e As EventArgs) Handles BSaveDraft.Click
        save()
    End Sub

    Sub save()
        If id_verification = "-1" Then
            'new

        Else
            'edit
            If GVInvoice.RowCount > 0 Then
                Dim q As String = ""

                'q = "UPDATE tb_awb_inv_sum SET id_comp='" & SLE3PL.EditValue.ToString & "',inv_number='" & addSlashes(SLEInvoice.EditValue.ToString) & "' WHERE id_awb_inv_sum='" & id_verification & "'"
                'execute_non_query(q, True, "", "", "", "")

                'delete all
                q = "DELETE FROM tb_awb_inv_sum_other WHERE id_awb_inv_sum='" & id_verification & "'"
                execute_non_query(q, True, "", "", "", "")
                'detail
                q = "INSERT INTO tb_awb_inv_sum_other(`id_awb_inv_sum`,`awb_no`,`id_awb_office_det`,`berat_cargo`,`rate_cargo`,`amount_cargo`,`berat_final`,`amount_final`,`note_wh`,`id_departement`) VALUES"
                For i As Integer = 0 To GVInvoice.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    Dim id_reff As String = ""
                    If GVInvoice.GetRowCellValue(i, "id_awb_office_det").ToString = "" Then
                        id_reff = "NULL"
                    Else
                        id_reff = "'" & GVInvoice.GetRowCellValue(i, "id_awb_office_det").ToString & "'"
                    End If

                    Dim id_departement As String = ""
                    If GVInvoice.GetRowCellValue(i, "id_departement").ToString = "" Then
                        id_departement = "NULL"
                    Else
                        id_departement = "'" & GVInvoice.GetRowCellValue(i, "id_departement").ToString & "'"
                    End If

                    q += "('" & id_verification & "','" & addSlashes(GVInvoice.GetRowCellValue(i, "awbill_no").ToString) & "'," & id_reff & ",'" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "rate_cargo").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_tot_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "berat_final").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "amount_final").ToString).ToString) & "','" & addSlashes(GVInvoice.GetRowCellValue(i, "note_wh").ToString) & "'," & id_departement & ")"
                Next
                execute_non_query(q, True, "", "", "", "")

                load_form()
                FormAWBOther.load_verification()
            Else
                warningCustom("No awb found")
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportAwbInv.id_ver = id_verification
        ReportAwbInv.dt = GCInvoice.DataSource
        ReportAwbInv.rmt = "318"
        Dim Report As New ReportAwbInv()

        For Each c In GVInvoice.FormatRules
            c.Enabled = False
        Next

        GridColumnNo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GridColumnNo.VisibleIndex = 0

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVInvoice.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVInvoice.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        ReportStyleGridview(Report.GVInvoice)
        Report.GVInvoice.AppearancePrint.Row.Font = New Font("Segoe UI", 5, FontStyle.Regular)
        Report.GVInvoice.BestFitColumns()

        GridColumnNo.SortOrder = DevExpress.Data.ColumnSortOrder.None
        GridColumnNo.VisibleIndex = -1

        'Parse val
        Dim q As String = "SELECT inv.inv_number,DATE_FORMAT(inv.created_date,'%d %M %Y') AS created_date,c.comp_name ,IF(inv.id_type=3,'Office','') AS del_type
FROM `tb_awb_inv_sum` inv
INNER JOIN tb_m_comp c ON c.`id_comp`=inv.`id_comp`
WHERE inv.id_awb_inv_sum='" & id_verification & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        Report.DataSource = dt

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        For Each c In GVInvoice.FormatRules
            c.Enabled = True
        Next

        Cursor = Cursors.Default
    End Sub

    Private Sub GVInvoice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVInvoice.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BBrowse.Click
        Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C:\"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            'use save as
            Dim open_file As String = ""

            'If is_save_as Then
            '    Cursor = Cursors.WaitCursor
            '    Dim path As String = Application.StartupPath & "\download\"
            '    'create directory if not exist
            '    If Not IO.Directory.Exists(path) Then
            '        System.IO.Directory.CreateDirectory(path)
            '    End If
            '    path = path + "file_temp.xls"
            '    Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
            '    Dim temp As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)
            '    'delete file
            '    Try
            '        My.Computer.FileSystem.DeleteFile(path)
            '    Catch ex As Exception
            '    End Try
            '    temp.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
            '    temp.Close()
            '    app.Quit()
            '    open_file = path
            '    Cursor = Cursors.Default
            'Else
            '    open_file = fdlg.FileName
            'End If

            open_file = fdlg.FileName

            TBFileAddress.Text = ""
            TBFileAddress.Text = open_file
        End If
        fdlg.Dispose()
    End Sub

    Private Sub TBFileAddress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFileAddress.EditValueChanged
        If Not TBFileAddress.Text = "" Then
            fill_combo_worksheet()
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
    End Sub

    Sub fill_field_grid_inv()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] WHERE not ([awb]='')", oledbconn)

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        Try

            Dim queryx As String = ""
            If SLETypeImport.EditValue.ToString = "3" Then
                queryx = "SELECT '' AS `no`,dd.`id_awb_office_det`,dis.sub_district,dd.id_departement,dep.`departement`
,dd.`awbill_no`
,d.pickup_date
,dd.`jml_koli`
FROM `tb_awb_office_det` dd 
INNER JOIN `tb_awb_office` d ON dd.`id_awb_office`=d.`id_awb_office` AND d.id_comp='" & SLE3PLImport.EditValue.ToString & "'
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=dd.id_sub_district AND d.`is_void`=2
INNER JOIN tb_m_departement dep ON dep.`id_departement`=dd.`id_departement`"
            End If

            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2
                            On table1("AWB").ToString.Replace("'", "").ToLower Equals table_tmp("awbill_no").ToString.ToLower Into awb = Group
                        From result_awb In awb.DefaultIfEmpty()
                        Select New With
                            {
                                .id_awb_office_det = If(result_awb Is Nothing, "0", result_awb("id_awb_office_det")),
                                .inv_number = If(table1("Nomor Invoice").ToString = "", "", table1("Nomor Invoice")),
                                .awbill_no = If(result_awb Is Nothing, table1("AWB").ToString.Replace("'", ""), result_awb("awbill_no")),
                                .sub_district = If(result_awb Is Nothing, "", result_awb("sub_district")),
                                .id_departement = If(result_awb Is Nothing, "0", result_awb("id_departement")),
                                .departement = If(result_awb Is Nothing, "", result_awb("departement")),
                                .a_weight = If(table1("Berat").ToString = "", 0, table1("Berat")),
                                .a_tot_price = If(table1("Cargo Rate").ToString = "" Or table1("Berat").ToString = "", 0, Decimal.Parse(table1("Cargo Rate").ToString) * Decimal.Parse(table1("Berat").ToString)),
                                .a_rate = If(table1("Cargo Rate").ToString = "", 0, table1("Cargo Rate")),
                                .pickup_date = If(result_awb Is Nothing, "", result_awb("pickup_date")),
                                .jml_koli = If(result_awb Is Nothing, 1, result_awb("jml_koli")),
                                .note = If(result_awb Is Nothing, "AWB Number not found", "OK")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()

            'get invoice number
            GVData.ActiveFilterString = "[inv_number] <> ''"
            If GVData.RowCount > 0 Then
                TEInvNumberImport.Text = GVData.GetRowCellValue(0, "inv_number").ToString()
            End If
            GVData.ActiveFilterString = ""

            'check awb sudah pernah di verifikasi + duplicate
            Dim is_duplicate As Boolean = False
            Dim is_already As Boolean = False

            Dim list_awb As String = ""
            For i = 0 To GVData.RowCount - 1
                If Not i = 0 Then
                    list_awb += ","
                End If
                list_awb += "'" & GVData.GetRowCellValue(i, "awbill_no").ToString & "'"

                'check duplicate
                For j = i To GVData.RowCount - 1
                    If Not j = i Then 'bukan row sama
                        If GVData.GetRowCellValue(i, "awbill_no").ToString = GVData.GetRowCellValue(j, "awbill_no").ToString Then
                            is_duplicate = True
                            GVData.SetRowCellValue(j, "note", "AWB duplicate")
                            Exit For
                        End If
                    End If
                Next
            Next

            If Not list_awb = "" Then
                Dim qlist As String = "SELECT inv.inv_number,invd.awb_no FROM
`tb_awb_inv_sum_other` invd
INNER JOIN tb_awb_inv_sum inv ON inv.`id_awb_inv_sum`=invd.`id_awb_inv_sum` AND inv.`id_report_status`!=5
WHERE awb_no IN (" & list_awb & ") AND inv.id_comp='" & SLE3PLImport.EditValue.ToString & "' AND invd.amount_final>0 "
                Dim dtlist As DataTable = execute_query(qlist, -1, True, "", "", "", "")
                If dtlist.Rows.Count > 0 Then
                    For i = 0 To dtlist.Rows.Count - 1
                        GVData.ActiveFilterString = "[awbill_no] = '" & dtlist.Rows(i)("awb_no").ToString & "'"
                        If GVData.RowCount > 0 Then
                            is_already = True
                            GVData.SetRowCellValue(0, "note", "AWB already verified (" & dtlist.Rows(i)("inv_number").ToString & ")")
                        End If
                        GVData.ActiveFilterString = ""
                    Next
                End If
            End If

            If is_already Then
                warningCustom("AWB already verified")
            ElseIf is_duplicate Then
                warningCustom("AWB duplicate")
            Else
                BVerify.Visible = True
            End If

            GVData.BestFitColumns()
            '
            SLE3PLImport.Properties.ReadOnly = True
            TEInvNumberImport.Enabled = False
            SLETypeImport.Properties.ReadOnly = True
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try

        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        'If TEInvNumberImport.Text = "" Then
        '    warningCustom("Please put invoice number")
        'Else
        'Dim qc As String = "SELECT * FROM tb_awb_inv_sum WHERE id_report_status!=5 AND inv_number='" & addSlashes(TEInvNumberImport.Text) & "' AND id_comp='" & SLE3PLImport.EditValue.ToString & "'"
        'Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        'If dtc.Rows.Count > 0 Then
        '    warningCustom("Invoice sudah pernah di verifikasi")
        'Else

        'End If
        'End If
        If Not CBWorksheetName.EditValue = "" Then
            Cursor = Cursors.WaitCursor
            fill_field_grid_inv()
            Cursor = Cursors.Default
        Else
            warningCustom("Periksa kembali file import anda, sheet tidak ditemukan")
        End If
    End Sub

    Private Sub BVerify_Click(sender As Object, e As EventArgs) Handles BVerify.Click
        If TEInvNumberImport.Text = "" Then
            warningCustom("Invoice number not found")
        Else
            Dim qch As String = "SELECT * FROM tb_awb_inv_sum WHERE id_report_status!=5 AND inv_number='" & addSlashes(TEInvNumberImport.Text) & "' AND id_comp='" & SLE3PLImport.EditValue.ToString & "'"
            Dim dtch As DataTable = execute_query(qch, -1, True, "", "", "", "")
            If dtch.Rows.Count > 0 Then
                warningCustom("Invoice sudah pernah di verifikasi")
            Else
                If GVData.RowCount > 0 Then
                    Dim q As String = "INSERT INTO tb_awb_inv_sum(created_by,created_date,id_report_status,id_comp,inv_number,id_type,is_other) VALUES('" & id_user & "',NOW(),1,'" & SLE3PLImport.EditValue.ToString & "','" & addSlashes(TEInvNumberImport.EditValue.ToString) & "','" & SLETypeImport.EditValue.ToString & "','1'); SELECT LAST_INSERT_ID(); "
                    id_verification = execute_query(q, 0, True, "", "", "", "")

                    'detail
                    q = "INSERT INTO tb_awb_inv_sum_other(`id_awb_inv_sum`,`awb_no`,`id_awb_office_det`,`berat_cargo`,`rate_cargo`,`amount_cargo`,`berat_final`,`amount_final`,`note_wh`,`id_departement`) VALUES"
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If

                        Dim berat_final As String = "0"
                        Dim amount_final As String = "0"
                        berat_final = decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "a_weight").ToString).ToString)
                        amount_final = decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "a_tot_price").ToString).ToString)

                        Dim id_dep As String = "NULL"
                        If Not GVData.GetRowCellValue(i, "id_departement").ToString = "0" Then
                            id_dep = "'" & GVData.GetRowCellValue(i, "id_departement").ToString & "'"
                        End If

                        Dim id_reff As String = "NULL"
                        If Not GVData.GetRowCellValue(i, "id_awb_office_det").ToString = "0" Then
                            id_reff = "'" & GVData.GetRowCellValue(i, "id_awb_office_det").ToString & "'"
                        End If

                        q += "('" & id_verification & "','" & GVData.GetRowCellValue(i, "awbill_no").ToString & "'," & id_reff & ",'" & decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "a_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "a_rate").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "a_tot_price").ToString).ToString) & "','" & berat_final & "','" & amount_final & "',''," & id_dep & ")"
                    Next
                    execute_non_query(q, True, "", "", "", "")

                    'FormAWBOther.load_verification()
                    load_form()
                Else
                    warningCustom("No awb found")
                End If
            End If
        End If
    End Sub

    Private Sub BDownloadFileKonsolidasi_Click(sender As Object, e As EventArgs)
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.FileName = TEInvoiceNumber.Text
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim opt As DevExpress.XtraPrinting.XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions
            opt.SheetName = "rekonsiliasi"
            GridColumnNo.VisibleIndex = -1
            GVInvoice.ActiveFilterString = "[diff_amount]<0"
            GVInvoice.ExportToXlsx(save.FileName, opt)
            GVInvoice.ActiveFilterString = ""
            GridColumnNo.VisibleIndex = 0

            Process.Start(save.FileName)
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_verification
        FormReportMark.report_mark_type = "318"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
    End Sub

    Public Shared Function ToDataTable(Of T)(ByVal data As IList(Of T)) As DataTable
        Dim properties As ComponentModel.PropertyDescriptorCollection = ComponentModel.TypeDescriptor.GetProperties(GetType(T))
        Dim table As DataTable = New DataTable()

        For Each prop As ComponentModel.PropertyDescriptor In properties
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next

        For Each item As T In data
            Dim row As DataRow = table.NewRow()

            For Each prop As ComponentModel.PropertyDescriptor In properties
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next

            table.Rows.Add(row)
        Next

        Return table
    End Function

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Dim q As String = "UPDATE tb_awb_inv_sum SET id_report_status='5' WHERE id_awb_inv_sum='" & id_verification & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            delete_all_mark_related("318", id_verification)
            '
            load_form()
        End If
    End Sub

    Private Sub SMAddVendor_Click(sender As Object, e As EventArgs) Handles SMAddVendor.Click
        If GVInvoice.RowCount > 0 Then
            If GVInvoice.GetFocusedRowCellValue("id_awb_office_det").ToString = "" Then
                FormPopUpDept.id_pop_up = "4"
                FormPopUpDept.ShowDialog()
            Else
                warningCustom("Departement locked")
            End If
        End If
    End Sub
End Class