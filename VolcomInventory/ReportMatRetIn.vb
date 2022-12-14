Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatRetIn
    Public Shared id_mat_purc_ret_in As String
    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_in_mat('" + id_mat_purc_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Private Sub ReportMatRetIn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Dim query As String = "SELECT a.id_report_status, a.id_mat_purc, a.id_mat_purc_ret_in, a.mat_purc_ret_in_date, "
            query += "a.mat_purc_ret_in_note, a.mat_purc_ret_in_number,  "
            query += "b.mat_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
            query += "FROM tb_mat_purc_ret_in a "
            query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "WHERE a.id_mat_purc_ret_in='" + id_mat_purc_ret_in + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LabelPO.Text = data.Rows(0)("mat_purc_number").ToString
            ' id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            'TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            LabelFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            'id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
            LabelTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            ' MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            Dim start_date_arr() As String = data.Rows(0)("mat_purc_ret_in_date").ToString.Split(" ")
            LabelDate.Text = start_date_arr(0).ToString
            ' Dim start_due_date_arr() As String = data.Rows(0)("sample_purc_ret_in_due_date").ToString.Split(" ")
            'LabelDueDate.Text = start_due_date_arr(0).ToString
            LabelNo.Text = data.Rows(0)("mat_purc_ret_in_number").ToString
            LabelNote.Text = data.Rows(0)("mat_purc_ret_in_note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'Dim id_report_status = data.Rows(0)("id_report_status").ToString
            'id_sample_purc = data.Rows(0)("id_sample_purc").ToString
            viewDetailReturn()
            load_mark_horz("19", id_mat_purc_ret_in, "2", "1", XrTable1)
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
End Class