Public Class FormEmpOvertimePick
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertimePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT e.id_employee, 'no' AS is_checked, d.departement, e.employee_code, e.employee_name, e.employee_position, ll.employee_level
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_level AS ll ON e.id_employee_level = ll.id_employee_level
            WHERE id_employee_active = 1
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        pick()
    End Sub

    Sub pick()
        For i = 0 To GVList.RowCount - 1
            Console.WriteLine(GVList.GetRowCellValue(i, "employee_code").ToString)
            'If GVList.GetRowCellValue(i, "is_checked").ToString = "yes" Then
            '    FormEmpOvertimeDet.GVEmployee.AddNewRow()

            '    Dim row As Integer = FormEmpOvertimeDet.GVEmployee.RowCount - 1

            '    FormEmpOvertimeDet.GVEmployee.SetRowCellValue(row, "id_employee", GVList.GetFocusedRowCellValue("id_employee"))
            '    FormEmpOvertimeDet.GVEmployee.SetRowCellValue(row, "employee_code", GVList.GetFocusedRowCellValue("employee_code"))
            '    FormEmpOvertimeDet.GVEmployee.SetRowCellValue(row, "employee_name", GVList.GetFocusedRowCellValue("employee_name"))
            '    FormEmpOvertimeDet.GVEmployee.SetRowCellValue(row, "employee_position", GVList.GetFocusedRowCellValue("employee_position"))
            '    FormEmpOvertimeDet.GVEmployee.SetRowCellValue(row, "employee_level", GVList.GetFocusedRowCellValue("employee_level"))
            'End If
        Next

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class