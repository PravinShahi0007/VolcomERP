Public Class FormViewBOM
    Public id_bom As String = "-1"
    Public id_product As String = "-1"
    Public nama_product As String = "-1"
    Public mark As Boolean = True

    Public id_bom_approve As String = "-1"

    Private Sub FormViewBOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CEMat.ValueChecked = Convert.ToSByte(1)
        CEMat.ValueUnchecked = Convert.ToSByte(2)
        '
        CEOVH.ValueChecked = Convert.ToSByte(1)
        CEOVH.ValueUnchecked = Convert.ToSByte(2)

        view_term(LETerm)
        view_report_status(LEReportStatus)

        view_currency(LECurrency)
        '
        Dim query As String = String.Format("SELECT * FROM tb_bom WHERE id_bom = '{0}'", id_bom)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_product = data.Rows(0)("id_product").ToString
        LabelProductCode.Text = get_product_x(data.Rows(0)("id_product").ToString, "2") & "-" & get_product_x(data.Rows(0)("id_product").ToString, "1")
        Dim bom_name As String = data.Rows(0)("bom_name").ToString
        Dim id_term_production As String = data.Rows(0)("id_term_production").ToString

        data.Dispose()

        TEName.Text = bom_name
        LETerm.EditValue = Nothing
        LETerm.ItemIndex = LETerm.Properties.GetDataSourceRowIndex("id_term_production", id_term_production)

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        view_bom_det(id_bom)
        view_bom_ovh(id_bom)
        view_bom_wip(id_bom)

        'calculate_unit_price()
        TEUnitPrice.Text = Decimal.Parse(data.Rows(0)("bom_unit_price")).ToString("N2")

        GroupComponent.Enabled = True

        If mark = False Then
            BMark.Visible = False
        Else
            BMark.Visible = True
        End If
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Sub view_bom_det(ByVal id_bom As String)
        Try
            Dim query As String
            query = "CALL view_bom_mat(" & id_bom & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            GVBomDetMat.BestFitColumns()
            calculate_unit_price()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_term(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_term_production,term_production FROM tb_lookup_term_production"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "term_production"
        lookup.Properties.ValueMember = "id_term_production"
        lookup.ItemIndex = 0
    End Sub
    Sub view_bom_ovh(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_ovh(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data
            GVBomDetOvh.BestFitColumns()
            calculate_unit_price()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_bom_wip(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_product(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetWip.DataSource = data
            calculate_unit_price()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub calculate_unit_price()
        Dim mat, ovh, wip, total As Decimal
        Try
            mat = Decimal.Parse(GVBomDetMat.Columns("total").SummaryText.ToString)
            ovh = Decimal.Parse(GVBomDetOvh.Columns("total").SummaryText.ToString)
            wip = Decimal.Parse(GVBomDetWip.Columns("total").SummaryText.ToString)
        Catch ex As Exception
        End Try

        total = mat + ovh + wip

        TEUnitPrice.Text = total.ToString("N2")
    End Sub
    'Sub allow_status()
    '    If check_print_report_status(LEReportStatus.EditValue.ToString) Then
    '        Bprint.Enabled = True
    '    Else
    '        Bprint.Enabled = False
    '    End If
    'End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        If id_bom_approve = "-1" Then
            FormReportMark.id_report = id_bom
            FormReportMark.is_view = "1"
            FormReportMark.report_mark_type = "8"
            FormReportMark.ShowDialog()
        Else
            FormReportMark.form_origin = "FormViewBOM"
            FormReportMark.is_view = "1"
            FormReportMark.id_report = id_bom_approve
            FormReportMark.report_mark_type = "79"
            FormReportMark.ShowDialog()
        End If
    End Sub

    'Private Sub Bprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bprint.Click
    '    '
    '    ReportBOM.id_bom = id_bom
    '    ReportBOM.product_name = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " " & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString
    '    ReportBOM.bom_name = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_name").ToString
    '    ReportBOM.bom_date = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_date_created").ToString
    '    ReportBOM.bom_term = FormBOM.GVBOM.GetFocusedRowCellDisplayText("term_production").ToString

    '    Dim Report As New ReportBOM()
    '    ' Show the report's preview. 
    '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
    '    Tool.ShowPreview()
    'End Sub
    Private Sub FormViewBOM_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class