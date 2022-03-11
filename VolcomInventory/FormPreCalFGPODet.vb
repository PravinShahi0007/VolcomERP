Public Class FormPreCalFGPODet
    Public id As String = "-1"
    Public is_view As String = "-1"

    Dim steps As String = "1"

    Private Sub FormPreCalFGPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_duty()
        Dim q As String = "SELECT po.`prod_order_number`,d.`design_code`,d.`design_display_name`,(l.`qty`*l.`price`) AS tot_fob,l.`qty`,l.`price`,cal.`rate_management`
,(l.`price`*cal.`rate_management`) AS fob_rp,(l.`price`*cal.`rate_management`)*l.`qty` AS tot_fob_rp
,ROUND(pdd.`prod_demand_design_propose_price`) AS pd_price,ROUND(((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) AS price_commision
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)) AS price_ppn
,ROUND(l.`qty`*(cal.`sales_percent`/100)) AS qty_sales
,ROUND(tot_freight.tot_freight/tot_fgpo.tot_qty_sales,2) AS freight_cost
,ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_freight
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100),2) AS royalty
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_royalty
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100),2) AS bm
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_bm
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.ppn/100),2) AS ppn_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.pph/100),2) AS pph_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.ppn/100)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS total_ppn_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.pph/100)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS total_pph_royalty
FROM `tb_pre_cal_fgpo_list` l
INNER JOIN tb_pre_cal_fgpo cal ON cal.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=l.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
INNER JOIN 
(
	SELECT det.`total_in_rp` AS tot_freight
	FROM tb_pre_cal_fgpo_det det
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=det.`id_pre_cal_fgpo` AND f.`choosen_id_comp`=det.`id_comp`
	WHERE det.`id_pre_cal_fgpo`='" & id & "' AND det.id_type=1
)tot_freight 
INNER JOIN 
(
	SELECT SUM(l.`qty`) AS tot_qty,SUM(ROUND(l.`qty`*(f.`sales_percent`/100))) AS tot_qty_sales
	FROM tb_pre_cal_fgpo_list l
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo` 
	WHERE f.`id_pre_cal_fgpo`='" & id & "'
)tot_fgpo
WHERE l.`id_pre_cal_fgpo`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDuty.DataSource = dt
        GVDuty.BestFitColumns()
    End Sub

    Sub load_kurs()
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Get kurs error.")
            TERateManagement.EditValue = 0.00
        Else
            TERateManagement.EditValue = data_kurs.Rows(0)("kurs_trans") + data_kurs.Rows(0)("fixed_floating")
        End If

        'rate payment average
        Dim q As String = "SELECT * FROM `tb_stock_valas` 
WHERE id_valas_bank=1 AND id_currency=2
ORDER BY id_stock_valas DESC LIMIT 1"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TERatePayment.EditValue = dt.Rows(0)("kurs_rata_rata")
        Else
            TERatePayment.EditValue = 1
        End If
    End Sub

    Sub load_head()
        load_type()
        load_vendor()

        If id = "-1" Then
            'new
            load_list_fgpo()
            load_kurs()
            '
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = False
            XTPOrignCharges.PageVisible = False
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
        Else
            'edit
            Dim q As String = "SELECT cal.reason,cal.ppn,cal.pph,cal.rate_current,cal.rate_management,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
,cal.quot_amo,cal.act_cbm,cal.quot_no,c.comp_name AS choosen_forwarder,CONCAT((SELECT iwo_code_head FROM tb_opt_prod LIMIT 1),LPAD(cal.id_pre_cal_fgpo,(SELECT iwo_code_digit FROM tb_opt_prod LIMIT 1),'0')) as wo_number
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
LEFT JOIN tb_m_comp c ON c.id_comp=cal.choosen_id_comp
WHERE cal.id_pre_cal_fgpo='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                steps = dt.Rows(0)("step")
                TENumber.Text = dt.Rows(0)("number").ToString
                DEProposeDate.EditValue = dt.Rows(0)("created_date")
                TEProposedBy.EditValue = dt.Rows(0)("employee_name").ToString
                TEPOL.Text = dt.Rows(0)("pol").ToString
                TECBM.EditValue = dt.Rows(0)("cbm")
                TECTN.EditValue = dt.Rows(0)("ctn")
                TEWeight.EditValue = dt.Rows(0)("weight")
                SLEVendorFGPO.EditValue = dt.Rows(0)("id_comp").ToString
                SLETypeImport.EditValue = dt.Rows(0)("id_type").ToString
                TERateManagement.EditValue = dt.Rows(0)("rate_management")
                TERatePayment.EditValue = dt.Rows(0)("rate_current")
                MERemark.Text = dt.Rows(0)("reason").ToString
                TEPPH.EditValue = dt.Rows(0)("pph")
                TEPPN.EditValue = dt.Rows(0)("ppn")
                TEPPH2.EditValue = dt.Rows(0)("pph")
                TEPPN2.EditValue = dt.Rows(0)("ppn")
                '
                TEQuotAmo.EditValue = dt.Rows(0)("quot_amo")
                TEQuotNo.EditValue = dt.Rows(0)("quot_no")
                TEActCBM.EditValue = dt.Rows(0)("act_cbm")
                '
                TEChoosenVendor.Text = dt.Rows(0)("choosen_forwarder").ToString
                TEWO.Text = dt.Rows(0)("wo_number").ToString
                '
                view_but()

                load_list_fgpo()

                load_list_forwarder()

                If steps = 7 Then
                    load_list_orign()
                    load_list_dest()
                    load_list_adm()
                    load_list_chosen()
                    load_duty()
                    load_list_wo()
                ElseIf steps > 3 Then
                    load_list_orign()
                    load_list_dest()
                    load_list_adm()
                    load_list_chosen()
                ElseIf steps > 2 Then
                    load_list_orign()
                End If
                '
                If steps = 1 And Not id = "-1" Then
                    BUpdateDuty.Visible = True
                Else
                    BUpdateDuty.Visible = False
                End If

                If is_view = "1" Then
                    BPrintBudget2.Visible = False
                    BPrintDuty.Visible = False
                    BUpdateDuty.Visible = False
                    '
                    BPrintBudgetBefore.Visible = False
                    BPrintDutyBefore.Visible = False
                End If
            End If
        End If
    End Sub

    Sub load_list_fgpo()
        Dim q As String = "SELECT d.`design_display_name`,d.`design_code`,pcl.id_prod_order,a.prod_order_number,pcl.qty,pcl.id_currency,pcl.price,pcl.duty
FROM `tb_pre_cal_fgpo_list` pcl
INNER JOIN tb_prod_order a ON a.id_prod_order=pcl.id_prod_order 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_m_design d ON b.id_design = d.id_design
WHERE pcl.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListFGPO.DataSource = dt
    End Sub

    Sub load_list_chosen()
        Dim q As String = "SELECT IF(v.id_comp=f.choosen_id_comp,'yes','no') AS is_check,c.id_comp,c.comp_number,c.comp_name,ori.tot_rp AS tot_orign,loc.tot_rp AS tot_loc,adm.tot_rp AS tot_adm,l.tot_qty,ROUND((ori.tot_rp+loc.tot_rp+adm.tot_rp)/l.tot_qty,2) AS unit_cost,(ori.tot_rp+loc.tot_rp+adm.tot_rp) AS tot_in_rp
FROM tb_pre_cal_fgpo_vendor v
INNER JOIN tb_pre_cal_fgpo f ON f.id_pre_cal_fgpo=v.id_pre_cal_fgpo
INNER JOIN tb_m_comp c ON c.id_comp=v.id_comp 
LEFT JOIN
(
	SELECT SUM(total_in_rp) AS tot_rp,id_pre_cal_fgpo,id_comp FROM tb_pre_cal_fgpo_det
	WHERE id_pre_cal_fgpo='" & id & "' AND id_type='1'
	GROUP BY id_pre_cal_fgpo,id_comp
)ori ON ori.id_pre_cal_fgpo=v.`id_pre_cal_fgpo` AND c.`id_comp`=ori.id_comp
LEFT JOIN
(
	SELECT SUM(total_in_rp) AS tot_rp,id_pre_cal_fgpo,id_comp FROM tb_pre_cal_fgpo_det
	WHERE id_pre_cal_fgpo='" & id & "' AND id_type='2'
	GROUP BY id_pre_cal_fgpo,id_comp
)loc ON ori.id_pre_cal_fgpo=v.`id_pre_cal_fgpo` AND c.`id_comp`=loc.id_comp
LEFT JOIN
(
	SELECT SUM(total_in_rp) AS tot_rp,id_pre_cal_fgpo,id_comp FROM tb_pre_cal_fgpo_det
	WHERE id_pre_cal_fgpo='" & id & "' AND id_type='3'
	GROUP BY id_pre_cal_fgpo,id_comp
)adm ON adm.id_pre_cal_fgpo=v.`id_pre_cal_fgpo`  AND c.`id_comp`=adm.id_comp
LEFT JOIN
(
	SELECT SUM(qty) AS tot_qty,id_pre_cal_fgpo FROM tb_pre_cal_fgpo_list
	WHERE id_pre_cal_fgpo='" & id & "' 
)l ON l.id_pre_cal_fgpo=v.`id_pre_cal_fgpo`
WHERE v.id_pre_cal_fgpo='" & id & "'
ORDER BY unit_cost DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPickVendor.DataSource = dt
    End Sub

    Sub load_list_adm()
        Dim q As String = ""

        'q = "SELECT ot.`id_pre_cal_fgpo_other`,ot.desc,ot.`id_currency`,cur.currency,ot.`unit_price`,ot.`kurs`,ot.`unit_price_in_rp`,ot.`qty`
        'FROM `tb_pre_cal_fgpo_other` ot
        'INNER JOIN tb_lookup_currency cur ON cur.id_currency=ot.`id_currency`
        'WHERE ot.`id_pre_cal_fgpo`='" & id & "'"

        q = "SELECT ot.`id_pre_cal_fgpo_det`,ot.id_pre_cal_temp,ot.desc,ot.`id_currency`,cur.currency,ot.`unit_price`,ot.`kurs`,ot.`unit_price_in_rp`,ot.`qty`
        FROM `tb_pre_cal_fgpo_det` ot
        INNER JOIN tb_lookup_currency cur ON cur.id_currency=ot.`id_currency`
        WHERE ot.`id_pre_cal_fgpo`='" & id & "' AND id_comp='" & SLECompOther.EditValue.ToString & "' AND id_type='3'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAdm.DataSource = dt
    End Sub

    Sub load_list_wo()
        Dim q As String = "SELECT d.`design_display_name`,d.`design_code`,pcl.id_prod_order,a.prod_order_number,pcl.qty,pcl.id_currency,pcl.price,pcl.duty
FROM `tb_pre_cal_fgpo_list` pcl
INNER JOIN tb_prod_order a ON a.id_prod_order=pcl.id_prod_order 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_m_design d ON b.id_design = d.id_design
WHERE pcl.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCWOFGPO.DataSource = dt
        GVWOFGPO.BestFitColumns()
    End Sub

    Sub load_list_orign()
        Dim q As String = "SELECT v.id_pre_cal_temp,v.desc,v.unit_price_in_rp,v.qty
FROM `tb_pre_cal_fgpo_det` v
WHERE v.id_pre_cal_fgpo='" & id & "' AND v.id_comp='" & SLEVendorOrign.EditValue.ToString & "' AND v.id_type=1"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCOrign.DataSource = dt
    End Sub

    Sub load_list_dest()
        Dim q As String = "SELECT v.id_pre_cal_temp,v.desc,v.unit_price_in_rp,v.qty
FROM `tb_pre_cal_fgpo_det` v
WHERE v.id_pre_cal_fgpo='" & id & "' AND v.id_comp='" & SLEVendorDest.EditValue.ToString & "' AND v.id_type=2"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDest.DataSource = dt
    End Sub

    Sub load_list_forwarder()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_pre_cal_fgpo_vendor v
INNER JOIN tb_m_comp c ON c.id_comp=v.id_comp 
WHERE v.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCVendor.DataSource = dt

        If steps > 2 Then
            viewSearchLookupQuery(SLEVendorOrign, q, "id_comp", "comp_name", "id_comp")
            viewSearchLookupQuery(SLEVendorDest, q, "id_comp", "comp_name", "id_comp")
            viewSearchLookupQuery(SLECompOther, q, "id_comp", "comp_name", "id_comp")
        End If
    End Sub

    Sub load_vendor()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 1)"
        viewSearchLookupQuery(SLEVendorFGPO, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'LCL' AS type
UNION ALL
SELECT 2 AS id_type,'FCL' AS type
UNION ALL
SELECT 3 AS id_type,'Courier' AS type"
        viewSearchLookupQuery(SLETypeImport, q, "id_type", "type", "id_type")
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If Not GVListFGPO.RowCount = 0 Then
            delete_row(GVListFGPO.FocusedRowHandle)
        End If
    End Sub

    Sub delete_row(ByVal i As Integer)
        GVListFGPO.DeleteRow(i)
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormPopUpProd.id_pop_up = "12"
        FormPopUpProd.id_comp = SLEVendorFGPO.EditValue.ToString
        FormPopUpProd.ShowDialog()
    End Sub

    Private Sub SLE3PLImport_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendorFGPO.EditValueChanged
        If Not GVListFGPO.RowCount = 0 Then
            For i = GVListFGPO.RowCount - 1 To 0 Step -1
                delete_row(i)
            Next
        End If
    End Sub

    Sub view_but()
        If steps = "1" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = False
            XTPOrignCharges.PageVisible = False
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = True
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = False
            '
            PCUFGPO.Visible = True
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = False
            PCUAdm.Visible = False

            PCPickVendor2.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False

            XTC.SelectedTabPageIndex = 0

            If Not id = "-1" Then
                PCUFGPO.Visible = False
                SLEVendorFGPO.Enabled = False
            End If
        ElseIf steps = "2" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = False
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = True
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = False
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = True
            PCPOrign.Visible = False
            PCPDest.Visible = False
            PCUAdm.Visible = False

            PCPickVendor2.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False

            XTC.SelectedTabPageIndex = 1
        ElseIf steps = "3" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = True
            PCDest.Visible = False
            PCAdm.Visible = False
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = True
            PCPDest.Visible = False
            PCUAdm.Visible = False

            PCPickVendor2.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False
            '
            XTC.SelectedTabPageIndex = 2
        ElseIf steps = "4" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = True
            PCAdm.Visible = False
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = True
            PCUAdm.Visible = False

            PCPickVendor2.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False
            '
            XTC.SelectedTabPageIndex = 3
        ElseIf steps = "5" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = True
            XTPChoosen.PageVisible = False
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = True
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = False
            PCUAdm.Visible = True

            PCPickVendor2.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False
            '
            XTC.SelectedTabPageIndex = 4
        ElseIf steps = "6" Then 'pick vendor
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = True
            XTPChoosen.PageVisible = True
            XTPDutyReport.PageVisible = False
            XTPWO.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = False

            PCPickVendor2.Visible = True
            PCPickVendor.Visible = True
            BUpdateReason.Visible = True
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = False
            BLoadCharges.Visible = False
            '
            XTC.SelectedTabPageIndex = 5
        ElseIf steps = "7" Then 'duty
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = True
            XTPChoosen.PageVisible = True
            XTPDutyReport.PageVisible = True
            XTPWO.PageVisible = True
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = False

            PCPickVendor.Visible = False
            PCPickVendor.Visible = False
            BUpdateReason.Visible = False
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = False
            BLoadCharges.Visible = False
            '
            XTC.SelectedTabPageIndex = 6
        End If
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        'check duty first

        If id = "-1" Then
            'new
            If GVListFGPO.RowCount = 0 Then
                warningCustom("Please pick PO")
            ElseIf TECBM.EditValue <= 0 Or TECTN.EditValue <= 0 Or TEWeight.EditValue <= 0 Or TEPOL.Text = "" Then
                warningCustom("Please complete all your input")
            ElseIf TERatePayment.EditValue <= 1 Or TERateManagement.EditValue <= 1 Then
                warningCustom("Kurs not found, please contact Accounting Departement")
            Else
                Dim q As String = "INSERT INTO `tb_pre_cal_fgpo`(created_date,created_by,id_report_status,step,`id_comp`,`id_type`,`weight`,`cbm`,`pol`,`ctn`,`rate_management`,`rate_current`) 
VALUES(NOW(),'" & id_user & "','1','2','" & SLEVendorFGPO.EditValue.ToString & "','" & SLETypeImport.EditValue.ToString & "','" & decimalSQL(Decimal.Parse(TEWeight.EditValue.ToString).ToString) & "','" & decimalSQL(Decimal.Parse(TECBM.EditValue.ToString).ToString) & "','" & addSlashes(TEPOL.Text) & "','" & decimalSQL(Decimal.Parse(TECTN.EditValue.ToString).ToString) & "','" & decimalSQL(Decimal.Parse(TERateManagement.EditValue.ToString).ToString) & "','" & decimalSQL(Decimal.Parse(TERatePayment.EditValue.ToString).ToString) & "');SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number('" & id & "','334')", True, "", "", "", "")

                'detail
                q = "INSERT INTO `tb_pre_cal_fgpo_list`(`id_pre_cal_fgpo`,`id_prod_order`,`id_currency`,`price`,`qty`,`duty`) VALUES"
                For i As Integer = 0 To GVListFGPO.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVListFGPO.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVListFGPO.GetRowCellValue(i, "price").ToString).ToString) & "','" & GVListFGPO.GetRowCellValue(i, "qty").ToString & "','" & decimalSQL(Decimal.Parse(GVListFGPO.GetRowCellValue(i, "duty").ToString).ToString) & "')"
                Next

                execute_non_query(q, True, "", "", "", "")
            End If

            load_head()
        Else
            'edit
            Dim q As String = "UPDATE tb_pre_cal_fgpo SET step=2,`id_type`='" & SLETypeImport.EditValue.ToString & "',`weight`='" & decimalSQL(Decimal.Parse(TEWeight.EditValue.ToString).ToString) & "',`cbm`='" & decimalSQL(Decimal.Parse(TECBM.EditValue.ToString).ToString) & "',`pol`='" & addSlashes(TEPOL.Text) & "',`ctn`='" & decimalSQL(Decimal.Parse(TECTN.EditValue.ToString).ToString) & "' WHERE id_pre_cal_fgpo='" & id & "'"
            execute_non_query(q, True, "", "", "", "")

            'cbm recal
            'orign


            'dest

            'adm

            load_head()
        End If
    End Sub

    Private Sub BAddVendor_Click(sender As Object, e As EventArgs) Handles BAddVendor.Click
        FormPopUpContact.id_pop_up = "94"
        FormPopUpContact.is_must_active = "1"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BDeleteVendor_Click(sender As Object, e As EventArgs) Handles BDeleteVendor.Click
        If GVVendor.RowCount > 0 Then
            Dim q As String = ""
            q = "DELETE FROM tb_pre_cal_fgpo_vendor WHERE id_pre_cal_fgpo='" & id & "' AND id_comp='" & GVVendor.GetFocusedRowCellValue("id_comp").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            q = "DELETE FROM tb_pre_cal_fgpo_det WHERE id_pre_cal_fgpo='" & id & "' AND id_comp='" & GVVendor.GetFocusedRowCellValue("id_comp").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            load_head()
        End If
    End Sub

    Private Sub BPrevVendor_Click(sender As Object, e As EventArgs) Handles BPrevVendor.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='1' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Private Sub BNextVendor_Click(sender As Object, e As EventArgs) Handles BNextVendor.Click
        If GVVendor.RowCount > 1 Then
            execute_non_query("UPDATE tb_pre_cal_fgpo SET step='3' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
            load_head()
        Else
            warningCustom("Pick minimum 2 vendor")
        End If
    End Sub

    Private Sub BAddOrign_Click(sender As Object, e As EventArgs) Handles BAddOrign.Click
        GVOrign.AddNewRow()
        GVOrign.FocusedRowHandle = GVOrign.RowCount - 1

        GVOrign.SetRowCellValue(GVOrign.RowCount - 1, "desc", "Freight")
        GVOrign.SetRowCellValue(GVOrign.RowCount - 1, "qty", TECBM.EditValue)
        GVOrign.SetRowCellValue(GVOrign.RowCount - 1, "unit_price_in_rp", 1.0)
    End Sub

    Private Sub BDelOrign_Click(sender As Object, e As EventArgs) Handles BDelOrign.Click
        If GVOrign.RowCount > 0 Then
            GVOrign.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BPrevOrign_Click(sender As Object, e As EventArgs) Handles BPrevOrign.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='2' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Sub save_orign()
        Cursor = Cursors.WaitCursor
        If GVOrign.RowCount > 0 Then
            Dim q As String = ""
            q = "DELETE FROM tb_pre_cal_fgpo_det WHERE id_pre_cal_fgpo='" & id & "' AND id_comp='" & SLEVendorOrign.EditValue.ToString & "' AND id_type='1'"
            execute_non_query(q, True, "", "", "", "")
            '
            q = "INSERT INTO `tb_pre_cal_fgpo_det`(`id_pre_cal_fgpo`,id_pre_cal_temp,`id_type`,`id_comp`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
            For i = 0 To GVOrign.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id & "','" & GVOrign.GetRowCellValue(i, "id_pre_cal_temp").ToString & "',1,'" & SLEVendorOrign.EditValue.ToString & "','" & addSlashes(GVOrign.GetRowCellValue(i, "desc").ToString) & "','1','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','1','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse((GVOrign.GetRowCellValue(i, "unit_price_in_rp") * GVOrign.GetRowCellValue(i, "qty")).ToString).ToString) & "')"
            Next

            execute_non_query(q, True, "", "", "", "")
        Else
            warningCustom("Please input Orign charges")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BNextOrign_Click(sender As Object, e As EventArgs) Handles BNextOrign.Click
        save_orign()

        'check
        Dim qc As String = "SELECT v.id_comp,SUM(IFNULL(det.total_in_rp,0)) AS tot
FROM `tb_pre_cal_fgpo_vendor` v
LEFT JOIN tb_pre_cal_fgpo_det det ON det.id_pre_cal_fgpo=v.id_pre_cal_fgpo AND v.id_comp=det.id_comp AND det.id_type=1
WHERE v.id_pre_cal_fgpo = '" & id & "' GROUP BY v.id_comp HAVING tot=0"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            warningCustom("Make sure all forwarder vendor have orign charges")
        Else
            execute_non_query("UPDATE tb_pre_cal_fgpo SET step='4' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
            load_head()
        End If
    End Sub

    Private Sub BDraftOrign_Click(sender As Object, e As EventArgs) Handles BDraftOrign.Click
        save_orign()
    End Sub

    Private Sub SLEVendorOrign_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendorOrign.EditValueChanged
        load_list_orign()
    End Sub

    Private Sub BAddDest_Click(sender As Object, e As EventArgs) Handles BAddDest.Click
        GVDest.AddNewRow()
        GVDest.FocusedRowHandle = GVDest.RowCount - 1

        GVDest.SetRowCellValue(GVDest.RowCount - 1, "desc", "")
        GVDest.SetRowCellValue(GVDest.RowCount - 1, "qty", TECBM.EditValue)
        GVDest.SetRowCellValue(GVDest.RowCount - 1, "unit_price_in_rp", 1.0)
    End Sub

    Private Sub BDeldest_Click(sender As Object, e As EventArgs) Handles BDelDest.Click
        If GVDest.RowCount > 0 Then
            GVDest.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BPrevDest_Click(sender As Object, e As EventArgs) Handles BPrevDest.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='3' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Sub save_dest()
        Cursor = Cursors.WaitCursor
        If GVDest.RowCount > 0 Then
            Dim q As String = ""
            q = "DELETE FROM tb_pre_cal_fgpo_det WHERE id_pre_cal_fgpo='" & id & "' AND id_comp='" & SLEVendorDest.EditValue.ToString & "' AND id_type='2'"
            execute_non_query(q, True, "", "", "", "")
            '
            q = "INSERT INTO `tb_pre_cal_fgpo_det`(`id_pre_cal_fgpo`,`id_pre_cal_temp`,`id_type`,`id_comp`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
            For i = 0 To GVDest.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id & "','" & GVDest.GetRowCellValue(i, "id_pre_cal_temp").ToString & "',2,'" & SLEVendorDest.EditValue.ToString & "','" & addSlashes(GVDest.GetRowCellValue(i, "desc").ToString) & "','1','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','1','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse((GVDest.GetRowCellValue(i, "unit_price_in_rp") * GVDest.GetRowCellValue(i, "qty")).ToString).ToString) & "')"
            Next

            execute_non_query(q, True, "", "", "", "")
        Else
            warningCustom("Please input Dest charges")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BNextDest_Click(sender As Object, e As EventArgs) Handles BNextDest.Click
        save_dest()

        'check
        Dim qc As String = "SELECT v.id_comp,SUM(IFNULL(det.total_in_rp,0)) AS tot
FROM `tb_pre_cal_fgpo_vendor` v
LEFT JOIN tb_pre_cal_fgpo_det det ON det.id_pre_cal_fgpo=v.id_pre_cal_fgpo AND v.id_comp=det.id_comp AND det.id_type=2
WHERE v.id_pre_cal_fgpo = '" & id & "'
GROUP BY v.id_comp
HAVING tot=0"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            warningCustom("Make sure all forwarder vendor have dest charges")
        Else
            execute_non_query("UPDATE tb_pre_cal_fgpo SET step='5' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
            load_head()
        End If
    End Sub

    Private Sub BDraftDest_Click(sender As Object, e As EventArgs) Handles BDraftDest.Click
        save_dest()
    End Sub

    Private Sub SLEVendordest_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendorDest.EditValueChanged
        load_list_dest()
    End Sub

    Private Sub BLoadCharges_Click(sender As Object, e As EventArgs) Handles BLoadCharges.Click
        Dim q As String = "SELECT '12' AS id_pre_cal_temp,'Duty' AS `desc`,1 AS `id_currency`,'Rp' AS currency,SUM(duty.duty_amo) AS `unit_price`,duty.rate_management AS `kurs`,SUM(duty.duty_amo) AS `unit_price_in_rp`,1 AS `qty`
FROM
(
	SELECT l.id_pre_cal_fgpo,(l.price*l.qty) AS tot_fob,(l.duty/100) AS duty,fr.tot_freight,h.`rate_management`,l.`qty`,tq.tot_qty,(fr.tot_freight/tq.tot_qty)*l.`qty` AS freight_per_po
	,ROUND((((fr.tot_freight/tq.tot_qty)*l.`qty`)+(l.price*l.qty*h.rate_management))*(l.duty/100),2) AS duty_amo
	FROM `tb_pre_cal_fgpo_list` l
	INNER JOIN tb_pre_cal_fgpo h ON h.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
	INNER JOIN
	(
		SELECT id_pre_cal_fgpo,SUM(d.`total_in_rp`) AS tot_freight
		FROM `tb_pre_cal_fgpo_det` d
		WHERE d.id_comp='" & SLECompOther.EditValue.ToString & "' AND d.`id_type`=1 AND d.id_pre_cal_fgpo='" & id & "'
	)fr ON fr.id_pre_cal_fgpo=l.`id_pre_cal_fgpo`
	INNER JOIN
	(
		SELECT id_pre_cal_fgpo,SUM(qty) AS tot_qty
		FROM `tb_pre_cal_fgpo_list` l
		WHERE l.id_pre_cal_fgpo='" & id & "'
	)tq ON tq.id_pre_cal_fgpo=l.`id_pre_cal_fgpo`
	WHERE l.id_pre_cal_fgpo='" & id & "'
) duty
UNION ALL
SELECT '13' AS id_pre_cal_temp,'KSO' AS `desc`,2 AS `id_currency`,'$' AS currency,get_kso_rate(tq.tot_fob) AS `unit_price`,h.rate_management AS `kurs`,(h.rate_management*get_kso_rate(tq.tot_fob)) AS `unit_price_in_rp`,1 AS `qty`
FROM tb_pre_cal_fgpo h
INNER JOIN
(
	SELECT id_pre_cal_fgpo,SUM(qty) AS tot_qty,SUM(price*qty) AS tot_fob
	FROM `tb_pre_cal_fgpo_list` l
	WHERE l.id_pre_cal_fgpo='" & id & "'
)tq ON tq.id_pre_cal_fgpo=h.`id_pre_cal_fgpo`
WHERE h.id_pre_cal_fgpo='" & id & "'
UNION ALL
SELECT '14' AS id_pre_cal_temp,'Adm Insurance' AS `desc`,2 AS `id_currency`,'$' AS currency,4 AS `unit_price`,h.rate_management AS `kurs`,(h.rate_management*4) AS `unit_price_in_rp`,1 AS `qty`
FROM tb_pre_cal_fgpo h
WHERE h.id_pre_cal_fgpo='" & id & "'
UNION ALL
SELECT '15' AS id_pre_cal_temp,'Insurance Rate' AS `desc`,2 AS `id_currency`,'$' AS currency,ROUND(SUM(l.qty * l.price)*0.00175,2) AS `unit_price`,h.rate_management AS `kurs`,ROUND(SUM(l.qty * l.price)*0.00175 * h.rate_management,2) AS `unit_price_in_rp`,1 AS `qty`
FROM `tb_pre_cal_fgpo_list` l
INNER JOIN tb_pre_cal_fgpo h ON h.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
WHERE h.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCAdm.DataSource = dt
    End Sub

    Sub save_other()
        'Dim q As String = ""
        'q = "DELETE FROM tb_pre_cal_fgpo_other WHERE id_pre_cal_fgpo='" & id & "'"
        'execute_non_query(q, True, "", "", "", "")

        ''`id_pre_cal_fgpo_other`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`
        'q = "INSERT INTO `tb_pre_cal_fgpo_other`(`id_pre_cal_fgpo`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
        'For i = 0 To GVAdm.RowCount - 1
        '    If Not i = 0 Then
        '        q += ","
        '    End If
        '    q += "('" & id & "','" & addSlashes(GVAdm.GetRowCellValue(i, "desc").ToString) & "','" & GVAdm.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "kurs").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "')"
        'Next

        'execute_non_query(q, True, "", "", "", "")

        Dim q As String = ""
        q = "DELETE FROM tb_pre_cal_fgpo_det WHERE id_pre_cal_fgpo='" & id & "' AND id_type=3 AND id_comp='" & SLECompOther.EditValue.ToString & "'"
        execute_non_query(q, True, "", "", "", "")

        '`id_pre_cal_fgpo_other`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`
        q = "INSERT INTO `tb_pre_cal_fgpo_det`(`id_pre_cal_fgpo`,`id_pre_cal_temp`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`,`id_type`,`id_comp`) VALUES"
        For i = 0 To GVAdm.RowCount - 1
            If Not i = 0 Then
                q += ","
            End If
            q += "('" & id & "','" & GVAdm.GetRowCellValue(i, "id_pre_cal_temp").ToString & "','" & addSlashes(GVAdm.GetRowCellValue(i, "desc").ToString) & "','" & GVAdm.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "kurs").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','3','" & SLECompOther.EditValue.ToString & "')"
        Next

        execute_non_query(q, True, "", "", "", "")
    End Sub

    Private Sub BDraftAdm_Click(sender As Object, e As EventArgs) Handles BDraftAdm.Click
        save_other()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVPickVendor.RowCount > 1 Then
            'choose second best
            Dim comp_second_best As String = ""
            If GVPickVendor.FocusedRowHandle = 0 Then
                comp_second_best = GVPickVendor.GetRowCellValue(1, "id_comp").ToString
            Else
                comp_second_best = GVPickVendor.GetRowCellValue(0, "id_comp").ToString
            End If

            Dim q As String = "UPDATE tb_pre_cal_fgpo SET choosen_id_comp='" & GVPickVendor.GetFocusedRowCellValue("id_comp").ToString & "',second_best_comp='" & comp_second_best & "' WHERE id_pre_cal_fgpo='" & id & "'"
            execute_non_query(q, True, "", "", "", "")
        End If
        load_head()
    End Sub

    Private Sub BNext_Click(sender As Object, e As EventArgs) Handles BNext.Click
        If GVAdm.RowCount > 0 Then
            save_other()
            execute_non_query("UPDATE tb_pre_cal_fgpo SET step='6' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
            load_head()
        End If
    End Sub

    Private Sub BPrevAdm_Click(sender As Object, e As EventArgs) Handles BPrevAdm.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='4' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Private Sub BPrevPickVendor_Click(sender As Object, e As EventArgs) Handles BPrevPickVendor.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='5' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Private Sub BPrintBudget_Click(sender As Object, e As EventArgs) Handles BPrintBudgetBefore.Click
        Dim qc As String = "SELECT number,f.reason,FORMAT(SUM(l.`qty`),0,'id_ID') AS qtyf,SUM(l.`qty`) AS qty,FORMAT(SUM(l.`price`*l.`qty`),2,'id_ID') AS fob_tot,c.`comp_name` AS best,cs.`comp_name` AS second_best,FORMAT(f.`cbm`,2,'id_ID') AS cbm,FORMAT(f.`ctn`,0,'id_ID') AS ctn,FORMAT(f.`weight`,0,'id_ID') AS weight,f.`pol`,cv.`comp_name` AS vendor_comp,FORMAT(f.`rate_management`,2,'id_ID') AS rate_management
FROM `tb_pre_cal_fgpo` f
INNER JOIN tb_m_comp cv ON cv.`id_comp`=f.`id_comp`
INNER JOIN tb_pre_cal_fgpo_list l ON l.`id_pre_cal_fgpo`=f.`id_pre_cal_fgpo`
INNER JOIN tb_m_comp c ON c.`id_comp`=f.`choosen_id_comp`
INNER JOIN tb_m_comp cs ON cs.`id_comp`=f.`second_best_comp`
WHERE f.`id_pre_cal_fgpo`='" & id & "'
AND NOT ISNULL(choosen_id_comp)"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print
            Cursor = Cursors.WaitCursor

            ReportPreCalBudget.id_report = id
            Dim Report As New ReportPreCalBudget()
            Report.DataSource = dtc
            Report.qty = dtc.Rows(0)("qty")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        Else
            warningCustom("Please choose vendor first")
        End If
    End Sub

    Private Sub BLoadOrign_Click(sender As Object, e As EventArgs) Handles BLoadOrign.Click
        Dim q As String = "SELECT t.`id_pre_cal_temp`,t.`desc`,0 AS unit_price_in_rp,IF(t.`is_use_cbm`=1,IF(t.`min_cbm`>cal.`cbm`,t.`min_cbm`,cal.`cbm`),1) AS qty
FROM `tb_pre_cal_temp` t
INNER JOIN `tb_pre_cal_fgpo` cal ON  t.`id_type`='1' AND t.`is_active`='1' 
WHERE cal.`id_pre_cal_fgpo`='" & id & "'"
        'cal.`id_type`=t.`vendor_type` AND
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCOrign.DataSource = dt
    End Sub

    Private Sub BLoadDest_Click(sender As Object, e As EventArgs) Handles BLoadDest.Click
        Dim q As String = "SELECT t.`id_pre_cal_temp`,t.`desc`,0 AS unit_price_in_rp,IF(t.`is_use_cbm`=1,IF(t.`min_cbm`>cal.`cbm`,t.`min_cbm`,cal.`cbm`),1) AS qty
FROM `tb_pre_cal_temp` t
INNER JOIN `tb_pre_cal_fgpo` cal ON t.`id_type`='2' AND t.`is_active`='1' AND cal.`id_pre_cal_fgpo`='" & id & "'
UNION ALL
SELECT 11 AS id_pre_cal_temp,'EST STORAGE FEE AND COST PEROUTLAY' AS `desc`, SUM(IF(st.`is_use_cbm`=1,IF(st.`min_cbm`>cal.`cbm`,st.`min_cbm`,CEIL(cal.`cbm`)),1)*st.price) AS unit_price_in_rp,1 AS qty
FROM `tb_pre_cal_storage` st
INNER JOIN `tb_pre_cal_fgpo` cal ON st.`is_active`='1'  AND  cal.`id_pre_cal_fgpo`='" & id & "' AND IF(st.id_type=2,cal.`cbm`<st.cbm_max AND cal.`cbm`>=st.cbm_min,TRUE) "
        'cal.`id_type`=t.`vendor_type` AND
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCDest.DataSource = dt
    End Sub

    Private Sub FormPreCalFGPODet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLECompOther_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompOther.EditValueChanged
        load_list_adm()
    End Sub

    Private Sub BUpdateReason_Click(sender As Object, e As EventArgs) Handles BUpdateReason.Click
        Dim q As String = "UPDATE tb_pre_cal_fgpo SET reason='" & addSlashes(MERemark.Text) & "' WHERE id_pre_cal_fgpo='" & id & "'"
        execute_non_query(q, True, "", "", "", "")
        load_head()
    End Sub

    Private Sub BNextPickVendor_Click(sender As Object, e As EventArgs) Handles BNextPickVendor.Click
        If GVAdm.RowCount > 0 Then
            submit_who_prepared("334", id, id_user)
            execute_non_query("UPDATE tb_pre_cal_fgpo SET step='7' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
            load_head()
        End If
    End Sub

    Private Sub BPrintBudget2_Click(sender As Object, e As EventArgs) Handles BPrintBudget2.Click
        Dim qc As String = "SELECT number,f.reason,FORMAT(SUM(l.`qty`),0,'id_ID') AS qtyf,SUM(l.`qty`) AS qty,FORMAT(SUM(l.`price`*l.`qty`),2,'id_ID') AS fob_tot,c.`comp_name` AS best,cs.`comp_name` AS second_best,FORMAT(f.`cbm`,2,'id_ID') AS cbm,FORMAT(f.`ctn`,0,'id_ID') AS ctn,FORMAT(f.`weight`,0,'id_ID') AS weight,f.`pol`,cv.`comp_name` AS vendor_comp,FORMAT(f.`rate_management`,2,'id_ID') AS rate_management
FROM `tb_pre_cal_fgpo` f
INNER JOIN tb_m_comp cv ON cv.`id_comp`=f.`id_comp`
INNER JOIN tb_pre_cal_fgpo_list l ON l.`id_pre_cal_fgpo`=f.`id_pre_cal_fgpo`
INNER JOIN tb_m_comp c ON c.`id_comp`=f.`choosen_id_comp`
INNER JOIN tb_m_comp cs ON cs.`id_comp`=f.`second_best_comp`
WHERE f.`id_pre_cal_fgpo`='" & id & "'
AND NOT ISNULL(choosen_id_comp)"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print
            Cursor = Cursors.WaitCursor

            ReportPreCalBudget.id_report = id
            Dim Report As New ReportPreCalBudget()
            Report.DataSource = dtc
            Report.qty = dtc.Rows(0)("qty")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        Else
            warningCustom("Please choose vendor first")
        End If
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        Dim q As String = "UPDATE tb_pre_cal_fgpo SET ppn='" & decimalSQL(Decimal.Parse(TEPPN.EditValue.ToString)) & "',pph='" & decimalSQL(Decimal.Parse(TEPPH.EditValue.ToString)) & "' WHERE id_pre_cal_fgpo='" & id & "'"
        execute_non_query(q, True, "", "", "", "")
        load_head()
    End Sub

    Sub print_duty()
        Dim qc As String = "SELECT FORMAT(SUM(bm.tot_fob),4,'ID_id') AS tot_fob,FORMAT(bm.total_freight_po,2,'ID_id') AS tot_freight,FORMAT(bm.tot_qty_royalty,'ID_id') AS tot_qty_royalty
,FORMAT(SUM(bm.tot_royalty),2,'ID_id') AS tot_freight_cost_royalty,FORMAT(SUM(bm.qty),'ID_id') AS tot_qty
,FORMAT(SUM(bm.tot_fob_rp),2,'ID_id') AS tot_fob_rp,FORMAT((SUM(bm.tot_cif)),2,'ID_id') AS tot_cif,FORMAT(SUM(bm.tot_duty),2,'ID_id') AS tot_bm,FORMAT(SUM(bm.tot_cif)+SUM(bm.tot_duty),2,'ID_id') AS tot_cif_bm
,FORMAT(h.ppn,2,'ID_id') AS ppn,FORMAT(ROUND((SUM(bm.tot_cif)+SUM(bm.tot_duty))*(h.ppn/100),2),2,'ID_id') AS tot_ppn
,FORMAT(h.pph,2,'ID_id') AS pph,FORMAT(ROUND((SUM(bm.tot_cif)+SUM(bm.tot_duty))*(h.pph/100),2),2,'ID_id') AS tot_pph
,FORMAT((SUM(bm.tot_duty)) + ROUND((SUM(bm.tot_cif)+SUM(bm.tot_duty))*(h.ppn/100),2) + ROUND((SUM(bm.tot_cif)+SUM(bm.tot_duty))*(h.pph/100),2),2,'ID_id') AS tot_bm_ppn_pph
,ROUND(h.sales_percent) AS sales_percent,ROUND(h.sales_commission) AS sales_commission,ROUND(h.sales_royalty) AS sales_royalty,ROUND(h.sales_ppn) AS sales_ppn
,FORMAT(h.rate_management,2,'ID_id') AS rate_management
,FORMAT(SUM(bm.tot_bm_royalty),2,'ID_id') AS tot_bm_royalty
,FORMAT(SUM(bm.total_ppn_royalty),2,'ID_id') AS tot_ppn_royalty
,FORMAT(SUM(bm.total_pph_royalty),2,'ID_id') AS tot_pph_royalty
,FORMAT(SUM(bm.total_pph_royalty)+SUM(bm.total_ppn_royalty),2,'ID_id') AS tot_ppn_pph_royalty
,c.`comp_name` AS vendor_name,cbest.`comp_name` AS forwarder
,h.`number`
,h.`ctn`,h.`cbm`
FROM `tb_pre_cal_fgpo` h 
INNER JOIN tb_m_comp c ON c.id_comp=h.`id_comp`
INNER JOIN tb_m_comp cbest ON cbest.`id_comp`=h.`choosen_id_comp`
INNER JOIN
(
	SELECT l.duty
	,SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_fob_rp
	,SUM(l.qty) AS qty
	,SUM(l.`price`*l.`qty`) AS tot_fob
	,tot_freight.tot_freight AS total_freight_po
	,tot_fgpo.tot_qty_sales AS tot_qty_royalty
	,SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`) AS tot_freight
	,SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`)+SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_cif
	,(SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`)+SUM((l.`price`*cal.`rate_management`)*l.`qty`))*(l.duty/100) AS tot_duty
	,SUM(ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100)),2)) AS tot_royalty
	,SUM((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.ppn/100)*ROUND(l.`qty`*(cal.`sales_percent`/100))) AS total_ppn_royalty
	,SUM((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.pph/100)*ROUND(l.`qty`*(cal.`sales_percent`/100))) AS total_pph_royalty
	,SUM((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100))) AS tot_bm_royalty
	FROM `tb_pre_cal_fgpo_list` l
	INNER JOIN tb_pre_cal_fgpo cal ON cal.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
	INNER JOIN tb_prod_order po ON po.`id_prod_order`=l.`id_prod_order`
	INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
	INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
	INNER JOIN 
	(
		SELECT SUM(det.`total_in_rp`) AS tot_freight
		FROM tb_pre_cal_fgpo_det det
		INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=det.`id_pre_cal_fgpo` AND f.`choosen_id_comp`=det.`id_comp`
		WHERE det.`id_pre_cal_fgpo`='" & id & "' AND det.id_type=1
	)tot_freight 
	INNER JOIN 
	(
		SELECT SUM(l.`qty`) AS tot_qty,SUM(ROUND(l.`qty`*(f.`sales_percent`/100))) AS tot_qty_sales
		FROM tb_pre_cal_fgpo_list l
		INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`  
		WHERE f.`id_pre_cal_fgpo`='" & id & "'
	)tot_fgpo
	WHERE l.`id_pre_cal_fgpo`='" & id & "'
	GROUP BY l.duty
)bm 
WHERE h.`id_pre_cal_fgpo`='" & id & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print
            Cursor = Cursors.WaitCursor

            Dim Report As New ReportPreCalReport()
            Report.id_report = id
            Report.DataSource = dtc

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        Else
            warningCustom("Please choose vendor first")
        End If
    End Sub

    Private Sub BPrintDuty_Click(sender As Object, e As EventArgs) Handles BPrintDuty.Click
        print_duty()
    End Sub

    Private Sub BUpdateDuty_Click(sender As Object, e As EventArgs) Handles BUpdateDuty.Click
        For i = 0 To GVListFGPO.RowCount - 1
            Dim q As String = "UPDATE tb_pre_cal_fgpo_list SET duty='" & decimalSQL(Decimal.Parse(GVListFGPO.GetRowCellValue(i, "duty").ToString).ToString) & "' WHERE id_pre_cal_fgpo='" & id & "' AND id_prod_order='" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
        Next
        infoCustom("Duty Updated")
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "334"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrintDutyBefore_Click(sender As Object, e As EventArgs) Handles BPrintDutyBefore.Click
        print_duty()
    End Sub

    Private Sub BStorageCalculation_Click(sender As Object, e As EventArgs) Handles BStorageCalculation.Click
        print_storage()
    End Sub

    Sub print_storage()
        Dim qc As String = "SELECT 
h.`number`
FROM `tb_pre_cal_fgpo` h 
WHERE h.`id_pre_cal_fgpo`='" & id & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print
            Cursor = Cursors.WaitCursor

            Dim Report As New ReportPreCalStorage()
            Report.id_report = id
            Report.DataSource = dtc

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        Else
            warningCustom("Please choose vendor first")
        End If
    End Sub

    Private Sub BPrintStorage2_Click(sender As Object, e As EventArgs) Handles BPrintStorage2.Click
        print_storage()
    End Sub

    Private Sub BUpdatePP_Click(sender As Object, e As EventArgs) Handles BUpdatePP.Click
        Dim q As String = "UPDATE tb_pre_cal_fgpo SET ppn='" & decimalSQL(Decimal.Parse(TEPPN2.EditValue.ToString)) & "',pph='" & decimalSQL(Decimal.Parse(TEPPH2.EditValue.ToString)) & "' WHERE id_pre_cal_fgpo='" & id & "'"
        execute_non_query(q, True, "", "", "", "")
        load_head()
    End Sub

    Private Sub GVAdm_KeyDown(sender As Object, e As KeyEventArgs) Handles GVAdm.KeyDown

    End Sub

    Private Sub RepositoryItemTextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles RepositoryItemTextEdit1.KeyDown

    End Sub

    Private Sub RepositoryItemTextEdit1_KeyUp(sender As Object, e As KeyEventArgs) Handles RepositoryItemTextEdit1.KeyUp
        Dim SpQty As DevExpress.XtraEditors.TextEdit = CType(sender, DevExpress.XtraEditors.TextEdit)
        Dim prc As Decimal = SpQty.EditValue
        Dim kurs As Decimal = GVAdm.GetFocusedRowCellValue("kurs")
        Dim amo As Decimal = prc * kurs
        'unit_price_in_rp
        GVAdm.SetFocusedRowCellValue("unit_price_in_rp", amo)
        GCAdm.Refresh()
        GCAdm.RefreshDataSource()
        GVAdm.RefreshData()
    End Sub

    Private Sub RepositoryItemTextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.EditValueChanged

    End Sub

    Private Sub GVAdm_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVAdm.CellValueChanged

    End Sub

    Private Sub BPrintWO_Click(sender As Object, e As EventArgs) Handles BPrintWO.Click
        'print
        Cursor = Cursors.WaitCursor

        Dim Report As New ReportIntShippingWO()
        Report.id_report = id

        Dim q As String = "SELECT cal.reason,cal.ppn,cal.pph,cal.rate_current,cal.rate_management,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
,c.`comp_name` AS fgpo_vendor,cf.comp_name AS forwarder,cal.`quot_no`,cal.`quot_amo`, CONCAT((SELECT iwo_code_head FROM tb_opt_prod LIMIT 1),LPAD(cal.id_pre_cal_fgpo,(SELECT iwo_code_digit FROM tb_opt_prod LIMIT 1),'0')) AS wo_no
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.`id_comp`=cal.`id_comp`
INNER JOIN tb_m_comp cf ON cf.`id_comp`=cal.`choosen_id_comp`
WHERE cal.id_pre_cal_fgpo='" & id & "'"

        Report.DataSource = execute_query(q, -1, True, "", "", "", "")

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub BSaveWO_Click(sender As Object, e As EventArgs) Handles BSaveWO.Click
        If TEQuotNo.Text = "" Or TEQuotAmo.EditValue <= 0 Or TEActCBM.EditValue <= 0 Then
            warningCustom("Please complete your input")
        Else
            Dim q As String = "UPDATE tb_pre_cal_fgpo SET quot_no='" & addSlashes(TEQuotNo.EditValue.ToString) & "',quot_amo='" & decimalSQL(Decimal.Parse(TEQuotAmo.EditValue.ToString)) & "',act_cbm='" & decimalSQL(Decimal.Parse(TECBM.EditValue.ToString)) & "' WHERE id_pre_cal_fgpo='" & id & "'"
            execute_non_query(q, True, "", "", "", "")
            load_head()
        End If
    End Sub
End Class