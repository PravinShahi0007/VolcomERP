Public Class FormSalesReportTrackingParam
    Dim id_comp_cat_store As String = "-1"
    Public id_comp As String = "0"
    Public id_store_contact_from As String = "0"

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "Select dr.id_wh_drawer, rack.id_wh_rack, Loc.id_wh_locator, cc.id_comp_contact, cc.id_comp, c.npwp, c.comp_number, c.comp_name, c.comp_commission, c.address_primary, c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeCompFrom.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TxtCodeCompFrom.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "85"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeCompFrom.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_store_contact_from = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                '
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesReportTrackingParam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")
    End Sub

    Sub load_rep()
        Dim query As String = "SELECT 0 as id_employee,'All' as employee_name
                                UNION
                                SELECT emp.id_employee,emp.employee_name FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                WHERE dep.id_departement=(SELECT id_dept_sales_rep FROM tb_opt_sales LIMIT 1) AND id_employee_active='1'
                                ORDER BY employee_name ASC"
        viewLookupQuery(LERepArea, query, 0, "employee_name", "id_employee")
    End Sub

    Sub load_island()
        Dim query As String = "SELECT 'All' as island
                                UNION
                                SELECT island FROM tb_m_city
                                WHERE NOT ISNULL(island)
                                GROUP BY island ORDER BY island ASC"
        viewLookupQuery(LEIsland, query, 0, "island", "island")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim date_start, date_end As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_end = Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")


        FormSalesReportTracking.load_data(id_comp, date_start, date_end)
        Close()
    End Sub

    Private Sub FormSalesReportTrackingParam_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class