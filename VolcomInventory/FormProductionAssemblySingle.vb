Public Class FormProductionAssemblySingle
    Public is_view As String = "-1"
    Public action As String = "-1"
    Public id_prod_ass As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormProductionAssemblySingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassProductionAssembly()
        Dim query As String = query_c.queryMain("AND a.id_prod_ass=" + id_prod_ass + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtDesignCode.Text = data.Rows(0)("code").ToString
        TxtDesign.Text = data.Rows(0)("name").ToString
        DEFrom.EditValue = data.Rows(0)("prod_ass_date")
        TxtNumber.Text = data.Rows(0)("prod_ass_number").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_prod_ass(" + id_prod_ass + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        viewDetailComponent()
    End Sub

    Sub viewDetailComponent()
        Dim id_prod_ass_det As String = "0"
        Try
            id_prod_ass_det = GVItemList.GetFocusedRowCellValue("id_prod_ass_det").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_prod_ass_comp(" + id_prod_ass_det + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComponent.DataSource = data
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "107", id_prod_ass) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If

        'ATTACH
        If check_attach_report_status(id_report_status, "107", id_prod_ass) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If is_view = "1" Then
            BtnSave.Visible = False
        End If
        TxtNumber.Focus()
    End Sub

    Private Sub FormProductionAssemblySingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVComponent_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVComponent.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            viewDetailComponent()
        End If
    End Sub

    Private Sub GVItemList_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVItemList.ColumnFilterChanged
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            viewDetailComponent()
        End If
    End Sub

    Private Sub AddComponentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddComponentToolStripMenuItem.Click
        addComponent()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        addComponent()
    End Sub

    Sub addComponent()
        Cursor = Cursors.WaitCursor
        FormProductionAssemblyComp.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class