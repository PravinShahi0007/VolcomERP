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
            Else
                newRow("id_prod_order") = ""
                newRow("id_report") = ""
                newRow("report_mark_type") = ""
                newRow("report_number") = TEReportNumber.Text
                newRow("info_design") = ""
            End If

            newRow("qty") = ""
            newRow("value") = ""
            newRow("vat") = ""
            newRow("inv_number") = ""
            newRow("note") = ""

            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormInvoiceFGPODP.calculate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class