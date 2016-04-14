Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportSampleReturnOut
    Public Shared id_sample_purc_ret_out As String
    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_out_sample('" + id_sample_purc_ret_out + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Try
            Dim query As String = "SELECT a.id_report_status, a.id_sample_purc, a.id_sample_purc_ret_out, a.sample_purc_ret_out_date, "
            query += "a.sample_purc_ret_out_due_date, a.sample_purc_ret_out_note, a.sample_purc_ret_out_number,  "
            query += "b.sample_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
            query += "FROM tb_sample_purc_ret_out a "
            query += "INNER JOIN tb_sample_purc b ON a.id_sample_purc = b.id_sample_purc "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "WHERE a.id_sample_purc_ret_out='" + id_sample_purc_ret_out + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LabelPO.Text = data.Rows(0)("sample_purc_number").ToString
            ' id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            'TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            LabelFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            'id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
            LabelTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            ' MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            Dim start_date_arr() As String = data.Rows(0)("sample_purc_ret_out_date").ToString.Split(" ")
            LabelDate.Text = start_date_arr(0).ToString
            Dim start_due_date_arr() As String = data.Rows(0)("sample_purc_ret_out_due_date").ToString.Split(" ")
            LabelDueDate.Text = start_due_date_arr(0).ToString
            LabelNo.Text = data.Rows(0)("sample_purc_ret_out_number").ToString
            LabelNote.Text = data.Rows(0)("sample_purc_ret_out_note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'Dim id_report_status = data.Rows(0)("id_report_status").ToString
            'id_sample_purc = data.Rows(0)("id_sample_purc").ToString
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Custom Column
    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        viewDetailReturn()
    End Sub
    Private Sub ReportSampleReturnOut_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("5", id_sample_purc_ret_out, "2", "1", XrTable1)
    End Sub
End Class