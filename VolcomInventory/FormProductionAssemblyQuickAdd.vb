Public Class FormProductionAssemblyQuickAdd
    Private Sub BtnAddComponent_Click(sender As Object, e As EventArgs) Handles BtnAddComponent.Click
        Cursor = Cursors.WaitCursor
        FormProductionAssemblyComp.id_pop_up = "1"
        FormProductionAssemblyComp.data_par = GCComponent.DataSource
        FormProductionAssemblyComp.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProductionAssemblyQuickAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_prod_ass_comp_all(" + FormProductionAssemblySingle.id_prod_ass + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComponent.DataSource = data
        Cursor = Cursors.Default
    End Sub
End Class