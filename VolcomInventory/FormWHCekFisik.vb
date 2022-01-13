Public Class FormWHCekFisik
    Dim dtu As DataTable
    Public report_mark_type As String = ""

    Public id_report As String = "-1"
    Public id_cek_fisik As String = "-1"
    Public is_able_reopen As Boolean = False
    Public id_user_cancel As String = "-1"

    Sub load_form()
        If report_mark_type = "return_transfer" Then
            'ret transfer
            If Not id_report = "-1" Then
                Dim q_item As String = "SELECT p.`id_product`,CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting) AS full_code,COUNT(CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)) AS qty
,IFNULL(sc.qty_scan,0) AS qty_scan
FROM `tb_sales_return_qc_det` deld 
INNER JOIN tb_m_product p ON p.`id_product`=deld.`id_product` AND deld.`id_sales_return_qc`='" & id_report & "'
INNER JOIN `tb_sales_return_qc_det_counting` delc ON delc.`id_sales_return_qc_det`=deld.`id_sales_return_qc_det`
LEFT JOIN
(
    SELECT dd.id_product,dd.scanned_code,COUNT(dd.scanned_code) AS qty_scan
    FROM `tb_wh_cek_fisik_scan` dd
    INNER JOIN tb_wh_cek_fisik d ON d.id_wh_cek_fisik=dd.id_wh_cek_fisik
    WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status!=5
    GROUP BY dd.scanned_code
)sc ON sc.scanned_code=CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)
GROUP BY full_code"
                Dim dt_item As DataTable = execute_query(q_item, -1, True, "", "", "", "")
                dtu = dt_item
                GCItemList.DataSource = dt_item
                GVItemList.BestFitColumns()

                q_item = "SELECT dd.id_product,dd.scanned_code
FROM `tb_wh_cek_fisik_scan` dd
INNER JOIN tb_wh_cek_fisik d ON d.id_wh_cek_fisik=dd.id_wh_cek_fisik
WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status!=5"
                dt_item = execute_query(q_item, -1, True, "", "", "", "")
                GCScanList.DataSource = dt_item
                get_total()
            End If
        Else
            Close()
        End If

    End Sub

    Private Sub TEOutboundNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyUp
        If e.KeyCode = Keys.Enter And id_cek_fisik = "-1" Then
            Dim q As String = ""
            If report_mark_type = "return_transfer" Then
                q = "SELECT id_sales_return_qc AS id_report,status_check_fisik FROM `tb_sales_return_qc` reqc WHERE reqc.sales_return_qc_number='" & addSlashes(TEOutboundNumber.Text) & "'"
            End If
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("status_check_fisik").ToString = "3" Then
                    FormError.LabelContent.Text = "Check fisik sudah dilakukan"
                    FormError.ShowDialog()
                    TEOutboundNumber.Text = ""
                ElseIf dt.Rows(0)("status_check_fisik").ToString = "2" Then
                    id_report = dt.Rows(0)("id_report").ToString
                    BReset.Visible = False
                    TEOutboundNumber.Properties.ReadOnly = True
                    '
                    load_form()
                    '
                    BComplete.Text = "Re-open"
                    LStatus.Text = "Tidak Balance"
                    PCScan.Visible = False
                ElseIf dt.Rows(0)("status_check_fisik").ToString = "1" Then
                    id_report = dt.Rows(0)("id_report").ToString
                    BReset.Visible = True
                    TEOutboundNumber.Properties.ReadOnly = True
                    LStatus.Text = "Belum Cek Fisik"
                    PCScan.Visible = True
                    '
                    Dim q_item As String = ""
                    If report_mark_type = "return_transfer" Then
                        q_item = "SELECT p.`id_product`,CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting) AS full_code,COUNT(CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)) AS qty
,IFNULL(sc.qty_scan,0) AS qty_scan
FROM `tb_sales_return_qc_det` deld 
INNER JOIN tb_m_product p ON p.`id_product`=deld.`id_product` AND deld.`id_sales_return_qc`='" & id_report & "'
INNER JOIN `tb_sales_return_qc_det_counting` delc ON delc.`id_sales_return_qc_det`=deld.`id_sales_return_qc_det`
LEFT JOIN
(
    SELECT dd.id_product,dd.scanned_code,COUNT(dd.scanned_code) AS qty_scan
    FROM `tb_wh_cek_fisik_scan` dd
    INNER JOIN tb_wh_cek_fisik d ON d.id_wh_cek_fisik=dd.id_wh_cek_fisik
    WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status!=5
    GROUP BY dd.scanned_code
)sc ON sc.scanned_code=CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)
GROUP BY full_code"
                    End If

                    Dim dt_item As DataTable = execute_query(q_item, -1, True, "", "", "", "")
                    dtu = dt_item
                    GCItemList.DataSource = dt_item
                    GVItemList.BestFitColumns()
                    '
                    q_item = "SELECT id_product,scanned_code FROM `tb_wh_cek_fisik_scan`
