Public Class FormProposePriceMKDSingle
    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = FormProposePriceMKDDet.GVData
    Sub viewDisc()
        Dim query As String = "SELECT CAST(d.value AS DECIMAL(5,0)) AS `propose_disc`, CONCAT((SELECT propose_disc),'%') AS `propose_disc_display`
        FROM tb_lookup_disc_type d WHERE d.value>0 "
        viewSearchLookupQuery(SLEProposeDisc, query, "propose_disc", "propose_disc_display", "propose_disc")
    End Sub

    Private Sub FormProposePriceMKDSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDisc()

        TxtCode.Text = gv.GetFocusedRowCellValue("design_code").ToString
        TxtDescription.Text = gv.GetFocusedRowCellValue("name").ToString
        TxtCurrDisc.EditValue = gv.GetFocusedRowCellValue("curr_disc")
        TxtCurrPrice.EditValue = gv.GetFocusedRowCellValue("design_price")
        TxtRekomendasiDisc.EditValue = gv.GetFocusedRowCellValue("erp_discount")
        If gv.GetFocusedRowCellValue("propose_disc").ToString = "" Then
            CENoPropose.EditValue = True
        Else
            CENoPropose.EditValue = False
            SLEProposeDisc.EditValue = gv.GetFocusedRowCellValue("propose_disc")
        End If
        MENote.Text = gv.GetFocusedRowCellValue("note").ToString
    End Sub

    Private Sub FormProposePriceMKDSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelControl4_Click(sender As Object, e As EventArgs) Handles LabelControl4.Click

    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub SLEProposeDisc_EditValueChanged(sender As Object, e As EventArgs) Handles SLEProposeDisc.EditValueChanged
        calculate()
    End Sub

    Private Sub CENoPropose_EditValueChanged(sender As Object, e As EventArgs) Handles CENoPropose.EditValueChanged
        SLEProposeDisc.EditValue = Nothing
        If CENoPropose.EditValue = True Then
            SLEProposeDisc.Enabled = False
            TxtProposeFinal.Enabled = False
        Else
            SLEProposeDisc.Enabled = True
            TxtProposeFinal.Enabled = True
            If gv.GetFocusedRowCellValue("propose_disc").ToString <> "" Then
                SLEProposeDisc.EditValue = gv.GetFocusedRowCellValue("propose_disc")
            End If
            If gv.GetFocusedRowCellValue("propose_price_final").ToString <> "" Then
                TxtProposeFinal.EditValue = gv.GetFocusedRowCellValue("propose_price_final").ToString
            End If
        End If
    End Sub

    Sub calculate()
        If SLEProposeDisc.EditValue = Nothing Then
            TxtProposePrice.EditValue = Nothing
            TxtProposeFinal.EditValue = Nothing
        Else
            Dim disc As Decimal = SLEProposeDisc.EditValue
            Dim normal_price As Decimal = gv.GetFocusedRowCellValue("design_price_normal")
            Dim propose_price As Decimal = normal_price * ((100 - disc) / 100)
            TxtProposePrice.EditValue = propose_price
            Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
            TxtProposeFinal.EditValue = propose_price_final
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        'cek inputan
        If CENoPropose.EditValue = False And (SLEProposeDisc.EditValue = Nothing Or TxtProposePrice.EditValue = Nothing Or TxtProposeFinal.EditValue = Nothing) Then
            warningCustom("Please input all data")
            Exit Sub
        End If

        'cek valid diskon
        If CENoPropose.EditValue = False And SLEProposeDisc.EditValue <= TxtCurrDisc.EditValue Then
            warningCustom("Discount is not valid")
            Exit Sub
        End If

        'cek valid note 
        If TxtRekomendasiDisc.EditValue = Nothing <> SLEProposeDisc.EditValue.ToString And MENote.Text = "" Then
            warningCustom("Please input note")
            Exit Sub
        End If
    End Sub
End Class