Public Class FormFGRepairDet
    Public id_fg_repair As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_repair_det_list As New List(Of String)
    Public id_pre As String = "-1"


    Private Sub FormFGRepairDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()

    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
End Class