WHERE `id_wh_cek_fisik`='" & id_cek_fisik & "'"
                    dt_item = execute_query(q_item, -1, True, "", "", "", "")
                    GCScanList.DataSource = dt_item

                    TEScannedCode.Focus()
                End If
            Else
                FormError.LabelContent.Text = "Nomor dokumen tidak ditemukan"
                FormError.ShowDialog()
                TEOutboundNumber.Text = ""
            End If
        End If
    End Sub

    Sub get_total()
        TETotQty.EditValue = GVItemList.Columns("qty").SummaryItem.SummaryValue
        TETotScan.EditValue = GVItemList.Columns("qty_scan").SummaryItem.SummaryValue
    End Sub

    Private Sub FormOutboundCheckFisik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        TETotQty.EditValue = 0
        TETotScan.EditValue = 0
        dtu = Nothing
        id_cek_fisik = "-1"
        id_report = "-1"
        '
        PCScan.Visible = False
        TEOutboundNumber.Properties.ReadOnly = False
        TEOutboundNumber.Text = ""
        '
        empty_scan_list()
        empty_item_list()

        BComplete.Text = "Complete"
        LStatus.Text = ""

        BReset.Visible = False
        TEOutboundNumber.Focus()
    End Sub

    Private Sub TEScannedCode_KeyUp(sender As Object, e As KeyEventArgs) Handles TEScannedCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            'check
            Dim code_check As String = addSlashes(TEScannedCode.Text)
            Dim code_found As Boolean = False
            Dim id_product As String = ""
            'check available code
            Dim dt_filter As DataRow() = dtu.Select("[full_code]='" + code_check + "' ")
            If dt_filter.Length > 0 Then
                id_product = dt_filter(0)("id_product").ToString()

                If get_opt_general_field("is_strict_check_fisik").ToString = "1" Then
                    'cek dulu
                    Dim is_over As Boolean = False
                    GVItemList.ActiveFilterString = "[full_code]='" & code_check & "'"
                    If GVItemList.GetRowCellValue(0, "qty") = GVItemList.GetRowCellValue(0, "qty_scan") Then
                        is_over = True
                    End If
                    GVItemList.ActiveFilterString = ""

                    If is_over Then
                        FormError.LabelContent.Text = "Over Qty, please ask dept head to unlock"
                        FormError.ShowDialog()

                        'save
                        save(False)
                    Else
                        'insert
                        newrow(id_product, code_check)
                        'count up
                        countQty(code_check)
                        TEScannedCode.Text = ""
                    End If
                Else
                    'insert
                    newrow(id_product, code_check)
                    'count up
                    countQty(code_check)
                    TEScannedCode.Text = ""
                End If
            Else
                If get_opt_general_field("is_strict_check_fisik").ToString = "1" Then
                    FormError.LabelContent.Text = "Code not found, please ask dept head to unlock"
                    FormError.ShowDialog()
                    TEScannedCode.Text = ""
                    TEScannedCode.Focus()
                    'save
                    save(False)
                Else
                    FormError.LabelContent.Text = "Code not found."
                    FormError.ShowDialog()
                    TEScannedCode.Text = ""
                    TEScannedCode.Focus()
                End If
            End If
        End If
    End Sub

    Sub countQty(ByVal code_check As String)
        Dim jml As Integer = 0
        GVScanList.ActiveFilterString = "[scanned_code]='" & code_check & "'"
        jml = GVScanList.RowCount
        GVScanList.ActiveFilterString = ""

        GVItemList.ActiveFilterString = "[full_code]='" & code_check & "'"
        GVItemList.SetFocusedRowCellValue("qty_scan", jml)
        GVItemList.ActiveFilterString = ""

        get_total()
    End Sub

    Sub newrow(ByVal id_product As String, ByVal scanned_code As String)
        Dim newRow As DataRow = (TryCast(GCScanList.DataSource, DataTable)).NewRow()
        newRow("id_product") = id_product
        newRow("scanned_code") = scanned_code
        TryCast(GCScanList.DataSource, DataTable).Rows.Add(newRow)
        GVScanList.RefreshData()
    End Sub

    Sub save(ByVal is_popup As Boolean)
        Dim q As String = ""
        q = "INSERT INTO tb_wh_cek_fisik(id_report,report_mark_type,created_date,created_by) VALUES('" & id_report & "','" & report_mark_type & "',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID();"
        id_cek_fisik = execute_query(q, 0, True, "", "", "", "")
        'detail
        If GVScanList.RowCount > 0 Then
            q = "INSERT INTO tb_wh_cek_fisik_scan(`id_wh_cek_fisik`,`id_product`,`scanned_code`) VALUES"
            For i As Integer = 0 To GVScanList.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If

                q += "('" & id_cek_fisik & "','" & GVScanList.GetRowCellValue(i, "id_product").ToString & "','" & GVScanList.GetRowCellValue(i, "scanned_code").ToString & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
        End If

        'notify head if not balance
        valid_check(is_popup)
        '
        If report_mark_type = "return_transfer" Then
            FormSalesReturnQC.viewSalesReturnQC()
        End If
        '
        Close()
    End Sub

    Private Sub BComplete_Click(sender As Object, e As EventArgs) Handles BComplete.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to " & BComplete.Text & " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If BComplete.Text = "Complete" Then
                If id_cek_fisik = "-1" Then
                    If GVScanList.RowCount = 0 Then
                        warningCustom("List scan kosong")
                    Else
                        'new
                        save(True)
                    End If
                End If
            Else
                'pakai login dept head 
                FormMenuAuth.type = "18"
                FormMenuAuth.ShowDialog()
                If is_able_reopen Then
                    're open
                    Dim q As String = ""
                    q = "UPDATE tb_wh_cek_fisik SET id_report_status=5,cancel_date=NOW(),cancel_by='" & id_user_cancel & "' WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status!=5"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    If report_mark_type = "return_transfer" Then
                        q = "UPDATE tb_sales_return_qc SET status_check_fisik=1 WHERE id_sales_return_qc='" & id_report & "'"
                    End If

                    execute_non_query(q, True, "", "", "", "")
                    '
                    TETotQty.EditValue = 0
                    TETotScan.EditValue = 0
                    dtu = Nothing
                    id_cek_fisik = "-1"
                    id_report = "-1"
                    '
                    PCScan.Visible = False
                    TEOutboundNumber.Properties.ReadOnly = False
                    TEOutboundNumber.Text = ""
                    '
                    empty_scan_list()
                    empty_item_list()

                    BComplete.Text = "Complete"
                    LStatus.Text = ""
                    BReset.Visible = False
                    TEOutboundNumber.Focus()

                    is_able_reopen = False
                End If
            End If
        End If
    End Sub

    Sub empty_scan_list()
        For i = GVScanList.RowCount - 1 To 0 Step -1
            GVScanList.DeleteRow(i)
        Next
    End Sub

    Sub empty_item_list()
        For i = GVItemList.RowCount - 1 To 0 Step -1
            GVItemList.DeleteRow(i)
        Next
    End Sub

    Sub valid_check(ByVal is_popup As Boolean)
        If report_mark_type = "return_transfer" Then
            Dim q As String = "
