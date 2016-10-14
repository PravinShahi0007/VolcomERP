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
        If Not id_holiday = "-1" Then
            Dim query As String = "SELECT * FROM tb_emp_holiday WHERE id_emp_holiday='" & id_holiday & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEHolidayDesc.Text = data.Rows(0)("emp_holiday_desc").ToString
            SLEReligion.EditValue = data.Rows(0)("id_religion").ToString
            DEDate.EditValue = data.Rows(0)("emp_holiday_date")
            '
        End If
    End Sub

    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'Public Holiday' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If DEDate.Text = "" Or TEHolidayDesc.Text = "" Then
            stopCustom("Please complete all fields.")
        Else
            If id_holiday = "-1" Then
                'new
                Dim query As String = ""
                query += "INSERT INTO tb_emp_holiday(id_religion,emp_holiday_date,emp_holiday_desc) VALUES('" & SLEReligion.EditValue.ToString & "','" & Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & TEHolidayDesc.Text & "')"
                execute_non_query(query, True, "", "", "", "")
                FormEmpHoliday.load_year()
                FormEmpHoliday.view_holiday()
                Close()
            Else
                'edit
                Dim query As String = ""
                query += "UPDATE tb_emp_holiday SET id_religion='" & SLEReligion.EditValue.ToString & "',emp_holiday_date='" & Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',emp_holiday_desc='" & TEHolidayDesc.Text & "' WHERE id_emp_holiday='" & id_holiday & "'"
                execute_non_query(query, True, "", "", "", "")
                FormEmpHoliday.load_year()
                FormEmpHoliday.view_holiday()
                Close()
            End If

        End If
    End Sub
End Class