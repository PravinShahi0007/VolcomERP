Public Class FormSampleBudgetDet
    Public id_pps As String = "-1"
    Public is_rev As String = "2"
    Private Sub FormSampleBudgetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pps = "-1" Then 'new
            TENumber.Text = "[auto_generate]"
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEDateCreated.EditValue = Now
            '
            PCAddDelete.Visible = True
            BtnSave.Visible = True
            BtnPrint.Visible = False
            BMark.Visible = False
        Else 'view
            Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_sample_budget_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
WHERE pps.id_sample_budget_pps = '" & id_pps & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                If data.Rows(0)("id_type").ToString = "2" Then
                    is_rev = "1"
                End If
                '
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TECreatedBy.Text = data.Rows(0)("employee_name")
                MENote.Text = data.Rows(0)("note").ToString
            End If
            '
            PCAddDelete.Visible = False
            BtnSave.Visible = False
            BtnPrint.Visible = True
            BMark.Visible = True
        End If
        '
        load_before_det()
        load_after_det()
        '
        If is_rev = "1" Then
            XTPBefore.PageVisible = True
            BAdd.Visible = False
            '
            If id_pps = "-1" Then 'new
                For i As Integer = 0 To FormSampleBudget.GVBudgetList.RowCount - 1
                    'before
                    Dim newRow_before As DataRow = (TryCast(GCBefore.DataSource, DataTable)).NewRow()
                    newRow_before("description_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "description").ToString
                    newRow_before("year_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "year").ToString
                    newRow_before("value_usd_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_usd")
                    newRow_before("value_rp_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_rp")
                    newRow_before("id_division_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "id_division").ToString
                    newRow_before("division_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "division").ToString
                    TryCast(GCBefore.DataSource, DataTable).Rows.Add(newRow_before)
                    GCBefore.RefreshDataSource()
                    GVBefore.RefreshData()
                    GVBefore.FocusedRowHandle = GVBefore.RowCount - 1
                    'after
                    Dim newRow_after As DataRow = (TryCast(GCAfter.DataSource, DataTable)).NewRow()
                    newRow_after("description_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "description").ToString
                    newRow_after("year_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "year").ToString
                    newRow_after("value_usd_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_usd")
                    newRow_after("value_rp_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_rp")
                    newRow_after("id_division_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "id_division").ToString
                    newRow_after("division_before") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "division").ToString
                    newRow_after("description_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "description").ToString
                    newRow_after("year_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "year").ToString
                    newRow_after("value_usd_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_usd")
                    newRow_after("value_rp_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "value_rp")
                    newRow_after("id_division_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "id_division").ToString
                    newRow_after("division_after") = FormSampleBudget.GVBudgetList.GetRowCellValue(i, "division").ToString
                    TryCast(GCAfter.DataSource, DataTable).Rows.Add(newRow_after)
                    GCAfter.RefreshDataSource()
                    GVAfter.RefreshData()
                    GVAfter.FocusedRowHandle = GVAfter.RowCount - 1
                Next
            End If
        Else
            XTPBefore.PageVisible = False
            BAdd.Visible = True
        End If
        '
        check_but()
    End Sub

    Sub load_before_det()
        Dim query As String = "SELECT ppd.*
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`id_code_detail`,'')) AS id_division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`id_code_detail`,'')) AS id_division_before 
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`code_detail_name`,'')) AS division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`code_detail_name`,'')) AS division_before 
FROM `tb_sample_budget_pps_det` ppd
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_after ON ppdiv_after.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_after.is_after='1'
LEFT JOIN tb_m_code_detail cd_after ON cd_after.`id_code_detail`=ppdiv_after.`id_code_division`
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_before ON ppdiv_before.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_before.is_after='2'
LEFT JOIN tb_m_code_detail cd_before ON cd_before.`id_code_detail`=ppdiv_before.`id_code_division`
WHERE ppd.id_sample_budget_pps='" & id_pps & "'
GROUP BY ppd.id_sample_budget_pps_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBefore.DataSource = data
        GVBefore.BestFitColumns()
    End Sub

    Sub load_after_det()
        Dim query As String = "SELECT ppd.*
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`id_code_detail`,'')) AS id_division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`id_code_detail`,'')) AS id_division_before 
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`code_detail_name`,'')) AS division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`code_detail_name`,'')) AS division_before 
FROM `tb_sample_budget_pps_det` ppd
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_after ON ppdiv_after.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_after.is_after='1'
LEFT JOIN tb_m_code_detail cd_after ON cd_after.`id_code_detail`=ppdiv_after.`id_code_division`
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_before ON ppdiv_before.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_before.is_after='2'
LEFT JOIN tb_m_code_detail cd_before ON cd_before.`id_code_detail`=ppdiv_before.`id_code_division`
WHERE ppd.id_sample_budget_pps='" & id_pps & "' 
GROUP BY ppd.id_sample_budget_pps_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleBudgetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_but()
        If is_rev = "1" Then
            BDel.Visible = False
        Else
            If GVAfter.RowCount > 0 Then
                BDel.Visible = True
            Else
                BDel.Visible = False
            End If
        End If
        '
        If GVAfter.RowCount > 0 Then
            BEdit.Visible = True
        Else
            BEdit.Visible = False
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        GVAfter.DeleteSelectedRows()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSampleBudgetSingle.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVAfter.RowCount <= 0 Then
            warningCustom("Please input proposed budget")
        Else
            If is_rev = "1" Then 'revision
                'header
                Dim query As String = "INSERT INTO `tb_sample_budget_pps`(`id_type`,`date_created`,`created_by`,`note`,`id_report_status`) 
