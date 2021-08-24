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
            Dim q As String = "SELECT cal.`number`,cal.`id_comp`,cal.`id_type`,cal.`weight`,cal.`cbm`,cal.`pol`,cal.`ctn`,cal.`created_date`,cal.`step`,emp.`employee_name`
FROM
`tb_pre_cal_fgpo` cal
INNER JOIN tb_m_user usr ON usr.`id_user`=cal.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE cal.id_pre_cal_fgpo='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                steps = dt.Rows(0)("step").ToString
            End If

            TENumber.Text = dt.Rows(0)("number").ToString
            DEProposeDate.EditValue = dt.Rows(0)("created_date")
            TEProposedBy.EditValue = dt.Rows(0)("employee_name").ToString
            TEPOL.Text = dt.Rows(0)("pol").ToString
            TECBM.EditValue = dt.Rows(0)("cbm")
            TECTN.EditValue = dt.Rows(0)("ctn")
            TEWeight.EditValue = dt.Rows(0)("weight")
            SLEVendorFGPO.EditValue = dt.Rows(0)("id_comp").ToString
            SLETypeImport.EditValue = dt.Rows(0)("id_type").ToString

            view_but()

            load_list_fgpo()
            load_list_forwarder()
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

    Sub load_list_forwarder()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_pre_cal_fgpo_vendor v
INNER JOIN tb_m_comp c ON c.id_comp=v.id_comp 
WHERE v.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCVendor.DataSource = dt
        viewSearchLookupQuery(SLEVendorOrign, q, "id_comp", "comp_name", "id_comp")
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
            XTPFreightCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            '
            PCFGPOList.Visible = True
            PCVendor.Visible = False
            PCOrign.Visible = False
            PCFreight.Visible = False
            PCAdm.Visible = False
        ElseIf steps = "2" Then
            XTPFGPO.PageVisible = True
            XTPVendor.PageVisible = True
            XTPOrignCharges.PageVisible = False
            XTPFreightCharges.PageVisible = False
            XTPAdmCharges.PageVisible = False
            '
            PCFGPOList.Visible = False
            PCVendor.Visible = True
            PCOrign.Visible = False
            PCFreight.Visible = False
            PCAdm.Visible = False
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
            Dim q As String = "DELETE FROM tb_pre_cal_fgpo_vendor WHERE id_pre_cal_fgpo='' AND id_comp='" & GVVendor.GetFocusedRowCellValue("id_comp").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            load_list_forwarder()
        End If
    End Sub

    Private Sub BPrevVendor_Click(sender As Object, e As EventArgs) Handles BPrevVendor.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='1' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub

    Private Sub BNextVendor_Click(sender As Object, e As EventArgs) Handles BNextVendor.Click
        execute_non_query("UPDATE tb_pre_cal_fgpo SET step='3' WHERE id_pre_cal_fgpo='" & id & "'", True, "", "", "", "")
        load_head()
    End Sub
End Class