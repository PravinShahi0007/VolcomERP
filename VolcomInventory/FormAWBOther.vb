Public Class FormAWBOther
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
        If GVAWB.RowCount < 1 Then
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
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_form()
    End Sub

    Sub load_form()
        Dim qw As String = ""

        If Not SLECargo.EditValue.ToString = "ALL" Then
            qw = " AND awb.id_comp='" & SLECargo.EditValue.ToString & "'"
        End If

        Dim qv As String = "SELECT IF(awb.is_void=1,'Void','-') AS status,awb.id_awb_office,CONCAT('AWBOFC',LPAD(awb.id_awb_office,5,'0')) AS number,awb.id_comp,awb.pickup_date,awb.created_date,emp.employee_name,awb.pickup_date
FROM `tb_awb_office` awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_comp
INNER JOIN tb_m_user usr ON usr.id_user=awb.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE DATE(awb.pickup_date)>='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(awb.pickup_date)<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' " & qw
        Dim dt As DataTable = execute_query(qv, -1, True, "", "", "", "")
        GCAWB.DataSource = dt
        GVAWB.BestFitColumns()
        check_menu()
    End Sub

    Private Sub FormAWBOther_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        '
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStartAWBList.EditValue = Now
        DEUntilAWBList.EditValue = Now
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' comp_name
UNION ALL
SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLE3PLAWBList, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        DEStart.Properties.MaxValue = DEUntil.EditValue
    End Sub

    Private Sub DEStartAWBList_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartAWBList.EditValueChanged
        DEUntilAWBList.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub DEUntilAWBList_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAWBList.EditValueChanged
        DEStartAWBList.Properties.MaxValue = DEUntil.EditValue
    End Sub

    Private Sub BViewAWBList_Click(sender As Object, e As EventArgs) Handles BViewAWBList.Click
        load_awb_list()
    End Sub

    Sub load_awb_list()
        Dim qw As String = ""

        If Not SLE3PLAWBList.EditValue.ToString = "ALL" Then
            qw = " AND awb.id_comp='" & SLE3PLAWBList.EditValue.ToString & "'"
        End If

        Dim q As String = "SELECT awbo.id_awb_office_det,awbo.`awbill_no`,dep.id_departement,dep.departement,awbo.`jml_koli`,awbo.id_client,IF(ISNULL(awbo.id_client),'Not Registered',c.comp_name) AS comp_name,dis.id_sub_district,dis.sub_district
,awb.pickup_date
,awbo.`client_note`,IFNULL(invo.inv_number,'') AS inv_number,v.`comp_name` AS vendor_name
FROM `tb_awb_office_det` awbo 
INNER JOIN tb_awb_office awb ON awb.id_awb_office=awbo.id_awb_office
INNER JOIN tb_m_departement dep ON dep.id_departement=awbo.id_departement
LEFT JOIN tb_m_comp c ON c.id_comp=awbo.`id_client`
INNER JOIN tb_m_comp v ON v.`id_comp`=awb.`id_comp`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awbo.id_sub_district
LEFT JOIN  
(
    SELECT id_awb_office_det,inv.inv_number
    FROM tb_awb_inv_sum_other invo 
    INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invo.id_awb_inv_sum AND inv.id_report_status!=5
)invo ON invo.id_awb_office_det=awbo.id_awb_office_det
WHERE DATE(awb.pickup_date)>='" & Date.Parse(DEStartAWBList.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(awb.pickup_date)<='" & Date.Parse(DEUntilAWBList.EditValue.ToString).ToString("yyyy-MM-dd") & "' " & qw
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormAWBOtherInv.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_verification()
    End Sub

    Sub load_verification()
        Dim q As String = "SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name,SUM(invd.amount_final) AS final_tot
FROM `tb_awb_inv_sum_other` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum AND is_other=1
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
GROUP BY inv.id_awb_inv_sum"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub GVInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoice.DoubleClick
        If GVInvoice.RowCount > 0 Then
            FormAWBOtherInv.id_verification = GVInvoice.GetFocusedRowCellValue("id_awb_inv_sum").ToString
            FormAWBOtherInv.ShowDialog()
        End If
    End Sub

    Private Sub DropAWBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DropAWBToolStripMenuItem.Click
        If GVList.RowCount > 0 Then
            'check
            Dim q As String = "SELECT awbo.`awbill_no`,dep.id_departement,dep.departement,awbo.`jml_koli`,awbo.id_client,IF(ISNULL(awbo.id_client),'Not Registered',c.comp_name) AS comp_name,dis.id_sub_district,dis.sub_district
,awbo.`client_note`,IFNULL(inv.inv_number,'') AS inv_number
FROM `tb_awb_office_det` awbo 
INNER JOIN tb_awb_office awb ON awb.id_awb_office=awbo.id_awb_office
INNER JOIN tb_m_departement dep ON dep.id_departement=awbo.id_departement
LEFT JOIN tb_m_comp c ON c.id_comp=awbo.id_client
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awbo.id_sub_district
LEFT JOIN tb_awb_inv_sum_other invo ON invo.id_awb_office_det=awbo.id_awb_office_det
LEFT JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invo.id_awb_inv_sum AND inv.id_report_status!=5
WHERE awbo.id_awb_office_det='" & GVList.GetFocusedRowCellValue("id_awb_office_det").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("inv_number").ToString = "" Then
                    'delete
                    Dim confirm As DialogResult

                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = DialogResult.Yes Then
                        Dim qdel As String = "DELETE FROM tb_awb_office_det WHERE id_awb_office_det='" & GVList.GetFocusedRowCellValue("id_awb_office_det").ToString & "'"
                        execute_non_query(qdel, True, "", "", "", "")
                        load_awb_list()
                    End If
                Else
                    warningCustom("AWB sudah masuk ke dalam proses verifikasi")
                End If
            End If
        End If
    End Sub
End Class