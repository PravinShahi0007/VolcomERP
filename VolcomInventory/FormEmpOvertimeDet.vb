Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public id As String = "0"

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        ' default
        loadOvertimeType()
        DEOvertimeDate.EditValue = Now
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMM yyyy h:mm:ss tt")
    End Sub

    Sub loadOvertimeType()
        Dim query As String = "SELECT id_ot_type, ot_type FROM tb_lookup_ot_type"

        viewLookupQuery(LUEOvertimeType, query, 0, "ot_type", "id_ot_type")
    End Sub

    Sub calculateTotalHours()
        If TEOvertimeStart.EditValue < TEOvertimeEnd.EditValue Then
            Dim diff As TimeSpan = TEOvertimeEnd.EditValue - TEOvertimeStart.EditValue

            TETotalHours.EditValue = Math.Floor(diff.TotalHours).ToString + " Hours"
        Else
            TETotalHours.EditValue = "0 Hours"
        End If
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBEmpAdd_Click(sender As Object, e As EventArgs) Handles SBEmpAdd.Click
        FormEmpOvertimePick.is_hrd = is_hrd

        FormEmpOvertimePick.ShowDialog()
    End Sub
End Class