Public Class FormCashAdvanceReconcile
    Public id_ca As String = ""
    Public is_view As String = "-1"

    Private Sub FormCashAdvanceReconcile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormCashAdvanceReconcile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_type()
        load_employee()
        load_dep()
        '
        load_acc()
        '
        load_det()
        load_ca()
    End Sub

    Sub load_acc()
        Dim query As String = "SELECT id_acc,acc_name,acc_description,CONCAT(acc_name,' - ',acc_description) as acc FROM tb_a_acc WHERE id_is_det='2'"
        viewSearchLookupRepositoryQuery(RSLECOA, query, 0, "acc", "id_acc")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT * FROM tb_cash_advance_report WHERE id_cash_advance='" & id_ca & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.BestFitColumns()
        check_but()
    End Sub

    Sub check_but()
        If GVJournalDet.RowCount = 0 Then
            BDelete.Visible = False
        Else
            BDelete.Visible = True
        End If
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_cash_advance_type,cash_advance_type FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT id_employee,id_departement,employee_name FROM tb_m_employee"
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_ca()
        Dim query As String = "SELECT * FROM tb_cash_advance WHERE id_cash_advance='" & id_ca & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TENumber.Text = data.Rows(0)("number").ToString

            DEActualReconcile.EditValue = Now
            DEDueDate.EditValue = data.Rows(0)("report_back_due_date")
            '
            SLEType.EditValue = data.Rows(0)("id_cash_advance_type").ToString
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
            SLEDepartement.EditValue = data.Rows(0)("id_departement").ToString
            '
            check_but()
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVJournalDet.RowCount > 0 Then
            GVJournalDet.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        GVJournalDet.AddNewRow()
        GVJournalDet.FocusedRowHandle = GVJournalDet.RowCount - 1
        check_but()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'check
        If GVJournalDet.RowCount = 0 Then
            warningCustom("Please insert detail report first")
        Else
            Dim query As String = "INSERT INTO tb_cash_advance_report(id_cash_advance,id_acc,description,value,note) VALUES"
            For i As Integer = 0 To GVJournalDet.RowCount - 1
                If Not i = 0 Then
                    query += ","
                End If
                query += "('" & id_ca & "','" & GVJournalDet.GetRowCellValue(i, "id_acc").ToString & "','" & GVJournalDet.GetRowCellValue(i, "description").ToString & "','" & decimalSQL(GVJournalDet.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVJournalDet.GetRowCellValue(i, "note").ToString) & "')"
            Next
            execute_non_query(query, True, "", "", "", "")
            warningCustom("Report saved")
        End If
    End Sub

    Private Sub RSLECOA_EditValueChanged(sender As Object, e As EventArgs) Handles RSLECOA.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            GVJournalDet.SetFocusedRowCellValue("description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVJournalDet_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GVJournalDet.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("value"), 0.00)
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        If GVJournalDet.RowCount = 0 Then
            warningCustom("Please insert detail report first")
        ElseIf GVJournalDet.Columns("value").SummaryItem.SummaryValue > 0 Then

        End If
    End Sub
End Class