Public Class FormFGProposePriceRevNew
    Dim id_pp As String = "-1"

    Private Sub FormFGProposePriceRevNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        view_division_fg()
        view_source_fg()
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division_fg()
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name 
        FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEDivision, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub view_source_fg()
        Dim id_code As String = get_setup_field("id_code_fg_source")
        Dim query As String = "SELECT (id_code_detail) AS id_source, (code_detail_name) AS source, display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' HAVING source<>'-' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LESource, query, 0, "display_name", "id_source")
    End Sub

    Private Sub FormFGProposePriceRevNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVFGPropose.RowCount > 0 And GVFGPropose.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = "70"
            m.id_report = GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub viewPP()
        Cursor = Cursors.WaitCursor
        Dim pp As New ClassFGProposePrice()
        Dim query As String = pp.queryMain("AND tb_fg_propose_price.id_report_status=6 AND tb_fg_propose_price.id_season=" + SLESeason.EditValue.ToString + " AND tb_fg_propose_price.id_source=" + LESource.EditValue.ToString + " AND tb_fg_propose_price.id_division=" + LEDivision.EditValue.ToString + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGPropose.DataSource = data
        If GVFGPropose.RowCount > 0 Then
            GVFGPropose.FocusedRowHandle = 0
        End If
        focusrow()
        GVFGPropose.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        viewPP()
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCFGPropose.DataSource = Nothing
    End Sub

    Private Sub LESource_EditValueChanged(sender As Object, e As EventArgs) Handles LESource.EditValueChanged
        GCFGPropose.DataSource = Nothing
    End Sub

    Private Sub LEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles LEDivision.EditValueChanged
        GCFGPropose.DataSource = Nothing
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Cursor = Cursors.WaitCursor
        Dim cond_process As Boolean = False
        Dim query_cek As String = "SELECT * FROM tb_fg_propose_price_rev r WHERE r.id_fg_propose_price=" + id_pp + " AND r.id_report_status<5 "
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count > 0 Then
            cond_process = True
        End If

        If id_pp = "-1" Then
            stopCustom("Please select Propose Price")
        ElseIf MENote.Text = "" Then
            stopCustom("Note can't blank")
        ElseIf cond_process Then
            stopCustom("Cannot make revisions. Propose Price is being processed")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create PD revison for " + TxtNumber.Text + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim note As String = addSlashes(MENote.Text)
                Dim query As String = "INSERT INTO tb_fg_propose_price_rev(id_fg_propose_price, rev_count, id_report_status, created_date,note) 
                VALUES('" + id_pp + "', getRevPP(" + id_pp + "),1, NOW(),'" + note + "'); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                FormFGProposePrice.viewRevision()
                FormFGProposePrice.GVRev.FocusedRowHandle = find_row(FormFGProposePrice.GVRev, "id_fg_propose_price_rev", id)

                Close()
                FormFGProposePriceRev.id = id
                FormFGProposePriceRev.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub focusrow()
        If GVFGPropose.RowCount > 0 And GVFGPropose.FocusedRowHandle >= 0 Then
            id_pp = GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
            TxtNumber.Text = GVFGPropose.GetFocusedRowCellValue("fg_propose_price_number").ToString
        Else
            id_pp = "-1"
            TxtNumber.Text = ""
        End If
    End Sub

    Private Sub GVFGPropose_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGPropose.FocusedRowChanged
        focusrow()
    End Sub

    Private Sub GVFGPropose_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVFGPropose.ColumnFilterChanged
        focusrow()
    End Sub
End Class