Public Class FormProdDemandBreakSingle 
    Public id_prod_demand_product As String
    Dim id_prod_demand_design As String = FormProdDemandDesignSingle.id_prod_demand_design
    Dim id_bom As String
    Dim prod_demand_product_qty As String
    Dim id_product As String
    Dim product_full_code As String
    Dim product_name As String
    Dim size_x As String
    Dim id_design As String = FormProdDemandDesignSingle.SLEDesign.EditValue
    Public action As String

    'Form Load
    Private Sub FormProdDemandBreakSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub
    'Action Load
    Sub actionLoad()
        If action = "ins" Then
            id_product = "0"
            viewProductSize()
            parseData()
            viewBom()
            viewAllocation()
        ElseIf action = "upd" Then
            'read db
            Dim query As String = "SELECT * FROM tb_prod_demand_product a LEFT JOIN tb_bom b ON a.id_bom = b.id_bom WHERE a.id_prod_demand_product = '" + id_prod_demand_product + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_product = data.Rows(0)("id_product").ToString

            'view product size
            viewProductSize()

            ' obtaining the focused view 
            Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GCProduct.FocusedView
            ' obtaining the column bound to the id_product field 
            Dim column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("id_product")
            If Not column Is Nothing Then
                ' locating the row 
                Dim rhFound As Integer = View.LocateByDisplayText(View.FocusedRowHandle + 1, column, id_product)
                ' focusing the cell 
                If (rhFound <> DevExpress.XtraGrid.GridControl.InvalidRowHandle) Then
                    View.FocusedRowHandle = rhFound
                    View.FocusedColumn = column
                End If
            End If
            parseData()
            viewBom()
            viewAllocation()
            If IsDBNull(data.Rows(0)("id_bom")) Then
                SLEBOM.EditValue = Nothing
                TxtEstimateCost.EditValue = 0.0
            Else
                SLEBOM.EditValue = data.Rows(0)("id_bom")
                TxtEstimateCost.EditValue = data.Rows(0)("bom_unit_price")
            End If
            TxtQuantity.Text = data.Rows(0)("prod_demand_product_qty")
        End If
    End Sub
    'Parse Var
    Sub parseData()
        id_product = GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
        product_name = GVProduct.GetFocusedRowCellDisplayText("product_name").ToString
        product_full_code = GVProduct.GetFocusedRowCellDisplayText("product_full_code").ToString
        size_x = GVProduct.GetFocusedRowCellDisplayText("Size").ToString
        TxtProductCode.Text = product_full_code
        TxtProductName.Text = product_name
        TxtProductSize.Text = size_x
    End Sub
    'View Product Size
    Sub viewProductSize()
        Try
            Dim query As String = "CALL view_product_demand_unselected('" + id_design + "', '" + id_product + "', '" + id_prod_demand_design + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            If data.Rows.Count < 1 Then
                BtnSave.Visible = False
                BtnCancel.Visible = False
                LabelAttention.Text = "Sample size not available or all size already selected for this product"
                LabelAttention.Visible = True
            Else
                BtnSave.Visible = True
                BtnCancel.Visible = True
                LabelAttention.Visible = False
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'view BOM
    Sub viewBom()
        Try
            Dim query As String = "SELECT a.id_bom, a.bom_name, COALESCE(a.bom_unit_price, 0) AS bom_unit_price, b.term_production, a.bom_date_created FROM tb_bom a "
            query += "INNER JOIN tb_lookup_term_production b ON a.id_term_production = b.id_term_production "
            query += "WHERE a.id_product = '" + id_product + "' AND a.is_default='1' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEBOM.Properties.DataSource = Nothing
            SLEBOM.Properties.DataSource = data
            SLEBOM.Properties.DisplayMember = "bom_name"
            SLEBOM.Properties.ValueMember = "id_bom"
            If data.Rows.Count.ToString >= 1 Then
                SLEBOM.EditValue = data.Rows(0)("id_bom").ToString
                TxtEstimateCost.EditValue = data.Rows(0)("bom_unit_price").ToString
            Else
                SLEBOM.EditValue = Nothing
                TxtEstimateCost.EditValue = 0.0
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Form Close
    Private Sub FormProdDemandBreakSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Row Cell Click
    Private Sub GVProduct_RowCellClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVProduct.RowCellClick
        
    End Sub
    'Camcel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Btn Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'UPDATED 24 October 2014 -hapus comment
        makeSafeGV(GVSize)
        GCSize.RefreshDataSource()
        GVSize.RefreshData()
        Dim query As String
        prod_demand_product_qty = decimalSQL(GVSize.Columns("prod_demand_alloc_qty").SummaryItem.SummaryValue.ToString)
        Try
            id_bom = SLEBOM.EditValue.ToString
        Catch ex As Exception
            id_bom = "0"
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    'If id_bom = "0" Then
                    '    errorCustom("Nothing BOM selected")
                    'Else
                    query = "INSERT INTO tb_prod_demand_product(id_prod_demand_design, id_product, id_bom, prod_demand_product_qty) "
                    If id_bom = "0" Then
                        query += "VALUES('{0}', '{1}', NULL, '{2}'); SELECT LAST_INSERT_ID(); "
                        query = String.Format(query, id_prod_demand_design, id_product, prod_demand_product_qty)
                    Else
                        query += "VALUES('{0}', '{1}', '{2}', '{3}'); SELECT LAST_INSERT_ID(); "
                        query = String.Format(query, id_prod_demand_design, id_product, id_bom, prod_demand_product_qty)
                    End If
                    id_prod_demand_product = execute_query(query, 0, True, "", "", "", "")
                    logData("tb_prod_demand_product", 1)

                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVSize.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_prod_demand_alloc(id_prod_demand_product, id_pd_alloc, prod_demand_alloc_qty) VALUES "
                    End If
                    For j As Integer = 0 To ((GVSize.RowCount - 1) - GetGroupRowCount(GVSize))
                        Dim id_pd_alloc As String = GVSize.GetRowCellValue(j, "id_pd_alloc").ToString
                        Dim prod_demand_alloc_qty As String = decimalSQL(GVSize.GetRowCellValue(j, "prod_demand_alloc_qty").ToString)
                        If jum_ins_j > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_prod_demand_product + "', '" + id_pd_alloc + "', '" + prod_demand_alloc_qty + "') "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    FormProdDemandDesignSingle.viewBreakdown()
                    FormProdDemandDesignSingle.getEstimate()
                    FormProdDemandDesignSingle.viewAllocation()
                    FormProdDemandDesignSingle.getMarkUp()
                    FormProdDemandDesignSingle.refreshMain()
                    Close()
                    'End If
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf action = "upd" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    'If id_bom = "0" Then
                    '    errorCustom("Nothing BOM selected")
                    'Else
                    If id_bom = "0" Then
                        query = "UPDATE tb_prod_demand_product SET id_prod_demand_design = '{0}', id_product = '{1}', id_bom = NULL, prod_demand_product_qty = '{2}' WHERE id_prod_demand_product ='{3}' "
                        query = String.Format(query, id_prod_demand_design, id_product, prod_demand_product_qty, id_prod_demand_product)
                    Else
                        query = "UPDATE tb_prod_demand_product SET id_prod_demand_design = '{0}', id_product = '{1}', id_bom = '{2}', prod_demand_product_qty = '{3}' WHERE id_prod_demand_product ='{4}' "
                        query = String.Format(query, id_prod_demand_design, id_product, id_bom, prod_demand_product_qty, id_prod_demand_product)
                    End If
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_prod_demand_product", 2)

                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVSize.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_prod_demand_alloc(id_prod_demand_product, id_pd_alloc, prod_demand_alloc_qty) VALUES "
                    End If
                    For j As Integer = 0 To ((GVSize.RowCount - 1) - GetGroupRowCount(GVSize))
                        Dim id_prod_demand_alloc As String = GVSize.GetRowCellValue(j, "id_prod_demand_alloc").ToString
                        Dim id_pd_alloc As String = GVSize.GetRowCellValue(j, "id_pd_alloc").ToString
                        Dim prod_demand_alloc_qty As String = decimalSQL(GVSize.GetRowCellValue(j, "prod_demand_alloc_qty").ToString)
                        If id_prod_demand_alloc = "0" Then
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_prod_demand_product + "', '" + id_pd_alloc + "', '" + prod_demand_alloc_qty + "') "
                            jum_ins_j = jum_ins_j + 1
                        Else
                            Dim query_detail2 As String = "UPDATE tb_prod_demand_alloc SET id_pd_alloc= '" + id_pd_alloc + "', prod_demand_alloc_qty='" + prod_demand_alloc_qty + "' WHERE id_prod_demand_alloc='" + id_prod_demand_alloc + "' "
                            execute_non_query(query_detail2, True, "", "", "", "")
                        End If
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    FormProdDemandDesignSingle.viewBreakdown()
                    FormProdDemandDesignSingle.getEstimate()
                    FormProdDemandDesignSingle.viewAllocation()
                    FormProdDemandDesignSingle.getMarkUp()
                    FormProdDemandDesignSingle.refreshMain()
                    Close()
                    'End If
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    'Value Changed
    Private Sub SLEBOM_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEBOM.EditValueChanged
        Try
            TxtEstimateCost.EditValue = SearchLookUpEdit1View.GetFocusedRowCellValue("bom_unit_price")
        Catch ex As Exception
            TxtEstimateCost.EditValue = 0.0
        End Try
    End Sub

    Private Sub GroupControlForm_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControlForm.Paint

    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        GCSize.RefreshDataSource()
        GVSize.RefreshData()
    End Sub

    'updated 16 Januari 2015
    Sub viewAllocation()
        Dim query As String = ""
        query += "SELECT pd_allc.id_pd_alloc, pd_allc.pd_alloc, IFNULL(allc.id_prod_demand_alloc, 0) AS id_prod_demand_alloc, allc.id_prod_demand_product,  "
        query += "IFNULL(allc.prod_demand_alloc_qty, 0) AS prod_demand_alloc_qty "
        query += "FROM tb_lookup_pd_alloc pd_allc "
        query += "LEFT JOIN tb_prod_demand_alloc allc ON  pd_allc.id_pd_alloc = allc.id_pd_alloc AND allc.id_prod_demand_product = '" + id_prod_demand_product + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSize.DataSource = data
    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemSpinEdit1.EditValueChanging
        GCSize.RefreshDataSource()
        GVSize.RefreshData()
    End Sub

    Private Sub RepositoryItemSpinEdit1_Spin(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.SpinEventArgs) Handles RepositoryItemSpinEdit1.Spin
      
    End Sub

    Private Sub RepositoryItemSpinEdit1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.ValueChanged
       
    End Sub

    Private Sub GVSize_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVSize.CellValueChanging
       
    End Sub

    Private Sub RepositoryItemSpinEdit1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RepositoryItemSpinEdit1.Validating
        GCSize.RefreshDataSource()
        GVSize.RefreshData()
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        'action
        'BtnSave.Visible = False
        'BtnCancel.Visible = False
        parseData()
        SLEBOM.EditValue = Nothing
        viewBom()

        'check list
        'Dim query As String = "SELECT COUNT(*) FROM tb_m_product "
        'query += "WHERE id_design = '" + id_design + "' "
        'query += "AND id_product !='" + id_product + "' "
        'If action = "upd" Then
        '    query += "AND id_prod_demand_product != '" + id_prod_demand_product + "' "
        'End If
        'Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        'If jml > 0 Then
        '    LabelAttention.Visible = True
        'Else
        '    LabelAttention.Visible = False
        '    BtnSave.Visible = True
        '    BtnCancel.Visible = True
        'End If
    End Sub

    Private Sub GVProduct_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.ColumnFilterChanged
        'action
        'BtnSave.Visible = False
        'BtnCancel.Visible = False
        parseData()
        SLEBOM.EditValue = Nothing
        viewBom()

        'check list
        'Dim query As String = "SELECT COUNT(*) FROM tb_m_product "
        'query += "WHERE id_design = '" + id_design + "' "
        'query += "AND id_product !='" + id_product + "' "
        'If action = "upd" Then
        '    query += "AND id_prod_demand_product != '" + id_prod_demand_product + "' "
        'End If
        'Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        'If jml > 0 Then
        '    LabelAttention.Visible = True
        'Else
        '    LabelAttention.Visible = False
        '    BtnSave.Visible = True
        '    BtnCancel.Visible = True
        'End If
    End Sub
End Class