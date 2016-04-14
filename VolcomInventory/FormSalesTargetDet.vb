Public Class FormSalesTargetDet 
    Public action As String
    Public id_sales_target As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_report_status As String

    Private Sub FormSalesTargetDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtSalesTargetNumber.Text = header_number_sales("1")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail()
            check_but()
        ElseIf action = "upd" Then
            'query view based on edit id's
            Dim query As String = "SELECT a.id_sales_target, a.id_comp_contact_to, (d.comp_name) AS comp_name_to, (d.comp_number) AS comp_number_to, (d.address_primary) AS comp_address_to, a.id_report_status, f.report_status, "
            query += "a.sales_target_note, a.id_season, e.season,a.sales_target_date, a.sales_target_note, a.sales_target_number, "
            query += "DATE_FORMAT(a.sales_target_date,'%Y-%m-%d') AS sales_target_datex "
            query += "FROM tb_sales_target a "
            query += "INNER JOIN tb_sales_target_det b ON a.id_sales_target = b.id_sales_target "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_season e ON e.id_season = a.id_season "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "WHERE a.id_sales_target = '" + id_sales_target + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sales_target_datex").ToString, 0)
            TxtSalesTargetNumber.Text = data.Rows(0)("sales_target_number").ToString
            SLESeason.EditValue = data.Rows(0)("id_season")
            MENote.Text = data.Rows(0)("sales_target_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            'detail2
            viewDetail()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT a.id_season, a.id_range, a.season, b.range, "
        query += "DATE_FORMAT(a.date_season_start, '%d %M %Y') AS date_season_start,  "
        query += "DATE_FORMAT(a.date_season_end, '%d %M %Y') AS date_season_end "
        query += "FROM tb_season a  "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY a.date_season_start ASC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_target('" + id_sales_target + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then

        ElseIf action = "upd" Then

        End If
        GCItemList.DataSource = data
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
    End Sub

    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVItemList.RowCount > 0 Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "38", id_sales_target) Then
            BtnBrowseContactTo.Enabled = True
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            'BtnInfoSrs.Enabled = True
            'LEPLCategory.Enabled = True
        Else
            BtnBrowseContactTo.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            'BtnInfoSrs.Enabled = False
            'LEPLCategory.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtSalesTargetNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "37"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesTargetDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class