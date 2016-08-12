Public Class ClassFingerPrint
    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    Public bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.
    Public ip As String = ""
    Public port As String = ""

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


End Class
