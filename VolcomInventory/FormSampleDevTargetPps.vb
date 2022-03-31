Public Class FormSampleDevTargetPps
    Private Sub FormSampleDevTargetPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_det()
        Dim q As String = "SELECT * FROM tb_sample_dev_pps_det
WHERE id_sample_dev_pps='-1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPps.DataSource = dt
        GVPps.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

    End Sub
End Class