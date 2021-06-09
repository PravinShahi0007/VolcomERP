﻿Public Class FormCompGroupEmail
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
        Dim q As String = "SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCGroupComp.DataSource = dt
        GVGroupComp.BestFitColumns()
    End Sub

    Private Sub FormCompGroupEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_rmt()
        load_comp_group()
    End Sub

    Sub view_rmt()
        Dim q As String = "SELECT report_mark_type,report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='314'"
        viewSearchLookupQuery(SLEReportMarkType, q, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Sub show_email()
        If GVGroupComp.RowCount > 0 Then
            Dim q As String = "SELECT `email`,`name`,IF(is_to=1,'To','CC') AS is_to 
FROM tb_mail_to_group
WHERE report_mark_type='" & SLEReportMarkType.EditValue.ToString & "' AND id_comp_group='" & GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString & "'"
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
        FormCompGroupEmailDet.ShowDialog()
    End Sub
End Class