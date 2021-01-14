Public Class FormStockValas
    Private Sub FormStockValas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_valas()

        DEFrom.EditValue = Now
        DETo.EditValue = Now
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim q As String = "
(SELECT sv.id_stock_valas,cur.currency,CONCAT('Last Transaction : ',IFNULL(pn.number,'Input manual')) AS number,sv.id_report,sv.report_mark_type,sv.amount,sv.kurs_transaksi,sv.balance,sv.kurs_rata_rata,sv.trans_datetime
FROM `tb_stock_valas` sv
INNER JOIN tb_lookup_currency cur ON sv.id_currency=cur.id_currency
LEFT JOIN tb_pn pn ON pn.id_pn=sv.id_report AND sv.report_mark_type=159
WHERE sv.id_valas_bank='" & SLEAkunValas.EditValue.ToString & "' AND DATE(sv.trans_datetime)<'" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY sv.`id_stock_valas` DESC
LIMIT 1)
UNION ALL
(SELECT sv.id_stock_valas,cur.currency,IFNULL(pn.number,'Input manual') AS number,sv.id_report,sv.report_mark_type,sv.amount,sv.kurs_transaksi,sv.balance,sv.kurs_rata_rata,sv.trans_datetime
FROM `tb_stock_valas` sv
INNER JOIN tb_lookup_currency cur ON sv.id_currency=cur.id_currency
LEFT JOIN tb_pn pn ON pn.id_pn=sv.id_report AND sv.report_mark_type=159
WHERE sv.id_valas_bank='" & SLEAkunValas.EditValue.ToString & "' AND DATE(sv.trans_datetime)>='" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(sv.trans_datetime)<='" & Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") & "')"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStock.DataSource = dt
        GVStock.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        print(GCStock, "Stock Valas Periode (" & Date.Parse(DEFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(DETo.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
    End Sub

    Sub view_valas()
        Dim query As String = "SELECT id_valas_bank,valas_bank FROM tb_valas_bank
WHERE is_active=1"
        viewSearchLookupQuery(SLEAkunValas, query, "id_valas_bank", "valas_bank", "id_valas_bank")
    End Sub

    Private Sub FormStockValas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class