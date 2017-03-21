Public Class FormEmpDPPick
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpDPPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub DEStartDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStartLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilLeave.Focus()
        End If
    End Sub

    Private Sub DEUntilDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub DEStartDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartLeave.EditValueChanged
        calc()
    End Sub

    Private Sub DEUntilDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilLeave.EditValueChanged
        calc()
    End Sub

    Sub calc()
        If Not DEStartLeave.EditValue > DEUntilLeave.EditValue Then
            '
            Dim date_start As Date = DEStartLeave.EditValue
            Dim date_until As Date = DEUntilLeave.EditValue
            Dim time_diff As TimeSpan
            Dim diff As Integer
            time_diff = date_until - date_start
            diff = Math.Floor(time_diff.TotalHours)
            TETotHour.EditValue = diff
        Else
            '
            TETotHour.EditValue = 0
        End If
    End Sub

    Private Sub FormEmpDPPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStartLeave.EditValue = Now
        DEUntilLeave.EditValue = Now
        calc()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Try
            Dim newRow As DataRow = (TryCast(FormEmpDPDet.GCDP.DataSource, DataTable)).NewRow()
            newRow("dp_time_start") = DEStartLeave.EditValue
            newRow("dp_time_end") = DEUntilLeave.EditValue
            newRow("subtotal_hour") = TETotHour.EditValue

            TryCast(FormEmpDPDet.GCDP.DataSource, DataTable).Rows.Add(newRow)
            FormEmpDPDet.GCDP.RefreshDataSource()
            FormEmpDPDet.calc()
            FormEmpDPDet.GVDP.FocusedRowHandle = 0
            Close()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class