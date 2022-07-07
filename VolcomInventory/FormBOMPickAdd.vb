Public Class FormBOMPickAdd
    Private Sub FormBOMPickAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAddMat_Click(sender As Object, e As EventArgs) Handles BAddMat.Click
        'insert
        For i = 0 To FormBOMDesignSingle.GVBomDetMat.RowCount - 1
            FormBOMDesignSingle.GVBomDetMat.DeleteRow(i)
        Next

        For i = 0 To GVBomDetMat.RowCount - 1
            FormBOMDesignSingle.GVBomDetMat.AddNewRow()
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component", GVBomDetMat.GetRowCellValue(i, "id_component").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component_price", GVBomDetMat.GetRowCellValue(i, "id_component_price").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("code", GVBomDetMat.GetRowCellValue(i, "code").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("name", GVBomDetMat.GetRowCellValue(i, "name").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("size", GVBomDetMat.GetRowCellValue(i, "size").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("color", GVBomDetMat.GetRowCellValue(i, "color").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("qty", GVBomDetMat.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("kurs", GVBomDetMat.GetRowCellValue(i, "kurs"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("uom", GVBomDetMat.GetRowCellValue(i, "uom").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("price", GVBomDetMat.GetRowCellValue(i, "price"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_cost", If(GVBomDetMat.GetRowCellValue(i, "is_cost2").ToString = "yes", "1", "2"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_addcost", If(GVBomDetMat.GetRowCellValue(i, "is_addcost2").ToString = "yes", "1", "2"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("total", GVBomDetMat.GetRowCellValue(i, "total"))
            FormBOMDesignSingle.GVBomDetMat.CloseEditor()
            FormBOMDesignSingle.GCBomDetMat.RefreshDataSource()
            FormBOMDesignSingle.GVBomDetMat.RefreshData()
        Next

        FormBOMDesignSingle.show_but_mat()
        FormBOMDesignSingle.calculate_unit_price()
        Close()
    End Sub

    Private Sub FormBOMPickAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        show_design()
    End Sub

    Sub show_design()
        Try
            Dim query As String = "CALL view_bom_design()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            If data.Rows.Count > 0 Then
                GVDesign.ExpandAllGroups()
                GVDesign.FocusedRowHandle = 0
                GVDesign.ActiveFilterString = "[prod_demand_number] <> '-'"
                view_bom_det()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub view_bom_det()
        Try
            Dim query As String
            query = "CALL view_bom_design_list(" & GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString & ",2)"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            GVBomDetMat.BestFitColumns()

            Dim query2 As String
            query2 = "CALL view_bom_design_list(" & GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString & ",3)"

            Dim data2 As DataTable = execute_query(query2, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data2
            GVBomDetOvh.BestFitColumns()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles GVDesign.FocusedRowObjectChanged
        view_bom_det()
    End Sub

    Private Sub BEditMat_Click(sender As Object, e As EventArgs) Handles BEditMat.Click
        Close()
    End Sub

    Private Sub BAddOVH_Click(sender As Object, e As EventArgs) Handles BAddOVH.Click
        'insert
        For i = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
            FormBOMDesignSingle.GVBomDetOvh.DeleteRow(i)
        Next

        For i = 0 To GVBomDetOvh.RowCount - 1
            FormBOMDesignSingle.GVBomDetOvh.AddNewRow()
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component", GVBomDetOvh.GetRowCellValue(i, "id_component").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component_price", GVBomDetOvh.GetRowCellValue(i, "id_component_price").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("code", GVBomDetOvh.GetRowCellValue(i, "code").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("name", GVBomDetOvh.GetRowCellValue(i, "name").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("size", "-")
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("color", "-")
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("qty", GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("kurs", GVBomDetOvh.GetRowCellValue(i, "kurs"))
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("currency", GVBomDetOvh.GetRowCellValue(i, "currency").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("uom", GVBomDetOvh.GetRowCellValue(i, "uom").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("vendor", GVBomDetOvh.GetRowCellValue(i, "vendor").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("ovh_cat", GVBomDetOvh.GetRowCellValue(i, "ovh_cat").ToString)
            If GVBomDetOvh.GetRowCellValue(i, "id_currency").ToString = "1" Then
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            Else
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "kurs"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue * GVBomDetOvh.GetRowCellValue(i, "kurs"))
            End If
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("is_ovh_main", If(GVBomDetOvh.GetRowCellValue(i, "is_ovh_main2").ToString = "yes", "1", "2"))

            FormBOMDesignSingle.GVBomDetOvh.CloseEditor()
            FormBOMDesignSingle.GCBomDetOvh.RefreshDataSource()
            FormBOMDesignSingle.GVBomDetOvh.RefreshData()
        Next

        FormBOMDesignSingle.show_but_ovh()
        FormBOMDesignSingle.calculate_unit_price()
        Close()
    End Sub

    Private Sub BAddBoth_Click(sender As Object, e As EventArgs) Handles BAddBoth.Click
        'insert mat
        For i = 0 To FormBOMDesignSingle.GVBomDetMat.RowCount - 1
            FormBOMDesignSingle.GVBomDetMat.DeleteRow(i)
        Next

        For i = 0 To GVBomDetMat.RowCount - 1
            FormBOMDesignSingle.GVBomDetMat.AddNewRow()
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component", GVBomDetMat.GetRowCellValue(i, "id_component").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("id_component_price", GVBomDetMat.GetRowCellValue(i, "id_component_price").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("code", GVBomDetMat.GetRowCellValue(i, "code").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("name", GVBomDetMat.GetRowCellValue(i, "name").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("size", GVBomDetMat.GetRowCellValue(i, "size").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("color", GVBomDetMat.GetRowCellValue(i, "color").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("qty", GVBomDetMat.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("kurs", GVBomDetMat.GetRowCellValue(i, "kurs"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("uom", GVBomDetMat.GetRowCellValue(i, "uom").ToString)
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("price", GVBomDetMat.GetRowCellValue(i, "price"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_cost", If(GVBomDetMat.GetRowCellValue(i, "is_cost2").ToString = "yes", "1", "2"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("is_addcost", If(GVBomDetMat.GetRowCellValue(i, "is_addcost2").ToString = "yes", "1", "2"))
            FormBOMDesignSingle.GVBomDetMat.SetFocusedRowCellValue("total", GVBomDetMat.GetRowCellValue(i, "total"))
            FormBOMDesignSingle.GVBomDetMat.CloseEditor()
            FormBOMDesignSingle.GCBomDetMat.RefreshDataSource()
            FormBOMDesignSingle.GVBomDetMat.RefreshData()
        Next

        FormBOMDesignSingle.show_but_mat()

        'insert OVH
        For i = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
            FormBOMDesignSingle.GVBomDetOvh.DeleteRow(i)
        Next

        For i = 0 To GVBomDetOvh.RowCount - 1
            FormBOMDesignSingle.GVBomDetOvh.AddNewRow()
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component", GVBomDetOvh.GetRowCellValue(i, "id_component").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component_price", GVBomDetOvh.GetRowCellValue(i, "id_component_price").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("code", GVBomDetOvh.GetRowCellValue(i, "code").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("name", GVBomDetOvh.GetRowCellValue(i, "name").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("size", "-")
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("color", "-")
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("qty", GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("kurs", GVBomDetOvh.GetRowCellValue(i, "kurs"))
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("currency", GVBomDetOvh.GetRowCellValue(i, "currency").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("uom", GVBomDetOvh.GetRowCellValue(i, "uom").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("vendor", GVBomDetOvh.GetRowCellValue(i, "vendor").ToString)
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("ovh_cat", GVBomDetOvh.GetRowCellValue(i, "ovh_cat").ToString)
            If GVBomDetOvh.GetRowCellValue(i, "id_currency").ToString = "1" Then
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue)
            Else
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", GVBomDetOvh.GetRowCellValue(i, "price"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "kurs"))
                FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", GVBomDetOvh.GetRowCellValue(i, "price") * GVBomDetOvh.GetRowCellValue(i, "component_qty") * FormBOMDesignSingle.TEQtyPD.EditValue * GVBomDetOvh.GetRowCellValue(i, "kurs"))
            End If
            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("is_ovh_main", If(GVBomDetOvh.GetRowCellValue(i, "is_ovh_main2").ToString = "yes", "1", "2"))

            FormBOMDesignSingle.GVBomDetOvh.CloseEditor()
            FormBOMDesignSingle.GCBomDetOvh.RefreshDataSource()
            FormBOMDesignSingle.GVBomDetOvh.RefreshData()
        Next

        FormBOMDesignSingle.show_but_ovh()
        FormBOMDesignSingle.calculate_unit_price()
        Close()
    End Sub
End Class