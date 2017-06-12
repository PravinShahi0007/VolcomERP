Public Class FormMasterCargoRateDet
    Public id_cargo_rate As String = "-1"
    Private Sub FormMasterCargoRateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cargo
    End Sub
    Sub load_cargo()
        Dim query As String = "SELECT * FROM tb_m_comp WHERE id_comp_cat='7'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCargo.DataSource = data

        If data.Rows.Count > 0 Then
            load_inbound()
            load_outbound()
        End If
    End Sub
    Sub load_inbound()

    End Sub
    Sub load_outbound()

    End Sub
End Class