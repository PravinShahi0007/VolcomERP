Public Class FormProductPriceSingle
    Public id_product_price As String = "-1"
    Public id_product As String = "-1"
    Private Sub FormProductPriceSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        If Not id_product_price = "-1" Then
            Dim query As String = String.Format("SELECT * FROM tb_m_product_price WHERE id_product_price = '{0}'", id_product_price)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPriceName.Text = data.Rows(0)("product_price_name").ToString
            TEPrice.Text = data.Rows(0)("product_price").ToString

            If data.Rows(0)("is_print").ToString <> "False" Then
                CEIsPrint.Checked = True
            Else
                CEIsPrint.Checked = False
            End If

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        End If
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub TEPriceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPriceName.Validating
        EP_TE_cant_blank(EPProductPrice, TEPriceName)
    End Sub

    Private Sub TEPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPrice.Validating
        EP_TE_cant_blank(EPProductPrice, TEPrice)
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim is_print, product_price, product_price_name, query, id_currency As String

        ValidateChildren()

        If CEIsPrint.Checked = True Then
            is_print = "1"
        Else
            is_print = "0"
        End If

        product_price = TEPrice.EditValue
        product_price_name = TEPriceName.Text
        id_currency = LECurrency.EditValue.ToString

        If Not id_product_price = "-1" Then
            'update
            If Not formIsValid(EPProductPrice) Then
                errorInput()
            Else
                If is_print = "1" Then
                    query = String.Format("UPDATE tb_m_product_price SET is_print='0' WHERE id_product='{0}'", id_product)
                    execute_non_query(query, True, "", "", "", "")
                End If

                query = String.Format("UPDATE tb_m_product_price SET product_price_name='{0}',product_price='{1}',product_price_date=DATE(NOW()),is_print='{2}',id_currency='{3}' WHERE id_product_price='{4}'", product_price_name, product_price, is_print, id_currency, id_product_price)
                execute_non_query(query, True, "", "", "", "")
                FormMasterProductDet.view_product_price(id_product)
                Close()
                Dispose()
            End If
        Else
            'insert
            If Not formIsValid(EPProductPrice) Then
                errorInput()
            Else
                If is_print = "1" Then
                    query = String.Format("UPDATE tb_m_product_price SET is_print='0' WHERE id_product='{0}'", id_product)
                    execute_non_query(query, True, "", "", "", "")
                End If

                query = String.Format("INSERT INTO tb_m_product_price(id_product,product_price_name,product_price,product_price_date,is_print,id_currency) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}')", id_product, product_price_name, product_price, is_print, id_currency)
                execute_non_query(query, True, "", "", "", "")
                FormMasterProductDet.view_product_price(id_product)
                Close()
                Dispose()
            End If
        End If
    End Sub
End Class