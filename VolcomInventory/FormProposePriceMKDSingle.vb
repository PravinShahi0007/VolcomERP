Public Class FormProposePriceMKDSingle
    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = FormProposePriceMKDDet.GVData
    Dim id_mkd_type As String = FormProposePriceMKDDet.LEMKDType.EditValue.ToString
    Sub viewDisc()
        Dim cond As String = ""
        If id_mkd_type = "1" Then
            cond = "AND d.value>=30 "
        Else
            cond = "AND d.value>30 "
        End If
        Dim query As String = "SELECT CAST(d.value AS DECIMAL(5,0)) AS `propose_disc`, CONCAT((SELECT propose_disc),'%') AS `propose_disc_display`
        FROM tb_lookup_disc_type d WHERE d.value>0 " + cond
        viewSearchLookupQuery(SLEProposeDisc, query, "propose_disc", "propose_disc_display", "propose_disc")
    End Sub

    Private Sub FormProposePriceMKDSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDisc()

        TxtCode.Text = gv.GetFocusedRowCellValue("design_code").ToString
        TxtDescription.Text = gv.GetFocusedRowCellValue("name").ToString
        TxtNormalPrice.EditValue = gv.GetFocusedRowCellValue("design_price_normal")
        TxtCurrDisc.EditValue = gv.GetFocusedRowCellValue("curr_disc")
        TxtCurrPrice.EditValue = gv.GetFocusedRowCellValue("design_price")
        TxtRekomendasiDisc.EditValue = gv.GetFocusedRowCellValue("erp_discount")
        If gv.GetFocusedRowCellValue("propose_disc").ToString = "" Then
            CENoPropose.EditValue = True
        Else
            CENoPropose.EditValue = False
            SLEProposeDisc.EditValue = gv.GetFocusedRowCellValue("propose_disc")
            TxtProposeFinal.EditValue = gv.GetFocusedRowCellValue("propose_price_final")
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
        Else
            SLEProposeDisc.Enabled = True
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
        Dim erp_discount As Decimal
        If IsDBNull(TxtRekomendasiDisc.EditValue) Then
            erp_discount = -1
        Else
            erp_discount = TxtRekomendasiDisc.EditValue
        End If
        Dim propose_disc As Decimal
        If SLEProposeDisc.EditValue = Nothing Then
            propose_disc = -1
        Else
            propose_disc = SLEProposeDisc.EditValue
        End If
        If erp_discount <> propose_disc And MENote.Text = "" Then
            warningCustom("Please input note")
            Exit Sub
        End If

        'cek final price dibawah 70%
        If CENoPropose.EditValue = False And (TxtProposeFinal.EditValue > TxtProposePrice.EditValue) Then
            warningCustom("Final Price is not valid : greather than propose price limit")
            Exit Sub
        End If

        'cek - sementara gak dipake
        'If CENoPropose.EditValue = False Then
        '    Dim qcek As String = "SELECT d.value FROM tb_lookup_disc_type d WHERE d.value>0 AND d.value>'" + SLEProposeDisc.EditValue.ToString + "' ORDER BY d.value ASC LIMIT 1 "
        '    Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        '    If dcek.Rows.Count > 0 Then
        '        Dim disc_bawah As Decimal = dcek.Rows(0)("value")
        '        Dim normal_price As Decimal = gv.GetFocusedRowCellValue("design_price_normal")
        '        Dim limit_bawah As Decimal = normal_price * ((100 - disc_bawah) / 100)
        '        If TxtProposeFinal.EditValue <= limit_bawah Then
        '            warningCustom("Final Price is not valid : less than propose price (" + disc_bawah.ToString + "%)")
        '            Exit Sub
        '        End If
        '    End If
        'End If

        'update
        If erp_discount = -1 Then
            gv.SetFocusedRowCellValue("erp_discount", Nothing)
        Else
            gv.SetFocusedRowCellValue("erp_discount", erp_discount)
        End If
        If propose_disc = -1 Then
            gv.SetFocusedRowCellValue("propose_disc", Nothing)
        Else
            gv.SetFocusedRowCellValue("propose_disc", propose_disc)
        End If
        If TxtProposePrice.EditValue = Nothing Then
            gv.SetFocusedRowCellValue("propose_price", Nothing)
        Else
            gv.SetFocusedRowCellValue("propose_price", TxtProposePrice.EditValue)
        End If
        If TxtProposeFinal.EditValue = Nothing Then
            gv.SetFocusedRowCellValue("propose_price_final", Nothing)
        Else
            gv.SetFocusedRowCellValue("propose_price_final", TxtProposeFinal.EditValue)
        End If
        If propose_disc > 0 Then
            gv.SetFocusedRowCellValue("propose_disc_group", "Up to " + Decimal.Parse(propose_disc.ToString).ToString("N0") + "%")
            gv.SetFocusedRowCellValue("propose_status", "Turun")
        Else
            gv.SetFocusedRowCellValue("propose_disc_group", "")
            gv.SetFocusedRowCellValue("propose_status", "")
        End If
        gv.SetFocusedRowCellValue("note", MENote.Text)

        'cek not use recom
        ' old
        'If id_mkd_type = "1" Then
        '    If erp_discount > 30 Then
        '        erp_discount = -1
        '    End If
        'End If
        If propose_disc <> erp_discount Then
            gv.SetFocusedRowCellValue("check_stt", "1")
        Else
            gv.SetFocusedRowCellValue("check_stt", "2")
        End If

        FormProposePriceMKDDet.GCData.RefreshDataSource()
        FormProposePriceMKDDet.GVData.RefreshData()
        'FormProposePriceMKDDet.GVData.BestFitColumns()
        Close()
    End Sub
End Class