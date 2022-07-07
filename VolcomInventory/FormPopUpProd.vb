Public Class FormPopUpProd
    Public id_pop_up As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp As String = "-1"
    ' Dim product_image_path As String = get_setup_field("pic_path_product") & "\"
    '1 = Mat Purchase Receive
    '2 = Mat Return Out
    '3 = PR Purchase Mat
    '5 = Return Mat Prod
    '6 = qc adj in
    '7 = qc adj out
    '8 = return in prod mat
    '10 = pr production
    '11 = Claim return

    Private Sub FormPopUpProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_purc()
        If id_prod_order <> "-1" Then
            GVProd.FocusedRowHandle = find_row(GVProd, "id_prod_order", id_prod_order)
        End If
    End Sub
    Sub view_sample_purc()
        Dim query = "SELECT "
        query += "a.is_block_qc_in,a.is_need_cps2_verify,a.cps2_verify,a.id_prod_order,d.id_sample, d.id_season, a.prod_order_number, (d.design_display_name) AS `design_name` , d.design_code, h.term_production, g.po_type, "
        query += "DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date, "
        query += "DATE_FORMAT(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY),'%d %M %Y') AS prod_order_lead_time, "
        query += "wo.comp_number AS `vendor_code`,wo.id_country, wo.comp_name AS `vendor`,SUM(pod.prod_order_qty) AS qty,IFNULL(wo.id_currency,1) AS id_currency,IFNULL(wo.prod_order_wo_det_price,0) AS price "

        If id_pop_up = "12" Then
            query += ",pcl.qty AS qty_listing,SUM(pod.prod_order_qty)-IFNULL(pcl.qty,0) AS qty_rem "
        End If

        query += "FROM tb_prod_order_det pod
