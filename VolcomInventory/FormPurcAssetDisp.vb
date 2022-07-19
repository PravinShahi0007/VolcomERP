Public Class FormPurcAssetDisp
    Public id_trans As String = "-1"

    Dim id_report_status As String = "1"
    Public is_view As String = "-1"
    Public is_sell As Boolean = True

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        'query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub FormPurcAssetDisp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_unit()
        load_pil()
        load_acc()

        If id_trans = "-1" Then
            'new
            DECreatedDate.EditValue = Now
            DEReff.EditValue = Now
            '
            TENumber.Text = "[auto number]"
            TECreatedBy.Text = "[auto]"
            '
        Else
            'edit
            BMark.Visible = True
            BtnPrint.Visible = True
            SLEUnit.Properties.ReadOnly = True
            PCAddDel.Visible = False
            SLECOAKerugian.Properties.ReadOnly = True
            SLECOAPendPenjualan.Properties.ReadOnly = True

            Dim q As String = "SELECT pps.*,emp.employee_name,ta.tag_description 
FROM `tb_purc_rec_asset_disp` pps
INNER JOIN tb_coa_tag ta ON ta.id_coa_tag=pps.id_coa_tag
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_purc_rec_asset_disp='" & id_trans & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                SLEUnit.EditValue = dt.Rows(0)("id_coa_tag").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
                is_sell = If(dt.Rows(0)("is_sell").ToString = "1", True, False)
                DEReff.EditValue = dt.Rows(0)("date_reff")
                If dt.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                End If
                MENote.Text = dt.Rows(0)("note").ToString
                SLECOAKerugian.EditValue = dt.Rows(0)("coa_kerugian").ToString
                If is_sell Then
                    SLECOAPendPenjualan.EditValue = dt.Rows(0)("coa_pend_penjualan").ToString
                End If
            End If
        End If

        load_det()
        check_but()
    End Sub

    Sub load_pil()
        Dim q As String = "SELECT ass.id_purc_rec_asset
,ass.id_acc_fa,ass.id_acc_dep_accum
,accacum.acc_name AS acc_dep_accum_name,accacum.acc_description AS acc_dep_accum
,accfa.acc_name AS acc_fa_name,accfa.acc_description AS acc_fa
,ass.asset_number,ass.asset_name,ass.asset_note,(ass.acq_cost+ass.value_added) AS total_value, IFNULL(SUM(amount),0.00) AS dep_value,(ass.acq_cost+ass.value_added) - IFNULL(SUM(amount),0.00) AS rem_value
FROM `tb_purc_rec_asset` ass 
LEFT JOIN `tb_purc_rec_asset_dep` dep ON dep.id_purc_rec_asset=ass.id_purc_rec_asset
INNER JOIN tb_a_acc accfa ON accfa.id_acc=ass.id_acc_fa
INNER JOIN tb_a_acc accacum ON accacum.id_acc=ass.id_acc_dep_accum
WHERE ass.is_active=1 AND ass.id_coa_tag='" & SLEUnit.EditValue.ToString & "'
GROUP BY ass.id_purc_rec_asset"
        viewSearchLookupRepositoryQuery(RISLEAsset, q, 0, "asset_number", "id_purc_rec_asset")
    End Sub

    Sub load_acc()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"

        If SLEUnit.EditValue.ToString = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If

        viewSearchLookupQuery(SLECOAKerugian, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLECOAPendPenjualan, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT dd.`id_purc_rec_asset_disp_det`,dd.`id_purc_rec_asset`,dd.`id_acc_fa`,dd.`id_acc_dep_accum`,dd.total_value,dd.`rem_value`,dd.`harga_jual`
,accacum.acc_name AS acc_dep_accum_name,accacum.acc_description AS acc_dep_accum
,accfa.acc_name AS acc_fa_name,accfa.acc_description AS acc_fa
,ass.asset_note,ass.asset_number
FROM tb_purc_rec_asset_disp_det dd
INNER JOIN tb_purc_rec_asset ass ON ass.id_purc_rec_asset=dd.id_purc_rec_asset
INNER JOIN tb_a_acc accfa ON accfa.id_acc=dd.id_acc_fa
INNER JOIN tb_a_acc accacum ON accacum.id_acc=dd.id_acc_dep_accum
WHERE dd.id_purc_rec_asset_disp='" & id_trans & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItem.DataSource = dt
        GVItem.BestFitColumns()
        check_but()
    End Sub

    Private Sub RISLEAsset_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEAsset.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            'budget
            GVItem.SetFocusedRowCellValue("acc_dep_accum_name", sle.Properties.View.GetFocusedRowCellValue("acc_dep_accum_name").ToString())
            GVItem.SetFocusedRowCellValue("acc_dep_accum", sle.Properties.View.GetFocusedRowCellValue("acc_dep_accum").ToString())
            GVItem.SetFocusedRowCellValue("id_acc_dep_accum", sle.Properties.View.GetFocusedRowCellValue("id_acc_dep_accum").ToString())
            GVItem.SetFocusedRowCellValue("acc_fa_name", sle.Properties.View.GetFocusedRowCellValue("acc_fa_name").ToString())
            GVItem.SetFocusedRowCellValue("acc_fa", sle.Properties.View.GetFocusedRowCellValue("acc_fa").ToString())
            GVItem.SetFocusedRowCellValue("id_acc_fa", sle.Properties.View.GetFocusedRowCellValue("id_acc_fa").ToString())
            GVItem.SetFocusedRowCellValue("asset_note", sle.Properties.View.GetFocusedRowCellValue("asset_note").ToString())
            GVItem.SetFocusedRowCellValue("asset_number", sle.Properties.View.GetFocusedRowCellValue("asset_number").ToString())

            GVItem.SetFocusedRowCellValue("total_value", sle.Properties.View.GetFocusedRowCellValue("total_value"))
            GVItem.SetFocusedRowCellValue("rem_value", sle.Properties.View.GetFocusedRowCellValue("rem_value"))

            GVItem.SetFocusedRowCellValue("harga_jual", 0.00)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVItem.RowCount > 0 Then
            GVItem.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub check_but()
        If GVItem.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
        If is_sell Then
            TEType.Text = "Penjualan Fixed Asset"
            formName = "Penjualan Fixed Asset"
            LCOAPendPenjualan.Visible = True
            SLECOAPendPenjualan.Visible = True
            GridColumnHargaJual.Visible = True
        Else
            TEType.Text = "Penghapusan Fixed Asset"
            formName = "Penghapusan Fixed Asset"
            LCOAPendPenjualan.Visible = False
            SLECOAPendPenjualan.Visible = False
            GridColumnHargaJual.Visible = False
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCItem.DataSource, DataTable)).NewRow()

        TryCast(GCItem.DataSource, DataTable).Rows.Add(newRow)
        GCItem.RefreshDataSource()
        GVItem.RefreshData()

        check_but()
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        load_pil()
        'reset gv
        For i As Integer = GVItem.RowCount - 1 To 0 Step -1
            GVItem.DeleteRow(i)
        Next
        check_but()
    End Sub

    Private Sub FormPurcAssetDisp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check duplicate
        Dim is_dupe As Boolean = False

        For i As Integer = 0 To GVItem.RowCount - 1
            Dim qc As String = "SELECT * FROM tb_purc_rec_asset_disp_det dd 
