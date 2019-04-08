Public Class FormInvoiceFGPODP
    Public id_dp As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPODP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateCreated.EditValue = Now
        TEPayNumber.Text = "[auto generate]"
        load_pay_from()
        load_vendor()
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub
    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub
End Class