Public Class FormViewFGCodeReplaceStore 
    Public action As String = "-1"
    Public id_fg_code_replace_store As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_code_replace_store_det_list As New List(Of String)

    Private Sub FormViewFGCodeReplaceStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormViewFGCodeReplaceStore_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'visible column counting
        GridColumnCountingStart.Visible = False
        GridColumnCountingEnd.Visible = False

        'query view based on edit id's
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryMainStore("AND rep.id_fg_code_replace_store=''" + id_fg_code_replace_store + "'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_fg_code_replace_store = data.Rows(0)("id_fg_code_replace_store").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNumber.Text = data.Rows(0)("fg_code_replace_store_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_code_replace_store_datex").ToString, 0)
        MENote.Text = data.Rows(0)("fg_code_replace_store_note").ToString

        'detail2
        viewDetail()
        check_but()
        allow_status()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
      
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryDetailStore(id_fg_code_replace_store)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        GVItemList.OptionsCustomization.AllowGroup = True

        If id_report_status = "6" Then
            GridColumnCountingStart.Visible = True
            GridColumnCountingEnd.Visible = True
        Else
            GridColumnCountingStart.Visible = False
            GridColumnCountingEnd.Visible = False
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "65"
        FormReportMark.id_report = id_fg_code_replace_store
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

End Class