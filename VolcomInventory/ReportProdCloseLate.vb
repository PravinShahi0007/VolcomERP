Public Class ReportProdCloseLate
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable

    Public id_pre As String = "-1"
    Public id_report As String = "-1"

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        '
        Dim po_height As Integer = 0

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(20, 80)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_no)

            'column vendor
            Dim tb_vendor As New DevExpress.XtraReports.UI.XRLabel

            tb_vendor.Text = dt_det.Rows(i)("comp_name").ToString
            tb_vendor.SizeF = New Size(130, 80)
            tb_vendor.LocationF = New Point(20, po_height)
            tb_vendor.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_vendor.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_vendor)

            'column design
            Dim tb_design As New DevExpress.XtraReports.UI.XRLabel

            tb_design.Text = dt_det.Rows(i)("prod_order_number").ToString & vbNewLine & dt_det.Rows(i)("design_display_name").ToString
            tb_design.SizeF = New Size(130, 80)
            tb_design.LocationF = New Point(150, po_height)
            tb_design.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_design.Multiline = True
            tb_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_design.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_design.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_design)

            'column order qty
            Dim tb_order_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_order_qty.Text = Decimal.Parse(dt_det.Rows(i)("po_qty").ToString).ToString("N0")
            tb_order_qty.SizeF = New Size(70, 80)
            tb_order_qty.LocationF = New Point(280, po_height)
            tb_order_qty.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_order_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_order_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_order_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_order_qty)

            'column rec qty
            Dim tb_rec_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_rec_qty.Text = Decimal.Parse(dt_det.Rows(i)("rec_qty").ToString).ToString("N0")
            tb_rec_qty.SizeF = New Size(70, 80)
            tb_rec_qty.LocationF = New Point(350, po_height)
            tb_rec_qty.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_rec_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_rec_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_rec_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_rec_qty)

            'column price per pcs
            Dim tb_prc_pcs As New DevExpress.XtraReports.UI.XRLabel

            tb_prc_pcs.Text = Decimal.Parse(dt_det.Rows(i)("prod_order_wo_det_price").ToString).ToString("N2")
            tb_prc_pcs.SizeF = New Size(100, 80)
            tb_prc_pcs.LocationF = New Point(420, po_height)
            tb_prc_pcs.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_prc_pcs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_prc_pcs.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_prc_pcs.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_prc_pcs)

            'column deskripsi
            Dim tb_deskripsi As New DevExpress.XtraReports.UI.XRLabel

            tb_deskripsi.Text = "Hasil produksi datang terlambat" & vbNewLine & "Delivery date PO : " & vbNewLine & "Delivery date KO : " & vbNewLine & "Received Date : " & vbNewLine & "Charge Back : "
            tb_deskripsi.SizeF = New Size(140, 80)
            tb_deskripsi.LocationF = New Point(520, po_height)
            tb_deskripsi.Font = New Font("Times New Roman", 7, FontStyle.Regular)
            tb_deskripsi.Multiline = True
            tb_deskripsi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_deskripsi.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_deskripsi.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_deskripsi)

            'column deskripsi detail
            Dim tb_deskripsi_det As New DevExpress.XtraReports.UI.XRLabel

            tb_deskripsi_det.Text = " " & vbNewLine & Date.Parse(dt_det.Rows(i)("est_rec_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & Date.Parse(dt_det.Rows(i)("est_rec_date_ko").ToString).ToString("dd MMMM yyyy") & vbNewLine & Date.Parse(dt_det.Rows(i)("arrive_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & dt_det.Rows(i)("late_day").ToString & " hari kalender (" & Decimal.Parse(dt_det.Rows(i)("claim_percent").ToString).ToString("N0") & "%)"
            tb_deskripsi_det.SizeF = New Size(120, 80)
            tb_deskripsi_det.LocationF = New Point(660, po_height)
            tb_deskripsi_det.Font = New Font("Times New Roman", 7, FontStyle.Regular)
            tb_deskripsi_det.Multiline = True
            tb_deskripsi_det.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_deskripsi_det.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            Me.XRDetail.Controls.Add(tb_deskripsi_det)

            'column qty rec trx
            Dim tb_qty_rec_trx As New DevExpress.XtraReports.UI.XRLabel

            tb_qty_rec_trx.Text = Decimal.Parse(dt_det.Rows(i)("rec_qty_trx").ToString).ToString("N0")
            tb_qty_rec_trx.SizeF = New Size(60, 80)
            tb_qty_rec_trx.LocationF = New Point(780, po_height)
            tb_qty_rec_trx.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qty_rec_trx.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qty_rec_trx.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty_rec_trx.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_qty_rec_trx)

            'column claim per pcs
            Dim tb_qc_reject_afkir As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_afkir.Text = Decimal.Parse(dt_det.Rows(i)("claim_pc").ToString).ToString("N2")
            tb_qc_reject_afkir.SizeF = New Size(60, 80)
            tb_qc_reject_afkir.LocationF = New Point(840, po_height)
            tb_qc_reject_afkir.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qc_reject_afkir.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_afkir.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qc_reject_afkir.Borders = DevExpress.XtraPrinting.BorderSide.Left
            Me.XRDetail.Controls.Add(tb_qc_reject_afkir)

            'column amount claim reject
            Dim tb_amo_claim_reject As New DevExpress.XtraReports.UI.XRLabel

            tb_amo_claim_reject.Text = Decimal.Parse(dt_det.Rows(i)("claim_amo").ToString).ToString("N2")
            tb_amo_claim_reject.SizeF = New Size(150, 80)
            tb_amo_claim_reject.LocationF = New Point(900, po_height)
            tb_amo_claim_reject.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_amo_claim_reject.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amo_claim_reject.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_amo_claim_reject.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            Me.XRDetail.Controls.Add(tb_amo_claim_reject)

            po_height = po_height + 80
        Next
        '
        If id_pre = "-1" Then
            load_mark_horz("212", id_report, "2", "1", XrTable3)
        Else
            pre_load_mark_horz("212", id_report, "2", "2", XrTable3)
        End If
    End Sub
End Class