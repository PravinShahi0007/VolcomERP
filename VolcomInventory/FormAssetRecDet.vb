Public Class FormAssetRecDet
    Public id_rec As String = "-1"
    Public is_view As String = "-1"
    Public id_po As String = "-1"
    Private Sub FormAssetRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_top()
        '
        If id_rec = "-1" Then 'new

        Else 'edit
            load_det()
        End If
        load_list()
    End Sub
    Sub load_list()
        Dim query As String = "SELECT * FROM tb_a_asset_rec_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub
    Sub load_det()

    End Sub
    Sub load_po_det()
        Dim query As String = "SELECT * FROM tb_a_asset_po WHERE id_asset_po='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEVendor.Text = data.Rows(0)("comp_name").ToString
            TEAttn.Text = data.Rows(0)("comp_attn").ToString
            MEAddress.Text = data.Rows(0)("comp_address").ToString
            TEPhone.Text = data.Rows(0)("comp_phone").ToString
            TEFax.Text = data.Rows(0)("comp_fax").ToString
            DEPODate.EditValue = data.Rows(0)("asset_po_date")
            DEEstRecDate.EditValue = data.Rows(0)("est_rec_date")
            TEPONumber.Text = data.Rows(0)("asset_po_no").ToString
            LEPil.ItemIndex = LEPil.Properties.GetDataSourceRowIndex("id_term_payment", data.Rows(0)("id_term_payment").ToString)
            '
            If data.Rows(0)("id_report_status").ToString = "6" Or is_view = "1" Then
                BtnSave.Visible = False
            End If
            '
        End If
    End Sub
    Sub load_top()
        Dim query As String = "SELECT id_term_payment,term_payment FROM tb_lookup_term_payment"
        viewLookupQuery(LEPil, query, 0, "term_payment", "id_term_payment")
    End Sub

    Private Sub BPickPONumber_Click(sender As Object, e As EventArgs) Handles BPickPONumber.Click

    End Sub

    Private Sub FormAssetRecDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class