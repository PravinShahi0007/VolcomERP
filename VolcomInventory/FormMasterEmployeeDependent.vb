Public Class FormMasterEmployeeDependent
    Public id_employee_dependent As String = "-1"
    Public id_employee As String = "-1"
    Public action As String = "-1"

    Private Sub FormMasterEmployeeDependent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_m_employee_dependent a WHERE a.id_employee_dependent='" + id_employee_dependent + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtName.Text = data.Rows(0)("employee_dependent_name").ToString
            LERelationship.ItemIndex = LERelationship.Properties.GetDataSourceRowIndex("id_relationship", data.Rows(0)("id_relationship").ToString)
        End If
    End Sub

    Sub view()
        Dim query As String = "SELECT * FROM tb_lookup_relationship a ORDER BY a.id_relationship ASC "
        viewLookupQuery(LERelationship, query, 0, "relationship", "id_relationship")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtName.Text.ToString <> "" Then
            Dim id_relationship As String = LERelationship.EditValue.ToString
            Dim employee_dependent_name As String = addSlashes(TxtName.Text.ToString)
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_m_employee_dependent(id_employee, id_relationship, employee_dependent_name) VALUES "
                query += "('" + id_employee + "', '" + id_relationship + "', '" + employee_dependent_name + "'); SELECT LAST_INSERT_ID(); "
                id_employee_dependent = execute_query(query, 0, True, "", "", "", "")
                FormMasterEmployeeNewDet.viewDependent()
                Close()
            Else
                Dim query As String = "UPDATE tb_m_employee_dependent SET id_relationship='" + id_relationship + "', employee_dependent_name='" + employee_dependent_name + "' WHERE id_employee_dependent='" + id_employee_dependent + "'"
                execute_non_query(query, True, "", "", "", "")
                FormMasterEmployeeNewDet.viewDependent()
                Close()
            End If
        Else
            stopCustom("Please insert name dependent")
        End If
    End Sub

    Private Sub FormMasterEmployeeDependent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class