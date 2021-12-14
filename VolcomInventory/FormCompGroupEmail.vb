Public Class FormCompGroupEmail
    Public rmt As String = "-1"

    Private Sub FormPopUpCompGroup_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormPopUpCompGroup_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormCompGroupEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        show_email()
    End Sub

    Sub load_comp_group()
        Dim q As String = ""

        If SLEReportMarkType.EditValue.ToString = "314" Then
            q = "SELECT id_comp_group,comp_group,description FROM tb_m_comp_group WHERE is_send_per_comp!=1"
        ElseIf SLEReportMarkType.EditValue.ToString = "320" Then
            q = "SELECT cg.id_comp_group,cg.comp_group,cg.description,c.comp_name,c.id_comp,c.comp_number
FROM tb_m_comp_group cg 
INNER JOIN tb_m_comp c ON c.id_comp_group=cg.id_comp_group AND c.is_active=1
WHERE cg.is_send_per_comp=1"
        ElseIf SLEReportMarkType.EditValue.ToString = "322" Or SLEReportMarkType.EditValue.ToString = "373" Then
            q = "SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCGroupComp.DataSource = dt
        GVGroupComp.BestFitColumns()
        '
        show_email()
    End Sub

    Private Sub FormCompGroupEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_rmt()
        load_comp_group()
        If rmt = "373" Then
            SLEReportMarkType.EditValue = rmt
            SLEReportMarkType.Enabled = False
            BAddInternal.Visible = False
        End If
    End Sub

    Sub view_rmt()
        Dim q As String = "SELECT report_mark_type,report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type IN (SELECT report_mark_type FROM tb_mail_to_group_department WHERE id_departement = " + id_departement_user + ")"
        viewSearchLookupQuery(SLEReportMarkType, q, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Sub show_email()
        If GVGroupComp.RowCount > 0 Then
            Dim q As String = ""
            If SLEReportMarkType.EditValue.ToString = "314" Then
                q = "SELECT id_mail_to_group,`email`,`name`,IF(is_to=1,'To','CC') AS is_to , IF(ISNULL(id_employee),'External','Internal') AS `type`
FROM tb_mail_to_group
WHERE report_mark_type='" & SLEReportMarkType.EditValue.ToString & "' AND id_comp_group='" & GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString & "'"
            ElseIf SLEReportMarkType.EditValue.ToString = "320" Then
                q = "SELECT id_mail_to_group,`email`,`name`,IF(is_to=1,'To','CC') AS is_to , IF(ISNULL(id_employee),'External','Internal') AS `type`
FROM tb_mail_to_group
WHERE report_mark_type='" & SLEReportMarkType.EditValue.ToString & "' AND id_comp_group='" & GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString & "' AND id_comp='" & GVGroupComp.GetFocusedRowCellValue("id_comp").ToString & "'"
            ElseIf SLEReportMarkType.EditValue.ToString = "322" Or SLEReportMarkType.EditValue.ToString = "373" Then
                q = "SELECT id_mail_to_group,`email`,`name`,IF(is_to=1,'To','CC') AS is_to , IF(ISNULL(id_employee),'External','Internal') AS `type`
FROM tb_mail_to_group
WHERE report_mark_type='" & SLEReportMarkType.EditValue.ToString & "' AND id_comp_group='" & GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString & "'"
            End If

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCEmail.DataSource = dt
            GVEmail.BestFitColumns()
        End If
    End Sub

    Private Sub GVGroupComp_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVGroupComp.ColumnFilterChanged
        show_email()
    End Sub

    Private Sub GVGroupComp_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVGroupComp.FocusedRowChanged
        show_email()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVEmail.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                Dim q As String = "DELETE FROM tb_mail_to_group WHERE id_mail_to_group='" & GVEmail.GetFocusedRowCellValue("id_mail_to_group").ToString & "'"
                execute_non_query(q, True, "", "", "", "")
                show_email()
            End If
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If GVGroupComp.RowCount > 0 Then
            If SLEReportMarkType.EditValue.ToString = "320" Then
                FormCompGroupEmailDet.id_comp = GVGroupComp.GetFocusedRowCellValue("id_comp").ToString
            End If
            FormCompGroupEmailDet.id_comp_group = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
            FormCompGroupEmailDet.ShowDialog()
        End If
    End Sub

    Private Sub BAddInternal_Click(sender As Object, e As EventArgs) Handles BAddInternal.Click
        If GVGroupComp.RowCount > 0 Then
            If SLEReportMarkType.EditValue.ToString = "320" Then
                FormCompGroupEmailDet.id_comp = GVGroupComp.GetFocusedRowCellValue("id_comp").ToString
            End If
            FormCompGroupEmailDet.is_external = False
            FormCompGroupEmailDet.id_comp_group = GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
            FormCompGroupEmailDet.ShowDialog()
        End If
    End Sub

    Private Sub SLEReportMarkType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReportMarkType.EditValueChanged
        If SLEReportMarkType.EditValue.ToString = "314" Then
            GridColumnStoreCode.VisibleIndex = -1
            GridColumnStoreName.VisibleIndex = -1
            load_comp_group()
        ElseIf SLEReportMarkType.EditValue.ToString = "320" Then
            GridColumnStoreCode.VisibleIndex = 2
            GridColumnStoreName.VisibleIndex = 3
            load_comp_group()
        ElseIf SLEReportMarkType.EditValue.ToString = "322" Then
            GridColumnStoreCode.VisibleIndex = -1
            GridColumnStoreName.VisibleIndex = -1
            load_comp_group()
        End If
    End Sub
End Class