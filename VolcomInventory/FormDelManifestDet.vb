Public Class FormDelManifestDet
    Public id_del_manifest As String = "0"

    Public is_block_del_store As String = get_setup_field("is_block_del_store")

    Public is_complete_wholesale As Boolean = False

    Private loaded As Boolean = False

    Dim id_report_status As String = "-1"

    'scan
    Private cforKeyDown As Char = vbNullChar
    Private _lastKeystroke As DateTime = DateTime.Now
    Public speed_barcode_read As Integer = get_setup_field("speed_barcode_read")
    Public speed_barcode_read_timer As Integer = get_setup_field("speed_barcode_read_timer")

    Private Sub FormDelManifestDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False

        view_del_type()
        view_ol_or_no()
        view_comp()
        view_comp_group()
        load_sub_dsitrict()
        '
        form_load()

        TEComp.Focus()
        '
        If is_complete_wholesale = True Then
            'check
            If id_report_status = "6" Or id_report_status = "5" Then
                BCompleteWholesale.Visible = False
            Else
                BCompleteWholesale.Visible = True
            End If
        End If
        '
        loaded = True
        '

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

    Sub load_sub_dsitrict_filter(ByVal filter As String)
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country` " & filter
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
        Else
            warningCustom("Shipping district not found, please choose shipping district correctly !")
            load_sub_dsitrict()
        End If
    End Sub

    Sub view_del_type()
        Dim q As String = "SELECT id_del_type, del_type, is_no_weight,volume_divide_by FROM tb_lookup_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
    End Sub

    Sub view_ol_or_no()
        Dim q As String = "SELECT '2' AS id, 'No' AS `type` 
UNION
SELECT '1' AS id, 'Yes' AS `type`"
        viewSearchLookupQuery(SLEOnlineShop, q, "id", "type", "id")
    End Sub

    Sub view_comp()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_m_comp c
WHERE c.id_commerce_type='1' AND c.id_comp_cat='6' AND is_active='1'"
        viewSearchLookupQuery(SLEComp, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT cg.`id_comp_group`,cg.`comp_group` 
FROM tb_m_comp c 
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
WHERE c.`id_commerce_type`=2 AND c.`is_active`=1
GROUP BY cg.`id_comp_group`"
        viewSearchLookupQuery(SLEStoreGroup, q, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs)
        If SLUE3PL.EditValue.ToString = "0" Then
            stopCustom("Please select 3PL.")
        Else
            FormDelManifestPick.ShowDialog()
        End If
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs)
        GVList.DeleteSelectedRows()
    End Sub

    Private Sub SBComplete_Click(sender As Object, e As EventArgs) Handles SBComplete.Click
        save("complete")
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Cursor = Cursors.WaitCursor

        Dim is_awb_ok As Boolean = True
        If SLEDelType.EditValue.ToString = "1" Then
            'WH
            If Not TEAwb.Text = GVList.GetRowCellValue(0, "ol_number").ToString Then
                warningCustom("Gunakan AWB dengan nomor outbound label " & GVList.GetRowCellValue(0, "ol_number").ToString)
                is_awb_ok = False
            End If
        Else
            'selain WH
            For i = 0 To GVList.RowCount - 1
                If TEAwb.Text = GVList.GetRowCellValue(i, "ol_number").ToString Then
                    warningCustom("Pastikan anda tidak salah menginput AWB.")
                    is_awb_ok = False
                    Exit For
                End If
            Next
        End If

        If is_awb_ok Then
            GVCargoRate.FocusedRowHandle = find_row(GVCargoRate, "id_3pl_rate", SLUE3PL.EditValue.ToString)

            'save("draft")
            save("save")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        save("cancel")
    End Sub

    Sub form_load()
        'header
        id_report_status = ""
        Dim data As DataTable

        If Not id_del_manifest = "0" Then
            Dim query As String = "
            SELECT m.mark_different,m.actual_weight,m.id_del_manifest, m.id_del_type,m.id_comp, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, m.id_report_status, IFNULL(l.report_status, 'Waiting Check By Security') AS report_status
            ,m.id_sub_district,m.awbill_no, m.id_cargo,m.cargo_rate,m.cargo_min_weight,m.cargo_lead_time,m.is_ol_shop,m.id_comp_group,m.ol_order,m.id_store_offline
            ,m.c_weight,m.c_tot_price,m.id_cargo_best,m.cargo_rate_best,m.cargo_min_weight_best,m.cargo_lead_time_best,m.mark_different       
            FROM tb_del_manifest AS m
            LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
            LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
            LEFT JOIN tb_m_user AS ub ON m.created_by = ub.id_user
            LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            WHERE m.id_del_manifest = " + id_del_manifest + ""

            data = execute_query(query, -1, True, "", "", "", "")

            TENumber.EditValue = data.Rows(0)("number").ToString
            TECreatedDate.EditValue = data.Rows(0)("created_date").ToString
            TEUpdatedDate.EditValue = data.Rows(0)("updated_date").ToString
            TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
            TEUpdatedBy.EditValue = data.Rows(0)("updated_by").ToString
            TEReportStatus.EditValue = data.Rows(0)("report_status").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            TERemarkDiff.Text = data.Rows(0)("mark_different").ToString

            If Not TERemarkDiff.Text = "" Then
                TERemarkDiff.Visible = True
                LRemarkDiff.Visible = True
            Else
                TERemarkDiff.Visible = False
                LRemarkDiff.Visible = False
            End If
            '
            SLEDelType.EditValue = data.Rows(0)("id_del_type").ToString
            SLEOnlineShop.EditValue = data.Rows(0)("is_ol_shop").ToString
            '
            online_pc_changed()
            '
            SLEStoreGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            TEOrderNumber.EditValue = data.Rows(0)("ol_order").ToString
            SLEComp.EditValue = data.Rows(0)("id_store_offline").ToString

            Try
                TEComp.Text = get_company_x(data.Rows(0)("id_store_offline").ToString, "2")
                TEComp.Properties.ReadOnly = True
            Catch ex As Exception
            End Try

            'footer
            'sub district
            load_sub_dsitrict_filter("")

            If SLEOnlineShop.EditValue.ToString = "1" Then
                SLEDelType.Properties.ReadOnly = True
                SLEOnlineShop.Properties.ReadOnly = True
                SLEStoreGroup.Properties.ReadOnly = True
                TEOrderNumber.Enabled = False
            Else
                SLEDelType.Properties.ReadOnly = True
                SLEOnlineShop.Properties.ReadOnly = True
                SLEComp.Properties.ReadOnly = True
            End If
            '
            load_cargo_rate()
            PCRate.Visible = True
            '
            SLESubDistrict.EditValue = data.Rows(0)("id_sub_district").ToString
            TEAwb.Text = data.Rows(0)("awbill_no").ToString
        End If

        'detail
        Dim query_det As String = "
            SELECT *
                FROM (
                SELECT 0 AS NO, mdet.id_wh_awb_det, c.id_comp_group, a.ol_number, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, IFNULL(so.shipping_city,ct.city) AS city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / dt.`volume_divide_by`) AS volume, a.c_weight
,adet.id_pl_sales_order_del     
FROM tb_del_manifest_det AS mdet
                INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest`
                INNER JOIN tb_lookup_del_type dt ON dt.`id_del_type`=md.`id_del_type`
                LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
                LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
                LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
                LEFT JOIN tb_sales_order so ON so.`id_sales_order`=pdel.`id_sales_order`
                LEFT JOIN tb_m_comp_contact AS cc ON pdel.id_store_contact_to = cc.id_comp_contact
                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
                LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
                LEFT JOIN (
	                SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	                FROM tb_pl_sales_order_del_det AS z1
	                LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	                LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	                GROUP BY z2.id_combine
                ) AS z ON pdelc.combine_number = z.combine_number
                WHERE mdet.id_del_manifest = " & id_del_manifest & "
            ) AS tb
            ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC
        "

        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

        'manipulate merge qty & total qty
        Dim last_collie As String = ""
        Dim last_combine As String = ""

        Dim total_qty As Integer = 0

        Dim qty_manipulated As String = ""

        For i = 0 To data_det.Rows.Count - 1
            If i = 0 Then
                last_collie = data_det.Rows(i)("id_awbill").ToString
                last_combine = data_det.Rows(i)("combine_number").ToString

                total_qty = total_qty + Integer.Parse(data_det.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            'merge qty
            If Not last_collie = data_det.Rows(i)("id_awbill").ToString Then
                qty_manipulated = qty_manipulated + " "
            End If

            'total qty
            If Not last_combine = data_det.Rows(i)("combine_number").ToString Then
                total_qty = total_qty + Integer.Parse(data_det.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            data_det.Rows(i)("qty") = data_det.Rows(i)("qty") + qty_manipulated

            last_collie = data_det.Rows(i)("id_awbill").ToString
            last_combine = data_det.Rows(i)("combine_number").ToString
        Next

        GCList.DataSource = data_det

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString

        GVList.BestFitColumns()

        'controls
        If id_report_status = "" Then
            SLUE3PL.ReadOnly = False

            SBCancel.Enabled = False

            'BGenOffline.Visible = True
            'BGenOnline.Visible = True

            If id_del_manifest <> "0" Then
                SBCancel.Enabled = True
            End If

            SBPrint.Enabled = False
            SBPrePrint.Enabled = False
            SBSave.Enabled = True
            SBComplete.Enabled = True

            If Not id_del_manifest = "0" Then
                SLUE3PL.ReadOnly = True
                SLESubDistrict.ReadOnly = True
                SLEComp.ReadOnly = True
                SLEStoreGroup.ReadOnly = True
                TEOrderNumber.Enabled = False

                'BGenOffline.Visible = False
                'BGenOnline.Visible = False
                '
                SBPrint.Visible = False
                SBPrePrint.Visible = False
                SBSave.Visible = False
            End If
        Else 'engggak dipakai ini
            SLUE3PL.ReadOnly = True
            SLESubDistrict.ReadOnly = True
            SLEComp.ReadOnly = True
            SLEStoreGroup.ReadOnly = True
            TEOrderNumber.Enabled = False

            'BGenOffline.Visible = False
            'BGenOnline.Visible = False

            TERemarkDiff.Enabled = False
            TEAwb.Enabled = False

            SBCancel.Enabled = False
            SBPrint.Enabled = False
            SBPrePrint.Enabled = False
            SBSave.Enabled = False
            SBComplete.Enabled = False

            If id_report_status = "5" Then
                SBPrint.Enabled = False
                SBPrePrint.Enabled = False
            End If

        End If

        SBAttachement.Enabled = True

        If id_del_manifest = "0" Then
            SBPrePrint.Enabled = False
            SBAttachement.Enabled = False
        End If
    End Sub

    Sub save(ByVal type As String)
        '
        Dim order As String = ""
        Dim div_by As String = 1
        Try
            div_by = GridView4.GetFocusedRowCellValue("volume_divide_by").ToString()
        Catch ex As Exception

        End Try

        Try
            If SLEStoreGroup.EditValue.ToString = "64" Then 'ZA
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "75" Then 'BLI
                order = addSlashes(TEOrderNumber.Text)
            ElseIf SLEStoreGroup.EditValue.ToString = "76" Then 'VIOS
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "77" Then 'SHOPEE
                order = addSlashes(TEOrderNumber.Text)
            End If
        Catch ex As Exception
            order = addSlashes(TEOrderNumber.Text)
        End Try

        'check awb
        Dim qc As String = ""
        qc = "SELECT awbill_no FROM tb_wh_awbill WHERE awbill_no='" & addSlashes(TEAwb.Text) & "' AND id_report_status!=5
AND id_awbill NOT IN (SELECT id_awbill FROM tb_del_manifest_det WHERE id_del_manifest='" & id_del_manifest & "')
UNION ALL
SELECT awbill_no FROM tb_del_manifest WHERE awbill_no='" & addSlashes(TEAwb.Text) & "' AND id_report_status!=5 AND id_del_manifest!='" & id_del_manifest & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

        'Dim is_awb_ok As Boolean = True
        'Dim is_need_finalize As String = "2"
        'If SLEDelType.EditValue.ToString = "6" Then
        '    'If TEAwb.Text = "" And Not get_opt_sales_field("is_active_new_ws_del") = "1" Then
        '    '    is_awb_ok = False
        '    'ElseIf get_opt_sales_field("is_active_new_ws_del") = "1" And TEAwb.Text = "" Then
        '    '    is_need_finalize = "1"
        '    'End If
        '    If TEAwb.Text = "" Then
        '        is_awb_ok = False
        '    End If
        'Else
        '    If TEAwb.Text = "" Then
        '        is_awb_ok = False
        '    End If
        'End If

        'check payment wholese
        Dim is_need_finalize As String = "2"
        Dim is_finalize_complete As String = "2"
        Dim is_ok_payment As Boolean = True

        If Not type = "cancel" Then
            If SLEDelType.EditValue.ToString = "6" Then
                For i = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "paid").ToString = "2" Then
                        is_ok_payment = False
                        Exit For
                    End If
                Next
                is_need_finalize = "1"
                is_finalize_complete = "1"
            End If
        End If

        'check manifest
        If GVList.RowCount < 1 Then
            stopCustom("DO not found.")
        ElseIf TERemarkDiff.Visible = True And TERemarkDiff.Text = "" Then
            stopCustom("Please put remark why choose this 3PL.")
        ElseIf dtc.Rows.Count > 0 Then
            stopCustom("AWB number already used.")
        ElseIf Not is_ok_payment Then
            stopCustom("Some SDO payment not paid yet.")
        Else
            Dim continue_save As Boolean = True
            If type = "save" Or type = "cancel" Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to " + type + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    continue_save = True
                Else
                    continue_save = False
                End If
            End If

            If type = "cancel" Then
                'check first
                Dim qcsd As String = "SELECT * FROM tb_odm_sc_det WHERE id_del_manifest='" & id_del_manifest & "'"
                Dim dtsd As DataTable = execute_query(qcsd, -1, True, "", "", "", "")
                If dtsd.Rows.Count > 0 Then
                    warningCustom("Already scanned by security")
                Else
                    Dim query As String = ""

                    query = "UPDATE tb_wh_awbill awb
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
INNER JOIN tb_del_manifest_det dd ON dd.id_wh_awb_det=awbd.id_wh_awb_det
SET awb.id_del_type=NULL,awb.awbill_no='',awb.weight_calc=null WHERE dd.id_del_manifest = " + id_del_manifest
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE tb_del_manifest SET id_report_status=5,awbill_no='' WHERE id_del_manifest = " + id_del_manifest
                    execute_non_query(query, True, "", "", "", "")
                    query = "DELETE FROM tb_del_manifest_det WHERE id_del_manifest = " + id_del_manifest
                    execute_non_query(query, True, "", "", "", "")
                    '
                    Close()
                End If
            Else
                If continue_save Then
                    Dim query As String = ""

                    If id_del_manifest = "0" Then
                        query = "INSERT INTO tb_del_manifest (id_comp, created_date, created_by,is_ol_shop,id_comp_group,ol_order,id_store_offline,id_del_type, id_sub_district ,awbill_no, id_cargo,cargo_rate,cargo_min_weight,cargo_lead_time
,c_weight,c_tot_price,id_cargo_best,cargo_rate_best,cargo_min_weight_best,cargo_lead_time_best,mark_different,actual_weight,is_need_finalize,is_finalize_complete) 
VALUES (" + GVCargoRate.GetFocusedRowCellValue("id_cargo").ToString + ", NOW(), " + id_user + "
,'" + SLEOnlineShop.EditValue.ToString + "','" + SLEStoreGroup.EditValue.ToString + "','" + order + "','" + SLEComp.EditValue.ToString + "'
,'" + SLEDelType.EditValue.ToString + "','" + SLESubDistrict.EditValue.ToString + "',TRIM('" + addSlashes(TEAwb.Text) + "'),'" + GVCargoRate.GetFocusedRowCellValue("id_cargo").ToString + "','" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_rate").ToString) + "','" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_min_weight").ToString) + "','" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_lead_time").ToString) + "'
,'" + decimalSQL(TECWeight.EditValue.ToString) + "','" + decimalSQL(TETotalRate.EditValue.ToString) + "','" + GVCargoRate.GetRowCellValue(0, "id_cargo").ToString + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_rate").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_min_weight").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_lead_time").ToString) + "','" + addSlashes(TERemarkDiff.Text) + "','" + decimalSQL(TEActualWeight.EditValue.ToString) + "','" + is_need_finalize + "','" + is_finalize_complete + "'); SELECT LAST_INSERT_ID();"

                        id_del_manifest = execute_query(query, 0, True, "", "", "", "")
                    Else
                        'update
                        query = "UPDATE tb_del_manifest SET id_comp = " + GVCargoRate.GetFocusedRowCellValue("id_cargo").ToString + ", updated_date = NOW(), updated_by = " + id_user + ", id_report_status = " + If(type = "draft", "NULL", If(type = "complete", "6", "5")) + "
