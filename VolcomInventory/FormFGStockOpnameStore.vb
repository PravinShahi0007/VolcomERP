Public Class FormFGStockOpnameStore 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bview_active As String = "1"
    

    Private Sub FormFGStockOpnameStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSoStore()
    End Sub

    Sub viewSoStore()
        Dim query As String = ""
        query += "SELECT lockx.lock, so.id_lock, so.id_fg_so_store, so.fg_so_store_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_store_date_created, '%d %M %Y / %H:%i') AS fg_so_store_date_created, "
        query += "DATE_FORMAT(so.fg_so_store_last_update, '%d %M %Y / %H:%i') AS fg_so_store_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_store_contact_from, (comp.id_comp) AS id_store_from, "
        query += "(comp.comp_number) AS store_number_from, (comp.comp_name) AS store_name_from "
        query += "FROM tb_fg_so_store so "
        'query += "INNER JOIN tb_fg_so_store_det so_det ON so.id_fg_so_store = so_det.id_fg_so_store "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_store_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "INNER JOIN tb_lookup_lock lockx ON lockx.id_lock = so.id_lock "
        query += "ORDER BY so.id_fg_so_store DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOStore.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If GVSOStore.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Private Sub FormFGStockOpnameStore_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGStockOpnameStore_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSOStore.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                bview_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"

                Dim id_lock As String = GVSOStore.GetFocusedRowCellValue("id_lock").ToString
                If id_lock = "1" Then
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("4", bview_active)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVSOStore_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSOStore.FocusedRowChanged
        noManipulating()
    End Sub
End Class