Public Class FormViewSamplePlan
    Public id_sample_plan As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Private Sub FormViewSamplePlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason(LESeason)
        view_report_status(LEReportStatus)
        'edit
        Dim query As String = "SELECT a.id_sample_plan,a.sample_plan_number,a.sample_plan_note,a.id_comp_contact_to,d.comp_name AS comp_name_to,a.id_season_orign,b.season_orign,a.sample_plan_date,DATE_FORMAT(a.sample_plan_date,'%d/%m/%y') AS date_view,a.id_report_status,e.report_status "
        query += "FROM tb_sample_plan a INNER JOIN tb_season_orign b ON a.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status e ON e.id_report_status = a.id_report_status "
        query += "WHERE a.id_sample_plan='" & id_sample_plan & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_plan_number").ToString
        MENote.Text = data.Rows(0)("sample_plan_note").ToString

        LESeason.EditValue = data.Rows(0)("id_season_orign").ToString

        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        TEDate.Text = data.Rows(0)("date_view").ToString
        TECompName.Text = get_company_x(get_id_company(id_comp_contact_to), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_contact_to), "2")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_contact_to), "3")
        TECompAttn.Text = get_company_contact_x(id_comp_contact_to, "1")

        view_list_purchase()
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_plan_sample_det('" & id_sample_plan & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season_orign,season_orign FROM tb_season_orign ORDER BY id_season_orign DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_plan
        FormReportMark.report_mark_type = "12"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class