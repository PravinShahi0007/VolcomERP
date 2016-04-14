Public Class FormPopUpProduct 
    Public id_pop_up As String = "-1"
    Public id_season_par As String = "-1"
    Public data_par As New DataTable
    Public id_trans As String = "-1"
    Public id_product_list As New List(Of String)

    Private Sub FormPopUpProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_product_per_season('" + id_season_par + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdList.DataSource = data

        If id_pop_up = "1" Then
            GridColumnQty.Visible = False
            GridColumnVendorCode.Visible = False
            GVProdList.ActiveFilterString = "[design_price]>0 "
            noEdit()
        ElseIf id_pop_up = "2" Then
            If data_par.Rows.Count = 0 Then
                GCProdList.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCProdList.DataSource = except
            End If
        End If
    End Sub

    Sub check_but()
        Dim ix As Integer = GVProdList.FocusedRowHandle

        If GVProdList.RowCount > 0 And ix >= 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub GVProdList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdList.FocusedRowChanged
        If id_pop_up = "1" Then
            noEdit()
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then ' ANALISIS NEW SO
            makeSafeGV(GVProdList)
            GVProdList.ActiveFilterString = "[is_select]='Yes' "
            If GVProdList.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to add these product ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim cond_dupe As Boolean = False
                    Dim query_val As String = ""
                    Dim i_val As Integer = 0
                    For i As Integer = 0 To ((GVProdList.RowCount - 1) - GetGroupRowCount(GVProdList))
                        Dim data_filter As DataRow() = data_par.Select("[id_product]='" + GVProdList.GetRowCellValue(i, "id_product").ToString + "' ")
                        If data_filter.Length > 0 Then
                            'duplicate
                            cond_dupe = True
                            stopCustom("Product : " + GVProdList.GetRowCellValue(i, "design_name").ToString + "/Size " + GVProdList.GetRowCellValue(i, "Size").ToString + " is already exist.")
                            Exit For
                        Else
                            'no duplicate
                            cond_dupe = False
                            If i_val > 0 Then
                                query_val += "; "
                            End If
                            query_val += "INSERT INTO tb_fg_so_reff_det(id_fg_so_reff, id_fg_ds_store, id_product, fg_so_reff_det_qty) "
                            query_val += "SELECT '" + id_trans + "', ds_store.id_fg_ds_store, '" + GVProdList.GetRowCellValue(i, "id_product").ToString + "', 0 FROM tb_fg_ds_store ds_store where ds_store.id_season='" + id_season_par + "' "
                            i_val += 1
                        End If
                    Next

                    If cond_dupe Then
                        Close()
                    Else
                        execute_non_query(query_val, True, "", "", "", "")
                        FormFGSalesOrderReffDet.viewDetail()
                        Close()
                    End If
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Nothing item selected.")
                GVProdList.ActiveFilterString = ""
            End If
        ElseIf id_pop_up = "2" Then 'BORROW REQUEST QC PRODUCT
            makeSafeGV(GVProdList)
            GVProdList.ActiveFilterString = "[is_select]='Yes' "
            If GVProdList.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to add these product ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    For i As Integer = 0 To ((GVProdList.RowCount - 1) - GetGroupRowCount(GVProdList))
                        Dim newRow As DataRow = (TryCast(FormFGBorrowQCReqSingle.GCBorrow.DataSource, DataTable)).NewRow()
                        newRow("id_borrow_qc_req_det") = "0"
                        newRow("id_borrow_qc_req") = "0"
                        newRow("name") = GVProdList.GetRowCellValue(i, "design_display_name").ToString
                        newRow("code") = GVProdList.GetRowCellValue(i, "product_full_code").ToString
                        newRow("vendor_code") = GVProdList.GetRowCellValue(i, "product_ean_code").ToString
                        newRow("size") = GVProdList.GetRowCellValue(i, "Size").ToString
                        newRow("borrow_qc_req_det_qty") = GVProdList.GetRowCellValue(i, "qty")
                        newRow("borrow_qc_req_det_note") = ""
                        newRow("id_design") = GVProdList.GetRowCellValue(i, "id_design").ToString
                        newRow("id_product") = GVProdList.GetRowCellValue(i, "id_product").ToString
                        newRow("id_sample") = GVProdList.GetRowCellValue(i, "id_sample").ToString
                        TryCast(FormFGBorrowQCReqSingle.GCBorrow.DataSource, DataTable).Rows.Add(newRow)
                        FormSalesOrderDet.GCItemList.RefreshDataSource()
                        FormSalesOrderDet.GVItemList.RefreshData()
                        Close()
                    Next
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Nothing item selected.")
                GVProdList.ActiveFilterString = ""
            End If
        End If
    End Sub

    Private Sub FormPopUpProduct_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub noEdit()
        If GVProdList.FocusedRowHandle >= 0 Then
            Dim id_design_cek As String = GVProdList.GetFocusedRowCellValue("id_design_price").ToString
            If id_design_cek = "0" Then
                GVProdList.Columns("is_select").OptionsColumn.AllowEdit = False
            Else
                GVProdList.Columns("is_select").OptionsColumn.AllowEdit = True
            End If
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProdList.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVProdList.RowCount - 1) - GetGroupRowCount(GVProdList))
                If cek Then
                    GVProdList.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVProdList.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub GVProdList_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVProdList.PopupMenuShowing
        If GVProdList.RowCount > 0 And GVProdList.FocusedRowHandle >= 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub SMImg_Click(sender As Object, e As EventArgs) Handles SMImg.Click
        pre_viewImages("2", Nothing, GVProdList.GetFocusedRowCellValue("id_design").ToString, True)
    End Sub
End Class