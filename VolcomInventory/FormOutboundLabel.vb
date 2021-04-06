Public Class FormOutboundLabel
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_from_do()
    End Sub

    Sub load_from_do()
        Dim q_where As String = ""

        If Not SLEComp.EditValue.ToString = "0" Then
            q_where += " AND c.id_comp='" + addSlashes(SLEComp.EditValue.ToString) + "'"
        End If

        Dim query As String = "SELECT 'yes' AS is_check,d.id_combine,d.id_pl_sales_order_del, IFNULL(comb.combine_number,d.pl_sales_order_del_number)  AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
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
GROUP BY IFNULL(d.`id_combine`,d.id_pl_sales_order_del) 
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

                query = "CALL gen_number_outbound_label('" & id_awb & "')"
                execute_non_query(query, True, "", "", "", "")

                Dim olnumber As String = ""
                Dim qs As String = "SELECT ol_number FROM tb_wh_awbill WHERE id_awbill='" & id_awb & "'"
                olnumber = execute_query(qs, 0, True, "", "", "", "")

                query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"
                For i As Integer = 0 To GVDOERP.RowCount - 1
                    If GVDOERP.GetRowCellValue(i, "id_combine").ToString = "" Then
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
                    Else
                        Dim q As String = "SELECT pl.id_pl_sales_order_del,pl.pl_sales_order_del_number,SUM(pld.pl_sales_order_del_det_qty) AS qty
FROM tb_pl_sales_order_del pl 
INNER JOIN tb_pl_sales_order_del_det pld ON pld.id_pl_sales_order_del=pl.id_pl_sales_order_del
WHERE pl.id_combine='" & GVDOERP.GetRowCellValue(i, "id_combine").ToString & "'
GROUP BY pl.id_pl_sales_order_del"
                        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                        For j = 0 To dt.Rows.Count - 1
                            If Not i + j = 0 Then
                                query += ","
                            End If
                            query += "('" + id_awb + "'," + dt.Rows(j)("id_pl_sales_order_del").ToString + ",NULL,'" + dt.Rows(j)("pl_sales_order_del_number").ToString + "','" + dt.Rows(j)("qty").ToString + "')"
                        Next
                    End If
                Next

                execute_non_query(query, True, "", "", "", "")

                warningCustom("Outbound Number " & olnumber & " created")

                '===================== PRINT HERE =====================
                print_ol(id_awb)

                load_from_do()
            End If
        Else
            warningCustom("Please choose DO")
        End If
        GVDOERP.ActiveFilterString = ""
    End Sub

    Sub print_ol(ByVal id_awbill As String)
        Dim report As ReportOutboundLabel = New ReportOutboundLabel
        '
        Dim q As String = "(SELECT c.`comp_number`,c.`comp_name` ,IFNULL(cb.combine_number,pl.`pl_sales_order_del_number`) AS number,SUM(pld.`pl_sales_order_del_det_qty`) AS qty, c.address_primary, i.city, d.sub_district, i.id_state, s.state, cc.contact_person, cc.contact_number, g.is_marketplace
