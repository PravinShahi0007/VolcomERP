Public Class FormSalesTarget 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesTarget()
    End Sub

    Sub viewSalesTarget()
        Dim query As String = "SELECT a.id_sales_target, a.id_comp_contact_to, (d.comp_name) AS comp_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_target_note, a.id_season, e.season,a.sales_target_date, a.sales_target_note, a.sales_target_number, "
        query += "DATE_FORMAT(a.sales_target_date,'%d %M %Y') AS sales_target_date "
        query += "FROM tb_sales_target a "
        query += "INNER JOIN tb_sales_target_det b ON a.id_sales_target = b.id_sales_target "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_season e ON e.id_season = a.id_season "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "ORDER BY a.id_sales_target DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesTarget.DataSource = data
        check_menu()
    End Sub

    Private Sub FormSalesTarget_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesTarget_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSalesTarget.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub

    Sub check_menu()
        If XTCSalesTarget.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesTarget.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        ElseIf XTCSalesTarget.SelectedTabPageIndex = 1 Then
            '    'based on PO
            '    If GVReq.RowCount < 1 Then
            '        'hide all
            '        bnew_active = "0"
            '        bedit_active = "0"
            '        bdel_active = "0"
            '        checkFormAccess(Name)
            '        button_main(bnew_active, bedit_active, bdel_active)
            '        '
            '    Else
            '        'show all
            '        bnew_active = "1"
            '        bedit_active = "0"
            '        bdel_active = "0"
            '        checkFormAccess(Name)
            '        button_main(bnew_active, bedit_active, bdel_active)
            '        '
            '    End If
        End If
    End Sub

    Private Sub XTCSalesTarget_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesTarget.SelectedPageChanged
        check_menu()
    End Sub
End Class