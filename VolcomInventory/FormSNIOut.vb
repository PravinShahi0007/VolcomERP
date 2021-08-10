Public Class FormSNIOut
    Public id As String = "-1"
    Private Sub FormSNIOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
    End Sub

    Private Sub FormSNIOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '' AS `no`,qco.`id_qc_sni_out_det`,po.`id_prod_order`,recd.`id_prod_order_rec`,po.`prod_order_number`,rec.`prod_order_rec_number`,p.`product_full_code`,dsg.`design_display_name`,cd.`display_name` AS size
FROM `tb_qc_sni_out_det` qco
INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec_det`=qco.`id_prod_order_rec_det`
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE qco.id_qc_sni_out='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Private Sub BAddProduct_Click(sender As Object, e As EventArgs) Handles BAddProduct.Click
        FormPopUpRecQC.id_pop_up = "5"
        FormPopUpRecQC.ShowDialog()
    End Sub

    Private Sub BDeleteProduct_Click(sender As Object, e As EventArgs) Handles BDeleteProduct.Click
        If GVDetail.RowCount > 0 Then
            GVDetail.DeleteSelectedRows()
        End If
    End Sub
End Class