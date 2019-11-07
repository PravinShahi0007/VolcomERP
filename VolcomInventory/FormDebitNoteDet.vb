Public Class FormDebitNoteDet
    Public id_dn As String = "-1"
    Public id_dn_type As String = "-1"
    Public id_comp As String = "-1"

    Private Sub FormDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()

        If id_dn = "-1" Then
            'pick from type
            If id_dn_type = "1" Then 'reject claim
                For i As Integer = 0 To FormDebitNote.GVSumClaimReject.RowCount - 1
                    'add row
                    If (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")) > 0 Then 'reject minor
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("number") = i + 1
                        newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                        newRow("description") = "REJECT MINOR"
                        newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor")
                        newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                        newRow("qty") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))
                        newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") / 100)
                        newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If

                    If (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major")) > 0 Then 'reject major
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("number") = i + 1
                        newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                        newRow("description") = "REJECT MAJOR"
                        newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major")
                        newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                        newRow("qty") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                        newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") / 100)
                        newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If

                    If FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir") > 0 Then 'reject afkir
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("number") = i + 1
                        newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                        newRow("description") = "AFKIR"
                        newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir")
                        newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                        newRow("qty") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                        newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") / 100)
                        newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                    GVItemList.BestFitColumns()
                Next
            ElseIf id_dn_type = "2" Then 'late claim
                Try
                    For i As Integer = 0 To FormDebitNote.GVClaimLate.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("number") = i + 1
                        newRow("id_report") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("report_mark_type") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_number") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("info_design") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "design_display_name").ToString
                        newRow("description") = "HASIL PRODUKSI DATANG TERLAMBAT" & vbNewLine & "Delivery Date PO : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "est_rec_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Delivery Date KO : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "est_rec_date_ko").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Received Date : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "arrive_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Charge Back : " & FormDebitNote.GVClaimLate.GetRowCellValue(i, "late_day").ToString & " hari kalender"
                        newRow("claim_percent") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent")
                        newRow("unit_price") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price")
                        newRow("qty") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "rec_qty_trx")
                        newRow("claim_pcs") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent") / 100)
                        newRow("claim_amo") = (FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent") / 100)) * FormDebitNote.GVClaimLate.GetRowCellValue(i, "rec_qty_trx")
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    Next
                    GVItemList.BestFitColumns()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Else

        End If

        calculate()
    End Sub

    Sub load_header()
        Dim query As String = "SELECT dn.`id_debit_note`,dn.`id_comp`,dn.`number`,dn.`id_dn_type`,dnt.dn_type,dn.`created_date`,st.`report_status`,dn.`note`,dn.`id_report_status`,emp.`employee_name`,comp.`comp_name` FROM tb_debit_note dn
INNER JOIN tb_m_comp comp ON comp.`id_comp`=dn.`id_comp`
INNER JOIN tb_m_user usr ON usr.`id_user`=dn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status st ON st.`id_report_status`=dn.`id_report_status`
INNER JOIN tb_lookup_dn_type dnt ON dnt.id_dn_type=dn.id_dn_type
WHERE dn.id_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            id_comp = data.Rows(0)("id_comp").ToString
            TEDNType.Text = data.Rows(0)("dn_type").ToString
            TEVendor.Text = data.Rows(0)("comp_name").ToString
            DECreated.Text = Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            TENumber.Text = data.Rows(0)("number").ToString
            TECreatedBy.Text = data.Rows(0)("employee_name").ToString
            MENote.Text = data.Rows(0)("note").ToString
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT dnd.`report_number`,dnd.`info_design`,dnd.`description`,dnd.`claim_percent`,dnd.`unit_price`,dnd.`qty`,dnd.`id_report`,dnd.`report_mark_type`,0.00 as claim_pcs, 0.00 as claim_amo
,@curRow := @curRow + 1 AS `number`
FROM tb_debit_note_det dnd
JOIN (SELECT @curRow := 0) r
WHERE dnd.id_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_dn
        FormReportMark.report_mark_type = "221"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate()
        Dim total As Decimal = 0.00

        total = Decimal.Parse(GVItemList.Columns("claim_amo").SummaryItem.SummaryValue)
        METotSay.Text = ConvertCurrencyToIndonesian(total).ToUpper
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim note As String = addSlashes(MENote.Text)
        Dim is_ok As Boolean = True
        '
        For i As Integer = 0 To GVItemList.RowCount - 1
            If GVItemList.GetRowCellValue(i, "claim_amo") <= 0 Then
                is_ok = False
            End If
        Next
        '
        If GVItemList.RowCount = 0 Then
            warningCustom("Please input what to debit note")
        ElseIf id_comp = "-1" Then
            warningCustom("Please choose the vendor first.")
        ElseIf is_ok = False Then
            warningCustom("Please complete your detail input")
        Else
            If id_dn = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_debit_note(id_comp,id_dn_type,created_by,created_date,note,id_report_status) VALUES('" & id_comp & "','" & id_dn_type & "','',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID(); "
                id_dn = execute_query(query, 0, True, "", "", "", "")

                Dim q_det As String = "INSERT INTO tb_debit_note_det(id_debit_note,id_report,report_mark_type,report_number,info_design,description,claim_percent,unit_price,qty) VALUES"
                For i As Integer = 0 To GVItemList.RowCount - 1
                    If i > 0 Then
                        q_det += ","
                    End If
                    q_det += "('" & id_dn & "','" & GVItemList.GetRowCellValue(i, "id_report").ToString & "','" & GVItemList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVItemList.GetRowCellValue(i, "report_number").ToString & "','" & GVItemList.GetRowCellValue(i, "info_design").ToString & "','" & addSlashes(GVItemList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "claim_percent").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "unit_price").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString) & "')"
                Next
                execute_non_query(q_det, True, "", "", "", "")
            Else 'edit

            End If
        End If
    End Sub
End Class