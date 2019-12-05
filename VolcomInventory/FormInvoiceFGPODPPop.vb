Public Class FormInvoiceFGPODPPop
    Public id_po As String = "-1"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount > 0 Then
            For i = 0 To GVList.RowCount - 1
                Try
                    'check
                    Dim is_already As Boolean = False
                    For j = 0 To FormInvoiceFGPODP.GVList.RowCount - 1
                        If FormInvoiceFGPODP.GVList.GetRowCellValue(i, "id_report").ToString = GVList.GetRowCellValue(i, "id_pn_fgpo_det").ToString And FormInvoiceFGPODP.GVList.GetRowCellValue(i, "report_mark_type").ToString = "199" Then
                            is_already = True
                            Exit For
                        End If
                    Next
                    If is_already = False Then
                        Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = GVList.GetRowCellValue(i, "id_pn_fgpo_det").ToString
                        newRow("report_mark_type") = "199"
                        newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                        newRow("info_design") = GVList.GetRowCellValue(i, "design_display_name").ToString
                        newRow("qty") = GVList.GetRowCellValue(i, "qty")
                        newRow("value") = GVList.GetRowCellValue(i, "value") * -1
                        newRow("vat") = GVList.GetRowCellValue(i, "vat") * -1
                        newRow("inv_number") = GVList.GetRowCellValue(i, "inv_number").ToString
                        newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                        TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
                    End If
                Catch ex As Exception
                    warningCustom(ex.ToString)
                End Try
                FormInvoiceFGPODP.SLEVendor.EditValue = GVList.GetRowCellValue(i, "id_comp").ToString
            Next
            Close()
        Else
            warningCustom("Please select DP first")
        End If
        GVList.ActiveFilterString = ""
    End Sub

    Private Sub FormInvoiceFGPODPPop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPODPPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dp()
    End Sub

    Sub load_dp()
        Dim query As String = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det,pnd.qty, pn.`id_pn_fgpo`,pn.`number`,pnd.`value`,pnd.`vat`,pnd.`inv_number`,pnd.`note` 
,dsg.`design_code`,dsg.`design_display_name`,wo.id_comp,wo.comp_name
FROM `tb_pn_fgpo_det` pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_report` AND pnd.`report_mark_type`='22'
LEFT JOIN 
(
    SELECT c.`comp_name`,c.id_comp
    FROM tb_prod_order_wo wo
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovhp.id_comp_contact
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
    WHERE wo.id_prod_order='" & id_po & "' AND wo.is_main_vendor=1
)wo ON wo.id_prod_order=po.id_prod_order
INNER JOIN `tb_prod_demand_design` pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE pn.`id_report_status`= '6' AND pnd.`id_report`='" & id_po & "' AND pnd.report_mark_type='22' AND pn.`type`='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub
End Class