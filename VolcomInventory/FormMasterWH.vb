Public Class FormMasterWH 
    Dim bnew_active As String
    Dim bedit_active As String
    Dim bdel_active As String
    Dim bnew_active2 As String
    Dim bedit_active2 As String
    Dim bdel_active2 As String
    Dim bnew_active3 As String
    Dim bedit_active3 As String
    Dim bdel_active3 As String
    Dim bnew_active4 As String
    Dim bedit_active4 As String
    Dim bdel_active4 As String
    Dim bnew_active21 As String
    Dim bedit_active21 As String
    Dim bdel_active21 As String
    Dim id_wh_locator As String
    Dim id_wh_rack As String
    Dim id_wh_drawer As String
    Dim id_comp As String
    Public is_single As Boolean = False

    'Load Form
    Private Sub FormMasterWH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWH()
        'viewWHStock()
        'viewWHStockMat()
        'viewWHStockDistSample()
        'viewWHStockFG()
        'viewWHStockDistFG()
    End Sub
    'Activated Form 
    Private Sub FormMasterWH_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not is_single Then
            FormMain.show_rb(Name)
            pageChangedMain()
        End If
    End Sub
    'Deadactive Form
    Private Sub FormMasterWH_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If Not is_single Then
            FormMain.hide_rb()
        End If
    End Sub
    'Tab Control
    Sub pageChanged()
        If XTCWH.SelectedTabPageIndex = 0 Then 'WH
            If Not is_single Then
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCWH.SelectedTabPageIndex = 1 Then 'Locator
            If Not is_single Then
                checkFormAccess(Name)
                button_main(bnew_active2, bedit_active2, bdel_active2)
            End If
        ElseIf XTCWH.SelectedTabPageIndex = 2 Then 'Rack
            If Not is_single Then
                checkFormAccess(Name)
                button_main(bnew_active3, bedit_active3, bdel_active3)
            End If
        ElseIf XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
            If Not is_single Then
                checkFormAccess(Name)
                button_main(bnew_active4, bedit_active4, bdel_active4)
            End If
        End If
    End Sub
    Sub pageChangedGoods()
        If XTCStock.SelectedTabPageIndex = 0 Then 'Sample
            If Not is_single Then
                checkFormAccess(Name)
                button_main(bnew_active21, bedit_active21, bdel_active21)
            End If
        End If
    End Sub
    Sub pageChangedMain()
        If Not is_single Then
            If XTCWHMain.SelectedTabPageIndex = 0 Then
                'FormMain.BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                FormMain.BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                FormMain.BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                FormMain.BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                pageChanged()
            Else
                '  FormMain.BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                FormMain.BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                FormMain.BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                FormMain.BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                pageChangedGoods()
            End If
        End If
    End Sub
    'Selected Page Changed
    Private Sub XTCWH_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCWH.SelectedPageChanged
        pageChanged()
    End Sub
    Private Sub XTCGoods_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs)
        pageChangedGoods()
    End Sub
    Private Sub XTCWHMain_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCWHMain.SelectedPageChanged
        pageChangedMain()
    End Sub
    'View Data
    Sub viewWH()
        Try
            Dim query As String
            Dim data As DataTable

            'get id category on opt
            query = "SELECT id_comp_cat_wh FROM tb_opt "
            Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

            'view data comp/warehouse
            query = "SELECT * FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' ORDER BY a.comp_number ASC "
            data = execute_query(query, -1, True, "", "", "", "")
            GCWH.DataSource = data
            If data.Rows.Count > 0 Then
                'show all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                'If Not is_single Then
                '    checkFormAccess(Name)
                'End If
                viewWHLocator()
                XTPLocator.PageEnabled = True
            Else
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                'If Not is_single Then
                '    checkFormAccess(Name)
                'End If
                XTPLocator.PageEnabled = False
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub viewWHLocator()
        Try
            id_comp = GVWH.GetFocusedRowCellDisplayText("id_comp").ToString
            LabelWH.Text = GVWH.GetFocusedRowCellDisplayText("comp_name").ToString
            Dim query As String = "SELECT * FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' ORDER BY wh_locator_code ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCWHLocator.DataSource = data
            If data.Rows.Count > 0 Then
                'show all
                bnew_active2 = "1"
                bedit_active2 = "1"
                bdel_active2 = "1"
                viewRack()
                XTPRack.PageEnabled = True
            Else
                'hide all except new
                bnew_active2 = "1"
                bedit_active2 = "0"
                bdel_active2 = "0"
                XTPRack.PageEnabled = False
                XTPDrawer.PageEnabled = False
            End If
            pageChanged()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    Sub viewRack()
        Try
            id_wh_locator = GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
            LabelRack.Text = GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + " / " + GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString
            Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_wh_locator + "' ORDER BY wh_rack_code ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRack.DataSource = data
            'For i As Integer = 0 To (data.Rows.Count - 1)
            '    MsgBox(data.Rows(i)("wh_rack").ToString)
            'Next
            If data.Rows.Count > 0 Then
                'show all
                bnew_active3 = "1"
                bedit_active3 = "1"
                bdel_active3 = "1"
                XTPDrawer.PageEnabled = True
                viewDrawer()
            Else
                'hide all except new
                bnew_active3 = "1"
                bedit_active3 = "0"
                bdel_active3 = "0"
                XTPDrawer.PageEnabled = False
            End If
            pageChanged()
        Catch ex As Exception
            'errorConnection()
            'Close()
        End Try
    End Sub
    Sub viewDrawer()
        Try
            id_wh_rack = GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
            LabelDrawer.Text = GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + " / " + GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString + " / " + GVRack.GetFocusedRowCellDisplayText("wh_rack").ToString
            Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_wh_rack + "' ORDER BY wh_drawer_code ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDrawer.DataSource = data
            If data.Rows.Count > 0 Then
                'show all
                bnew_active4 = "1"
                bedit_active4 = "1"
                bdel_active4 = "1"
            Else
                'hide all except new
                bnew_active4 = "1"
                bedit_active4 = "0"
                bdel_active4 = "0"
            End If
            pageChanged()
        Catch ex As Exception
            'errorConnection()
            'Close()
        End Try
    End Sub

    'Update WH
    Private Sub BtnUpdateWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateWH.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = FormMain
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Row Click
    Private Sub GVLocator_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVLocator.RowClick
        viewRack()
    End Sub
    Private Sub GVWH_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVWH.RowClick

    End Sub
   
    Private Sub GVRack_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRack.RowClick
        viewDrawer()
    End Sub
    '-----------------------
    ' TAB STOCK DATA
    '-----------------------
    Sub viewSampleList(ByVal SLEWHx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLELocatorx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLERackx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLEDrawerx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal GC As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = SLEDrawerx.EditValue.ToString
        Dim id_wh_rack_view As String = SLERackx.EditValue.ToString
        Dim id_wh_locator_view As String = SLELocatorx.EditValue.ToString
        Dim id_wh_view As String = SLEWHx.EditValue.ToString
        Try
            Dim query As String = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '9999-12-01','1')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GC.DataSource = data
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub viewMatList(ByVal SLEWHx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLELocatorx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLERackx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLEDrawerx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal GC As DevExpress.XtraGrid.GridControl, ByVal GV As DevExpress.XtraGrid.Views.Grid.GridView)
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = SLEDrawerx.EditValue.ToString
        Dim id_wh_rack_view As String = SLERackx.EditValue.ToString
        Dim id_wh_locator_view As String = SLELocatorx.EditValue.ToString
        Dim id_wh_view As String = SLEWHx.EditValue.ToString
        'Try
        Dim query As String = "CALL view_stock_mat('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GC.DataSource = data
        GV.Columns("id_mat").GroupIndex = 0
        'Catch ex As Exception
        'errorConnection()
        ' End Try
        Cursor = Cursors.Default
    End Sub

    Sub viewFGList(ByVal SLEWHx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLELocatorx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLERackx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal SLEDrawerx As DevExpress.XtraEditors.SearchLookUpEdit, ByVal GC As DevExpress.XtraGrid.GridControl, ByVal GV As DevExpress.XtraGrid.Views.Grid.GridView)
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = SLEDrawerx.EditValue.ToString
        Dim id_wh_rack_view As String = SLERackx.EditValue.ToString
        Dim id_wh_locator_view As String = SLELocatorx.EditValue.ToString
        Dim id_wh_view As String = SLEWHx.EditValue.ToString
        Try
            Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '0','3', '9999-01-01')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GC.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub viewSampleStorage()
        viewSampleList(SLEWH, SLELocator, SLERack, SLEDrawer, GCSample)
        viewSampleStorageDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Sub viewMatStorage()
        viewMatList(SLEWHStockMat, SLELocatorStockMat, SLERackStockMat, SLEDrawerStockMat, GCMatStock, GVMatStock)
        viewMatStorageDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVMatStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEMatStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Sub viewFGStorage()
        viewFGList(SLEWHStockFG, SLELocatorStockFG, SLERackStockFG, SLEDrawerStockFG, GCFGStock, GVFGStock)
        viewFGStorageDetail()
        Dim id_sample As String = "0"
        Try
            id_sample = GVFGStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEFGStock, get_setup_field("pic_path_sample") & "\", id_sample, False)
    End Sub

    Sub viewSampleStorageDetail()
        Try
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


            Dim query As String = "SELECT *,CONCAT_WS(' ',DATE(a.datetime_storage_sample), CAST(TIME(a.datetime_storage_sample) AS CHAR) ) AS dt_storage_sample FROM tb_storage_sample a "
            query += "INNER JOIN tb_m_sample c ON a.id_sample = c.id_sample "
            query += "INNER JOIN tb_lookup_storage_category e ON e.id_storage_category = a.id_storage_category "
            query += "INNER JOIN tb_m_wh_drawer f ON f.id_wh_drawer = a.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack g ON g.id_wh_rack = f.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator h ON h.id_wh_locator = g.id_wh_locator "
            query += "INNER JOIN tb_m_comp i ON i.id_comp = h.id_comp "
            query += "WHERE a.id_wh_drawer LIKE '" + id_wh_drawer_view + "' "
            query += "AND g.id_wh_rack LIKE '" + id_wh_rack_view + "' "
            query += "AND h.id_wh_locator LIKE '" + id_wh_locator_view + "' "
            query += "AND i.id_comp LIKE '" + id_wh_view + "' "
            query += "AND a.id_sample = '" + id_samplex + "' "
            query += "ORDER BY a.datetime_storage_sample ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSampleDetail.DataSource = data
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub

    Sub viewMatStorageDetail()
        Dim id_mat_detx As String = ""
        Dim id_wh_drawer_view As String = ""
        Dim id_wh_rack_view As String = ""
        Dim id_wh_locator_view As String = ""
        Dim id_wh_view As String = ""
        Try
            id_mat_detx = GVMatStock.GetFocusedRowCellDisplayText("id_mat_det").ToString
            id_wh_drawer_view = SLEDrawerStockMat.EditValue.ToString
            id_wh_rack_view = SLERackStockMat.EditValue.ToString
            id_wh_locator_view = SLELocatorStockMat.EditValue.ToString
            id_wh_view = SLEWHStockMat.EditValue.ToString
        Catch ex As Exception
            'no action
        End Try

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
            Dim query As String = "SELECT *,CONCAT_WS(' ',DATE(a.storage_mat_datetime), CAST(TIME(a.storage_mat_datetime) AS CHAR) ) AS dt_storage_mat FROM tb_storage_mat a "
            query += "INNER JOIN tb_m_mat_det c ON a.id_mat_det = c.id_mat_det "
            query += "INNER JOIN tb_m_mat c1 ON c.id_mat = c1.id_mat "
            query += "INNER JOIN tb_lookup_storage_category e ON e.id_storage_category = a.id_storage_category "
            query += "INNER JOIN tb_m_wh_drawer f ON f.id_wh_drawer = a.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack g ON g.id_wh_rack = f.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator h ON h.id_wh_locator = g.id_wh_locator "
            query += "INNER JOIN tb_m_comp i ON i.id_comp = h.id_comp "
            query += "WHERE a.id_wh_drawer LIKE '" + id_wh_drawer_view + "' "
            query += "AND g.id_wh_rack LIKE '" + id_wh_rack_view + "' "
            query += "AND h.id_wh_locator LIKE '" + id_wh_locator_view + "' "
            query += "AND i.id_comp LIKE '" + id_wh_view + "' "
            query += "AND a.id_mat_det = '" + id_mat_detx + "' "
            query += "ORDER BY a.storage_mat_datetime ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatHistoryStock.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub viewFGStorageDetail()
        Dim id_bomx As String = ""
        Dim id_productx As String = ""
        Dim id_wh_drawer_view As String = ""
        Dim id_wh_rack_view As String = ""
        Dim id_wh_locator_view As String = ""
        Dim id_wh_view As String = ""
        Try
            'id_bomx = GVFGStock.GetFocusedRowCellValue("id_bom").ToString
            id_productx = GVFGStock.GetFocusedRowCellValue("id_product").ToString
            id_wh_drawer_view = SLEDrawerStockMat.EditValue.ToString
            id_wh_rack_view = SLERackStockMat.EditValue.ToString
            id_wh_locator_view = SLELocatorStockMat.EditValue.ToString
            id_wh_view = SLEWHStockMat.EditValue.ToString
        Catch ex As Exception
            'no action
        End Try

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
            Dim query As String = "SELECT *,CONCAT_WS(' ',DATE(a.storage_product_datetime), CAST(TIME(a.storage_product_datetime) AS CHAR) ) AS dt_storage_product FROM tb_storage_fg a "
            query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
            query += "INNER JOIN tb_m_design c1 ON c.id_design = c1.id_design "
            query += "INNER JOIN tb_lookup_storage_category e ON e.id_storage_category = a.id_storage_category "
            query += "INNER JOIN tb_m_wh_drawer f ON f.id_wh_drawer = a.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack g ON g.id_wh_rack = f.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator h ON h.id_wh_locator = g.id_wh_locator "
            query += "INNER JOIN tb_m_comp i ON i.id_comp = h.id_comp "
            query += "WHERE a.id_wh_drawer LIKE '" + id_wh_drawer_view + "' "
            query += "AND g.id_wh_rack LIKE '" + id_wh_rack_view + "' "
            query += "AND h.id_wh_locator LIKE '" + id_wh_locator_view + "' "
            query += "AND i.id_comp LIKE '" + id_wh_view + "' "
            query += "AND a.id_product = '" + id_productx + "' "
            'query += "AND a.id_bom = '" + id_bomx + "' "
            query += "ORDER BY a.storage_product_datetime ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCFGHistoryStock.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Function viewWHQuery(ByVal id_opt As String) As String
        Dim query As String = ""
        If Not is_single Then
            query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        End If
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
    Sub viewWHStock()
        Dim query As String = viewWHQuery("1")
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHStockMat()
        Dim query As String = viewWHQuery("2")
        viewSearchLookupQuery(SLEWHStockMat, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHStockFG()
        Dim query As String = viewWHQuery("3")
        viewSearchLookupQuery(SLEWHStockFG, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Function viewWHLocatorQuery(ByVal id_comp) As String
        Dim query As String = ""
        'If id_comp = "0" Then
        query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        'End If
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        Return query
    End Function
    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = viewWHLocatorQuery(id_comp)
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHLocatorSLEMat()
        Dim id_comp As String = SLEWHStockMat.EditValue.ToString
        Dim query As String = viewWHLocatorQuery(id_comp)
        viewSearchLookupQuery(SLELocatorStockMat, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHLocatorSLEFG()
        Dim id_comp As String = SLEWHStockFG.EditValue.ToString
        Dim query As String = viewWHLocatorQuery(id_comp)
        viewSearchLookupQuery(SLELocatorStockFG, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Function viewWHRackQuery(ByVal id_locator As String) As String
        'Dim query As String = ""
        Dim query As String = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        Return query
    End Function
    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = viewWHRackQuery(id_locator)
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHRackStockMat()
        Dim id_locator As String = SLELocatorStockMat.EditValue.ToString
        Dim query As String = viewWHRackQuery(id_locator)
        viewSearchLookupQuery(SLERackStockMat, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHRackStockFG()
        Dim id_locator As String = SLELocatorStockFG.EditValue.ToString
        Dim query As String = viewWHRackQuery(id_locator)
        viewSearchLookupQuery(SLERackStockFG, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Function viewWHDrawerQuery(ByVal id_rack As String) As String
        Dim query As String = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        Return query
    End Function
    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = viewWHDrawerQuery(id_rack)
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Sub viewWHDrawerStockMat()
        Dim id_rack As String = SLERackStockMat.EditValue.ToString
        Dim query As String = viewWHDrawerQuery(id_rack)
        viewSearchLookupQuery(SLEDrawerStockMat, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Sub viewWHDrawerStockFG()
        Dim id_rack As String = SLERackStockFG.EditValue.ToString
        Dim query As String = viewWHDrawerQuery(id_rack)
        viewSearchLookupQuery(SLEDrawerStockFG, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            GCSample.DataSource = Nothing
            GCSampleDetail.DataSource = Nothing
            viewWHLocatorSLE()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEWHStockMat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWHStockMat.EditValueChanged
        Try
            GCMatStock.DataSource = Nothing
            GCMatHistoryStock.DataSource = Nothing
            viewWHLocatorSLEMat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEWHStockFG_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWHStockFG.EditValueChanged
        Try
            GCFGStock.DataSource = Nothing
            GCFGHistoryStock.DataSource = Nothing
            viewWHLocatorSLEFG()
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

    Private Sub SLELocatorStockMat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocatorStockMat.EditValueChanged
        Try
            GCMatStock.DataSource = Nothing
            GCMatHistoryStock.DataSource = Nothing
            viewWHRackStockMat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLELocatorStockFG_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocatorStockFG.EditValueChanged
        Try
            GCFGStock.DataSource = Nothing
            GCFGHistoryStock.DataSource = Nothing
            viewWHRackStockFG()
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

    Private Sub SLERackStockMat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERackStockMat.EditValueChanged
        Try
            GCMatStock.DataSource = Nothing
            GCMatHistoryStock.DataSource = Nothing
            viewWHDrawerStockMat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLERackStockFG_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERackStockFG.EditValueChanged
        Try
            GCFGStock.DataSource = Nothing
            GCFGHistoryStock.DataSource = Nothing
            viewWHDrawerStockFG()
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

    Private Sub SLEDrawerStockMat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawerStockMat.EditValueChanged
        Try
            GCMatStock.DataSource = Nothing
            GCMatHistoryStock.DataSource = Nothing
            If SLEDrawerStockMat.EditValue Is Nothing Then
                BtnViewStockMat.Enabled = False
            Else
                BtnViewStockMat.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEDrawerStockFG_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawerStockFG.EditValueChanged
        Try
            GCFGStock.DataSource = Nothing
            GCFGHistoryStock.DataSource = Nothing
            If SLEDrawerStockFG.EditValue Is Nothing Then
                BtnViewStockFG.Enabled = False
            Else
                BtnViewStockFG.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Cursor = Cursors.WaitCursor
        Try
            viewSampleStorage()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewStockMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockMat.Click
        Cursor = Cursors.WaitCursor
        Try
            viewMatStorage()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewStockFG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockFG.Click
        Cursor = Cursors.WaitCursor
        Try
            viewFGStorage()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImgSampleStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgSampleStock.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub BtnImgMatStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgMatStock.Click
        Dim id_mat_detx As String = "0"
        Try
            id_mat_detx = GVMatStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEMatStock, get_setup_field("pic_path_mat") & "\", id_mat_detx, True)
    End Sub

    Private Sub BtnImgFGStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgFGStock.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVFGStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEFGStock, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        viewSampleStorageDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Private Sub GVMatStock_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatStock.FocusedRowChanged
        viewMatStorageDetail()
        Dim id_mat_detx As String = ""
        Try
            id_mat_detx = GVMatStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEMatStock, get_setup_field("pic_path_mat") & "\", id_mat_detx, False)
    End Sub

    Private Sub GVFGStock_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGStock.FocusedRowChanged
        viewFGStorageDetail()
        Dim id_samplex As String = ""
        Try
            id_samplex = GVFGStock.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PEFGStock, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Private Sub GVMatStock_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatStock.CustomColumnDisplayText
        If e.Column.FieldName = "id_mat" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatStock.IsGroupRow(rowhandle) Then
                rowhandle = GVMatStock.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatStock.GetRowCellValue(rowhandle, "mat_name")
            End If
        End If
    End Sub

    '-----------------------
    ' TAB DISTRIBUTION
    '-----------------------
    Sub viewSampleDistList()
        viewSampleList(SLEWHSampleDist, SLELocatorSampleDist, SLERackSampleDist, SLEDrawerSampleDist, GCSampleDist)
        viewSampleDistDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Sub viewSampleDistDetail()
        Dim id_sample As String = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
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
        viewSampleDistDetail()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, False)
    End Sub

    Private Sub BtnImgSampleDist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImgSampleDist.Click
        Dim id_samplex As String = ""
        Try
            id_samplex = GVSampleDist.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PESampleDist, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub GVWH_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVWH.FocusedRowChanged
        viewWHLocator()
    End Sub

    Private Sub BtnDefaultLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultLoc.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to add default locator, rack, and drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim id_wh_param As String = "-1"
            Try
                id_wh_param = GVWH.GetFocusedRowCellValue("id_comp").ToString
            Catch ex As Exception
            End Try
            Dim code_wh_param As String = "-1"
            Try
                code_wh_param = GVWH.GetFocusedRowCellValue("comp_number").ToString
            Catch ex As Exception
            End Try
            'MsgBox(code_wh_param.ToString)
            Dim query As String = "CALL generate_def_loc('" + id_wh_param + "', '" + code_wh_param + "') "
            execute_non_query(query, True, "", "", "", "")
            viewWHLocator()

            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub
End Class