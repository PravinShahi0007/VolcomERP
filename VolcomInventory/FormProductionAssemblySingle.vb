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
        viewBom()
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

    Sub viewBom()
        Dim query As String = "SELECT a.id_product, a.code, a.name, a.qty, a.uom,AVG(a.val) AS `price`
        FROM(
	        SELECT acd.id_product, p.id_design, d.design_code AS `code`,d.design_display_name AS `name`, b.id_bom, acd.prod_ass_comp_qty_det, bd.id_bom_det, 
	        bd.id_mat_det_price, bd.id_ovh_price, bd.component_qty,
	        bd.bom_price, bd.kurs, comp.qty, u.uom,SUM(bd.component_qty*bd.bom_price*bd.kurs) AS `val`
	        FROM tb_prod_ass a
	        INNER JOIN tb_prod_ass_det ad ON ad.id_prod_ass = a.id_prod_ass
	        INNER JOIN tb_prod_ass_comp_det acd ON acd.id_prod_ass_det = ad.id_prod_ass_det
	        INNER JOIN tb_bom b ON b.id_product = acd.id_product AND b.is_default=1
	        INNER JOIN tb_bom_det bd ON bd.id_bom = b.id_bom
	        INNER JOIN tb_m_product p ON p.id_product = b.id_product
	        INNER JOIN tb_m_design d ON d.id_design = p.id_design
	        LEFT JOIN (
		        SELECT ass.id_prod_ass, SUM(cd.prod_ass_det_qty) AS `qty` 
		        FROM tb_prod_ass_det cd
		        INNER JOIN tb_prod_ass ass ON ass.id_prod_ass = cd.id_prod_ass
		        GROUP BY ass.id_prod_ass
	        ) comp ON comp.id_prod_ass = a.id_prod_ass
	        INNER JOIN tb_m_uom u ON u.id_uom = d.id_uom
	        WHERE a.id_prod_ass=" + id_prod_ass + "
	        GROUP BY p.id_product
        ) a GROUP BY a.id_design "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBOM.DataSource = data
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

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        deleteComponent()
    End Sub

    Sub deleteComponent()
        If GVComponent.RowCount > 0 And GVComponent.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id As String = "-1"
            Try
                id = GVComponent.GetFocusedRowCellValue("id_prod_ass_comp_det").ToString
            Catch ex As Exception
            End Try
            Dim query As String = "DELETE FROM tb_prod_ass_comp_det WHERE id_prod_ass_comp_det='" + id + "'"
            execute_non_query(query, True, "", "", "", "")
            viewDetailComponent()
            viewBom()
            Cursor = Cursors.Default
        End If
    End Sub
End Class