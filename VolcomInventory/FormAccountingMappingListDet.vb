Public Class FormAccountingMappingListDet 
    Public id_acc As String = "-1"
    Public id_coa_mapping As String = "-1"
    Public is_search_cc As String = "-1"

    Private Sub BPickDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDesign.Click
        FormPopUpCOA.id_pop_up = "5"
        FormPopUpCOA.ShowDialog()
    End Sub

    Private Sub FormAccountingMappingListDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_dc(LEpayment)
        load_operation()
    End Sub

    Sub load_operation()
        Dim query As String = "SELECT * FROM tb_opt_coa_mapping_det WHERE id_coa_mapping = '" & id_coa_mapping & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCValueMap.DataSource = data
    End Sub

    Private Sub view_dc(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_dc,dc FROM tb_lookup_dc WHERE id_dc='1' or id_dc='2'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "dc"
        lookup.Properties.ValueMember = "id_dc"
        lookup.ItemIndex = 0
    End Sub

    Private Sub FormAccountingMappingListDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        'need update
        'edit detail is not available now

        Dim is_acc_sup As String = "1"

        If is_search_cc = "-1" Or is_search_cc = "2" Then
            is_acc_sup = "2"
        Else
            is_acc_sup = "1"
        End If

        'save
        Dim query As String = String.Format("UPDATE tb_opt_coa_mapping SET id_acc='{0}',id_dc='{1}',is_acc_sup='{2}',description='{4}' WHERE id_coa_mapping='{3}'", id_acc, LEpayment.EditValue.ToString, is_acc_sup, id_coa_mapping, MEDesc.Text.ToString)
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Mapping saved.")
        FormAccountingMappingList.load_mapping_coa()
        Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class