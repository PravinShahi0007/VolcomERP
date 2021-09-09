Public Class ReportDebitNote
    Public Shared id_report As String = "-1"
    Public Shared dt As DataTable
    Public Shared vendor As String = ""

    Private Sub ReportDebitNote_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        '
        Dim q As String = "SELECT GROUP_CONCAT(f.tot) AS rej_sum
FROM(
SELECT CONCAT(c.`pl_category`,' = ',ROUND(SUM(dnd.qty))) AS tot
FROM `tb_debit_note_det` dnd
INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note
INNER JOIN tb_prod_fc fc ON fc.id_prod_fc=dnd.id_reff
INNER JOIN tb_lookup_pl_category_sub s ON s.id_pl_category_sub=fc.id_pl_category_sub
INNER JOIN tb_lookup_pl_category c ON c.`id_pl_category`=s.`id_claim_group`
WHERE dn.id_debit_note='" & id_report & "' AND (dn.id_dn_type='1' OR dn.id_dn_type='4')
GROUP BY c.`id_pl_category`
) f"
        Dim dts As DataTable = execute_query(q, -1, True, "", "", "", "")
        LSummary.Text = dts.Rows(0)("rej_sum").ToString
        '
        pre_load_mark_horz("221", id_report, vendor, "2", XrTable1)
    End Sub
End Class