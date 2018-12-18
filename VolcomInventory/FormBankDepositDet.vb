Public Class FormBankDepositDet
    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

    End Sub

    Private Sub FormBankDepositDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_receive_from()
        load_report_type()
        '
        TEPayNumber.Text = "[auto_generate]"
        DEDateCreated.EditValue = Now()
        TETotal.EditValue = 0.00
    End Sub

    Sub load_receive_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub FormBankDepositDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class