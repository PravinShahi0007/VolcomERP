Public Class FormItemSubCat
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public is_accounting As String = "-1"

    Private Sub FormItemSubCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT icd.`id_item_cat_detail`,ic.`item_cat`,vt.`vendor_type`,icd.`item_cat_detail`,icd.`created_date`,emp.`employee_name`,IF(icd.id_status='1','Waiting for accounting',IF(icd.id_status='2','Active','Not Active')) AS status,icd.id_status
FROM `tb_item_cat_detail` icd
LEFT JOIN `tb_item_cat` ic ON ic.`id_item_cat`=icd.`id_item_cat`
INNER JOIN tb_vendor_type vt ON vt.`id_vendor_type`=icd.`id_vendor_type`
INNER JOIN tb_m_user usr ON usr.`id_user`=icd.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`"
        If is_accounting = "1" Then
            query += " WHERE icd.id_status='1' "
        End If
        query += "ORDER BY icd.`id_item_cat` DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurchaseCategory.DataSource = data
        check_menu()
    End Sub

    Private Sub FormItemSubCat_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemSubCat_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If is_accounting = "1" Then
            bnew_active = "0"
        Else
            bnew_active = "1"
        End If
        '
        If GVPurchaseCategory.RowCount < 1 Then
            'hide all except new
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bedit_active = "1"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        End If
    End Sub

    Private Sub FormItemSubCat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class