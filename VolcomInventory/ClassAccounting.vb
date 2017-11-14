Public Class ClassAccounting
    Public Sub generateJournalSalesDraft(ByVal id_report_par As String, rmt As String)
        Dim query As String = "CALL generate_journal_sales_draft(" + id_report_par + "," + rmt + ")"
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub viewJournalSalesDraft()
        Dim query As String = "SELECT d.id_acc_trans_draft, d.id_acc, acc.acc_name, acc.acc_description, d.id_comp, d.debit, d.credit, d.id_currency, d.kurs, d.debit_valas, d.credit_valas, 
        d.acc_trans_det_note, d.report_mark_type, d.id_report, d.report_number, d.id_acc_src, d.id_status_open
        FROM tb_a_acc_trans_draft d
        INNER JOIN tb_a_acc acc ON acc.id_acc = d.id_acc
        WHERE d.id_acc_trans_draft>0 "
    End Sub
End Class