Public Class FormEmpUniReport
    Private Sub FormEmpUniReport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormEmpUniReport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpUniReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewPeriodUniform()
        viewDept()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim dept As String = "0"
        Try
            dept = LEDeptSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim period As String = "0"
        Try
            period = LEPeriodx.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_emp_uni_budget(" + period + ", '" + dept + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        Cursor = Cursors.Default
    End Sub


    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE a.id_departement=" + id_departement_user + " ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewPeriodUniform()
        Dim query As String = "SELECT * FROM tb_emp_uni_period p ORDER BY p.id_emp_uni_period DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.Properties.DataSource = Nothing
        LEPeriodx.Properties.DataSource = data
        LEPeriodx.Properties.DisplayMember = "period_name"
        LEPeriodx.Properties.ValueMember = "id_emp_uni_period"
        LEPeriodx.ItemIndex = 0
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewDetail()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCDetail, "")
    End Sub
End Class