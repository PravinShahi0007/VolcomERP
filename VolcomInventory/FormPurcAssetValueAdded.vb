Public Class FormPurcAssetValueAdded
    Public id As String = "-1"
    Public id_parent As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormPurcAssetValueAdded_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset='" + id_parent + "' ", "1", True)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("asset_number").ToString
            TxtAssetName.Text = data.Rows(0)("asset_name").ToString
            DECreated.Properties.MinValue = data.Rows(0)("acq_date")
            DECreated.Properties.MaxValue = getTimeDB()
            DECreated.EditValue = getTimeDB()
            TxtValueAdded.EditValue = 0.00
        ElseIf action = "upd" Then

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcAssetValueAdded_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class