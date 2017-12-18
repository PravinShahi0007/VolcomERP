Public Class FormEmpScheduleBulkSet
    Private Sub FormEmpScheduleBulkSet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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

    Private Sub FormEmpScheduleBulkSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_schedule()
        load_emp()
    End Sub
    Sub load_schedule()
        Dim query As String = "SELECT *,IF(monday=1 AND tuesday=1 AND wednesday=1 AND thursday=1 AND friday=1 AND saturday=1 AND sunday=1,'Everyday',"
        query += " CONCAT(If(sunday=1,'Sunday,',''),IF(monday=1,'Monday,',''),IF(tuesday=1,'Tuesday,',''),IF(wednesday=1,'Wednesday,',''),IF(thursday=1,'Thursday,',''),IF(friday=1,'Friday,',''),IF(saturday=1,'Saturday',''))) AS workday "
        query += " FROM tb_emp_shift "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCShift.DataSource = data
        GVShift.BestFitColumns()
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

    Private Sub BTempSchedule_Click(sender As Object, e As EventArgs) Handles BTempSchedule.Click
        Cursor = Cursors.WaitCursor
        If DEStart.Text.ToString = "" Or DEUntil.Text.ToString = "" Then
            stopCustom("Please fill date schedule first")
        Else
            GVEmployee.ActiveFilterString = "[is_select]='yes' "
            If GVEmployee.RowCount > 0 Then
                PGBBulk.EditValue = 0
                For i As Integer = 0 To GVEmployee.RowCount - 1
                    'loop date
                    Dim startP As Date = DEStart.EditValue
                    Dim endP As Date = DEUntil.EditValue
                    Dim CurrD As Date = startP
                    Dim length = endP - startP

                    PGBDate.EditValue = 0
                    Dim j As Integer = 0
                    While (CurrD <= endP)
                        Dim date_start, date_until, id_employee As String
                        id_employee = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                        '
                        date_start = Date.Parse(CurrD).ToString("yyyy-MM-dd")
                        date_until = Date.Parse(CurrD).ToString("yyyy-MM-dd")
                        '
                        Dim query As String = "CALL add_shift(" & id_employee & "," & GVShift.GetFocusedRowCellValue("id_shift").ToString & ",'" & date_start & "','" & date_until & "',1)"
                        execute_non_query(query, True, "", "", "", "")

                        progres_bar_cus_update(PGBDate, j + 1, length.Days)
                        j += 1
                        CurrD = CurrD.AddDays(1)
                    End While
                    '
                    progres_bar_cus_update(PGBBulk, i + 1, GVEmployee.RowCount)
                Next
                infoCustom("Schedule success.")
            Else
                stopCustom("Please choose employee first.")
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BDayOff_Click(sender As Object, e As EventArgs) Handles BDayOff.Click
        Cursor = Cursors.WaitCursor
        If DEStart.Text.ToString = "" Or DEUntil.Text.ToString = "" Then
            stopCustom("Please fill date schedule first")
        Else
            GVEmployee.ActiveFilterString = "[is_select]='yes' "
            If GVEmployee.RowCount > 0 Then
                For i As Integer = 0 To GVEmployee.RowCount - 1
                    FormMain.BEProgress.EditValue = 0
                    'do schedule
                    Dim date_start, date_until, id_employee As String
                    id_employee = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                    '
                    date_start = Date.Parse(DEStart.EditValue).ToString("yyyy-MM-dd")
                    date_until = Date.Parse(DEUntil.EditValue).ToString("yyyy-MM-dd")
                    '
                    Dim query As String = "CALL add_shift(" & id_employee & "," & GVShift.GetFocusedRowCellValue("id_shift").ToString & ",'" & date_start & "','" & date_until & "',2)"
                    execute_non_query(query, True, "", "", "", "")

                    '
                    progres_bar_cus_update(PGBBulk, i + 1, GVEmployee.RowCount)
                Next
                PGBBulk.EditValue = 0
                infoCustom("Set dayoff success.")
            Else
                stopCustom("Please choose employee first.")
            End If
        End If

        Cursor = Cursors.Default
    End Sub
End Class