Public Class FormEmpStoreSchCompare
    Public view_store As Boolean = True

    Private Sub FormEmpStoreSchCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        DEStartSum.EditValue = Now
        DEUntilSum.EditValue = Now
    End Sub
    Sub viewDept()
        Dim query As String = ""
        If view_store Then
            query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE is_store='1' ORDER BY a.departement ASC) "
        Else
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
            query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        End If
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_schedule_table()
    End Sub

    Sub load_schedule_table()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = "SELECT * FROM tb_m_employee WHERE id_departement LIKE '" & dept & "' AND id_employee_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleAfter.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleAfter.Columns.AddVisible("id_employee", "ID")
            GVScheduleAfter.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleAfter.Columns("id_employee").Visible = False

            GVScheduleAfter.Columns.AddVisible("employee_code", "NIP")
            GVScheduleAfter.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleAfter.Columns.AddVisible("employee_name", "Name")
            GVScheduleAfter.Columns("employee_name").OptionsColumn.AllowEdit = False

            While (curD <= endP)
                GVScheduleAfter.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))
                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleAfter.DataSource = data_x
            GVScheduleAfter.DeleteRow(0)
            '
            For i As Integer = 0 To data.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_schedule emp WHERE emp.id_employee='" & data.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleAfter.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data.Rows(i)("id_employee").ToString
                newRow("employee_code") = data.Rows(i)("employee_code").ToString
                newRow("employee_name") = data.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleAfter.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleAfter.RefreshDataSource()
            Next
            GVScheduleAfter.BestFitColumns()
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub
End Class