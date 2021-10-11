Public Class ReportPolis
    Public dt As DataTable
    Public dt_kolektif As DataTable
    Public id_pps As String = "-1"
    Private Sub ReportPolis_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'add column
        Dim font_rowhead_style As New Font(XTPolisPPS.Font.FontFamily, XTPolisPPS.Font.Size, FontStyle.Bold)

        Dim j As Integer = 13
        For i = 0 To dt.Columns.Count - 1
            If dt.Columns(i).ColumnName.ToString.Contains("vendor_") Then
                XTPolisPPS.InsertColumnToRight(Nothing, True)

                Dim cell_a As DevExpress.XtraReports.UI.XRTableCell = XRRowHead.Cells(j)
                cell_a.Font = font_rowhead_style
                cell_a.Text = get_company_x(dt.Columns(i).ColumnName.ToString.Split("_")(1), "1")
                cell_a.Padding = XTPolisPPS.Padding
                cell_a.TextAlignment = XTPolisPPS.TextAlignment

                j += 1
            End If
        Next

        'add column dipilih
        'XTPolisPPS.InsertColumnToRight(Nothing, True)

        'Dim cell_pilih As DevExpress.XtraReports.UI.XRTableCell = XRRowHead.Cells(j)
        'cell_pilih.Font = font_rowhead_style
        'cell_pilih.Text = "Vendor yang dipilih"
        'cell_pilih.Padding = XTPolisPPS.Padding
        'cell_pilih.TextAlignment = XTPolisPPS.TextAlignment

        'detail
        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRRowHead
        For i = 0 To dt.Rows.Count - 1
            insert_row(row_baru, dt, i)
        Next

        If SubBandKolektif.Visible = True Then
            'kolektif
            Dim row_baru_kolektif As DevExpress.XtraReports.UI.XRTableRow = RowKolektif
            For i = 0 To dt_kolektif.Rows.Count - 1
                insert_row_kolektif(row_baru_kolektif, dt_kolektif, i)
            Next
        End If
        '
        pre_load_mark_horz("307", id_pps, "2", "2", XRTableMark)
    End Sub
    '
    Sub insert_row_kolektif(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTPolisPPS.Font.FontFamily, XTPolisPPS.Font.Size - 1, FontStyle.Regular)

        row = XTKolektif.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = row_i + 1
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'nama vendor
        Dim nama_vendor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        nama_vendor.Text = dt.Rows(row_i)("comp_name").ToString
        nama_vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        nama_vendor.Font = font_row_style

        'penawaran
        Dim penawaran As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        penawaran.Text = Decimal.Parse(dt.Rows(row_i)("price").ToString).ToString("N2")
        penawaran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        penawaran.Font = font_row_style
    End Sub
    '
    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTPolisPPS.Font.FontFamily, XTPolisPPS.Font.Size - 1, FontStyle.Regular)

        row = XTPolisPPS.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = row_i + 1
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'kode toko
        Dim kode As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        kode.Text = dt.Rows(row_i)("comp_number").ToString
        kode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        kode.Font = font_row_style

        'nama toko
        Dim nama_toko As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        nama_toko.Text = dt.Rows(row_i)("comp_name").ToString
        nama_toko.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        nama_toko.Font = font_row_style

        'jatuh tempo
        Dim jatuh_tempo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        Try

        Catch ex As Exception

        End Try
        jatuh_tempo.Text = Date.Parse(dt.Rows(row_i)("old_end_date").ToString).ToString("dd MMMM yyyy")
        jatuh_tempo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        jatuh_tempo.Font = font_row_style

        'nilai stock this year
        Dim nilai_stock As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        nilai_stock.Text = Decimal.Parse(dt.Rows(row_i)("nilai_stock").ToString).ToString("N2")
        nilai_stock.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_stock.Font = font_row_style

        'fit out
        Dim nilai_fit_out As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        nilai_fit_out.Text = Decimal.Parse(dt.Rows(row_i)("nilai_fit_out").ToString).ToString("N2")
        nilai_fit_out.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_fit_out.Font = font_row_style

        'peralatan
        Dim nilai_peralatan As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        nilai_peralatan.Text = Decimal.Parse(dt.Rows(row_i)("nilai_peralatan").ToString).ToString("N2")
        nilai_peralatan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_peralatan.Font = font_row_style

        'building
        Dim nilai_building As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        nilai_building.Text = Decimal.Parse(dt.Rows(row_i)("nilai_building").ToString).ToString("N2")
        nilai_building.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_building.Font = font_row_style

        'public liability
        Dim nilai_public_liability As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        nilai_public_liability.Text = Decimal.Parse(dt.Rows(row_i)("nilai_public_liability").ToString).ToString("N2")
        nilai_public_liability.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_public_liability.Font = font_row_style

        'total
        Dim nilai_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        nilai_total.Text = Decimal.Parse(dt.Rows(row_i)("nilai_total").ToString).ToString("N2")
        nilai_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        nilai_total.Font = font_row_style

        'nilai stok tahun lalu
        Dim old_nilai_total As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        old_nilai_total.Text = Decimal.Parse(dt.Rows(row_i)("old_nilai_total").ToString).ToString("N2")
        old_nilai_total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        old_nilai_total.Font = font_row_style

        'vendor tahun lalu
        Dim old_vendor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)
        old_vendor.Text = dt.Rows(row_i)("old_vendor").ToString
        old_vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        old_vendor.Font = font_row_style

        'harga tahun lalu
        Dim old_premi As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)
        old_premi.Text = Decimal.Parse(dt.Rows(row_i)("old_premi").ToString).ToString("N2")
        old_premi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        old_premi.Font = font_row_style

        Dim j As Integer = 13
        For i = 0 To dt.Columns.Count - 1
            If dt.Columns(i).ColumnName.ToString.Contains("vendor_") Then
                'harga per vendor
                Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(j)
                price.Text = Decimal.Parse(dt.Rows(row_i)(dt.Columns(i).ColumnName.ToString).ToString).ToString("N2")
                price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                price.Font = font_row_style

                If dt.Columns(i).ColumnName.ToString.Substring(7).ToString = dt.Rows(row_i)("polis_vendor").ToString Then
                    price.BackColor = Color.LimeGreen
                Else
                    price.BackColor = Color.Transparent
                End If

                j += 1
            End If
        Next

        'polis_vendor
        'vendor dipilih
        'Dim vendor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(j)
        'vendor.Text = dt.Rows(row_i)("vendor").ToString
        'vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'vendor.Font = font_row_style
    End Sub
End Class