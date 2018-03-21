Public Class FormMasterAsset
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Private Sub FormMasterAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now

        load_pil()
        load_asset()
        load_moving_log()
    End Sub
    Sub load_asset()
        Dim where_string As String = ""
        If LEPil.EditValue.ToString = "1" Then
            'by PO date
            where_string = " WHERE ass.po_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND ass.po_date<='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf LEPil.EditValue.ToString = "2" Then
            'by rec date
            where_string = " WHERE ass.rec_date >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND ass.rec_date<='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        End If
        '
        Dim query As String = "SELECT ass.id_asset,ass.id_asset_cat,cat.asset_cat,vendor_code,asset_code_old,asset_code,asset_desc,po_no,po_qty,po_value,po_date,rec_date,rec_qty,rec_value,age
                                ,DATE_ADD(rec_date,INTERVAL age MONTH) AS date_aging
                                ,MONTH(DATEDIFF(rec_date,NOW())) AS age_current
                                ,rec_value/age AS monthly_dep
                                ,IF(age>=(SELECT age_current),0,(rec_value-((SELECT age_current)*(SELECT monthly_dep)))) AS current_value
                                ,IF(ISNULL(cur_user.id_asset),emp.employee_name,cur_user.employee_name) AS employee_name
                                ,IF(ISNULL(cur_user.id_asset),ass.id_employee,cur_user.id_employee) AS id_employee
                                ,IF(ISNULL(cur_user.id_asset),dep.departement,cur_user.departement) AS departement
                                ,IF(ISNULL(cur_user.id_asset),ass.id_departement,cur_user.id_departement) AS id_departement
                                FROM tb_a_asset ass
                                LEFT JOIN tb_m_employee emp ON emp.id_employee=ass.id_employee
                                LEFT JOIN
                                (
                                        SELECT a.id_asset,emp.`employee_name`,emp.`id_employee`,dep.`departement`,dep.`id_departement` FROM
                                    (
	                                SELECT * FROM tb_a_asset_log ORDER BY `date` DESC ,id_asset_log DESC
                                    )a 
                                    LEFT JOIN tb_m_employee emp ON emp.`id_employee`=a.id_employee
                                    INNER JOIN tb_m_departement dep ON dep.`id_departement`=a.id_departement
                                    GROUP BY a.id_asset
                                )cur_user ON cur_user.id_asset=ass.id_asset
                                INNER JOIN tb_m_departement dep ON dep.id_departement=ass.id_departement
                                INNER JOIN tb_a_asset_cat cat ON cat.id_asset_cat=ass.id_asset_cat " & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAsset.DataSource = data
        GVAsset.BestFitColumns()
        check_but()
    End Sub
    Sub load_moving_log()
        If GVAsset.RowCount > 0 Then
            Dim query As String = "SELECT assl.*,dep.`departement`,emp.`employee_name`,dep_new.`departement` AS departement_new,emp_new.`employee_name` AS employee_name_new FROM tb_a_asset_log assl 
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=assl.`id_departement_old`
                                LEFT JOIN tb_m_employee emp ON emp.`id_employee`=assl.`id_employee_old`
                                INNER JOIN tb_m_departement dep_new ON dep_new.`id_departement`=assl.`id_departement`
                                LEFT JOIN tb_m_employee emp_new ON emp_new.`id_employee`=assl.`id_employee`
                                WHERE assl.id_asset='" & GVAsset.GetFocusedRowCellValue("id_asset").ToString & "'
                                ORDER BY assl.date DESC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCAssetMovingLog.DataSource = data
            GVAssetMovingLog.BestFitColumns()
        End If
        check_but()
    End Sub
    Sub load_pil()
        Dim query As String = "SELECT '1' id_pil,'By PO Date' as pil_name
                                UNION
                               SELECT '2' id_pil,'By REC Date' as pil_name"
        viewLookupQuery(LEPil, query, 0, "pil_name", "id_pil")
    End Sub
    Sub check_but()
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            If GVAsset.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterAssetCategory_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormMasterAssetCategory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterAssetCategory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_asset()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        check_but()
    End Sub

    Private Sub GVAsset_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAsset.FocusedRowChanged
        load_moving_log()
    End Sub

    Private Sub GVAssetMovingLog_DoubleClick(sender As Object, e As EventArgs) Handles GVAssetMovingLog.DoubleClick
        If GVAssetMovingLog.RowCount > 0 Then
            FormMasterAssetLog.id_asset = GVAsset.GetFocusedRowCellValue("id_asset").ToString
            FormMasterAssetLog.id_asset_log = GVAssetMovingLog.GetFocusedRowCellValue("id_asset_log").ToString
            FormMasterAssetLog.ShowDialog()
        End If
    End Sub
End Class