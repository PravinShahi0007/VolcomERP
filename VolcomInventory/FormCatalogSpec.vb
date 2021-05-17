Public Class FormCatalogSpec
    Private Sub FormCatalogSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        'query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        'query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.is_md='1' "
        query += "ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub FormCatalogSpec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormCatalogSpec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim cond As String = "AND d.id_season=" + SLESeason.EditValue.ToString + " "
        Dim query As String = "CALL view_catalog_spec('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVDesign_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVDesign.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "body" AndAlso e.IsGetData Then
            Dim prc As String = "Rp. " + Decimal.Parse(Convert.ToDecimal(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "design_price_normal"))).ToString("N0") + ",-"
            Dim color As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "color").ToString
            Dim size_chart As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "size_chart").ToString
            Dim spek As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "spek").ToString
            Dim bahan As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "bahan").ToString
            e.Value = prc + System.Environment.NewLine + System.Environment.NewLine + color + System.Environment.NewLine + System.Environment.NewLine + size_chart + System.Environment.NewLine + System.Environment.NewLine + spek + System.Environment.NewLine + System.Environment.NewLine + bahan
        ElseIf e.Column.FieldName = "img" AndAlso e.IsGetData Then
            Images = Nothing
            Images = New Hashtable()
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
        GCDesign.DataSource = Nothing
    End Sub
End Class