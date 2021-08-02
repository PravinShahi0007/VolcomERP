Public Class FormPurcAssetDep
    Public id_dep As String = "-1"
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
        DEReffDate.EditValue = Now
        DECreatedDate.EditValue = Now
        '
        TENumber.Text = "[auto number]"
        TECreatedBy.Text = "[auto]"
        '
        If id_dep = "-1" Then
            BMark.Visible = False
            BtnPrint.Visible = False
        Else
            BMark.Visible = True
            BtnPrint.Visible = True
            DEReffDate.Properties.ReadOnly = True
            SLEUnit.Properties.ReadOnly = True
            BLoadAsset.Visible = False
            '
            Dim q As String = "SELECT pps.*,emp.employee_name FROM `tb_asset_dep_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_asset_dep_pps='" & id_dep & "'"
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
        Dim q As String = "SELECT ass.useful_life+ass.month_added AS useful_life,ppsd.remaining_life AS life,ppsd.remaining_life, ppsd.id_acc_dep, ppsd.id_acc_dep_accum,accdep.acc_description AS acc_dep,accacum.acc_description AS acc_dep_accum,accdep.acc_name AS acc_dep_name,accacum.acc_name AS acc_dep_accum_name
,ass.`asset_name`,ass.acq_date,ppsd.remaining_life AS rem_life
,ass.id_acc_dep
,ass.acq_cost + ass.value_added AS acq_cost,ppsd.dep_value,ppsd.accum_dep
FROM `tb_asset_dep_pps_det` ppsd
INNER JOIN tb_a_acc accdep ON accdep.id_acc=ppsd.id_acc_dep
INNER JOIN tb_a_acc accacum ON accacum.id_acc=ppsd.id_acc_dep_accum
INNER JOIN tb_purc_rec_asset ass ON ass.id_purc_rec_asset=ppsd.id_purc_rec_asset
WHERE ppsd.id_asset_dep_pps='" & id_dep & "'"
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
        Dim qc As String = "SELECT * FROM `tb_asset_dep_pps`
WHERE DATE_FORMAT(reff_date,'%m%Y')=DATE_FORMAT(LAST_DAY(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH)),'%m%Y') AND id_report_status=6 AND id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2021-07-31" Then
            'check dulu sudah input belum
            qc = "SELECT * FROM tb_asset_dep_pps WHERE reff_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND id_report_status!=5 AND id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
            Dim dtd As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtd.Rows.Count > 0 Then
                warningCustom("Depreciation for this month already created")
            Else
                Dim q As String = "SET @end_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "';
SELECT ass.useful_life+ass.month_added AS useful_life,0 AS id_asset_dep_pps_det, ass.id_purc_rec_asset, ass.id_acc_dep, ass.id_acc_dep_accum
,accdep.acc_description AS acc_dep,accacum.acc_description AS acc_dep_accum
,accdep.acc_name AS acc_dep_name,accacum.acc_name AS acc_dep_accum_name
,CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) +
  DATEDIFF(
    @end_date,
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date)
    MONTH
  ) /
  DATEDIFF(
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + 1
    MONTH,
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date)
    MONTH
  )) AS life
,ass.`asset_name`,ass.acq_date,ass.`useful_life`+ass.`month_added`-(SELECT life) AS rem_life
,id_acc_dep
,IFNULL(accum_dep.accum_dep,0.00) AS accum_dep
,(ass.acq_cost+ass.value_added) AS acq_cost
,IF((SELECT rem_life)=0,((ass.acq_cost+ass.value_added)-IFNULL(accum_dep.accum_dep,0.00)),ROUND((ass.acq_cost+ass.value_added)/(ass.useful_life+ass.`month_added`),2)) AS dep_value
FROM tb_purc_rec_asset ass
INNER JOIN tb_a_acc accdep ON accdep.id_acc=ass.id_acc_dep
INNER JOIN tb_a_acc accacum ON accacum.id_acc=ass.id_acc_dep_accum
LEFT JOIN
(
    SELECT id_purc_rec_asset,SUM(amount) AS accum_dep
    FROM 
    `tb_purc_rec_asset_dep` ass
    GROUP BY id_purc_rec_asset
)accum_dep ON accum_dep.id_purc_rec_asset=ass.id_purc_rec_asset
WHERE 
ass.is_active=1 AND ass.id_coa_tag='" & SLEUnit.EditValue.ToString & "' AND
CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + DATEDIFF(@end_date,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH) / DATEDIFF(ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + 1 MONTH,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH)) 
<=ass.`useful_life` AND ass.acq_date<=@end_date AND ass.acq_date>='2020-01-01'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCDepreciation.DataSource = dt
                GVDepreciation.BestFitColumns()
                DEReffDate.Properties.ReadOnly = True
                SLEUnit.Properties.ReadOnly = True
            End If
        Else
            warningCustom("Last month depreciation is not posted yet.")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check bulan sebelumnya udh belum or ada pending (pending waktu teken add)
        Dim qc As String = "SELECT * FROM `tb_asset_dep_pps`
