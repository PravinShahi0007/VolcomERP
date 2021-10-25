Public Class FormDisplayAllocLog
    Sub viewClass()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_class_group`, 'All' AS `class_group` 
        UNION ALL
        SELECT c.id_class_group, GROUP_CONCAT(DISTINCT cls.display_name ORDER BY cls.display_name ASC) AS `class_group` 
        FROM tb_class_group c
        INNER JOIN tb_class_group_det cd ON cd.id_class_group = c.id_class_group
        INNER JOIN tb_m_code_detail cls ON cls.id_code_Detail = cd.id_class
        GROUP BY c.id_class_group "
        viewSearchLookupQuery(SLEClass, query, "id_class_group", "class_group", "id_class_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewDisplayType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_display_type`, 'All' AS `display_type`
        UNION ALL
        SELECT dt.id_display_type, dt.display_type FROM tb_display_type dt "
        viewSearchLookupQuery(SLEDisplay, query, "id_display_type", "display_type", "id_display_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDisplayAllocLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewClass()
        viewDisplayType()
    End Sub

    Private Sub FormDisplayAllocLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLEClass_EditValueChanged(sender As Object, e As EventArgs) Handles SLEClass.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDisplay.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim where As String = ""
        Dim id_class_group As String = SLEClass.EditValue.ToString
        If id_class_group <> "0" Then
            where += "AND l.id_class_group = '" + id_class_group + "' "
        End If
        Dim id_display_type As String = SLEDisplay.EditValue.ToString
        If id_display_type <> "0" Then
            where += "AND l.id_display_type='" + id_display_type + "' "
        End If

        Dim query As String = "SELECT l.id_class_group, c.class_group, l.id_display_type, dt.display_type, 
        l.id_user, e.employee_name, l.log_date, l.`log` 
        FROM tb_display_alloc_log l
        INNER JOIN tb_class_group c ON c.id_class_group = l.id_class_group
        INNER JOIN tb_display_type dt ON dt.id_display_type = l.id_display_type
        INNER JOIN tb_m_user u ON u.id_user = l.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE 1=1 " + where + "
        ORDER BY l.log_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Log Update Display Capacity")
        Cursor = Cursors.Default
    End Sub
End Class