Public Class FormMasterDesignFabricationLookup
    Private Sub FormMasterDesignFabricationLookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT id_design_fabrication, design_fabrication
            FROM tb_design_fabrication
            ORDER BY id_design_fabrication DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCFabrication.DataSource = data

        GVFabrication.BestFitColumns()
    End Sub

    Private Sub FormMasterDesignFabricationLookup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVFabrication_DoubleClick(sender As Object, e As EventArgs) Handles GVFabrication.DoubleClick
        FormMasterDesignSingle.TxtFabrication.EditValue = GVFabrication.GetFocusedRowCellValue("design_fabrication").ToString

        Close()
    End Sub
End Class