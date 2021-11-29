Public Class FormProposePromoDet
    Public id_propose_promo As String = "0"

    Private Sub FormProposePromoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormProposePromoDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormProposePromoPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVProduct.DeleteSelectedRows()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        If TENama.EditValue.ToString = "" Or TEKTP.EditValue.ToString = "" Or TENPWP.EditValue.ToString = "" Or MEAlamat.EditValue.ToString = "" Then
            stopCustom("Please check your input.")
        Else
            GVProduct.FindFilterText = ""
            GVProduct.ActiveFilterString = ""
            GVProduct.ClearColumnsFilter()

            If GVProduct.RowCount > 0 Then
                'stock check
                For i = 0 To GVProduct.RowCount - 1
                    If GVProduct.IsValidRowHandle(i) Then
                        Dim query_sc As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES ('" + id_user + "', '" + GVProduct.GetRowCellValue(i, "code").ToString + "', '" + addSlashes(GVProduct.GetRowCellValue(i, "name").ToString) + "', '" + GVProduct.GetRowCellValue(i, "size").ToString + "', '" + GVProduct.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVProduct.GetRowCellValue(i, "qty").ToString) + "'); CALL view_validate_stock(" + id_user + ", " + GVProduct.GetRowCellValue(i, "id_comp").ToString + ", '" + GVProduct.GetRowCellValue(i, "id_product").ToString + "', 1);"

                        Dim data_sc As DataTable = execute_query(query_sc, -1, True, "", "", "", "")

                        If data_sc.Rows.Count > 0 Then
                            stopCustom("No stock available for some items.")

                            FormValidateStock.dt = data_sc
                            FormValidateStock.ShowDialog()

                            Exit Sub
                        End If
                    End If
                Next

                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim nama As String = addSlashes(TENama.EditValue.ToString)
                    Dim ktp As String = addSlashes(TEKTP.EditValue.ToString)
                    Dim npwp As String = addSlashes(TENPWP.EditValue.ToString)
                    Dim alamat As String = addSlashes(MEAlamat.EditValue.ToString)

                    Dim query As String = "INSERT INTO tb_propose_promo (nama, ktp, npwp, alamat, created_at, created_by, id_report_status) VALUES ('" + nama + "', '" + ktp + "', '" + npwp + "', '" + alamat + "', NOW(), '" + id_employee_user + "', 1); SELECT LAST_INSERT_ID();"

                    id_propose_promo = execute_query(query, 0, True, "", "", "", "")

                    Dim query_detail As String = "INSERT INTO tb_propose_promo_det (id_propose_promo, id_comp, id_product, id_design_price, design_price, qty) VALUES "

                    For i = 0 To GVProduct.RowCount - 1
                        If GVProduct.IsValidRowHandle(i) Then
                            Dim id_comp As String = GVProduct.GetRowCellValue(i, "id_comp").ToString
                            Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVProduct.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVProduct.GetRowCellValue(i, "design_price").ToString)
                            Dim qty As String = decimalSQL(GVProduct.GetRowCellValue(i, "qty").ToString)

                            query_detail += "(" + id_propose_promo + ", " + id_comp + ", " + id_product + ", " + id_design_price + ", '" + design_price + "', '" + qty + "'), "
                        End If
                    Next

                    query_detail = query_detail.Substring(0, query_detail.Length - 2)

                    execute_non_query(query_detail, True, "", "", "", "")

                    execute_non_query("CALL gen_number(" + id_propose_promo + ", '358')", True, "", "", "", "")

                    submit_who_prepared("358", id_propose_promo, id_user)

                    infoCustom("Submitted.")

                    form_load()
                End If
            Else
                stopCustom("Please select product.")
            End If
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        FormReportMark.report_mark_type = "358"
        FormReportMark.id_report = id_propose_promo

        FormReportMark.ShowDialog()
    End Sub

    Sub form_load()
        Dim query_head As String = "
            SELECT p.number, p.nama, p.ktp, p.npwp, p.alamat, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, r.report_status
            FROM tb_propose_promo AS p
            LEFT JOIN tb_m_employee AS e ON p.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON p.id_report_status = r.id_report_status
            WHERE p.id_propose_promo = " + id_propose_promo + "
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        If data_head.Rows.Count > 0 Then
            TENumber.EditValue = data_head.Rows(0)("number").ToString
            TEReportStatus.EditValue = data_head.Rows(0)("report_status").ToString
            TENama.EditValue = data_head.Rows(0)("nama").ToString
            TEKTP.EditValue = data_head.Rows(0)("ktp").ToString
            TENPWP.EditValue = data_head.Rows(0)("npwp").ToString
            TECreatedAt.EditValue = data_head.Rows(0)("created_at").ToString
            TECreatedBy.EditValue = data_head.Rows(0)("created_by").ToString
            MEAlamat.EditValue = data_head.Rows(0)("alamat").ToString
        Else
            TENumber.EditValue = "[autogenerate]"
            TECreatedAt.EditValue = DateTime.Parse(Now()).ToString("dd MMMM yyyy HH:mm:ss")
            TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        End If

        Dim query_detail As String = "
            SELECT d.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, d.id_product, p.product_display_name AS name, p.product_full_code AS code, z.code_detail_name AS size, d.id_design_price, d.qty, e.design_cop, (d.qty * e.design_cop) AS design_cop_amount, d.design_price, (d.qty * d.design_price) AS design_price_amount
            FROM tb_propose_promo_det AS d
            LEFT JOIN tb_m_comp AS c ON d.id_comp = c.id_comp
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_m_design AS e ON p.id_design = e.id_design
            LEFT JOIN (
                SELECT c.id_product, d.code_detail_name
                FROM tb_m_product_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS z ON d.id_product = z.id_product
            WHERE d.id_propose_promo = " + id_propose_promo + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCProduct.DataSource = data_detail

        GVProduct.BestFitColumns()

        'control
        If id_propose_promo = "0" Then
            TENama.ReadOnly = False
            TEKTP.ReadOnly = False
            TENPWP.ReadOnly = False
            MEAlamat.ReadOnly = False
            SBSubmit.Enabled = True
            SBPrint.Enabled = False
            SBAttachment.Enabled = False
            SBMark.Enabled = False
            SBAdd.Enabled = True
            SBRemove.Enabled = True
        Else
            TENama.ReadOnly = True
            TEKTP.ReadOnly = True
            TENPWP.ReadOnly = True
            MEAlamat.ReadOnly = True
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBAttachment.Enabled = True
            SBMark.Enabled = True
            SBAdd.Enabled = False
            SBRemove.Enabled = False
        End If
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_propose_promo
        FormDocumentUpload.report_mark_type = "358"

        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportProposePromo()

        report.id_propose_promo = id_propose_promo

        report.XLNumber.Text = TENumber.EditValue.ToString
        report.XLKTP.Text = TEKTP.EditValue.ToString
        report.XLNama.Text = TENama.EditValue.ToString
        report.XLNPWP.Text = TENPWP.EditValue.ToString
        report.XLCreatedAt.Text = TECreatedAt.EditValue.ToString
        report.XLCreatedBy.Text = TECreatedBy.EditValue.ToString
        report.XLAlamat.Text = MEAlamat.EditValue.ToString

        report.GCProduct.DataSource = GCProduct.DataSource

        report.GVProduct.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class