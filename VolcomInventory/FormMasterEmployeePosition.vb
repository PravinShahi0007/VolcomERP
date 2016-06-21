Public Class FormMasterEmployeePosition
    Public id_employee_position As String = "-1"
    Public id_employee As String = "-1"


    Sub viewDept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
        viewLookupQuery(LEOriginDept, query, 0, "departement", "id_departement")
    End Sub

    Sub viewLevel()
        Dim query As String = "SELECT * FROM tb_lookup_employee_level lvl ORDER BY lvl.id_employee_level ASC  "
        viewLookupQuery(LELevel, query, 0, "employee_level", "id_employee_level")
        viewLookupQuery(LEOriginLevel, query, 0, "employee_level", "id_employee_level")
    End Sub


    Private Sub FormMasterEmployeePosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewLevel()

        'current position
        Dim query As String = "SELECT emp.id_departement,emp.employee_position, emp.id_employee_level FROM tb_m_employee emp WHERE emp.id_employee='" + id_employee + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEOriginDept.EditValue = data.Rows(0)("id_departement")
        LEOriginLevel.EditValue = data.Rows(0)("id_employee_level")
        TxtOriginPosition.Text = data.Rows(0)("employee_position").ToString
    End Sub

End Class