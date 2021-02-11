Public Class FormPolisObject
    Public id_object As String = "-1"

    Private Sub FormPolisObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()

        load_head()
    End Sub

    Sub load_head()
        If id_object = "-1" Then 'new

        Else 'edit

        End If
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'Not Store' AS comp_name,'' AS sts
UNION ALL
SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) AS comp_name,IF(c.is_active=1,'Active','Not Active') AS sts  
FROM tb_m_comp c
WHERE c.id_comp_cat='6'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormPolisObject_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged
        If SLEVendor.EditValue.ToString = "0" Then

        End If
    End Sub
End Class