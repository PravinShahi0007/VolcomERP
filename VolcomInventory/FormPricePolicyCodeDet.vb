Public Class FormPricePolicyCodeDet
    Public action As String = "-1"
    Public id As String = "-1"

    Private Sub FormPricePolicyCodeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Private Sub FormPricePolicyCodeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Height = 130
        Else
            Height = 274
            Dim query As String = ""
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCreate.Visible = False
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        tabOpt()
        XTCData.SelectedTabPageIndex = XTCData.SelectedTabPageIndex + 1
    End Sub

    Sub tabOpt()
        If XTCData.SelectedTabPageIndex = 0 Then
            'normal
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = False
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            '30
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            '50
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
        ElseIf XTCData.SelectedTabPageIndex = 3 Then
            '70
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
        ElseIf XTCData.SelectedTabPageIndex = 4 Then
            'fix
            BtnSave.Visible = True
            BtnNext.Visible = False
            BtnPrev.Visible = True
        End If
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        tabOpt()
        XTCData.SelectedTabPageIndex = XTCData.SelectedTabPageIndex - 1
    End Sub
End Class