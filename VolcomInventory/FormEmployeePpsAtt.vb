Public Class FormEmployeePpsAtt
    Public id_pps As String = "-1"
    Public type As String = ""
    Public pps_path As String = "\\192.168.1.2\dataapp$\emp_pps\"

    Private Sub FormEmployeePpsAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'viewImages(PictureEdit, pps_path, id_pps + type, False)
    End Sub

    Private Sub FormEmployeePpsAtt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class