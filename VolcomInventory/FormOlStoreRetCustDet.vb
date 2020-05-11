﻿Public Class FormOlStoreRetCustDet
    Public id_ret As String = "-1"

    Dim order_id As String = ""
    Dim id_comp_group As String = ""

    Private Sub FormOlStoreRetCustDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT 0 AS id_comp_group,'ALL' AS comp_group,'ALL' AS description
UNION
SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM `tb_ol_store_ret_list` rl
INNER JOIN `tb_ol_store_ret_det` retd ON retd.`id_ol_store_ret`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret ret ON retd.id_ol_store_ret=ret.id_ol_store_ret
WHERE ret.id_report_status=6 AND (rl.`id_ol_store_ret_stt`=4 OR rl.id_ol_store_ret_stt=5)
GROUP BY ret.sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Private Sub FormOlStoreRetCustDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp_group()
        view_order()

        If id_ret = "-1" Then 'new

        End If
    End Sub
End Class