FROM tb_wh_awbill_det awbd
INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del`
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pl.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
INNER JOIN tb_pl_sales_order_del_det pld ON pld.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
LEFT JOIN tb_m_city AS i ON c.id_city = i.id_city
LEFT JOIN tb_m_state AS s ON i.id_state = s.id_state
LEFT JOIN tb_m_sub_district AS d ON c.id_sub_district = d.id_sub_district
LEFT JOIN tb_m_comp_group AS g ON c.id_comp_group = g.id_comp_group
WHERE id_awbill='" & id_awbill & "'
GROUP BY IFNULL(cb.id_combine,pld.`id_pl_sales_order_del`)
ORDER BY pl.id_pl_sales_order_del ASC)
UNION ALL
(SELECT '' AS `comp_number`,pl.shipping_name AS `comp_name` ,pl.`number` AS number,COUNT(pld.`id_ol_store_ret_list`) AS qty, '' AS address_primary, '' city, '' sub_district, 0 id_state, '' state, '' contact_person, '' contact_number, 2 is_marketplace
FROM tb_wh_awbill_det awbd
INNER JOIN tb_ol_store_cust_ret pl ON pl.`id_ol_store_cust_ret`=awbd.`id_ol_store_cust_ret`
INNER JOIN tb_ol_store_cust_ret_det pld ON pld.`id_ol_store_cust_ret`=pl.`id_ol_store_cust_ret`
WHERE id_awbill='" & id_awbill & "'
GROUP BY pld.`id_ol_store_cust_ret`
ORDER BY pl.id_ol_store_cust_ret ASC)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        Dim olnumber As String = ""
        Dim qs As String = "SELECT ol_number FROM tb_wh_awbill WHERE id_awbill='" & id_awbill & "'"
        olnumber = execute_query(qs, 0, True, "", "", "", "")
        '
        report.id_awbill = id_awbill
        report.ol_number = olnumber
        report.dt = dt

        'Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        'tool.ShowPreview()

        report.CreateDocument()

        '
        Dim report_outbound As ReportOutboundLabelOfline = New ReportOutboundLabelOfline

        report_outbound.XLStoreCode.Text = dt.Rows(0)("comp_number").ToString
        report_outbound.XLStoreName.Text = dt.Rows(0)("comp_name").ToString
        report_outbound.XLAddress.Text = dt.Rows(0)("address_primary").ToString + Environment.NewLine + dt.Rows(0)("sub_district").ToString + ", " + dt.Rows(0)("city").ToString + Environment.NewLine + dt.Rows(0)("state").ToString + Environment.NewLine + "Attn: " + dt.Rows(0)("contact_person").ToString + " " + dt.Rows(0)("contact_number").ToString

        report_outbound.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To report.Pages.Count - 1
            list.Add(report.Pages(i))
        Next

        If dt.Rows(0)("is_marketplace").ToString = "2" And Not dt.Rows(0)("id_state").ToString = "20" Then
            For i = 0 To report_outbound.Pages.Count - 1
                list.Add(report_outbound.Pages(i))
            Next
        End If

        report.Pages.AddRange(list)

        Dim tool_outbound As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool_outbound.ShowPreview()
    End Sub

    Private Sub FormOutboundLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp()
        view_comp_group()
        load_sub_dsitrict()

        TEBarcodeScan.Focus()
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
        Dim order As String = ""

        Try
            If SLEStoreGroup.EditValue.ToString = "64" Then 'ZA
                order = addSlashes(TEOrderOnline.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "75" Then 'BLI
                order = addSlashes(TEOrderOnline.Text)
            ElseIf SLEStoreGroup.EditValue.ToString = "76" Then 'VIOS
                order = addSlashes(TEOrderOnline.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "77" Then 'SHOPEE
                order = addSlashes(TEOrderOnline.Text)
            End If
        Catch ex As Exception
            order = addSlashes(TEOrderOnline.Text)
        End Try

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
                Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
                c.comp_number AS `store_number`,c.id_commerce_type,SUM(dd.pl_sales_order_del_det_qty) AS `qty`,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
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
                WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(order) & "' AND ISNULL(awbh.id_awbill) GROUP BY d.id_pl_sales_order_del"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    Dim query As String = ""
                    Dim id_awb As String = ""

                    query = "INSERT INTO tb_wh_awbill(id_sub_district,awbill_type,awbill_date,id_store,is_old_ways)"
                    query += " VALUES('" + SLESubDistrictOnline.EditValue.ToString + "','1',NOW(),NULL,'2'); SELECT LAST_INSERT_ID(); "

                    id_awb = execute_query(query, 0, True, "", "", "", "")

                    query = "CALL gen_number_outbound_label('" & id_awb & "')"
                    execute_non_query(query, True, "", "", "", "")

                    Dim olnumber As String = ""
                    Dim qs As String = "SELECT ol_number FROM tb_wh_awbill WHERE id_awbill='" & id_awb & "'"
                    olnumber = execute_query(qs, 0, True, "", "", "", "")


                    For k = 0 To dt.Rows.Count - 1
                        query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"

                        Dim id_pl_sales_order_del As String = "NULL"
                        Dim id_ol_store_cust_ret As String = "NULL"

                        id_pl_sales_order_del = dt.Rows(k)("id_pl_sales_order_del").ToString

                        query += "('" + id_awb + "'," + id_pl_sales_order_del + "," + id_ol_store_cust_ret + ",'" + dt.Rows(k)("do_no").ToString + "','" + decimalSQL(Decimal.Parse(dt.Rows(k)("qty").ToString).ToString) + "')"
                        execute_non_query(query, True, "", "", "", "")
                    Next

                    warningCustom("Outbound Number " & olnumber & " created")

                    print_ol(id_awb)
                    Close()
                End If


                'group per store
                'Dim koli_collection As String = ""
                '                Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
                'c.comp_number AS `store_number`,c.id_commerce_type,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
                'FROM tb_pl_sales_order_del d
                'INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
                'LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
                'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
                'INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                'INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
                'LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                'LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
                'LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill AND awbh.id_report_status!=5
                'INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
                'WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(TEOrderOnline.Text) & "' AND ISNULL(awbh.id_awbill) GROUP BY c.id_comp"
                '                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                '                For j = 0 To dt.Rows.Count - 1
                '                    'loop per comp
                '                    Dim id_comp_loop As String = dt.Rows(j)("id_comp").ToString
                '                    'outbound label generate
                '                    Dim query As String = ""
                '                    Dim id_awb As String = ""
                '                    '
                '                    query = "INSERT INTO tb_wh_awbill(id_sub_district,awbill_type,awbill_date,id_store,is_old_ways)"
                '                    query += " VALUES('" + SLESubDistrictOnline.EditValue.ToString + "','1',NOW(),'" + id_comp_loop + "','2'); SELECT LAST_INSERT_ID(); "

                '                    id_awb = execute_query(query, 0, True, "", "", "", "")

                '                    query = "CALL gen_number_outbound_label('" & id_awb & "')"
                '                    execute_non_query(query, True, "", "", "", "")

                '                    Dim olnumber As String = ""
                '                    Dim qs As String = "SELECT ol_number FROM tb_wh_awbill WHERE id_awbill='" & id_awb & "'"
                '                    olnumber = execute_query(qs, 0, True, "", "", "", "")

                '                    If Not j = 0 Then
                '                        koli_collection += ","
                '                    End If
                '                    koli_collection += olnumber
                '                    '
                '                    Dim q_loop As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
                'c.comp_number AS `store_number`,c.id_commerce_type,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'yes' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
                'FROM tb_pl_sales_order_del d
                'INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
                'LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
                'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
                'INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                'INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
                'LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                'LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
                'LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill AND awbh.id_report_status!=5
                'INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
                'WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & order & "'
                'AND ISNULL(awbh.id_awbill) AND c.id_comp='" & id_comp_loop & "'
                'GROUP BY c.id_comp"
                '                    Dim dt_loop As DataTable = execute_query(q_loop, -1, True, "", "", "", "")
                '                    For k = 0 To dt_loop.Rows.Count - 1
                '                        query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"
                '                        Dim id_pl_sales_order_del As String = "NULL"
                '                        Dim id_ol_store_cust_ret As String = "NULL"

                '                        id_pl_sales_order_del = dt_loop.Rows(k)("id_pl_sales_order_del").ToString

                '                        query += "('" + id_awb + "'," + id_pl_sales_order_del + "," + id_ol_store_cust_ret + ",'" + dt_loop.Rows(k)("do_no").ToString + "','" + decimalSQL(Decimal.Parse(dt_loop.Rows(k)("qty").ToString).ToString) + "')"
                '                        execute_non_query(query, True, "", "", "", "")
                '                    Next
                '                    '================= PRINT HERE PER LOOP ===================
                '                    print_ol(id_awb)

                '                Next
                '                warningCustom("Outbound Number " & koli_collection & " created")
                '                Close()

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
        view_ol()
    End Sub

    Sub view_ol()
        Dim order As String = ""

        Try
            If SLEStoreGroup.EditValue.ToString = "64" Then 'ZA
                order = addSlashes(TEOrderOnline.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "75" Then 'BLI
                order = addSlashes(TEOrderOnline.Text)
            ElseIf SLEStoreGroup.EditValue.ToString = "76" Then 'VIOS
                order = addSlashes(TEOrderOnline.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "77" Then 'SHOPEE
                order = addSlashes(TEOrderOnline.Text)
            End If
        Catch ex As Exception
            order = addSlashes(TEOrderOnline.Text)
        End Try

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
WHERE d.id_report_status=1 AND cg.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & order & "'
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

    Private Sub TEOrderOnline_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOrderOnline.KeyUp
        If e.KeyCode = Keys.Enter Then
            view_ol()
        End If
    End Sub

    Private Sub TEBarcodeScan_KeyUp(sender As Object, e As KeyEventArgs) Handles TEBarcodeScan.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim q_where As String = "AND IFNULL(comb.combine_number, d.pl_sales_order_del_number) = '" + addSlashes(TEBarcodeScan.EditValue.ToString) + "'"

            Dim query As String = "
                SELECT 'yes' AS is_check, d.id_combine, d.id_pl_sales_order_del, IFNULL(comb.combine_number, d.pl_sales_order_del_number) AS do_no, comb.combine_number, d.pl_sales_order_del_date AS scan_date, c.comp_number AS store_number, c.id_commerce_type, c.id_sub_district, c.id_comp, c.comp_name AS store_name, SUM(dd.pl_sales_order_del_det_qty) AS qty, stt.report_status, so.shipping_city, c.id_commerce_type
                FROM tb_pl_sales_order_del AS d
                INNER JOIN tb_sales_order AS so ON so.id_sales_order = d.id_sales_order
                LEFT JOIN tb_pl_sales_order_del_combine AS comb ON comb.id_combine = d.id_combine
                INNER JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = d.id_store_contact_to
                INNER JOIN tb_m_comp AS c ON c.id_comp = cc.id_comp
                LEFT JOIN tb_pl_sales_order_del_det AS dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
                LEFT JOIN tb_wh_awbill_det AS awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
                LEFT JOIN tb_wh_awbill AS awbh ON awbh.id_awbill = awb.id_awbill
                INNER JOIN tb_lookup_report_status AS stt ON stt.id_report_status = d.id_report_status
                WHERE d.id_report_status = 1 AND so.is_export_awb = 2 AND ISNULL(awbh.id_awbill) " + q_where + "
                GROUP BY IFNULL(d.id_combine, d.id_pl_sales_order_del)
                ORDER BY d.id_pl_sales_order_del DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                Dim err_message As String = ""

                If GVDOERP.RowCount = 0 Then
                    reset_sdo()
                Else
                    If Not data.Rows(0)("id_comp").ToString = GVDOERP.GetRowCellValue(0, "id_comp").ToString Then
                        err_message = "Store is different."
                    End If
                End If

                For i = 0 To GVDOERP.RowCount - 1
                    If GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString = data.Rows(0)("id_pl_sales_order_del").ToString Then
                        err_message = "SDO already scanned."
                    End If
                Next

                If err_message = "" Then
                    Dim data_a As DataTable = GCDOERP.DataSource

                    Dim row_a As DataRow = data_a.NewRow

                    row_a("is_check") = data.Rows(0)("is_check")
                    row_a("id_combine") = data.Rows(0)("id_combine")
                    row_a("id_pl_sales_order_del") = data.Rows(0)("id_pl_sales_order_del")
                    row_a("do_no") = data.Rows(0)("do_no")
                    row_a("combine_number") = data.Rows(0)("combine_number")
                    row_a("scan_date") = data.Rows(0)("store_number")
                    row_a("store_number") = data.Rows(0)("store_number")
                    row_a("id_commerce_type") = data.Rows(0)("id_commerce_type")
                    row_a("id_sub_district") = data.Rows(0)("id_sub_district")
                    row_a("id_comp") = data.Rows(0)("id_comp")
                    row_a("store_name") = data.Rows(0)("store_name")
                    row_a("qty") = data.Rows(0)("qty")
                    row_a("report_status") = data.Rows(0)("report_status")
                    row_a("shipping_city") = data.Rows(0)("shipping_city")
                    row_a("id_commerce_type") = data.Rows(0)("id_commerce_type")

                    data_a.Rows.Add(row_a)

                    GCDOERP.DataSource = data_a
                Else
                    stopCustomDialog(err_message)
                End If
            Else
                stopCustomDialog("SDO Not Found.")
            End If

            TEBarcodeScan.EditValue = ""

            TEBarcodeScan.Focus()
        End If
    End Sub

    Sub reset_sdo()
        GCDOERP.DataSource = execute_query("
            SELECT NULL AS is_check, NULL AS id_combine, NULL AS id_pl_sales_order_del, NULL AS do_no, NULL AS combine_number, NULL AS scan_date, NULL AS store_number, NULL AS id_commerce_type, NULL AS id_sub_district, NULL AS id_comp, NULL AS store_name, NULL AS qty, NULL AS report_status, NULL AS shipping_city, NULL AS id_commerce_type
            FROM tb_pl_sales_order_del
            WHERE id_pl_sales_order_del = -1
        ", -1, True, "", "", "", "")
    End Sub

    Private Sub SBReset_Click(sender As Object, e As EventArgs) Handles SBReset.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to reset?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            reset_sdo()
        End If
    End Sub
End Class