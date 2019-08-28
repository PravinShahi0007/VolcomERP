Public Class ReportSalesDelOrderOwnStore
    Public Shared id As String
    Public Shared id_pre As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "43"
    Public Shared is_combine = "2"
    Public Shared id_report_status As String = "-1"
    Public Shared id_store As String = "-1"
    Public Shared is_use_unique_code As String = "-1"

    Private Sub ReportSalesDelOrderOwnStore_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If id_pre = "-1" Then
            load_mark_horz(rmt, id, "2", "1", XrTable1)
        End If

        'printed by & printed date
        Dim qp As String = "SELECT e.employee_nick_name AS `printed_by`, DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i') AS `printed_date`
        FROM tb_m_user u
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE u.id_user=" + id_user + " "
        Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
        LabelPrintedDate.Text = dp.Rows(0)("printed_date").ToString
        LabelPrintedBy.Text = dp.Rows(0)("printed_by").ToString

        'detail
        viewDetail()

        'completed
        If id_report_status = "6" Then
            LabelCompleted.Visible = True
            Dim qcom As String = "SELECT e.employee_name AS `completed_by`, DATE_FORMAT(r.final_comment_date,'%d-%m-%Y %H:%i') AS `completed_date` 
            FROM tb_report_mark_final_comment r 
            INNER JOIN tb_m_user u ON u.id_user = r.id_user
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE r.report_mark_type=" + rmt + " AND r.id_report=" + id + " "
            Dim dcom As DataTable = execute_query(qcom, -1, True, "", "", "", "")
            DataSource = dcom
        End If
    End Sub

    Sub viewDetail()
        Dim del As New ClassSalesDelOrder()
        Dim cond As String = ""
        If is_combine = "2" Then
            cond = "AND dd.id_pl_sales_order_del=" + id + " "
        Else
            cond = "AND d.is_combine=1 AND d.id_combine=" + id + " "
        End If
        Dim query As String = ""
        If is_use_unique_code = "1" Then
            query = del.queryDelConceptStore(cond, id_store)
        Else
            query = del.queryDelRegular(cond, id_store)
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class