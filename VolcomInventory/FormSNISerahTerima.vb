Public Class FormSNISerahTerima
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSNISerahTerima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Sub load_list()
        Dim q As String = "SELECT rec.`id_sni_rec`,rec.number,emp.employee_name AS created_by,rec.created_date,pps.number AS pps_number,sts.report_status
FROM `tb_sni_rec` rec
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=rec.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=rec.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_sni_pps pps ON pps.id_sni_pps=rec.id_sni_pps
ORDER BY rec.id_sni_rec DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSNISerahTerimaDet.ShowDialog()
    End Sub

    Private Sub FormSNISerahTerima_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSNISerahTerima_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVList.RowCount < 1 Then
            'hide all except new
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormSNISerahTerimaDet.id = GVList.GetFocusedRowCellValue("id_sni_rec").ToString
        FormSNISerahTerimaDet.ShowDialog()
    End Sub
End Class