INNER JOIN tb_purc_rec_asset_disp d ON d.id_purc_rec_asset_disp=dd.id_purc_rec_asset_disp AND d.id_report_status!=5
WHERE dd.id_purc_rec_asset='" & GVItem.GetRowCellValue(i, "id_purc_rec_asset").ToString & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                is_dupe = True
                Exit For
            End If
        Next

        If GVItem.RowCount > 2 And Not is_dupe Then
            For i As Integer = 0 To GVItem.RowCount - 1
                For j = i To GVItem.RowCount - 1
                    If GVItem.GetRowCellValue(i, "id_purc_rec_asset").ToString = GVItem.GetRowCellValue(j, "id_purc_rec_asset").ToString And Not i = j Then
                        Exit For
                    End If
                Next

                If is_dupe Then
                    Exit For
                End If
            Next
        End If

        '
        Dim is_ok_harga_jual As Boolean = True
        If is_sell Then
            For i As Integer = 0 To GVItem.RowCount - 1
                If GVItem.GetRowCellValue(i, "harga_jual") <= 0 Then
                    is_ok_harga_jual = False
                    Exit For
                End If
            Next
        End If

        If GVItem.RowCount = 0 Then
            warningCustom("Please insert item first.")
        ElseIf is_dupe Then
            warningCustom("Item already proposed.")
        ElseIf Not is_ok_harga_jual Then
            warningCustom("Pastikan harga jual terinput dengan benar.")
        Else
            If id_trans = "-1" Then 'new
                Dim coa_pend_penjualan As String = "NULL"

                If is_sell Then
                    coa_pend_penjualan = "'" & SLECOAPendPenjualan.EditValue.ToString & "'"
                End If

                Dim q As String = "INSERT INTO `tb_purc_rec_asset_disp`(`created_by`,`created_date`,`date_reff`,`id_report_status`,`is_sell`,`note`,`id_coa_tag`,coa_kerugian,coa_pend_penjualan)
