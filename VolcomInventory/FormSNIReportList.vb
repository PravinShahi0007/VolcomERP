Public Class FormSNIReportList
    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,sts.report_status
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub FormSNIReportList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        FormSNIppsDet.is_view_list = True
        FormSNIppsDet.ShowDialog()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 Then
            FormSNIppsDet.id_pps = GVList.GetFocusedRowCellValue("id_sni_pps").ToString
            FormSNIppsDet.ShowDialog()
        End If
    End Sub
End Class