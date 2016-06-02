Public Class FormFGDesignList
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "0"
    Dim bdupe_active As String = "1"
    Public id_pop_up As String = "-1"

    Private Sub FormFGDesignList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
    End Sub

    'view season
    Sub viewSeason(ByVal type As String)
        Dim query As String = ""
        'query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        'query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.is_md='" + type + "' "
        query += "ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_line_list_type a ORDER BY a.id_line_list_type ASC "
        viewSearchLookupQuery(SLEType, query, "id_line_list_type", "line_list_type", "id_line_list_type")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
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
        Dim query As String = "CALL view_all_design_param('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data


        check_menu()

        If GVDesign.RowCount > 0 Then
            PanelOpt.Visible = True
            PanelControlFreeze.Visible = True
        Else
            PanelOpt.Visible = False
            PanelControlFreeze.Visible = False
        End If

        If id_pop_up = "1" Then 'approve
            GridColumnSelect.Visible = True
            If GVDesign.RowCount > 0 Then
                PanelApp.Visible = True
            Else
                PanelApp.Visible = False
            End If
        Else
            GridColumnSelect.Visible = False
        End If

        noEdit()
    End Sub

    Private Sub FormFGDesignList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGDesignList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVDesign.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            bdupe_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Else
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVDesign.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                bdupe_active = "0"
            Else
                'show all
                'If id_pop_up = "1" Then 'design dept - input sample for line list
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                bdupe_active = "1"
                'End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        noManipulating()
        noEdit()
    End Sub

    Private Sub GVDesign_DoubleClick(sender As Object, e As EventArgs) Handles GVDesign.DoubleClick
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        Dim type_par As String = "-1"
        Try
            type_par = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try
        viewSeason(type_par)
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
        End If
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        PanelOpt.Visible = False
        PanelControlFreeze.Visible = False
        GCDesign.DataSource = Nothing
        If id_pop_up = "1" Then 'approve
            PanelApp.Visible = False
        End If
    End Sub

    Private Sub CheckSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSelAll.CheckedChanged
        If GVDesign.RowCount > 0 Then
            Dim cek As String = CheckSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                Dim is_approved As String = GVDesign.GetRowCellValue(i, "is_approved").ToString
                If cek And is_approved = "2" Then
                    GVDesign.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVDesign.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Sub noEdit()
        Dim is_approved As String = "1"
        Try
            is_approved = GVDesign.GetFocusedRowCellValue("is_approved").ToString
        Catch ex As Exception
        End Try
        If is_approved = "2" Then
            GVDesign.Columns("is_select").OptionsColumn.AllowEdit = True
        Else
            GVDesign.Columns("is_select").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles BtnApprove.Click
        GVDesign.ActiveFilterString = "[is_select]='Yes'"
        If GVDesign.RowCount = 0 Then
            stopCustom("Please select design first.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to aprrove these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim query As String = "UPDATE tb_m_design SET is_approved='1', approved_by='" + id_user + "', approved_time=NOW() WHERE id_design >0 AND ( "
                For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                    If i > 0 Then
                        query += "OR "
                    End If
                    query += "id_design='" + GVDesign.GetRowCellValue(i, "id_design").ToString + "' "
                Next
                query += ") "
                Try
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Design approved succesfully")
                Catch ex As Exception
                    infoCustom("Error excecution, please try again later.")
                End Try
                GVDesign.ActiveFilterString = ""
                viewData()
                Cursor = Cursors.Default
            Else
                GVDesign.ActiveFilterString = ""
            End If
        End If
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
End Class