Public Class FormBiayaSewaPPS
    Public id_pps As String = "-1"
    Dim id_report_status As String = "1"
    Public is_view As String = "-1"

    Dim def_id_acc As String = "-1"

    Private Sub FormBiayaSewaPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_unit()
        load_acc()

        DECreatedDate.EditValue = getTimeDB()
        '
        TENumber.Text = "[auto number]"
        TECreatedBy.Text = "[auto]"
        '
        If id_pps = "-1" Then
            'new
            BMark.Visible = False
            BtnPrint.Visible = False
        Else
            'edit
            BMark.Visible = True
            BtnPrint.Visible = True
            SLEUnit.Properties.ReadOnly = True
            PCAddDel.Visible = False

            Dim q As String = "SELECT pps.*,emp.employee_name 
FROM `tb_biaya_sewa_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_biaya_sewa_bulanan='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                SLEUnit.EditValue = dt.Rows(0)("id_coa_tag").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
                If dt.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                End If
            End If
        End If
        load_det()
        check_but()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*,acc_uangmuka.`acc_description` AS acc_uang_muka,acc_biaya.`acc_description` AS acc_biaya,acc_prepaid.`acc_description` AS acc_prepaid_non_current
FROM `tb_biaya_sewa_pps_det` ppsd
INNER JOIN tb_a_acc acc_uangmuka ON acc_uangmuka.id_acc=ppsd.coa_uang_muka
INNER JOIN tb_a_acc acc_biaya ON acc_biaya.id_acc=ppsd.coa_biaya
INNER JOIN tb_a_acc acc_prepaid ON acc_prepaid.id_acc=ppsd.coa_prepaid_non_current
WHERE ppsd.id_biaya_sewa_pps='" & id_pps & "'"
        GCItem.DataSource = execute_query(q, -1, True, "", "", "", "")
    End Sub

    Private Sub RIDEReffDate_EditValueChanged(sender As Object, e As EventArgs) Handles RIDEReffDate.EditValueChanged
        Try
            sender.EditValue = New DateTime(sender.EditValue.Year, sender.EditValue.Month, Date.DaysInMonth(sender.EditValue.Year, sender.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

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

    Sub load_acc()
        Dim q As String = "SELECT id_acc,acc_name,acc_description,CONCAT(acc_name,' - ',acc_description) AS full_desc FROM tb_a_acc WHERE id_is_det=2 AND id_status=1 AND id_coa_type='" & If(SLEUnit.EditValue.ToString = "1", "1", "2") & "'"
        viewSearchLookupRepositoryQuery(RISLEPrepaid, q, 0, "full_desc", "id_acc")
        def_id_acc = execute_query(q, 0, True, "", "", "", "")
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVItem.RowCount > 0 Then
            GVItem.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Sub check_but()
        If GVItem.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCItem.DataSource, DataTable)).NewRow()
        newRow("date_reff") = Now()
        '
        newRow("coa_prepaid_non_current") = def_id_acc
        newRow("coa_uang_muka") = def_id_acc
        newRow("coa_biaya") = def_id_acc
        '
        newRow("total_uang_muka") = 0.00
        newRow("total_bulan") = 12
        '
        TryCast(GCItem.DataSource, DataTable).Rows.Add(newRow)
        GCItem.RefreshDataSource()
        GVItem.RefreshData()

        load_acc()
        check_but()
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

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        load_acc()
        'reset gv
        For i As Integer = GVItem.RowCount - 1 To 0 Step -1
            GVItem.DeleteRow(i)
        Next
        check_but()
    End Sub

    Private Sub XTCDep_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDep.SelectedPageChanged
        If XTCDep.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVItem.RowCount > 0 Then
            makeSafeGV(GVItem)
            Dim jum_row As Integer = 0
            'detil
            For i As Integer = 0 To GVItem.RowCount - 1
                '
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = get_acc(GVItem.GetRowCellValue(i, "coa_uang_muka").ToString, "1")
                newRow("acc_description") = get_acc(GVItem.GetRowCellValue(i, "coa_uang_muka").ToString, "2")
                newRow("cc") = "000"
                newRow("report_number") = TENumber.Text
                newRow("note") = "Alokasi " & GVItem.GetRowCellValue(i, "description").ToString & " untuk " & GVItem.GetRowCellValue(i, "description").ToString & " bulan"
                newRow("debit") = GVItem.GetRowCellValue(i, "total_uang_muka")
                newRow("credit") = 0
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
                GVDraft.BestFitColumns()
            Next
            For i As Integer = 0 To GVItem.RowCount - 1
                '
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = get_acc(GVItem.GetRowCellValue(i, "coa_prepaid_non_current").ToString, "1")
                newRow("acc_description") = get_acc(GVItem.GetRowCellValue(i, "coa_prepaid_non_current").ToString, "2")
                newRow("cc") = "000"
                newRow("report_number") = TENumber.Text
                newRow("note") = "Alokasi " & GVItem.GetRowCellValue(i, "description").ToString & " untuk " & GVItem.GetRowCellValue(i, "description").ToString & " bulan"
                newRow("debit") = 0
                newRow("credit") = GVItem.GetRowCellValue(i, "total_uang_muka")
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
                GVDraft.BestFitColumns()
            Next
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check bulan sebelumnya udh belum or ada pending (pending waktu teken add)
        If GVItem.RowCount = 0 Then
            warningCustom("Please insert item first.")
        Else
            If id_pps = "-1" Then 'new
                Dim q As String = "INSERT INTO `tb_biaya_sewa_pps`(`created_by`,`created_date`,`id_report_status`,id_coa_tag)
VALUES('" & id_user & "',NOW(),'1','" & SLEUnit.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(q, 0, True, "", "", "", "")
                'det
                q = "INSERT INTO tb_biaya_sewa_pps_det(`id_biaya_sewa_pps`,`description`,`date_reff`,`total_uang_muka`,`total_bulan`,`coa_prepaid_non_current`,`coa_uang_muka`,`coa_biaya`) VALUES"
                For i As Integer = 0 To GVItem.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & addSlashes(GVItem.GetRowCellValue(i, "description").ToString) & "','" & Date.Parse(GVItem.GetRowCellValue(i, "date_reff").ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(GVItem.GetRowCellValue(i, "total_uang_muka").ToString) & "','" & GVItem.GetRowCellValue(i, "total_bulan").ToString & "','" & GVItem.GetRowCellValue(i, "coa_prepaid_non_current").ToString & "','" & GVItem.GetRowCellValue(i, "coa_uang_muka").ToString & "','" & GVItem.GetRowCellValue(i, "coa_biaya").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id_pps & "','295')"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("295", id_pps, id_user)
                '
                warningCustom("Master alokasi biaya diajukan, menunggu persetujuan")
                FormBiayaSewa.XTCBiayaSewa.SelectedTabPageIndex = 2
                FormBiayaSewa.load_pps()
                Close()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "295"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_pps
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans 
            WHERE ad.report_mark_type=295 AND ad.id_report=" + id_pps + "
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

    End Sub
End Class