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
        Else
            BtnCreate.Text = "Save Changes"
            Dim cpc As New ClassPricePolicy()
            Dim data As DataTable = cpc.dataMain("AND cd.id_code_detail = '" + id + "' ", "1")
            TxtCode.Text = data.Rows(0)("code").ToString
            TxtDesc.Text = data.Rows(0)("description").ToString
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dpp.id_design_price_policy,dpp.id_code_detail, dpp.id_disc_type, dt.disc_type, dpp.age_min, dpp.age_max, dpp.target_sal_thru
        FROM tb_m_design_price_policy dpp
        INNER JOIN tb_lookup_disc_type dt ON dt.id_disc_type = dpp.id_disc_type
        WHERE dpp.id_code_detail='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        PanelControl3.Enabled = True
        GCData.Enabled = True
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs)

    End Sub

    Dim cond_check As Boolean = True
    Sub tabCheck()

    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        saveChanges()
    End Sub

    Function checkUsed() As Boolean
        If action = "upd" Then
            Dim qd As String = "SELECT * FROM tb_m_design_code WHERE id_code_detail='" + id + "' "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            If dd.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

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
        Dim cond_used As Boolean = checkUsed()

        If cond_code_exist Then
            stopCustom("Code already exist")
        ElseIf cond_used Then
            stopCustom("Can't update because this code already used")
        Else
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create this code. Click Yes to continue setup detail?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "INSERT INTO tb_m_code_detail(id_code, code, display_name, code_detail_name) VALUES('" + id_code_price_policy + "','" + code_check + "', '" + code_check + "', '" + addSlashes(TxtDesc.Text) + "'); 
                    SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'refresh
                    refreshMain()
                    action = "upd"
                    actionLoad()
                    infoCustom("Please setup detail aging")
                End If
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to update this rule?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "UPDATE tb_m_code_detail SET code='" + code_check + "',display_name='" + code_check + "',code_detail_name='" + addSlashes(TxtDesc.Text) + "'   
                    WHERE id_code_detail='" + id + "';"
                    execute_non_query(query, True, "", "", "", "")
                    'refresh
                    refreshMain()
                    action = "upd"
                    actionLoad()
                    infoCustom("Save changes successfully")
                    Close()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshMain()
        FormPricePolicyCode.viewData()
        FormPricePolicyCode.GVData.FocusedRowHandle = find_row(FormPricePolicyCode.GVData, "id_code_detail", id)
    End Sub

    Private Sub TxtNormalUntil_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt30Until_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt50Until_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt70Until_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtFixUntil_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        saveChanges()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If Not checkUsed() Then
            Try
                Dim id_design_price_policy As String = GVData.GetFocusedRowCellValue("id_design_price_policy").ToString
                Dim query_del As String = "DELETE FROM tb_m_design_price_policy WHERE id_design_price_policy='" + id_design_price_policy + "' "
                execute_non_query(query_del, True, "", "", "", "")
                actionLoad()
                refreshMain()
            Catch ex As Exception
                errorDelete()
            End Try
        Else
            stopCustom("Can't delete, this type already used")
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPricePolicyCodeSingle.id_code_detail = id
        FormPricePolicyCodeSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class