Public Class FormEmpPayrollOvertimePick
    Public date_start As String = ""
    Public date_end As String = ""

    Private Sub FormEmpPayrollOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        '
    End Sub
    Sub viewDept()
        Dim query As String = ""
        query = "SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Dim dept As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If
    End Sub
End Class