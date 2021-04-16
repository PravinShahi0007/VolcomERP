Public Class FormPolisDet
    Dim id_pps As String = "-1"
    Dim steps As Integer = 1
    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        load_polis()
    End Sub

    Sub load_polis()
        If id_pps = "-1" Then 'new
            Dim q As String = "SELECT 
p.id_polis AS old_id_polis,p.end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`
,p.`nilai_stock` AS old_nilai_stock,p.`nilai_fit_out` AS old_nilai_fit_out,p.`nilai_peralatan` AS old_nilai_peralatan,p.`nilai_building` AS old_nilai_building,p.`nilai_public_liability` AS old_nilai_public_liability,p.`nilai_total` AS old_nilai_total,pol_by.`comp_name` AS old_vendor,pd.`premi` AS old_premi
,pd.description AS old_type
FROM tb_polis_det pd
INNER JOIN tb_polis p ON p.`id_polis`=pd.`id_polis`
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_reff` AND p.`id_polis_cat`=1
INNER JOIN tb_m_comp pol_by ON pol_by.id_comp=p.id_polis_by
LEFT JOIN 
(
    SELECT ppsd.`id_comp`,ppsd.`id_polis_pps`
    FROM `tb_polis_pps_det` ppsd
    INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND pps.`id_report_status`!=6 AND pps.`id_report_status`!=5
    GROUP BY ppsd.`id_comp`
)pps ON pps.id_comp=p.id_reff
WHERE p.`is_active`=1 AND DATEDIFF(p.end_date,DATE(NOW()))<45 AND ISNULL(pps.id_comp)"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                GCSummary.DataSource = dt
                BGVSummary.BestFitColumns()
                GridColumnAlamat.Width = 100
                '

            End If
        Else

        End If

    End Sub

    Sub load_nilai_stock()
        Dim q As String = "SELECT ppsd.`id_polis_pps_det`,ppsd.
FROM `tb_polis_pps_det` ppsd
WHERE ppsd.id_polis_pps='" & id_pps & "'"
    End Sub

    Private Sub FormPolisDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pps = "-1" Then
            XTPNilaiStock.PageVisible = False
            XTPPenawaran.PageVisible = False
            XTPDetail.PageVisible = False
        Else
            XTPNilaiStock.PageVisible = True
            XTPPenawaran.PageVisible = False
            XTPDetail.PageVisible = False
        End If
    End Sub

    Private Sub BGVSummary_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles BGVSummary.CellMerge
        If e.Column.FieldName = "comp_name" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "address_primary" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "comp_name" Or e.Column.FieldName = "old_nilai_stock" Or e.Column.FieldName = "old_nilai_fit_out" Or e.Column.FieldName = "old_nilai_peralatan" Or e.Column.FieldName = "old_nilai_building" Or e.Column.FieldName = "old_nilai_public_liability" Or e.Column.FieldName = "old_nilai_total" Or e.Column.FieldName = "old_vendor" Then
            If BGVSummary.GetRowCellValue(e.RowHandle1, "old_id_polis").ToString = BGVSummary.GetRowCellValue(e.RowHandle2, "old_id_polis").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BGVSummary.RowCount = 0 Then
            '
            warningCustom("Please load polis first")
        Else
            If id_pps = "-1" Then
                Dim q As String = ""
                q = "INSERT INTO tb_polis_pps(`created_by`,`created_date`,`last_update_by`,`last_update_date`,`id_report_status`,`step`) VALUES('" & id_user & "',NOW(),'" & id_user & "',NOW(),'1','1'); SELECT LAST_INSERT_ID();"
                id_pps = execute_query(q, 0, True, "", "", "", "")
                q = "INSERT INTO tb_polis_pps_det(`id_polis_pps`,`old_id_polis`,`old_nilai_stock`,`old_nilai_fit_out`,`old_nilai_building`,`old_nilai_peralatan`,`old_nilai_public_liability`,`old_nilai_total`,`old_polis_vendor`) VALUES"
                For i = 0 To BGVSummary.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    q += "('" & id_pps & "','" & BGVSummary.GetRowCellValue(i, "old_id_polis") & "'," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_stock").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_fit_out").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_building").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_peralatan").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_public_liability").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_total").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_vendor").ToString).ToString()) & ")"
                Next
                execute_non_query(q, True, "", "", "", "")
                load_polis()
            Else

            End If
        End If
    End Sub
End Class