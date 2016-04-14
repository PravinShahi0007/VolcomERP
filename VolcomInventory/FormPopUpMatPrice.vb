Public Class FormPopUpMatPrice 
    Public id_mat_det As String = "-1"
    Public id_currency As String = "1"
    Public id_pop_up As String = "-1"
    Private Sub FormPopUpMatPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_price()
        view_currency(LECurrency)

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", id_currency)
    End Sub
    Sub view_mat_price()
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_mat_det_price.id_mat_det_price,tb_m_mat_det_price.mat_det_price_name,tb_m_mat_det_price.mat_det_price,tb_m_mat_det_price.mat_det_price_date,tb_m_comp.comp_name FROM tb_m_mat_det_price,tb_m_comp,tb_m_comp_contact,tb_lookup_currency WHERE tb_m_mat_det_price.id_currency=tb_lookup_currency.id_currency AND tb_m_mat_det_price.id_comp_contact=tb_m_comp_contact.id_comp_contact AND tb_m_comp_contact.id_comp=tb_m_comp.id_comp AND tb_m_mat_det_price.id_mat_det='" & id_mat_det & "' ORDER BY tb_m_mat_det_price.id_mat_det_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPrice.DataSource = data

        If Not data.Rows.Count < 1 Then
            GVMatPrice.FocusedRowHandle = 0
        End If
    End Sub
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpMatPrice_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVMatPrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPrice.FocusedRowChanged
        If GVMatPrice.RowCount > 0 Then
            Dim price As Decimal
            Dim currency As String

            price = GVMatPrice.GetFocusedRowCellValue("mat_det_price")
            currency = GVMatPrice.GetFocusedRowCellValue("currency")

            TEVendCur.Text = currency
            TEVendPrice.EditValue = price

            TEPriceTot.EditValue = price
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

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then ' formpopupstoragemat
            If GVMatPrice.RowCount > 0 And TEPriceTot.EditValue > 0 Then
                FormPopUpStorageMat.TEUnitPrice.EditValue = TEPriceTot.EditValue
                Close()
            Else
                stopCustom("Please input the price.")
            End If
        End If
    End Sub
End Class