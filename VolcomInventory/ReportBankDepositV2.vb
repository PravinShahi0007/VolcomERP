Public Class ReportBankDepositV2
    Public Shared id As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportBankDepositV2_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'GCList.DataSource = dt

        Dim query As String = "SELECT py.id_rec_payment, py.number AS `report_number`, 
        DATE_FORMAT(py.date_created,'%d-%m-%Y') AS `created_date`,
        DATE_FORMAT(py.date_received,'%d-%m-%Y') AS `rec_date`,
        CONCAT(a.acc_name, ' - ', a.acc_description) AS `rec_payment_to`,py.value AS `amount`,
        py.note AS `note`, d.report_status, co.npwp_name AS `own_comp_name`, co.npwp AS `own_comp_npwp`,
        DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i:%s') AS `printed_date`, eusr.employee_name AS `printed_by`
        FROM tb_rec_payment py
        INNER JOIN tb_a_acc a ON a.id_acc = py.id_acc_pay_rec
        JOIN tb_opt o
        LEFT JOIN tb_m_comp co ON co.id_comp  = o.id_own_company
        INNER JOIN tb_lookup_report_status d ON d.id_report_status = py.id_report_status 
        JOIN tb_m_user usr ON usr.id_user=" + id_user + "
        INNER JOIN tb_m_employee eusr ON eusr.id_employee = usr.id_employee
        WHERE py.id_rec_payment=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data

        'initial
        LabelAmount.Text = Decimal.Parse(data.Rows(0)("amount").ToString).ToString("N2")
        LabelSay.Text = "Say : " + ConvertCurrencyToEnglish(data.Rows(0)("amount"), get_setup_field("id_currency_default"))

        'detail
        viewDetail()

        'report status
        Dim itime As String = "2"
        If id_report_status = "1" Then
            itime = "2"
        ElseIf id_report_status = "6" Then
            itime = "1"
        End If
        pre_load_mark_horz_plain_acc(rmt, id, "2", itime, XrTable1)
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewDetail()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "SELECT (@nomer:=@nomer+1) AS `no`,a.* 
        FROM (
	        (SELECT 0 AS `id_det`,'1' AS `is_header`, 0 AS `id_reff`,a.acc_name AS `coa`, '' AS `reff`, py.note, '' AS `vendor`,
	        cc.comp_number AS `cc`, 'D' AS `type`, FORMAT(py.value,2,'id_ID') AS `amount`
	        FROM tb_rec_payment py
	        INNER JOIN tb_a_acc a ON a.id_acc = py.id_acc_pay_rec
	        INNER JOIN tb_coa_tag ct ON ct.id_coa_tag = py.id_coa_tag
	        INNER JOIN tb_m_comp cc ON cc.id_comp = ct.id_comp
	        WHERE py.id_rec_payment='" + id + "' AND py.`value` > 0)
	        UNION ALL
	        (SELECT pyd.id_rec_payment_det AS `id_det`,'2' AS `is_header`, pyd.id_report AS `id_reff`, a.acc_name AS `coa`, pyd.number AS `reff`, pyd.note, pyd.vendor,
	        comp.comp_number AS `cc`, dc.dc_code AS `type`, FORMAT(ABS(pyd.`value`),2,'id_ID') AS `amount` 
	        FROM tb_rec_payment_det pyd
	        INNER JOIN tb_lookup_dc dc ON dc.id_dc = pyd.id_dc
	        INNER JOIN tb_a_acc a ON a.id_acc = pyd.id_acc
	        LEFT JOIN tb_m_comp comp ON comp.id_comp = pyd.id_comp
	        WHERE pyd.id_rec_payment='" + id + "'
	        ORDER BY pyd.id_rec_payment_det ASC)
        ) a
        JOIN (SELECT @nomer:=0) n
        ORDER BY a.is_header ASC, a.id_det ASC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        DetailReport.DataSource = data
    End Sub
End Class