Public Class FormMKDEvent
    Private Sub FormMKDEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewOption()
    End Sub

    Private Sub FormMKDEvent_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMKDEvent_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub ViewOption()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `eos_day`, 'All' AS `note`
        UNION ALL
        SELECT r.eos_day, r.note 
        FROM tb_eos_reminder r
        ORDER BY eos_day ASC "
        viewSearchLookupQuery(SLEOption, query, "eos_day", "note", "eos_day")
        SLEOption.EditValue = 0
        Cursor = Cursors.Default
    End Sub
End Class