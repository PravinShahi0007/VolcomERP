Public Class FormEmpLeaveCutDet
    Public id_leave_cut As String = "-1"

    Private Sub FormEmpLeaveCutDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_leave_cut = "-1" Then
            FormEmpLeaveCutDetSetup.ShowDialog()
        End If
        If id_leave_cut = "-1" Then
            Close()
        Else
            load_det()
        End If
    End Sub

    Private Sub BGetEmployee_Click(sender As Object, e As EventArgs) Handles BGetEmployee.Click
        FormEmpLeaveCutEmp.id_leave_cut = id_leave_cut
        FormEmpLeaveCutEmp.ShowDialog()
    End Sub

    Sub load_det()
        Dim query As String = "CALL view_leave_cut('" & id_leave_cut & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveAdj.DataSource = data
        GVLeaveAdj.BestFitColumns()
    End Sub

    Private Sub BSetup_Click(sender As Object, e As EventArgs) Handles BSetup.Click
        FormEmpLeaveCutDetSetup.id_leave_cut = id_leave_cut
        FormEmpLeaveCutDetSetup.ShowDialog()
    End Sub

    Private Sub Bload_Click(sender As Object, e As EventArgs) Handles Bload.Click

    End Sub
End Class