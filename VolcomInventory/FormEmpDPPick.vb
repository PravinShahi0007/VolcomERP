Public Class FormEmpDPPick
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpDPPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEUntilDP_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub DEStartDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartDP.EditValueChanged
        Try
            TEStart.EditValue = DEStartDP.EditValue
            TEEnd.EditValue = DEStartDP.EditValue
            calc()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEUntilDP_EditValueChanged(sender As Object, e As EventArgs)
        calc()
    End Sub

    Sub calc()
        If Not TEStart.EditValue > TEEnd.EditValue Then
            '
            Dim time_diff As TimeSpan
            Dim diff As Integer
            time_diff = TEEnd.EditValue - TEStart.EditValue
            diff = Math.Floor(time_diff.TotalHours)
            TETotHour.EditValue = diff
        Else
            '
            TETotHour.EditValue = 0
        End If
    End Sub

    Private Sub FormEmpDPPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStartDP.EditValue = Now.Date
        calc()
        DEStartDP.Focus()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Try
            Dim newRow As DataRow = (TryCast(FormEmpDPDet.GCDP.DataSource, DataTable)).NewRow()
            newRow("dp_time_start") = TEStart.EditValue
            newRow("dp_time_end") = TEEnd.EditValue
            newRow("subtotal_hour") = TETotHour.EditValue
            newRow("remark") = MENote.Text

            TryCast(FormEmpDPDet.GCDP.DataSource, DataTable).Rows.Add(newRow)
            FormEmpDPDet.GCDP.RefreshDataSource()
            FormEmpDPDet.calc()
            FormEmpDPDet.show_but()
            FormEmpDPDet.GVDP.FocusedRowHandle = 0
            Close()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub TEStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEStart.EditValueChanged
        calc()
    End Sub

    Private Sub TEEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEEnd.EditValueChanged
        calc()
    End Sub
End Class