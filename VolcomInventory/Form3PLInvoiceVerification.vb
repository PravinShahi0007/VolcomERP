Public Class Form3PLInvoiceVerification
    Private Sub Form3PLInvoiceVerification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub Form3PLInvoiceVerification_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub Form3PLInvoiceVerification_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_verification()
    End Sub

    Sub load_verification()
        Dim q As String = "SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name,SUM(invd.amount_cargo) AS a_tot,SUM(invd.amount_wh) AS c_tot,SUM(invd.amount_final) AS final_tot
FROM `tb_awb_inv_sum_det` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum AND is_other=2
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
GROUP BY inv.id_awb_inv_sum"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormAWBInv.ShowDialog()
    End Sub

    Private Sub GVInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoice.DoubleClick
        FormAWBInv.id_verification = GVInvoice.GetFocusedRowCellValue("id_awb_inv_sum").ToString
        FormAWBInv.ShowDialog()
    End Sub
End Class