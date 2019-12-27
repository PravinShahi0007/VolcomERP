Public Class FormInvoiceFGPOAdd
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPOAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        Try
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            If XTCAdd.SelectedTabPageIndex = 0 Then 'fgpo
                newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                newRow("id_report") = SLEFGPO.EditValue.ToString
                newRow("report_mark_type") = "22"
                newRow("report_number") = TEReportNumber.Text
                newRow("info_design") = TEInfoDesign.Text

                newRow("qty") = TEQty.EditValue
                newRow("id_currency") = LECurrency.EditValue.ToString
                newRow("currency") = LECurrency.Text
                newRow("kurs") = TEKurs.EditValue
                newRow("value_bef_kurs") = TEBeforeKurs.EditValue

                newRow("value") = TEAfterKurs.EditValue
                newRow("vat") = TEVat.EditValue
                newRow("inv_number") = ""
                newRow("note") = ""
            Else
                newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                newRow("id_report") = SLEFGPO.EditValue.ToString
                newRow("report_mark_type") = "22"
                newRow("report_number") = TEReportNumber.Text
                newRow("info_design") = TEInfoDesign.Text

                newRow("qty") = TEQty.EditValue
                newRow("id_currency") = LECurrency.EditValue.ToString
                newRow("currency") = LECurrency.Text
                newRow("kurs") = TEKurs.EditValue
                newRow("value_bef_kurs") = TEBeforeKurs.EditValue

                newRow("value") = TEAfterKurs.EditValue
                newRow("vat") = TEVat.EditValue
                newRow("inv_number") = ""
                newRow("note") = ""
            End If

            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormInvoiceFGPODP.calculate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class