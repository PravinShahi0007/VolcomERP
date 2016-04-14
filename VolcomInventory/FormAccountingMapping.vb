Public Class FormAccountingMapping

    Private Sub FormAccountingMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_asg()
    End Sub

    Sub view_asg()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM tb_lookup_report_mark_type"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMarkAssign.DataSource = data
    End Sub

    Private Sub FormAccountingMapping_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAccountingMapping_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class