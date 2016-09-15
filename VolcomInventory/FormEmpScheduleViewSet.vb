Public Class FormEmpScheduleViewSet
    Public id_employee As String = "-1"

    Private Sub BTempSchedule_Click(sender As Object, e As EventArgs) Handles BTempSchedule.Click
        Dim date_start, date_until As Date
        '
        date_start = Date.Parse(DEStart.EditValue).ToString("yyyy-mm-dd")
        date_until = Date.Parse(DEUntil.EditValue).ToString("yyyy-mm-dd")
        '
        Dim query As String = "CALL add_shift(" & id_employee & "," & GVShift.GetFocusedRowCellValue("id_shift").ToString & ",'" & date_start & "','" & date_until & "')"
        execute_non_query(query, True, "", "", "", "")
        '
    End Sub

    Private Sub FormEmpScheduleViewSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_schedule()
    End Sub

    Sub load_schedule()
        Dim query As String = "SELECT *,IF(monday=1 AND tuesday=1 AND wednesday=1 AND thursday=1 AND friday=1 AND saturday=1 AND sunday=1,'Everyday',"
        query += " CONCAT(If(sunday=1,'Sunday,',''),IF(monday=1,'Monday,',''),IF(tuesday=1,'Tuesday,',''),IF(wednesday=1,'Wednesday,',''),IF(thursday=1,'Thursday,',''),IF(friday=1,'Friday,',''),IF(saturday=1,'Saturday',''))) AS workday "
        query += " FROM tb_emp_shift "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCShift.DataSource = data
        GVShift.BestFitColumns()
    End Sub
End Class