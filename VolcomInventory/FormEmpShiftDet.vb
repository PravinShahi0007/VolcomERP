Public Class FormEmpShiftDet
    Public id_shift As String = "-1"

    Private Sub FormEmpShiftDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_shift = "-1" Then 'new

        Else
            Dim query As String = "SELECT * FROM tb_emp_shift WHERE id_shift='" & id_shift & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        End If
    End Sub

    Private Sub FormEmpShiftDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub
End Class