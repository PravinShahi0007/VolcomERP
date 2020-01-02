Public Class FormFollowUpARDetail
    Public action As String = "-1"
    Public id As String = "-1"
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLEStoreGroup.EditValue = Nothing Or MEFollowUp.Text = "" Or MEResult.Text = "" Then
            warningCustom("Please complete all data")
        Else
            Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
            Dim due_date As String = DateTime.Parse(SLEDue.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim follow_up As String = addSlashes(MEFollowUp.Text)
            Dim follow_up_result As String = addSlashes(MEResult.Text)
            Dim follow_up_date As String = DateTime.Parse(DEFollowUpDate.EditValue.ToString).ToString("yyyy-MM-dd")

            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_follow_up_ar(id_comp_group, due_date, follow_up, follow_up_result, follow_up_date, follow_up_input) 
                VALUES('" + id_comp_group + "', '" + due_date + "', '" + follow_up + "', '" + follow_up_result + "', '" + follow_up_date + "', NOW()); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")

                refreshMainView()
                Close()
            ElseIf action = "upd" Then
                Dim query As String = "UPDATE tb_follow_up_ar SET id_comp_group='" + id_comp_group + "', due_date='" + due_date + "', follow_up='" + follow_up + "', 
                follow_up_result='" + follow_up_result + "', follow_up_date='" + follow_up_date + "', follow_up_input=NOW()
                WHERE id_follow_up_ar='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                refreshMainView()
                Close()
            End If
        End If
    End Sub

    Sub refreshMainView()
        FormFollowUpAR.SLEStoreGroup.EditValue = "0"
        FormFollowUpAR.GCData.DataSource = Nothing
        FormFollowUpAR.GCActive.DataSource = Nothing
        If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 Then
            FormFollowUpAR.viewList()
            FormFollowUpAR.GVData.FocusedRowHandle = find_row(FormFollowUpAR.GVData, "id_follow_up_ar", id)
        ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 Then
            FormFollowUpAR.viewActive()
            FormFollowUpAR.GVActive.FocusedRowHandle = find_row(FormFollowUpAR.GVActive, "id_follow_up_ar", id)
        Else

        End If
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormFollowUpARDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        viewDueDate()
    End Sub

    Sub viewDueDate()
        Dim id_cg As String = "-1"
        Try
            id_cg = SLEStoreGroup.EditValue.ToString
            If id_cg = "" Then
                id_cg = "-1"
            End If
        Catch ex As Exception
            id_cg = "-1"
        End Try
        Dim query As String = "SELECT sp.sales_pos_due_date, DATE_FORMAT(sp.sales_pos_due_date,'%d %M %Y') AS `due_date`
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        WHERE sp.id_report_status=6 AND c.id_comp_group=" + id_cg + "
        GROUP BY sp.sales_pos_due_date 
        ORDER BY sp.sales_pos_due_date DESC "
        viewSearchLookupQuery(SLEDue, query, "sales_pos_due_date", "due_date", "sales_pos_due_date")
    End Sub

    Private Sub FormFollowUpARDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DateTime = getTimeDB()
        DEFollowUpDate.EditValue = dt_now
        load_group_store()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim f As New ClassFollowUpAR()
            Dim query As String = f.queryMain("AND f.id_follow_up_ar='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEStoreGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            SLEDue.EditValue = data.Rows(0)("due_date")
            DEFollowUpDate.EditValue = data.Rows(0)("follow_up_date")
            MEFollowUp.Text = data.Rows(0)("follow_up").ToString
            MEResult.Text = data.Rows(0)("follow_up_result").ToString
        End If
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub
End Class