Public Class FormEmpFPFinger
    Public ip As String = ""
    Public port As String = ""

    Private Sub FormEmpFPFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Finger Template : " + ip
        Dim fp As New ClassFingerPrint()
        fp.ip = ip
        fp.port = port
        fp.connect()
        Dim axCZKEM1 As zkemkeeper.CZKEM = fp.axCZKEM1
        Dim iMachineNumber As Integer = 1
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag As Integer

        Dim lvItem As New ListViewItem("Items", 0)

        lvDownload.Items.Clear()
        lvDownload.BeginUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Cursor = Cursors.WaitCursor
        AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        AxCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        While AxCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If AxCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    lvItem = lvDownload.Items.Add(sdwEnrollNumber.ToString())
                    lvItem.SubItems.Add(sName)
                    lvItem.SubItems.Add(idwFingerIndex.ToString())
                    lvItem.SubItems.Add(sTmpData)
                    lvItem.SubItems.Add(iPrivilege.ToString())
                    lvItem.SubItems.Add(sPassword)
                    If bEnabled = True Then
                        lvItem.SubItems.Add("true")
                    Else
                        lvItem.SubItems.Add("false")
                    End If
                    lvItem.SubItems.Add(iFlag.ToString())
                End If
            Next
        End While
        lvDownload.EndUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        fp.disconnect()
        '
        Dim dt As New DataTable
        For it = 0 To lvDownload.Items(0).SubItems.Count - 1
            Dim DCOL As New DataColumn(lvDownload.Columns(it).Text)
            dt.Columns.Add(DCOL)
        Next
        For it = 0 To lvDownload.Items.Count - 1
            Dim DROW As DataRow = dt.NewRow
            For j As Integer = 0 To lvDownload.Items(it).SubItems.Count - 1
                DROW(lvDownload.Columns(j).Text) = lvDownload.Items(it).SubItems(j).Text
            Next
            dt.Rows.Add(DROW)
        Next
        GCList.DataSource = dt
    End Sub

    Private Sub FormEmpFPFinger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCList, "List Finger")
    End Sub

    Private Sub BDownload_Click(sender As Object, e As EventArgs) Handles BDownload.Click
        If GVList.RowCount > 0 Then
            Dim dt As DataTable = GCList.DataSource
            Dim q As String = "INSERT INTO tb_fp_download(`user_id`,`name`,`finger_index`,`tmp_data`,`privilege`) VALUES"
            For i = 0 To dt.Rows.Count - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & dt.Rows(i)("UserID").ToString & "','" & dt.Rows(i)("Name").ToString & "','" & dt.Rows(i)("FingerIndex").ToString & "','" & dt.Rows(i)("tmpData").ToString & "','" & dt.Rows(i)("Privilege").ToString & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
        End If
    End Sub
End Class