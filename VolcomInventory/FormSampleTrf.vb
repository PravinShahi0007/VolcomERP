Public Class FormSampleTrf
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleTrf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSanpleTrf()
    End Sub

    Sub viewSanpleTrf()
        Dim query As String = ""
        query += "SELECT "
        query += "trf.id_sample_trf, trf.sample_trf_number, trf.sample_trf_date, trf.sample_trf_note, trf.id_report_status, rep_status.report_status, "
        query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
        query += "FROM tb_sample_trf trf "
        query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status rep_status ON trf.id_report_status = rep_status.id_report_status "
        query += "ORDER BY trf.id_sample_trf DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleTrf.DataSource = data
        check_menu()
    End Sub

    Private Sub FormSampleTrf_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSampleTrf_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVSampleTrf.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSampleTrf.FocusedRowHandle
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


    'Private Sub GVFGTrf_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
    '    noManipulating()
    'End Sub
End Class