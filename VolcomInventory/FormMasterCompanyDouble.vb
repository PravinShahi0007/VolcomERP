Public Class FormMasterCompanyDouble
    Public dt As DataTable
    Public id_pop_up As String = "-1"


    Private Sub FormMasterCompanyDouble_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCComp.DataSource = dt
        GCComp.Focus()
    End Sub

    Private Sub GCComp_KeyDown(sender As Object, e As KeyEventArgs) Handles GCComp.KeyDown
        If e.KeyCode = Keys.Enter Then
            If GVComp.FocusedRowHandle >= 0 And GVComp.RowCount > 0 Then
                If id_pop_up = "1" Then
                    FormWHSvcLevel.id_comp_selected = GVComp.GetFocusedRowCellValue("id_drawer_def").ToString
                    FormWHSvcLevel.TxtCompID.Text = GVComp.GetFocusedRowCellValue("comp_number").ToString
                    FormWHSvcLevel.TxtCompID.Text = GVComp.GetFocusedRowCellValue("comp_name").ToString
                    FormWHSvcLevel.DEFromAcc.Focus()
                    Close()
                Else
                    FormFGStock.id_drw_rsv = GVComp.GetFocusedRowCellValue("id_drawer_def").ToString
                    FormFGStock.TxtCodeAccRsv.Text = GVComp.GetFocusedRowCellValue("comp_number").ToString
                    FormFGStock.TxtNameAccRsv.Text = GVComp.GetFocusedRowCellValue("comp_name").ToString
                    FormFGStock.BtnViewRsv.Focus()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub FormMasterCompanyDouble_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class