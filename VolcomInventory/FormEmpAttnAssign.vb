Public Class FormEmpAttnAssign
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public is_all As String = "-1"
    Public is_user_mapping As String = "-1"
    Public is_departement As String = "-1"

    Private Sub FormEmpAttnAssign_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnAssign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnAssign_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnAssign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dept()
    End Sub
    '
    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a "
        If Not is_all = "1" Then
            If is_user_mapping = "1" Then
                query += "WHERE id_departement IN (SELECT id_departement FROM tb_assign_sch_map WHERE id_user = " + id_user + ") ORDER BY a.departement ASC "
            Else
                query += "WHERE id_departement='" + id_departement_user + "' ORDER BY a.departement ASC "
            End If
        End If

        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        LEDeptSum.ItemIndex = 0
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_attn()
    End Sub

    Sub load_attn()
        If Not LEDeptSum.EditValue Is Nothing Then
            Dim query_sub As String = ""
            If LEDeptSum.EditValue.ToString = "17" Then
                query_sub = "AND sch.id_departement_sub = '" + LESubDeptSum.EditValue.ToString + "'"
            End If

            Dim query As String = "SELECT * FROM tb_emp_assign_sch sch
                                LEFT JOIN tb_m_user usr ON usr.id_user=sch.id_user_propose
                                LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                LEFT JOIN tb_m_departement dep ON dep.id_departement=sch.id_departement
                                LEFT JOIN tb_m_departement_sub dep_sub ON dep_sub.id_departement_sub=sch.id_departement_sub
                                LEFT JOIN tb_lookup_report_status s ON s.id_report_status=sch.id_report_status
                                WHERE sch.id_departement='" & LEDeptSum.EditValue.ToString & "' " + query_sub + "
                                ORDER BY sch.id_assign_sch DESC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCAttnAssign.DataSource = data

            GVAttnAssign.BestFitColumns()
        End If
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        GCAttnAssign.DataSource = Nothing

        If LEDeptSum.EditValue.ToString = "17" Then
            PCSubDepartement.Visible = True
            GridColumnNomor.VisibleIndex = 0
            GridColumnDate.VisibleIndex = 1
            GridColumnDepartement.VisibleIndex = 2
            GridColumnSubDepartement.VisibleIndex = 3
            GridColumnProposeBy.VisibleIndex = 4
            GridColumnReportStatus.VisibleIndex = 5

            Dim query As String = "
                SELECT id_departement_sub, departement_sub
                FROM tb_m_departement_sub
                WHERE id_departement = " + LEDeptSum.EditValue.ToString + " AND id_departement_sub <> 16
            "

            viewLookupQuery(LESubDeptSum, query, 0, "departement_sub", "id_departement_sub")
            LESubDeptSum.ItemIndex = 0
        Else
            PCSubDepartement.Visible = False
            GridColumnSubDepartement.VisibleIndex = -1

            LESubDeptSum.Properties.DataSource = Nothing
        End If
    End Sub

    Private Sub GVAttnAssign_DoubleClick(sender As Object, e As EventArgs) Handles GVAttnAssign.DoubleClick
        FormEmpAttnAssignDet.id_emp_assign_sch = GVAttnAssign.GetFocusedRowCellValue("id_assign_sch").ToString
        FormEmpAttnAssignDet.ShowDialog()
    End Sub
End Class