Imports DevExpress.XtraEditors

Module Viewing
    '-- SAMPLE Mens or Girls or Youth --'
    Sub _view_division(ByVal SLE As LookUpEdit)
        Dim id_code As String = get_setup_field("id_code_sample_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "code_detail_name", "id_code_detail")
    End Sub

    Sub _view_division_fg(ByVal SLE As LookUpEdit)
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub _view_class_fg(ByVal SLE As LookUpEdit)
        Dim id_code As String = get_setup_field("id_code_fg_class")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub _view_source_fg(ByVal SLE As LookUpEdit)
        Dim id_code As String = get_setup_field("id_code_fg_source")
        Dim query As String = "SELECT (id_code_detail) AS id_source, (code_detail_name) AS source, display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "display_name", "id_source")
    End Sub

    Sub _view_rec_note(ByVal SLE As LookUpEdit)
        Dim query As String = "SELECT * FROM tb_lookup_rec_note a ORDER BY a.id_rec_note ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(SLE, query, 0, "rec_note", "id_rec_note")
    End Sub
End Module
