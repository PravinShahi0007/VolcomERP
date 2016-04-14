Public Class FormViewSampleOrder 
    Public action As String
    Public id_sample_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sample_order_det_list As New List(Of String)
    Public id_so_type As String = "-1"

    Private Sub FormViewSampleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        actionLoad()
    End Sub

    Private Sub FormViewSampleOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'query view based on edit id's
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryMain("AND so.id_sample_order=''" + id_sample_order + "'' ", "1")
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sample_order_datex").ToString, 0)
        TxtNumber.Text = data.Rows(0)("sample_order_number").ToString
        MENote.Text = data.Rows(0)("sample_order_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        'detail2
        viewDetail()
        check_but()
        allow_status()
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryDetail(id_sample_order)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_order_det_list.Add(data.Rows(i)("id_sample_order_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub check_but()
     
    End Sub

    Sub allow_status()
        TxtNameCompTo.Properties.Buttons.Clear() 'clear browse button
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False
        LEStatusSO.Enabled = False
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_order
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "62"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class