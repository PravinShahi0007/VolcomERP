Public Class FormPopUpRecQC 
    Public id_pop_up As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_rec As String = "-1"
    Private Sub FormPopUpRecQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_prod_order_rec()
    End Sub
    Sub view_prod_order_rec()
        Dim query = "SELECT a.id_report_status,h.report_status,g.season,a.id_prod_order_rec,a.prod_order_rec_number,
                    DATE_ADD(wo.prod_order_wo_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date,
                    delivery_order_date,a.arrive_date,a.delivery_order_number,b.prod_order_number, 
                    prod_order_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to 
                    FROM tb_prod_order_rec a  
                    INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order 
                    LEFT JOIN 
                    (SELECT * FROM tb_prod_order_wo wo WHERE wo.`is_main_vendor`=1 GROUP BY wo.`id_prod_order`) wo ON wo.`id_prod_order`=b.`id_prod_order`
                    INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to 
                    INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp 
                    INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_to  
                    INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp 
                    INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery 
                    INNER JOIN tb_season g ON g.id_season = i.id_season 
                    INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status
                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=b.`id_prod_demand_design`"
        If Not id_prod_order = "-1" Then
            query += "WHERE a.id_prod_order='" & id_prod_order & "' "
        End If
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
        If id_pop_up = "1" Then 'PR WO Prod
            FormProdPRWODet.TEDONumber.Text = GVProdRec.GetFocusedRowCellValue("delivery_order_number").ToString
            FormProdPRWODet.TERecNumber.Text = GVProdRec.GetFocusedRowCellValue("prod_order_rec_number").ToString
            FormProdPRWODet.id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
            FormProdPRWODet.view_list_rec()
            FormProdPRWODet.BPickWO.Enabled = False
            Close()
        ElseIf id_pop_up = "2" Then 'Debit Note Receiving
            Dim newRow As DataRow = (TryCast(FormProdDebitNoteDet.GCProdRec.DataSource, DataTable)).NewRow()
            newRow("id_prod_debit_note_det") = "0"
            newRow("id_prod_order_rec") = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
            newRow("delivery_order_number") = GVProdRec.GetFocusedRowCellValue("name").ToString
            TryCast(FormProdDebitNoteDet.GCProdRec.DataSource, DataTable).Rows.Add(newRow)
            FormProdDebitNoteDet.GCProdRec.RefreshDataSource()
            FormProdDebitNoteDet.GVProdRec.RefreshData()
            Close()
        End If
    End Sub
End Class