Public Class FormPricePolicyCode
    Private Sub FormPricePolicyCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cpc As New ClassPricePolicy()
        GCData.DataSource = cpc.dataMain("-1", "1")
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPricePolicyCode_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPricePolicyCode_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class