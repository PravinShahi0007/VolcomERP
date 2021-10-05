Public Class ReportPreCalStorage
    Public id_report As String = "-1"

    Private Sub ReportPreCalStorage_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim qorign As String = "SELECT 11 AS id_pre_cal_temp,st.`storage_item` AS `desc`, (IF(st.`is_use_cbm`=1,IF(st.`min_cbm`>cal.`cbm`,st.`min_cbm`,CEIL(cal.`cbm`)),1)*st.price) AS unit_price_in_rp
,(IF(st.`is_use_cbm`=1,IF(st.`min_cbm`>cal.`cbm`,st.`min_cbm`,CEIL(cal.`cbm`)),1)) AS qty
,st.`price`
FROM `tb_pre_cal_storage` st
INNER JOIN `tb_pre_cal_fgpo` cal ON st.`is_active`='1'  
AND  cal.`id_pre_cal_fgpo`='" & id_report & "'"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        Dim total As Decimal = 0.00

        For i = 0 To dt_orign.Rows.Count - 1
            insert_row_bm(RowBM, dt_orign, i)
            total += dt_orign.Rows(i)("unit_price_in_rp")
            If i = dt_orign.Rows.Count - 1 Then
                insert_row_bm_total(RowBM, total)
            End If
        Next
    End Sub

    Sub insert_row_bm(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'desc

        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = dt.Rows(row_i)("desc").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        desc.Font = font_row_style

        'qty
        Dim qty As String = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N2") & 

        Dim qty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        qty_col.Text = qty
        qty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        qty_col.Font = font_row_style

        'price
        Dim price As String = Decimal.Parse(dt.Rows(row_i)("price").ToString).ToString("N2") & 

        Dim price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        price_col.Text = price
        price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_col.Font = font_row_style

        'tot_price
        Dim tot_price As String = Decimal.Parse(dt.Rows(row_i)("unit_price_in_rp").ToString).ToString("N2")

        Dim tot_price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        tot_price_col.Text = tot_price
        tot_price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_price_col.Font = font_row_style
    End Sub

    Sub insert_row_bm_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'desc

        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = "Total"
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        desc.Font = font_row_style

        'qty
        Dim qty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        qty_col.Text = ""
        qty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_col.Font = font_row_style

        'price
        Dim price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        price_col.Text = ""
        price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_col.Font = font_row_style

        'tot_price
        Dim tot_price As String = Decimal.Parse(total.ToString).ToString("N2")

        Dim tot_price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        tot_price_col.Text = tot_price
        tot_price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_price_col.Font = font_row_style
    End Sub
End Class