Public Class FormSalesInv
    Private Sub FormSalesInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`, LAST_DAY(DATE(NOW())) AS `last_date` ", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEUntil.Properties.MaxValue = data_dt.Rows(0)("last_date")

        loadComp()
        loadFilterOpt()
        viewPeriodType()
        viewDisplay()
    End Sub

    Private Sub FormSalesInv_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesInv_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub loadComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_comp`, 'All Store' AS `comp_name`, 0 AS `id_comp_cat`
        UNION
        SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name, c.id_comp_cat
        FROM tb_m_comp c
        WHERE (c.id_comp_cat='5' OR c.id_comp_cat='6') "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub loadFilterOpt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_filter_opt`, 'No Filter' AS `filter_opt`
        UNION
        SELECT 1 AS `id_filter_opt`, 'Class' AS `filter_opt`
        UNION
        SELECT 2 AS `id_filter_opt`, 'Category' AS `filter_opt`
        UNION
        SELECT 3 AS `id_filter_opt`, 'Sub Category' AS `filter_opt`
        UNION
        SELECT 4 AS `id_filter_opt`, 'Status Product' AS `filter_opt` "
        viewLookupQuery(LEFilterOpt, query, 0, "filter_opt", "id_filter_opt")
        Cursor = Cursors.Default
    End Sub

    Sub loadSubFilter()
        Cursor = Cursors.WaitCursor
        Dim id_filter_opt As String = "1"
        Try
            id_filter_opt = myCoalesce(LEFilterOpt.EditValue.ToString, "1")
        Catch ex As Exception
        End Try

        Dim query As String = ""
        Select Case id_filter_opt
            Case 1
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o) "
            Case 2
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.display_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_cat FROM tb_opt o)
                GROUP BY cd.display_name "
            Case 3
                query = "SELECT cd.id_code_detail AS `id_sub_filter`, cd.code_detail_name AS `sub_filter`, cd.display_name AS `sub_filter_display` 
                FROM tb_m_code_detail cd 
                WHERE cd.id_code IN (SELECT o.id_code_fg_subcat FROM tb_opt o) "
            Case 4
                query = "SELECT cd.id_design_cat AS `id_sub_filter`, cd.design_cat AS `sub_filter`, cd.design_cat AS `sub_filter_display` 
                FROM tb_lookup_design_cat cd "
            Case Else
                query = "SELECT 1 AS `id_sub_filter`, '-' AS `sub_filter`,  '-' AS `sub_filter_display` "
        End Select
        viewSearchLookupQuery(SLESubFilter, query, "id_sub_filter", "sub_filter_display", "id_sub_filter")
        Cursor = Cursors.Default
    End Sub

    Sub viewPeriodType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_period_type`,'Sales Date' AS `period_type`
        UNION
        SELECT '2' AS `id_period_type`,'Entry Date' AS `period_type` "
        viewSearchLookupQuery(SLEPeriodType, query, "id_period_type", "period_type", "id_period_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click

    End Sub

    Private Sub LEFilterOpt_EditValueChanged(sender As Object, e As EventArgs) Handles LEFilterOpt.EditValueChanged
        loadSubFilter()
    End Sub

    Sub viewDisplay()
        Cursor = Cursors.Default
        Dim query As String = "SELECT 1 AS `id_display`, 'All' AS `display`
        UNION
        SELECT 2 AS `id_display`, 'Sales Only' AS `display` "
        viewLookupQuery(LEDisplay, query, 0, "display", "id_display")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewByProduct()
    End Sub

    Sub viewByProduct()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        'Prepare paramater date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'other
        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim id_period_type As String = SLEPeriodType.EditValue.ToString
        Dim is_with_sizetype_param As String = ""
        If CESizetyp.EditValue = True Then
            is_with_sizetype_param = "1"
        Else
            is_with_sizetype_param = "2"
        End If

        'display
        Dim opt_display_param As String = LEDisplay.EditValue.ToString
        If opt_display_param = "1" Then
            gridBandSOH.Visible = True
        Else
            gridBandSOH.Visible = False
        End If

        'where string
        Dim where_param As String = ""
        Dim id_filter_opt As String = LEFilterOpt.EditValue.ToString
        Dim id_sub_filter As String = SLESubFilter.EditValue.ToString
        Select Case id_filter_opt
            Case 1
                where_param = "AND cls.id_class=" + id_sub_filter + " "
            Case 2
                where_param = "AND kat.kat=''" + SLESubFilter.Text.ToString + "'' "
            Case 3
                where_param = "AND subkat.id_subkat=" + id_sub_filter + " "
            Case 4
                where_param = "AND prc.id_design_cat=" + id_sub_filter + " "
            Case Else
                where_param = ""
        End Select

        'excecute
        Dim query As String = "CALL view_sales_inv('" + date_from_selected + "', '" + date_until_selected + "', '" + id_comp + "', '" + id_period_type + "', '" + is_with_sizetype_param + "', '" + opt_display_param + "', '" + where_param + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByProduct.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHideFilter_Click(sender As Object, e As EventArgs) Handles BtnHideFilter.Click
        PanelControlViewByProduct.Visible = False
        BtnShowFilter.Visible = True
    End Sub

    Private Sub BtnShowFilter_Click(sender As Object, e As EventArgs) Handles BtnShowFilter.Click
        PanelControlViewByProduct.Visible = True
        BtnShowFilter.Visible = False
    End Sub
End Class