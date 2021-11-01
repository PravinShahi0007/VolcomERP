Imports System.Data.OleDb

Public Class FormPolisDet
    Public id_pps As String = "-1"
    Dim steps As Integer = "0"
    Public is_view As String = "-1"

    Public is_perpanjangan As String = "-1"

    Dim copy_file_path As String = ""

    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        load_polis()
    End Sub

    Sub load_polis()
        If id_pps = "-1" Then 'new
            'yang belum di propose dan mau jatuh tempo
            Dim q As String = "SELECT 
p.id_polis AS old_id_polis,p.end_date AS old_end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`,c.`id_comp`
,p.`nilai_stock` AS old_nilai_stock,p.`nilai_fit_out` AS old_nilai_fit_out,p.`nilai_peralatan` AS old_nilai_peralatan,p.`nilai_building` AS old_nilai_building,p.`nilai_public_liability` AS old_nilai_public_liability,p.`nilai_total` AS old_nilai_total,pol_by.`id_comp` AS old_id_vendor,pol_by.`comp_name` AS old_vendor
,SUM(p.`premi`) AS old_premi
FROM tb_polis p
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_reff` AND p.`id_polis_cat`=1
INNER JOIN tb_m_comp pol_by ON pol_by.id_comp=p.id_polis_by
LEFT JOIN
(
    SELECT ppsd.`id_comp`,ppsd.`id_polis_pps`
    FROM `tb_polis_pps_det` ppsd
    INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND pps.`id_report_status`!=6 AND pps.`id_report_status`!=5
    GROUP BY ppsd.`id_comp`
)pps ON pps.id_comp=p.id_reff
WHERE p.`is_active`=1 AND DATEDIFF(p.end_date,DATE(NOW()))<45 AND ISNULL(pps.id_polis_pps) AND p.id_desc_premi = '" + SLEPolisType.EditValue.ToString + "'
GROUP BY p.id_polis"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSummary.DataSource = Nothing
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
            Dim q As String = "SELECT pps.*,emp.employee_name FROM tb_polis_pps pps 
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE pps.id_polis_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                'head
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                '
                SLEPPSType.EditValue = dt.Rows(0)("id_pps_type").ToString
                SLEPolisType.EditValue = dt.Rows(0)("id_desc_premi").ToString
                DEStart.EditValue = dt.Rows(0)("start_polis").ToString
                DEUntil.EditValue = dt.Rows(0)("end_polis").ToString
                '
                SLEPPSType.Properties.ReadOnly = True
                SLEPolisType.Properties.ReadOnly = True
                DEStart.Properties.ReadOnly = True
                DEUntil.Properties.ReadOnly = True
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
                    XTPVendor.PageVisible = False
                    XTPDetail.PageVisible = False
                    BSaveDraft.Visible = True
                    '
                    XTCPolis.SelectedTabPageIndex = 1
                    '
                    load_nilai_stock()

                    PCNilaiLain.Visible = False
                    PCNilaiStock.Visible = True
                ElseIf steps = "2" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    XTPPenawaran.PageVisible = False
                    XTPVendor.PageVisible = False
                    BSaveDraft.Visible = True

                    XTCPolis.SelectedTabPageIndex = 2
                    load_nilai_stock()
                    load_nilai_lainnya()

                    PCNilaiLain.Visible = True
                    PCNilaiStock.Visible = False
                ElseIf steps = "3" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    BSaveDraft.Visible = True
                    '
                    If SLEPPSType.EditValue.ToString = "1" Then
                        'kolektif
                        XTPPenawaran.PageVisible = False
                        XTPVendor.PageVisible = True
                        '
                        XTCPolis.SelectedTabPageIndex = 3
                        load_nilai_stock()
                        load_nilai_lainnya()
                        '
                        load_nilai_penawaran_kolektif()
                        view_vendor_penawaran_kolektif()
                    Else
                        'mandiri
                        XTPPenawaran.PageVisible = True
                        XTPVendor.PageVisible = False
                        '
                        XTCPolis.SelectedTabPageIndex = 4
                        load_nilai_stock()
                        load_nilai_lainnya()
                        '
                        view_vendor_penawaran()
                        load_nilai_penawaran()
                        load_nilai_penawaran()
                    End If

                    PCNilaiLain.Visible = False
                    PCNilaiStock.Visible = False
                ElseIf steps = "4" Then
                    XTPNilaiStock.PageVisible = True
                    XTPDetail.PageVisible = True
                    XTPPenawaran.PageVisible = True
                    BSaveDraft.Visible = True
                    '
                    If SLEPPSType.EditValue.ToString = "1" Then
                        'kolektif
                        XTPPenawaran.PageVisible = False
                        XTPVendor.PageVisible = True
                        '
                        XTCPolis.SelectedTabPageIndex = 3
                        load_nilai_stock()
                        load_nilai_lainnya()

                        load_nilai_penawaran_kolektif()
                        view_vendor_penawaran_kolektif()
                        PCPenawaranKolektif.Visible = False
                    Else
                        'mandiri
                        XTPPenawaran.PageVisible = True
                        XTPVendor.PageVisible = False
                        '
                        XTCPolis.SelectedTabPageIndex = 4
                        load_nilai_stock()
                        load_nilai_lainnya()

                        view_vendor_penawaran()
                        load_nilai_penawaran()
                        load_nilai_penawaran()
                        PCPenawaran.Visible = False
                    End If
                    '
                    BtnPrint.Visible = True
                    BSaveDraft.Visible = False
                    BtnSave.Visible = False

                    PCNilaiLain.Visible = False
                    PCNilaiStock.Visible = False
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
            BSetVendorDipilih.Visible = False
            BGetExcel.Visible = False
            BUploadExcel.Visible = False
        Else
            SLEPenawaranDel.Visible = True
            BDelPenawaran.Visible = True
            BSetVendorDipilih.Visible = True
            BGetExcel.Visible = True
            BUploadExcel.Visible = True
        End If
    End Sub

    Sub view_vendor_penawaran_kolektif()
        Dim q As String = "SELECT id_comp,comp_name,comp_number FROM tb_m_comp WHERE id_comp_cat='2' AND is_active=1
