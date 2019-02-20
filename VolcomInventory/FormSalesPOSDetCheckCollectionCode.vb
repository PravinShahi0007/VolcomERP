Public Class FormSalesPOSDetCheckCollectionCode
    Private Sub FormSalesPOSDetCheckCollectionCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get koleksi unik
        Dim dsg As New ClassDesign()
        Dim dt_code As DataTable = dsg.dataMasterSalUnique(FormSalesPOSDet.id_comp)

        Dim tb1 = FormSalesPOSDet.data_temp_unique.AsEnumerable()
        Dim tb2 = dt_code.AsEnumerable()

        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("code").ToString
                    Into Group
                    From y1 In Group.DefaultIfEmpty()
                    Select New With
                    {
                        .id_product = If(y1 Is Nothing, "", y1("id_product")),
                        .is_unique_report = If(y1 Is Nothing, "", y1("is_unique_report")),
                        .code = table1.Field(Of String)("code"),
                        .name = If(y1 Is Nothing, "", y1("name")),
                        .size = If(y1 Is Nothing, "", y1("size")),
                        .qty = table1("qty"),
                        .status = If(y1 Is Nothing, "Product not found", "OK")
                    }
        GCData.DataSource = Nothing
        GCData.DataSource = query.ToList()
        GCData.RefreshDataSource()
        GVData.BestFitColumns()

    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("status")).ToString
        If stt <> "OK" Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub

    Private Sub FormSalesPOSDetCheckCollectionCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class