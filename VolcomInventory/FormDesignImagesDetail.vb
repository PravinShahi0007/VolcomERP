Public Class FormDesignImagesDetail
    Public id_design As String = "-1"

    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString

    Private imagesZ As Hashtable = New Hashtable()
    Private imagesV As Hashtable = New Hashtable()
    Private imagesSQ As Hashtable = New Hashtable()
    Private imagesTH As Hashtable = New Hashtable()

    Private Sub FormDesignImagesDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_design = "-1" Then
            Try
                FormMain.SplashScreenManager1.ShowWaitForm()
            Catch ex As Exception
            End Try

            'zalora
            Dim query_z = "
                SELECT CONCAT('" + cloud_image_url + "/', i.file_name) AS url, i.file_name, i.sort, '' AS file_open
                FROM tb_design_images AS i
                WHERE i.id_design = " + id_design + " AND i.store = 'Z'
                ORDER BY i.sort ASC
            "

            Dim data_z As DataTable = execute_query(query_z, -1, True, "", "", "", "")

            GCZ.DataSource = data_z

            GVZ.BestFitColumns()

            setImagesZ()

            GridColumn1.VisibleIndex = True
            GridColumn1.VisibleIndex = 0

            GCZ.RefreshDataSource()

            GVZ.RefreshData()

            'vios
            Dim query_v = "
                SELECT CONCAT('" + cloud_image_url + "/', i.file_name) AS url, i.file_name, i.sort, '' AS file_open
                FROM tb_design_images AS i
                WHERE i.id_design = " + id_design + " AND i.store = 'V'
                ORDER BY i.sort ASC
            "

            Dim data_v As DataTable = execute_query(query_v, -1, True, "", "", "", "")

            GCV.DataSource = data_v

            GVV.BestFitColumns()

            setImagesV()

            GridColumn5.VisibleIndex = True
            GridColumn5.VisibleIndex = 0

            GCV.RefreshDataSource()

            GVV.RefreshData()

            'sq
            Dim query_sq = "
                SELECT CONCAT('" + cloud_image_url + "/', i.file_name) AS url, i.file_name, i.sort, '' AS file_open
                FROM tb_design_images AS i
                WHERE i.id_design = " + id_design + " AND i.store = 'SQ'
                ORDER BY i.sort ASC
            "

            Dim data_sq As DataTable = execute_query(query_sq, -1, True, "", "", "", "")

            GCSQ.DataSource = data_sq

            GVSQ.BestFitColumns()

            setImagesSQ()

            GridColumn9.VisibleIndex = True
            GridColumn9.VisibleIndex = 0

            GCSQ.RefreshDataSource()

            GVSQ.RefreshData()

            'th
            Dim query_th = "
                SELECT CONCAT('" + cloud_image_url + "/', i.file_name) AS url, i.file_name, i.sort, '' AS file_open
                FROM tb_design_images AS i
                WHERE i.id_design = " + id_design + " AND i.store = 'TH'
                ORDER BY i.sort ASC
            "

            Dim data_th As DataTable = execute_query(query_th, -1, True, "", "", "", "")

            GCTH.DataSource = data_th

            GVTH.BestFitColumns()

            setImagesTH()

            GridColumn13.VisibleIndex = True
            GridColumn13.VisibleIndex = 0

            GCTH.RefreshDataSource()

            GVTH.RefreshData()

            Try
                FormMain.SplashScreenManager1.CloseWaitForm()
            Catch ex As Exception
            End Try
        Else
            stopCustom("Please select design.")

            Close()
        End If
    End Sub

    Sub setImagesZ()
        For i = 0 To GVZ.RowCount - 1
            Dim img As Image = Nothing
            Dim resizeImg As Image = Nothing

            img = Image.FromFile(product_image_path + "\default.jpg")

            resizeImg = img.GetThumbnailImage(138, 200, Nothing, Nothing)

            Dim fileName As String = GVZ.GetRowCellValue(i, "sort").ToString

            Try
                Dim filePath As String = GVZ.GetRowCellValue(i, "url").ToString

                Dim t As Net.WebClient = New Net.WebClient

                img = Image.FromStream(New IO.MemoryStream(t.DownloadData(filePath)))

                resizeImg = img.GetThumbnailImage(138, 200, Nothing, Nothing)
            Catch ex As Exception
            End Try

            imagesZ.Add(fileName, resizeImg)
        Next
    End Sub

    Sub setImagesV()
        For i = 0 To GVV.RowCount - 1
            Dim img As Image = Nothing
            Dim resizeImg As Image = Nothing

            img = Image.FromFile(product_image_path + "\default.jpg")

            resizeImg = img.GetThumbnailImage(150, 200, Nothing, Nothing)

            Dim fileName As String = GVV.GetRowCellValue(i, "sort").ToString

            Try
                Dim filePath As String = GVV.GetRowCellValue(i, "url").ToString

                Dim t As Net.WebClient = New Net.WebClient

                img = Image.FromStream(New IO.MemoryStream(t.DownloadData(filePath)))

                resizeImg = img.GetThumbnailImage(150, 200, Nothing, Nothing)
            Catch ex As Exception
            End Try

            imagesV.Add(fileName, resizeImg)
        Next
    End Sub

    Sub setImagesSQ()
        For i = 0 To GVSQ.RowCount - 1
            Dim img As Image = Nothing
            Dim resizeImg As Image = Nothing

            img = Image.FromFile(product_image_path + "\default.jpg")

            resizeImg = img.GetThumbnailImage(200, 200, Nothing, Nothing)

            Dim fileName As String = GVSQ.GetRowCellValue(i, "sort").ToString

            Try
                Dim filePath As String = GVSQ.GetRowCellValue(i, "url").ToString

                Dim t As Net.WebClient = New Net.WebClient

                img = Image.FromStream(New IO.MemoryStream(t.DownloadData(filePath)))

                resizeImg = img.GetThumbnailImage(200, 200, Nothing, Nothing)
            Catch ex As Exception
            End Try

            imagesSQ.Add(fileName, resizeImg)
        Next
    End Sub

    Sub setImagesTH()
        For i = 0 To GVTH.RowCount - 1
            Dim img As Image = Nothing
            Dim resizeImg As Image = Nothing

            img = Image.FromFile(product_image_path + "\default.jpg")

            resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)

            Dim fileName As String = GVTH.GetRowCellValue(i, "sort").ToString

            Try
                Dim filePath As String = GVTH.GetRowCellValue(i, "url").ToString

                Dim t As Net.WebClient = New Net.WebClient

                img = Image.FromStream(New IO.MemoryStream(t.DownloadData(filePath)))

                resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
            Catch ex As Exception
            End Try

            imagesTH.Add(fileName, resizeImg)
        Next
    End Sub

    Private Sub GVZ_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVZ.CustomUnboundColumnData
        If e.Column.FieldName = "image" AndAlso e.IsGetData Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim fileName As String = view.GetRowCellValue(e.ListSourceRowIndex, "sort").ToString

            e.Value = imagesZ(fileName)
        End If
    End Sub

    Private Sub GVV_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVV.CustomUnboundColumnData
        If e.Column.FieldName = "image" AndAlso e.IsGetData Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim fileName As String = view.GetRowCellValue(e.ListSourceRowIndex, "sort").ToString

            e.Value = imagesV(fileName)
        End If
    End Sub

    Private Sub GVSQ_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVSQ.CustomUnboundColumnData
        If e.Column.FieldName = "image" AndAlso e.IsGetData Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim fileName As String = view.GetRowCellValue(e.ListSourceRowIndex, "sort").ToString

            e.Value = imagesSQ(fileName)
        End If
    End Sub

    Private Sub GVTH_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVTH.CustomUnboundColumnData
        If e.Column.FieldName = "image" AndAlso e.IsGetData Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            Dim fileName As String = view.GetRowCellValue(e.ListSourceRowIndex, "sort").ToString

            e.Value = imagesTH(fileName)
        End If
    End Sub

    Private Sub RepositoryItemHyperLinkEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit.Click
        Process.Start(GVZ.GetFocusedRowCellValue("url").ToString)
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        Process.Start(GVV.GetFocusedRowCellValue("url").ToString)
    End Sub

    Private Sub RepositoryItemHyperLinkEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit2.Click
        Process.Start(GVSQ.GetFocusedRowCellValue("url").ToString)
    End Sub

    Private Sub RepositoryItemHyperLinkEdit3_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit3.Click
        Process.Start(GVTH.GetFocusedRowCellValue("url").ToString)
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVZ.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile(cloud_image_url + "/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVV.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile(cloud_image_url + "/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVSQ.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile(cloud_image_url + "/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit3_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit3.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVTH.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile(cloud_image_url + "/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub FormDesignImagesDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class