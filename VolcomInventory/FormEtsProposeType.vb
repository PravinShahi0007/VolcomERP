Public Class FormEtsProposeType
    Private Sub FormEtsProposeType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewProposeType()
    End Sub

    Sub viewProposeType()
        Dim query As String = "SELECT * FROM tb_lookup_propose_type pt "
        viewLookupQuery(LEProposeType, query, 0, "propose_type", "id_propose_type")
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If MENote.Text = "" And LEProposeType.EditValue.ToString = "2" Then
            warningCustom("Please complete all data")
        Else
            Dim id_propose_type As String = LEProposeType.EditValue.ToString
            Dim note As String = addSlashes(MENote.Text)
            For i As Integer = 0 To (FormEtsDet.GVProduct.RowCount - 1) - GetGroupRowCount(FormEtsDet.GVProduct)
                Dim id_ets_det As String = FormEtsDet.GVProduct.GetRowCellValue(i, "id_ets_det").ToString
                Dim query As String = "UPDATE tb_ets_det SET note='" + note + "', id_propose_type='" + id_propose_type + "' WHERE id_ets_det='" + id_ets_det + "' "
                execute_non_query(query, True, "", "", "", "")
            Next
            FormEtsDet.viewDetail(1)
            Close()
        End If
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormEtsProposeType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class