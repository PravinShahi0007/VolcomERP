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
            'Dim r As New ClassItemRequest()
            'Dim query As String = r.queryMain("AND r.id_item_req='" + id + "' ", "1")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'id_report_status = data.Rows(0)("id_report_status").ToString
            'TxtNumber.Text = data.Rows(0)("number").ToString
            'created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            'DECreated.EditValue = data.Rows(0)("created_date")
            'MENote.Text = data.Rows(0)("note").ToString
            'TxtDept.Text = data.Rows(0)("departement").ToString
            'TxtRequestedBy.Text = data.Rows(0)("created_by_name").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetail()
            allow_status()
        End If
    End Sub

    Private Function getRmg(ByVal cond As String) As DataTable
        Dim query As String = "SELECT rd.id_item_req_det, rd.id_item_req, rd.id_item, i.item_desc, u.uom, rd.id_prepare_status, ps.prepare_status, rd.final_reason, (rd.qty-IFNULL(dq.qty_del,0.0)) AS `qty`, 
        rd.remark, '' AS `stt`
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
            Dim query As String = ""
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
            BtnCancell.Visible = True
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
End Class