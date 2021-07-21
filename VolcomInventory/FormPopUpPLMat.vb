Public Class FormPopUpPLMat
    Public id_pop_up As String = "-1"
    Private Sub FormPopUpPLMat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPL()
    End Sub

    Sub viewPL()
        Dim query As String = "SELECT a.id_currency,a.id_pl_mrs ,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, 
(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,i.prod_order_mrs_number, 
DATE_FORMAT(a.pl_mrs_date,'%d %M %Y') AS pl_mrs_date, a.id_report_status 
FROM tb_pl_mrs a 
INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact 
INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact 
INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status 
INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs 
WHERE a.id_report_status = '6' AND ISNULL(i.id_prod_order)
ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPL.DataSource = data
        If data.Rows.Count > 0 Then
            viewFillEmptyData()
        End If
    End Sub

    Sub viewFillEmptyData()
        Dim query As String = "CALL view_inv_mat_pl('" + GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString + "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormPopUpPLMat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then '
            FormMatRetInProd.TEPONumber.Text = GVProdPL.GetFocusedRowCellValue("pl_mrs_number").ToString
            FormMatRetInProd.id_pl_mrs = GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString
            '
            FormMatRetInProd.GroupControlRet.Enabled = True
            FormMatRetInProd.viewDetailOther(GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString)
            '
            Close()
        End If
    End Sub

    Private Sub GVProdPL_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPL.FocusedRowChanged
        viewFillEmptyData()
    End Sub

    Private Sub GVProdPL_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdPL.ColumnFilterChanged
        viewFillEmptyData()
    End Sub
End Class