﻿Public Class FormBankWithdrawalSum
    Public id_sum As String = "-1"
    Private Sub FormBankWithdrawalSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        DEDateCreated.EditValue = Now
        DEPayment.EditValue = Now

        If id_sum = "-1" Then

        Else

        End If
    End Sub

    Sub load_type()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupQuery(SLEType, q, "id_currency", "currency", "id_currency")
    End Sub

    Private Sub FormBankWithdrawalSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BGenerate_Click(sender As Object, e As EventArgs) Handles BGenerate.Click
        If BGenerate.Text = "Generate" Then
            generate()
        Else
            unlock()
        End If
    End Sub

    Sub generate()
        'check if already
        Dim qc As String = "SELECT id_pn_summary FROM tb_pn_summary WHERE id_pn_summary!='" & id_sum & "' AND id_currency='" & SLEType.EditValue.ToString & "' AND id_report_status!=5 AND DATE(date_payment)='" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count = 0 Then
            Dim q As String = "SELECT 'no' AS is_check,py.number,sts.report_status,emp.employee_name AS created_by, py.date_created, py.`id_pn`,py.`value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_pn_det pyd ON pyd.id_pn=py.id_pn AND pyd.`id_currency`='" & SLEType.EditValue.ToString & "' AND pyd.`is_include_total`=1
WHERE py.`id_report_status`!='5' AND py.`id_report_status`!='6' AND  DATE(py.`date_payment`)='" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
            If SLEType.EditValue.ToString = "1" Then
                q += " GROUP BY py.id_pn "
            Else
                q += " GROUP BY pyd.id_pn_det "
            End If
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt
            GVList.BestFitColumns()
            DEPayment.Enabled = False
            BGenerate.Text = "Unlock"
        Else
            warningCustom("Summary already created for this payment date.")
        End If
    End Sub

    Sub unlock()
        Dim q As String = "SELECT 'no' AS is_check,py.number,sts.report_status,emp.employee_name AS created_by, py.date_created, py.`id_pn`,py.`value` ,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
WHERE py.id_pn='-1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        DEPayment.Enabled = True
        BGenerate.Text = "Generate"
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVList.RowCount = 0 Then
            warningCustom("No BBK listed.")
        Else
            If id_sum = "-1" Then 'new
                Dim q As String = "INSERT INTO tb_pn_summary(date_payment,created_date,created_by,id_report_status)
VALUES('" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'" & id_user & "',1); SELECT LAST_INSERT_ID();"
                id_sum = execute_query(q, 0, True, "", "", "", "")
                For i As Integer = 0 To GVList.RowCount - 1
                    q = "INSERT INTO tb_pn_summary_det(id_pn_summary,id_pn)
VALUES('" & id_sum & "','" & GVList.GetRowCellValue(i, "id_pn").ToString & "')"
                    execute_non_query(q, True, "", "", "", "")
                Next

                FormBankWithdrawal.view_sum()
                Close()
            End If
        End If
    End Sub
End Class