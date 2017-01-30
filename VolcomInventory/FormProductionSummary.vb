Public Class FormProductionSummary
    Private Sub FormProductionSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromPD.EditValue = data_dt.Rows(0)("dt")
        DEUntilPD.EditValue = data_dt.Rows(0)("dt")
        DEFrom.Focus()
    End Sub

    Private Sub FormProductionSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormProductionSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewApprovedPO()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_po_approved('" + date_from_selected + "', '" + date_until_selected + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewApprovedPO()
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Private Sub XTCSum_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSum.SelectedPageChanged
        If XTCSum.SelectedTabPageIndex = 0 Then
            DEFrom.Focus()
        ElseIf XTCSum.SelectedTabPageIndex = 1 Then
            DEFromPD.Focus()
        End If
    End Sub

    Private Sub BtnViewPD_Click(sender As Object, e As EventArgs) Handles BtnViewPD.Click
        viewPD()
    End Sub

    Sub viewPD()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_pd_list('" + date_from_selected + "', '" + date_until_selected + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFromPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilPD.Focus()
        End If
    End Sub

    Private Sub DEUntilPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewPD.Focus()
        End If
    End Sub

    Private Sub FormProductionSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class