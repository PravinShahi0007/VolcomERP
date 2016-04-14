Public Class FormFGCodeReplaceWHSingle 
    Dim dt As New DataTable

    Private Sub FormFGCodeReplaceWHSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGCodeReplaceWHSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()

        'inisialisasi jika blm ada
        Try
            dt.Columns.Add("code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("qty_all_product")
            dt.Columns.Add("qty_replace")
            dt.Columns.Add("id_product")
        Catch ex As Exception
        End Try
    End Sub

    Sub viewProduct()
        Dim query As String = "CALL view_stock_fg('0', '0', '0', '0', '0','1', '9999-01-01')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        dt.Clear()
        makeSafeGV(GVProduct)
        Dim jum_select As Integer = 0
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = True
        Dim alert_check As String = ""

        For i As Integer = 0 To ((GVProduct.RowCount - 1) - GetGroupRowCount(GVProduct))
            Dim is_select As String = GVProduct.GetRowCellValue(i, "is_select").ToString
            If is_select = "Yes" Then
                Dim qty_replace As Integer = 0
                Try
                    qty_replace = Integer.Parse(GVProduct.GetRowCellValue(i, "qty_replace").ToString)
                Catch ex As Exception
                End Try

                If qty_replace = 0 Then
                    cond_general = False
                Else
                    Dim R As DataRow = dt.NewRow
                    R("code") = GVProduct.GetRowCellValue(i, "code").ToString
                    R("name") = GVProduct.GetRowCellValue(i, "name").ToString
                    R("size") = GVProduct.GetRowCellValue(i, "size").ToString
                    R("color") = GVProduct.GetRowCellValue(i, "color").ToString
                    R("qty_all_product") = Decimal.Parse(GVProduct.GetRowCellValue(i, "qty_all_product").ToString)
                    R("qty_replace") = Decimal.Parse(GVProduct.GetRowCellValue(i, "qty_replace").ToString)
                    R("id_product") = GVProduct.GetRowCellValue(i, "id_product").ToString
                    dt.Rows.Add(R)
                    jum_select = jum_select + 1
                End If
            End If
        Next

        If cond_general Then
            If jum_select <= 0 Then
                stopCustom("No item selected !")
            Else
                'cek ada sama ato gak
                For j As Integer = 0 To ((FormFGCodeReplaceWHDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGCodeReplaceWHDet.GVItemList))
                    Dim id_product_cek As String = FormFGCodeReplaceWHDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                    For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                        If id_product_cek = dt.Rows(j_sub)("id_product").ToString Then
                            alert_check = dt.Rows(j_sub)("name").ToString + " / Size : " + dt.Rows(j_sub)("size").ToString + ", already selected !"
                            cond_check = False
                            Exit For
                        End If
                    Next
                Next

                If Not cond_check Then
                    stopCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormFGCodeReplaceWHDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("counting_start") = "0000"
                        newRow("counting_end") = "0000"
                        newRow("fg_code_replace_wh_det_qty") = Decimal.Parse(dt.Rows(ls)("qty_replace").ToString)
                        newRow("id_product") = dt.Rows(ls)("id_product").ToString
                        newRow("id_fg_code_replace_wh_det") = "0"
                        TryCast(FormFGCodeReplaceWHDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormFGCodeReplaceWHDet.GCItemList.RefreshDataSource()
                        FormFGCodeReplaceWHDet.GVItemList.RefreshData()
                    Next
                    FormFGCodeReplaceWHDet.check_but()
                    Close()
                End If
            End If
        Else
            stopCustom("Input not valid. Make sure : " + System.Environment.NewLine + "- Replacement qty is not zero.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub


    Private Sub SpinQtyReplace_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpinQtyReplace.EditValueChanged
        'aktifkan jika dipakai (ada pembatasan berdasarkan limit)
        Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
        Dim qty_limit As Decimal = Decimal.Parse(GVProduct.GetFocusedRowCellValue("qty_all_product").ToString)
        If qty_rec > qty_limit Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Replacement qty cannot exceed " + qty_limit.ToString + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GVProduct.SetFocusedRowCellValue("qty_replace", 0)
        End If
    End Sub
End Class