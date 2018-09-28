Public Class FormPurcReceive
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPurcReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewOrder()
        Dim where_string As String = ""

        If SLEVendor.EditValue.ToString = "0" Then
            where_string = ""
        Else
            where_string = " WHERE c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name as emp_created,po.last_update,emp_upd.employee_name AS emp_updated 
        FROM tb_purc_order po
        INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
        INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
        INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
        INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
        " & where_string & " AND po.id_report_status=6 ORDER BY po.id_purc_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
    End Sub

    Sub viewReceive()

    End Sub

    Private Sub FormPurcReceive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReceive_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormPurcReceive_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCRec.SelectedTabPageIndex = 0 Then
            If GVPO.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCRec.SelectedTabPageIndex = 1 Then
            If GVReceive.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCRec.SelectedTabPageIndex = 0 Then
                indeks = GVPO.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCRec.SelectedTabPageIndex = 1 Then
                indeks = GVReceive.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "1"
                    bdel_active = "0"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVPO_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPO.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVReceive_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVReceive.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVReceive_DoubleClick(sender As Object, e As EventArgs) Handles GVReceive.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCRec_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRec.SelectedPageChanged
        check_menu()
        If XTCRec.SelectedTabPageIndex = 0 Then
            viewOrder()
        ElseIf XTCRec.SelectedTabPageIndex = 1 Then
            viewReceive()
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewOrder()
    End Sub
End Class