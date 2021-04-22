Public Class FormOLReturnRefuseAddNonFisik
    Private Sub FormOLReturnRefuseAddNonFisik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Dim data_exist As DataTable = FormOLReturnRefuseDet.GCData.DataSource
        Dim data_main As DataTable = FormOLReturnRefuseDet.dt
        If data_exist.Rows.Count = 0 Then
            GCData.DataSource = data_main
            GVData.BestFitColumns()
        Else
            Dim t1 = data_main.AsEnumerable()
            Dim t2 = data_exist.AsEnumerable()
            Try
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_sales_order_det").ToString Equals _t2("id_sales_order_det").ToString Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
                GVData.BestFitColumns()
            Catch ex As Exception
                GCData.DataSource = Nothing
            End Try
        End If
    End Sub

    Private Sub FormOLReturnRefuseAddNonFisik_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim code As String = GVData.GetFocusedRowCellValue("code_list").ToString
            Dim dtf As DataRow() = FormOLReturnRefuseDet.dt.Select("[code_list]='" + code + "' AND [is_used]='2'")
            If dtf.Length <= 0 Then
                stopCustomDialog("Code : " + code + " not found or already scanned.")
                Close()
            Else
                makeSafeGV(GVData)
                Dim newRow As DataRow = (TryCast(FormOLReturnRefuseDet.GCData.DataSource, DataTable)).NewRow()
                newRow("id_return_refuse_det") = "0"
                newRow("id_return_refuse") = "0"
                newRow("id_sales_order_det") = dtf(0)("id_sales_order_det").ToString
                newRow("id_sales_return_order_det") = "0"
                newRow("id_sales_pos_det_cn") = "0"
                newRow("id_product") = dtf(0)("id_product").ToString
                newRow("id_pl_prod_order_rec_det_unique") = dtf(0)("id_pl_prod_order_rec_det_unique").ToString
                newRow("scanned_code") = dtf(0)("code_list").ToString
                newRow("name") = dtf(0)("name").ToString
                newRow("size") = dtf(0)("size").ToString
                newRow("item_id") = dtf(0)("item_id").ToString
                newRow("ol_store_id") = dtf(0)("ol_store_id").ToString
                newRow("id_design_price") = dtf(0)("id_design_price").ToString
                newRow("design_price") = dtf(0)("design_price")
                newRow("qty") = 1

                TryCast(FormOLReturnRefuseDet.GCData.DataSource, DataTable).Rows.Add(newRow)
                FormOLReturnRefuseDet.GCData.RefreshDataSource()
                FormOLReturnRefuseDet.GVData.RefreshData()
                FormOLReturnRefuseDet.GVData.FocusedRowHandle = FormOLReturnRefuseDet.GVData.RowCount - 1
                '
                dtf(0)("is_used") = "1"
                '
                'refresh
                viewData()
            End If
            Cursor = Cursors.WaitCursor
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GCData_DoubleClick(sender As Object, e As EventArgs) Handles GCData.DoubleClick
        choose()
    End Sub
End Class