Public Class FormStockCardDept
    Private Sub BtnViewSC_Click(sender As Object, e As EventArgs) Handles BtnViewSC.Click

    End Sub

    Private Sub BAddInOut_Click(sender As Object, e As EventArgs) Handles BAddInOut.Click
        FormStockCardDepDet.ShowDialog()
    End Sub

    Private Sub BViewInOut_Click(sender As Object, e As EventArgs) Handles BViewInOut.Click
        load_inout()
    End Sub

    Sub load_inout()
        Dim query As String = "SELECT trx.`id_item_card_trs`,trx.`number`,sts.`report_status`,emp.employee_name,trx.`created_date`,c.`comp_name`,IF(trx.id_type=1,'Delivery','Receiving') AS type
FROM `tb_item_card_trs` trx
INNER JOIN tb_m_departement dep ON dep.id_departement=trx.id_departement
INNER JOIN tb_m_user usr ON usr.`id_user`=trx.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=trx.`id_report_status`
INNER JOIN tb_m_comp c ON c.`id_comp`=trx.`id_store`
WHERE trx.id_departement='" & id_departement_user & "' AND DATE(trx.`created_date`) >= '" & Date.Parse(DEFromInout.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(trx.`created_date`) <= '" & Date.Parse(DEUntilInout.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY trx.id_item_card_trs DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInOut.DataSource = data
        GVInOut.BestFitColumns()
    End Sub

    Private Sub GVInOut_DoubleClick(sender As Object, e As EventArgs) Handles GVInOut.DoubleClick
        If GVInOut.RowCount > 0 Then
            FormStockCardDepDet.id_trans = GVInOut.GetFocusedRowCellValue("id_item_card_trs").ToString
            FormStockCardDepDet.ShowDialog()
        End If
    End Sub
End Class