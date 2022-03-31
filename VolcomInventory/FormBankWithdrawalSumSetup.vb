Public Class FormBankWithdrawalSumSetup
    Public id_summary_det As String = ""
    Public id_comp As String = ""

    Private Sub FormBankWithdrawalSumSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_kode_bank()
        load_cust_residen()
        load_cust_type()
        load_trx_type()

        Dim q As String = "SELECT c.comp_number,c.comp_name,c.def_cust_type,c.def_cust_residen,c.def_id_trx_code,c.id_bank,cat.comp_cat_name,c.bank_attn_name,c.bank_address,c.bank_rek
FROM tb_m_comp c 
INNER JOIN tb_m_comp_cat cat ON cat.id_comp_cat=c.id_comp_cat
WHERE c.id_comp='" & id_comp & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            If Not dt.Rows(0)("def_cust_type").ToString = "" Then
                SLECustType.EditValue = dt.Rows(0)("def_cust_type").ToString
            End If
            If Not dt.Rows(0)("def_cust_residen").ToString = "" Then
                SLEResiden.EditValue = dt.Rows(0)("def_cust_residen").ToString
            End If
            If Not dt.Rows(0)("def_id_trx_code").ToString = "" Then
                SLETrxType.EditValue = dt.Rows(0)("def_id_trx_code").ToString
            End If
            '
            If Not dt.Rows(0)("id_bank").ToString = "0" And Not dt.Rows(0)("id_bank").ToString = "" Then
                SLETrxType.EditValue = dt.Rows(0)("id_bank").ToString
            End If
            '
            TECode.Text = dt.Rows(0)("comp_number").ToString
            TEVendor.Text = dt.Rows(0)("comp_name").ToString
            TEVendorType.Text = dt.Rows(0)("comp_cat_name").ToString
            TEBankAddress.Text = dt.Rows(0)("bank_address").ToString
            TEBankName.Text = dt.Rows(0)("bank_attn_name").ToString
            TEBankNo.Text = dt.Rows(0)("bank_rek").ToString
            '
        End If
        '
        load_trx()
    End Sub

    Sub load_trx()

    End Sub

    Sub load_kode_bank()
        Dim query As String = "SELECT id,nama_bank,kode_bank FROM `tb_kode_bank` WHERE id!=0 AND kode_bank!='INT'"
        viewSearchLookupQuery(SLEBankAccount, query, "id", "nama_bank", "id")
        viewSearchLookupQuery(SLEBankAccount, query, "id", "nama_bank", "id")
    End Sub

    Sub load_cust_residen()
        Dim q As String = "SELECT id_cust_residen,cust_residen FROM `tb_lookup_bca_cust_residen`"
        viewSearchLookupQuery(SLEResiden, q, "id_cust_residen", "cust_residen", "id_cust_residen")
    End Sub

    Sub load_cust_type()
        Dim q As String = "SELECT id_cust_type,cust_type FROM `tb_lookup_bca_cust_type`"
        viewSearchLookupQuery(SLECustType, q, "id_cust_type", "cust_type", "id_cust_type")
    End Sub

    Sub load_trx_type()
        Dim q As String = "SELECT id_trx_code,trx_code FROM `tb_lookup_bca_trx_code`"
        viewSearchLookupQuery(SLETrxType, q, "id_trx_code", "trx_code", "id_trx_code")
    End Sub
End Class