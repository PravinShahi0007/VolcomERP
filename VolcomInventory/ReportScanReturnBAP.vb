Public Class ReportScanReturnBAP
    Public data_det As DataTable
    Public id_bap As String = "-1"
    Private Sub ReportScanReturnBAP_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        XRHeader.Html = "Pada hari ini [day_s], tanggal [date_s], bulan [month_s], tahun [year_s], kami yang bertandatangan di bawah ini, telah melakukan serah terima kiriman produk sesuai prosedur yang berlaku pada <br /><b>PT. Volcom Indonesia</b>. Dari hasil serah terima produk tersebut, dapat kami sampaikan sebagai berikut:"
        XRpoint2.Html = "Fisik produk <b>TIDAK SESUAI</b>  dengan Dokumen terkait yang terdapat di dalam paket / box.<br/>Adapun produk yang tidak sesuai adalah sebagai berikut :"

        '
        Dim q As String = "SET @@lc_time_names = 'id_ID';SELECT bap_number,DAYNAME(bap_date) AS day_s,DATE_FORMAT(bap_date,'%d') AS date_s,DATE_FORMAT(bap_date,'%M') AS month_s,DATE_FORMAT(bap_date,'%Y') AS year_s,IF(`is_lubang`=1,'V','') AS is_lubang,IF(`is_seal_rusak`=1,'V','') AS `is_seal_rusak`,IF(`is_basah`=1,'V','') AS `is_basah`,IF(`is_other_cond`=1,'V','') AS `is_other_cond`,`other_cond`
FROM `tb_scan_return_bap`
WHERE `id_scan_return_bap` = '" & id_bap & "'"
        DataSource = execute_query(q, -1, True, "", "", "", "")
        '

        Dim id_current As String = ""

        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        row.Font = New Font("Times New Roman", 7, FontStyle.Regular)

        For i = 0 To data_det.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTDetail.InsertRowBelow(XTTop)
                row.HeightF = 16
            Else
                row = XTDetail.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = i + 1.ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            no.BackColor = Color.Transparent

            'return Note number
            Dim departement As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            departement.Text = data_det.Rows(i)("number_return_note").ToString
            departement.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            departement.BackColor = Color.Transparent

            'list store
            Dim list_store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            If Not id_current = data_det.Rows(i)("number_return_note").ToString Then
                id_current = data_det.Rows(i)("number_return_note").ToString
            Else
                list_store.RowSpan = list_store.RowSpan + 1
            End If

            list_store.WordWrap = True
            list_store.Multiline = True
            list_store.Text = data_det.Rows(i)("store_list").ToString
            list_store.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            list_store.BackColor = Color.Transparent

            'kode barang
            Dim kode_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            kode_barang.Text = data_det.Rows(i)("code").ToString
            kode_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            kode_barang.BackColor = Color.Transparent

            'deskripsi barang
            Dim desc_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            desc_barang.Text = data_det.Rows(i)("description").ToString
            desc_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            desc_barang.BackColor = Color.Transparent

            'Size barang
            Dim size_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            size_barang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size_barang.Text = data_det.Rows(i)("size").ToString
            size_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            size_barang.BackColor = Color.Transparent

            'Qty barang
            Dim qty_barang As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            qty_barang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_barang.Text = Decimal.Parse(data_det.Rows(i)("qty").ToString).ToString("N0")
            qty_barang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            qty_barang.BackColor = Color.Transparent

            'Notes 
            Dim notes As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            notes.WordWrap = True
            notes.Multiline = True
            notes.Text = data_det.Rows(i)("note").ToString
            notes.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            notes.BackColor = Color.Transparent
        Next
    End Sub
End Class