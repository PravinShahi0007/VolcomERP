Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UI.PivotGrid
Imports DevExpress.XtraPivotGrid

Public Class ReportProdCOP
    Public Shared id_design As String = "-1"
    Public kursx As Decimal = 0
    Sub view_list_prod()
        Dim query = "CALL view_desg_rec('" & id_design & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProd.DataSource = data
        GVListProd.ExpandAllGroups()
    End Sub
    Sub view_list_cost()
        Dim query = "CALL view_cop_design('" & id_design & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCost.DataSource = data
    End Sub
    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProd.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVCost_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCost.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Sub calculate()
        Dim qty, total, unit_price As Decimal
        qty = 0.0
        total = 0.0
        unit_price = 0.0
        Try
            qty = GVListProd.Columns("receive_created_qty").SummaryItem.SummaryValue
            total = GVCost.Columns("total_price").SummaryItem.SummaryValue
            Lqty.Text = qty.ToString("N2")
            LTotal.Text = total.ToString("N2")
        Catch ex As Exception
            Console.WriteLine("error")
        End Try

        If Lqty.Text = "" Or qty = 0 Or qty = 0.0 Or LTotal.Text = "" Or total = 0 Or total = 0.0 Then
            unit_price = 0
        Else
            unit_price = total / qty
        End If

        LUnitCost.Text = unit_price.ToString("N2")
    End Sub

    Private Sub ReportProdCOP_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        view_list_prod()
        view_list_cost()
        calculate_cost()
        calculate()
    End Sub

    Private Sub GVListProd_CalcRowHeight(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs) Handles GVListProd.CalcRowHeight
        e.RowHeight = 10
    End Sub

    Private Sub ReportFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter.BeforePrint
        calculate()
        Dim date_show As String = ""
        date_show = get_company_x(get_setup_field("id_own_company"), "7") & "," & view_date(0)
        LCityDate.Text = date_show
        LUser.Text = get_user_identify(id_user, "1")
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT design_name,design_code,id_cop_status FROM tb_m_design WHERE id_design = '{0}'", id_design)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LDesignName.Text = data.Rows(0)("design_name").ToString
        LCodeDesign.Text = data.Rows(0)("design_code").ToString
        Lkurs.Text = kursx.ToString("N2")
        If data.Rows(0)("id_cop_status").ToString = "1" Then
            LStatus.Text = "Pre Final"
        Else
            LStatus.Text = "Final"
        End If
    End Sub

    Sub calculate_cost()
        If GVCost.RowCount > 0 Then
            Dim kurs As Decimal = kursx
            Dim actual_price As Decimal = 0
            Dim price As Decimal = 0
            Dim qty As Decimal = 0
            Dim total As Decimal = 0
            For i As Integer = 0 To (GVCost.RowCount - 1 - GetGroupRowCount(GVCost))
                If GVCost.GetRowCellValue(i, "id_category").ToString = "2" And Not GVCost.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    actual_price = GVCost.GetRowCellValue(i, "actual_price")
                    price = kurs * actual_price
                    GVCost.SetRowCellValue(i, "price", price)
                    '
                    qty = GVCost.GetRowCellValue(i, "qty")
                    total = qty * price
                    GVCost.SetRowCellValue(i, "total_price", total)
                End If
            Next
        End If
    End Sub
End Class