Public Class FormVerificationMasterOL
    Private Sub FormVerificationMasterOL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormVerificationMasterOL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT vm.id_verification_master, c.comp_name, vm.created_date, e.employee_name AS created_by
            FROM tb_verification_master AS vm
            LEFT JOIN tb_m_comp AS c ON vm.id_comp = c.id_comp
            LEFT JOIN tb_m_employee AS e ON vm.created_by = e.id_employee
            ORDER BY vm.created_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCVerification.DataSource = data

        GVVerification.BestFitColumns()
    End Sub

    Private Sub GVVerification_DoubleClick(sender As Object, e As EventArgs) Handles GVVerification.DoubleClick
        FormVerificationMasterOLDet.id_verification_master = GVVerification.GetFocusedRowCellValue("id_verification_master")

        FormVerificationMasterOLDet.ShowDialog()
    End Sub

    Private Sub SBNew_Click(sender As Object, e As EventArgs) Handles SBNew.Click
        FormVerificationMasterOLDet.ShowDialog()
    End Sub

    Private Sub FormVerificationMasterOL_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormVerificationMasterOL_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class