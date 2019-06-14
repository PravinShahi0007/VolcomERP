Public Class FormItemSubCatDet
    Public id_sub_cat As String = "-1"

    Private Sub FormItemSubCatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_cat()
        Dim query As String = "SELECT cat.id_item_cat,cat.item_cat FROM `tb_item_cat` cat
INNER JOIN `tb_item_coa` coa ON cat.`id_item_cat`=coa.`id_item_cat`
WHERE coa.`is_request`='1' AND cat.is_active='1'
GROUP BY cat.`id_item_cat`"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub
End Class