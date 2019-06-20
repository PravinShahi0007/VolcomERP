Public Class FormInvoiceFGPODPPop
    Public id_po As String = "-1"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount > 0 Then
            For i = 0 To GVList.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = GVList.GetRowCellValue(i, "id_pn_fgpo_det").ToString
                newRow("report_mark_type") = "199"
                newRow("number") = GVList.GetRowCellValue(i, "number").ToString
                newRow("description") = GVList.GetRowCellValue(i, "design_display_name").ToString
                newRow("code") = GVList.GetRowCellValue(i, "design_code").ToString
                newRow("value") = GVList.GetRowCellValue(i, "value").ToString
                newRow("vat") = GVList.GetRowCellValue(i, "vat").ToString
                newRow("inv_number") = GVList.GetRowCellValue(i, "inv_number").ToString
                newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            Next
        Else
            warningCustom("Please select DP first")
        End If
        GVList.ActiveFilterString = ""
    End Sub

    Private Sub FormInvoiceFGPODPPop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPODPPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dp()
    End Sub

    Sub load_dp()
        Dim query As String = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det, pn.`id_pn_fgpo`,pn.`number`,pnd.`value`,pnd.`vat`,pnd.`inv_number`,pnd.`note` FROM `tb_pn_fgpo_det` pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
WHERE pn.`id_report_status`= '6' AND pnd.`id_report`='" & id_po & "' AND pnd.report_mark_type='22' AND pn.`type`='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub
End Class