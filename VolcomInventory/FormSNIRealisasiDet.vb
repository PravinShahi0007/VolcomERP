Public Class FormSNIRealisasiDet
    Public id As String = "-1"
    '
    Dim id_pps As String = "-1"

    Private Sub FormSNIRealisasiDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEBudgetNumber.Focus()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        load_budget()
    End Sub

    Sub load_budget()
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,pps.id_report_status,pps.is_submit 
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pps.`number`='" & addSlashes(TEBudgetNumber.Text) & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            id_pps = dt.Rows(0)("id_sni_pps").ToString
            '
            load_proposed()

            load_artikel()
            load_budget_det()
            '
            usage_artikel()
            '
            calculate_budget()
            '
            TEBudgetNumber.Properties.ReadOnly = True
            BLoad.Visible = False
        Else
            warningCustom("Proposal budget not found")
            TEBudgetNumber.Text = ""
            TEBudgetNumber.Focus()
        End If
    End Sub

    Sub load_proposed()
        Dim q As String = "SELECT 'no' AS is_check,clr.color,IFNULL(p.id_product,0) AS id_product,dsg.`id_design`,dsg.`design_code`,dsg.design_fabrication,dsg.`design_display_name`,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) AS ecop,del.`delivery`,ssn.`season`
,'VOLCOM' AS brand,co.country,pdl.qty_line_list,so.season_orign
FROM tb_sni_pps_list `ppsl`
LEFT JOIN tb_m_product p ON p.id_design=ppsl.id_design AND p.product_code='921' -- hanya S
INNER JOIN tb_m_design dsg ON dsg.`id_design`=ppsl.`id_design`
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design`
INNER JOIN tb_season_delivery del ON del.id_delivery=dsg.`id_delivery`
INNER JOIN tb_season ssn ON ssn.id_season=del.id_season
INNER JOIN tb_season_orign so ON so.id_season_orign=dsg.id_season_orign
INNER JOIN tb_m_country co ON co.id_country=so.id_country
INNER JOIN 
(
    SELECT dc.id_design,CONCAT(cd.code_detail_name,' (',cd.display_name,')') AS color
    FROM `tb_m_design_code` dc
    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail=dc.id_code_detail
    WHERE cd.id_code='14'
    GROUP BY dc.id_design
) clr oN clr.id_design=dsg.id_design
INNER JOIN
(
    SELECT dsg.`id_design`,SUM(pdp.`prod_demand_product_qty`) AS qty_line_list
    FROM tb_m_design dsg
    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
    INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
    GROUP BY dsg.`id_design`
)pdl ON pdl.id_design=dsg.id_design
AND dsg.`is_approved`=1 AND dsg.`is_old_design`=2 AND dsg.`id_lookup_status_order`!=2
WHERE ppsl.id_sni_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCProposed.DataSource = dt
        GVProposed.BestFitColumns()
        '
    End Sub

    Sub load_artikel()
        Dim q As String = "SELECT 'no' AS is_check,id_design,id_product,id_sni_pps_budget,budget_desc,budget_value,budget_qty
FROM `tb_sni_pps_budget` b
WHERE b.id_sni_pps='" & id_pps & "' AND NOT ISNULL(b.id_design) AND NOT ISNULL(b.id_product)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBudgetCop.DataSource = dt
        GVBudgetCop.BestFitColumns()
    End Sub

    Sub load_budget_det()
        Dim q As String = "SELECT 'no' AS is_check,id_sni_pps_budget,budget_desc,budget_value,budget_qty
FROM `tb_sni_pps_budget` b
WHERE b.id_sni_pps='" & id_pps & "' AND ISNULL(b.id_design)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBudget.DataSource = dt
        GVBudget.BestFitColumns()
    End Sub

    Sub calculate_budget()
        GVBudget.RefreshData()
        GVBudgetCop.RefreshData()

        TETotalBudget.EditValue = GVBudgetCop.Columns("sub_amount").SummaryItem.SummaryValue + GVBudget.Columns("sub_amount").SummaryItem.SummaryValue
        TETotalQty.EditValue = GVProposed.Columns("qty_line_list").SummaryItem.SummaryValue
        TESNICop.EditValue = Math.Round((GVBudgetCop.Columns("sub_amount").SummaryItem.SummaryValue + GVBudget.Columns("sub_amount").SummaryItem.SummaryValue) / GVProposed.Columns("qty_line_list").SummaryItem.SummaryValue, 2)
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()

    Private Sub GVProposed_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVProposed.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub
    Private Sub GVProposed_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProposed.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub usage_artikel()
        Dim q As String = "SELECT b.id_design,0.00 AS bom_design_price,b.id_product,b.id_sni_pps_budget,b.budget_desc,b.budget_value,b.budget_qty,IFNULL(rec.qty,0) AS rec_qty,0 AS ret_qty
FROM `tb_sni_pps_budget` b
LEFT JOIN 
(
	SELECT rec.`id_sni_pps`,recd.id_product,SUM(recd.qty) AS qty
	FROM `tb_sni_rec_det` recd 
	INNER JOIN tb_sni_rec rec ON rec.`id_sni_rec`=recd.`id_sni_rec` AND rec.`id_report_status`=6
	GROUP BY recd.`id_product`
)rec ON rec.`id_product`=b.`id_product` AND rec.id_sni_pps=b.`id_sni_pps`
WHERE b.id_sni_pps='" & id_pps & "' 
AND NOT ISNULL(b.id_design) AND NOT ISNULL(b.id_product)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSampling.DataSource = dt
        GVSampling.BestFitColumns()
        '
        For i = 0 To GVSampling.RowCount - 1
            GVSampling.SetRowCellValue(i, "bom_design_price", get_bom_design_price(GVSampling.GetRowCellValue(i, "id_design").ToString))
        Next
    End Sub

    Function get_bom_design_price(ByVal id_design As String)
        Dim cop As Decimal = 0.00
        'cop total
        Dim cop_total As Decimal = 0.00
        Dim q As String = "CALL view_cop_design_po('" & id_design & "')"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                cop_total += dt.Rows(0)("total_price")
            Next
        End If

        'qty total
        Dim qty_total As Integer = 1
        q = "SELECT SUM(prod_order_qty) AS qty_order
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.id_prod_order=pod.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design AND po.id_report_status=6
WHERE pdd.id_design='" & id_design & "'"
        Dim dt_total As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        If dt_total.Rows.Count > 0 Then
            qty_total = dt_total.Rows(0)("qty_order")
        End If

        cop = Math.Round(cop_total / qty_total, 2)

        Return cop
    End Function
End Class