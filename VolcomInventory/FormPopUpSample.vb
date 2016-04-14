Public Class FormPopUpSample
    Public id_sample As String = "-1"
    Public id_pop_up As String = "-1"
    ' id pop up here , even if i think it's only used once ... i hope..
    ' 1 = sample plan

    Private Sub FormPopUpSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample()
        If GVSample.RowCount > 0 Then
            If id_sample <> "-1" Then
                GVSample.FocusedRowHandle = find_row(GVSample, "id_sample", id_sample)
            End If
        End If
    End Sub
    Sub view_sample()
        Try
            Dim query As String
            query = "CALL view_sample()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSample.DataSource = data
            '
            If id_sample <> "-1" Then
                '
                GVSample.FocusedRowHandle = find_row(GVSample, "id_sample", id_sample)
            End If
            '
            If Not data.Rows.Count < 1 Then
                view_image()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        pre_viewImages("1", PictureEdit1, GVSample.GetFocusedRowCellValue("id_sample").ToString, False)
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Try
            pre_viewImages("1", PictureEdit1, GVSample.GetFocusedRowCellValue("id_sample").ToString, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpSample_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then
            If id_sample <> "-1" Then
                'edit
                'check if exist
                Dim already = False
                If FormSamplePlanDet.GVListPurchase.RowCount > 0 Then
                    For i As Integer = 0 To FormSamplePlanDet.GVListPurchase.RowCount - 1
                        If FormSamplePlanDet.GVListPurchase.GetRowCellValue(i, "id_sample").ToString = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString And Not GVSample.GetFocusedRowCellDisplayText("id_sample").ToString = id_sample Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This sample already on list.")
                Else
                    FormSamplePlanDet.GVListPurchase.SetRowCellValue(FormSamplePlanDet.GVListPurchase.FocusedRowHandle, "id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                    FormSamplePlanDet.GVListPurchase.SetRowCellValue(FormSamplePlanDet.GVListPurchase.FocusedRowHandle, "size", GVSample.GetFocusedRowCellDisplayText("Size").ToString)
                    FormSamplePlanDet.GVListPurchase.SetRowCellValue(FormSamplePlanDet.GVListPurchase.FocusedRowHandle, "name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                    FormSamplePlanDet.GVListPurchase.SetRowCellValue(FormSamplePlanDet.GVListPurchase.FocusedRowHandle, "code", GVSample.GetFocusedRowCellDisplayText("sample_us_code").ToString)
                    FormSamplePlanDet.GVListPurchase.SetRowCellValue(FormSamplePlanDet.GVListPurchase.FocusedRowHandle, "color", GVSample.GetFocusedRowCellDisplayText("Color").ToString)
                    Close()
                End If
            Else
                'new
                'check if exist
                Dim already = False
                If FormSamplePlanDet.GVListPurchase.RowCount > 0 Then
                    For i As Integer = 0 To FormSamplePlanDet.GVListPurchase.RowCount - 1
                        If FormSamplePlanDet.GVListPurchase.GetRowCellValue(i, "id_sample").ToString = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Sample already in list")
                Else
                    Dim newRow As DataRow = (TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_sample") = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
                    newRow("size") = GVSample.GetFocusedRowCellDisplayText("Size").ToString
                    newRow("name") = GVSample.GetFocusedRowCellDisplayText("sample_name").ToString
                    newRow("code") = GVSample.GetFocusedRowCellDisplayText("sample_us_code").ToString
                    newRow("color") = GVSample.GetFocusedRowCellDisplayText("Color").ToString
                    newRow("qty") = "1"

                    TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePlanDet.GCListPurchase.RefreshDataSource()
                    FormSamplePlanDet.check_gv_but()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSample.RowClick
        If GVSample.RowCount > 0 Then
            view_image()
        End If
    End Sub
End Class