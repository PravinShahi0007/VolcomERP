Public Class FormReportMarkCancel
    Public id_report_mark_cancel As String = "-1"
    Public id_report_mark_cancel_user As String = "-1"
    '
    Dim id_report As String = "-1"
    Dim report_mark_type As String = "-1"
    '
    Dim is_view As String = "2"
    Private Sub FormReportMarkCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        act_load()
    End Sub

    Sub load_report_mark_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_able_cancel='1'"
        viewLookupQuery(LEReportMarkType, query, 0, "report_mark_type_name", "report_mark_type")
    End Sub

    Sub act_load()
        load_report_mark_type()
        If is_view = "1" Then
            Dim query As String = "SELECT rmc.*,emp.employee_name FROM tb_report_mark_cancel rmc 
                                            LEFT JOIN tb_m_user usr ON usr.id_user=rmc.created_by
                                            LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                            WHERE rmc.id_report_mark_cancel='" & id_report_mark_cancel & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TECancelBy.Text = data.Rows(0)("employee_name").ToString
                'TENumber.Text = data.Rows(0)("report_number").ToString
                DEDateProposed.EditValue = data.Rows(0)("created_datetime")
                MEReason.Text = data.Rows(0)("reason").ToString
                id_report = data.Rows(0)("id_report").ToString
                report_mark_type = data.Rows(0)("report_mark_type").ToString
                '
                Dim query_user As String = "SELECT * FROM tb_report_mark_cancel_user WHERE id_report_mark_cancel_user='" & id_report_mark_cancel_user & "'"
                Dim data_user As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data_user.Rows(0)("is_approve").ToString = "1" Then
                    BApprove.Enabled = False
                    BApprove.Text = "Approved"
                Else
                    BApprove.Enabled = True
                    BApprove.Text = "Approve"
                End If
                '
            End If
        Else
            'not view
            If id_report_mark_cancel = "-1" Then 'new
                DEDateProposed.EditValue = Now
                BAttachment.Visible = False
            Else 'edit
                Dim query_view As String = "SELECT * FROM tb_report_mark"
                BAttachment.Visible = True
                LEReportMarkType.Enabled = False
                PCAddDel.Visible = False
            End If
        End If
        but_show()
    End Sub

    Sub but_show()
        If is_view = "1" Then
            PCAddDel.Visible = False
        Else
            PCAddDel.Visible = True
            If GVReportList.RowCount > 0 Then
                BDelete.Visible = True
            Else
                BDelete.Visible = False
            End If
        End If
    End Sub

    Private Sub FormReportMarkCancel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_report_mark_cancel
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "142"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        If BApprove.Text = "Approve" Then
            'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to approve?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            'If confirm = Windows.Forms.DialogResult.Yes Then
            'End If
            Dim query_upd As String = "UPDATE tb_report_mark_cancel_user SET is_approve='1' WHERE id_report_mark_cancel_user='" & id_report_mark_cancel_user & "'"
            execute_non_query(query_upd, True, "", "", "", "")
            Close()
        End If
    End Sub

    Private Sub LEReportMarkType_EditValueChanged(sender As Object, e As EventArgs) Handles LEReportMarkType.EditValueChanged
        Try
            Dim qb As New ClassShowPopUp()
            qb.is_qb = "1"
            qb.report_mark_type = LEReportMarkType.EditValue.ToString
            qb.load_detail()
            Console.WriteLine(qb.query_view)
            Dim data As DataTable = execute_query(qb.query_view_blank, -1, True, "", "", "", "")
            GCReportList.DataSource = data
            qb.apply_gv_style(GVReportList, "-1")
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        GVReportList.DeleteSelectedRows()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim id_already As String = ""
        If GVReportList.RowCount > 0 Then
            id_already = "("
            For i As Integer = 0 To GVReportList.RowCount - 1
                If Not i = 0 Then
                    id_already += ","
                End If
                id_already += GVReportList.GetRowCellValue(i, "id_report").ToString
            Next
            id_already += ")"
        End If
        FormReportMarkCancelPick.id_already = id_already
        FormReportMarkCancelPick.ShowDialog()
    End Sub

    Private Sub SMViewDet_Click(sender As Object, e As EventArgs) Handles SMViewDet.Click
        If GVReportList.RowCount > 0 Then
            Dim sp As New ClassShowPopUp()
            sp.id_report = GVReportList.GetFocusedRowCellValue("id_report").ToString
            sp.report_mark_type = LEReportMarkType.EditValue.ToString
            sp.show()
        End If
    End Sub
End Class