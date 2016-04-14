Public Class FormViewSampleDel
    Public action As String = ""
    Public id_sample_del As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim dt As New DataTable
    Public id_report_status As String = "-1"
    Public id_sample_del_det_list As New List(Of String)
    Public id_sample_del_det_drawer_list As New List(Of String)
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"

    Private Sub FormViewSampleDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewPLCat()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GroupControlDrawerDetail.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        XTPOutboundScanNew.PageEnabled = True

        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
        query += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
        query += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, (comp_from.id_comp) AS id_comp_from, "
        query += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, (comp_to.id_comp) AS id_comp_to, "
        query += "stt.report_status, "
        query += "DATE_FORMAT(del.sample_del_date, '%Y-%m-%d') AS sample_del_datex, del.sample_del_note, "
        query += "del.id_pl_category "
        query += "FROM tb_sample_del del "
        query += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
        query += "WHERE del.id_sample_del = '" + id_sample_del + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sample_del = data.Rows(0)("id_sample_del").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNumber.Text = data.Rows(0)("sample_del_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sample_del_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sample_del_note").ToString
        LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)

        ''detail2
        viewDetailBC()
        viewDetail()
        viewDetailDrawer()
        check_but()
        allow_status()
    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
       
    End Sub

    Sub check_but2()
      
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query As String = "CALL view_sample_del('" + id_sample_del + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_del_det_list.Add(data.Rows(i)("id_sample_del_det").ToString)
            For j As Integer = 0 To data.Rows(i)("sample_del_det_qty") - 1
                GVBarcode.AddNewRow()
                GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            Next
        Next
        GCItemList.DataSource = data
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        query += "SELECT a.id_sample_del_det_drawer, a.id_sample_del_det,a1.id_sample, a.id_wh_drawer, c.id_wh_rack, d.id_wh_locator, e.id_comp, b.id_wh_drawer, c.wh_rack, d.wh_locator, e.comp_name, "
        query += "(b.wh_drawer) AS drawer, (c.wh_rack) AS rack,  "
        query += "(d.wh_locator) AS locator, (e.comp_name) AS wh, a.id_sample_price, a.sample_price, a.id_sample_price, "
        query += "(a.sample_del_det_drawer_qty) AS qty_all_sample, (a.sample_del_det_drawer_qty) AS qty_all_sample_old,(a.sample_del_det_drawer_qty * a.sample_price) AS sample_amount_all  "
        query += "FROM tb_sample_del_det_drawer a   "
        query += "INNER JOIN tb_sample_del_det a1 ON a1.id_sample_del_det = a.id_sample_del_det "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer  "
        query += "INNER JOIN tb_m_wh_rack c ON c.id_wh_rack = b.id_wh_rack  "
        query += "INNER JOIN tb_m_wh_locator d ON d.id_wh_locator = c.id_wh_locator INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp WHERE a1.id_sample_del = '" + id_sample_del + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_del_det_drawer_list.Add(data.Rows(i)("id_sample_del_det_drawer").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        LEPLCategory.Enabled = False
        GVItemList.OptionsCustomization.AllowGroup = True
        GridColumnQtyWH.Visible = False
    End Sub

    Private Sub FormViewSampleDel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditRetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditRetail.CheckedChanged
        If CheckEditRetail.EditValue = True Then
            GridColumnRetail.Visible = True
            GridColumnRetail.VisibleIndex = 10
            GridColumnRetailAmount.Visible = True
            GridColumnRetailAmount.VisibleIndex = 11
            GridColumnRemark.VisibleIndex = 20
        Else
            GridColumnRetail.Visible = False
            GridColumnRetailAmount.Visible = False
        End If
    End Sub


    Private Sub CheckEditCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditCost.CheckedChanged
        If CheckEditCost.EditValue = True Then
            GridColumnCostAmount.Visible = True
            GridColumnCostAmount.VisibleIndex = 12
            GridColumnRemark.VisibleIndex = 20
        Else
            GridColumnCostAmount.Visible = False
        End If
    End Sub


    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub deleteDetailBC(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVBarcode.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception

            End Try
            If id_sample = id_sample_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVDrawer.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception
            End Try
            If id_sample = id_sample_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub countQtyFromWh(ByVal id_sample_param As String)
        Dim jum As Decimal = 0.0
        Dim jum_amount As Decimal = 0.0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim id_sample_i As String = GVDrawer.GetRowCellValue(i, "id_sample").ToString
                If id_sample_i = id_sample_param Then
                    jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_sample"))
                    jum_amount = jum_amount + Decimal.Parse(GVDrawer.GetRowCellValue(i, "sample_amount_all"))
                End If
            Catch ex As Exception
            End Try
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("sample_del_det_qty_wh", jum)
        GVItemList.SetFocusedRowCellValue("sample_del_det_amount", jum_amount)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        allowScanPage()
    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_del_det_qty_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_sample_style As String = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            Dim id_sample_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_sample"))
            If id_sample_check = id_sample_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_samplex As String = "-1"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        GVDrawer.ActiveFilterString = "[id_sample]='" + id_samplex + "'"
        GVBarcode.ActiveFilterString = "[id_sample]='" + id_samplex + "'"
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        'CEK BARCODE
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim id_sample As String = ""


        'check available code
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Dim code As String = GVItemList.GetRowCellValue(i, "code").ToString
            id_sample = GVItemList.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
            countQty(id_sample)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        Dim jum_amount_ret As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("sample_del_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("sample_del_det_amount_ret", tot * Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_ret_price").ToString))

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub


    Sub allowDelete()
      
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "60"
        FormReportMark.id_report = id_sample_del
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class