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
        If action = "ins" Then
        ElseIf action = "upd" Then

        End If
    End Sub

    Private Sub FormPurcAssetValueAdded_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class