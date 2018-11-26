Public Class FormItemDelDetail
    Public id As String = "-1"
    Public id_req As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""

    Private Sub FormItemDelDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'del detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()

            'default detail view
            viewDetail()
        Else
            Dim d As New ClassItemDel()
            Dim query As String = d.queryMain("AND del.id_item_del='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            TxtRequestNo.Text = data.Rows(0)("req_number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            TxtDept.Text = data.Rows(0)("departement").ToString
            TxtRequestedBy.Text = data.Rows(0)("requested_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetail()
            allow_status()
        End If
    End Sub

    Private Function getRmg(ByVal cond As String) As DataTable
        Dim query As String = "SELECT rd.id_item_req_det, rd.id_item_req, rd.id_item, i.item_desc, u.uom, rd.id_prepare_status, ps.prepare_status, rd.final_reason, (rd.qty-IFNULL(dq.qty_del,0.0)) AS `qty`, 
        '' AS remark, '' AS `stt`
        FROM tb_item_req_det rd
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        LEFT JOIN (
	        SELECT dd.id_item_req_det, SUM(dd.qty) AS `qty_del`
	        FROM tb_item_del_det dd
	        INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
	        WHERE d.id_report_status!=5
	        GROUP BY dd.id_item_req_det
        ) dq ON dq.id_item_req_det = rd.id_item_req_det
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = rd.id_prepare_status
        WHERE rd.id_item_req=" + id_req + " " + cond
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Dim data As DataTable = Nothing
        If action = "ins" Then
            data = getRmg("")
        ElseIf action = "upd" Then
            Dim query As String = "SELECT dd.id_item_del_det, dd.id_item_del, dd.id_item_req_det, dd.id_item, i.item_desc, u.uom, dd.qty, dd.remark 
            FROM tb_item_del_det dd
            INNER JOIN tb_item i ON i.id_item = dd.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            WHERE dd.id_item_del=" + id + " "
            data = execute_query(query, -1, True, "", "", "", "")
        End If
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVData.OptionsBehavior.Editable = False
        BtnSave.Visible = False

        If check_edit_report_status(id_report_status, "156", id) Then
            MENote.Enabled = True
        Else
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormItemDelDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update status
            Dim query As String = "UPDATE tb_item_del SET id_report_status=5 WHERE id_item_del='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 156, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            FormItemDel.viewDelivery()
            FormItemDel.GVDelivery.FocusedRowHandle = find_row(FormItemDel.GVDelivery, "id_item_del", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            gcx = GCData
            gvx = GVData
            ReportItemDel.id = id
            ReportItemDel.dt = gcx.DataSource
            Dim Report As New ReportItemDel()


            'creating And saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse Val
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelRequestNo.Text = TxtRequestNo.Text.ToUpper
            Report.LabelDept.Text = TxtDept.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString
            Report.LNote.Text = MENote.Text.ToString


            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCData)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "156"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "156", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "156"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek data
        Cursor = Cursors.WaitCursor
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GridColumnStt.Visible = False
        Dim cond_data As Boolean = True
        Dim dcs As DataTable = getRmg("")
        makeSafeGV(GVData)
        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
            Dim id_item_req_det_cek As String = GVData.GetRowCellValue(i, "id_item_req_det").ToString
            Dim qty_cek As Decimal = GVData.GetRowCellValue(i, "qty")
            Dim data_filter_cek As DataRow() = dcs.Select("[id_item_req_det]='" + id_item_req_det_cek + "' ")
            If qty_cek > data_filter_cek(0)("qty") Then
                GVData.SetRowCellValue(i, "stt", "Qty can't exceed " + data_filter_cek(0)("qty").ToString + ";")
                cond_data = False
            Else
                GVData.SetRowCellValue(i, "stt", "OK")
            End If
        Next
        Cursor = Cursors.Default

        If GVData.Columns("qty").SummaryItem.SummaryValue <= 0 Then
            warningCustom("Please complete all data")
        ElseIf Not cond_data Then
            GridColumnStt.VisibleIndex = 100
            warningCustom("Can't save, some item exceed limit qty")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim note As String = addSlashes(MENote.Text.ToString)

                'query main
                Dim qm As String = "INSERT INTO tb_item_del(id_item_req, created_date, created_by, note, id_report_status) VALUES 
                ('" + id_req + "', NOW(), '" + id_user + "', '" + note + "', '1'); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ",156); ", True, "", "", "", "")

                'query det
                GVData.ActiveFilterString = "[qty]>0"
                Dim qd As String = "INSERT INTO tb_item_del_det(id_item_del, id_item_req_det, id_item, qty, remark) VALUES "
                For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_item_req_det As String = GVData.GetRowCellValue(d, "id_item_req_det").ToString
                    Dim id_item As String = GVData.GetRowCellValue(d, "id_item").ToString
                    Dim qty As String = decimalSQL(GVData.GetRowCellValue(d, "qty").ToString)
                    Dim remark As String = addSlashes(GVData.GetRowCellValue(d, "remark").ToString)

                    If d > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id + "', '" + id_item_req_det + "', '" + id_item + "', '" + qty + "','" + remark + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If
                makeSafeGV(GVData)

                'submit
                submit_who_prepared(156, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                infoCustom("Delivery : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle
        Dim id_item_req_det As String = GVData.GetRowCellValue(rh, "id_item_req_det").ToString
        If e.Column.FieldName = "qty" Then
            If e.Value >= 0 Then
                Dim old_value As Decimal = GVData.ActiveEditor.OldEditValue
                Dim dcek As DataTable = getRmg("AND rd.id_item_req_det='" + id_item_req_det + "' ")
                If e.Value > dcek.Rows(0)("qty") Then
                    warningCustom("Qty can't exceed " + dcek.Rows(0)("qty").ToString)
                    GVData.SetRowCellValue(rh, "qty", old_value)
                End If
                GVData.BestFitColumns()
            Else
                GVData.SetRowCellValue(rh, "qty", 0)
                GVData.BestFitColumns()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=156 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class