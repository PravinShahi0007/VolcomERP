Public Class FormBankDeposit
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim id_pay_type_po As String = "-1"

    Private Sub FormBankDeposit_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBankDeposit_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormBankDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_status_payment()

        load_vendor_po()
    End Sub
    Sub load_status_payment()
        Dim query As String = "SELECT 0 AS id_status_payment,'Open' AS status_payment
UNION
SELECT 1 AS id_status_payment,'Paid' AS status_payment
UNION
SELECT 2 AS id_status_payment,'Overdue' AS status_payment"
        viewSearchLookupQuery(SLEStatusPayment, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
UNION
SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='8' or c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEStoreDeposit, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_vendor_po()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='8'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_deposit()

    End Sub
    Sub load_invoice()

    End Sub
End Class