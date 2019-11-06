Public Class FormDebitNoteDet
    Public id_dn As String = "-1"
    Public id_dn_type As String = "-1"

    Private Sub FormDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()

        If id_dn = "-1" Then
            'pick from type
            If id_dn_type = "1" Then 'reject claim
                For i As Integer = 0 To FormDebitNote.GVSumClaimReject.RowCount - 1
                    'add row
                    If (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")) > 0 Then 'reject minor
                        Dim newRow As DataRow = (TryCast(FormDebitNote.GCSumClaimReject.DataSource, DataTable)).NewRow()
                        newRow("no") = i + 1
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
                        Dim newRow As DataRow = (TryCast(FormDebitNote.GCSumClaimReject.DataSource, DataTable)).NewRow()
                        newRow("no") = i + 1
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
                        Dim newRow As DataRow = (TryCast(FormDebitNote.GCSumClaimReject.DataSource, DataTable)).NewRow()
                        newRow("no") = i + 1
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
                Next
            ElseIf id_dn_type = "2" Then 'late claim
                For i As Integer = 0 To FormDebitNote.GVClaimLate.RowCount - 1
                    Dim newRow As DataRow = (TryCast(FormDebitNote.GCSumClaimReject.DataSource, DataTable)).NewRow()
                    newRow("no") = i + 1
                    newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                    newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                    newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                    newRow("description") = "HASIL PRODUKSI DATANG TERLAMBAT" & vbNewLine & "Delivery Date PO : " & Date.Parse(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "est_rec_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Delivery Date KO : " & Date.Parse(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "est_rec_date_ko").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Received Date : " & Date.Parse(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "arrive_in_qc").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Charge Back : " & FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "late_day").ToString & " hari kalender"
                    newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "claim_percent")
                    newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                    newRow("qty") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_qty_trx")
                    newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "claim_percent") / 100)
                    newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "claim_percent") / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_qty_trx")
                    TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                Next
            End If
        Else

        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT dnd.`report_number`,dnd.`info_design`,dnd.`description`,dnd.`claim_percent`,dnd.`unit_price`,dnd.`qty`,dnd.`id_report`,dnd.`report_mark_type`,0.00 as claim_pcs, 0.00 as claim_amo
,@curRow := @curRow + 1 AS `no`
FROM tb_debit_note_det dnd
JOIN (SELECT @curRow := 0) r
WHERE dnd.id_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class