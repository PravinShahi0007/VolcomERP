Public Class FormSampleDevelopmentVerifyCPS2
    Private Sub FormSampleDevelopmentVerifyCPS2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSampleDevelopmentVerifyCPS2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEDesignCode.Text = ""
        TEDesignName.Text = ""
        TEVendor.Text = ""
        '

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click

    End Sub
End Class