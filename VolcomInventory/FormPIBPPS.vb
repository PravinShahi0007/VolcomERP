Public Class FormPIBPPS
    Public id As String = "-1"

    Private Sub FormPIBPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPIBPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        '
        If id = "-1" Then 'new

        Else 'edit

        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        del()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

    End Sub

    Sub del()
        If GVPIBPps.RowCount > 0 And GVPIBPps.FocusedRowHandle >= 0 Then
            GVPIBPps.DeleteSelectedRows()
            GCPIBPPps.RefreshDataSource()
            GVPIBPps.RefreshData()
        End If
    End Sub
End Class