Public Class FormEmpHolidayDet
    Public id_holiday As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormEmpHolidayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpHolidayDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_religion()
    End Sub

    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'ALL' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub
End Class