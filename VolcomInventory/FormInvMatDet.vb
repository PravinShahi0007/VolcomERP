Imports DevExpress.XtraReports.UI

Public Class FormInvMatDet
    Public id_inv As String = "-1"
    Public id_status As String = "1"

    Public is_deposit As String = "-1"
    Public is_view As String = "-1"
    '
    Sub load_form()
        load_vendor()
        load_type()

        DEDueDate.EditValue = Now
        DERefDate.EditValue = Now
        DEDateCreated.EditValue = Now

        If id_inv = "-1" Then 'new
            BtnPrint.Visible = False
            PanelControlPreview.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            XTPDraft.PageVisible = False
            '
            load_det()
            'vendor 
            SLEVendor.EditValue = FormInvMat.SLEVendorPayment.EditValue

            If FormInvMat.XTCMatInv.SelectedTabPageIndex = 1 Then
                'invoice pl
                SLEPayType.EditValue = "1"
                'detail
                Try
                    For i = 0 To FormInvMat.GVPL.RowCount - 1
                        If is_deposit = "1" Then
                            Dim query As String = "SELECT md.`mat_det_code`,md.`mat_det_name`,pld.`pl_mrs_det_qty` AS qty,ROUND(pld.`pl_mrs_det_price`,2) AS price,(pld.`pl_mrs_det_qty`*ROUND(pld.`pl_mrs_det_price`,2)) AS amount
FROM tb_pl_mrs_det pld
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
WHERE pld.`id_pl_mrs`='" & FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString & "'"
                            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                            For j As Integer = 0 To data.Rows.Count - 1
                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow("id_prod_order") = "0"
                                newRow("prod_order_number") = "-"
                                newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                                newRow("report_mark_type") = "30"
                                newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                                newRow("info_design") = data.Rows(j)("mat_det_code").ToString & " - " & data.Rows(j)("mat_det_name").ToString
                                newRow("qty") = data.Rows(j)("qty")
                                newRow("price") = data.Rows(j)("price")
                                newRow("value") = data.Rows(j)("price") * data.Rows(j)("qty")
                                newRow("note") = ""
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                            Next
                        Else
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvMat.GVPL.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("prod_order_number") = FormInvMat.GVPL.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                            newRow("report_mark_type") = "30"
                            newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                            newRow("info_design") = FormInvMat.GVPL.GetRowCellValue(i, "design_display_name").ToString
                            newRow("value") = FormInvMat.GVPL.GetRowCellValue(i, "amount")
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf FormInvMat.XTCMatInv.SelectedTabPageIndex = 2 Then
                'invoice retur
                SLEPayType.EditValue = "2"
                'detail
                Try
                    For i = 0 To FormInvMat.GVRetur.RowCount - 1
                        If is_deposit = "1" Then

                        Else
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvMat.GVRetur.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("prod_order_number") = FormInvMat.GVRetur.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("id_report") = FormInvMat.GVRetur.GetRowCellValue(i, "id_mat_prod_ret_in").ToString
                            newRow("report_mark_type") = "32"
                            newRow("report_number") = FormInvMat.GVRetur.GetRowCellValue(i, "mat_prod_ret_in_number").ToString
                            newRow("info_design") = FormInvMat.GVRetur.GetRowCellValue(i, "design_display_name").ToString
                            newRow("value") = FormInvMat.GVRetur.GetRowCellValue(i, "amount")
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf FormInvMat.XTCMatInv.SelectedTabPageIndex = 3 Then
                'packing list with memo
                TEVatPercent.Enabled = False
                SLEPayType.EditValue = "3"
                'detail
                Try
                    For i = 0 To FormInvMat.GVPLMemo.RowCount - 1
                        '                        Dim query As String = "SELECT md.`mat_det_code`,md.`mat_det_name`,pld.`pl_mrs_det_qty` AS qty,ROUND(pld.`pl_mrs_det_price`,2) AS price,(pld.`pl_mrs_det_qty`*ROUND(pld.`pl_mrs_det_price`,2)) AS amount
                        'FROM tb_pl_mrs_det pld
                        'INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
                        'INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
                        'WHERE pld.`id_pl_mrs`='" & FormInvMat.GVPLMemo.GetRowCellValue(i, "id_pl_mrs").ToString & "'"
                        '                        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                        '                        For j As Integer = 0 To data.Rows.Count - 1
                        '                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        '                            newRow("id_prod_order") = "0"
                        '                            newRow("prod_order_number") = "-"
                        '                            newRow("id_report") = FormInvMat.GVPLMemo.GetRowCellValue(i, "id_pl_mrs").ToString
                        '                            newRow("report_mark_type") = "30"
                        '                            newRow("report_number") = FormInvMat.GVPLMemo.GetRowCellValue(i, "pl_mrs_number").ToString
                        '                            newRow("info_design") = data.Rows(j)("mat_det_code").ToString & " - " & data.Rows(j)("mat_det_name").ToString
                        '                            newRow("qty") = data.Rows(j)("qty")
                        '                            newRow("price") = data.Rows(j)("price")
                        '                            newRow("value") = data.Rows(j)("price") * data.Rows(j)("qty")
                        '                            newRow("note") = ""
                        '                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        '                        Next

                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = FormInvMat.GVPLMemo.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("prod_order_number") = FormInvMat.GVPLMemo.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("id_report") = FormInvMat.GVPLMemo.GetRowCellValue(i, "id_pl_mrs").ToString
                        newRow("report_mark_type") = "30"
                        newRow("report_number") = FormInvMat.GVPLMemo.GetRowCellValue(i, "pl_mrs_number").ToString
                        newRow("info_design") = FormInvMat.GVPLMemo.GetRowCellValue(i, "design_display_name").ToString
                        newRow("value") = FormInvMat.GVPLMemo.GetRowCellValue(i, "amount")
                        newRow("note") = ""
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            DERefDate.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='1'", 0, True, "", "", "", "")
        Else 'edit
            BtnPrint.Visible = True
            PanelControlPreview.Visible = True
            BMark.Visible = True
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            TEVatPercent.Enabled = False
            '
            XTPDraft.PageVisible = True
            BAttachment.Visible = True

            'load header
            Dim q_head As String = "SELECT inv.`number`,inv.is_not_kas,inv.`id_comp`,inv.is_deposit,c.`comp_name`,inv.`vat_percent`,inv.`id_inv_mat_type`,typ.`inv_mat_type`,inv.created_date,inv.ref_date,inv.due_date,inv.note,inv.id_report_status
