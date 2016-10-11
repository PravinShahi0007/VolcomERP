Public Class FormEmpScheduleTableSet
    Private Sub FormEmpScheduleTableSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT 'no' as is_select,lvl.employee_level,emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        query += " INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level"
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        Dim cek As String = CESelectAll.EditValue.ToString
        For i As Integer = 0 To (GVEmployee.RowCount - 1)
            If cek Then
                GVEmployee.SetRowCellValue(i, "is_select", "yes")
            Else
                GVEmployee.SetRowCellValue(i, "is_select", "no")
            End If
        Next
    End Sub
    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class