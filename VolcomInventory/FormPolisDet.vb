Public Class FormPolisDet
    Private Sub BLoadPolis_Click(sender As Object, e As EventArgs) Handles BLoadPolis.Click
        Dim q As String = "SELECT 
p.id_polis AS old_id_polis,p.end_date,pol_by.comp_name AS comp_name_polis,c.comp_number,c.`comp_name`,c.`address_primary`
FROM tb_polis_det pd
INNER JOIN tb_polis p ON p.`id_polis`=pd.`id_polis`
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_reff` AND p.`id_polis_cat`=1
INNER JOIN tb_m_comp pol_by ON pol_by.id_comp=p.id_polis_by
LEFT JOIN 
(
    SELECT ppsd.`id_comp`,ppsd.`id_polis_pps`
    FROM `tb_polis_pps_det` ppsd
    INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND pps.`id_report_status`!=6 AND pps.`id_report_status`!=5
    GROUP BY ppsd.`id_comp`
)pps ON pps.id_comp=pd.id_reff
WHERE p.`is_active`=1 AND DATEDIFF(p.end_date,DATE(NOW()))<45 AND ISNULL(pps.id_comp)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            GCSummary.DataSource = dt
            BGVSummary.BestFitColumns()
        End If
    End Sub
End Class