Public Class FormVMStock
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormVMStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DESOHUntil.EditValue = Now()
        load_store()
    End Sub

    Sub load_store()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' AS comp_name,'ALL' AS comp_number,'-' AS sts
UNION ALL
SELECT 'office' AS id_comp,'Office' AS comp_name,'Office' AS comp_number,'-' AS sts
UNION ALL
SELECT id_comp,comp_name,comp_number,IF(is_active=1,'Active','Not Active') AS sts
FROM tb_m_comp WHERE id_comp_cat='6'"
        viewSearchLookupQuery(SLEToko, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLECardToko, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Dim qw As String = ""

        If SLEToko.EditValue.ToString = "office" Then
            qw = " AND id_comp='0' "
        ElseIf SLEToko.EditValue.ToString = "ALL" Then
            qw = ""
        Else
            qw = " AND id_comp='" & SLEToko.EditValue.ToString & "' "
        End If

        Dim q As String = "(SELECT st.`id_comp`,c.`comp_number`,c.`comp_name`,IF(st.id_comp=0,'Office',CONCAT(c.comp_number,' - ',c.comp_name)) AS location,i.`id_item`,i.`item_desc`,SUM(st.qty) AS qty,uom.uom
FROM `tb_stock_vm` st
LEFT JOIN tb_m_comp c ON c.`id_comp`=st.`id_comp`
INNER JOIN tb_item i ON i.`id_item`=st.`id_item`
INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom
WHERE DATE(st.stock_date)<=DATE('" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
GROUP BY st.`id_comp`,st.`id_item`
HAVING qty>0 " & qw & ")
UNION ALL
(SELECT '0' AS `id_comp`,'Office (Storage)' AS `comp_number`,'Office (Storage)' AS `comp_name`,'Office (Storage)' AS location,im.`id_item`,im.`item_desc`,
SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) AS `qty`,uom.uom
FROM tb_storage_item i
INNER JOIN tb_item im ON im.id_item = i.id_item
INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
WHERE DATE(i.storage_item_datetime)<=DATE('" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND i.id_departement='18'
GROUP BY i.id_departement,i.id_item
HAVING qty>0 " & qw & ")"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStock.DataSource = dt
        GVStock.BestFitColumns()
    End Sub

    Private Sub BMoveAsset_Click(sender As Object, e As EventArgs) Handles BMoveAsset.Click
        FormVMMove.ShowDialog()
    End Sub

    Private Sub GVMoveList_DoubleClick(sender As Object, e As EventArgs) Handles GVMoveList.DoubleClick
        FormVMMove.id = GVMoveList.GetFocusedRowCellValue("id_vm_item_move").ToString
        FormVMMove.ShowDialog()
    End Sub

    Private Sub BRefreshMove_Click(sender As Object, e As EventArgs) Handles BRefreshMove.Click
        Dim q As String = "SELECT IF(h.id_type=1,'Transfer',IF(h.id_type=2,'Add Asset','Remove Asset')) AS type,IF(h.id_comp_from=0,'Office',IFNULL(cf.comp_name,'-')) AS comp_from,IF(h.id_comp_to=0,'Office',IFNULL(ct.comp_name,'-')) AS comp_to,h.id_vm_item_move,h.number,h.note,h.created_date,sts.report_status,emp.employee_name,h.id_report_status,h.id_comp_from,h.id_comp_to,h.id_type FROM tb_vm_item_move h
INNER JOIN tb_m_user usr ON usr.id_user=h.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=h.id_report_status
LEFT JOIN tb_m_comp cf ON cf.id_comp=h.id_comp_from
LEFT JOIN tb_m_comp ct ON ct.id_comp=h.id_comp_to
ORDER BY h.id_vm_item_move DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCMoveList.DataSource = dt
        GVMoveList.BestFitColumns()
    End Sub

    Private Sub BSearchCard_Click(sender As Object, e As EventArgs) Handles BSearchCard.Click

    End Sub
End Class