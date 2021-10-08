Public Class ReportPolisReg
    Public id_report As String = "-1"

    Private Sub ReportPolisReg_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim qorign As String = "SELECT regd.id_polis_reg_det,ppsd.old_end_date,pps.id_polis_pps,d.description,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
,c.id_comp,c.`comp_name`,c.`comp_number`,c.address_primary,recv.id_comp AS id_rekomendasi_vendor,recv.comp_name AS rekomendasi_vendor,regd.`rekomendasi_premi`,cv.id_comp AS id_vendor_dipilih,cv.comp_name AS vendor_dipilih,regd.`premi`,regd.`polis_number`
FROM 
`tb_polis_reg_det` regd
INNER JOIN `tb_polis_pps_det` ppsd ON ppsd.`id_polis_pps_det`=regd.id_polis_pps_det AND regd.`id_polis_reg`='" & id_report & "'
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
INNER JOIN `tb_lookup_desc_premi` d ON d.id_desc_premi=regd.`id_desc_premi`
INNER JOIN tb_m_comp recv ON recv.id_comp=regd.rekomendasi_vendor
LEFT JOIN tb_m_comp cv ON cv.id_comp=regd.vendor_dipilih"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        Dim total As Decimal = 0.00

        For i = 0 To dt_orign.Rows.Count - 1
            insert_row_bm(RowBM, dt_orign, i)
            total += dt_orign.Rows(i)("premi")
            If i = dt_orign.Rows.Count - 1 Then
                insert_row_bm_total(RowBM, total)
            End If
        Next
        pre_load_mark_horz("309", id_report, "2", "2", XrTable6)
    End Sub
    'store code, store, nilai pertanggungan, venodr rekomendasi, vendor dipilih, nomor polis, premi
    Sub insert_row_bm(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'store code
        Dim st_c As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        st_c.Text = dt.Rows(row_i)("comp_number").ToString
        st_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        st_c.Font = font_row_style

        'store
        Dim st As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        st.Text = dt.Rows(row_i)("comp_name").ToString
        st.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        st.Font = font_row_style

        'nilai pertanggungan
        Dim np As String = Decimal.Parse(dt.Rows(row_i)("nilai_total").ToString).ToString("N2")

        Dim npc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        npc.Text = np
        npc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        npc.Font = font_row_style

        'vendor dipilih
        Dim vr As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        vr.Text = dt.Rows(row_i)("vendor_dipilih").ToString
        vr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        vr.Font = font_row_style

        If dt.Rows(row_i)("id_rekomendasi_vendor").ToString = dt.Rows(row_i)("id_vendor_dipilih").ToString Then
            vr.BackColor = Color.LimeGreen
        Else
            vr.BackColor = Color.Transparent
        End If

        ''vendor rekomendasi
        'Dim vp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        'vp.Text = dt.Rows(row_i)("vendor_dipilih").ToString
        'vp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        'vp.Font = font_row_style

        'nomor_polis
        Dim nomorp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        nomorp.Text = dt.Rows(row_i)("polis_number").ToString
        nomorp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        nomorp.Font = font_row_style

        'premi
        Dim premi As String = Decimal.Parse(dt.Rows(row_i)("premi").ToString).ToString("N2")

        Dim premic As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        premic.Text = premi
        premic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        premic.Font = font_row_style
    End Sub

    Sub insert_row_bm_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        Dim rown As DevExpress.XtraReports.UI.XRTableRow = XTBM.InsertRowBelow(row)

        rown.HeightF = 20
        rown.Font = font_row_style

        'store code
        Dim st_c As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(0)
        st_c.Text = ""
        st_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        st_c.Font = font_row_style

        'store
        Dim st As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(1)
        st.Text = "Total"
        st.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        st.Font = font_row_style

        'nilai pertanggungan
        Dim npc As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(2)
        npc.Text = ""
        npc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        npc.Font = font_row_style

        'vendor dipilih
        Dim vr As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(3)
        vr.Text = ""
        vr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        vr.Font = font_row_style
        vr.BackColor = Color.Transparent

        ''vendor dipilih
        'Dim vp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        'vp.Text = ""
        'vp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        'vp.Font = font_row_style

        'nomor_polis
        Dim nomorp As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(4)
        nomorp.Text = ""
        nomorp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        nomorp.Font = font_row_style

        'premi
        Dim premi As String = Decimal.Parse(total.ToString).ToString("N2")

        Dim premic As DevExpress.XtraReports.UI.XRTableCell = rown.Cells.Item(5)
        premic.Text = premi
        premic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        premic.Font = font_row_style
    End Sub
End Class