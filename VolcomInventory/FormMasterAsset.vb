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
        Dim query As String = "SELECT id_asset,ass.id_asset_cat,cat.asset_cat,vendor_code,asset_code_old,asset_code,asset_desc,ass.id_departement,dep.departement,ass.id_employee,emp.employee_name,po_no,po_qty,po_value,po_date,rec_date,rec_qty,rec_value,age
                                ,DATE_ADD(rec_date,INTERVAL age MONTH) AS date_aging
                                ,MONTH(DATEDIFF(rec_date,NOW())) AS age_current
                                ,rec_value/age AS monthly_dep
                                ,IF(age>=(SELECT age_current),0,(rec_value-((SELECT age_current)*(SELECT monthly_dep)))) AS current_value
                                FROM tb_a_asset ass
                                LEFT JOIN tb_m_employee emp ON emp.id_employee=ass.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=ass.id_departement
                                INNER JOIN tb_a_asset_cat cat ON cat.id_asset_cat=ass.id_asset_cat " & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAsset.DataSource = data
        check_but()
    End Sub
    Sub load_pil()
        Dim query As String = "SELECT '1' id_pil,'By PO Date' as pil_name
                                UNION
                               SELECT '2' id_pil,'By REC Date' as pil_name"
        viewLookupQuery(LEPil, query, 0, "pil_name", "id_pil")
    End Sub
    Sub check_but()
        If GVAsset.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
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
End Class