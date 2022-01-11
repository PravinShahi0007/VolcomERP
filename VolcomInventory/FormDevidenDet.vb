Public Class FormDevidenDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim is_load As Boolean = False

    Private Sub FormDevidenDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        is_load = True
        TEProfit.EditValue = 0
        TEDeviden.EditValue = 0
        TEDevidenPercent.EditValue = 0
        '
        DEDateReff.EditValue = Now
        DECreated.EditValue = Now
        '
        load_year()

        If id = "-1" Then

        Else
            SLEYear.Properties.ReadOnly = True
            TEDevidenPercent.Properties.ReadOnly = True
            TEDeviden.Properties.ReadOnly = True
            PCRecalculate.Visible = False
            '
            BtnSave.Visible = False
            BtnMark.Visible = True
            BtnPrint.Visible = True
            '
            'edit
            Dim q As String = "SELECT * FROM tb_deviden WHERE id_deviden='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLEYear.EditValue = dt.Rows(0)("profit_year").ToString
                '
                TEProfit.EditValue = dt.Rows(0)("profit_value")
                TEDeviden.EditValue = dt.Rows(0)("deviden_value")
                TEDevidenPercent.EditValue = dt.Rows(0)("profit_percent")
                '
                load_compare()
                load_share()
                '
                If dt.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                End If
            End If
        End If
        is_load = False
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
WHERE profit_year<'" & SLEYear.EditValue.ToString & "' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4)
UNION ALL
(SELECT '" & SLEYear.EditValue.ToString & "' AS `Year`," & decimalSQL(Decimal.Parse(TEProfit.EditValue.ToString)) & " AS `Net Profit`," & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & " AS `Deviden`," & decimalSQL(Decimal.Parse(TEDevidenPercent.EditValue.ToString)) & " AS `% From Profit`)
ORDER BY `Year`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCComparation.DataSource = dt
        GVComparation.BestFitColumns()
        'compare
        If id = "-1" Then
            q = "SELECT d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
FROM `tb_deviden_share` ds
INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden
INNER JOIN 
(
	SELECT profit_year FROM `tb_deviden` WHERE profit_year<'" & SLEYear.EditValue.ToString & "' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4
)dy ON dy.profit_year=d.profit_year
INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
UNION ALL
SELECT '" & SLEYear.EditValue.ToString & "' AS profit_year,sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_percent`,sh.`deviden_percent`,((100-sh.`pph_percent`)/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS deviden_amount,(sh.`pph_percent`/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS pph_amount
FROM tb_shareholder sh
INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`
UNION ALL
SELECT tb.profit_year,0 AS id_comp,'' AS comp_number,'' AS `pph_account`,'' AS pph_desc,'TOTAL' AS `comp_name`,0 AS `pph_percent`,0 AS deviden_percent,SUM(tb.deviden_amount) AS deviden_amount,SUM(tb.pph_amount) AS pph_amount
FROM
(
	SELECT d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
	FROM `tb_deviden_share` ds
	INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden
	INNER JOIN 
	(
		SELECT profit_year FROM `tb_deviden` WHERE profit_year<'" & SLEYear.EditValue.ToString & "' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4
	)dy ON dy.profit_year=d.profit_year
	INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
	LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
	UNION ALL
	SELECT '" & SLEYear.EditValue.ToString & "' AS profit_year,sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_percent`,sh.`deviden_percent`,((100-sh.`pph_percent`)/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS deviden_amount,(sh.`pph_percent`/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS pph_amount
	FROM tb_shareholder sh
	INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
	LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`
) tb
GROUP BY tb.profit_year
ORDER BY id_comp DESC,profit_year ASC"
        Else
            q = "SELECT d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
