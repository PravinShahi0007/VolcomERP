Public Class FormAdjustmentOGPick
    Private Sub FormAdjustmentOGPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim in_item As String = ""

        If Not FormAdjustmentOGDet.SLUEType.EditValue.ToString = "1" Then
            For i = 0 To FormAdjustmentOGDet.GVList.RowCount - 1
                in_item += FormAdjustmentOGDet.GVList.GetRowCellValue(i, "id_item").ToString + ", "
            Next
        End If

        If in_item = "" Then
            in_item = "0"
        Else
            in_item = in_item.Substring(0, in_item.Length - 2)
        End If

        Dim date_until_selected As String = Date.Parse(Now).ToString("yyyy-MM-dd")

        Dim dept As String = FormAdjustmentOGDet.SLUEFromDepartment.EditValue.ToString
        Dim cat As String = "0"
        '
        If dept = "-1" Then
            dept = "AND i.id_item NOT IN (" + in_item + ")"
        Else
            dept = "AND i.id_item NOT IN (" + in_item + ") AND i.id_departement=" + dept + ""
        End If

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'add zero
        If FormAdjustmentOGDet.SLUEType.EditValue.ToString = "1" Then
            For i = 0 To data.Rows.Count - 1
                in_item += ", " + data.Rows(i)("id_item").ToString
            Next

            Dim data_z As DataTable = execute_query("
                SELECT uom_stock.uom, " + FormAdjustmentOGDet.SLUEFromDepartment.EditValue.ToString + " AS id_departement, '" + FormAdjustmentOGDet.SLUEFromDepartment.Text + "' AS departement, i.id_item, i.item_desc, i.id_item_cat, c.item_cat, 0 AS qty, 0 AS qty_req, t.avg_cost AS `value`, '' AS remark
                FROM tb_item AS i
                INNER JOIN tb_item_cat AS c ON c.id_item_cat = i.id_item_cat
                INNER JOIN tb_m_uom uom ON uom.id_uom = i.id_uom
                LEFT JOIN tb_m_uom uom_stock ON uom_stock.id_uom = i.id_uom_stock
                LEFT JOIN (
	                SELECT avg_cost.id_item, avg_cost.avg_cost 
                    FROM tb_item_avg_cost avg_cost
                    INNER JOIN (
	                    SELECT a.id_item,MAX(a.id_item_avg_cost) AS id_item_avg_cost
	                    FROM tb_item_avg_cost a
	                    GROUP BY a.id_item
                    ) a ON a.id_item_avg_cost=avg_cost.id_item_avg_cost
                ) t ON t.id_item = i.id_item
                WHERE i.id_item NOT IN (" + in_item + ")
            ", -1, True, "", "", "", "")

            For i = 0 To data_z.Rows.Count - 1
                Dim r As DataRow = data.NewRow

                r("uom") = data_z.Rows(i)("uom")
                r("id_departement") = data_z.Rows(i)("id_departement")
                r("departement") = data_z.Rows(i)("departement")
                r("id_item") = data_z.Rows(i)("id_item")
                r("item_desc") = data_z.Rows(i)("item_desc")
                r("id_item_cat") = data_z.Rows(i)("id_item_cat")
                r("item_cat") = data_z.Rows(i)("item_cat")
                r("qty") = data_z.Rows(i)("qty")
                r("qty_req") = data_z.Rows(i)("qty_req")
                r("value") = data_z.Rows(i)("value")
                r("remark") = data_z.Rows(i)("remark")

                data.Rows.Add(r)
            Next
        End If

        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        Dim data As DataTable = FormAdjustmentOGDet.GCList.DataSource

        Dim row As DataRow = data.NewRow

        row("id_item") = GVList.GetFocusedRowCellValue("id_item")
        row("item_desc") = GVList.GetFocusedRowCellValue("item_desc")
        row("uom") = GVList.GetFocusedRowCellValue("uom")
        row("id_item_cat") = GVList.GetFocusedRowCellValue("id_item_cat")
        row("item_cat") = GVList.GetFocusedRowCellValue("item_cat")
        row("qty") = 0
        row("value") = GVList.GetFocusedRowCellValue("value")

        data.Rows.Add(row)

        FormAdjustmentOGDet.GCList.DataSource = data

        Close()
    End Sub

    Private Sub FormAdjustmentOGPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class