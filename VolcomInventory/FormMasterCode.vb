Public Class FormMasterCode
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterCode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterCode_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_code()
    End Sub

    Sub view_code()
        Dim data As DataTable = execute_query("SELECT id_code,code_name,description,is_include_name,is_include_code FROM tb_m_code ORDER BY code_name", -1, True, "", "", "", "")
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
    End Sub
    Sub view_code_detail(ByVal id_code As String)
        Dim data As DataTable = execute_query("SELECT id_code_detail,code,display_name,code_detail_name FROM tb_m_code_detail WHERE id_code='" & id_code & "' ORDER BY code", -1, True, "", "", "", "")
        GCCodeDetail.DataSource = data
        check_menu()
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
End Class