SELECT * FROM (
	SELECT p.`id_product`,CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting) AS full_code,COUNT(CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)) AS qty
	,IFNULL(sc.qty_scan,0) AS qty_scan
	FROM `tb_sales_return_qc` awb 
	INNER JOIN tb_sales_return_qc_det awbd ON awbd.`id_sales_return_qc`=awb.`id_sales_return_qc` AND awb.`id_sales_return_qc`='" & id_report & "'
	INNER JOIN tb_m_product p ON p.`id_product`=awbd.`id_product`
	INNER JOIN `tb_sales_return_qc_det_counting` delc ON delc.`id_sales_return_qc_det`=awbd.`id_sales_return_qc_det`
	LEFT JOIN
	(
	    SELECT dd.id_product,dd.scanned_code,COUNT(dd.scanned_code) AS qty_scan
	    FROM `tb_wh_cek_fisik_scan` dd
	    INNER JOIN tb_wh_cek_fisik d ON d.id_wh_cek_fisik=dd.id_wh_cek_fisik
	    WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status!=5
	    GROUP BY dd.scanned_code
	)sc ON sc.scanned_code=CONCAT(p.`product_full_code`,delc.sales_return_qc_det_counting)
	GROUP BY full_code
) tt WHERE tt.qty-tt.qty_scan!=0"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                q = "UPDATE tb_sales_return_qc SET status_check_fisik=2 WHERE id_sales_return_qc='" & id_report & "'"
                execute_non_query(q, True, "", "", "", "")
                pushNotifFromDb(id_report, "305")
                If is_popup Then
                    warningCustom("Scan fisik return transfer tidak balance")
                End If
            Else
                q = "UPDATE tb_sales_return_qc SET status_check_fisik=3,id_report_status=3 WHERE id_sales_return_qc='" & id_report & "'"
                execute_non_query(q, True, "", "", "", "")
                'Reset approval
                q = String.Format("UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL WHERE id_report='{0}' AND (report_mark_type='49' OR report_mark_type='106')", id_report)
                execute_non_query(q, True, "", "", "", "")
            End If
        End If
    End Sub

    Private Sub FormOutboundCheckFisik_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class