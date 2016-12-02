Public Class FormProductionCOPDet
    Private Sub FormProductionCOPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEEcop.EditValue = 0.00
        TEKurs.EditValue = 1.0

        view_currency(LECurrency)
        TEVendor.Focus()
        '
        TEVendor.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_number_pd").ToString
        TEVendorName.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_name_pd").ToString
        TEKurs.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_kurs_pd")
        TEEcop.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd")
        '
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_curr").ToString)
    End Sub
End Class