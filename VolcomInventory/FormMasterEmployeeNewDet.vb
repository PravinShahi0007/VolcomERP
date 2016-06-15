﻿Public Class FormMasterEmployeeNewDet
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

        If Not formIsValidInPanel(ErrorProvider1, PanelControlTop) Or Not formIsValidInXTP(ErrorProvider1, XTPGeneral) Then
            errorInput()
        Else
            MsgBox("sip")
        End If
    End Sub



    Private Sub BtnAddNationality_Click(sender As Object, e As EventArgs) Handles BtnAddNationality.Click
        Cursor = Cursors.WaitCursor
        FormMasterArea.quick_edit = "1"
        FormMasterArea.id_pop_up = "1"
        FormMasterArea.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class