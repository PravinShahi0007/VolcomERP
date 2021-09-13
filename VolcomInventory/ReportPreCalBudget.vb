Public Class ReportPreCalBudget
    Public Shared id_report As String = "-1"

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Regular)

        'If Not row_i = 0 Then
        '    row = XTDetail.InsertRowBelow(row)
        'End If

        row = XTDetail.InsertRowBelow(row)


        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style
        row.Visible = True

        '-------------------- vendor 1 ------------------------------------------
        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = dt.Rows(row_i)("desc").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'desc
        Dim curr As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        curr.Text = dt.Rows(row_i)("curr").ToString
        curr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        curr.Font = font_row_style

        'value
        Dim harga As String = Decimal.Parse(dt.Rows(row_i)("unit_price_in_rp").ToString).ToString("N2")

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = harga
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim qty As String = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N2")

        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_qty.Text = qty
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount As String = Decimal.Parse(dt.Rows(row_i)("total_in_rp").ToString).ToString("N2")

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        sub_amount_col.Text = sub_amount
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style

        '-------------------- vendor 2 ------------------------------------------
        'desc
        Dim descc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        descc.Text = dt.Rows(row_i)("descc").ToString
        descc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        descc.Font = font_row_style

        'desc
        Dim currc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        currc.Text = dt.Rows(row_i)("currc").ToString
        currc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        currc.Font = font_row_style

        'value
        Dim hargac As String = Decimal.Parse(dt.Rows(row_i)("unit_price_in_rpc").ToString).ToString("N2")

        Dim total_nilaic As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        total_nilaic.Text = hargac
        total_nilaic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilaic.Font = font_row_style

        'qty
        Dim qtyc As String = Decimal.Parse(dt.Rows(row_i)("qtyc").ToString).ToString("N2")

        Dim col_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        col_qtyc.Text = qtyc
        col_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qtyc.Font = font_row_style

        'sub_amount
        Dim sub_amountc As String = Decimal.Parse(dt.Rows(row_i)("total_in_rpc").ToString).ToString("N2")

        Dim sub_amount_colc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        sub_amount_colc.Text = sub_amountc
        sub_amount_colc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_colc.Font = font_row_style
    End Sub

    Sub insert_header(ByRef row_det As DevExpress.XtraReports.UI.XRTableRow, ByVal txt As String, ByVal opt As String)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Underline And FontStyle.Bold)

        Dim row As New DevExpress.XtraReports.UI.XRTableRow

        row_det = XTDetail.InsertRowBelow(row_det)
        row = XTDetail.InsertRowAbove(row_det)
        row_det.Visible = False

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        '-------------------- vendor 1 ------------------------------------------
        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = txt
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        Dim curr As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        curr.Text = ""
        curr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        curr.Font = font_row_style

        'value
        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = ""
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_qty.Text = ""
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        sub_amount_col.Text = ""
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style

        '-------------------- vendor 2 ------------------------------------------
        'desc
        Dim descc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        descc.Text = txt
        descc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        descc.Font = font_row_style

        'currc
        Dim currc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        currc.Text = ""
        currc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        currc.Font = font_row_style

        'value
        Dim total_nilaic As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        total_nilaic.Text = ""
        total_nilaic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilaic.Font = font_row_style

        'qty
        Dim col_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        col_qtyc.Text = ""
        col_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qtyc.Font = font_row_style

        'sub_amount
        Dim sub_amount_colc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        sub_amount_colc.Text = ""
        sub_amount_colc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_colc.Font = font_row_style

        row.DeleteCell(curr)
        row.DeleteCell(total_nilai)
        row.DeleteCell(col_qty)
        row.DeleteCell(sub_amount_col)
        '
        Dim separator As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        '
        row.DeleteCell(currc)
        row.DeleteCell(total_nilaic)
        row.DeleteCell(col_qtyc)
        row.DeleteCell(sub_amount_colc)

        desc.WidthF = 500
        separator.WidthF = 50
        descc.WidthF = 500

        If opt = "sub" Then
            desc.BackColor = Color.LightGray
            descc.BackColor = Color.LightGray
        End If
    End Sub

    Sub insert_row_manual(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Bold)

        If Not row_i = 0 Then
            row = XTDetail.InsertRowBelow(row)
        End If

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style
        row.BackColor = Color.Black
        row.ForeColor = Color.White

        '-------------------- vendor 1 ------------------------------------------
        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = dt.Rows(row_i)("desc").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'desc
        Dim curr As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        curr.Text = dt.Rows(row_i)("curr").ToString
        curr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        curr.Font = font_row_style

        'value

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = dt.Rows(row_i)("unit_price_in_rp").ToString
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty

        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_qty.Text = dt.Rows(row_i)("qty").ToString
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        sub_amount_col.Text = dt.Rows(row_i)("total_in_rp").ToString
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style

        '-------------------
        Dim separator As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        separator.BackColor = Nothing

        '-------------------- vendor 2 ------------------------------------------
        'desc
        Dim descc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        descc.Text = dt.Rows(row_i)("descc").ToString
        descc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        descc.Font = font_row_style

        Dim currc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        currc.Text = dt.Rows(row_i)("currc").ToString
        currc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        currc.Font = font_row_style

        'value

        Dim total_nilaic As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        total_nilaic.Text = dt.Rows(row_i)("unit_price_in_rpc").ToString
        total_nilaic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilaic.Font = font_row_style

        'qty

        Dim col_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        col_qtyc.Text = dt.Rows(row_i)("qtyc").ToString
        col_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qtyc.Font = font_row_style

        'sub_amount

        Dim sub_amount_colc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        sub_amount_colc.Text = dt.Rows(row_i)("total_in_rpc").ToString
        sub_amount_colc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_colc.Font = font_row_style
    End Sub

    Private Sub ReportPreCalBudget_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRRow
        Dim total_orign As Decimal = 0.00
        Dim total_orignc As Decimal = 0.00
        Dim total_dest As Decimal = 0.00
        Dim total_destc As Decimal = 0.00

        Dim qorign As String = "SELECT d.`desc`,cur.currency AS curr,IFNULL(d.`unit_price`,0) AS unit_price,IFNULL(d.`qty`,0) AS qty,IFNULL(d.`unit_price_in_rp`,0) AS unit_price_in_rp,IFNULL(d.`total_in_rp`,0) AS total_in_rp, dc.`desc` AS descc,curc.currency AS currc,IFNULL(dc.`unit_price`,0) AS unit_pricec,IFNULL(dc.`qty`,0) AS qtyc,IFNULL(dc.`unit_price_in_rp`,0) AS unit_price_in_rpc,IFNULL(dc.`total_in_rp`,0) AS total_in_rpc
