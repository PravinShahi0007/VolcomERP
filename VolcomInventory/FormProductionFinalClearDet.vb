Public Class FormProductionFinalClearDet
    Public id_prod_fc As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_report_status As String = "-1"
    Dim id_prod_order As String = "-1"

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
            'Dim query_c As ClassFGWHAlloc = New ClassFGWHAlloc()
            'Dim query As String = query_c.queryMain("AND allc.id_fg_wh_alloc='" + id_fg_wh_alloc + "' ", "2")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'id_fg_wh_alloc = data.Rows(0)("id_fg_wh_alloc").ToString
            'id_report_status = data.Rows(0)("id_report_status").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'TxtNumber.Text = data.Rows(0)("fg_wh_alloc_number").ToString
            'DEForm.Text = view_date_from(data.Rows(0)("fg_wh_alloc_datex").ToString, 0)
            'MENote.Text = data.Rows(0)("fg_wh_alloc_note").ToString
            'id_comp_from = data.Rows(0)("id_comp").ToString
            'TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            'TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            'id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
            'id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            'id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            'is_submit = data.Rows(0)("is_submit").ToString


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
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, "AND comp.id_departement=" + id_departement_user + "")
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

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim data As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND comp.id_departement=" + id_departement_user + "")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_to = "-1"
                TxtNameCompTo.Text = ""
                TxtCodeCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                id_comp_to = data.Rows(0)("id_comp").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                TxtOrder.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOrder.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim order As String = addSlashes(TxtOrder.Text.ToString)
            Dim query As String = "SELECT po.id_prod_order, po.prod_order_number, c.comp_number AS `vendor_code`, c.comp_name AS `vendor`,
            dsg.design_code AS `code`, dsg.design_display_name AS `name`, s.id_season, s.season,d.delivery
            FROM tb_prod_order po 
            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            INNER JOIN tb_m_design dsg ON dsg.id_design = pdd.id_design
            LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
            LEFT JOIN tb_m_ovh_price ovp ON ovp.id_ovh_price = wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovp.id_comp_contact
            LEFT JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_season_delivery d ON d.id_delivery = po.id_delivery
            INNER JOIN tb_season s ON s.id_season = d.id_season
            WHERE (po.id_report_status=3 OR po.id_report_status=4 OR po.id_report_status=6) AND po.prod_order_number='" + order + "' "
            Dim data As DataTable = execute_non_query(query, -1, True, "", "", "")
            If data.Rows.Count = 0 Then
                stopCustom("Account Not found!")
                id_prod_order = "-1"
                TxtOrder.Text = ""
                TxtSeason.Text = ""
                TxtDel.Text = ""
                TxtVendorCode.Text = ""
                TxtVendorName.Text = ""
                TxtStyleCode.Text = ""
                TxtStyle.Text = ""
                TxtOrder.Text = ""
                TxtOrder.Focus()
            Else
                id_prod_order = data.Rows(0)("id_prod_order").ToString
                TxtOrder.Text = data.Rows(0)("prod_order_number").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                TxtDel.Text = data.Rows(0)("delivery").ToString
                TxtVendorCode.Text = data.Rows(0)("vendor_code").ToString
                TxtVendorName.Text = data.Rows(0)("vendor").ToString
                TxtStyleCode.Text = data.Rows(0)("code").ToString
                TxtStyle.Text = data.Rows(0)("name").ToString
                LEPLCategory.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class