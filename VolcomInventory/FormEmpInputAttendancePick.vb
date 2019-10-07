Public Class FormEmpInputAttendancePick
    Private Sub FormEmpInputAttendancePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT 'no' AS is_check, e.id_departement, d.departement, e.id_employee, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, sts.employee_status
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            LEFT JOIN tb_lookup_employee_status AS sts ON e.id_employee_status = sts.id_employee_status
            WHERE e.id_employee_active = 1 AND (
                (e.id_departement IN (SELECT id_departement FROM tb_emp_attn_input_dep))
            )
            ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        DEDate_Validating(DEDate, New ComponentModel.CancelEventArgs)

        If Not DEDate.EditValue Is Nothing Then
            GVEmployee.ApplyFindFilter("")

            GVEmployee.ExpandAllGroups()

            Dim data As DataTable = FormEmpInputAttendanceDet.GCEmployee.DataSource

            For i = 0 To GVEmployee.RowCount - 1
                If GVEmployee.GetRowCellValue(i, "is_check") = "yes" Then
                    data.Rows.Add("0",
                                  GVEmployee.GetRowCellValue(i, "id_departement"),
                                  GVEmployee.GetRowCellValue(i, "departement"),
                                  GVEmployee.GetRowCellValue(i, "id_employee"),
                                  GVEmployee.GetRowCellValue(i, "employee_code"),
                                  GVEmployee.GetRowCellValue(i, "employee_name"),
                                  GVEmployee.GetRowCellValue(i, "employee_position"),
                                  GVEmployee.GetRowCellValue(i, "id_employee_status"),
                                  GVEmployee.GetRowCellValue(i, "employee_status"),
                                  Date.Parse(DEDate.EditValue.ToString()).ToString("dd MMM yyyy"),
                                  Nothing,
                                  Nothing)
                End If
            Next

            FormEmpInputAttendanceDet.GCEmployee.DataSource = data

            FormEmpInputAttendanceDet.GCEmployee.RefreshDataSource()

            FormEmpInputAttendanceDet.GVEmployee.BestFitColumns()

            Close()
        Else
            errorCustom("Please insert date.")
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub FormEmpInputAttendancePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDate.Validating
        If DEDate.EditValue Is Nothing Then
            ErrorProvider.SetError(DEDate, "Don't leave blank.")
        Else
            ErrorProvider.SetError(DEDate, "")
        End If
    End Sub
End Class