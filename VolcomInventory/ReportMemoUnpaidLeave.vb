Public Class ReportMemoUnpaidLeave
    Public Shared report_mark_type As String = "-1"
    Public Shared id_report As String = "-1"

    Private data_sign As DataTable = New DataTable

    Private Sub ReportMemoUnpaidLeave_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query_round As String = ""

        If get_opt_emp_field("is_leave_hour") = "2" Then
            query_round = ",1"
        End If

        Dim query As String = "SELECT formdc.form_dc,empl.id_emp,empl.emp_leave_number,empl.leave_purpose,lt.leave_type,empl.report_mark_type, empl.id_leave_type,
                                emp.employee_name, empl.emp_leave_date,emp.employee_code, emp.employee_position, emp.id_departement, dep.departement, 
                                emp_ch.employee_name AS name_ch, emp_ch.employee_code AS code_ch,emp.employee_join_date,
                                ROUND(empl.leave_remaining/60" + query_round + ") AS leave_remaining,ROUND(empl.leave_total/60" + query_round + ") AS leave_total,
                                periode.start_periode,periode.end_periode
                                FROM tb_emp_leave empl
                                INNER JOIN tb_lookup_leave_type lt ON lt.id_leave_type=empl.id_leave_type
                                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                INNER JOIN tb_m_employee emp_ch ON emp_ch.id_employee=empl.id_emp_change
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                LEFT JOIN tb_lookup_form_dc formdc ON formdc.id_form_dc=empl.id_form_dc
                                LEFT JOIN (SELECT id_emp_leave,MIN(datetime_start) AS start_periode,MAX(datetime_until) AS end_periode FROM tb_emp_leave_det GROUP BY id_emp_leave)
                                periode ON periode.id_emp_leave=empl.id_emp_leave
                                WHERE empl.id_emp_leave='" & id_report & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        XLNama.Text = data.Rows(0)("employee_name").ToString + " / " + data.Rows(0)("employee_code").ToString
        XLPosisi.Text = data.Rows(0)("employee_position").ToString
        XLDepartemen.Text = data.Rows(0)("departement").ToString
        XLPeriode.Text = Date.Parse(data.Rows(0)("start_periode").ToString).ToString("dd MMMM yyyy HH:mm") & " sampai " & Date.Parse(data.Rows(0)("end_periode").ToString).ToString("dd MMMM yyyy HH:mm")
        XLKeperluan.Text = data.Rows(0)("leave_purpose").ToString
        XLLama.Text = data.Rows(0)("leave_total").ToString & " jam"

        pre_load_asg_horz(report_mark_type, data.Rows(0)("id_emp").ToString, XrTable1, "1")

        Dim query_head As String = "
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT leave_memo_to1 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT leave_memo_to2 FROM tb_opt_emp LIMIT 1)
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        XLTo1.Text = data_head(0)("employee_name").ToString
        XLToPosition1.Text = data_head(0)("employee_position").ToString
        XLTo2.Text = data_head(1)("employee_name").ToString
        XLToPosition2.Text = data_head(1)("employee_position").ToString
        XLFrom.Text = data.Rows(0)("employee_name").ToString
        XLFromPosition.Text = data.Rows(0)("employee_position").ToString

        Dim y As Integer = 0

        For i = data_sign.Rows.Count - 1 To 0 Step -1
            If Not data_sign.Rows(i)("id_report_status").ToString = "1" Then
                Dim label1 As DevExpress.XtraReports.UI.XRLabel = New DevExpress.XtraReports.UI.XRLabel
                Dim label2 As DevExpress.XtraReports.UI.XRLabel = New DevExpress.XtraReports.UI.XRLabel

                label1.Text = data_sign.Rows(i)("employee_name").ToString
                label1.SizeF = New SizeF(300, 23)
                label1.LocationF = New PointF(123, y)
                label1.Font = New Font("Tahoma", 9.75)

                Dim pad1 As DevExpress.XtraPrinting.PaddingInfo = New DevExpress.XtraPrinting.PaddingInfo
                pad1.Left = 2
                pad1.Right = 2

                label1.Padding = pad1

                label2.Text = data_sign.Rows(i)("role").ToString
                label2.SizeF = New SizeF(250, 23)
                label2.LocationF = New SizeF(437, y)
                label2.Font = New Font("Tahoma", 9.75)

                Dim pad2 As DevExpress.XtraPrinting.PaddingInfo = New DevExpress.XtraPrinting.PaddingInfo
                pad2.Left = 2
                pad2.Right = 2

                label2.Padding = pad2

                XPCC.Controls.Add(label1)
                XPCC.Controls.Add(label2)

                y = y + 23
            End If
        Next

        'number
        Dim number As String = execute_query("SELECT CONCAT('/INT/', (SELECT `code` FROM tb_ot_memo_number_dep WHERE id_departement = " + data.Rows(0)("id_departement").ToString + "), '-MM/', (SELECT `code` FROM tb_ot_memo_number_mon WHERE `month` = " + DateTime.Parse(data.Rows(0)("emp_leave_date").ToString).ToString("%M") + "), '/', " + DateTime.Parse(data.Rows(0)("emp_leave_date").ToString).ToString("%y") + ") AS `number`", 0, True, "", "", "", "")

        XLNumber.Text = number
    End Sub

    Sub pre_load_asg_horz(ByVal report_mark_type As String, ByVal id_employee As String, ByVal xrtable As DevExpress.XtraReports.UI.XRTable, ByVal need_ceo As String)
        xrtable.Borders = DevExpress.XtraPrinting.BorderSide.None
        xrtable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

        Dim query As String = "
            SELECT * FROM (
            (SELECT c.report_status_display, 1 AS id_report_status, '' AS report_mark_note, 0 AS id_report_mark, c.report_status, 0 AS id_user, e.employee_name, 2 AS mark, '00:00:00' AS date_time, e.employee_position AS role, 2 AS is_head_dept, 2 AS is_asst_head_dept, 2 AS is_sub_head
            FROM tb_m_employee AS e
            LEFT JOIN tb_lookup_report_status c ON c.id_report_status = 1
            WHERE e.id_employee = " + id_employee + ")
            UNION
            (SELECT c.report_status_display, b.id_report_status, '' AS report_mark_note, 0 AS id_report_mark, c.report_status, a.id_user, e.employee_name, 2 AS mark, '00:00:00' AS date_time, e.employee_position AS role, a.is_head_dept, a.is_asst_head_dept, a.is_sub_head
            FROM tb_mark_asg_user a 
            LEFT JOIN tb_mark_asg b ON a.id_mark_asg = b.id_mark_asg
            LEFT JOIN tb_lookup_report_status c ON b.id_report_status = c.id_report_status
            LEFT JOIN tb_m_user d ON a.id_user = d.id_user
            LEFT JOIN tb_m_employee e ON d.id_employee = e.id_employee
            WHERE b.report_mark_type = " + report_mark_type + " AND a.level = 1
            ORDER BY b.id_report_status, a.id_mark_asg)) AS tb
            ORDER BY id_report_status ASC
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("is_head_dept").ToString = "1" Then
                Dim query_head As String = "
                    SELECT d.id_user_head AS id_user, eh.employee_name, eh.employee_position AS role
                    FROM tb_m_employee AS e
                    LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                    LEFT JOIN tb_m_user AS u ON d.id_user_head = u.id_user
                    LEFT JOIN tb_m_employee AS eh ON u.id_employee = eh.id_employee
                    WHERE e.id_employee = " + id_employee + "
                "
                Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
                data.Rows(i)("id_user") = data_head.Rows(0)("id_user")
                data.Rows(i)("employee_name") = data_head.Rows(0)("employee_name").ToString
                data.Rows(i)("role") = data_head.Rows(0)("role").ToString
            ElseIf data.Rows(i)("is_asst_head_dept").ToString = "1" Then
                Dim query_head As String = "
                    SELECT d.id_user_asst_head AS id_user, eh.employee_name, eh.employee_position AS role
                    FROM tb_m_employee AS e
                    LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                    LEFT JOIN tb_m_user AS u ON d.id_user_asst_head = u.id_user
                    LEFT JOIN tb_m_employee AS eh ON u.id_employee = eh.id_employee
                    WHERE e.id_employee = " + id_employee + "
                "
                Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
                data.Rows(i)("id_user") = data_head.Rows(0)("id_user")
                data.Rows(i)("employee_name") = data_head.Rows(0)("employee_name").ToString
                data.Rows(i)("role") = data_head.Rows(0)("role").ToString
            ElseIf data.Rows(i)("is_sub_head").ToString = "1" Then
                Dim query_head As String = "
                    SELECT d.id_usr_head_sub_dept AS id_user, eh.employee_name, eh.employee_position AS role
                    FROM tb_m_employee AS e
                    LEFT JOIN tb_m_departement_sub AS d ON e.id_departement_sub = d.id_departement_sub
                    LEFT JOIN tb_m_user AS u ON d.id_usr_head_sub_dept = u.id_user
                    LEFT JOIN tb_m_employee AS eh ON u.id_employee = eh.id_employee
                    WHERE e.id_employee = " + id_employee + "
                "
                Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
                data.Rows(i)("id_user") = data_head.Rows(0)("id_user")
                data.Rows(i)("employee_name") = data_head.Rows(0)("employee_name").ToString
                data.Rows(i)("role") = data_head.Rows(0)("role").ToString
            End If
        Next

        Dim data_hrm As DataTable = execute_query("
            SELECT id_employee, employee_name, employee_position, (SELECT id_user_head FROM tb_m_departement WHERE id_departement = 8) AS id_user FROM tb_m_employee WHERE id_employee = (SELECT usr.id_employee FROM tb_m_departement AS dep LEFT JOIN tb_m_user AS usr ON dep.id_user_head = usr.id_user WHERE dep.id_departement = 8)
        ", -1, True, "", "", "", "")

        'change to hrm
        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("id_report_status").ToString = "3" Then
                data.Rows(i)("id_user") = data_hrm.Rows(0)("id_user").ToString
                data.Rows(i)("employee_name") = data_hrm.Rows(0)("employee_name").ToString
                data.Rows(i)("role") = data_hrm.Rows(0)("employee_position").ToString
            End If
        Next

        'remove empty
        For i = data.Rows.Count - 1 To 0 Step -1
            Dim row As DataRow = data.Rows(i)

            If row("employee_name").ToString = "" Then
                data.Rows.Remove(row)
            End If
        Next

        Dim data_duplicate As DataTable = New DataTable

        data_duplicate.Columns.Add("id_user", GetType(Integer))
        data_duplicate.Columns.Add("total", GetType(Integer))
        data_duplicate.Columns.Add("inserted", GetType(Integer))

        'remove duplicate
        For i = 0 To data.Rows.Count - 1
            Dim index As Integer = -1

            For j = 0 To data_duplicate.Rows.Count - 1
                If data.Rows(i)("id_user").ToString = data_duplicate.Rows(j)("id_user").ToString Then
                    index = j
                End If
            Next

            If index = -1 Then
                data_duplicate.Rows.Add(data.Rows(i)("id_user"), 1, 0)
            Else
                data_duplicate.Rows(index)("total") = data_duplicate.Rows(index)("total") + 1
            End If
        Next

        Dim data_final As DataTable = data.Clone

        For i = 0 To data.Rows.Count - 1
            For j = 0 To data_duplicate.Rows.Count - 1
                If data.Rows(i)("id_user").ToString = data_duplicate.Rows(j)("id_user").ToString And data_duplicate.Rows(j)("inserted").ToString = "0" Then
                    data_final.ImportRow(data.Rows(i))

                    data_duplicate.Rows(j)("inserted") = 1
                End If
            Next
        Next

        data = data_final

        data_sign = data

        Dim cellsInRow As Integer = data.Rows.Count
        Dim rowHeight As Single = 25.0F

        Dim query_ceo As String = "SELECT rmt.is_need_ceo_appr,rmt.is_need_cfo_appr,rmt.id_user_ceo,rmt.id_user_cfo,emp_cfo.employee_name AS cfo_name,emp.employee_name FROM tb_lookup_report_mark_type rmt"
        query_ceo += " Left JOIN tb_m_user us ON us.id_user=16"
        query_ceo += " LEFT JOIN tb_m_employee emp On emp.id_employee=us.id_employee"
        query_ceo += " Left JOIN tb_m_user us_cfo ON us_cfo.id_user=124"
        query_ceo += " LEFT JOIN tb_m_employee emp_cfo On emp_cfo.id_employee=us_cfo.id_employee"
        query_ceo += " WHERE rmt.report_mark_type='" + report_mark_type + "'"
        Dim data_ceo As DataTable = execute_query(query_ceo, -1, True, "", "", "", "")

        'header
        Dim row_head As New DevExpress.XtraReports.UI.XRTableRow()
        row_head.HeightF = rowHeight
        For j As Integer = 0 To cellsInRow - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()
            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size + 1, FontStyle.Bold)

            'position
            'cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            If j < cellsInRow - 1 Then
                If data.Rows(j)("report_status").ToString = data.Rows(j + 1)("report_status").ToString Then
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                Else
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                End If
            Else
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            End If

            'merge or not
            If j > 0 Then
                If data.Rows(j)("report_status").ToString = data.Rows(j - 1)("report_status").ToString Then
                    cell.Text = ""
                Else
                    If data.Rows(j)("id_report_status").ToString = "3" And (need_ceo = "1" Or need_ceo = "1") Then
                        cell.Text = ""
                    Else
                        cell.Text = data.Rows(j)("report_status_display").ToString
                    End If
                End If
            Else
                If data.Rows(j)("id_report_status").ToString = "3" And (need_ceo = "1" Or need_ceo = "1") Then
                    cell.Text = ""
                Else
                    cell.Text = data.Rows(j)("report_status_display").ToString
                End If
            End If

            row_head.Cells.Add(cell)
        Next j

        'Approved by CEO
        If need_ceo = "1" Or need_ceo = "1" Then 'need approve
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size + 1, FontStyle.Bold)
            cell.Text = get_report_mark_status("3", "1")
            row_head.Cells.Add(cell)
        End If

        xrtable.Rows.Add(row_head)

        'insert row blank 3 times
        For i As Integer = 0 To 1
            Dim row_blank As New DevExpress.XtraReports.UI.XRTableRow()
            row_blank.HeightF = 10.0F
            For j As Integer = 0 To cellsInRow - 1
                Dim cell_blank As New DevExpress.XtraReports.UI.XRTableCell()
                cell_blank.Text = " "
                row_blank.Cells.Add(cell_blank)
            Next j
            xrtable.Rows.Add(row_blank)
        Next
        '

        'who name
        Dim row_name As New DevExpress.XtraReports.UI.XRTableRow()
        row_name.HeightF = rowHeight

        For j As Integer = 0 To cellsInRow - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size, FontStyle.Bold)
            cell.Text = data.Rows(j)("employee_name").ToString

            row_name.Cells.Add(cell)
        Next j

        'Approved by CEO
        If need_ceo = "1" Or need_ceo = "1" Then 'need approve
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()
            cell.CanGrow = True
            cell.Multiline = True
            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size, FontStyle.Bold)
            If need_ceo = "1" And need_ceo = "1" Then 'need approve
                cell.Text = data_ceo.Rows(0)("employee_name").ToString & " / " & vbNewLine & data_ceo.Rows(0)("cfo_name").ToString
            ElseIf need_ceo = "1" Then
                cell.Text = data_ceo.Rows(0)("employee_name").ToString
            Else
                cell.Text = data_ceo.Rows(0)("cfo_name").ToString
            End If
            row_name.Cells.Add(cell)
        End If

        xrtable.Rows.Add(row_name)

        'role
        Dim row_role As New DevExpress.XtraReports.UI.XRTableRow()
        row_role.HeightF = rowHeight

        For j As Integer = 0 To cellsInRow - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size, FontStyle.Bold)
            cell.Text = data.Rows(j)("role").ToString

            row_role.Cells.Add(cell)
        Next j

        'Approved by CEO
        If need_ceo = "1" Or need_ceo = "1" Then 'need approve
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()
            cell.Font = New Font(xrtable.Font.FontFamily, xrtable.Font.Size, FontStyle.Bold)
            cell.Text = "Director"
            row_role.Cells.Add(cell)
        End If

        xrtable.Rows.Add(row_role)
    End Sub
End Class