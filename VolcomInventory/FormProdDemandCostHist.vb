Public Class FormProdDemandCostHist 

    Public id_design_par As String = "-1"

    Private Sub FormProdDemandCostHist_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProdDemandCostHist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.getCostHistQuery(id_design_par)
        Dim data As DataTable = execute_query(query, True, -1, "", "", "", "")
        GCLogCost.DataSource = data
    End Sub
End Class