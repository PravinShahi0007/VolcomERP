Public Class FormFGAging
    Public is_view As String = "-1"
    Public data_edit As New DataTable

    Private Sub FormFGAging_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGAging_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFGAging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        viewSeason()

        'initialisation datatable edit
        Try
            data_edit.Columns.Add("id_design")
            data_edit.Columns.Add("aging_design")
        Catch ex As Exception
        End Try
    End Sub

    'view season
    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        'query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        'query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY `id_season` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            GridColumnPic.Visible = True
            GridColumnPic.VisibleIndex = 0
        Else
            GridColumnPic.Visible = False
        End If
        GCDesign.RefreshDataSource()
        GVDesign.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVDesign_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVDesign.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        ElseIf e.Column.FieldName = "current_date" AndAlso e.IsGetData Then
            e.Value = DEFrom.EditValue
        End If
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckEditFreeze.EditValue.ToString
        If val = "True" Then
            freeze(True)
        Else
            freeze(False)
        End If
        Cursor = Cursors.Default
    End Sub

    Sub freeze(ByVal check As Boolean)
        If check Then
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ColDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            ColDisplayName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Else
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            ColDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            ColDisplayName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            If CheckImg.EditValue = True Then
                GridColumnPic.VisibleIndex = 0
            End If
            ColDesignCode.VisibleIndex = 1
            GridColumnCodeImport.VisibleIndex = 2
            ColDisplayName.VisibleIndex = 3
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        GridColumnPic.Visible = False
        CheckImg.EditValue = False
        GVDesign.RowHeight = 10

        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim cond As String = ""
        If id_ss = "-1" Then
            cond = "-1"
        Else
            cond = "And f1.id_season=" + id_ss + " "
        End If
        Dim query As String = "CALL view_design_aging('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data

        If GVDesign.RowCount > 0 Then
            PanelOpt.Visible = True
            PanelControlFreeze.Visible = True
            If is_view = "-1" Then
                BtnEdit.Visible = True
            End If
        Else
            PanelOpt.Visible = False
            PanelControlFreeze.Visible = False
            BtnEdit.Visible = False
        End If

        noEdit()
        Cursor = Cursors.Default
    End Sub

    Sub noEdit()
        'Dim is_approved As String = "1"
        'Try
        '    is_approved = GVDesign.GetFocusedRowCellValue("is_approved").ToString
        'Catch ex As Exception
        'End Try
        'If is_approved = "2" Then
        '    GVDesign.Columns("is_select").OptionsColumn.AllowEdit = True
        'Else
        '    GVDesign.Columns("is_select").OptionsColumn.AllowEdit = False
        'End If
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        PanelOpt.Visible = False
        PanelControlFreeze.Visible = False
        BtnEdit.Visible = False
        GCDesign.DataSource = Nothing
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        BtnView.Visible = False
        BtnEdit.Visible = False
        BtnSave.Visible = True
        BtnCancel.Visible = True
        GridColumnAgingDesign.OptionsColumn.AllowEdit = True
        GCDesign.Focus()
        GVDesign.Focus()
        GVDesign.FocusedColumn = GridColumnAgingDesign
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        reset()
    End Sub

    Sub reset()
        BtnView.Visible = True
        BtnEdit.Visible = True
        BtnSave.Visible = False
        BtnCancel.Visible = False
        GridColumnAgingDesign.OptionsColumn.AllowEdit = False
        viewData()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        For i As Integer = 0 To data_edit.Rows.Count - 1
            Dim query_ds As String = "UPDATE tb_m_design SET aging_design='" + data_edit.Rows(i)("aging_design").ToString + "' WHERE id_design='" + data_edit.Rows(i)("id_design").ToString + "' "
            execute_non_query(query_ds, True, "", "", "", "")
            progres_bar_update(i, data_edit.Rows.Count - 1)
        Next
        reset()
    End Sub

    Private Sub GVDesign_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDesign.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As String = e.RowHandle.ToString
        If e.Column.FieldName.ToString = "aging_design" Then
            Dim id_design As String = GVDesign.GetRowCellValue(row_foc, "id_design").ToString
            Dim val_foc As String = decimalSQL(e.Value.ToString)

            Dim R As DataRow = data_edit.NewRow
            R("id_design") = id_design
            R("aging_design") = val_foc
            data_edit.Rows.Add(R)
        End If
        Cursor = Cursors.Default
    End Sub
End Class