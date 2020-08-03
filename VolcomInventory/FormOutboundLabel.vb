Public Class FormOutboundLabel
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_from_do()
    End Sub

    Sub load_from_do()
        Dim q_where As String = ""

        If Not SLEComp.EditValue.ToString = "0" Then
            q_where += " AND c.id_comp='" + addSlashes(SLEComp.EditValue.ToString) + "'"
        End If

        Dim query As String = "SELECT 'yes' AS is_check,d.id_pl_sales_order_del, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,c.id_sub_district,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'no' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill = awb.id_awbill
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE d.`id_report_status`=1 AND so.is_export_awb=2  AND ISNULL(awbh.id_awbill) " & q_where & "
GROUP BY d.id_pl_sales_order_del 
ORDER BY d.id_pl_sales_order_del DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GVDOERP.ActiveFilterString = ""
        GCDOERP.DataSource = data
        GVDOERP.BestFitColumns()
        '
        If data.Rows.Count > 0 Then
            SLESubDistrict.EditValue = data.Rows(0)("id_sub_district").ToString
        End If
    End Sub

    Private Sub FormOutboundLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCreateOutboundLabel_Click(sender As Object, e As EventArgs) Handles BCreateOutboundLabel.Click
        'create outbound label
        GVDOERP.ActiveFilterString = "[is_check]='yes'"
        If GVDOERP.RowCount > 0 Then
            'check if already generated
            Dim id As String = ""
            For i = 0 To GVDOERP.RowCount - 1
                If Not i = 0 Then
                    id += ","
                End If
                id += "'" & GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString & "'"
            Next
            '
            Dim query_check As String = "SELECT * FROM tb_wh_awbill_det awbd
