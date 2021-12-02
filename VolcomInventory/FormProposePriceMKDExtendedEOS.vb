Public Class FormProposePriceMKDExtendedEOS
    Private Sub FormProposePriceMKDExtendedEOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProposePriceMKDExtendedEOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim id_extended_eos As String = ""
        If CEStatus.EditValue = True Then
            id_extended_eos = "1"
        Else
            id_extended_eos = "2"
        End If
        Dim extended_eos As String = execute_query("SELECT e.extended_eos FROM tb_lookup_extended_eos e WHERE e.id_extended_eos=" + id_extended_eos + "", 0, True, "", "", "", "")
        For i As Integer = (FormProposePriceMKDDet.GVData.RowCount - 1) - GetGroupRowCount(FormProposePriceMKDDet.GVData) To 0 Step -1
            FormProposePriceMKDDet.GVData.SetRowCellValue(i, "id_extended_eos", id_extended_eos)
            FormProposePriceMKDDet.GVData.SetRowCellValue(i, "extended_eos", extended_eos)
            FormProposePriceMKDDet.GVData.SetRowCellValue(i, "is_select", "No")
            Close()
        Next
    End Sub
End Class