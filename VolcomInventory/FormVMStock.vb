Public Class FormVMStock
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

        Dim q As String = "(SELECT st.`id_comp`,c.`comp_number`,c.`comp_name`,i.`id_item`,i.`item_desc`,SUM(st.qty) AS qty,uom.uom
FROM `tb_stock_vm` st
INNER JOIN tb_m_comp c ON c.`id_comp`=st.`id_comp`
INNER JOIN tb_item i ON i.`id_item`=st.`id_item`
INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom
WHERE st.stock_date<='" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY st.`id_comp`,st.`id_item`
HAVING qty>0 " & qw & ")
UNION ALL
(SELECT '0' AS `id_comp`,'Office (Storage)' AS `comp_number`,'Office (Storage)' AS `comp_name`,im.`id_item`,im.`item_desc`,
SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) AS `qty`,uom.uom
FROM tb_storage_item i
INNER JOIN tb_item im ON im.id_item = i.id_item
INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
WHERE DATE(i.storage_item_datetime)<'" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND i.id_departement='18'
GROUP BY i.id_departement,i.id_item
HAVING qty>0 " & qw & ")"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStock.DataSource = dt
        GVStock.BestFitColumns()
    End Sub
End Class