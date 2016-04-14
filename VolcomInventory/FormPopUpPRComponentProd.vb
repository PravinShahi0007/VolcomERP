Public Class FormPopUpPRComponentProd 

    Public id_wo As String = "-1"
    Public id_rec As String = "-1"
    Public id_pr As String = "-1"
    Public id_pr_det As String = "-1"
    'for edit
    Public id_det As String = "-1"
    Public type As String = "-1"

    Private Sub FormPopUpPRComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_pr()
        view_ovh()
        view_dc(LETerm)
        TEPriceOvh.EditValue = 0.0
        TEQtyOvh.EditValue = 0.0
        TEPriceTotOvh.EditValue = 0.0
        If id_rec <> "-1" Then
            'rec selected
            XTPReceive.PageVisible = True
            XTPPurchase.PageVisible = False
            view_list_rec()
        Else
            'no rec yet
            XTPReceive.PageVisible = False
            XTPPurchase.PageVisible = True
            view_list_wo()
        End If

        'focus to selected
        Dim pagex As Integer
        pagex = 0

        If type = "1" Then
            pagex = 1
            GVProdPR.FocusedRowHandle = find_row(GVProdPR, "id_pr_prod_order", id_det)
        ElseIf type = "2" Then
            If id_rec <> "-1" Then
                pagex = 3
                GVListReceive.FocusedRowHandle = find_row(GVListReceive, "id_prod_order_wo_det", id_det)
            Else
                pagex = 2
                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_prod_order_wo_det", id_det)
            End If
        ElseIf type = "3" Then
            pagex = 0
            GVOVH.FocusedRowHandle = find_row(GVOVH, "id_ovh", id_det)
        Else
            pagex = 0
        End If
        XtraTabControl1.SelectedTabPageIndex = pagex
        'end focus to selected
    End Sub

    Sub view_list_wo()
        Dim query = "CALL view_pr_prod_from_wo('" & id_wo & "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BSavePurc.Enabled = True
        Else
            BSavePurc.Enabled = False
        End If
    End Sub

    Sub view_dc(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_dc,dc FROM tb_lookup_dc"
        viewLookupQuery(lookup, query, 0, "dc", "id_dc")
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_prod_from_rec('" & id_wo & "','" & id_rec & "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListReceive.DataSource = data

        If data.Rows.Count > 0 Then
            BSaveRec.Enabled = True
        Else
            BSaveRec.Enabled = False
        End If
    End Sub

    Sub view_mat_pr()
        Dim query As String = "SELECT z.pr_prod_order_dp,z.pr_prod_order_total,z.id_pr_prod_order,z.pr_prod_order_number,DATE_FORMAT(z.pr_prod_order_date,'%d %M %Y') as pr_prod_order_date,b.prod_order_wo_number,d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.prod_order_wo_date,INTERVAL (b.prod_order_wo_top+b.prod_order_wo_lead_time) DAY),'%d %M %Y') AS prod_order_wo_top "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_prod_order_wo b ON b.id_prod_order_wo=z.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "WHERE z.id_prod_order_wo='" & id_wo & "' AND (z.id_report_status='3' or z.id_report_status='4' or z.id_report_status='6')"
        query += "ORDER BY z.id_pr_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPR.DataSource = data
        If data.Rows.Count > 0 Then
            BSavePR.Enabled = True
        Else
            BSavePR.Enabled = False
        End If
    End Sub

    Sub view_ovh()
        Dim data As DataTable = execute_query("SELECT * FROM tb_m_ovh a INNER JOIN tb_m_uom b ON b.id_uom = a.id_uom ORDER BY overhead_code ASC", -1, True, "", "", "", "")
        GCOVH.DataSource = data
        If data.Rows.Count > 0 Then
            BSaveOvh.Enabled = True
            load_ovh()
        Else
            BSaveOvh.Enabled = False
        End If
    End Sub

    Private Sub GVOVH_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOVH.RowClick
        load_ovh()
    End Sub

    Sub load_ovh()
        TEUOM.Text = GVOVH.GetFocusedRowCellDisplayText("uom").ToString
    End Sub

    Sub calculate_ovh()
        Dim tot, qty, price As Decimal

        Try
            price = Decimal.Parse(TEPriceOvh.EditValue)
            qty = Decimal.Parse(TEQtyOvh.EditValue)

            tot = price * qty

            TEPriceTotOvh.EditValue = tot
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TEPriceOvh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEPriceOvh.EditValueChanged
        calculate_ovh()
    End Sub

    Private Sub TEQtyOvh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQtyOvh.EditValueChanged
        calculate_ovh()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVListReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListReceive.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BCancelOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelOvh.Click
        Close()
    End Sub

    Private Sub GCancelPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCancelPR.Click
        Close()
    End Sub

    Private Sub BCancelPurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelPurc.Click
        Close()
    End Sub

    Private Sub BCancelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelRec.Click
        Close()
    End Sub
    Private Sub BSaveOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveOvh.Click
        If id_det = "-1" Then 'add new item
            If check_on_gv(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, "3", "1") Then
                errorDuplicate(" Item on list.")
            Else
                Dim newRow As DataRow = (TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable)).NewRow()
                newRow("name") = GVOVH.GetFocusedRowCellDisplayText("overhead").ToString
                newRow("id_det") = GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                newRow("code") = GVOVH.GetFocusedRowCellDisplayText("overhead_code").ToString
                newRow("qty") = TEQtyOvh.EditValue
                newRow("type") = "3"
                newRow("uom") = GVOVH.GetFocusedRowCellDisplayText("uom").ToString
                newRow("price") = TEPriceOvh.EditValue
                'tot or debt
                If LETerm.EditValue = "1" Then
                    newRow("debit") = TEPriceTotOvh.EditValue
                Else
                    newRow("total") = TEPriceTotOvh.EditValue
                End If
                '
                TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                FormProdPRWODet.GCListPurchase.RefreshDataSource()
                FormProdPRWODet.show_but()
                FormProdPRWODet.calculate()
                Close()
            End If
        Else 'edit item
            If check_on_gv(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, "3", "2") Then
                errorDuplicate(" Item on list.")
            Else
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "id_det", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "name", GVOVH.GetFocusedRowCellDisplayText("overhead").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "code", GVOVH.GetFocusedRowCellDisplayText("overhead_code").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "qty", TEQtyOvh.EditValue)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "type", "3")
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "price", TEPriceOvh.EditValue)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "uom", GVOVH.GetFocusedRowCellDisplayText("uom").ToString)
                If LETerm.EditValue = "1" Then
                    FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "debit", TEPriceTotOvh.EditValue)
                    FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "total", "")
                Else
                    FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "debit", "")
                    FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "total", TEPriceTotOvh.EditValue)
                End If
                FormProdPRWODet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BSavePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePurc.Click
        If id_det = "-1" Then 'new item
            If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString, "2", "1") Then
                errorDuplicate(" Item on list.")
            Else
                Dim newRow As DataRow = (TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable)).NewRow()
                newRow("id_det") = GVListPurchase.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString
                newRow("name") = GVListPurchase.GetFocusedRowCellDisplayText("name").ToString
                newRow("code") = GVListPurchase.GetFocusedRowCellDisplayText("code").ToString
                newRow("qty") = GVListPurchase.GetFocusedRowCellDisplayText("qty").ToString
                newRow("type") = "2"
                newRow("uom") = GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString
                newRow("price") = GVListPurchase.GetFocusedRowCellDisplayText("price").ToString
                newRow("total") = GVListPurchase.GetFocusedRowCellValue("total")

                TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                FormProdPRWODet.GCListPurchase.RefreshDataSource()
                FormProdPRWODet.show_but()
                FormProdPRWODet.calculate()
                Close()
            End If
        Else 'edit item
            If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString, "2", "2") Then
                errorDuplicate(" Item on list.")
            Else
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "id_det", GVListPurchase.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "code", GVListPurchase.GetFocusedRowCellDisplayText("code").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "qty", GVListPurchase.GetFocusedRowCellDisplayText("qty"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "type", "2")
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "price", GVListPurchase.GetFocusedRowCellDisplayText("price"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "total", GVListPurchase.GetFocusedRowCellValue("total"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "uom", GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString)
                FormProdPRWODet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BSaveRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveRec.Click
        If id_det = "-1" Then 'add item
            If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString, "2", "1") Then
                errorDuplicate(" Item on list.")
            Else
                Dim newRow As DataRow = (TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable)).NewRow()
                newRow("id_det") = GVListReceive.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString
                newRow("name") = GVListReceive.GetFocusedRowCellDisplayText("name").ToString
                newRow("code") = GVListReceive.GetFocusedRowCellDisplayText("code").ToString
                newRow("qty") = GVListReceive.GetFocusedRowCellValue("qty")
                newRow("type") = "2"
                newRow("uom") = GVListReceive.GetFocusedRowCellDisplayText("uom").ToString
                newRow("price") = GVListReceive.GetFocusedRowCellValue("price")
                newRow("total") = GVListReceive.GetFocusedRowCellValue("total")

                TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                FormProdPRWODet.GCListPurchase.RefreshDataSource()
                FormProdPRWODet.show_but()
                FormProdPRWODet.calculate()
                Close()
            End If
        Else 'edit item
            If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString, "2", "2") Then
                errorDuplicate(" Item on list.")
            Else
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "id_det", GVListReceive.GetFocusedRowCellDisplayText("id_prod_order_wo_det").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "name", GVListReceive.GetFocusedRowCellDisplayText("name").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "code", GVListReceive.GetFocusedRowCellDisplayText("code").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "qty", GVListReceive.GetFocusedRowCellValue("qty"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "type", "2")
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "price", GVListReceive.GetFocusedRowCellValue("price"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "total", GVListReceive.GetFocusedRowCellValue("total"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "uom", GVListReceive.GetFocusedRowCellDisplayText("uom").ToString)
                FormProdPRWODet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BSavePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePR.Click
        If id_det = "-1" Then 'add item
            If check_on_gv(GVProdPR.GetFocusedRowCellDisplayText("id_pr_prod_order").ToString, "1", "1") Then
                errorDuplicate(" Item on list.")
            Else
                Dim newRow As DataRow = (TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable)).NewRow()
                newRow("id_det") = GVProdPR.GetFocusedRowCellDisplayText("id_pr_prod_order").ToString
                newRow("name") = "Payment Request"
                newRow("code") = GVProdPR.GetFocusedRowCellDisplayText("pr_prod_order_number").ToString
                newRow("qty") = 1.0
                newRow("type") = "1"
                newRow("price") = GVProdPR.GetFocusedRowCellValue("pr_prod_order_dp")
                newRow("debit") = GVProdPR.GetFocusedRowCellValue("pr_prod_order_dp")

                TryCast(FormProdPRWODet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                FormProdPRWODet.GCListPurchase.RefreshDataSource()
                FormProdPRWODet.show_but()
                FormProdPRWODet.calculate()
                Close()
            End If
        Else 'edit item
            If check_on_gv(GVProdPR.GetFocusedRowCellDisplayText("id_pr_prod_order").ToString, "1", "2") Then
                errorDuplicate(" Item on list.")
            Else
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "id_det", GVProdPR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "name", "Payment Request")
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "code", GVProdPR.GetFocusedRowCellDisplayText("pr_mat_purc_number").ToString)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "qty", 1.0)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "type", "1")
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "price", GVProdPR.GetFocusedRowCellValue("pr_mat_purc_dp"))
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "total", Nothing)
                FormProdPRWODet.GVListPurchase.SetRowCellValue(FormProdPRWODet.GVListPurchase.FocusedRowHandle, "debit", GVProdPR.GetFocusedRowCellValue("pr_mat_purc_dp"))
                FormProdPRWODet.calculate()
                Close()
            End If
        End If
    End Sub

    Function check_on_gv(ByVal id_det As String, ByVal type As String, ByVal opt As String)
        ' opt 
        ' 1 = new
        ' 2 = edit
         Dim temp_check As Boolean = False
        For i As Integer = 0 To FormProdPRWODet.GVListPurchase.RowCount - 1
            If opt = "1" Then 'new
                If type = FormProdPRWODet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormProdPRWODet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() Then
                    temp_check = True
                    Exit For
                End If
            Else 'edit
                If type = FormProdPRWODet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormProdPRWODet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() And Not i = FormProdPRWODet.GVListPurchase.FocusedRowHandle Then
                    temp_check = True
                    Exit For
                End If
            End If
        Next

        Return temp_check
    End Function

    Private Sub FormPopUpPRComponent_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVSamplePR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPR.FocusedRowChanged
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
End Class