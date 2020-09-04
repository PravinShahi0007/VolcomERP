Public Class FormPurcOrderCloseReceiving
    Public id_close_receiving As String = "0"

    Private Sub FormPurcOrderCloseReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        Dim query As String = "
            (SELECT c.number, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, c.id_report_status, s.report_status
            FROM tb_purc_order_close AS c
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS s ON c.id_report_status = s.id_report_status
            WHERE id_close_receiving = " + id_close_receiving + ")
            
            UNION ALL

            (SELECT '[autogenerate]' AS number, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_date, '" + get_emp(id_employee_user, "2") + "' AS created_by, 0 AS id_report_status, '' AS report_status)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedDate.EditValue = data.Rows(0)("created_date").ToString
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        TEReportStatus.EditValue = data.Rows(0)("report_status").ToString

        'details
        GCPO.DataSource = execute_query("
            SELECT po.est_date_receive, po.id_purc_order, c.comp_number, c.comp_name, po.purc_order_number, (SUM(pod.qty * (pod.value - pod.discount)) - po.disc_value + po.vat_value) AS total_po, IF(ISNULL(rec.id_purc_order_det), 0, SUM(rec.qty * (pod.value - pod.discount)) - (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value - pod.discount)) * po.disc_value) + (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value-pod.discount)) * po.vat_value)) AS total_rec, (IFNULL(SUM(rec.qty * pod.value), 0) / SUM(pod.qty * pod.value)) * 100 AS rec_progress, IF(po.is_close_rec = 1, 'Closed', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) <= 0, 'Waiting', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) < 1, 'Partial', 'Complete'))) AS rec_status, cl_d.close_rec_reason AS close_rec_reason
            FROM tb_purc_order_close_det cl_d
            INNER JOIN tb_purc_order po ON cl_d.id_purc_order = po.id_purc_order
            INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order` = po.`id_purc_order`
            INNER JOIN tb_m_user usr_cre ON usr_cre.id_user = po.created_by
            INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee = usr_cre.id_employee
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN 
            ( 
                SELECT recd.`id_purc_order_det`, SUM(recd.`qty`) AS qty 
                FROM tb_purc_rec_det recd 
                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec` = recd.`id_purc_rec` AND rec.`id_report_status` = '6'
                GROUP BY recd.`id_purc_order_det`
            ) rec ON rec.id_purc_order_det = pod.`id_purc_order_det`
            LEFT JOIN
            (
                SELECT id_purc_order, IFNULL(SUM(IF(id_report_status NOT IN (5, 6), 1, 0)), 0) AS rec_report_submit
                FROM tb_purc_rec
                GROUP BY id_purc_order
            ) rec_report ON po.id_purc_order = rec_report.id_purc_order
            WHERE cl_d.id_close_receiving = " + id_close_receiving + "
            GROUP BY po.id_purc_order
        ", -1, True, "", "", "", "")

        GVPO.BestFitColumns()

        'controls
        If data.Rows(0)("id_report_status").ToString = "0" Then
            'new
            SBAdd.Enabled = True
            SBRemove.Enabled = True
            SBSave.Visible = True
            SBMark.Visible = False
        Else
            'submitted
            SBAdd.Enabled = False
            SBRemove.Enabled = False
            SBSave.Visible = False
            SBMark.Visible = True

            SBClose.Location = New Point(686, 15)
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormPurcOrderCloseReceivingList.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVPO.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If GVPO.RowCount > 0 Then
            Dim cnt As Boolean = True

            For i = 0 To GVPO.RowCount - 1
                If GVPO.GetRowCellValue(i, "close_rec_reason").ToString = "" Then
                    cnt = False
                End If
            Next

            If cnt Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "INSERT INTO tb_purc_order_close (created_date, created_by, id_report_status) VALUES (NOW(), " + id_employee_user + ", 1); SELECT LAST_INSERT_ID();"

                    id_close_receiving = execute_query(query, 0, True, "", "", "", "")

                    query = "INSERT INTO tb_purc_order_close_det (id_close_receiving, id_purc_order, close_rec_reason) VALUES "

                    For i = 0 To GVPO.RowCount - 1
                        query += "(" + id_close_receiving + ", " + GVPO.GetRowCellValue(i, "id_purc_order").ToString + ", '" + addSlashes(GVPO.GetRowCellValue(i, "close_rec_reason").ToString) + "'), "
                    Next

                    execute_non_query(query.Substring(0, query.Length - 2), True, "", "", "", "")

                    execute_non_query("CALL gen_number(" + id_close_receiving + ", '259')", True, "", "", "", "")

                    submit_who_prepared("259", id_close_receiving, id_user)

                    infoCustom("Saved.")

                    Close()
                End If
            Else
                stopCustom("Please add close receiving reason.")
            End If
        Else
            stopCustom("No PO selected.")
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "259"
        FormReportMark.id_report = id_close_receiving

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcOrderCloseReceiving_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormPurcOrder.load_close_receiving()

        Dispose()
    End Sub
End Class