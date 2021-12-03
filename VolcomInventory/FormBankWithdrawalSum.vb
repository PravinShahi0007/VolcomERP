﻿Public Class FormBankWithdrawalSum
    Public id_sum As String = "-1"
    Public id_report_status As String = "-1"
    Public is_view As String = "-1"
    Public id_coa_type As String = "-1"
    '
    Dim is_submit As Boolean = False

    Sub load_summary_type()
        Dim q As String = "SELECT id_pn_summary_type,pn_summary_type FROM tb_pn_summary_type"
        viewSearchLookupRepositoryQuery(RISLEStatusRelease, q, 0, "pn_summary_type", "id_pn_summary_type")
    End Sub

    Private Sub FormBankWithdrawalSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETotal.EditValue = 0.0
        load_type()
        load_summary_type()
        DEDateCreated.EditValue = Now
        DEPayment.EditValue = Now
        DEChangeDate.EditValue = Now

        If id_sum = "-1" Then 'new
            BCancel.Visible = False
            BRelease.Visible = False
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            '
            id_coa_type = FormBankWithdrawal.SLECOAType.EditValue.ToString
            TECOAType.Text = FormBankWithdrawal.SLECOAType.Text
        Else
            DEPayment.Enabled = False
            SLEType.ReadOnly = True
            '
            BtnSave.Visible = False
            BGenerate.Visible = False
            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            Dim q As String = "SELECT typ.id_coa_type,typ.coa_type,pns.id_report_status,pns.`id_pn_summary`,pns.number,pns.`date_payment`,pns.`created_date`,emp.`employee_name`, cur.`id_currency`,cur.`currency`, pns.note
FROM tb_pn_summary pns
LEFT JOIN tb_pn_summary_det pnsd ON pnsd.id_pn_summary=pns.id_pn_summary
LEFT JOIN tb_pn_det pnd ON pnd.`id_pn`=pnsd.`id_pn` AND pnd.`id_currency`=pns.`id_currency`
INNER JOIN tb_coa_type typ ON typ.id_coa_type=pns.id_coa_type
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pns.`id_currency`
INNER JOIN tb_m_user usr ON usr.`id_user`=pns.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pns.`id_pn_summary`='" & id_sum & "'
GROUP BY pns.`id_pn_summary`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                id_coa_type = dt.Rows(0)("id_coa_type").ToString
                TECOAType.Text = dt.Rows(0)("coa_type").ToString
                TEPayNumber.Text = dt.Rows(0)("number").ToString
                DEDateCreated.EditValue = dt.Rows(0)("created_date")
                DEPayment.EditValue = dt.Rows(0)("date_payment")
                SLEType.EditValue = dt.Rows(0)("id_currency").ToString
                MENote.Text = dt.Rows(0)("note").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
                If id_report_status = "5" Or id_report_status = "6" Then
                    BRelease.Visible = False
                    BCancel.Visible = False
                Else
                    BCancel.Visible = True
                    BRelease.Visible = True
                End If
                load_det()

                Dim is_ada_tolakan As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "id_pn_summary_type").ToString = "1" Then
                        'ada tolakan
                        is_ada_tolakan = True
                        Exit For
                    End If
                Next

                'check submit
                Dim qc As String = "SELECT * FROM tb_report_mark WHERE id_report='" & id_sum & "' AND report_mark_type='" & If(is_ada_tolakan, "285", "251") & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "'")
                If dtc.Rows.Count > 0 Then
                    is_submit = True
                End If

                If is_submit Then
                    GCCheck.Visible = False
                End If
            End If
            '
            LChangeTo.Visible = False
            DEChangeDate.Visible = False
            BChangeDate.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim qh As String = ""
        If SLEType.EditValue.ToString = "1" Then
            qh = "SUM(pyd.`value`)"
        Else
            qh = "SUM(pyd.`val_bef_kurs`)"
        End If
        Dim q As String = "SELECT 'no' AS is_check,py.is_buy_valas,sts.report_status,py.number,emp.employee_name AS created_by, py.date_created, py.`id_pn`,IF(pnsd.id_pn_summary_type=1 OR pnsd.id_pn_summary_type=3," & qh & ",0) AS `value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment
