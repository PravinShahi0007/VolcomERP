Public Class FormMasterSampleNR
    Private Sub FormMasterSampleNR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewNR(LEStatus)
    End Sub
    'View Status normal/reject
    Private Sub viewNR(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status_nr,status_nr FROM tb_lookup_status_nr ORDER BY id_status_nr ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status_nr"
        lookup.Properties.ValueMember = "id_status_nr"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BStatusNR_Click(sender As Object, e As EventArgs) Handles BStatusNR.Click
        Dim query As String = ""
        Dim id_collection As String = ""
        For i As Integer = 0 To FormMasterSample.GVSample.RowCount - 1
            If Not i = 0 Then
                id_collection += ","
            End If
            id_collection += i.ToString
        Next
        query = "UPDATE tb_m_sample SET id_status_nr='" + LEStatus.EditValue.ToString + "' WHERE id_sample IN(" + id_collection + ")"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Sample updated.")
        FormMasterSample.view_sample()
        FormMasterSample.CheckEditSelAll.Checked = False
        Close()
    End Sub

    Private Sub FormMasterSampleNR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class