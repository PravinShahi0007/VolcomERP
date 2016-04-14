Public Class FormPopUpMatReq
    Dim id_mrs As String
    Public id_pop_up As String
    Public is_other As String = "-1"

    'Form
    Private Sub FormPopUpMatReq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            viewmatReqProd()
        End If
    End Sub

    'View Data
    Sub viewMatReqprod()
        Dim query As String = ""
        query += "SELECT a.id_prod_order_mrs, a.prod_order_mrs_number, a.prod_order_mrs_date,prod_o.prod_order_number, "
        query += "a.prod_order_mrs_note, (c.comp_name) AS comp_from, (c.id_comp) AS id_comp_from, (c.comp_number) AS comp_code_from, a.id_comp_contact_req_from,a.id_comp_contact_req_to, "
        query += "f.report_status, a.id_report_status "
        query += "FROM tb_prod_order_mrs a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_req_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_prod_order prod_o ON prod_o.id_prod_order = a.id_prod_order "
        query += "WHERE (a.id_report_status = '3' OR a.id_report_status = '4' OR a.id_report_status = '6') "
        If is_other = "1" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then
                'mat wo
                query += " AND ISNULL(a.id_prod_order) AND NOT ISNULL(a.id_mat_wo) "
            Else
                'other
                query += " AND ISNULL(a.id_prod_order) AND ISNULL(a.id_mat_wo)  "
            End If

        Else
            query += " AND NOT ISNULL(a.id_prod_order) "
        End If
        query += "ORDER BY a.id_prod_order_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReq.DataSource = data
        If data.Rows.Count > 0 Then
            'show
            viewDetail()
            BtnChoose.Enabled = True
        Else
            'hide 
            BtnChoose.Enabled = False
        End If
    End Sub

    Sub viewDetail()
        id_mrs = GVReq.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
        Dim query As String = "CALL view_prod_order_mrs('" + id_mrs + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMat.DataSource = data
    End Sub

    'GridView
    Private Sub GVReq_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVReq.RowClick
        viewDetail()
    End Sub
    'Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then
            FormMatPLSingle.TxtSRSNumber.Text = GVReq.GetFocusedRowCellValue("prod_order_mrs_number").ToString
            FormMatPLSingle.id_comp_contact_to = GVReq.GetFocusedRowCellValue("id_comp_contact_req_from")
            FormMatPLSingle.id_comp_to = GVReq.GetFocusedRowCellValue("id_comp_from")
            FormMatPLSingle.TxtCodeCompTo.Text = GVReq.GetFocusedRowCellValue("comp_code_from").ToString
            FormMatPLSingle.TxtNameCompTo.Text = GVReq.GetFocusedRowCellValue("comp_from").ToString
            FormMatPLSingle.id_mrs = GVReq.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
            FormMatPLSingle.viewFillEmptyData()
            FormMatPLSingle.GroupControlDrawer.Enabled = True
            FormMatPLSingle.GroupControlDetailSingle.Enabled = True
            FormMatPLSingle.BtnInfoSrs.Enabled = True
            Close()
        End If
    End Sub

    Private Sub FormPopUpMatReq_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class