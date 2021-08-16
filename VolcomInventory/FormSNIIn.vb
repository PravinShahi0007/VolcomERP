Public Class FormSNIIn
    Public id As String = "-1"
    Private Sub FormSNIIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TESNIOutNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TESNIOutNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TESNIOutNo.Text = "" Then
                warningCustom("Please scan SNI Out form")
            Else
                '
                Dim qc As String = "SELECT * FROM tb_qc_sni_out WHERE number='" & addSlashes(TESNIOutNo.Text) & "' AND id_report_status=6"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            End If
        End If
    End Sub
End Class