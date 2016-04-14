Public Class ReportFGStockOpnameStore
    Public Shared id_fg_so_store As String

    Sub viewDetail()
        Dim query As String = "CALL view_fg_so_store_sum('" + id_fg_so_store + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportFGStockOpnameStore_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = ""
        query += "SELECT so.fg_so_store_note, so.id_lock, so.id_fg_so_store, so.fg_so_store_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_store_date_created, '%Y-%m-%d') AS fg_so_store_date_created, "
        query += "DATE_FORMAT(so.fg_so_store_last_update, '%Y-%m-%d') AS fg_so_store_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_store_contact_from, (comp.id_comp) AS id_store_from, "
        query += "(comp.comp_number) AS store_number_from, (comp.comp_name) AS store_name_from, (comp.address_primary) AS store_address_from "
        query += "FROM tb_fg_so_store so "
        'query += "INNER JOIN tb_fg_so_store_det so_det ON so.id_fg_so_store = so_det.id_fg_so_store "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_store_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "WHERE so.id_fg_so_store = '" + id_fg_so_store + "' "
        query += "ORDER BY so.id_fg_so_store DESC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        LabelNo.Text = data.Rows(0)("fg_so_store_number").ToString
        LabelStore.Text = data.Rows(0)("store_number_from").ToString + " " + data.Rows(0)("store_name_from").ToString
        LabelDate.Text = view_date_from(data.Rows(0)("fg_so_store_date_created").ToString, 0)
        LabelLastUpdate.Text = view_date_from(data.Rows(0)("fg_so_store_last_update").ToString, 0)
        LabelNote.Text = data.Rows(0)("fg_so_store_note").ToString
        LabelAddress.Text = data.Rows(0)("store_address_from").ToString
        viewDetail()
        load_mark_horz("53", id_fg_so_store, "2", "1", XrTable1)
    End Sub
End Class