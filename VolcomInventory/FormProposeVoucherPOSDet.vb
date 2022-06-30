Public Class FormProposeVoucherPOSDet
    Public id As String = "0"

    Private Sub FormProposeVoucherPOSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOutlet()

        RIDEDate.MinValue = Date.Parse(getTimeDB())

        form_load()
    End Sub

    Sub form_load()
        SBAdd.Enabled = True
        SBRemove.Enabled = True
        SBSubmit.Enabled = True
        SBPrint.Enabled = False
        SBAttachment.Enabled = False
        MENote.ReadOnly = False
        SBMark.Enabled = False
        GVData.OptionsBehavior.ReadOnly = False

        If id = "0" Then
            Dim data As DataTable = New DataTable

            data.Columns.Add("voucher_number", GetType(String))
            data.Columns.Add("voucher_value", GetType(Integer))
            data.Columns.Add("voucher_name", GetType(String))
            data.Columns.Add("voucher_address", GetType(String))
            data.Columns.Add("period_start", GetType(Date))
            data.Columns.Add("period_end", GetType(Date))
            data.Columns.Add("outlet_name", GetType(String))

            GridColumn5.Visible = True
            GridColumn6.Visible = False

            GCData.DataSource = data
        Else
            Dim query_head As String = "
                SELECT h.number, DATE_FORMAT(h.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, h.note, r.report_status AS report_status
                FROM tb_pos_voucher_pps AS h
                LEFT JOIN tb_lookup_report_status AS r ON h.id_report_status = r.id_report_status
                LEFT JOIN tb_m_employee AS e ON h.created_by = e.id_employee
                WHERE h.id_voucher_pps = " + id + "
            "

            Dim head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

            TENumber.EditValue = head.Rows(0)("number").ToString
            TEReportStatus.EditValue = head.Rows(0)("report_status").ToString
            TECreatedDate.EditValue = head.Rows(0)("created_date").ToString
            TECreatedBy.EditValue = head.Rows(0)("created_by").ToString
            MENote.EditValue = head.Rows(0)("note").ToString

            Dim query_detail As String = "
                SELECT d.voucher_number, d.voucher_value, d.voucher_name, d.voucher_address, d.period_start, d.period_end, GROUP_CONCAT(o.outlet_name SEPARATOR '\n') AS outlet_name_line
                FROM tb_pos_voucher_pps_det AS d
                LEFT JOIN tb_outlet AS o ON d.id_outlet = o.id_outlet
                WHERE d.id_voucher_pps = " + id + "
                GROUP BY d.voucher_number
            "

            Dim detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            GridColumn5.Visible = False
            GridColumn6.Visible = True

            GCData.DataSource = detail

            GVData.BestFitColumns()

            SBAdd.Enabled = False
            SBRemove.Enabled = False
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBAttachment.Enabled = True
            MENote.ReadOnly = True
            SBMark.Enabled = True
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVData.AddNewRow()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVData.DeleteSelectedRows()
    End Sub

    Sub viewOutlet()
        Dim query As String = "SELECT id_outlet, outlet_name FROM tb_outlet"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim el As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            el.Description = data.Rows(i)("outlet_name").ToString
            el.Tag = data.Rows(i)("id_outlet").ToString

            RICCBEOutlet.Items.Add(el, False)
        Next
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        'check number
        Dim list_number As List(Of String) = New List(Of String)
        Dim duplicate_number As Boolean = False

        Dim is_empty As Boolean = False
        Dim number_list As String = ""

        For i = 0 To GVData.RowCount - 1
            If GVData.IsValidRowHandle(i) Then
                If list_number.Contains(GVData.GetRowCellValue(i, "voucher_number").ToString) Then
                    duplicate_number = True
                End If

                list_number.Add(GVData.GetRowCellValue(i, "voucher_number").ToString)

                number_list += "'" + GVData.GetRowCellValue(i, "voucher_number").ToString + "', "

                If GVData.GetRowCellValue(i, "voucher_number").ToString = "" Or GVData.GetRowCellValue(i, "voucher_value").ToString = "" Or GVData.GetRowCellValue(i, "period_start").ToString = "" Or GVData.GetRowCellValue(i, "period_end").ToString = "" Or GVData.GetRowCellValue(i, "outlet_name").ToString = "" Then
                    is_empty = True
                End If
            End If
        Next

        If Not number_list = "" And Not is_empty Then
            If Not duplicate_number Then
                Dim count_number As String = execute_query("
                    SELECT COUNT(*) AS total
                    FROM tb_pos_voucher_pps_det AS d
                    LEFT JOIN tb_pos_voucher_pps AS h ON d.id_voucher_pps = h.id_voucher_pps
                    WHERE h.id_report_status <> 5 AND d.voucher_number IN (" + number_list.Substring(0, number_list.Length - 2) + ")
                ", 0, True, "", "", "", "")

                If count_number = "0" Then
                    Dim confirm As DialogResult

                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim query As String = "
                            INSERT INTO tb_pos_voucher_pps (created_date, created_by, note, id_report_status) VALUES (NOW(), " + id_employee_user + ", '" + addSlashes(MENote.EditValue.ToString) + "', 1); SELECT LAST_INSERT_ID();
                        "

                        id = execute_query(query, 0, True, "", "", "", "")

                        execute_non_query("CALL gen_number(" + id + ", '412')", True, "", "", "", "")

                        Dim query_detail As String = "INSERT INTO tb_pos_voucher_pps_det (id_voucher_pps, voucher_number, voucher_value, voucher_name, voucher_address, period_start, period_end, id_outlet, is_active) VALUES "

                        For i = 0 To GVData.RowCount - 1
                            Dim outlet_names As String() = GVData.GetRowCellValue(i, "outlet_name").ToString.Split(",")

                            For j = 0 To outlet_names.Count - 1
                                Dim outlet_name As String = trimSpace(outlet_names(j))

                                Dim id_outlet As String = execute_query("SELECT id_outlet FROM tb_outlet WHERE outlet_name = '" + outlet_name + "'", 0, True, "", "", "", "")
                                Dim voucher_number As String = GVData.GetRowCellValue(i, "voucher_number").ToString
                                Dim voucher_value As String = GVData.GetRowCellValue(i, "voucher_value").ToString
                                Dim voucher_name As String = GVData.GetRowCellValue(i, "voucher_name").ToString
                                Dim voucher_address As String = GVData.GetRowCellValue(i, "voucher_address").ToString
                                Dim period_start As String = Date.Parse(GVData.GetRowCellValue(i, "period_start").ToString).ToString("yyyy-MM-dd")
                                Dim period_end As String = Date.Parse(GVData.GetRowCellValue(i, "period_end").ToString).ToString("yyyy-MM-dd")

                                query_detail += "(" + id + ", '" + voucher_number + "', " + voucher_value + ", '" + voucher_name + "', '" + voucher_address + "', '" + period_start + "', '" + period_end + "', " + id_outlet + ", 1), "
                            Next
                        Next

                        query_detail = query_detail.Substring(0, query_detail.Length - 2)

                        execute_non_query(query_detail, True, "", "", "", "")

                        submit_who_prepared("412", id, id_user)

                        form_load()

                        FormProposeVoucherPOS.load_view()
                    End If
                Else
                    stopCustom("Voucher number already used.")
                End If
            Else
                stopCustom("Cannot duplicate voucher number.")
            End If
        Else
            stopCustom("Please check your input.")
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Dim report_mark_type As String = "412"

        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub FormProposeVoucherPOSDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportProposeVoucherPOS()

        report.id = id

        report.XLNumber.Text = TENumber.EditValue.ToString
        report.XLCreatedAt.Text = TECreatedDate.EditValue.ToString
        report.XLCreatedBy.Text = TECreatedBy.EditValue.ToString

        report.GCData.DataSource = GCData.DataSource

        report.GVData.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Dim report_mark_type As String = "412"

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = report_mark_type

        FormDocumentUpload.ShowDialog()
    End Sub
End Class