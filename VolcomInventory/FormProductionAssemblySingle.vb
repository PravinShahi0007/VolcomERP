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
        MENote.Text = data.Rows(0)("prod_ass_note").ToString
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
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim qty As Decimal = GVItemList.GetFocusedRowCellValue("prod_ass_det_qty")
            If qty > 0 Then
                Dim id_ass_det As String = GVItemList.GetFocusedRowCellValue("id_prod_ass_det").ToString
                FormProductionAssemblyComp.id_prod_ass_det = id_ass_det
                FormProductionAssemblyComp.data_par = GCComponent.DataSource
                FormProductionAssemblyComp.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            'main
            Dim prod_ass_note As String = addSlashes(MENote.Text)
            Dim query As String = "UPDATE tb_prod_ass SET prod_ass_note = '" + prod_ass_note + "' WHERE id_prod_ass=" + id_prod_ass + ""
            execute_non_query(query, True, "", "", "", "")

            'detail
            makeSafeGV(GVItemList)
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_prod_ass_det As String = GVItemList.GetRowCellValue(i, "id_prod_ass_det").ToString
                Dim qty_foc As String = GVItemList.GetRowCellValue(i, "prod_ass_det_qty").ToString
                Dim note_foc As String = addSlashes(GVItemList.GetRowCellValue(i, "prod_ass_det_note").ToString)
                Dim query_upd As String = "UPDATE tb_prod_ass_det SET prod_ass_det_qty='" + qty_foc + "',
            prod_ass_det_note='" + note_foc + "' WHERE id_prod_ass_det=" + id_prod_ass_det + " "
                execute_non_query(query_upd, True, "", "", "", "")
            Next
            infoCustom(TxtNumber.Text + " was updated successfully. ")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class