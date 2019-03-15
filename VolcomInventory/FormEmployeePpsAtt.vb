Public Class FormEmployeePpsAtt
    Public type As String = ""
    Public image As Object = Nothing
    Public read_only As Boolean = False

    Private Sub FormEmployeePpsAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureEdit.EditValue = image

        If read_only Then
            PictureEdit.ReadOnly = True
            SBScanUpload.Enabled = False
            SBSave.Enabled = False
        End If
    End Sub

    Private Sub FormEmployeePpsAtt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If type = "ktp" Then
            FormEmployeePpsDet.PEKTP.EditValue = PictureEdit.EditValue
        ElseIf type = "kk" Then
            FormEmployeePpsDet.PEKK.EditValue = PictureEdit.EditValue
        End If

        Close()
    End Sub
End Class