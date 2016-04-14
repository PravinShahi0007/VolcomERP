Public Class FormSampleAdjustment
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    'Form
    Private Sub FormSampleReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewAdjInSample()
        viewAdjOutSample()
    End Sub
    Private Sub FormSampleReturn_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormSampleReturn_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'View Data
    Sub viewAdjInSample()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_in_sample_date, '%d %M %Y') AS adj_in_sample_datex "
        query += "FROM tb_adj_in_sample a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_in_sample DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjSampleIn.DataSource = data
        check_menu()
    End Sub
    Sub viewAdjOutSample()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_out_sample_date, '%d %M %Y') AS adj_out_sample_datex "
        query += "FROM tb_adj_out_sample a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_out_sample DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjOutSample.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCAdj.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVAdjSampleIn.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCAdj.SelectedTabPageIndex = 1 Then
            ''based on PO
            If GVAdjOutSample.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        End If
    End Sub

    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAdj.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVAdjSampleIn_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVAdjSampleIn.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVAdjSampleIn.RowCount > 0 And GVAdjSampleIn.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAdjOutSample_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVAdjOutSample.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVAdjOutSample.RowCount > 0 And GVAdjOutSample.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub
End Class