INNER JOIN tb_wh_awbill awb ON awbd.`id_awbill`=awb.`id_awbill` AND awb.`id_report_status` != 5 
WHERE awbd.`id_pl_sales_order_del` IN (" & id & ") "
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count > 0 Then
                Dim number_already_generated As String = ""
                For i = 0 To data_check.Rows.Count - 1
                    If Not i = 0 Then
                        number_already_generated += ","
                    End If
                    number_already_generated += "'" & data_check.Rows(i)("prod_order_number").ToString & "'"
                Next
                warningCustom("Delivery with number : " & number_already_generated & " already process.")
            Else
                'outbound label generate
                Dim query As String = ""
                Dim id_awb As String = ""
                '
                query = "INSERT INTO tb_wh_awbill(id_sub_district,awbill_type,awbill_date,id_store,is_old_ways)"
                query += " VALUES('" + SLESubDistrict.EditValue.ToString + "','1',NOW(),'" + SLEComp.EditValue.ToString + "','2'); SELECT LAST_INSERT_ID(); "

                id_awb = execute_query(query, 0, True, "", "", "", "")

                query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"
                For i As Integer = 0 To GVDOERP.RowCount - 1
                    Dim id_pl_sales_order_del As String = "NULL"
                    Dim id_ol_store_cust_ret As String = "NULL"
                    Try
                        id_pl_sales_order_del = GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        id_ol_store_cust_ret = GVDOERP.GetRowCellValue(i, "id_ol_store_cust_ret").ToString
                    Catch ex As Exception
                    End Try
                    If id_pl_sales_order_del = "" Then
                        id_pl_sales_order_del = "NULL"
                    End If
                    If id_ol_store_cust_ret = "" Then
                        id_ol_store_cust_ret = "NULL"
                    End If

                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" + id_awb + "'," + id_pl_sales_order_del + "," + id_ol_store_cust_ret + ",'" + GVDOERP.GetRowCellValue(i, "do_no").ToString + "','" + GVDOERP.GetRowCellValue(i, "qty").ToString + "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                '===================== PRINT HERE =====================


                warningCustom("Outbound Number " & id_awb & " created")
                load_from_do()
            End If
        Else
            warningCustom("Please choose DO")
        End If
        GVDOERP.ActiveFilterString = ""
    End Sub

    Private Sub FormOutboundLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp()
        view_comp_group()
        load_sub_dsitrict()
    End Sub

    Sub load_sub_dsitrict()
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country`"
        viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Sub load_sub_dsitrictOnline()
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country`"
        viewSearchLookupQuery(SLESubDistrictOnline, q, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Sub view_comp()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_m_comp c
WHERE c.id_commerce_type='1' AND c.id_comp_cat='6' AND is_active='1'"
        viewSearchLookupQuery(SLEComp, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BCreateOutboundOnline_Click(sender As Object, e As EventArgs) Handles BCreateOutboundOnline.Click
        If GVDOOnline.RowCount > 0 Then
            'check if already generated
            Dim id As String = ""
            For i = 0 To GVDOOnline.RowCount - 1
                If Not i = 0 Then
                    id += ","
                End If
                id += "'" & GVDOOnline.GetRowCellValue(i, "id_pl_sales_order_del").ToString & "'"
            Next
            '
            Dim query_check As String = "SELECT * FROM tb_wh_awbill_det awbd
INNER JOIN tb_wh_awbill awb ON awbd.`id_awbill`=awb.`id_awbill` AND awb.`id_report_status` != 5 
WHERE awbd.`id_pl_sales_order_del` IN (" & id & ") "
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count > 0 Then
                Dim number_already_generated As String = ""
                For i = 0 To data_check.Rows.Count - 1
                    If Not i = 0 Then
                        number_already_generated += ","
                    End If
                    number_already_generated += "'" & data_check.Rows(i)("do_no").ToString & "'"
                Next
                warningCustom("Delivery with number : " & number_already_generated & " already process.")
            Else
                'group per store
                Dim koli_collection As String = ""
                Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill AND awbh.id_report_status!=5
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(TEOrderOnline.Text) & "' AND ISNULL(awbh.id_awbill) GROUP BY c.id_comp"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                For j = 0 To dt.Rows.Count - 1
                    'loop per comp
                    Dim id_comp_loop As String = dt.Rows(j)("id_comp").ToString
                    'outbound label generate
                    Dim query As String = ""
                    Dim id_awb As String = ""
                    '
                    query = "INSERT INTO tb_wh_awbill(id_sub_district,awbill_type,awbill_date,id_store,is_old_ways)"
                    query += " VALUES('" + SLESubDistrictOnline.EditValue.ToString + "','1',NOW(),'" + id_comp_loop + "','2'); SELECT LAST_INSERT_ID(); "

                    id_awb = execute_query(query, 0, True, "", "", "", "")

                    If Not j = 0 Then
                        koli_collection += ","
                    End If
                    koli_collection += id_awb
                    '
                    Dim q_loop As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill AND awbh.id_report_status!=5
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(TEOrderOnline.Text) & "'
AND ISNULL(awbh.id_awbill) AND c.id_comp='" & id_comp_loop & "'
GROUP BY c.id_comp"
                    Dim dt_loop As DataTable = execute_query(q_loop, -1, True, "", "", "", "")
                    For k = 0 To dt_loop.Rows.Count - 1
                        query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"
                        Dim id_pl_sales_order_del As String = "NULL"
                        Dim id_ol_store_cust_ret As String = "NULL"

                        id_pl_sales_order_del = dt_loop.Rows(k)("id_pl_sales_order_del").ToString

                        query += "('" + id_awb + "'," + id_pl_sales_order_del + "," + id_ol_store_cust_ret + ",'" + dt_loop.Rows(k)("do_no").ToString + "','" + decimalSQL(Decimal.Parse(dt_loop.Rows(k)("qty").ToString).ToString) + "')"
                        execute_non_query(query, True, "", "", "", "")
                    Next
                    '================= PRINT HERE PER LOOP ===================

                Next
                warningCustom("Outbound Number " & koli_collection & " created")
                Close()
            End If
        Else
            warningCustom("Please choose DO")
        End If
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT cg.`id_comp_group`,cg.`comp_group` 
FROM tb_m_comp c 
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
WHERE c.`id_commerce_type`=2 AND c.`is_active`=1
GROUP BY cg.`id_comp_group`"
        viewSearchLookupQuery(SLEStoreGroup, q, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Private Sub BViewDOOnline_Click(sender As Object, e As EventArgs) Handles BViewDOOnline.Click
        If BViewDOOnline.Text = "view" Then
            'cari
            Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill AND awbh.id_report_status!=5
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(TEOrderOnline.Text) & "'
AND ISNULL(awbh.id_awbill)
GROUP BY d.id_pl_sales_order_del"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count = 0 Then
                warningCustom("Reffrence number/delivery not found")
            Else
                GCDOOnline.DataSource = dt
                GVDOOnline.BestFitColumns()
                '
                load_sub_dsitrict_filter(" WHERE ct.city='" & dt.Rows(0)("shipping_city").ToString & "' ")
                '
                TEOrderOnline.Enabled = False
                SLEStoreGroup.Properties.ReadOnly = True
                BViewDOOnline.Text = "reset"
            End If
        ElseIf BViewDOOnline.Text = "reset" Then
            TEOrderOnline.Enabled = True
            TEOrderOnline.Text = ""
            SLEStoreGroup.Properties.ReadOnly = False
            '
            For i = GVDOOnline.RowCount - 1 To 0 Step -1
                GVDOOnline.DeleteRow(i)
            Next
            BViewDOOnline.Text = "view"
        End If
    End Sub

    Sub load_sub_dsitrict_filter(ByVal filter As String)
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country` " & filter
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            viewSearchLookupQuery(SLESubDistrictOnline, q, "id_sub_district", "sub_district", "id_sub_district")
        Else
            warningCustom("Shipping city not found, please choose shipping district correctly !")
            load_sub_dsitrictOnline()
        End If
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        If GVDOERP.RowCount > 0 Then
            Dim cek As String = CESelAll.EditValue.ToString
            For i As Integer = 0 To ((GVDOERP.RowCount - 1) - GetGroupRowCount(GVDOERP))
                If cek Then
                    GVDOERP.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVDOERP.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub
End Class