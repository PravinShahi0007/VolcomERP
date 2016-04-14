Public Class FormFGTrf 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGTrf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewFGTrf()
    End Sub

    Sub viewFGTrf()
        Dim query As String = ""
        query += "SELECT "
        query += "trf.id_fg_trf, trf.fg_trf_number, DATE_FORMAT(trf.fg_trf_date, '%d %M %Y') AS fg_trf_date, trf.fg_trf_note, trf.id_report_status, rep_status.report_status, "
        query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
        query += "FROM tb_fg_trf trf "
        query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status rep_status ON trf.id_report_status = rep_status.id_report_status "
        query += "ORDER BY trf.id_fg_trf DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
        check_menu()
    End Sub

    Private Sub FormFGTrf_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGTrf_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVFGTrf.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
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

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVFGTrf.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub GVFGTrf_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        noManipulating()
    End Sub
End Class