Public Class FormAdjustmentOGDet
    Public id_adjustment As String = "-1"

    Private Sub FormAdjustmentOGDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()
        view_departement()
        view_report_status()

        form_load()
    End Sub

    Private Sub FormAdjustmentOGDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT 1 AS id_type, 0 AS id_departement_from, 0 AS id_departement_to, '[autogenerate]' AS number, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at, '" + get_emp(id_employee_user, "2") + "' AS created_by, 1 AS report_status
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        SLUEType.EditValue = data.Rows(0)("id_type").ToString
        SLUEFromDepartment.EditValue = data.Rows(0)("id_departement_from").ToString
        SLUEToDepartement.EditValue = data.Rows(0)("id_departement_to").ToString
        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedAt.EditValue = data.Rows(0)("created_at").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        SLUEStatus.EditValue = data.Rows(0)("report_status").ToString

        Dim query_detail As String = "
            SELECT *
            FROM (
                SELECT 0 AS id_item, '' AS item_desc, '' AS uom, '' AS item_cat, '' AS qty, '' AS `value`
            ) AS tb 
            WHERE id_item = 1
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCList.DataSource = data_detail

        GVList.BestFitColumns()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormAdjustmentOGPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Sub view_type()
        Dim query As String = "
            SELECT 1 AS id_type, 'Adjustment' AS `type`
            UNION ALL
            SELECT 2 AS id_type, 'Transfer' AS `type`
        "

        viewSearchLookupQuery(SLUEType, query, "id_type", "type", "id_type")
    End Sub

    Sub view_departement()
        Dim query As String = "
            SELECT 0 as id_departement, 'Purchasing Storage' as departement
            UNION ALL            
            SELECT id_departement, departement FROM tb_m_departement
        "

        viewSearchLookupQuery(SLUEFromDepartment, query, "id_departement", "departement", "id_departement")
        viewSearchLookupQuery(SLUEToDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_report_status()
        Dim query As String = "
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        If SLUEType.EditValue.ToString = "1" Then
            Label5.Visible = False
            SLUEToDepartement.Visible = False
        Else
            Label5.Visible = True
            SLUEToDepartement.Visible = True
        End If
    End Sub
End Class