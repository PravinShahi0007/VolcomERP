Public Class FormWHDelEmptyDet
    Public action As String
    Public id_wh_del_empty As String = "-1"
    Public id_report_status As String
    Public dt As New DataTable
    Public id_pre As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_do_emp")
    Public is_view As String = "-1"
    Public is_fix As String = "2"
    Dim is_scan_prob As String = "-1"

    Private Sub FormWHDelEmptyDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim del As New ClassDelEmpty()
        Dim query As String = del.queryMain("AND del.id_wh_del_empty=" + id_wh_del_empty + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
        DETrans.EditValue = data.Rows(0)("wh_del_empty_date")
        TxtSalesDelOrderNumber.Text = data.Rows(0)("wh_del_empty_number").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_report_status)
        is_fix = data.Rows(0)("is_fix").ToString

        view_detail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub view_detail()
        'detail barcode
        Dim query As String = "SELECT '0' AS `no`, ed.id_wh_del_empty_det,ed.id_wh_del_empty, ed.id_product, ed.scanned_code AS `code`,
        d.design_display_name AS `name`, cd.code_detail_name AS `size` 
        FROM tb_wh_del_empty_det ed
        INNER JOIN tb_m_product p ON p.id_product = ed.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE ed.id_wh_del_empty=" + id_wh_del_empty + " ORDER BY id_wh_del_empty_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        If is_fix = "1" Then
            BtnSave.Enabled = False
            PanelNavBarcode.Enabled = False
        Else
            BtnSave.Enabled = True
            PanelNavBarcode.Enabled = True
        End If

        'attachment
        If check_attach_report_status(id_report_status, "111", id_wh_del_empty) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'pre print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
        TxtSalesDelOrderNumber.Focus()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_wh_del_empty
        FormReportMark.report_mark_type = "111"
        FormReportMark.form_origin = Name
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_wh_del_empty
        FormDocumentUpload.report_mark_type = "111"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtScan.Text)
            If is_scan_prob = "1" Then 'scan

            Else 'del

            End If
        End If
    End Sub
End Class