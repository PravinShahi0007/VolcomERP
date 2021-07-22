﻿Public Class FormExternalUserDet
    Public id_user As String = "-1"

    Public id_store As String = "-1"

    Private Sub FormExternalUserDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_store()

        If Not id_store = "-1" Then
            LabelControl6.Visible = False
            TECode.Visible = False

            SLUEStore.EditValue = id_store
        End If

        If Not id_user = "-1" Then
            Dim data As DataTable = execute_query("SELECT username, name_external, position_external, id_store, (SELECT st_user_code FROM tb_st_user WHERE id_user = '" + id_user + "') AS st_user_code FROM tb_m_user WHERE id_user = '" + id_user + "'", -1, True, "", "", "", "")

            TEName.EditValue = data.Rows(0)("name_external").ToString
            TEPosition.EditValue = data.Rows(0)("position_external").ToString
            TEUsername.EditValue = data.Rows(0)("username").ToString
            SLUEStore.EditValue = data.Rows(0)("id_store").ToString
            TECode.EditValue = data.Rows(0)("st_user_code").ToString
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim messages As String = ""

        'check duplicate username
        Dim total_username As String = execute_query("SELECT COUNT(*) FROM tb_m_user WHERE username = '" + addSlashes(TEUsername.EditValue.ToString) + "' AND id_user <> '" + id_user + "'", 0, True, "", "", "", "")

        If Not total_username = "0" Then
            messages = "Username already use."
        End If

        'check duplicate code
        If id_store = "-1" Then
            Dim total_code As String = execute_query("SELECT COUNT(*) FROM tb_st_user WHERE st_user_code = '" + addSlashes(TECode.EditValue.ToString) + "' AND id_user <> '" + id_user + "'", 0, True, "", "", "", "")

            If Not total_code = "0" Then
                messages = "Code already use."
            End If
        End If

        'check empty
        If id_store = "-1" Then
            If id_user = "-1" Then
                If TEName.Text = "" Or TEPosition.Text = "" Or TEUsername.Text = "" Or TEPassword.Text = "" Or TECode.Text = "" Then
                    messages = "Name, position, username, password & code can't be blank."
                End If
            Else
                If TEName.Text = "" Or TEPosition.Text = "" Or TEUsername.Text = "" Or TECode.Text = "" Then
                    messages = "Name, position, username & code can't be blank."
                End If
            End If
        Else
            If id_user = "-1" Then
                If TEName.Text = "" Or TEPosition.Text = "" Or TEUsername.Text = "" Or TEPassword.Text = "" Then
                    messages = "Name, position, username, password & code can't be blank."
                End If
            Else
                If TEName.Text = "" Or TEPosition.Text = "" Or TEUsername.Text = "" Then
                    messages = "Name, position, username & code can't be blank."
                End If
            End If
        End If

        'insert to database
        If messages = "" Then
            If id_user = "-1" Then
                'new
                id_user = execute_query("INSERT INTO tb_m_user (id_role, username, password, name_external, position_external, is_external_user, id_store) VALUES (119, '" + addSlashes(TEUsername.EditValue.ToString) + "', MD5('" + addSlashes(TEPassword.EditValue.ToString) + "'), '" + addSlashes(TEName.EditValue.ToString) + "', '" + addSlashes(TEPosition.EditValue.ToString) + "', '1', '" + SLUEStore.EditValue.ToString + "'); SELECT LAST_INSERT_ID();", 0, True, "", "", "", "")

                If id_store = "-1" Then
                    execute_non_query("INSERT INTO tb_st_user (id_user, st_user_code, role) VALUES ('" + id_user + "', '" + addSlashes(TECode.EditValue.ToString) + "', '5')", True, "", "", "", "")
                Else
                    execute_non_query("INSERT INTO tb_st_user (id_user, role) VALUES ('" + id_user + "', '5')", True, "", "", "", "")
                End If
            Else
                'update
                If TEPassword.Text = "" Then
                    execute_non_query("UPDATE tb_m_user SET id_role = 119, username = '" + addSlashes(TEUsername.EditValue.ToString) + "', name_external = '" + addSlashes(TEName.EditValue.ToString) + "', position_external = '" + addSlashes(TEPosition.EditValue.ToString) + "', id_store = '" + SLUEStore.EditValue.ToString + "' WHERE id_user = '" + id_user + "'", True, "", "", "", "")
                Else
                    execute_non_query("UPDATE tb_m_user SET id_role = 119, username = '" + addSlashes(TEUsername.EditValue.ToString) + "', password = MD5('" + addSlashes(TEPassword.EditValue.ToString) + "'), name_external = '" + addSlashes(TEName.EditValue.ToString) + "', position_external = '" + addSlashes(TEPosition.EditValue.ToString) + "', id_store = '" + SLUEStore.EditValue.ToString + "' WHERE id_user = '" + id_user + "'", True, "", "", "", "")
                End If

                If id_store = "-1" Then
                    execute_non_query("UPDATE tb_st_user SET st_user_code = '" + addSlashes(TECode.EditValue.ToString) + "' WHERE id_user = '" + id_user + "'", True, "", "", "", "")
                End If
            End If

            infoCustom("User external saved.")

            FormExternalUser.load_form()

            Close()
        Else
            stopCustom(messages)
        End If
    End Sub

    Sub view_store()
        Dim where As String = ""

        If Not id_store = "-1" Then
            where = "WHERE id_store IN (" + id_store + ")"
        End If

        viewSearchLookupQuery(SLUEStore, "SELECT id_store, store_name FROM tb_m_store " + where, "id_store", "store_name", "id_store")
    End Sub

    Private Sub FormExternalUserDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub TEName_EditValueChanged(sender As Object, e As EventArgs) Handles TEName.EditValueChanged

    End Sub
End Class