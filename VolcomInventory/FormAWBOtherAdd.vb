Public Class FormAWBOtherAdd
    Private Sub FormAWBOtherAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_sub_district()
        load_store()
        load_dep()
        '
        load_head()
    End Sub

    Sub load_dep()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement WHERE is_office_dept='1'"
        viewLookupQuery(LEDeptSum, q, 0, "departement", "id_departement")
    End Sub

    Sub load_head()
        TEAWBNumber.Text = ""
        TEKoli.EditValue = 1
        '
        SLEClient.EditValue = "0"
        SLESubDistrict.EditValue = "0"
        SLESubDistrict.Enabled = True
        TEExtraNote.Properties.ReadOnly = False
        TEExtraNote.Text = ""
    End Sub

    Sub load_store()
        Dim q As String = "
SELECT '0' AS `id_comp`,'-' AS `comp_number`,'Not registered' AS `comp_name`,0 AS `id_sub_district`,'' AS `sub_district`,'' AS address_primary
UNION ALL
SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_sub_district`,dis.`sub_district`,c.address_primary
FROM tb_m_comp c 
INNER JOIN tb_m_sub_district dis ON dis.`id_sub_district`=c.`id_sub_district`
WHERE c.`is_active`=1 AND (c.id_comp_cat='1' OR c.id_comp_cat='2' OR c.id_comp_cat='6' OR c.id_comp_cat='8')"
        viewSearchLookupQuery(SLEClient, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_sub_district()
        Dim q As String = "
SELECT '0' AS id_sub_district,'Nothing' AS `sub_district`,'' AS city
UNION ALL
SELECT dis.id_sub_district,dis.`sub_district`,cit.city
FROM tb_m_sub_district dis
INNER JOIN tb_m_city cit ON cit.id_city=dis.`id_city`"
        viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Private Sub SLEClient_EditValueChanged(sender As Object, e As EventArgs) Handles SLEClient.EditValueChanged
        If SLEClient.EditValue.ToString = "0" Then
            SLESubDistrict.EditValue = "0"
            SLESubDistrict.Enabled = True
            TEExtraNote.Properties.ReadOnly = False
        Else
            SLESubDistrict.EditValue = SLEClient.Properties.View.GetFocusedRowCellValue("id_sub_district").ToString
            SLESubDistrict.Enabled = False
            TEExtraNote.Properties.ReadOnly = True
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'save
        Cursor = Cursors.WaitCursor

        If TEAWBNumber.Text = "" Or SLESubDistrict.EditValue.ToString = "0" Or (SLEClient.EditValue.ToString = "0" And TEExtraNote.EditValue.ToString = "") Then
            warningCustom("Please complete all data")
        Else
            FormAWBOtherDet.GVList.AddNewRow()
            FormAWBOtherDet.GVList.FocusedRowHandle = FormAWBOtherDet.GVList.RowCount - 1
            '
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "awbill_no", TEAWBNumber.Text)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "id_departement", LEDeptSum.EditValue.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "departement", LEDeptSum.Text.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "id_sub_district", SLESubDistrict.EditValue.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "sub_district", SLESubDistrict.Text.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "jml_koli", TEKoli.EditValue.ToString)
            '
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "id_client", SLEClient.EditValue.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "comp_name", SLEClient.Text.ToString)
            FormAWBOtherDet.GVList.SetRowCellValue(FormAWBOtherDet.GVList.RowCount - 1, "client_note", TEExtraNote.Text.ToString)
            '
            FormAWBOtherDet.GVList.BestFitColumns()
            load_head()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub TEAWBNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEAWBNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            TEKoli.Focus()
        End If
    End Sub

    Private Sub TEKoli_KeyUp(sender As Object, e As KeyEventArgs) Handles TEKoli.KeyUp
        If e.KeyCode = Keys.Enter Then
            TEKoli.Focus()
        End If
    End Sub

    Private Sub TEExtraNote_KeyUp(sender As Object, e As KeyEventArgs) Handles TEExtraNote.KeyUp
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub
End Class