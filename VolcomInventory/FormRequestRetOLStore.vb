Public Class FormRequestRetOLStore
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim rmt As String = "246"
    Public action As String = "-1"
    Dim scan_mode As String = ""
    Dim dt As DataTable
    Dim lead_time_return As Integer = 0

    Private Sub FormRequestRetOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub checkDate()
        Cursor = Cursors.WaitCursor
        Dim id_group As String = "-1"
        Try
            id_group = SLECompGroup.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT lead_time_return FROM tb_m_comp_group WHERE id_comp_group='" + id_group + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            lead_time_return = data.Rows(0)("lead_time_return")
        Else
            lead_time_return = 0
        End If
        Dim diff As Integer = DateDiff("d", DERecByCust.EditValue, DEReqDate.EditValue).ToString
        If diff <= lead_time_return Then
            LabelValidDate.Text = "OK"
            LabelValidDate.ForeColor = Color.Green
        Else
            LabelValidDate.Text = "NOT VALID"
            LabelValidDate.ForeColor = Color.Red
        End If
        'Console.WriteLine(diff.ToString)
        'Console.WriteLine("Lead time :" + lead_time_return.ToString)
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim dt_now As DateTime = getTimeDB()
            DECreated.EditValue = dt_now
            DEReqDate.EditValue = dt_now
            DERecByCust.EditValue = dt_now
            SLECompGroup.Focus()
            viewDetail()
        ElseIf action = "upd" Then
            'main
            Dim query_c As ClassRequestRetOLStore = New ClassRequestRetOLStore()
            Dim query As String = query_c.queryMain("AND r.id_ol_store_ret_req=" + id + " ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            SLECompGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            TxtOrderNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            DERecByCust.EditValue = data.Rows(0)("receive_cust_date")
            TxtRetRequest.Text = data.Rows(0)("ret_req_number").ToString
            DEReqDate.EditValue = data.Rows(0)("ret_req_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString

            'detail
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_ol_store_ret_req_det, d.id_ol_store_ret_req, 
        d.id_sales_order_det, sod.id_product, p.product_full_code AS `code`,d.product_full_code, p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id
        FROM tb_ol_store_ret_req_det d 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = sod.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE d.id_ol_store_ret_req=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLECompGroup.Enabled = False
        BtnBrowseOrder.Enabled = False
        BtnPrint.Visible = True
        PanelControlNav.Visible = False
        TxtRetRequest.Enabled = False
        DEReqDate.Enabled = False
        BtnSaveChanges.Visible = False

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            MENote.Enabled = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            MENote.Enabled = False
        ElseIf id_report_status = "1" Then
            MENote.Enabled = True
        End If
    End Sub

    Private Sub TxtRetRequest_EditValueChanged(sender As Object, e As EventArgs) Handles TxtRetRequest.EditValueChanged

    End Sub

    Private Sub FormRequestRetOLStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this transaction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_store_ret_req SET id_report_status=5 WHERE id_ol_store_ret_req='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormOlStoreReturnList.viewRequest()
            FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        makeSafeGV(GVData)
        checkDate()

        If TxtOrderNumber.Text = "" Or TxtRetRequest.Text = "" Or GVData.RowCount <= 0 Then
            stopCustom("Please complete all data")
        ElseIf LabelValidDate.Text <> "OK" Then
            stopCustom("Request date not valid")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                BtnSaveChanges.Visible = False
                Cursor = Cursors.WaitCursor
                BtnSaveChanges.Enabled = False

                Dim id_comp_group As String = SLECompGroup.EditValue.ToString
                Dim sales_order_ol_shop_number As String = addSlashes(TxtOrderNumber.Text)
                Dim receive_cust_date As String = DateTime.Parse(DERecByCust.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim ret_req_number As String = addSlashes(TxtRetRequest.Text)
                Dim ret_req_date As String = DateTime.Parse(DEReqDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)

                'main 
                Dim query As String = "INSERT INTO tb_ol_store_ret_req(id_comp_group, sales_order_ol_shop_number, receive_cust_date, ret_req_number, ret_req_date, created_date, created_by, updated_date, updated_by, note, id_report_status) VALUES 
                ('" + id_comp_group + "', '" + sales_order_ol_shop_number + "', '" + receive_cust_date + "', '" + ret_req_number + "', '" + ret_req_date + "', NOW(), " + id_user + ", NOW(), " + id_user + ", '" + note + "', 1);SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + "," + rmt + "); ", True, "", "", "", "")

                'detail
                Dim query_det As String = "INSERT INTO tb_ol_store_ret_req_det(id_ol_store_ret_req, id_sales_order_det, product_full_code) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                    Dim product_full_code As String = GVData.GetRowCellValue(i, "product_full_code").ToString

                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id + "', '" + id_sales_order_det + "', '" + product_full_code + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(rmt, id, id_user)

                ''refresh
                FormOlStoreReturnList.viewRequest()
                FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
                action = "upd"
                actionLoad()
                infoCustom("Request return submitted.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnBrowseOrder_Click(sender As Object, e As EventArgs) Handles BtnBrowseOrder.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreBrowseOrder.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        checkDate()
    End Sub

    Private Sub DERecByCust_EditValueChanged(sender As Object, e As EventArgs) Handles DERecByCust.EditValueChanged
        checkDate()
    End Sub

    Private Sub DEReqDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEReqDate.EditValueChanged
        checkDate()
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.DeleteRow(GVData.FocusedRowHandle)
            CType(GVData.DataSource, DataTable).AcceptChanges()
            GCData.RefreshDataSource()
            GVData.RefreshData()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormRequestRetOLStoreSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class