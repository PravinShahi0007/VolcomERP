Public Class FormBuktiPickup
    Private Sub FormBuktiPickup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT pickup.id_pickup, DATE_FORMAT(pickup.pickup_date, '%d %b %Y') AS pickup_date, CONCAT(comp.comp_number, ' - ', comp.comp_name) AS comp_name, pickup.note, pickup.id_report_status, IF(pickup.id_report_status = 0, 'Draft', status.report_status) AS report_status, DATE_FORMAT(pickup.created_date, '%d %b %Y %H:%i:%s') AS created_date, created_by.employee_name AS created_by, DATE_FORMAT(pickup.updated_date, '%d %b %Y %H:%i:%s') AS updated_date, updated_by.employee_name AS updated_by
            FROM tb_del_pickup AS pickup
            LEFT JOIN tb_m_comp AS comp ON pickup.id_comp = comp.id_comp
            LEFT JOIN tb_lookup_report_status AS status ON pickup.id_report_status = status.id_report_status
            LEFT JOIN tb_m_employee AS created_by ON pickup.created_by = created_by.id_employee
            LEFT JOIN tb_m_employee AS updated_by ON pickup.updated_by = updated_by.id_employee
            WHERE pickup.created_date IS NOT NULL AND pickup.created_by IS NOT NULL
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormBuktiPickup_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBuktiPickup_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBuktiPickup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        Try
            FormBuktiPickupDet.id_pickup = GVList.GetFocusedRowCellValue("id_pickup").ToString
            FormBuktiPickupDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class