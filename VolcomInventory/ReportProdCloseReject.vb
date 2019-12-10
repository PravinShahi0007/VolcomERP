Public Class ReportProdCloseReject
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
            tb_no.SizeF = New Size(20, 40)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_no)

            'column fgpo number
            Dim tb_fgpo_number As New DevExpress.XtraReports.UI.XRLabel

            tb_fgpo_number.Text = dt_det.Rows(i)("prod_order_number").ToString
            tb_fgpo_number.SizeF = New Size(60, 40)
            tb_fgpo_number.LocationF = New Point(20, po_height)
            tb_fgpo_number.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_fgpo_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_fgpo_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_fgpo_number.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_fgpo_number)

            'column vendor
            Dim tb_vendor As New DevExpress.XtraReports.UI.XRLabel

            tb_vendor.Text = dt_det.Rows(i)("comp_name").ToString
            tb_vendor.SizeF = New Size(140, 40)
            tb_vendor.LocationF = New Point(80, po_height)
            tb_vendor.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_vendor.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_vendor)

            'column design
            Dim tb_design As New DevExpress.XtraReports.UI.XRLabel

            tb_design.Text = dt_det.Rows(i)("design_display_name").ToString
            tb_design.SizeF = New Size(150, 40)
            tb_design.LocationF = New Point(220, po_height)
            tb_design.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_design.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_design.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_design)

            'column order qty
            Dim tb_order_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_order_qty.Text = Decimal.Parse(dt_det.Rows(i)("qty_order").ToString).ToString("N0")
            tb_order_qty.SizeF = New Size(70, 40)
            tb_order_qty.LocationF = New Point(370, po_height)
            tb_order_qty.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_order_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_order_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_order_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_order_qty)

            'column rec qty
            Dim tb_rec_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_rec_qty.Text = Decimal.Parse(dt_det.Rows(i)("qty_rec").ToString).ToString("N0")
            tb_rec_qty.SizeF = New Size(70, 40)
            tb_rec_qty.LocationF = New Point(440, po_height)
            tb_rec_qty.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_rec_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_rec_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_rec_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_rec_qty)

            'column unit price
            Dim tb_unit_price As New DevExpress.XtraReports.UI.XRLabel

            tb_unit_price.Text = Decimal.Parse(dt_det.Rows(i)("unit_price").ToString).ToString("N2")
            tb_unit_price.SizeF = New Size(100, 40)
            tb_unit_price.LocationF = New Point(510, po_height)
            tb_unit_price.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_unit_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_unit_price.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_unit_price.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_unit_price)

            'column qc normal
            Dim tb_qc_normal As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_normal.Text = Decimal.Parse(dt_det.Rows(i)("qc_normal").ToString).ToString("N0")
            tb_qc_normal.SizeF = New Size(70, 40)
            tb_qc_normal.LocationF = New Point(610, po_height)
            tb_qc_normal.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qc_normal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_normal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qc_normal.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_qc_normal)

            'column qc reject minor
            Dim tb_qc_reject_minor As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_minor.Text = "Claim : " & Decimal.Parse(dt_det.Rows(i)("p_minor").ToString).ToString("N0") & " %" & vbNewLine & "Qty : " & Decimal.Parse((dt_det.Rows(i)("qc_normal_minor") + dt_det.Rows(i)("qc_minor").ToString).ToString).ToString("N0")
            tb_qc_reject_minor.SizeF = New Size(70, 40)
            tb_qc_reject_minor.LocationF = New Point(680, po_height)
            tb_qc_reject_minor.Multiline = True
            tb_qc_reject_minor.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qc_reject_minor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_minor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qc_reject_minor.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_qc_reject_minor)

            'column qc reject major
            Dim tb_qc_reject_major As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_major.Text = "Claim : " & Decimal.Parse(dt_det.Rows(i)("p_major").ToString).ToString("N0") & " %" & vbNewLine & "Qty : " & Decimal.Parse((dt_det.Rows(i)("qc_minor_major") + dt_det.Rows(i)("qc_major").ToString).ToString).ToString("N0")
            tb_qc_reject_major.SizeF = New Size(70, 40)
            tb_qc_reject_major.LocationF = New Point(750, po_height)
            tb_qc_reject_major.Multiline = True
            tb_qc_reject_major.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qc_reject_major.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_major.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qc_reject_major.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_qc_reject_major)

            'column qc reject afkir
            Dim tb_qc_reject_afkir As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_afkir.Text = "Claim : " & Decimal.Parse(dt_det.Rows(i)("p_afkir").ToString).ToString("N0") & " %" & vbNewLine & "Qty : " & Decimal.Parse(dt_det.Rows(i)("qc_afkir").ToString).ToString("N0")
            tb_qc_reject_afkir.SizeF = New Size(70, 40)
            tb_qc_reject_afkir.LocationF = New Point(820, po_height)
            tb_qc_reject_afkir.Multiline = True
            tb_qc_reject_afkir.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_qc_reject_afkir.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_afkir.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qc_reject_afkir.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_qc_reject_afkir)

            'column amount claim reject
            Dim tb_amo_claim_reject As New DevExpress.XtraReports.UI.XRLabel

            tb_amo_claim_reject.Text = Decimal.Parse((dt_det.Rows(i)("amo_claim_minor") + dt_det.Rows(i)("amo_claim_major") + dt_det.Rows(i)("amo_claim_afkir")).ToString).ToString("N2")
            tb_amo_claim_reject.SizeF = New Size(160, 40)
            tb_amo_claim_reject.LocationF = New Point(890, po_height)
            tb_amo_claim_reject.Font = New Font("Times New Roman", 8, FontStyle.Regular)
            tb_amo_claim_reject.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amo_claim_reject.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_amo_claim_reject.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_amo_claim_reject)

            po_height = po_height + 40
        Next

        '
        If id_pre = "-1" Then
            load_mark_horz("212", id_report, "2", "1", XrTable3)
        Else
            pre_load_mark_horz("212", id_report, "2", "2", XrTable3)
        End If
    End Sub
End Class