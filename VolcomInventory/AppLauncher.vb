Imports System.Net
Imports System.ComponentModel

Public Class AppLauncher
    Dim _list_download As Queue(Of String) = New Queue(Of String)()

    Private Sub AppLauncher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Opacity = 0.83
        PictureEdit1.Image = Image.FromFile(My.Application.Info.DirectoryPath.ToString & "\launch_image.png")
        PanelControl1.Parent = Me
        PanelControl1.BackColor = Color.White

        LVersion.Text = "Volcom ERP (Version : " & Application.ProductVersion.ToString & ")"
        Dim update_url As String = get_setup_field("update_address")
        Dim web As New Net.WebClient
        Dim LatestVersion As String = web.DownloadString(update_url & "version.txt") 'To download the Lastest Version from a specified URL.
        If Application.ProductVersion.ToString < LatestVersion Then
            infoCustom("Latest Version : " & LatestVersion & " of this application is available !")
            BUpdate.Enabled = True
        Else
            BUpdate.Enabled = False
        End If
    End Sub
    Sub DownloadQueue()
        _list_download.Enqueue("http://192.168.1.30/app/SetupVolcomERP.msi")
        _list_download.Enqueue("http://192.168.1.30/app/setup.exe")

        download_start()
    End Sub
    Sub download_start()
        If _list_download.Any() Then
            Dim _web_client As New WebClient
            AddHandler _web_client.DownloadProgressChanged, AddressOf client_DownloadProgressChanged
            AddHandler _web_client.DownloadFileCompleted, AddressOf client_DownloadFileCompleted

            Dim url = _list_download.Dequeue
            Dim filename As String = url.Substring(url.LastIndexOf("/") + 1, (url.Length - url.LastIndexOf("/") - 1))
            _web_client.DownloadFileAsync(New Uri(url), My.Application.Info.DirectoryPath.ToString + "/" + filename)
            Return
        End If
        infoCustom("Download complete, installing new version..")
        Process.Start(My.Application.Info.DirectoryPath.ToString & "/setup.exe")
        Application.Exit()

        'Dim s As New WebClient
        'AddHandler s.DownloadProgressChanged, AddressOf pC
        'AddHandler s.DownloadFileCompleted, AddressOf pC2
        's.DownloadFileAsync(New Uri("http://192.168.1.30/app/SetupVolcomERP.msi"), My.Application.Info.DirectoryPath.ToString & "\setup_new.msi")
        's.DownloadFileAsync(New Uri("http://192.168.1.30/app/SetupVolcomERP.msi"), My.Application.Info.DirectoryPath.ToString & "\setup_new2.msi")

    End Sub

    'Sub pC(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
    '    ProgressBarControl1.EditValue = e.ProgressPercentage
    'End Sub

    'Sub pC2(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
    '    infoCustom("Download complete, installing new version..")
    '    Application.Exit()
    'End Sub

    Sub client_DownloadFileCompleted(ByVal sender As System.Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Error Is Nothing Then
            Throw e.Error
        End If
        If e.Cancelled Then

        End If

        download_start()
    End Sub

    Sub client_DownloadProgressChanged(ByVal sender As System.Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBarControl1.EditValue = Integer.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUpdate.Click
        DownloadQueue()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLaunch.Click
        FormMain.NotifyIconVI.ShowBalloonTip(2000, "Information", "Volcom MRP is now running." + Environment.NewLine + "Right click here for more option.", ToolTipIcon.Info)
        Close()
    End Sub

    Private Sub AppLauncher_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class