Public Class FormReportBalanceSheetTax
    Private Sub FormReportBalanceSheetTax_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If FormReportBalanceSheet.XTPTaxDetail.SelectedTabPageIndex = 0 Then
            FormReportBalanceSheet.GVTaxReport.RefreshData()
            FormReportBalanceSheet.GVTaxReport.ActiveFilterString = "[is_check] = 'yes'"
            FormReportBalanceSheet.GridColumnTaxCat.GroupIndex = -1
            '
            If FormReportBalanceSheet.GVTaxReport.RowCount > 0 Then
                For i As Integer = 0 To FormReportBalanceSheet.GVTaxReport.RowCount - 1
                    Dim q As String = "UPDATE tb_a_acc_trans SET date_tax_report='" & Date.Parse(DETaxMonth.EditValue.ToString).ToString("yyyy-MM-01") & "' WHERE id_acc_trans='" & FormReportBalanceSheet.GVTaxReport.GetRowCellValue(i, "id_acc_trans") & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next
                FormReportBalanceSheet.view_pajak()
            End If
            '
            FormReportBalanceSheet.GridColumnTaxCat.GroupIndex = 0
            FormReportBalanceSheet.GVTaxReport.ActiveFilterString = ""
            FormReportBalanceSheet.GVTaxReport.ExpandAllGroups()
            Close()
        Else
            FormReportBalanceSheet.GVActiveTax.RefreshData()
            FormReportBalanceSheet.GVActiveTax.ActiveFilterString = "[is_check] = 'yes'"
            FormReportBalanceSheet.GridColumnActiveTaxCat.GroupIndex = -1
            '
            If FormReportBalanceSheet.GVActiveTax.RowCount > 0 Then
                For i As Integer = 0 To FormReportBalanceSheet.GVActiveTax.RowCount - 1
                    Dim q As String = "UPDATE tb_a_acc_trans SET date_tax_report='" & Date.Parse(DETaxMonth.EditValue.ToString).ToString("yyyy-MM-01") & "' WHERE id_acc_trans='" & FormReportBalanceSheet.GVActiveTax.GetRowCellValue(i, "id_acc_trans") & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next
                FormReportBalanceSheet.view_pajak()
            End If
            '
            FormReportBalanceSheet.GridColumnActiveTaxCat.GroupIndex = 0
            FormReportBalanceSheet.GVActiveTax.ActiveFilterString = ""
            FormReportBalanceSheet.GVActiveTax.ExpandAllGroups()
            Close()
        End If
    End Sub

    Private Sub FormReportBalanceSheetTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = ""
        If FormReportBalanceSheet.SLETaxCat.Properties.View.GetFocusedRowCellValue("id_type").ToString = "2" Then
            'PPN
            q = "SELECT DATE_ADD(MAX(period_to),INTERVAL 1 DAY) AS min_date
FROM tb_tax_ppn_summary
WHERE id_report_status=6"
        Else
            'pph
            q = "SELECT DATE_ADD(MAX(period_to),INTERVAL 1 DAY) AS min_date
FROM tb_tax_pph_summary
WHERE id_report_status=6"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            DETaxMonth.Properties.MinValue = Date.Parse(dt.Rows(0)("min_date").ToString).ToString("yyyy-MM-dd")
        End If

        If FormReportBalanceSheet.DETaxFrom.EditValue > DETaxMonth.Properties.MinValue Then
            DETaxMonth.EditValue = FormReportBalanceSheet.DETaxFrom.EditValue
        Else
            DETaxMonth.EditValue = DETaxMonth.Properties.MinValue
        End If
    End Sub

    Private Sub BSetEmpty_Click(sender As Object, e As EventArgs) Handles BSetEmpty.Click
        If FormReportBalanceSheet.XTPTaxDetail.SelectedTabPageIndex = 0 Then
            FormReportBalanceSheet.GVTaxReport.RefreshData()
            FormReportBalanceSheet.GVTaxReport.ActiveFilterString = "[is_check] = 'yes'"
            FormReportBalanceSheet.GridColumnTaxCat.GroupIndex = -1
            '
            If FormReportBalanceSheet.GVTaxReport.RowCount > 0 Then
                For i As Integer = 0 To FormReportBalanceSheet.GVTaxReport.RowCount - 1
                    Dim q As String = "UPDATE tb_a_acc_trans SET date_tax_report=NULL WHERE id_acc_trans='" & FormReportBalanceSheet.GVTaxReport.GetRowCellValue(i, "id_acc_trans") & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next
                FormReportBalanceSheet.view_pajak()
            End If
            '
            FormReportBalanceSheet.GridColumnTaxCat.GroupIndex = 0
            FormReportBalanceSheet.GVTaxReport.ActiveFilterString = ""
            FormReportBalanceSheet.GVTaxReport.ExpandAllGroups()
            Close()
        Else
            FormReportBalanceSheet.GVActiveTax.RefreshData()
            FormReportBalanceSheet.GVActiveTax.ActiveFilterString = "[is_check] = 'yes'"
            FormReportBalanceSheet.GridColumnActiveTaxCat.GroupIndex = -1
            '
            If FormReportBalanceSheet.GVActiveTax.RowCount > 0 Then
                For i As Integer = 0 To FormReportBalanceSheet.GVActiveTax.RowCount - 1
                    Dim q As String = "UPDATE tb_a_acc_trans SET date_tax_report=NULL WHERE id_acc_trans='" & FormReportBalanceSheet.GVActiveTax.GetRowCellValue(i, "id_acc_trans") & "'"
                    execute_non_query(q, True, "", "", "", "")
                Next
                FormReportBalanceSheet.view_pajak()
            End If
            '
            FormReportBalanceSheet.GridColumnActiveTaxCat.GroupIndex = 0
            FormReportBalanceSheet.GVActiveTax.ActiveFilterString = ""
            FormReportBalanceSheet.GVActiveTax.ExpandAllGroups()
            Close()
        End If
    End Sub
End Class