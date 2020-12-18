Public Class FormSalesPosPriceRecon
    Public id As String = "-1"
    Public action As String = ""
    Dim rmt As String = "281"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "2"
    Dim is_view As String = ""

    Private Sub FormSalesPosPriceRecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub FormSalesPosPriceRecon_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'view
            Dim time_now As DateTime = getTimeDB()
            DECreated.EditValue = time_now
            viewDetail()

            'insert row
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            For d As Integer = 0 To FormSalesPOS.GVProbList.RowCount - 1
                Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                newRow("id_sales_pos_prob") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_sales_pos_prob").ToString
                newRow("id_sales_pos") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_sales_pos").ToString
                newRow("sales_pos_number") = FormSalesPOS.GVProbList.GetRowCellValue(d, "sales_pos_number").ToString
                newRow("comp_number") = FormSalesPOS.GVProbList.GetRowCellValue(d, "comp_number").ToString
                newRow("comp_name") = FormSalesPOS.GVProbList.GetRowCellValue(d, "comp_name").ToString
                newRow("id_product") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_product").ToString
                newRow("code") = FormSalesPOS.GVProbList.GetRowCellValue(d, "code").ToString
                newRow("name") = FormSalesPOS.GVProbList.GetRowCellValue(d, "name").ToString
                newRow("size") = FormSalesPOS.GVProbList.GetRowCellValue(d, "size").ToString
                newRow("id_design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(d, "id_design_price_retail").ToString
                newRow("design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_retail")
                newRow("design_price_store") = FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_store")
                Dim dt_prc As DataTable = getUsedPrice(FormSalesPOS.GVProbList.GetRowCellValue(d, "id_product").ToString, decimalSQL(FormSalesPOS.GVProbList.GetRowCellValue(d, "design_price_store").ToString))
                If dt_prc.Rows.Count > 0 Then
                    newRow("id_design_price_valid") = dt_prc.Rows(0)("id_design_price").ToString
                    newRow("design_price_valid") = dt_prc.Rows(0)("design_price")
                    newRow("note") = "OK"
                Else
                    newRow("id_design_price_valid") = "0"
                    newRow("design_price_valid") = 0.00
                    newRow("note") = "Price not found"
                End If
                TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                GCData.RefreshDataSource()
                GVData.RefreshData()
                GVData.BestFitColumns()
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
        ElseIf action = "upd" Then
            viewDetail()
            allowStatus()
        End If
    End Sub

    Function getUsedPrice(ByVal id_prod_par As String, ByVal price_par As String) As DataTable
        Dim query As String = "SELECT prc.id_design_price, prc.design_price 
        FROM tb_m_product p
        INNER JOIN tb_m_design_price prc ON prc.id_design = p.id_design
        WHERE p.id_product='" + id_prod_par + "' AND prc.design_price='" + price_par + "'
        ORDER BY prc.id_design_price DESC
        LIMIT 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "Select rd.id_sales_pos_recon_det, rd.id_sales_pos_recon,
        rd.id_sales_pos_prob, rd.id_sales_pos, sp.sales_pos_number, c.comp_number, c.comp_name,
        rd.id_product, p.product_full_code As `code`, p.product_display_name As `name`, cd.code_detail_name As `size`,
        rd.id_design_price_retail, rd.design_price_retail, rd.design_price_store,
        rd.id_design_price_valid, rd.design_price_valid, rd.note
        FROM tb_sales_pos_recon_det rd
        INNER JOIN tb_m_product p ON p.id_product = rd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_sales_pos
        INNER JOIN tb_m_comp c ON c.id_comp = rd.id_comp
        WHERE rd.id_sales_pos_recon='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()

    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If action = "ins" Then
            makeSafeGV(GVData)
            GVData.ActiveFilterString = "[note]<>'OK'"
            Dim cond_ok As Boolean = True
            If GVData.RowCount > 0 Then
                cond_ok = False
            End If
            makeSafeGV(GVData)

            If Not cond_ok Then
                stopCustom("There is price not valid")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    'save
                    'refresh main
                    'refresh det
                End If
            End If
        Else

        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click

    End Sub

    Sub showAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class