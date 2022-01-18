Public Class FormBankWithdrawalPPNTag
    Private Sub FormBankWithdrawalPPNTag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id_coa_tag As String = ""

        For i = 0 To FormBankWithdrawal.GVSummaryPPN.RowCount - 1
            id_coa_tag += FormBankWithdrawal.GVSummaryPPN.GetRowCellValue(i, "id_coa_tag").ToString + ", "
        Next

        id_coa_tag = id_coa_tag.Substring(0, id_coa_tag.Length - 2)

        Dim query As String = "SELECT id_coa_tag, tag_description AS tag FROM tb_coa_tag WHERE id_coa_tag IN (" + id_coa_tag + ")"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCTag.DataSource = data

        GVTag.BestFitColumns()
    End Sub

    Private Sub FormBankWithdrawalPPNTag_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GCTag_DoubleClick(sender As Object, e As EventArgs) Handles GCTag.DoubleClick
        FormBankWithdrawalDet.id_pay_type = "2"
        FormBankWithdrawalDet.report_mark_type = "293"
        FormBankWithdrawalDet.id_coa_tag = GVTag.GetFocusedRowCellValue("id_coa_tag").ToString
        FormBankWithdrawalDet.ShowDialog()

        Close()
    End Sub
End Class