Public Class FormLineList
    Public show_spesific_col As Boolean = False

    Private Sub FormLineList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()

        'fill col
        'For i As Integer = 0 To GVData.Columns.Count - 1
        '    If GVData.Columns(i).Visible = True Then
        '        Dim query As String = "INSERT INTO tb_col_line_list(fieldname, is_md, is_mkt) VALUES('" + addSlashes(GVData.Columns(i).FieldName.ToString) + "',1,2); "
        '        execute_non_query(query, True, "", "", "", "")
        '    End If
        'Next
        If show_spesific_col Then
            Dim qry As String = "SELECT * FROM tb_col_line_list l "
            Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim col_name As String = dt.Rows(j)("fieldname").ToString
                Dim is_mkt As String = dt.Rows(j)("is_mkt").ToString
                If is_mkt = "2" Then
                    GVData.Columns(col_name).Visible = False
                    GVData.Columns(col_name).OptionsColumn.ShowInCustomizationForm = False
                End If
            Next
        End If
    End Sub

    Private Sub FormLineList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormLineList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        query += "AND b.is_md='1' "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim query As String = "CALL view_line_list_all_new(" + id_ss + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            Else
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
            End If
        End If
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVData_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVData.CustomUnboundColumnData
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

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            BandedGridColumnImg.Visible = True
            BandedGridColumnImg.VisibleIndex = 1
        Else
            BandedGridColumnImg.Visible = False
        End If
        GCData.RefreshDataSource()
        GVData.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckEditFreeze.EditValue.ToString
        If val = "True" Then
            GridBandFreeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridBandFreeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkProdDemand_Click(sender As Object, e As EventArgs) Handles RepoLinkProdDemand.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_prod_demand As String = "-1"
            Try
                id_prod_demand = GVData.GetFocusedRowCellValue("id_prod_demand").ToString
            Catch ex As Exception
            End Try
            If id_prod_demand = "" Then
                stopCustom("Document not found")
                Cursor = Cursors.Default
                Exit Sub
            End If
            FormViewProdDemand.id_prod_demand = id_prod_demand
            FormViewProdDemand.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class