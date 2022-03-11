Public Class FormBuktiPickupDet
    Public id_pickup As String = "0"
    Public is_view_attachment As String = "-1"

    Private Sub FormBuktiPickupDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        view_comp()
        load_form()

        DEDate.Properties.MaxValue = Date.Parse(Now)

        Cursor = Cursors.Default
    End Sub

    Sub load_form()
        If id_pickup = "0" Then
            SLUECompany.EditValue = 0
            DEDate.EditValue = getTimeDB()
            TECreatedBy.EditValue = get_emp(id_employee_user, "2")
            DECreatedDate.EditValue = getTimeDB()
            TEUpdatedBy.EditValue = ""
            DEUpdatedDate.EditValue = ""
            MENote.EditValue = ""
            TEReportStatus.EditValue = ""

            Dim data As DataTable = New DataTable

            data.Columns.Add("id_pl_sales_order_del", GetType(Integer))
            data.Columns.Add("no", GetType(Integer))
            data.Columns.Add("pl_sales_order_del_number", GetType(String))
            data.Columns.Add("combine_number", GetType(String))
            data.Columns.Add("wh", GetType(String))
            data.Columns.Add("store", GetType(String))
            data.Columns.Add("comp_group", GetType(String))
            data.Columns.Add("sales_order_number", GetType(String))
            data.Columns.Add("sales_order_ol_shop_number", GetType(String))
            data.Columns.Add("so_status", GetType(String))
            data.Columns.Add("total", GetType(Decimal))
            data.Columns.Add("pl_sales_order_del_date", GetType(Date))

            GCList.DataSource = data

            GVList.BestFitColumns()
        Else
            Dim query As String = "
                SELECT pickup.id_pickup, DATE_FORMAT(pickup.pickup_date, '%d %b %Y') AS pickup_date, pickup.id_comp, pickup.note, pickup.id_report_status, IF(pickup.id_report_status = 0, 'Draft', status.report_status) AS report_status, DATE_FORMAT(pickup.created_date, '%d %b %Y %H:%i:%s') AS created_date, created_by.employee_name AS created_by, DATE_FORMAT(pickup.updated_date, '%d %b %Y %H:%i:%s') AS updated_date, updated_by.employee_name AS updated_by
                FROM tb_del_pickup AS pickup
                LEFT JOIN tb_lookup_report_status AS status ON pickup.id_report_status = status.id_report_status
                LEFT JOIN tb_m_employee AS created_by ON pickup.created_by = created_by.id_employee
                LEFT JOIN tb_m_employee AS updated_by ON pickup.updated_by = updated_by.id_employee
                WHERE pickup.id_pickup = " + id_pickup + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            SLUECompany.EditValue = data.Rows(0)("id_comp")
            DEDate.EditValue = data.Rows(0)("pickup_date")
            TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TEUpdatedBy.EditValue = data.Rows(0)("updated_by").ToString
            DEUpdatedDate.EditValue = data.Rows(0)("updated_date")
            MENote.EditValue = data.Rows(0)("note").ToString
            TEReportStatus.EditValue = data.Rows(0)("report_status").ToString

            'detail
            Dim query_det As String = "
                SELECT a.id_pl_sales_order_del, 0 AS no, a.pl_sales_order_del_number, IFNULL(comb.combine_number, '-') AS combine_number, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS wh, CONCAT(d.comp_number, ' - ', d.comp_name) AS store, dg.comp_group, b.sales_order_number, b.sales_order_ol_shop_number, cat.so_status, IFNULL(det.total, 0) AS total, a.pl_sales_order_del_date
                FROM tb_del_pickup_det AS pickup_det
                LEFT JOIN tb_pl_sales_order_del AS a ON pickup_det.id_pl_sales_order_del = a.id_pl_sales_order_del
                INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order
                INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
                INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp
                INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from 
                INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp
                LEFT JOIN (
                    SELECT del.id_pl_sales_order_del, SUM(det.pl_sales_order_del_det_qty) AS total 
                    FROM tb_pl_sales_order_del del 
                    INNER JOIN tb_pl_sales_order_del_det det ON del.id_pl_sales_order_del = det.id_pl_sales_order_del 
                    GROUP BY del.id_pl_sales_order_del 
                ) det ON det.id_pl_sales_order_del = a.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = a.id_combine
                INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status
                LEFT JOIN tb_m_comp_group dg ON d.id_comp_group = dg.id_comp_group
                WHERE pickup_det.id_pickup = " + id_pickup + "
            "

            Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

            GCList.DataSource = data_det

            GVList.BestFitColumns()
        End If

        'controls
        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_del_pickup WHERE id_pickup = " + id_pickup + "), -1) AS id_report_status", 0, True, "", "", "", "")

        If id_report_status = "-1" Then
            'new
            SLUECompany.Properties.ReadOnly = False
            DEDate.ReadOnly = False
            SBRemove.Enabled = True
            SBAdd.Enabled = True
            SBSave.Enabled = True
            SBComplete.Enabled = True
            SBCancel.Enabled = False
            MENote.ReadOnly = False
            SBAttachement.Enabled = False
        ElseIf id_report_status = "0" Then
            'draft
            SLUECompany.Properties.ReadOnly = False
            DEDate.ReadOnly = False
            SBRemove.Enabled = True
            SBAdd.Enabled = True
            SBSave.Enabled = True
            SBComplete.Enabled = True
            SBCancel.Enabled = True
            MENote.ReadOnly = False
            SBAttachement.Enabled = True
        Else
            'cancel or complete
            SLUECompany.Properties.ReadOnly = True
            DEDate.ReadOnly = True
            SBRemove.Enabled = False
            SBAdd.Enabled = False
            SBSave.Enabled = False
            SBComplete.Enabled = False
            SBCancel.Enabled = False
            MENote.ReadOnly = True
            SBAttachement.Enabled = True
        End If

        If is_view_attachment = "1" Then
            viewAttach()
        End If
    End Sub

    Sub view_comp()
        Dim query As String = "(SELECT 0 AS id_comp, '' AS comp_name) UNION ALL(SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUECompany, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormBuktiPickupPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Private Sub FormBuktiPickupDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormBuktiPickup.load_form()

        Try
            If Not id_pickup = "0" Then
                FormBuktiPickup.GVList.FocusedRowHandle = find_row(FormBuktiPickup.GVList, "id_pickup", id_pickup)
            End If
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub SBComplete_Click(sender As Object, e As EventArgs) Handles SBComplete.Click
        Cursor = Cursors.WaitCursor

        save("complete")

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Cursor = Cursors.WaitCursor

        save("draft")

        Cursor = Cursors.Default
    End Sub

    Sub save(type As String)
        GVList.ApplyFindFilter("")

        GVList.ActiveFilterString = ""

        SLUECompany_Validating(SLUECompany, New ComponentModel.CancelEventArgs)
        DEDate_Validating(DEDate, New ComponentModel.CancelEventArgs)

        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 217 AND id_report = " + id_pickup

        Dim cek_attachment As String = If(type = "complete" And execute_query(query_attachment, 0, True, "", "", "", "") = "0" And Not id_pickup = "0", "Please add attachement", "")

        If GVList.RowCount <= 0 Then
            errorCustom("No delivery selected")
        ElseIf Not formIsValidInPanel(ErrorProvider, PanelControl2) Then
            errorCustom("Please check your input")
        ElseIf Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        Else
            Dim continue_save As Boolean = True

            If type = "complete" Then
                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to complete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    continue_save = True
                Else
                    continue_save = False
                End If
            End If

            If continue_save Then
                Dim pickup_date As String = Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim id_comp As String = SLUECompany.EditValue.ToString
                Dim note As String = MENote.EditValue.ToString
                Dim id_report_status As String = If(type = "complete", "6", "0")

                Dim attachment As Boolean = False

                'tb_del_pickup
                If id_pickup = "0" Then
                    Dim query As String = "INSERT INTO tb_del_pickup (pickup_date, id_comp, note, id_report_status, created_date, created_by) VALUES ('" + pickup_date + "', " + id_comp + ", '" + addSlashes(note) + "', " + id_report_status + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_pickup = execute_query(query, 0, True, "", "", "", "")

                    attachment = True
                Else
                    Dim query As String = "UPDATE tb_del_pickup SET pickup_date = '" + pickup_date + "', id_comp = " + id_comp + ", note = '" + addSlashes(note) + "', id_report_status = " + id_report_status + ", updated_date = NOW(), updated_by = " + id_employee_user + "  WHERE id_pickup = " + id_pickup

                    execute_non_query(query, True, "", "", "", "")
                End If

                execute_non_query("DELETE FROM tb_del_pickup_det WHERE id_pickup = " + id_pickup, True, "", "", "", "")

                'tb_del_pickup_det
                Dim query_det As String = "INSERT INTO tb_del_pickup_det (id_pickup, id_pl_sales_order_del) VALUES "

                For i = 0 To GVList.RowCount - 1
                    If GVList.IsValidRowHandle(i) Then
                        query_det += "(" + id_pickup + ", " + GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString + "), "
                    End If
                Next

                query_det = query_det.Substring(0, query_det.Length - 2)

                execute_non_query(query_det, True, "", "", "", "")

                If attachment Then
                    warningCustom("Please add attachment")

                    FormDocumentUpload.is_no_delete = "-1"
                    FormDocumentUpload.is_view = "-1"
                    FormDocumentUpload.id_report = id_pickup
                    FormDocumentUpload.report_mark_type = "217"

                    FormDocumentUpload.ShowDialog()
                End If

                'check complete attachment
                query_attachment = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 217 AND id_report = " + id_pickup

                cek_attachment = execute_query(query_attachment, 0, True, "", "", "", "")

                If attachment And type = "complete" And cek_attachment = "0" Then
                    Dim query As String = "UPDATE tb_del_pickup SET id_report_status = 0 WHERE id_pickup = " + id_pickup

                    execute_non_query(query, True, "", "", "", "")

                    errorCustom("Couldn't complete because no attachment was uploaded")

                    load_form()
                Else
                    If type = "draft" Then
                        infoCustom("Data successfully saved")

                        load_form()
                    Else
                        Close()
                    End If
                End If
            End If
        End If
    End Sub

    Sub viewAttach()
        Cursor = Cursors.WaitCursor

        Dim id_report_status As String = execute_query("SELECT IFNULL((SELECT id_report_status FROM tb_del_pickup WHERE id_pickup = " + id_pickup + "), 0) AS id_report_status", 0, True, "", "", "", "")

        FormDocumentUpload.is_no_delete = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.is_view = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.id_report = id_pickup
        FormDocumentUpload.report_mark_type = "217"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBAttachement_Click(sender As Object, e As EventArgs) Handles SBAttachement.Click
        viewAttach()
    End Sub

    Private Sub SLUECompany_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUECompany.Validating
        If SLUECompany.EditValue.ToString = "0" Then
            ErrorProvider.SetError(SLUECompany, "Can't be blank")
        Else
            ErrorProvider.SetError(SLUECompany, "")
        End If
    End Sub

    Private Sub DEDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDate.Validating
        If DEDate.EditValue.ToString = "" Then
            ErrorProvider.SetError(DEDate, "Can't be blank")
        Else
            ErrorProvider.SetError(DEDate, "")
        End If
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "UPDATE tb_del_pickup SET id_report_status = 5 WHERE id_pickup = " + id_pickup

            execute_non_query(query, True, "", "", "", "")

            Close()
        End If
    End Sub

    Private Sub GVList_RowCountChanged(sender As Object, e As EventArgs) Handles GVList.RowCountChanged
        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                GVList.SetRowCellValue(i, "no", i + 1)
            End If
        Next
    End Sub
End Class