FROM `tb_deviden_share` ds
INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden
INNER JOIN 
(
	SELECT profit_year FROM `tb_deviden` WHERE profit_year<'" & SLEYear.EditValue.ToString & "' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4
)dy ON dy.profit_year=d.profit_year
INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
UNION ALL
SELECT '" & SLEYear.EditValue.ToString & "' AS profit_year,sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_percent`,sh.`deviden_percent`,sh.deviden_amount,sh.pph_amount
FROM tb_deviden_share sh
INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`
WHERE sh.id_deviden='" & id & "'
UNION ALL
SELECT tb.profit_year,0 AS id_comp,'' AS comp_number,'' AS `pph_account`,'' AS pph_desc,'TOTAL' AS `comp_name`,0 AS `pph_percent`,0 AS deviden_percent,SUM(tb.deviden_amount) AS deviden_amount,SUM(tb.pph_amount) AS pph_amount
FROM
(
	SELECT d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
	FROM `tb_deviden_share` ds
	INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden
	INNER JOIN 
	(
		SELECT profit_year FROM `tb_deviden` WHERE profit_year<'" & SLEYear.EditValue.ToString & "' AND id_report_status=6 ORDER BY profit_year DESC LIMIT 4
	)dy ON dy.profit_year=d.profit_year
	INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
	LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
	UNION ALL
	SELECT '" & SLEYear.EditValue.ToString & "' AS profit_year,sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_percent`,sh.`deviden_percent`,sh.deviden_amount,sh.pph_amount
	FROM tb_deviden_share sh
	INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
	LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`
    WHERE sh.id_deviden='" & id & "'
) tb
GROUP BY tb.profit_year
ORDER BY id_comp DESC,profit_year ASC"
        End If

        dt = execute_query(q, -1, True, "", "", "", "")
        GCHistory.DataSource = dt
        GVHistory.BestFitColumns()
        GVHistory.ExpandAllGroups()
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
            If Not is_load Then
                TEDeviden.EditValue = TEProfit.EditValue * (TEDevidenPercent.EditValue / 100)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TEDeviden_EditValueChanged(sender As Object, e As EventArgs) Handles TEDeviden.EditValueChanged
        Try
            If Not is_load Then
                TEDevidenPercent.EditValue = (TEDeviden.EditValue / TEProfit.EditValue) * 100
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        load_compare()
        load_share()
    End Sub

    Sub load_share()
        Dim q As String = ""

        If id = "-1" Then
            q = "SELECT sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_account`,sh.`pph_percent`,sh.`deviden_percent`,((100-sh.`pph_percent`)/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS deviden_amount,(sh.`pph_percent`/100)*((sh.`deviden_percent`/100)*" & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & ") AS pph_amount
FROM tb_shareholder sh
INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`"
        Else
            q = "SELECT sh.`id_comp`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,sh.`pph_account`,sh.`pph_percent`,sh.`deviden_percent`,sh.deviden_amount,sh.pph_amount
FROM tb_deviden_share sh
INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`
WHERE sh.id_deviden='" & id & "'"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCShareHolder.DataSource = dt
        GVShareHolder.BestFitColumns()
    End Sub

    Private Sub BVerify_Click(sender As Object, e As EventArgs) Handles BVerify.Click
        FormShareholder.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not GVShareHolder.RowCount > 0 Then
            warningCustom("Data is empty.")
        Else
            If id = "-1" Then
                'new
                Dim q As String = "INSERT INTO `tb_deviden`(profit_year,`profit_value`,`deviden_value`,`profit_percent`,`created_date`,`created_by`,`id_report_status`)
VALUES('" & SLEYear.EditValue.ToString & "'," & decimalSQL(Decimal.Parse(TEProfit.EditValue.ToString)) & "," & decimalSQL(Decimal.Parse(TEDeviden.EditValue.ToString)) & "," & decimalSQL(Decimal.Parse(TEDevidenPercent.EditValue.ToString)) & ",NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID(); "
                id = execute_query(q, 0, True, "", "", "", "")
                '
                q = "INSERT INTO `tb_deviden_share`(`id_deviden`,`id_comp`,`pph_account`,`pph_percent`,`deviden_percent`,`deviden_amount`,`pph_amount`) VALUES"
                For i = 0 To GVShareHolder.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVShareHolder.GetRowCellValue(i, "id_comp").ToString & "','" & GVShareHolder.GetRowCellValue(i, "pph_account").ToString & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "pph_percent").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "deviden_percent").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "deviden_amount").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "pph_amount").ToString).ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                submit_who_prepared("384", id, id_user)

                load_head()
            Else

            End If
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "384"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=384 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class