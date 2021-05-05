Public Class FormProposePriceMKDBulk
    Dim id_mkd_type As String = FormProposePriceMKDDet.LEMKDType.EditValue.ToString
    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = FormProposePriceMKDDet.GVData

    Sub viewDisc()
        Dim cond As String = ""
        If id_mkd_type = "1" Then
            cond = "AND d.value=30 "
        Else
            cond = "AND d.value>30 "
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
        If CENoPropose.EditValue = False And id_mkd_type <> "3" And SLEProposeDisc.EditValue = Nothing And MENote.Text = "" Then
            warningCustom("Please input propose disc")
            Exit Sub
        End If

        'cek inputan slain internal sale
        If CENoPropose.EditValue = False And id_mkd_type = "3" And TxtProposeFinal.EditValue = Nothing And MENote.Text = "" Then
            warningCustom("Please input fixed price")
            Exit Sub
        End If

        For i As Integer = 0 To (gv.RowCount - 1) - GetGroupRowCount(gv)
            Dim propose_disc As Decimal
            Dim erp_discount As Decimal
            If id_mkd_type <> "3" Then
                'selain internal sale
                Dim curr_disc As Decimal = gv.GetRowCellValue(i, "curr_disc")
                Dim normal_price As Decimal = gv.GetRowCellValue(i, "design_price_normal")
                If SLEProposeDisc.EditValue = Nothing Then
                    propose_disc = -1
                Else
                    propose_disc = SLEProposeDisc.EditValue
                End If
                If gv.GetRowCellValue(i, "erp_discount").ToString = "" Then
                    erp_discount = -1
                Else
                    erp_discount = gv.GetRowCellValue(i, "erp_discount")
                End If

                If CENoPropose.EditValue = False Then
                    If propose_disc > curr_disc Then
                        'isi
                        Dim propose_price As Decimal = normal_price * ((100 - propose_disc) / 100)
                        Dim propose_price_final As Decimal = Math.Floor(Decimal.Parse(propose_price) / 1000D) * 1000
                        gv.SetRowCellValue(i, "propose_disc", propose_disc)
                        gv.SetRowCellValue(i, "propose_price", propose_price)
                        gv.SetRowCellValue(i, "propose_price_final", propose_price_final)
                    Else
                        'no propose
                        gv.SetRowCellValue(i, "propose_disc", Nothing)
                        gv.SetRowCellValue(i, "propose_price", Nothing)
                        gv.SetRowCellValue(i, "propose_price_final", Nothing)
                    End If
                Else
                    'no propose
                    gv.SetRowCellValue(i, "propose_disc", Nothing)
                    gv.SetRowCellValue(i, "propose_price", Nothing)
                    gv.SetRowCellValue(i, "propose_price_final", Nothing)
                End If
                gv.SetRowCellValue(i, "note", MENote.Text)
                gv.SetRowCellValue(i, "is_select", "No")
                If propose_disc <> erp_discount Then
                    gv.SetFocusedRowCellValue("check_stt", "1")
                Else
                    gv.SetFocusedRowCellValue("check_stt", "2")
                End If
                FormProposePriceMKDDet.GCData.RefreshDataSource()
                FormProposePriceMKDDet.GVData.RefreshData()
            Else
                'internal sale
                If CENoPropose.EditValue = False Then
                    'propose
                    gv.SetRowCellValue(i, "propose_price_final", TxtProposeFinal.EditValue)
                Else
                    'no propose
                    gv.SetRowCellValue(i, "propose_price_final", Nothing)
                End If
                gv.SetRowCellValue(i, "note", MENote.Text)
                gv.SetRowCellValue(i, "is_select", "No")
                If propose_disc <> erp_discount Then
                    gv.SetFocusedRowCellValue("check_stt", "1")
                Else
                    gv.SetFocusedRowCellValue("check_stt", "2")
                End If
                FormProposePriceMKDDet.GCData.RefreshDataSource()
                FormProposePriceMKDDet.GVData.RefreshData()
            End If
        Next
    End Sub
End Class