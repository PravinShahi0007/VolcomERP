Public Class FormFGStockOpnameStoreSingle 
    Public id_pop_up As String = "-1"
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Private Sub FormFGStockOpnameStoreSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGStockOpnameStoreSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPLCat()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then
            FormFGStockOpnameWHDet.id_pl_category = LEPLCategory.EditValue.ToString
            FormFGStockOpnameWHDet.pl_category = LEPLCategory.Text.ToString
            FormFGStockOpnameWHDet.startScan()
            Close()
        ElseIf id_pop_up = "3" Then
            FormSampleStockOpnameDet.id_pl_category = LEPLCategory.EditValue.ToString
            FormSampleStockOpnameDet.pl_category = LEPLCategory.Text.ToString
            FormSampleStockOpnameDet.startScan()
            Close()
            'FormFGStockOpnameStoreDet.GVBarcode.FocusedRowHandle = FormFGStockOpnameStoreDet.GVBarcode.RowCount - 1
            'FormFGStockOpnameStoreDet.GVBarcode.FocusedColumn = FormFGStockOpnameStoreDet.GVBarcode.Columns("code")
            'FormFGStockOpnameStoreDet.MENote.Focus()
            'FormFGStockOpnameStoreDet.Focus()
            'FormFGStockOpnameStoreDet.GVBarcode.Focus()
            'FormFGStockOpnameStoreDet.GVBarcode.ShowEditor()
        Else
            FormFGStockOpnameStoreDet.id_pl_category = LEPLCategory.EditValue.ToString
            FormFGStockOpnameStoreDet.pl_category = LEPLCategory.Text.ToString
            FormFGStockOpnameStoreDet.startScan()
            Close()
            'FormFGStockOpnameStoreDet.GVBarcode.FocusedRowHandle = FormFGStockOpnameStoreDet.GVBarcode.RowCount - 1
            'FormFGStockOpnameStoreDet.GVBarcode.FocusedColumn = FormFGStockOpnameStoreDet.GVBarcode.Columns("code")
            'FormFGStockOpnameStoreDet.MENote.Focus()
            'FormFGStockOpnameStoreDet.Focus()
            'FormFGStockOpnameStoreDet.GVBarcode.Focus()
            'FormFGStockOpnameStoreDet.GVBarcode.ShowEditor()
        End If
    End Sub
End Class