Public Class FormBudgetProdDemandNew
    Private Sub FormBudgetProdDemandNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
    End Sub

    Private Sub FormBudgetProdDemandNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        'cek ada outstanidng gk
        Dim qcek As String = "SELECT COUNT(*) AS `jum_created` 
        FROM tb_b_prod_demand_propose b
        WHERE b.`year`='" + DEYearBudget.Text + "' AND b.id_report_status!=5 "
        Dim cek As String = execute_query(qcek, 0, True, "", "", "", "")
        If cek <> "0" Then
            stopCustom("Propose budget already processed.")
            Exit Sub
        End If

        If DEYearBudget.Text = "" Or MENote.Text = "" Then
            warningCustom("Please complete all data")
        End If
    End Sub
End Class