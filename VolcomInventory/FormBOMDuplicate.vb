Public Class FormBOMDuplicate
    Dim id_bom As String = "-1"
    Private Sub FormBOMDuplicate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_product()
        TEProduct.Text = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " (" & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString & ")"
        TEMethod.Text = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_name").ToString
        id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
    End Sub
    Sub view_product()
        Try
            Dim query As String
            query = "CALL view_product()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub BDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDuplicate.Click
        Dim confirm As DialogResult
        Dim query, id_bom_baru, id_product As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to duplicate this BOM?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                id_product = GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                '
                query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,bom_unit_price,bom_date_created,id_currency,kurs)"
                query += String.Format(" SELECT '{0}',tb_bom.id_term_production,tb_bom.bom_name,tb_bom.bom_unit_price,DATE(NOW()),id_currency,kurs FROM tb_bom WHERE tb_bom.id_bom={1};SELECT LAST_INSERT_ID(); ", id_product, id_bom)
                id_bom_baru = execute_query(query, 0, True, "", "", "", "")
                '
                insert_who_prepared("8", id_bom_baru, id_user)
                '
                query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,id_ovh_price,id_product_price,kurs,bom_price,component_qty) "
                query += String.Format(" SELECT '{0}',tb_bom_det.id_component_category,tb_bom_det.id_mat_det_price,tb_bom_det.id_ovh_price,tb_bom_det.id_product_price,tb_bom_det.kurs,tb_bom_det.bom_price,tb_bom_det.component_qty FROM tb_bom_det WHERE tb_bom_det.id_bom={1}", id_bom_baru, id_bom)
                execute_non_query(query, True, "", "", "", "")
                FormBOM.GVProduct.FocusedRowHandle = find_row(FormBOM.GVProduct, "id_product", id_product)
                FormBOM.view_bom(id_product)
                Close()
            Catch ex As Exception
                errorProcess()
            End Try
        End If
    End Sub
End Class