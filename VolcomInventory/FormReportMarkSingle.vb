Public Class FormReportMarkSingle 
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"
    Public id_report_mark As String = "-1"

    Private Sub FormReportMarkSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_user(LEUser)
        view_status_report(LEStatus)

        If id_report_mark <> "-1" Then
            'edit
            Dim query As String = String.Format("SELECT id_user,id_report_status FROM tb_report_mark WHERE id_report_mark = '{0}'", id_report_mark)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            LEStatus.EditValue = Nothing
            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            LEUser.EditValue = data.Rows(0)("id_user").ToString
        End If
    End Sub

    Sub view_user(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT a.id_user,b.employee_name FROM tb_m_user a INNER JOIN tb_m_employee b ON a.id_employee=b.id_employee ORDER BY b.employee_name ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Lookup.Properties.DataSource = Nothing
        Lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "employee_name"
        lookup.Properties.ValueMember = "id_user"
        lookup.EditValue = data.Rows(0)("id_user").ToString
    End Sub

    Private Sub view_status_report(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status WHERE id_report_status!='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub FormReportMarkSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If FormReportMark.id_report_status_report >= LEStatus.EditValue.ToString Then
            stopCustom("This status already locked.")
        Else
            If id_report_mark <> "-1" Then
                'edit
                Dim query_jml As String = String.Format("SELECT COUNT(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_user='{2}' AND id_report_mark !='{3}'", report_mark_type, id_report, LEUser.EditValue.ToString, id_report_mark)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" Person.")
                Else
                    Dim query As String = String.Format("UPDATE tb_report_mark SET id_report_status='{0}',id_user='{1}' WHERE id_report_mark='{2}'", LEStatus.EditValue.ToString, LEUser.EditValue.ToString, id_report_mark)
                    execute_non_query(query, True, "", "", "", "")
                    FormReportMark.view_mark()
                    Close()
                End If
            Else
                'new
                Dim query_jml As String = String.Format("SELECT COUNT(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_user='{2}' AND id_report_mark !='{3}'", report_mark_type, id_report, LEUser.EditValue.ToString, id_report_mark)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" Person.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_report_mark(report_mark_type,id_report,id_report_status,id_user) VALUES('{0}','{1}','{2}','{3}')", report_mark_type, id_report, LEStatus.EditValue.ToString, LEUser.EditValue.ToString)
                    execute_non_query(query, True, "", "", "", "")
                    FormReportMark.view_mark()
                    Close()
                End If
            End If
        End If
    End Sub
End Class