FROM tb_inv_mat inv
INNER JOIN tb_m_comp c ON c.`id_comp`=inv.`id_comp`
INNER JOIN `tb_inv_mat_type` typ ON typ.`id_inv_mat_type`=inv.`id_inv_mat_type`
WHERE inv.id_inv_mat='" & id_inv & "'"
            Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
            If dt_head.Rows.Count > 0 Then
                TENumber.Text = dt_head.Rows(0)("number").ToString
                SLEPayType.EditValue = dt_head.Rows(0)("id_inv_mat_type").ToString
                SLEVendor.EditValue = dt_head.Rows(0)("id_comp").ToString
                '
                DEDateCreated.EditValue = dt_head.Rows(0)("created_date")
                DEDueDate.EditValue = dt_head.Rows(0)("due_date")
                DERefDate.EditValue = dt_head.Rows(0)("ref_date")
                TEVatPercent.EditValue = dt_head.Rows(0)("vat_percent")
                MENote.Text = dt_head.Rows(0)("note").ToString
                '
                id_status = dt_head.Rows(0)("id_report_status").ToString
                is_deposit = dt_head.Rows(0)("is_deposit").ToString
                '
                If dt_head.Rows(0)("is_not_kas").ToString = "1" Then
                    CEKas.Checked = False
                Else
                    CEKas.Checked = True
                End If
            End If
            '
            load_det()
            calculate()
            '
            If id_status = "6" Then
                BtnViewJournal.Visible = True
            Else
                BtnViewJournal.Visible = False
            End If
        End If

        If is_deposit = "1" Then
            GridColumnFGPO.Visible = False
            GridColumnPayment.Visible = False
            '
            GridColumnQty.Visible = True
            GridColumnPrice.Visible = True
            GridColumnAmount.Visible = True
            '
            CEKas.Visible = True
        Else
            GridColumnFGPO.Visible = True
            GridColumnPayment.Visible = True
            '
            GridColumnQty.Visible = False
            GridColumnPrice.Visible = False
            GridColumnAmount.Visible = False

            CEKas.Visible = False
        End If

        If SLEPayType.EditValue.ToString = "1" Then
            Text = "Invoice Material"
        Else
            Text = "Credit Note Material"
        End If
    End Sub

    Private Sub FormInvMatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_inv_mat_type,inv_mat_type FROM `tb_inv_mat_type`"
        viewSearchLookupQuery(SLEPayType, query, "id_inv_mat_type", "inv_mat_type", "id_inv_mat_type")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar` FROM tb_pl_mrs pl
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
GROUP BY c.`id_comp`"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub calculate()
        Dim tot As Decimal = 0.0
        Dim vat_p As Decimal = 0.0
        Dim tot_vat As Decimal = 0.0
        Dim grand_tot As Decimal = 0.0

        Try
            tot = GVList.Columns("value").SummaryItem.SummaryValue
            vat_p = TEVatPercent.EditValue
            tot_vat = tot * (vat_p / 100)
            '
            TETotal.EditValue = tot
            TEVat.EditValue = tot_vat
            grand_tot = tot + tot_vat
            TEGrandTotal.EditValue = grand_tot
        Catch ex As Exception

        End Try
    End Sub

    Sub load_det()
        Dim query As String = ""

        If is_deposit = "1" Then
            query = "SELECT 0 AS `id_prod_order`,'-' AS `prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.`value`,invd.price,invd.qty,invd.note
