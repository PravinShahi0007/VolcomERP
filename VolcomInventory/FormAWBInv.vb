Imports System.Data.OleDb

Public Class FormAWBInv
    Public id_verification As String = "-1"
    Public copy_file_path As String = ""

    Private Sub FormAWBInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_3pl()
        '
        load_form()
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'Outbound' AS type
UNION ALL
SELECT 1 AS id_type,'Outbound' AS type"
        viewSearchLookupQuery(SLETypeImport, q, "id_type", "type", "id_type")
    End Sub

    Sub load_form()
        If id_verification = "-1" Then
            'new
            BSubmit.Visible = False
        Else
            'edit
            BAttachment.Visible = True

            Dim q As String = "SELECT * 
FROM `tb_awb_inv_sum`
WHERE id_awb_inv_sum='" & id_verification & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLUE3PL.EditValue = dt.Rows(0)("id_comp").ToString
                SLEInvoice.EditValue = dt.Rows(0)("inv_number").ToString
                load_det()
                '
                If dt.Rows(0)("is_submit").ToString = "1" Then
                    BSaveDraft.Visible = False
                    BSubmit.Visible = False
                    BMark.Visible = True
                    BtnPrint.Visible = True
                    '
                    Bload.Visible = False
                    SLUE3PL.Properties.ReadOnly = True
                    SLEInvoice.Properties.ReadOnly = True
                End If
            End If
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '' AS no,d.`id_del_manifest`,dis.sub_district,d.id_comp,IF(d.`is_ol_shop`=1,cg.comp_group,store.comp_number) AS comp_number,IF(d.`is_ol_shop`=1,cg.description,store.comp_name) AS comp_name
,d.`awbill_inv_no`,d.`awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
,d.`cargo_rate`
,odm.created_date AS pickup_date
,COUNT(dd.`id_del_manifest_det`) AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh
FROM tb_awb_inv_sum_det id
INNER JOIN tb_del_manifest_det dd ON id.id_del_manifest=dd.id_del_manifest
INNER JOIN `tb_del_manifest` d ON dd.`id_del_manifest`=d.`id_del_manifest`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district AND d.`id_report_status`=6
INNER JOIN tb_m_comp store ON store.id_comp=id_store_offline 
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=d.id_comp_group
INNER JOIN tb_odm_sc_det odmd ON odmd.id_del_manifest=d.`id_del_manifest`
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc
WHERE id.id_awb_inv_sum='" & id_verification & "'
GROUP BY d.`id_del_manifest`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Sub load_inv()
        Dim query As String = "SELECT awbill_inv_no FROM tb_del_manifest 
WHERE id_comp='" & SLUE3PL.EditValue.ToString & "'
GROUP BY awbill_inv_no,id_comp"

        viewSearchLookupQuery(SLEInvoice, query, "awbill_inv_no", "awbill_inv_no", "awbill_inv_no")
    End Sub

    Sub load_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLE3PLImport, query, "id_comp", "comp_name", "id_comp")
        load_inv()
    End Sub

    Private Sub Bload_Click(sender As Object, e As EventArgs) Handles Bload.Click
        Dim q As String = "SELECT '' AS no,d.`id_del_manifest`,dis.sub_district,d.id_comp,IF(d.`is_ol_shop`=1,cg.comp_group,store.comp_number) AS comp_number,IF(d.`is_ol_shop`=1,cg.description,store.comp_name) AS comp_name
,d.`awbill_inv_no`,d.`awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
,d.`cargo_rate`
,odm.created_date AS pickup_date
,COUNT(dd.`id_del_manifest_det`) AS collie
,d.`c_weight`,d.`c_tot_price`,d.`a_weight`,d.`a_tot_price`
,'' AS note_wh
FROM tb_del_manifest_det dd 
INNER JOIN `tb_del_manifest` d ON dd.`id_del_manifest`=d.`id_del_manifest`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district AND d.`id_report_status`=6
INNER JOIN tb_m_comp store ON store.id_comp=id_store_offline 
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=d.id_comp_group
INNER JOIN tb_odm_sc_det odmd ON odmd.id_del_manifest=d.`id_del_manifest`
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc
WHERE d.id_comp='" & SLUE3PL.EditValue.ToString & "' AND d.awbill_inv_no='" & SLEInvoice.EditValue.ToString & "'
GROUP BY d.`id_del_manifest`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        load_inv()
    End Sub

    Private Sub FormAWBInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        If GVInvoice.RowCount > 0 Then
            save()
            'check notes
            Dim is_ok As Boolean = True

            For i = 0 To GVInvoice.RowCount - 1
                If (GVInvoice.GetRowCellValue(i, "diff_weight") > 0 Or GVInvoice.GetRowCellValue(i, "diff_amount") > 0) And GVInvoice.GetRowCellValue(i, "note_wh").ToString = "" Then
                    is_ok = False
                    Exit For
                End If
            Next

            If is_ok Then
                Dim q As String = "UPDATE tb_awb_inv_sum SET is_submit='1' WHERE id_awb_inv_sum='" & id_verification & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("310", id_verification, id_user)
                '
                load_form()
                Form3PLInvoiceVerification.load_verification()
            Else
                warningCustom("Please put note why different")
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
            If GVInvoice.RowCount > 0 Then
                'check first
                Dim qc As String = "SELECT * FROM tb_awb_inv_sum WHERE id_comp='" & SLUE3PL.EditValue.ToString & "' AND inv_number='" & addSlashes(SLEInvoice.EditValue.ToString) & "' AND id_report_status!=5"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count > 0 Then
                    'sudah ada
                    warningCustom("This invoice already created.")
                Else
                    Dim q As String = "INSERT INTO tb_awb_inv_sum(created_by,created_date,id_report_status,id_comp,inv_number,note) VALUES('" & id_user & "',NOW(),1,'" & SLUE3PL.EditValue.ToString & "','" & addSlashes(SLEInvoice.EditValue.ToString) & "',''); SELECT LAST_INSERT_ID(); "
                    id_verification = execute_query(q, 0, True, "", "", "", "")
                    'detail
                    q = "INSERT INTO tb_awb_inv_sum_det(`id_awb_inv_sum`,`id_del_manifest`,`berat_wh`,`berat_cargo`,`amount_wh`,`amount_cargo`,`note_wh`) VALUES"
                    For i As Integer = 0 To GVInvoice.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If

                        q += "('" & id_verification & "','" & GVInvoice.GetRowCellValue(i, "id_del_manifest").ToString & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "c_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "c_tot_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_tot_price").ToString).ToString) & "','" & addSlashes(GVInvoice.GetRowCellValue(i, "note_wh").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")

                    Form3PLInvoiceVerification.load_verification()

                    Close()
                End If
            Else
                warningCustom("No awb found")
            End If
        Else
            'edit
            If GVInvoice.RowCount > 0 Then
                Dim q As String = ""

                q = "UPDATE tb_awb_inv_sum SET id_comp='" & SLUE3PL.EditValue.ToString & "',inv_number='" & addSlashes(SLEInvoice.EditValue.ToString) & "' WHERE id_awb_inv_sum='" & id_verification & "'"
                execute_non_query(q, True, "", "", "", "")

                'delete all
                q = "DELETE FROM tb_awb_inv_sum_det WHERE id_awb_inv_sum='" & id_verification & "'"
                execute_non_query(q, True, "", "", "", "")
                'detail
                q = "INSERT INTO tb_awb_inv_sum_det(`id_awb_inv_sum`,`id_del_manifest`,`berat_wh`,`berat_cargo`,`amount_wh`,`amount_cargo`,`note_wh`) VALUES"
                For i As Integer = 0 To GVInvoice.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    q += "('" & id_verification & "','" & GVInvoice.GetRowCellValue(i, "id_del_manifest").ToString & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "c_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_weight").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "c_tot_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVInvoice.GetRowCellValue(i, "a_tot_price").ToString).ToString) & "','" & addSlashes(GVInvoice.GetRowCellValue(i, "note_wh").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                load_form()
                Form3PLInvoiceVerification.load_verification()
            Else
                warningCustom("No awb found")
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportAwbInv.id_ver = id_verification
        ReportAwbInv.dt = GCInvoice.DataSource
        Dim Report As New ReportAwbInv()

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVInvoice.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVInvoice.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        ReportStyleGridview(Report.GVInvoice)
        Report.GVInvoice.BestFitColumns()

        'Parse val
        Dim query As String = "SELECT"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

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

    Private Sub CBWorksheetName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBWorksheetName.EditValueChanged

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
    Sub fill_field_grid()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        GCData.DataSource = Nothing

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        Try

            Dim queryx As String = "SELECT '' AS `no`,d.`id_del_manifest`,'' AS id_inbound_awb,dis.sub_district,d.id_comp,IF(d.`is_ol_shop`=1,cg.comp_group,store.comp_number) AS comp_number,IF(d.`is_ol_shop`=1,cg.description,store.comp_name) AS comp_name
