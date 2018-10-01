Public Class FormPurcReceiveDet
    Public id As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"

    Private Sub FormPurcReceiveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewSummary()
        Dim query As String = "SELECT rd.id_purc_rec_det, rd.id_purc_rec, 
        rd.id_item, i.item_desc, i.id_uom, u.uom,
        rd.id_purc_order_det, pod.`value`, pod.qty AS `qty_order`, rd.qty, rd.note 
        FROM tb_purc_rec_det rd
        INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        WHERE rd.id_purc_rec=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
    End Sub
End Class