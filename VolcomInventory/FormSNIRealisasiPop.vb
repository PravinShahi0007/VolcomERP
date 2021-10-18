Public Class FormSNIRealisasiPop
    Private Sub FormSNIRealisasiPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT d.id_item_del,d.number AS item_del_number,r.`number` AS item_req_number,dd.`qty`,d.`note`
FROM tb_item_del_det dd
INNER JOIN tb_item_del d ON d.`id_item_del`=dd.`id_item_del` AND d.`id_report_status`=6
INNER JOIN tb_item_req_det rd ON rd.`id_item_req_det`=dd.`id_item_req_det`
INNER JOIN tb_item_req r ON r.id_item_req=rd.id_item_req
WHERE rd.`id_item`='752'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click

    End Sub
End Class