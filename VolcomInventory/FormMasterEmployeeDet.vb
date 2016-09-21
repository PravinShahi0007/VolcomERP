Public Class FormMasterEmployeeDet
    Public action As String = "-1"
    Public id_employee As String = "-1"

    Private Sub MasterEmployeeDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSex()
        viewDept()
        If action = "upd" Then
            Dim query As String = ""
            query += "SELECT * FROM tb_m_employee a "
            query += "INNER JOIN tb_lookup_sex b ON a.id_sex = b.id_sex "
            query += "INNER JOIN tb_m_departement c ON a.id_departement = c.id_departement "
            query += "WHERE a.id_employee = '" + id_employee + "' "
            query += "ORDER BY a.employee_name ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCode.Text = data.Rows(0)("employee_code").ToString
            TxtName.Text = data.Rows(0)("employee_name").ToString
            LEDept.ItemIndex = LEDept.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            LESex.ItemIndex = LESex.Properties.GetDataSourceRowIndex("id_sex", data.Rows(0)("id_sex").ToString)
        End If
    End Sub

    Private Sub MasterEmployeeDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
    End Sub

    Sub viewSex()
        Dim query As String = "SELECT * FROM tb_lookup_sex a ORDER BY a.id_sex "
        viewLookupQuery(LESex, query, 0, "sex", "id_sex")
    End Sub

    Private Sub TxtCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCode.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtCode)
    End Sub

    Private Sub TxtName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtName.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtName)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()

        Dim employee_code As String = TxtCode.Text
        Dim employee_name As String = TxtName.Text
        Dim id_sex As String = LESex.EditValue.ToString
        Dim id_departement As String = LEDept.EditValue.ToString
        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_m_employee(employee_code, employee_name, id_sex, id_departement) VALUES ('" + employee_code + "', '" + employee_name + "', '" + id_sex + "', '" + id_departement + "') "
            execute_non_query(query, True, "", "", "", "")
            FormMasterEmployee.viewEmployee("-1")
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_m_employee SET employee_code = '" + employee_code + "', employee_name='" + employee_name + "', id_sex='" + id_sex + "', id_departement = '" + id_departement + "' WHERE id_employee = '" + id_employee + "' "
            execute_non_query(query, True, "", "", "", "")
            FormMasterEmployee.viewEmployee("-1")
            Close()
        End If
    End Sub
End Class