﻿Public Class FormBuktiPickupPick
    Private Sub FormBuktiPickupPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp_group()
        view_comp()

        SLUECompany.EditValue = 0
        DEFrom.EditValue = Date.Parse(Now)
        DEUntil.EditValue = Date.Parse(Now)
    End Sub

    Private Sub FormBuktiPickupPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Cursor = Cursors.WaitCursor

        Dim date_from As String = Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_to As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        'check already pickup
        Dim where_not_in As String = "0,"

        'list
        FormBuktiPickupDet.GVList.ApplyFindFilter("")

        FormBuktiPickupDet.GVList.ActiveFilterString = ""

        For i = 0 To FormBuktiPickupDet.GVList.RowCount - 1
            If FormBuktiPickupDet.GVList.IsValidRowHandle(i) Then
                where_not_in += FormBuktiPickupDet.GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString + ","
            End If
        Next

        'database
        where_not_in += execute_query("
            SELECT CONCAT(IFNULL(GROUP_CONCAT(pickup_det.id_pl_sales_order_del), 0), ',')
            FROM tb_del_pickup_det AS pickup_det
            LEFT JOIN tb_del_pickup AS pickup ON pickup_det.id_pickup = pickup.id_pickup
            WHERE pickup.id_pickup <> " + FormBuktiPickupDet.id_pickup + " AND pickup.id_report_status <> 5
        ", 0, True, "", "", "", "")

        'trim last ,
        where_not_in = where_not_in.Substring(0, where_not_in.Length - 1)

        'store
        Dim where_group As String = If(SLUEGroup.EditValue.ToString = "0", "", "AND d.id_comp_group = " + SLUEGroup.EditValue.ToString)
        Dim where_store As String = If(SLUECompany.EditValue.ToString = "0", "", "AND d.id_comp = " + SLUECompany.EditValue.ToString)

        'query
        Dim query As String = "
            SELECT 'no' AS is_select,odph.number AS number_odp, a.id_pl_sales_order_del, a.pl_sales_order_del_number, IFNULL(comb.combine_number, '-') AS combine_number, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS wh, CONCAT(d.comp_number, ' - ', d.comp_name) AS store, dg.comp_group, b.sales_order_number, b.sales_order_ol_shop_number, cat.so_status, IFNULL(det.total, 0) AS total, a.pl_sales_order_del_date, b.tracking_code
            FROM tb_pl_sales_order_del AS a
            INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order
            INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
            INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp
            INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from 
            INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp
            LEFT JOIN (
                SELECT del.id_pl_sales_order_del, SUM(det.pl_sales_order_del_det_qty) AS total 
                FROM tb_pl_sales_order_del del 
                INNER JOIN tb_pl_sales_order_del_det det ON del.id_pl_sales_order_del = det.id_pl_sales_order_del 
                GROUP BY del.id_pl_sales_order_del 
            ) det ON det.id_pl_sales_order_del = a.id_pl_sales_order_del
            LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = a.id_combine
            INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status
            LEFT JOIN tb_m_comp_group dg ON d.id_comp_group = dg.id_comp_group
            LEFT JOIN tb_wh_awbill_det awbd ON awbd.id_pl_sales_order_del=a.id_pl_sales_order_del
            LEFT JOIN tb_del_manifest_det dd ON dd.id_wh_awb_det=awbd.id_wh_awb_det
            LEFT JOIN tb_odm_sc_det od ON od.id_del_manifest=dd.id_del_manifest
            LEFT JOIN tb_odm_print_det odp ON odp.id_odm_sc=od.id_odm_sc
            LEFT JOIN tb_odm_print odph ON odph.id_odm_print=odp.id_odm_print
            WHERE a.id_pl_sales_order_del NOT IN (" + where_not_in + ") AND (a.pl_sales_order_del_date >= '" + date_from + "' AND a.pl_sales_order_del_date <= '" + date_to + "') AND (a.id_report_status = 3 OR a.id_report_status=6) " + where_group + " " + where_store + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVList.ApplyFindFilter("")

        GVList.ActiveFilterString = "[is_select] = 'yes'"

        If GVList.RowCount <= 0 Then
            errorCustom("No delivery selected")
        Else
            Dim data As DataTable = FormBuktiPickupDet.GCList.DataSource

            For i = 0 To GVList.RowCount - 1
                If GVList.IsValidRowHandle(i) Then
                    data.Rows.Add(
                        GVList.GetRowCellValue(i, "id_pl_sales_order_del"),
                        0,
                        GVList.GetRowCellValue(i, "pl_sales_order_del_number"),
                        GVList.GetRowCellValue(i, "combine_number"),
                        GVList.GetRowCellValue(i, "wh"),
                        GVList.GetRowCellValue(i, "store"),
                        GVList.GetRowCellValue(i, "comp_group"),
                        GVList.GetRowCellValue(i, "sales_order_number"),
                        GVList.GetRowCellValue(i, "sales_order_ol_shop_number"),
                        GVList.GetRowCellValue(i, "so_status"),
                        GVList.GetRowCellValue(i, "total"),
                        Date.Parse(GVList.GetRowCellValue(i, "pl_sales_order_del_date"))
                    )
                End If
            Next

            FormBuktiPickupDet.GCList.DataSource = data

            FormBuktiPickupDet.GVList.BestFitColumns()

            Close()
        End If

        GVList.ActiveFilterString = ""
    End Sub

    Sub view_comp_group()
        Dim query As String = "(SELECT 0 AS id_comp_group, 'All Group' AS comp_group) UNION ALL (SELECT id_comp_group, CONCAT(comp_group, ' - ', description) AS comp_group FROM tb_m_comp_group)"

        viewSearchLookupQuery(SLUEGroup, query, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Sub view_comp()
        Dim where_group As String = If(SLUEGroup.EditValue.ToString = "0", "", "AND id_comp_group = " + SLUEGroup.EditValue.ToString)

        Dim query As String = "(SELECT 0 AS id_comp, 'All Store' AS comp_name) UNION ALL (SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name FROM tb_m_comp WHERE id_comp_cat = 6 " + where_group + ")"

        viewSearchLookupQuery(SLUECompany, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        For i = 0 To GVList.RowCount - 1
            If CESelectAll.EditValue Then
                GVList.SetRowCellValue(i, "is_select", "yes")
            Else
                GVList.SetRowCellValue(i, "is_select", "no")
            End If
        Next
    End Sub

    Private Sub SLUEGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEGroup.EditValueChanged
        view_comp()
    End Sub
End Class