Public Class FormProdDemandRevDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = ""

    Private Sub FormProdDemandRevDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("AND r.id_prod_demand_rev='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtProdDemandNumber.Text = data.Rows(0)("prod_demand_number").ToString
        TxtRevision.Text = data.Rows(0)("rev_count").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        If data.Rows(0)("id_pd_kind").ToString = "1" Then
            rmt = "143"
        ElseIf data.Rows(0)("id_pd_kind").ToString = "2" Then
            rmt = "144"
        ElseIf data.Rows(0)("id_pd_kind").ToString = "3" Then
            rmt = "145"
        End If

        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()

    End Sub


    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
        End If
    End Sub


    Private Sub FormProdDemandRevDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class