Public Class FormProductionAttach
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim is_submit As String = "2"

    Private Sub FormProductionAttach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        load_fgpo()

        If id = "-1" Then
            BAttachPPS.Visible = False
            BShowPO.Visible = True
            SLEFGPO.Properties.ReadOnly = False
        Else
            Dim q As String = "SELECT at.*,emp.employee_name FROM tb_prod_order_attach at 
INNER JOIN tb_m_user usr ON usr.id_user=at.created_by
INNER JOIN tb_m_employee emp On emp.id_employee=usr.id_employee
WHERE at.id_prod_order_attach='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                DECreated.Text = dt.Rows(0)("created_date")
                '
                SLEFGPO.EditValue = dt.Rows(0)("id_prod_order").ToString
                loadLineList()
                '
                BAttachPPS.Visible = False
                BShowPO.Visible = False
                SLEFGPO.Properties.ReadOnly = True
                '
                is_submit = dt.Rows(0)("is_submit").ToString

                If is_submit = "1" Then
                    BtnMark.Visible = True
                    PCSubmit.Visible = True
                    BtnSave.Visible = False
                Else
                    BtnMark.Visible = False
                    PCSubmit.Visible = True
                    BtnSave.Visible = True
                End If
            End If
        End If
    End Sub

    Sub load_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`,CONCAT(po.`prod_order_number`,' - ',dsg.`design_display_name`) AS view_po
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "view_po", "id_prod_order")
    End Sub

    Sub loadLineList()
        Try
            FormViewProduction.Close()
            FormViewProduction.Dispose()
        Catch ex As Exception
        End Try

        Try
            If Not SLEFGPO.EditValue = Nothing Then
                FormViewProduction.MdiParent = Me
                FormViewProduction.id_prod_order = SLEFGPO.EditValue.ToString
                FormViewProduction.is_no_cost = "1"
                FormViewProduction.is_view_only = "1"
                FormViewProduction.ControlBox = False
                FormViewProduction.Show()
                FormViewProduction.WindowState = FormWindowState.Maximized
                FormViewProduction.Focus()
                '
                BAttachPPS.Visible = True
            End If
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BShowPO.Click
        loadLineList()
    End Sub

    Private Sub FormProductionAttach_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = "374"

        If is_submit = "1" Then
            FormDocumentUpload.is_view = "1"
        End If

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check attachment first
        Dim qc As String = "SELECT * FROM tb_doc WHERE report_mark_type='374' AND id_report='" & id & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'sudah ada
            Dim qu As String = "UPDATE tb_prod_order_attach SET is_submit=1 WHERE id_prod_order_attach='" & id & "'"
            execute_non_query(qu, True, "", "", "", "")
            '
            submit_who_prepared("374", id, id_user)
            '
            load_head()
        Else
            warningCustom("Please attach signed FGPO")
        End If
    End Sub

    Private Sub BAttachPPS_Click(sender As Object, e As EventArgs) Handles BAttachPPS.Click
        Cursor = Cursors.WaitCursor
        If Not SLEFGPO.EditValue = Nothing Then
            'check if already
            Dim qc As String = "SELECT * FROM tb_prod_order_attach WHERE id_prod_order='" & SLEFGPO.EditValue.ToString & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Already proposed before")
            Else
                Dim q As String = "INSERT INTO tb_prod_order_attach(id_prod_order,created_by,created_date) VALUES('" & SLEFGPO.EditValue.ToString & "','" & id_user & "',NOW()); SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")
                '
                execute_non_query("CALL gen_number('" & id & "','374')", True, "", "", "", "")
                '
                load_head()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = "374"
        FormReportMark.ShowDialog()
    End Sub
End Class