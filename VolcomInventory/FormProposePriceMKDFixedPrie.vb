Public Class FormProposePriceMKDFixedPrie
    Private Sub FormProposePriceMKDFixedPrie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkPropose()
        ActiveControl = TxtProposeFinal
    End Sub

    Sub checkPropose()
        If CENoPropose.EditValue = True Then
            TxtProposeFinal.EditValue = Nothing
            TxtProposeFinal.Enabled = False
        Else
            TxtProposeFinal.Enabled = True
            TxtProposeFinal.EditValue = 0.00
            TxtProposeFinal.Focus()
        End If
    End Sub

    Private Sub FormProposePriceMKDFixedPrie_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CENoPropose_EditValueChanged(sender As Object, e As EventArgs) Handles CENoPropose.EditValueChanged
        checkPropose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        'cek inputan slain internal sale
        If CENoPropose.EditValue = False And TxtProposeFinal.EditValue = 0.00 Then
            warningCustom("Please input fixed price")
            Exit Sub
        End If

        'cek note
        If MENote.Text = "" Then
            warningCustom("Please input note")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        For i As Integer = (FormProposePriceMKDDet.GVData.RowCount - 1) - GetGroupRowCount(FormProposePriceMKDDet.GVData) To 0 Step -1
            Dim erp_discount As Decimal
            Dim normal_price As Decimal = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "design_price_normal")
            Dim current_price As Decimal = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "design_price")
            Dim erp_discount_cek As String = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "erp_discount").ToString
            If erp_discount_cek = "" Then
                erp_discount = -1
            Else
                erp_discount = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "erp_discount")
            End If
            Dim propose_disc_selected As Decimal

            If CENoPropose.EditValue = True Then
                propose_disc_selected = -1
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", Nothing)
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", Nothing)
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "")
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "")
            Else
                Dim input_price As Decimal = TxtProposeFinal.EditValue
                If input_price < current_price Then
                    propose_disc_selected = Math.Round(((normal_price - input_price) / normal_price) * 100)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", propose_disc_selected)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", input_price)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", input_price)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "Up to " + Decimal.Parse(propose_disc_selected.ToString).ToString("N0") + "%")
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "Turun")
                Else
                    propose_disc_selected = -1
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "")
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "")
                End If
            End If
            FormProposePriceMKDDet.GVData.SetRowCellValue(i, "note", MENote.Text)
            If propose_disc_selected <> erp_discount Then
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "1")
            Else
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "2")
            End If
            FormProposePriceMKDDet.GVData.SetRowCellValue(i, "is_select", "No")
        Next
        Close()
        Cursor = Cursors.Default
    End Sub
End Class