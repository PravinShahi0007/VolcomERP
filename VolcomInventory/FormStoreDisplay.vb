Public Class FormStoreDisplay
    Public is_load_new As Boolean = False

    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_season`, 999 as `range`, 'All Season' AS `season`
        UNION ALL
        SELECT ss.id_season, rg.`range`, ss.season 
        FROM tb_season ss 
        INNER JOIN tb_range rg ON rg.id_range = ss.id_range
        WHERE rg.is_md=1
        ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        Cursor = Cursors.Default
    End Sub

    Sub viewComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT 0 AS `id_comp`, '- All Store -' AS `comp`) 
        UNION ALL
        (SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        WHERE c.id_comp_cat=6 
        ORDER BY c.comp_number ASC) "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStoreDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewComp()
    End Sub

    Private Sub FormStoreDisplay_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormStoreDisplay_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStoreDisplay_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPps()
    End Sub

    Sub viewPps()
        Cursor = Cursors.WaitCursor

        'cond
        Dim cond As String = ""
        Dim id_season As String = SLESeason.EditValue.ToString
        If id_season <> "0" Then
            cond += "AND p.id_season='" + id_season + "' "
        End If
        Dim id_comp As String = SLEComp.EditValue.ToString
        If id_comp <> "0" Then
            cond += "AND p.id_comp='" + id_comp + "' "
        End If

        Dim sd As New ClassStoreDisplay()
        Dim query As String = sd.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPPS.DataSource = data
        GVPPS.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCPPS, "Propose List : Store Display")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        FormStoreDisplayDet.action = "ins"
        FormStoreDisplayDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailPps()
        If GVPPS.RowCount > 0 And GVPPS.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormStoreDisplayDet.action = "upd"
            FormStoreDisplayDet.id = GVPPS.GetFocusedRowCellValue("id_display_pps").ToString
            FormStoreDisplayDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVPPS.DoubleClick
        If GVPPS.RowCount > 0 And GVPPS.FocusedRowHandle >= 0 Then
            viewDetailPps()
        End If
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetailPps()
        End If
    End Sub

    Private Sub BtnDisplayCapacity_Click(sender As Object, e As EventArgs) Handles BtnDisplayCapacity.Click
        Cursor = Cursors.WaitCursor
        FormDisplayAlloc.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class