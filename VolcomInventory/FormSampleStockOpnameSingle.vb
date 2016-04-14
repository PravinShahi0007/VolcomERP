Public Class FormSampleStockOpnameSingle 
    Public id_wh As String = "-1"
    Public action_pop As String = "-1"
    Public id_product_list As New List(Of String)
    Public name_product_list As New List(Of String)
    Dim dt As New DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormFGStockOpnameWHSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("qty")
            dt.Columns.Add("sample_price")
            dt.Columns.Add("amount")
            dt.Columns.Add("note")
            dt.Columns.Add("id_det")
            dt.Columns.Add("id_sample")
            dt.Columns.Add("id_sample_price")
        Catch ex As Exception
        End Try

        viewDetail()
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_stock_sample('" + id_wh + "', '0', '0','0','9999-01-01','1') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSample.DataSource = data
        If GVSample.RowCount < 1 Then
            BtnChoose.Visible = False
        Else
            GVSample.FocusedRowHandle = 0
            BtnChoose.Visible = True
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGStockOpnameWHSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSample.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Cursor = Cursors.WaitCursor
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditProduct.CheckedChanged
        Cursor = Cursors.WaitCursor
        GVSample.OptionsBehavior.AutoExpandAllGroups = True
        Dim cek As String = CheckEditProduct.EditValue.ToString
        For i As Integer = 0 To (GVSample.RowCount - 1)
            Try
                If cek Then
                    GVSample.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSample.SetRowCellValue(i, "is_select", "No")
                End If
            Catch ex As Exception
            End Try
        Next
        Cursor = Cursors.Default
    End Sub

    Sub insertDt(ByVal code_param As String, ByVal name_param As String, ByVal size_param As String, ByVal color_param As String, ByVal cost_param As Decimal, ByVal id_price_param As String, ByVal id_sample_param As String)
        Dim R As DataRow = dt.NewRow
        R("code") = code_param
        R("name") = name_param
        R("size") = size_param
        R("color") = color_param
        R("qty") = 0.0
        R("sample_price") = cost_param
        R("amount") = 0.0
        R("note") = ""
        R("id_det") = "0"
        R("id_sample") = id_sample_param
        R("id_sample_price") = id_price_param
        dt.Rows.Add(R)
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = False
        Dim alert_check As String = ""
        dt.Clear()

        Dim jum_select As Integer = 0
        For i As Integer = 0 To (GVSample.RowCount - 1)
            Try
                Dim is_select As String = GVSample.GetRowCellValue(i, "is_select").ToString
                Dim code As String = GVSample.GetRowCellValue(i, "code").ToString
                Dim name As String = GVSample.GetRowCellValue(i, "name").ToString
                Dim size As String = GVSample.GetRowCellValue(i, "size").ToString
                Dim color As String = GVSample.GetRowCellValue(i, "color").ToString
                Dim sample_price As String = Decimal.Parse(GVSample.GetRowCellValue(i, "sample_price").ToString)
                Dim id_sample As String = GVSample.GetRowCellValue(i, "id_sample").ToString
                Dim id_sample_price As String = GVSample.GetRowCellValue(i, "id_sample_price").ToString
                If is_select = "Yes" Then
                    insertDt(code, name, size, color, sample_price, id_sample_price, id_sample)
                    jum_select = jum_select + 1
                End If
                cond_general = True
            Catch ex As Exception
            End Try
        Next

        If jum_select < 1 Then
            cond_general = False
        End If

        If cond_general Then
            If id_pop_up = "-1" Then
                'STOCK OPNAME 
                For j As Integer = 0 To (FormSampleStockOpnameDet.GVItemList.RowCount - 1)
                    Try
                        Dim id_sample_cek As String = FormSampleStockOpnameDet.GVItemList.GetRowCellValue(j, "id_sample").ToString
                        Dim sample_price_cek As Decimal = Decimal.Parse(FormSampleStockOpnameDet.GVItemList.GetRowCellValue(j, "sample_price").ToString)
                        For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                            Try
                                If id_sample_cek = dt.Rows(j_sub)("id_sample").ToString And sample_price_cek = Decimal.Parse(dt.Rows(j_sub)("sample_price").ToString) Then
                                    alert_check = dt.Rows(j_sub)("name").ToString + " / Size : " + dt.Rows(j_sub)("size").ToString + ", already selected !"
                                    cond_check = False
                                    Exit For
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    Catch ex As Exception
                    End Try
                Next

                Dim id_param As String = ""
                If Not cond_check Then
                    errorCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormSampleStockOpnameDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("qty") = Decimal.Parse(dt.Rows(ls)("qty").ToString)
                        newRow("sample_price") = Decimal.Parse(dt.Rows(ls)("sample_price").ToString)
                        newRow("amount") = Decimal.Parse(dt.Rows(ls)("amount").ToString)
                        newRow("note") = dt.Rows(ls)("note").ToString
                        newRow("id_det") = dt.Rows(ls)("id_det").ToString
                        newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                        newRow("id_sample_price") = dt.Rows(ls)("id_sample_price").ToString
                        TryCast(FormSampleStockOpnameDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormSampleStockOpnameDet.GCItemList.RefreshDataSource()
                        FormSampleStockOpnameDet.GVItemList.RefreshData()
                    Next
                    FormSampleStockOpnameDet.check_but()
                    Close()
                End If
            End If
        Else
            errorCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub
End Class