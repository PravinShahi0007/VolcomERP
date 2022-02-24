Public Class ReportRiderContract
    Public id_pps As String = "-1"

    Private Sub ReportRiderContract_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim total As Decimal = 0.00
        Dim total_old As Decimal = 0.00
        Dim monthly_total As Decimal = 0.00
        Dim monthly_total_old As Decimal = 0.00
        '
        'surf rider
        Dim q_surf As String = "SELECT c.`comp_name`
,CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from_old,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until_old,'%d %b %Y'),'')) AS contract_old
,IF(ISNULL(ppsd.`kontrak_from_old`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from_old,ppsd.kontrak_until_old)*ppsd.`monthly_pay_old`) AS total_old
,IFNULL(ppsd.`monthly_pay_old`,0) AS monthly_pay_old
,IF(ppsd.terminate=1,'Contract terminated',CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until,'%d %b %Y'),''))) AS contract
,IF(ppsd.terminate=1,0,IF(ISNULL(ppsd.`kontrak_from`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until)*ppsd.`monthly_pay`)) AS total
,IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0)) AS monthly_pay
,IFNULL((IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0))-IFNULL(ppsd.`monthly_pay_old`,0))/IFNULL(ppsd.`monthly_pay_old`,0),0)*100 AS inc
FROM `tb_kontrak_rider_pps_det` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.id_kontrak_rider_pps='" & id_pps & "' AND ppsd.id_kontrak_type=1"
        Dim dtsurf As DataTable = execute_query(q_surf, -1, True, "", "", "", "")
        If dtsurf.Rows.Count > 0 Then
            Dim total_sub As Decimal = 0.00
            Dim total_old_sub As Decimal = 0.00
            Dim monthly_sub As Decimal = 0.00
            Dim monthly_old_sub As Decimal = 0.00
            '
            For i = 0 To dtsurf.Rows.Count - 1
                insert_row(XRSurf, dtsurf, i, XTSurf)
                monthly_sub += dtsurf.Rows(i)("monthly_pay")
                monthly_old_sub += dtsurf.Rows(i)("monthly_pay_old")
                total_sub += dtsurf.Rows(i)("total")
                total_old_sub += dtsurf.Rows(i)("total_old")
            Next

            total += total_sub
            total_old += total_old_sub
            monthly_total += monthly_sub
            monthly_total_old += monthly_old_sub

            insert_row_total(XRSurf, dtsurf, XTSurf, monthly_old_sub, total_old_sub, monthly_sub, total_sub)
        Else
            SBSurf.Visible = False
        End If

        'skateboard
        Dim q_skate As String = "SELECT c.`comp_name`
,CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from_old,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until_old,'%d %b %Y'),'')) AS contract_old
,IF(ISNULL(ppsd.`kontrak_from_old`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from_old,ppsd.kontrak_until_old)*ppsd.`monthly_pay_old`) AS total_old
,IFNULL(ppsd.`monthly_pay_old`,0) AS monthly_pay_old
,IF(ppsd.terminate=1,'Contract terminated',CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until,'%d %b %Y'),''))) AS contract
,IF(ppsd.terminate=1,0,IF(ISNULL(ppsd.`kontrak_from`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until)*ppsd.`monthly_pay`)) AS total
,IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0)) AS monthly_pay
,IFNULL((IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0))-IFNULL(ppsd.`monthly_pay_old`,0))/IFNULL(ppsd.`monthly_pay_old`,0),0)*100 AS inc
FROM `tb_kontrak_rider_pps_det` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.id_kontrak_rider_pps='" & id_pps & "' AND ppsd.id_kontrak_type=2"
        Dim dtskate As DataTable = execute_query(q_skate, -1, True, "", "", "", "")
        If dtskate.Rows.Count > 0 Then
            Dim total_sub As Decimal = 0.00
            Dim total_old_sub As Decimal = 0.00
            Dim monthly_sub As Decimal = 0.00
            Dim monthly_old_sub As Decimal = 0.00
            '
            For i = 0 To dtskate.Rows.Count - 1
                insert_row(XRSkate, dtskate, i, XTSkate)
                monthly_sub += dtskate.Rows(i)("monthly_pay")
                monthly_old_sub += dtskate.Rows(i)("monthly_pay_old")
                total_sub += dtskate.Rows(i)("total")
                total_old_sub += dtskate.Rows(i)("total_old")
            Next

            total += total_sub
            total_old += total_old_sub
            monthly_total += monthly_sub
            monthly_total_old += monthly_old_sub

            insert_row_total(XRSkate, dtskate, XTSkate, monthly_old_sub, total_old_sub, monthly_sub, total_sub)
        Else
            SBSkate.Visible = False
        End If

        'team ambasador
        Dim q_ambasador As String = "SELECT c.`comp_name`
,CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from_old,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until_old,'%d %b %Y'),'')) AS contract_old
,IF(ISNULL(ppsd.`kontrak_from_old`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from_old,ppsd.kontrak_until_old)*ppsd.`monthly_pay_old`) AS total_old
,IFNULL(ppsd.`monthly_pay_old`,0) AS monthly_pay_old
,IF(ppsd.terminate=1,'Contract terminated',CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until,'%d %b %Y'),''))) AS contract
,IF(ppsd.terminate=1,0,IF(ISNULL(ppsd.`kontrak_from`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until)*ppsd.`monthly_pay`)) AS total
,IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0)) AS monthly_pay
,IFNULL((IF(ppsd.terminate=1,0,IFNULL(ppsd.`monthly_pay`,0))-IFNULL(ppsd.`monthly_pay_old`,0))/IFNULL(ppsd.`monthly_pay_old`,0),0)*100 AS inc
FROM `tb_kontrak_rider_pps_det` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.id_kontrak_rider_pps='" & id_pps & "' AND ppsd.id_kontrak_type=3"
        Dim dtambasador As DataTable = execute_query(q_ambasador, -1, True, "", "", "", "")
        If dtambasador.Rows.Count > 0 Then
            Dim total_sub As Decimal = 0.00
            Dim total_old_sub As Decimal = 0.00
            Dim monthly_sub As Decimal = 0.00
            Dim monthly_old_sub As Decimal = 0.00
            '
            For i = 0 To dtambasador.Rows.Count - 1
                insert_row(XRAmbasador, dtambasador, i, XTAmbasador)
                monthly_sub += dtambasador.Rows(i)("monthly_pay")
                monthly_old_sub += dtambasador.Rows(i)("monthly_pay_old")
                total_sub += dtambasador.Rows(i)("total")
                total_old_sub += dtambasador.Rows(i)("total_old")
            Next

            total += total_sub
            total_old += total_old_sub
            monthly_total += monthly_sub
            monthly_total_old += monthly_old_sub

            insert_row_total(XRAmbasador, dtambasador, XTAmbasador, monthly_old_sub, total_old_sub, monthly_sub, total_sub)
        Else
            SBAmbasador.Visible = False
        End If
        '
        LTotMonthlyOld.Text = monthly_total_old.ToString("N2")
        LTotOld.Text = total_old.ToString("N2")
        LTotMonthly.Text = monthly_total.ToString("N2")
        Ltot.Text = total.ToString("N2")
        '
        pre_load_mark_horz("398", id_pps, "2", "2", XRReport)
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer, ByVal xt As DevExpress.XtraReports.UI.XRTable)
        Dim font_row_style As New Font(xt.Font.FontFamily, xt.Font.Size - 2, FontStyle.Regular)

        row = xt.InsertRowBelow(row)

        row.HeightF = 15
        row.Font = font_row_style
        row.BackColor = Color.Transparent

        'no
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = row_i + 1
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'name
        Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        name.Text = dt.Rows(row_i)("comp_name").ToString
        name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        name.Font = font_row_style

        'contract old
        Dim contract_old As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        contract_old.Text = dt.Rows(row_i)("contract_old").ToString
        contract_old.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        contract_old.Font = font_row_style

        'payment old
        Dim pay_old As String = Decimal.Parse(dt.Rows(row_i)("monthly_pay_old").ToString).ToString("N2")

        Dim pay_old_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        pay_old_col.Text = pay_old
        pay_old_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pay_old_col.Font = font_row_style

        'total payment old
        Dim tot_pay_old As String = Decimal.Parse(dt.Rows(row_i)("total_old").ToString).ToString("N2")

        Dim tot_pay_old_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        tot_pay_old_col.Text = tot_pay_old
        tot_pay_old_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pay_old_col.Font = font_row_style

        'contract
        Dim contract As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        contract.Text = dt.Rows(row_i)("contract").ToString
        contract.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        contract.Font = font_row_style

        'payment
        Dim pay As String = Decimal.Parse(dt.Rows(row_i)("monthly_pay").ToString).ToString("N2")

        Dim pay_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        pay_col.Text = pay
        pay_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pay_col.Font = font_row_style

        'total payment
        Dim tot_pay As String = Decimal.Parse(dt.Rows(row_i)("total").ToString).ToString("N2")

        Dim tot_pay_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        tot_pay_col.Text = tot_pay
        tot_pay_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pay_col.Font = font_row_style

        'inc dec
        Dim incdec As String = Decimal.Parse(dt.Rows(row_i)("inc").ToString).ToString("N2")

        Dim incdec_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        incdec_col.Text = incdec & " % "
        incdec_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        incdec_col.Font = font_row_style
    End Sub

    Sub insert_row_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal xt As DevExpress.XtraReports.UI.XRTable, ByVal sub_monthly_old As Decimal, ByVal sub_total_old As Decimal, ByVal sub_monthly As Decimal, ByVal sub_total As Decimal)
        Dim font_row_style As New Font(xt.Font.FontFamily, xt.Font.Size - 2, FontStyle.Regular)

        row = xt.InsertRowBelow(row)

        row.HeightF = 15
        row.Font = font_row_style
        row.BackColor = Color.LightGray

        'no
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = ""
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'name
        Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        name.Text = "Sub Total"
        name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        name.Font = font_row_style

        'contract old
        Dim contract_old As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        contract_old.Text = ""
        contract_old.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        contract_old.Font = font_row_style

        'payment old
        Dim pay_old As String = Decimal.Parse(sub_monthly_old.ToString).ToString("N2")

        Dim pay_old_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        pay_old_col.Text = pay_old
        pay_old_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pay_old_col.Font = font_row_style

        'total payment old
        Dim tot_pay_old As String = Decimal.Parse(sub_total_old.ToString).ToString("N2")

        Dim tot_pay_old_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        tot_pay_old_col.Text = tot_pay_old
        tot_pay_old_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pay_old_col.Font = font_row_style

        'contract
        Dim contract As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        contract.Text = ""
        contract.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        contract.Font = font_row_style

        'payment
        Dim pay As String = Decimal.Parse(sub_monthly.ToString).ToString("N2")

        Dim pay_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        pay_col.Text = pay
        pay_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pay_col.Font = font_row_style

        'total payment
        Dim tot_pay As String = Decimal.Parse(sub_total.ToString).ToString("N2")

        Dim tot_pay_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        tot_pay_col.Text = tot_pay
        tot_pay_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pay_col.Font = font_row_style

        'inc dec
        Dim incdec As String = ""
        If Not sub_monthly_old = 0 Then
            incdec = Decimal.Parse((((sub_monthly - sub_monthly_old) / sub_monthly_old) * 100).ToString).ToString("N2")
        Else
            incdec = 0.ToString("N2")
        End If

        Dim incdec_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        incdec_col.Text = incdec & " % "
        incdec_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        incdec_col.Font = font_row_style
    End Sub
End Class