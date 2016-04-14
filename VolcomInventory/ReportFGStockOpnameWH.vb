Public Class ReportFGStockOpnameWH
    Public Shared id_fg_so_wh As String
    Public Shared dt As DataTable

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportFGStockOpnameWH_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = ""
        query += "SELECT so.fg_so_wh_note, so.id_lock, so.id_fg_so_wh, so.fg_so_wh_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_wh_date_created, '%Y-%m-%d') AS fg_so_wh_date_created, "
        query += "DATE_FORMAT(so.fg_so_wh_last_update, '%Y-%m-%d') AS fg_so_wh_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
        query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from, (comp.address_primary) AS comp_address_from "
        query += "FROM tb_fg_so_wh so "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "WHERE so.id_fg_so_wh = '" + id_fg_so_wh + "' "
        query += "ORDER BY so.id_fg_so_wh DESC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        LabelNo.Text = data.Rows(0)("fg_so_wh_number").ToString
        LabelStore.Text = data.Rows(0)("comp_number_from").ToString + " " + data.Rows(0)("comp_name_from").ToString
        LabelDate.Text = view_date_from(data.Rows(0)("fg_so_wh_date_created").ToString, 0)
        LabelLastUpdate.Text = view_date_from(data.Rows(0)("fg_so_wh_last_update").ToString, 0)
        LabelNote.Text = data.Rows(0)("fg_so_wh_note").ToString
        LabelAddress.Text = data.Rows(0)("comp_address_from").ToString

        GCItemList.DataSource = dt

        load_mark_horz("56", id_fg_so_wh, "2", "1", XrTable1)
    End Sub
End Class