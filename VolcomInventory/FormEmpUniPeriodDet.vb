Public Class FormEmpUniPeriodDet
    Public action As String = "-1"
    Public id_emp_uni_period As String = "-1"

    Private Sub FormEmpUniPeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTCUni.Enabled = False
            BtnSave.Text = "Create New"
        Else
            Dim query_c As New ClassEmpUni()
            Dim query As String = query_c.queryMain("AND u.id_emp_uni_period=" + id_emp_uni_period + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtPeriodName.Text = data.Rows(0)("period_name").ToString
            DEStart.EditValue = data.Rows(0)("selection_date_start")
            DEEnd.EditValue = data.Rows(0)("selection_date_end")
            DEDist.EditValue = data.Rows(0)("distribution_date")
            XTCUni.Enabled = True
            BtnSave.Text = "Save"
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT b.id_emp_uni_budget, b.id_emp_uni_period, 
        b.id_employee, e.employee_code, e.employee_name, e.id_departement, d.departement, e.employee_position, e.id_employee_level, l.employee_level,
        b.budget, 0 AS `amount`, 0 AS `total_qty`, '-' AS `del_report_status`
        FROM tb_emp_uni_budget b
        INNER JOIN tb_emp_uni_period p ON p.id_emp_uni_period = b.id_emp_uni_period
        INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        LEFT JOIN tb_lookup_employee_level l ON l.id_employee_level=e.id_employee_level
        WHERE b.id_emp_uni_period=" + id_emp_uni_period + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DEStart.Text <> "" And DEEnd.Text <> "" And DEDist.Text <> "" Then
            Dim period_name As String = addSlashes(TxtPeriodName.Text)
            Dim selection_date_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim selection_date_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim distribution_date As String = DateTime.Parse(DEDist.EditValue.ToString).ToString("yyyy-MM-dd")
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_emp_uni_period(period_name, selection_date_start, selection_date_end, created_date, distribution_date) VALUES "
                query += "('" + period_name + "', '" + selection_date_start + "', '" + selection_date_end + "', NOW(), '" + distribution_date + "'); SELECT LAST_INSERT_ID(); "
                id_emp_uni_period = execute_query(query, 0, True, "", "", "", "")
                action = "upd"
                actionLoad()
                infoCustom("Uniform period was created successfully, please input detail budget.")
            Else
                Dim query As String = "UPDATE tb_emp_uni_period SET period_name='" + period_name + "', selection_date_start='" + selection_date_start + "', selection_date_end='" + selection_date_end + "', distribution_date='" + distribution_date + "' WHERE id_emp_uni_period='" + id_emp_uni_period + "' "
                execute_non_query(query, True, "", "", "", "")
                action = "upd"
                actionLoad()
                infoCustom("Uniform period was edited successfully.")
            End If
            FormEmpUniPeriod.viewUniformPeriod()
            FormEmpUniPeriod.GVUni.FocusedRowHandle = find_row(FormEmpUniPeriod.GVUni, "id_emp_uni_period", id_emp_uni_period)
        Else
            stopCustom("Period can't blank")
        End If

    End Sub

    Private Sub FormEmpUniPeriodDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniPeriodSingle.action = "ins"
        FormEmpUniPeriodSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class