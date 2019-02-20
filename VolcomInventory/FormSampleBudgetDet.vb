Public Class FormSampleBudgetDet
    Dim id_pps As String = "-1"
    Dim is_rev As String = "2"
    Private Sub FormSampleBudgetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_before_det()
        load_after_det()

        If id_pps = "-1" Then 'new
            TECreatedBy.Text = ""
            DEDateCreated.EditValue = Now
        Else 'view

        End If

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
                Dim query_det As String = "INSERT INTO `tb_sample_budget_pps_det`(`id_sample_budget_pps`,`description_before`,`year_before`,`value_usd_before`,`value_rp_before`,`description_after`,`year_after`,`value_usd_after`,`value_rp_after`)
VALUES"
                For i As Integer = 0 To GVAfter.RowCount - 1
                    If Not i = 0 Then
                        query_det += ","
                    End If
                    query_det += "('" & id_pps & "','" & addSlashes(GVAfter.GetRowCellValue(i, "description_before").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_before").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_before").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_before").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "description_after").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_after").ToString) & "')"
                Next

                execute_non_query(query_det, True, "", "", "", "")
                infoCustom("budget proposed")
            Else 'new
                Dim query As String = "INSERT INTO `tb_sample_budget_pps`(`id_type`,`date_created`,`created_by`,`note`,`id_report_status`) 
VALUES('1',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1');SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(query, 0, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_pps & "','175')"
                execute_non_query(query, True, "", "", "", "")
                'detail
                Dim query_det As String = "INSERT INTO `tb_sample_budget_pps_det`(`id_sample_budget_pps`,`description_before`,`year_before`,`value_usd_before`,`value_rp_before`,`description_after`,`year_after`,`value_usd_after`,`value_rp_after`)
VALUES"
                For i As Integer = 0 To GVAfter.RowCount - 1
                    If Not i = 0 Then
                        query_det += ","
                    End If
                    query_det += "('" & id_pps & "',NULL,NULL,NULL,NULL,'" & addSlashes(GVAfter.GetRowCellValue(i, "description_after").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_usd_after").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_rp_after").ToString) & "')"
                Next

                execute_non_query(query_det, True, "", "", "", "")
                infoCustom("Budget proposed")
            End If
        End If
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormSampleBudgetSingle.is_edit = "1"
        FormSampleBudgetSingle.ShowDialog()
    End Sub
End Class