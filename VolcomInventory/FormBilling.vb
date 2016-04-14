Public Class FormBilling 
    Private Sub FormBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_billing_type(LEBilling)
    End Sub

    Private Sub FormBilling_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBilling_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        view_bill(LEBilling.EditValue.ToString)
    End Sub

    Sub view_bill(ByVal id_bill_type As String)
        Dim query As String = "SELECT * FROM tb_bill bill INNER JOIN tb_m_comp comp ON comp.id_comp=bill.id_cc WHERE id_bill_type='" & id_bill_type & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCBilling.DataSource = data
    End Sub

    Private Sub GVBilling_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBilling.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class