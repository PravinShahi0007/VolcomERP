Public Class FormSampleStock 
    'Tab1
    Public date_default As String = ""
    Public wh_stock_selected As String = ""
    Public locator_stock_selected As String = ""
    Public rack_stock_selected As String = ""
    Public drawer_stock_selected As String = ""
    Public date_until_stock_selected As String = "9999-12-01"
    Public dt_stock As DataTable
    Public dtd_temp As DataTable

    Private Sub FormSampleStock_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSampleStock_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
        If XTCWHMain.SelectedTabPageIndex = 0 Then
            FormMain.BBSwitch.Enabled = True
            FormMain.BBPrint.Enabled = True
        Else
            FormMain.BBSwitch.Enabled = False
            FormMain.BBPrint.Enabled = False
        End If
    End Sub

    Private Sub FormSampleStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'default date
        date_default = getNowDB(2)

        viewWHStock()
        viewWHStockDistSample()
    End Sub

    Function viewWHQuery(ByVal id_opt As String) As String
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        If id_opt = "1" Then 'Sample
            query += "SELECT e.id_comp, e.comp_number, e.comp_name FROM tb_storage_sample a "
        ElseIf id_opt = "2" Then 'Material
            query += "SELECT e.id_comp, e.comp_number, e.comp_name FROM tb_storage_mat a "
        ElseIf id_opt = "3" Then 'FG
            query += "SELECT e.id_comp, e.comp_number, e.comp_name FROM tb_storage_fg a "
        End If
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "GROUP BY e.id_comp "
        Return query
    End Function

    Function viewWHLocatorQuery(ByVal id_comp) As String
        Dim query As String = ""
        'If id_comp = "0" Then
        query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        'End If
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        Return query
    End Function

    Function viewWHRackQuery(ByVal id_locator As String) As String
        'Dim query As String = ""
        Dim query As String = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        Return query
    End Function

    Function viewWHDrawerQuery(ByVal id_rack As String) As String
        Dim query As String = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        Return query
    End Function

    '-----------------------
    ' TAB STOCK DATA
    '-----------------------
    Sub viewSampleList(ByVal SLEWHx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLELocatorx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLERackx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLEDrawerx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal GC As DevExpress.XtraGrid.GridControl, ByVal id_type_param As String)
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = SLEDrawerx.EditValue.ToString
        Dim id_wh_rack_view As String = SLERackx.EditValue.ToString
        Dim id_wh_locator_view As String = SLELocatorx.EditValue.ToString
        Dim id_wh_view As String = SLEWHx.EditValue.ToString

        'prepare var
        If id_wh_view = "0" Then
            wh_stock_selected = "All WH"
        Else
            wh_stock_selected = SLEWHx.Properties.View.GetFocusedRowCellValue("comp_name").ToString
        End If

        If id_wh_locator_view = "0" Then
            locator_stock_selected = "All Locator"
        Else
            locator_stock_selected = SLELocatorx.Properties.View.GetFocusedRowCellValue("wh_locator").ToString
        End If

        If id_wh_rack_view = "0" Then
            rack_stock_selected = "All Rack"
        Else
            rack_stock_selected = SLERackx.Properties.View.GetFocusedRowCellValue("wh_rack").ToString
        End If

        If id_wh_drawer_view = "0" Then
            drawer_stock_selected = "All Drawer"
        Else
            drawer_stock_selected = SLEDrawerx.Properties.View.GetFocusedRowCellValue("wh_drawer").ToString
        End If

        date_until_stock_selected = "9999-12-01"
        Try
            date_until_stock_selected = DateTime.Parse(DEUntilStockWH.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'Try
        Dim query As String = ""
        If id_type_param = "1" Then
            query = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + date_until_stock_selected + "','1')"
        ElseIf id_type_param = "2" Then
            query = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + date_until_stock_selected + "','3')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GC.DataSource = data
        dt_stock = data
        ' Catch ex As Exception
        'errorConnection()
        ' End Try
        Cursor = Cursors.Default
    End Sub

    Sub viewWHStock()
        Dim query As String = viewWHQuery("1")
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            GCSample.DataSource = Nothing
            GCSampleDetail.DataSource = Nothing
            viewWHLocatorSLE()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Try
            GCSample.DataSource = Nothing
            GCSampleDetail.DataSource = Nothing
            viewWHRack()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
            GCSample.DataSource = Nothing
            GCSampleDetail.DataSource = Nothing
            viewWHDrawer()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEDrawer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawer.EditValueChanged
        Try
            GCSample.DataSource = Nothing
            GCSampleDetail.DataSource = Nothing
            If SLEDrawer.EditValue Is Nothing Then
                BtnViewStock.Enabled = False
            Else
                BtnViewStock.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = viewWHLocatorQuery(id_comp)
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = viewWHRackQuery(id_locator)
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = viewWHDrawerQuery(id_rack)
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Cursor = Cursors.WaitCursor
       viewSampleStorage()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImgSampleDist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgSampleDist.Click
        Dim id_samplex As String = ""
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub


    Private Sub BtnImgSampleStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgSampleStock.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Sub viewSampleStorage()
        viewSampleList(SLEWH, SLELocator, SLERack, SLEDrawer, GCSample, "1")
        viewSampleStorageDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Sub viewSampleStorageDetail()
        ' Try
        GVSample.ActiveFilter.Clear()
        GVSampleDetail.ActiveFilter.Clear()
        Dim id_samplex As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim id_wh_drawer_view As String = SLEDrawer.EditValue.ToString
        Dim id_wh_rack_view As String = SLERack.EditValue.ToString
        Dim id_wh_locator_view As String = SLELocator.EditValue.ToString
        Dim id_wh_view As String = SLEWH.EditValue.ToString

        If id_wh_drawer_view = "0" Then
            id_wh_drawer_view = "%%"
        Else
            id_wh_drawer_view = "%" + id_wh_drawer_view + "%"
        End If

        If id_wh_rack_view = "0" Then
            id_wh_rack_view = "%%"
        Else
            id_wh_rack_view = "%" + id_wh_rack_view + "%"
        End If

        If id_wh_locator_view = "0" Then
            id_wh_locator_view = "%%"
        Else
            id_wh_locator_view = "%" + id_wh_locator_view + "%"
        End If

        If id_wh_view = "0" Then
            id_wh_view = "%%"
        Else
            id_wh_view = "%" + id_wh_view + "%"
        End If

        Try
            dtd_temp.Clear()
        Catch ex As Exception
        End Try
        GCSampleDetail.DataSource = Nothing

        Dim query As String = "SELECT * FROM tb_storage_sample a "
        query += "INNER JOIN tb_m_sample c ON a.id_sample = c.id_sample "
        query += "INNER JOIN tb_lookup_storage_category e ON e.id_storage_category = a.id_storage_category "
        query += "INNER JOIN tb_m_wh_drawer f ON f.id_wh_drawer = a.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack g ON g.id_wh_rack = f.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator h ON h.id_wh_locator = g.id_wh_locator "
        query += "INNER JOIN tb_m_comp i ON i.id_comp = h.id_comp "
        query += "LEFT JOIN tb_lookup_report_mark_type rm ON rm.report_mark_type = a.report_mark_type "
        query += "WHERE a.id_wh_drawer LIKE '" + id_wh_drawer_view + "' "
        query += "AND g.id_wh_rack LIKE '" + id_wh_rack_view + "' "
        query += "AND h.id_wh_locator LIKE '" + id_wh_locator_view + "' "
        query += "AND i.id_comp LIKE '" + id_wh_view + "' "
        'query += "AND a.id_sample = '" + id_samplex + "' "
        query += "AND a.id_stock_status = '1' "
        query += "ORDER BY a.datetime_storage_sample ASC "
        dtd_temp = execute_query(query, -1, True, "", "", "", "")
        dtd_temp.DefaultView.RowFilter = "id_sample = '" + id_samplex + "' "
        Dim data As DataTable = dtd_temp.DefaultView.ToTable
        GCSampleDetail.DataSource = data

        'filter
        'GVSampleDetail.ActiveFilterString = "[id_sample] = '" + id_samplex + "'"
        'Catch ex As Exception
        '    errorConnection()
        '    Close()
        'End Try
    End Sub

    '-----------------------
    ' TAB DISTRIBUTION
    '-----------------------
    Sub viewSampleDistList()
        viewSampleList(SLEWHSampleDist, SLELocatorSampleDist, SLERackSampleDist, SLEDrawerSampleDist, GCSampleDist, "2")
        viewSampleDistDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Sub viewSampleDistDetail()
        Dim id_sample As String = "0"
        Try
            id_sample = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        Dim query As String = "CALL view_sample_dist('" + id_sample + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDistDetail.DataSource = data
    End Sub

    Private Sub BtnViewSampleDist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewSampleDist.Click
        Cursor = Cursors.WaitCursor
        'Try
        viewSampleDistList()
        'Catch ex As Exception
        'errorConnection()
        ' End Try
        Cursor = Cursors.Default
    End Sub
    Sub viewWHStockDistSample()
        Dim query As String = viewWHQuery("1")
        viewSearchLookupQuery(SLEWHSampleDist, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewWHLocatorDistSample()
        Dim id_comp As String = SLEWHSampleDist.EditValue.ToString
        Dim query As String = viewWHLocatorQuery(id_comp)
        'MsgBox(query)
        viewSearchLookupQuery(SLELocatorSampleDist, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Sub viewWHRackDistSample()
        Dim id_locator As String = SLELocatorSampleDist.EditValue.ToString
        Dim query As String = viewWHRackQuery(id_locator)
        viewSearchLookupQuery(SLERackSampleDist, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Sub viewWHDrawerSampleDist()
        Dim id_rack As String = SLERackSampleDist.EditValue.ToString
        Dim query As String = viewWHDrawerQuery(id_rack)
        viewSearchLookupQuery(SLEDrawerSampleDist, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub SLEWHSampleDist_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWHSampleDist.EditValueChanged
        Try
            viewWHLocatorDistSample()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLELocatorSampleDist_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocatorSampleDist.EditValueChanged
        Try
            viewWHRackDistSample()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLERackSampleDist_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERackSampleDist.EditValueChanged
        Try
            viewWHDrawerSampleDist()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEDrawerSampleDist_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawerSampleDist.EditValueChanged
        Try
            If SLEDrawerSampleDist.EditValue Is Nothing Then
                BtnViewSampleDist.Enabled = False
            Else
                BtnViewSampleDist.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVSampleDist_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDist.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewSampleDistDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        Cursor = Cursors.Default
    End Sub

    
    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        GVSampleDetail.ActiveFilter.Clear()
        'viewSampleStorageDetail()
        Dim id_samplex As String = "-1"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
            dtd_temp.DefaultView.RowFilter = "id_sample = '" + id_samplex + "' "
            Dim data As DataTable = dtd_temp.DefaultView.ToTable
            GCSampleDetail.DataSource = Nothing
            GCSampleDetail.DataSource = data
        Catch ex As Exception

        End Try
        'GVSampleDetail.ActiveFilterString = "[id_sample] = '" + id_samplex + "'"

        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckAvailableStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAvailableStock.CheckedChanged
        If CheckAvailableStock.EditValue.ToString = "True" Then
            GVSample.ActiveFilterString = "[qty_all_sample] > 0 "
        Else
            GVSample.ActiveFilterString = ""
        End If
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Private Sub GVSample_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.ColumnFilterChanged
        'when close filter
        If GVSample.ActiveFilter.Count = 0 Then
            CheckAvailableStock.Checked = False
        Else
            CheckAvailableStock.Checked = True
        End If
    End Sub

    Private Sub XTCWHMain_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCWHMain.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub ToolTipControllerStock_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipControllerStock.GetActiveObjectInfo
        If Not e.SelectedControl Is GCSampleDetail Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GCSampleDetail.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells

        Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
        Dim text As String = "Double click to see detail document"
        info = New DevExpress.Utils.ToolTipControlInfo(o, text)

        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub GVSampleDetail_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSampleDetail.DoubleClick
        Cursor = Cursors.WaitCursor
        Dim id_report As String = "-1"
        Dim report_mark_type As String = "-1"
        Try
            id_report = GVSampleDetail.GetFocusedRowCellValue("id_report").ToString
            report_mark_type = GVSampleDetail.GetFocusedRowCellValue("report_mark_type").ToString
        Catch ex As Exception
        End Try

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = report_mark_type
        showpopup.id_report = id_report
        showpopup.show()

        Cursor = Cursors.Default
    End Sub
End Class