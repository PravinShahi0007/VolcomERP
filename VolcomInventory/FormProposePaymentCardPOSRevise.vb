Public Class FormProposePaymentCardPOSRevise
    Private Sub FormProposePaymentCardPOSRevise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim in_card As String = ""

        For i = 0 To FormProposePaymentCardPOSDet.GVData.RowCount - 1
            If FormProposePaymentCardPOSDet.GVData.IsValidRowHandle(i) Then
                in_card += FormProposePaymentCardPOSDet.GVData.GetRowCellValue(i, "id_card").ToString + ", "
            End If
        Next

        If in_card = "" Then
            in_card = "0"
        Else
            in_card = in_card.Substring(0, in_card.Length - 2)
        End If

        Dim query As String = "
            SELECT c.id_card, c.card_name, c.discount, CONCAT(a.acc_name, ' - ', a.acc_description) AS acc, c.id_acc
            FROM tb_pos_card_type AS c
            LEFT JOIN tb_a_acc AS a ON c.id_acc = a.id_acc
            WHERE c.id_card NOT IN (" + in_card + ")
            ORDER BY c.card_name ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub FormProposePaymentCardPOSRevise_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        FormProposePaymentCardPOSDet.GVData.AddNewRow()

        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("type", "Revise")
        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("id_card", GVData.GetFocusedRowCellValue("id_card"))
        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("card_name", GVData.GetFocusedRowCellValue("card_name").ToString)
        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("discount", GVData.GetFocusedRowCellValue("discount"))
        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("id_acc", GVData.GetFocusedRowCellValue("id_acc"))
        FormProposePaymentCardPOSDet.GVData.SetFocusedRowCellValue("note", "")

        FormProposePaymentCardPOSDet.GVData.RefreshData()

        Close()
    End Sub
End Class