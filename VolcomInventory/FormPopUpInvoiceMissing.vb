Public Class FormPopUpInvoiceMissing 
    Public id_popup As String = "-1"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpInvoiceMissing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEDueDate.DateTime = Now
        MQPBMissing.Visible = False
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        MQPBMissing.Visible = True
        If id_popup = "1" Then
            Dim number As String = header_number_sales("24")
            Dim query_cek As String = "SELECT id_sales_pos_ref FROM tb_fg_so_wh WHERE id_fg_so_wh='" + FormViewFGStockOpnameWH.id_fg_so_wh + "'"
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows(0)("id_sales_pos_ref").ToString = "" Or data_cek.Rows(0)("id_sales_pos_ref").ToString = "0" Then
                Dim query As String = ""
                Dim id_sales_pos As String = ""

                FormViewFGStockOpnameWH.GVItemList.ClearColumnsFilter()
                FormViewFGStockOpnameWH.GVItemList.ActiveFilterString = "[fg_so_wh_sum_dif] < 0"
                If FormViewFGStockOpnameWH.GVItemList.RowCount > 0 Then
                    Dim tot As Decimal = 0
                    Dim after_vat As Decimal = 0

                    query = "INSERT INTO tb_sales_pos(id_store_contact_from,sales_pos_date,sales_pos_due_date,sales_pos_number,sales_pos_note,sales_pos_start_period,sales_pos_end_period,id_memo_type)"
                    query += " VALUES('" + FormViewFGStockOpnameWH.id_comp_contact_from + "',NOW(),'" + DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "','" + number + "','" + MENote.Text + "',NOW(),NOW(),'7');SELECT LAST_INSERT_ID() "
                    id_sales_pos = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_sales("24")
                    'marknya 
                    insert_who_prepared("77", id_sales_pos, id_user)

                    query = "INSERT INTO tb_sales_pos_det(id_sales_pos,id_product,id_design_price,design_price,id_design_price_retail,design_price_retail,sales_pos_det_qty) VALUES "
                    'query += " SELECT '" + id_sales_pos + "' AS id_sales_pos,so_wh_d.id_product,so_wh_d.id_design_price,so_wh_d.design_price,so_wh_d.id_design_price,so_wh_d.design_price,so_wh_d.fg_so_wh_det_qty FROM tb_fg_so_wh_det so_wh_d"
                    'query += " INNER JOIN tb_fg_so_wh so_wh ON so_wh.id_fg_so_wh=so_wh_d.id_fg_so_wh"
                    'query += " WHERE so_wh.id_fg_so_wh='" + FormViewFGStockOpnameWH.id_fg_so_wh + "' AND so_wh_d.fg_so_wh_det_qty>0"

                    For i As Integer = 0 To FormViewFGStockOpnameWH.GVItemList.RowCount - 1
                        Dim id_product As String = FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim id_design_price As String = FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        Dim design_price As String = decimalSQL(FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "design_price").ToString)
                        Dim qty As String = decimalSQL((FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "fg_so_wh_sum_dif") * -1).ToString)
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" + id_sales_pos + "','" + id_product + "','" + id_design_price + "','" + design_price + "','" + id_design_price + "','" + design_price + "','" + qty + "')"
                        tot += FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "design_price") * (FormViewFGStockOpnameWH.GVItemList.GetRowCellValue(i, "fg_so_wh_sum_dif") * -1)
                    Next
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE tb_sales_pos SET sales_pos_vat=10,sales_pos_total='" + decimalSQL(tot.ToString) + "' WHERE id_sales_pos='" + id_sales_pos + "'"
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE tb_fg_so_wh SET id_sales_pos_ref='" + id_sales_pos + "' WHERE id_fg_so_wh='" + FormViewFGStockOpnameWH.id_fg_so_wh + "'"
                    execute_non_query(query, True, "", "", "", "")

                    infoCustom("Invoice created. Number : " + number)
                Else
                    infoCustom("No missing for this SO.")
                End If
                FormViewFGStockOpnameWH.GVItemList.ActiveFilterString = ""
            Else
                stopCustom("Invoice already created for this stock opname.")
            End If

            MQPBMissing.Visible = False
            FormFGMissing.viewFGMissingWH()
            FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", FormViewFGStockOpnameWH.id_fg_so_wh)
            FormViewFGStockOpnameWH.actionLoad()
        ElseIf id_popup = "2" Then
            Dim number As String = header_number_sales("11")
            Dim query_cek As String = "SELECT id_sales_pos_ref FROM tb_fg_so_store WHERE id_fg_so_store='" + FormViewFGStockOpname.id_fg_so_store + "'"
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows(0)("id_sales_pos_ref").ToString = "" Or data_cek.Rows(0)("id_sales_pos_ref").ToString = "0" Then
                Dim query As String = ""
                Dim id_sales_pos As String = ""

                FormViewFGStockOpname.GVItemList.ClearColumnsFilter()
                FormViewFGStockOpname.GVItemList.ActiveFilterString = "[fg_so_store_sum_dif] < 0"
                If FormViewFGStockOpname.GVItemList.RowCount > 0 Then
                    Dim tot As Decimal = 0
                    Dim after_vat As Decimal = 0

                    query = "INSERT INTO tb_sales_pos(id_store_contact_from,sales_pos_date,sales_pos_due_date,sales_pos_number,sales_pos_note,sales_pos_start_period,sales_pos_end_period,id_memo_type)"
                    query += " VALUES('" + FormViewFGStockOpname.id_store_contact_from + "',NOW(),'" + DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "','" + number + "','" + MENote.Text + "',NOW(),NOW(),'3');SELECT LAST_INSERT_ID() "
                    id_sales_pos = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_sales("11")
                    'marknya
                    insert_who_prepared("55", id_sales_pos, id_user)

                    query = "INSERT INTO tb_sales_pos_det(id_sales_pos,id_product,id_design_price,design_price,id_design_price_retail,design_price_retail,sales_pos_det_qty) VALUES "
                    'query += " SELECT '" + id_sales_pos + "' AS id_sales_pos,so_wh_d.id_product,so_wh_d.id_design_price,so_wh_d.design_price,so_wh_d.id_design_price,so_wh_d.design_price,so_wh_d.fg_so_wh_det_qty FROM tb_fg_so_wh_det so_wh_d"
                    'query += " INNER JOIN tb_fg_so_wh so_wh ON so_wh.id_fg_so_wh=so_wh_d.id_fg_so_wh"
                    'query += " WHERE so_wh.id_fg_so_wh='" + FormViewFGStockOpnameWH.id_fg_so_wh + "' AND so_wh_d.fg_so_wh_det_qty>0"

                    For i As Integer = 0 To FormViewFGStockOpname.GVItemList.RowCount - 1
                        Dim id_product As String = FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim id_design_price As String = FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        Dim design_price As String = decimalSQL(FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "design_price").ToString)
                        Dim qty As String = decimalSQL((FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "fg_so_store_sum_dif") * -1).ToString)
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" + id_sales_pos + "','" + id_product + "','" + id_design_price + "','" + design_price + "','" + id_design_price + "','" + design_price + "','" + qty + "')"
                        tot += FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "design_price") * (FormViewFGStockOpname.GVItemList.GetRowCellValue(i, "fg_so_store_sum_dif") * -1)
                    Next
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE tb_sales_pos SET sales_pos_vat=10,sales_pos_discount='" + decimalSQL(FormViewFGStockOpname.disc.ToString) + "',sales_pos_total='" + decimalSQL(tot.ToString) + "' WHERE id_sales_pos='" + id_sales_pos + "'"
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE tb_fg_so_store SET id_sales_pos_ref='" + id_sales_pos + "' WHERE id_fg_so_store='" + FormViewFGStockOpname.id_fg_so_store + "'"
                    execute_non_query(query, True, "", "", "", "")

                    infoCustom("Invoice created. Number : " + number)
                Else
                    infoCustom("No missing for this SO.")
                End If
                FormViewFGStockOpname.GVItemList.ActiveFilterString = ""
            Else
                stopCustom("Invoice already created for this stock opname.")
            End If

            MQPBMissing.Visible = False
            FormFGMissing.viewFGMissing()
            FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", FormViewFGStockOpname.id_fg_so_store)
            FormViewFGStockOpname.actionLoad()
        End If
        
        Close()
    End Sub

    Private Sub FormPopUpInvoiceMissing_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class