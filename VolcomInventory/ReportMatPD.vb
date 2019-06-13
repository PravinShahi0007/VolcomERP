Public Class ReportMatPD
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable
    '
    Public id_purc As String = "-1"

    Private Sub ReportMatPD_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt_head

        Dim po_height As Integer = 0

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(30, 20)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_no)
            'column class
            Dim tb_class As New DevExpress.XtraReports.UI.XRLabel

            tb_class.Text = dt_det.Rows(i)("class").ToString
            tb_class.SizeF = New Size(50, 20)
            tb_class.LocationF = New Point(30, po_height)
            tb_class.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_class.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_class.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_class)
            'column design name
            Dim tb_design As New DevExpress.XtraReports.UI.XRLabel

            tb_design.Text = dt_det.Rows(i)("design_name").ToString
            tb_design.SizeF = New Size(250, 20)
            tb_design.LocationF = New Point(80, po_height)
            tb_design.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_design.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_design.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_design)
            'column color
            Dim tb_color As New DevExpress.XtraReports.UI.XRLabel

            tb_color.Text = dt_det.Rows(i)("color").ToString
            tb_color.SizeF = New Size(40, 20)
            tb_color.LocationF = New Point(330, po_height)
            tb_color.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_color.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_color)
            'column qty pd
            Dim tb_qty_pd As New DevExpress.XtraReports.UI.XRLabel

            tb_qty_pd.Text = dt_det.Rows(i)("qty_pd").ToString
            tb_qty_pd.SizeF = New Size(55, 20)
            tb_qty_pd.LocationF = New Point(370, po_height)
            tb_qty_pd.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_qty_pd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_qty_pd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty_pd.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_qty_pd)
            'column consumption
            Dim tb_cons As New DevExpress.XtraReports.UI.XRLabel

            tb_cons.Text = dt_det.Rows(i)("consumption").ToString
            tb_cons.SizeF = New Size(70, 20)
            tb_cons.LocationF = New Point(425, po_height)
            tb_cons.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_cons.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_cons.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_cons.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_cons)
            'column qty order
            Dim tb_qty_order As New DevExpress.XtraReports.UI.XRLabel

            tb_qty_order.Text = dt_det.Rows(i)("qty_order").ToString
            tb_qty_order.SizeF = New Size(229, 20)
            tb_qty_order.LocationF = New Point(495, po_height)
            tb_qty_order.Font = New Font("Calibri", 10, FontStyle.Bold)
            tb_qty_order.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_qty_order.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty_order.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_qty_order)
            po_height = po_height + 20
        Next

        pre_load_mark_horz("197", id_purc, "1", "2", XrTable1)
    End Sub
End Class