AND id_comp NOT IN (SELECT id_vendor FROM tb_polis_pps_vendor WHERE id_polis_pps='" & id_pps & "')"
        viewSearchLookupQuery(SLEPenawaranAddKolektif, q, "id_comp", "comp_name", "id_comp")

        If GVPenawaranKolektif.RowCount > 0 Then
            BDelPenawaranKolektif.Visible = True
        Else
            BDelPenawaranKolektif.Visible = False
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

        qs = "SELECT 'no' AS is_check,ppsd.`id_comp`,ppsd.old_end_date,c.`comp_name`,c.`comp_number`,c.`address_primary`
,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`
,ppsd.old_nilai_total,ppsd.nilai_total,ppsd.old_premi,ppsd.old_polis_vendor,v_old.comp_name AS old_vendor
,ppsd.old_premi
,ppsd.polis_vendor,ppsd.premi,v.comp_name AS vendor
,ppsd.v_start_date,ppsd.v_end_date
" & qh & "
FROM tb_polis_pps_det ppsd 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
LEFT JOIN tb_polis pol ON pol.id_polis=ppsd.old_id_polis
LEFT JOIN tb_m_comp v_old ON v_old.id_comp=ppsd.old_polis_vendor
LEFT JOIN tb_m_comp v ON v.id_comp=ppsd.polis_vendor
" & qj & "
WHERE ppsd.id_polis_pps='" & id_pps & "'
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
        'GVPenawaran.Columns.AddVisible("vendor", "Vendor yang dipilih")
        'GVPenawaran.Columns("vendor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'GVPenawaran.Columns("vendor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'GVPenawaran.Columns("vendor").DisplayFormat.FormatString = "N2"
        'GVPenawaran.Columns("vendor").OptionsColumn.AllowFocus = False
        'GVPenawaran.Columns("vendor").OptionsColumn.ReadOnly = True
        'GVPenawaran.Columns("vendor").OptionsColumn.AllowEdit = False
        '
        GVPenawaran.RefreshData()

        GCPenawaran.DataSource = dt
        GVPenawaran.BestFitColumns()
    End Sub

    Sub load_nilai_penawaran_kolektif()
        Dim q As String = "SELECT ppsv.id_vendor,c.comp_number,c.comp_name,ppsv.price,ppsv.is_recommended
FROM tb_polis_pps_kolektif ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_pps & "'
GROUP BY ppsv.id_vendor"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCPenawaranKolektif.DataSource = dt
        GVPenawaranKolektif.BestFitColumns()
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
        load_pps_type()
        load_polis_type()

        DEStart.EditValue = Now
        DEUntil.EditValue = Now

        If id_pps = "-1" Then
            XTPNilaiStock.PageVisible = False
            XTPPenawaran.PageVisible = False
            XTPVendor.PageVisible = False
            XTPDetail.PageVisible = False
            '
            BSaveDraft.Visible = False
            gridBandNewValue.Visible = False
            '
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
WHERE ppsd.id_polis_pps='-1'"
            Dim dth As DataTable = execute_query(qh, -1, True, "", "", "", "")
            GCSummary.DataSource = dth
            '
        Else
            gridBandNewValue.Visible = True
            load_form()
        End If
    End Sub

    Sub load_pps_type()
        Dim q As String = "SELECT 1 AS id_pps_type,'Kolektif' AS pps_type
UNION ALL
SELECT 2 AS id_pps_type,'Mandiri' AS pps_type"
        viewSearchLookupQuery(SLEPPSType, q, "id_pps_type", "pps_type", "id_pps_type")
    End Sub

    Sub load_polis_type()
        Dim q As String = "SELECT id_desc_premi,description FROM tb_lookup_desc_premi WHERE is_active=1"
        viewSearchLookupQuery(SLEPolisType, q, "id_desc_premi", "description", "id_desc_premi")
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
            warningCustom("Please add store")
        Else
            If id_pps = "-1" Then
                If SLEPPSType.EditValue.ToString = "1" And BGVSummary.RowCount < 2 Then
                    warningCustom("Please add more store")
                Else
                    Dim q As String = ""
                    q = "INSERT INTO tb_polis_pps(`created_by`,`created_date`,`last_update_by`,`last_update_date`,`id_report_status`,id_desc_premi,id_pps_type,start_polis,end_polis,`step`) VALUES('" & id_user & "',NOW(),'" & id_user & "',NOW(),'1','" & SLEPolisType.EditValue.ToString & "','" & SLEPPSType.EditValue.ToString & "','" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "','1'); SELECT LAST_INSERT_ID();"
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
                    '
                    q = "CALL gen_number('" & id_pps & "','307')"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    load_form()
                End If
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
                            load_form()
                            'infoCustom("Nilai stok sudah tersubmit, menunggu proses selanjutnya.")
                            'Close()
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
                                q += "UPDATE tb_polis_pps_det ppsd
INNER JOIN
tb_polis_pps pps ON pps.id_polis_pps=ppsd.id_polis_pps
SET ppsd.nilai_fit_out='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_fit_out").ToString) & "'
,ppsd.nilai_building='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_building").ToString) & "'
,ppsd.nilai_peralatan='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_peralatan").ToString) & "'
,ppsd.nilai_public_liability='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_public_liability").ToString) & "'
,ppsd.nilai_total='" & decimalSQL(GVNilaiLainnya.GetRowCellValue(i, "nilai_total").ToString) & "'
,ppsd.v_start_date=IF(pps.`id_pps_type`=2,DATE_ADD(ppsd.old_end_date,INTERVAL 1 DAY),'" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "'),ppsd.v_end_date=IF(pps.`id_pps_type`=2,DATE_ADD(DATE_ADD(ppsd.old_end_date,INTERVAL 1 YEAR),INTERVAL 1 DAY),'" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
WHERE ppsd.id_polis_pps='" & id_pps & "' AND ppsd.id_comp='" & GVNilaiLainnya.GetRowCellValue(i, "id_comp").ToString & "';"
                            Next
                            execute_non_query(q, True, "", "", "", "")
                            q = "UPDATE tb_polis_pps SET step=3 WHERE id_polis_pps='" & id_pps & "'"
                            execute_non_query(q, True, "", "", "", "")
                            'infoCustom("Nilai lainnya sudah tersubmit, menunggu proses selanjutnya.")
                            'Close()
                            load_form()
                        End If
                    Else
                        warningCustom("Pastikan nilai total tidak ada yang 0")
                    End If
                ElseIf steps = "3" Then
                    If SLEPPSType.EditValue.ToString = "1" Then
                        'kolektif
                        save_draft_penawaran_kolektif()
                        Dim is_ok As Boolean = True
                        Dim qc As String = "SELECT * FROM tb_polis_pps_kolektif WHERE id_polis_pps='" & id_pps & "' AND  price<=0"
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
                    Else
                        'mandiri
                        save_draft_penawaran()
                        Dim is_ok As Boolean = True

                        Dim qc As String = "SELECT * FROM tb_polis_pps_vendor WHERE id_polis_pps = '" + id_pps + "' AND price <= 0"
                        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                        If dtc.Rows.Count > 0 Then
                            is_ok = False
                        End If

                        'Dim qc As String = "SELECT * FROM tb_polis_pps_det WHERE id_polis_pps='" & id_pps & "' AND (ISNULL(polis_vendor) or premi<=0)"
                        'Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                        'If dtc.Rows.Count > 0 Then
                        '    is_ok = False
                        'End If

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
            If SLEPPSType.EditValue.ToString = "1" Then
                save_draft_penawaran_kolektif()

                infoCustom("Draft saved.")
            Else
                'mandiri
                If GVPenawaran.RowCount > 0 And GVPenawaran.Columns.Count > 15 Then
                    save_draft_penawaran()

                    infoCustom("Draft saved.")
                End If
            End If
        End If
    End Sub

    Sub save_draft_penawaran_kolektif()
        If GVPenawaranKolektif.RowCount > 0 Then
            For i As Integer = 0 To GVPenawaranKolektif.RowCount - 1
                Dim qa As String = "UPDATE tb_polis_pps_kolektif SET price='" & decimalSQL(Decimal.Parse(GVPenawaranKolektif.GetRowCellValue(i, "price").ToString).ToString) & "' WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & GVPenawaranKolektif.GetRowCellValue(i, "id_vendor").ToString & "'"
                execute_non_query(qa, True, "", "", "", "")


            Next

            Dim q As String = "UPDATE tb_polis_pps_kolektif SET is_recommended=2 WHERE id_polis_pps='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "UPDATE `tb_polis_pps_kolektif` ppsd
INNER JOIN
(
	SELECT ppsv.id_polis_pps_kolektif,ppsv.price FROM
	`tb_polis_pps_kolektif` ppsv
	INNER JOIN
	(
		SELECT id_polis_pps,MIN(price) AS price 
		FROM tb_polis_pps_kolektif ppsv
		WHERE price > 0 AND ppsv.`id_polis_pps`='" & id_pps & "'
		GROUP BY id_polis_pps
	)minv ON minv.id_polis_pps=ppsv.id_polis_pps AND minv.price=ppsv.price
	LIMIT 1
)bestv ON bestv.id_polis_pps_kolektif=ppsd.id_polis_pps_kolektif
SET ppsd.is_recommended=1
WHERE ppsd.`id_polis_pps`='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
        End If
    End Sub

    Sub save_draft_penawaran()
        Dim q As String = ""
        'loop per vendor
        For j = 14 To GVPenawaran.Columns.Count - 1
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

            '    q = "UPDATE tb_polis_pps_det ppsd
            'INNER JOIN tb_polis_pps_vendor ppsv ON ppsd.polis_vendor=ppsv.id_vendor AND ppsd.id_polis_pps=ppsv.id_polis_pps AND ppsd.id_comp=ppsv.id_comp
            'SET ppsd.premi=ppsv.price
            'WHERE ppsd.id_polis_pps='" & id_pps & "'"
            '    execute_non_query(q, True, "", "", "", "")

            'set rekomendasi
            q = "UPDATE `tb_polis_pps_det` ppsd
INNER JOIN
(
	SELECT ppsv.id_polis_pps,ppsv.id_comp,ppsv.id_vendor,ppsv.price FROM
	tb_polis_pps_vendor ppsv
	INNER JOIN
	(
		SELECT id_polis_pps,id_comp,MIN(price) AS price 
		FROM tb_polis_pps_vendor ppsv
		WHERE price > 0 AND ppsv.`id_polis_pps`='" & id_pps & "'
		GROUP BY id_polis_pps,id_comp
	)minv ON minv.id_polis_pps=ppsv.id_polis_pps AND minv.price=ppsv.price AND minv.id_comp=ppsv.id_comp
)bestv ON bestv.id_polis_pps=ppsd.id_polis_pps AND ppsd.id_comp=bestv.id_comp 
SET ppsd.polis_vendor=bestv.id_vendor,ppsd.premi=bestv.price
WHERE ppsd.`id_polis_pps`='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
        Next


        '        For j = 14 To GVPenawaran.Columns.Count - 2 'ada kolom vendor dipilih terakhir, oleh karena itu -2 
        '            Dim id_vendor As String = GVPenawaran.Columns(j).FieldName.ToString.Split("_")(1)
        '            execute_non_query("DELETE FROM tb_polis_pps_vendor WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & id_vendor & "'", True, "", "", "", "")
        '            '
        '            q = "INSERT INTO tb_polis_pps_vendor(id_polis_pps,id_comp,id_vendor,price) VALUES "
        '            For i As Integer = 0 To GVPenawaran.RowCount - 1
        '                If Not i = 0 Then
        '                    q += ","
        '                End If
        '                q += "('" & id_pps & "','" & GVPenawaran.GetRowCellValue(i, "id_comp").ToString & "','" & id_vendor & "','" & decimalSQL(Decimal.Parse(GVPenawaran.GetRowCellValue(i, GVPenawaran.Columns(j).FieldName.ToString).ToString)) & "')"
        '            Next
        '            execute_non_query(q, True, "", "", "", "")
        '            '
        '            q = "UPDATE tb_polis_pps_det ppsd
        'INNER JOIN tb_polis_pps_vendor ppsv ON ppsd.polis_vendor=ppsv.id_vendor AND ppsd.id_polis_pps=ppsv.id_polis_pps AND ppsd.id_comp=ppsv.id_comp
        'SET ppsd.premi=ppsv.price
        'WHERE ppsd.id_polis_pps='" & id_pps & "'"
        '            execute_non_query(q, True, "", "", "", "")
        '        Next

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
        If SLEPPSType.EditValue.ToString = "1" Then
            'kolektif
            Dim qh As String = "SELECT 'no' AS is_check,ppsd.`id_comp`,ppsd.old_end_date,c.`comp_name`,c.`comp_number`,c.`address_primary`
,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`
,ppsd.old_nilai_total,ppsd.nilai_total,ppsd.old_premi,ppsd.old_polis_vendor,v_old.comp_name AS old_vendor
,ppsd.old_premi
,ppsd.polis_vendor,ppsd.premi,v.comp_name AS vendor
,ppsd.v_start_date,ppsd.v_end_date
FROM tb_polis_pps_det ppsd 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
LEFT JOIN tb_polis pol ON pol.id_polis=ppsd.old_id_polis
LEFT JOIN tb_m_comp v_old ON v_old.id_comp=ppsd.old_polis_vendor
LEFT JOIN tb_m_comp v ON v.id_comp=ppsd.polis_vendor
WHERE ppsd.id_polis_pps='" & id_pps & "'
GROUP BY ppsd.`id_comp`"
            Dim dth As DataTable = execute_query(qh, -1, True, "", "", "", "")

            Dim Report As New ReportPolis()
            Report.dt_kolektif = GCPenawaranKolektif.DataSource
            Report.dt = dth
            Report.id_pps = id_pps
            Report.SubBandKolektif.Visible = True
            '
            Dim q As String = "SELECT premi.description,DATE_FORMAT(pps.created_date,'%d %M %Y') AS created_date,emp.employee_name AS created_by,YEAR(pps.created_date) AS this_year,number FROM tb_polis_pps pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_desc_premi premi ON premi.id_desc_premi=pps.id_desc_premi
