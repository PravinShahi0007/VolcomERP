﻿Public Class FormProductionManualETA
    Public id_prod_order As String = "-1"
    Private Sub FormProductionManualETA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEArrive.Properties.MinValue = Now
    End Sub

    Sub view_eta_log()
        Dim q As String = "SELECT lo.*,emp.employee_name 
FROM `tb_prod_order_eta_qc_log` lo
INNER JOIN tb_m_user usr ON usr.id_user=lo.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCLog.DataSource = dt
        GVLog.BestFitColumns()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        view_eta_log()
    End Sub

    Private Sub Binput_Click(sender As Object, e As EventArgs) Handles Binput.Click
        Dim qu As String = ""
        'update
        qu = "UPDATE tb_prod_order SET manual_eta_date='" & Date.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_prod_order='" & id_prod_order & "'"
        execute_non_query(qu, True, "", "", "", "")
        'insert log
        qu = "INSERT INTO tb_prod_order_eta_qc_log(id_user,datetime,eta_date) VALUES('" & id_user & "',NOW(),'" & Date.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd") & "')"
        execute_non_query(qu, True, "", "", "", "")

        view_eta_log()
    End Sub
End Class