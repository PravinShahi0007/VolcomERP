Public Class FormProductionAttach
    Private Sub FormProductionAttach_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Sub loadLineList()
        Try
            FormViewProduction.Dispose()
        Catch ex As Exception
        End Try

        PCForm.Controls.Clear()
        FormViewProduction.TopLevel = False
        PCForm.Controls.Add(FormViewProduction)

        FormViewProduction.id_prod_order = SLEFGPO.EditValue.ToString
        FormViewProduction.is_no_cost = "1"
        FormViewProduction.ShowDialog()

        FormViewProduction.Show()
        FormViewProduction.ControlBox = False
        FormViewProduction.FormBorderStyle = FormBorderStyle.None
        FormViewProduction.Focus()
        FormViewProduction.Dock = DockStyle.Fill
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        loadLineList()
    End Sub
End Class