Public Class ReportRetExos
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportRetExos_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt

        'Mark
        pre_load_mark_horz_check(rmt, id, "2", "2", XrTable1)

        'sattus
        If id_report_status = "6" Then
            LabelTitleApprovedDate.Visible = True
            LabelDotApprovedDate.Visible = True
            LabelApprovedDate.Visible = True
        End If

        'printed date & approved date
        Dim qpd As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date`, DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` 
        FROM tb_report_mark rm 
        WHERE rm.id_report=" + id + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class