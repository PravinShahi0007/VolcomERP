Public Class FormPopUpRecQC 
    Public id_pop_up As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_rec As String = "-1"
    Public id_contact_vendor As String = "-1"

    Public is_show_qc_report1 As Boolean = False

    Private Sub FormPopUpRecQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDesign()
        viewSeason()
        'view_prod_order_rec()

        If is_show_qc_report1 Then
            GridColumnOutstandingRetOut.Visible = False
            GridColumnQtyReject.Visible = False
            GridColumnQtyRetOut.Visible = False
            GridColumnQCReport.Visible = False
        Else
            GridColumnOutstandingRetOut.Visible = False
            GridColumnQtyReject.Visible = False
            GridColumnQtyRetOut.Visible = False
            GridColumnQCReport.Visible = False
        End If
    End Sub

    Sub viewDesign()
        Dim q As String = "SELECT '-' AS prod_order_number,'ALL' AS design_display_name,'-' AS design_code,'0' AS id_design
UNION
SELECT po.prod_order_number,dsg.design_display_name,dsg.design_code,dsg.id_design
FROM tb_prod_order po 
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design AND po.id_report_status='6'
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design"
        viewSearchLookupQuery(SLEDesignStockStore, q, "id_design", "design_display_name", "id_design")
    End Sub
    Sub viewSeason()
        Dim query As String = "SELECT '0' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub
    Sub view_prod_order_rec()
        Dim query = "SELECT dsg.id_qc_wash,pl.pl_category,a.id_report_status,h.report_status,g.season,a.id_prod_order_rec,b.id_prod_order ,a.prod_order_rec_number,a.prod_order_rec_note,
                    DATE_ADD(wo.prod_order_wo_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date, i.delivery,
                    delivery_order_date,a.arrive_date,a.delivery_order_number,b.prod_order_number, rec_qty.sum_qty,wo.price_pc,dsg.id_design,
                    prod_order_rec_date, f.comp_name AS comp_from,f.comp_number AS comp_from_code,d.comp_name AS comp_to,dsg.design_code,CONCAT(LEFT(dsg.design_display_name,3),' ',dsg.design_name) AS design_display_name, RIGHT(dsg.design_display_name,3) AS color 
                    FROM tb_prod_order_rec a  
                    INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order AND a.id_report_status=6
                    INNER JOIN tb_lookup_pl_category pl ON pl.id_pl_category=a.id_pl_category
                    LEFT JOIN 
                    (
                        SELECT wo.*,wod.prod_order_wo_det_price AS price_pc FROM tb_prod_order_wo wo 
                        INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
                        WHERE wo.`is_main_vendor`=1 GROUP BY wo.`id_prod_order_wo`,wo.`id_prod_order`
                    ) wo ON wo.`id_prod_order`=b.`id_prod_order`
                    INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to 
                    INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp 
                    INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from 
                    INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp 
                    INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery 
                    INNER JOIN tb_season g ON g.id_season = i.id_season 
                    INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status
                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=b.`id_prod_demand_design`
                    INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design 
                    INNER JOIN
                    (
                        SELECT rec.id_prod_order_rec,SUM(recd.prod_order_rec_det_qty) AS sum_qty
	                    FROM 
	                    tb_prod_order_rec rec 
	                    LEFT JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec=rec.id_prod_order_rec
	                    GROUP BY rec.id_prod_order_rec 
                    ) rec_qty ON rec_qty.id_prod_order_rec=a.id_prod_order_rec
                    WHERE 1=1 "
        If Not id_prod_order = "-1" Then
            query += "AND a.id_prod_order='" & id_prod_order & "' "
        End If
        If Not id_contact_vendor = "-1" Then
            query += "AND a.id_comp_contact_from='" & id_contact_vendor & "' "
        End If
        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query += "AND dsg.id_design='" & SLEDesignStockStore.EditValue.ToString & "' "
        End If
        If Not SLESeason.EditValue.ToString = "0" Then
            query += "AND g.id_season='" & SLESeason.EditValue.ToString & "' "
        End If
        '
        If id_pop_up = "3" Then
            query += " AND (a.id_pl_category=1 OR a.id_pl_category=5 OR a.id_pl_category=6) "
        End If
        '
        query += "ORDER BY g.date_season_start DESC, a.id_prod_order_rec DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
            If Not id_rec = "-1" Then
                GVProdRec.FocusedRowHandle = find_row(GVProdRec, "id_prod_order_rec", id_rec)
            End If
            view_list_rec(GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString)
        End If
        GVProdRec.BestFitColumns()
    End Sub

    Sub view_list_rec(ByVal id_prod_order_recx As String)
        Dim query = "CALL view_prod_order_rec_det('" & id_prod_order_recx & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub GVProdRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRec.FocusedRowChanged
        If GVProdRec.RowCount > 0 Or Not GVProdRec.IsGroupRow(e.FocusedRowHandle) Then
            Try
                view_list_rec(GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpRecQC_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If GVListPurchase.RowCount > 0 Then
            If id_pop_up = "1" Then 'PR WO Prod
                FormProdPRWODet.TEDONumber.Text = GVProdRec.GetFocusedRowCellValue("delivery_order_number").ToString
                FormProdPRWODet.TERecNumber.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                FormProdPRWODet.id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                FormProdPRWODet.view_list_rec()
                FormProdPRWODet.BPickWO.Enabled = False
                Close()
            ElseIf id_pop_up = "2" Then 'Debit Note Receiving
                'check first
                Dim check_dupe As String = "1"
                For i As Integer = 0 To FormProdDebitNoteDet.GVProdRec.RowCount - 1
                    If GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString = FormProdDebitNoteDet.GVProdRec.GetRowCellValue(i, "id_prod_order_rec").ToString Then
                        check_dupe = "2"
                    End If
                Next

                If check_dupe = "2" Then
                    stopCustom("This receiving already on list.")
                Else
                    Dim date_do As Date = GVProdRec.GetFocusedRowCellValue("est_rec_date").ToString
                    Dim arrive_qc As Date
                    Dim day_late As Integer = 0

                    If GVProdRec.GetFocusedRowCellValue("arrive_date").ToString = "" Then
                        arrive_qc = GVProdRec.GetFocusedRowCellValue("prod_order_rec_date")
                    Else
                        arrive_qc = GVProdRec.GetFocusedRowCellValue("arrive_date")
                    End If

                    Dim span = arrive_qc - date_do

                    If span.Days < 0 Then
                        day_late = 0
                    Else
                        day_late = span.Days
                    End If

                    Dim newRow As DataRow = (TryCast(FormProdDebitNoteDet.GCProdRec.DataSource, DataTable)).NewRow()
                    newRow("id_prod_debit_note_det") = "0"
                    newRow("id_prod_order_rec") = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    newRow("prod_order_rec_number") = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                    newRow("prod_order_number") = GVProdRec.GetFocusedRowCellValue("prod_order_number").ToString
                    newRow("design_code") = GVProdRec.GetFocusedRowCellValue("design_code").ToString
                    newRow("name") = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    newRow("color") = GVProdRec.GetFocusedRowCellValue("color").ToString
                    newRow("name") = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    newRow("qty") = GVProdRec.GetFocusedRowCellValue("sum_qty")
                    newRow("qty_pcs") = GVProdRec.GetFocusedRowCellValue("sum_qty")
                    newRow("delivery_order_number") = GVProdRec.GetFocusedRowCellValue("delivery_order_number").ToString
                    newRow("delivery_order_date") = GVProdRec.GetFocusedRowCellValue("delivery_order_date")
                    newRow("arrive_date") = arrive_qc
                    newRow("est_rec_date") = GVProdRec.GetFocusedRowCellValue("est_rec_date")
                    newRow("claim_price_pc") = GVProdRec.GetFocusedRowCellValue("price_pc")
                    newRow("id_claim_type") = "1"
                    newRow("days_late") = day_late
                    TryCast(FormProdDebitNoteDet.GCProdRec.DataSource, DataTable).Rows.Add(newRow)
                    FormProdDebitNoteDet.GCProdRec.RefreshDataSource()
                    FormProdDebitNoteDet.GVProdRec.RefreshData()
                    FormProdDebitNoteDet.GVProdRec.BestFitColumns()
                    FormProdDebitNoteDet.button_check()
                    Close()
                End If
            ElseIf id_pop_up = "3" Then 'Return Out
                Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                Dim date_created As String = ""

                If data.Rows.Count > 0 Then
                    FormProductionRetOutSingle.TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                    FormProductionRetOutSingle.GroupControlRet.Enabled = True
                    FormProductionRetOutSingle.GroupControlListBarcode.Enabled = True
                    FormProductionRetOutSingle.id_prod_order_det_list.Clear()
                    FormProductionRetOutSingle.BtnInfoSrs.Enabled = True

                    'updated 21 Desember 2015
                    FormProductionRetOutSingle.id_design = GVProdRec.GetFocusedRowCellValue("id_design").ToString
                    FormProductionRetOutSingle.PEView.Enabled = True
                    pre_viewImages("2", FormProductionRetOutSingle.PEView, GVProdRec.GetFocusedRowCellValue("id_design").ToString, False)
                    FormProductionRetOutSingle.id_prod_order_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    FormProductionRetOutSingle.TERecNumber.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                    FormProductionRetOutSingle.id_prod_order = GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString
                    FormProductionRetOutSingle.TxtDesign.Text = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    FormProductionRetOutSingle.TxtSeason.Text = GVProdRec.GetFocusedRowCellValue("season").ToString
                    FormProductionRetOutSingle.mainVendor()

                    'FormProductionRetOutSingle
                    FormProductionRetOutSingle.viewDetailReturn()
                    If Not get_opt_prod_field("is_enable_qc_report1") = "1" Then
                        FormProductionRetOutSingle.view_barcode_list()
                    End If
                    FormProductionRetOutSingle.check_but()
                    '
                    '
                    Close()
                Else
                    stopCustom("Data is empty.")
                End If
            ElseIf id_pop_up = "4" Then 'final clearance
                If GVProdRec.RowCount > 0 Then
                    FormProductionFinalClearDet.id_prod_order = GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString
                    FormProductionFinalClearDet.id_prod_order_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    FormProductionFinalClearDet.id_design = GVProdRec.GetFocusedRowCellValue("id_design").ToString
                    FormProductionFinalClearDet.TxtOrder.Text = GVProdRec.GetFocusedRowCellValue("prod_order_number").ToString
                    FormProductionFinalClearDet.TERec.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                    FormProductionFinalClearDet.TxtSeason.Text = GVProdRec.GetFocusedRowCellValue("season").ToString
                    FormProductionFinalClearDet.TxtDel.Text = GVProdRec.GetFocusedRowCellValue("delivery").ToString
                    FormProductionFinalClearDet.TxtVendorCode.Text = GVProdRec.GetFocusedRowCellValue("comp_from_code").ToString
                    FormProductionFinalClearDet.TxtVendorName.Text = GVProdRec.GetFocusedRowCellValue("comp_from").ToString
                    FormProductionFinalClearDet.TxtStyleCode.Text = GVProdRec.GetFocusedRowCellValue("design_code").ToString
                    FormProductionFinalClearDet.TxtStyle.Text = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    FormProductionFinalClearDet.viewDetail()
                    FormProductionFinalClearDet.BtnInfoSrs.Enabled = True
                    pre_viewImages("2", FormProductionFinalClearDet.PEView, FormProductionFinalClearDet.id_design, False)

                    Close()
                Else
                    warningCustom("No data selected.")
                End If
            ElseIf id_pop_up = "5" Then 'QC SNI Out
                If GVListPurchase.RowCount > 0 Then
                    'check
                    Dim is_ok As Boolean = True

                    For i = 0 To FormSNIOut.GVDetail.RowCount - 1
                        If FormSNIOut.GVDetail.GetRowCellValue(i, "id_product").ToString = GVListPurchase.GetFocusedRowCellValue("id_product").ToString Then
                            is_ok = False
                            warningCustom("Product telah dipilih pada list")
                            Exit For
                        End If
                    Next

                    If is_ok Then
                        Dim newRow As DataRow = (TryCast(FormSNIOut.GCDetail.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString
                        newRow("id_prod_order_det") = GVListPurchase.GetFocusedRowCellValue("id_prod_order_det").ToString
                        newRow("id_prod_order_rec") = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                        newRow("id_prod_order_rec_det") = GVListPurchase.GetFocusedRowCellValue("id_prod_order_rec_det").ToString
                        newRow("prod_order_number") = GVProdRec.GetFocusedRowCellValue("prod_order_number").ToString
                        newRow("prod_order_rec_number") = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                        newRow("id_product") = GVListPurchase.GetFocusedRowCellValue("id_product").ToString
                        newRow("product_full_code") = GVListPurchase.GetFocusedRowCellValue("code").ToString
                        newRow("name") = GVListPurchase.GetFocusedRowCellValue("name").ToString
                        newRow("size") = GVListPurchase.GetFocusedRowCellValue("size").ToString
                        newRow("qty") = 0
                        TryCast(FormSNIOut.GCDetail.DataSource, DataTable).Rows.Add(newRow)
                        FormSNIOut.GCDetail.RefreshDataSource()
                        FormSNIOut.GVDetail.RefreshData()
                        FormSNIOut.can_scan()
                    End If
                    'FormSNIOut.gv.id_prod_order = GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString
                    'FormProductionFinalClearDet.id_prod_order_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    'FormProductionFinalClearDet.id_design = GVProdRec.GetFocusedRowCellValue("id_design").ToString
                    'FormProductionFinalClearDet.TxtOrder.Text = GVProdRec.GetFocusedRowCellValue("prod_order_number").ToString
                    'FormProductionFinalClearDet.TERec.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                    'FormProductionFinalClearDet.TxtSeason.Text = GVProdRec.GetFocusedRowCellValue("season").ToString
                    'FormProductionFinalClearDet.TxtDel.Text = GVProdRec.GetFocusedRowCellValue("delivery").ToString
                    'FormProductionFinalClearDet.TxtVendorCode.Text = GVProdRec.GetFocusedRowCellValue("comp_from_code").ToString
                    'FormProductionFinalClearDet.TxtVendorName.Text = GVProdRec.GetFocusedRowCellValue("comp_from").ToString
                    'FormProductionFinalClearDet.TxtStyleCode.Text = GVProdRec.GetFocusedRowCellValue("design_code").ToString
                    'FormProductionFinalClearDet.TxtStyle.Text = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    'FormProductionFinalClearDet.viewDetail()
                    'FormProductionFinalClearDet.BtnInfoSrs.Enabled = True
                    'pre_viewImages("2", FormProductionFinalClearDet.PEView, FormProductionFinalClearDet.id_design, False)

                    'Close()

                Else
                    warningCustom("No data selected.")
                End If
            ElseIf id_pop_up = "6" Then 'qc report 1
                Dim query As String = String.Format("SELECT id_report_status,id_delivery,prod_order_number,id_po_type,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                Dim date_created As String = ""

                If data.Rows.Count > 0 Then
                    FormQCReport1Det.TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                    FormQCReport1Det.GroupControlRet.Enabled = True
                    FormQCReport1Det.GroupControlListBarcode.Enabled = True
                    FormQCReport1Det.id_qc_report1_det_list.Clear()
                    FormQCReport1Det.BtnInfoSrs.Enabled = True

                    'updated 21 Desember 2015
                    FormQCReport1Det.id_design = GVProdRec.GetFocusedRowCellValue("id_design").ToString
                    FormQCReport1Det.id_prod_order_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    FormQCReport1Det.TERecNumber.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
                    FormQCReport1Det.id_prod_order = GVProdRec.GetFocusedRowCellValue("id_prod_order").ToString
                    FormQCReport1Det.TxtDesign.Text = GVProdRec.GetFocusedRowCellValue("design_display_name").ToString
                    FormQCReport1Det.TxtSeason.Text = GVProdRec.GetFocusedRowCellValue("season").ToString

                    FormQCReport1Det.design_need_wash = GVProdRec.GetFocusedRowCellValue("id_qc_wash").ToString

                    'FormProductionRetOutSingle
                    FormQCReport1Det.viewDetailReturn()
                    FormQCReport1Det.view_barcode_list()
                    Close()
                Else
                    stopCustom("Data is empty.")
                End If
            End If

        Else
            stopCustom("Please choose receiving first")
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_prod_order_rec()
    End Sub
End Class