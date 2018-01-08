Public Class FormViewPRProdWOPIB
    Public pib_number As String = ""
    Private Sub FormViewPRProdWOPIB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pr()
    End Sub
    Sub load_pr()
        Dim query As String = "SELECT pr.`id_pr_prod_order`,pr.`pr_prod_order_number`,ovh.`id_ovh`,ovh.`overhead`,SUM(IF(prd.id_dc=1,-1,1)*(prd.`pr_prod_order_det_qty`*prd.`pr_prod_order_det_price`)) AS gross_total
                                ,pr.pr_prod_order_dp,pr.pr_prod_order_vat
                                ,IF(pr.pr_prod_order_dp=0,SUM(IF(prd.id_dc=1,-1,1)*(prd.`pr_prod_order_det_qty`*prd.`pr_prod_order_det_price`)) * ((100+pr.pr_prod_order_vat)/100),pr.pr_prod_order_dp* ((100+pr.pr_prod_order_vat)/100)) AS after_vat
                                FROM tb_pr_prod_order_det prd
                                INNER JOIN tb_pr_prod_order pr ON pr.`id_pr_prod_order`=prd.`id_pr_prod_order`
                                LEFT JOIN tb_m_ovh ovh ON ovh.`id_ovh`=prd.id_ovh
                                WHERE pr.`pr_prod_order_pib`='" & pib_number & "'
                                GROUP BY pr.`id_pr_prod_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPRWO.DataSource = data
    End Sub
End Class