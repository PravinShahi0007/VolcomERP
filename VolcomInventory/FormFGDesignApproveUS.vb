Public Class FormFGDesignApproveUS
    Public id As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""
    Dim is_confirm As String = "-1"
    Public is_new As String = "-1"

    Private Sub FormFGDesignApproveUS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        'main
        Dim query As String = "SELECT number, created_date, IFNULL(is_design_app_us,0) AS `is_design_app_us`,
        IFNULL(is_sample_app_us,0) AS `is_sample_app_us`, reason_no_need_sample_app, id_report_status, is_confirm
        FROM tb_m_design_approve_us WHERE id_design_approve_us='" + id + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        is_confirm = data.Rows(0)("is_confirm").ToString
        If data.Rows(0)("is_sample_app_us").ToString = "1" Then
            CENoNeedSampleApp.EditValue = True
        Else
            CENoNeedSampleApp.EditValue = False
        End If
        TxtReason.Text = data.Rows(0)("reason_no_need_sample_app").ToString

        'detil
        Dim query_det As String = "SELECT dsg.id_design, dsg.design_display_name, dsg.design_fabrication FROM tb_m_design_approve_us_det ad
        INNER JOIN tb_m_design dsg ON dsg.id_design = ad.id_design
        WHERE id_design_approve_us='" + id + "' "
        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
        GCData.DataSource = data_det
        GVData.BestFitColumns()

    End Sub

    Sub allow_status()
        If is_confirm = "1" Then
            BtnConfirm.Visible = False
            BtnCancellApprove.Visible = True
            BtnMark.Visible = True
            CENoNeedSampleApp.Enabled = False
        Else
            BtnConfirm.Visible = True
            BtnCancellApprove.Visible = False
            BtnMark.Visible = False
            CENoNeedSampleApp.Enabled = True
        End If

        If id_report_status = "5" Or id_report_status = "6" Then
            BtnCancellApprove.Visible = False
        End If
    End Sub

    Private Sub BtnCancellApprove_Click(sender As Object, e As EventArgs) Handles BtnCancellApprove.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update status
            Dim query As String = "UPDATE tb_m_design_approve_us SET id_report_status=5 WHERE id_design_approve_us='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "170", id)
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            If is_new = "-1" Then
                FormFGDesignList.viewData()
            End If
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "170"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachmentDesign_Click(sender As Object, e As EventArgs) Handles BtnAttachmentDesign.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "170"
        FormDocumentUpload.id_report = id
        If is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnAttachmentSample.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "171"
        FormDocumentUpload.id_report = id
        If is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CENoNeedSampleApp_CheckedChanged(sender As Object, e As EventArgs) Handles CENoNeedSampleApp.CheckedChanged
        If CENoNeedSampleApp.EditValue = True Then
            BtnAttachmentSample.Enabled = False
            PanelControlReason.Enabled = True
        Else
            BtnAttachmentSample.Enabled = True
            PanelControlReason.Enabled = False
        End If
    End Sub
End Class