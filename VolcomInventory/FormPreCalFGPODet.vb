Public Class FormPreCalFGPODet
    Public id As String = "-1"
    Public is_view As String = "-1"

    Dim steps As String = "1"

    Private Sub FormPreCalFGPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
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
        Else
            'edit
            Dim q As String = "SELECT cal.rate_current,cal.rate_management,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
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

                view_but()

                load_list_fgpo()

                load_list_forwarder()

                If steps > 3 Then
                    load_list_orign()
                    load_list_dest()
                    load_list_adm()
                    load_list_chosen()
                ElseIf steps > 2 Then
                    load_list_orign()
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

            XTC.SelectedTabPageIndex = 0
        ElseIf steps = "2" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = False
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
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

            XTC.SelectedTabPageIndex = 1
        ElseIf steps = "3" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
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
            '
            XTC.SelectedTabPageIndex = 2
        ElseIf steps = "4" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = False
            XTPChoosen.PageVisible = False
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
            '
            XTC.SelectedTabPageIndex = 3
        ElseIf steps = "5" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = True
            XTPChoosen.PageVisible = False
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
            '
            XTC.SelectedTabPageIndex = 4
        ElseIf steps = "6" Then 'pick vendor
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = True
            XTPDestCharges.PageVisible = True
            XTPAdmCharges.PageVisible = True
            XTPChoosen.PageVisible = True
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCDest.Visible = False
            PCAdm.Visible = False
            '
            PCUFGPO.Visible = False
            PCUVendor.Visible = False
            PCPOrign.Visible = False
            PCPDest.Visible = False
            BLoadCharges.Visible = False
            '
            XTC.SelectedTabPageIndex = 5
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
	,ROUND((((fr.tot_freight/tq.tot_qty)*l.`qty`)+(l.price*l.qty*h.rate_management))*(l.duty/100)) AS duty_amo
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
SELECT '13' AS id_pre_cal_temp,'KSO' AS `desc`,2 AS `id_currency`,'$' AS currency,315 AS `unit_price`,h.rate_management AS `kurs`,(h.rate_management*315) AS `unit_price_in_rp`,1 AS `qty`
FROM tb_pre_cal_fgpo h
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

    Private Sub BPrintBudget_Click(sender As Object, e As EventArgs) Handles BPrintBudget.Click
        Dim qc As String = "SELECT choosen_id_comp
FROM `tb_pre_cal_fgpo`
WHERE id_pre_cal_fgpo='" & id & "'
AND NOT ISNULL(choosen_id_comp)"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print

        Else
            warningCustom("Please choose vendor first")
        End If
    End Sub

    Private Sub BLoadOrign_Click(sender As Object, e As EventArgs) Handles BLoadOrign.Click
        Dim q As String = "SELECT t.`id_pre_cal_temp`,t.`desc`,0 AS unit_price_in_rp,IF(t.`is_use_cbm`=1,IF(t.`min_cbm`>cal.`cbm`,t.`min_cbm`,cal.`cbm`),1) AS qty
FROM `tb_pre_cal_temp` t
INNER JOIN `tb_pre_cal_fgpo` cal ON cal.`id_type`=t.`vendor_type` AND t.`id_type`='1' AND t.`is_active`='1' 
WHERE cal.`id_pre_cal_fgpo`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCOrign.DataSource = dt
    End Sub

    Private Sub BLoadDest_Click(sender As Object, e As EventArgs) Handles BLoadDest.Click
        Dim q As String = "SELECT t.`id_pre_cal_temp`,t.`desc`,0 AS unit_price_in_rp,IF(t.`is_use_cbm`=1,IF(t.`min_cbm`>cal.`cbm`,t.`min_cbm`,cal.`cbm`),1) AS qty
FROM `tb_pre_cal_temp` t
INNER JOIN `tb_pre_cal_fgpo` cal ON cal.`id_type`=t.`vendor_type` AND t.`id_type`='2' AND t.`is_active`='1' AND cal.`id_pre_cal_fgpo`='" & id & "'
UNION ALL
SELECT 11 AS id_pre_cal_temp,'EST STORAGE FEE AND COST PEROUTLAY' AS `desc`, SUM(IF(st.`is_use_cbm`=1,IF(st.`min_cbm`>cal.`cbm`,st.`min_cbm`,CEIL(cal.`cbm`)),1)*st.price) AS unit_price_in_rp,1 AS qty
FROM `tb_pre_cal_storage` st
INNER JOIN `tb_pre_cal_fgpo` cal ON st.`is_active`='1'  AND  cal.`id_pre_cal_fgpo`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCDest.DataSource = dt
    End Sub

    Private Sub FormPreCalFGPODet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLECompOther_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompOther.EditValueChanged
        load_list_adm()
    End Sub
End Class