,id_del_type='" + SLEDelType.EditValue.ToString + "',id_sub_district='" + SLESubDistrict.EditValue.ToString + "' ,is_ol_shop='" + SLEOnlineShop.EditValue.ToString + "',id_comp_group='" + SLEStoreGroup.EditValue.ToString + "',ol_order='" + order + "',id_store_offline='" + SLEComp.EditValue.ToString + "'
,awbill_no=TRIM('" + addSlashes(TEAwb.Text) + "'),id_cargo='" + GVCargoRate.GetFocusedRowCellValue("id_cargo").ToString + "',cargo_rate='" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_rate").ToString) + "',cargo_min_weight='" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_min_weight").ToString) + "',cargo_lead_time='" + decimalSQL(GVCargoRate.GetFocusedRowCellValue("cargo_lead_time").ToString) + "'
,c_weight='" + decimalSQL(TECWeight.EditValue.ToString) + "',c_tot_price='" + decimalSQL(TETotalRate.EditValue.ToString) + "',id_cargo_best='" + GVCargoRate.GetRowCellValue(0, "id_cargo").ToString + "',cargo_rate_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_rate").ToString) + "',cargo_min_weight_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_min_weight").ToString) + "',cargo_lead_time_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_lead_time").ToString) + "',mark_different='" + addSlashes(TERemarkDiff.Text) + "',actual_weight='" + decimalSQL(TEActualWeight.EditValue.ToString) + "'
,is_need_finalize='" + is_need_finalize + "',is_finalize_complete='" + is_finalize_complete + "'
WHERE id_del_manifest = " + id_del_manifest
                        execute_non_query(query, True, "", "", "", "")

                        'delete
                        query = "DELETE FROM tb_del_manifest_det WHERE id_del_manifest = " + id_del_manifest
                        execute_non_query(query, True, "", "", "", "")
                    End If

                    'detail
                    query = "INSERT INTO tb_del_manifest_det (id_del_manifest, id_wh_awb_det) VALUES "

                    For i = 0 To GVList.RowCount - 1
                        If GVList.IsValidRowHandle(i) Then
                            query += "(" + id_del_manifest + ", " + GVList.GetRowCellValue(i, "id_wh_awb_det").ToString + "), "
                        End If
                    Next

                    query = query.Substring(0, query.Length - 2)

                    execute_non_query(query, True, "", "", "", "")

                    'Update AWB
                    query = "UPDATE tb_wh_awbill awb 
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_awbill`=awb.`id_awbill`
INNER JOIN `tb_del_manifest_det` dmd ON dmd.`id_wh_awb_det`=awbd.`id_wh_awb_det`
INNER JOIN tb_del_manifest dm ON dm.id_del_manifest=dmd.`id_del_manifest`
SET awb.`awbill_no`=dm.`awbill_no`,awb.id_del_type=dm.id_del_type,awb.weight_calc=ROUND((awb.length*awb.width*awb.height)/" & div_by & ",2)
,awb.c_weight=IF(ROUND((awb.length*awb.width*awb.height)/" & div_by & ",2)>awb.weight,ROUND((awb.length*awb.width*awb.height)/" & div_by & ",2),awb.weight)
,awb.id_sub_district=dm.id_sub_district
WHERE dmd.`id_del_manifest`='" & id_del_manifest & "'"
                    execute_non_query(query, True, "", "", "", "")
                    '
                    execute_non_query("CALL gen_number(" + id_del_manifest + ", '232')", True, "", "", "", "")

                    If type = "save" Then
                        form_load()
                    Else
                        Close()
                    End If
                End If
            End If
        End If

        'If SLUE3PL.EditValue.ToString = "0" Then
        '    stopCustom("Please select 3PL.")
        'ElseIf GVList.RowCount < 1 Then
        '    stopCustom("Please add delivery.")
        'Else
        '    Dim continue_save As Boolean = True

        '    If type = "complete" Or type = "cancel" Then
        '        Dim confirm As DialogResult

        '        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to " + type + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            continue_save = True
        '        Else
        '            continue_save = False
        '        End If
        '    End If

        '    If continue_save Then
        '        Dim query As String = ""

        '        If id_del_manifest = "0" Then
        '            query = "INSERT INTO tb_del_manifest (id_comp, created_date, created_by) VALUES (" + SLUE3PL.EditValue.ToString + ", NOW(), " + id_user + "); SELECT LAST_INSERT_ID();"

        '            id_del_manifest = execute_query(query, 0, True, "", "", "", "")
        '        Else
        '            'update
        '            query = "UPDATE tb_del_manifest SET id_comp = " + SLUE3PL.EditValue.ToString + ", updated_date = NOW(), updated_by = " + id_user + ", id_report_status = " + If(type = "draft", "NULL", If(type = "complete", "6", "5")) + " WHERE id_del_manifest = " + id_del_manifest

        '            execute_non_query(query, True, "", "", "", "")

        '            'delete
        '            query = "DELETE FROM tb_del_manifest_det WHERE id_del_manifest = " + id_del_manifest

        '            execute_non_query(query, True, "", "", "", "")
        '        End If

        '        'detail
        '        query = "INSERT INTO tb_del_manifest_det (id_del_manifest, id_wh_awb_det) VALUES "

        '        For i = 0 To GVList.RowCount - 1
        '            If GVList.IsValidRowHandle(i) Then
        '                query += "(" + id_del_manifest + ", " + GVList.GetRowCellValue(i, "id_wh_awb_det").ToString + "), "
        '            End If
        '        Next

        '        query = query.Substring(0, query.Length - 2)

        '        execute_non_query(query, True, "", "", "", "")

        '        execute_non_query("CALL gen_number(" + id_del_manifest + ", '232')", True, "", "", "", "")

        '        If type = "draft" Then
        '            form_load()
        '        Else
        '            Close()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub GVList_RowCountChanged(sender As Object, e As EventArgs) Handles GVList.RowCountChanged
        'manipulate numbering, merge qty & total qty
        Dim last_collie As String = ""
        Dim last_combine As String = ""

        Dim total_qty As Integer = 0

        Dim qty_manipulated As String = ""

        Dim no As Integer = 1

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If i = 0 Then
                    last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString
                    last_combine = GVList.GetRowCellValue(i, "combine_number").ToString

                    total_qty = total_qty + Integer.Parse(GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                'numbering & merge qty
                If Not last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString Then
                    qty_manipulated = qty_manipulated + " "

                    no = no + 1
                End If

                'total qty
                If Not last_combine = GVList.GetRowCellValue(i, "combine_number").ToString Then
                    total_qty = total_qty + Integer.Parse(GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                GVList.SetRowCellValue(i, "qty", GVList.GetRowCellValue(i, "qty").ToString.Replace(" ", "") + qty_manipulated)

                GVList.SetRowCellValue(i, "no", no)

                last_collie = GVList.GetRowCellValue(i, "id_awbill").ToString
                last_combine = GVList.GetRowCellValue(i, "combine_number").ToString
            End If
        Next

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        print("2")
    End Sub

    Private Sub SBAttachement_Click(sender As Object, e As EventArgs) Handles SBAttachement.Click
        Cursor = Cursors.WaitCursor

        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_del_manifest WHERE id_del_manifest = " + id_del_manifest + "), 0) AS id_report_status", 0, True, "", "", "", "")

        FormDocumentUpload.is_no_delete = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.is_view = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.id_report = id_del_manifest
        FormDocumentUpload.report_mark_type = "232"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormDelManifestDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            'FormDelManifest.form_load()

            'If Not id_del_manifest = "0" Then
            '    FormDelManifest.GVList.FocusedRowHandle = find_row(FormDelManifest.GVList, "id_del_manifest", id_del_manifest)
            'End If
        Catch ex As Exception
        End Try
        Dispose()
    End Sub

    Private Sub SBPrePrint_Click(sender As Object, e As EventArgs) Handles SBPrePrint.Click
        Cursor = Cursors.WaitCursor

        If compare_database() Then
            print("1")
        Else
            stopCustom("Please save changes first.")
        End If

        Cursor = Cursors.Default
    End Sub

    Sub print(ByVal id_pre As String)
        Dim id_group As List(Of String) = New List(Of String)

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                If Not id_group.Contains(GVList.GetRowCellValue(i, "id_comp_group").ToString) Then
                    id_group.Add(GVList.GetRowCellValue(i, "id_comp_group").ToString)
                End If
            End If
        Next

        Dim on_hold As Boolean = False

        If id_pre = "2" Then
            For i = 0 To id_group.Count - 1
                'chek invoice
                Dim del As New ClassSalesDelOrder()

                If is_block_del_store = "1" And del.checkUnpaidInvoice(id_group(i)) Then
                    on_hold = True
                End If
            Next
        End If

        If on_hold Then
            stopCustom("Hold delivery")
        Else
            Dim data_view As DataView = New DataView(GCList.DataSource)

            data_view.Sort = "comp_number ASC, id_awbill ASC, awbill_no ASC, combine_number ASC"

            Dim report As ReportDelManifest = New ReportDelManifest

            report.id_del_manifest = id_del_manifest
            report.id_pre = id_pre
            report.dt = data_view.ToTable

            report.XrLabelNumber.Text = TENumber.Text
            report.XrLabel3PL.Text = SLUE3PL.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub

    Function compare_database() As Boolean
        Dim query As String = "
            SELECT *
            FROM (
                SELECT 0 AS no, mdet.id_wh_awb_det, c.id_comp_group, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
                FROM tb_del_manifest_det AS mdet
                LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
                LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
                LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
                LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
                LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
                LEFT JOIN (
	                SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	                FROM tb_pl_sales_order_del_det AS z1
	                LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	                LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	                GROUP BY z2.id_combine
                ) AS z ON pdelc.combine_number = z.combine_number
                WHERE mdet.id_del_manifest = " + id_del_manifest + "
            ) AS tb
            ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim match As Boolean = True

        For i = 0 To data.Rows.Count - 1
            Dim getin As Boolean = False

            For j = 0 To GVList.RowCount - 1
                If GVList.IsValidRowHandle(j) Then
                    If data.Rows(i)("id_wh_awb_det").ToString = GVList.GetRowCellValue(j, "id_wh_awb_det").ToString Then
                        getin = True
                    End If
                End If
            Next

            If Not getin Then
                match = False
            End If
        Next

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                Dim getin As Boolean = False

                For j = 0 To data.Rows.Count - 1
                    If GVList.GetRowCellValue(i, "id_wh_awb_det").ToString = data.Rows(j)("id_wh_awb_det").ToString Then
                        getin = True
                    End If
                Next

                If Not getin Then
                    match = False
                End If
            End If
        Next

        Return match
    End Function

    Private Sub SLEOnlineShop_EditValueChanged(sender As Object, e As EventArgs) Handles SLEOnlineShop.EditValueChanged
        online_pc_changed()
    End Sub

    Sub online_pc_changed()
        If SLEDelType.EditValue.ToString = "6" And SLEOnlineShop.EditValue.ToString = "1" Then
            warningCustom("Please pick online type no.")
            SLEOnlineShop.EditValue = "2"
        Else
            If SLEOnlineShop.EditValue.ToString = "1" Then
                PCOnline.Visible = True
                PCOffline.Visible = False
                TEOrderNumber.Focus()
            ElseIf SLEOnlineShop.EditValue.ToString = "2" Then
                PCOnline.Visible = False
                PCOffline.Visible = True
                TEComp.Focus()
            End If
        End If
    End Sub

    Sub gen_online()
        Dim order As String = ""

        Try
            If SLEStoreGroup.EditValue.ToString = "64" Then 'ZA
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "75" Then 'BLI
                order = addSlashes(TEOrderNumber.Text)
            ElseIf SLEStoreGroup.EditValue.ToString = "76" Then 'VIOS
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "77" Then 'SHOPEE
                order = addSlashes(TEOrderNumber.Text)
            End If
        Catch ex As Exception
            order = addSlashes(TEOrderNumber.Text)
        End Try

        Dim q As String = "SELECT 0 AS `no`,awb.id_sub_district,awb.ol_number,awbd.id_wh_awb_det,c.id_comp_group,awb.`awbill_date`,awb.`id_awbill`,IFNULL(pdelc.combine_number, awbd.do_no) AS combine_number,awbd.`do_no`,pl.`pl_sales_order_del_number`,c.`comp_number`,c.`comp_name`
,CONCAT((ROUND(IF(pdelc.combine_number IS NULL, awbd.qty, z.qty), 0)), ' ') AS qty,so.`shipping_city` AS city,awb.weight, awb.width, awb.length, awb.height,awb.`weight_calc` AS volume
FROM tb_wh_awbill_det awbd
INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill` AND awb.`is_old_ways`=2 AND step=2 AND awb.`id_report_status`!=5 
INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del` AND pl.`id_report_status`!=5
LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pl.id_combine = pdelc.id_combine
LEFT JOIN (
	SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	FROM tb_pl_sales_order_del_det AS z1
	LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	GROUP BY z2.id_combine
) AS z ON pdelc.combine_number = z.combine_number
INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN (
    SELECT id_wh_awb_det 
    FROM `tb_del_manifest_det` deld 
    INNER JOIN tb_del_manifest del ON del.id_del_manifest=deld.id_del_manifest 
    AND (del.id_report_status!=5 OR ISNULL(del.id_report_status))
) tb_c ON tb_c.id_wh_awb_det=awbd.id_wh_awb_det
WHERE ISNULL(tb_c.id_wh_awb_det) AND c.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & order & "'
ORDER BY awbd.id_awbill ASC,awbd.id_pl_sales_order_del ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If GVList.RowCount > 0 Then
            'sub district
            load_sub_dsitrict_filter(" AND dis.id_sub_district='" & GVList.GetRowCellValue(0, "id_sub_district").ToString & "'")
            '
            load_cargo_rate()
            '
            SLEDelType.Properties.ReadOnly = True
            SLEOnlineShop.Properties.ReadOnly = True
            SLEStoreGroup.Properties.ReadOnly = True
            TEOrderNumber.Enabled = False
            '
            PCRate.Visible = True
            '
            TEAwb.Focus()
        Else
            FormError.LabelContent.Text = "Outbound number not found or already created"
            FormError.ShowDialog()
        End If
    End Sub

    Private Sub BGenOnline_Click(sender As Object, e As EventArgs) Handles BGenOnline.Click
        If SLEStoreGroup.EditValue.ToString = "76" And SLEDelType.EditValue.ToString = "7" Then 'VIOS tapi milih marketplace
            warningCustom("VIOS tidak menggunakan marketplace")
        Else
            gen_online()
        End If
    End Sub

    Sub gen_offline()
        Dim div_by As String = 1
        Try
            div_by = GridView4.GetFocusedRowCellValue("volume_divide_by").ToString()
        Catch ex As Exception

        End Try

        Dim q As String = "SELECT 0 AS `no`,awb.ol_number,awbd.id_wh_awb_det,c.id_comp_group,awb.`awbill_date`,awb.`id_awbill`,IFNULL(pdelc.combine_number, awbd.do_no) AS combine_number,awbd.`do_no`,pl.`pl_sales_order_del_number`,c.`comp_number`,c.`comp_name`
,CONCAT((ROUND(IF(pdelc.combine_number IS NULL, awbd.qty, z.qty), 0)), ' ') AS qty,ct.`city` AS city,awb.weight, awb.width, awb.length, awb.height
-- ,awb.`weight_calc` AS volume
,ROUND((awb.width* awb.length* awb.height)/" & div_by & ",2) AS volume
,c.id_sub_district
,IF(ISNULL(pl_release.id_pl_sales_order_del),IF(ISNULL(sp.id_sales_pos),2,IF(sp.netto>0,IF(IFNULL(rec.value,0)=0,2,1),1)),1) AS paid
FROM tb_wh_awbill_det awbd
INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill` AND awb.`is_old_ways`=2 AND step=2 AND awb.`id_report_status`!=5 
-- AND awb.id_del_type='" & SLEDelType.EditValue.ToString & "'
INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del` AND pl.`id_report_status`!=5
LEFT JOIN 
(
	SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`,sp.netto
	FROM tb_sales_pos sp
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
LEFT JOIN
(
    SELECT id_pl_sales_order_del
    FROM `tb_pl_sales_order_del_send`
)pl_release ON pl_release.id_pl_sales_order_del=pl.id_pl_sales_order_del
LEFT JOIN
(
	SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
	FROM tb_rec_payment_det rd 
	INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
	INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
	INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pl.id_combine = pdelc.id_combine
LEFT JOIN (
	SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	FROM tb_pl_sales_order_del_det AS z1
	LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	GROUP BY z2.id_combine
) AS z ON pdelc.combine_number = z.combine_number
INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_city ct ON ct.id_city=c.id_city
LEFT JOIN (
    SELECT id_wh_awb_det 
    FROM `tb_del_manifest_det` deld 
    INNER JOIN tb_del_manifest del ON del.id_del_manifest=deld.id_del_manifest 
    AND (del.id_report_status!=5 OR ISNULL(id_report_status))
) tb_c ON tb_c.id_wh_awb_det=awbd.id_wh_awb_det
WHERE c.`id_comp`='" & SLEComp.EditValue.ToString & "' AND ISNULL(tb_c.id_wh_awb_det)
ORDER BY awbd.id_awbill ASC,awbd.id_pl_sales_order_del ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()

        If GVList.RowCount > 0 Then
            'sub district
            load_sub_dsitrict_filter(" AND dis.id_sub_district='" & GVList.GetRowCellValue(0, "id_sub_district").ToString & "'")
            '
            load_cargo_rate()
            '
            SLEDelType.Properties.ReadOnly = True
            SLEOnlineShop.Properties.ReadOnly = True
            SLEComp.Properties.ReadOnly = True
            TEComp.Enabled = False
            '
            PCRate.Visible = True
            '
            TEAwb.Focus()
            '
            If SLEDelType.EditValue.ToString = "6" Then
                GCPayment.Visible = True
            End If
        Else
            FormError.LabelContent.Text = "Outbound number not found or already created"
            FormError.ShowDialog()
            TEComp.Text = ""
            TEComp.Focus()
        End If
    End Sub

    Private Sub BGenOffline_Click(sender As Object, e As EventArgs) Handles BGenOffline.Click
        gen_offline()
    End Sub
    '
    Sub load_cargo_rate()
        Dim berat_terpakai As Decimal = 0.00
        Dim berat_dim As Decimal = 0.00
        Dim berat_aktual As Decimal = 0.00
        '
        Dim order As String = ""

        Try
            If SLEStoreGroup.EditValue.ToString = "64" Then 'ZA
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "75" Then 'BLI
                order = addSlashes(TEOrderNumber.Text)
            ElseIf SLEStoreGroup.EditValue.ToString = "76" Then 'VIOS
                order = addSlashes(TEOrderNumber.Text.Split("-")(1))
            ElseIf SLEStoreGroup.EditValue.ToString = "77" Then 'SHOPEE
                order = addSlashes(TEOrderNumber.Text)
            End If
        Catch ex As Exception
            order = addSlashes(TEOrderNumber.Text)
        End Try
        '
        If id_del_manifest = "0" Then
            Dim q_weight As String = ""
            'get all awbill
            Dim id_awb As String = ""
            For i As Integer = 0 To GVList.RowCount - 1
                If Not i = 0 Then
                    id_awb += ","
                End If
                id_awb += GVList.GetRowCellValue(i, "id_awbill").ToString
            Next

            Dim div_by As String = 1
            Try
                div_by = GridView4.GetFocusedRowCellValue("volume_divide_by").ToString()
            Catch ex As Exception

            End Try

            If SLEOnlineShop.EditValue.ToString = "1" Then
                'online
                q_weight = "SELECT SUM(tb.weight) AS weight, tb.width, tb.length, tb.height,SUM(tb.volume) AS volume,SUM(tb.final) AS final
FROM 
(
	SELECT SUM(awb.weight) AS weight, awb.width, awb.length, awb.height, SUM(awb.`volume`) AS volume,SUM(IF(awb.weight>awb.volume,awb.weight,awb.volume)) AS final
	FROM (
        SELECT awb.id_awbill,awb.weight AS weight, awb.width, awb.length, awb.height
        ,ROUND((awb.width* awb.length*awb.height)/" & div_by & ",2) AS volume
        -- ,awb.`weight_calc` AS volume
        FROM tb_wh_awbill_det awbd
        INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill` AND awb.`is_old_ways`=2 AND step=2 AND awb.`id_report_status`!=5 AND awb.id_awbill IN (" & id_awb & ")
        INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del` AND pl.`id_report_status`!=5
        INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        WHERE c.`id_comp_group`='" & SLEStoreGroup.EditValue.ToString & "' AND so.`sales_order_ol_shop_number`='" & order & "'
        GROUP BY awb.`id_awbill`
        HAVING weight >= 0 
    )awb 
	GROUP BY awb.id_awbill
)tb "
            Else
                'offline
                q_weight = "SELECT SUM(tb.weight) AS weight, tb.width, tb.length, tb.height,SUM(tb.volume) AS volume,SUM(tb.final) AS final
FROM 
(
    SELECT SUM(awb.weight) AS weight, awb.width, awb.length, awb.height, SUM(awb.`volume`) AS volume,SUM(IF(awb.weight>awb.volume,awb.weight,awb.volume)) AS final
	FROM (
	    SELECT awb.id_awbill,awb.weight, awb.width, awb.length, awb.height
        ,ROUND((awb.width* awb.length*awb.height)/" & div_by & ",2) AS volume
        -- ,awb.`weight_calc` AS volume
	    FROM tb_wh_awbill_det awbd
	    INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill` AND awb.`is_old_ways`=2 AND step=2 AND awb.`id_report_status`!=5 AND awb.id_awbill IN (" & id_awb & ")
	    INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del` AND pl.`id_report_status`!=5
	    INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
	    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
	    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	    WHERE c.`id_comp`='" & SLEComp.EditValue.ToString & "'
	    GROUP BY awb.id_awbill
	    HAVING weight >= 0
    )awb 
	GROUP BY awb.id_awbill
)tb "
            End If


            Dim dt_weight As DataTable = execute_query(q_weight, -1, True, "", "", "", "")
            If dt_weight.Rows.Count > 0 Then
                berat_dim = Decimal.Parse(dt_weight.Rows(0)("volume").ToString)
                berat_aktual = Decimal.Parse(dt_weight.Rows(0)("weight").ToString)

                'If berat_dim > berat_aktual Then
                '    berat_terpakai = berat_dim
                'Else
                '    berat_terpakai = berat_aktual
                'End If

                berat_terpakai = Decimal.Parse(dt_weight.Rows(0)("final").ToString)

                Dim q As String = ""

                q = "SELECT rate.id_3pl_rate,rate.id_comp AS id_cargo,comp.comp_name AS cargo,rate.cargo_min_weight,rate.cargo_rate
, IF(" + decimalSQL(berat_terpakai.ToString) + " < rate.cargo_min_weight, rate.cargo_min_weight, ROUND(" + decimalSQL(berat_terpakai.ToString) + ")) AS weight
, IF(" + decimalSQL(berat_terpakai.ToString) + " < rate.cargo_min_weight, rate.cargo_min_weight, ROUND(" + decimalSQL(berat_terpakai.ToString) + ")) AS actual_weight
,(IF(" + decimalSQL(berat_terpakai.ToString) + " < rate.cargo_min_weight,rate.cargo_min_weight,ROUND(" + decimalSQL(berat_terpakai.ToString) + ")) * cargo_rate) AS amount
,rate.cargo_lead_time
,comp.awb_rank
FROM `tb_3pl_rate` AS rate
INNER JOIN tb_m_comp comp ON comp.id_comp=rate.id_comp
WHERE rate.id_sub_district='" + SLESubDistrict.EditValue.ToString + "' AND rate.is_active=1 AND rate.id_type=1 AND rate.id_del_type='" + SLEDelType.EditValue.ToString + "'
GROUP BY rate.id_comp
ORDER BY amount ASC,comp.awb_rank ASC"

                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCCargoRate.DataSource = dt
                GVCargoRate.BestFitColumns()
                viewSearchLookupQuery(SLUE3PL, q, "id_3pl_rate", "cargo", "id_3pl_rate")
                '
                TEActualWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("weight")
                TECWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("weight")
                TERate.EditValue = GVCargoRate.GetFocusedRowCellValue("cargo_rate")
                TETotalRate.EditValue = GVCargoRate.GetFocusedRowCellValue("amount")
            End If
        Else
            Dim q As String = ""
            q = "SELECT 1 AS id_3pl_rate,del.id_comp AS id_cargo,c.comp_name AS cargo,del.cargo_min_weight,del.cargo_rate
,del.`c_weight` AS weight
,del.actual_weight
,del.`c_tot_price` AS amount
,del.cargo_lead_time
,1 AS awb_rank
FROM tb_del_manifest del
INNER JOIN tb_m_comp c ON c.`id_comp`=del.`id_cargo`
WHERE del.id_del_manifest='" + id_del_manifest + "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCCargoRate.DataSource = dt
            GVCargoRate.BestFitColumns()
            viewSearchLookupQuery(SLUE3PL, q, "id_3pl_rate", "cargo", "id_3pl_rate")
            SLUE3PL.EditValue = "1"
            '
            TEActualWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("actual_weight")
            TECWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("weight")
            TERate.EditValue = GVCargoRate.GetFocusedRowCellValue("cargo_rate")
            TETotalRate.EditValue = GVCargoRate.GetFocusedRowCellValue("amount")
        End If
    End Sub

    Private Sub SLESubDistrict_EditValueChanged(sender As Object, e As EventArgs) Handles SLESubDistrict.EditValueChanged
        Try
            load_cargo_rate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        Try
            TEActualWeight.EditValue = SLUE3PL.Properties.View.GetFocusedRowCellValue("actual_weight")
            TECWeight.EditValue = SLUE3PL.Properties.View.GetFocusedRowCellValue("weight")
            TERate.EditValue = SLUE3PL.Properties.View.GetFocusedRowCellValue("cargo_rate")
            TETotalRate.EditValue = SLUE3PL.Properties.View.GetFocusedRowCellValue("amount")
            '
            If Not SLUE3PL.EditValue.ToString = GVCargoRate.GetRowCellValue(0, "id_3pl_rate").ToString Then
                TERemarkDiff.Visible = True
                LRemarkDiff.Visible = True
            Else
                TERemarkDiff.Visible = False
                LRemarkDiff.Visible = False
            End If
            '
            GVCargoRate.FocusedRowHandle = find_row(GVCargoRate, "id_3pl_rate", SLUE3PL.EditValue.ToString)
            '
            TERemarkDiff.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVCargoRate_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCargoRate.FocusedRowChanged
        SLUE3PL.EditValue = GVCargoRate.GetFocusedRowCellValue("id_3pl_rate").ToString
        '
        TEActualWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("actual_weight")
        TECWeight.EditValue = GVCargoRate.GetFocusedRowCellValue("weight")
        TERate.EditValue = GVCargoRate.GetFocusedRowCellValue("cargo_rate")
        TETotalRate.EditValue = GVCargoRate.GetFocusedRowCellValue("amount")
    End Sub

    Private Sub GVList_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVList.CellMerge
        If e.Column.FieldName = "qty" Or e.Column.FieldName = "combine_number" Or e.Column.FieldName = "city" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "comp_name" Then
            If GVList.GetRowCellValue(e.RowHandle1, "combine_number").ToString = GVList.GetRowCellValue(e.RowHandle2, "combine_number").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        Else
            If GVList.GetRowCellValue(e.RowHandle1, "id_awbill").ToString = GVList.GetRowCellValue(e.RowHandle2, "id_awbill").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BBRemove_Click(sender As Object, e As EventArgs) Handles BBRemove.Click
        If GVList.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to remove this koli ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_awb As String = GVList.GetFocusedRowCellValue("id_awbill").ToString
                For i = GVList.RowCount - 1 To 0 Step -1
                    If GVList.GetRowCellValue(i, "id_awbill").ToString = id_awb Then
                        GVList.DeleteRow(i)
                    End If
                Next
                load_cargo_rate()
            End If
        End If
    End Sub

    Private Sub TEOrderNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOrderNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            gen_online()
            TEAwb.Focus()
        End If
    End Sub

    Private Sub TEComp_KeyUp(sender As Object, e As KeyEventArgs) Handles TEComp.KeyUp
        If e.KeyCode = Keys.Enter Then
            '
            Dim qc As String = "SELECT c.*,cg.is_wholesale FROM tb_m_comp c INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.id_comp_group WHERE c.comp_number='" & addSlashes(TEComp.Text) & "' AND c.id_comp_cat='6'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                '
                If dtc.Rows(0)("is_wholesale").ToString = "1" And Not SLEDelType.EditValue.ToString = "6" Then
                    'wholesale tapi gk milih tipe pengiriman wholesale
                    warningCustom("Please choose wholesale delivery type")
                Else
                    SLEComp.EditValue = dtc.Rows(0)("id_comp").ToString
                    gen_offline()
                End If
            Else
                FormError.LabelContent.Text = "Store not found."
                FormError.ShowDialog()
                TEComp.Text = ""
                TEComp.Focus()
            End If
            '
            If SLEDelType.EditValue.ToString = "6" Then 'wholesale
                'TEAwb.EditValue = GVList.GetRowCellValue(0, "ol_number").ToString
                'TEAwb.ReadOnly = True
                'If get_opt_sales_field("is_active_new_ws_del") = "1" Then
                '    'bisa ketik
                '    TEAwb.EditValue = ""
                '    TEAwb.ReadOnly = True
                'Else

                'End If
                TEAwb.EditValue = ""
                TEAwb.ReadOnly = False
            Else
                TEAwb.EditValue = ""
                TEAwb.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub SLEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDelType.EditValueChanged
        If loaded = True Then
            If SLEDelType.EditValue.ToString = "6" And SLEOnlineShop.EditValue.ToString = "1" Then
                warningCustom("Please pick online type no.")
                SLEOnlineShop.EditValue = "2"
            Else

            End If

            If SLEOnlineShop.EditValue.ToString = "1" Then
                TEOrderNumber.Focus()
            ElseIf SLEOnlineShop.EditValue.ToString = "2" Then
                TEComp.Focus()
            End If
        End If
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        TEOrderNumber.Focus()
    End Sub

    Private Sub TEAwb_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAwb.KeyDown
        'If Not SLEDelType.EditValue.ToString = "6" Then 'wholesale
        '    cforKeyDown = ChrW(e.KeyCode)
        'End If
    End Sub

    Private Sub TEAwb_KeyUp(sender As Object, e As KeyEventArgs) Handles TEAwb.KeyUp
        'If Not SLEDelType.EditValue.ToString = "6" Then 'wholesale
        '    If Len(TEAwb.EditValue.ToString) > 1 Then
        '        If cforKeyDown <> ChrW(e.KeyCode) OrElse cforKeyDown = vbNullChar Then
        '            cforKeyDown = vbNullChar
        '            TEAwb.EditValue = ""
        '            Return
        '        End If

        '        Dim elapsed As TimeSpan = DateTime.Now - _lastKeystroke

        '        If elapsed.TotalMilliseconds > speed_barcode_read Then TEAwb.EditValue = ""

        '        If e.KeyCode = Keys.Enter And TEAwb.Text.Length > 0 Then
        '            'kalau ada run sesuatu disini 
        '        End If
        '    End If

        '    _lastKeystroke = DateTime.Now
        'End If
    End Sub

    Private Sub BCompleteWholesale_Click(sender As Object, e As EventArgs) Handles BCompleteWholesale.Click
        'hold delivery
        Dim err_hold As String = ""
        For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
            If Not GVList.IsGroupRow(i) Then
                Dim del As New ClassSalesDelOrder()
                If is_block_del_store = "1" And del.checkUnpaidInvoice(GVList.GetRowCellValue(i, "id_comp_group").ToString) Then
                    err_hold += GVList.GetRowCellValue(i, "combine_number").ToString + " (" + GVList.GetRowCellValue(i, "comp_number").ToString + " - " + GVList.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        'store not active
        Dim err_not_active As String = ""
        For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
            If Not GVList.IsGroupRow(i) Then
                If GVList.GetRowCellValue(i, "is_active").ToString = "2" Then
                    err_not_active += GVList.GetRowCellValue(i, "combine_number").ToString + " (" + GVList.GetRowCellValue(i, "comp_number").ToString + " - " + GVList.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        'already closed
        Dim awb_already As Boolean = False
        Dim qawb As String = "SELECT * FROM `tb_del_manifest` WHERE id_del_manfiest='" & id_del_manifest & "' AND is_need_finalize=1 AND is_finalize_complete=2 AND id_report_status!=6 AND id_report_status!=5"
        Dim dtawb As DataTable = execute_query(qawb, -1, True, "", "", "", "")
        If Not dtawb.Rows.Count > 0 Then
            awb_already = True
        End If

        If err_hold <> "" Then
            warningCustom("Hold delivery : " + System.Environment.NewLine + err_hold)
        ElseIf err_not_active <> "" Then
            warningCustom("Store not active : " + System.Environment.NewLine + err_not_active)
        ElseIf awb_already Then
            warningCustom("Manifest already locked, please contact support.")
        Else
            'complete
            Try
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If

                For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing Order " & i + 1 & " of " & (GVList.RowCount - 1 - GetGroupRowCount(GVList)).ToString)
                    Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                    stt.changeStatus(GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "6")
                Next

                FormMain.SplashScreenManager1.CloseWaitForm()
                '
                Dim qu As String = "UPDATE tb_del_manifest SET is_finalize_complete=1 WHERE id_del_manfiest='" & id_del_manifest & "'"
                '
                infoCustom("Completed")
                Close()
            Catch ex As Exception
                'log scan security
                Dim qlog As String = "INSERT INTO tb_log_scan_security(reff,log_date,log_by,log) VALUES('" & id_del_manifest & "',NOW(),'" & id_user & "','" & addSlashes("Wholesale manifest complete error " & ex.ToString) & "')"
                execute_non_query(qlog, True, "", "", "", "")

                warningCustom(ex.ToString)
                FormMain.SplashScreenManager1.CloseWaitForm()
            End Try
        End If
    End Sub
End Class