Imports DevExpress.XtraEditors

Public Class FormMasterUserMappingSingle
    Public id_menu As String
    Dim id_role As String
    Dim check_value As String
    'Load
    Private Sub FormMasterUserMappingSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRole()
    End Sub
    Sub viewRole()
        Dim query As String = "SELECT *, "
        query += "(SELECT IF(COUNT(*)=0, 'True', 'False') FROM tb_menu_access WHERE tb_menu_access.id_menu='" + id_menu + "' AND tb_menu_access.id_role=a.id_role) AS check_val "
        query += "FROM tb_m_role a ORDER BY a.role ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
    End Sub
    'Row Click
    Private Sub GVRole_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRole.RowClick
        id_role = GVRole.GetFocusedRowCellDisplayText("id_role").ToString
        check_value = GVRole.GetFocusedRowCellDisplayText("check_val").ToString
        If check_value = "True" Then 'Menu blm diset
            processStart()
            Try
                Dim query = String.Format("INSERT INTO tb_menu_access(id_role, id_menu) VALUES('{0}', '{1}')", id_role, id_menu)
                execute_non_query(query, True, "", "", "", "")
                viewRole()
                processEnd()
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf check_value = "False" Then 'Menu sudah diset
            Dim confirm As DialogResult = XtraMessageBox.Show("Are you sure to disable menu for " + GVRole.GetFocusedRowCellDisplayText("role").ToString + " role?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                processStart()
                Try
                    Dim query = String.Format("DELETE FROM tb_menu_access WHERE id_menu='{0}' AND id_role='{1}'", id_menu, id_role)
                    execute_non_query(query, True, "", "", "", "")
                    viewRole()
                    processEnd()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
    End Sub
    'Form Close
    Private Sub FormMasterUserMappingSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Close
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    'When Process Start
    Private Sub processStart()
        GCRole.Enabled = False
        PCWait.Visible = True
        BtnClose.Enabled = False
        Me.ControlBox = False
    End Sub
    'When Process End
    Private Sub processEnd()
        PCWait.Visible = False
        GCRole.Enabled = True
        BtnClose.Enabled = True
        Me.ControlBox = True
    End Sub
End Class