FROM `tb_pre_cal_fgpo_det` d
INNER JOIN tb_pre_cal_fgpo h ON h.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND d.id_type=1 AND d.`id_comp`=h.`choosen_id_comp`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=d.id_currency
LEFT JOIN tb_pre_cal_fgpo_det dc ON dc.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND dc.id_type=1 AND dc.`id_comp`=h.`second_best_comp` AND dc.`id_pre_cal_temp`=d.`id_pre_cal_temp`
LEFT JOIN tb_lookup_currency curc ON curc.id_currency=dc.id_currency
WHERE d.`id_pre_cal_fgpo`='" & id_report & "' 
ORDER BY d.`id_pre_cal_temp` ASC"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        For i = 0 To dt_orign.Rows.Count - 1
            If i = 0 Then
                insert_header(row_baru, "ORIGN CHARGES :", "sub")
            End If
            insert_row(row_baru, dt_orign, i)
            total_orign += dt_orign.Rows(i)("total_in_rp")
            total_orignc += dt_orign.Rows(i)("total_in_rpc")
        Next
        '
        Dim qdest As String = "SELECT d.`desc`,cur.currency AS curr,IFNULL(d.`unit_price`,0) AS unit_price,IFNULL(d.`qty`,0) AS qty,IFNULL(d.`unit_price_in_rp`,0) AS unit_price_in_rp,IFNULL(d.`total_in_rp`,0) AS total_in_rp, dc.`desc` AS descc,curc.currency AS currc,IFNULL(dc.`unit_price`,0) AS unit_pricec,IFNULL(dc.`qty`,0) AS qtyc,IFNULL(dc.`unit_price_in_rp`,0) AS unit_price_in_rpc,IFNULL(dc.`total_in_rp`,0) AS total_in_rpc
