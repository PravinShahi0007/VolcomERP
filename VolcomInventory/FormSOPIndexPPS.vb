Public Class FormSOPIndexPPS
    Private Sub FormSOPIndexPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPIndexPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_departement()
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
WHERE p.id_departement=''"
        viewSearchLookupQuery(SLESubProsedur, q, "id_sop_prosedur_sub", "sop_prosedur_sub", "id_sop_prosedur_sub")
    End Sub

    Sub clear_grid()
        For i As Integer = GVList.RowCount - 1 To 0 Step -1
            GVList.DeleteRow(i)
        Next
    End Sub
End Class