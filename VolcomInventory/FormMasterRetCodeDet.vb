Public Class FormMasterRetCodeDet 
    Public action As String = "-1"
    Public id_ret_code As String = "-1"
    Public quick_edit As String = "-1"

    Private Sub FormMasterRetCodeDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As ClassDesign = New ClassDesign()
            Dim query As String = query_c.getRetCodeQuery("AND a.id_ret_code = '" + id_ret_code + "' ")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtRetCode.Text = data.Rows(0)("ret_code").ToString
            DERetDate.EditValue = data.Rows(0)("ret_date")
            TxtDesc.Text = data.Rows(0)("ret_description").ToString
        End If
    End Sub

    Private Sub FormMasterRetCodeDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim dt As String = "0000-00-00"
        Try
            dt = DERetDate.EditValue
        Catch ex As Exception
        End Try
        If TxtRetCode.Text = "" Or dt = "0000-00-00" Then
            stopCustom("Data can't blank!")
        Else
            Dim query_cek As String = "SELECT COUNT(*) FROM tb_lookup_ret_code a WHERE a.ret_code='" + TxtRetCode.Text + "' "
            If action = "upd" Then
                query_cek += "AND a.id_ret_code<>'" + id_ret_code + "' "
            End If
            Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
            If jum_cek > "0" Then
                stopCustom("Return code already exist.")
            Else
                Dim ret_code As String = TxtRetCode.Text.ToString
                Dim ret_date As String = Nothing
                Try
                    ret_date = DateTime.Parse(DERetDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Catch ex As Exception
                End Try
                Dim ret_description As String = TxtDesc.Text

                'MsgBox(ret_date.ToString)
                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_lookup_ret_code(ret_code, ret_date, ret_description) VALUES ("
                    query += "'" + ret_code + "', "
                    If ret_date = Nothing Then
                        query += "NULL "
                    Else
                        query += "'" + ret_date + "', "
                    End If
                    query += "'" + ret_description + "'); SELECT LAST_INSERT_ID(); "
                    id_ret_code = execute_query(query, 0, True, "", "", "", "")
                    If quick_edit = "-1" Then
                        FormMasterRetCode.viewRetCode()
                        FormMasterRetCode.GVRetCode.FocusedRowHandle = find_row(FormMasterRetCode.GVRetCode, "id_ret_code", id_ret_code)
                    ElseIf quick_edit = "1" Then
                        FormMasterRetCode.viewRetCode()
                        FormMasterRetCode.GVRetCode.FocusedRowHandle = find_row(FormMasterRetCode.GVRetCode, "id_ret_code", id_ret_code)
                        FormMasterDesignSingle.view_ret_code(FormMasterDesignSingle.LERetCode)
                    End If
                    Close()
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_lookup_ret_code SET ret_code='" + ret_code + "', ret_description='" + ret_description + "', "
                    If ret_date = Nothing Then
                        query += "ret_date=NULL "
                    Else
                        query += "ret_date='" + ret_date + "' "
                    End If
                    query += "WHERE id_ret_code='" + id_ret_code + "' "
                    execute_non_query(query, True, "", "", "", "")
                    If quick_edit = "-1" Then
                        FormMasterRetCode.viewRetCode()
                        FormMasterRetCode.GVRetCode.FocusedRowHandle = find_row(FormMasterRetCode.GVRetCode, "id_ret_code", id_ret_code)
                    ElseIf quick_edit = "1" Then
                        FormMasterRetCode.viewRetCode()
                        FormMasterRetCode.GVRetCode.FocusedRowHandle = find_row(FormMasterRetCode.GVRetCode, "id_ret_code", id_ret_code)
                        FormMasterDesignSingle.view_ret_code(FormMasterDesignSingle.LERetCode)
                    End If
                    Close()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class