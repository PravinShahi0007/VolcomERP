Public Class FormBOMSingleWip
    Public id_bom As String = "-1"
    Public id_bom_det As String = "-1"
    Private Sub FormBOMSingleWip_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBOMSingleWip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_product()
        LabelBOMName.Text = FormBOMSingle.LabelPrintedName.Text
    End Sub
    Sub view_product()
        Try
            Dim query As String
            query = "CALL view_product()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            '
            If id_bom_det <> "-1" Then
                '
                Dim id_product As String
                id_product = get_id_product(id_bom_det)
                GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product)
                '
            End If
            '
            If Not data.Rows.Count < 1 Then
                view_product_price(GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_product_price(ByVal id_productx As String)
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_product_price.id_product_price,tb_m_product_price.product_price_name,tb_m_product_price.product_price,tb_m_product_price.product_price_date FROM tb_m_product_price,tb_lookup_currency WHERE tb_m_product_price.id_currency=tb_lookup_currency.id_currency AND tb_m_product_price.id_product='" & id_productx & "' ORDER BY tb_m_product_price.id_product_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProductPrice.DataSource = data

        If id_bom_det <> "-1" Then
            '
            query = String.Format("SELECT * FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
            data = execute_query(query, -1, True, "", "", "", "")

            GVProductPrice.FocusedRowHandle = find_row(GVProductPrice, "id_product_price", data.Rows(0)("id_product_price").ToString)
            load_product_price()

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", get_id_currency(id_bom))
            TEKurs.Text = data.Rows(0)("kurs").ToString()
            TEPrice.Text = data.Rows(0)("bom_price").ToString()
            TEQty.Text = data.Rows(0)("component_qty").ToString()
            '
        Else
            If Not data.Rows.Count < 1 Then
                load_product_price()
            End If
        End If
    End Sub
    Sub load_product_price()
        TEVendCur.Text = GVProductPrice.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.Text = GVProductPrice.GetFocusedRowCellDisplayText("product_price").ToString
        TEUOM.Text = GVProduct.GetFocusedRowCellDisplayText("uom").ToString

        Try
            Dim price_kurs, price_tot As Decimal

            If TEVendPrice.Text = "" Or TEKurs.Text = "" Then
                TEPrice.Text = "0"
            Else
                price_kurs = Decimal.Parse(TEVendPrice.Text) * Decimal.Parse(TEKurs.Text)
                TEPrice.Text = price_kurs.ToString("0.00")
            End If
            If TEPrice.Text = "" Or TEQty.Text = "" Then
                TEPriceTot.Text = "0"
            Else
                price_tot = Decimal.Parse(TEPrice.Text) * Decimal.Parse(TEQty.Text)
                TEPriceTot.Text = price_tot.ToString("0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
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

    Private Sub GVProductPrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProductPrice.FocusedRowChanged
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

    Private Sub GVProductPrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProductPrice.RowClick
        load_product_price()
    End Sub

    Private Sub GVProduct_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProduct.RowClick
        view_product_price(GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
    End Sub
    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        Try
            Dim price_kurs, price_tot As Decimal

            If TEVendPrice.Text = "" Or TEKurs.Text = "" Then
                TEPrice.Text = "0"
            Else
                price_kurs = Decimal.Parse(TEVendPrice.Text) * Decimal.Parse(TEKurs.Text)
                TEPrice.Text = price_kurs.ToString("0.00")
            End If
            If TEPrice.Text = "" Or TEQty.Text = "" Then
                TEPriceTot.Text = "0"
            Else
                price_tot = Decimal.Parse(TEPrice.Text) * Decimal.Parse(TEQty.Text)
                TEPriceTot.Text = price_tot.ToString("0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQty.EditValueChanged
        Try
            Dim price_kurs, price_tot As Decimal

            If TEVendPrice.Text = "" Or TEKurs.Text = "" Then
                TEPrice.Text = "0"
            Else
                price_kurs = Decimal.Parse(TEVendPrice.Text) * Decimal.Parse(TEKurs.Text)
                TEPrice.Text = price_kurs.ToString("0.00")
            End If
            If TEPrice.Text = "" Or TEQty.Text = "" Then
                TEPriceTot.Text = "0"
            Else
                price_tot = Decimal.Parse(TEPrice.Text) * Decimal.Parse(TEQty.Text)
                TEPriceTot.Text = price_tot.ToString("0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_component_category, id_component_price, kurs, bom_price, component_qty, error_text, query As String

        id_component_category = "3"
        error_text = "-1"
        '
        id_component_price = "0"
        kurs = "0"
        bom_price = "0"
        component_qty = "0"
        '
        Try
            id_component_price = GVProductPrice.GetFocusedRowCellDisplayText("id_product_price").ToString
            If id_component_price = "" Then
                error_text = "1"
            End If
            kurs = TEKurs.EditValue
            bom_price = TEPrice.EditValue
            component_qty = TEQty.EditValue
        Catch ex As Exception
            error_text = "1"
        End Try

        If error_text <> "-1" Then
            'ada error
            errorInput()
        Else
            If id_bom_det <> "-1" Then
                'edit
                Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_product_price='{0}' AND id_bom='{1}' AND id_bom_det !='{2}'", id_component_price, id_bom, id_bom_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" Product.")
                Else
                    query = String.Format("UPDATE tb_bom_det SET id_product_price='{0}',kurs='{1}',bom_price='{2}',component_qty='{3}' WHERE id_bom_det='{4}'", id_component_price, kurs, bom_price, component_qty, id_bom_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormBOMSingle.view_bom_wip(id_bom)
                    Close()
                End If
            Else
                'insert
                Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_product_price='{0}' AND id_bom='{1}'", id_component_price, id_bom)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" Product.")
                Else
                    query = String.Format("INSERT INTO tb_bom_det(id_bom,id_product_price,kurs,bom_price,component_qty,id_component_category) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_bom, id_component_price, kurs, bom_price, component_qty, id_component_category)
                    execute_non_query(query, True, "", "", "", "")
                    FormBOMSingle.view_bom_wip(id_bom)
                    Close()
                End If
            End If
        End If
    End Sub
End Class