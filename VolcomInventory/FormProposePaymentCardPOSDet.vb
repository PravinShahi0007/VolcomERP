Public Class FormProposePaymentCardPOSDet
    Public id_propose_card_pos As String = "-1"

    Private Sub FormProposePaymentCardPOSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupRepositoryQuery(RISLUEAccount, "SELECT id_acc, CONCAT(acc_name, ' - ', acc_description) AS acc FROM tb_a_acc WHERE id_status = 1 AND id_is_det = 2", 0, "acc", "id_acc")

        formLoad()
    End Sub

    Private Sub FormProposePaymentCardPOSDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub formLoad()
        Dim query_head As String = "
            SELECT c.report_number, c.note, r.report_status, e.employee_name AS created_by, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date
            FROM tb_propose_card_pos AS c
            LEFT JOIN tb_lookup_report_status AS r ON c.id_report_status = r.id_report_status
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            WHERE c.id_propose_card_pos = " + id_propose_card_pos + "
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        If data_head.Rows.Count > 0 Then
            TENumber.EditValue = data_head.Rows(0)("report_number").ToString
            TEReportStatus.EditValue = data_head.Rows(0)("report_status").ToString
            TECreatedDate.EditValue = data_head.Rows(0)("created_date").ToString
            TECreatedBy.EditValue = data_head.Rows(0)("created_by").ToString
        End If

        Dim query_detail As String = "
            SELECT IF(d.id_card IS NULL, 'New', 'Revise') AS `type`, d.id_card, d.card_name, d.discount, d.id_acc, d.note
            FROM tb_propose_card_pos_det AS d
            WHERE d.id_propose_card_pos = " + id_propose_card_pos + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCData.DataSource = data_detail

        GVData.BestFitColumns()

        If id_propose_card_pos = "-1" Then
            SBAdd.Enabled = True
            SBRevise.Enabled = True
            SBRemove.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            SBSubmit.Enabled = True
            SBPrint.Enabled = False
            SBAttachment.Enabled = False
            SBMark.Enabled = False
            MENote.ReadOnly = False
        Else
            SBAdd.Enabled = False
            SBRevise.Enabled = False
            SBRemove.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBAttachment.Enabled = True
            SBMark.Enabled = True
            MENote.ReadOnly = True
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVData.AddNewRow()

        GVData.SetFocusedRowCellValue("type", "New")
        GVData.SetFocusedRowCellValue("id_card", 0)
        GVData.SetFocusedRowCellValue("card_name", "")
        GVData.SetFocusedRowCellValue("discount", 0.00)
        GVData.SetFocusedRowCellValue("id_acc", 3554)
        GVData.SetFocusedRowCellValue("note", "")
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVData.DeleteSelectedRows()
    End Sub

    Private Sub SBRevise_Click(sender As Object, e As EventArgs) Handles SBRevise.Click
        FormProposePaymentCardPOSRevise.ShowDialog()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        If GVData.RowCount > 0 Then
            Dim vld As Boolean = True

            For i = 0 To GVData.RowCount - 1
                If GVData.IsValidRowHandle(i) Then
                    If GVData.GetRowCellValue(i, "card_name").ToString = "" Or GVData.GetRowCellValue(i, "discount").ToString = "" Or GVData.GetRowCellValue(i, "id_acc").ToString = "" Then
                        vld = False
                    End If
                End If
            Next

            If vld Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim note As String = MENote.EditValue.ToString

                    Dim query_head As String = "
                        INSERT INTO tb_propose_card_pos (note, id_report_status, created_date, created_by) VALUES ('" + addSlashes(note) + "', 1, NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();
                    "

                    id_propose_card_pos = execute_query(query_head, 0, True, "", "", "", "")

                    Dim query_detail As String = "INSERT INTO tb_propose_card_pos_det (id_propose_card_pos, id_card, card_name, discount, id_acc, note) VALUES "

                    For i = 0 To GVData.RowCount - 1
                        Dim id_card As String = GVData.GetRowCellValue(i, "id_card").ToString
                        Dim card_name As String = GVData.GetRowCellValue(i, "card_name").ToString
                        Dim discount As String = GVData.GetRowCellValue(i, "discount").ToString
                        Dim id_acc As String = GVData.GetRowCellValue(i, "id_acc").ToString
                        Dim detail_note As String = GVData.GetRowCellValue(i, "note").ToString

                        query_detail += "(" + id_propose_card_pos + ", " + If(id_card = "" Or id_card = "0", "NULL", id_card) + ", '" + addSlashes(card_name) + "', " + decimalSQL(discount) + ", " + id_acc + ", '" + addSlashes(detail_note) + "'), "
                    Next

                    query_detail = query_detail.Substring(0, query_detail.Length - 2)

                    execute_non_query(query_detail, True, "", "", "", "")

                    execute_non_query("CALL gen_number(" + id_propose_card_pos + ", '415')", True, "", "", "", "")

                    submit_who_prepared("415", id_propose_card_pos, id_user)

                    formLoad()

                    FormProposePaymentCardPOS.load_form()
                End If
            Else
                stopCustom("Please complete form.")
            End If
        Else
            stopCustom("Please add card type.")
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportProposePaymentCardPOS()

        report.id = id_propose_card_pos

        report.XLNumber.Text = TENumber.EditValue.ToString
        report.XLCreatedAt.Text = TECreatedDate.EditValue.ToString
        report.XLCreatedBy.Text = TECreatedBy.EditValue.ToString

        report.GCData.DataSource = GCData.DataSource

        report.GVData.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Dim report_mark_type As String = "415"

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_propose_card_pos
        FormDocumentUpload.report_mark_type = report_mark_type

        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Dim report_mark_type As String = "415"

        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.id_report = id_propose_card_pos

        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        If (e.Column.FieldName = "card_name" Or e.Column.FieldName = "discount" Or e.Column.FieldName = "id_acc") And Not GVData.GetFocusedRowCellValue("id_card").ToString = "0" And Not GVData.GetFocusedRowCellValue("id_card").ToString = "" Then
            Dim query As String = "
                SELECT p.card_name, p.discount, p.id_acc, CONCAT(a.acc_name, ' - ', a.acc_description) AS acc
                FROM tb_pos_card_type AS p
                LEFT JOIN tb_a_acc AS a ON p.id_acc = a.id_acc
                WHERE p.id_card = " + GVData.GetFocusedRowCellValue("id_card").ToString + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim note As String = ""

            If Not GVData.GetFocusedRowCellValue("card_name").ToString = data.Rows(0)("card_name").ToString Then
                note += "Card Name: from '" + data.Rows(0)("card_name").ToString + "' to '" + GVData.GetFocusedRowCellValue("card_name").ToString + "'" + Environment.NewLine
            End If

            Dim discount As String = GVData.GetFocusedRowCellValue("discount").ToString

            If Not Decimal.Parse(If(discount = "", "0", discount)) = Decimal.Parse(data.Rows(0)("discount").ToString) Then
                note += "Discount: from '" + data.Rows(0)("discount").ToString + "' to '" + GVData.GetFocusedRowCellValue("discount").ToString + "'" + Environment.NewLine
            End If

            If Not GVData.GetFocusedRowCellValue("id_acc").ToString = data.Rows(0)("id_acc").ToString Then
                note += "Account: from '" + data.Rows(0)("acc").ToString + "' to '" + GVData.GetFocusedRowCellDisplayText("id_acc").ToString + "'" + Environment.NewLine
            End If

            If Not note = "" Then
                note = note.Substring(0, note.Length - 1)
            End If

            GVData.SetFocusedRowCellValue("note", note)
        End If
    End Sub

    Sub updateChanges(id_report As String)
        Dim query As String = "
            SELECT id_card, card_name, discount, id_acc
            FROM tb_propose_card_pos_det
            WHERE id_propose_card_pos = " + id_report + "   
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("id_card").ToString = "" Then
                Dim query_insert As String = "
                    INSERT INTO tb_pos_card_type (card_name, discount, id_acc, discount_acc) VALUES ('" + addSlashes(data.Rows(i)("card_name").ToString) + "', " + decimalSQL(data.Rows(i)("discount").ToString) + ", " + data.Rows(i)("id_acc").ToString + ", 3891)
                "

                execute_non_query(query_insert, True, "", "", "", "")
            Else
                Dim query_update As String = "
                    UPDATE tb_pos_card_type SET card_name = '" + addSlashes(data.Rows(i)("card_name").ToString) + "', discount = " + decimalSQL(data.Rows(i)("discount").ToString) + ", id_acc = " + data.Rows(i)("id_acc").ToString + " WHERE id_card = " + data.Rows(i)("id_card").ToString + "
                "

                execute_non_query(query_update, True, "", "", "", "")
            End If
        Next
    End Sub
End Class