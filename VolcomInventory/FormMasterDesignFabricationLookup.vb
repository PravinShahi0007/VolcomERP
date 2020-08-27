Public Class FormMasterDesignFabricationLookup
    Private Sub FormMasterDesignFabricationLookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
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

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormMasterDesignFabricationDet.id_design_fabrication = "0"

        FormMasterDesignFabricationDet.ShowDialog()
    End Sub

    Private Sub SBEdit_Click(sender As Object, e As EventArgs) Handles SBEdit.Click
        Try
            FormMasterDesignFabricationDet.id_design_fabrication = GVFabrication.GetFocusedRowCellValue("id_design_fabrication").ToString

            FormMasterDesignFabricationDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        Try
            FormMasterDesignFabricationDet.id_design_fabrication = GVFabrication.GetFocusedRowCellValue("id_design_fabrication").ToString

            FormMasterDesignFabricationDet.delete()

            form_load()
        Catch ex As Exception
        End Try
    End Sub
End Class