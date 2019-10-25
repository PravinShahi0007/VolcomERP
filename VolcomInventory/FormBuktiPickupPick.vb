Public Class FormBuktiPickupPick
    Private Sub FormBuktiPickupPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                where_not_in += where_not_in + FormBuktiPickupDet.GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString + ","
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
        Dim where_store As String = If(SLUECompany.EditValue.ToString = "0", "", "AND d.id_comp = " + SLUECompany.EditValue.ToString)

        'query
        Dim salesdelorder As ClassSalesDelOrder = New ClassSalesDelOrder()

        Dim query As String = salesdelorder.queryMain(" AND a.id_pl_sales_order_del NOT IN (" + where_not_in + ") AND (a.pl_sales_order_del_date >= '" + date_from + "' AND a.pl_sales_order_del_date <= '" + date_to + "') AND a.id_report_status = 6 " + where_store, "1")

        query = "SELECT 'no' AS is_select," + query.Substring(6, query.Length - 6)

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
                        GVList.GetRowCellValue(i, "pl_sales_order_del_number"),
                        GVList.GetRowCellValue(i, "combine_number"),
                        GVList.GetRowCellValue(i, "wh"),
                        GVList.GetRowCellValue(i, "store"),
                        GVList.GetRowCellValue(i, "comp_group"),
                        GVList.GetRowCellValue(i, "sales_order_number"),
                        GVList.GetRowCellValue(i, "sales_order_ol_shop_number"),
                        GVList.GetRowCellValue(i, "so_status"),
                        GVList.GetRowCellValue(i, "total_remaining"),
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

    Sub view_comp()
        Dim query As String = "(SELECT 0 AS id_comp, 'All Store' AS comp_name) UNION ALL(SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name FROM tb_m_comp WHERE id_comp_cat = 6)"

        viewSearchLookupQuery(SLUECompany, query, "id_comp", "comp_name", "id_comp")
    End Sub
End Class