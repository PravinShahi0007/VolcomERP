Public Class FormSNIRealisasi
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVRealisasi.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub load_list()
        Dim q As String = "SELECT sr.id_sni_realisasi,sr.number,sr.created_date,pps.number AS pps_number,emp.employee_name,total_real.total AS tot_realisasi
FROM tb_sni_realisasi sr
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=sr.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=sr.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee =usr.id_employee
INNER JOIN tb_sni_pps pps ON pps.id_sni_pps=sr.id_sni_pps
INNER JOIN
(
	SELECT tot.id_sni_realisasi,SUM(tot.val) AS total
	FROM
	(
		SELECT id_sni_realisasi,(qty*`value`) AS val
		FROM `tb_sni_realisasi_budget`
		GROUP BY id_sni_realisasi
		UNION ALL
		SELECT id_sni_realisasi,((rec_qty-ret_qty)*`bom_price`) AS val
		FROM `tb_sni_realisasi_return`
		GROUP BY id_sni_realisasi
	)tot
	GROUP BY tot.id_sni_realisasi
)total_real ON total_real.id_sni_realisasi=sr.id_sni_realisasi"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRealisasi.DataSource = dt
        GVRealisasi.BestFitColumns()
    End Sub

    Private Sub FormSNIRealisasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Private Sub GVRealisasi_DoubleClick(sender As Object, e As EventArgs) Handles GVRealisasi.DoubleClick
        FormSNIRealisasiDet.id = GVRealisasi.GetFocusedRowCellValue("id_sni_realisasi").ToString
        FormSNIRealisasiDet.ShowDialog()
    End Sub
End Class