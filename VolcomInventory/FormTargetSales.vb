﻿Public Class FormTargetSales
    Private Sub FormTargetSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewYearPropose()

    End Sub

    Private Sub BtnViewPropose_Click(sender As Object, e As EventArgs) Handles BtnViewPropose.Click
        viewPropose()
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor
        Dim tahun As String = ""
        Try
            tahun = SLEYearPropose.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT t.id_b_revenue_propose, t.`number`, t.`year`, t.`total`,
        t.created_date, t.id_created_user, e.employee_name AS `created_user`, t.note, 
        t.id_report_status, stt.report_status, t.is_confirm  
        FROM tb_b_revenue_propose t
        INNER JOIN tb_m_user u ON u.id_user = t.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = t.id_report_status 
        WHERE t.`year`='" + tahun + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPropose.DataSource = data
        GVPropose.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSales_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTargetSales_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormTargetSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class