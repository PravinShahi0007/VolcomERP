Public Class FormBudgetExpenseProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormBudgetExpenseProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTotalInput.EditValue = 0.00
        viewReportStatus()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As New ClassBudgetRevPropose()
            Dim query As String = query_c.queryMain("AND rp.id_b_revenue_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtYear.Text = data.Rows(0)("year").ToString
            TxtTotal.EditValue = data.Rows(0)("total")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString

            viewDetail()
            getTotal()
            allow_status()
        Else
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        End If
    End Sub

    Sub viewDetail()
        'Dim query As String = ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
        'GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnImportFromExcel.Visible = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            GVData.OptionsBehavior.Editable = True
        Else
            BtnImportFromExcel.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GVData.OptionsBehavior.Editable = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVData.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnImportFromExcel.Visible = False
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVData.OptionsBehavior.Editable = False
        End If
    End Sub

    Sub getTotal()
        'Dim query As String = "SELECT IFNULL(SUM(bd.b_revenue_propose),0) AS `total` FROM tb_b_revenue_propose_det bd WHERE bd.id_b_revenue_propose=" + id + ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'TxtTotalInput.EditValue = data.Rows(0)("total")
        'TxtDiff.EditValue = TxtTotal.EditValue - TxtTotalInput.EditValue
    End Sub

    Private Sub FormBudgetExpenseProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If XTCBudget.SelectedTabPageIndex = 0 Then

            If action = "ins" Then
                'insert
            ElseIf action = "upd" Then
                'update
            End If
        ElseIf XTCBudget.SelectedTabPageIndex = 1 Then
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then
        End If
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click

    End Sub
End Class