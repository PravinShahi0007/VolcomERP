Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportSamplePlan
    Public Shared id_sample_plan As String = "-1"
    Public Shared id_comp_contact_to As String = "-1"

    Sub view_list_purchase()
        Dim query = "CALL view_plan_sample_det('" & id_sample_plan & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim query As String = "SELECT a.id_sample_plan,a.sample_plan_number,a.sample_plan_note,a.id_comp_contact_to,d.comp_name AS comp_name_to,a.id_season_orign,b.season_orign,a.sample_plan_date,DATE_FORMAT(a.sample_plan_date,'%d/%m/%y') AS date_view,a.id_report_status,e.report_status "
        query += "FROM tb_sample_plan a INNER JOIN tb_season_orign b ON a.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status e ON e.id_report_status = a.id_report_status "
        query += "WHERE a.id_sample_plan='" & id_sample_plan & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LRecNumber.Text = data.Rows(0)("sample_plan_number").ToString
        LNote.Text = data.Rows(0)("sample_plan_note").ToString

        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        LRecDate.Text = data.Rows(0)("date_view").ToString
        LToName.Text = get_company_x(get_id_company(id_comp_contact_to), "1")
        LToAddress.Text = get_company_x(get_id_company(id_comp_contact_to), "3")
        LToAttn.Text = get_company_contact_x(id_comp_contact_to, "1")

        LSeason.Text = get_season_orign_x(data.Rows(0)("id_season_orign").ToString, "1")
        view_list_purchase()

    End Sub

    Private Sub ReportSamplePlan_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("12", id_sample_plan, "2", "1", XrTable1)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class