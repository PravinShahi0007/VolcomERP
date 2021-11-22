﻿Public Class ReportFGAdjIn
    Public Shared id_adj_in_fg As String
    Dim currency As String
    Public is_pre As String = "2"
    Public report_mark_type As String = ""
    Private Sub ReportFGAdjIn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'Fetch from db main
        Dim query As String = "SELECT *, DATE_FORMAT(a.adj_in_fg_date, '%Y-%m-%d') AS adj_in_fg_datex FROM tb_adj_in_fg a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_lookup_adj_type t ON a.id_adj_type = t.id_adj_type "
        query += "WHERE a.id_adj_in_fg = '" + id_adj_in_fg + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''tampung ke form
        LabelNo.Text = data.Rows(0)("adj_in_fg_number").ToString
        LabelDate.Text = view_date_from(data.Rows(0)("adj_in_fg_datex").ToString, 0)
        LabelNote.Text = data.Rows(0)("adj_in_fg_note").ToString
        currency = data.Rows(0)("currency").ToString
        currency = data.Rows(0)("currency").ToString
        XLType.Text = data.Rows(0)("adj_type").ToString

        'Detail
        viewDetailReturn()

        'Mark
        pre_load_mark_horz_check(report_mark_type, id_adj_in_fg, "2", "2", XrTable1)


    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_fg_adj_in('" + id_adj_in_fg + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.Columns("adj_in_fg_det_amount").SummaryItem.DisplayFormat = " {0:n2} "
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class