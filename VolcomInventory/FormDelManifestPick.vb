Public Class FormDelManifestPick
    Private Sub FormDelManifestPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp()
    End Sub

    Private Sub FormDelManifestPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_comp()
        Dim query As String = "(SELECT 0 AS id_comp, '' AS comp_name) UNION ALL (SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name FROM tb_m_comp WHERE id_comp_cat = 6)"

        viewSearchLookupQuery(SLUECompany, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Cursor = Cursors.WaitCursor

        Dim query_where As String = ""

        If SLUECompany.EditValue.ToString = "0" Then
            query_where += "AND a.id_store = " + SLUECompany.EditValue.ToString
        End If

        Dim query As String = "
            SELECT 'no' AS is_select, adet.id_wh_awb_det, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, adet.qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
            FROM tb_wh_awbill_det AS adet
            LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
            LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
            LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
            LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
            WHERE 1 " + query_where + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim data As DataTable = FormDelManifestDet.GCList.DataSource

        GVList.ActiveFilterString = "[is_select] = 'yes'"

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                data.Rows.Add(
                    0,
                    GVList.GetRowCellValue(i, "id_wh_awb_det"),
                    GVList.GetRowCellValue(i, "do_no"),
                    GVList.GetRowCellValue(i, "pl_sales_order_del_number"),
                    GVList.GetRowCellValue(i, "comp_number"),
                    GVList.GetRowCellValue(i, "comp_name"),
                    GVList.GetRowCellValue(i, "qty"),
                    GVList.GetRowCellValue(i, "city"),
                    GVList.GetRowCellValue(i, "weight"),
                    GVList.GetRowCellValue(i, "width"),
                    GVList.GetRowCellValue(i, "length"),
                    GVList.GetRowCellValue(i, "height"),
                    GVList.GetRowCellValue(i, "volume"),
                    GVList.GetRowCellValue(i, "c_weight")
                )
            End If
        Next

        FormDelManifestDet.GVList.BestFitColumns()

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class