WHERE DATE_FORMAT(reff_date,'%m%Y')=DATE_FORMAT(LAST_DAY(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH)),'%m%Y') AND id_report_status=6 AND id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2021-07-31" Then
            If GVDepreciation.RowCount = 0 Then
                warningCustom("Please load depreciation first")
            Else
                If id_dep = "-1" Then 'new
                    Dim q As String = "INSERT INTO `tb_asset_dep_pps`(created_date,created_by,reff_date,id_coa_tag)
VALUES(DATE(NOW()),'" & id_user & "','" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & SLEUnit.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                    id_dep = execute_query(q, 0, True, "", "", "", "")
                    'det
                    q = "INSERT INTO tb_asset_dep_pps_det(`id_asset_dep_pps`,`id_purc_rec_asset`,`id_acc_dep`,`id_acc_dep_accum`,`accum_dep`,`remaining_life`,`dep_value`) VALUES"
                    For i As Integer = 0 To GVDepreciation.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_dep & "','" & GVDepreciation.GetRowCellValue(i, "id_purc_rec_asset").ToString & "','" & GVDepreciation.GetRowCellValue(i, "id_acc_dep").ToString & "','" & GVDepreciation.GetRowCellValue(i, "id_acc_dep_accum").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "accum_dep").ToString) & "','" & GVDepreciation.GetRowCellValue(i, "rem_life").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "dep_value").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id_dep & "','287')"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    submit_who_prepared("287", id_dep, id_user)
                    '
                    warningCustom("Depreciation created, waiting to approve")
                    FormPurcAsset.load_dep_pps()
                    Close()
                End If
            End If
        Else
            warningCustom("Last month depreciation is not posted yet.")
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
                newRow("acc_name") = GVDepreciation.GetRowCellValue(i, "acc_dep_name").ToString
                newRow("acc_description") = GVDepreciation.GetRowCellValue(i, "acc_dep").ToString
                newRow("cc") = "000"
                newRow("report_number") = TENumber.Text
                newRow("note") = "Depreciation " & GVDepreciation.GetRowCellValue(i, "asset_name").ToString & "(" & Date.Parse(DEReffDate.EditValue.ToString).ToString("MMMM yyyy") & ")"
                newRow("debit") = GVDepreciation.GetRowCellValue(i, "dep_value")
                newRow("credit") = 0
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
                newRow_accum("acc_name") = GVDepreciation.GetRowCellValue(i, "acc_dep_accum_name").ToString
                newRow_accum("acc_description") = GVDepreciation.GetRowCellValue(i, "acc_dep_accum").ToString
                newRow_accum("cc") = "000"
                newRow_accum("report_number") = TENumber.Text
                newRow_accum("note") = "Accumulation depreciation " & GVDepreciation.GetRowCellValue(i, "asset_name").ToString & "(" & Date.Parse(DEReffDate.EditValue.ToString).ToString("MMMM yyyy") & ")"
                newRow_accum("debit") = 0
                newRow_accum("credit") = GVDepreciation.GetRowCellValue(i, "dep_value")
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
        FormReportMark.report_mark_type = "287"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_dep
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans 
            WHERE ad.report_mark_type=287 AND ad.id_report=" + id_dep + "
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
        ReportPurcAssetDep.id_dep = id_dep
        ReportPurcAssetDep.id_report_status = id_report_status
        ReportPurcAssetDep.dt = GCDepreciation.DataSource
        Dim Report As New ReportPurcAssetDep()


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