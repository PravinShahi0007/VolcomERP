Public Class FormOutboundListDet
    Public id_awb As String = ""

    Private Sub FormOutboundListDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_del_type()
        Dim q As String = "SELECT id_del_type, del_type, is_no_weight FROM tb_lookup_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
    End Sub

    Private Sub FormOutboundListDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPanjang.EditValue = 0
        TELebar.EditValue = 0
        TETinggi.EditValue = 0
        TEActWeight.EditValue = 0
        '
        view_del_type()
        '
        Dim q As String = "SELECT * FROM tb_awbill WHERE id_awbill='" & id_awb & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TEOutboundNumber.Text = dt.Rows(0)("id_awbill")
            '
            view_do()
        End If
    End Sub

    Sub view_do()
        Dim query As String = "SELECT * FROM tb_wh_awbill_det WHERE id_awbill='" + id_awb + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDO.DataSource = data
        GVDO.BestFitColumns()
    End Sub

    Sub calculate()

    End Sub
End Class