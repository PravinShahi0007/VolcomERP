Public Class FormDocTracking
    Private Sub FormDocTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim dt As DateTime = getTimeDB()
        DEFrom.EditValue = dt
        DEUntil.EditValue = dt

        loadComp()
    End Sub

    Sub loadComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name, c.id_comp_cat
        FROM tb_m_comp c
        WHERE (c.id_comp_cat='5' OR c.id_comp_cat='6') "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
        SLEComp.EditValue = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDocTracking_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDocTracking_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
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

        'comp
        Dim id_comp As String = "0"
        If SLEComp.EditValue = Nothing Then
            stopCustom("Please select account first")
            Cursor = Cursors.Default
            Exit Sub
        Else
            id_comp = SLEComp.EditValue.ToString
        End If
        Dim query As String = "CALL view_doc_tracking(" + id_comp + ", '" + date_from_selected + "', '" + date_until_selected + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLink_Click(sender As Object, e As EventArgs) Handles RepoLink.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_report As String = "0"
            Try
                id_report = GVData.GetFocusedRowCellValue("id_report").ToString
            Catch ex As Exception
            End Try
            myCoalesce(id_report, "0")
            Dim rmt As String = "0"
            Try
                rmt = GVData.GetFocusedRowCellValue("report_mark_type").ToString
            Catch ex As Exception
            End Try
            myCoalesce(rmt, "0")
            Dim sm As New ClassShowPopUp()
            sm.id_report = id_report
            sm.report_mark_type = rmt
            sm.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class