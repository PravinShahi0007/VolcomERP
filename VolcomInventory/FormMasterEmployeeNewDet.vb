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

    Private Sub FormMasterEmployeeNewDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEJoinDate.EditValue = data_dt.Rows(0)("dt")
        DEDOB.EditValue = data_dt.Rows(0)("dt")
        TxtCode.Focus()
        viewSex()
        viewDept()
        viewBloodType()
        viewReligion()
        viewCountry()
        viewLevel()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTPActivity.PageEnabled = False
            XTPEducation.PageEnabled = False
            XTPFamily.PageEnabled = False
            XTPInfo.PageEnabled = False
            XTPStatus.PageEnabled = False

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
            BtnFinish.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 1 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
            BtnFinish.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 2 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
            BtnFinish.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 3 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
            BtnFinish.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 4 Then
            BtnNext.Visible = True
            BtnPrevious.Visible = True
            BtnFinish.Visible = False
        ElseIf XTPEmployee.SelectedTabPageIndex = 5 Then
            BtnNext.Visible = False
            BtnPrevious.Visible = True
            BtnFinish.Visible = True
            BtnFinish.SendToBack()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex + 1
    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        XTPEmployee.SelectedTabPageIndex = XTPEmployee.SelectedTabPageIndex - 1
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
End Class