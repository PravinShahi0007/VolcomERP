Public Class FormReportMarkCancel
    Public id_report_mark_cancel As String = "-1"
    Public id_report_mark_cancel_user As String = "-1"
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
                '
            End If
        Else
            'not view
            If id_report_mark_cancel = "-1" Then 'new
                DEDateProposed.EditValue = Now
                BAttachment.Visible = False
            Else 'edit
                Dim query_view As String = "SELECT rmc.*,emp.`employee_name` FROM tb_report_mark_cancel rmc
                                            INNER JOIN tb_m_user usr ON usr.`id_user`=rmc.`created_by`
                                            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                            WHERE rmc.id_report_mark_cancel='" & id_report_mark_cancel & "'"
                Dim data_view As DataTable = execute_query(query_view, -1, True, "", "", "", "")
                '
                TECancelBy.Text = data_view.Rows(0)("employee_name").ToString
                TENumber.Text = data_view.Rows(0)("id_report_mark_cancel").ToString
                DEDateProposed.EditValue = data_view.Rows(0)("created_datetime")
                MEReason.Text = data_view.Rows(0)("reason").ToString
                '
                BAttachment.Visible = True
                LEReportMarkType.Enabled = False
                PCAddDel.Visible = False
                '
                load_det()
            End If
        End If
        but_show()
    End Sub
    Sub load_det()
        Dim qb As New ClassShowPopUp()
        qb.is_qb = "1"
        qb.id_report_mark_cancel = id_report_mark_cancel
        qb.report_mark_type = LEReportMarkType.EditValue.ToString
        qb.load_detail()
        Dim data As DataTable = execute_query(qb.query_view_edit, -1, True, "", "", "", "")
        GCReportList.DataSource = data

        qb.apply_gv_style(GVReportList, "-1")
    End Sub


    Sub but_show()
        If is_view = "1" Or Not id_report_mark_cancel = "-1" Then
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
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.report_mark_type = "142"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        'If BApprove.Text = "Approve" Then
        '    'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to approve?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    'If confirm = Windows.Forms.DialogResult.Yes Then
        '    'End If
        '    Dim query_upd As String = "UPDATE tb_report_mark_cancel_user SET is_approve='1' WHERE id_report_mark_cancel_user='" & id_report_mark_cancel_user & "'"
        '    execute_non_query(query_upd, True, "", "", "", "")
        '    Close()
        'End If
        If is_view = "2" Then
            If id_report_mark_cancel = "-1" Then 'new
                If GVReportList.RowCount > 0 Then
                    Dim query As String = "INSERT INTO tb_report_mark_cancel(created_by,created_datetime,reason,report_mark_type) VALUES('" & id_user & "',NOW(),'" & addSlashes(MEReason.Text) & "','" & LEReportMarkType.EditValue.ToString & "');SELECT LAST_INSERT_ID() "
                    id_report_mark_cancel = execute_query(query, 0, True, "", "", "", "")
                    Dim query_det As String = "INSERT INTO tb_report_mark_cancel_report(id_report_mark_cancel,id_report) VALUES"
                    For i As Integer = 0 To GVReportList.RowCount - 1
                        If Not i = 0 Then
                            query_det += ","
                        End If
                        query_det += "('" & id_report_mark_cancel & "','" & GVReportList.GetRowCellValue(i, "id_report").ToString & "')"
                    Next
                    execute_non_query(query_det, True, "", "", "", "")
                    FormReportMarkCancelList.load_cancel_form()
                    Close()
                Else
                    warningCustom("Please select the report first")
                End If
            Else
                Dim query As String = "UPDATE tb_report_mark_cancel SET reason='" & addSlashes(MEReason.Text) & "' WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        End If
    End Sub

    Private Sub LEReportMarkType_EditValueChanged(sender As Object, e As EventArgs) Handles LEReportMarkType.EditValueChanged
        Try
            Dim qb As New ClassShowPopUp()
            qb.is_qb = "1"
            qb.report_mark_type = LEReportMarkType.EditValue.ToString
            qb.load_detail()
            Dim data As DataTable

            If id_report_mark_cancel_user = "-1" Then
                data = execute_query(qb.query_view_blank, -1, True, "", "", "", "")
            Else
                data = execute_query(qb.query_view_edit, -1, True, "", "", "", "")
            End If

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