Public Class FormInfoPLSampleDel 
    Public id_pl_sample_del As String
    Public id_sample_return As String = "-1"
    Private Sub FormInfoPLSampleDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPLDet()
    End Sub

    Sub viewPLDet()
        Dim query As String = ""
        'MsgBox(id_sample_return)
        If id_sample_return = "-1" Then
            query = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
        Else
            query = "CALL view_pl_sample_limit2('" + id_pl_sample_del + "', '" + id_sample_return + "')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        viewDrawerOrigin()
    End Sub

    Sub viewDrawerOrigin()
        'MsgBox("BT")
        Dim id_sample As String = GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim query As String = "SELECT * FROM tb_pl_sample_del_det a "
        query += "INNER JOIN tb_pl_sample_del b ON a.id_pl_sample_del = b.id_pl_sample_del "
        query += "INNER JOIN tb_sample_requisition_det c ON a.id_sample_requisition_det = c.id_sample_requisition_det "
        query += "INNER JOIN tb_m_wh_drawer d ON d.id_wh_drawer = a.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack e ON e.id_wh_rack = d.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator f ON e.id_wh_locator = f.id_wh_locator "
        query += "INNER JOIN tb_m_comp g ON g.id_comp = f.id_comp "
        query += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' AND c.id_sample = '" + id_sample + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawerDetail.DataSource = data
        viewCreatedReturn()
    End Sub

    Sub viewCreatedReturn()
        Dim id_sample As String = GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim query As String = "SELECT * FROM tb_sample_return_det a "
        query += "INNER JOIN tb_sample_return b ON a.id_sample_return = b.id_sample_return "
        query += "INNER JOIN tb_m_wh_drawer d ON d.id_wh_drawer = a.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack e ON e.id_wh_rack = d.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator f ON e.id_wh_locator = f.id_wh_locator "
        query += "INNER JOIN tb_m_comp g ON g.id_comp = f.id_comp "
        query += "WHERE b.id_pl_sample_del = '" + id_pl_sample_del + "' AND a.id_sample = '" + id_sample + "' AND b.id_report_status!='5' "
        If id_sample_return <> "-1" Then
            query += "AND a.id_sample_return!='" + id_sample_return + "' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCreatedReturn.DataSource = data
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        viewDrawerOrigin()
        viewCreatedReturn()
    End Sub
End Class