Public Class FormProposePriceMKDBulk
    Dim id_mkd_type As String = FormProposePriceMKDDet.LEMKDType.EditValue.ToString
    'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = FormProposePriceMKDDet.GVData

    Sub viewDisc()
        Dim cond As String = ""
        If id_mkd_type = "1" Then
            cond = "AND d.value>=30 "
        Else
            cond = "AND d.value>=30 "
        End If
        Dim query As String = "SELECT CAST(d.value AS DECIMAL(5,0)) AS `propose_disc`, CONCAT((SELECT propose_disc),'%') AS `propose_disc_display`
        FROM tb_lookup_disc_type d WHERE d.value>0 " + cond
        viewSearchLookupQuery(SLEProposeDisc, query, "propose_disc", "propose_disc_display", "propose_disc")
    End Sub

    Private Sub FormProposePriceMKDBulk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDisc()
        checkPropose()
    End Sub

    Private Sub FormProposePriceMKDBulk_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CENoPropose_EditValueChanged(sender As Object, e As EventArgs) Handles CENoPropose.EditValueChanged
        checkPropose()
    End Sub

    Sub checkPropose()
        If CENoPropose.EditValue = True Then
            SLEProposeDisc.EditValue = Nothing
            TxtProposeFinal.EditValue = Nothing
            SLEProposeDisc.Enabled = False
            TxtProposeFinal.Enabled = False
        Else
            If id_mkd_type <> "3" Then
                SLEProposeDisc.Enabled = True
                TxtProposeFinal.Enabled = False
            Else
                SLEProposeDisc.Enabled = False
                TxtProposeFinal.Enabled = True
                TxtProposeFinal.EditValue = 0.00
            End If
        End If
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        'cek inputan slain internal sale
        If CENoPropose.EditValue = False And id_mkd_type <> "3" And SLEProposeDisc.EditValue = Nothing Then
            warningCustom("Please input propose disc")
            Exit Sub
        End If

        'cek inputan slain internal sale
        If CENoPropose.EditValue = False And id_mkd_type = "3" And TxtProposeFinal.EditValue = Nothing Then
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
            Dim propose_disc As Decimal
            Dim erp_discount As Decimal
            If id_mkd_type <> "3" Then
                'selain internal sale
                Dim curr_disc As Decimal = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "curr_disc")
                Dim normal_price As Decimal = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "design_price_normal")
                If SLEProposeDisc.EditValue = Nothing Then
                    propose_disc = -1
                Else
                    propose_disc = SLEProposeDisc.EditValue
                End If
                Dim erp_discount_cek As String = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "erp_discount").ToString
                If erp_discount_cek = "" Then
                    erp_discount = -1
                Else
                    erp_discount = FormProposePriceMKDDet.GVData.GetRowCellValue(i, "erp_discount")
                End If

                Dim propose_disc_selected As Decimal
                If CENoPropose.EditValue = False Then
                    If propose_disc >= curr_disc Then
                        'isi
                        propose_disc_selected = propose_disc
                        Dim propose_price As Decimal = normal_price * ((100 - propose_disc) / 100)
                        Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", propose_disc)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", propose_price)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", propose_price_final)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "Up to " + Decimal.Parse(propose_disc.ToString).ToString("N0") + "%")
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "Turun")
                    Else
                        'no propose
                        propose_disc_selected = -1
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", Nothing)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", Nothing)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "")
                        FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "")
                    End If
                Else
                    'no propose
                    propose_disc_selected = -1
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "")
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "")
                End If
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "note", MENote.Text)

                'cek not use recom
                'old
                'If id_mkd_type = "1" Then
                '    If erp_discount > 30 Then
                '        erp_discount = -1
                '    End If
                'End If
                If propose_disc_selected <> erp_discount Then
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "1")
                Else
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "2")
                End If

                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "is_select", "No")
            Else
                'internal sale
                If CENoPropose.EditValue = False Then
                    'propose
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", TxtProposeFinal.EditValue)
                Else
                    'no propose
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_price_final", Nothing)
                End If
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "note", MENote.Text)
                If propose_disc <> erp_discount Then
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "1")
                Else
                    FormProposePriceMKDDet.GVData.SetRowCellValue(i, "check_stt", "2")
                End If
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_disc_group", "")
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "propose_status", "")
                FormProposePriceMKDDet.GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
        Close()
        Cursor = Cursors.Default
    End Sub
End Class