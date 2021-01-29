Public Class FormPurcAssetDep
    Public id_dep As String = "-1"
    Dim id_report_status As String = "1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPurcAssetDep_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcAssetDep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            End If
        End If

        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ass.useful_life,ass.useful_life,ppsd.remaining_life AS life,ppsd.remaining_life, ass.id_acc_dep, ass.id_acc_dep_accum,accdep.acc_description AS acc_dep,accacum.acc_description AS acc_dep_accum,accdep.acc_name AS acc_dep_name,accacum.acc_name AS acc_dep_accum_name
,ass.`asset_name`,ass.acq_date,ppsd.remaining_life
,ass.id_acc_dep
,ass.acq_cost,ppsd.dep_value,ppsd.accum_dep
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
WHERE DATE_FORMAT(NOW(),'%m%Y')=DATE_FORMAT(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH),'%m%Y') AND id_report_status=6"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2020-01-31" Then
            'check dulu sudah input belum
            qc = "SELECT * FROM tb_asset_dep_pps WHERE reff_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND id_report_status!=5"
            Dim dtd As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtd.Rows.Count > 0 Then
                warningCustom("Depreciation for this month already created")
            Else
                Dim q As String = "SET @end_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "';
SELECT ass.useful_life,0 AS id_asset_dep_pps_det, ass.id_purc_rec_asset, ass.id_acc_dep, ass.id_acc_dep_accum,accdep.acc_description AS acc_dep,accacum.acc_description AS acc_dep_accum,accdep.acc_name AS acc_dep_name,accacum.acc_name AS acc_dep_accum_name,
CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) +
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
,ass.`asset_name`,ass.acq_date,ass.`useful_life`-(SELECT life) AS rem_life
,id_acc_dep
,ass.acq_cost,ass.acq_cost/ass.useful_life AS dep_value,IFNULL(accum_dep.accum_dep,0.00) AS accum_dep_value
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
CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + DATEDIFF(@end_date,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH) / DATEDIFF(ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + 1 MONTH,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH)) 
<=ass.`useful_life` AND ass.acq_date<=@end_date AND ass.acq_date>='2020-01-01'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCDepreciation.DataSource = dt
                GVDepreciation.BestFitColumns()
                DEReffDate.Properties.ReadOnly = True
            End If
        Else
            warningCustom("Last month depreciation is not posted yet.")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check bulan sebelumnya udh belum or ada pending (pending waktu teken add)
        Dim qc As String = "SELECT * FROM `tb_asset_dep_pps`
WHERE DATE_FORMAT(NOW(),'%m%Y')=DATE_FORMAT(DATE_SUB('" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH),'%m%Y') AND id_report_status=6"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Or Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") = "2020-01-31" Then
            If GVDepreciation.RowCount = 0 Then
                warningCustom("Please load depreciation first")
            Else
                If id_dep = "-1" Then 'new
                    Dim q As String = "INSERT INTO `tb_asset_dep_pps`(created_date,created_by,reff_date)
VALUES(DATE(NOW()),'" & id_user & "','" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID(); "
                    id_dep = execute_query(q, 0, True, "", "", "", "")
                    'det
                    q = "INSERT INTO tb_asset_dep_pps_det(`id_asset_dep_pps`,`id_purc_rec_asset`,`id_acc_dep`,`id_acc_dep_accum`,`accum_dep`,`remaining_life`,`dep_value`) VALUES"
                    For i As Integer = 0 To GVDepreciation.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_dep & "','" & GVDepreciation.GetRowCellValue(i, "id_purc_rec_asset").ToString & "','" & GVDepreciation.GetRowCellValue(i, "id_acc_dep").ToString & "','" & GVDepreciation.GetRowCellValue(i, "id_acc_dep_accum").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "id_acc_dep_accum").ToString) & "','" & GVDepreciation.GetRowCellValue(i, "rem_life").ToString & "','" & decimalSQL(GVDepreciation.GetRowCellValue(i, "dep_value").ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id_dep & "','287')"
                    execute_non_query(q, True, "", "", "", "")
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
                newRow("debit") = 0
                newRow("credit") = GVDepreciation.GetRowCellValue(i, "dep_value")
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
                'accum
                jum_row += 1
                Dim newRow_accum As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow_accum("no") = jum_row
                newRow_accum("acc_name") = GVDepreciation.GetRowCellValue(i, "acc_dep_accum_name").ToString
                newRow_accum("acc_description") = GVDepreciation.GetRowCellValue(i, "acc_dep_accum").ToString
                newRow_accum("cc") = "000"
                newRow_accum("report_number") = TENumber.Text
                newRow_accum("note") = "Accumulation depreciation " & GVDepreciation.GetRowCellValue(i, "asset_name").ToString & "(" & Date.Parse(DEReffDate.EditValue.ToString).ToString("MMMM yyyy") & ")"
                newRow_accum("debit") = GVDepreciation.GetRowCellValue(i, "dep_value")
                newRow_accum("credit") = 0
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow_accum)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
            GVDraft.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCDep_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDep.SelectedPageChanged
        If XTCDep.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub
End Class