FROM `tb_inv_mat_det` invd
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        Else
            query = "SELECT po.`id_prod_order`,po.`prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.`value`,invd.note
FROM `tb_inv_mat_det` invd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=invd.`id_prod_order`
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCList.DataSource = data
    End Sub

    Private Sub FormInvMatDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEVatPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVatPercent.EditValueChanged
        calculate()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not SLEVendor.EditValue.ToString = "" Then
            If SLEPayType.EditValue.ToString = "1" Then 'PL
                If id_inv = "-1" Then
                    'new
                    'header
                    Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`,is_deposit,is_not_kas)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "','" & If(is_deposit = "1", "1", "2") & "','" & If(CEKas.Checked = True, "2", "1") & "'); SELECT LAST_INSERT_ID(); "
                    id_inv = execute_query(query, 0, True, "", "", "", "")
                    'id_inv
                    query = ""
                    For i = 0 To GVList.RowCount - 1
                        If is_deposit = "1" Then
                            query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`qty`,`price`,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "price").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                        Else
                            query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                        End If
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = "CALL gen_number('" & id_inv & "','231')"
                    execute_non_query(query, True, "", "", "", "")
                    submit_who_prepared("231", id_inv, id_user)
                    '
                    infoCustom("BPB Created")
                    FormInvMat.load_view()
                    FormInvMat.XTCMatInv.SelectedTabPageIndex = 0
                    FormInvMat.load_view()
                    FormInvMat.GVInvoice.FocusedRowHandle = find_row(FormInvMat.GVInvoice, "id_inv_mat", id_inv)
                    Close()
                Else
                    'edit
                    Dim query As String = ""
                End If
            ElseIf SLEPayType.EditValue.ToString = "2" Then 'retur
                If id_inv = "-1" Then
                    'new
                    'header
                    Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`,is_deposit)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "','2'); SELECT LAST_INSERT_ID(); "
                    id_inv = execute_query(query, 0, True, "", "", "", "")
                    'id_inv
                    query = ""
                    For i = 0 To GVList.RowCount - 1
                        query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = "CALL gen_number('" & id_inv & "','231')"
                    execute_non_query(query, True, "", "", "", "")
                    submit_who_prepared("231", id_inv, id_user)
                    '
                    infoCustom("BRP Created")
                    FormInvMat.load_view()
                    FormInvMat.XTCMatInv.SelectedTabPageIndex = 0
                    FormInvMat.load_view()
                    FormInvMat.GVInvoice.FocusedRowHandle = find_row(FormInvMat.GVInvoice, "id_inv_mat", id_inv)
                    Close()
                Else
                    'edit
                    Dim query As String = ""
                End If
            ElseIf SLEPayType.EditValue.ToString = "3" Then 'langsung biaya
                If id_inv = "-1" Then
                    'new
                    'header
                    Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`,is_deposit)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "','" & If(is_deposit = "1", "1", "2") & "'); SELECT LAST_INSERT_ID(); "
                    id_inv = execute_query(query, 0, True, "", "", "", "")
                    'id_inv
                    query = ""
                    For i = 0 To GVList.RowCount - 1
                        If is_deposit = "1" Then
                            query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`qty`,`price`,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "price").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                        Else
                            query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                        End If
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = "CALL gen_number('" & id_inv & "','231')"
                    execute_non_query(query, True, "", "", "", "")
                    submit_who_prepared("231", id_inv, id_user)
                    '
                    infoCustom("BPB Created")
                    FormInvMat.load_view()
                    FormInvMat.XTCMatInv.SelectedTabPageIndex = 0
                    FormInvMat.load_view()
                    FormInvMat.GVInvoice.FocusedRowHandle = find_row(FormInvMat.GVInvoice, "id_inv_mat", id_inv)
                    Close()
                Else
                    'edit
                    Dim query As String = ""
                End If
            End If
        Else
            warningCustom("Please make sure vendor already choosen")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportInvMat.id_inv_mat = id_inv
        ReportInvMat.rmt = "231"
        ReportInvMat.dt = GCList.DataSource
        Dim Report As New ReportInvMat()

        If id_status = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        If CEPrintPreview.EditValue = True Then
            Dim Tool As ReportPrintTool = New ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=231 AND ad.id_report=" + id_inv + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "231"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_inv
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "price" Then
            GVList.SetRowCellValue(e.RowHandle, "value", GVList.GetRowCellValue(e.RowHandle, "price") * GVList.GetRowCellValue(e.RowHandle, "qty"))
        End If
        GVList.RefreshData()
        calculate()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_inv
        FormDocumentUpload.report_mark_type = "231"
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCInvMat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCInvMat.SelectedPageChanged
        If XTCInvMat.SelectedTabPageIndex = 1 Then
            GVList.RefreshData()
            load_blank_draft()
            viewDraftJournal()
        End If
    End Sub

    Sub load_blank_draft()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVList.RowCount > 0 Then
            Dim dn_date As String = ""
            Dim ref_date As String = ""
            Dim bill_type As String = ""
            Dim id_type As String = ""
            Dim is_deposit As String = ""
            Dim is_not_kas As String = ""

            Dim q_head As String = "SELECT created_date,ref_date,id_inv_mat_type,is_deposit,is_not_kas FROM tb_inv_mat WHERE id_inv_mat='" & id_inv & "'"
            Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
            If dt_head.Rows.Count > 0 Then
                dn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                id_type = dt_head.Rows(0)("id_inv_mat_type").ToString
                is_deposit = dt_head.Rows(0)("is_deposit").ToString
                is_not_kas = dt_head.Rows(0)("is_deposit").ToString

                If dt_head.Rows(0)("id_inv_mat_type").ToString = "1" Then
                    bill_type = "23"
                ElseIf dt_head.Rows(0)("id_inv_mat_type").ToString = "2" Then
                    bill_type = "20"
                End If
            End If

            Dim qjd As String = ""

            'check status pabean
            Dim id_status_pabean As String = execute_query("SELECT id_status_pabean FROM tb_m_comp WHERE id_comp = (SELECT id_comp FROM tb_inv_mat WHERE id_inv_mat = " + id_inv + ")", 0, True, "", "", "", "")

            If is_deposit = "1" And is_not_kas = "2" Then
                qjd = "SELECT a.*,acc.`acc_name`,acc.`acc_description`,c.comp_number AS cc FROM (
-- pend lain tanpa ppn
SELECT  (SELECT id_acc_pend_lain FROM tb_opt_accounting) AS `id_acc`, inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "' AND inv.vat_percent = 0   
UNION ALL                 
-- pend lain dengan ppn
SELECT  (SELECT id_acc_pend_lain_dgn_ppn FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "' AND inv.vat_percent > 0
UNION ALL
-- hutang PPN
SELECT  (SELECT id_acc_ppn_lain FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(15,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "' AND inv.vat_percent > 0
UNION ALL
-- KAS
SELECT  (SELECT id_acc_kas FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(15,2)) AS `debit`, 0 AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "' 
) a
INNER JOIN tb_a_acc acc ON acc.id_acc=a.id_acc
INNER JOIN tb_m_comp c ON c.id_comp=a.id_comp
WHERE a.credit>0 OR a.debit>0"
            Else
                If id_type = "1" Then 'pl
                    Dim inv_pct As String = "inv.`vat_percent`"

                    If id_status_pabean = "2" Then
                        inv_pct = "0"
                    End If

                    qjd = "SELECT a.*,acc.`acc_name`,acc.`acc_description`,c.comp_number AS cc FROM (
SELECT  (SELECT id_acc_jual_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `credit`
,CONCAT('PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "'
UNION ALL
-- hutang PPN
SELECT * FROM (
    SELECT  (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`)*((" + inv_pct + ")/(100)) AS DECIMAL(15,2)) AS `credit`
    ,CONCAT('PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
    FROM `tb_inv_mat_det` invd
    INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
    WHERE invd.`id_inv_mat`='" & id_inv & "'
) AS tb
WHERE tb.credit > 0
UNION ALL
-- AR
SELECT  c.id_acc_ar AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((100+" + inv_pct + ")/(100)) AS DECIMAL(15,2)) AS `debit`, 0 AS `credit`
,CONCAT('PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_inv & "') a
INNER JOIN tb_a_acc acc ON acc.id_acc=a.id_acc 
INNER JOIN tb_m_comp c ON c.id_comp=a.id_comp"
                ElseIf id_type = "2" Then 'ret
                    Dim inv_pct As String = "inv.`vat_percent`"

                    If id_status_pabean = "2" Then
                        inv_pct = "0"
                    End If

                    qjd = "SELECT a.*,acc.`acc_name`,acc.`acc_description`,c.comp_number AS cc FROM (