VALUES('2',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1');SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(query, 0, True, "", "", "", "")

                query = "CALL gen_number('" & id_pps & "','175')"
                execute_non_query(query, True, "", "", "", "")

                'detail
                For i As Integer = 0 To GVAfter.RowCount - 1
                    Dim query_det As String = "INSERT INTO `tb_sample_budget_pps_det`(`id_sample_budget_pps`,`description_before`,`year_before`,`value_usd_before`,`value_rp_before`,`description_after`,`year_after`,`value_usd_after`,`value_rp_after`)
VALUES ('" & id_pps & "','" & addSlashes(GVAfter.GetRowCellValue(i, "description_before").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_before").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_before").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_before").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "description_after").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_after").ToString) & "'); SELECT LAST_INSERT_ID(); "
                    Dim id_det As String = execute_query(query_det, 0, True, "", "", "", "")
                    '
                    Dim query_div As String = ""
                    'after
                    Dim div_after() As String = GVAfter.GetRowCellValue(i, "id_division_after").ToString.Split(",")
                    For Each div As String In div_after
                        If Not query_div = "" Then
                            query_div += ","
                        End If
                        query_div += "('" & id_det & "','" & div.ToString & "','1')"
                    Next div
                    'before
                    Dim div_before() As String = GVAfter.GetRowCellValue(i, "id_division_before").ToString.Split(",")
                    For Each div As String In div_before
                        If Not query_div = "" Then
                            query_div += ","
                        End If
                        query_div += "('" & id_det & "','" & div.ToString & "','2')"
                    Next div

                    query_div = "INSERT INTO `tb_sample_budget_pps_div`(`id_sample_budget_pps_det`,`id_code_division`,`is_after`) VALUES" & query_div
                    execute_non_query(query_div, True, "", "", "", "")
                Next

                FormSampleBudget.XTCSampleBudget.SelectedTabPageIndex = 1
                FormSampleBudget.DEStart.EditValue = Now
                FormSampleBudget.DEUntil.EditValue = Now
                FormSampleBudget.load_propose()
                infoCustom("Revise budget proposed")
                Close()
            Else 'new
                Dim query As String = "INSERT INTO `tb_sample_budget_pps`(`id_type`,`date_created`,`created_by`,`note`,`id_report_status`) 
VALUES('1',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1');SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(query, 0, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_pps & "','175')"
                execute_non_query(query, True, "", "", "", "")
                'detail
                For i As Integer = 0 To GVAfter.RowCount - 1
                    Dim query_det As String = "INSERT INTO `tb_sample_budget_pps_det`(`id_sample_budget_pps`,`description_before`,`year_before`,`value_usd_before`,`value_rp_before`,`description_after`,`year_after`,`value_usd_after`,`value_rp_after`)
VALUES ('" & id_pps & "',NULL,NULL,NULL,NULL,'" & addSlashes(GVAfter.GetRowCellValue(i, "description_after").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_after").ToString) & "'); SELECT LAST_INSERT_ID(); "
                    Dim id_det As String = execute_query(query_det, 0, True, "", "", "", "")
                    '
                    Dim query_div As String = ""
                    'after
                    Dim div_after() As String = GVAfter.GetRowCellValue(i, "id_division_after").ToString.Split(",")
                    For Each div As String In div_after
                        If Not query_div = "" Then
                            query_div += ","
                        End If
                        query_div += "('" & id_det & "','" & div.ToString & "','1')"
                    Next div

                    query_div = "INSERT INTO `tb_sample_budget_pps_div`(`id_sample_budget_pps_det`,`id_code_division`,`is_after`) VALUES" & query_div
                    execute_non_query(query_div, True, "", "", "", "")
                Next

                infoCustom("Budget proposed")
                FormSampleBudget.XTCSampleBudget.SelectedTabPageIndex = 1
                FormSampleBudget.DEStart.EditValue = Now
                FormSampleBudget.DEUntil.EditValue = Now
                FormSampleBudget.load_propose()
                Close()
            End If
        End If
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormSampleBudgetSingle.is_edit = "1"
        FormSampleBudgetSingle.ShowDialog()
    End Sub
End Class