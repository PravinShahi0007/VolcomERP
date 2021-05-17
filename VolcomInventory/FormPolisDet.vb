Public Class FormPolisDet
    Public id_pps As String = "-1"
    Dim steps As Integer = "0"
    Public is_view As String = "-1"
    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        load_polis()
    End Sub

    Sub load_polis()
        If id_pps = "-1" Then 'new
            'yang belum di propose dan mau jatuh tempo
            Dim q As String = "SELECT 
p.id_polis AS old_id_polis,p.end_date AS old_end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`,c.`id_comp`
,p.`nilai_stock` AS old_nilai_stock,p.`nilai_fit_out` AS old_nilai_fit_out,p.`nilai_peralatan` AS old_nilai_peralatan,p.`nilai_building` AS old_nilai_building,p.`nilai_public_liability` AS old_nilai_public_liability,p.`nilai_total` AS old_nilai_total,pol_by.`id_comp` AS old_id_vendor,pol_by.`comp_name` AS old_vendor
,SUM(pd.`premi`) AS old_premi
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
WHERE p.`is_active`=1 AND DATEDIFF(p.end_date,DATE(NOW()))<45 AND ISNULL(pps.id_polis_pps)
GROUP BY pd.id_polis"
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
                Dim qh As String = "SELECT ppsd.old_end_date,ppsd.old_id_polis,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`,c.`id_comp`
