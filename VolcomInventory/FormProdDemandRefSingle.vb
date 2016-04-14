Public Class FormProdDemandRefSingle 
    Public id_pop_up As String = "-1"

    Private Sub FormProdDemandRefSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProdDemand()
    End Sub

    Sub viewProdDemand()
        Dim query_c As ClassProdDemand = New ClassProdDemand()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        If GVProdDemand.RowCount < 1 Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
            GVProdDemand.FocusedRowHandle = 0
        End If
    End Sub


    Private Sub BtnLoadDetailPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLoadDetailPD.Click
        Cursor = Cursors.WaitCursor

        Dim id_prod_demand As String = "-1"
        Try
            id_prod_demand = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            If id_prod_demand = "" Then
                id_prod_demand = "-1"
            End If
        Catch ex As Exception
        End Try

        'build report
        Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        prod_demand_report.printReport(id_prod_demand, BGVProduct, GCProduct)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormProdDemandSingle.id_prod_demand_ref = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            FormProdDemandSingle.ButtonEdit1.EditValue = GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
            FormProdDemandSingle.SLESeason.EditValue = GVProdDemand.GetFocusedRowCellValue("id_season").ToString
            FormProdDemandSingle.LESampleDivision.ItemIndex = FormProdDemandSingle.LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", GVProdDemand.GetFocusedRowCellValue("id_division").ToString)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        allow_()
        Cursor = Cursors.Default
    End Sub

    Sub allow_()
        Dim id_ As String = "-1"
        Try
            id_ = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
        Catch ex As Exception
        End Try

        If id_ = "-1" Or id_ = "" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
    End Sub

    Private Sub GVProdDemand_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdDemand.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        allow_()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdDemandRefSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub BGVProduct_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT_add_report_column"), "0.00"))
            Select Case summaryID
                Case 46
                    tot_cost += cost
                    tot_prc += prc
                Case 47
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 46 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 47 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub BGVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class