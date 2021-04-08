﻿Public Class FormPriceChecker
    Private Sub FormPriceChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPriceChecker_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            startScan()
            defaultInput()

        End If
    End Sub

    Sub startScan()

    End Sub

    Private Sub BtnStartScan_Click(sender As Object, e As EventArgs) Handles BtnStartScan.Click
        startScan()
    End Sub

    Sub defaultInput()
        LabelDesc.Text = "-"
        LabelPrice.Text = "Rp. 0"
        LabelPriceType.Text = "-"
        LabelEffectiveDate.Text = "-"
        LabelCode.Text = ""
        LabelClass.Text = ""
        LabelColor.Text = ""
        LabelSeason.Text = ""
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewPrice()
        End If
    End Sub

    Sub viewPrice()
        Cursor = Cursors.WaitCursor
        Dim code As String = ""
        If TxtScannedCode.Text.Length > 9 Then
            code = addSlashes(TxtScannedCode.Text)
        Else
            code = addSlashes(TxtScannedCode.Text.Substring(0, 9))
        End If
        Dim query As String = ""
        Cursor = Cursors.Default
    End Sub
End Class