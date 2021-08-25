Public Class FormMasterSilhouetteDet
    Public id_class As String = "-1"

    Sub viewSht()
        Dim query As String = "SELECT cd.id_code_detail,cd.code_detail_name 
        FROM tb_m_code_detail cd WHERE cd.id_code IN (SELECT o.id_code_fg_sht FROM tb_opt o)
        ORDER BY cd.code_detail_name ASC "
        viewSearchLookupQuery(SLESHT, query, "id_code_detail", "code_detail_name", "id_code_detail")
    End Sub

    Sub viewData()

    End Sub

    Private Sub FormMasterSilhouetteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSht()
        viewData()
    End Sub
End Class