Public Class FormFGProposePriceDetail
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Public id_division As String = "-1"
    Public id_source As String = "-1"


    Private Sub FormFGProposePriceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub


    Sub actionLoad()
        'main
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("AND tb_fg_propose_price.id_fg_propose_price=''" + id + "'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        MENote.Text = data.Rows(0)("fg_propose_price_note").ToString
        DECreated.EditValue = data.Rows(0)("fg_propose_price_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        id_division = data.Rows(0)("id_division").ToString
        id_source = data.Rows(0)("id_source").ToString
        TxtSource.Text = data.Rows(0)("source").ToString

        'detail
        viewDetail()
    End Sub

    Sub viewDetail()

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

    End Sub

    Private Sub BtnUpdateCOP_Click(sender As Object, e As EventArgs) Handles BtnUpdateCOP.Click

    End Sub
End Class