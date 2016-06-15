Public Class FormMasterCompanySingle
    Public id_company As String
    Public id_pop_up As String = "-1"
    Public id_def_drawer As String = "-1"

    Dim data_map As DataTable

    Private Sub FormMasterCompanySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCompanySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        action_load()
    End Sub

    Sub action_load()
        XTCCompany.SelectedTabPageIndex = 1
        XTCCompany.SelectedTabPageIndex = 0
        'LE/SLE
        view_comp_group()
        view_country(LECountry)
        view_category(LECompanyCategory)
        view_status(LEStatus)
        view_tax(LETax)
        view_departement(LEDepartement)
        view_store_type()
        view_store_area()
        viewSalesRep()
        viewPDAlloc()
        viewWHType()
        viewSOType()
        'default value
        TxtCommission.EditValue = 0.0
        LEStoreType.EditValue = Nothing
        LEArea.EditValue = Nothing
        SLESalesRep.EditValue = Nothing
        LEAllocation.EditValue = Nothing
        LESOType.EditValue = Nothing
        LEWHType.EditValue = Nothing

        If id_company = "-1" Then
            'new
            XTPSetup.PageVisible = False
        Else
            'edit
            XTPSetup.PageVisible = True
            Dim query As String = String.Format("SELECT comp.*,drawer.wh_drawer FROM tb_m_comp comp LEFT JOIN tb_m_wh_drawer drawer ON drawer.id_wh_drawer=comp.id_drawer_def WHERE id_comp = '{0}'", id_company)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim id_company_category As String = data.Rows(0)("id_comp_cat").ToString
            Dim id_city As String = data.Rows(0)("id_city").ToString
            Dim company_name As String = data.Rows(0)("comp_name").ToString
            Dim company_code As String = data.Rows(0)("comp_number").ToString
            Dim company_printed_name As String = data.Rows(0)("comp_display_name").ToString
            Dim address_primary As String = data.Rows(0)("address_primary").ToString
            Dim address_other As String = data.Rows(0)("address_other").ToString
            Dim postal_code As String = data.Rows(0)("postal_code").ToString
            Dim email As String = data.Rows(0)("email").ToString
            Dim website As String = data.Rows(0)("website").ToString
            Dim is_active As String = data.Rows(0)("is_active").ToString
            Dim id_tax As String = data.Rows(0)("id_tax").ToString
            Dim npwp As String = data.Rows(0)("npwp").ToString
            Dim fax As String = data.Rows(0)("fax").ToString
            Dim id_dept As String = data.Rows(0)("id_departement").ToString
            Dim id_comp_group As String = data.Rows(0)("id_comp_group").ToString

            id_def_drawer = data.Rows(0)("id_drawer_def").ToString
            TEDefDrawer.Text = data.Rows(0)("wh_drawer").ToString
            '
            TECargoDest.Text = data.Rows(0)("awb_destination").ToString
            TECargoZone.Text = data.Rows(0)("awb_zone").ToString
            TECargoCode.Text = data.Rows(0)("awb_cargo_code").ToString
            '
            SLEGroup.EditValue = id_comp_group

            data.Dispose()

            Dim id_state As String = get_state(id_city.ToString)
            Dim id_region As String = get_region(id_state.ToString)
            Dim id_country As String = get_country(id_region.ToString)

            TECompanyName.Text = company_name
            TECompanyPrintedName.Text = company_printed_name
            TECompanyCode.Text = company_code
            MEAddress.Text = address_primary
            MEOAddress.Text = address_other
            TEPostalCode.Text = postal_code
            TEEMail.Text = email
            TEWeb.Text = website
            TENPWP.Text = npwp
            TEFax.Text = fax

            Dim id_comp_contact As String = "-1"
            id_comp_contact = get_company_x(id_company, "6")

            TEPhone.Text = get_company_contact_x(id_comp_contact, "2")
            TEPhone.Enabled = False
            TEAttn.Text = get_company_contact_x(id_comp_contact, "1")
            TEAttn.Enabled = False

            LECompanyCategory.EditValue = Nothing
            LECompanyCategory.ItemIndex = LECompanyCategory.Properties.GetDataSourceRowIndex("id_comp_cat", id_company_category)

            LETax.EditValue = Nothing
            LETax.ItemIndex = LETax.Properties.GetDataSourceRowIndex("id_tax", id_tax)

            If id_dept = "" Then '
                LEDepartement.EditValue = Nothing
                LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", 0)
            Else
                LEDepartement.EditValue = Nothing
                LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", id_dept)
            End If

            LECountry.EditValue = Nothing
            LECountry.ItemIndex = LECountry.Properties.GetDataSourceRowIndex("id_country", id_country)
            view_region(LERegion, LECountry.EditValue.ToString)

            LERegion.EditValue = Nothing
            LERegion.ItemIndex = LERegion.Properties.GetDataSourceRowIndex("id_region", id_region)
            view_state(LEState, LERegion.EditValue.ToString)

            LEState.EditValue = Nothing
            LEState.ItemIndex = LEState.Properties.GetDataSourceRowIndex("id_state", id_state)
            view_city(LECity, LEState.EditValue.ToString)

            LECity.EditValue = Nothing
            LECity.ItemIndex = LECity.Properties.GetDataSourceRowIndex("id_city", id_city)

            LEStatus.EditValue = Nothing
            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status", is_active)

            'Updated 8 juni 2015
            TxtCommission.EditValue = data.Rows(0)("comp_commission")
            LEStoreType.ItemIndex = LEStoreType.Properties.GetDataSourceRowIndex("id_store_type", data.Rows(0)("id_store_type"))
            LEArea.ItemIndex = LEArea.Properties.GetDataSourceRowIndex("id_area", data.Rows(0)("id_area"))
            SLESalesRep.EditValue = data.Rows(0)("id_employee_rep")
            LEAllocation.ItemIndex = LEAllocation.Properties.GetDataSourceRowIndex("id_pd_alloc", data.Rows(0)("id_pd_alloc"))
            LEWHType.ItemIndex = LEWHType.Properties.GetDataSourceRowIndex("id_wh_type", data.Rows(0)("id_wh_type"))

            'update 11 Agustus 2015
            LESOType.ItemIndex = LESOType.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type"))

            'update 20 Agustus 2015
            view_mapping()
        End If
    End Sub

    Sub viewSOType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type ORDER BY id_so_type ASC "
        viewLookupQuery(LESOType, query, 0, "so_type", "id_so_type")
    End Sub
    Sub viewWHType()
        Dim query As String = "SELECT * FROM tb_lookup_wh_type ORDER BY id_wh_type ASC "
        viewLookupQuery(LEWHType, query, 0, "wh_type", "id_wh_type")
    End Sub

    Sub viewPDAlloc()
        Dim query As String = "SELECT * FROM tb_lookup_pd_alloc ORDER BY id_pd_alloc ASC "
        viewLookupQuery(LEAllocation, query, 0, "pd_alloc", "id_pd_alloc")
    End Sub

    Sub viewSalesRep()
        Dim query As String = "SELECT * FROM tb_m_employee ORDER BY employee_name ASC "
        viewSearchLookupQuery(SLESalesRep, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub view_store_type()
        Dim query As String = "SELECT * FROM tb_lookup_store_type ORDER BY id_store_type ASC "
        viewLookupQuery(LEStoreType, query, 0, "store_type", "id_store_type")
    End Sub

    Sub view_store_area()
        Dim query As String = "SELECT * FROM tb_m_area ORDER BY id_area ASC "
        viewLookupQuery(LEArea, query, 0, "area", "id_area")
    End Sub

    Private Sub LECountry_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LECountry.EditValueChanged
        Cursor = Cursors.WaitCursor
        Try
            If LECountry.EditValue <> Nothing Then
                LERegion.EditValue = Nothing
                LEState.EditValue = Nothing
                LECity.EditValue = Nothing
                view_region(LERegion, LECountry.EditValue)
                'view_state(LEState, LERegion.EditValue)
                'view_city(LECity, LEState.EditValue)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub LERegion_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LERegion.EditValueChanged
        Cursor = Cursors.WaitCursor
        Try
            If LERegion.EditValue <> Nothing Then
                LEState.EditValue = Nothing
                LECity.EditValue = Nothing
                view_state(LEState, LERegion.EditValue)
                'view_city(LECity, LEState.EditValue)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub LEState_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEState.EditValueChanged
        Cursor = Cursors.WaitCursor
        Try
            If LEState.EditValue <> Nothing Then
                LECity.EditValue = Nothing
                view_city(LECity, LEState.EditValue)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        ValidateChildren()

        Dim query As String
        Dim name As String = TECompanyName.Text
        Dim printed_name As String = TECompanyPrintedName.Text
        Dim code As String = TECompanyCode.Text
        Dim address As String = MEAddress.Text
        Dim oaddress As String = MEOAddress.Text
        Dim postal_code As String = TEPostalCode.Text
        Dim attn As String = TEAttn.Text
        Dim phone As String = TEPhone.Text
        Dim id_city As String = LECity.EditValue.ToString
        Dim id_company_category As String = LECompanyCategory.EditValue.ToString
        Dim is_active As String = LEStatus.EditValue.ToString
        Dim email As String = TEEMail.Text
        Dim web As String = TEWeb.Text
        Dim npwp As String = TENPWP.Text
        Dim fax As String = TEFax.Text
        Dim id_tax As String = LETax.EditValue.ToString
        Dim id_dept As String = LEDepartement.EditValue.ToString
        Dim id_comp_group As String = SLEGroup.EditValue.ToString
        Dim id_baru As String = ""
        '
        Dim cargo_dest As String = TECargoDest.Text
        Dim cargo_zone As String = TECargoZone.Text
        Dim cargo_code As String = TECargoCode.Text
        'update 8 juni 2015
        Dim comp_commission As String = Nothing
        Try
            comp_commission = decimalSQL(TxtCommission.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim id_store_type As String = Nothing
        Try
            id_store_type = LEStoreType.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_area As String = Nothing
        Try
            id_area = LEArea.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_employee_rep As String = Nothing
        Try
            id_employee_rep = SLESalesRep.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_pd_alloc As String = Nothing
        Try
            id_pd_alloc = LEAllocation.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_wh_type As String = Nothing
        Try
            id_wh_type = LEWHType.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_so_type As String = Nothing
        Try
            id_so_type = LESOType.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_def_drawer = "" Then
            id_def_drawer = "-1"
        End If

        If id_company = "-1" Then
            'new
            If Not formIsValidInGroup(EPCompany, GroupControl1) Or Not formIsValidInGroup(EPCompany, GroupControl2) Or Not formIsValidInGroup(EPCompany, GroupControl3) Then
                errorInput()
            Else
                'insert to company
                query = "INSERT INTO tb_m_comp(comp_name,comp_display_name,comp_number,address_primary,address_other,postal_code,email,website,id_city,id_comp_cat,is_active,id_tax,npwp,fax,id_comp_group,awb_destination,awb_zone,awb_cargo_code,id_departement, comp_commission, id_store_type, id_area, id_employee_rep, id_pd_alloc, id_wh_type, id_so_type, id_drawer_def) "
                query += "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}', "
                If id_dept = "0" Then
                    query += "NULL, "
                Else
                    query += "'" + id_dept + "', "
                End If
                If comp_commission = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + comp_commission + "', "
                End If
                If id_store_type = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_store_type + "', "
                End If
                If id_area = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_area + "', "
                End If
                If id_employee_rep = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_employee_rep + "', "
                End If
                If id_pd_alloc = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_pd_alloc + "', "
                End If
                If id_wh_type = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_wh_type + "', "
                End If
                If id_so_type = Nothing Then
                    query += "NULL, "
                Else
                    query += "'" + id_so_type + "', "
                End If
                If id_def_drawer = "-1" Then
                    query += "NULL "
                Else
                    query += "'" + id_def_drawer + "' "
                End If
                query += "); SELECT LAST_INSERT_ID(); "
                query = String.Format(query, name, printed_name, code, address, oaddress, postal_code, email, web, id_city, id_company_category, is_active, id_tax, npwp, fax, id_comp_group, cargo_dest, cargo_zone, cargo_code)

                'call last id
                id_baru = execute_query(query, 0, True, "", "", "", "")

                'insert default drawer
                Dim query_drw As String = "CALL generate_def_loc('" + id_baru + "', '" + code + "') "
                execute_non_query(query_drw, True, "", "", "", "")

                'insert to contact
                query = "INSERT INTO tb_m_comp_contact(contact_person,contact_number,is_default,id_comp)"
                query += String.Format("VALUES('{0}','{1}','{2}','{3}')", attn, phone, "1", id_baru)
                execute_non_query(query, True, "", "", "", "")

                If id_pop_up = "1" Then
                    FormPopUpContact.view_company()
                    FormPopUpContact.GVCompany.FocusedRowHandle = find_row(FormPopUpContact.GVCompany, "id_comp", id_baru)
                Else
                    FormMasterCompany.view_company()
                    FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", id_baru)
                End If

                id_company = id_baru
                infoCustom("Detail company saved.")

                action_load()
            End If
        Else
            'edit
            If Not formIsValidInGroup(EPCompany, GroupControl1) Or Not formIsValidInGroup(EPCompany, GroupControl2) Or Not formIsValidInGroup(EPCompany, GroupControl3) Then
                errorInput()
            Else
                'update company
                query = "UPDATE tb_m_comp SET comp_name='{0}',comp_display_name='{1}',comp_number='{2}',address_primary='{3}',address_other='{4}',postal_code='{5}',email='{6}',website='{7}',id_city='{8}',id_comp_cat='{9}',is_active='{10}',id_tax='{11}',npwp='{12}',fax='{13}',id_comp_group='{14}',awb_destination='{15}',awb_zone='{16}',awb_cargo_code='{17}', "
                If id_dept = "0" Then
                    query += "id_departement = NULL, "
                Else
                    query += "id_departement = '" + id_dept + "', "
                End If
                If comp_commission = Nothing Then
                    query += "comp_commission = NULL, "
                Else
                    query += "comp_commission = '" + comp_commission + "', "
                End If
                If id_store_type = Nothing Then
                    query += "id_store_type = NULL, "
                Else
                    query += "id_store_type = '" + id_store_type + "', "
                End If
                If id_area = Nothing Then
                    query += "id_area = NULL, "
                Else
                    query += "id_area = '" + id_area + "', "
                End If
                If id_employee_rep = Nothing Then
                    query += "id_employee_rep = NULL, "
                Else
                    query += "id_employee_rep = '" + id_employee_rep + "', "
                End If
                If id_pd_alloc = Nothing Then
                    query += "id_pd_alloc = NULL, "
                Else
                    query += "id_pd_alloc = '" + id_pd_alloc + "', "
                End If
                If id_wh_type = Nothing Then
                    query += "id_wh_type = NULL, "
                Else
                    query += "id_wh_type = '" + id_wh_type + "', "
                End If
                If id_so_type = Nothing Then
                    query += "id_so_type = NULL, "
                Else
                    query += "id_so_type = '" + id_so_type + "', "
                End If
                If id_def_drawer = "-1" Then
                    query += "id_drawer_def = NULL "
                Else
                    query += "id_drawer_def = '" + id_def_drawer + "' "
                End If
                query += "WHERE id_comp='" + id_company + "' "
                query = String.Format(query, name, printed_name, code, address, oaddress, postal_code, email, web, id_city, id_company_category, is_active, id_tax, npwp, fax, id_comp_group, cargo_dest, cargo_zone, cargo_code)
                execute_non_query(query, True, "", "", "", "")


                If id_pop_up = "1" Then
                    FormPopUpContact.view_company()
                    FormPopUpContact.GVCompany.FocusedRowHandle = find_row(FormPopUpContact.GVCompany, "id_comp", id_company)
                Else
                    FormMasterCompany.view_company()
                    FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", id_company)
                End If

                infoCustom("Changes saved.")
                action_load()
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub TECompanyName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompanyName.Validating
        If TECompanyName.Text.ToString.Length < 1 Then
            EPCompany.SetError(TECompanyName, "Don't leave this field blank.")
        Else
            EPCompany.SetError(TECompanyName, String.Empty)
        End If
    End Sub

    Private Sub TECompanyPrintedName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompanyPrintedName.Validating
        If TECompanyPrintedName.Text.ToString.Length < 1 Then
            EPCompany.SetError(TECompanyPrintedName, "Don't leave this field blank.")
        Else
            EPCompany.SetError(TECompanyPrintedName, String.Empty)
        End If
    End Sub

    Private Sub TEEMail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEEMail.Validating
        If TEEMail.Text = "" Then
            EPCompany.SetError(TEEMail, String.Empty)
        Else
            If Not isEmail(TEEMail.Text) Then
                EPCompany.SetError(TEEMail, "Email is not valid.")
            Else
                EPCompany.SetError(TEEMail, String.Empty)
            End If
        End If
    End Sub

    Private Sub TEPhone_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPhone.Validating
        If id_company = "-1" Then
            If Not isPhoneNumber(TEPhone.Text) Or TEPhone.Text.Length < 1 Then
                EPCompany.SetError(TEPhone, "Phone number is not valid.")
            Else
                EPCompany.SetError(TEPhone, String.Empty)
            End If
        End If
    End Sub

    Private Sub TEWeb_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEWeb.Validating
        If TEWeb.Text = "" Then
            EPCompany.SetError(TEWeb, String.Empty)
        Else
            If Not isWebsite(TEWeb.Text) Then
                EPCompany.SetError(TEWeb, "Website URL is not valid.")
            Else
                EPCompany.SetError(TEWeb, String.Empty)
            End If
        End If
    End Sub

    Private Sub TEAttn_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEAttn.Validating
        If id_company = "-1" Then
            If TEAttn.Text.Length < 1 Then
                EPCompany.SetError(TEAttn, "Don't leave this field blank.")
            Else
                EPCompany.SetError(TEAttn, String.Empty)
            End If
        End If
    End Sub

    Private Sub MEAddress_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEAddress.Validating
        EP_ME_cant_blank(EPCompany, MEAddress)
    End Sub

    Private Sub TECompanyCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompanyCode.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_comp) FROM tb_m_comp WHERE comp_number='{0}' AND id_comp!='{1}' AND id_comp_cat='" + LECompanyCategory.EditValue.ToString + "' ", TECompanyCode.Text, id_company)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPCompany, TECompanyCode, "1")
        Else
            EP_TE_cant_blank(EPCompany, TECompanyCode)
        End If
    End Sub
    Private Sub view_departement(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT '0' as id_departement,'-' as departement UNION SELECT id_departement,departement FROM tb_m_departement"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "departement"
        lookup.Properties.ValueMember = "id_departement"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_country(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_country,country FROM tb_m_country"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "country"
        lookup.Properties.ValueMember = "id_country"
        lookup.ItemIndex = 0
        If data.Rows.Count > 0 Then
            view_region(LERegion, lookup.EditValue)
        End If
    End Sub
    Private Sub view_region(ByVal lookup As DevExpress.XtraEditors.LookUpEdit, ByVal id_country As String)
        Dim query As String = String.Format("SELECT id_region,region FROM tb_m_region WHERE id_country='{0}'", id_country)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "region"
        lookup.Properties.ValueMember = "id_region"
        lookup.ItemIndex = 0

        If data.Rows.Count > 0 Then
            view_state(LEState, lookup.EditValue)
        End If
    End Sub
    Private Sub view_state(ByVal lookup As DevExpress.XtraEditors.LookUpEdit, ByVal id_region As String)
        Dim query As String = String.Format("SELECT id_state,state FROM tb_m_state WHERE id_region='{0}'", id_region)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "state"
        lookup.Properties.ValueMember = "id_state"
        lookup.ItemIndex = 0
        If data.Rows.Count > 0 Then
            view_city(LECity, lookup.EditValue)
        End If
    End Sub
    Private Sub view_city(ByVal lookup As DevExpress.XtraEditors.LookUpEdit, ByVal id_state As String)
        Dim query As String = String.Format("SELECT id_city,city FROM tb_m_city WHERE id_state='{0}'", id_state)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "city"
        lookup.Properties.ValueMember = "id_city"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_category(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_comp_cat,comp_cat_name FROM tb_m_comp_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "comp_cat_name"
        lookup.Properties.ValueMember = "id_comp_cat"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_tax(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_tax,tax FROM tb_lookup_tax"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "tax"
        lookup.Properties.ValueMember = "id_tax"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status,status FROM tb_lookup_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status"
        lookup.Properties.ValueMember = "id_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BGroupComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGroupComp.Click
        FormPopUpCompGroup.ShowDialog()
    End Sub

    Sub view_comp_group()
        Dim query As String = "SELECT id_comp_group,comp_group FROM tb_m_comp_group "
        viewSearchLookupQuery(SLEGroup, query, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        view_comp_group()
    End Sub

    Sub setNothingLE(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        lookup.EditValue = Nothing
    End Sub

    Sub setNothingSLE(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        lookup.EditValue = Nothing
    End Sub

    Private Sub BtnClearStoreType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearStoreType.Click
        setNothingLE(LEStoreType)
    End Sub

    Private Sub BtnClearLEArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearLEArea.Click
        setNothingLE(LEArea)
    End Sub

    Private Sub BtnClearSalesRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearSalesRep.Click
        setNothingSLE(SLESalesRep)
    End Sub

    Private Sub BtnClearAllocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearAllocation.Click
        setNothingLE(LEAllocation)
    End Sub

    Private Sub BtnWHType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWHType.Click
        setNothingLE(LEWHType)
    End Sub

    Sub view_mapping()
        Dim query = "SELECT id_coa_map,coa_map FROM tb_coa_map"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCoaTrans.DataSource = data
        If data.Rows.Count > 0 Then
            view_mapping_acc(id_company, GVCoaTrans.GetFocusedRowCellValue("id_coa_map").ToString)
        End If
    End Sub
    Sub view_mapping_acc(ByVal id_comp As String, ByVal id_coa_map As String)
        Dim query = "SELECT coa_map_d.id_coa_map_det,coa_map_d.coa_map_det,comp_coa.id_acc,comp_coa.id_comp_coa,coa.acc_name,coa.acc_description  FROM tb_coa_map_det coa_map_d"
        query += " INNER JOIN tb_coa_map coa_map ON coa_map.id_coa_map=coa_map_d.id_coa_map"
        query += " LEFT JOIN tb_m_comp_coa comp_coa ON comp_coa.id_coa_map_det=coa_map_d.id_coa_map_det AND id_comp='" + id_comp + "'"
        query += " LEFT JOIN tb_a_acc coa ON coa.id_acc=comp_coa.id_acc"
        query += " WHERE coa_map_d.id_coa_map='" + id_coa_map + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCoaMapping.DataSource = data
    End Sub

    Private Sub GVCoaMapping_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCoaMapping.DoubleClick
        If GVCoaMapping.RowCount > 0 Then
            FormPopUpCOA.id_pop_up = "7"
            FormPopUpCOA.ShowDialog()
        End If
    End Sub

    Private Sub GVCoaTrans_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCoaTrans.FocusedRowChanged
        If GVCoaTrans.RowCount > 0 Then
            view_mapping_acc(id_company, GVCoaTrans.GetFocusedRowCellValue("id_coa_map").ToString)
        Else
            view_mapping_acc("-1", "-1")
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "4"
        FormPopUpDrawer.id_comp = id_company
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub BClearDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClearDrawer.Click
        TEDefDrawer.Text = ""
        id_def_drawer = "-1"
    End Sub

End Class