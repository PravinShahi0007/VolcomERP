Public Class FormPurcReceiveDet
    Public id As String = "-1"
    Dim id_purc_order As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Private Sub FormPurcReceiveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim r As New ClassPurcReceive()
        Dim query As String = r.queryMain("AND r.id_purc_rec='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        TxtNumber.Text = data.Rows(0)("purc_rec_number").ToString
        created_date = DateTime.Parse(data.Rows(0)("date_created")).ToString("yyyy-MM-dd HH:mm:ss")
        DECreated.EditValue = data.Rows(0)("date_created")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_purc_order = data.Rows(0)("id_purc_order").ToString
        TxtOrderNumber.Text = data.Rows(0)("purc_order_number").ToString
        TxtVendor.Text = data.Rows(0)("vendor").ToString

        viewSummary()
        allow_status()
    End Sub

    Sub viewDetail()

    End Sub

    Sub viewSummary()
        Dim query As String = ""
        If is_confirm = "1" Then
            query = "SELECT rd.id_purc_rec_det, rd.id_purc_rec, 
            rd.id_item, i.item_desc, i.id_uom, u.uom,
            rd.id_purc_order_det, pod.`value`, pod.qty AS `qty_order`, rd.qty, rd.note 
            FROM tb_purc_rec_det rd
            INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            INNER JOIN tb_item i ON i.id_item = rd.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            WHERE rd.id_purc_rec=" + id + " "
        Else
            query = "SELECT IFNULL(rd.id_purc_rec_det,0) AS `id_purc_rec_det`, IFNULL(rd.id_purc_rec,0) AS `id_purc_rec`,
            pod.id_item, i.item_desc, i.id_uom, u.uom,
            pod.id_purc_order_det, pod.`value`, pod.qty AS `qty_order`, IFNULL(rd.qty,0) AS `qty`, IFNULL(rd.note,'') AS  `note` 
            FROM tb_purc_order_det pod
            LEFT JOIN tb_purc_rec_det rd ON rd.id_purc_order_det = pod.id_purc_order_det AND rd.id_purc_rec=-1
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            WHERE pod.id_purc_order=" + id_purc_order + " "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnSave.Visible = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnDraftJournal.Visible = False
            MENote.Enabled = True
            GVSummary.OptionsBehavior.Editable = True
        Else
            BtnSave.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnDraftJournal.Visible = True
            MENote.Enabled = False
            GVSummary.OptionsBehavior.Editable = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnDraftJournal.Visible = False
            BtnViewJournal.Visible = True
            GVSummary.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnSave.Visible = False
            BtnCancell.Visible = False
            BtnDraftJournal.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            GVSummary.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub FormPurcReceiveDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click

    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_purc_rec SET id_report_status=5 WHERE id_purc_rec='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 148, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormPurcReceive.viewReceive()
            FormPurcReceive.GVReceive.FocusedRowHandle = find_row(FormPurcReceive.GVReceive, "id_purc_rec", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
        Else
            If XTCReceive.SelectedTabPageIndex = 0 Then
                print_raw_no_export(GCSummary)
            ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
                print_raw_no_export(GCDetail)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "148"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "148"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSummary.CellValueChanged
        If e.Column.FieldName = "qty" Then
            If e.Value > 0 Then
                Dim rh As Integer = e.RowHandle
                Dim id_purc_order_det As String = GVSummary.GetRowCellValue(rh, "id_purc_order_det").ToString
                Dim query As String = "SELECT pod.id_purc_order_det, pod.qty AS `qty_order`, IFNULL(rd.qty,0) AS `qty_rec`, (pod.qty-IFNULL(rd.qty,0)) AS `qty_remaining`
                FROM tb_purc_order_det pod
                LEFT JOIN (
	                SELECT rd.id_purc_order_det, SUM(rd.qty) AS `qty` 
	                FROM tb_purc_rec_det rd
	                INNER JOIN tb_purc_rec r
	                WHERE r.id_report_status!=5 AND r.id_purc_rec!=" + id + "
	                GROUP BY rd.id_purc_order_det
                ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
                WHERE pod.id_purc_order=" + id_purc_order + " AND pod.id_purc_order_det=" + id_purc_order_det + " "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            End If
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class