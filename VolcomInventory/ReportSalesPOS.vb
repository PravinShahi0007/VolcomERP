Public Class ReportSalesPOS
    Public Shared id_sales_pos As String = "-1"
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"
    Dim total_amount As Decimal = 0.0
    Dim id_so_type As String = "-1"

    Sub viewDetail()
        Dim query As String = "CALL view_sales_pos('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCSalesPOS.DataSource = data
    End Sub

    Private Sub GVSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportSalesPOS_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("48", id_sales_pos, "2", "1", XrTable1)
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVSalesPOS.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        LSay.Text = ConvertCurrencyToEnglish(total_amount, id_currency)
        LGrossTot.Text = total_amount.ToString
        LCur.Text = currency.ToString
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        sayCurr()
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        viewDetail()
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        'get currency default
        Dim query_currency As String = "SELECT b.currency, b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim datax As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = datax.Rows(0)("id_currency").ToString
        currency = datax.Rows(0)("currency").ToString

        Dim query As String = ""
        query += "SELECT sot.so_type,pld.pl_sales_order_del_number,a.id_pl_sales_order_del,a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (c.comp_name) AS store_name_from,c.npwp, "
        query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, c.id_comp, "
        query += "a.sales_pos_due_date, a.sales_pos_start_period, a.sales_pos_end_period, a.sales_pos_discount, a.sales_pos_vat "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "LEFT JOIN tb_pl_sales_order_del pld ON pld.id_pl_sales_order_del=a.id_pl_sales_order_del "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type sot ON sot.id_so_type=a.id_so_type "
        query += "WHERE a.id_sales_pos = '" + id_sales_pos + "' "
        query += "ORDER BY a.id_sales_pos ASC "

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        LStore.Text = data.Rows(0)("store_name_from").ToString
        LStoreAddress.Text = data.Rows(0)("store_address_from").ToString
        LPODate.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
        LPOSNumber.Text = data.Rows(0)("sales_pos_number").ToString
        LNote.Text = data.Rows(0)("sales_pos_note").ToString
        LType.Text = data.Rows(0)("so_type").ToString
        id_so_type = data.Rows(0)("id_so_type").ToString

        check_do()
        If Not data.Rows(0)("id_pl_sales_order_del").ToString = "" Then
            LDelOrder.Text = data.Rows(0)("pl_sales_order_del_number").ToString
        End If

    End Sub

    Sub check_do()
        If id_so_type = "1" Then
            LDelOrderLeft.Visible = False
            LDelOrderMid.Visible = False
            LDelOrder.Visible = False
        Else
            LDelOrderLeft.Visible = True
            LDelOrderMid.Visible = True
            LDelOrder.Visible = True
        End If
    End Sub
End Class