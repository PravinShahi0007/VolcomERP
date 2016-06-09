Public Class FormViewProductionPLToWHRec
    Public action As String
    Public id_order As String = "-1"
    Public id_pl_prod_order_rec As String = "0"
    Public id_pl_prod_order As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_pl_prod_order_det_list, id_pl_prod_order_rec_det_list, id_pl_prod_order_rec_det_unique_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'var check duplicate unique
    Public cond_check_unique As Boolean = True
    Public sample_check_unique As String
    Public qty_pl_unique As Decimal
    Public allow_sum_unique As Decimal

    Public data_code As DataTable
    Public dt As New DataTable

    Public id_comp_to As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormProductionPLToWHRecDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccessSingle(Name)
        viewReportStatus() 'get report status
        viewPLCat()
        viewComp()
        actionLoad()
    End Sub

    Private Sub FormProductionPLToWHRecDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        'Enable/Disable
        GroupControlRet.Enabled = True
        GroupControlListBarcode.Enabled = True
        BMark.Enabled = True
        BtnAttachment.Enabled = True


        'View data
        Try
            Dim query As String = "SELECT b.id_prod_order, b1.prod_order_number, ss.season,(loc.id_comp) AS `id_comp_storage`,g.id_design,(f.id_comp) AS id_comp_to, i.pl_category, b.id_pl_category, h.design_name, h.id_sample, DATE_FORMAT(a.pl_prod_order_rec_date,'%Y-%m-%d') AS pl_prod_order_rec_datex, "
            query += "a.id_report_status, a.id_pl_prod_order, a.id_pl_prod_order_rec, a.pl_prod_order_rec_date, a.pl_prod_order_rec_note, a.pl_prod_order_rec_number, "
            query += "b1.prod_order_number, b.pl_prod_order_number,(c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, "
            query += "(d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, (e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS "
            query += "comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, h.design_cop, "
            query += "a.id_wh_drawer, CONCAT(drw.wh_drawer_code, '-', drw.wh_drawer) AS wh_drawer, "
            query += "rck.id_wh_rack, CONCAT(rck.wh_rack_code, '-', rck.wh_rack) AS wh_rack, "
            query += "loc.id_wh_locator, CONCAT(loc.wh_locator_code, '-', loc.wh_locator) AS wh_locator, "
            query += "alloc.id_pd_alloc, alloc.pd_alloc "
            query += "FROM tb_pl_prod_order_rec a "
            query += "INNER JOIN tb_pl_prod_order b ON a.id_pl_prod_order = b.id_pl_prod_order "
            query += "INNER JOIN tb_prod_order b1 ON b.id_prod_order = b1.id_prod_order "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b1.id_prod_demand_design "
            query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
            query += "INNER JOIN tb_lookup_pl_category i ON b.id_pl_category = i.id_pl_category "
            query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = b.id_pd_alloc "
            query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b1.id_delivery "
            query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
            query += "WHERE a.id_pl_prod_order_rec='" + id_pl_prod_order_rec + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'allocation
            viewComp()

            TxtUnitCost.EditValue = Decimal.Parse(data.Rows(0)("design_cop").ToString)
            TxtOrderNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            DERet.Text = view_date_from(data.Rows(0)("pl_prod_order_rec_datex").ToString, 0)
            TxtRetOutNumber.Text = data.Rows(0)("pl_prod_order_rec_number").ToString
            MENote.Text = data.Rows(0)("pl_prod_order_rec_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_pl_prod_order = data.Rows(0)("id_pl_prod_order").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_design = data.Rows(0)("id_design").ToString
            pre_viewImages("2", PEView, id_design, False)
            TEDesign.Text = data.Rows(0)("design_name").ToString
            PEView.Enabled = True

            'updated 28 Desember 2015
            SLEStorage.EditValue = data.Rows(0)("id_comp_storage").ToString
            SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
            SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
            SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            TxtPONumber.Text = data.Rows(0)("prod_order_number").ToString
            id_order = data.Rows(0)("id_prod_order").ToString
            mainVendor()
        Catch ex As Exception
            errorConnection()
        End Try

        view_barcode_list()
        viewDetail()
        check_but()
        allowDelete()
        allow_status()
    End Sub

    Sub mainVendor()
        'main vendor
        Dim data_vend As DataTable = getMainVendor(id_order)
        Try
            TxtVendorCode.Text = data_vend.Rows(0)("comp_number").ToString
            TxtVendor.Text = data_vend.Rows(0)("comp_name").ToString
        Catch ex As Exception
            TxtVendorCode.Text = ""
            TxtVendor.Text = ""
        End Try

    End Sub


    'View Storage
    Sub viewComp()
        Dim query As String = "SELECT a.id_comp, CONCAT(a.comp_number, '-', a.comp_name) AS comp_name, b.comp_cat_name, a.address_primary FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        'query += "WHERE a.id_departement = '" + id_departement_user + "' "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub allow_status()
        MENote.Properties.ReadOnly = True
        DERet.Properties.ReadOnly = True
        SLEStorage.Enabled = False
        SLELocator.Enabled = False
        SLERack.Enabled = False
        SLEDrawer.Enabled = False
        BtnAttachment.Enabled = True
        TxtRetOutNumber.Focus()
    End Sub
    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVRetDetail.RowCount > 0 Then
            'BtnEdit.Visible = True
            'BtnDel.Visible = True
        Else
            'BtnEdit.Visible = False
            'BtnDel.Visible = False
        End If
    End Sub
    'View po
    Sub view_list_po(ByVal id_pl_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_pl_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_pl_prod_order_det_list.Add(data.Rows(i)("id_pl_prod_order_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub

    Sub view_po()
        Dim query = "SELECT b.id_design, "
        query += "a.id_pl_prod_order,d.id_sample, a.pl_prod_order_number, d.design_display_name,d.design_name , d.design_code, g.pl_category, "
        query += "DATE_FORMAT(a.pl_prod_order_date,'%d %M %Y') AS pl_prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "a.id_comp_contact_from, a.id_comp_contact_to, (i.id_comp) AS id_comp_to, (i.comp_name) AS comp_name_to, (i.comp_number) AS comp_number_to, (k.comp_name) AS comp_name_from, (k.comp_number) AS comp_number_from, d.design_cop "
        query += "FROM tb_pl_prod_order a "
        query += "INNER JOIN tb_m_comp_contact h ON h.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp i ON h.id_comp = i.id_comp "
        query += "INNER JOIN tb_m_comp_contact j ON j.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp k ON k.id_comp = j.id_comp "
        query += "INNER JOIN tb_prod_order a1 ON a.id_prod_order = a1.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b ON a1.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_pl_category g ON g.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN tb_pl_prod_order_rec z ON a.id_pl_prod_order = z.id_pl_prod_order AND z.id_report_status!='5' "
        query += "WHERE (a.id_report_status = '3' OR a.id_report_status = '4' OR a.id_report_status = '6' OR a.id_report_status = '7') AND ISNULL(z.id_pl_prod_order_rec) AND a.id_pl_prod_order = '" + id_pl_prod_order + "' "
        query += "ORDER BY a.id_pl_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtUnitCost.EditValue = data.Rows(0)("design_cop")
        TxtOrderNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
        TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
        GroupControlRet.Enabled = True
        GroupControlListBarcode.Enabled = True
        viewDetail()
        view_barcode_list()
        id_pl_prod_order_det_list.Clear()
        check_but()
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        SLEStorage.EditValue = data.Rows(0)("id_comp_to").ToString
        TEDesign.Text = data.Rows(0)("design_name").ToString
        id_design = data.Rows(0)("id_design").ToString
        pre_viewImages("2", PEView, id_design, False)
        PEView.Enabled = True
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        Dim id_pl_prod_order_rec_det_par As String = "-1"
        Try
            id_pl_prod_order_rec_det_par = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_rec_det").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_prod_order_rec_det_counting) AS code, "
        query += "b.id_pl_prod_order_rec_det, (a.pl_prod_order_rec_det_counting) AS counting_code, a.id_pl_prod_order_rec_det_unique, ('2') AS is_fix, b.id_pl_prod_order_det "
        query += "FROM tb_pl_prod_order_rec_det_counting a "
        query += "INNER JOIN tb_pl_prod_order_rec_det b ON a.id_pl_prod_order_rec_det = b.id_pl_prod_order_rec_det "
        query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
        query += "WHERE b.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' AND a.id_counting_type='1' AND a.id_pl_prod_order_rec_det='" + id_pl_prod_order_rec_det_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_pl_prod_rec('" + id_pl_prod_order_rec + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        check_but()
    End Sub

    'View PL Category
    Sub viewPLCat()
        'Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    'Button
  

    Sub deleteDetailBc(ByVal id_pl_prod_order_det As String)
      
    End Sub
  
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_prod_order_rec
        FormReportMark.report_mark_type = "37"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

   
    'DeleteRows
    Sub deleteRowsBc()

    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub


    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim id_pl_prod_order_det As String = ""
        Dim counting_code As String = ""

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            id_pl_prod_order_det = dt.Rows(i)("id_pl_prod_order_det").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        'check duplicate code
        ' MsgBox(GVBarcode.RowCount.ToString)
        If GVBarcode.RowCount <= 0 Then
            code_duplicate = False
        Else
            For i As Integer = 0 To (GVBarcode.RowCount - 1)
                Dim code As String = ""
                If Not IsDBNull(GVBarcode.GetRowCellValue(i, "code")) Then
                    code = GVBarcode.GetRowCellValue(i, "code".ToString)
                End If

                Dim is_fix As String = "1"
                If Not IsDBNull(GVBarcode.GetRowCellValue(i, "is_fix")) Then
                    is_fix = GVBarcode.GetRowCellValue(i, "is_fix").ToString
                End If

                If code = code_check And is_fix = "2" Then
                    code_duplicate = True
                    Exit For
                End If
            Next
        End If


        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found !")
        ElseIf code_duplicate Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data duplicate !")
        Else
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det", id_pl_prod_order_det)
            'MsgBox(counting_code)
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            countQty(id_pl_prod_order_det)
            newRowsBc()
            'allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBarcode.CellValueChanged
        'MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()

    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_pl_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_pl_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_pl_prod_order_det").ToString
            If id_pl_prod_order_det = id_pl_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_pl_prod_order_det", id_pl_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("pl_prod_order_rec_det_qty", tot)
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    'check limit qty
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_pl_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        'MsgBox(id_pl_prod_order_det_cek)
        Dim query_check As String = "CALL view_stock_prod_pl_rec('" + id_pl_prod_order + "', '" + id_pl_prod_order_det_cek + "', '0', '0', '" + id_pl_prod_order_rec + "', '0') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpPLProdDet.id_pop_up = "1"
        FormPopUpPLProdDet.action = "ins"
        FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
        FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
        FormPopUpPLProdDet.BtnSave.Visible = False
        FormPopUpPLProdDet.is_info_form = True
        FormPopUpPLProdDet.XTPDetail.PageVisible = False
        FormPopUpPLProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub


    Private Sub GVRetDetail_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.DoubleClick
        Cursor = Cursors.WaitCursor
        FormPopUpPLProdDet.id_pop_up = "1"
        FormPopUpPLProdDet.action = "ins"
        FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
        FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
        FormPopUpPLProdDet.BtnSave.Visible = False
        FormPopUpPLProdDet.is_info_form = True
        FormPopUpPLProdDet.XTPDetail.PageVisible = False
        FormPopUpPLProdDet.id_pl_prod_order_det = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
        FormPopUpPLProdDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

  
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        Dim id_comp As String = "-1"
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Dim id_locator As String = "-1"
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Dim id_rack As String = "-1"
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_prod_order_rec
        FormDocumentUpload.report_mark_type = "37"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlTopMain_Paint(sender As Object, e As PaintEventArgs) Handles PanelControlTopMain.Paint

    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetDetail_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub
End Class