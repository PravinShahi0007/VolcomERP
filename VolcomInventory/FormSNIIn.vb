Public Class FormSNIIn
    Public id As String = "-1"
    Public id_out As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormSNIIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        view_vendor()
        view_barcode_list()
        viewReportStatus()

        If id = "-1" Then
            'new
            BtnSave.Visible = True
            PanelNavBarcode.Visible = True
            '
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnAttachment.Visible = False
            BtnSave.Visible = True
        Else
            'edit
            GroupControlListBarcode.Visible = False
            SCCQC.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
            TESNIOutNo.Properties.ReadOnly = True

            Dim q As String = "SELECT emp.employee_name,qci.number,qci.`created_date`,qco.id_comp_to,qci.id_qc_sni_out,qci.notes,qci.id_report_status,qco.number AS out_number
FROM tb_qc_sni_in qci
INNER JOIN tb_qc_sni_out qco ON qco.id_qc_sni_out=qci.id_qc_sni_out
INNER JOIN tb_m_user usr ON qci.created_by=usr.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE qci.id_qc_sni_in='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                id_out = dt.Rows(0)("id_qc_sni_out").ToString
                '
                SLEVendor.EditValue = dt.Rows(0)("id_comp_to").ToString
                SLEVendor.Properties.ReadOnly = True
                '
                TESNIOutNo.Text = dt.Rows(0)("out_number").ToString
                TxtNumber.Text = dt.Rows(0)("number").ToString
                DEProposeDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                '
                MENote.Text = dt.Rows(0)("notes").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", dt.Rows(0)("id_report_status").ToString)
            End If
            load_det_view()

            GridColumnQtyOut.Visible = False
            GridColumnQtyRemaining.Visible = False

            BtnSave.Visible = False
            PanelNavBarcode.Visible = False
            MENote.Enabled = False
            '
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnAttachment.Visible = True
            BtnSave.Visible = False
        End If
    End Sub

    Sub load_det_view()
        Dim q As String = "SELECT '' AS `no`,qco.`id_qc_sni_out_det`,pdp.`id_product`,po.`id_prod_order`,pod.id_prod_order_det,recd.id_prod_order_rec_det,recd.`id_prod_order_rec`,po.`prod_order_number`,rec.`prod_order_rec_number`,p.`product_full_code`,dsg.`design_display_name` AS `name`
