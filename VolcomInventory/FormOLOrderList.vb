Public Class FormOLOrderList
    Private Sub FormOLOrderList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewData()
    End Sub


    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT 0 AS id_comp_group, 'ALL' AS comp_group, 'ALL GROUP' AS description
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_group As String = ""
        If SLECompGroup.EditValue.ToString <> "0" Then
            cond_group = "AND d.id_comp_group='" + SLECompGroup.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT a.sales_order_ol_shop_number,a.customer_name, a.sales_order_ol_shop_date, a.id_sales_order AS `id_sales_order_single`,GROUP_CONCAT(DISTINCT a.id_sales_order) AS `id_sales_order`,
        GROUP_CONCAT(DISTINCT a.sales_order_number) AS `sales_order_number`, a.id_comp_group, a.comp_group_desc, a.printed_date, a.printed_by,
        GROUP_CONCAT(DISTINCT a.tracking_code) AS `tracking_code`
        FROM (
	        SELECT a.id_sales_order, a.sales_order_number, a.sales_order_ol_shop_number, a.customer_name, a.sales_order_ol_shop_date, cg.id_comp_group,cg.comp_group, cg.description AS `comp_group_desc`,
	        CAST((IFNULL(dord_item.tot_do, 0.00)/IFNULL(so_item.tot_so,0.00)*100) AS DECIMAL(5,2)) AS so_completness,
	        IFNULL(pri.indeks_order,0) AS `indeks_order`, lp.printed_date, IFNULL(lp.printed_by,'-') AS `printed_by`, a.tracking_code
	        FROM tb_sales_order a 
	        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
	        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
	        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = d.id_comp_group
	        LEFT JOIN ( 
	          SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  
	          FROM tb_sales_order_det so_det 
	          INNER JOIN tb_sales_order so ON so.id_sales_order = so_det.id_sales_order
	          INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = so.id_store_contact_to 
	          INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
	          WHERE so.id_report_status=6 AND d.id_commerce_type=2
	          GROUP BY so_det.id_sales_order 
	        ) so_item ON so_item.id_sales_order = a.id_sales_order 
	        LEFT JOIN ( 
	          SELECT dord.id_sales_order, SUM(dord_det.pl_sales_order_del_det_qty) AS tot_do 
	          FROM tb_pl_sales_order_del_det dord_det 
	          INNER JOIN tb_pl_sales_order_del dord ON dord.id_pl_sales_order_del = dord_det.id_pl_sales_order_del 
	          INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = dord.id_store_contact_to
	          INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
	          WHERE dord.id_report_status!='5' AND d.id_commerce_type=2
	          GROUP BY dord.id_sales_order 
	        ) dord_item ON dord_item.id_sales_order = a.id_sales_order
	        LEFT JOIN tb_store_priority_order pri ON pri.id_comp = d.id_comp
            LEFT JOIN (
                SELECT a.id_sales_order, a.log_date AS `printed_date`, e.employee_name AS `printed_by` 
                FROM (
                SELECT * FROM tb_sales_order_log_print lp
                ORDER BY lp.log_date ASC
                ) a 
                INNER JOIN tb_m_user u ON u.id_user = a.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                GROUP BY a.id_sales_order
            ) lp ON lp.id_sales_order = a.id_sales_order 
	        WHERE a.id_sales_order>0 
	        AND a.id_so_status!=5 AND a.id_report_status='6' AND a.id_prepare_status='1' 
	        AND d.id_commerce_type=2 " + cond_group + "
	        HAVING so_completness<100
	        ORDER BY indeks_order ASC, id_sales_order ASC 
        ) a
        GROUP BY a.sales_order_ol_shop_number, a.tracking_code "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        viewData()
    End Sub

    Private Sub FormOLOrderList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DownloadShippingLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadShippingLabelToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        'check store
        Dim id_sod As String = GVData.GetFocusedRowCellValue("id_sales_order").ToString
        Dim id_cg As String = GVData.GetFocusedRowCellValue("id_comp_group").ToString

        If id_cg = "75" Then
            Dim item_id As String = execute_query("
                SELECT ol_store_id
                FROM tb_sales_order_det
                WHERE id_sales_order IN(" + id_sod + ")
                LIMIT 1
            ", 0, True, "", "", "", "")

            FormSalesOrderShippingLabelPdf.ol_store = "blibli"
            FormSalesOrderShippingLabelPdf.order_id = item_id

            FormSalesOrderShippingLabelPdf.ShowDialog()
        ElseIf id_cg = "64" Then
            Dim item_id As String = execute_query("
                SELECT item_id
                FROM tb_sales_order_det
                WHERE id_sales_order IN(" + id_sod + ")
                LIMIT 1
            ", 0, True, "", "", "", "")

            FormSalesOrderShippingLabelPdf.ol_store = "zalora"
            FormSalesOrderShippingLabelPdf.order_id = item_id

            FormSalesOrderShippingLabelPdf.ShowDialog()
        Else
            stopCustom("Not found.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub FileAttachmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileAttachmentToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDocumentUpload.report_mark_type = "39"
            FormDocumentUpload.id_report = GVData.GetFocusedRowCellValue("id_sales_order_single").ToString
            FormDocumentUpload.is_view = "1"
            FormDocumentUpload.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool
    Dim id_sor_selected As String = ""
    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            'cek sudah semua ke proses ato blm
            Dim qcek As String = "SELECT * FROM tb_ol_store_order od WHERE od.id_comp_group='" + GVData.GetFocusedRowCellValue("id_comp_group").ToString + "' AND od.sales_order_ol_shop_number='" + GVData.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString + "' AND od.is_process=2 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                Cursor = Cursors.Default
                stopCustom("Proses tidak bisa dilanjutkan karena masi proses sinkronisai order. Coba lagi beberapa saat")
                Exit Sub
            End If

            id_sor_selected = ""
            Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
            Dim rpt As New ReportSalesOrderNew()
            Dim id As String = GVData.GetFocusedRowCellValue("id_sales_order").ToString
            id_sor_selected = id
            Dim qso As String = "SELECT * FROM tb_sales_order so WHERE so.id_sales_order IN(" + id + ") "
            Dim dso As DataTable = execute_query(qso, -1, True, "", "", "", "")
            For i As Integer = 0 To dso.Rows.Count - 1
                ReportSalesOrderNew.id_sales_order = dso.Rows(i)("id_sales_order").ToString
                Dim Report As New ReportSalesOrderNew()
                'Grid Detail
                ReportStyleGridview(Report.GVItemList)

                Report.PrintingSystem.ContinuousPageNumbering = False
                Report.CreateDocument()

                For j = 0 To Report.Pages.Count - 1
                    list.Add(Report.Pages(j))
                Next
            Next
            rpt.Pages.AddRange(list)
            tool_detail = New DevExpress.XtraReports.UI.ReportPrintTool(rpt)
            AddHandler tool_detail.PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            tool_detail.ShowPreviewDialog()

            'refresh
            Dim sales_order_ol_shop_number As String = GVData.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
            viewData()
            GVData.FocusedRowHandle = find_row(GVData, "sales_order_ol_shop_number", sales_order_ol_shop_number)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub PrintingSystem_EndPrint(ByVal sender As Object, ByVal e As EventArgs)
        'insert log
        If id_sor_selected <> "" Then
            Dim query As String = "INSERT INTO tb_sales_order_log_print(id_sales_order, id_user, log_date) 
            SELECT so.id_sales_order, '" + id_user + "', NOW() 
            FROM tb_sales_order so WHERE so.id_sales_order IN(" + id_sor_selected + "); "
            execute_non_query(query, True, "", "", "", "")
        End If
        tool_detail.ClosePreview()
    End Sub
End Class