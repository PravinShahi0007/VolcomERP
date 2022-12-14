Public Class FormEmpUniPeriod
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim is_first_load As Boolean = True

    Private Sub FormEmpUniPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewUniformPeriod()
        checkSizeProfileSetup()
    End Sub

    Sub checkSizeProfileSetup()
        Dim is_enable_size_profile As String = get_setup_field("is_enable_size_profile")
        If is_enable_size_profile = "1" Then
            CheckEdit1.EditValue = True
        Else
            CheckEdit1.EditValue = False
        End If
        is_first_load = False
    End Sub

    Private Sub FormEmpUniPeriod_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormEmpUniPeriod_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVUni.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = 0
        Try
            indeks = GVUni.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub viewUniformPeriod()
        Cursor = Cursors.WaitCursor

        Dim query_c As ClassEmpUni = New ClassEmpUni()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUni.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVUni_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVUni.FocusedRowChanged

    End Sub

    Private Sub GVUni_DoubleClick(sender As Object, e As EventArgs) Handles GVUni.DoubleClick
        If GVUni.FocusedRowHandle >= 0 And GVUni.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If GVUni.FocusedRowHandle >= 0 And GVUni.RowCount > 0 Then
            If GVUni.GetFocusedRowCellValue("id_status").ToString = "1" Then
                EnablePeriodToolStripMenuItem.Visible = False
                DisablePeriodToolStripMenuItem.Visible = True
            ElseIf GVUni.GetFocusedRowCellValue("id_status").ToString = "2" Then
                EnablePeriodToolStripMenuItem.Visible = True
                DisablePeriodToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub EnablePeriodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnablePeriodToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVUni.RowCount > 0 And GVUni.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to enable this period?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id As String = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                Dim query As String = "UPDATE tb_emp_uni_period SET id_status='1' WHERE id_emp_uni_period='" + GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString + "' "
                execute_non_query(query, True, "", "", "", "")
                viewUniformPeriod()
                GVUni.FocusedRowHandle = find_row(GVUni, "id_emp_uni_period", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DisablePeriodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisablePeriodToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVUni.RowCount > 0 And GVUni.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to disable this period?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id As String = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                Dim query As String = "UPDATE tb_emp_uni_period SET id_status='2' WHERE id_emp_uni_period='" + GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString + "' "
                execute_non_query(query, True, "", "", "", "")
                viewUniformPeriod()
                GVUni.FocusedRowHandle = find_row(GVUni, "id_emp_uni_period", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If Not is_first_load Then
            Dim info As String = ""
            Dim is_enable_size_profile = ""
            If CheckEdit1.EditValue = True Then
                is_enable_size_profile = "1"
                info = "Pengaturan size berhasil diaktifkan"
            Else
                is_enable_size_profile = "2"
                info = "Pengaturan size berhasil dinonaktifkan"
            End If
            Dim query As String = "UPDATE tb_opt set is_enable_size_profile='" + is_enable_size_profile + "' "
            execute_non_query(query, True, "", "", "", "")
            infoCustom(info)
        End If
    End Sub
End Class