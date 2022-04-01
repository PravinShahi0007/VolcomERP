Public Class FormSampleDevTargetPps
    Public id_pps As String = "-1"
    Private Sub FormSampleDevTargetPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT * FROM tb_sample_dev_pps_det
WHERE id_sample_dev_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPps.DataSource = dt
        GVPps.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSampleDevTargetAdd.ShowDialog()
    End Sub
End Class