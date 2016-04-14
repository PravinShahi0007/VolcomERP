Public Class FormMasterDesignPriceSingle 
    Public id_design_price As String = "-1"
    Public id_design As String = "-1"
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"


    Private Sub FormMasterDesignPriceSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString

        'default date
        Dim date_def As Date = execute_query("SELECT NOW()", 0, True, "", "", "", "")
        DEStart.EditValue = date_def

        view_currency(LECurrency)
        view_design_price_type(LEDesignPriceType)
        If Not id_design_price = "-1" Then
            Dim query As String = String.Format("SELECT * FROM tb_m_design_price WHERE id_design_price = '{0}'", id_design_price)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPriceName.Text = data.Rows(0)("design_price_name").ToString
            TEPrice.EditValue = data.Rows(0)("design_price").ToString
            DEStart.EditValue = data.Rows(0)("design_price_start_date")

            If data.Rows(0)("is_print").ToString <> "False" Then
                CEIsPrint.Checked = True
            Else
                CEIsPrint.Checked = False
            End If

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            LEDesignPriceType.EditValue = Nothing
            LEDesignPriceType.ItemIndex = LEDesignPriceType.Properties.GetDataSourceRowIndex("id_design_price_type", data.Rows(0)("design_price_type").ToString)
        End If
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency WHERE id_currency = '" + id_currency + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub view_design_price_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT * FROM tb_lookup_design_price_type WHERE id_design_price_type!='0' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "design_price_type"
        lookup.Properties.ValueMember = "id_design_price_type"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TEPriceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPriceName.Validating
        EP_TE_cant_blank(EPProductPrice, TEPriceName)
    End Sub

    Private Sub TEPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPrice.Validating
        EP_TE_cant_blank(EPProductPrice, TEPrice)
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim is_print, product_price, product_price_name, query, id_currency, is_active_wh As String
        ValidateChildren()

        If CEIsPrint.Checked = True Then
            is_print = "1"
        Else
            is_print = "0"
        End If

        If CEIsActiveWH.Checked = True Then
            is_active_wh = "0"
        Else
            is_active_wh = "1"
        End If

        product_price = TEPrice.EditValue
        product_price_name = TEPriceName.Text
        id_currency = LECurrency.EditValue.ToString
        Dim design_price_start_date As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim id_design_price_type As String = LEDesignPriceType.EditValue.ToString

        If Not id_design_price = "-1" Then
            ''update
            'If Not formIsValid(EPProductPrice) Then
            '    errorInput()
            'Else
            '    If is_print = "1" Then
            '        query = String.Format("UPDATE tb_m_design_price SET is_print='0' WHERE id_design='{0}'", id_design)
            '        execute_non_query(query, True, "", "", "", "")
            '    End If

            '    query = String.Format("UPDATE tb_m_design_price SET id_design_price_type = '" + id_design_price_type + "' design_price_name='{0}',design_price='{1}',design_price_date=DATE(NOW()),is_print='{2}',id_currency='{3}', design_price_start_date ='" + design_price_start_date + "' WHERE id_design_price='{4}'", product_price_name, decimalSQL(product_price.ToString), is_print, id_currency, id_design_price)
            '    execute_non_query(query, True, "", "", "", "")
            '    FormMasterDesignSingle.view_product_price(id_design)
            '    Close()
            '    Dispose()
            'End If
        Else
            'insert
            If Not formIsValid(EPProductPrice) Then
                errorInput()
            Else
                If is_print = "1" Then
                    query = String.Format("UPDATE tb_m_design_price SET is_print='0' WHERE id_design='{0}'", id_design)
                    execute_non_query(query, True, "", "", "", "")
                End If

                query = String.Format("INSERT INTO tb_m_design_price(id_design_price_type, id_design,design_price_name,design_price, design_price_date, design_price_start_date,is_print,id_currency, is_active_wh, id_user) VALUES('" + id_design_price_type + "', '{0}','{1}','{2}',DATE(NOW()), '" + design_price_start_date + "','{3}','{4}', '" + is_active_wh + "', '" + id_user + "')", id_design, product_price_name, decimalSQL(product_price.ToString), is_print, id_currency)
                execute_non_query(query, True, "", "", "", "")
                FormMasterDesignSingle.view_product_price(id_design)
                Close()
                Dispose()
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignPriceSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
       
    End Sub
End Class