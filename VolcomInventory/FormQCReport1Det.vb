﻿Public Class FormQCReport1Det
    Public id As String = "-1"
    Public is_view As String = "-1"

    Public id_prod_order As String = "-1"
    Public id_prod_order_rec As String = "-1"
    Public id_prod_order_det_list, id_qc_report1_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_design As String = "-1"

    Private Sub FormQCReport1Det_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnBrowsePO.Focus()
        viewReportStatus() 'get report status
        actionLoad()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("qc_report1_det_qty", tot)
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If id = "-1" Then
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DERet.Text = view_date(0)

            'own source
            Dim id_qc As String = execute_query("SELECT id_qc_dept FROM tb_opt", 0, True, "", "", "", "")
            Dim query_get_comp_name As String = "SELECT b.comp_name, b.comp_number FROM tb_m_comp_contact a "
            query_get_comp_name += "INNER JOIN tb_m_comp b ON a.id_comp = b.id_comp "
            query_get_comp_name += "WHERE a.id_comp_contact = '" + id_qc + "' AND b.id_departement = '" + id_departement_user + "'"
            Try
                Dim data_comp_from As DataTable = execute_query(query_get_comp_name, -1, True, "", "", "", "")
            Catch ex As Exception
            End Try
        Else
            'Enable/Disable
            BMark.Enabled = True
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True
            GroupControlListBarcode.Enabled = True
            BtnInfoSrs.Enabled = True


            'View data
            Dim query As String = ""
            query += "WHERE a.id_qc_report1='" + id + "' "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
            DERet.Text = view_date_from(data.Rows(0)("prod_order_ret_out_datex").ToString, 0)
            MENote.Text = data.Rows(0)("prod_order_ret_out_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_prod_order_rec = data.Rows(0)("id_prod_order_rec").ToString
            id_design = data.Rows(0)("id_design").ToString
            TxtDesign.Text = data.Rows(0)("design_display_name").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            '
            view_barcode_list()
            viewDetailReturn()
            allow_status()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "385", id) Then
            GVRetDetail.OptionsBehavior.Editable = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            BScan.Enabled = True
            BDelete.Enabled = True
            BtnInfoSrs.Enabled = True
            GVRetDetail.OptionsCustomization.AllowGroup = False
        Else
            GVRetDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            BScan.Enabled = False
            BDelete.Enabled = False
            BtnInfoSrs.Enabled = False
            GVRetDetail.OptionsCustomization.AllowGroup = True
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnBrowsePO_Click(sender As Object, e As EventArgs) Handles BtnBrowsePO.Click
        FormPopUpRecQC.id_pop_up = "6"
        FormPopUpRecQC.ShowDialog()
    End Sub

    Sub viewDetailReturn()
        If id = "-1" Then
            Dim query As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '0', '0', '0', '0', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
            Next
            GCRetDetail.DataSource = data

            GridColumnPriceOVH.VisibleIndex = "-1"
            GridColumnAmount.VisibleIndex = "-1"
        Else
            'Dim query As String = "CALL view_return_out_prod('" + id + "', '1')"
            Dim query As String = ""
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
                id_qc_report1_det_list.Add(data.Rows(i)("id_qc_report1_det").ToString)
                For j As Integer = 0 To data.Rows(i)("qc_report1_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("ean_code", data.Rows(i)("ean_code"))
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", data.Rows(i)("id_prod_order_det"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next

            GCRetDetail.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
        End If
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
        allowDelete()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
            deleteRowsBc()
            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_prod_order_det)
            End If
            allowDelete()
        End If
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "ean_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        MENote.Enabled = True
        BtnBrowsePO.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVRetDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BtnInfoSrs.Enabled = True
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnBrowsePO.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVRetDetail.OptionsBehavior.Editable = False
        ControlBox = False
        BtnInfoSrs.Enabled = False
        newRowsBc()
    End Sub

    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub GVBarcode_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("ean_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Dim code As String = GVRetDetail.GetRowCellValue(i, "ean_code").ToString
            id_prod_order_det = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("ean_code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            countQty(id_prod_order_det)
            newRowsBc()
            'allowDelete()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = "385"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = "385"
        '
        If Not check_edit_report_status(id_report_status, "385", id) Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        '
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name

        'Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '" + id_prod_order_ret_out + "', '0','0', '0', '0') "
        'Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")

        Dim q_check As String = "CALL view_limit_qc_report1('" + id_prod_order_rec + "', '" + id_prod_order_det_cek + "', '" + id + "')"
        Dim data As DataTable = execute_query(q_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ValidateChildren()
        makeSafeGV(GVRetDetail)

        'cek dengan requisition di DB
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            Dim id_prod_order_det_cekya As String = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_plya As String = GVRetDetail.GetRowCellValue(i, "qc_report1_qty").ToString
            Dim sample_checkya As String = GVRetDetail.GetRowCellValue(i, "name").ToString + " / Size : " + GVRetDetail.GetRowCellValue(i, "size").ToString
            isAllowRequisition(sample_checkya, id_prod_order_det_cekya, qty_plya)
            If Not cond_check Then
                Exit For
            End If
        Next

        If GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            errorCustom("Product : '" + sample_check + "' cannot exceed " + allow_sum.ToString("F2") + ", please check in Info Qty ! ")
            'infoQty()
        Else
            Dim query As String
            Dim prod_order_ret_out_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_prod_order_det, qc_report1_qty As String
            Dim id_qc_report1_det As String
            Dim id_ovh_price As String = "NULL"
            '
            If id = "-1" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        BtnSave.Enabled = False

                        'Main tbale
                        query = "INSERT INTO tb_qc_report1(id_prod_order,id_prod_order_rec, created_date, created_by, id_report_status) "
                        query += "VALUES('" + id_prod_order + "','" + id_prod_order_rec + "', NOW(),  '" + id_user + "', '" + id_report_status + "') ; SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")

                        execute_non_query("CALL gen_number('" & id & "','385')", True, "", "", "", "")

                        'Detail return
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                qc_report1_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "qc_report1_qty").ToString)

                                query = "INSERT tb_qc_report1_det(id_qc_report1, id_prod_order_det, qc_report1_qty) "
                                query += "VALUES('" + id + "', '" + id_prod_order_det + "', '" + qc_report1_qty + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                stopCustom(ex.ToString)
                            End Try
                        Next

                        'submit
                        submit_who_prepared("385", id, id_user)

                        'FormProductionRet.viewRetOut()
                        'FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", id)
                        actionLoad()

                        infoCustom("QC Report 1 was created successfully.")
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try

                        'edit main table
                        query = "UPDATE tb_qc_report1_det SET id_prod_order = '" + id_prod_order + "',id_prod_order_rec = '" + id_prod_order_rec + "' WHERE id_qc_report1 = '" + id + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_qc_report1_det = GVRetDetail.GetRowCellValue(j, "id_qc_report1").ToString
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                qc_report1_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "qc_report1_qty").ToString)

                                If id_qc_report1_det = "0" Then
                                    query = "INSERT tb_qc_report1_det(id_qc_report1, id_prod_order_det, qc_report1_qty) "
                                    query += "VALUES('" + id + "', '" + id_prod_order_det + "', '" + qc_report1_qty + "') "
                                    execute_non_query(query, True, "", "", "", "")
                                Else
                                    query = "UPDATE tb_qc_report1_det SET id_prod_order_det = '" + id_prod_order_det + "', qc_report1_qty = '" + qc_report1_qty + "' WHERE id_qc_report1_det = '" + id_qc_report1_det + "'"
                                    execute_non_query(query, True, "", "", "", "")
                                    id_qc_report1_det_list.Remove(id_qc_report1_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'delete sisa
                        For k As Integer = 0 To (id_qc_report1_det_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_qc_report1_det WHERE id_qc_report1_det = '" + id_qc_report1_det_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'View
                        'FormProductionRet.viewRetOut()
                        'FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", id)
                        actionLoad()

                        infoCustom("QC Report 1 was edited successfully.")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub FormQCReport1Det_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class