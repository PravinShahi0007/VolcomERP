Public Class ClassFingerPrint
    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    Public bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.
    Public ip As String = get_setup_field("fingerprint_ip")
    Public port As String = get_setup_field("fingerprint_port")

    Public Sub connect()
        Dim idwErrorCode As Integer
        bIsConnected = axCZKEM1.Connect_Net(ip.Trim(), Convert.ToInt32(port.Trim()))
        If bIsConnected = True Then
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            stopCustom("Unable to connect the device,ErrorCode=" & idwErrorCode)
        End If
    End Sub

    Public Sub disconnect()
        axCZKEM1.Disconnect()
        bIsConnected = False
    End Sub

    Public Sub enable_fp()
        axCZKEM1.EnableDevice(iMachineNumber, True)

    End Sub

    Public Sub disable_fp()
        axCZKEM1.EnableDevice(iMachineNumber, False)
    End Sub

    Public Sub refresh_fp()
        axCZKEM1.RefreshData(iMachineNumber)
    End Sub


    Public Sub get_attlog()
        disable_fp()

        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)

        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
            'get records from the memory
            'insert to database
            Dim query As String = "INSERT INTO tb_emp_attn(id_employee,datetime,type_log,scan_method) VALUES"
            Dim query_val As String = ""
            Dim penanda As Integer = 0
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                penanda += 1
                If Not penanda = 1 Then
                    query_val += ","
                End If
                query_val += "('" + get_emp(sdwEnrollNumber.ToString, "1") + "','" & idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString() & "','" & idwInOutMode.ToString() & "','" & idwVerifyMode.ToString() & "')"
            End While
            If penanda > 0 Then
                query += query_val
                execute_non_query(query, True, "", "", "", "")
            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode > 0 Then
                stopCustom("Reading data from terminal failed, ErrorCode = " & idwErrorCode)
            End If
        End If

        enable_fp()
    End Sub
    Sub clear_attlog()
        Dim idwErrorCode As Integer

        disable_fp()

        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            stopCustom("Operation failed, ErrorCode = " & idwErrorCode)
        End If

        enable_fp()
    End Sub
End Class
