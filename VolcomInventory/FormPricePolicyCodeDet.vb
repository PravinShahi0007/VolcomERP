Public Class FormPricePolicyCodeDet
    Public action As String = "-1"
    Public id As String = "-1"
    Dim id_code_price_policy As String = get_setup_field("id_code_price_policy")

    Private Sub FormPricePolicyCodeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Private Sub FormPricePolicyCodeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Height = 130
        Else
            Height = 245
            Dim cpc As New ClassPricePolicy()
            Dim data As DataTable = cpc.dataMain("AND cd.id_code_detail = '" + id + "' ", "1")
            TxtCode.Text = data.Rows(0)("code").ToString
            TxtDesc.Text = data.Rows(0)("description").ToString
            'normal
            TxtNormalFrom.EditValue = 0
            TxtNormalUntil.EditValue = data.Rows(0)("normal")
            '30
            Txt30Until.EditValue = data.Rows(0)("mkd_30")
            '50
            Txt50Until.EditValue = data.Rows(0)("mkd_50")
            '70
            Txt70Until.EditValue = data.Rows(0)("mkd_70")
            'fix
            TxtFixUntil.EditValue = data.Rows(0)("mkd_fix")
            allow_status()
            tabOpt()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCreate.Visible = False
        TxtNormalFrom.Enabled = False
        Txt30From.Enabled = False
        Txt50From.Enabled = False
        Txt70From.Enabled = False
        TxtFixFrom.Enabled = False
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        tabCheck()
        If cond_check Then
            XTCData.SelectedTabPageIndex = XTCData.SelectedTabPageIndex + 1
            tabOpt()
        End If
    End Sub

    Dim cond_check As Boolean = True
    Sub tabCheck()
        cond_check = True
        If XTCData.SelectedTabPageIndex = 0 Then
            'normal
            If TxtNormalUntil.EditValue = 0 Then
                stopCustom("Please input age")
                cond_check = False
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            '30
            If Txt30Until.EditValue = 0 Then
                stopCustom("Please input age")
                cond_check = False
            End If
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            '50
            If Txt50Until.EditValue = 0 Then
                stopCustom("Please input age")
                cond_check = False
            End If
        ElseIf XTCData.SelectedTabPageIndex = 3 Then
            '70
            If Txt70Until.EditValue = 0 Then
                stopCustom("Please input age")
                cond_check = False
            End If
        ElseIf XTCData.SelectedTabPageIndex = 4 Then
            'fix
            If TxtFixUntil.EditValue = 0 Then
                stopCustom("Please input age")
                cond_check = False
            End If
        End If
    End Sub

    Sub tabOpt()
        If XTCData.SelectedTabPageIndex = 0 Then
            'normal
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = False
            TxtNormalUntil.Focus()
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            '30
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
            Txt30Until.Focus()
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            '50
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
            Txt50Until.Focus()
        ElseIf XTCData.SelectedTabPageIndex = 3 Then
            '70
            BtnSave.Visible = False
            BtnNext.Visible = True
            BtnPrev.Visible = True
            Txt70Until.Focus()
        ElseIf XTCData.SelectedTabPageIndex = 4 Then
            'fix
            BtnSave.Visible = True
            BtnNext.Visible = False
            BtnPrev.Visible = True
            TxtFixUntil.Focus()
        End If
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        tabCheck()
        If cond_check Then
            XTCData.SelectedTabPageIndex = XTCData.SelectedTabPageIndex - 1
            tabOpt()
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        saveChanges()
    End Sub

    Sub saveChanges()
        Cursor = Cursors.WaitCursor
        Dim code_check As String = addSlashes(TxtCode.Text)
        Dim cond_code_exist As Boolean = False
        Dim qcek As String = "SELECT * FROM tb_m_code_detail cd WHERE cd.id_code='" + id_code_price_policy + "' AND cd.code='" + code_check + "' AND cd.id_code_detail!='" + id + "' "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            cond_code_exist = True
        End If

        'cek use in design
        Dim cond_used As Boolean = False
        If action = "upd" Then
            Dim qd As String = "SELECT * FROM tb_m_design_code WHERE id_code_detail='" + id + "' "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            If dd.Rows.Count > 0 Then
                cond_used = True
            End If
        End If

        If cond_code_exist Then
            stopCustom("Code already exist")
        ElseIf cond_used Then
            stopCustom("Can't update because this code already used")
        ElseIf TxtNormalUntil.EditValue <> 0 Or Txt30Until.EditValue <> 0 Or Txt50Until.EditValue <> 0 Or Txt70Until.EditValue <> 0 Or TxtFixUntil.EditValue <> 0 Then
            stopCustom("Please input all data")
        Else
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create this code. Click Yes to continue setup detail?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "INSERT INTO tb_m_code_detail(id_code, code, display_name, code_detail_name) VALUES('" + id_code_price_policy + "','" + code_check + "', '" + code_check + "', '" + addSlashes(TxtDesc.Text) + "'); 
                    SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("INSERT INTO tb_m_design_price_policy(id_code_detail) VALUES('" + id + "'); ", True, "", "", "", "")

                    'refresh
                    FormPricePolicyCode.viewData()
                    FormPricePolicyCode.GVData.FocusedRowHandle = find_row(FormPricePolicyCode.GVData, "id_code_detail", id)
                    action = "upd"
                    actionLoad()
                    infoCustom("Please setup detail aging")
                End If
            Else
                Dim query As String = "UPDATE tb_m_code_detail SET code='" + code_check + "',display_name='" + code_check + "',code_detail_name='" + addSlashes(TxtDesc.Text) + "'   
                WHERE id_code_detail='" + id + "'; UPDATE tb_m_design_price_policy SET normal='" + decimalSQL(TxtNormalUntil.EditValue.tos) + "',
                mkd_30='" + decimalSQL(Txt30Until.EditValue.ToString) + "', mkd_50='" + decimalSQL(Txt50Until.EditValue.ToString) + "',
                mkd_70='" + decimalSQL(Txt70Until.EditValue.ToString) + "', mkd_fix='" + decimalSQL(TxtFixUntil.EditValue.ToString) + "'
                WHERE id_code_detail='" + id + "'; "
                execute_non_query(query, True, "", "", "", "")
                'refresh
                FormPricePolicyCode.viewData()
                FormPricePolicyCode.GVData.FocusedRowHandle = find_row(FormPricePolicyCode.GVData, "id_code_detail", id)
                action = "upd"
                actionLoad()
                infoCustom("Save changes successfully")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNormalUntil_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNormalUntil.EditValueChanged
        Try
            Txt30From.EditValue = TxtNormalUntil.EditValue + 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txt30Until_EditValueChanged(sender As Object, e As EventArgs) Handles Txt30Until.EditValueChanged
        Try
            Txt50From.EditValue = Txt30Until.EditValue + 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txt50Until_EditValueChanged(sender As Object, e As EventArgs) Handles Txt50Until.EditValueChanged
        Try
            Txt70From.EditValue = Txt50Until.EditValue + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt70Until_EditValueChanged(sender As Object, e As EventArgs) Handles Txt70Until.EditValueChanged
        Try
            TxtFixFrom.EditValue = Txt70Until.EditValue + 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtFixUntil_EditValueChanged(sender As Object, e As EventArgs) Handles TxtFixUntil.EditValueChanged

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class