FROM `tb_pre_cal_fgpo_det` d
INNER JOIN tb_pre_cal_fgpo h ON h.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND d.id_type=2 AND d.`id_comp`=h.`choosen_id_comp`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=d.id_currency
LEFT JOIN tb_pre_cal_fgpo_det dc ON dc.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND dc.id_type=2 AND dc.`id_comp`=h.`second_best_comp` AND dc.`id_pre_cal_temp`=d.`id_pre_cal_temp`
LEFT JOIN tb_lookup_currency curc ON curc.id_currency=dc.id_currency
WHERE d.`id_pre_cal_fgpo`='" & id_report & "' 
ORDER BY d.`id_pre_cal_temp` ASC"
        Dim dt_dest As DataTable = execute_query(qdest, -1, True, "", "", "", "")

        For i = 0 To dt_dest.Rows.Count - 1
            If i = 0 Then
                insert_header(row_baru, "DESTINATION CHARGES :", "sub")
            End If
            insert_row(row_baru, dt_dest, i)
            total_dest += dt_dest.Rows(i)("total_in_rp")
            total_destc += dt_dest.Rows(i)("total_in_rpc")
            '
            If i = dt_dest.Rows.Count - 1 Then
                'summary
                Dim qsum As String = "SELECT 'TOTAL IN RUPIAH' AS `desc`,'' AS curr,'' AS unit_price,'' AS qty,'' AS unit_price_in_rp,'" & Decimal.Parse(total_orign + total_dest.ToString).ToString("N2") & "' AS total_in_rp, 'TOTAL IN RUPIAH' AS descc,'' AS currc,'' AS unit_pricec,'' AS qtyc,'' AS unit_price_in_rpc,'" & Decimal.Parse(total_orignc + total_destc.ToString).ToString("N2") & "' AS total_in_rpc"
                Dim dtsum As DataTable = execute_query(qsum, -1, True, "", "", "", "")
                insert_row_manual(row_baru, dtsum, 0)
            End If
        Next

        '
        Dim qadm As String = "SELECT d.`desc`,cur.currency AS curr,IFNULL(d.`unit_price`,0) AS unit_price,IFNULL(d.`qty`,0) AS qty,IFNULL(d.`unit_price_in_rp`,0) AS unit_price_in_rp,IFNULL(d.`total_in_rp`,0) AS total_in_rp, dc.`desc` AS descc,curc.currency AS currc,IFNULL(dc.`unit_price`,0) AS unit_pricec,IFNULL(dc.`qty`,0) AS qtyc,IFNULL(dc.`unit_price_in_rp`,0) AS unit_price_in_rpc,IFNULL(dc.`total_in_rp`,0) AS total_in_rpc
FROM `tb_pre_cal_fgpo_det` d
INNER JOIN tb_pre_cal_fgpo h ON h.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND d.id_type=3 AND d.`id_comp`=h.`choosen_id_comp`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=d.id_currency
LEFT JOIN tb_pre_cal_fgpo_det dc ON dc.`id_pre_cal_fgpo`=d.`id_pre_cal_fgpo` AND dc.id_type=3 AND dc.`id_comp`=h.`second_best_comp` AND dc.`id_pre_cal_temp`=d.`id_pre_cal_temp`
LEFT JOIN tb_lookup_currency curc ON curc.id_currency=dc.id_currency
WHERE d.`id_pre_cal_fgpo`='" & id_report & "' 
ORDER BY d.`id_pre_cal_temp` ASC"
        Dim dt_adm As DataTable = execute_query(qadm, -1, True, "", "", "", "")

        For i = 0 To dt_adm.Rows.Count - 1
            If i = 0 Then
                insert_header(row_baru, "TOTAL AVERAGE", "")
                '
                Dim qsum As String = "SELECT 'FREIGHT' AS `desc`,'' AS curr,0 AS unit_price,0 AS qty,0 AS unit_price_in_rp," & decimalSQL(Decimal.Parse(total_orign.ToString).ToString) & " AS total_in_rp, 'FREIGHT' AS descc,'' AS currc,0 AS unit_pricec,0 AS qtyc,0 AS unit_price_in_rpc," & decimalSQL(Decimal.Parse(total_orignc.ToString).ToString) & " AS total_in_rpc
UNION ALL
SELECT 'DESTINATION CHARGES' AS `desc`,'' AS curr,0 AS unit_price,0 AS qty,0 AS unit_price_in_rp," & decimalSQL(Decimal.Parse(total_dest.ToString).ToString) & " AS total_in_rp, 'DESTINATION CHARGES' AS descc,'' AS currc,0 AS unit_pricec,0 AS qtyc,0 AS unit_price_in_rpc," & decimalSQL(Decimal.Parse(total_destc.ToString).ToString) & " AS total_in_rpc"
                Dim dtsum As DataTable = execute_query(qsum, -1, True, "", "", "", "")
                '
                insert_row(row_baru, dtsum, 0)
                insert_row(row_baru, dtsum, 1)
            End If
            insert_row(row_baru, dt_adm, i)
        Next
    End Sub
End Class