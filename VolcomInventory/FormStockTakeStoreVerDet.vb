Public Class FormStockTakeStoreVerDet
    Public id_st_store_bap As String = "-1"

    Private Sub FormStockTakeStoreVerDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        account_load()
        view_report_mark_type()

        form_load()
    End Sub

    Private Sub FormStockTakeStoreVerDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()

        FormStockTakeStoreVer.form_load()
    End Sub

    Sub form_load()
        'header
        Dim query_header As String = "
            SELECT b.id_comp, b.number, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, id_report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee    
            WHERE b.id_st_store_bap = " + id_st_store_bap + "
        "

        Dim data_header As DataTable = execute_query(query_header, -1, True, "", "", "", "")

        SLUEAccount.EditValue = data_header.Rows(0)("id_comp").ToString
        TECreatedAt.EditValue = data_header.Rows(0)("created_at").ToString
        TECreatedBy.EditValue = data_header.Rows(0)("created_by").ToString
        SLUEReportStatus.EditValue = data_header.Rows(0)("id_report_status").ToString
        TENumber.EditValue = data_header.Rows(0)("number").ToString

        'detail
        Dim query_detail As String = "
            SELECT d.id_product, p.full_code, p.name, p.size, d.price, (d.soh_qty - d.scan_qty) AS qty_awal, 0 AS qty_ver, '' AS note, '' AS id_report, '' AS report_number, '' AS report_mark_type, '' AS report_mark_type_name, d.id_price, d.soh_qty AS qty_soh, d.scan_qty AS qty_scan
            FROM tb_st_store_bap_det AS d
            LEFT JOIN tb_m_product_store AS p ON d.id_product = p.id_product
            WHERE d.id_st_store_bap = " + id_st_store_bap + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        'verification
        Dim query_ver As String = "
            SELECT d.id_product, v.id_report, v.report_mark_type, v.qty, r.report_mark_type_name, v.report_number, v.note
            FROM tb_st_store_bap_ver AS v
            LEFT JOIN tb_st_store_bap_det AS d ON v.id_st_store_bap_det = d.id_st_store_bap_det
            LEFT JOIN tb_lookup_report_mark_type AS r ON v.report_mark_type = r.report_mark_type
            WHERE d.id_st_store_bap = " + id_st_store_bap + "
        "

        Dim data_ver As DataTable = execute_query(query_ver, -1, True, "", "", "", "")

        For i = 0 To data_ver.Rows.Count - 1
            If data_ver.Rows(i)("report_mark_type").ToString = "43" Then
                For j = 0 To data_detail.Rows.Count - 1
                    If data_detail.Rows(j)("id_product").ToString = data_ver.Rows(i)("id_product").ToString Then
                        If data_detail.Rows(j)("id_report").ToString = "" Then
                            data_detail.Rows(j)("id_report") = data_ver.Rows(i)("id_report").ToString
                        Else
                            data_detail.Rows(j)("id_report") += "," + data_ver.Rows(i)("id_report").ToString
                        End If

                        If data_detail.Rows(j)("report_number").ToString = "" Then
                            data_detail.Rows(j)("report_number") = data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_number") += "," + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type") = data_ver.Rows(i)("report_mark_type").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type") += "," + data_ver.Rows(i)("report_mark_type").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type_name").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type_name") = data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type_name") += "," + data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("note").ToString = "" Then
                            data_detail.Rows(j)("note") = data_ver.Rows(i)("note").ToString
                        Else
                            data_detail.Rows(j)("note") += "," + data_ver.Rows(i)("note").ToString
                        End If

                        data_detail.Rows(j)("qty_ver") += Decimal.Parse(data_ver.Rows(i)("qty").ToString)
                    End If
                Next
            ElseIf data_ver.Rows(i)("report_mark_type").ToString = "46" Or data_ver.Rows(i)("report_mark_type").ToString = "113" Or data_ver.Rows(i)("report_mark_type").ToString = "120" Or data_ver.Rows(i)("report_mark_type").ToString = "111" Then
                For j = 0 To data_detail.Rows.Count - 1
                    If data_detail.Rows(j)("id_product").ToString = data_ver.Rows(i)("id_product").ToString Then
                        If data_detail.Rows(j)("id_report").ToString = "" Then
                            data_detail.Rows(j)("id_report") = data_ver.Rows(i)("id_report").ToString
                        Else
                            data_detail.Rows(j)("id_report") += "," + data_ver.Rows(i)("id_report").ToString
                        End If

                        If data_detail.Rows(j)("report_number").ToString = "" Then
                            data_detail.Rows(j)("report_number") = data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_number") += "," + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type") = data_ver.Rows(i)("report_mark_type").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type") += "," + data_ver.Rows(i)("report_mark_type").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type_name").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type_name") = data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type_name") += "," + data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("note").ToString = "" Then
                            data_detail.Rows(j)("note") = data_ver.Rows(i)("note").ToString
                        Else
                            data_detail.Rows(j)("note") += "," + data_ver.Rows(i)("note").ToString
                        End If

                        data_detail.Rows(j)("qty_ver") += Decimal.Parse(data_ver.Rows(i)("qty").ToString)
                    End If
                Next
            ElseIf data_ver.Rows(i)("report_mark_type").ToString = "0" Then
                For j = 0 To data_detail.Rows.Count - 1
                    If data_detail.Rows(j)("id_product").ToString = data_ver.Rows(i)("id_product").ToString Then
                        Dim inOut As String = ""

                        If Decimal.Parse(data_ver.Rows(i)("qty").ToString) > 0 Then
                            inOut = "In"
                        Else
                            inOut = "Out"
                        End If

                        If data_detail.Rows(j)("report_mark_type").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type") = "Adjustment " + inOut
                        Else
                            data_detail.Rows(j)("report_mark_type") += "," + "Adjustment " + inOut
                        End If

                        If data_detail.Rows(j)("report_mark_type_name").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type_name") = "Adjustment " + inOut
                        Else
                            data_detail.Rows(j)("report_mark_type_name") += "," + "Adjustment " + inOut
                        End If

                        If data_detail.Rows(j)("note").ToString = "" Then
                            data_detail.Rows(j)("note") = data_ver.Rows(i)("note").ToString
                        Else
                            data_detail.Rows(j)("note") += "," + data_ver.Rows(i)("note").ToString
                        End If

                        data_detail.Rows(j)("qty_ver") += Decimal.Parse(data_ver.Rows(i)("qty").ToString)
                    End If
                Next
            Else
                For j = 0 To data_detail.Rows.Count - 1
                    If data_detail.Rows(j)("id_product").ToString = data_ver.Rows(i)("id_product").ToString Then
                        If data_detail.Rows(j)("id_report").ToString = "" Then
                            data_detail.Rows(j)("id_report") = data_ver.Rows(i)("id_report").ToString
                        Else
                            data_detail.Rows(j)("id_report") += "," + data_ver.Rows(i)("id_report").ToString
                        End If

                        If data_detail.Rows(j)("report_number").ToString = "" Then
                            data_detail.Rows(j)("report_number") = data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_number") += "," + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type") = data_ver.Rows(i)("report_mark_type").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type") += "," + data_ver.Rows(i)("report_mark_type").ToString
                        End If

                        If data_detail.Rows(j)("report_mark_type_name").ToString = "" Then
                            data_detail.Rows(j)("report_mark_type_name") = data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        Else
                            data_detail.Rows(j)("report_mark_type_name") += "," + data_ver.Rows(i)("report_mark_type_name").ToString + " - " + data_ver.Rows(i)("report_number").ToString
                        End If

                        If data_detail.Rows(j)("note").ToString = "" Then
                            data_detail.Rows(j)("note") = data_ver.Rows(i)("note").ToString
                        Else
                            data_detail.Rows(j)("note") += "," + data_ver.Rows(i)("note").ToString
                        End If

                        data_detail.Rows(j)("qty_ver") += Decimal.Parse(data_ver.Rows(i)("qty").ToString)
                    End If
                Next
            End If
        Next

        GCData.DataSource = data_detail

        If SLUEReportStatus.EditValue.ToString = "0" Then
            SBImportExcel.Enabled = True
            SBMark.Enabled = False
            SBPrint.Enabled = False
            SBSubmit.Enabled = True
        Else
            SBImportExcel.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSubmit.Enabled = False
        End If

        BGVData.BestFitColumns()
    End Sub

    Sub account_load()
        Dim query As String = "
            SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name
            FROM tb_m_comp AS c
            WHERE c.id_comp IN (SELECT id_comp FROM tb_st_store_soh WHERE id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + ")
        "

        viewSearchLookupQuery(SLUEAccount, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SLUEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEAccount.EditValueChanged
        form_load()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Dispose()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim query As String = "UPDATE tb_st_store_bap SET id_report_status = 1 WHERE id_st_store_bap = " + id_st_store_bap

        execute_non_query(query, True, "", "", "", "")

        submit_who_prepared("324", id_st_store_bap, id_user)

        Close()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim Report As New ReportStockTakeStoreBAPHasil()

        Dim director As String = execute_query("
            SELECT employee_name
            FROM tb_m_employee
            WHERE id_employee = (SELECT id_emp_director FROM tb_opt LIMIT 1)
        ", 0, True, "", "", "", "")

        Dim vice_director As String = execute_query("
            SELECT employee_name
            FROM tb_m_employee
            WHERE id_employee = (SELECT id_emp_vice_director FROM tb_opt LIMIT 1)
        ", 0, True, "", "", "", "")

        Dim ia_manager As String = execute_query("
            SELECT employee_name
            FROM tb_m_employee
            WHERE id_employee = (SELECT id_emp_ia_manager FROM tb_opt LIMIT 1)
        ", 0, True, "", "", "", "")

        Dim start_period As String = execute_query("
            SELECT DATE_FORMAT(p.schedule_start, '%d %M %Y') AS schedule_start
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_st_store_period AS p ON b.id_st_store_period = p.id_st_store_period
            WHERE b.id_st_store_bap = " + id_st_store_bap + "
        ", 0, True, "", "", "", "")

        Dim date_created As String = execute_query("
            SELECT DATE_FORMAT(created_at, '%d %M %Y') AS created_at
            FROM tb_st_store_bap
            WHERE id_st_store_bap = " + id_st_store_bap + "
        ", 0, True, "", "", "", "")

        Report.XLDateCreated.Text = Report.XLDateCreated.Text.Replace("[date_created]", date_created)
        Report.XLKepada.Text = director + " / " + vice_director
        Report.XLDari.Text = ia_manager
        Report.XLToko.Text = SLUEAccount.Text
        Report.XLNo.Text = TENumber.Text
        Report.XLText.Text = Report.XLText.Text.Replace("[account]", SLUEAccount.Text).Replace("[start_period]", start_period)

        Dim data_missing As DataTable = New DataTable

        data_missing.Columns.Add("no", GetType(String))
        data_missing.Columns.Add("full_code", GetType(String))
        data_missing.Columns.Add("code", GetType(String))
        data_missing.Columns.Add("description", GetType(String))
        data_missing.Columns.Add("size", GetType(String))
        data_missing.Columns.Add("qty", GetType(String))
        data_missing.Columns.Add("price", GetType(String))
        data_missing.Columns.Add("amount", GetType(String))
        data_missing.Columns.Add("remark", GetType(String))

        Dim data_over As DataTable = New DataTable

        data_over.Columns.Add("no", GetType(String))
        data_over.Columns.Add("full_code", GetType(String))
        data_over.Columns.Add("code", GetType(String))
        data_over.Columns.Add("description", GetType(String))
        data_over.Columns.Add("size", GetType(String))
        data_over.Columns.Add("qty", GetType(String))
        data_over.Columns.Add("price", GetType(String))
        data_over.Columns.Add("amount", GetType(String))
        data_over.Columns.Add("remark", GetType(String))

        Dim data_adj As DataTable = New DataTable

        data_adj.Columns.Add("no", GetType(String))
        data_adj.Columns.Add("full_code", GetType(String))
        data_adj.Columns.Add("code", GetType(String))
        data_adj.Columns.Add("description", GetType(String))
        data_adj.Columns.Add("size", GetType(String))
        data_adj.Columns.Add("qty", GetType(String))
        data_adj.Columns.Add("price", GetType(String))
        data_adj.Columns.Add("amount", GetType(String))
        data_adj.Columns.Add("remark", GetType(String))

        For i = 0 To BGVData.RowCount - 1
            If BGVData.IsValidRowHandle(i) Then
                If BGVData.GetRowCellValue(i, "qty_akhir") > 0 Then
                    Dim row_missing As DataRow = data_missing.NewRow

                    row_missing("no") = data_missing.Rows.Count + 1
                    row_missing("full_code") = BGVData.GetRowCellValue(i, "full_code").ToString
                    row_missing("code") = BGVData.GetRowCellValue(i, "full_code").ToString.Substring(0, 9)
                    row_missing("description") = BGVData.GetRowCellValue(i, "name").ToString
                    row_missing("size") = BGVData.GetRowCellValue(i, "size").ToString
                    row_missing("qty") = BGVData.GetRowCellValue(i, "qty_akhir").ToString
                    row_missing("price") = BGVData.GetRowCellValue(i, "price")
                    row_missing("amount") = BGVData.GetRowCellValue(i, "price") * BGVData.GetRowCellValue(i, "qty_akhir")
                    row_missing("remark") = "Missing"

                    data_missing.Rows.Add(row_missing)
                ElseIf BGVData.GetRowCellValue(i, "qty_akhir") < 0 Then
                    Dim row_over As DataRow = data_over.NewRow

                    row_over("no") = data_over.Rows.Count + 1
                    row_over("full_code") = BGVData.GetRowCellValue(i, "full_code").ToString
                    row_over("code") = BGVData.GetRowCellValue(i, "full_code").ToString.Substring(0, 9)
                    row_over("description") = BGVData.GetRowCellValue(i, "name").ToString
                    row_over("size") = BGVData.GetRowCellValue(i, "size").ToString
                    row_over("qty") = Math.Abs(BGVData.GetRowCellValue(i, "qty_akhir"))
                    row_over("price") = BGVData.GetRowCellValue(i, "price")
                    row_over("amount") = BGVData.GetRowCellValue(i, "price") * BGVData.GetRowCellValue(i, "qty_akhir")
                    row_over("remark") = "Over Fisik"

                    data_over.Rows.Add(row_over)
                End If
            End If
        Next

        'add adjustment
        Dim dt_adj As DataTable = execute_query("
            SELECT p.full_code, p.name, p.size, SUM(v.qty) AS qty, d.price
            FROM tb_st_store_bap_ver AS v
            LEFT JOIN tb_st_store_bap_det AS d ON v.id_st_store_bap_det = d.id_st_store_bap_det
            LEFT JOIN tb_m_product_store AS p ON d.id_product = p.id_product
            WHERE d.id_st_store_bap = " + id_st_store_bap + " AND v.report_mark_type = 0
            GROUP BY d.id_product 
        ", -1, True, "", "", "", "")

        For i = 0 To dt_adj.Rows.Count - 1
            Dim row_adj As DataRow = data_adj.NewRow

            row_adj("no") = data_adj.Rows.Count + 1
            row_adj("full_code") = dt_adj.Rows(i)("full_code").ToString
            row_adj("code") = dt_adj.Rows(i)("full_code").ToString.ToString.Substring(0, 9)
            row_adj("description") = dt_adj.Rows(i)("name").ToString
            row_adj("size") = dt_adj.Rows(i)("size").ToString
            row_adj("qty") = Math.Abs(dt_adj.Rows(i)("qty"))
            row_adj("price") = dt_adj.Rows(i)("price")
            row_adj("amount") = dt_adj.Rows(i)("price") * Math.Abs(dt_adj.Rows(i)("qty"))

            If dt_adj.Rows(i)("qty") > 0 Then
                row_adj("remark") = "Adjustment In"
            ElseIf dt_adj.Rows(i)("qty") < 0 Then
                row_adj("remark") = "Adjustment Out"
            End If

            data_adj.Rows.Add(row_adj)
        Next

        'add nihil
        If data_missing.Rows.Count = 0 Then
            Dim row_missing As DataRow = data_missing.NewRow

            row_missing("no") = ""
            row_missing("full_code") = "NIHIL"
            row_missing("code") = "NIHIL"
            row_missing("description") = "NIHIL"
            row_missing("size") = "NIHIL"
            row_missing("qty") = "NIHIL"
            row_missing("price") = "NIHIL"
            row_missing("remark") = "NIHIL"

            data_missing.Rows.Add(row_missing)

            Report.XLMissing.Text = "Tidak dilakukan adjustment apapun di system"
        End If

        If data_over.Rows.Count = 0 Then
            Dim row_over As DataRow = data_over.NewRow

            row_over("no") = ""
            row_over("full_code") = "NIHIL"
            row_over("code") = "NIHIL"
            row_over("description") = "NIHIL"
            row_over("size") = "NIHIL"
            row_over("qty") = "NIHIL"
            row_over("price") = "NIHIL"
            row_over("remark") = "NIHIL"

            data_over.Rows.Add(row_over)

            Report.XLOver.Text = "Tidak dilakukan adjustment apapun di system"
        End If

        If data_adj.Rows.Count = 0 Then
            Dim row_adj As DataRow = data_adj.NewRow

            row_adj("no") = ""
            row_adj("full_code") = "NIHIL"
            row_adj("code") = "NIHIL"
            row_adj("description") = "NIHIL"
            row_adj("size") = "NIHIL"
            row_adj("qty") = "NIHIL"
            row_adj("price") = "NIHIL"
            row_adj("remark") = "NIHIL"

            data_adj.Rows.Add(row_adj)

            Report.XLAdjustment.Text = "Tidak dilakukan adjustment apapun di system"
        End If

        Report.id = id_st_store_bap

        Report.GCMissing.DataSource = data_missing
        Report.GCOver.DataSource = data_over
        Report.GCAdjustment.DataSource = data_adj

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBImportExcel_Click(sender As Object, e As EventArgs) Handles SBImportExcel.Click
        FormImportExcel.id_pop_up = "60"
        FormImportExcel.ShowDialog()
    End Sub

    Sub view_report_mark_type()
        Dim query As String = "
            SELECT 0 AS id_report_status, '' AS report_status
            UNION ALL
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEReportStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "324"
        FormReportMark.id_report = id_st_store_bap

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub
End Class