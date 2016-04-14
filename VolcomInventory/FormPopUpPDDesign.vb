Public Class FormPopUpPDDesign
    Public id_prod_demand As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpPDDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_prod_demand WHERE id_prod_demand = '" + id_prod_demand + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LPDNo.Text = data.Rows(0)("prod_demand_number").ToString

        viewDesignDemand()
    End Sub
    Sub viewDesignDemand()
        Dim query As String = "CALL view_design_demand_all('" + id_prod_demand + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        GVDesign.Columns("category_design").GroupIndex = 0
        If data.Rows.Count < 1 Then
            BChoose.Enabled = False
        Else
            BChoose.Enabled = True
        End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpPDDesign_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BChoose.Click
        If id_pop_up = "1" Then 'formproductiondet
            'Dim query_check As String = "SELECT COUNT(id_prod_order) FROM tb_prod_order pro LEFT JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design=pro.id_prod_demand_design "
            'query_check += " WHERE pro.id_report_status!=5 AND pd_desg.id_design='" & GVDesign.GetFocusedRowCellValue("id_design").ToString & "'"
            'Dim jml_po As String = execute_query(query_check, 0, True, "", "", "", "")

            'If jml_po = "0" Then
            FormProductionDet.id_prod_demand_design = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
            FormProductionDet.TEDesign.Text = GVDesign.GetFocusedRowCellValue("design_name").ToString
            FormProductionDet.TEDesignCode.Text = GVDesign.GetFocusedRowCellValue("design_code").ToString
            FormProductionDet.TEUSCOde.Text = GVDesign.GetFocusedRowCellValue("sample_us_code").ToString
            FormProductionDet.id_delivery = GVDesign.GetFocusedRowCellValue("id_delivery").ToString
            FormProductionDet.TEDelivery.Text = get_delivery_x(GVDesign.GetFocusedRowCellValue("id_delivery").ToString, "1")
            FormProductionDet.TESeason.Text = get_season_x(get_id_season(GVDesign.GetFocusedRowCellValue("id_delivery").ToString), "1")
            FormProductionDet.TERange.Text = get_range_x(get_id_range(get_id_season(GVDesign.GetFocusedRowCellValue("id_delivery").ToString)), "1")
            FormProductionDet.view_prod_demand_product()
            FormProductionDet.view_bom()
            Close()
            'Else
            '    stopCustom("PO with this design already created, please cancel it first.")
            'End If
        End If
    End Sub
End Class