Public Class FormSalesPOSNoStock
    Public id_menu As String = "-1"

    Private Sub FormSalesPOSNoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()

        Dim dnow As DateTime = getTimeDB()
        DEFrom.EditValue = dnow
        DEUntil.EditValue = dnow

        If id_menu = "1" Then 'F&A
            BtnAction.Visible = False
        ElseIf id_menu = "2" Then 'IA
            BtnAdd.Visible = False
        End If
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ns As New ClassSalesPOS()
        Dim query As String = ns.queryMainNoStock("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesPOSNoStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            'detail
            Cursor = Cursors.WaitCursor
            FormSalesPOSNoStockDet.action = "upd"
            FormSalesPOSNoStockDet.id = GVData.GetFocusedRowCellValue("id_sales_pos_no_stock").ToString
            FormSalesPOSNoStockDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesPOSNoStockDet.action = "ins"
        FormSalesPOSNoStockDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewData()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewDetail
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT nsd.id_sales_pos_no_stock_det, nsd.id_sales_pos_no_stock, 
        ns.`number`, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, ns.created_date, ns.created_by, nsemp.employee_name AS `created_by_name`, ns.period_from, ns.period_until,
        nsd.id_product, prod.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,
        nsd.qty, nsd.id_design_price, nsd.design_price, nsd.note, nsd.is_verified, nsd.verified_by, vemp.employee_name AS `verified_by_name`, nsd.verified_date, nsd.verified_note, 'No' AS `is_select`
        FROM tb_sales_pos_no_stock_det nsd
        INNER JOIN tb_sales_pos_no_stock ns ON ns.id_sales_pos_no_stock = nsd.id_sales_pos_no_stock
        INNER JOIN tb_m_product prod ON prod.id_product = nsd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        LEFT JOIN tb_m_user vu ON vu.id_user = nsd.verified_by
        LEFT JOIN tb_m_employee vemp ON vemp.id_employee = vu.id_employee
        INNER JOIN tb_m_user nsu ON nsu.id_user = ns.created_by
        INNER JOIN tb_m_employee nsemp ON nsemp.id_employee = nsu.id_employee
        INNER JOIN tb_m_comp c ON c.id_comp = ns.id_comp
        WHERE nsd.id_sales_pos_no_stock>0 AND ns.id_report_status!=5 AND (ns.period_until>='" + date_from_selected + "' AND ns.period_until<='" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class