Public Class FormAPReport
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormARAging_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormARAging_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAPReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_comp()
    End Sub

    Sub load_comp()
        Cursor = Cursors.WaitCursor

        Dim query As String = "SELECT 0 AS id_comp,'All' as comp_name
        UNION
        SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c"

        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAPReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class