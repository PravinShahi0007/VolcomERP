Public Class FormSamplePLExport
    Dim id_pl_start As String = ""
    Dim id_pl_end As String = ""

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        view_pl_det()
        GVSample.ExpandAllGroups()
    End Sub

    Sub view_pl_det()
        Dim query As String = ""
        query = "SELECT spld.id_sample_pl_det,spl.id_sample_pl,spl.sample_pl_number,sp.id_sample,sp.sample_code AS `code`,sp.sample_display_name AS description,SUM(spld.sample_pl_det_qty) AS qty"
        query += " ,spld.sample_ret_price As price"
        query += " ,SUM(spld.sample_price * spld.sample_pl_det_qty) As total_cost "
        query += " ,SUM(spld.sample_ret_price * spld.sample_pl_det_qty) AS total_amount "
        query += " FROM tb_sample_pl_det spld"
        query += " INNER JOIN tb_sample_pl spl On spl.id_sample_pl=spld.id_sample_pl"
        query += " INNER JOIN tb_m_sample sp On sp.id_sample=spld.id_sample"
        query += " WHERE spl.id_report_status = '6'"
        query += " AND spld.id_sample_pl >= (SELECT id_sample_pl FROM tb_sample_pl WHERE sample_pl_number = '" & TEPLStart.Text & "')"
        query += " And spld.id_sample_pl <= (SELECT id_sample_pl FROM tb_sample_pl WHERE sample_pl_number = '" & TEPLEnd.Text & "')"
        query += " GROUP BY sp.id_sample, spld.id_sample_ret_price "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSample.DataSource = data
    End Sub

    Private Sub FormSamplePLExport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(0, 0, 0)
    End Sub

    Private Sub FormSamplePLExport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSamplePLExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        Dim data As DataTable
        query = "SELECT sample_pl_number FROM tb_sample_pl WHERE id_report_status=6 ORDER BY id_sample_pl ASC LIMIT 1"
        data = execute_query(query, -1, True, "", "", "", "")
        TEPLStart.Text = data.Rows(0)("sample_pl_number").ToString
        query = "SELECT sample_pl_number FROM tb_sample_pl WHERE id_report_status=6 ORDER BY id_sample_pl DESC LIMIT 1"
        data = execute_query(query, -1, True, "", "", "", "")
        TEPLEnd.Text = data.Rows(0)("sample_pl_number").ToString
    End Sub
End Class