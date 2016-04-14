Public Class FormMasterSample
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bdupe_active As String = "1"

    Private Sub FormMasterSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample()
    End Sub
    Sub view_sample()
        Try
            GVSample.ActiveFilterString = ""
            Dim query As String = "CALL view_sample_master()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSample.DataSource = data
            ColSampleSeason.GroupIndex = 0

            'GVSample.BestFitColumns()
            If data.Rows.Count < 1 Then
                GVSample.FocusedRowHandle = 0
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                GVSample.FocusedRowHandle = 0
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub

    Private Sub GVSample_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.DoubleClick
        If GVSample.FocusedRowHandle >= 0 Then
            FormMasterSampleDet.id_sample = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            FormMasterSampleDet.ShowDialog()
        End If
    End Sub

    Private Sub FormMasterSample_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterSample_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterSample_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        noManipulating()
    End Sub
    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSample.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                bdupe_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                bdupe_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GVSample_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSample.CustomColumnDisplayText
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVSample.IsGroupRow(rowhandle) Then
                rowhandle = GVSample.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVSample.GetRowCellDisplayText(rowhandle, "season")
            End If
        ElseIf e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BStatusNR_Click(sender As Object, e As EventArgs) Handles BStatusNR.Click
        Cursor = Cursors.WaitCursor
        GVSample.ActiveFilterString = "[checkbox]='Yes'"
        GVSample.ClearGrouping()
        If GVSample.RowCount > 0 Then
            FormMasterSampleNR.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVSample.RowCount > 0 Then
            GVSample.ExpandAllGroups()
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVSample.RowCount - 1) - GetGroupRowCount(GVSample))
                If cek Then
                    GVSample.SetRowCellValue(i, "checkbox", "yes")
                Else
                    GVSample.SetRowCellValue(i, "checkbox", "no")
                End If
            Next
        End If
    End Sub
End Class