,pnsd.id_pn_summary_det,pnsd.id_pn_summary_type
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_pn_det pyd ON pyd.id_pn=py.id_pn AND pyd.`id_currency`='" & SLEType.EditValue.ToString & "' AND pyd.`is_include_total`=1
INNER JOIN tb_pn_summary_det pnsd ON pnsd.`id_pn`=pyd.`id_pn` AND pnsd.`id_pn_summary`='" & id_sum & "'"

        If SLEType.EditValue.ToString = "1" Then
            q += " GROUP BY py.id_pn "
        Else
            q += " GROUP BY pyd.id_pn_det "
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()

        TETotal.EditValue = GVList.Columns("value").SummaryItem.SummaryValue
    End Sub

    Sub load_type()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupQuery(SLEType, q, "id_currency", "currency", "id_currency")
    End Sub

    Private Sub FormBankWithdrawalSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BGenerate_Click(sender As Object, e As EventArgs) Handles BGenerate.Click
        If BGenerate.Text = "Generate" Then
            generate()
        Else
            unlock()
        End If
    End Sub

    Sub generate()
        'check if already
        Dim qc As String = "SELECT id_pn_summary FROM tb_pn_summary WHERE id_pn_summary!='" & id_sum & "' AND id_coa_type='" & id_coa_type & "' AND id_currency='" & SLEType.EditValue.ToString & "' AND id_report_status!=5 AND id_report_status!=6 AND DATE(date_payment)='" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count = 0 Then
            Dim qw As String = ""
            Dim qs As String = ""
            If SLEType.EditValue.ToString = "1" Then
                qw = " ISNULL(py.id_valas_bank) AND "
                qs = " SUM(pyd.`value`) "
            Else
                qw = " NOT ISNULL(py.id_valas_bank) AND "
                qs = " SUM(pyd.`val_bef_kurs`)"
            End If

            Dim q As String = "SELECT 'no' AS is_check,py.is_buy_valas,sts.report_status,py.number,emp.employee_name AS created_by, py.date_created, py.`id_pn`," & qs & " AS value ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment,1 AS id_pn_summary_type
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_pn_det pyd ON pyd.id_pn=py.id_pn AND pyd.`is_include_total`=1 
INNER JOIN tb_a_acc acc ON acc.id_acc=pyd.id_acc AND acc.is_no_summary=2
INNER JOIN tb_coa_tag ct ON ct.id_coa_tag=py.id_coa_tag AND ct.id_coa_type='" & id_coa_type & "'
WHERE " & qw & " py.`id_report_status`!='5' AND py.`id_report_status`='3' AND py.is_auto_debet='2' AND py.`id_report_status`!='6' AND  DATE(py.`date_payment`)='" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
            q += " GROUP BY py.id_pn "

            'If SLEType.EditValue.ToString = "1" Then
            '    q += " GROUP BY py.id_pn "
            'Else
            '    q += " GROUP BY pyd.id_pn_det "
            'End If

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt
            GVList.BestFitColumns()
            TETotal.EditValue = GVList.Columns("value").SummaryItem.SummaryValue
            DEPayment.Enabled = False
            SLEType.ReadOnly = True
            '
            LChangeTo.Visible = True
            DEChangeDate.Visible = True
            BChangeDate.Visible = True
            '
            BGenerate.Text = "Unlock"
        Else
            warningCustom("Summary already created for this payment date.")
        End If
    End Sub

    Sub unlock()
        Dim q As String = "SELECT 'no' AS is_check,py.is_buy_valas,sts.report_status,py.number,emp.employee_name AS created_by, py.date_created, py.`id_pn`,py.`value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment, 1 AS id_pn_summary_type
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
WHERE py.id_pn='-1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        TETotal.EditValue = GVList.Columns("value").SummaryItem.SummaryValue
        DEPayment.Enabled = True
        SLEType.ReadOnly = False
        '
        LChangeTo.Visible = False
        DEChangeDate.Visible = False
        BChangeDate.Visible = False
        '
        BGenerate.Text = "Generate"
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVList.RowCount = 0 Then
            warningCustom("No BBK listed.")
        Else
            If id_sum = "-1" Then 'new
                Dim q As String = "INSERT INTO tb_pn_summary(id_coa_type,id_currency,date_payment,created_date,created_by,note,id_report_status)