,ppsd.old_nilai_stock,ppsd.old_nilai_fit_out,ppsd.old_nilai_peralatan,ppsd.old_nilai_building,ppsd.old_nilai_public_liability,ppsd.old_nilai_total
,ppsd.nilai_stock,ppsd.nilai_fit_out,ppsd.nilai_peralatan,ppsd.nilai_building,ppsd.nilai_public_liability,ppsd.nilai_total
,pol_by.`id_comp` AS old_id_vendor,pol_by.`comp_name` AS old_vendor,ppsd.old_premi
,v.comp_name AS polis_vendor,ppsd.premi
FROM tb_polis_pps_det ppsd
LEFT JOIN tb_m_comp v ON v.id_comp=ppsd.polis_vendor
LEFT JOIN tb_polis p ON p.`id_polis`=ppsd.`old_id_polis`
LEFT JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp` 
LEFT JOIN tb_m_comp pol_by ON pol_by.id_comp=p.id_polis_by
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

                    XTCPolis.SelectedTabPageIndex = 3
                    load_nilai_stock()
                    load_nilai_lainnya()

                    view_vendor_penawaran()
                    load_nilai_penawaran()
                    load_nilai_penawaran()
                ElseIf steps = "4" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    XTPPenawaran.PageVisible = True
                    BSaveDraft.Visible = True
                    '

                    XTCPolis.SelectedTabPageIndex = 3
                    load_nilai_stock()
                    load_nilai_lainnya()

                    view_vendor_penawaran()
                    load_nilai_penawaran()
                    load_nilai_penawaran()
                    '
                    PCPenawaran.Visible = False
                    BtnPrint.Visible = True
                    BSaveDraft.Visible = False
                    BtnSave.Visible = False
                End If
            End If
        End If
    End Sub

    Sub view_vendor_penawaran()
        Dim q As String = "SELECT id_comp,comp_name,comp_number FROM tb_m_comp WHERE id_comp_cat='2' AND is_active=1
AND id_comp NOT IN (SELECT id_vendor FROM tb_polis_pps_vendor WHERE id_polis_pps='" & id_pps & "')"
        viewSearchLookupQuery(SLEPenawaranAdd, q, "id_comp", "comp_name", "id_comp")
        '
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaranDel, q, "id_comp", "comp_name", "id_comp")

        If SLEPenawaranDel.Text = "" Then
            SLEPenawaranDel.Visible = False
            BDelPenawaran.Visible = False
        Else
            SLEPenawaranDel.Visible = True
            BDelPenawaran.Visible = True
        End If
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
            qh += ",IFNULL(tb_" & dt.Rows(i)("id_comp").ToString & ".price,0) AS vendor_" & dt.Rows(i)("id_comp").ToString & ""
            qj += "
LEFT JOIN 
(
	SELECT id_comp,price
	FROM `tb_polis_pps_vendor` 
	WHERE id_polis_pps='" & id_pps & "' AND id_vendor=" & dt.Rows(i)("id_comp").ToString & "
)tb_" & dt.Rows(i)("id_comp").ToString & " ON tb_" & dt.Rows(i)("id_comp").ToString & ".id_comp=ppsd.id_comp
"
        Next

        qs = "SELECT ppsd.`id_comp`,pol.end_date,c.`comp_name`,c.`comp_number`,c.`address_primary`
,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`
,ppsd.old_nilai_total,ppsd.nilai_total,ppsd.old_premi,ppsd.old_polis_vendor,v_old.comp_name AS old_vendor
,ppsd.old_premi
,ppsd.polis_vendor,ppsd.premi,v.comp_name AS vendor
" & qh & "
FROM tb_polis_pps_det ppsd 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
LEFT JOIN tb_polis pol ON pol.id_polis=ppsd.old_id_polis
LEFT JOIN tb_m_comp v_old ON v_old.id_comp=ppsd.old_polis_vendor
LEFT JOIN tb_m_comp v ON v.id_comp=ppsd.polis_vendor
" & qj & "
GROUP BY ppsd.`id_comp`"

        dt = execute_query(qs, -1, True, "", "", "", "")

        'remove column
        For i = GVPenawaran.Columns.Count To 15 Step -1
            If i > 14 Then
                GVPenawaran.Columns.RemoveAt(i - 1)
            End If
        Next

        'add column
        For i = 0 To dt.Columns.Count - 1
            If dt.Columns(i).ColumnName.ToString.Contains("vendor_") Then
                'Dim col As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn
                'col.FieldName = dt.Columns(i).ColumnName.ToString
                'col.Caption = get_company_x(dt.Columns(i).ColumnName.ToString.Split("_")(1), "1")
                GVPenawaran.Columns.AddVisible(dt.Columns(i).ColumnName.ToString, get_company_x(dt.Columns(i).ColumnName.ToString.Split("_")(1), "1"))
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "N2"
            End If
        Next

        'add vendor dipilih
        GVPenawaran.Columns.AddVisible("vendor", "Vendor yang dipilih")
        GVPenawaran.Columns("vendor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GVPenawaran.Columns("vendor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVPenawaran.Columns("vendor").DisplayFormat.FormatString = "N2"
        '
        GVPenawaran.RefreshData()

        GCPenawaran.DataSource = dt
        GVPenawaran.BestFitColumns()
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

    'Private Sub BGVSummary_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles BGVSummary.CellMerge
    '    If e.Column.FieldName = "comp_name" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "address_primary" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "comp_name" Or e.Column.FieldName = "old_nilai_stock" Or e.Column.FieldName = "old_nilai_fit_out" Or e.Column.FieldName = "old_nilai_peralatan" Or e.Column.FieldName = "old_nilai_building" Or e.Column.FieldName = "old_nilai_public_liability" Or e.Column.FieldName = "old_nilai_total" Or e.Column.FieldName = "old_vendor" Then
    '        If BGVSummary.GetRowCellValue(e.RowHandle1, "old_id_polis").ToString = BGVSummary.GetRowCellValue(e.RowHandle2, "old_id_polis").ToString Then
    '            e.Merge = True
    '            e.Handled = True
    '        Else
    '            e.Merge = False
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If BGVSummary.RowCount = 0 Then
            warningCustom("Please load polis first")
        Else
            If id_pps = "-1" Then
                Dim q As String = ""
                q = "INSERT INTO tb_polis_pps(`created_by`,`created_date`,`last_update_by`,`last_update_date`,`id_report_status`,`step`) VALUES('" & id_user & "',NOW(),'" & id_user & "',NOW(),'1','1'); SELECT LAST_INSERT_ID();"
                id_pps = execute_query(q, 0, True, "", "", "", "")
                q = "INSERT INTO tb_polis_pps_det(`id_polis_pps`,`id_comp`,`old_id_polis`,`old_end_date`,`old_nilai_stock`,`old_nilai_fit_out`,`old_nilai_building`,`old_nilai_peralatan`,`old_nilai_public_liability`,`old_nilai_total`,`old_polis_vendor`,`old_premi`) VALUES"
                For i = 0 To BGVSummary.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    Dim old_polis As String = ""
                    Dim old_polis_vendor As String = ""

                    If BGVSummary.GetRowCellValue(i, "old_id_polis").ToString = "" Then
                        old_polis = "NULL"
                    Else
                        old_polis = "'" & BGVSummary.GetRowCellValue(i, "old_id_polis").ToString & "'"
                    End If

                    If BGVSummary.GetRowCellValue(i, "old_id_vendor").ToString = "" Then
                        old_polis_vendor = "NULL"
                    Else
                        old_polis_vendor = "'" & BGVSummary.GetRowCellValue(i, "old_id_vendor").ToString & "'"
                    End If

                    q += "('" & id_pps & "','" & BGVSummary.GetRowCellValue(i, "id_comp") & "'," & old_polis & ",'" & Date.Parse(BGVSummary.GetRowCellValue(i, "old_end_date").ToString).ToString("yyyy-MM-dd") & "'," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_stock").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_fit_out").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_building").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_peralatan").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_public_liability").ToString).ToString()) & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_nilai_total").ToString).ToString()) & "," & old_polis_vendor & "," & decimalSQL(Decimal.Parse(BGVSummary.GetRowCellValue(i, "old_premi").ToString).ToString()) & ")"
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
                ElseIf steps = "3" Then
                    save_draft_penawaran()
                    Dim is_ok As Boolean = True
                    Dim qc As String = "SELECT * FROM tb_polis_pps_det WHERE id_polis_pps='" & id_pps & "' AND (ISNULL(polis_vendor) or premi<=0)"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        is_ok = False
                    End If
                    If is_ok Then
                        'next step
                        Dim q As String = "UPDATE tb_polis_pps SET step=4 WHERE id_polis_pps='" & id_pps & "'"
                        execute_non_query(q, True, "", "", "", "")
                        'mark
                        submit_who_prepared("307", id_pps, id_user)
                        infoCustom("Penawaran disubmit, menunggu persetujuan.")
                        Close()
                    Else
                        warningCustom("Pastikan semua memiliki vendor yang dipilih dan memiliki penawaran harga")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BSaveDraft_Click(sender As Object, e As EventArgs) Handles BSaveDraft.Click
        If steps = "1" Then 'nilai stok
            If GVNilaiStock.RowCount > 0 Then
                Dim q As String = ""
                For i As Integer = 0 To GVNilaiStock.RowCount - 1
                    q += "UPDATE tb_polis_pps_det SET nilai_stock='" & decimalSQL(GVNilaiStock.GetRowCellValue(i, "nilai_stock").ToString) & "' WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVNilaiStock.GetRowCellValue(i, "id_comp").ToString & "';"
                Next
                execute_non_query(q, True, "", "", "", "")
                infoCustom("Draft saved.")
            End If
        ElseIf steps = "2" Then 'nilai lain
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
        ElseIf steps = "3" Then 'nilai penawaran
            If GVPenawaran.RowCount > 0 And GVPenawaran.Columns.Count > 15 Then
                save_draft_penawaran()

                infoCustom("Draft saved.")
            End If
        End If
    End Sub

    Sub save_draft_penawaran()
        Dim q As String = ""
        'loop per vendor
        For j = 14 To GVPenawaran.Columns.Count - 2 'ada vendor dipilih terakhir
            Dim id_vendor As String = GVPenawaran.Columns(j).FieldName.ToString.Split("_")(1)
            execute_non_query("DELETE FROM tb_polis_pps_vendor WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & id_vendor & "'", True, "", "", "", "")
            '
            q = "INSERT INTO tb_polis_pps_vendor(id_polis_pps,id_comp,id_vendor,price) VALUES "
            For i As Integer = 0 To GVPenawaran.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id_pps & "','" & GVPenawaran.GetRowCellValue(i, "id_comp").ToString & "','" & id_vendor & "','" & decimalSQL(Decimal.Parse(GVPenawaran.GetRowCellValue(i, GVPenawaran.Columns(j).FieldName.ToString).ToString)) & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
            '
            q = "UPDATE tb_polis_pps_det ppsd
INNER JOIN tb_polis_pps_vendor ppsv ON ppsd.polis_vendor=ppsv.id_vendor AND ppsd.id_polis_pps=ppsv.id_polis_pps AND ppsd.id_comp=ppsv.id_comp
SET ppsd.premi=ppsv.price
WHERE ppsd.id_polis_pps='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
        Next
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BRefreshPenawaran_Click(sender As Object, e As EventArgs) Handles BRefreshPenawaran.Click
        view_vendor_penawaran()
        load_nilai_penawaran()
    End Sub

    Private Sub BAddPenawaran_Click(sender As Object, e As EventArgs) Handles BAddPenawaran.Click
        'confirm first
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to add " & SLEPenawaranAdd.Text & " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            'add to database first row as 0
            Dim q As String = "INSERT INTO tb_polis_pps_vendor(id_polis_pps,id_comp,id_vendor,price) VALUES('" & id_pps & "','" & Decimal.Parse(GVPenawaran.GetRowCellValue(0, "id_comp").ToString) & "','" & SLEPenawaranAdd.EditValue.ToString & "','0.00')"
            execute_non_query(q, True, "", "", "", "")
            'refresh
            view_vendor_penawaran()
            load_nilai_penawaran()
        End If
    End Sub

    Private Sub BDelPenawaran_Click(sender As Object, e As EventArgs) Handles BDelPenawaran.Click
        'confirm first
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to drop " & SLEPenawaranDel.Text & " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            'delete
            Dim q As String = "DELETE FROM tb_polis_pps_vendor WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & SLEPenawaranDel.EditValue.ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "UPDATE tb_polis_pps_det SET polis_vendor=NULL WHERE id_polis_pps='" & id_pps & "' AND polis_vendor='" & SLEPenawaranDel.EditValue.ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            'refresh
            view_vendor_penawaran()
            load_nilai_penawaran()
        End If
    End Sub

    Private Sub PilihVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PilihVendorToolStripMenuItem.Click
        If GVPenawaran.RowCount > 0 Then
            If GVPenawaran.FocusedColumn.AbsoluteIndex > 13 Then
                save_draft_penawaran()

                Dim id_vendor As String = GVPenawaran.FocusedColumn.FieldName.ToString.Split("_")(1)
                Dim qu As String = "UPDATE tb_polis_pps_det SET polis_vendor='" & id_vendor & "',premi='" & decimalSQL(Decimal.Parse(GVPenawaran.GetFocusedRowCellValue(GVPenawaran.FocusedColumn.FieldName).ToString)) & "' WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVPenawaran.GetFocusedRowCellValue("id_comp").ToString & "'"
                execute_non_query(qu, True, "", "", "", "")
                load_nilai_penawaran()
            Else
                MsgBox("Please pick on vendor column")
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ReportPolis.dt = GCPenawaran.DataSource
        ReportPolis.id_pps = id_pps
        Dim Report As New ReportPolis()
        '
        Dim q As String = "SELECT created_date,created_by,YEAR(created_date) AS this_year FROM tb_polis_pps WHERE id_polis_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        Report.DataSource = dt
        '
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "307"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_pps
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If BGVSummary.RowCount > 0 Then
            BGVSummary.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormPolisDetAdd.ShowDialog()
    End Sub
End Class