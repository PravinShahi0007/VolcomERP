Public Class FormRefundOLStoreDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim rmt As String = "244"
    Public action As String = "-1"
    Dim scan_mode As String = ""
    Dim dt As DataTable

    Private Sub FormRefundOLStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewReportStatus()
        'actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewWH()
        'Cursor = Cursors.WaitCursor
        'Dim query As String = ""
        'query += "SELECT ('0') AS id_comp, ('All') AS comp_number, ('All Store') AS comp_name, ('All Store') AS comp_name_label UNION ALL "
        'query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        'FROM tb_m_comp e "
        'viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        'Cursor = Cursors.Default
    End Sub
End Class