Public Class FormMasterComnputerDet
    Public action As String
    Public id_computer As String = "-1"

    Private Sub FormMasterComnputerDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_m_computer WHERE id_computer='" + id_computer + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtPCName.Text = data.Rows(0)("computer_name").ToString
            TxtCurrentUser.Text = data.Rows(0)("computer_user").ToString
            TxtIPAddress.Text = data.Rows(0)("computer_ip").ToString
            TxtSpesification.Text = data.Rows(0)("computer_spec").ToString
            TxtDepartement.Text = data.Rows(0)("computer_dept").ToString
        End If
    End Sub

    Private Sub TxtPCName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPCName.Validating
        EP_TE_cant_blank(EPLogin, TxtPCName)
    End Sub

    Private Sub TxtCurrentUser_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCurrentUser.Validating
        EP_TE_cant_blank(EPLogin, TxtCurrentUser)
    End Sub

    Private Sub TxtIPAddress_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtIPAddress.Validating
        EP_TE_cant_blank(EPLogin, TxtIPAddress)
    End Sub

    Private Sub TxtSpesification_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtSpesification.Validating
        EP_TE_cant_blank(EPLogin, TxtSpesification)
    End Sub

    Private Sub TxtDepartement_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDepartement.Validating
        EP_TE_cant_blank(EPLogin, TxtDepartement)
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        ValidateChildren()
        If Not formIsValid(EPLogin) Then
            errorInput()
        Else
            Dim computer_name As String = TxtPCName.Text
            Dim computer_user As String = addSlashes(TxtCurrentUser.Text)
            Dim computer_ip As String = TxtIPAddress.Text
            Dim computer_spec As String = TxtSpesification.Text
            Dim computer_dept As String = TxtDepartement.Text
            If action = "ins" Then
                Dim query As String = "INSERT tb_m_computer(computer_name, computer_user, computer_ip, computer_spec, computer_dept) "
                query += "VALUES ('" + computer_name + "', '" + computer_user + "', '" + computer_ip + "', '" + computer_spec + "', '" + computer_dept + "'); SELECT LAST_INSERT_ID(); "
                id_computer = execute_query(query, 0, True, "", "", "", "")
                FormMasterComputer.viewComputer()
                FormMasterComputer.GVComputer.FocusedRowHandle = find_row(FormMasterComputer.GVComputer, "id_computer", id_computer)
                Close()
            Else
                Dim query As String = "UPDATE tb_m_computer SET computer_name='" + computer_name + "', computer_user='" + computer_user + "', computer_ip='" + computer_ip + "', computer_spec='" + computer_spec + "', computer_dept='" + computer_dept + "' WHERE id_computer='" + id_computer + "' "
                execute_non_query(query, True, "", "", "", "")
                FormMasterComputer.viewComputer()
                FormMasterComputer.GVComputer.FocusedRowHandle = find_row(FormMasterComputer.GVComputer, "id_computer", id_computer)
                Close()
            End If
        End If
    End Sub

    Private Sub FormMasterComnputerDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class