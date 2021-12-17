Public Class FormSOPIndexPPS
    Public id As String = "-1"

    Private Sub FormSOPIndexPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPIndexPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_departement()
        If id = "-1" Then
            'new
            SLEDepartement.Properties.ReadOnly = False
        Else
            'edit
            SLEDepartement.Properties.ReadOnly = True
        End If
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.id_sop_pps_det,ps.id_sop_prosedur_sub,ps.sop_prosedur_sub,ps.sop_prosedur_sub_code,p.sop_prosedur,p.sop_prosedur_code,ppsd.sop_name,ppsd.sop_number
FROM tb_sop_pps_det ppsd
INNER JOIN `tb_sop_prosedur_sub` ps ON ps.id_sop_prosedur_sub=ppsd.id_sop_prosedur_sub
INNER JOIN tb_sop_prosedur p ON p.id_sop_prosedur=ps.id_sop_prosedur 
WHERE ppsd.id_sop_pps='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub SLEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDepartement.EditValueChanged
        clear_grid()
        load_sub_prosedur()
    End Sub

    Sub load_sub_prosedur()
        Dim q As String = "SELECT ps.id_sop_prosedur_sub,ps.sop_prosedur_sub,ps.sop_prosedur_sub_code,p.sop_prosedur,p.sop_prosedur_code
FROM `tb_sop_prosedur_sub` ps 
INNER JOIN tb_sop_prosedur p ON p.id_sop_prosedur=ps.id_sop_prosedur AND p.is_active=1 AND ps.is_active=1
WHERE p.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        viewSearchLookupQuery(SLESubProsedur, q, "id_sop_prosedur_sub", "sop_prosedur_sub", "id_sop_prosedur_sub")
        SLESubProsedur.EditValue = Nothing
    End Sub

    Sub clear_grid()
        For i As Integer = GVList.RowCount - 1 To 0 Step -1
            GVList.DeleteRow(i)
        Next
    End Sub

    Private Sub BRefreshCat_Click(sender As Object, e As EventArgs) Handles BRefreshCat.Click
        load_sub_prosedur()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If Not SLESubProsedur.EditValue = Nothing And Not SLEDepartement.EditValue = Nothing Then
            Cursor = Cursors.WaitCursor
            GVList.AddNewRow()
            GVList.FocusedRowHandle = GVList.RowCount - 1
            '
            GVList.SetRowCellValue(GVList.RowCount - 1, "id_sop_prosedur_sub", SLESubProsedur.EditValue.ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_sub", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_sub").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_sub_code", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_sub_code").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_code", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_code").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_name", TESOPName.Text)
            '
            GVList.BestFitColumns()
            Cursor = Cursors.Default
        Else
            warningCustom("Pastikan anda memilih departement dan sub prosedur")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BCat.Click
        FormSOPCat.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class