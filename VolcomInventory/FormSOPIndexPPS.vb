Public Class FormSOPIndexPPS
    Private Sub FormSOPIndexPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPIndexPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub
End Class