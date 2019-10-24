Public Class ReportProdClose
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        DataSource = dt_head
        '
        Dim po_height As Integer = 0

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(20, 20)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XRLeadTime.Controls.Add(tb_no)

            'column fgpo number
            Dim tb_fgpo_number As New DevExpress.XtraReports.UI.XRLabel

            tb_fgpo_number.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_fgpo_number.SizeF = New Size(50, 20)
            tb_fgpo_number.LocationF = New Point(20, po_height)
            tb_fgpo_number.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_fgpo_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_fgpo_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_fgpo_number)

            'column vendor
            Dim tb_vendor As New DevExpress.XtraReports.UI.XRLabel

            tb_vendor.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_vendor.SizeF = New Size(150, 20)
            tb_vendor.LocationF = New Point(70, po_height)
            tb_vendor.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_vendor)

            'column design
            Dim tb_design As New DevExpress.XtraReports.UI.XRLabel

            tb_design.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_design.SizeF = New Size(150, 20)
            tb_design.LocationF = New Point(220, po_height)
            tb_design.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_design.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_design)

            'column order qty
            Dim tb_order_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_order_qty.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_order_qty.SizeF = New Size(50, 20)
            tb_order_qty.LocationF = New Point(370, po_height)
            tb_order_qty.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_order_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_order_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_order_qty)

            'column rec qty
            Dim tb_rec_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_rec_qty.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_rec_qty.SizeF = New Size(50, 20)
            tb_rec_qty.LocationF = New Point(420, po_height)
            tb_rec_qty.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_rec_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_rec_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_rec_qty)

            'column unit price
            Dim tb_unit_price As New DevExpress.XtraReports.UI.XRLabel

            tb_unit_price.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_unit_price.SizeF = New Size(100, 20)
            tb_unit_price.LocationF = New Point(470, po_height)
            tb_unit_price.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_unit_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_unit_price.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_unit_price)

            'column qc normal
            Dim tb_qc_normal As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_normal.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_qc_normal.SizeF = New Size(50, 20)
            tb_qc_normal.LocationF = New Point(570, po_height)
            tb_qc_normal.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_qc_normal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_normal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_unit_price)

            'column qc reject minor
            Dim tb_qc_reject_minor As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_minor.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_qc_reject_minor.SizeF = New Size(50, 20)
            tb_qc_reject_minor.LocationF = New Point(620, po_height)
            tb_qc_reject_minor.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_qc_reject_minor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_minor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_qc_reject_minor)

            'column qc reject major
            Dim tb_qc_reject_major As New DevExpress.XtraReports.UI.XRLabel

            tb_qc_reject_major.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_qc_reject_major.SizeF = New Size(50, 20)
            tb_qc_reject_major.LocationF = New Point(670, po_height)
            tb_qc_reject_major.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_qc_reject_major.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qc_reject_major.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_qc_reject_major)

            'column amount claim reject
            Dim tb_amo_claim_reject As New DevExpress.XtraReports.UI.XRLabel

            tb_amo_claim_reject.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_amo_claim_reject.SizeF = New Size(120, 20)
            tb_amo_claim_reject.LocationF = New Point(720, po_height)
            tb_amo_claim_reject.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_amo_claim_reject.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amo_claim_reject.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_amo_claim_reject)

            'column amount claim late
            Dim tb_amo_claim_late As New DevExpress.XtraReports.UI.XRLabel

            tb_amo_claim_late.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_amo_claim_late.SizeF = New Size(120, 20)
            tb_amo_claim_late.LocationF = New Point(840, po_height)
            tb_amo_claim_late.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_amo_claim_late.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amo_claim_late.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_amo_claim_late)

            'column total claim
            Dim tb_tot_claim As New DevExpress.XtraReports.UI.XRLabel

            tb_tot_claim.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_tot_claim.SizeF = New Size(120, 20)
            tb_tot_claim.LocationF = New Point(960, po_height)
            tb_tot_claim.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_tot_claim.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_tot_claim.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Me.XRLeadTime.Controls.Add(tb_tot_claim)

            po_height = po_height + 20
        Next
    End Sub
End Class