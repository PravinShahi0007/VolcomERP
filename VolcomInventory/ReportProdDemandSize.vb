Public Class ReportProdDemandSize
    Public Shared id_prod_demand As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"
    Public Shared is_pre As String = "-1"
    Public Shared is_hidden_mark As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportProdDemandSize_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt

        'sattus
        If id_report_status = "6" Then
            LabelTitleApprovedDate.Visible = True
            LabelDotApprovedDate.Visible = True
            LabelApprovedDate.Visible = True
        End If

        'printed date & approved date
        Dim qpd As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date`, DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` 
        FROM tb_report_mark rm 
        WHERE rm.id_report=" + id_prod_demand + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd

        'find updated created/approve date in revision
        Dim id_pdr As String = ""
        Try
            id_pdr = execute_query("SELECT pdr.id_prod_demand_rev 
        FROM tb_prod_demand_rev pdr
        WHERE pdr.id_prod_demand=" + id_prod_demand + " AND pdr.id_report_status=6
        ORDER BY pdr.id_prod_demand_rev DESC LIMIT 1 ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_pdr = ""
        End Try
        If id_pdr <> "" Then
            Dim query_date_rev As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date` 
            FROM tb_report_mark rm 
            WHERE rm.id_report=" + id_pdr + " AND (rm.report_mark_type=143 OR rm.report_mark_type=144 OR rm.report_mark_type=145 OR rm.report_mark_type=194)  AND rm.id_mark=2
            ORDER BY rm.id_report_mark DESC LIMIT 1 "
            Dim data_date_rev As DataTable = execute_query(query_date_rev, -1, True, "", "", "", "")
            LabelApprovedDate.Text = Date.Parse(data_date_rev.Rows(0)("approved_date").ToString).ToString("dd MMMM yyyy").ToUpper
        End If
    End Sub
End Class