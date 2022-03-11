Public Class FormBiayaSewaBulanan
    Public id_biaya_bulanan As String = "-1"
    Dim id_report_status As String = "1"
    Public is_view As String = "-1"

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPurcAssetDep_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcAssetDep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_unit()
        DEReffDate.EditValue = getTimeDB()
        DECreatedDate.EditValue = getTimeDB()
        '
        TENumber.Text = "[auto number]"
        TECreatedBy.Text = "[auto]"
        '
        If id_biaya_bulanan = "-1" Then
            BMark.Visible = False
            BtnPrint.Visible = False
        Else
            BMark.Visible = True
            BtnPrint.Visible = True
            DEReffDate.Properties.ReadOnly = True
            SLEUnit.Properties.ReadOnly = True
            BLoadAsset.Visible = False
            '
            Dim q As String = "SELECT pps.*,emp.employee_name 
FROM `tb_biaya_sewa_bulanan` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_biaya_sewa_bulanan='" & id_biaya_bulanan & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                DEReffDate.EditValue = dt.Rows(0)("reff_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                SLEUnit.EditValue = dt.Rows(0)("id_coa_tag").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
                If dt.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                End If
            End If
        End If

        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ass.total_bulan AS total_bulan,ppsd.remaining_month, ppsd.coa_uang_muka, ppsd.coa_biaya,acc_biaya.acc_description AS acc_biaya,acc_uangmuka.acc_description AS acc_uang_muka,acc_biaya.acc_name AS acc_biaya_name,acc_uangmuka.acc_name AS acc_uang_muka_name
,ass.`description`,ass.date_reff
,ass.total_uang_muka AS total_uang_muka
,ppsd.alokasi_biaya_per_bulan,ppsd.biaya_teralokasi
FROM `tb_biaya_sewa_bulanan_det` ppsd
INNER JOIN tb_a_acc acc_uangmuka ON acc_uangmuka.id_acc=ppsd.coa_uang_muka
INNER JOIN tb_a_acc acc_biaya ON acc_biaya.id_acc=ppsd.coa_biaya
INNER JOIN tb_biaya_sewa ass ON ass.id_biaya_sewa=ppsd.id_biaya_sewa
WHERE ppsd.id_biaya_sewa_bulanan='" & id_biaya_bulanan & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDepreciation.DataSource = dt
        GVDepreciation.BestFitColumns()
    End Sub

    Private Sub DEReffDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEReffDate.EditValueChanged
        Try
            DEReffDate.EditValue = New DateTime(DEReffDate.EditValue.Year, DEReffDate.EditValue.Month, Date.DaysInMonth(DEReffDate.EditValue.Year, DEReffDate.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BLoadAsset_Click(sender As Object, e As EventArgs) Handles BLoadAsset.Click
        Dim qc As String = "SELECT * FROM `tb_biaya_sewa_bulanan`
WHERE DATE_FORMAT(reff_date,'%m%Y')=DATE_FORMAT(LAST_DAY(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH)),'%m%Y') AND id_report_status=6 AND id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2021-01-31" Then
            'check dulu sudah input belum
            qc = "SELECT * FROM tb_biaya_sewa_bulanan WHERE reff_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND id_report_status!=5"
            Dim dtd As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtd.Rows.Count > 0 Then
                warningCustom("Depreciation for this month already created")
            Else
                Dim q As String = "SET @end_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "';
SELECT ass.total_bulan,0 AS id_biaya_sewa_bulanan_det, ass.id_biaya_sewa, ass.coa_uang_muka, ass.coa_biaya
,acc_uangmuka.acc_description AS acc_uang_muka,acc_biaya.acc_description AS acc_biaya
,acc_uangmuka.acc_name AS acc_uang_muka_name,acc_biaya.acc_name AS acc_biaya_name
,CEIL(TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) +
  DATEDIFF(
    @end_date,
    ass.`date_reff` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date)
    MONTH
  ) /
  DATEDIFF(
    ass.`date_reff` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) + 1
    MONTH,
    ass.`date_reff` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date)
    MONTH
  )) AS life
,ass.`description`,ass.date_reff,ass.total_bulan-(SELECT life) AS remaining_month
,IFNULL(teralokasi.alokasi,0.00) AS biaya_teralokasi
,ass.`total_uang_muka`
,IF((SELECT remaining_month)=0,(ass.`total_uang_muka`-IFNULL(teralokasi.alokasi,0.00)),ROUND((ass.total_uang_muka)/(ass.total_bulan),2)) AS alokasi_biaya_per_bulan
FROM tb_biaya_sewa ass
INNER JOIN tb_a_acc acc_uangmuka ON acc_uangmuka.id_acc=ass.coa_uang_muka
INNER JOIN tb_a_acc acc_biaya ON acc_biaya.id_acc=ass.coa_biaya
LEFT JOIN
(
    SELECT id_biaya_sewa,SUM(amount) AS alokasi
    FROM 
    `tb_biaya_sewa_teralokasi` ass
    GROUP BY id_biaya_sewa
)teralokasi ON teralokasi.id_biaya_sewa=ass.id_biaya_sewa
WHERE 
ass.is_active=1 AND ass.id_coa_tag='" & SLEUnit.EditValue.ToString & "' AND
CEIL(TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) + DATEDIFF(@end_date,ass.`date_reff` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) MONTH) / DATEDIFF(ass.`date_reff` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) + 1 MONTH,ass.`date_reff` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`date_reff`, @end_date) MONTH)) 
<=ass.`total_bulan` AND ass.date_reff<=@end_date AND ass.date_reff>='2020-12-31'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCDepreciation.DataSource = dt
                GVDepreciation.BestFitColumns()
                DEReffDate.Properties.ReadOnly = True
                SLEUnit.Properties.ReadOnly = True
            End If
        Else
            warningCustom("Alokasi biaya bulan lalu belum dilaksanakan.")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check bulan sebelumnya udh belum or ada pending (pending waktu teken add)
        Dim qc As String = "SELECT * FROM `tb_asset_dep_pps`
