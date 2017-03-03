Public Class FormProductionFinalClearDet
    Public id_prod_fc As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_report_status As String = "-1"

    Private Sub FormProductionFinalClearDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPLCat()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            GroupControlItemList.Enabled = False
            BMark.Enabled = False
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()
        ElseIf action = "upd" Then
            GroupControlItemList.Enabled = True
            BtnAttachment.Enabled = True
            BtnSave.Text = "Save Changes"

            'query view based on edit id's
            Dim query_c As ClassFGWHAlloc = New ClassFGWHAlloc()
            Dim query As String = query_c.queryMain("AND allc.id_fg_wh_alloc='" + id_fg_wh_alloc + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_wh_alloc = data.Rows(0)("id_fg_wh_alloc").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_wh_alloc_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_wh_alloc_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_wh_alloc_note").ToString
            id_comp_from = data.Rows(0)("id_comp").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
            id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            is_submit = data.Rows(0)("is_submit").ToString


            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "105", id_prod_fc) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If


        'ATTACH
        If check_attach_report_status(id_report_status, "105", id_prod_fc) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, "-1")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_from = "-1"
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            Else
                id_comp_from = data.Rows(0)("id_comp").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtCodeCompTo.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class