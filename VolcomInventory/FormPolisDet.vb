Public Class FormPolisDet
    Public id_pps As String = "-1"
    Dim steps As Integer = "0"
    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        load_polis()
    End Sub

    Sub load_polis()
        If id_pps = "-1" Then 'new
            'yang belum di propose dan mau jatuh tempo
            Dim q As String = "SELECT 
p.id_polis AS old_id_polis,p.end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`,c.`id_comp`
,p.`nilai_stock` AS old_nilai_stock,p.`nilai_fit_out` AS old_nilai_fit_out,p.`nilai_peralatan` AS old_nilai_peralatan,p.`nilai_building` AS old_nilai_building,p.`nilai_public_liability` AS old_nilai_public_liability,p.`nilai_total` AS old_nilai_total,pol_by.`id_comp` AS old_id_vendor,pol_by.`comp_name` AS old_vendor,pd.`premi` AS old_premi
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
WHERE p.`is_active`=1 AND DATEDIFF(p.end_date,DATE(NOW()))<45 AND ISNULL(pps.id_polis_pps)"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                GCSummary.DataSource = dt
                BGVSummary.BestFitColumns()
                GridColumnAlamat.Width = 100
            End If
        Else

        End If
    End Sub

    Sub load_form()
        If Not id_pps = "-1" Then
            Dim q As String = "SELECT * FROM tb_polis_pps pps WHERE pps.id_polis_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                'load tab pertama
                BLoadPolis.Visible = False
                Dim qh As String = "
SELECT ppsd.old_id_polis,p.end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`,c.`id_comp`
,ppsd.old_nilai_stock,ppsd.old_nilai_fit_out,ppsd.old_nilai_peralatan,ppsd.old_nilai_building,ppsd.old_nilai_public_liability,ppsd.old_nilai_total
,pol_by.`id_comp` AS old_id_vendor,pol_by.`comp_name` AS old_vendor,ppsd.old_premi
,ppsd.old_id_polis_type
FROM tb_polis_pps_det ppsd
INNER JOIN tb_polis p ON p.`id_polis`=ppsd.`old_id_polis`
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_reff` AND p.`id_polis_cat`=1
INNER JOIN tb_m_comp pol_by ON pol_by.id_comp=p.id_polis_by
WHERE ppsd.id_polis_pps='" & id_pps & "'"
                Dim dth As DataTable = execute_query(qh, -1, True, "", "", "", "")
                GCSummary.DataSource = dth
                BGVSummary.BestFitColumns()
                'steps
                steps = dt.Rows(0)("step").ToString
                If steps = "1" Then
                    'isi nilai stok
                    XTPNilaiStock.PageVisible = True
                    XTPPenawaran.PageVisible = False
                    XTPDetail.PageVisible = False
                    BSaveDraft.Visible = True
                    '
                    XTCPolis.SelectedTabPageIndex = 1
                    '
                    load_nilai_stock()
                ElseIf steps = "2" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    XTPPenawaran.PageVisible = False
                    BSaveDraft.Visible = True

                    XTCPolis.SelectedTabPageIndex = 2
                    load_nilai_stock()
                    load_nilai_lainnya()
                ElseIf steps = "3" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    XTPPenawaran.PageVisible = True
                    BSaveDraft.Visible = True
                    '
                    view_vendor_penawaran()
                    '
                    XTCPolis.SelectedTabPageIndex = 3
                    load_nilai_stock()
                    load_nilai_lainnya()
                    load_nilai_penawaran()
                End If
            End If
        End If
    End Sub

    Sub view_vendor_penawaran()
        Dim q As String = "SELECT id_comp,comp_name,comp_number FROM tb_m_comp WHERE id_comp_cat='2' AND is_active=1"
        viewSearchLookupQuery(SLEPenawaranAdd, q, "id_comp", "comp_name", "id_comp")
        '
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaranDel, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_nilai_penawaran()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_pps & "'
GROUP BY ppsv.id_vendor"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        Dim qs As String = ""
        Dim qh As String = ""
        Dim qj As String = ""
        For i = 0 To dt.Rows.Count - 1
            'generate query
            qh += ",(tb_" & dt.Rows(i)("id_comp").ToString & ".price) AS vendor_" & dt.Rows(i)("comp_name").ToString & ""
            qj += "
LEFT JOIN 
(
	SELECT id_comp,price
	FROM `tb_polis_pps_vendor` 
	WHERE id_polis_pps='" & id_pps & "' AND id_vendor=" & dt.Rows(i)("id_comp").ToString & "
)tb_" & dt.Rows(i)("id_comp").ToString & " ON tb_" & dt.Rows(i)("id_comp").ToString & ".id_comp=ppsd.id_comp
"
        Next
        qs = "SELECT ppsd.id_polis_pps,ppsd.id_comp" & qh & "
FROM tb_polis_pps_det ppsd " & qj
    End Sub

    Sub load_nilai_lainnya()
        Dim q As String = "SELECT ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,c.`address_primary`,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.id_polis_pps='" & id_pps & "'
GROUP BY ppsd.`id_comp`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCNilaiLainnya.DataSource = dt
        GVNilaiLainnya.BestFitColumns()
    End Sub

    Sub load_nilai_stock()
        Dim q As String = "SELECT ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,c.`address_primary`,ppsd.`old_nilai_stock`,ppsd.`nilai_stock`
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.id_polis_pps='" & id_pps & "'
GROUP BY ppsd.`id_comp`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCNilaiStock.DataSource = dt
        GVNilaiStock.BestFitColumns()
    End Sub

    Private Sub FormPolisDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pps = "-1" Then
            XTPNilaiStock.PageVisible = False
            XTPPenawaran.PageVisible = False
            XTPDetail.PageVisible = False
            '
            BSaveDraft.Visible = False
        Else
            load_form()
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
            warningCustom("Please load polis first")
        Else
            If id_pps = "-1" Then
                Dim q As String = ""
                q = "INSERT INTO tb_polis_pps(`created_by`,`created_date`,`last_update_by`,`last_update_date`,`id_report_status`,`step`) VALUES('" & id_user & "',NOW(),'" & id_user & "',NOW(),'1','1'); SELECT LAST_INSERT_ID();"
                id_pps = execute_query(q, 0, True, "", "", "", "")
                q = "INSERT INTO tb_polis_pps_det(`id_polis_pps`,`id_comp`,`old_id_polis`,`old_nilai_stock`,`old_nilai_fit_out`,`old_nilai_building`,`old_nilai_peralatan`,`old_nilai_public_liability`,`old_nilai_total`,`old_polis_vendor`,`old_premi`) VALUES"
                For i = 0 To BGVSummary.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    q += "('" & id_pps & "','" & BGVSummary.GetRowCellValue(i, "id_comp") & "','" & BGVSummary.GetRowCellValue(i, "old_id_polis") & "'," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_stock").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_fit_out").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_building").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_peralatan").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_public_liability").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_total").ToString).ToString()) & ",'" & BGVSummary.GetRowCellValue(i, "old_id_vendor").ToString & "'," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_premi").ToString).ToString()) & ")"
                Next
                execute_non_query(q, True, "", "", "", "")
                load_form()
            Else
                If steps = "1" Then
                    'check all input
                    Dim is_ok As Boolean = True
                    GVNilaiStock.ActiveFilterString = "[nilai_stock]<=0"
                    If GVNilaiStock.RowCount > 0 Then
                        is_ok = False
                    End If
                    GVNilaiStock.ActiveFilterString = ""
                    '
                    If is_ok Then
                        'lanjut
                        If GVNilaiStock.RowCount > 0 Then
                            Dim q As String = ""
                            For i As Integer = 0 To GVNilaiStock.RowCount - 1
                                q += "UPDATE tb_polis_pps_det SET nilai_stock='" & decimalSQL(GVNilaiStock.GetRowCellValue(i, "nilai_stock").ToString) & "' WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVNilaiStock.GetRowCellValue(i, "id_comp").ToString & "';"
                            Next
                            execute_non_query(q, True, "", "", "", "")
                            q = "UPDATE tb_polis_pps SET step=2 WHERE id_polis_pps='" & id_pps & "'"
                            execute_non_query(q, True, "", "", "", "")
                            infoCustom("Nilai stok sudah tersubmit, menunggu proses selanjutnya.")
                            Close()
                        End If
                    Else
                        warningCustom("Pastikan nilai stock tidak ada yang 0")
                    End If
                ElseIf steps = "2" Then
                    'check all input
                    Dim is_ok As Boolean = True
                    GVNilaiLainnya.ActiveFilterString = "[nilai_total]<=0"
                    If GVNilaiLainnya.RowCount > 0 Then
                        is_ok = False
                    End If
                    GVNilaiLainnya.ActiveFilterString = ""
                    '
                    If is_ok Then
                        'lanjut
                        If GVNilaiLainnya.RowCount > 0 Then
                            Dim q As String = ""
                            For i As Integer = 0 To GVNilaiLainnya.RowCount - 1
                                q += "UPDATE tb_polis_pps_det SET nilai_fit_out='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_fit_out").ToString) & "'
,nilai_building='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_building").ToString) & "'
,nilai_peralatan='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_peralatan").ToString) & "'
,nilai_public_liability='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_public_liability").ToString) & "'
,nilai_total='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_total").ToString) & "'
WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVNilaiLainnya.GetRowCellValue(i, "id_comp").ToString & "';"
                            Next
                            execute_non_query(q, True, "", "", "", "")
                            q = "UPDATE tb_polis_pps SET step=3 WHERE id_polis_pps='" & id_pps & "'"
                            execute_non_query(q, True, "", "", "", "")
                            infoCustom("Nilai lainnya sudah tersubmit, menunggu proses selanjutnya.")
                            Close()
                        End If
                    Else
                        warningCustom("Pastikan nilai total tidak ada yang 0")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BSaveDraft_Click(sender As Object, e As EventArgs) Handles BSaveDraft.Click
        If steps = "1" Then
            If GVNilaiStock.RowCount > 0 Then
                Dim q As String = ""
                For i As Integer = 0 To GVNilaiStock.RowCount - 1
                    q += "UPDATE tb_polis_pps_det SET nilai_stock='" & decimalSQL(GVNilaiStock.GetRowCellValue(i, "nilai_stock").ToString) & "' WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVNilaiStock.GetRowCellValue(i, "id_comp").ToString & "';"
                Next
                execute_non_query(q, True, "", "", "", "")
                infoCustom("Draft saved.")
            End If
        ElseIf steps = "2" Then
            If GVNilaiLainnya.RowCount > 0 Then
                Dim q As String = ""
                For i As Integer = 0 To GVNilaiLainnya.RowCount - 1
                    q += "UPDATE tb_polis_pps_det SET nilai_fit_out='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_fit_out").ToString) & "'
,nilai_building='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_building").ToString) & "'
,nilai_peralatan='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_peralatan").ToString) & "'
,nilai_public_liability='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_public_liability").ToString) & "'
,nilai_total='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_total").ToString) & "' WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVNilaiLainnya.GetRowCellValue(i, "id_comp").ToString & "';"
                Next
                execute_non_query(q, True, "", "", "", "")
                infoCustom("Draft saved.")
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BRefreshPenawaran_Click(sender As Object, e As EventArgs) Handles BRefreshPenawaran.Click
        view_vendor_penawaran()
        load_nilai_penawaran()
    End Sub
End Class