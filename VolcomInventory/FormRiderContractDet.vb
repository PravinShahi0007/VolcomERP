Public Class FormRiderContractDet
    Private Sub FormRiderContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT * 
FROM `tb_kontrak_rider_pps_det`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPPS.DataSource = dt
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVPPS.AddNewRow()
    End Sub
End Class