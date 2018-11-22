Public Class FormItemDelDetail
    Public id As String = "-1"
    Public id_req As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""

    Private Sub FormItemDelDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'del detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()

            'default detail view
            viewDetail()
        Else
            'Dim r As New ClassItemRequest()
            'Dim query As String = r.queryMain("AND r.id_item_req='" + id + "' ", "1")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'id_report_status = data.Rows(0)("id_report_status").ToString
            'TxtNumber.Text = data.Rows(0)("number").ToString
            'created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            'DECreated.EditValue = data.Rows(0)("created_date")
            'MENote.Text = data.Rows(0)("note").ToString
            'TxtDept.Text = data.Rows(0)("departement").ToString
            'TxtRequestedBy.Text = data.Rows(0)("created_by_name").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()

    End Sub

    Sub allow_status()

    End Sub

    Private Sub FormItemDelDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class