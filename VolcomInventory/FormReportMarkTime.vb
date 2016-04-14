Public Class FormReportMarkTime
    Public id_report_mark As String = "-1"

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormReportMarkTime_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportMarkTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = String.Format("SELECT COALESCE(HOUR(report_mark_lead_time),0) AS hr,COALESCE(MINUTE(report_mark_lead_time),0) AS mnt,COALESCE(SECOND(report_mark_lead_time),0) AS scn FROM tb_report_mark WHERE id_report_mark ='{0}'", id_report_mark)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'going to marked
        Dim hr, mnt, scn As String
        hr = data.Rows(0)("hr").ToString
        mnt = data.Rows(0)("mnt").ToString
        scn = data.Rows(0)("scn").ToString

        TEHour.Text = hr
        TEMin.Text = mnt
        TESec.Text = scn
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim time_fix As String = ""
        Dim query As String = ""

        Try
            time_fix = TEHour.Text & ":" & TEMin.Text & ":" & TESec.Text

            If CEResetST.Checked = True Or FormReportMark.GVMark.GetFocusedRowCellValue("date_time_start") = "" Then
                query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time = '{0}',report_mark_start_datetime=NOW() WHERE id_report_mark = '{1}'", time_fix, id_report_mark)
            Else
                query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time = '{0}' WHERE id_report_mark = '{1}'", time_fix, id_report_mark)
            End If

            execute_non_query(query, True, "", "", "", "")

            If CEGenST.Checked = True Then
                'get startdatetime first
                Dim start_datetime As String = ""
                Dim query_datetime As String = "SELECT CONCAT_WS(' ',DATE(report_mark_start_datetime),TIME(report_mark_start_datetime)) AS start_datetime FROM tb_report_mark WHERE id_report_mark='" & id_report_mark & "'"
                Dim data_datetime As DataTable = execute_query(query_datetime, -1, True, "", "", "", "")

                start_datetime = data_datetime.Rows(0)("start_datetime").ToString()

                'loop all level
                If Not FormReportMark.GVMark.GetFocusedRowCellValue("id_mark_asg").ToString = "" Then
                    Dim query_cek As String = "select id_report_mark from tb_report_mark a "
                    query_cek += "WHERE a.level > (SELECT b.level FROM tb_report_mark b WHERE b.id_report_mark='" & id_report_mark & "' LIMIT 1) "
                    query_cek += "AND a.id_mark_asg = (SELECT b.id_mark_asg FROM tb_report_mark b WHERE b.id_report_mark='" & id_report_mark & "' LIMIT 1)"
                    query_cek += "AND a.report_mark_type='" & FormReportMark.report_mark_type & "' "
                    query_cek += "AND a.id_report='" & FormReportMark.id_report & "'"

                    Dim data As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time = '{0}',report_mark_start_datetime=ADDTIME('{3}',{2}*TIME('{0}')) WHERE id_report_mark = '{1}'", time_fix, data.Rows(i)("id_report_mark").ToString(), i + 1, start_datetime)
                        execute_non_query(query, True, "", "", "", "")
                    Next
                End If
                '
            End If
            FormReportMark.view_mark()
            FormReportMark.GVMark.FocusedRowHandle = find_row(FormReportMark.GVMark, "id_report_mark", id_report_mark)
            Close()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
End Class