VALUES('" & id_user & "',NOW(),'" & Date.Parse(DEReff.EditValue.ToString).ToString("yyyy-MM-dd") & "','1','" & If(is_sell, "1", "2") & "','" & addSlashes(MENote.Text) & "','" & SLEUnit.EditValue.ToString & "','" & SLECOAKerugian.EditValue.ToString & "'," & coa_pend_penjualan & "); SELECT LAST_INSERT_ID(); "
                id_trans = execute_query(q, 0, True, "", "", "", "")
                'det
                q = "INSERT INTO `tb_purc_rec_asset_disp_det`(`id_purc_rec_asset_disp`,`id_purc_rec_asset`,`id_acc_fa`,`id_acc_dep_accum`,`total_value`,`rem_value`,`harga_jual`) VALUES"
                For i As Integer = 0 To GVItem.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_trans & "','" & GVItem.GetRowCellValue(i, "id_purc_rec_asset").ToString & "','" & GVItem.GetRowCellValue(i, "id_acc_fa").ToString & "','" & GVItem.GetRowCellValue(i, "id_acc_dep_accum").ToString & "','" & decimalSQL(GVItem.GetRowCellValue(i, "total_value").ToString) & "','" & decimalSQL(GVItem.GetRowCellValue(i, "rem_value").ToString) & "','" & decimalSQL(GVItem.GetRowCellValue(i, "harga_jual").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id_trans & "','298')"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("298", id_trans, id_user)
                '
                warningCustom("Dokumen diajukan, menunggu persetujuan")
                FormPurcAsset.load_disp()
                Close()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "298"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_trans
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans 
            WHERE ad.report_mark_type=298 AND ad.id_report=" + id_trans + "
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

    Private Sub XTCDep_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDep.SelectedPageChanged
        If XTCDep.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVItem.RowCount > 0 Then
            makeSafeGV(GVItem)
            Dim jum_row As Integer = 0
            'detail
            For i As Integer = 0 To GVItem.RowCount - 1
                'perolehan
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = get_acc(GVItem.GetRowCellValue(i, "id_acc_fa").ToString, "1")
                newRow("acc_description") = get_acc(GVItem.GetRowCellValue(i, "id_acc_fa").ToString, "2")
                newRow("cc") = "000"
                newRow("report_number") = TENumber.Text
                newRow("note") = If(is_sell, "Penjualan Fixed Asset ", "Penghapusan Fixed Asset ") & GVItem.GetRowCellValue(i, "asset_note").ToString
                newRow("debit") = 0
                newRow("credit") = GVItem.GetRowCellValue(i, "total_value")
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
                GVDraft.BestFitColumns()
                'kerugian
                If GVItem.GetRowCellValue(i, "rem_value") > 0 Then
                    jum_row += 1
                    Dim newRowk As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowk("no") = jum_row
                    newRowk("acc_name") = get_acc(SLECOAKerugian.EditValue.ToString, "1")
                    newRowk("acc_description") = get_acc(SLECOAKerugian.EditValue.ToString, "2")
                    newRowk("cc") = "000"
                    newRowk("report_number") = TENumber.Text
                    newRowk("note") = If(is_sell, "Penjualan Fixed Asset ", "Penghapusan Fixed Asset ") & GVItem.GetRowCellValue(i, "asset_note").ToString
                    newRowk("debit") = GVItem.GetRowCellValue(i, "rem_value")
                    newRowk("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowk)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    GVDraft.BestFitColumns()
                End If
                'akumulasi
                If GVItem.GetRowCellValue(i, "total_value") - GVItem.GetRowCellValue(i, "rem_value") > 0 Then
                    jum_row += 1
                    Dim newRowa As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowa("no") = jum_row
                    newRowa("acc_name") = get_acc(GVItem.GetRowCellValue(i, "id_acc_dep_accum").ToString, "1")
                    newRowa("acc_description") = get_acc(GVItem.GetRowCellValue(i, "id_acc_dep_accum").ToString, "2")
                    newRowa("cc") = "000"
                    newRowa("report_number") = TENumber.Text
                    newRowa("note") = If(is_sell, "Penjualan Fixed Asset ", "Penghapusan Fixed Asset ") & GVItem.GetRowCellValue(i, "asset_note").ToString
                    newRowa("debit") = GVItem.GetRowCellValue(i, "total_value") - GVItem.GetRowCellValue(i, "rem_value")
                    newRowa("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowa)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    GVDraft.BestFitColumns()
                End If
            Next
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim q As String = "SELECT pps.*,emp.employee_name,ta.tag_description 
FROM `tb_purc_rec_asset_disp` pps
INNER JOIN tb_coa_tag ta ON ta.id_coa_tag=pps.id_coa_tag
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_purc_rec_asset_disp='" & id_trans & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        Cursor = Cursors.WaitCursor

        Dim Report As New ReportPurcAssetDisp()

        If is_sell Then
            Report.LTitle.Text = "FIXED ASSET SOLD"
        Else
            Report.LTitle.Text = "FIXED ASSET DISPOSAL"
        End If
        '

        '
        Report.DataSource = dt
        Report.id_trans = id_trans
        Report.dt = GCItem.DataSource
        ' ...
        ' creating and saving the view's layout to a new memory stream 
        '

        GridColumnAsset.VisibleIndex = "-1"
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItem.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItem.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        GridColumnAsset.VisibleIndex = "0"

        'Grid Detail
        ReportStyleGridview(Report.GVItem)
        Report.GVItem.BestFitColumns()

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
End Class