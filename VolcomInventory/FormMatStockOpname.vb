Public Class FormMatStockOpname 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormMatStockOpname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_so()
        show_but()
    End Sub

    Private Sub FormMatStockOpname_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        show_but()
    End Sub

    Private Sub FormMatStockOpname_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub show_but()
        If GVMatPR.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub view_so()
        Dim query As String = "SELECT a.id_mat_so,a.mat_so_number,a.id_report_status,DATE_FORMAT(a.mat_so_date_created,'%d %M %Y') AS mat_so_date_created,DATE_FORMAT(a.mat_so_last_update,'%d %M %Y') AS mat_so_last_update,b.report_status,a.id_lock,c.lock FROM tb_mat_so a INNER JOIN tb_lookup_report_status b ON b.id_report_status=a.id_report_status INNER JOIN tb_lookup_lock c ON c.id_lock=a.id_lock"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPR.DataSource = data
    End Sub

    'Private Sub GVMatPR_CustomDrawGroupRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVMatPR.CustomDrawGroupRow
    '    TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty
    'End Sub

    Private Sub GVMatPR_GroupRowCollapsing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVMatPR.GroupRowCollapsing
        e.Allow = False
    End Sub

    Private Sub GVMatPR_GroupRowExpanding(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVMatPR.GroupRowExpanding
        e.Allow = False
    End Sub
End Class