Public Class FormMasterDesignFabrication
    Private Sub FormMasterDesignFabrication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT df.id_design_fabrication, df.design_fabrication, df.created_date, ec.employee_name AS created_by, df.updated_date, eu.employee_name AS updated_by
            FROM tb_design_fabrication AS df
            LEFT JOIN tb_m_employee AS ec ON df.created_by = ec.id_employee
            LEFT JOIN tb_m_employee AS eu ON df.updated_by = eu.id_employee
            ORDER BY df.id_design_fabrication DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCFabrication.DataSource = data

        GVFabrication.BestFitColumns()
    End Sub

    Private Sub FormMasterDesignFabrication_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "1")
    End Sub

    Private Sub FormMasterDesignFabrication_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVFabrication_DoubleClick(sender As Object, e As EventArgs) Handles GVFabrication.DoubleClick
        FormMasterDesignFabricationDet.id_design_fabrication = GVFabrication.GetFocusedRowCellValue("id_design_fabrication").ToString
        FormMasterDesignFabricationDet.ShowDialog()
    End Sub
End Class