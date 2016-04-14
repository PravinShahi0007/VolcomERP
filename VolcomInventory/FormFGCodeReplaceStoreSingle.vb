Public Class FormFGCodeReplaceStoreSingle 
    Dim dt As New DataTable

    Private Sub FormFGCodeReplaceStoreSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGCodeReplaceStoreSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()

        'inisialisasi jika blm ada
        Try
            dt.Columns.Add("code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("comp_name")
            dt.Columns.Add("jum_product")
            dt.Columns.Add("jum_replace")
            dt.Columns.Add("id_pl_sales_order_del_det")
            dt.Columns.Add("pl_sales_order_del_number")
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_comp")
        Catch ex As Exception
        End Try
    End Sub

    Sub viewProduct()
        Dim query As String = "CALL view_return_in_sales_sum('0', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True

            'colummn do
            Dim queryku As String = ""
            queryku += "SELECT del_det.id_pl_sales_order_del_det, comp.id_comp, del_det.id_product,(del.pl_sales_order_del_number) as 'DO Number', (so.sales_order_number) AS 'Sales Order', (del.pl_sales_order_del_date) AS 'Created Date' "
            queryku += "FROM tb_pl_sales_order_del_det del_det "
            queryku += "INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = del_det.id_pl_sales_order_del "
            queryku += "INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order "
            queryku += "INNER JOIN tb_m_comp_contact comp_cont ON comp_cont.id_comp_contact = del.id_store_contact_to "
            queryku += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_cont.id_comp "
            queryku += "WHERE del.id_report_status='6' ORDER BY del.pl_sales_order_del_number DESC "
            Dim data_do As DataTable = execute_query(queryku, -1, True, "", "", "", "")
            SLEDO.DataSource = Nothing
            SLEDO.DataSource = data_do
            SLEDO.PopulateViewColumns()
            SLEDO.NullText = ""
            SLEDO.View.Columns("id_pl_sales_order_del_det").Visible = False
            SLEDO.View.Columns("id_comp").Visible = False
            SLEDO.View.Columns("id_product").Visible = False
            SLEDO.DisplayMember = "DO Number"
            SLEDO.ValueMember = "id_pl_sales_order_del_det"
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
                Dim id_pl_sales_order_del_det As String = "-1"
                Try
                    id_pl_sales_order_del_det = GVProduct.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString
                Catch ex As Exception
                End Try

                Dim jum_replace As Integer = 0
                Try
                    jum_replace = Integer.Parse(GVProduct.GetRowCellValue(i, "jum_replace").ToString)
                Catch ex As Exception
                End Try

                If id_pl_sales_order_del_det = "-1" Or id_pl_sales_order_del_det = "0" Or jum_replace = 0 Then
                    cond_general = False
                Else
                    Dim R As DataRow = dt.NewRow
                    R("code") = GVProduct.GetRowCellValue(i, "code").ToString
                    R("name") = GVProduct.GetRowCellValue(i, "name").ToString
                    R("size") = GVProduct.GetRowCellValue(i, "size").ToString
                    R("color") = GVProduct.GetRowCellValue(i, "color").ToString
                    R("jum_product") = Decimal.Parse(GVProduct.GetRowCellValue(i, "jum_product").ToString)
                    R("jum_replace") = Decimal.Parse(GVProduct.GetRowCellValue(i, "jum_replace").ToString)
                    R("id_pl_sales_order_del_det") = GVProduct.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString
                    R("pl_sales_order_del_number") = GVProduct.GetRowCellDisplayText(i, "id_pl_sales_order_del_det").ToString
                    R("id_product") = GVProduct.GetRowCellValue(i, "id_product").ToString
                    R("id_comp") = GVProduct.GetRowCellValue(i, "id_comp").ToString
                    R("comp_name") = GVProduct.GetRowCellValue(i, "comp_name").ToString
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
                For j As Integer = 0 To ((FormFGCodeReplaceStoreDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGCodeReplaceStoreDet.GVItemList))
                    Dim id_product_cek As String = FormFGCodeReplaceStoreDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                    Dim id_comp_cek As String = FormFGCodeReplaceStoreDet.GVItemList.GetRowCellValue(j, "id_comp").ToString
                    For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                        If id_product_cek = dt.Rows(j_sub)("id_product").ToString And id_comp_cek = dt.Rows(j_sub)("id_comp").ToString Then
                            alert_check = dt.Rows(j_sub)("name").ToString + " / Size : " + dt.Rows(j_sub)("size").ToString + " / Store : " + dt.Rows(j_sub)("comp_name").ToString + ", already selected !"
                            cond_check = False
                            Exit For
                        End If
                    Next
                Next

                If Not cond_check Then
                    stopCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormFGCodeReplaceStoreDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("pl_sales_order_del_number") = dt.Rows(ls)("pl_sales_order_del_number").ToString
                        newRow("id_comp") = dt.Rows(ls)("id_comp").ToString
                        newRow("comp_name") = dt.Rows(ls)("comp_name").ToString
                        newRow("counting_start") = "0000"
                        newRow("counting_end") = "0000"
                        newRow("fg_code_replace_store_det_qty") = Decimal.Parse(dt.Rows(ls)("jum_replace").ToString)
                        newRow("id_pl_sales_order_del_det") = dt.Rows(ls)("id_pl_sales_order_del_det").ToString
                        newRow("id_product") = dt.Rows(ls)("id_product").ToString
                        newRow("id_fg_code_replace_store_det") = "0"
                        TryCast(FormFGCodeReplaceStoreDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormFGCodeReplaceStoreDet.GCItemList.RefreshDataSource()
                        FormFGCodeReplaceStoreDet.GVItemList.RefreshData()
                    Next
                    FormFGCodeReplaceStoreDet.check_but()
                    Close()
                End If
            End If
        Else
            stopCustom("Input not valid. Make sure : " + System.Environment.NewLine + "- Delivery order not blank." + System.Environment.NewLine + "- Replacement qty is not zero.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private clone As DataView = Nothing
    Private Sub GVProduct_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "id_pl_sales_order_del_det" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "[id_product] = " + row("id_product").ToString() + " AND [id_comp] = " + row("id_comp").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub GVProduct_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Private Sub SpinQtyReplace_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpinQtyReplace.EditValueChanged
        'aktifkan jika dipakai (ada pembatasan berdasarkan limit)
        Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
        Dim qty_limit As Decimal = Decimal.Parse(GVProduct.GetFocusedRowCellValue("jum_product").ToString)
        If qty_rec > qty_limit Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Replacement qty cannot exceed " + qty_limit.ToString + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GVProduct.SetFocusedRowCellValue("jum_replace", 0)
        End If
    End Sub
End Class