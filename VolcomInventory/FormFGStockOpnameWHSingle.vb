Public Class FormFGStockOpnameWHSingle 
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
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("design_price")
            dt.Columns.Add("amount")
            dt.Columns.Add("note")
            dt.Columns.Add("id_det")
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_design")
            dt.Columns.Add("id_sample")
        Catch ex As Exception
        End Try

        viewDetail()
    End Sub


    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_stock_fg('" + id_wh + "', '0', '0','0','0','3', '9999-01-01') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount < 1 Then
            BtnChoose.Visible = False
        Else
            GVProduct.FocusedRowHandle = 0
            BtnChoose.Visible = True
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGStockOpnameWHSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_designx As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        pre_viewImages("2", PictureEdit1, id_designx, False)

        'If id_samplex = "0" Then
        '    BtnChoose.Enabled = False
        'Else
        '    BtnChoose.Enabled = True
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Cursor = Cursors.WaitCursor
        Dim id_designx As String = "0"

        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        pre_viewImages("2", PictureEdit1, id_designx, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditProduct.CheckedChanged
        Cursor = Cursors.WaitCursor
        GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Dim cek As String = CheckEditProduct.EditValue.ToString
        For i As Integer = 0 To (GVProduct.RowCount - 1)
            Try
                If cek Then
                    GVProduct.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVProduct.SetRowCellValue(i, "is_select", "No")
                End If
            Catch ex As Exception
            End Try
        Next
        Cursor = Cursors.Default
    End Sub

    Sub insertDt(ByVal code_param As String, ByVal name_param As String, ByVal size_param As String, ByVal color_param As String, ByVal cost_param As Decimal, ByVal id_design_price_param As Integer, ByVal design_price_param As Decimal, ByVal id_product_param As String, ByVal id_design_param As String, ByVal id_sample_param As String)
        Dim R As DataRow = dt.NewRow
        R("code") = code_param
        R("name") = name_param
        R("size") = size_param
        R("color") = color_param
        R("qty") = 0.0
        R("design_price") = design_price_param
        R("id_design_price") = id_design_price_param
        R("bom_unit_price") = cost_param
        R("amount") = 0.0
        R("note") = ""
        R("id_det") = "0"
        R("id_product") = id_product_param
        R("id_design") = id_design_param
        R("id_sample") = id_sample_param
        dt.Rows.Add(R)
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = False
        Dim alert_check As String = ""
        dt.Clear()

        Dim jum_select As Integer = 0
        For i As Integer = 0 To ((GVProduct.RowCount - 1) - GetGroupRowCount(GVProduct))
            Dim is_select As String = GVProduct.GetRowCellValue(i, "is_select").ToString
            Dim code As String = GVProduct.GetRowCellValue(i, "code").ToString
            Dim name As String = GVProduct.GetRowCellValue(i, "name").ToString
            Dim size As String = GVProduct.GetRowCellValue(i, "size").ToString
            Dim color As String = GVProduct.GetRowCellValue(i, "color").ToString
            Dim bom_unit_price As String = Decimal.Parse(GVProduct.GetRowCellValue(i, "bom_unit_price").ToString)
            Dim id_design_price As String = GVProduct.GetRowCellValue(i, "id_design_price").ToString
            Dim design_price As Decimal = GVProduct.GetRowCellValue(i, "design_price")
            Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
            Dim id_design As String = GVProduct.GetRowCellValue(i, "id_design").ToString
            Dim id_sample As String = GVProduct.GetRowCellValue(i, "id_sample").ToString
            If is_select = "Yes" Then
                insertDt(code, name, size, color, bom_unit_price, id_design_price, design_price, id_product, id_design, id_sample)
                jum_select = jum_select + 1
            End If
            cond_general = True
        Next

        If jum_select < 1 Then
            cond_general = False
        End If

        If cond_general Then
            If id_pop_up = "-1" Then
                'STOCK OPNAME 
                For j As Integer = 0 To (FormFGStockOpnameWHDet.GVItemList.RowCount - 1)
                    Try
                        Dim id_product_cek As String = FormFGStockOpnameWHDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                        Dim bom_unit_price_cek As Decimal = Decimal.Parse(FormFGStockOpnameWHDet.GVItemList.GetRowCellValue(j, "bom_unit_price").ToString)
                        For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                            Try
                                If id_product_cek = dt.Rows(j_sub)("id_product").ToString Then
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
                        Dim newRow As DataRow = (TryCast(FormFGStockOpnameWHDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("qty") = Decimal.Parse(dt.Rows(ls)("qty").ToString)
                        newRow("bom_unit_price") = Decimal.Parse(dt.Rows(ls)("bom_unit_price").ToString)
                        newRow("id_design_price") = Decimal.Parse(dt.Rows(ls)("id_design_price").ToString)
                        newRow("design_price") = Decimal.Parse(dt.Rows(ls)("design_price").ToString)
                        newRow("amount") = Decimal.Parse(dt.Rows(ls)("amount").ToString)
                        newRow("note") = dt.Rows(ls)("note").ToString
                        newRow("id_det") = dt.Rows(ls)("id_det").ToString
                        newRow("id_product") = dt.Rows(ls)("id_product").ToString
                        newRow("id_design") = dt.Rows(ls)("id_design").ToString
                        newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                        TryCast(FormFGStockOpnameWHDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormFGStockOpnameWHDet.GCItemList.RefreshDataSource()
                        FormFGStockOpnameWHDet.GVItemList.RefreshData()

                        id_param = id_param + dt.Rows(ls)("id_product").ToString
                        If ls < (dt.Rows.Count - 1) Then
                            id_param = id_param + ";"
                        End If
                    Next
                    FormFGStockOpnameWHDet.codeAvailableIns(id_param)
                    Close()
                End If
            ElseIf id_pop_up = "2" Then
                'WRITE IFF
                For j As Integer = 0 To (FormFGWoffDet.GVItemList.RowCount - 1)
                    Try
                        Dim id_product_cek As String = FormFGWoffDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                        For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                            Try
                                If id_product_cek = dt.Rows(j_sub)("id_product").ToString Then
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

                Dim id_param_woff As String = ""
                If Not cond_check Then
                    errorCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormFGWoffDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("fg_woff_det_qty") = Decimal.Parse(dt.Rows(ls)("qty").ToString)
                        newRow("qty_from_wh") = 0.0
                        newRow("fg_woff_det_note") = dt.Rows(ls)("note").ToString
                        newRow("id_fg_woff_det") = dt.Rows(ls)("id_det").ToString
                        newRow("id_product") = dt.Rows(ls)("id_product").ToString
                        newRow("id_design") = dt.Rows(ls)("id_design").ToString
                        newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                        newRow("design_cop") = dt.Rows(ls)("bom_unit_price")
                        newRow("design_cop_amount") = 0.0
                        TryCast(FormFGWoffDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormFGWoffDet.GCItemList.RefreshDataSource()
                        FormFGWoffDet.GVItemList.RefreshData()

                        id_param_woff = id_param_woff + dt.Rows(ls)("id_product").ToString
                        If ls < (dt.Rows.Count - 1) Then
                            id_param_woff = id_param_woff + ";"
                        End If
                    Next
                    FormFGWoffDet.codeAvailableIns(id_param_woff)
                    FormFGWoffDet.check_but()
                    Close()
                End If
            End If
        Else
            errorCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub
End Class