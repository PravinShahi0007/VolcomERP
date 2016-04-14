Public Class FormSampleRet
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bnew_active2 As String = "1"
    Dim bedit_active2 As String = "1"
    Dim bdel_active2 As String = "1"

    'Form Load
    Private Sub FormSampleRet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRetOut()
        viewRetIn()
    End Sub
    'Activated Form
    Private Sub FormSampleRet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        pageChanged()
    End Sub
    'Deadactivate Form
    Private Sub FormSampleRet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Seleceted Page Changed
    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturn.SelectedPageChanged
        pageChanged()
    End Sub
    Sub pageChanged()
        If XTCReturn.SelectedTabPageIndex = 0 Then 'Return Out
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            checkFormAccess(Name)
            button_main(bnew_active2, bedit_active2, bdel_active2)
        End If
    End Sub
    'View Data
    Sub viewRetOut()
        Try
            Dim query As String = "SELECT a.id_sample_purc_ret_out, a.sample_purc_ret_out_date, a.sample_purc_ret_out_due_date, a.sample_purc_ret_out_note,  "
            query += "a.sample_purc_ret_out_number , b.sample_purc_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to "
            query += "FROM tb_sample_purc_ret_out a "
            query += "INNER JOIN tb_sample_purc b ON a.id_sample_purc = b.id_sample_purc "
            query += "INNER JOIN tb_season c ON b.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "ORDER BY a.id_sample_purc_ret_out DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetOut.DataSource = data
            If data.Rows.Count > 0 Then
                bnew_active = 1
                bdel_active = 1
                bedit_active = 1
            Else
                bnew_active = 1
                bdel_active = 0
                bedit_active = 0
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub viewRetIn()
        Try
            Dim query As String = "SELECT a.id_sample_purc_ret_in, a.sample_purc_ret_in_date, a.sample_purc_ret_in_note,  "
            query += "a.sample_purc_ret_in_number , b.sample_purc_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to "
            query += "FROM tb_sample_purc_ret_in a "
            query += "INNER JOIN tb_sample_purc b ON a.id_sample_purc = b.id_sample_purc "
            query += "INNER JOIN tb_season c ON b.id_season = c.id_season "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
            query += "ORDER BY a.id_sample_purc_ret_in DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetIn.DataSource = data
            If data.Rows.Count > 0 Then
                bnew_active2 = 1
                bdel_active2 = 1
                bedit_active2 = 1
            Else
                bnew_active2 = 1
                bdel_active2 = 0
                bedit_active2 = 0
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'Focus Row Changed
    Private Sub GVRetOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetOut.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVRetIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetIn.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
End Class