Public Class FormPolisReg
    Public id_polis_pps As String = "-1"
    Public id_reg As String = "-1"
    Private Sub BSaveDraft_Click(sender As Object, e As EventArgs) Handles BSaveDraft.Click

    End Sub

    Private Sub FormPolisReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps_view()
    End Sub

    Sub load_pps_view()
        If id_reg = "-1" Then
            FormPolisRegPick.ShowDialog()
            If id_polis_pps = "-1" Then
                Close()
            Else
                Dim q As String = "SELECT pol.end_date,pps.id_polis_pps,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
,ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,ppsd.`premi`,ppsd.`polis_vendor`,v.`comp_name` AS vendor
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_polis pol ON pol.`id_polis`=ppsd.`old_id_polis`
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND ppsd.`id_polis_pps`='" & id_polis_pps & "' AND pps.id_report_status=6
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
INNER JOIN tb_m_comp v ON v.`id_comp`=ppsd.`polis_vendor`"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCSummary.DataSource = dt
                BGVSummary.BestFitColumns()
            End If
        Else
            Dim q As String = "SELECT pol.end_date,pps.id_polis_pps,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
,ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,ppsd.`premi`,ppsd.`polis_vendor`,v.`comp_name` AS vendor
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_polis pol ON pol.`id_polis`=ppsd.`old_id_polis`
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND ppsd.`id_polis_pps`='" & id_polis_pps & "' AND pps.id_report_status=6
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
INNER JOIN tb_m_comp v ON v.`id_comp`=ppsd.`polis_vendor`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSummary.DataSource = dt
            BGVSummary.BestFitColumns()
        End If
    End Sub
End Class