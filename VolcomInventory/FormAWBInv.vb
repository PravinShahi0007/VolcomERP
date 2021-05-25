Public Class FormAWBInv
    Public id_verification As String = "-1"

    Private Sub FormAWBInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_3pl()
        '
        load_form()
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
        fdlg.InitialDirectory = "C: \"
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
End Class
