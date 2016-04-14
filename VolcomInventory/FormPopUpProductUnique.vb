Public Class FormPopUpProductUnique 
    Dim id_design_image As String = "-1"
    Dim code As String = "-1"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpProductUnique_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Cursor = Cursors.WaitCursor
        pre_viewImages("2", PictureEdit1, id_design_image, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        code = "-1"
        Try
            id_design_image = GVProduct.GetFocusedRowCellValue("id_design").ToString
            code = GVProduct.GetFocusedRowCellValue("product_unique_code").ToString
        Catch ex As Exception
        End Try

        pre_viewImages("2", PictureEdit1, id_design_image, False)

        If code = "-1" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewProduct()
        Dim query As String = ""
        query += "CALL view_fg_unique_all() "
        Dim data As DataTable = execute_query(query, -11, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
            GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub FormPopUpProductUnique_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        FormFGTracking.BtnEditCode.Text = code
        Close()
        Cursor = Cursors.Default
    End Sub
End Class