VALUES('" & id_coa_type & "','" & SLEType.EditValue.ToString & "','" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "',1); SELECT LAST_INSERT_ID();"
                id_sum = execute_query(q, 0, True, "", "", "", "")
                '
                q = "DELETE FROM tb_pn_summary_det WHERE id_pn_summary='" & id_sum & "' "
                execute_non_query(q, True, "", "", "", "")
                '
                For i As Integer = 0 To GVList.RowCount - 1
                    q = "INSERT INTO tb_pn_summary_det(id_pn_summary,id_pn) VALUES('" & id_sum & "','" & GVList.GetRowCellValue(i, "id_pn").ToString & "')"
                    execute_non_query(q, True, "", "", "", "")
                Next

                q = "CALL gen_number('" & id_sum & "','251')"
                execute_non_query(q, True, "", "", "", "")

                'pindah
                'submit_who_prepared("251", id_sum, id_user)

                FormBankWithdrawal.view_sum()
                Close()
            End If
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_pn_summary SET id_report_status=5 WHERE id_pn_summary='" + id_sum + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = ""
            Try
                queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "251", id_sum)
                execute_non_query(queryrm, True, "", "", "", "")
            Catch ex As Exception
            End Try

            'nonaktif mark
            Try
                queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "285", id_sum)
                execute_non_query(queryrm, True, "", "", "", "")
            Catch ex As Exception
            End Try

            FormBankWithdrawal.view_sum()
            FormBankWithdrawal.GVBBKSummary.FocusedRowHandle = find_row(FormBankWithdrawal.GVBBKSummary, "id_pn_summary", id_sum)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportBankWithdrawalSum.id_sum = id_sum
        Dim Report As New ReportBankWithdrawalSum()

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        'If CEPrintPreview.EditValue = True Then
        '    Dim Tool As ReportPrintTool = New ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'Else
        '    Dim instance As New Printing.PrinterSettings
        '    Dim DefaultPrinter As String = instance.PrinterName

        '    ' THIS IS TO PRINT THE REPORT
        '    Report.PrinterName = DefaultPrinter
        '    Report.CreateDocument()
        '    Report.PrintingSystem.ShowMarginsWarning = False
        '    Report.Print()
        'End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BRelease_Click(sender As Object, e As EventArgs) Handles BRelease.Click
        'check first
        Dim q As String = "SELECT pnsd.id_pn 
