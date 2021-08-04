Public Class FormAREvalNote
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_submit As String = "-1"
    Dim rmt As String = "329"

    Private Sub FormAREvalNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormAREvalNote_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        'main
        Dim query As String = "SELECT n.id_ar_eval_note, n.id_ar_eval_pps, n.`number`, n.created_date, n.id_report_status, n.note 
        FROM tb_ar_eval_note n
        WHERE n.id_ar_eval_note=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_submit = data.Rows(0)("is_submit").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()

    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        If is_submit = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Properties.ReadOnly = False
            GVData.OptionsBehavior.ReadOnly = False
            GCData.ContextMenuStrip = ContextMenuStrip1
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            GCData.ContextMenuStrip = Nothing
        End If

        'reset propose
        If is_view = "-1" And is_submit = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            GCData.ContextMenuStrip = Nothing
        End If
    End Sub
End Class