Public Class FormPriceMKDVios
    Public id_report As String = "-1"
    Public rmt As String = "-1"

    Private Sub FormPriceMKDVios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnLastPropose_Click(sender As Object, e As EventArgs) Handles BtnLastPropose.Click
        viewLatestProposal()
    End Sub

    Sub viewLatestProposal()
        Cursor = Cursors.WaitCursor
        Dim qh As String = "SELECT pp.id_pp_change AS `id_report`, 306 AS `rmt`, pp.number AS `pp_number`, pp.created_date, pp.effective_date, pt.design_price_type
        FROM tb_pp_change pp
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pp.id_design_price_type
        WHERE pp.id_report_status=6
        UNION ALL
        SELECT pm.id_fg_price AS `id_report`, 82 AS `rmt`, pm.fg_price_number AS `pp_number`, pm.fg_price_date AS `created_date`, pm.fg_effective_date AS `effective_date`, pt.design_price_type
        FROM tb_fg_price pm
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pm.id_design_price_type
        WHERE pm.id_report_status=6 AND pt.id_design_price_type!=1
        ORDER BY effective_date DESC
        LIMIT 1 "
        Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
        If dh.Rows.Count <= 0 Then
            stopCustom("No latest proposal")
            refreshView()
        Else
            id_report = dh.Rows(0)("id_report").ToString
            rmt = dh.Rows(0)("rmt").ToString

            If rmt = "82" Then

            ElseIf rmt = "306" Then

            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshView()
        id_report = "-1"
        rmt = "-1"
        TxtProposeNo.Text = ""
        DEEffDate.EditValue = Nothing
        GCData.DataSource = Nothing
    End Sub
End Class