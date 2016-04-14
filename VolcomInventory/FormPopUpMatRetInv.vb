Public Class FormPopUpMatRetInv 
    Public id_ret_in As String = "-1"
    Public id_prod_wo As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpMatRetInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRetInProd()
    End Sub

    Sub viewRetInProd()
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_prod_ret_in, a.mat_prod_ret_in_date, a.mat_prod_ret_in_note,h.prod_order_number,b.prod_order_wo_number,desg.design_name,  "
            query += "a.mat_prod_ret_in_number , (e.comp_name) AS comp_from "
            query += "FROM tb_mat_prod_ret_in a "
            query += "INNER JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
            query += "INNER JOIN tb_prod_order h ON b.id_prod_order = h.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = h.id_prod_demand_design "
            query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
            query += "WHERE (a.id_report_status = '4' OR a.id_report_status = '3' OR a.id_report_status = '6') AND a.id_prod_order_wo='" & id_prod_wo & "' ORDER BY a.id_mat_prod_ret_in DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetInProd.DataSource = data
            If data.Rows.Count > 0 Then
                viewDetailReturn()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub viewDetailReturn()
        Dim query As String = "CALL view_mat_prod_ret('" + GVRetInProd.GetFocusedRowCellValue("id_mat_prod_ret_in").ToString + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub

    Private Sub GVRetInProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetInProd.FocusedRowChanged
        viewDetailReturn()
    End Sub
    Private Sub FormPopUpMatRetInv_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then 'formmatinvoiceretdet
            'check if exist
            Dim already = False
            If FormMatInvoiceReturDet.GVRetInProd.RowCount > 0 Then
                For i As Integer = 0 To FormMatInvoiceReturDet.GVRetInProd.RowCount - 1
                    If FormMatInvoiceReturDet.GVRetInProd.GetRowCellValue(i, "id_mat_prod_ret_in").ToString = GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in").ToString Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("This return already on list")
            Else
                Dim newRow As DataRow = (TryCast(FormMatInvoiceReturDet.GCRetInProd.DataSource, DataTable)).NewRow()
                newRow("id_mat_prod_ret_in") = GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in").ToString
                newRow("mat_prod_ret_in_number") = GVRetInProd.GetFocusedRowCellDisplayText("mat_prod_ret_in_number").ToString
                newRow("mat_prod_ret_in_date") = GVRetInProd.GetFocusedRowCellDisplayText("mat_prod_ret_in_date").ToString
                newRow("report_status") = GVRetInProd.GetFocusedRowCellDisplayText("report_status").ToString
                newRow("id_report_status") = GVRetInProd.GetFocusedRowCellDisplayText("id_report_status").ToString

                TryCast(FormMatInvoiceReturDet.GCRetInProd.DataSource, DataTable).Rows.Add(newRow)
                FormMatInvoiceReturDet.GCRetInProd.RefreshDataSource()
                FormMatInvoiceReturDet.check_but()
                FormMatInvoiceReturDet.GVRetInProd.FocusedRowHandle = 0
                'detail PL
                If GVRetDetail.RowCount > 0 Then
                    For i As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Dim newRowx As DataRow = (TryCast(FormMatInvoiceReturDet.GCListPurchase.DataSource, DataTable)).NewRow()
                        newRowx("id_mat_prod_ret_in_det") = GVRetDetail.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString
                        newRowx("id_mat_prod_ret_in") = GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in").ToString
                        newRowx("code") = GVRetDetail.GetRowCellValue(i, "mat_det_code").ToString
                        newRowx("name") = GVRetDetail.GetRowCellValue(i, "mat_det_name").ToString
                        newRowx("inv_pl_mrs_ret_det_qty") = GVRetDetail.GetRowCellValue(i, "mat_prod_ret_in_det_qty")
                        newRowx("price") = GVRetDetail.GetRowCellValue(i, "pl_mrs_det_price")
                        newRowx("uom") = GVRetDetail.GetRowCellValue(i, "uom").ToString
                        newRowx("total_price") = GVRetDetail.GetRowCellValue(i, "total_price")
                        newRowx("id_mat_det") = GVRetDetail.GetRowCellValue(i, "id_mat_det").ToString
                        newRowx("mat_prod_ret_in_number") = GVRetInProd.GetFocusedRowCellDisplayText("mat_prod_ret_in_number").ToString

                        TryCast(FormMatInvoiceReturDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRowx)
                        FormMatInvoiceReturDet.GCListPurchase.RefreshDataSource()
                    Next
                    FormMatInvoiceReturDet.calculate()
                End If

                Close()
            End If
        End If
    End Sub
End Class