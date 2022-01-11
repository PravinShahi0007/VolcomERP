Public Class FormDevidenDet
    Public id As String = "-1"

    Private Sub FormDevidenDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEProfit.EditValue = 0
        TEDeviden.EditValue = 0
        TEDevidenPercent.EditValue = 0
        '
        DEDateReff.EditValue = Now
        DECreated.EditValue = Now
        '
        load_year()
    End Sub

    Sub load_year()
        Dim q As String = "SELECT YEAR(date_until) AS yr FROM `tb_closing_log`
WHERE MONTH(date_until) = 12
GROUP BY YEAR(date_until)"
        viewSearchLookupQuery(SLEYear, q, "yr", "yr", "yr")
        SLEYear.EditValue = Nothing

        TEProfit.EditValue = 0
        TEDeviden.EditValue = 0
        TEDevidenPercent.EditValue = 0
    End Sub

    Private Sub SLEYear_EditValueChanged(sender As Object, e As EventArgs) Handles SLEYear.EditValueChanged
        load_profit()
    End Sub

    Sub load_compare()
        Dim q As String = "(SELECT profit_year AS `Year`,profit_value AS `Net Profit`,deviden_value AS `Deviden`,profit_percent AS `% From Profit`
FROM `tb_deviden`
WHERE profit_year<'2020' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4)
UNION ALL
(SELECT '" & SLEYear.EditValue.ToString & "' AS `Year`," & decimalSQL(Decimal.Parse(TEProfit.EditValue.ToString)) & " AS `Net Profit`," & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & " AS `Deviden`," & decimalSQL(Decimal.Parse(TEDevidenPercent.EditValue.ToString)) & " AS `% From Profit`)
ORDER BY `Year`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCComparation.DataSource = dt
        GVComparation.BestFitColumns()
    End Sub

    Sub load_profit()
        If Not SLEYear.EditValue = Nothing Then
            Dim q As String = "SELECT 
SUM(IF(acc.`id_dc`=1,(ad.`debit`-ad.`credit`),(ad.`credit`-ad.`debit`))) AS val
FROM tb_a_acc_trans_det ad
INNER JOIN tb_a_acc_trans a ON a.`id_acc_trans`=ad.`id_acc_trans`
INNER JOIN tb_a_acc acc ON acc.`id_acc`=ad.`id_acc` AND acc.`id_consolidation`=26
WHERE a.`id_report_status`=6 AND YEAR(a.`date_reference`)<='" & SLEYear.EditValue.ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEProfit.EditValue = dt.Rows(0)("val")
                'search prev year percentage
                Dim qs As String = "SELECT profit_percent
FROM `tb_deviden`
WHERE profit_year=(SELECT MAX(profit_year) FROM tb_deviden WHERE profit_year<'2021' AND id_report_status=6) "
                Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")

                TEDevidenPercent.EditValue = 0

                If dts.Rows.Count > 0 Then
                    TEDevidenPercent.EditValue = dts.Rows(0)("profit_percent")
                End If
            End If
        Else
            TEProfit.EditValue = 0
            TEDeviden.EditValue = 0
            TEDevidenPercent.EditValue = 0
        End If
        '-- ad.*,IF(acc.`id_dc`=1,(ad.`debit`-ad.`credit`),(ad.`credit`-ad.`debit`))
    End Sub

    Private Sub TEDevidenPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEDevidenPercent.EditValueChanged
        Try
            TEDeviden.EditValue = TEProfit.EditValue * (TEDevidenPercent.EditValue / 100)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TEDeviden_EditValueChanged(sender As Object, e As EventArgs) Handles TEDeviden.EditValueChanged
        Try
            TEDevidenPercent.EditValue = (TEDeviden.EditValue / TEProfit.EditValue) * 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        load_compare()
    End Sub
End Class