FROM tb_pn_summary_det pnsd 
INNER JOIN tb_pn pn ON pn.id_pn=pnsd.id_pn AND pnsd.`id_pn_summary_type`!=2
WHERE pn.id_report_status!=3 AND pnsd.id_pn_summary='" & id_sum & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            warningCustom("BBK need to be approved.")
        Else
            'check jika ada pembelian valas, release BBK yang valas dulu
            'Dim is_buy_valas As Boolean = False
            'Dim is_pending_valas As Boolean = False
            'For i As Integer = 0 To GVList.RowCount - 1
            '    If GVList.GetRowCellValue(i, "is_buy_valas").ToString = "1" Then
            '        is_buy_valas = True
            '    End If
            'Next

            'If is_buy_valas Then
            '    If is_buy_valas Then
            '        Dim qusing_valas_pend As String = "SELECT * 
            '    FROM tb_pn_det pnd
            '    INNER JOIN tb_pn pn ON pn.id_pn=pnd.`id_pn`
            '    WHERE pn.id_report_status!=6 AND pn.`id_report_status`!=5 AND pn.`kurs`>1"
            '        Dim dtc As DataTable = execute_query(qusing_valas_pend, -1, True, "", "", "", "")
            '        If dtc.Rows.Count > 0 Then
            '            is_pending_valas = True
            '        End If
            '    End If
            'End If

            'If is_pending_valas Then
            '    warningCustom("Release BBK dengan valas terlebih dahulu.")
            'Else
            '    FormReportMark.id_report = id_sum
            '    FormReportMark.report_mark_type = "251"
            '    FormReportMark.form_origin = Name
            '    FormReportMark.ShowDialog()
            'End If
            'check kalau ada tolak
            Dim qc As String = "SELECT * FROM tb_pn_summary_det WHERE id_pn_summary_type='3' AND id_pn_summary='" & id_sum & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            '
            If dtc.Rows.Count > 0 Then
                'ada yang tolak
                'check dulu attachment mutasi
                Dim qcu As String = "SELECT * FROM tb_doc WHERE id_report='" & id_sum & "' AND report_mark_Type='285'"
                Dim dtcu As DataTable = execute_query(qcu, -1, True, "", "", "", "")
                If dtcu.Rows.Count > 0 Then
                    FormReportMark.id_report = id_sum
                    FormReportMark.report_mark_type = "285"
                    FormReportMark.form_origin = Name
                    FormReportMark.ShowDialog()
                Else
                    warningCustom("Please attach mutasi.")
                End If
            Else
                FormReportMark.id_report = id_sum
                FormReportMark.report_mark_type = "251"
                FormReportMark.form_origin = Name
                FormReportMark.ShowDialog()
            End If
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sum
        FormDocumentUpload.report_mark_type = "251"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BChangeDate_Click(sender As Object, e As EventArgs) Handles BChangeDate.Click
        GVList.ActiveFilterString = ""
        GVList.ActiveFilterString = "[is_check]='yes'"

        If GVList.RowCount > 0 Then
            'check if summary already created and completed
            Dim qc As String = "SELECT * FROM tb_pn_summary WHERE DATE(date_payment)='" & Date.Parse(DEChangeDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND id_report_status=6"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("This payment date already created and completed")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to change payment date ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    For i = 0 To GVList.RowCount - 1
                        'update date payment + remove from this summary + add to summary
                        Dim query As String = "UPDATE tb_pn SET date_payment='" & Date.Parse(DEChangeDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_pn='" & GVList.GetRowCellValue(i, "id_pn").ToString & "'"
                        execute_non_query(query, True, "", "", "", "")
                        query = "DELETE FROM tb_pn_summary_det WHERE id_pn_summary='" & id_sum & "' AND id_pn='" & GVList.GetRowCellValue(i, "id_pn").ToString & "'"
                        execute_non_query(query, True, "", "", "", "")
                        qc = "SELECT id_pn_summary FROM tb_pn_summary WHERE DATE(date_payment)='" & Date.Parse(DEChangeDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND id_currency='" & SLEType.EditValue.ToString & "' AND id_coa_type='" & id_coa_type & "' AND id_report_status!=6"
                        dtc = execute_query(qc, -1, True, "", "", "", "")
                        If dtc.Rows.Count > 0 Then
                            query = "INSERT INTO tb_pn_summary_det(id_pn_summary,id_pn) VALUES('" & dtc.Rows(0)("id_pn_summary").ToString & "','" & GVList.GetRowCellValue(i, "id_pn").ToString & "')"
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        'log
                        query = "INSERT INTO tb_pn_log_date_payment(id_pn,log_date,from_date,to_date,log_by) VALUES('" & GVList.GetRowCellValue(i, "id_pn").ToString & "',NOW(),'" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEChangeDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "')"
                        execute_non_query(query, True, "", "", "", "")
                    Next
                    'refresh list
                    If id_sum = "-1" Then
                        unlock()
                        generate()
                    Else
                        load_det()
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        Else
            warningCustom("Please select BBK first.")
        End If

        GVList.ActiveFilterString = ""
    End Sub

    Private Sub CMChangeDate_Click(sender As Object, e As EventArgs) Handles CMChangeDate.Click
        If is_submit Then
            warningCustom("This summary is already locked")
        Else
            GVList.ActiveFilterString = "[is_check]='yes'"
            If GVList.RowCount > 0 Then
                FormBankWithdrawalSumDate.ShowDialog()
            Else
                warningCustom("Please select data first.")
            End If
            GVList.ActiveFilterString = ""
        End If
    End Sub

    Private Sub BAttachmentMutasi_Click(sender As Object, e As EventArgs) Handles BAttachmentMutasi.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sum
        FormDocumentUpload.report_mark_type = "285"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TolakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TolakToolStripMenuItem.Click
        If is_submit Then
            warningCustom("This summary is already locked")
        Else
            GVList.ActiveFilterString = "[is_check]='yes'"
            If GVList.RowCount > 0 Then
                'status tolakan
                Try
                    For i = 0 To GVList.RowCount - 1
                        Dim q As String = "UPDATE tb_pn_summary_det SET id_pn_summary_type='3' WHERE id_pn_summary_det='" & GVList.GetFocusedRowCellValue("id_pn_summary_det").ToString & "'"
                        execute_non_query(q, True, "", "", "", "")
                    Next
                Catch ex As Exception
                End Try
                load_det()
            Else
                warningCustom("Please select data first.")
            End If
            GVList.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVList.RowCellStyle
        Try
            If GVList.GetRowCellValue(e.RowHandle, "id_pn_summary_type").ToString = "3" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.FontStyleDelta = FontStyle.Bold
            ElseIf GVList.GetRowCellValue(e.RowHandle, "id_pn_summary_type").ToString = "2" Then
                e.Appearance.BackColor = Color.LightYellow
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class