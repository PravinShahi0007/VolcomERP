Public Class FormWorkOrderDet
    Public id_wo As String = "-1"
    Private Sub FormWorkOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_work_order_type()
        TEReqNUmber.Text = "[auto_generate]"
        TEReqBy.Text = get_emp(id_user, "4")
        TEDep.Text = get_emp(id_user, "5")
        DEDateCreated.EditValue = Now
    End Sub

    Sub load_work_order_type()
        Dim query As String = "SELECT wot.`id_work_order_type`,wot.`work_order_type`,dep.`departement` FROM tb_lookup_work_order_type wot
INNER JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=wot.`id_sub_departement`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=sub.`id_departement`"
        viewSearchLookupQuery(SLEType, query, "id_work_order_type", "work_order_type", "id_work_order_type")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_wo = "-1" Then
            Dim query As String = ""
        End If
    End Sub
End Class