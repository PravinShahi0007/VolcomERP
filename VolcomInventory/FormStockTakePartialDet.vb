Public Class FormStockTakePartialDet
    Public id As String = "-1"

    Private Sub FormStockTakePartialDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEReportStatus, "SELECT 0 AS id_report_status, '' AS report_status UNION ALL SELECT id_report_status, report_status FROM tb_lookup_report_status", "id_report_status", "report_status", "id_report_status")

        load_form()
    End Sub

    Private Sub FormStockTakePartialDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim note As String = TENote.EditValue.ToString

        If Not note = "" Then
            Dim query_head As String = "
                INSERT INTO tb_st_store_partial (note, id_report_status, created_at, created_by) VALUES ('" + addSlashes(note) + "', 1, NOW(), " + id_user + "); SELECT LAST_INSERT_ID();
            "

            id = execute_query(query_head, 0, True, "", "", "", "")

            'gen number
            execute_non_query("UPDATE tb_st_store_partial SET number = CONCAT('STCKP', LPAD(" + id + ", 7, '0')) WHERE id_st_store_partial = " + id, True, "", "", "", "")

            'detail
            GVProduct.ClearColumnsFilter()
            GVProduct.ApplyFindFilter("")
            GVProduct.ActiveFilter.Clear()

            GVProduct.ActiveFilterString = "[is_select] = 'yes'"

            If GVProduct.RowCount > 0 Then
                For i = 0 To GVProduct.RowCount - 1
                    If GVProduct.IsValidRowHandle(i) Then
                        Dim id_design As String = GVProduct.GetRowCellValue(i, "id_design").ToString

                        Dim query_detail As String = "INSERT INTO tb_st_store_partial_det (id_st_store_partial, id_design) VALUES (" + id + ", " + id_design + ")"

                        execute_non_query(query_detail, True, "", "", "", "")
                    End If
                Next
            Else
                stopCustom("Please select product.")
            End If

            GVProduct.ActiveFilterString = ""

            submit_who_prepared("323", id, id_user)

            load_form()

            infoCustom("Save complete.")
        Else
            stopCustom("Please fill note.")
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Sub load_form()
        Dim query_header As String = "
            SELECT number, note, id_report_status
            FROM tb_st_store_partial
            WHERE id_st_store_partial = " + id + "
            UNION ALL
            SELECT '[autogenerate]' AS number, '' AS note, 0 AS id_report_status
        "

        Dim data_header As DataTable = execute_query(query_header, -1, True, "", "", "", "")

        TENumber.EditValue = data_header(0)("number").ToString
        TENote.EditValue = data_header(0)("note").ToString
        SLUEReportStatus.EditValue = data_header(0)("id_report_status").ToString

        Dim query_detail As String = "
            SELECT id_design
            FROM tb_st_store_partial_det
            WHERE id_st_store_partial = " + id + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        Dim query_design As String = "
            SELECT 'no' AS is_select, d.id_design, d.design_code, d.design_display_name, c.code AS class
            FROM tb_m_design AS d
            INNER JOIN (
	            SELECT c.id_design, d.code, d.code_detail_name
	            FROM tb_m_design_code AS c
	            INNER JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
	            WHERE d.id_code = 30
            ) AS c ON d.id_design = c.id_design
            WHERE d.id_lookup_status_order <> 2
        "

        Dim data_design As DataTable = execute_query(query_design, -1, True, "", "", "", "")

        For i = 0 To data_design.Rows.Count - 1
            For j = 0 To data_detail.Rows.Count - 1
                If data_design(i)("id_design").ToString = data_detail(j)("id_design").ToString Then
                    data_design(i)("is_select") = "yes"
                End If
            Next
        Next

        GCProduct.DataSource = data_design

        GVProduct.BestFitColumns()

        'access
        If SLUEReportStatus.EditValue.ToString = "0" Then
            TENote.ReadOnly = False
            GVProduct.OptionsBehavior.Editable = True
            SBSave.Enabled = True
            SBMark.Enabled = False
            SBImportExcel.Enabled = True
        Else
            TENote.ReadOnly = True
            GVProduct.OptionsBehavior.Editable = False
            SBSave.Enabled = False
            SBMark.Enabled = True
            SBImportExcel.Enabled = False
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "323"
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBDownloadTemplate_Click(sender As Object, e As EventArgs) Handles SBDownloadTemplate.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.FileName = "Template Partial Stock Take.xlsx"

        save.ShowDialog()

        If Not save.FileName = "" Then
            Try
                My.Computer.Network.DownloadFile("\\192.168.1.2\dataapp$\template\Template Partial Stock Take.xlsx", save.FileName)

                infoCustom("File downloaded.")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SBImportExcel_Click(sender As Object, e As EventArgs) Handles SBImportExcel.Click
        FormImportExcel.id_pop_up = "61"
        FormImportExcel.ShowDialog()
    End Sub
End Class