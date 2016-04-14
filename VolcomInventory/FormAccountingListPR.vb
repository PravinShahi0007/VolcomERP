Public Class FormAccountingListPR 
    Private Sub FormAccountingListPR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_list_pr()
    End Sub

    Sub view_list_pr()
        Dim query As String = "CALL view_all_pr()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPaymentList.DataSource = data
        GVPaymentList.BestFitColumns()
    End Sub

    Private Sub FormAccountingListPR_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAccountingListPR_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccountingListPR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub GVPaymentList_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPaymentList.RowStyle
        If GVPaymentList.GetRowCellValue(e.RowHandle, "diff_date") < 0 Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
            e.Appearance.ForeColor = Color.Black
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CEChecked_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEChecked.EditValueChanged
        GVPaymentList.PostEditor()
    End Sub

    Private Sub CEChecked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEChecked.CheckedChanged
        'infoCustom(GVPaymentList.GetFocusedRowCellValue("is_check").ToString())

    End Sub
End Class