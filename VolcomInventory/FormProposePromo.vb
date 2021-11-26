Public Class FormProposePromo
    Private Sub FormProposePromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormProposePromo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT p.id_propose_promo, p.number, p.nama, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, r.report_status
            FROM tb_propose_promo AS p
            LEFT JOIN tb_m_employee AS e ON p.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON p.id_report_status = r.id_report_status
            ORDER BY p.id_propose_promo DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCPromo.DataSource = data

        GVPromo.BestFitColumns()
    End Sub

    Private Sub FormProposePromo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProposePromo_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVPromo_DoubleClick(sender As Object, e As EventArgs) Handles GVPromo.DoubleClick
        FormMain.but_edit()
    End Sub
End Class