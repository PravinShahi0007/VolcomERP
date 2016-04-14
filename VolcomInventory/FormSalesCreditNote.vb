Public Class FormSalesCreditNote 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim current_year As String

    'selected - Tab1
    Public id_store_selected As String = "-1"
    Public label_store_selected As String = "-1"
    Public date_from_selected As String = "0000-01-01"
    Public date_until_selected As String = "9999-12-01"
    Public label_type_selected As String = "2"
    Public dt As DataTable

    Private Sub FormSalesCreditNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tab Daily
        viewSalesPOS()

        'sementara gak terpakai 
        viewStore()
        DEUntil.DateTime = Now
        DEFrom.DateTime = Now
        'viewOption()
    End Sub

    Private Sub FormSalesCreditNote_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesCreditNote_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewSalesPOS()
        Try
            Dim query_c As ClassSalesInv = New ClassSalesInv()
            Dim query As String = query_c.queryMain("AND a.id_memo_type=''2'' AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            'Dim query As String = query_c.queryMain("AND a.id_memo_type=''2''  ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSalesPOS.DataSource = data
            dt = data
            check_menu()
            GVSalesPOS.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub


    Sub check_menu()
        If GVSalesPOS.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        End If
    End Sub

    Sub viewStore()
        Dim query As String = getQueryStore()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_store_selected = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEStore.Properties.DataSource = Nothing
        SLEStore.Properties.DataSource = data
        SLEStore.Properties.DisplayMember = "comp_name_label"
        SLEStore.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEStore.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor

        'hide/show expand
        'label_type_selected = LEOptionView.EditValue.ToString
        'If label_type_selected = "1" Then
        '    BExpand.Visible = True
        '    BHide.Visible = True
        'Else
        '    BExpand.Visible = False
        '    BHide.Visible = False
        'End If

        'Prepare paramater
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            id_store_selected = SLEStore.EditValue.ToString
        Catch ex As Exception
        End Try

        'modify value
        If id_store_selected = "0" Then
            label_store_selected = "All Store"
            id_store_selected = "%%"
        Else
            label_store_selected = SLEStore.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        viewSalesPOS()
        Cursor = Cursors.Default
    End Sub

    Sub viewOption()
        Dim query As String = getOptionView()
        viewLookupQuery(LEOptionView, query, 0, "option_view", "id_option_view")
    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Public Sub HideAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, False)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub BExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExpand.Click
        ExpandAllRows(GVSalesPOS)
    End Sub

    Private Sub BHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHide.Click
        HideAllRows(GVSalesPOS)
    End Sub

    Private Sub GVSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesPOSDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOSDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class