Public Class FormSamplePrintBarcode 

    Private Sub FormSamplePrintBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample()
        view_price()
    End Sub
    Sub view_sample()
        Try
            Dim query As String = "CALL view_sample_barcode('2')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSample.DataSource = data
            GVSample.BestFitColumns()
            If data.Rows.Count < 1 Then
                GVSample.FocusedRowHandle = 0
                'hide all except new
                checkFormAccess(Name)
            Else
                'show all
                GVSample.FocusedRowHandle = 0
                checkFormAccess(Name)
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub view_price()
        Dim query As String = "SELECT price.id_sample_ret_price as id_sample_ret_price,price.id_sample as id_sample,price.sample_ret_price_name,price.sample_ret_price,cur.currency FROM tb_m_sample_ret_price price "
        query += " INNER JOIN tb_lookup_currency cur ON cur.id_currency=price.id_currency "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RSLEPrice.DataSource = data

        RSLEPrice.DisplayMember = "sample_ret_price"
        RSLEPrice.ValueMember = "id_sample_ret_price"
        RSLEPrice.PopulateViewColumns()
        RSLEPrice.NullText = ""

        RSLEPrice.View.Columns("id_sample_ret_price").Caption = "ID Sample Price"
        RSLEPrice.View.Columns("id_sample").Caption = "id_sample"
        RSLEPrice.View.Columns("sample_ret_price_name").Caption = "Price Name"
        RSLEPrice.View.Columns("currency").Caption = "Currency"
        RSLEPrice.View.Columns("sample_ret_price").Caption = "Price"

        RSLEPrice.View.Columns("id_sample_ret_price").Visible = False
        RSLEPrice.View.Columns("id_sample").Visible = False

        RSLEPrice.View.Columns("sample_ret_price_name").VisibleIndex = 1
        RSLEPrice.View.Columns("currency").VisibleIndex = 2
        RSLEPrice.View.Columns("sample_ret_price").VisibleIndex = 3

        RSLEPrice.View.Columns("sample_ret_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        RSLEPrice.View.Columns("sample_ret_price").DisplayFormat.FormatString = "N2"

        RSLEPrice.View.BestFitColumns()
    End Sub
    Private Sub FormSamplePrintBarcode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub
    Private clone As DataView = Nothing
    Private Sub GVSample_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "id_sample_ret_price" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "[id_sample] = " + row("id_sample").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub
    Private Sub GVSample_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub
    Private Sub FormSamplePrintBarcode_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to print this barcode ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVSample.ActiveFilterString = "[is_print] = 'yes'"
            GVSample.ExpandAllGroups()
            Dim is_ok As String = "1"
            If GVSample.RowCount > 0 Then
                Dim pd As New PrintDialog()
                pd.PrinterSettings = New Printing.PrinterSettings()
                If (pd.ShowDialog() = DialogResult.OK) Then
                    For i As Integer = 0 To GVSample.RowCount - 1 - GetGroupRowCount(GVSample)
                        Dim pb As New print_barcode
                        pb.season = GVSample.GetRowCellValue(i, "season_orign_display").ToString
                        pb.color = GVSample.GetRowCellValue(i, "display_Color").ToString
                        pb.desc = GVSample.GetRowCellValue(i, "sample_display_name").ToString
                        pb.code = GVSample.GetRowCellValue(i, "sample_code").ToString
                        pb.size = GVSample.GetRowCellValue(i, "size").ToString
                        pb.class_ = GVSample.GetRowCellValue(i, "Sample Counting Class").ToString
                        pb.qty = GVSample.GetRowCellValue(i, "qty").ToString
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, pb.generate_barcode_sample())
                    Next

                    'unselect
                    GVSample.ActiveFilterString = ""
                    For j As Integer = 0 To ((GVSample.RowCount - 1) - GetGroupRowCount(GVSample))
                        GVSample.SetRowCellValue(j, "is_print", "no")
                    Next
                End If
            Else
                infoCustom("No item selected.")
            End If
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        GVSample.ActiveFilterString = ""
        Dim cek As String = CheckEditSelAll.EditValue.ToString
        GVSample.ExpandAllGroups()
        For i As Integer = 0 To ((GVSample.RowCount - 1) - GetGroupRowCount(GVSample))
            If cek Then
                GVSample.SetRowCellValue(i, "is_print", "yes")
            Else
                GVSample.SetRowCellValue(i, "is_print", "no")
            End If
        Next
    End Sub

    Private Sub BPrintZebra_Click(sender As Object, e As EventArgs) Handles BPrintZebra.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to print this barcode ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVSample.ActiveFilterString = "[is_print] = 'yes'"
            GVSample.ExpandAllGroups()
            Dim is_ok As String = "1"
            If GVSample.RowCount > 0 Then
                Dim pd As New PrintDialog()
                pd.PrinterSettings = New Printing.PrinterSettings()
                If (pd.ShowDialog() = DialogResult.OK) Then
                    For i As Integer = 0 To GVSample.RowCount - 1 - GetGroupRowCount(GVSample)
                        Dim pb As New print_barcode
                        pb.season = GVSample.GetRowCellValue(i, "season_orign_display").ToString
                        pb.color = GVSample.GetRowCellValue(i, "display_Color").ToString
                        pb.desc = GVSample.GetRowCellValue(i, "sample_display_name").ToString
                        pb.code = GVSample.GetRowCellValue(i, "sample_code").ToString
                        pb.size = GVSample.GetRowCellValue(i, "size").ToString
                        pb.class_ = GVSample.GetRowCellValue(i, "Sample Counting Class").ToString
                        pb.qty = GVSample.GetRowCellValue(i, "qty").ToString
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, pb.generate_barcode_sample_zebra())
                    Next

                    'unselect
                    GVSample.ActiveFilterString = ""
                    For j As Integer = 0 To ((GVSample.RowCount - 1) - GetGroupRowCount(GVSample))
                        GVSample.SetRowCellValue(j, "is_print", "no")
                    Next
                End If
            Else
                infoCustom("No item selected.")
            End If
        End If
    End Sub
End Class