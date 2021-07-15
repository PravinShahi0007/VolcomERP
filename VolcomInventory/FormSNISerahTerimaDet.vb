Public Class FormSNISerahTerimaDet
    Public id As String = "-1"
    Private Sub FormSNISerahTerimaDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSNISerahTerimaDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        If Not TEBudgetNumber.Text = "" Then
            Dim q As String = ""
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

            If dt.Rows.Count > 0 Then
                TEBudgetNumber.Properties.ReadOnly = True
            Else
                warningCustom("Budget number not found or already used.")
                TEBudgetNumber.Properties.ReadOnly = True
            End If
        End If
    End Sub
End Class