Public Class FormAWBInv
    Private Sub FormAWBInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_3pl()
    End Sub

    Sub load_inv()
        Dim query As String = "SELECT id_ FROM tb_del_manifest 
WHERE id_comp='" & SLUE3PL.EditValue.ToString & "'
GROUP BY awbill_inv_no,id_comp"

        viewSearchLookupQuery(SLEInvoice, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
        load_inv()
    End Sub
End Class
