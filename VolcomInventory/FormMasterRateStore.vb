Public Class FormMasterRateStore 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_single As Boolean = False

    Private Sub FormMasterRateStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRate()
        If is_single Then
            PanelControlRange.Visible = True
        End If
        check_but_single()
    End Sub

    Private Sub FormMasterRateStore_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterRateStore_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not is_single Then
            FormMain.show_rb(Name)
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub viewRate()
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.getRateStore("-1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStoreRate.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub check_but_single()
        If GVStoreRate.RowCount <= 0 Then
            BtnEditRange.Enabled = False
            BtnDeleteRange.Enabled = False
        Else
            Dim rh As Integer = GVStoreRate.FocusedRowHandle
            If rh >= 0 Then
                BtnEditRange.Enabled = True
                BtnDeleteRange.Enabled = True
            Else
                BtnEditRange.Enabled = False
                BtnDeleteRange.Enabled = False
            End If
        End If
    End Sub

    Private Sub FormMasterRateStore_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If Not is_single Then
            FormMain.hide_rb()
        End If
    End Sub

    Private Sub GVStoreRate_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVStoreRate.DoubleClick
        If GVStoreRate.RowCount > 0 And GVStoreRate.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnEditRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditRange.Click
        'MASTER RATE
        FormMasterRateStoreDet.quick_edit = "1"
        FormMasterRateStoreDet.id_store_rate = Me.GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString
        FormMasterRateStoreDet.action = "upd"
        FormMasterRateStoreDet.ShowDialog()
    End Sub

    Private Sub GVStoreRate_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVStoreRate.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but_single()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVStoreRate_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVStoreRate.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but_single()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddRange.Click
        'Rate store
        FormMasterRateStoreDet.action = "ins"
        FormMasterRateStoreDet.quick_edit = "1"
        FormMasterRateStoreDet.ShowDialog()
    End Sub

    Private Sub BtnDeleteRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteRange.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_store_rate As String = GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString

                'delete write off
                Dim query As String = String.Format("DELETE FROM tb_lookup_store_rate WHERE id_store_rate ='{0}'", id_store_rate)
                execute_non_query(query, True, "", "", "", "")

                'del mark
                viewRate()
                If is_single Then
                    FormFGDistSchemeStoreDet.loadStoreRate()
                End If
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub
End Class