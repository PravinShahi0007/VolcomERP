Public Class Report3PLInsurance
    Public id_odm_print As String = "-1"
    Public id_3pl As String = ""

    Private Sub Report3PLInsurance_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim q As String = "SELECT del.awbill_no,SUM(pld.`pl_sales_order_del_det_qty` * pld.design_price) AS total_harga
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print AND odmph.id_3pl='" & id_3pl & "' -- vendornya apa
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & id_odm_print & "'
INNER JOIN tb_odm_sc_det odmd ON odmd.id_odm_sc=odm.id_odm_sc
INNER JOIN `tb_del_manifest_det` deld ON deld.id_del_manifest=odmd.id_del_manifest
INNER JOIN `tb_del_manifest` del ON deld.id_del_manifest=del.id_del_manifest
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_wh_awb_det=deld.id_wh_awb_det
INNER JOIN `tb_pl_sales_order_del_det` pld ON pld.`id_pl_sales_order_del`=awbd.id_pl_sales_order_del
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=pld.`id_pl_sales_order_del`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_comp_group cg ON c.id_comp_group=cg.id_comp_group AND cg.is_marketplace=2
INNER JOIN tb_m_product p ON p.`id_product`=pld.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
LEFT JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
LEFT JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
GROUP BY del.awbill_no"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRDetail
        Dim tot_nilai As Decimal = 0.00
        For i = 0 To dt.Rows.Count - 1
            insert_row(row_baru, dt, i)
            'add summary
            tot_nilai += dt.Rows(i)("total_harga")
            If i = dt.Rows.Count - 1 Then
                insert_footer(row_baru, tot_nilai)
            End If
        Next
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Regular)

        If Not row_i = 0 Then
            row = XTDetail.InsertRowBelow(row)
        End If

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = row_i + 1
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'awb_no
        Dim awb_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        awb_no.Text = dt.Rows(row_i)("awbill_no").ToString
        awb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        awb_no.Font = font_row_style

        'total_nilai
        Dim harga As String = Decimal.Parse(dt.Rows(row_i)("total_harga").ToString).ToString("N2")

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = harga
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style
    End Sub

    Sub insert_footer(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size + 1, FontStyle.Bold)

        row = XTDetail.InsertRowBelow(row)

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 25
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = "Total"
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'awb_no
        Dim awb_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        awb_no.Text = ""
        awb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        awb_no.Font = font_row_style

        'total_nilai
        Dim harga As String = Decimal.Parse(Decimal.Parse(total.ToString).ToString("N2")).ToString("N2")

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = harga
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style
    End Sub
End Class