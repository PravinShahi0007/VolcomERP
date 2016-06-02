Public Class FormMasterCodeDetSingle
    Public id_code As String = "-1"
    Public id_code_det As String = "-1"
    Public id_pop_up As String = "-1"
    Private Sub TECodeDet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECodeDet.Validating
        EP_TE_cant_blank(ErrorProviderCodeDet, TECodeDet)
    End Sub

    Private Sub TEPrintedCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPrintedCode.Validating
        EP_TE_cant_blank(ErrorProviderCodeDet, TEPrintedCode)
    End Sub

    Private Sub TECode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECode.Validating
        EP_TE_cant_blank(ErrorProviderCodeDet, TECode)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_code_detail) FROM tb_m_code_detail WHERE code='{0}' AND id_code='{1}' AND id_code_detail !='{2}'", TECode.Text, id_code, id_code_det)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(ErrorProviderCodeDet, TECode, "1")
        End If
    End Sub

    Private Sub FormMasterCodeDetSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_code_det <> "-1" Then
            'update
            Dim query As String = String.Format("SELECT * FROM tb_m_code_detail WHERE id_code_detail='{0}'", id_code_det)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim code_name As String = data.Rows(0)("code_detail_name").ToString
            Dim display_name As String = data.Rows(0)("display_name").ToString
            Dim code As String = data.Rows(0)("code").ToString
            data.Dispose()

            TECode.Text = code
            TEPrintedCode.Text = display_name
            TECodeDet.Text = code_name
        End If
    End Sub

    Private Sub FormMasterCodeDetSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim code As String = TECode.Text
        Dim display_name As String = TEPrintedCode.Text
        Dim code_name As String = TECodeDet.Text
        Dim data_insert_parameter_temp As DataTable

        Try
            If id_code_det <> "-1" Then
                'update
                If Not formIsValid(ErrorProviderCodeDet) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_code_detail SET code_detail_name='{0}',display_name='{1}',code='{2}' WHERE id_code_detail='{3}'", addSlashes(code_name), addSlashes(display_name), addSlashes(code), id_code_det)
                    execute_non_query(query, True, "", "", "", "")
                    If id_pop_up = "1" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterSampleDet.data_insert_parameter.Copy()

                        FormMasterSampleDet.load_isi_param()
                        FormMasterSampleDet.load_template(FormMasterSampleDet.LETemplate.EditValue)

                        FormMasterSampleDet.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterSampleDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "2" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter.Copy()

                        FormMasterDesignSingle.load_isi_param("1")
                        FormMasterDesignSingle.load_template(FormMasterDesignSingle.LETemplate.EditValue)

                        FormMasterDesignSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterDesignSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "3" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterProductDet.data_insert_parameter.Copy()

                        FormMasterProductDet.load_isi_param()
                        FormMasterProductDet.load_template(FormMasterProductDet.LETemplate.EditValue)

                        FormMasterProductDet.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterProductDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "4" Then 'raw mat det
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterRawMaterialDetSingle.data_insert_parameter.Copy()

                        FormMasterRawMaterialDetSingle.loadIsiParam()
                        FormMasterRawMaterialDetSingle.load_template(FormMasterRawMaterialDetSingle.LETemplate.EditValue)

                        FormMasterRawMaterialDetSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterRawMaterialDetSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "5" Then 'raw mat
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterRawMaterialSingle.data_insert_parameter.Copy()

                        FormMasterRawMaterialSingle.loadIsiParam()
                        FormMasterRawMaterialSingle.load_template(FormMasterRawMaterialSingle.LETemplate.EditValue)

                        FormMasterRawMaterialSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterRawMaterialSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "6" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter_dsg.Copy()

                        FormMasterDesignSingle.load_isi_param("2")
                        FormMasterDesignSingle.load_template_dsg(FormMasterDesignSingle.LETemplateDsg.EditValue)

                        FormMasterDesignSingle.data_insert_parameter_dsg.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterDesignSingle.data_insert_parameter_dsg.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    Else
                        FormMasterCode.view_code_detail(id_code)
                    End If

                    Close()
                End If
            Else
                'insert
                If Not formIsValid(ErrorProviderCodeDet) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_code_detail(code_detail_name,display_name,code,id_code) VALUES('{0}','{1}','{2}','{3}')", addSlashes(code_name), addSlashes(display_name), addSlashes(code), id_code)
                    execute_non_query(query, True, "", "", "", "")
                    If id_pop_up = "1" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterSampleDet.data_insert_parameter.Copy()

                        FormMasterSampleDet.load_isi_param()
                        FormMasterSampleDet.load_template(FormMasterSampleDet.LETemplate.EditValue)

                        FormMasterSampleDet.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterSampleDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "2" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter.Copy()

                        FormMasterDesignSingle.load_isi_param("1")
                        FormMasterDesignSingle.load_template(FormMasterDesignSingle.LETemplate.EditValue)

                        FormMasterDesignSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterDesignSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "3" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterProductDet.data_insert_parameter.Copy()

                        FormMasterProductDet.load_isi_param()
                        FormMasterProductDet.load_template(FormMasterProductDet.LETemplate.EditValue)

                        FormMasterProductDet.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterProductDet.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "4" Then 'raw mat det
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterRawMaterialDetSingle.data_insert_parameter.Copy()

                        FormMasterRawMaterialDetSingle.loadIsiParam()
                        FormMasterRawMaterialDetSingle.load_template(FormMasterRawMaterialDetSingle.LETemplate.EditValue)

                        FormMasterRawMaterialDetSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterRawMaterialDetSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "5" Then 'raw mat
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterRawMaterialSingle.data_insert_parameter.Copy()

                        FormMasterRawMaterialSingle.loadIsiParam()
                        FormMasterRawMaterialSingle.load_template(FormMasterRawMaterialSingle.LETemplate.EditValue)

                        FormMasterRawMaterialSingle.data_insert_parameter.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterRawMaterialSingle.data_insert_parameter.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    ElseIf id_pop_up = "6" Then
                        FormCodeTemplateEdit.view_code_detail(id_code)
                        data_insert_parameter_temp = FormMasterDesignSingle.data_insert_parameter_dsg.Copy()

                        FormMasterDesignSingle.load_isi_param("2")
                        FormMasterDesignSingle.load_template_dsg(FormMasterDesignSingle.LETemplateDsg.EditValue)

                        FormMasterDesignSingle.data_insert_parameter_dsg.Clear()
                        If Not data_insert_parameter_temp.Rows.Count = 0 Then
                            For i As Integer = 0 To data_insert_parameter_temp.Rows.Count - 1
                                FormMasterDesignSingle.data_insert_parameter_dsg.Rows.Add(data_insert_parameter_temp.Rows(i)("code").ToString, data_insert_parameter_temp.Rows(i)("value").ToString)
                            Next
                        End If
                    Else
                        FormMasterCode.view_code_detail(id_code)
                    End If
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub
End Class