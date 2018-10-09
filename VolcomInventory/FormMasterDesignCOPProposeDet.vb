Public Class FormMasterDesignCOPProposeDet
    Public id_comp As String = "-1"
    Public id_comp_contact As String = "-1"

    Private Sub FormMasterDesignCOPProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        view_currency(LECurrency)
    End Sub
    Sub load_det(ByVal opt As String)
        Dim query_where As String = ""
        '
        TEKurs.EditValue = 0.00

        '
        If opt = "code" Then
            If Not SLESeasonByCode.EditValue.ToString = "-1" Then
                query_where += " AND RIGHT(f1.design_code,2)='" & SLESeasonByCode.EditValue.ToString & "'"
            End If

            Try
                Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCItemList.DataSource = data
                BGVItemList.BestFitColumns()
            Catch ex As Exception
                errorConnection()
            End Try
        ElseIf opt = "season" Then
            If Not SLESeason.EditValue.ToString = "-1" Then
                query_where += " AND season.id_season='" & SLESeason.EditValue.ToString & "'"
            End If

            Try
                Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCItemList.DataSource = data
                BGVItemList.BestFitColumns()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' AS season,'-1' AS `range` UNION
                                (SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonByCode, query, "range", "season", "range")
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BSearchByCode_Click(sender As Object, e As EventArgs) Handles BSearchByCode.Click
        load_det("code")
    End Sub

    Private Sub BGVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BGVItemList.RowCellStyle
        Try
            If BGVItemList.GetRowCellValue(e.RowHandle, "id_lookup_status_order").ToString = "2" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignCOPProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_det("season")
    End Sub

    Private Sub TEVendor_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
            query += " where cc.is_default=1 and c.id_comp_cat='1' AND c.comp_number='" + TEVendor.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TEVendor.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "88"
                FormPopUpContact.id_cat = 1
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TEVendor.Text + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_comp_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                TEVendor.Text = data.Rows(0)("comp_number").ToString
                '
                LECurrency.Focus()
            End If
        End If
    End Sub

    Private Sub LECurrency_KeyDown(sender As Object, e As KeyEventArgs) Handles LECurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEKurs.Focus()
        End If
    End Sub

    Private Sub TEKurs_KeyDown(sender As Object, e As KeyEventArgs) Handles TEKurs.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEEcop.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not BGVItemList.RowCount > 0 Then
            warningCustom("Please choose the design first")
        ElseIf id_comp_contact = "-1" Then
            warningCustom("Please fill the vendor")
        Else
            Dim newRow As DataRow = (TryCast(FormMasterDesignCOPPropose.GCItemList.DataSource, DataTable)).NewRow()
            newRow("id_design") = BGVItemList.GetFocusedRowCellDisplayText("id_design").ToString
            newRow("design_code") = BGVItemList.GetFocusedRowCellDisplayText("design_code").ToString
            newRow("design_display_name") = BGVItemList.GetFocusedRowCellDisplayText("design_display_name").ToString
            '
            newRow("id_comp_contact") = id_comp_contact
            newRow("comp_number") = TEVendor.Text
            newRow("comp_name") = TEVendorName.Text
            newRow("id_currency") = LECurrency.EditValue.ToString
            newRow("currency") = LECurrency.Text
            newRow("kurs") = TEKurs.EditValue
            newRow("design_cop") = TEEcop.EditValue
            newRow("add_cost") = TEAdditionalCost.EditValue
            '
            newRow("id_comp_contact_before") = BGVItemList.GetFocusedRowCellDisplayText("prod_order_cop_pd_vendor").ToString
            newRow("comp_number_before") = BGVItemList.GetFocusedRowCellDisplayText("comp_number_pd").ToString
            newRow("comp_name_before") = BGVItemList.GetFocusedRowCellDisplayText("comp_name_pd").ToString
            newRow("id_currency_before") = BGVItemList.GetFocusedRowCellDisplayText("prod_order_cop_pd_curr").ToString
            newRow("currency_before") = BGVItemList.GetFocusedRowCellDisplayText("curr_pd").ToString
            newRow("kurs_before") = BGVItemList.GetFocusedRowCellDisplayText("prod_order_cop_pd_kurs").ToString
            newRow("design_cop_before") = BGVItemList.GetFocusedRowCellDisplayText("prod_order_cop_pd").ToString
            newRow("add_cost_before") = BGVItemList.GetFocusedRowCellDisplayText("prod_order_cop_pd_addcost").ToString
            '
            TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable).Rows.Add(newRow)
            FormEmpLeaveDet.GCLeaveDet.RefreshDataSource()
        End If
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "88"
        FormPopUpContact.id_cat = 1
        FormPopUpContact.ShowDialog()
    End Sub
End Class