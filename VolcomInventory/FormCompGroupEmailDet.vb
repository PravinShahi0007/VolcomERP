Public Class FormCompGroupEmailDet
    Public id_comp_group As String = "-1"
    Public id_comp As String = "-1"
    Public is_external As Boolean = True

    Private Sub FormCompGroupEmailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_emp()
        TECompGroup.Text = FormCompGroupEmail.GVGroupComp.GetFocusedRowCellValue("description").ToString

        If is_external Then
            PCEmployee.Visible = False
        Else
            TEName.Properties.ReadOnly = True
            TEEmail.Properties.ReadOnly = True
        End If
        '
        If id_comp = "-1" Then
            PCComp.Visible = False
        Else
            PCComp.Visible = True
            TEStore.Text = FormCompGroupEmail.GVGroupComp.GetFocusedRowCellValue("comp_name").ToString
        End If
    End Sub

    Sub load_emp()
        Dim q As String = "SELECT id_employee,employee_name,email_external
FROM tb_m_employee emp 
WHERE id_employee_active=1 AND email_external!=''"
        viewSearchLookupQuery(SLEEmp, q, "id_employee", "employee_name", "id_employee")
        SLEEmp.EditValue = Nothing
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS is_to,'To' AS `desc`
UNION ALL
SELECT 2 AS is_to,'CC' AS `desc`"
        viewSearchLookupQuery(SLEToCC, q, "is_to", "desc", "is_to")
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormCompGroupEmailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If TEEmail.Text = "" Or TEName.Text = "" Then
            warningCustom("Please complete your input")
        Else
            Dim q As String = ""
            If id_comp = "-1" Then
                'per grup
                If is_external Then
                    q = "INSERT INTO `tb_mail_to_group`(id_employee,`report_mark_type`,`id_comp_group`,`is_to`,`email`,`name`) VALUES(NULL,'" & FormCompGroupEmail.SLEReportMarkType.EditValue.ToString & "','" & id_comp_group & "','" & SLEToCC.EditValue.ToString & "','" & addSlashes(TEEmail.Text) & "','" & addSlashes(TEName.Text) & "')"
                Else
                    q = "INSERT INTO `tb_mail_to_group`(id_employee,`report_mark_type`,`id_comp_group`,`is_to`,`email`,`name`) VALUES('" & SLEEmp.EditValue.ToString & "','" & FormCompGroupEmail.SLEReportMarkType.EditValue.ToString & "','" & id_comp_group & "','" & SLEToCC.EditValue.ToString & "','" & addSlashes(TEEmail.Text) & "','" & addSlashes(TEName.Text) & "')"
                End If
            Else
                'per comp
                If is_external Then
                    q = "INSERT INTO `tb_mail_to_group`(id_employee,`report_mark_type`,`id_comp_group`,id_comp,`is_to`,`email`,`name`) VALUES(NULL,'" & FormCompGroupEmail.SLEReportMarkType.EditValue.ToString & "','" & id_comp_group & "','" & id_comp & "','" & SLEToCC.EditValue.ToString & "','" & addSlashes(TEEmail.Text) & "','" & addSlashes(TEName.Text) & "')"
                Else
                    q = "INSERT INTO `tb_mail_to_group`(id_employee,`report_mark_type`,`id_comp_group`,id_comp,`is_to`,`email`,`name`) VALUES('" & SLEEmp.EditValue.ToString & "','" & FormCompGroupEmail.SLEReportMarkType.EditValue.ToString & "','" & id_comp_group & "','" & id_comp & "','" & SLEToCC.EditValue.ToString & "','" & addSlashes(TEEmail.Text) & "','" & addSlashes(TEName.Text) & "')"
                End If
            End If

            execute_non_query(q, True, "", "", "", "")
            Close()
            FormCompGroupEmail.show_email()
        End If
    End Sub

    Private Sub SLEEmp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmp.EditValueChanged
        Try
            TEName.Text = SLEEmp.Properties.View.GetFocusedRowCellValue("employee_name").ToString
            TEEmail.Text = SLEEmp.Properties.View.GetFocusedRowCellValue("email_external").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class