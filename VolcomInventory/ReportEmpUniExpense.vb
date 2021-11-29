Public Class ReportEmpUniExpense
    Public Shared id_emp_uni_ex As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportEmpUniExpense_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_emp_uni_ex WHERE id_emp_uni_ex = " + id_emp_uni_ex, 0, True, "", "", "", "")

        LabelTitleOwnComp.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
        LabelOwnCompNPWP.Text = execute_query("SELECT npwp FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")

        'get total
        Dim qtot As String = "SELECT e.id_emp_uni_ex, SUM(ed.design_cop * ed.qty) + (SUM(ed.design_cop * ed.qty) * (e.vat_trans/100)) AS `total`,
        e.vat_trans AS `ppn_pros`, (SUM(ed.design_cop * ed.qty) + (SUM(ed.design_cop * ed.qty) * (e.vat_trans/100))) * (e.vat_trans/(100 + e.vat_trans)) AS `ppn`,
        (SUM(ed.design_cop * ed.qty) + (SUM(ed.design_cop * ed.qty) * (e.vat_trans/100))) * (100/(100 + e.vat_trans)) AS `dpp`
        FROM tb_emp_uni_ex e
        INNER JOIN tb_emp_uni_ex_det ed ON ed.id_emp_uni_ex = e.id_emp_uni_ex
        WHERE e.id_emp_uni_ex=" + id_emp_uni_ex + "
        GROUP BY e.id_emp_uni_ex "
        Dim dtot As DataTable = execute_query(qtot, -1, True, "", "", "", "")
        LabelTotal.Text = Decimal.Parse(dtot.Rows(0)("total").ToString).ToString("N2")
        LabelDPP.Text = Decimal.Parse(dtot.Rows(0)("dpp").ToString).ToString("N2")
        LabelPPNPros.Text = "PPN " + Decimal.Parse(dtot.Rows(0)("ppn_pros").ToString).ToString("N0") + "%"
        LabelPPN.Text = Decimal.Parse(dtot.Rows(0)("ppn").ToString).ToString("N2")

        Dim total As Decimal = 0.00
        Dim total_qty As Decimal = 0.00

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        For i = 0 To dt.Rows.Count - 1
            row = XTable.InsertRowBelow(row)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = i + 1
            no.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            no.Borders = DevExpress.XtraPrinting.BorderSide.None

            'code
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = dt.Rows(i)("code").ToString
            code.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            code.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            code.Borders = DevExpress.XtraPrinting.BorderSide.None

            'name
            Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            name.Text = dt.Rows(i)("name").ToString
            name.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            name.Borders = DevExpress.XtraPrinting.BorderSide.None

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = dt.Rows(i)("size").ToString
            size.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            size.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            size.Borders = DevExpress.XtraPrinting.BorderSide.None

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = dt.Rows(i)("qty").ToString
            qty.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None

            'design_cop
            Dim design_cop As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            design_cop.Text = Decimal.Parse(dt.Rows(i)("design_cop").ToString).ToString("N2")
            design_cop.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            design_cop.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            design_cop.Borders = DevExpress.XtraPrinting.BorderSide.None

            'amount
            Dim amount As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amount.Text = Decimal.Parse((dt.Rows(i)("qty") * dt.Rows(i)("design_cop")).ToString).ToString("N2")
            amount.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
            amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            amount.Borders = DevExpress.XtraPrinting.BorderSide.None

            total += dt.Rows(i)("qty") * dt.Rows(i)("design_cop")
            total_qty += dt.Rows(i)("qty")
        Next

        RowTotalAmount.Text = Decimal.Parse(total.ToString).ToString("N2")
        RowTotalQty.Text = Decimal.Parse(total_qty.ToString).ToString("N0")

        pre_load_mark_horz_plain_acc(report_mark_type, id_emp_uni_ex, "(                       )", "2", XrTable1)
        'load_mark_horz(report_mark_type, id_emp_uni_ex, "2", "1", XrTable1)
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class