INNER JOIN tb_prod_order a ON a.id_prod_order=pod.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production "
        query += "LEFT JOIN (
    SELECT wo.id_prod_order,wo.id_currency,wod.prod_order_wo_det_price,cm.comp_name,cm.comp_number,cm.id_comp,cou.id_country
    FROM tb_prod_order_wo wo
    INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
    INNER JOIN tb_m_ovh_price ovh ON ovh.id_ovh_price = wo.id_ovh_price
    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovh.id_comp_contact
    INNER JOIN tb_m_comp cm ON cm.id_comp = cc.id_comp
    INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=cm.id_sub_district
    INNER JOIN tb_m_city city ON city.id_city=dis.id_city
    INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
    INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
    INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
    WHERE wo.is_main_vendor=1 AND wo.id_report_status=6
    GROUP BY wo.id_prod_order
) wo ON wo.id_prod_order=a.id_prod_order "

        If id_pop_up = "12" Then
            query += "LEFT JOIN (
    SELECT pcl.`id_prod_order`,SUM(pcl.qty) AS qty
    FROM `tb_pre_cal_fgpo_list` pcl
    INNER JOIN tb_pre_cal_fgpo pc ON pc.`id_pre_cal_fgpo`=pcl.`id_pre_cal_fgpo` AND pc.`id_report_status`!=5
    GROUP BY pcl.id_prod_order
) pcl ON pcl.id_prod_order=a.id_prod_order "
        End If

        query += "WHERE (a.id_report_status = '6') "
        If id_prod_order <> "-1" Then
            query += "AND a.id_prod_order = '" + id_prod_order + "' "
        End If
        If id_pop_up = "4" Then 'PL QC TO WH
            'query += "AND id_prod_demand_design_line_upd_lock='2' "
        End If
        If id_pop_up = "8" Then 'Return MRS
            query += " OR a.id_report_status='5' OR a.id_report_status='6' "
        End If

        If Not id_comp = "-1" Then
            query += " AND wo.id_comp='" & id_comp & "'"
        End If

        query += " GROUP BY a.id_prod_order "

        If id_pop_up = "12" Then
            query += " HAVING qty>IFNULL(qty_listing,0) "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        data.Columns.Add("images", GetType(Image))

        If id_pop_up = "6" Then
            GVListProduct.FocusedRowHandle = find_row(GVListProduct, "id_prod_order", FormProdQCAdjIn.id_prod_order)
        ElseIf id_pop_up = "7" Then
            GVListProduct.FocusedRowHandle = find_row(GVListProduct, "id_prod_order", FormProdQCAdjIn.id_prod_order)
        End If

        GCProd.DataSource = data

        If data.Rows.Count > 0 Then
            'show all
            BSave.Enabled = True
            view_list_purchase(GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_list_purchase(ByVal id_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        GVListProduct.BestFitColumns()
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            If GVProd.GetFocusedRowCellValue("is_block_qc_in").ToString = "1" Then
                'tidak boleh masuk QC
                stopCustom("FGPO dalam status tidak boleh menerima barang ke dalam QC")
            Else
                'If GVProd.GetFocusedRowCellValue("is_need_cps2_verify").ToString = "1" And GVProd.GetFocusedRowCellValue("cps2_verify").ToString = "2" Then
                '    warningCustom("Copy Prototype Sample 2 still not verified. Please contact sample.")
                'Else
                'End If

                'cek KP
                Dim is_ok_kp As Boolean = True

                If GVProd.GetFocusedRowCellValue("id_country").ToString = "5" Then
                    Dim qc As String = "SELECT kd.* FROM tb_prod_order_kp_det kd
INNER JOIN tb_prod_order_kp k ON k.id_prod_order_kp=kd.id_prod_order_kp AND k.is_locked=1 AND k.is_void=2
WHERE kd.id_prod_order='" & GVProd.GetFocusedRowCellValue("id_prod_order").ToString & "'"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        is_ok_kp = True
                    Else
                        is_ok_kp = False
                        warningCustom("SKP belum diapprove, mohon hubungi purchasing.")
                    End If
                End If

                If is_ok_kp Then
                    Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    Dim date_created As String = ""

                    If data.Rows.Count > 0 Then
                        FormProductionRecDet.id_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                        FormProductionRecDet.TEPONumber.Text = data.Rows(0)("prod_order_number").ToString

                        date_created = data.Rows(0)("prod_order_datex").ToString
                        FormProductionRecDet.TEOrderDate.Text = view_date_from(date_created, 0)
                        FormProductionRecDet.TEEstRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("prod_order_lead_time").ToString))

                        FormProductionRecDet.GConListPurchase.Enabled = True
                        FormProductionRecDet.GroupControlListBarcode.Enabled = True
                        FormProductionRecDet.view_list_purchase()
                        FormProductionRecDet.view_barcode_list()


                        FormProductionRecDet.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                        FormProductionRecDet.TEDesign.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                        FormProductionRecDet.TxtPOType.Text = GVProd.GetFocusedRowCellValue("po_type").ToString
                        FormProductionRecDet.id_comp_from = "-1"
                        FormProductionRecDet.TECompName.Text = ""
                        pre_viewImages("2", FormProductionRecDet.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                        FormProductionRecDet.PEView.Enabled = True
                        FormProductionRecDet.BtnInfoSrs.Enabled = True
                        FormProductionRecDet.mainVendor()
                        FormProductionRecDet.SLERecType.ReadOnly = True
                        Close()
                    Else
                        stopCustom("Data is empty.")
                    End If
                End If
            End If
        ElseIf id_pop_up = "2" Then
            Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormProductionRetOutSingle.TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                FormProductionRetOutSingle.GroupControlRet.Enabled = True
                FormProductionRetOutSingle.GroupControlListBarcode.Enabled = True
                FormProductionRetOutSingle.id_prod_order_det_list.Clear()
                FormProductionRetOutSingle.BtnInfoSrs.Enabled = True

                'updated 21 Desember 2015
                FormProductionRetOutSingle.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionRetOutSingle.PEView.Enabled = True
                pre_viewImages("2", FormProductionRetOutSingle.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionRetOutSingle.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionRetOutSingle.TxtDesign.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                FormProductionRetOutSingle.TxtSeason.Text = GVProd.GetFocusedRowCellValue("season").ToString
                FormProductionRetOutSingle.mainVendor()

                'FormProductionRetOutSingle
                FormProductionRetOutSingle.viewDetailReturn()
                FormProductionRetOutSingle.view_barcode_list()
                FormProductionRetOutSingle.check_but()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "3" Then
            FormProductionRetInSingle.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString

            Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormProductionRetInSingle.TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                FormProductionRetInSingle.GroupControlRet.Enabled = True
                FormProductionRetInSingle.GroupControlListBarcode.Enabled = True
                FormProductionRetInSingle.viewDetailReturn()
                FormProductionRetInSingle.view_barcode_list()
                FormProductionRetInSingle.deleteRows()
                FormProductionRetInSingle.id_prod_order_det_list.Clear()
                FormProductionRetInSingle.check_but()
                FormProductionRetInSingle.BtnInfoSrs.Enabled = True

                FormProductionRetInSingle.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionRetInSingle.TEDesign.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                FormProductionRetInSingle.TxtSeason.Text = GVProd.GetFocusedRowCellValue("season").ToString
                pre_viewImages("2", FormProductionRetInSingle.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionRetInSingle.mainVendor()
                FormProductionRetInSingle.PEView.Enabled = True
                FormProductionRetInSingle.viewDetailReturn()
                FormProductionRetInSingle.view_barcode_list()
                FormProductionRetInSingle.check_but()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "4" Then
            FormProductionPLToWHDet.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString

            Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormProductionPLToWHDet.TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                'FormProductionPLToWHDet.id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                'FormProductionPLToWHDet.TxtNameCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
                'FormProductionPLToWHDet.TxtCodeCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "2")
                'FormProductionPLToWHDet.MEAdrressCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")
                FormProductionPLToWHDet.GroupControlRet.Enabled = True
                FormProductionPLToWHDet.GroupControlListBarcode.Enabled = True

                FormProductionPLToWHDet.id_prod_order_det_list.Clear()
                FormProductionPLToWHDet.dt.Clear()

                FormProductionPLToWHDet.viewDetail()
                FormProductionPLToWHDet.view_barcode_list()
                'FormProductionPLToWHDet.view_list_po(GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString)
                FormProductionPLToWHDet.check_but()
                FormProductionPLToWHDet.BtnInfoSrs.Enabled = True
                FormProductionPLToWHDet.BtnViewLineList.Enabled = True

                FormProductionPLToWHDet.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionPLToWHDet.id_season = GVProd.GetFocusedRowCellValue("id_season").ToString
                FormProductionPLToWHDet.TEDesign.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                pre_viewImages("2", FormProductionPLToWHDet.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionPLToWHDet.PEView.Enabled = True
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "5" Then 'return mat production
            FormMatRetInProd.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString

            Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormMatRetInProd.TEPONumber.Text = data.Rows(0)("prod_order_number").ToString

                FormProductionRetInSingle.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionRetInSingle.TEDesign.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                pre_viewImages("2", FormProductionRetInSingle.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionRetInSingle.PEView.Enabled = True
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "6" Then 'adj in qc
            If Not FormProdQCAdjIn.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString Then
                FormProdQCAdjIn.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString
                FormProdQCAdjIn.TEProdOrderNumber.Text = GVProd.GetFocusedRowCellDisplayText("prod_order_number").ToString
                FormProdQCAdjIn.empty_grid()
                For i As Integer = 0 To GVListProduct.RowCount - 1
                    FormProdQCAdjIn.GVDetail.AddNewRow()
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetRowCellValue(i, "id_prod_order_det").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("code", GVListProduct.GetRowCellValue(i, "code").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("description", GVListProduct.GetRowCellValue(i, "name").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("size", GVListProduct.GetRowCellValue(i, "size").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("color", GVListProduct.GetRowCellValue(i, "color").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("cost", GVListProduct.GetRowCellValue(i, "estimate_cost").ToString)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("qty", 0)
                    FormProdQCAdjIn.GVDetail.SetFocusedRowCellValue("amount", 0.0)
                    FormProdQCAdjIn.GVDetail.CloseEditor()
                Next
                FormProdQCAdjIn.calculate()
            End If
            Close()
        ElseIf id_pop_up = "7" Then 'adj out qc
            If Not FormProdQCAdjOut.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString Then
                FormProdQCAdjOut.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString
                FormProdQCAdjOut.TEProdOrderNumber.Text = GVProd.GetFocusedRowCellDisplayText("prod_order_number").ToString
                FormProdQCAdjOut.empty_grid()
                For i As Integer = 0 To GVListProduct.RowCount - 1
                    FormProdQCAdjOut.GVDetail.AddNewRow()
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("id_prod_order_det", GVListProduct.GetRowCellValue(i, "id_prod_order_det").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("code", GVListProduct.GetRowCellValue(i, "code").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("description", GVListProduct.GetRowCellValue(i, "name").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("size", GVListProduct.GetRowCellValue(i, "size").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("color", GVListProduct.GetRowCellValue(i, "color").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("cost", GVListProduct.GetRowCellValue(i, "estimate_cost").ToString)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("qty", 0)
                    FormProdQCAdjOut.GVDetail.SetFocusedRowCellValue("amount", 0.0)
                    FormProdQCAdjOut.GVDetail.CloseEditor()
                Next
                FormProdQCAdjOut.calculate()
            End If
            Close()
        ElseIf id_pop_up = "8" Then 'ret in prod material
            If GVProd.RowCount > 0 Then
                FormMatRetInProd.id_prod_order = GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString
                FormMatRetInProd.TEPONumber.Text = GVProd.GetFocusedRowCellDisplayText("prod_order_number").ToString
                FormMatRetInProd.TEDesign.Text = GVProd.GetFocusedRowCellDisplayText("design_name").ToString
                FormMatRetInProd.TEDesignCode.Text = GVProd.GetFocusedRowCellDisplayText("design_code").ToString

                'FormMatRetInProd.id_comp_contact_from = GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString
                'FormMatRetInProd.TxtNameCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "1")
                'FormMatRetInProd.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
                'FormMatRetInProd.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVProdWO.GetFocusedRowCellValue("id_comp_contact").ToString), "3")
                'FormMatRetInProd.TEPONumber.Text = GVProdWO.GetFocusedRowCellValue("prod_order_number").ToString
                'FormMatRetInProd.TEDesign.Text = GVProdWO.GetFocusedRowCellValue("design_name").ToString

                FormMatRetInProd.GroupControlRet.Enabled = True
                FormMatRetInProd.viewDetailReturnExt("-1")
                FormMatRetInProd.check_but()
                Close()
            Else
                warningCustom("No data selected.")
            End If
        ElseIf id_pop_up = "9" Then
            If GVProd.RowCount > 0 Then
                FormProductionFinalClearDet.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionFinalClearDet.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionFinalClearDet.TxtOrder.Text = GVProd.GetFocusedRowCellValue("prod_order_number").ToString
                FormProductionFinalClearDet.TxtSeason.Text = GVProd.GetFocusedRowCellValue("season").ToString
                FormProductionFinalClearDet.TxtDel.Text = GVProd.GetFocusedRowCellValue("delivery").ToString
                FormProductionFinalClearDet.TxtVendorCode.Text = GVProd.GetFocusedRowCellValue("vendor_code").ToString
                FormProductionFinalClearDet.TxtVendorName.Text = GVProd.GetFocusedRowCellValue("vendor").ToString
                FormProductionFinalClearDet.TxtStyleCode.Text = GVProd.GetFocusedRowCellValue("design_code").ToString
                FormProductionFinalClearDet.TxtStyle.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                FormProductionFinalClearDet.viewDetail()
                pre_viewImages("2", FormProductionFinalClearDet.PEView, FormProductionFinalClearDet.id_design, False)
                Close()
            Else
                warningCustom("No data selected.")
            End If
        ElseIf id_pop_up = "10" Then
            If GVProd.RowCount > 0 Then
                FormProdPRWODet.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormProdPRWODet.TEWOPONumber.Text = GVProd.GetFocusedRowCellDisplayText("prod_order_number").ToString
                FormProdPRWODet.view_list_po()

                FormProdPRWODet.GConListPurchase.Enabled = True
                Close()
            Else
                warningCustom("No data selected.")
            End If
        ElseIf id_pop_up = "11" Then
            If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then
                Dim id_prod_order As String = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                Dim id_design As String = GVProd.GetFocusedRowCellValue("id_design").ToString
                Dim qw As String = "SELECT c.id_comp, cc.id_comp_contact, c.comp_number, c.comp_name, po.id_prod_order, po.prod_order_number 
                FROM tb_prod_order_wo wo
                INNER JOIN tb_prod_order po ON po.id_prod_order = wo.id_prod_order
                INNER JOIN tb_m_ovh_price o ON o.id_ovh_price = wo.id_ovh_price
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = o.id_comp_contact
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE wo.id_report_status!=5 AND wo.is_main_vendor=1 AND wo.id_prod_order=" + id_prod_order + " "
                Dim dw As DataTable = execute_query(qw, -1, True, "", "", "", "")
                If dw.Rows.Count > 0 Then
                    FormProductionClaimReturnDet.id_prod_order = id_prod_order
                    FormProductionClaimReturnDet.id_comp_contact = dw.Rows(0)("id_comp_contact").ToString
                    FormProductionClaimReturnDet.id_design = id_design
                    FormProductionClaimReturnDet.TxtVendor.Text = dw.Rows(0)("comp_number").ToString + " - " + dw.Rows(0)("comp_name").ToString
                    FormProductionClaimReturnDet.TxtOrderNumber.Text = GVProd.GetFocusedRowCellValue("prod_order_number").ToString
                    FormProductionClaimReturnDet.TxtDesignCode.Text = GVProd.GetFocusedRowCellValue("design_code").ToString
                    FormProductionClaimReturnDet.TxtDesignName.Text = GVProd.GetFocusedRowCellValue("design_name").ToString
                    pre_viewImages("2", FormProductionClaimReturnDet.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                    FormProductionClaimReturnDet.viewDetail()
                    Close()
                Else
                    warningCustom("Vendor not found")
                End If
            Else
                warningCustom("No data selected.")
            End If
        ElseIf id_pop_up = "12" Then
            'pre cal
            If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then
                Dim is_already As Boolean = False
                For i = 0 To FormPreCalFGPODet.GVListFGPO.RowCount - 1
                    If FormPreCalFGPODet.GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString = GVProd.GetFocusedRowCellValue("id_prod_order").ToString Then
                        is_already = True
                        Exit For
                    End If
                Next
                'check
                If is_already Then
                    warningCustom("PO sudah dipilih")
                Else
                    FormPreCalFGPODet.GVListFGPO.AddNewRow()
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("id_prod_order", GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("prod_order_number", GVProd.GetFocusedRowCellValue("prod_order_number").ToString)
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("design_display_name", GVProd.GetFocusedRowCellValue("design_name").ToString)
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("design_code", GVProd.GetFocusedRowCellValue("design_code").ToString)
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("id_currency", GVProd.GetFocusedRowCellValue("id_currency").ToString)
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("price", GVProd.GetFocusedRowCellValue("price"))
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("qty", GVProd.GetFocusedRowCellValue("qty_rem"))
                    FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("duty", 10)
                    FormPreCalFGPODet.GVListFGPO.RefreshData()
                    FormPreCalFGPODet.GVListFGPO.UpdateTotalSummary()
                    FormPreCalFGPODet.GCListFGPO.Refresh()
                End If

            Else
                warningCustom("No data selected.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpProd_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If

        If GVProd.RowCount > 0 Then
            view_list_purchase(GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
        End If
    End Sub
    Private Sub GVProd_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProd.RowClick

    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProd.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub
End Class