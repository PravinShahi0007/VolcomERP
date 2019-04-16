Public Class FormWorkOrderDet
    Public id_wo As String = "-1"
    Public id_status As String = "1"
    Public is_view As String = "-1"

    Private Sub FormWorkOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_work_order_type()
        load_urgency()
        TEReqNUmber.Text = "[auto_generate]"
        TEReqBy.Text = get_emp(id_user, "4")
        TEDep.Text = get_emp(id_user, "5")
        DEDateCreated.EditValue = Now

        If id_wo = "-1" Then
            'new
            BtnPrint.Visible = False
            BMark.Visible = False
        Else
            'edit
            Dim query As String = "SELECT wo.`id_work_order`,wo.id_report_status,wo.`id_work_order_type`,wo.`number`,wo.`note`,wo.`created_date`,emp.`employee_name`,dep.`departement` FROM tb_work_order wo
INNER JOIN tb_m_user usr ON usr.`id_user`=wo.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=wo.`id_departement_created`
WHERE wo.`id_work_order`='" & id_wo & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEReqNUmber.Text = data.Rows(0)("number").ToString
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                DEDateCreated.EditValue = data.Rows(0)("created_date")
                SLEType.EditValue = data.Rows(0)("id_work_order_type").ToString
                SLEUrgency.EditValue = data.Rows(0)("is_urgent").ToString
                id_status = data.Rows(0)("id_report_status").ToString
            End If
            '
            BtnPrint.Visible = True
            BMark.Visible = True
            '
            If check_edit_report_status(id_status, "190", id_wo) Then
                BtnSave.Visible = False
            Else
                BtnSave.Visible = True
            End If
        End If
    End Sub

    Sub load_work_order_type()
        Dim query As String = "Select wot.`id_work_order_type`, wot.`work_order_type`, dep.`departement` FROM tb_lookup_work_order_type wot
INNER JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=wot.`id_sub_departement`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=sub.`id_departement`"
        viewSearchLookupQuery(SLEType, query, "id_work_order_type", "work_order_type", "id_work_order_type")
    End Sub

    Sub load_urgency()
        Dim query As String = "Select '2' AS is_urgent,'Not Urgent' AS urgent
UNION
SELECT '1' AS is_urgent,'Urgent' AS urgent"
        viewSearchLookupQuery(SLEUrgency, query, "is_urgent", "urgent", "is_urgent")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If MENote.Text = "" Then
            warningCustom("Please describe the problem simple and clear.")
        Else
            If id_wo = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_work_order(id_work_order_type,is_urgent,created_date,created_by,id_departement_created,note) VALUES('" & SLEType.EditValue.ToString & "','" & SLEUrgency.EditValue.ToString & "',NOW(),'" & id_user & "','" & id_departement_user & "','" & addSlashes(MENote.Text.ToString) & "'); SELECT LAST_INSERT_ID(); "
                id_wo = execute_query(query, 0, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_wo & "','190')"
                execute_non_query(query, True, "", "", "", "")
                '
                submit_who_prepared("190", id_wo, id_user)
                '
                infoCustom("Work order submitted")
                load_form()
            Else 'edit
                Dim query As String = "UPDATE tb_work_order SET id_work_order_type='" & SLEType.EditValue.ToString & "',is_urgent='" & SLEUrgency.EditValue.ToString & "',created_date=NOW(),created_by='" & id_user & "',id_departement_created='" & id_departement_user & "',note='" & addSlashes(MENote.Text.ToString) & "' WHERE id_work_order='" & id_wo & "'; "
                execute_non_query(query, True, "", "", "", "")
                '
                infoCustom("Work order updated")
                load_form()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormWorkOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_wo
        FormReportMark.report_mark_type = "190"
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class