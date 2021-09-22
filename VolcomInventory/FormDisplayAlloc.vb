Public Class FormDisplayAlloc
    Private Sub FormDisplayAlloc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormDisplayAlloc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'build kolom
        Dim qt As String = "SELECT dt.id_display_type, UPPER(dt.display_type) AS `display_type` FROM tb_display_type dt "
        Dim dt As DataTable = execute_query(qt, -1, True, "", "", "", "")
        Dim col_type1 As String = ""
        Dim col_type2 As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If i > 0 Then
                col_type1 += ","
                col_type2 += ","
            End If
            col_type1 += "SUM(CASE WHEN a.id_display_type=" + dt.Rows(i)("id_display_type").ToString + " THEN a.capacity END) AS `" + dt.Rows(i)("display_type").ToString + "` "
            col_type2 += "IFNULL(a.`" + dt.Rows(i)("display_type").ToString + "`,0) AS `" + dt.Rows(i)("display_type").ToString + "` "
        Next

        Dim query As String = "SELECT cg.id_class_group,dv.display_name AS `DIVISION`, 
        ct.class_type AS `TYP`, UPPER(cat.class_cat) AS `CATEGORY`, cg.class_group AS `CLASS`,
        " + col_type2 + ",
        IFNULL(a.`TOTAL DISPLAY`,0) AS `TOTAL DISPLAY`, 
        IFNULL(a.`ESTIMASI SKU`,0) AS `ESTIMASI SKU`
        FROM tb_class_group cg
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_type ct ON ct.id_class_type = cg.id_class_type
        INNER JOIN tb_class_cat cat ON cat.id_class_cat = cg.id_class_cat
        LEFT JOIN (
	        SELECT a.id_class_group, 
	        " + col_type1 + ",
	        SUM(a.capacity) AS `TOTAL DISPLAY`, 
	        SUM(a.capacity / a.qty_size) AS `ESTIMASI SKU`
	        FROM tb_display_alloc a
	        GROUP BY a.id_class_group
        ) a ON a.id_class_group = cg.id_class_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns("id_class_group").Visible = False
        For c As Integer = 0 To GVData.Columns.Count - 1
            Dim dtf As DataRow() = dt.Select("display_type='" + GVData.Columns(c).FieldName + "'")
            If dtf.Length > 0 Or GVData.Columns(c).FieldName = "TOTAL DISPLAY" Or GVData.Columns(c).FieldName = "ESTIMASI SKU" Then
                'display
                GVData.Columns(c).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns(c).DisplayFormat.FormatString = "{0:n2}"
                'summary
                GVData.Columns(c).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVData.Columns(c).SummaryItem.DisplayFormat = "{0:n2}"
                'grup summary
                Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                summary.DisplayFormat = "{0:n0}"
                summary.FieldName = GVData.Columns(c).FieldName
                summary.ShowInGroupColumnFooter = GVData.Columns(c)
                summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVData.GroupSummary.Add(summary)
            End If
        Next
        GVData.Columns("DIVISION").GroupIndex = 0
        GVData.Columns("CATEGORY").GroupIndex = 1
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClassGroup_Click(sender As Object, e As EventArgs) Handles BtnClassGroup.Click
        Cursor = Cursors.WaitCursor
        FormClassGroup.ShowDialog()
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewData()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(GCData, "")
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.DataAware

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormDisplayAllocDet.TxtClassGroup.Text = GVData.GetFocusedRowCellValue("CLASS").ToString
            FormDisplayAllocDet.foc = GVData.FocusedColumn.FieldName.ToString
            FormDisplayAllocDet.id_class_group = GVData.GetFocusedRowCellValue("id_class_group").ToString
            FormDisplayAllocDet.ShowDialog()
        End If
    End Sub
End Class