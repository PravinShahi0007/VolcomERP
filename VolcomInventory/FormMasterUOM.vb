Public Class FormMasterUOM
    Public action As String
    Public id_uom As String
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    'close form
    Private Sub FormMasterUOM_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        PCUOM.Visible = False
        TxtUOM.Text = ""
    End Sub
    'validate
    Private Sub TxtUOM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtUOM.Validating
        EP_TE_cant_blank(ErrorProviderUom, TxtUOM)
    End Sub
    'load
    Private Sub FormMasterUOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewUOM()
        If action = "upd" Then
            Try
                Dim query As String = String.Format("SELECT * FROM tb_m_uom WHERE id_uom = '{0}'", id_uom)
                Dim data As DataTable = execute_query(query, 1, True, "", "", "", "")
                TxtUOM.Text = data.Rows(0)("uom").ToString
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
    'view
    Sub viewUOM()
        Dim query As String = "SELECT * FROM tb_m_uom"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUOM.DataSource = data
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
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Me.ValidateChildren()
        If TxtUOM.Text.ToString.Length < 1 Then
            errorInput()
        Else
            Dim uom As String = TxtUOM.Text.ToString
            Dim query As String
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_uom(uom) VALUES('{0}')", uom)
                    execute_non_query(query, True, "", "", "", "")
                    viewUOM()
                    PCUOM.Visible = False
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_uom SET uom='{0}' WHERE id_uom='{1}'", uom, id_uom)
                    execute_non_query(query, True, "", "", "", "")
                    viewUOM()
                    PCUOM.Visible = False
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
        TxtUOM.Text = ""
        Cursor = Cursors.Default
    End Sub
    'grid view click
    Private Sub GCUOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCUOM.Click
        action = "upd"
        getDataUpd()
    End Sub
    'upd data
    Sub getDataUpd()
        id_uom = GVUOM.GetFocusedRowCellDisplayText("id_uom").ToString
        TxtUOM.Text = GVUOM.GetFocusedRowCellDisplayText("uom").ToString
    End Sub

    Private Sub FormMasterUOM_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterUOM_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class