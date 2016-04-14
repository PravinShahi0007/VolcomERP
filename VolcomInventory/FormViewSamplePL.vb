Public Class FormViewSamplePL
    Public action As String
    Public id_pl_sample_purc As String
    Public id_comp_contact_from As String
    Public id_comp_contact_to As String
    Public id_sample_purc_rec As String
    Dim code_list As New List(Of String)
    Dim id_sample_purc_rec_list As New List(Of String)
    Dim id_pl_sample_purc_det_list As New List(Of String)
    Dim id_pl_sample_purc_det_unique_list As New List(Of String)
    Dim test_old As String

    Private Sub FormViewSamplePL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPLCat() 'get PL Category
        viewReportStatus() 'get report status
        'Try
        'Enabled/disable form
        GConListPL.Enabled = True
        GroupControlDetailSingle.Enabled = True

        'Fetch from db main
        Dim query As String = "SELECT a.id_pl_sample_purc, a.id_sample_purc,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, g.sample_purc_number,b.pl_category, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from,(f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,(f.address_primary) AS comp_address_to, a.id_pl_category, a.id_report_status, g.sample_purc_number "
        query += "FROM tb_pl_sample_purc a "
        query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category  "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_sample_purc g ON g.id_sample_purc = a.id_sample_purc "
        query += "WHERE a.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtOrderNumber.Text = data.Rows(0)("sample_purc_number").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        TxtPLNumber.Text = data.Rows(0)("pl_sample_purc_number").ToString
        Dim start_date_arr() As String = data.Rows(0)("pl_sample_purc_date").ToString.Split(" ")
        DEPL.Text = start_date_arr(0)
        LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
        MENote.Text = data.Rows(0)("pl_sample_purc_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        'Fetch db detail
        viewPLSample()
        'Catch ex As Exception
        'errorConnection()
        'Close()
        ' End Try
    End Sub
    'View PL Sample
    Sub viewPLSample()
        Try
            Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                'id_sample_purc_rec_list.Add(data.Rows(i)("id_sample_purc_rec_det").ToString)
                id_pl_sample_purc_det_list.Add(data.Rows(i)("id_pl_sample_purc_det").ToString)
            Next
            GCListPurchase.DataSource = data
            viewPLUnique()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'View PL Unique
    Sub viewPLUnique()
        Try
            Dim query As String = "SELECT (CONCAT(d.sample_code, COALESCE(c.sample_unique_code, ''))) AS sample_unique_code, a.id_pl_sample_purc_det, a.id_pl_sample_purc_det_unique, a.id_sample_unique FROM tb_pl_sample_purc_det_unique a "
            query += "INNER JOIN tb_pl_sample_purc_det b ON a.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
            query += "INNER JOIN tb_m_sample_unique c ON a.id_sample_unique = c.id_sample_unique "
            query += "INNER JOIN tb_m_sample d ON d.id_sample = c.id_sample "
            'query += "INNER JOIN tb_pl_sample_purc_rec e ON e.id_pl_sample_purc_rec = b.id_pl_sample_purc_rec "
            query += "WHERE b.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                code_list.Add(data.Rows(i)("sample_unique_code").ToString)
                id_pl_sample_purc_det_unique_list.Add(data.Rows(i)("id_pl_sample_purc_det_unique").ToString)
            Next
            GCDetail.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_sample_purc
        FormReportMark.report_mark_type = "3"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class