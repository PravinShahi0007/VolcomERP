Public Class FormEmpHoliday
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpHoliday_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_year()
        load_religion()
    End Sub
    Sub load_year()
        Dim query As String = "SELECT 'ALL' AS `year` UNION SELECT YEAR(emp_holiday_date) AS `year` FROM tb_emp_holiday GROUP BY YEAR(emp_holiday_date) ORDER BY `year` DESC"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
    End Sub
    Sub load_religion()
        Dim query As String = "SELECT '0' AS id_religion,'ALL' AS religion UNION SELECT id_religion,religion FROM tb_lookup_religion"
        viewSearchLookupQuery(SLEReligion, query, "id_religion", "religion", "id_religion")
    End Sub
    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_holiday()
    End Sub
    Sub view_holiday()
        Dim date_search, religion_search As String
        If SLEYear.EditValue.ToString = "ALL" Then
            date_search = " LIKE '%%' "
        Else
            date_search = " = '" + SLEYear.EditValue.ToString + "'"
        End If
        '
        If SLEReligion.EditValue.ToString = "ALL" Then
            religion_search = " LIKE '%%' "
        Else
            religion_search = " = '" + SLEReligion.EditValue.ToString + "'"
        End If

        Dim query As String = "SELECT hol.*,IF(hol.id_religion=0,'Public Holiday',rel.religion) AS religion FROM tb_emp_holiday hol
                                LEFT JOIN tb_lookup_religion rel ON rel.id_religion=hol.id_religion WHERE YEAR(hol.emp_holiday_date) " + date_search + " AND (hol.id_religion " + religion_search + " OR hol.id_religion=0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHoliday.DataSource = data

    End Sub
    Private Sub FormEmpHoliday_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpHoliday_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        FormImportExcel.id_pop_up = "27"
        FormImportExcel.ShowDialog()
    End Sub
End Class