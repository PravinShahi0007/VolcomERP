Public Class FormBankWithdrawalDet
    Private Sub FormBankWithdrawalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankWithdrawalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pay_from()
        load_trans_type()
        load_report_type()
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEReportType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub
End Class