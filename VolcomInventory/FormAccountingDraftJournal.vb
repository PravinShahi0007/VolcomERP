Public Class FormAccountingDraftJournal
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormAccountingDraftJournal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormAccountingDraftJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDraft()

        'only view draft
        If is_view = "1" Then
            PanelControlNav.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Sub viewDraft()
        Dim acc As New ClassAccounting()
        Dim query As String = acc.viewJournalSalesDraft("AND d.id_report=" + id_report + " AND d.report_mark_type =" + report_mark_type + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class