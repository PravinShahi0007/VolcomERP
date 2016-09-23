Public Class FormMasterEmployee
    Public contract_rvw_date As String = "-1"

    Private Sub FormMasterEmployee_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterEmployee_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewEmployee(ByVal cond_param As String)
        Dim query As String = "CALL view_employee('" + cond_param + "', '2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Sub viewEmployeeAge(ByVal cond_param As String, ByVal date_param As String)
        Dim query As String = "CALL view_employee_age('" + cond_param + "', '2', '" + date_param + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormMasterEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployee("-1")
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to sync all machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SplashScreenManager1.ShowWaitForm()
            'class declare
            Dim fp As New ClassFingerPrint()
            Dim data_fp As DataTable = fp.get_fp_register()

            'test connection
            Dim query As String = "SELECT * FROM tb_m_fingerprint"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim conn As Boolean = False
            For i As Integer = 0 To data.Rows.Count - 1
                fp.ip = data.Rows(i)("ip").ToString
                fp.port = data.Rows(i)("port").ToString
                fp.connect()
                conn = fp.bIsConnected
                If Not conn Then
                    SplashScreenManager1.CloseWaitForm()
                    fp.disconnect()
                    stopCustom("Can't connect machine : " + data.Rows(i)("name").ToString)
                    Exit For
                Else
                    fp.disconnect()
                End If
            Next

            If conn Then
                fp.ip = data_fp.Rows(0)("ip").ToString
                fp.port = data_fp.Rows(0)("port").ToString
                fp.download_fp_tmp()
                fp.download_face_tmp()
                fp.upload_fp_temp()
                fp.upload_face_tmp()
                SplashScreenManager1.CloseWaitForm()
                infoCustom("Process completed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormMasterEmployeeCustom.ShowDialog()
    End Sub
End Class