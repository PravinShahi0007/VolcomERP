Public Class FormProdDemandSize
    Public id As String = "-1"
    Public rmt As String = "-1"
    Public id_report_status As String = "-1"
    Public status As String = ""
    Public season As String = ""
    Public created_date As String = ""
    Public division As String = ""

    Private Sub FormProdDemandSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDetail()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.prod_demand_number,p.product_full_code AS `barcode`, d.design_code AS `code`, CONCAT(d.design_code,' - ', d.design_display_name) AS `design`, 
        cd.code_detail_name AS `size`, pdp.prod_demand_product_qty AS `qty`
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
        INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE pdd.id_prod_demand=" + id + " AND pdp.prod_demand_product_qty>0 AND pdd.is_void=2
        ORDER BY pdd.id_prod_demand_design ASC, cd.id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        LabelTitle.Text = data.Rows(0)("prod_demand_number").ToString
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdDemandSize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportProdDemandSize.dt = GCData.DataSource
        ReportProdDemandSize.id_prod_demand = id
        ReportProdDemandSize.is_pre = "-1"
        ReportProdDemandSize.is_hidden_mark = "1"
        ReportProdDemandSize.id_report_status = id_report_status

        ReportProdDemandSize.rmt = rmt
        Dim Report As New ReportProdDemandSize()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVData.OptionsPrint.UsePrintStyles = True
        Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        Report.GVData.AppearancePrint.HeaderPanel.BorderColor = Color.Black
        Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        Report.GVData.AppearancePrint.Lines.BackColor = Color.Black

        Report.GVData.OptionsPrint.ExpandAllDetails = True
        Report.GVData.OptionsPrint.UsePrintStyles = True
        Report.GVData.OptionsPrint.PrintDetails = True
        Report.GVData.OptionsPrint.PrintFooter = True


        Report.LabelNumber.Text = LabelTitle.Text
        Report.LabelDate.Text = created_date
        Report.LabelSeason.Text = season
        Report.LabelDivision.Text = division
        Report.LabelStatus.Text = Status

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub
End Class