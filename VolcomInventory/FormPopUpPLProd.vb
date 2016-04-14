Public Class FormPopUpPLProd 
    Public id_pop_up As String = "-1"
    Public id_pl_prod_order As String = "-1"
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"
    '1 = Receiving FG In WH 

    Private Sub FormPopUpPLProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_purc()
        If id_pl_prod_order <> "-1" Then
            GVProd.FocusedRowHandle = find_row(GVProd, "id_pl_prod_order", id_pl_prod_order)
        End If
    End Sub
    Sub view_sample_purc()
        Dim query = "SELECT a.id_prod_order, a1.prod_order_number, d.design_cop, "
        query += "a.id_pl_prod_order,d.id_sample, a.pl_prod_order_number, d.design_display_name,d.design_name , d.design_code, g.pl_category, "
        query += "DATE_FORMAT(a.pl_prod_order_date,'%d %M %Y') AS pl_prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "b.id_design,a.id_comp_contact_from, (i.id_comp) as id_comp_to, a.id_comp_contact_to, (i.comp_name) AS comp_name_to, (i.comp_number) AS comp_number_to, (k.comp_name) AS comp_name_from, (k.comp_number) AS comp_number_from, "
        query += "alloc.id_pd_alloc, alloc.pd_alloc "
        query += "FROM tb_pl_prod_order a "
        query += "INNER JOIN tb_m_comp_contact h ON h.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp i ON h.id_comp = i.id_comp "
        query += "INNER JOIN tb_m_comp_contact j ON j.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp k ON k.id_comp = j.id_comp "
        query += "INNER JOIN tb_prod_order a1 ON a.id_prod_order = a1.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b ON a1.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_pl_category g ON g.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN tb_pl_prod_order_rec z ON a.id_pl_prod_order = z.id_pl_prod_order AND z.id_report_status!='5' "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = a.id_pd_alloc "
        query += "WHERE a.id_report_status = '6' AND ISNULL(z.id_pl_prod_order_rec) AND i.id_departement ='" + id_departement_user + "' "
        query += "ORDER BY a.id_pl_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        data.Columns.Add("images", GetType(Image))
        For i As Integer = 0 To data.Rows.Count - 1
            Dim img As Image
            Dim fileName As String = ""
            If System.IO.File.Exists(product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower) Then
                fileName = product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower
            Else
                fileName = product_image_path & "default" & ".jpg".ToLower
            End If

            img = Image.FromFile(fileName)

            data.Rows(i)("images") = img
        Next
        GCProd.DataSource = data

        If data.Rows.Count > 0 Then
            'show all
            BSave.Enabled = True
            view_list_purchase(GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString, GVProd.GetFocusedRowCellValue("id_pd_alloc").ToString)
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_list_purchase(ByVal id_pl_prod_order As String, ByVal id_pd_alloc_param As String)
        Dim query = "CALL view_pl_prod('" + id_pl_prod_order + "', '0', '" + id_pd_alloc_param + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormProductionPLToWHRecDet.id_pl_prod_order = GVProd.GetFocusedRowCellDisplayText("id_pl_prod_order").ToString

            Dim query As String = String.Format("SELECT a.id_report_status, a.id_delivery, b.pl_prod_order_number,a.id_po_type,DATE_FORMAT(b.pl_prod_order_date,'%Y-%m-%d') as pl_prod_order_datex, b.pl_prod_order_note FROM tb_prod_order a INNER JOIN tb_pl_prod_order b ON a.id_prod_order = b.id_prod_order WHERE b.id_pl_prod_order = '{0}'", GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                'allocation - 27 may 2015
                FormProductionPLToWHRecDet.id_pd_alloc = GVProd.GetFocusedRowCellValue("id_pd_alloc").ToString
                FormProductionPLToWHRecDet.TxtAllocation.Text = GVProd.GetFocusedRowCellValue("pd_alloc").ToString
                FormProductionPLToWHRecDet.viewComp()

                FormProductionPLToWHRecDet.TxtUnitCost.Text = Decimal.Parse(GVProd.GetFocusedRowCellValue("design_cop").ToString)
                FormProductionPLToWHRecDet.TxtOrderNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
                FormProductionPLToWHRecDet.TxtPLCategory.Text = GVProd.GetFocusedRowCellValue("pl_category").ToString
                FormProductionPLToWHRecDet.GroupControlRet.Enabled = True
                FormProductionPLToWHRecDet.GroupControlListBarcode.Enabled = True
                FormProductionPLToWHRecDet.viewDetail()
                FormProductionPLToWHRecDet.view_barcode_list()
                FormProductionPLToWHRecDet.id_pl_prod_order_det_list.Clear()
                FormProductionPLToWHRecDet.check_but()
                FormProductionPLToWHRecDet.BtnInfoSrs.Enabled = True
                FormProductionPLToWHRecDet.id_comp_contact_from = GVProd.GetFocusedRowCellValue("id_comp_contact_from").ToString
                FormProductionPLToWHRecDet.TxtCodeCompFrom.Text = GVProd.GetFocusedRowCellValue("comp_number_from").ToString
                FormProductionPLToWHRecDet.TxtNameCompFrom.Text = GVProd.GetFocusedRowCellValue("comp_name_from").ToString
                FormProductionPLToWHRecDet.id_comp_contact_to = GVProd.GetFocusedRowCellValue("id_comp_contact_to").ToString
                FormProductionPLToWHRecDet.id_comp_to = GVProd.GetFocusedRowCellValue("id_comp_to").ToString
                FormProductionPLToWHRecDet.SLEStorage.EditValue = GVProd.GetFocusedRowCellValue("id_comp_to").ToString
                FormProductionPLToWHRecDet.id_sample = GVProd.GetFocusedRowCellValue("id_sample").ToString
                FormProductionPLToWHRecDet.id_design = GVProd.GetFocusedRowCellValue("id_design").ToString
                FormProductionPLToWHRecDet.TEDesign.Text = GVProd.GetFocusedRowCellValue("design_display_name").ToString
                FormProductionPLToWHRecDet.id_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionPLToWHRecDet.mainVendor()
                FormProductionPLToWHRecDet.TxtPONumber.Text = GVProd.GetFocusedRowCellValue("prod_order_number").ToString
                FormProductionPLToWHRecDet.TxtSeason.Text = GVProd.GetFocusedRowCellValue("season").ToString
                pre_viewImages("2", FormProductionPLToWHRecDet.PEView, GVProd.GetFocusedRowCellValue("id_design").ToString, False)
                FormProductionPLToWHRecDet.PEView.Enabled = True
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpPLProd_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
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
        view_list_purchase(GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString, GVProd.GetFocusedRowCellValue("id_pd_alloc").ToString)
    End Sub
    Private Sub GVProd_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProd.RowClick

    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProd.CustomColumnDisplayText
        'If e.Column.FieldName = "id_delivery" Then
        '    Dim rowhandle As Integer = e.RowHandle
        '    If GVProd.IsGroupRow(rowhandle) Then
        '        rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
        '        e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "delivery")
        '    End If
        'End If
        'If e.Column.FieldName = "id_season" Then
        '    Dim rowhandle As Integer = e.RowHandle
        '    If GVProd.IsGroupRow(rowhandle) Then
        '        rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
        '        e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "season")
        '    End If
        'End If
    End Sub
End Class