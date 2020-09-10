Public Class FormSampleDevelopmentVerifyCPS2
    Public id_po As String = "-1"
    Private Sub FormSampleDevelopmentVerifyCPS2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If Not MENote.Text = "" Then
            'check already verified

            '
            Dim q As String = "UPDATE tb_prod_order SET cps2_verify='1',cps2_verify_by='" & id_user & "',cps2_verify_note='" & addSlashes(MENote.Text) & "',cps2_verify_date=NOW() WHERE id_prod_order='" & id_po & "'"
            execute_non_query(q, True, "", "", "", "")
            Close()
        Else
            warningCustom("Please put some note !")
        End If
    End Sub
End Class