﻿Public Class FormReturnForBOF
    Private Sub FormReturnForBOF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEGroup, "
            SELECT id_comp_group, comp_group, description
            FROM tb_m_comp_group
        ", "id_comp_group", "comp_group", "id_comp_group")

        DEFrom.EditValue = Now
        DETo.EditValue = Now
    End Sub

    Private Sub FormReturnForBOF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim id_comp_group As String = SLUEGroup.EditValue.ToString

        Dim date_from As String = Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_to As String = Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query_check As String = "
            (SELECT d.id_report_status
            FROM tb_pl_sales_order_del d
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = d.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            WHERE d.pl_sales_order_del_date>='" + date_from + "' AND d.pl_sales_order_del_date<='" + date_to + "' AND s.id_comp_group='" + id_comp_group + "' AND d.id_report_status NOT IN (5, 6))
            UNION ALL
            (SELECT r.id_report_status
            FROM tb_sales_return r
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = r.id_store_contact_from
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            WHERE r.sales_return_date>='" + date_from + "' AND r.sales_return_date<='" + date_to + "' AND s.id_comp_group='" + id_comp_group + "' AND r.id_report_status NOT IN (5, 6))
        "

        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")

        If data_check.Rows.Count = 0 Then
            Dim query As String = "
                SELECT 'DEL' AS `Type`,  d.pl_sales_order_del_number AS `Reff Number`, DATE_FORMAT(d.pl_sales_order_del_date, '%d %M %Y') AS `Tanggal`, w.comp_number AS `Asal`, s.comp_number AS `Tujuan`,p.product_full_code AS `Kode` ,dd.pl_sales_order_del_det_qty AS `Qty`, dd.design_price AS `Harga`
                FROM tb_pl_sales_order_del d
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = d.id_comp_contact_from
                INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
                INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = d.id_store_contact_to
                INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                INNER JOIN tb_m_product p ON p.id_product = dd.id_product
                WHERE d.pl_sales_order_del_date>='" + date_from + "' AND d.pl_sales_order_del_date<='" + date_to + "' 
                AND s.id_comp_group='" + id_comp_group + "' AND d.id_report_status=6 
                UNION ALL 
                SELECT 'RTS' AS `Type`, r.sales_return_number AS `Reff Number`, r.sales_return_date AS `Tanggal`,s.comp_number AS `Asal`, w.comp_number AS `Tujuan`, p.product_full_code AS `Kode` ,rd.sales_return_det_qty AS `Qty`, rd.design_price AS `Harga`
                FROM tb_sales_return r
                INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return
                INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = r.id_comp_contact_to
                INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
                INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = r.id_store_contact_from
                INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                INNER JOIN tb_m_product p ON p.id_product = rd.id_product
                WHERE r.sales_return_date>='" + date_from + "' AND r.sales_return_date<='" + date_to + "'
                AND s.id_comp_group='" + id_comp_group + "' AND r.id_report_status=6 
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCList.DataSource = data

            GVList.BestFitColumns()
        Else
            stopCustom("There are some incomplete transaction.")
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        print(GCList, "Delivery Return for BOF")
    End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"

        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim opt As DevExpress.XtraPrinting.XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions

            opt.RawDataMode = True

            GVList.ExportToXlsx(save.FileName, opt)

            infoCustom("File saved.")
        End If
    End Sub
End Class