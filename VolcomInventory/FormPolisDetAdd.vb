Public Class FormPolisDetAdd
    Private Sub FormPolisDetAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormPolisDet.SLEPPSType.EditValue.ToString = "1" Then
            DECreatedDate.EditValue = FormPolisDet.DEStart.EditValue
            DECreatedDate.Enabled = False
        Else
            DECreatedDate.EditValue = Now()
            DECreatedDate.Enabled = True
        End If
        view_store()
    End Sub

    Sub view_store()
        Dim q As String = "SELECT * FROM tb_m_comp
WHERE id_comp_cat='6' AND is_active=1
AND id_comp NOT IN (SELECT id_reff FROM tb_polis WHERE is_active=1 AND id_desc_premi='" & FormPolisDet.SLEPolisType.EditValue.ToString & "')"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
        SLEVendor.EditValue = Nothing
    End Sub

    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        'check
        If SLEVendor.EditValue = Nothing Then
            warningCustom("Choose store first")
        Else
            Dim is_ok As Boolean = True
            For i = 0 To FormPolisDet.BGVSummary.RowCount - 1
                If FormPolisDet.BGVSummary.GetRowCellValue(i, "id_comp").ToString = SLEVendor.EditValue.ToString Then
                    is_ok = False
                    Exit For
                End If
            Next

            If is_ok Then
                'insert to row
                Cursor = Cursors.WaitCursor
                FormPolisDet.BGVSummary.AddNewRow()
                FormPolisDet.BGVSummary.FocusedRowHandle = FormPolisDet.BGVSummary.RowCount - 1
                '
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "id_comp", SLEVendor.Properties.View.GetFocusedRowCellValue("id_comp").ToString)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "comp_name", SLEVendor.Properties.View.GetFocusedRowCellValue("comp_name").ToString)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "comp_number", SLEVendor.Properties.View.GetFocusedRowCellValue("comp_number").ToString)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "address_primary", SLEVendor.Properties.View.GetFocusedRowCellValue("address_primary").ToString)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_end_date", Date.Parse(DECreatedDate.EditValue.ToString).AddDays(-1))
                '
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_stock", 0)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_fit_out", 0)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_building", 0)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_peralatan", 0)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_public_liability", 0)
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_nilai_total", 0)
                '
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_polis_vendor", "NULL")
                FormPolisDet.BGVSummary.SetRowCellValue(FormPolisDet.BGVSummary.RowCount - 1, "old_premi", 0)
                '
                FormPolisDet.BGVSummary.BestFitColumns()
                'Close()
                Cursor = Cursors.Default
            Else
                warningCustom("Store already registered")
            End If
        End If
    End Sub

    Private Sub FormPolisDetAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class