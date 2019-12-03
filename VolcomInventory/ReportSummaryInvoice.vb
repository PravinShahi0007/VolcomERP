Public Class ReportSummaryInvoice
    Public Shared id As String = "-1"

    Private Sub ReportSummaryInvoice_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT c.comp_number AS `store_code`, c.comp_name AS `store`,
        sp.`sales_pos_number`,sp.`sales_pos_date`,
        CONCAT(DATE_FORMAT(sp.`sales_pos_start_period`,'%d-%m-%y'),' s/d ',DATE_FORMAT(sp.`sales_pos_end_period`,'%d-%m-%y')) AS period,
        sp.`sales_pos_due_date`, DATE_SUB(sp.sales_pos_due_date,INTERVAL 11 DAY) AS `send_date`,
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS amount
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
          SELECT pyd.id_report, pyd.report_mark_type, 
          COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
          SUM(pyd.value) AS  `value`
          FROM tb_rec_payment_det pyd
          INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
          WHERE py.`id_report_status`=6
          GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        INNER JOIN tb_m_comp cf ON cf.id_comp=1
        WHERE sp.id_sales_pos IN (" + id + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceList.DataSource = data
        ReportStyleGridview(GVInvoiceList)
    End Sub
End Class