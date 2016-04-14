Public Class FormMasterRetCode 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_single As Boolean = False

    Private Sub FormMasterDepartement_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDepartement_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub viewRetCode()
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.getRetCodeQuery("-1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetCode.DataSource = data
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

    Private Sub FormMasterDepartement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRetCode()
        If is_single Then
            PanelControlRange.Visible = True
        End If
        check_but_single()
    End Sub

    Sub check_but_single()
        If GVRetCode.RowCount <= 0 Then
            BtnEditRange.Enabled = False
            BtnDeleteRange.Enabled = False
        Else
            Dim rh As Integer = GVRetCode.FocusedRowHandle
            If rh >= 0 Then
                BtnEditRange.Enabled = True
                BtnDeleteRange.Enabled = True
            Else
                BtnEditRange.Enabled = False
                BtnDeleteRange.Enabled = False
            End If
        End If
    End Sub

    Private Sub FormMasterDepartement_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVRetCode_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetCode.DoubleClick
        If GVRetCode.RowCount > 0 And GVRetCode.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnEditRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditRange.Click
        'MASTER RET CODE
        FormMasterRetCodeDet.quick_edit = "1"
        FormMasterRetCodeDet.id_ret_code = Me.GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString
        FormMasterRetCodeDet.action = "upd"
        FormMasterRetCodeDet.ShowDialog()
    End Sub

    Private Sub GVRetCode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetCode.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but_single()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetCode_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetCode.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but_single()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddRange.Click
        'RETURN CODE
        FormMasterRetCodeDet.action = "ins"
        FormMasterRetCodeDet.quick_edit = "1"
        FormMasterRetCodeDet.ShowDialog()
    End Sub

    Private Sub BtnDeleteRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteRange.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_ret_code As String = GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString

                'delete write off
                Dim query As String = String.Format("DELETE FROM tb_lookup_ret_code WHERE id_ret_code ='{0}'", id_ret_code)
                execute_non_query(query, True, "", "", "", "")

                'del mark
                viewRetCode()
                If is_single Then
                    FormMasterDesignSingle.view_ret_code(FormMasterDesignSingle.LERetCode)
                End If
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub
End Class