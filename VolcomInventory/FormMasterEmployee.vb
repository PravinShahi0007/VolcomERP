Public Class FormMasterEmployee 

    Private Sub FormMasterEmployee_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterEmployee_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewEmployee()
        Dim query As String = "CALL view_employee('-1', 2)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormMasterEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployee()
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            GVEmployee.RowHeight = 100
            GVEmployee.Columns("img").Visible = True
        Else
            GVEmployee.RowHeight = 10
            GVEmployee.Columns("img").Visible = False
        End If
        GCEmployee.RefreshDataSource()
        GVEmployee.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = emp_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub GVEmployee_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVEmployee.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_employee"))

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

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 And GVEmployee.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub freeze(ByVal check As Boolean)
        If check Then
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridColumnPic.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            If CheckImg.EditValue = True Then
                GridColumnPic.VisibleIndex = 0
            End If
            GridColumn2.VisibleIndex = 1
            GridColumn1.VisibleIndex = 2
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