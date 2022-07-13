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

    Private Sub CESetPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CESetPeriod.EditValueChanged
        If CESetPeriod.EditValue = False Then
            DEFrom.Enabled = False
            DEUntil.Enabled = False
            DEFrom.EditValue = Nothing
            DEUntil.EditValue = Nothing
        Else
            DEFrom.Enabled = True
            DEUntil.Enabled = True
            Dim month As String = FormAccountingFakturScanSingle.TxtPeriod.Text
            Dim year As String = FormAccountingFakturScanSingle.TxtYear.Text
            Dim tgl_awal As String = year + "-0" + month + "-" + "01 00:00:00"
            Dim dt As DateTime = DateTime.ParseExact(tgl_awal, "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)
            Dim dt_end As DateTime = DateTime.ParseExact(year + "-0" + month + "-" + System.DateTime.DaysInMonth(dt.Year, dt.Month).ToString + " 00:00:00", "yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)
            DEFrom.Properties.MinValue = dt
            DEUntil.Properties.MinValue = dt
            DEFrom.Properties.MaxValue = dt_end
            DEUntil.Properties.MaxValue = dt_end
            DEFrom.EditValue = dt
            DEUntil.EditValue = dt_end
        End If
    End Sub
End Class