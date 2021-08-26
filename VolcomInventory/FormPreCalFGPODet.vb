Public Class FormPreCalFGPODet
    Public id As String = "-1"
    Public is_view As String = "-1"

    Dim steps As String = "1"

    Private Sub FormPreCalFGPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        load_type()
        load_vendor()

        If id = "-1" Then
            'new
            load_list_fgpo()
        Else
            'edit
            Dim q As String = "SELECT cal.duty_percent,cal.commission,cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
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

                TEDutyPercent.EditValue = dt.Rows(0)("duty_percent")
                TECommision.EditValue = dt.Rows(0)("commission")

                view_but()

                load_list_fgpo()
                load_list_forwarder()

                If steps > 2 Then
                    load_list_orign()
                ElseIf steps > 3 Then
                    load_list_orign()
                    load_list_dest()
                    load_list_adm()
                End If
            End If
        End If
    End Sub

    Sub load_list_fgpo()
        Dim q As String = "SELECT d.`design_display_name`,d.`design_code`,pcl.id_prod_order,a.prod_order_number,pcl.qty,pcl.id_currency,pcl.price
FROM `tb_pre_cal_fgpo_list` pcl
INNER JOIN tb_prod_order a ON a.id_prod_order=pcl.id_prod_order 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_m_design d ON b.id_design = d.id_design
WHERE pcl.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListFGPO.DataSource = dt
    End Sub

    Sub load_list_chosen()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_pre_cal_fgpo_vendor v
INNER JOIN tb_m_comp c ON c.id_comp=v.id_comp 
WHERE v.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPickVendor.DataSource = dt
    End Sub

    Sub load_list_adm()
        Dim q As String = "SELECT ot.`id_pre_cal_fgpo_other`,ot.desc,ot.`id_currency`,cur.currency,ot.`unit_price`,ot.`kurs`,ot.`unit_price_in_rp`,ot.`qty`
FROM `tb_pre_cal_fgpo_other` ot
INNER JOIN tb_lookup_currency cur ON cur.id_currency=ot.`id_currency`
WHERE ot.`id_pre_cal_fgpo`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAdm.DataSource = dt
    End Sub

    Sub load_list_orign()
        Dim q As String = "SELECT v.desc,v.unit_price_in_rp,v.qty
