Public Class FormSetupRawMatCodeDesc 
    'Form Close
    Private Sub FormSetupRawMatCodeDesc_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Validating
    Private Sub MemoEdit1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEDescription.Validating
        EP_ME_cant_blank(ErrorProviderDescription, MEDescription)
    End Sub
    'Form Load
    Private Sub FormSetupRawMatCodeDesc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelTitle.Text = FormSetupRawMatCode.GVCodeTypeDetail.GetFocusedRowCellDisplayText("code_lookup").ToString
        Dim query As String = "SELECT description_code FROM tb_m_raw_mat_code_detail WHERE id_code_detail = '" + FormSetupRawMatCode.GVCodeTypeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString + "'"
        Dim data As String = execute_query(query, 0, True, "", "", "", "")
        MEDescription.Text = data
    End Sub
    'Action Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Not formIsValid(ErrorProviderDescription) Then
            errorInput()
        Else
            Try
                Dim description_code As String = MEDescription.Text.ToString
                Dim id_code_detail As String = FormSetupRawMatCode.GVCodeTypeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                Dim query As String = "UPDATE tb_m_raw_mat_code_detail SET description_code='" + description_code + "' WHERE id_code_detail='" + id_code_detail + "'"
                execute_non_query(query, True, "", "", "", "")
                FormSetupRawMatCode.viewCodeType(2, FormSetupRawMatCode.GCCodeTypeDetail)
                Close()
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
End Class