Public Class FormShareholder
    Private Sub FormShareholder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        load_vendor()
        reset_but()
        '
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT sh.`id_shareholder`,c.`id_comp`,c.`comp_name`,c.`comp_number`,sh.`pph_account`,IF(sh.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc
,sh.`pph_percent`,sh.`deviden_percent`
FROM `tb_shareholder` sh
INNER JOIN tb_m_comp c ON c.`id_comp`=sh.`id_comp`
LEFT JOIN tb_a_acc acc ON sh.`pph_account`=acc.`id_acc`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCShareHolder.DataSource = dt
        GVShareHolder.BestFitColumns()
    End Sub

    Sub reset_but()
        TESharePercent.EditValue = 0
        TEPPHPercent.EditValue = 0
        '
        SLECOA.EditValue = "0"
    End Sub

    Private Sub FormShareholder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCOA()
        Dim query As String = "
SELECT 0 AS id_acc,'No PPH' AS acc_desc,'No PPH' AS acc_name,'No PPH' AS acc_description
UNION ALL
SELECT a.id_acc, CONCAT(a.acc_name,' - ',a.acc_description) AS acc_desc,a.acc_name,a.acc_description
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc_desc", "id_acc")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.is_active='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVShareHolder.RowCount > 0 Then
            GVShareHolder.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If SLECOA.EditValue.ToString = "0" And TEPPHPercent.EditValue > 0 Then
            TEPPHPercent.EditValue = 0
        End If
        '
        If Not SLECOA.EditValue.ToString = "0" And TEPPHPercent.EditValue <= 0 Then
            warningCustom("Please set PPH percent")
        ElseIf TESharePercent.EditValue = 0 Then
            warningCustom("Please set share percent")
        Else
            Cursor = Cursors.WaitCursor
            GVShareHolder.AddNewRow()
            GVShareHolder.FocusedRowHandle = GVShareHolder.RowCount - 1
            '
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "id_comp", SLEVendor.EditValue.ToString)
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "comp_name", get_company_x(SLEVendor.EditValue.ToString, "1"))
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "comp_number", get_company_x(SLEVendor.EditValue.ToString, "2"))

            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "pph_account", SLECOA.EditValue.ToString)
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "pph_desc", SLECOA.Text)
            '
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "pph_percent", TEPPHPercent.EditValue)
            GVShareHolder.SetRowCellValue(GVShareHolder.RowCount - 1, "deviden_percent", TESharePercent.EditValue)

            GVShareHolder.BestFitColumns()
            Cursor = Cursors.Default

            GVShareHolder.RefreshData()

            reset_but()
        End If
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        If Not GVShareHolder.Columns("deviden_percent").SummaryItem.SummaryValue = 100 Then
            warningCustom("Share percent not 100%")
        Else
            Dim q As String = "DELETE FROM tb_shareholder"
            execute_non_query(q, True, "", "", "", "")
            '
            q = "INSERT INTO tb_shareholder(`id_comp`,`pph_account`,`pph_percent`,`deviden_percent`) VALUES"
            For i As Integer = 0 To GVShareHolder.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & GVShareHolder.GetRowCellValue(i, "id_comp").ToString & "','" & GVShareHolder.GetRowCellValue(i, "pph_account").ToString & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "pph_percent").ToString)) & "','" & decimalSQL(Decimal.Parse(GVShareHolder.GetRowCellValue(i, "deviden_percent").ToString)) & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
            Close()
        End If
    End Sub
End Class