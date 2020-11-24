Public Class FormBatchUploadOnlineStore
    Private Sub FormBatchUploadOnlineStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_online_store()
    End Sub

    Private Sub FormBatchUploadOnlineStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBatchUploadOnlineStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBatchUploadOnlineStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_online_store()
        viewSearchLookupQuery(SLUEOnlineStore, "SELECT * FROM tb_design_column_type", "id_design_column_type", "column_type", "id_design_column_type")
    End Sub

    Sub view_column()
        If SLUEOnlineStore.EditValue.ToString = "3" Then
            column_vios()
        ElseIf SLUEOnlineStore.EditValue.ToString = "4" Then
            column_zalora()
        ElseIf SLUEOnlineStore.EditValue.ToString = "5" Then
            column_blibli()
        ElseIf SLUEOnlineStore.EditValue.ToString = "8" Then
            column_shopee()
        End If
    End Sub

    Sub column_vios()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = Data
    End Sub

    Sub column_zalora()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Sub column_blibli()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Sub column_shopee()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        clear_data()

        view_column()
    End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"

        save.ShowDialog()

        If Not save.FileName = "" Then
            GVBatchUpload.ExportToXlsx(save.FileName)

            infoCustom("File saved.")
        End If
    End Sub

    Private Sub SLUEOnlineStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEOnlineStore.EditValueChanged
        clear_data()
    End Sub

    Sub clear_data()
        GCBatchUpload.DataSource = Nothing

        GVBatchUpload.Columns.Clear()
    End Sub
End Class