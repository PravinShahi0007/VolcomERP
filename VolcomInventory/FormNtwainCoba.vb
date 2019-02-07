Imports System.Reflection
Imports System.Threading
Imports NTwain
Imports NTwain.Data

Public Class FormNtwainCoba
    Private sMyScanner As String = String.Empty

    Private Sub FormNtwainCoba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sMyScanner = TwainModule.GetScanSource
        Dim lstFiles As List(Of String) = TwainModule.ScanImages(".bmp", True, sMyScanner)
    End Sub

End Class