Public Class FormBankDepositDet
    Public report_mark_type As String = "-1"
    Public id_deposit As String = "-1"
    '
    Private Sub FormBankDepositDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_receive_from()
        '
        TEPayNumber.Text = "[auto_generate]"
        DEDateCreated.EditValue = Now()
        TETotal.EditValue = 0.00
        '
        If id_deposit = "-1" Then 'new
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            'check account
            Dim query_check As String = "SELECT IFNULL(id_acc_ar,0) AS id_acc_ar FROM tb_m_comp c
INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp
WHERE cc.id_comp_contact='" & FormBankWithdrawal.SLEVendor.EditValue & "'"
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows(0)("id_acc_arr").ToString = "0" Then
                warningCustom("This vendor AP account is not set.")
                Close()
            End If
            'load header
            SLEVendor.EditValue = FormBankDeposit.SLEStoreInvoice.EditValue
            'load detail
            For i As Integer = 0 To FormBankWithdrawal.GVPOList.RowCount - 1
                'id_report,number,total,balance due
                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_purc_order").ToString
                newRow("report_mark_type") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type").ToString
                newRow("report_mark_type_name") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type_name").ToString
                newRow("number") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "purc_order_number").ToString
                newRow("total_dp") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_dp").ToString
                newRow("value") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due").ToString
                newRow("balance_due") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due").ToString
                newRow("note") = ""
                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
            Next
            'calculate_amount()
        Else

        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT id_rec_payment_det,id_report,report_mark_type,number,total_dp,`value`,balance_due,note FROM tb_rec_payment_det recd WHERE recd.id_rec_payment='" & id_deposit & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub load_receive_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub FormBankDepositDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class