FROM `tb_pre_cal_fgpo_det` v
WHERE v.id_pre_cal_fgpo='" & id & "' AND v.id_comp='" & SLEVendorOrign.EditValue.ToString & "' AND v.id_type=1"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCOrign.DataSource = dt
    End Sub

    Sub load_list_dest()
        Dim q As String = "SELECT v.desc,v.unit_price_in_rp,v.qty
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
        viewSearchLookupQuery(SLEVendorOrign, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLEVendorDest, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_vendor()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 1)"
        viewSearchLookupQuery(SLEVendorFGPO, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'LCL' AS type
UNION ALL
SELECT 2 AS id_type,'FCL' AS type"
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
            PCUAdm.Visible = False
            '
            XTC.SelectedTabPageIndex = 4
        End If
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        If id = "-1" Then
            'new
            If GVListFGPO.RowCount = 0 Then
                warningCustom("Please pick PO")
            ElseIf TECBM.EditValue <= 0 Or TECTN.EditValue <= 0 Or TEWeight.EditValue <= 0 Or TEPOL.Text = "" Then
                warningCustom("Please complete all your input")
            Else
                Dim q As String = "INSERT INTO `tb_pre_cal_fgpo`(created_date,created_by,id_report_status,step,`id_comp`,`id_type`,`weight`,`cbm`,`pol`,`ctn`) 
VALUES(NOW(),'" & id_user & "','1','2','" & SLEVendorFGPO.EditValue.ToString & "','" & SLETypeImport.EditValue.ToString & "','" & decimalSQL(Decimal.Parse(TEWeight.EditValue.ToString).ToString) & "','" & decimalSQL(Decimal.Parse(TECBM.EditValue.ToString).ToString) & "','" & addSlashes(TEPOL.Text) & "','" & decimalSQL(Decimal.Parse(TECTN.EditValue.ToString).ToString) & "');SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number('" & id & "','334')", True, "", "", "", "")

                'detail
                q = "INSERT INTO `tb_pre_cal_fgpo_list`(`id_pre_cal_fgpo`,`id_prod_order`,`id_currency`,`price`,`qty`) VALUES"
                For i As Integer = 0 To GVListFGPO.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVListFGPO.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString).ToString) & "','" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "')"
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
            q = "INSERT INTO `tb_pre_cal_fgpo_det`(`id_pre_cal_fgpo`,`id_type`,`id_comp`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
            For i = 0 To GVOrign.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id & "',1,'" & SLEVendorOrign.EditValue.ToString & "','" & addSlashes(GVOrign.GetRowCellValue(i, "desc").ToString) & "','1','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','1','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVOrign.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse((GVOrign.GetRowCellValue(i, "unit_price_in_rp") * GVOrign.GetRowCellValue(i, "qty")).ToString).ToString) & "')"
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
WHERE v.id_pre_cal_fgpo = '" & id & "'
GROUP BY v.id_comp
HAVING tot=0"
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
            q = "INSERT INTO `tb_pre_cal_fgpo_det`(`id_pre_cal_fgpo`,`id_type`,`id_comp`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
            For i = 0 To GVDest.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id & "',2,'" & SLEVendorDest.EditValue.ToString & "','" & addSlashes(GVDest.GetRowCellValue(i, "desc").ToString) & "','1','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','1','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDest.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse((GVDest.GetRowCellValue(i, "unit_price_in_rp") * GVDest.GetRowCellValue(i, "qty")).ToString).ToString) & "')"
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
        TEDutyPercent.EditValue = 10
        TECommision.EditValue = 6

        Dim q As String = "SELECT '' AS `id_pre_cal_fgpo_other`,ot.desc,ot.`id_currency`,cur.currency,ot.amo AS `unit_price`,(SELECT kurs_trans+fixed_floating FROM tb_kurs_trans WHERE id_kurs_trans = (SELECT MAX(id_kurs_trans) FROM `tb_kurs_trans`)) AS `kurs`
,(SELECT unit_price) * (SELECT kurs) AS `unit_price_in_rp`,1 AS `qty`
FROM `tb_lookup_adm_precal` ot
INNER JOIN tb_lookup_currency cur ON cur.id_currency=ot.`id_currency`
WHERE ot.`is_active`='1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        GCAdm.DataSource = dt
    End Sub

    Sub save_other()
        Dim q As String = ""
        q = "UPDATE tb_pre_cal_fgpo SET duty_percent='" & decimalSQL(Decimal.Parse(TEDutyPercent.EditValue.ToString)) & "',commission='" & decimalSQL(Decimal.Parse(TECommision.EditValue.ToString)) & "' WHERE id_pre_cal_fgpo='" & id & "'"
        execute_non_query(q, True, "", "", "", "")
        '
        q = "DELETE FROM tb_pre_cal_fgpo_other WHERE id_pre_cal_fgpo='" & id & "'"
        execute_non_query(q, True, "", "", "", "")
        '`id_pre_cal_fgpo_other`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`
        q = "INSERT INTO `tb_pre_cal_fgpo_other`(`id_pre_cal_fgpo`,`desc`,`id_currency`,`unit_price`,`kurs`,`unit_price_in_rp`,`qty`,`total_in_rp`) VALUES"
        For i = 0 To GVAdm.RowCount - 1
            If Not i = 0 Then
                q += ","
            End If
            q += "('" & id & "','" & addSlashes(GVAdm.GetRowCellValue(i, "desc").ToString) & "','" & GVAdm.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "kurs").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVAdm.GetRowCellValue(i, "unit_price_in_rp").ToString).ToString) & "')"
        Next

        execute_non_query(q, True, "", "", "", "")
    End Sub

    Private Sub BDraftAdm_Click(sender As Object, e As EventArgs) Handles BDraftAdm.Click
        save_other()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVPickVendor.RowCount > 0 Then
            Dim q As String = "UPDATE tb_pre_cal_fgpo SET choosen_id_comp='" & GVPickVendor.GetFocusedRowCellValue("id_comp").ToString & "' WHERE id_pre_cal_fgpo='" & id & "'"
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
End Class