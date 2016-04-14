Public Class FormViewSalesOrderGen
    Public action As String = "-1"
    Public id_sales_order_gen As String = "-1"
    Dim is_submit As String = "2"
    Public id_report_status As String = "-1"
    Public id_pre As String = "-1"

    Private Sub FormSalesOrderGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSoStatus()
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT a.id_so_status, a.so_status FROM tb_lookup_so_status a "
        query += "INNER JOIN tb_lookup_so_status_acc b ON a.id_so_status = b.id_so_status "
        query += "WHERE b.id_departement='" + id_departement_user + "' "
        query += "ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        GroupControlItemList.Enabled = True
        BtnAttachment.Enabled = True

        'query view based on edit id's
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMainGen("AND gen.id_sales_order_gen='" + id_sales_order_gen + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sales_order_gen = data.Rows(0)("id_sales_order_gen").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        TxtReff.Text = data.Rows(0)("sales_order_gen_reff").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_order_gen_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sales_order_gen_note").ToString
        is_submit = data.Rows(0)("is_submit").ToString

        TxtReff.Enabled = False
        BMark.Enabled = True
        LEStatusSO.Enabled = False

        'detail2
        viewDetail()
        check_but()
        allow_status()

        If id_pre = "1" Then
            prePrinting()
            Close()
        ElseIf id_pre = "2" Then
            printing()
            Close()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_order_gen(" + id_sales_order_gen + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data

        If is_submit = "2" Then
            'sum
            Dim query_sum As String = "CALL view_sales_order_gen_sum(" + id_sales_order_gen + ")"
            Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")

            Dim query_stock As String = "CALL view_sales_order_prod_list(0, 0, 0)"
            Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
            Dim tb1 = data_sum.AsEnumerable() 'sum
            Dim tb2 = data_stock.AsEnumerable() 'allow stock fo so

            Dim queryx = From sum In tb1 'left join sum dgn stock menjadi stockjoin
                         Group Join stc In tb2
                         On sum("code") Equals stc("product_full_code") And sum("id_comp_from") Equals stc("id_comp") Into stcjoin = Group
                         From resultstc In stcjoin.DefaultIfEmpty()
                         Select New With
                                {
                                    .code = sum("code").ToString,
                                    .id_product = If(resultstc Is Nothing, "", resultstc("id_product").ToString),
                                    .name = If(resultstc Is Nothing, "", resultstc("design_display_name").ToString),
                                    .size = If(resultstc Is Nothing, "", resultstc("Size").ToString),
                                    .comp_from = If(resultstc Is Nothing, "", resultstc("comp_number").ToString + " - " + resultstc("comp_name").ToString),
                                    .id_comp_from = If(resultstc Is Nothing, "", resultstc("id_comp").ToString),
                                    .id_comp_contact_from = If(resultstc Is Nothing, "", resultstc("id_comp_contact").ToString),
                                    .id_design_price = If(resultstc Is Nothing, "", resultstc("id_design_price").ToString),
                                    .design_price = If(resultstc Is Nothing, "", resultstc("design_price")),
                                    .sales_order_gen_det_qty = sum("sales_order_gen_det_qty"),
                                    .total_allow = If(resultstc Is Nothing, 0, resultstc("total_allow")),
                                    .note = If(resultstc Is Nothing Or sum("sales_order_gen_det_qty") > If(resultstc Is Nothing, 0, resultstc("total_allow")), If(resultstc Is Nothing, "This product is not available for prepare order; ", "") + If(sum("sales_order_gen_det_qty") > If(resultstc Is Nothing, 0, resultstc("total_allow")), "Qty can't exceed " + If(resultstc Is Nothing, 0, resultstc("total_allow")).ToString + ";", ""), "OK")
                                }

            GCSummary.DataSource = queryx.ToList()
            XTPSummary.PageVisible = True
            XTPOrder.PageVisible = False
        Else
            Dim view_reff As New ClassSalesOrder()
            view_reff.viewReff(id_sales_order_gen, "AND soa.sales_order_gen_reff=''" + TxtReff.Text.ToString + "'' ", GCNewPrepare, GVNewPrepare)
            XTPSummary.PageVisible = False
            XTPOrder.PageVisible = True
        End If
    End Sub

    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub allow_status()
        MENote.Enabled = False

        BtnAttachment.Enabled = True

        TxtReff.Focus()
    End Sub



    Private Sub FormFGWHAllocDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "88"
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_sales_order_gen
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "88"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_sales_order_gen
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        ReportFGWHAlloc.id_fg_wh_alloc = id_sales_order_gen
        ReportFGWHAlloc.dt = GCItemList.DataSource
        Dim Report As New ReportFGWHAlloc()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LabelCreated.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportFGWHAlloc.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportFGWHAlloc.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub GVNewPrepare_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNewPrepare.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class