WHERE DATE_FORMAT(reff_date,'%m%Y')=DATE_FORMAT(LAST_DAY(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH)),'%m%Y') AND id_report_status=6 AND id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2021-01-31" Then
            If GVDepreciation.RowCount = 0 Then
                warningCustom("Please load depreciation first")
            Else
                If id_biaya_bulanan = "-1" Then 'new
                    Dim q As String = "INSERT INTO `tb_biaya_sewa_bulanan`(created_date,created_by,reff_date,id_coa_tag)
VALUES(DATE(NOW()),'" & id_user & "','" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & SLEUnit.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                    id_biaya_bulanan = execute_query(q, 0, True, "", "", "", "")
                    'det
                    q = "INSERT INTO tb_biaya_sewa_bulanan_det(`id_biaya_sewa_bulanan`,`id_biaya_sewa`,`coa_uang_muka`,`coa_biaya`,`biaya_teralokasi`,`remaining_month`,`alokasi_biaya_per_bulan`) VALUES"
                    For i As Integer = 0 To GVDepreciation.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_biaya_bulanan & "','" & GVDepreciation.GetRowCellValue(i, "id_biaya_sewa").ToString & "','" & GVDepreciation.GetRowCellValue(i, "coa_uang_muka").ToString & "','" & GVDepreciation.GetRowCellValue(i, "coa_biaya").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "biaya_teralokasi").ToString) & "','" & GVDepreciation.GetRowCellValue(i, "remaining_month").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "alokasi_biaya_per_bulan").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id_biaya_bulanan & "','294')"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    submit_who_prepared("294", id_biaya_bulanan, id_user)
                    '
                    warningCustom("Alokasi biaya diajukan, menunggu persetujuan")
                    FormBiayaSewa.load_biaya_bulanan_pps()
                    Close()
                End If
            End If
        Else
            warningCustom("Alokasi biaya bulan lalu belum dilaksanakan.")
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
        If GVDepreciation.RowCount > 0 Then
            makeSafeGV(GVDepreciation)
            Dim jum_row As Integer = 0
            'detil
            For i As Integer = 0 To GVDepreciation.RowCount - 1
                'dep
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVDepreciation.GetRowCellValue(i, "acc_uang_muka_name").ToString
                newRow("acc_description") = GVDepreciation.GetRowCellValue(i, "acc_uang_muka").ToString
                newRow("cc") = "000"
                newRow("report_number") = TENumber.Text
                newRow("note") = "Alokasi biaya " & GVDepreciation.GetRowCellValue(i, "description").ToString & "(" & Date.Parse(DEReffDate.EditValue.ToString).ToString("MMMM yyyy") & ")"
                newRow("debit") = 0
                newRow("credit") = GVDepreciation.GetRowCellValue(i, "alokasi_biaya_per_bulan")
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
                GVDraft.BestFitColumns()
            Next
            For i As Integer = 0 To GVDepreciation.RowCount - 1
                'accum
                jum_row += 1
                Dim newRow_accum As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow_accum("no") = jum_row
                newRow_accum("acc_name") = GVDepreciation.GetRowCellValue(i, "acc_biaya_name").ToString
                newRow_accum("acc_description") = GVDepreciation.GetRowCellValue(i, "acc_biaya").ToString
                newRow_accum("cc") = "000"
                newRow_accum("report_number") = TENumber.Text
                newRow_accum("note") = "Alokasi biaya " & GVDepreciation.GetRowCellValue(i, "description").ToString & "(" & Date.Parse(DEReffDate.EditValue.ToString).ToString("MMMM yyyy") & ")"
                newRow_accum("debit") = GVDepreciation.GetRowCellValue(i, "alokasi_biaya_per_bulan")
                newRow_accum("credit") = 0
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow_accum)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCDep_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDep.SelectedPageChanged
        If XTCDep.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "294"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_biaya_bulanan
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans 
            WHERE ad.report_mark_type=294 AND ad.id_report=" + id_biaya_bulanan + "
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ReportBiayaSewaBulanan.id_biaya = id_biaya_bulanan
        ReportBiayaSewaBulanan.id_report_status = id_report_status
        ReportBiayaSewaBulanan.dt = GCDepreciation.DataSource
        Dim Report As New ReportBiayaSewaBulanan()


        'creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDepreciation.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDepreciation.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVDepreciation)
        Report.GVDepreciation.OptionsPrint.AllowMultilineHeaders = True

        'Parse Val
        Report.LNumber.Text = TENumber.Text.ToUpper
        Report.LDateCreated.Text = DECreatedDate.Text.ToUpper
        Report.LENDPeriod.Text = DEReffDate.Text.ToUpper
        Report.Lunit.Text = SLEUnit.Text.ToUpper

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub
End Class