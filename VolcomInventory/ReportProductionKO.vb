﻿Public Class ReportProductionKO
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable

    Public Shared is_po_mat As String = "2"
    Private Sub ReportProductionKO_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt_head
        '
        Dim po_height As Integer = 0
        Dim row_po_height As Integer = 20

        Dim f As Font = New Font("Calibri", 11, FontStyle.Bold)

        If is_po_mat = "1" Then
            row_po_height = 40
            f = New Font("Calibri", 9, FontStyle.Bold)
        End If

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(34, row_po_height)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = f
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_no.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_no)
            'column po no
            Dim tb_po_no As New DevExpress.XtraReports.UI.XRLabel

            tb_po_no.Text = dt_det.Rows(i)("prod_order_number").ToString
            tb_po_no.SizeF = New Size(81, row_po_height)
            tb_po_no.LocationF = New Point(34, po_height)
            tb_po_no.Font = f
            tb_po_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_po_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_po_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_po_no.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_po_no)
            'column description
            Dim tb_desc As New DevExpress.XtraReports.UI.XRLabel

            tb_desc.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_desc.SizeF = New Size(187.5, row_po_height)
            tb_desc.LocationF = New Point(115, po_height)
            tb_desc.Font = f
            tb_desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_desc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_desc.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_desc.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_desc)
            'column color
            Dim tb_color As New DevExpress.XtraReports.UI.XRLabel

            tb_color.Text = dt_det.Rows(i)("color").ToString
            tb_color.SizeF = New Size(52, row_po_height)
            tb_color.LocationF = New Point(302.5, po_height)
            tb_color.Font = f
            tb_color.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_color.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_color)
            'column qty order
            Dim tb_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_qty.Text = Decimal.Parse(dt_det.Rows(i)("qty_order").ToString).ToString("N0")
            tb_qty.SizeF = New Size(64.5, row_po_height)
            tb_qty.LocationF = New Point(354.5, po_height)
            tb_qty.Font = f
            tb_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_qty.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_qty)
            'column unit price
            Dim tb_unit_price As New DevExpress.XtraReports.UI.XRLabel

            tb_unit_price.Text = Decimal.Parse(dt_det.Rows(i)("bom_unit").ToString).ToString("N2")
            tb_unit_price.SizeF = New Size(100, row_po_height)
            tb_unit_price.LocationF = New Point(419, po_height)
            tb_unit_price.Font = f
            tb_unit_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_unit_price.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_unit_price.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tb_unit_price.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_unit_price)
            'column amount rp
            Dim tb_amount As New DevExpress.XtraReports.UI.XRLabel

            tb_amount.Text = Decimal.Parse(dt_det.Rows(i)("po_amount_rp").ToString).ToString("N2")
            tb_amount.SizeF = New Size(170, row_po_height)
            tb_amount.LocationF = New Point(519, po_height)
            tb_amount.Font = f
            tb_amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_amount.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
            tb_amount.KeepTogether = True

            Me.XPTableAmount.Controls.Add(tb_amount)

            '================ LEAD TIME ===============================================================
            'column desc ltime
            Dim tb_desc_ltime As New DevExpress.XtraReports.UI.XRLabel

            tb_desc_ltime.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_desc_ltime.SizeF = New Size(200, row_po_height)
            tb_desc_ltime.LocationF = New Point(0, po_height)
            tb_desc_ltime.Font = f
            tb_desc_ltime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_desc_ltime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_desc_ltime.KeepTogether = True

            Me.XRLeadTime.Controls.Add(tb_desc_ltime)
            'column color ltime
            Dim tb_color_ltime As New DevExpress.XtraReports.UI.XRLabel

            tb_color_ltime.Text = "(" & dt_det.Rows(i)("color").ToString & ")"
            tb_color_ltime.SizeF = New Size(52, row_po_height)
            tb_color_ltime.LocationF = New Point(200, po_height)
            tb_color_ltime.Font = f
            tb_color_ltime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color_ltime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color_ltime.KeepTogether = True

            Me.XRLeadTime.Controls.Add(tb_color_ltime)

            'column lead time ltime 
            Dim tb_leadtime As New DevExpress.XtraReports.UI.XRLabel

            tb_leadtime.Text = " : " & Date.Parse(dt_det.Rows(i)("esti_del_date").ToString).ToString("dd MMMM yyyy")
            tb_leadtime.SizeF = New Size(150, row_po_height)
            tb_leadtime.LocationF = New Point(252, po_height)
            tb_leadtime.Font = f
            tb_leadtime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_leadtime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_leadtime.KeepTogether = True

            Me.XRLeadTime.Controls.Add(tb_leadtime)

            'column Revision (If Any) 
            Dim tb_revision As New DevExpress.XtraReports.UI.XRLabel

            If Not dt_det.Rows(i)("revision_times").ToString = "0" Then
                'tb_revision.Text = " (Revisi " & dt_det.Rows(i)("revision").ToString.PadLeft(2, "0") & ") "
                tb_revision.Text = " (Revisi " & dt_det.Rows(i)("revision_times").ToString & ") "
            End If

            tb_revision.SizeF = New Size(100, row_po_height)
            tb_revision.LocationF = New Point(402, po_height)
            tb_revision.Font = f
            tb_revision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_revision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_revision.KeepTogether = True

            Me.XRLeadTime.Controls.Add(tb_revision)
            '
            po_height = po_height + row_po_height
        Next
    End Sub
End Class