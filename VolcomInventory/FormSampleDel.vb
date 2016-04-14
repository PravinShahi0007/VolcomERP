Public Class FormSampleDel 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleDel()
    End Sub

    Sub viewSampleDel()
        Dim query As String = ""
        query += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
        query += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
        query += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "stt.report_status, pl_cat.id_pl_category, pl_cat.pl_category "
        query += "FROM tb_sample_del del "
        query += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category pl_cat ON pl_cat.id_pl_category = del.id_pl_category "
        query += "ORDER BY del.id_sample_del DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDel.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If GVSampleDel.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSampleDel.FocusedRowHandle
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

    Private Sub GVSampleDel_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDel.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub FormSampleDel_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSampleDel_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class