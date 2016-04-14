Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO

Public Class barcodeaa

    Private Sub barcodeaa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim reader As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim s As String
        Dim pd As New PrintDialog()

        s = MemoEdit1.Text.ToString()
        Dim line As String() = s.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        reader.AppendLine()
        For i As Integer = 0 To line.Length - 1
            reader.AppendLine(line(i))
        Next
        'Dim output As String = reader.ToString().Replace("<ESC>", (ChrW(27)).ToString())
        Dim output As String = reader.ToString().Replace("<ESC>", (ChrW(27)).ToString())

        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            MsgBox(output.ToString)
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reader As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim s As String
        Dim pd As New PrintDialog()

        s = MemoEdit1.Text.ToString()
        Dim line As String() = s.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        reader.AppendLine()
        For i As Integer = 0 To line.Length - 1
            reader.AppendLine(line(i))
        Next

        'Dim output As String = reader.ToString().Replace("<ESC>", (ChrW(27)).ToString())
        Dim output As String = reader.ToString()

        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            MsgBox(output.ToString)
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
        End If
    End Sub
End Class