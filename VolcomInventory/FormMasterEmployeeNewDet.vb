Public Class FormMasterEmployeeNewDet
    Public action As String = "-1"
    Public id_employee As String = "-1"

    Sub viewDept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
    End Sub

    Sub viewSex()
        Dim query As String = "SELECT * FROM tb_lookup_sex a ORDER BY a.id_sex "
        viewLookupQuery(LESex, query, 0, "sex", "id_sex")
    End Sub

    Sub viewBloodType()
        Dim query As String = "SELECT * FROM tb_lookup_blood_type bld ORDER BY bld.id_blood_type ASC "
        viewLookupQuery(LEBloodType, query, 0, "blood_type", "id_blood_type")
    End Sub

    Sub viewReligion()
        Dim query As String = "SELECT * FROM tb_lookup_religion rlg ORDER BY rlg.id_religion ASC "
        viewLookupQuery(LEReligion, query, 0, "religion", "id_religion")
    End Sub

    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country cty ORDER BY cty.id_country ASC "
        viewLookupQuery(LECountry, query, 0, "country", "id_country")
    End Sub

    Sub viewLevel()
        Dim query As String = "SELECT * FROM tb_lookup_employee_level lvl ORDER BY lvl.id_employee_level ASC  "
        viewLookupQuery(LELevel, query, 0, "employee_level", "id_employee_level")
    End Sub

    Sub viewActive()
        Dim query As String = "SELECT * FROM tb_lookup_employee_active act ORDER BY act.id_employee_active ASC "
        viewLookupQuery(LEActive, query, 0, "employee_active", "id_employee_active")
    End Sub

    Sub viewDegree()
        Dim query As String = "SELECT * FROM tb_lookup_education a ORDER BY a.id_education ASC "
        viewLookupQuery(LEDegree, query, 0, "education", "id_education")
    End Sub

    Private Sub FormMasterEmployeeNewDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEJoinDate.EditValue = data_dt.Rows(0)("dt")
        TxtCode.Focus()
        viewSex()
        viewDept()
        viewBloodType()
        viewReligion()
        viewCountry()
        viewLevel()
        viewActive()
        viewDegree()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTPDependent.PageEnabled = False
            XTPStatus.PageEnabled = False
            XTPPosition.PageEnabled = False

            'load img
            pre_viewImages("4", PEEmployee, id_employee, False)
        Else
            BtnSaveChanges.Text = "Save Changes"
            XTPDependent.PageEnabled = True
            XTPStatus.PageEnabled = True
            XTPPosition.PageEnabled = True

            Dim query As String = "CALL view_employee('AND emp.id_employee=" + id_employee + " ', 1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim datarow As DataRow = data.Rows(0)
            'general tab
            TxtCode.Text = datarow("employee_code").ToString
            TxtFullName.Text = datarow("employee_name").ToString
            TxtNickName.Text = datarow("employee_nick_name").ToString
            TxtInitialName.Text = datarow("employee_initial_name").ToString
            DEJoinDate.EditValue = datarow("employee_join_date")
            LEActive.EditValue = datarow("id_employee_active").ToString
            LESex.EditValue = datarow("id_sex").ToString
            LEBloodType.EditValue = datarow("id_blood_type").ToString
            TxtPOB.Text = datarow("employee_pob").ToString
            DEDOB.EditValue = datarow("employee_dob")
            LEReligion.EditValue = datarow("id_religion").ToString
            LECountry.EditValue = datarow("id_country").ToString
            TxtEthnic.Text = datarow("employee_ethnic").ToString
            LEDegree.EditValue = datarow("id_education").ToString
            TxtKTP.Text = datarow("employee_ktp").ToString
            DEKTP.EditValue = datarow("employee_ktp_period")
            TxtPassport.Text = datarow("employee_passport").ToString
            DEPassport.EditValue = datarow("employee_passport_period")
            TxtBPJSTK.Text = datarow("employee_bpjs_tk").ToString
            TxtBPJSSehat.Text = datarow("employee_bpjs_kesehatan").ToString
            TxtNpwp.Text = datarow("employee_npwp").ToString
            TxtPhone.Text = datarow("phone").ToString
            TxtMobilePhone.Text = datarow("phone_mobile").ToString
            TxtPhoneExt.Text = datarow("phone_ext").ToString
            TxtEmailLocal.Text = datarow("email_lokal").ToString
            TxtEmailExternal.Text = datarow("email_external").ToString
            TxtOtherEmail.Text = datarow("email_other").ToString
            MEAddress.Text = datarow("address_primary").ToString
            MEAddressBoarding.Text = datarow("address_additional").ToString

            'load img
            pre_viewImages("4", PEEmployee, id_employee, False)
        End If
    End Sub



    Sub save()

    End Sub

    Private Sub XTPEmployee_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPEmployee.SelectedPageChanged
        If XTPEmployee.SelectedTabPageIndex = 0 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 1 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
        ElseIf XTPEmployee.SelectedTabPageIndex = 2 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
        ElseIf XTPEmployee.SelectedTabPageIndex = 3 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
        ElseIf XTPEmployee.SelectedTabPageIndex = 4 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
        ElseIf XTPEmployee.SelectedTabPageIndex = 5 Then
            BtnNext.Visible = False
            BtnPrevious.Visible = True
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex + 1).PageEnabled = True
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex + 1
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex - 1).PageEnabled = False
    End Sub

    Sub saveTab()

    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex - 1).PageEnabled = True
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex - 1
        XTPEmployee.TabPages.Item(XTPEmployee.SelectedTabPageIndex + 1).PageEnabled = False
    End Sub

    Private Sub TxtCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCode.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtCode)
    End Sub

    Private Sub TxtFullName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtFullName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtFullName)
    End Sub

    Private Sub TxtNickName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNickName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtNickName)
    End Sub

    Private Sub TxtInitialName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtInitialName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtInitialName)
    End Sub

    Private Sub TxtPosition_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPosition.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtPosition)
    End Sub

    Private Sub PEEmployee_DoubleClick(sender As Object, e As EventArgs) Handles PEEmployee.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("4", PEEmployee, id_employee, True)
        Cursor = Cursors.Default
    End Sub



    Private Sub TxtFocus_Enter(sender As Object, e As EventArgs) Handles TxtFocus.Enter
        LESex.Focus()
    End Sub

    Private Sub TxtPOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPOB.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
    End Sub

    Private Sub DEDOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDOB.Validating
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        ValidateChildren()
        EP_TE_cant_blank(ErrorProvider1, TxtPOB)
        EP_DE_cant_blank(ErrorProvider1, DEDOB)
        EP_ME_cant_blank(ErrorProvider1, MEAddress)

        If Not formIsValidInPanel(ErrorProvider1, PanelControlTop) Or Not formIsValidInXTP(ErrorProvider1, XTPGeneral) Then
            errorInput()
        Else
            Dim employee_code As String = addSlashes(TxtCode.Text)
            Dim employee_name As String = addSlashes(TxtFullName.Text)
            Dim employee_nick_name As String = addSlashes(TxtNickName.Text)
            Dim employee_initial_name As String = addSlashes(TxtInitialName.Text)
            Dim employee_join_date As String = addSlashes(DateTime.Parse(DEJoinDate.EditValue.ToString).ToString("yyyy-MM-dd"))
            Dim id_employee_active As String = addSlashes(LEActive.EditValue.ToString)
            Dim id_sex As String = addSlashes(LESex.EditValue.ToString)
            Dim id_blood_type As String = addSlashes(LEBloodType.EditValue.ToString)
            Dim employee_pob As String = addSlashes(TxtPOB.Text)
            Dim employee_dob As String = addSlashes(DateTime.Parse(DEDOB.EditValue.ToString).ToString("yyyy-MM-dd"))
            Dim id_religion As String = addSlashes(LEReligion.EditValue.ToString)
            Dim id_country As String = addSlashes(LECountry.EditValue.ToString)
            Dim employee_ethnic As String = addSlashes(addSlashes(TxtEthnic.Text))
            Dim id_education As String = addSlashes(LEDegree.EditValue.ToString)
            Dim employee_ktp As String = addSlashes(TxtKTP.Text)
            Dim employee_ktp_period As String = "NULL"
            Try
                employee_ktp_period = checkNullInput(DateTime.Parse(DEKTP.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try
            Dim employee_passport As String = addSlashes(TxtPassport.Text)
            Dim employee_passport_period As String = "NULL"
            Try
                employee_passport_period = checkNullInput(DateTime.Parse(DEPassport.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try
            Dim employee_bpjs_tk As String = addSlashes(TxtBPJSTK.Text)
            Dim employee_bpjs_kesehatan As String = addSlashes(TxtBPJSSehat.Text)
            Dim employee_npwp As String = addSlashes(TxtNpwp.Text)
            Dim phone As String = TxtPhone.Text
            Dim phone_mobile As String = TxtMobilePhone.Text
            Dim phone_ext As String = TxtPhoneExt.Text
            Dim email_lokal As String = TxtEmailLocal.Text
            Dim email_external As String = TxtEmailExternal.Text
            Dim email_other As String = TxtOtherEmail.Text
            Dim address_primary As String = addSlashes(MEAddress.Text)
            Dim address_additional As String = addSlashes(MEAddressBoarding.Text)

            If action = "ins" Then
                'main
                Dim query As String = "INSERT INTO tb_m_employee(employee_code, employee_name, employee_nick_name, employee_initial_name, employee_join_date, id_employee_active, id_sex, id_blood_type, employee_pob, employee_dob, id_religion, id_country, employee_ethnic, id_education, employee_ktp, employee_ktp_period, employee_passport, employee_passport_period, employee_bpjs_tk, employee_bpjs_kesehatan, employee_npwp, address_primary, address_additional, phone, phone_mobile, phone_ext, email_lokal, email_external, email_other) "
                query += "VALUES('" + employee_code + "', '" + employee_name + "', '" + employee_nick_name + "', '" + employee_initial_name + "', '" + employee_join_date + "', '" + id_employee_active + "', '" + id_sex + "', '" + id_blood_type + "', '" + employee_pob + "', '" + employee_dob + "', '" + id_religion + "', '" + id_country + "', '" + employee_ethnic + "', '" + id_education + "', '" + employee_ktp + "', " + employee_ktp_period + ", '" + employee_passport + "', " + employee_passport_period + ", '" + employee_bpjs_tk + "', '" + employee_bpjs_kesehatan + "', '" + employee_npwp + "', '" + address_primary + "', '" + address_additional + "', '" + phone + "', '" + phone_mobile + "', '" + phone_ext + "', '" + email_lokal + "', '" + email_external + "', '" + email_other + "'); SELECT LAST_INSERT_ID(); "
                id_employee = execute_query(query, 0, True, "", "", "", "")

                'pic
                save_image_ori(PEEmployee, emp_image_path, id_employee & ".jpg")

                'info & refresh
                FormMasterEmployee.viewEmployee()
                action = "upd"
                actionLoad()
                infoCustom("Created successfully, please add some information detail.")
            Else

            End If
        End If
    End Sub



    Private Sub BtnAddNationality_Click(sender As Object, e As EventArgs) Handles BtnAddNationality.Click
        Cursor = Cursors.WaitCursor
        FormMasterArea.quick_edit = "1"
        FormMasterArea.id_pop_up = "1"
        FormMasterArea.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub MEAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles MEAddress.KeyDown
        EP_ME_cant_blank(ErrorProvider1, MEAddress)
    End Sub
End Class