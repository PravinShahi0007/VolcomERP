﻿Public Class FormWHAWBill
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_lock As String = "2"
    '
    Private open_file_import As String = ""
    Private Sub FormWHAWBill_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormWHAWBill_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub check_but()
        If XTCAwb.SelectedTabPageIndex = 0 Then
            If GVAWBill.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCAwb.SelectedTabPageIndex = 1 Then
            If GVAwbillIn.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_outbound()
        Dim number_start, number_end, date_start, date_end As String

        If TENoStart.Text = "" Then
            number_start = ""
        Else
            number_start = " AND awb.id_awbill>='" + TENoStart.EditValue.ToString + "'"
        End If

        If TENoEnd.Text = "" Then
            number_end = ""
        Else
            number_end = " AND awb.id_awbill<='" + TENoEnd.EditValue.ToString + "'"
        End If

        If DEStart.EditValue = Nothing Then
            date_start = ""
        Else
            Dim date_temp As Date = DEStart.EditValue
            date_start = " AND DATE(awb.awbill_date)>='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        If DEEnd.EditValue = Nothing Then
            date_end = ""
        Else
            Dim date_temp As Date = DEEnd.EditValue
            date_end = " AND DATE(awb.awbill_date)<='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        Dim query As String = ""

        If CECompare.Checked = True Then
            Cursor = Cursors.WaitCursor

            gridBandCalcDetail.Visible = True

            If CEDO.Checked = True Then
                query = "CALL view_wh_awbill_do(1,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = True
            Else
                query = "CALL view_wh_awbill(1,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = False
            End If
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            For i As Integer = GVAWBill.Columns.Count - 1 To 0 Step -1
                If GVAWBill.Columns(i).FieldName.ToString.Contains("#") Then
                    GVAWBill.Columns.RemoveAt(i)
                End If
            Next

            GVAWBill.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcRate.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcLeadTime.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcMinWeight.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_charge_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcCWeight.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_amount#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcAmount.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVAWBill.EndUpdate()

            GCAWBill.DataSource = data
            GVAWBill.BestFitColumns()

            Cursor = Cursors.Default
        Else
            If CEDO.Checked = True Then 'view do
                gridBandDO.Visible = True
                query = "SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') as is_cod,do.do_no, NULL AS `do_no_combine`,do.qty, 0 AS `amount`,do.reff, do.scan_date, grp.id_comp_group,grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff, ('') AS `rmk`, ('') AS `no`"
                query += " ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda, so.sales_order_ol_shop_number"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " inner join tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill"
                query += " inner join tb_wh_awb_do do ON do.do_no=awbd.do_no"
                query += " LEFT JOIN tb_pl_sales_order_del dod ON dod.id_pl_sales_order_del =awbd.id_pl_sales_order_del"
                query += " LEFT JOIN tb_sales_order so ON so.id_sales_order = dod.id_sales_order"
                query += " LEFT JOIN
                            (
	                            SELECT id_wh_awb_det
	                            FROM tb_wh_awbill_det awbd
	                            INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
	                            INNER JOIN tb_wh_awb_do `do` ON `do`.`do_no`=awbd.`do_no`
	                            WHERE 1=1 " + number_start + " " + number_end + " " + date_start + " " + date_end + " 
	                            GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det"
                query += " WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
                query += " UNION ALL "
                query += "SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') as is_cod,awbd.do_no, doc.combine_number AS `do_no_combine`,awbd.qty,  dod.amount, UPPER(sos.so_status) AS `reff`,do.pl_sales_order_del_date AS `scan_date`, grp.id_comp_group, grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff, ('') AS `rmk`, ('') AS `no`"
                query += " ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda, so.sales_order_ol_shop_number"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " inner join tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill"
                query += " LEFT JOIN
                            (
	                            SELECT id_wh_awb_det
	                            FROM tb_wh_awbill_det awbd
	                            INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
	                            WHERE 1=1 " + number_start + " " + number_end + " " + date_start + " " + date_end + " 
	                            GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det
                        inner join tb_pl_sales_order_del do ON do.id_pl_sales_order_del =awbd.id_pl_sales_order_del
                        INNER JOIN (
	                        SELECT d.id_pl_sales_order_del, d.pl_sales_order_del_number, d.pl_sales_order_del_date,SUM(dd.design_price * dd.pl_sales_order_del_det_qty) AS `amount`
	                        FROM tb_pl_sales_order_del d
	                        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
	                        WHERE d.id_report_status!=5 
	                        GROUP BY d.id_pl_sales_order_del
                        ) dod ON dod.id_pl_sales_order_del = do.id_pl_sales_order_del
                        LEFT JOIN tb_pl_sales_order_del_combine doc ON doc.id_combine = do.id_combine
				        INNER JOIN tb_sales_order so ON so.id_sales_order = do.id_sales_order
				        INNER JOIN tb_lookup_so_status sos ON sos.id_so_status = so.id_so_status"
                query += " WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + " "
                query += " UNION ALL 
                            SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') AS is_cod,awbd.do_no, '' AS `do_no_combine`,awbd.qty,  dod.amount, 'Return Customer' AS `reff`,do.created_date AS `scan_date`, grp.id_comp_group, grp.comp_group,comp_store.comp_number AS account,comp_store.comp_name AS account_name,comp_cargo.comp_name AS cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) AS volume,
                            DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,
                            DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,
                            (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,
                            (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,
                            (awb.c_weight-awb.a_weight) AS weight_diff,(awb.c_tot_price-awb.a_tot_price) AS amount_diff, ('') AS `rmk`, ('') AS `no`
                            ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda, do.sales_order_ol_shop_number
                            FROM tb_wh_awbill awb
                            INNER JOIN tb_m_comp comp_store ON comp_store.id_comp=awb.id_store
                            INNER JOIN tb_m_comp comp_cargo ON comp_cargo.id_comp=awb.id_cargo
                            LEFT JOIN tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group
                            INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
                            LEFT JOIN
                            (
                                SELECT id_wh_awb_det
                                FROM tb_wh_awbill_det awbd
                                INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
                                WHERE 1=1 " + number_start + " " + number_end + " " + date_start + " " + date_end + " 
                                GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det
                            INNER JOIN `tb_ol_store_cust_ret` `do` ON do.`id_ol_store_cust_ret` =awbd.id_ol_store_cust_ret
                            INNER JOIN (
	                            SELECT crd.id_ol_store_cust_ret,SUM(sod.design_price) AS amount FROM tb_ol_store_cust_ret_det crd
	                            INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list=crd.id_ol_store_ret_list
	                            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det=rl.id_ol_store_ret_det
	                            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det=rd.id_sales_order_det
	                            GROUP BY crd.id_ol_store_cust_ret
                            ) dod ON dod.id_ol_store_cust_ret = do.id_ol_store_cust_ret
                            WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
                query += " ORDER BY id_awbill,do_no ASC "
            Else
                gridBandDO.Visible = False
                query = "SELECT 'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_no,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') as is_cod,grp.comp_group, comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff,('') AS `no`,2 as penanda"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
            End If
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCAWBill.DataSource = data

            gridBandCalcDetail.Visible = False

            GVAWBill.BestFitColumns()
        End If

        'show manifest button
        If CEDO.Checked = True And CECompare.Checked = False Then
            BtnManifest.Visible = True
        Else
            BtnManifest.Visible = False
        End If

        numbering()

        check_but()
    End Sub
    Sub load_inbound()
        Dim number_start, number_end, date_start, date_end As String

        If TEInNoStart.EditValue = 0 Or TEInNoStart.EditValue = Nothing Then
            number_start = ""
        Else
            number_start = " AND awb.id_awbill>='" + TEInNoStart.EditValue.ToString + "'"
        End If

        If TEInNoEnd.EditValue = 0 Or TEInNoEnd.EditValue = Nothing Then
            number_end = ""
        Else
            number_end = " AND awb.id_awbill<='" + TEInNoEnd.EditValue.ToString + "'"
        End If

        If DEInStart.EditValue = Nothing Then
            date_start = ""
        Else
            Dim date_temp As Date = DEInStart.EditValue
            date_start = " AND DATE(awb.awbill_date)>='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        If DEInEnd.EditValue = Nothing Then
            date_end = ""
        Else
            Dim date_temp As Date = DEInEnd.EditValue
            date_end = " AND DATE(awb.awbill_date)<='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        Dim query As String = ""

        If CEInCompare.Checked = True Then
            Cursor = Cursors.WaitCursor

            GBInCalcDet.Visible = True

            If CERO.Checked = True Then
                query = "CALL view_wh_awbill_do(2,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = True
            Else
                query = "CALL view_wh_awbill(2,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = False
            End If

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            For i As Integer = GVAwbillIn.Columns.Count - 1 To 0 Step -1
                If GVAwbillIn.Columns(i).FieldName.ToString.Contains("#") Then
                    GVAwbillIn.Columns.RemoveAt(i)
                End If
            Next

            GVAwbillIn.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcRate.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBInCalcLeadTime.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcMinWeight.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_charge_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcCWeight.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_amount#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBInCalcAmount.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVAwbillIn.EndUpdate()

            GCAwbillIn.DataSource = data
            GVAwbillIn.BestFitColumns()

            Cursor = Cursors.Default
        Else
            If CERO.Checked = True Then 'view do
                gridBandRO.Visible = True
                query = "SELECT awb.awbill_no,awbd.qty,awbd.act_qty,(awbd.qty-awbd.act_qty) AS diff_qty,'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_inv_no,IF(is_paid_by_store='2','no','yes') AS is_cod,awbd.do_no,awbd.qty,do.reff, do.scan_date, grp.comp_group,comp_store.comp_number AS account,comp_store.comp_name AS account_name,comp_cargo.comp_name AS cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) AS volume,
                            DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,
                            DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,
                            (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,
                            (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,
                            (awb.c_weight-awb.a_weight) AS weight_diff,(awb.c_tot_price-awb.a_tot_price) AS amount_diff, ('') AS `rmk`, ('') AS `no`
                            ,IF(ISNULL(head.id_wh_awb_det),1,2) AS penanda
                            FROM tb_wh_awbill awb
                            INNER JOIN tb_m_comp comp_store ON comp_store.id_comp=awb.id_store
                            INNER JOIN tb_m_comp comp_cargo ON comp_cargo.id_comp=awb.id_cargo
                            LEFT JOIN tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group
                            INNER JOIN tb_wh_awbill_det_in awbd ON awbd.id_awbill=awb.id_awbill
                            LEFT JOIN tb_wh_awb_do DO ON do.do_no=awbd.do_no
                            LEFT JOIN
                            (
	                            SELECT id_wh_awb_det
	                            FROM tb_wh_awbill_det awbd
	                            INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
	                            INNER JOIN tb_wh_awb_do `do` ON `do`.`do_no`=awbd.`do_no`
	                            WHERE 1=1 " + number_start + " " + number_end + " " + date_start + " " + date_end + " 
	                            GROUP BY awbd.id_awbill
                            ) head ON head.id_wh_awb_det=awbd.id_wh_awb_det"
                query += " WHERE awb.awbill_type='2' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
                query += " ORDER BY awb.id_awbill,awbd.do_no ASC"
            Else
                gridBandRO.Visible = False
                query = "SELECT awb.awbill_no,'no' AS is_check,IF(awb.is_lock=2,'no','yes') AS is_lock,awb.awbill_inv_no,grp.comp_group, comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff,2 as penanda FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " WHERE awb.awbill_type='2' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
            End If

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCAwbillIn.DataSource = data

            GBInCalcDet.Visible = False

            GVAwbillIn.BestFitColumns()
        End If
        check_but()
    End Sub
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_outbound()
    End Sub

    Private Sub BInView_Click(sender As Object, e As EventArgs) Handles BInView.Click
        load_inbound()
    End Sub

    Private Sub XTCAwb_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAwb.SelectedPageChanged
        check_but()
    End Sub

    Private Sub GVAWBill_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVAWBill.CellMerge
        If (e.Column.FieldName = "no" Or e.Column.FieldName = "id_awbill" Or e.Column.FieldName = "weight" Or e.Column.FieldName = "length" Or e.Column.FieldName = "width" Or e.Column.FieldName = "height" Or e.Column.FieldName = "volume" Or e.Column.FieldName = "c_weight" Or e.Column.FieldName = "c_tot_price" Or e.Column.FieldName = "a_weight" Or e.Column.FieldName = "a_tot_price" Or e.Column.FieldName = "weight_diff" Or e.Column.FieldName = "amount_diff") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_awbill")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_awbill")

            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub GCAWBill_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GCAWBill.ProcessGridKey
        If e.KeyCode = Keys.Enter Then
            GVAWBill.FocusedRowHandle += 1
            e.Handled = True
        End If
    End Sub

    Private Sub GCAwbillIn_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GCAwbillIn.ProcessGridKey
        If e.KeyCode = Keys.Enter Then
            GVAwbillIn.FocusedRowHandle += 1
            e.Handled = True
        End If
    End Sub

    Private Sub GVAWBill_HiddenEditor(sender As Object, e As EventArgs) Handles GVAWBill.HiddenEditor
        If GVAWBill.FocusedColumn.FieldName = "rec_by_store_date" Then
            Dim datex As String = ""
            If Not GVAWBill.GetFocusedRowCellValue("rec_by_store_date").ToString = "" Then
                datex = "'" & Date.Parse(GVAWBill.GetFocusedRowCellValue("rec_by_store_date").ToString).ToString("yyyy-MM-dd") & "'"
            Else
                datex = "NULL"
            End If

            Dim query As String = "UPDATE tb_wh_awbill SET rec_by_store_date=" + datex + " WHERE id_awbill='" + GVAWBill.GetFocusedRowCellValue("id_awbill").ToString + "'"
            execute_non_query(query, True, "", "", "", "")
            Try
                GVAWBill.SetFocusedRowCellValue("del_time", DateDiff(DateInterval.Day, GVAWBill.GetFocusedRowCellValue("pick_up_date"), GVAWBill.GetFocusedRowCellValue("rec_by_store_date")))
                GVAWBill.SetFocusedRowCellValue("lead_time_diff", DateDiff(DateInterval.Day, GVAWBill.GetFocusedRowCellValue("eta_date"), GVAWBill.GetFocusedRowCellValue("rec_by_store_date")))
                If GVAWBill.GetFocusedRowCellValue("lead_time_diff").ToString = "0" Then
                    GVAWBill.SetFocusedRowCellValue("time_remark", "ON TIME")
                ElseIf GVAWBill.GetFocusedRowCellValue("lead_time_diff") > 0 Then
                    GVAWBill.SetFocusedRowCellValue("time_remark", "LATE")
                ElseIf GVAWBill.GetFocusedRowCellValue("lead_time_diff") < 0 Then
                    GVAWBill.SetFocusedRowCellValue("time_remark", "EARLY")
                Else
                    GVAWBill.SetFocusedRowCellValue("time_remark", "ON DELIVERY")
                End If
            Catch ex As Exception
            End Try
        ElseIf GVAWBill.FocusedColumn.FieldName = "rec_by_store_person" Then
            Dim query As String = "UPDATE tb_wh_awbill SET rec_by_store_person='" + GVAWBill.GetFocusedRowCellValue("rec_by_store_person") + "' WHERE id_awbill='" + GVAWBill.GetFocusedRowCellValue("id_awbill").ToString + "'"
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Private Sub BtnManifest_Click(sender As Object, e As EventArgs) Handles BtnManifest.Click
        Cursor = Cursors.WaitCursor
        FormOutboundManifest.dt = GCAWBill.DataSource
        FormOutboundManifest.ftr = GVAWBill.ActiveFilterString
        ''creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVAWBill.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'FormOutboundManifest.GVManifest.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        FormOutboundManifest.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Dim total As Decimal = 0.0
    Dim group_total As Decimal = 0.0

    Private Sub GVAWBill_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAWBill.CustomSummaryCalculate
        If (CType(e.Item, DevExpress.XtraGrid.GridSummaryItem)).FieldName = "qty" Then
            Return
        End If

        If e.IsTotalSummary Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                total = 0
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If GVAWBill.GetRowCellValue(e.RowHandle, "penanda").ToString = "2" Then
                    total += e.FieldValue
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = total
            End If
        End If
        If e.IsGroupSummary Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                group_total = 0
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If GVAWBill.GetRowCellValue(e.RowHandle, "penanda").ToString = "2" Then
                    group_total += e.FieldValue
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = group_total
            End If
        End If
    End Sub

    Private Sub BAWBRec_Click(sender As Object, e As EventArgs) Handles BAWBRec.Click
        FormImportExcel.id_pop_up = "35"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVAWBill.RowCount > 0 Then
            For i As Integer = 0 To ((GVAWBill.RowCount - 1) - GetGroupRowCount(GVAWBill))
                If CESelectAll.Checked = False Then
                    GVAWBill.SetRowCellValue(i, "is_check", "no")
                Else
                    GVAWBill.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        Cursor = Cursors.WaitCursor
        'search id det
        Dim where_string As String = ""
        makeSafeGV(GVAWBill)
        GVAWBill.ActiveFilterString = "[is_check]='yes'"
        If GVAWBill.RowCount > 0 Then
            For i As Integer = 0 To GVAWBill.RowCount - 1
                If i = 0 Then
                    where_string = GVAWBill.GetRowCellValue(i, "id_awbill").ToString
                Else
                    where_string += "," & GVAWBill.GetRowCellValue(i, "id_awbill").ToString
                End If
            Next
            makeSafeGV(GVAWBill)
            'update
            Dim query_upd As String = "UPDATE tb_wh_awbill SET is_lock='1' WHERE id_awbill IN (" & where_string & ")"
            execute_non_query(query_upd, True, "", "", "", "")
            infoCustom("Process locked.")
            load_outbound()
            '
            Cursor = Cursors.Default
        Else
            stopCustom("Please choose collie first.")
        End If
    End Sub

    Private Sub FormWHAWBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_lock = "1" Then
            PCLock.Visible = True
            PCLockIn.Visible = True
        Else
            PCLock.Visible = False
            PCLockIn.Visible = False
        End If
    End Sub

    Private Sub BReportInvoice_Click(sender As Object, e As EventArgs) Handles BReportInvoice.Click
        FormAWBInvoiceReport.ShowDialog()
    End Sub

    Private Sub BImportAwb_Click(sender As Object, e As EventArgs) Handles BImportAwb.Click
        FormImportExcel.id_pop_up = "44"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub CESelAllInboud_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAllInboud.CheckedChanged
        If GVAwbillIn.RowCount > 0 Then
            For i As Integer = 0 To ((GVAwbillIn.RowCount - 1) - GetGroupRowCount(GVAwbillIn))
                If CESelAllInboud.Checked = False Then
                    GVAwbillIn.SetRowCellValue(i, "is_check", "no")
                Else
                    GVAwbillIn.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BLockInbound_Click(sender As Object, e As EventArgs) Handles BLockInbound.Click
        Cursor = Cursors.WaitCursor
        'search id det
        Dim where_string As String = ""
        makeSafeGV(GVAwbillIn)
        GVAwbillIn.ActiveFilterString = "[is_check]='yes'"
        If GVAwbillIn.RowCount > 0 Then
            For i As Integer = 0 To GVAwbillIn.RowCount - 1
                If i = 0 Then
                    where_string = GVAwbillIn.GetRowCellValue(i, "id_awbill").ToString
                Else
                    where_string += "," & GVAwbillIn.GetRowCellValue(i, "id_awbill").ToString
                End If
            Next
            makeSafeGV(GVAwbillIn)
            'update
            Dim query_upd As String = "UPDATE tb_wh_awbill SET is_lock='1' WHERE id_awbill IN (" & where_string & ")"
            execute_non_query(query_upd, True, "", "", "", "")
            infoCustom("Process locked.")
            load_inbound()
            '
            Cursor = Cursors.Default
        Else
            stopCustom("Please choose collie first.")
        End If
    End Sub

    Sub numbering()
        Dim last_collie As String = ""

        Dim no As Integer = 1

        For i = 0 To GVAWBill.RowCount - 1
            If GVAWBill.IsValidRowHandle(i) Then
                If i = 0 Then
                    last_collie = GVAWBill.GetRowCellValue(i, "id_awbill").ToString

                End If

                'numbering
                If Not last_collie = GVAWBill.GetRowCellValue(i, "id_awbill").ToString Then
                    no = no + 1
                End If

                GVAWBill.SetRowCellValue(i, "no", no)

                last_collie = GVAWBill.GetRowCellValue(i, "id_awbill").ToString
            End If
        Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormWHAwbillTrackCollection.ShowDialog()
    End Sub

    Private Sub BShipmentLabel_Click(sender As Object, e As EventArgs) Handles BShipmentLabel.Click
        GVAWBill.ActiveFilterString = "[is_check] = 'yes'"

        If GVAWBill.RowCount > 0 Then
            Dim q_in As String = ""

            For i = 0 To GVAWBill.RowCount - 1
                If GVAWBill.IsValidRowHandle(i) Then
                    q_in += GVAWBill.GetRowCellValue(i, "id_awbill").ToString + ", "
                End If
            Next

            Dim query As String = "
                SELECT aw.awbill_no, so.sales_order_ol_shop_number, so.shipping_name, so.shipping_address, so.shipping_address1, so.shipping_address2, so.shipping_city, CONCAT(so.shipping_region, ', ', so.shipping_post_code) AS shipping_region_post_code, so.shipping_phone
                FROM tb_wh_awbill_det AS aw_det
                INNER JOIN tb_pl_sales_order_del AS pl_del ON aw_det.id_pl_sales_order_del = pl_del.id_pl_sales_order_del
                INNER JOIN tb_sales_order AS so ON pl_del.id_sales_order = so.id_sales_order
                INNER JOIN tb_wh_awbill AS aw ON aw_det.id_awbill = aw.id_awbill    
                WHERE aw_det.id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ")

                UNION ALL

                SELECT aw.awbill_no, cust_ret.sales_order_ol_shop_number, cust_ret.shipping_name, cust_ret.shipping_address, cust_ret.shipping_address AS shipping_address1, '' AS shipping_address2, cust_ret.shipping_city, CONCAT(cust_ret.shipping_region, ', ', cust_ret.shipping_post_code) AS shipping_region_post_code, cust_ret.shipping_phone
                FROM tb_wh_awbill_det AS aw_det
                INNER JOIN tb_ol_store_cust_ret AS cust_ret ON aw_det.id_ol_store_cust_ret = cust_ret.id_ol_store_cust_ret
                INNER JOIN tb_wh_awbill AS aw ON aw_det.id_awbill = aw.id_awbill    
                WHERE aw_det.id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ")
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim report As ReportWHAWBillShipmentLabel = New ReportWHAWBillShipmentLabel

            report.DataSource = data

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        Else
            errorCustom("No AWB selected.")
        End If

        GVAWBill.ActiveFilterString = ""
    End Sub

    Private Sub SBExportCsss_Click(sender As Object, e As EventArgs) Handles SBExportCsss.Click
        GVAWBill.ActiveFilterString = "[is_check] = 'yes'"

        If GVAWBill.RowCount > 0 Then
            Dim q_in As String = ""

            For i = 0 To GVAWBill.RowCount - 1
                If GVAWBill.IsValidRowHandle(i) Then
                    q_in += GVAWBill.GetRowCellValue(i, "id_awbill").ToString + ", "
                End If
            Next

            Dim is_exported As String = execute_query("SELECT MAX(is_exported) AS is_exported FROM tb_wh_awbill WHERE id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ")", 0, True, "", "", "", "")

            If is_exported = "0" Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Selected awb can only be exported once, are you sure want to export?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = DialogResult.Yes Then
                    Dim query As String = "
                        SELECT so.shipping_name, CONCAT(so.shipping_address1, ' ', so.shipping_address2) AS shipping_address, so.shipping_city, so.shipping_post_code, so.shipping_region, so.shipping_phone, sod.qty, aw.c_weight, opt.jne_good_desc, opt.jne_goods_value, opt.jne_special_instruction, opt.jne_service, CONCAT(aw_det.id_awbill, '#', so.sales_order_ol_shop_number) AS order_id, opt.jne_insurance, opt.jne_shipper_name, opt.jne_shipper_address, opt.jne_shipper_city, opt.jne_shipper_zip, opt.jne_shipper_region, opt.jne_shipper_contact, opt.jne_shipper_phone, '' AS destination_code
                        FROM tb_wh_awbill_det AS aw_det
                        INNER JOIN tb_pl_sales_order_del AS pl_del ON aw_det.id_pl_sales_order_del = pl_del.id_pl_sales_order_del
                        INNER JOIN tb_sales_order AS so ON pl_del.id_sales_order = so.id_sales_order
                        INNER JOIN (
                            SELECT id_sales_order, SUM(sales_order_det_qty) AS qty
                            FROM tb_sales_order_det
                            GROUP BY id_sales_order
                        ) AS sod ON so.id_sales_order = sod.id_sales_order
                        INNER JOIN tb_wh_awbill AS aw ON aw_det.id_awbill = aw.id_awbill    
                        INNER JOIN tb_opt AS opt ON aw_det.id_awbill = aw_det.id_awbill
                        WHERE aw_det.id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ")
                
                        UNION ALL

                        SELECT cust_ret.shipping_name, cust_ret.shipping_address, cust_ret.shipping_city, cust_ret.shipping_post_code, cust_ret.shipping_region, cust_ret.shipping_phone, aw_det.qty, aw.c_weight, opt.jne_good_desc, opt.jne_goods_value, opt.jne_special_instruction, opt.jne_service, CONCAT(aw_det.id_awbill, '#', cust_ret.sales_order_ol_shop_number) AS order_id, opt.jne_insurance, opt.jne_shipper_name, opt.jne_shipper_address, opt.jne_shipper_city, opt.jne_shipper_zip, opt.jne_shipper_region, opt.jne_shipper_contact, opt.jne_shipper_phone, '' AS destination_code
                        FROM tb_wh_awbill_det AS aw_det
                        INNER JOIN tb_ol_store_cust_ret AS cust_ret ON aw_det.id_ol_store_cust_ret = cust_ret.id_ol_store_cust_ret
                        INNER JOIN tb_wh_awbill AS aw ON aw_det.id_awbill = aw.id_awbill    
                        INNER JOIN tb_opt AS opt ON aw_det.id_awbill = aw_det.id_awbill
                        WHERE aw_det.id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ")
                    "

                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                    GCExportExcel.DataSource = data

                    Dim save As SaveFileDialog = New SaveFileDialog

                    save.Filter = "Excel File | *.xls"
                    save.ShowDialog()

                    If Not save.FileName = "" Then
                        Dim op As DevExpress.XtraPrinting.XlsExportOptionsEx = New DevExpress.XtraPrinting.XlsExportOptionsEx

                        op.ExportType = DevExpress.Export.ExportType.WYSIWYG

                        GVExportExcel.ExportToXls(save.FileName, op)

                        'resave
                        Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application

                        Dim awb As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(save.FileName)

                        awb.Save()

                        awb.Close()

                        app.Quit()

                        'update is exported
                        execute_non_query("UPDATE tb_wh_awbill SET is_exported = 1 WHERE id_awbill IN (" + q_in.Substring(0, q_in.Length - 2) + ") ", True, "", "", "", "")

                        infoCustom("File saved.")
                    End If
                End If
            Else
                errorCustom("Some data already exported.")
            End If
        Else
            errorCustom("No AWB selected.")
        End If

        GVAWBill.ActiveFilterString = ""
    End Sub

    Private Sub SBImportCsss_Click(sender As Object, e As EventArgs) Handles SBImportCsss.Click
        Dim fdlg As OpenFileDialog = New OpenFileDialog()

        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            open_file_import = fdlg.FileName
        End If

        fdlg.Dispose()

        If Not fdlg.FileName = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("AWB can only be imported once, are you sure want to import?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                'resave
                Dim awb_tmp As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\awb_tmp.xls"

                Dim app As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application

                Dim awb As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Open(fdlg.FileName)

                Dim aws As Microsoft.Office.Interop.Excel.Worksheet = awb.Worksheets(1)

                aws.Name = "Sheet1"

                awb.SaveAs(awb_tmp, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)

                awb.Close()

                app.Quit()

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + awb_tmp + "'; Extended Properties=""Excel 12.0 XML; IMEX=1; HDR=YES; TypeGuessRows=0; ImportMixedTypes=Text;""")

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)

                DtSet = New System.Data.DataSet

                MyCommand.Fill(DtSet)

                Dim dt As DataTable = DtSet.Tables(0)

                Dim data As DataTable = New DataTable

                data.Columns.Add("id_awbill", GetType(String))
                data.Columns.Add("awbill", GetType(String))

                'check already imported
                Dim already_imported As Boolean = False

                For i = 2 To dt.Rows.Count - 1
                    Try
                        Dim id_awbill As String = dt.Rows(i)(1).ToString.Substring(0, dt.Rows(i)(1).ToString.IndexOf("#"))

                        Dim awbill_no As String = execute_query("SELECT awbill_no AS total FROM tb_wh_awbill WHERE id_awbill = '" + id_awbill + "'", 0, True, "", "", "", "")

                        If Not awbill_no = "" Then
                            already_imported = True
                        End If
                    Catch ex As Exception
                    End Try
                Next

                'import
                Dim total_imported As Integer = 0
                Dim total_already_imported As Integer = 0
                Dim total_not_imported As Integer = 0

                For i = 2 To dt.Rows.Count - 1
                    Try
                        Dim awbill_no As String = dt.Rows(i)(29).ToString.Replace("#", "")
                        Dim id_awbill As String = dt.Rows(i)(1).ToString.Substring(0, dt.Rows(i)(1).ToString.IndexOf("#"))

                        '
                        Dim already_awb As String = execute_query("SELECT COUNT(*) AS total FROM tb_wh_awbill WHERE id_awbill = '" + id_awbill + "'", 0, True, "", "", "", "")

                        If Not already_awb = "0" Then
                            '
                            Dim select_awbill_no As String = execute_query("SELECT awbill_no AS total FROM tb_wh_awbill WHERE id_awbill = '" + id_awbill + "'", 0, True, "", "", "", "")

                            If select_awbill_no = "" Then
                                'update
                                Dim que As String = "UPDATE tb_wh_awbill SET awbill_no = '" + awbill_no + "' WHERE id_awbill = '" + id_awbill + "'"

                                execute_non_query(que, True, "", "", "", "")

                                total_imported = total_imported + 1
                            Else
                                total_already_imported = total_already_imported + 1
                            End If
                        Else
                            total_not_imported = total_not_imported + 1
                        End If
                    Catch ex As Exception
                    End Try
                Next

                MyConnection.Close()

                My.Computer.FileSystem.DeleteFile(awb_tmp)

                Dim msg As String = total_imported.ToString + " data successfully imported."
                msg += Environment.NewLine + total_already_imported.ToString + " data already imported."
                msg += Environment.NewLine + total_not_imported.ToString + " data failed to imported."

                infoCustom(msg)
            End If
        End If
    End Sub
End Class