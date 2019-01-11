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
            GVJournalDet.AddNewRow()
            GVJournalDet.SetFocusedRowCellValue("id_acc", data.Rows(0)("id_acc_to").ToString)
            GVJournalDet.SetFocusedRowCellValue("description", "Cash in Advance")
            GVJournalDet.SetFocusedRowCellValue("val_debit", 0.00)
            GVJournalDet.SetFocusedRowCellValue("val_credit", data.Rows(0)("val_ca"))
            GVJournalDet.SetFocusedRowCellValue("is_val_ca", 1)
            GVJournalDet.SetFocusedRowCellValue("note", "")
            GVJournalDet.CloseEditor()
            GCJournalDet.RefreshDataSource()
            GVJournalDet.RefreshData()
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
        Dim db As Decimal = 0.00
        Dim cr As Decimal = 0.00
        Dim is_acc_ok As Boolean = True
        '
        For i As Integer = 0 To GVJournalDet.RowCount - 1
            If GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                is_acc_ok = False
            End If
        Next
        '
        For i As Integer = 0 To GVJournalDet.RowCount - 1
            db += GVJournalDet.GetRowCellValue(i, "val_debit")
            cr += GVJournalDet.GetRowCellValue(i, "val_credit")
        Next
        '
        If is_acc_ok = False Then
            warningCustom("Please complete all data in report detail")
        ElseIf Not cr = db Then
            warningCustom("Value in report is not balance")
        ElseIf GVJournalDet.RowCount = 0 Then
            warningCustom("Please insert detail report first")
        Else
            Dim query As String = "INSERT INTO tb_cash_advance_report(id_cash_advance,id_acc,description,val_debit,val_credit,is_val_ca,note) VALUES"
            For i As Integer = 0 To GVJournalDet.RowCount - 1
                If Not i = 0 Then
                    query += ","
                End If
                query = "('" & id_ca & "','" & GVJournalDet.GetRowCellValue(i, "id_acc").ToString & "','" & GVJournalDet.GetRowCellValue(i, "description").ToString & "','" & decimalSQL(GVJournalDet.GetRowCellValue(i, "val_debit").ToString) & "','" & decimalSQL(GVJournalDet.GetRowCellValue(i, "val_credit").ToString) & "','" & GVJournalDet.GetRowCellValue(i, "is_val_ca").ToString & "','" & addSlashes(GVJournalDet.GetRowCellValue(i, "note").ToString) & "')"
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
        view.SetRowCellValue(e.RowHandle, view.Columns("val_credit"), 0.00)
        view.SetRowCellValue(e.RowHandle, view.Columns("val_debit"), 0.00)
        view.SetRowCellValue(e.RowHandle, view.Columns("is_val_ca"), 2)
    End Sub

    Private Sub GVJournalDet_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GVJournalDet.ShowingEditor
        Dim currentView As DevExpress.XtraGrid.Views.Grid.GridView = (TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView))
        '
        If GVJournalDet.GetFocusedRowCellValue("is_val_ca").ToString = "1" Then
            Dim allowEdit As Boolean = CBool(currentView.GetRowCellValue(currentView.FocusedRowHandle, currentView.Columns("AllowEdit")))
            e.Cancel = Not allowEdit
        End If
    End Sub
End Class