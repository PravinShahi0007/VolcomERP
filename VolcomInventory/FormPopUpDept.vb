Public Class FormPopUpDept
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        If id_pop_up = "4" Then
            query = "SELECT d.* FROM tb_m_departement d 
INNER JOIN tb_coa_map_departement coa ON coa.id_departement=d.id_departement AND coa.type=8
ORDER BY d.departement ASC "
        ElseIf id_pop_up = "1" Then
            query = "SELECT * FROM tb_m_departement d WHERE d.is_office_dept=1 AND d.is_kk_unit=2 AND d.is_store=2 ORDER BY d.departement ASC "
        Else
            query = "SELECT * FROM tb_m_departement d ORDER BY d.departement ASC "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            If id_pop_up = "1" Then
                Cursor = Cursors.WaitCursor
                FormEmpUniExpenseDet.id_departement = GVData.GetFocusedRowCellValue("id_departement").ToString
                FormEmpUniExpenseDet.TxtDepartement.Text = GVData.GetFocusedRowCellValue("departement").ToString
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "2" Then
                Cursor = Cursors.WaitCursor
                FormBudgetExpenseProposeFormatXLS.id_dept = GVData.GetFocusedRowCellValue("id_departement").ToString
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "3" Then
                Cursor = Cursors.WaitCursor
                FormBudgetExpenseRevisionNew.id_dept = GVData.GetFocusedRowCellValue("id_departement").ToString
                FormBudgetExpenseRevisionNew.TxtDept.Text = GVData.GetFocusedRowCellValue("departement").ToString
                FormBudgetExpenseRevisionNew.viewAnnual()
                Close()
                Cursor = Cursors.Default
            ElseIf id_pop_up = "4" Then
                Cursor = Cursors.WaitCursor
                FormAWBOtherInv.GVInvoice.SetFocusedRowCellValue("id_departement", GVData.GetFocusedRowCellValue("id_departement").ToString)
                FormAWBOtherInv.GVInvoice.SetFocusedRowCellValue("departement", GVData.GetFocusedRowCellValue("departement").ToString)
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub
End Class