,cd.`display_name` AS size
,qcid.qty AS qty_in
FROM tb_qc_sni_in_det qcid 
INNER JOIN `tb_qc_sni_out_det` qco ON qco.id_qc_sni_out_det=qcid.id_qc_sni_out_det
INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec_det`=qco.`id_prod_order_rec_det`
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE qcid.id_qc_sni_in='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_vendor()
        Dim query As String = "SELECT comp.id_comp,comp.comp_number, comp.comp_name FROM tb_m_comp comp WHERE comp.id_comp_cat='1' OR comp.id_comp_cat='2'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS product_full_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
        allowDelete()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Private Sub TESNIOutNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TESNIOutNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TESNIOutNo.Text = "" Then
                warningCustom("Please scan SNI Out form")
            Else
                Dim qc As String = "SELECT id_qc_sni_out,id_comp_to FROM tb_qc_sni_out WHERE number='" & addSlashes(TESNIOutNo.Text) & "' AND id_report_status=6"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count = 0 Then
                    warningCustom("SNI Out number not found")
                    TESNIOutNo.Text = ""
                    TESNIOutNo.Focus()
                Else
                    TESNIOutNo.Properties.ReadOnly = True
                    SLEVendor.EditValue = dtc.Rows(0)("id_comp_to").ToString
                    id_out = dtc.Rows(0)("id_qc_sni_out").ToString
                    '
                    load_det()
                    '
                    GroupControlListBarcode.Enabled = True
                    PanelNavBarcode.Visible = True
                End If
            End If
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '' AS `no`,qco.`id_qc_sni_out_det`,pdp.`id_product`,po.`id_prod_order`,pod.id_prod_order_det,recd.id_prod_order_rec_det,recd.`id_prod_order_rec`,po.`prod_order_number`,rec.`prod_order_rec_number`,p.`product_full_code`,dsg.`design_display_name` AS `name`
,cd.`display_name` AS size
,qco.qty
,0 AS qty_in
,(qco.qty-IFNULL(qci.qty,0)) AS qty_remaining
FROM `tb_qc_sni_out_det` qco
INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec_det`=qco.`id_prod_order_rec_det`
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
LEFT JOIN
(
	SELECT qcid.id_qc_sni_out_det,SUM(qcid.`qty`) AS qty
	FROM `tb_qc_sni_in_det` qcid
	INNER JOIN `tb_qc_sni_out_det` qcod ON qcod.`id_qc_sni_out_det`=qcid.`id_qc_sni_out_det`
	INNER JOIN tb_qc_sni_in qci ON qci.`id_qc_sni_in`=qcid.`id_qc_sni_in` AND qci.`id_report_status`!=5
	GROUP BY qcid.id_qc_sni_out_det
)qci ON qci.id_qc_sni_out_det=qco.id_qc_sni_out_det
WHERE qco.id_qc_sni_out='" & id_out & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVDetail.OptionsBehavior.Editable = False
        ControlBox = False
        newRowsBc()
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "product_full_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVDetail.OptionsBehavior.Editable = True
        ControlBox = True
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

    Private Sub GVBarcode_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("product_full_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        For i As Integer = 0 To (GVDetail.RowCount - 1)
            Dim code As String = GVDetail.GetRowCellValue(i, "product_full_code").ToString
            id_prod_order_det = GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("product_full_code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            countQty(id_prod_order_det)
            newRowsBc()
            allowDelete()
        End If
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
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
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_prod_order_det", id_prod_order_detx)

        GVDetail.SetFocusedRowCellValue("qty_in", tot)
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek dengan requisition di DB
        Dim is_ok As Boolean = True

        Dim prod_check As String = ""
        Dim allow_qty As String = "0"

        For i As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
            Dim id_qc_sni_out As String = GVDetail.GetRowCellValue(i, "id_qc_sni_out_det").ToString
            prod_check = GVDetail.GetRowCellValue(i, "name").ToString

            Dim qc As String = "SELECT qcod.id_qc_sni_out_det,qcod.qty,IFNULL(qci.qty,0) AS qty_in,(qcod.qty-IFNULL(qci.qty,0)) AS qty_rem
FROM `tb_qc_sni_out_det` qcod
LEFT JOIN
(
	SELECT qcid.id_qc_sni_out_det,SUM(qcid.`qty`) AS qty
	FROM `tb_qc_sni_in_det` qcid
	INNER JOIN `tb_qc_sni_out_det` qcod ON qcod.`id_qc_sni_out_det`=qcid.`id_qc_sni_out_det`
	INNER JOIN tb_qc_sni_in qci ON qci.`id_qc_sni_in`=qcid.`id_qc_sni_in` AND qci.`id_report_status`!=5
	GROUP BY qcid.id_qc_sni_out_det
)qci ON qci.id_qc_sni_out_det=qcod.id_qc_sni_out_det
WHERE qcod.id_qc_sni_out_det='" & id_qc_sni_out & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                If dtc.Rows(0)("qty_rem") < GVDetail.GetRowCellValue(i, "qty_in") Then
                    is_ok = False
                    allow_qty = dtc.Rows(0)("qty_rem").ToString
                    Exit For
                End If
            Else
                is_ok = False
                allow_qty = "0"
                Exit For
            End If
        Next

        If GVDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not is_ok Then
            errorCustom("Product : '" + prod_check + "' cannot exceed " + allow_qty + ", please check ! ")
        Else
            Dim query As String = ""

            If id = "-1" Then 'new
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        BtnSave.Enabled = False

                        'Main tbale
                        query = "INSERT INTO tb_qc_sni_in(`id_qc_sni_out`,`created_by`,`created_date`,`id_report_status`,`notes`) "
                        query += "VALUES('" & id_out & "','" & id_user & "',NOW(),'1','" & addSlashes(MENote.Text) & "') ; SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")

                        execute_non_query("CALL gen_number('" & id & "','331')", True, "", "", "", "")

                        'Detail return
                        For j As Integer = 0 To ((GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail))
                            Try
                                If Not GVDetail.GetRowCellValue(j, "qty_in").ToString = "0" Then
                                    query = "INSERT tb_qc_sni_in_det(`id_qc_sni_in`,`id_qc_sni_out_det`,`qty`) "
                                    query += "VALUES('" + id + "', '" + GVDetail.GetRowCellValue(j, "id_qc_sni_out_det").ToString + "', '" + decimalSQL(Decimal.Parse(GVDetail.GetRowCellValue(j, "qty_in").ToString).ToString) + "') "
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                                stopCustom(ex.ToString)
                            End Try
                        Next

                        'submit
                        submit_who_prepared("331", id, id_user)

                        FormSNIQC.load_list()
                        FormSNIQC.GVSNIIn.FocusedRowHandle = find_row(FormSNIQC.GVSNIIn, "id_qc_sni_in", id)
                        infoCustom("QC SNI In saved")
                        load_head()
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try
                    Cursor = Cursors.Default
                End If
            Else 'update
                'you cant update

            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSNIIn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "331"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.report_mark_type = "331"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class