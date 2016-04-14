Public Class FormInfoLineList 
    Public id_pop_up As String = "-1"
    Private Sub FormInfoLineList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_design()
    End Sub

    Sub view_design()
        Try
            Dim query As String = "CALL view_all_design()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            If data.Rows.Count > 0 Then
                BtnChoose.Enabled = True
            Else
                BtnChoose.Enabled = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub


    Private Sub GVDesign_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDesign.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_design_par As String = "-1"
        Try
            id_design_par = GVDesign.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        If id_design_par = "-1" Or id_design_par = "" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_design_par As String = "-1"
        Try
            id_design_par = GVDesign.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        If id_design_par = "-1" Or id_design_par = "" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormPopUpStorageSample.GVSample.ApplyFindFilter("")
            FormPopUpStorageSample.GVSample.ApplyFindFilter(GVDesign.GetFocusedRowCellValue("sample_code").ToString)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInfoLineList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class