Public Class FormFKNumber

    Private Sub FormFKNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim id As String = FormAccountingFakturScanSingle.id_acc_fak_scan
        Dim query As String = "CALL view_fk_fg_comp(" + id + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        GVData.ActiveFilterString = "[is_select]='Yes' "
        'cek gk ada yg dicentang
        If GVData.RowCount <= 0 Then
            warningCustom("Please select product first")
            GVData.ActiveFilterString = ""
            Exit Sub
        End If

        If Txtno2.Text = "" Or Txtno3.Text = "" Then
            warningCustom("Please complete all data")
            GVData.ActiveFilterString = ""
        Else
            Cursor = Cursors.WaitCursor
            FormImportExcel.id_pop_up = "68"
            FormImportExcel.ShowDialog()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormFKNumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i As Integer = 0 To GVData.RowCount - 1
            If CESelectAll.EditValue = True Then
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub
End Class