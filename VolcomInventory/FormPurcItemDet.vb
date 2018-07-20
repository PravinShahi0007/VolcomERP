Public Class FormPurcItemDet
    Public id_item As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormPurcItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_uom()
        load_cat()
    End Sub

    Sub load_uom()
        Dim query As String = "SELECT * FROM tb_item_cat WHERE is_active='1'"
        viewSearchLookupQuery(SLECat, query, 0, "uom", "id_uom")
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT * FROM tb_item_cat WHERE is_active='1'"
        viewSearchLookupQuery(SLECat, query, 0, "item_cat", "id_item_cat")
    End Sub

    Private Sub FormPurcItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class