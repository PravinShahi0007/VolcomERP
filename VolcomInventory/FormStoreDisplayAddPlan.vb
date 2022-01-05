Public Class FormStoreDisplayAddPlan
    Public id_trans As String = "-1"

    Private Sub FormStoreDisplayAddPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        TxtQtySKU.EditValue = 0
        Dim query As String = "SELECT cg.id_class_group, cg.class_group, 'No' AS `is_select` 
        FROM tb_class_group cg 
        LEFT JOIN tb_display_pps_plan dpp ON dpp.id_class_group = cg.id_class_group AND dpp.id_display_pps='" + id_trans + "'
        WHERE cg.is_active=1 AND ISNULL(dpp.id_class_group)
        ORDER BY cg.class_group ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormStoreDisplayAddPlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        GVData.ActiveFilterString = ""
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount <= 0 Then
            warningCustom("Please select class first")
        ElseIf TxtQtySKU.EditValue <= 0 Then
            warningCustom("Please input qty")
        Else
            Dim query As String = "INSERT INTO tb_display_pps_plan(id_display_pps, id_season, id_delivery, id_class_group, qty_sku) "
            For i As Integer = 0 To GVData.RowCount - 1

            Next
            actionLoad()
        End If
        GVData.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub
End Class