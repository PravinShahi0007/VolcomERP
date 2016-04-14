Public Class FormSampleDelOrderPopUp 
    Public id_pop_up As String = "-1"
    Public id_sample_order As String = "-1"
    Dim dt As New DataTable

    Private Sub FormSampleDelOrderPopUp_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleDelOrderPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleOrder()

        If id_pop_up = "2" Then
            'initiation datatable jika blm ada
            Try
                dt.Columns.Add("code")
                dt.Columns.Add("name")
                dt.Columns.Add("size")
                dt.Columns.Add("color")
                dt.Columns.Add("pl_sample_order_del_det_qty")
                dt.Columns.Add("pl_sample_order_del_det_qty_wh")
                dt.Columns.Add("pl_sample_order_del_det_note")
                dt.Columns.Add("id_sample_ret_price")
                dt.Columns.Add("sample_ret_price")
                dt.Columns.Add("pl_sample_order_del_det_amount_ret")
                dt.Columns.Add("id_sample")
                dt.Columns.Add("id_sample_order_det")
                dt.Columns.Add("id_pl_sample_order_del_det")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub viewSampleOrder()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim cond As String = "AND so.id_report_status =''3'' OR so.id_report_status =''4'' "
        If id_sample_order <> "-1" Then
            cond += "AND so.id_sample_order = ''" + id_sample_order + "'' "
        End If
        Dim query As String = query_c.queryMain(cond, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleOrder.DataSource = data
        If GVSampleOrder.RowCount > 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
        viewSampleOrderDet()
    End Sub

    Sub viewSampleOrderDet()
        Dim id_sample_order As String = "-1"
        Try
            id_sample_order = GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
        Catch ex As Exception
        End Try
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryDetail(id_sample_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSampleOrder.DataSource = data
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormSampleDelOrderDet.id_sample_order = GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
            FormSampleDelOrderDet.TxtSampleOrder.Text = GVSampleOrder.GetFocusedRowCellValue("sample_order_number").ToString
            FormSampleDelOrderDet.id_store_contact_to = GVSampleOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
            FormSampleDelOrderDet.id_store_to = GVSampleOrder.GetFocusedRowCellValue("id_store_to").ToString
            FormSampleDelOrderDet.TxtCodeCompTo.Text = GVSampleOrder.GetFocusedRowCellValue("store_number_to").ToString
            FormSampleDelOrderDet.TxtNameCompTo.Text = GVSampleOrder.GetFocusedRowCellValue("store_name_to").ToString
            FormSampleDelOrderDet.MEAdrressCompTo.Text = GVSampleOrder.GetFocusedRowCellValue("store_address_to").ToString
            FormSampleDelOrderDet.LETypeSO.ItemIndex = FormSampleDelOrderDet.LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", GVSampleOrder.GetFocusedRowCellValue("id_so_type").ToString)
            FormSampleDelOrderDet.LEStatusSO.ItemIndex = FormSampleDelOrderDet.LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", GVSampleOrder.GetFocusedRowCellValue("id_so_status").ToString)
            FormSampleDelOrderDet.BtnInfoSrs.Enabled = True
            FormSampleDelOrderDet.GroupControlListItem.Enabled = True
            FormSampleDelOrderDet.viewSampleOrder()
            FormSampleDelOrderDet.viewDetailBC()
            FormSampleDelOrderDet.viewDetailDrawer()
            FormSampleDelOrderDet.check_but()
            FormSampleDelOrderDet.allowScanPage()
            Close()
        ElseIf id_pop_up = "2" Then
            Dim jum_select As Integer = 0
            Dim alert_check As String = ""
            Dim cond_check As Boolean = True
            dt.Clear()
            For i As Integer = 0 To GVListSampleOrder.RowCount - 1
                Try
                    Dim is_select As String = GVListSampleOrder.GetRowCellValue(i, "is_select").ToString
                    If is_select = "Yes" Then
                        Dim R As DataRow = dt.NewRow
                        R("code") = GVListSampleOrder.GetRowCellValue(i, "code").ToString
                        R("name") = GVListSampleOrder.GetRowCellValue(i, "name").ToString
                        R("size") = GVListSampleOrder.GetRowCellValue(i, "size").ToString
                        R("color") = GVListSampleOrder.GetRowCellValue(i, "color").ToString
                        R("pl_sample_order_del_det_qty") = 0.0
                        R("pl_sample_order_del_det_qty_wh") = 0.0
                        R("pl_sample_order_del_det_note") = ""
                        R("id_sample_ret_price") = GVListSampleOrder.GetRowCellValue(i, "id_sample_ret_price").ToString
                        R("sample_ret_price") = Decimal.Parse(GVListSampleOrder.GetRowCellValue(i, "sample_ret_price").ToString)
                        R("pl_sample_order_del_det_amount_ret") = 0.0
                        R("id_sample") = GVListSampleOrder.GetRowCellValue(i, "id_sample").ToString
                        R("id_pl_sample_order_del_det") = "0"
                        R("id_sample_order_det") = GVListSampleOrder.GetRowCellValue(i, "id_sample_order_det").ToString
                        dt.Rows.Add(R)
                        jum_select = jum_select + 1
                    End If
                Catch ex As Exception
                End Try
            Next


            If jum_select <= 0 Then
                stopCustom("No item selected !")
            Else
                'cek ada sama ato gak
                For j As Integer = 0 To (FormSampleDelOrderDet.GVItemList.RowCount - 1)
                    Try
                        Dim id_sample_cek As String = FormSampleDelOrderDet.GVItemList.GetRowCellValue(j, "id_sample").ToString
                        For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                            Try
                                If id_sample_cek = dt.Rows(j_sub)("id_sample").ToString Then
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

                If Not cond_check Then
                    stopCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormSampleDelOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("pl_sample_order_del_det_qty") = 0.0
                        newRow("pl_sample_order_del_det_qty_wh") = 0.0
                        newRow("pl_sample_order_del_det_amount_ret") = 0.0
                        newRow("pl_sample_order_del_det_note") = ""
                        newRow("id_pl_sample_order_del_det") = "0"
                        newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                        newRow("id_sample_order_det") = dt.Rows(ls)("id_sample_order_det").ToString
                        newRow("id_sample_ret_price") = dt.Rows(ls)("id_sample_ret_price").ToString
                        newRow("sample_ret_price") = Decimal.Parse(dt.Rows(ls)("sample_ret_price").ToString)
                        TryCast(FormSampleDelOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormSampleDelOrderDet.GCItemList.RefreshDataSource()
                        FormSampleDelOrderDet.GVItemList.RefreshData()
                    Next
                    FormSampleDelOrderDet.check_but()
                    FormSampleDelOrderDet.allowScanPage()
                    Close()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSampleOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleOrder.FocusedRowChanged
        viewSampleOrderDet()
    End Sub

    Private Sub GVListSampleOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

  
    Private Sub CheckEditSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelectAll.CheckedChanged
        Cursor = Cursors.WaitCursor
        GVListSampleOrder.OptionsBehavior.AutoExpandAllGroups = True
        Dim cek As String = CheckEditSelectAll.EditValue.ToString
        For i As Integer = 0 To (GVListSampleOrder.RowCount - 1)
            Try
                If cek Then
                    GVListSampleOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVListSampleOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Catch ex As Exception
            End Try
        Next
        Cursor = Cursors.Default
    End Sub
End Class