SELECT  (SELECT id_acc_retur_jual_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,  CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `debit`,0 AS `credit`
,CONCAT('RETUR PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "'
UNION ALL
-- hutang PPN
SELECT * FROM (
    SELECT  (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((" + inv_pct + ")/(100)) AS DECIMAL(15,2)) AS `debit`,0 AS `credit`
    ,CONCAT('RETUR PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
    FROM `tb_inv_mat_det` invd
    INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
    WHERE invd.`id_inv_mat`='" & id_inv & "'
) AS tb
WHERE tb.debit > 0
UNION ALL
-- AR
SELECT  c.id_acc_ar AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,0 AS `debit`, CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(15,2)) AS `credit`
,CONCAT('RETUR PENJUALAN SUPPLIES') AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_inv & "') a
INNER JOIN tb_a_acc acc ON acc.id_acc=a.id_acc
INNER JOIN tb_m_comp c ON c.id_comp=a.id_comp"
                ElseIf id_type = "3" Then 'dengan memo 
                    qjd = "SELECT a.*,acc.`acc_name`,acc.`acc_description`,c.comp_number AS cc FROM (
-- adj
SELECT  (SELECT id_acc_biaya_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,  CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `debit`,0 AS `credit`
,inv.note AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "'
UNION ALL
-- Persediaan
SELECT  (SELECT id_acc_biaya_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(15,2)) AS `credit`
,inv.note AS `note`, 231 AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_inv & "') a
INNER JOIN tb_a_acc acc ON acc.id_acc=a.id_acc
INNER JOIN tb_m_comp c ON c.id_comp=a.id_comp"
                End If
            End If
            Dim dt As DataTable = execute_query(qjd, -1, True, "", "", "", "")
            GCDraft.DataSource = dt
        End If
        Cursor = Cursors.Default
    End Sub
End Class