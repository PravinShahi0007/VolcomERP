Imports System.Collections.ObjectModel

Public Class FormWHCargoRateDet
    Public id_store As String = "-1"
    Public id_cargo As String = "-1"
    Public id_rate_type As String = "-1"

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub FormWHCargoRateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str_arr As String() = FormWHCargoRate.GVCompany.FocusedColumn.FieldName.ToString.Split("#"c)

        If str_arr(0) = "cargo_rate" Then
            TERate.Focus()
        ElseIf str_arr(0) = "cargo_lead_time" Then
            TERate.Focus()
        ElseIf str_arr(0) = "cargo_min_weight" Then
            TERate.Focus()
        End If
    End Sub

    Private Sub FormWHCargoRateDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BDeleteRate_Click(sender As Object, e As EventArgs) Handles BDeleteRate.Click
        Dim query As String = ""
        query = "DELETE FROM tb_wh_cargo_rate WHERE id_store='" + id_store + "' AND id_cargo='" + id_cargo + "'  AND id_rate_type='" + id_rate_type + "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Rate deleted.")
        If id_rate_type = "1" Then
            FormWHCargoRate.load_cargo_rate()
            FormWHCargoRate.GVCompany.FocusedRowHandle = find_row(FormWHCargoRate.GVCompany, "id_store", id_store)
        Else
            FormWHCargoRate.load_cargo_rate_in()
            FormWHCargoRate.GVCompanyIn.FocusedRowHandle = find_row(FormWHCargoRate.GVCompanyIn, "id_store", id_store)
        End If

        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        query = "DELETE FROM tb_wh_cargo_rate WHERE id_store='" + id_store + "' AND id_cargo='" + id_cargo + "' AND id_rate_type='" + id_rate_type + "'"
        execute_non_query(query, True, "", "", "", "")
        query = "INSERT INTO tb_wh_cargo_rate (id_store,id_cargo,id_rate_type,cargo_rate,cargo_lead_time,cargo_min_weight,cargo_rate_date) VALUES('" + id_store + "','" + id_cargo + "','" + id_rate_type + "','" + decimalSQL(TERate.EditValue.ToString) + "','" + decimalSQL(TELeadTime.EditValue.ToString) + "','" + decimalSQL(TEMinWeight.EditValue.ToString) + "',now())"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Rate saved.")
        '
        Dim find_string As String = ""
        Dim filter_string As String = ""
        Dim sort_out(FormWHCargoRate.GVCompany.Columns.Count, 2) As String
        Dim sort_in(FormWHCargoRate.GVCompanyIn.Columns.Count, 2) As String
        '
        If id_rate_type = "1" Then
            find_string = FormWHCargoRate.GVCompany.FindFilterText.ToString
            filter_string = FormWHCargoRate.GVCompany.ActiveFilterString
            'sorting
            For i As Integer = 0 To FormWHCargoRate.GVCompany.SortedColumns.Count - 1
                sort_out(i, 1) = FormWHCargoRate.GVCompany.SortedColumns.Item(i).FieldName
                If FormWHCargoRate.GVCompany.SortedColumns.Item(i).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                    sort_out(i, 2) = "1"
                Else
                    sort_out(i, 2) = "2"
                End If
            Next
            '
            FormWHCargoRate.load_cargo_rate()
            'sorting
            For i As Integer = 0 To FormWHCargoRate.GVCompany.Columns.Count.ToString
                If Not sort_out(i, 2) = "" Then
                    If sort_out(i, 2) = "1" Then
                        FormWHCargoRate.GVCompany.Columns(sort_out(i, 1)).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    Else
                        FormWHCargoRate.GVCompany.Columns(sort_out(i, 1)).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    End If

                End If
            Next
            '
            FormWHCargoRate.GVCompany.ApplyFindFilter(find_string)
            FormWHCargoRate.GVCompany.ActiveFilterString = filter_string

            FormWHCargoRate.GVCompany.FocusedRowHandle = find_row_as_is(FormWHCargoRate.GVCompany, "id_store", id_store)
        Else
            find_string = FormWHCargoRate.GVCompanyIn.FindFilterText.ToString
            filter_string = FormWHCargoRate.GVCompanyIn.ActiveFilterString
            'sorting
            For i As Integer = 0 To FormWHCargoRate.GVCompany.SortedColumns.Count - 1
                sort_out(i, 1) = FormWHCargoRate.GVCompany.SortedColumns.Item(i).FieldName
                If FormWHCargoRate.GVCompany.SortedColumns.Item(i).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                    sort_out(i, 2) = "1"
                Else
                    sort_out(i, 2) = "2"
                End If
            Next
            '
            FormWHCargoRate.load_cargo_rate_in()

            FormWHCargoRate.GVCompanyIn.ApplyFindFilter(find_string)
            FormWHCargoRate.GVCompanyIn.ActiveFilterString = filter_string

            FormWHCargoRate.GVCompanyIn.FocusedRowHandle = find_row_as_is(FormWHCargoRate.GVCompanyIn, "id_store", id_store)
        End If
        Close()
    End Sub
End Class