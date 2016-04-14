Public Class FormViewBOMFull
    Public id_prod_demand_design As String = "-1"
    Sub view_bom()
        Try
            Dim query As String
            query = "CALL view_bom_pd_design(" & id_prod_demand_design & ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBOM.DataSource = data
            GVBOM.ClearGrouping()
            GVBOM.Columns("id_component_category").GroupIndex = 0
            GVBOM.ExpandAllGroups()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub viewBreakdown()
        Dim query As String = "CALL view_product_demand_all('" + id_prod_demand_design + "', '0.00')"
        'Dim query As String = "SELECT * FROM tb_prod_demand_product a "
        'query += "INNER JOIN tb_m_product b ON a.id_product = b.id_product "
        'query += "LEFT JOIN tb_bom c ON a.id_bom = c.id_bom "
        'query += "WHERE a.id_prod_demand_design = '" + id_prod_demand_design + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
    End Sub
    Private Sub FormViewBOMFull_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewBreakdown()
        view_bom()

        Dim query As String = "SELECT id_design FROM tb_prod_demand_design WHERE id_prod_Demand_design='" & id_prod_demand_design & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelPrintedName.Text = get_design_name(data.Rows(0)("id_design").ToString)
    End Sub

    Private Sub GVBOM_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBOM.CustomColumnDisplayText
        If e.Column.FieldName = "id_component_category" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVBOM.IsGroupRow(rowhandle) Then
                rowhandle = GVBOM.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVBOM.GetRowCellDisplayText(rowhandle, "category")
            End If
        End If
    End Sub

    Private Sub GVProduct_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.DoubleClick
        If GVProduct.RowCount > 0 Then
            '
            If GVProduct.GetFocusedRowCellDisplayText("id_bom").ToString = "" Then
                stopCustom("No BOM registered.")
            Else
                FormViewBOM.id_bom = GVProduct.GetFocusedRowCellDisplayText("id_bom").ToString
                FormViewBOM.nama_product = GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " - " & GVProduct.GetFocusedRowCellDisplayText("Size").ToString
                FormViewBOM.id_product = GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                FormViewBOM.mark = False
                FormViewBOM.ShowDialog()
            End If
        End If
    End Sub
End Class