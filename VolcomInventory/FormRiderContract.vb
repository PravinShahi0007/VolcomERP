Public Class FormRiderContract
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormRiderContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEContract.EditValue = Now
    End Sub

    Sub load_contract()
        Dim q As String = "SELECT 'no' AS is_check,ppsd.id_kontrak_rider,c.`comp_name`,ppsd.kontrak_from,ppsd.kontrak_until,ppsd.id_comp,ppsd.id_kontrak_type
,CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until,'%d %b %Y'),'')) AS contract
,IF(ISNULL(ppsd.`kontrak_from`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until)*ppsd.`monthly_pay`) AS total
,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until) AS qty_month
,IFNULL(ppsd.`monthly_pay`,0) AS monthly_pay
FROM `tb_kontrak_rider` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
WHERE ppsd.kontrak_from<='" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND ppsd.kontrak_until>='" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCContractList.DataSource = dt
        GVContractList.BestFitColumns()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT * FROM tb_kontrak_rider_pps pps
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pps.`id_report_status`
ORDER BY pps.id_kontrak_rider_pps DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPPS.DataSource = dt
        GVPPS.BestFitColumns()
    End Sub

    Private Sub BChanges_Click(sender As Object, e As EventArgs) Handles BNewExtend.Click
        GVContractList.ActiveFilterString = "[is_check]='yes'"
        FormRiderContractDet.id_type = "1"
        FormRiderContractDet.ShowDialog()
        GVContractList.ActiveFilterString = ""
    End Sub

    Private Sub GVPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVPPS.DoubleClick
        If GVPPS.RowCount > 0 Then
            FormRiderContractDet.id_pps = GVPPS.GetFocusedRowCellValue("id_kontrak_rider_pps").ToString
            FormRiderContractDet.ShowDialog()
        End If
    End Sub

    Private Sub BRefreshPPS_Click(sender As Object, e As EventArgs) Handles BRefreshPPS.Click
        load_pps()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_contract()
    End Sub

    Private Sub BChanges_Click_1(sender As Object, e As EventArgs) Handles BChanges.Click
        GVContractList.ActiveFilterString = "[is_check]='yes'"
        FormRiderContractDet.id_type = "2"
        FormRiderContractDet.ShowDialog()
        GVContractList.ActiveFilterString = ""
    End Sub
End Class