,d.`awbill_inv_no`,d.`awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
,d.`cargo_rate`
,odm.created_date AS pickup_date
,COUNT(dd.`id_del_manifest_det`) AS collie
,d.`c_weight`,d.`c_tot_price`,d.`a_weight`,d.`a_tot_price`
FROM tb_del_manifest_det dd 
INNER JOIN `tb_del_manifest` d ON dd.`id_del_manifest`=d.`id_del_manifest`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district AND d.`id_report_status`=6
INNER JOIN tb_m_comp store ON store.id_comp=id_store_offline 
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=d.id_comp_group
INNER JOIN tb_odm_sc_det odmd ON odmd.id_del_manifest=d.`id_del_manifest`
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc
GROUP BY d.`id_del_manifest`
UNION ALL
-- inbound
SELECT '' AS `no`,'' AS `id_del_manifest`,dd.id_inbound_awb,dis.sub_district,d.id_comp,store.comp_number AS comp_number,store.comp_name AS comp_name
,d.`awb_inv_number` AS awbill_inv_no,d.awb_number AS `awbill_no`,d.`created_date` AS rec_by_store_date,emp.employee_name AS `rec_by_store_person`
,rate.`cargo_rate`
,rn.date_return_note AS pickup_date
,COUNT(dd.`id_inbound_koli`) AS collie
,SUM(IF(dd.berat>dd.berat_dimensi,dd.berat,dd.berat_dimensi)) AS `c_weight`,SUM(IF(dd.berat>dd.berat_dimensi,dd.berat,dd.berat_dimensi)*rate.cargo_rate) AS `c_tot_price`,d.`a_weight`,d.`a_tot_price`
FROM tb_inbound_koli dd 
INNER JOIN `tb_inbound_awb` d ON dd.`id_inbound_awb`=d.`id_inbound_awb`
INNER JOIN tb_3pl_rate rate ON rate.id_3pl_rate=d.id_3pl_rate
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=rate.id_sub_district
INNER JOIN tb_m_user usr ON usr.id_user=d.`created_by`
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN 
(
	SELECT st.id_inbound_awb,st.id_comp,c.`comp_number`,c.`comp_name`
	FROM `tb_inbound_store` st
	INNER JOIN tb_m_comp c ON c.id_comp=st.`id_comp`
	GROUP BY id_inbound_awb
)store ON store.id_inbound_awb=d.id_inbound_awb 
INNER JOIN
(
	SELECT rn.`id_inbound_awb`,rn.`date_return_note`
	FROM tb_return_note rn 
	GROUP BY rn.`id_inbound_awb`
)rn ON rn.`id_inbound_awb`=d.id_inbound_awb 
GROUP BY d.`id_inbound_awb`"
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
                                .awbill_no = If(result_awb Is Nothing, table1("awb_no"), result_awb("awbill_no")),
                                .sub_district = If(result_awb Is Nothing, "", result_awb("sub_district")),
                                .awbill_inv_no = If(table1("inv_no").ToString = "", "", table1("inv_no")),
                                .a_weight = If(table1("a_weight").ToString = "", "", table1("a_weight")),
                                .a_tot_price = If(table1("a_weight").ToString = "", "", If(result_awb Is Nothing, table1("a_weight"), If(table1("a_weight") < result_awb("cargo_min_weight"), result_awb("cargo_min_weight"), table1("a_weight"))) * If(result_awb Is Nothing, 0, result_awb("cargo_rate"))),
                                .id_del_manifest = If(result_awb Is Nothing, "", result_awb("id_del_manifest")),
                                .note = If(result_awb Is Nothing, "AWB Number not found", "OK")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdAwb").Visible = False
            GVData.Columns("is_old_ways").Visible = False
            GVData.Columns("id_del_manifest").Visible = False
            GVData.Columns("AWB").Caption = "AWB Number"
            GVData.Columns("inv_no_new").Caption = "Invoice Number"
            GVData.Columns("note").Caption = "Note"

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
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        If TEInvNumberImport.Text = "" Then
            warningCustom("Please put invoice number")
        Else
            Dim qc As String = "SELECT * FROM tb_awb_inv_sum WHERE id_report_status!=5 AND inv_number='" & addSlashes(TEInvNumberImport.Text) & "' AND id_comp='" & SLE3PLImport.EditValue.ToString & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Invoice sudah pernah di verifikasi")
            Else
                If Not CBWorksheetName.EditValue = "" Then
                    Cursor = Cursors.WaitCursor
                    fill_field_grid()
                    Cursor = Cursors.Default
                Else
                    warningCustom("Periksa kembali file import anda, sheet tidak ditemukan")
                End If
            End If
        End If

    End Sub
End Class
