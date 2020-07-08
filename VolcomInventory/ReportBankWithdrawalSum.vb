Public Class ReportBankWithdrawalSum
    Public Shared id_sum As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"
    Public Shared dt As DataTable
    Public id_pre As String = "-1"

    Private Sub ReportBankWithdrawalSum_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query_head As String = "SELECT pns.`id_pn_summary`,pns.number,pns.`date_payment`,pns.`created_date`,emp.`employee_name`, cur.`id_currency`,cur.`currency`,SUM(pnd.`val_bef_kurs`) AS val_bef_kurs, pns.note
FROM tb_pn_summary pns
INNER JOIN tb_pn_summary_det pnsd ON pnsd.id_pn_summary=pns.id_pn_summary
INNER JOIN tb_pn_det pnd ON pnd.`id_pn`=pnsd.`id_pn` AND pnd.`id_currency`=pns.`id_currency`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pns.`id_currency`
INNER JOIN tb_m_user usr ON usr.`id_user`=pns.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_list_account_bank bnk ON bnk.id_list_account_bank=pns.id_list_account_bank
WHERE pns.`id_pn_summary`='" & id_sum & "'
GROUP BY pns.`id_pn_summary` "
        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
        DataSource = data_head

        'set footer detail
        'RowTotalAmount.Text = Decimal.Parse(data_head.Rows(0)("total").ToString).ToString("N2")

        'set invocie value info
        LTotal.Text = Decimal.Parse(data_head.Rows(0)("val_bef_kurs").ToString).ToString("N2")
        LTotSay.Text = "Say : " + ConvertCurrencyToIndonesian(data_head.Rows(0)("val_bef_kurs"))

        'detail
        Dim font_row_style As New Font("Segoe UI", 8, FontStyle.Regular)
        For i = 0 To dt.Rows.Count - 1
            'detail
            Dim query As String = ""
            If FormInvMatDet.is_deposit = "1" Then

            Else

            End If
            '
            Dim dt_det As DataTable = execute_query(query, -1, True, "", "", "", "")
            For j = 0 To dt_det.Rows.Count - 1
                Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
                row_det.HeightF = 15
                'no
                Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                no.Text = (j + 1).ToString + "."
                no.Borders = DevExpress.XtraPrinting.BorderSide.None
                no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                no.BackColor = Color.Transparent
                no.Font = font_row_style
                no.WidthF = 50

                row_det.Cells.Add(no)

                'barcode
                Dim code As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                code.Text = dt_det.Rows(j)("mat_det_code").ToString
                code.Borders = DevExpress.XtraPrinting.BorderSide.None
                code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                code.BackColor = Color.Transparent
                code.Font = font_row_style
                code.WidthF = 140

                row_det.Cells.Add(code)

                'descrition
                Dim descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                descrip.Text = dt_det.Rows(j)("mat_det_name").ToString
                descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
                descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                descrip.BackColor = Color.Transparent
                descrip.Font = font_row_style
                descrip.WidthF = 280

                row_det.Cells.Add(descrip)

                'qty
                Dim qty As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                qty.Text = Decimal.Parse(dt_det.Rows(j)("qty").ToString).ToString("N4")
                qty.Borders = DevExpress.XtraPrinting.BorderSide.None
                qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                qty.BackColor = Color.Transparent
                qty.Font = font_row_style
                qty.WidthF = 85

                row_det.Cells.Add(qty)

                'price
                Dim price As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                price.Text = Decimal.Parse(dt_det.Rows(j)("price").ToString).ToString("N2")
                price.Borders = DevExpress.XtraPrinting.BorderSide.None
                price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                price.BackColor = Color.Transparent
                price.Font = font_row_style
                price.WidthF = 100

                row_det.Cells.Add(price)

                'amount
                Dim amo As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                amo.Text = Decimal.Parse(dt_det.Rows(j)("amount").ToString).ToString("N2")
                amo.Borders = DevExpress.XtraPrinting.BorderSide.None
                amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                amo.BackColor = Color.Transparent
                amo.Font = font_row_style
                amo.WidthF = 117

                row_det.Cells.Add(amo)

                XTable.Rows.Add(row_det)
            Next
        Next
        'row total
        Dim row_total As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        row_total.HeightF = 15

        Dim blank_amo As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        blank_amo.Text = ""
        blank_amo.WidthF = 665
        blank_amo.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        blank_amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        blank_amo.BackColor = Color.Transparent
        blank_amo.Font = font_row_style

        row_total.Cells.Add(blank_amo)
        '
        Dim amo_tot As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        amo_tot.Text = Decimal.Parse(data_head.Rows(0)("total").ToString).ToString("N2")
        amo_tot.WidthF = 117
        amo_tot.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        amo_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo_tot.BackColor = Color.Transparent
        amo_tot.Font = font_row_style

        row_total.Cells.Add(amo_tot)
        XTable.Rows.Add(row_total)

        'If id_pre = "1" Then
        '    pre_load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        'Else
        '    load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        'End If
    End Sub
End Class