Public Class FormMasterCodeDetSingle
    Public id_code As String = "-1"
    Public id_code_det As String = "-1"
    Public id_pop_up As String = "-1"

    Public is_set_parent_color As String = "-1"

    Private lookup As List(Of DevExpress.XtraEditors.SearchLookUpEdit) = New List(Of DevExpress.XtraEditors.SearchLookUpEdit)

    Private Sub TECodeDet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECodeDet.Validating
        EP_TE_cant_blank(ErrorProviderCodeDet, TECodeDet)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_code_detail) FROM tb_m_code_detail WHERE code_detail_name='{0}' AND id_code='{1}' AND id_code_detail !='{2}'", TECodeDet.Text, id_code, id_code_det)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(ErrorProviderCodeDet, TECodeDet, "1")
        End If
    End Sub

    Private Sub TEPrintedCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPrintedCode.Validating
        EP_TE_cant_blank(ErrorProviderCodeDet, TEPrintedCode)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_code_detail) FROM tb_m_code_detail WHERE display_name='{0}' AND id_code='{1}' AND id_code_detail !='{2}'", TEPrintedCode.Text, id_code, id_code_det)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(ErrorProviderCodeDet, TEPrintedCode, "1")
        End If
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

        If id_code = "14" Then
            view_mapping_column()
        End If

        If is_set_parent_color = "1" Then
            PanelControl2.Visible = False
            PanelControl3.Visible = False
            PanelControl4.Visible = False
        End If
    End Sub

    Private Sub FormMasterCodeDetSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormMasterCode.view_code_detail(FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        If is_set_parent_color = "-1" Then
            TECode_Validating(TECode, New System.ComponentModel.CancelEventArgs)
            TEPrintedCode_Validating(TEPrintedCode, New System.ComponentModel.CancelEventArgs)
            TECodeDet_Validating(TECodeDet, New System.ComponentModel.CancelEventArgs)

            Dim query As String
            Dim code As String = TECode.Text
            Dim display_name As String = TEPrintedCode.Text
            Dim code_name As String = TECodeDet.Text
            Dim data_insert_parameter_temp As DataTable

            Try
                If id_code_det <> "-1" Then
                    'update
                    If Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl2) Or Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl3) Or Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl4) Then
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
                    If Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl2) Or Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl3) Or Not formIsValidInPanel(ErrorProviderCodeDet, PanelControl4) Then
                        errorInput()
                    Else
                        query = String.Format("INSERT INTO tb_m_code_detail(code_detail_name,display_name,code,id_code) VALUES('{0}','{1}','{2}','{3}'); SELECT LAST_INSERT_ID();", addSlashes(code_name), addSlashes(display_name), addSlashes(code), id_code)
                        id_code_det = execute_query(query, 0, True, "", "", "", "")
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

                'color mapping
                If Not id_code_det = "-1" Then
                    If id_code = "14" Then
                        execute_non_query("DELETE FROM tb_design_column_mapping_color WHERE id_code_detail = " + id_code_det, True, "", "", "", "")

                        For i = 0 To lookup.Count - 1
                            If Not lookup(i).EditValue.ToString = "0" Then
                                execute_non_query("INSERT INTO tb_design_column_mapping_color (id_design_column_type_color, id_code_detail) VALUES (" + lookup(i).EditValue.ToString + ", " + id_code_det + ")", True, "", "", "", "")
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            For j = 0 To FormMasterCode.GVCodeDetail.RowCount - 1
                execute_non_query("DELETE FROM tb_design_column_mapping_color WHERE id_code_detail = " + FormMasterCode.GVCodeDetail.GetRowCellValue(j, "id_code_detail").ToString, True, "", "", "", "")

                For i = 0 To lookup.Count - 1
                    If Not lookup(i).EditValue.ToString = "0" Then
                        execute_non_query("INSERT INTO tb_design_column_mapping_color (id_design_column_type_color, id_code_detail) VALUES (" + lookup(i).EditValue.ToString + ", " + FormMasterCode.GVCodeDetail.GetRowCellValue(j, "id_code_detail").ToString + ")", True, "", "", "", "")
                    End If
                Next
            Next

            Close()
        End If

        Cursor = Cursors.Default
    End Sub

    Sub view_mapping_column()
        Dim query As String = "
            SELECT id_design_column_type, column_type
            FROM tb_design_column_type
            WHERE is_mapping_color = 1
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            'panel control
            Dim pc As DevExpress.XtraEditors.PanelControl = New DevExpress.XtraEditors.PanelControl

            pc.Dock = DockStyle.Top
            pc.Size = New Size(417, 30)
            pc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

            'label
            Dim lc As DevExpress.XtraEditors.LabelControl = New DevExpress.XtraEditors.LabelControl

            lc.Text = "Color " + data.Rows(i)("column_type").ToString.ToLower
            lc.Location = New Point(13, 7)
            lc.Font = New Font("Calibri", 9.75, FontStyle.Regular)

            pc.Controls.Add(lc)

            'slue
            Dim slue As DevExpress.XtraEditors.SearchLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit

            slue.Location = New Point(165, 4)
            slue.Size = New Size(230, 22)

            viewSearchLookupQuery(slue, "
                SELECT `id_design_column_type_color`, `color`
                FROM `tb_design_column_type_color`
                WHERE `id_design_column_type` = " + data.Rows(i)("id_design_column_type").ToString + "
            ", "id_design_column_type_color", "color", "id_design_column_type_color")

            Dim id_design_column_type_color As String = execute_query("
                SELECT m.id_design_column_type_color
                FROM tb_design_column_mapping_color AS m
                LEFT JOIN tb_design_column_type_color AS c ON m.id_design_column_type_color = c.id_design_column_type_color
                WHERE c.id_design_column_type = " + data.Rows(i)("id_design_column_type").ToString + " AND m.id_code_detail = " + id_code_det + "
                UNION ALL
                SELECT 0 AS id_mapping_color
            ", 0, True, "", "", "", "")

            slue.EditValue = id_design_column_type_color

            lookup.Add(slue)

            pc.Controls.Add(slue)

            PCValue.Controls.Add(pc)

            pc.BringToFront()

            PCValue.Size = New Size(421, PCValue.Size.Height + 30)
            Size = New Size(569, Size.Height + 30)
        Next

        PCAction.BringToFront()
    End Sub
End Class