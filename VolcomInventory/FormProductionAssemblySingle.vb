Public Class FormProductionAssemblySingle
    Public is_view As String = "-1"
    Public action As String = "-1"
    Public id_prod_ass As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormProductionAssemblySingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassProductionAssembly()
        Dim query As String = query_c.queryMain("AND a.id_prod_ass=" + id_prod_ass + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtDesignCode.Text = data.Rows(0)("code").ToString
        TxtDesign.Text = data.Rows(0)("name").ToString
        DEFrom.EditValue = data.Rows(0)("prod_ass_date")
        TxtNumber.Text = data.Rows(0)("prod_ass_number").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()

    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "107", id_prod_ass) Then
            MENote.Enabled = True
        Else
            MENote.Enabled = False
        End If
        BtnSave.Enabled = False
        GVItemList.OptionsBehavior.Editable = False
        MENote.Enabled = False

        'ATTACH
        If check_attach_report_status(id_report_status, "107", id_prod_ass) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If is_view = "1" Then
            BtnSave.Visible = False
        End If
        TxtNumber.Focus()
    End Sub

    Private Sub FormProductionAssemblySingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class