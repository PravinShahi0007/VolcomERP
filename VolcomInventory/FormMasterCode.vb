Public Class FormMasterCode
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public id_template As String = "-1"
    Public id_code As String = "-1"

    Private Sub FormMasterCode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        check_menu()
    End Sub

    Private Sub FormMasterCode_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_code()
    End Sub

    Sub view_code()
        Dim q_where As String = ""

        If Not id_template = "-1" Then
            q_where = "WHERE id_code IN (SELECT id_code FROM tb_template_code_det WHERE id_template_code = " + id_template + ")"
        End If

        Dim data As DataTable = execute_query("SELECT id_code,code_name,description,is_include_name,is_include_code FROM tb_m_code " + q_where + " ORDER BY code_name", -1, True, "", "", "", "")
        GCCode.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            XTPCodeDet.PageEnabled = True
            view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
            view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
            LabelCodeContent.Text = GVCode.GetFocusedRowCellDisplayText("code_name").ToString
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            XTPCodeDet.PageEnabled = False
        End If

        If Not id_template = "-1" Then
            button_main("0", "0", "0")
        End If
    End Sub
    Sub view_code_detail(ByVal id_code As String)
        Dim q_select As String = ""

        Dim t_color As DataTable = execute_query("SELECT id_design_column_type, column_type FROM tb_design_column_type WHERE is_mapping_color = 1", -1, True, "", "", "", "")

        For i = 0 To t_color.Rows.Count - 1
            GVCodeDetail.Columns.Remove(GVCodeDetail.Columns(t_color.Rows(i)("column_type").ToString))
        Next

        If id_code = "14" Then
            For i = 0 To t_color.Rows.Count - 1
                Dim c As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn
                c.FieldName = t_color.Rows(i)("column_type").ToString
                c.OptionsColumn.AllowEdit = False
                c.Caption = t_color.Rows(i)("column_type").ToString + " COLOR"

                GVCodeDetail.Columns.Add(c)

                c.VisibleIndex = i + 4
            Next

            For i = 0 To t_color.Rows.Count - 1
                q_select += "
                    , (SELECT p.color FROM tb_design_column_mapping_color AS m LEFT JOIN tb_design_column_type_color AS p ON m.id_design_column_type_color = p.id_design_column_type_color WHERE p.id_design_column_type = " + t_color.Rows(i)("id_design_column_type").ToString + " AND m.id_code_detail = d.id_code_detail) AS `" + t_color.Rows(i)("column_type").ToString + "`
                "
            Next
        End If

        Dim data As DataTable = execute_query("
            SELECT 'no' AS is_check, d.id_code_detail, d.code, d.display_name, d.code_detail_name " + q_select + "
            FROM tb_m_code_detail AS d
            WHERE d.id_code = '" & id_code & "'
            ORDER BY d.code
        ", -1, True, "", "", "", "")

        GCCodeDetail.DataSource = data

        check_menu()

        If Not id_code = "14" Then
            SBParentColor.Visible = False
            ColumnCheck.VisibleIndex = -1
        Else
            SBParentColor.Visible = True
            ColumnCheck.VisibleIndex = 0
        End If
    End Sub

    Private Sub GVCode_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVCode.RowClick
        view_code_detail(GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
        LabelCodeContent.Text = GVCode.GetFocusedRowCellDisplayText("code_name").ToString
    End Sub

    Private Sub XTCCode_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCode.SelectedPageChanged
        check_menu()
    End Sub
    Sub check_menu()
        If XTCCode.SelectedTabPageIndex = 0 Then
            'code
            If GVCode.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If

            If Not id_template = "-1" Then
                button_main("0", "0", "0")
            End If
        Else
            'detail
            If GVCodeDetail.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub SBParentColor_Click(sender As Object, e As EventArgs) Handles SBParentColor.Click
        makeSafeGV(GVCodeDetail)
        GVCodeDetail.ActiveFilterString = "[is_check] = 'yes'"

        If GVCodeDetail.RowCount > 0 Then
            FormMasterCodeDetSingle.id_code = GVCode.GetFocusedRowCellDisplayText("id_code").ToString
            FormMasterCodeDetSingle.is_set_parent_color = "1"
            FormMasterCodeDetSingle.ShowDialog()
        Else
            stopCustom("No color selected.")
        End If

        GVCodeDetail.ActiveFilterString = ""
    End Sub
End Class