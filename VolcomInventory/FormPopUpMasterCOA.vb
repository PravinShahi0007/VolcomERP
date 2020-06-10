Public Class FormPopUpMasterCOA
    Private Sub FormPopUpMasterCOA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPopUpMasterCOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_acc()
    End Sub

    Sub view_acc()
        Dim query As String = "SELECT a.id_acc,acc_name,a.acc_description,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,comp.id_comp,comp.comp_name,comp.comp_number,e.dc FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat INNER JOIN tb_lookup_status c ON a.id_status=c.id_status INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det INNER JOIN tb_lookup_dc AS e ON a.id_dc = e.id_dc "
        query += "LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
        GVAcc.BestFitColumns()
    End Sub
End Class