WHERE pps.id_polis_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            Report.DataSource = dt
            '
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            'mandiri
            Dim Report As New ReportPolis()
            Report.dt = GCPenawaran.DataSource
            Report.id_pps = id_pps
            '
            Dim q As String = "SELECT premi.description,DATE_FORMAT(pps.created_date,'%d %M %Y') AS created_date,emp.employee_name AS created_by,YEAR(pps.created_date) AS this_year,number FROM tb_polis_pps pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_desc_premi premi ON premi.id_desc_premi=pps.id_desc_premi
WHERE pps.id_polis_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            Report.DataSource = dt
            Report.SubBandKolektif.Visible = False
            '
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
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

    Private Sub FormPolisDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BGetExelNilaiStock_Click(sender As Object, e As EventArgs) Handles BGetExelNilaiStock.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.FileName = "Nilai Stok " & TENumber.Text
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim opt As DevExpress.XtraPrinting.XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions
            opt.SheetName = "permohonan nilai stok"
            GVNilaiStock.ExportToXlsx(save.FileName, opt)

            Process.Start(save.FileName)
        End If
    End Sub

    Private Sub BImportNilaiStock_Click(sender As Object, e As EventArgs) Handles BImportNilaiStock.Click
        Dim file_rekon_name As String = ""

        Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C:\"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            'use save as
            Dim open_file As String = ""

            'If is_save_as Then
            '    Cursor = Cursors.WaitCursor
            '    Dim path As String = Application.StartupPath & "\download\"
            '    'create directory if not exist
            '    If Not IO.Directory.Exists(path) Then
            '        System.IO.Directory.CreateDirectory(path)
            '    End If
            '    path = path + "file_temp.xls"
            '    Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
            '    Dim temp As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)
            '    'delete file
            '    Try
            '        My.Computer.FileSystem.DeleteFile(path)
            '    Catch ex As Exception
            '    End Try
            '    temp.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
            '    temp.Close()
            '    app.Quit()
            '    open_file = path
            '    Cursor = Cursors.Default
            'Else
            '    open_file = fdlg.FileName
            'End If

            open_file = fdlg.FileName
            file_rekon_name = open_file

            'TBFileAddress.Text = ""
            'TBFileAddress.Text = open_file
        Else
            Exit Sub
        End If
        fdlg.Dispose()

        'get data
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim data_temp As New DataTable

        copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(file_rekon_name)
        IO.File.Copy(file_rekon_name, copy_file_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        MyCommand = New OleDbDataAdapter("select * from [permohonan nilai stok$] WHERE not ([Kode Toko]='')", oledbconn)

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        Try

            Dim queryx As String = "SELECT pd.`id_polis_pps_det`,pd.`id_polis_pps`,pd.`id_comp`,pd.`nilai_stock`,c.comp_number
FROM `tb_polis_pps_det` pd
INNER JOIN tb_m_comp c ON c.id_comp=pd.id_comp
WHERE pd.`id_polis_pps`='" & id_pps & "' "

            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim hasil = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("Kode Toko").ToString.ToLower Equals table_tmp("comp_number").ToString.ToLower Into awb = Group
                        From result_awb In awb.DefaultIfEmpty()
                        Select New With
                            {
                            .id_polis_pps_det = If(result_awb Is Nothing, "", result_awb("id_polis_pps_det")),
                            .nilai_stock = If(table1("Nilai Stock").ToString = "", 0, table1("Nilai Stock"))
                            }

            'Dim dtcek As DataTable = query.ToList().CopyTodatatable
            Dim hasil_dt = ToDataTable(hasil.ToList())
            For i = 0 To hasil_dt.Rows.Count - 1
                'Console.WriteLine(hasil_dt(i)("berat_final").ToString)
                If Not hasil_dt(i)("id_polis_pps_det").ToString = "" Then
                    'update
                    Dim qu As String = "UPDATE tb_polis_pps_det SET nilai_stock='" & decimalSQL(Decimal.Parse(hasil_dt(i)("nilai_stock").ToString).ToString) & "' WHERE id_polis_pps_det='" & hasil_dt(i)("id_polis_pps_det").ToString & "'"
                    execute_non_query(qu, True, "", "", "", "")
                End If
            Next

            load_form()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try

        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub

    Public Shared Function ToDataTable(Of T)(ByVal data As IList(Of T)) As DataTable
        Dim properties As ComponentModel.PropertyDescriptorCollection = ComponentModel.TypeDescriptor.GetProperties(GetType(T))
        Dim table As DataTable = New DataTable()

        For Each prop As ComponentModel.PropertyDescriptor In properties
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next

        For Each item As T In data
            Dim row As DataRow = table.NewRow()

            For Each prop As ComponentModel.PropertyDescriptor In properties
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next

            table.Rows.Add(row)
        Next

        Return table
    End Function

    Private Sub BGetExelNilaiLain_Click(sender As Object, e As EventArgs) Handles BGetExelNilaiLain.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.FileName = "Nilai Lain " & TENumber.Text
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim opt As DevExpress.XtraPrinting.XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions
            opt.SheetName = "permohonan nilai lain"
            GVNilaiLainnya.ExportToXlsx(save.FileName, opt)

            Process.Start(save.FileName)
        End If
    End Sub

    Private Sub BUploadExelNilaiLain_Click(sender As Object, e As EventArgs) Handles BUploadExelNilaiLain.Click
        Dim file_rekon_name As String = ""

        Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C:\"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            'use save as
            Dim open_file As String = ""

            'If is_save_as Then
            '    Cursor = Cursors.WaitCursor
            '    Dim path As String = Application.StartupPath & "\download\"
            '    'create directory if not exist
            '    If Not IO.Directory.Exists(path) Then
            '        System.IO.Directory.CreateDirectory(path)
            '    End If
            '    path = path + "file_temp.xls"
            '    Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
            '    Dim temp As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)
            '    'delete file
            '    Try
            '        My.Computer.FileSystem.DeleteFile(path)
            '    Catch ex As Exception
            '    End Try
            '    temp.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
            '    temp.Close()
            '    app.Quit()
            '    open_file = path
            '    Cursor = Cursors.Default
            'Else
            '    open_file = fdlg.FileName
            'End If

            open_file = fdlg.FileName
            file_rekon_name = open_file

            'TBFileAddress.Text = ""
            'TBFileAddress.Text = open_file
        Else
            Exit Sub
        End If
        fdlg.Dispose()

        'get data
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim data_temp As New DataTable

        copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(file_rekon_name)
        IO.File.Copy(file_rekon_name, copy_file_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        MyCommand = New OleDbDataAdapter("select * from [permohonan nilai lain$] WHERE not ([Kode Toko]='')", oledbconn)

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        Try

            Dim queryx As String = "SELECT pd.`id_polis_pps_det`,pd.`id_polis_pps`,pd.`id_comp`,c.comp_number
FROM `tb_polis_pps_det` pd
INNER JOIN tb_m_comp c ON c.id_comp=pd.id_comp
WHERE pd.`id_polis_pps`='" & id_pps & "' "

            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim hasil = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("Kode Toko").ToString.ToLower Equals table_tmp("comp_number").ToString.ToLower Into awb = Group
                        From result_awb In awb.DefaultIfEmpty()
                        Select New With
                            {
                            .id_polis_pps_det = If(result_awb Is Nothing, "", result_awb("id_polis_pps_det")),
                            .nilai_fit_out = If(table1("Nilai Fitout").ToString = "", 0, table1("Nilai Fitout")),
                            .nilai_building = If(table1("Nilai Building").ToString = "", 0, table1("Nilai Building")),
                            .nilai_peralatan = If(table1("Nilai Peralatan").ToString = "", 0, table1("Nilai Peralatan")),
                            .nilai_public_liability = If(table1("Nilai Public Liability").ToString = "", 0, table1("Nilai Public Liability"))
                            }

            'Dim dtcek As DataTable = query.ToList().CopyTodatatable
            Dim hasil_dt = ToDataTable(hasil.ToList())
            For i = 0 To hasil_dt.Rows.Count - 1
                'Console.WriteLine(hasil_dt(i)("berat_final").ToString)
                If Not hasil_dt(i)("id_polis_pps_det").ToString = "" Then
                    'update
                    Dim qu As String = "UPDATE tb_polis_pps_det SET nilai_fit_out='" & decimalSQL(Decimal.Parse(hasil_dt(i)("nilai_fit_out").ToString).ToString) & "',nilai_building='" & decimalSQL(Decimal.Parse(hasil_dt(i)("nilai_building").ToString).ToString) & "',nilai_peralatan='" & decimalSQL(Decimal.Parse(hasil_dt(i)("nilai_peralatan").ToString).ToString) & "',nilai_public_liability='" & decimalSQL(Decimal.Parse(hasil_dt(i)("nilai_public_liability").ToString).ToString) & "' WHERE id_polis_pps_det='" & hasil_dt(i)("id_polis_pps_det").ToString & "'"
                    execute_non_query(qu, True, "", "", "", "")
                End If
            Next

            load_form()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try

        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub

    Private Sub BGetExcel_Click(sender As Object, e As EventArgs) Handles BGetExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.FileName = "Harga Penawaran Vendor " & SLEPenawaranDel.Text & " " & TENumber.Text
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim opt As DevExpress.XtraPrinting.XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions
            opt.SheetName = "penawaran"
            load_nilai_penawaran_vendor(SLEPenawaranDel.EditValue.ToString)
            GVPenawaran.ExportToXlsx(save.FileName, opt)
            load_nilai_penawaran()

            Process.Start(save.FileName)
        End If
    End Sub

    Sub load_nilai_penawaran_vendor(ByVal id_vendor As String)
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_pps & "' AND ppsv.id_vendor='" & id_vendor & "'
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

        qs = "SELECT 'no' AS is_check,ppsd.`id_comp`,ppsd.old_end_date,c.`comp_name`,c.`comp_number`,c.`address_primary`
,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`
,ppsd.old_nilai_total,ppsd.nilai_total,ppsd.old_premi,ppsd.old_polis_vendor,v_old.comp_name AS old_vendor
,ppsd.old_premi
,ppsd.polis_vendor,ppsd.premi,v.comp_name AS vendor
,ppsd.v_start_date,ppsd.v_end_date
" & qh & "
FROM tb_polis_pps_det ppsd 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
LEFT JOIN tb_polis pol ON pol.id_polis=ppsd.old_id_polis
LEFT JOIN tb_m_comp v_old ON v_old.id_comp=ppsd.old_polis_vendor
LEFT JOIN tb_m_comp v ON v.id_comp=ppsd.polis_vendor
" & qj & "
WHERE ppsd.id_polis_pps='" & id_pps & "'
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
                GVPenawaran.Columns.AddVisible(dt.Columns(i).ColumnName.ToString, "Penawaran")
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVPenawaran.Columns(dt.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "N2"
            End If
        Next
        '
        GVPenawaran.RefreshData()

        GCPenawaran.DataSource = dt
        GVPenawaran.BestFitColumns()
    End Sub

    Private Sub BUploadExcel_Click(sender As Object, e As EventArgs) Handles BUploadExcel.Click
        Dim file_rekon_name As String = ""

        Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C:\"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            'use save as
            Dim open_file As String = ""

            'If is_save_as Then
            '    Cursor = Cursors.WaitCursor
            '    Dim path As String = Application.StartupPath & "\download\"
            '    'create directory if not exist
            '    If Not IO.Directory.Exists(path) Then
            '        System.IO.Directory.CreateDirectory(path)
            '    End If
            '    path = path + "file_temp.xls"
            '    Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
            '    Dim temp As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)
            '    'delete file
            '    Try
            '        My.Computer.FileSystem.DeleteFile(path)
            '    Catch ex As Exception
            '    End Try
            '    temp.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
            '    temp.Close()
            '    app.Quit()
            '    open_file = path
            '    Cursor = Cursors.Default
            'Else
            '    open_file = fdlg.FileName
            'End If

            open_file = fdlg.FileName
            file_rekon_name = open_file

            'TBFileAddress.Text = ""
            'TBFileAddress.Text = open_file
        Else
            Exit Sub
        End If
        fdlg.Dispose()

        'get data
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim data_temp As New DataTable

        copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(file_rekon_name)
        IO.File.Copy(file_rekon_name, copy_file_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        MyCommand = New OleDbDataAdapter("select * from [penawaran$] WHERE not ([Kode Toko]='')", oledbconn)

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !" + System.Environment.NewLine + ex.ToString)
            Exit Sub
        End Try

        Try

            Dim queryx As String = "SELECT pd.`id_polis_pps_det`,pd.`id_polis_pps`,pd.`id_comp`,c.comp_number
FROM `tb_polis_pps_det` pd
INNER JOIN tb_m_comp c ON c.id_comp=pd.id_comp
WHERE pd.`id_polis_pps`='" & id_pps & "' "

            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim hasil = From table1 In tb1
                        Group Join table_tmp In tb2
                        On table1("Kode Toko").ToString.ToLower Equals table_tmp("comp_number").ToString.ToLower Into awb = Group
                        From result_awb In awb.DefaultIfEmpty()
                        Select New With
                            {
                            .id_comp = If(result_awb Is Nothing, "", result_awb("id_comp")),
                            .price = If(table1("Penawaran").ToString = "", 0, table1("Penawaran"))
                            }

            'Dim dtcek As DataTable = query.ToList().CopyTodatatable
            Dim hasil_dt = ToDataTable(hasil.ToList())
            For i = 0 To hasil_dt.Rows.Count - 1
                'Console.WriteLine(hasil_dt(i)("berat_final").ToString)
                If Not hasil_dt(i)("id_comp").ToString = "" Then
                    Dim qu As String = ""
                    'delete first
                    qu = "DELETE FROM tb_polis_pps_vendor WHERE id_comp='" & hasil_dt(i)("id_comp").ToString & "' AND id_vendor='" & SLEPenawaranDel.EditValue.ToString & "' AND id_polis_pps='" & id_pps & "'"
                    execute_non_query(qu, True, "", "", "", "")

                    'insert
                    qu = "INSERT INTO tb_polis_pps_vendor(id_polis_pps,id_comp,id_vendor,price) VALUES('" & id_pps & "','" & hasil_dt(i)("id_comp").ToString & "','" & SLEPenawaranDel.EditValue.ToString & "','" & decimalSQL(Decimal.Parse(hasil_dt(i)("price").ToString).ToString) & "')"
                    execute_non_query(qu, True, "", "", "", "")
                End If
            Next

            load_form()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try

        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub

    Private Sub BSetVendorDipilih_Click(sender As Object, e As EventArgs) Handles BSetVendorDipilih.Click
        GVPenawaran.ActiveFilterString = "[is_check]='yes'"
        If GVPenawaran.RowCount > 0 Then
            For i = 0 To GVPenawaran.RowCount - 1
                Dim qu As String = "UPDATE tb_polis_pps_det SET polis_vendor='" & SLEPenawaranDel.EditValue.ToString & "',premi=(SELECT price FROM `tb_polis_pps_vendor` WHERE id_comp='" & GVPenawaran.GetRowCellValue(i, "id_comp").ToString & "' AND id_polis_pps='" & id_pps & "' AND id_vendor='" & SLEPenawaranDel.EditValue.ToString & "') WHERE id_polis_pps='" & id_pps & "' AND id_comp='" & GVPenawaran.GetRowCellValue(i, "id_comp").ToString & "'"
                execute_non_query(qu, True, "", "", "", "")
            Next
        End If
        GVPenawaran.ActiveFilterString = ""
        load_nilai_penawaran()
    End Sub

    Private Sub SLEPPSType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPPSType.EditValueChanged
        If SLEPPSType.EditValue.ToString = "1" Then
            '1 untuk semua
            LDateFrom.Visible = True
            LDateUntil.Visible = True
            DEUntil.Visible = True
            DEStart.Visible = True
        Else
            'mandiri
            LDateFrom.Visible = False
            LDateUntil.Visible = False
            DEUntil.Visible = False
            DEStart.Visible = False
        End If
    End Sub

    Private Sub BAddPenawaranKolektif_Click(sender As Object, e As EventArgs) Handles BAddPenawaranKolektif.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to add " & SLEPenawaranAddKolektif.Text & " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            'add to database first row as 0
            Dim q As String = ""
            q = "DELETE FROM tb_polis_pps_kolektif WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & SLEPenawaranAddKolektif.EditValue.ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "INSERT INTO tb_polis_pps_kolektif(id_polis_pps,id_vendor,price) VALUES('" & id_pps & "','" & SLEPenawaranAddKolektif.EditValue.ToString & "','0.00')"
            execute_non_query(q, True, "", "", "", "")
            'refresh
            view_vendor_penawaran_kolektif()
            load_nilai_penawaran_kolektif()
        End If
    End Sub

    Private Sub BDelPenawaranKolektif_Click(sender As Object, e As EventArgs) Handles BDelPenawaranKolektif.Click
        'confirm first
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to drop " & GVPenawaranKolektif.GetFocusedRowCellValue("comp_name").Text & " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            'delete
            Dim q As String = "DELETE FROM tb_polis_pps_kolektif WHERE id_polis_pps='" & id_pps & "' AND id_vendor='" & GVPenawaranKolektif.GetFocusedRowCellValue("id_vendor").Text & "'"
            execute_non_query(q, True, "", "", "", "")
            'refresh
            view_vendor_penawaran_kolektif()
            load_nilai_penawaran_kolektif()
        End If
    End Sub
End Class