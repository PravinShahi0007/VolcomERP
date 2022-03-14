﻿Public Class FormMasterCompanySingle
    Public id_company As String
    Public id_pop_up As String = "-1"
    Public id_def_drawer As String = "-1"
    '
    Public is_view As String = "-1"
    Dim id_vendor_type As String = "-1"
    '
    Public is_need_bank_account As String = "-1"
    '
    Public id_comp_group_add As String = "-1"
    Public is_add_other As String = "-1"
    '
    Public is_accounting As Boolean = False
    '
    '
    Dim data_map As DataTable

    Private Sub FormMasterCompanySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not id_comp_group_add = "-1" Then
            FormPopUpCompGroup.view_comp_group()

            FormPopUpCompGroup.GVGroupComp.FocusedRowHandle = find_row(FormPopUpCompGroup.GVGroupComp, "id_comp_group", id_comp_group_add)
        End If

        Dispose()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAR, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAP, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEDP, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub FormMasterCompanySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FormMasterCompany.is_accounting Then
            is_accounting = True
        End If

        action_load()

        '
        GroupControlDesc.CausesValidation = True
        GCAddress.CausesValidation = True
        GCCP.CausesValidation = True
        '

        If id_comp_group_add = "-1" Then
            GroupControlStoreGroup.Visible = False

            Size = New Size(Size.Width, Size.Height - 56)
        End If
    End Sub

    Sub load_contract_template()
        Dim query As String = "SELECT id_ko_template,description,`year` FROM `tb_ko_template`"
        viewLookupQuery(LEContractTemplate, query, 0, "description", "id_ko_template")
    End Sub

    Sub load_vendor_type()
        Dim query As String = "SELECT id_vendor_type,vendor_type FROM tb_vendor_type"
        viewSearchLookupQuery(SLEVendorType, query, "id_vendor_type", "vendor_type", "id_vendor_type")
    End Sub

    Sub load_annotation()
        Dim query As String = "SELECT id_annotation,annotation FROM tb_lookup_annotation"
        viewSearchLookupQuery(SLEAnnotation, query, "id_annotation", "annotation", "id_annotation")
    End Sub

    Sub load_kode_bank()
        Dim where_country As String = ""

        If LECountry.EditValue.ToString = "5" Then
            where_country = "WHERE id!=0"
        End If

        Dim query As String = "SELECT id,nama_bank,kode_bank FROM `tb_kode_bank` " + where_country
        viewSearchLookupQuery(SLEBankAccount, query, "id", "nama_bank", "id")
    End Sub

    Sub action_load()
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCCompany.TabPages
            XTCCompany.SelectedTabPage = t
        Next t
        '
        XTCCompany.SelectedTabPage = XTCCompany.TabPages(0)
        'LE/SLE
        viewCOA()
        view_comp_group()
        view_store_company()
        view_country(LECountry)
        view_category(LECompanyCategory)
        view_status(LEStatus)
        view_tax(LETax)
        view_departement(LEDepartement)
        view_store_type()
        view_store_area()
        viewCommerceType()
        viewSalesRep()
        viewPDAlloc()
        viewWHType()
        viewSOType()
        viewLegal()
        load_annotation()
        load_contract_template()
        load_vendor_type()
        load_kode_bank()
        view_status_pabean()
        'default value
        TxtCommission.EditValue = 0.0
        LEStoreType.EditValue = Nothing
        LEArea.EditValue = Nothing
        LECommerceType.EditValue = Nothing
        SLESalesRep.EditValue = Nothing
        LEAllocation.EditValue = Nothing
        LESOType.EditValue = Nothing
        LEWHType.EditValue = Nothing

        'add contact group
        If id_comp_group_add = "-1" Then
            id_comp_group_add = If(id_company = "-1", "-1", execute_query("SELECT IFNULL((SELECT id_comp_group FROM tb_m_comp_group WHERE id_comp = " + id_company + "), -1) AS id_comp_group_add", 0, True, "", "", "", ""))
        End If

        If id_comp_group_add = "-1" Then
            'GroupControlStoreGroup.Visible = False

            'Size = New Size(Size.Width, Size.Height - 56)
        Else
            Dim query As String = "SELECT comp_group, description FROM tb_m_comp_group WHERE id_comp_group = " + id_comp_group_add
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TECompGroup.EditValue = data.Rows(0)("comp_group").ToString
            TECompGroupDescription.EditValue = data.Rows(0)("description").ToString
        End If

        If id_company = "-1" Then
            'new
            XTPSetup.PageVisible = False
            XTPLegal.PageVisible = False
            BCPSetup.Visible = False
            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status", "3")
            '
            BApproval.Visible = False
            BPrint.Visible = False

            'add contact group
            If Not id_comp_group_add = "-1" Then
                LECompanyCategory.ItemIndex = LECompanyCategory.Properties.GetDataSourceRowIndex("id_comp_cat", "2")
                LECompanyCategory.ReadOnly = True
            End If
            '
            XTPCOA.PageVisible = False

            'store list
            If FormMasterCompany.is_store = "1" Then
                LECompanyCategory.ItemIndex = LECompanyCategory.Properties.GetDataSourceRowIndex("id_comp_cat", "6")
                LECompanyCategory.Enabled = False
            End If
        Else
            'edit
            XTPLegal.PageVisible = True
            BCPSetup.Visible = True
            BApproval.Visible = True
            BPrint.Visible = True
            '

            Dim query As String = String.Format("SELECT comp.*,acc_ap.acc_name AS ap_name,acc_ar.acc_name AS ar_name,acc_dp.acc_name As dp_name,ccat.is_need_bank_account,ccat.is_advance_setup,drawer.wh_drawer 
,acc_ap_cabang.acc_name AS ap_cabang_name,acc_ar_cabang.acc_name AS ar_cabang_name,acc_dp_cabang.acc_name As dp_cabang_name
FROM tb_m_comp comp 
LEFT JOIN tb_m_wh_drawer drawer ON drawer.id_wh_drawer=comp.id_drawer_def 
INNER JOIN tb_m_comp_cat ccat ON ccat.id_comp_cat=comp.id_comp_cat
LEFT JOIN tb_a_acc acc_ap ON acc_ap.id_acc=comp.id_acc_ap
LEFT JOIN tb_a_acc acc_dp ON acc_dp.id_acc=comp.id_acc_dp
LEFT JOIN tb_a_acc acc_ar ON acc_ar.id_acc=comp.id_acc_ar 
LEFT JOIN tb_a_acc acc_ap_cabang ON acc_ap_cabang.id_acc=comp.id_acc_cabang_ap
LEFT JOIN tb_a_acc acc_dp_cabang ON acc_dp_cabang.id_acc=comp.id_acc_cabang_dp
LEFT JOIN tb_a_acc acc_ar_cabang ON acc_ar_cabang.id_acc=comp.id_acc_cabang_ar 
WHERE comp.id_comp = '{0}'", id_company)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim id_company_category As String = data.Rows(0)("id_comp_cat").ToString
            '
            If id_company_category = "1" Then 'vendor FG
                PCVendorLegal.Visible = True
            Else
                PCVendorLegal.Visible = False
            End If
            '
            If data.Rows(0)("id_acc_ar").ToString = "" Then
                SLEAR.EditValue = Nothing
            Else
                SLEAR.EditValue = data.Rows(0)("id_acc_ar").ToString
                TxtARCode.Text = data.Rows(0)("ar_name").ToString
            End If
            '
            If data.Rows(0)("id_acc_ap").ToString = "" Then
                SLEAP.EditValue = Nothing
            Else
                SLEAP.EditValue = data.Rows(0)("id_acc_ap").ToString
                TxtAPCode.Text = data.Rows(0)("ap_name").ToString
            End If
            '
            If data.Rows(0)("id_acc_dp").ToString = "" Then
                SLEDP.EditValue = Nothing
            Else
                SLEDP.EditValue = data.Rows(0)("id_acc_dp").ToString
                TxtDPCode.Text = data.Rows(0)("dp_name").ToString
            End If

            If data.Rows(0)("id_acc_cabang_ar").ToString = "" Then
                SLEARCabang.EditValue = Nothing
            Else
                SLEARCabang.EditValue = data.Rows(0)("id_acc_cabang_ar").ToString
                TxtARCodeCabang.Text = data.Rows(0)("ar_cabang_name").ToString
            End If
            '
            If data.Rows(0)("id_acc_cabang_ap").ToString = "" Then
                SLEAPCabang.EditValue = Nothing
            Else
                SLEAPCabang.EditValue = data.Rows(0)("id_acc_cabang_ap").ToString
                TxtAPCodeCabang.Text = data.Rows(0)("ap_cabang_name").ToString
            End If
            '
            If data.Rows(0)("id_acc_cabang_dp").ToString = "" Then
                SLEDPCabang.EditValue = Nothing
            Else
                SLEDPCabang.EditValue = data.Rows(0)("id_acc_cabang_dp").ToString
                TxtDPCodeCabang.Text = data.Rows(0)("dp_cabang_name").ToString
            End If

            Dim id_city As String = data.Rows(0)("id_city").ToString
            Dim id_sub_district As String = data.Rows(0)("id_sub_district").ToString
            Dim company_name As String = data.Rows(0)("comp_name").ToString
            Dim company_code As String = data.Rows(0)("comp_number").ToString
            Dim company_printed_name As String = data.Rows(0)("comp_display_name").ToString
            Dim address_primary As String = data.Rows(0)("address_primary").ToString
            Dim address_other As String = data.Rows(0)("address_other").ToString
            Dim postal_code As String = data.Rows(0)("postal_code").ToString
            Dim email As String = data.Rows(0)("email").ToString
            Dim website As String = data.Rows(0)("website").ToString
            Dim bank_rek As String = data.Rows(0)("bank_rek").ToString
            Dim bank_atas_nama As String = data.Rows(0)("bank_attn_name").ToString
            Dim bank_address As String = data.Rows(0)("bank_address").ToString
            Dim is_active As String = data.Rows(0)("is_active").ToString
            Dim id_tax As String = data.Rows(0)("id_tax").ToString
            Dim npwp As String = data.Rows(0)("npwp").ToString
            Dim fax As String = data.Rows(0)("fax").ToString
            Dim phone As String = data.Rows(0)("phone").ToString
            Dim id_dept As String = data.Rows(0)("id_departement").ToString
            Dim id_comp_group As String = data.Rows(0)("id_comp_group").ToString
            Dim id_vendor_type As String = data.Rows(0)("id_vendor_type").ToString
            Dim id_bank As String = data.Rows(0)("id_bank").ToString
            '
            If is_active = "3" And is_accounting = False Then
                XTPCOA.PageVisible = False
            Else
                XTPCOA.PageVisible = True
                If is_accounting = False Then
                    BCreateCOA.Visible = False
                Else
                    BCreateCOA.Visible = True
                End If
            End If
            '
            is_need_bank_account = data.Rows(0)("is_need_bank_account").ToString
            '
            id_def_drawer = data.Rows(0)("id_drawer_def").ToString
            TEDefDrawer.Text = data.Rows(0)("wh_drawer").ToString
            '
            TECargoDest.Text = data.Rows(0)("awb_destination").ToString
            TECargoZone.Text = data.Rows(0)("awb_zone").ToString
            TECargoCode.Text = data.Rows(0)("awb_cargo_code").ToString
            '
            TENPWPName.Text = data.Rows(0)("npwp_name").ToString
            TENPWPAddress.Text = data.Rows(0)("npwp_address").ToString
            '
            SLEGroup.EditValue = id_comp_group
            view_store_company()
            SLEStoreCompany.EditValue = data.Rows(0)("id_store_company").ToString
            SLEVendorType.EditValue = id_vendor_type

            data.Dispose()

            Dim id_state As String = get_state(id_city.ToString)
            Dim id_region As String = get_region(id_state.ToString)
            Dim id_country As String = get_country(id_region.ToString)

            Dim id_status_pabean As String = data.Rows(0)("id_status_pabean").ToString
            SLUEStatusPabean.EditValue = id_status_pabean

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
            TEPhoneComp.Text = phone
            '
            TEBankRek.Text = bank_rek
            TEBankAtasNama.Text = bank_atas_nama
            TEBankAddress.Text = bank_address

            Dim id_comp_contact As String = "-1"
            id_comp_contact = get_company_x(id_company, "6")

            TECPPhone.Text = get_company_contact_x(id_comp_contact, "2")
            TECPPhone.Enabled = False
            TECPName.Text = get_company_contact_x(id_comp_contact, "1")
            TECPName.Enabled = False
            TECPEmail.Text = get_company_contact_x(id_comp_contact, "4")
            TECPEmail.Enabled = False
            TECPPosition.Text = get_company_contact_x(id_comp_contact, "5")
            TECPPosition.Enabled = False
            SLEAnnotation.EditValue = get_company_contact_x(id_comp_contact, "6")
            SLEAnnotation.Enabled = False

            LECompanyCategory.EditValue = Nothing
            LECompanyCategory.ItemIndex = LECompanyCategory.Properties.GetDataSourceRowIndex("id_comp_cat", id_company_category)
            LECompanyCategory.Enabled = False

            If data.Rows(0)("is_advance_setup").ToString = "1" Then
                XTPSetup.PageVisible = True
            Else
                XTPSetup.PageVisible = False
            End If

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
            view_district(LEDistrict, LECity.EditValue.ToString)

            LEDistrict.EditValue = Nothing
            LEDistrict.ItemIndex = LEDistrict.Properties.GetDataSourceRowIndex("id_sub_district", id_sub_district)

            LEStatus.EditValue = Nothing
            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status", is_active)

            SLEBankAccount.EditValue = id_bank

            'Updated 8 juni 2015
            TxtCommission.EditValue = data.Rows(0)("comp_commission")
            LEStoreType.ItemIndex = LEStoreType.Properties.GetDataSourceRowIndex("id_store_type", data.Rows(0)("id_store_type"))
            LEArea.ItemIndex = LEArea.Properties.GetDataSourceRowIndex("id_area", data.Rows(0)("id_area"))
            LECommerceType.ItemIndex = LECommerceType.Properties.GetDataSourceRowIndex("id_commerce_type", data.Rows(0)("id_commerce_type"))
            SLESalesRep.EditValue = data.Rows(0)("id_employee_rep")
            LEAllocation.ItemIndex = LEAllocation.Properties.GetDataSourceRowIndex("id_pd_alloc", data.Rows(0)("id_pd_alloc"))
            LEWHType.ItemIndex = LEWHType.Properties.GetDataSourceRowIndex("id_wh_type", data.Rows(0)("id_wh_type"))

            'update 11 Agustus 2015
            LESOType.ItemIndex = LESOType.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type"))

            'update 20 Agustus 2015
            'view_mapping()

            'load button approval
            BPrint.Visible = True

            BResetMark.Visible = False

            If is_active = "1" Or is_active = "2" Then
                BApproval.Visible = False
                If Not is_view = "1" Then
                    BResetMark.Visible = True
                End If
            Else
                BApproval.Visible = True
                '
                BApproval.Visible = True
                If LEStatus.EditValue.ToString = "3" Then
                    BApproval.Text = "Submit"
                Else
                    BApproval.Text = "Approval"

                    If Not is_view = "1" Then
                        BResetMark.Visible = True
                    End If
                End If
            End If
            '
            If is_view = "1" Then
                BCPSetup.Visible = False
            End If
            '
            If LEStatus.EditValue.ToString = "3" Then 'created
                BSave.Visible = True
                BAddLegal.Visible = True
                BDeleteLegal.Visible = True
            Else
                BSave.Visible = False
                BAddLegal.Visible = False
                BDeleteLegal.Visible = False
            End If

            'store display capacity
            viewDisplayCapacity()
            viewDCHist()
            Dim is_show_display_capacity As String = get_setup_field("is_show_display_capacity")
            If is_show_display_capacity = "2" Then
                GroupControlDC.Visible = False
            End If
        End If
    End Sub

    Sub viewLegal()
        Dim query As String = "SELECT '0' AS id_legal_type,'ALL' AS legal_type UNION SELECT id_legal_type,legal_type FROM tb_lookup_legal_type WHERE is_active='1' "
        viewLookupQuery(LELegalType, query, 0, "legal_type", "id_legal_type")
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

    Sub viewCommerceType()
        Dim query As String = "SELECT * FROM tb_lookup_commerce_type ct ORDER BY ct.id_commerce_type ASC "
        viewLookupQuery(LECommerceType, query, 0, "commerce_type", "id_commerce_type")
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
                LEDistrict.EditValue = Nothing
                view_region(LERegion, LECountry.EditValue)
                load_kode_bank()
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
                LEDistrict.EditValue = Nothing
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
                LEDistrict.EditValue = Nothing
                view_city(LECity, LEState.EditValue)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        EP_TE_cant_blank(EPCompany, TECompanyName)
        EP_TE_cant_blank(EPCompany, TECompanyCode)
        EP_TE_cant_blank(EPCompany, TECompanyPrintedName)

        EP_TE_cant_blank(EPCompany, TEPhoneComp)
        EP_TE_cant_blank(EPCompany, TEEMail)
        EP_ME_cant_blank(EPCompany, MEAddress)

        EP_TE_cant_blank(EPCompany, TECPEmail)
        EP_TE_cant_blank(EPCompany, TECPName)
        EP_TE_cant_blank(EPCompany, TECPPhone)

        TECompanyCode_Validating(TECompanyCode, New System.ComponentModel.CancelEventArgs)

        Dim query As String
        Dim name As String = addSlashes(TECompanyName.Text)
        Dim printed_name As String = addSlashes(TECompanyPrintedName.Text)
        Dim code As String = addSlashes(TECompanyCode.Text)
        Dim address As String = addSlashes(MEAddress.Text)
        Dim oaddress As String = addSlashes(MEOAddress.Text)
        Dim postal_code As String = addSlashes(TEPostalCode.Text)
        Dim id_city As String = LECity.EditValue.ToString
        Dim id_sub_district As String = LEDistrict.EditValue.ToString
        Dim id_company_category As String = LECompanyCategory.EditValue.ToString
        Dim is_active As String = LEStatus.EditValue.ToString
        Dim email As String = addSlashes(TEEMail.Text)
        Dim web As String = addSlashes(TEWeb.Text)
        Dim npwp As String = addSlashes(TENPWP.Text)
        Dim fax As String = addSlashes(TEFax.Text)
        Dim phone As String = addSlashes(TEPhoneComp.Text)
        Dim id_tax As String = LETax.EditValue.ToString
        Dim id_dept As String = LEDepartement.EditValue.ToString
        Dim id_comp_group As String = SLEGroup.EditValue.ToString
        Dim id_vendor_type As String = SLEVendorType.EditValue.ToString
        Dim id_baru As String = ""
        '
        Dim id_bank As String = SLEBankAccount.EditValue.ToString
        Dim bank_rek As String = addSlashes(TEBankRek.Text)
        Dim bank_atas_nama As String = addSlashes(TEBankAtasNama.Text)
        Dim bank_address As String = addSlashes(TEBankAddress.Text)
        '
        Dim annotation As String = SLEAnnotation.EditValue.ToString
        Dim contact_name As String = addSlashes(TECPName.Text)
        Dim contact_phone As String = addSlashes(TECPPhone.Text)
        Dim contact_position As String = addSlashes(TECPPosition.Text)
        Dim contact_email As String = addSlashes(TECPEmail.Text)
        '
        Dim npwp_name As String = addSlashes(TENPWPName.Text)
        Dim npwp_address As String = addSlashes(TENPWPAddress.Text)
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

        Dim id_commerce_type As String = Nothing
        Try
            id_commerce_type = LECommerceType.EditValue.ToString
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

        Dim id_store_company As String = "0"
        Try
            id_store_company = SLEStoreCompany.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_status_pabean As String = SLUEStatusPabean.EditValue.ToString

        If id_company = "-1" Then
            'new
            If Not (id_company_category = "5" Or id_company_category = "6") And id_tax = 1 Then
                warningCustom("Please put PKP or Non PKP")
            ElseIf Not formIsValidInGroup(EPCompany, GroupControlDesc) Or Not formIsValidInGroup(EPCompany, GCAddress) Or Not formIsValidInGroup(EPCompany, GCCP) Then
                errorInput()
            Else
                'insert to company
                query = "INSERT INTO tb_m_comp(comp_name,comp_display_name,comp_number,address_primary,address_other,postal_code,email,website,id_city,id_comp_cat,is_active,id_tax,npwp,fax,id_comp_group,awb_destination,awb_zone,awb_cargo_code, phone, id_vendor_type,id_bank,bank_rek,bank_attn_name,bank_address,npwp_name,npwp_address, id_departement, comp_commission, id_store_type, id_area, id_employee_rep, id_pd_alloc, id_wh_type, id_so_type, id_drawer_def,id_store_company,id_sub_district,id_coa_tag,id_status_pabean) "
                query += "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}',"
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
                    query += "NULL, "
                Else
                    query += "'" + id_def_drawer + "', "
                End If
                If id_store_company = "0" Or id_store_company = "" Then
                    query += "NULL, "
                Else
                    query += "'" + id_store_company + "', "
                End If
                query += "'" + id_sub_district + "','1' "
                query += "," + id_status_pabean + ""
                query += "); SELECT LAST_INSERT_ID(); "
                query = String.Format(query, name, printed_name, code, address, oaddress, postal_code, email, web, id_city, id_company_category, is_active, id_tax, npwp, fax, id_comp_group, cargo_dest, cargo_zone, cargo_code, phone, id_vendor_type, id_bank, bank_rek, bank_atas_nama, bank_address, npwp_name, npwp_address)

                'call last id
                id_baru = execute_query(query, 0, True, "", "", "", "")

                'insert default drawer
                If id_company_category = "5" Or id_company_category = "6" Then
                    Dim query_drw As String = "CALL generate_def_loc('" + id_baru + "', '" + code + "') "
                    execute_non_query(query_drw, True, "", "", "", "")
                End If

                'insert to contact
                query = "INSERT INTO tb_m_comp_contact(contact_person,contact_number,email,position,is_default,id_comp,id_annotation)"
                query += String.Format("VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", contact_name, contact_phone, contact_email, contact_position, "1", id_baru, annotation)
                execute_non_query(query, True, "", "", "", "")

                If id_pop_up = "1" Then
                    FormPopUpContact.view_company()
                    FormPopUpContact.GVCompany.FocusedRowHandle = find_row(FormPopUpContact.GVCompany, "id_comp", id_baru)
                Else
                    FormMasterCompany.view_company()
                    FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", id_baru)
                End If

                'add contact group
                If Not id_comp_group_add = "-1" And is_add_other = "-1" Then
                    query = "UPDATE tb_m_comp_group SET id_comp = " + id_baru + " WHERE id_comp_group = " + id_comp_group_add
                    execute_non_query(query, True, "", "", "", "")
                End If

                id_company = id_baru

                'another company
                If is_add_other = "1" Then
                    query = "INSERT tb_m_comp_group_other (id_comp_group, id_comp) VALUES ('" + id_comp_group_add + "', '" + id_company + "')"
                    execute_non_query(query, True, "", "", "", "")
                End If

                infoCustom("Detail company saved.")

                action_load()
            End If
        Else
            'edit
            If Not (id_company_category = "5" Or id_company_category = "6") And id_tax = 1 Then
                warningCustom("Please put PKP or Non PKP")
            ElseIf Not formIsValidInGroup(EPCompany, GroupControlDesc) Or Not formIsValidInGroup(EPCompany, GCAddress) Or Not formIsValidInGroup(EPCompany, GCCP) Then
                errorInput()
            Else
                'update company
                query = "UPDATE tb_m_comp SET comp_name='{0}',comp_display_name='{1}',comp_number='{2}',address_primary='{3}',address_other='{4}',postal_code='{5}',email='{6}',website='{7}',id_city='{8}',id_comp_cat='{9}',is_active='{10}',id_tax='{11}',npwp='{12}',fax='{13}',id_comp_group='{14}',awb_destination='{15}',awb_zone='{16}',awb_cargo_code='{17}',phone='{18}',id_vendor_type='{19}',id_bank='{20}',bank_rek='{21}',bank_attn_name='{22}',bank_address='{23}',npwp_name='{24}',npwp_address='{25}', "
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
                If id_commerce_type = Nothing Then
                    query += "id_commerce_type = NULL, "
                Else
                    query += "id_commerce_type = '" + id_commerce_type + "', "
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
                    query += "id_drawer_def = NULL, "
                Else
                    query += "id_drawer_def = '" + id_def_drawer + "', "
                End If
                If id_store_company = "0" Or id_store_company = "" Then
                    query += "id_store_company = NULL, "
                Else
                    query += "id_store_company = '" + id_store_company + "', "
                End If
                Try
                    If SLEAP.EditValue = Nothing Or SLEAP.EditValue.ToString = "" Then
                        query += "id_acc_ap = NULL, "
                    Else
                        query += "id_acc_ap = '" + SLEAP.EditValue.ToString + "', "
                    End If
                Catch ex As Exception
                    query += "id_acc_ap = NULL, "
                End Try
                Try
                    If SLEDP.EditValue = Nothing Or SLEDP.EditValue.ToString = "" Then
                        query += "id_acc_dp = NULL, "
                    Else
                        query += "id_acc_dp = '" + SLEDP.EditValue.ToString + "', "
                    End If
                Catch ex As Exception
                    query += "id_acc_dp = NULL, "
                End Try
                Try
                    If SLEAR.EditValue = Nothing Or SLEAR.EditValue.ToString = "" Then
                        query += "id_acc_ar = NULL, "
                    Else
                        query += "id_acc_ar = '" + SLEAR.EditValue.ToString + "', "
                    End If
                Catch ex As Exception
                    query += "id_acc_ar = NULL, "
                End Try

                query += "id_sub_district='" + id_sub_district + "'"
                query += ",id_status_pabean='" + id_status_pabean + "'"
                query += "WHERE id_comp='" + id_company + "' "
                query = String.Format(query, name, printed_name, code, address, oaddress, postal_code, email, web, id_city, id_company_category, is_active, id_tax, npwp, fax, id_comp_group, cargo_dest, cargo_zone, cargo_code, phone, id_vendor_type, id_bank, bank_rek, bank_atas_nama, bank_address, npwp_name, npwp_address)
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
        If Not isEmail(TEEMail.Text) Or TEEMail.Text.Length < 1 Then
            EPCompany.SetError(TEEMail, "Email is not valid.")
        Else
            EPCompany.SetError(TEEMail, String.Empty)
        End If
    End Sub

    Private Sub TEPhone_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECPPhone.Validating
        If id_company = "-1" Then
            If Not isPhoneNumber(TECPPhone.Text) Or TECPPhone.Text.Length < 1 Then
                EPCompany.SetError(TECPPhone, "Phone number is not valid.")
            Else
                EPCompany.SetError(TECPPhone, String.Empty)
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

    Private Sub TEAttn_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECPName.Validating
        If id_company = "-1" Then
            If TECPName.Text.Length < 1 Then
                EPCompany.SetError(TECPName, "Don't leave this field blank.")
            Else
                EPCompany.SetError(TECPName, String.Empty)
            End If
        End If
    End Sub

    Private Sub MEAddress_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEAddress.Validating
        EP_ME_cant_blank(EPCompany, MEAddress)
    End Sub

    Private Sub TECompanyCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompanyCode.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_comp) FROM tb_m_comp WHERE comp_number='{0}' AND id_comp!='{1}' AND id_comp_cat='" + LECompanyCategory.EditValue.ToString + "' ", addSlashes(TECompanyCode.Text), id_company)
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
    Private Sub view_district(ByVal lookup As DevExpress.XtraEditors.LookUpEdit, ByVal id_city As String)
        Dim query As String = String.Format("SELECT id_sub_district,sub_district FROM tb_m_sub_district WHERE id_city='{0}'", id_city)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "sub_district"
        lookup.Properties.ValueMember = "id_sub_district"
        lookup.ItemIndex = 0
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
        Dim query As String = "SELECT id_comp_cat,comp_cat_name FROM tb_m_comp_cat ORDER BY id_comp_cat DESC"
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
        Dim query As String = "SELECT id_comp_status AS id_status,comp_status AS status FROM tb_lookup_comp_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status"
        lookup.Properties.ValueMember = "id_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BGroupComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGroupComp.Click
        FormPopUpCompGroup.Close()

        FormPopUpCompGroup.ShowDialog()
    End Sub

    Sub view_comp_group()
        Dim query As String = "SELECT id_comp_group,comp_group,description FROM tb_m_comp_group "
        viewSearchLookupQuery(SLEGroup, query, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_store_company()
        Dim query As String = "
            SELECT 0 AS id_comp_group, 0 AS id_comp, '' AS comp_number, '' AS comp_name
            UNION ALL
            SELECT cother.id_comp_group, comp.id_comp, comp.comp_number, comp.comp_name
            FROM tb_m_comp_group_other AS cother
            LEFT JOIN tb_m_comp AS comp ON cother.id_comp = comp.id_comp
            WHERE cother.id_comp_group = " + SLEGroup.EditValue.ToString + " AND comp.is_active = 1
            UNION ALL
            SELECT cgroup.id_comp_group, comp.id_comp, comp.comp_number, comp.comp_name
            FROM tb_m_comp_group AS cgroup
            LEFT JOIN tb_m_comp AS comp ON cgroup.id_comp = comp.id_comp
            WHERE cgroup.id_comp_group = " + SLEGroup.EditValue.ToString + " AND cgroup.id_comp IS NOT NULL AND comp.is_active = 1
        "
        viewSearchLookupQuery(SLEStoreCompany, query, "id_comp", "comp_name", "id_comp")
        Dim tmp_comp As String = execute_query("SELECT IFNULL(id_comp, 0) AS id_comp FROM tb_m_comp_group WHERE id_comp_group = " + SLEGroup.EditValue.ToString, 0, True, "", "", "", "")
        SLEStoreCompany.EditValue = tmp_comp
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

    'Sub view_mapping()
    '    Dim query = "SELECT id_coa_map,coa_map FROM tb_coa_map"
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCCoaTrans.DataSource = data
    '    If data.Rows.Count > 0 Then
    '        view_mapping_acc(id_company, GVCoaTrans.GetFocusedRowCellValue("id_coa_map").ToString)
    '    End If
    'End Sub
    'Sub view_mapping_acc(ByVal id_comp As String, ByVal id_coa_map As String)
    '    Dim query = "SELECT coa_map_d.id_coa_map_det,coa_map_d.coa_map_det,comp_coa.id_acc,comp_coa.id_comp_coa,coa.acc_name,coa.acc_description  FROM tb_coa_map_det coa_map_d"
    '    query += " INNER JOIN tb_coa_map coa_map ON coa_map.id_coa_map=coa_map_d.id_coa_map"
    '    query += " LEFT JOIN tb_m_comp_coa comp_coa ON comp_coa.id_coa_map_det=coa_map_d.id_coa_map_det AND id_comp='" + id_comp + "'"
    '    query += " LEFT JOIN tb_a_acc coa ON coa.id_acc=comp_coa.id_acc"
    '    query += " WHERE coa_map_d.id_coa_map='" + id_coa_map + "'"
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCCoaMapping.DataSource = data
    'End Sub

    'Private Sub GVCoaMapping_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If GVCoaMapping.RowCount > 0 Then
    '        FormPopUpCOA.id_pop_up = "7"
    '        FormPopUpCOA.ShowDialog()
    '    End If
    'End Sub

    'Private Sub GVCoaTrans_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
    '    If GVCoaTrans.RowCount > 0 Then
    '        view_mapping_acc(id_company, GVCoaTrans.GetFocusedRowCellValue("id_coa_map").ToString)
    '    Else
    '        view_mapping_acc("-1", "-1")
    '    End If
    'End Sub

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

    Private Sub BClearSOType_Click(sender As Object, e As EventArgs) Handles BClearSOType.Click

    End Sub

    Private Sub BCommerceType_Click(sender As Object, e As EventArgs) Handles BCommerceType.Click
        setNothingLE(LECommerceType)
    End Sub

    Private Sub BViewLegal_Click(sender As Object, e As EventArgs) Handles BViewLegal.Click
        load_legal()
    End Sub

    Sub load_legal()
        Dim query_where As String = ""
        If Not LELegalType.EditValue.ToString = 0 Then
            query_where = " AND lgl.id_legal_type='" & LELegalType.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT lgl.id_comp_legal,lgl.ext,lglt.`legal_type`,lgl.`number`,lgl.`active_until`,lgl.`upload_datetime`,emp.`employee_name`,lgl.id_comp_legal,CONCAT(lgl.id_comp_legal,lgl.ext) AS filename,lgl.file_name FROM `tb_m_comp_legal` lgl
INNER JOIN tb_lookup_legal_type lglt ON lglt.`id_legal_type`=lgl.`id_legal_type`
INNER JOIN tb_m_user usr ON usr.`id_user`=lgl.`upload_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE lgl.`id_comp`='" & id_company & "'" & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLegal.DataSource = data
        GVLegal.BestFitColumns()
        If GVLegal.RowCount > 0 And Not is_view = "1" And LEStatus.EditValue.ToString = "3" Then
            BDeleteLegal.Visible = True
        Else
            BDeleteLegal.Visible = False
        End If
    End Sub

    Private Sub BAddLegal_Click(sender As Object, e As EventArgs) Handles BAddLegal.Click
        FormMasterCompanyLegal.id_comp = id_company
        FormMasterCompanyLegal.ShowDialog()
    End Sub

    Private Sub RICEDownload_Click(sender As Object, e As EventArgs) Handles RICEDownload.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim path As String = Application.StartupPath & "\download\"
            'delete all file first
            Dim q As String = "SELECT is_clean_download_folder FROM tb_m_user WHERE id_user='" & id_user & "'"
            Dim is_del As String = execute_query(q, 0, True, "", "", "", "")

            If is_del = "1" Then
                For Each deleteFile In IO.Directory.GetFiles(path, "*.*", IO.SearchOption.TopDirectoryOnly)
                    Try
                        IO.File.Delete(deleteFile)
                    Catch ex As Exception

                    End Try
                Next
            End If
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'download
            Dim directory_upload As String = get_setup_field("upload_legal_dir")
            Dim source_path As String = directory_upload & id_company & "\"
            My.Computer.Network.DownloadFile(source_path & GVLegal.GetFocusedRowCellValue("filename").ToString, path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString, "", "", True, 100, True)
            'open folder
            If IO.File.Exists(path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString) Then
                Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
                open_folder.WindowStyle = ProcessWindowStyle.Maximized
                open_folder.FileName = "explorer.exe"
                open_folder.Arguments = "/select,""" & path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString & """"
                Process.Start(open_folder)
            Else
                stopCustom("No Supporting Document !")
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BCPSetup_Click(sender As Object, e As EventArgs) Handles BCPSetup.Click
        FormMasterCompanyContact.id_company = id_company
        FormMasterCompanyContact.ShowDialog()
    End Sub

    Private Sub TEPhoneComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEPhoneComp.Validating
        If id_company = "-1" Then
            If Not isPhoneNumber(TEPhoneComp.Text) Or TEPhoneComp.Text.Length < 1 Then
                EPCompany.SetError(TEPhoneComp, "Phone number is not valid.")
            Else
                EPCompany.SetError(TEPhoneComp, String.Empty)
            End If
        End If
    End Sub

    Private Sub TECPEmail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TECPEmail.Validating
        If Not isEmail(TECPEmail.Text) Or TECPEmail.Text.Length < 1 Then
            EPCompany.SetError(TECPEmail, "Email is not valid.")
        Else
            EPCompany.SetError(TECPEmail, String.Empty)
        End If
    End Sub

    Private Sub BApproval_Click_1(sender As Object, e As EventArgs) Handles BApproval.Click
        'check coa first
        Dim q_check As String = "SELECT * FROM tb_m_comp WHERE id_comp='" & id_company & "' AND ISNULL(id_acc_ap) AND ISNULL(id_acc_ar) AND ISNULL(id_acc_dp) AND ISNULL(id_acc_cabang_ap) AND ISNULL(id_acc_cabang_ar) AND ISNULL(id_acc_cabang_dp)"
        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")

        If BApproval.Text.ToString = "Submit" And dt_check.Rows.Count > 0 Then
            'belum dimasukin AP AR DP
            warningCustom("Please input AR, AP, or DP first before submit. Contact accounting for details.")
        Else
            If BApproval.Text.ToString = "Submit" Then
                'check if PKP and no attachment
                Dim qpkp As String = "SELECT c.id_tax,IFNULL(cl.id_comp_legal,0) AS legal
FROM tb_m_comp c
LEFT JOIN `tb_m_comp_legal` cl ON cl.id_comp=c.id_comp AND cl.id_legal_type='4'
WHERE c.id_comp='" & id_company & "'"
                Dim dt_pkp As DataTable = execute_query(qpkp, -1, True, "", "", "", "")
                If dt_pkp.Rows.Count > 0 Then
                    If dt_pkp.Rows(0)("id_tax").ToString = "2" And dt_pkp.Rows(0)("legal").ToString = "0" Then
                        warningCustom("Please upload PPKP")
                    Else
                        EP_TE_cant_blank(EPCompany, TECompanyName)
                        EP_TE_cant_blank(EPCompany, TECompanyCode)
                        EP_TE_cant_blank(EPCompany, TECompanyPrintedName)

                        EP_TE_cant_blank(EPCompany, TEPhoneComp)
                        EP_TE_cant_blank(EPCompany, TEEMail)
                        EP_ME_cant_blank(EPCompany, MEAddress)

                        EP_TE_cant_blank(EPCompany, TECPEmail)
                        EP_TE_cant_blank(EPCompany, TECPName)
                        EP_TE_cant_blank(EPCompany, TECPPhone)

                        TECompanyCode_Validating(TECompanyCode, New System.ComponentModel.CancelEventArgs)

                        If Not formIsValidInGroup(EPCompany, GroupControlDesc) Or Not formIsValidInGroup(EPCompany, GCAddress) Or Not formIsValidInGroup(EPCompany, GCCP) Then
                            errorInput()
                        Else
                            Dim q As String = "SELECT id_comp_cat FROM tb_m_comp WHERE id_comp='" & id_company & "'"
                            Dim id_cat As String = execute_query(q, 0, True, "", "", "", "")
                            If id_cat = "1" Or id_cat = "8" Then
                                'cek attachment already have or not
                                Dim query As String = "SELECT c.`id_comp`,c.`comp_name`,lt.`id_legal_type`,lt.`legal_type`,cl.`id_comp_legal` FROM tb_m_comp c
INNER JOIN tb_vendor_type_legal vtl ON vtl.`id_vendor_type`=c.`id_vendor_type` AND c.id_comp_cat=vtl.id_comp_cat
INNER JOIN `tb_lookup_legal_type` lt ON lt.`id_legal_type`=vtl.`id_legal_type`
LEFT JOIN tb_m_comp_legal cl ON cl.`id_comp`=c.`id_comp` AND vtl.`id_legal_type`=cl.`id_legal_Type`
WHERE c.id_comp='" & id_company & "' AND ISNULL(cl.`id_comp_legal`)"
                                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                                If data.Rows.Count = 0 Then
                                    FormReportMark.id_report = id_company
                                    FormReportMark.report_mark_type = "153"
                                    FormReportMark.is_view = is_view
                                    FormReportMark.ShowDialog()
                                Else
                                    Dim str_missing As String = "Please upload this remaining document : "
                                    For i As Integer = 0 To data.Rows.Count - 1
                                        str_missing += vbNewLine & " - " & data.Rows(i)("legal_type").ToString
                                    Next
                                    warningCustom(str_missing)
                                End If
                            Else
                                FormReportMark.id_report = id_company
                                If id_cat <> "6" Then
                                    FormReportMark.report_mark_type = "153"
                                Else
                                    FormReportMark.report_mark_type = "347"
                                End If
                                FormReportMark.is_view = is_view
                                FormReportMark.ShowDialog()
                            End If
                        End If
                    End If
                End If
            Else
                FormReportMark.id_report = id_company
                If LECompanyCategory.EditValue.ToString <> "6" Then
                    FormReportMark.report_mark_type = "153"
                Else
                    FormReportMark.report_mark_type = "347"
                End If
                FormReportMark.is_view = is_view
                FormReportMark.ShowDialog()
            End If
        End If
    End Sub

    Sub update_status(ByVal status As String)
        Dim query As String = "UPDATE tb_m_comp SET is_active='" & status & "' WHERE id_comp='" & id_company & "'"
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub BManageContractVendor_Click(sender As Object, e As EventArgs) Handles BManageContractVendor.Click
        FormProdTemplateKO.ShowDialog()
    End Sub

    Private Sub BSetContract_Click(sender As Object, e As EventArgs) Handles BSetContract.Click
        Dim query As String = "UPDATE tb_m_comp SET id_ko_template='" & LEContractTemplate.EditValue.ToString & "' WHERE id_comp='" & id_company & "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Contract template is set")
    End Sub

    Private Sub BrefreshTemplateContract_Click(sender As Object, e As EventArgs) Handles BrefreshTemplateContract.Click
        load_contract_template()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim Report As New ReportMasterCompanySingle()

        LELegalType.ItemIndex = 0

        load_legal()

        Report.DTLegal = GCLegal.DataSource

        Report.XLCompanyCode.Text = TECompanyCode.Text
        Report.XLCompanyName.Text = TECompanyName.Text
        Report.XLShortName.Text = TECompanyPrintedName.Text
        Report.XLCategory.Text = LECompanyCategory.Text
        Report.XLCompanyGroup.Text = SLEGroup.Text
        Report.XLPhone.Text = TEPhoneComp.Text
        Report.XLWeb.Text = TEWeb.Text
        Report.XLFax.Text = TEFax.Text
        Report.XLEmail.Text = TEEMail.Text
        Report.XLTax.Text = LETax.Text
        Report.XLStatus.Text = LEStatus.Text
        Report.XLNPWP.Text = TENPWP.Text

        Report.XLAddress.Text = MEAddress.Text
        Report.XLOtherAddress.Text = MEOAddress.Text
        Report.XLACountry.Text = LECountry.Text
        Report.XLARegion.Text = LERegion.Text
        Report.XLAState.Text = LEState.Text
        Report.XLACity.Text = LECity.Text
        Report.XLAPostalCode.Text = TEPostalCode.Text

        Report.XLContactPerson.Text = TECPName.Text
        Report.XLNumber.Text = TECPPhone.Text
        Report.XLPosition.Text = TECPPosition.Text
        Report.XLCPEmail.Text = TECPEmail.Text

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

        Tool.ShowPreview()
    End Sub

    Private Sub BSetVendorType_Click(sender As Object, e As EventArgs)
        Dim query As String = "UPDATE tb_m_comp SET id_vendor_type='' WHERE id_comp='" & id_company & "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Vendor type updated")
    End Sub

    Private Sub LECompanyCategory_EditValueChanged(sender As Object, e As EventArgs) Handles LECompanyCategory.EditValueChanged
        Try
            TECompanyCode_Validating(TECompanyCode, New System.ComponentModel.CancelEventArgs)

            If LECompanyCategory.EditValue.ToString = "1" Or LECompanyCategory.EditValue.ToString = "7" Or LECompanyCategory.EditValue.ToString = "8" Then
                LVendorType.Visible = True
                SLEVendorType.Visible = True
                LCStatusPabean.Visible = True
                SLUEStatusPabean.Visible = True
            Else
                LVendorType.Visible = False
                SLEVendorType.Visible = False
                LCStatusPabean.Visible = False
                SLUEStatusPabean.Visible = False
            End If
            '
            Dim query As String = "SELECT is_need_bank_account 
FROM tb_m_comp_cat ccat WHERE ccat.id_comp_cat='" & LECompanyCategory.EditValue.ToString & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                is_need_bank_account = data.Rows(0)("is_need_bank_account").ToString
            End If
            '
            If is_need_bank_account = "1" Then
                SLEBankAccount.Visible = True
                TEBankRek.Visible = True
                TEBankAtasNama.Visible = True
                TEBankAddress.Visible = True
                '
                LBankAccount.Visible = True
                LBankAddress.Visible = True
                LRekName.Visible = True
                LNoRek.Visible = True
            Else
                SLEBankAccount.Visible = False
                TEBankRek.Visible = False
                TEBankAtasNama.Visible = False
                TEBankAddress.Visible = False
                '
                LBankAccount.Visible = False
                LBankAddress.Visible = False
                LRekName.Visible = False
                LNoRek.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BDeleteLegal_Click(sender As Object, e As EventArgs) Handles BDeleteLegal.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim directory_upload As String = get_setup_field("upload_legal_dir")
                Dim path As String = directory_upload & id_company & "\" & GVLegal.GetFocusedRowCellValue("id_comp_legal").ToString & GVLegal.GetFocusedRowCellValue("ext").ToString

                Dim query As String = ""
                query = String.Format("DELETE FROM tb_m_comp_legal WHERE id_comp_legal = '{0}'", GVLegal.GetFocusedRowCellValue("id_comp_legal").ToString)
                execute_non_query(query, True, "", "", "", "")
                If IO.File.Exists(path) Then
                    IO.File.Delete(path)
                End If
                load_legal()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TEBankRek_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEBankRek.Validating
        If TEBankRek.Text.Length < 1 And is_need_bank_account = "1" Then
            EPCompany.SetError(TEBankRek, "Rekening is not valid.")
        Else
            EPCompany.SetError(TEBankRek, String.Empty)
        End If
    End Sub

    Private Sub TEBankAtasNama_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEBankAtasNama.Validating
        If TEBankAtasNama.Text.Length < 1 And is_need_bank_account = "1" Then
            EPCompany.SetError(TEBankAtasNama, "Atas Nama Rekening is not valid.")
        Else
            EPCompany.SetError(TEBankAtasNama, String.Empty)
        End If
    End Sub

    Private Sub TEBankAddress_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEBankAddress.Validating
        If TEBankAddress.Text.Length < 1 And is_need_bank_account = "1" Then
            EPCompany.SetError(TEBankAddress, "Bank Address is not valid.")
        Else
            EPCompany.SetError(TEBankAddress, String.Empty)
        End If
    End Sub

    Private Sub XTCCompany_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCompany.SelectedPageChanged
        If XTCCompany.SelectedTabPageIndex = 1 Then
            Try
                load_legal()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BResetMark_Click(sender As Object, e As EventArgs) Handles BResetMark.Click
        Cursor = Cursors.WaitCursor
        Dim rmt_reset As String = ""
        If LECompanyCategory.EditValue.ToString <> "6" Then
            rmt_reset = "153"
        Else
            rmt_reset = "347"
        End If
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to reset this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_report_mark WHERE id_report='" & id_company & "' AND report_mark_type='" & rmt_reset & "';UPDATE tb_m_comp SET is_active='3',id_report_status='1' WHERE id_comp='" & id_company & "'"
            execute_non_query(query, True, "", "", "", "")
            action_load()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEGroup.EditValueChanged
        view_store_company()
    End Sub

    Private Sub TECompanyCode_EditValueChanged(sender As Object, e As EventArgs) Handles TECompanyCode.EditValueChanged
        TECompanyCode.EditValue = trimSpace(TECompanyCode.EditValue.ToString)
    End Sub

    Private Sub TECompanyName_EditValueChanged(sender As Object, e As EventArgs) Handles TECompanyName.EditValueChanged
        TECompanyName.EditValue = trimSpace(TECompanyName.EditValue.ToString)
    End Sub

    Private Sub TECompanyPrintedName_EditValueChanged(sender As Object, e As EventArgs) Handles TECompanyPrintedName.EditValueChanged
        TECompanyPrintedName.EditValue = trimSpace(TECompanyPrintedName.EditValue.ToString)
    End Sub

    Private Sub LECity_EditValueChanged(sender As Object, e As EventArgs) Handles LECity.EditValueChanged
        Cursor = Cursors.WaitCursor
        Try
            If LECity.EditValue <> Nothing Then
                LEDistrict.EditValue = Nothing
                view_district(LEDistrict, LECity.EditValue)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEAR_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAR.EditValueChanged
        If SLEAR.EditValue = Nothing Then
            TxtARCode.Text = ""
        Else
            Try
                TxtARCode.Text = SLEAR.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEAP_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAP.EditValueChanged
        If SLEAP.EditValue = Nothing Then
            TxtAPCode.Text = ""
        Else
            Try
                TxtAPCode.Text = SLEAP.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEDP_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDP.EditValueChanged
        If SLEDP.EditValue = Nothing Then
            TxtDPCode.Text = ""
        Else
            Try
                TxtDPCode.Text = SLEDP.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEARCabang_EditValueChanged(sender As Object, e As EventArgs) Handles SLEARCabang.EditValueChanged
        If SLEARCabang.EditValue = Nothing Then
            TxtARCodeCabang.Text = ""
        Else
            Try
                TxtARCodeCabang.Text = SLEARCabang.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEAPCabang_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAPCabang.EditValueChanged
        If SLEAPCabang.EditValue = Nothing Then
            TxtAPCodeCabang.Text = ""
        Else
            Try
                TxtAPCodeCabang.Text = SLEAPCabang.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEDPCabang_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDPCabang.EditValueChanged
        If SLEDPCabang.EditValue = Nothing Then
            TxtDPCodeCabang.Text = ""
        Else
            Try
                TxtDPCode.Text = SLEDPCabang.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BCreateCOA_Click(sender As Object, e As EventArgs) Handles BCreateCOA.Click
        FormPopUpMasterCOA.ShowDialog()
    End Sub

    Private Sub RICEDocView_Click(sender As Object, e As EventArgs) Handles RICEDocView.Click
        Try
            Dim path As String = Application.StartupPath & "\download\"

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'download
            Dim directory_upload As String = get_setup_field("upload_legal_dir")
            Dim source_path As String = directory_upload & id_company & "\"

            'download
            My.Computer.Network.DownloadFile(source_path & GVLegal.GetFocusedRowCellValue("filename").ToString, path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString, "", "", True, 100, True)

            'open folder
            If IO.File.Exists(path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString) Then
                Dim FILE_NAME As String = path & GVLegal.GetFocusedRowCellValue("file_name").ToString & "_" & GVLegal.GetFocusedRowCellValue("filename").ToString

                If IO.File.Exists(FILE_NAME) = True Then
                    Process.Start(FILE_NAME)
                Else
                    MsgBox("File Does Not Exist")
                End If
            Else
                stopCustom("No Supporting Document !")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SLEBankAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEBankAccount.EditValueChanged
        If SLEBankAccount.EditValue = Nothing Then
            SLEBankAccount.EditValue = "0"
        End If
    End Sub

    Sub view_status_pabean()
        Dim query As String = "
            SELECT * FROM tb_lookup_status_pabean
        "

        viewSearchLookupQuery(SLUEStatusPabean, query, "id_status_pabean", "status_pabean", "id_status_pabean")
    End Sub

    Sub viewDisplayCapacity()
        Cursor = Cursors.WaitCursor

        'build kolom
        Dim qt As String = "SELECT dt.id_display_type, UPPER(dt.display_type) AS `display_type` FROM tb_display_type dt WHERE dt.is_display_alloc=1 "
        Dim dt As DataTable = execute_query(qt, -1, True, "", "", "", "")
        Dim col_type1 As String = ""
        Dim col_type2 As String = ""
        Dim col_tot_capacity As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If i > 0 Then
                col_type1 += ","
                col_type2 += ","
                col_tot_capacity += "+"
            End If
            col_type1 += "SUM(CASE WHEN a.id_display_type=" + dt.Rows(i)("id_display_type").ToString + " THEN dm.qty END) AS `" + dt.Rows(i)("display_type").ToString + "|QTY`, 
            SUM((CASE WHEN a.id_display_type=" + dt.Rows(i)("id_display_type").ToString + " THEN dm.qty END) * (CASE WHEN a.id_display_type=" + dt.Rows(i)("id_display_type").ToString + " THEN a.capacity END))  AS `" + dt.Rows(i)("display_type").ToString + "|CAPACITY`"
            col_type2 += "IFNULL(a.`" + dt.Rows(i)("display_type").ToString + "|QTY`,0) AS `" + dt.Rows(i)("display_type").ToString + "|QTY`, 
            IFNULL(a.`" + dt.Rows(i)("display_type").ToString + "|CAPACITY`,0) AS `" + dt.Rows(i)("display_type").ToString + "|CAPACITY` "
            col_tot_capacity += "IFNULL(a.`" + dt.Rows(i)("display_type").ToString + "|CAPACITY`,0) "
        Next

        Dim query As String = "SELECT cg.id_class_group AS `GROUP INFO|id_class_group`,dv.display_name AS `GROUP INFO|DIVISION`, 
        ct.class_type AS `GROUP INFO|TYP`, UPPER(cat.class_cat) AS `GROUP INFO|CATEGORY`, cg.class_group AS `GROUP INFO|CLASS`,
        (" + col_tot_capacity + ") AS `TOTAL|CAPACITY`,
        " + col_type2 + ",
        0 AS `CHECK QTY|BOOKED QTY`, '' AS `CHECK QTY|NOTE`
        FROM tb_class_group cg
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_type ct ON ct.id_class_type = cg.id_class_type
        INNER JOIN tb_class_cat cat ON cat.id_class_cat = cg.id_class_cat
        LEFT JOIN (
	        SELECT dm.id_class_group, 
            " + col_type1 + "
            FROM tb_display_master dm
            LEFT JOIN tb_display_alloc a ON a.id_display_type = dm.id_display_type AND a.id_class_group=dm.id_class_group
            WHERE dm.id_comp=" + id_company + " AND dm.is_active=1
            GROUP BY a.id_class_group
        ) a ON a.id_class_group = cg.id_class_group  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data


        'clear band
        GVData.Bands.Clear()
        GVData.Columns.Clear()

        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next

        'setu band
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVData.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If data.Columns(j).Caption = "GROUP INFO|DIVISION" Or data.Columns(j).Caption = "GROUP INFO|CATEGORY" Then
                        col.Group()
                    End If

                    If Not bandName.Contains("INFO") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n2}"

                        'summary
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        col.SummaryItem.DisplayFormat = "{0:n2}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N2}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVData.GroupSummary.Add(summary)
                    End If

                    If bandName = "CHECK QTY" Then
                        band.Visible = False
                    End If
                End If
            Next
        Next
        GVData.Columns("GROUP INFO|id_class_group").Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If LEStatus.EditValue.ToString <> "3" Then
            warningCustom("Klik 'Reset' jika ingin melakukan perubahan master kapasitas toko dan pastikan tidak ada proposal display yang sedang diproses approvalnya")
            Exit Sub
        End If

        If LEStatus.EditValue.ToString = "3" Then
            Dim qcek As String = "SELECT IFNULL(GROUP_CONCAT(DISTINCT p.number),'-') AS `display_trans`
            FROM tb_display_pps p 
            WHERE p.id_comp=" + id_company + " AND p.id_report_status<5 AND p.is_confirm=1 "
            Dim trans_ots As String = execute_query(qcek, 0, True, "", "", "", "")
            If trans_ots <> "-" Then
                warningCustom("Master display tidak dapat diubah, karena sedang diproses approval pada proposal display nomer : " + trans_ots)
                Exit Sub
            End If
        End If

        Cursor = Cursors.WaitCursor
        FormDisplayCapacityMaster.id_comp = id_company
        FormDisplayCapacityMaster.id_class_group = GVData.GetFocusedRowCellValue("GROUP INFO|id_class_group").ToString
        FormDisplayCapacityMaster.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewDCHist()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dm.id_display_master, dm.id_comp, dm.id_display_type, dm.id_class_group, cg.class_group, dm.qty, dm.is_active, dm.input_date, dm.input_by, e.employee_name AS `input_by_name`
        FROM tb_display_master dm
        INNER JOIN tb_display_type typ ON typ.id_display_type = dm.id_display_type
        INNER JOIN tb_class_group cg ON cg.id_class_group = dm.id_class_group
        INNER JOIN tb_m_user us ON us.id_user = dm.input_by
        INNER JOIN tb_m_employee e ON e.id_employee = us.id_employee
        WHERE dm.id_comp=" + id_company + " ORDER BY dm.input_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDCHist.DataSource = data
        GVDCHist.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class