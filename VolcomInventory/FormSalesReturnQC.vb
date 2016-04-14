Public Class FormSalesReturnQC 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturnQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesReturnQC()
    End Sub

    Private Sub FormSalesReturnQC_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesReturnQC_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewSalesReturnQC()
        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnQC.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If GVSalesReturnQC.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVSalesReturnQC_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnQC.DoubleClick
        If GVSalesReturnQC.RowCount > 0 And GVSalesReturnQC.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnQCDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnQCDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturnQC.PopupMenuShowing
        If GVSalesReturnQC.RowCount > 0 And GVSalesReturnQC.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVSalesReturnQC.GetFocusedRowCellValue("id_report_status").ToString
            If id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrint.Visible = False
            Else
                SMPrint.Visible = True
            End If

            If id_stt <> "1" And id_stt <> "2" And id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrePrint.Visible = False
            Else
                SMPrePrint.Visible = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub
End Class