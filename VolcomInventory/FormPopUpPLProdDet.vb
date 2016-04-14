Public Class FormPopUpPLProdDet 
    Public id_pl_prod_order As String
    Public id_pl_prod_order_det As String = "0"
    Public id_pl_prod_order_det_edit As String
    Public id_pop_up As String
    Public id_pl As String
    Public id_ret_out As String = "0"
    Public id_ret_in As String = "0"
    Public id_pl_prod_order_rec As String = "0"
    Public is_info_form As Boolean = False
    Public action As String
    Private Sub FormPopUpPLProdDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        XTCPLMenu.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        Dim query As String = "SELECT * FROM tb_pl_prod_order WHERE id_pl_prod_order = '" + id_pl_prod_order + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Production Order No. :" + data.Rows(0)("pl_prod_order_number").ToString
        view_list_purchase(id_pl_prod_order)
        view_list_compare(id_pl)
    End Sub
    Sub view_list_purchase(ByVal id_pl_prod_order As String)
        Dim query As String = ""
        If id_pop_up = "1" Then
            query = "CALL view_pl_prod('" + id_pl_prod_order + "', '0', '0')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If id_pop_up = "1" Then
            Dim i As Integer = data.Rows.Count - 1
            If id_pl_prod_order_det <> "0" Then
                While (i >= 0)
                    If data.Rows(i)("id_pl_prod_order_det").ToString <> id_pl_prod_order_det Then
                        data.Rows.RemoveAt(i)
                    End If
                    i = i - 1
                End While
            End If
        End If
        GCListProduct.DataSource = data
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub

    Sub view_list_purchase_det(ByVal id_pl_prod_order_det As String)
        Dim queryx As String = "SELECT ('') AS no, a.id_product, c.product_full_code,CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code, "
        queryx += "b.id_pl_prod_order_det, (a.pl_prod_order_det_counting) AS counting_code, a.id_pl_prod_order_det_unique, ('2') AS is_fix, b.id_pl_prod_order_det "
        queryx += "FROM tb_pl_prod_order_det_counting a "
        queryx += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
        queryx += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
        queryx += "WHERE a.id_pl_prod_order_det = '" + id_pl_prod_order_det + "' "
        Dim data As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        Dim i As Integer = data.Rows.Count - 1
        GCPLUnique.DataSource = data
    End Sub

    Sub view_list_compare(ByVal id_pl_prod_order_recy As String)
        Dim query = "CALL view_pl_prod_rec('" + id_pl_prod_order_recy + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim i As Integer = data.Rows.Count - 1
        If id_pl_prod_order_det <> "0" Then
            While (i >= 0)
                If data.Rows(i)("id_pl_prod_order_det").ToString <> id_pl_prod_order_det Then
                    data.Rows.RemoveAt(i)
                End If
                i = i - 1
            End While
        End If
        GCPLCompare.DataSource = data
        If data.Rows.Count > 0 Then
            Dim id_pl_prod_orderx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order").ToString
            Dim id_pl_prod_order_recx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            Dim id_pl_prod_order_detx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
            view_list_compare_det(id_pl_prod_orderx, id_pl_prod_order_recx, id_pl_prod_order_detx)
        End If
    End Sub

    Sub view_list_compare_det(ByVal id_pl_prod_order As String, ByVal id_pl_prod_order_rec As String, ByVal id_pl_prod_order_detx As String)
        Dim query As String = "SELECT code_pl, IF(ISNULL(code_pl_rec), '-', code_pl_rec) AS code_pl_rec, IF(ISNULL(code_pl_rec), 'Not Match', 'Match') AS status_compare, a.id_pl_prod_order_det FROM "
        query += "(SELECT CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code_pl, a.id_pl_prod_order_det "
        query += "FROM tb_pl_prod_order_det_counting a  "
        query += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det  "
        query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product  "
        query += "WHERE b.id_pl_prod_order = '" + id_pl_prod_order + "' ) a  "
        query += "LEFT JOIN  "
        query += "(SELECT CONCAT(c.product_full_code, a.pl_prod_order_rec_det_counting) AS code_pl_rec, b.id_pl_prod_order_det "
        query += "FROM tb_pl_prod_order_rec_det_counting a  "
        query += "INNER JOIN tb_pl_prod_order_rec_det b ON a.id_pl_prod_order_rec_det = b.id_pl_prod_order_rec_det  "
        query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product  "
        query += "WHERE b.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' AND a.id_counting_type='1' ) b ON a.code_pl = b.code_pl_rec "
        query += "WHERE a.id_pl_prod_order_det LIKE '%" + id_pl_prod_order_detx + "%' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPLDetailCompare.DataSource = data
    End Sub


    Private Sub GVPLCompare_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPLCompare.FocusedRowChanged
        Try
            Dim id_pl_prod_orderx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order").ToString
            Dim id_pl_prod_order_recx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            Dim id_pl_prod_order_detx As String = GVPLCompare.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
            view_list_compare_det(id_pl_prod_orderx, id_pl_prod_order_recx, id_pl_prod_order_detx)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            If action = "ins" Then
                FormProductionPLToWHRecDet.newRows()
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_rec_det", "0")
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("pl_prod_order_rec_det_qty", "0")
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("range_qty", GVListProduct.GetFocusedRowCellValue("range_qty").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.CloseEditor()
                FormProductionPLToWHRecDet.id_pl_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString)
                FormProductionPLToWHRecDet.check_but()
                id_pl_prod_order_det = GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString
                Close()
            ElseIf action = "upd" Then
                Dim id_pl_prod_order_det_old As String = FormProductionPLToWHRecDet.GVRetDetail.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString
                FormProductionPLToWHRecDet.deleteDetailBc(id_pl_prod_order_det_old)
                FormProductionPLToWHRecDet.id_pl_prod_order_det_list.Remove(id_pl_prod_order_det_old)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_rec_det", "0")
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("id_pl_prod_order_det", GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("name", GVListProduct.GetFocusedRowCellDisplayText("name").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("size", GVListProduct.GetFocusedRowCellValue("size").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListProduct.GetFocusedRowCellValue("uom").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("pl_prod_order_rec_det_qty", "0")
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("code", GVListProduct.GetFocusedRowCellValue("code").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("ean_code", GVListProduct.GetFocusedRowCellValue("ean_code").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.SetFocusedRowCellValue("range_qty", GVListProduct.GetFocusedRowCellValue("range_qty").ToString)
                FormProductionPLToWHRecDet.GVRetDetail.CloseEditor()
                FormProductionPLToWHRecDet.id_pl_prod_order_det_list.Add(GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString)
                FormProductionPLToWHRecDet.check_but()
                id_pl_prod_order_det = GVListProduct.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString
                Close()
            End If
            FormProductionPLToWHRecDet.GCRetDetail.RefreshDataSource()
            FormProductionPLToWHRecDet.GVRetDetail.RefreshData()
        End If
    End Sub

    Private Sub FormPopUpPLProdDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        'If id_pop_up = "1" Then
        '    If action = "ins" Then
        '        'go to process
        '        FormProcessing.id_process = "1"
        '        FormProcessing.idx = id_pl_prod_order_det
        '        FormProcessing.ShowDialog()
        '    ElseIf action = "upd" Then
        '        'go to process
        '        FormProcessing.id_process = "2"
        '        FormProcessing.idx = id_pl_prod_order_det_edit
        '        FormProcessing.ShowDialog()

        '        ''go to process
        '        FormProcessing.id_process = "1"
        '        FormProcessing.idx = id_pl_prod_order_det
        '        FormProcessing.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVListProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVListProduct.FocusedRowChanged
        Try
            Dim id_pl_prod_order_det As String = GVListProduct.GetFocusedRowCellValue("id_pl_prod_order_det")
            view_list_purchase_det(id_pl_prod_order_det)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVPLCompare_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPLCompare.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVPLDetailCompare_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVPLDetailCompare.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        'If e.Column.FieldName = "prod_order_lead_time" Then
        Dim status_compare As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("status_compare"))
        If status_compare = "Not Match" Then
            e.Appearance.BackColor = Color.LightSalmon
            e.Appearance.BackColor2 = Color.LightSalmon
        End If
        'End If
    End Sub
End Class