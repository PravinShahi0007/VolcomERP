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
GROUP BY inv.id_awb_inv_sum
ORDER BY inv.id_awb_inv_sum DESC"

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

    Private Sub BRefreshOffice_Click(sender As Object, e As EventArgs) Handles BRefreshOffice.Click
        load_verification_office()
    End Sub

    Private Sub BCreateOffice_Click(sender As Object, e As EventArgs) Handles BCreateOffice.Click
        FormAWBOtherInv.ShowDialog()
    End Sub

    Private Sub GVInvoiceOffice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoiceOffice.DoubleClick
        If GVInvoiceOffice.RowCount > 0 Then
            FormAWBOtherInv.id_verification = GVInvoiceOffice.GetFocusedRowCellValue("id_awb_inv_sum").ToString
            FormAWBOtherInv.ShowDialog()
        End If
    End Sub

    Sub load_verification_office()
        Dim q As String = "SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name,SUM(invd.amount_final) AS final_tot
FROM `tb_awb_inv_sum_other` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum AND is_other=1
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
GROUP BY inv.id_awb_inv_sum
ORDER BY inv.id_awb_inv_sum DESC"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoiceOffice.DataSource = dt
        GVInvoiceOffice.BestFitColumns()
    End Sub

    Private Sub Form3PLInvoiceVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()

        DEStartAWBList.EditValue = Now
        DEUntilAWBList.EditValue = Now
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' comp_name
UNION ALL
SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLE3PLAWBList, q, "id_comp", "comp_name", "id_comp")
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
,IFNULL(invo.amount_final,0) AS amount_final
FROM `tb_awb_office_det` awbo 
INNER JOIN tb_awb_office awb ON awb.id_awb_office=awbo.id_awb_office
INNER JOIN tb_m_departement dep ON dep.id_departement=awbo.id_departement
LEFT JOIN tb_m_comp c ON c.id_comp=awbo.`id_client`
INNER JOIN tb_m_comp v ON v.`id_comp`=awb.`id_comp`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awbo.id_sub_district
LEFT JOIN  
(
    SELECT id_awb_office_det,inv.inv_number,amount_final
    FROM tb_awb_inv_sum_other invo 
    INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invo.id_awb_inv_sum AND inv.id_report_status=6
)invo ON invo.id_awb_office_det=awbo.id_awb_office_det
WHERE DATE(awb.pickup_date)>='" & Date.Parse(DEStartAWBList.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(awb.pickup_date)<='" & Date.Parse(DEUntilAWBList.EditValue.ToString).ToString("yyyy-MM-dd") & "' " & qw
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BExportOffice_Click(sender As Object, e As EventArgs) Handles BExportOffice.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.DataAware

            GVList.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class