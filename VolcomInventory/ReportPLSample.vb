Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportPLSample
    Public pl_sample_purc_number As String
    Public pl_sample_purc_date As String
    Public source As String
    Public comp_from As String
    Public comp_to As String
    Public address_to As String
    Public Shared id_pl_sample_purc As String
    Public pl_sample_purc_note As String

    Sub viewPLSample()
        Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        viewPLSample()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
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
        LabelRR.Text = data.Rows(0)("sample_purc_number").ToString
        LabelFrom.Text = data.Rows(0)("comp_name_from").ToString
        LabelTo.Text = data.Rows(0)("comp_name_to").ToString
        LabelAddress.Text = data.Rows(0)("comp_address_to").ToString
        LabelNo.Text = data.Rows(0)("pl_sample_purc_number").ToString
        Dim start_date_arr() As String = data.Rows(0)("pl_sample_purc_date").ToString.Split(" ")
        LabelDate.Text = start_date_arr(0)
        LabelSource.Text = data.Rows(0)("pl_category").ToString
        LabelNote.Text = data.Rows(0)("pl_sample_purc_note").ToString
        ' LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
    End Sub

    Private Sub ReportPLSample_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("3", id_pl_sample_purc, "2", "1", XrTable1)
    End Sub
End Class