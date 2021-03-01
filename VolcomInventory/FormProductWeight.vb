Public Class FormProductWeight
    Public id_trans As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormProductWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProductWeight_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub TEFGPONumbers_KeyDown(sender As Object, e As KeyEventArgs) Handles TEFGPONumbers.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TEFGPONumbers.Text = "" Then
                Dim q As String = "SELECT p.`id_product`,p.`product_full_code`,p.`product_display_name`,cd.`code_detail_name` AS size, 0.00 AS weight,0 AS id_product_weight_pps_det,'' AS note
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.prod_order_number='" & TEFGPONumber.Text & TEFGPONumbers.Text & "'
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN `tb_m_product_code` pc ON p.id_product=pc.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    GCItem.DataSource = dt
                    GVItem.BestFitColumns()
                Else
                    warningCustom("FGPO Not Found")
                End If
            End If
        End If
    End Sub
End Class