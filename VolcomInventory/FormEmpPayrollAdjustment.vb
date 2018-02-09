Public Class FormEmpPayrollAdjustment
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT * FROM tb"
    End Sub

    Private Sub FormEmpPayrollAdjustment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class