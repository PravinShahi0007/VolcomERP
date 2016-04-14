Public Class FormSampleStockOpnameDet 
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_so As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public dt As New DataTable
    Public id_fg_so_wh_det_list As New List(Of String)
    Public id_fg_so_wh_det_counting_list As New List(Of String)
    Dim id_comp_cat_wh As String = "-1"
    Public id_pl_category As String = "-1"
    Public pl_category As String = "-1"
    Dim id_lock As String = "-1"
    Dim is_scan As Boolean = False

    Private Sub FormFGStockOpnameWHDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")
        'call action
        actionLoad()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGStockOpnameWHDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_sample")
            dt.Columns.Add("code")
            dt.Columns.Add("sample_price")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            TxtSONumber.Text = header_number("18")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnLock.Enabled = False
            DECreated.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            GroupControlItem.Enabled = True
            BtnBrowseCompFrom.Enabled = False

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT so.sample_so_note, so.id_lock, so.id_sample_so, so.sample_so_number, so.id_report_status,stat.report_status, "
            query += "DATE_FORMAT(so.sample_so_date_created, '%Y-%m-%d') AS sample_so_date_created, "
            query += "DATE_FORMAT(so.sample_so_last_update, '%Y-%m-%d') AS sample_so_last_update, "
            query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
            query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from "
            query += "FROM tb_sample_so so "
            query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
            query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
            query += "WHERE so.id_sample_so = '" + id_sample_so + "' "

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtSONumber.Text = data.Rows(0)("sample_so_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            DECreated.Text = view_date_from(data.Rows(0)("sample_so_date_created").ToString, 0)
            TxtLastUpdate.Text = view_date_from(data.Rows(0)("sample_so_last_update").ToString, 0)
            MENote.Text = data.Rows(0)("sample_so_note").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_lock = data.Rows(0)("id_lock").ToString

            ''detail2
            viewDetail()
            view_barcode_list()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "SELECT ('0') AS code, ('') AS name, ('') AS size, ('') AS color, CAST('0' AS DECIMAL(13,2)) AS qty, CAST('0' AS DECIMAL(13,2)) AS sample_price, ('0') AS id_sample_price, CAST('0' AS DECIMAL(13,2)) AS amount, ('') AS note, ('0') AS id_sample, ('0') AS id_det "
            Dim datax As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = datax
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query As String = "CALL view_sample_so('" + id_sample_so + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_so_wh_det_list.Add(data.Rows(i)("id_det").ToString)
                id_param = id_param + data.Rows(i)("id_sample").ToString
                If i < (data.Rows.Count - 1) Then
                    id_param = id_param + ";"
                End If
            Next
            GCItemList.DataSource = data
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_sample_so_det, ('0') AS id_sample,('1') AS is_fix, CAST('0' AS DECIMAL(13,2)) AS sample_price, ('0') AS id_pl_category, ('') AS pl_category "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_sample_so_det, ('0') AS id_sample,('1') AS is_fix, CAST('0' AS DECIMAL(13,2)) AS sample_price, ('0') AS id_pl_category, ('') AS pl_category "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()

            query = "SELECT ('') AS no, "
            query += "c.sample_code as code, ('2') AS is_fix, "
            query += "b.id_sample,b.sample_price,b.id_pl_category, e.pl_category,b.sample_so_det_qty "
            query += "FROM tb_sample_so a "
            query += "INNER JOIN tb_sample_so_det b ON a.id_sample_so = b.id_sample_so "
            query += "INNER JOIN tb_m_sample c ON c.id_sample = b.id_sample "
            query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = b.id_pl_category "
            query += "WHERE b.id_sample_so = '" + id_sample_so + "' "
            data = execute_query(query, -1, True, "", "", "", "")
            'GCBarcode.DataSource = data
            For i As Integer = 0 To data.Rows.Count - 1
                For j As Integer = 0 To data.Rows(i)("sample_so_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample").ToString)
                    GVBarcode.SetFocusedRowCellValue("id_pl_category", data.Rows(i)("id_pl_category").ToString)
                    GVBarcode.SetFocusedRowCellValue("pl_category", data.Rows(i)("pl_category").ToString)
                    GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code").ToString)
                    GVBarcode.SetFocusedRowCellValue("sample_price", data.Rows(i)("sample_price").ToString)
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
            allowDelete()
        End If
    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        dt.Rows.Add(R)
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub allow_status()
        'BMark.Enabled = True
        If id_lock = "1" Then
            GVItemList.OptionsBehavior.Editable = True
            'PanelControlNav.Enabled = True
            PanelControlNavDetail.Enabled = True
            PanelNavBarcode.Enabled = True
            PanelNavBarcode.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            TxtSONumber.Properties.ReadOnly = True
            'BtnInfoSrs.Enabled = True
            BMark.Enabled = False
            BtnLock.Enabled = True
        Else
            GVItemList.OptionsBehavior.Editable = False
            'PanelControlNav.Enabled = False
            PanelControlNavDetail.Enabled = False
            PanelNavBarcode.Enabled = False
            PanelNavBarcode.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            TxtSONumber.Properties.ReadOnly = True
            'BtnInfoSrs.Enabled = False
            BMark.Enabled = True
            BtnLock.Enabled = False
        End If

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        TxtSONumber.Focus()
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
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
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

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        'MsgBox(id_product_param)
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next


        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        Dim cost As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_price").ToString)
        GVItemList.SetFocusedRowCellValue("amount", tot * cost)
        GVItemList.SetFocusedRowCellValue("qty", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sample_so
        FormReportMark.report_mark_type = "64"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            FormFGStockOpnameStoreSingle.id_pop_up = "3"
            FormFGStockOpnameStoreSingle.ShowDialog()
            'startScan()
        End If

    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            viewImagesBarcode(PictureEdit1, get_setup_field("pic_path_sample") & "\", False)
            BView.Enabled = False
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            BRefresh.Enabled = False
            TxtSONumber.Enabled = False
            newRowsBc()
            'allowDelete()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        is_scan = False
        BView.Enabled = True
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        BRefresh.Enabled = True
        TxtSONumber.Enabled = True
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        allowDelete()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_sample As String = GVBarcode.GetFocusedRowCellValue("id_sample").ToString

            deleteRowsBc()
            If id_sample <> "" Or id_sample <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_sample)
            End If

            allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
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

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim code_item_found As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_sample As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0

        'check available code
        For i As Integer = 0 To GVItemList.RowCount - 1
            Dim code As String = GVItemList.GetRowCellValue(i, "code").ToString
            id_sample = GVItemList.GetRowCellValue(i, "id_sample").ToString
            bom_unit_price = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_price").ToString)
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
            GVBarcode.SetFocusedRowCellValue("sample_price", bom_unit_price)
            GVBarcode.SetFocusedRowCellValue("id_pl_category", id_pl_category)
            GVBarcode.SetFocusedRowCellValue("pl_category", pl_category)
            countQty(id_sample)
            newRowsBc()
        End If
        Cursor = Cursors.Default
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

    Private Sub BtnBrowseStoreFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseCompFrom.Click
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.id_pop_up = "55"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        If Not is_scan Then
            viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        End If
        check_but()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub FormFGStockOpnameWHDet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        GVBarcode.ShowEditor()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Scanned item can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sample_so_number As String = TxtSONumber.Text
                Dim sample_so_note As String = MENote.Text

                If action = "ins" Then
                    'query main table
                    Dim query_main As String = ""
                    query_main = "INSERT INTO tb_sample_so(id_comp_contact_from, sample_so_number, sample_so_date_created, sample_so_last_update, sample_so_note, id_report_status) "
                    query_main += "VALUES ('" + id_comp_contact_from + "', '" + sample_so_number + "', NOW(), NOW(), '" + sample_so_note + "', '1');SELECT LAST_INSERT_ID() "
              
                    id_sample_so = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc("18")

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        '
                        Dim query_pl_cat As String = "SELECT id_pl_category FROM tb_lookup_pl_category"
                        Dim data_pl_cat As DataTable = execute_query(query_pl_cat, "-1", True, "", "", "", "")
                        '
                        query_detail = "INSERT tb_sample_so_det(id_sample_so, id_sample,id_sample_price, sample_price, sample_so_det_qty, sample_so_det_note, id_pl_category) VALUES "
                        For j As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                                Dim id_sample_price As String = GVItemList.GetRowCellValue(j, "id_sample_price").ToString
                                Dim sample_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_price").ToString)
                                Dim sample_so_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                                Dim sample_so_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                                Dim dt_temp As DataTable = GCBarcode.DataSource

                                For k As Integer = 0 To data_pl_cat.Rows.Count - 1
                                    Dim result() As DataRow = dt_temp.Select("id_sample='" & id_sample & "' AND id_pl_category='" & data_pl_cat.Rows(k)("id_pl_category").ToString() & "' AND is_fix='2'")
                                    ' Loop and display.
                                    If Not result.Length = 0 Then
                                        If jum_ins_j > 0 Then
                                            query_detail += ", "
                                        End If
                                        query_detail += "('" + id_sample_so + "', '" + id_sample + "','" & id_sample_price & "', '" + sample_price + "', '" + result.Length.ToString + "', '" + sample_so_det_note + "','" & data_pl_cat.Rows(k)("id_pl_category").ToString() & "') "
                                        jum_ins_j = jum_ins_j + 1
                                    End If
                                Next
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If
                    End If
                    FormSampleStockOpname.viewSOWH()
                    FormSampleStockOpname.GVSOWH.FocusedRowHandle = find_row(FormSampleStockOpname.GVSOWH, "id_sample_so", id_sample_so)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_sample_so SET id_comp_contact_from = '" + id_comp_contact_from + "', sample_so_number= '" + sample_so_number + "', sample_so_note = '" + sample_so_note + "', sample_so_last_update = NOW() WHERE id_sample_so = '" + id_sample_so + "' "
                    execute_non_query(query_main, True, "", "", "", "")
                    'Detail return
                    Dim jum_ins_j As Integer = 0

                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        '
                        Dim query_pl_cat As String = "SELECT id_pl_category FROM tb_lookup_pl_category"
                        Dim data_pl_cat As DataTable = execute_query(query_pl_cat, "-1", True, "", "", "", "")
                        '
                        query_detail = "DELETE FROM tb_sample_so_det WHERE id_sample_so='" + id_sample_so + "';INSERT tb_sample_so_det(id_sample_so, id_sample,id_sample_price, sample_price, sample_so_det_qty, sample_so_det_note, id_pl_category) VALUES "
                        For j As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                                Dim id_sample_price As String = GVItemList.GetRowCellValue(j, "id_sample_price").ToString
                                Dim sample_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_price").ToString)
                                Dim sample_so_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                                Dim sample_so_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                                Dim dt_temp As DataTable = GCBarcode.DataSource

                                For k As Integer = 0 To data_pl_cat.Rows.Count - 1
                                    Dim result() As DataRow = dt_temp.Select("id_sample='" & id_sample & "' AND id_pl_category='" & data_pl_cat.Rows(k)("id_pl_category").ToString() & "' AND is_fix='2'")
                                    ' Loop and display.
                                    If Not result.Length = 0 Then
                                        If jum_ins_j > 0 Then
                                            query_detail += ", "
                                        End If
                                        query_detail += "('" + id_sample_so + "', '" + id_sample + "','" & id_sample_price & "', '" + sample_price + "', '" + result.Length.ToString + "', '" + sample_so_det_note + "','" & data_pl_cat.Rows(k)("id_pl_category").ToString() & "') "
                                        jum_ins_j = jum_ins_j + 1
                                    End If
                                Next
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If
                    End If
                    FormSampleStockOpname.viewSOWH()
                    FormSampleStockOpname.GVSOWH.FocusedRowHandle = find_row(FormSampleStockOpname.GVSOWH, "id_sample_so", id_sample_so)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub TxtNameStoreFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Nobody can't edit this data after locking process, are you sure to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'get product
            Dim query_product As String = "("
            Dim query_product2 As String = "("
            For i As Integer = 0 To GVItemList.RowCount - 1
                Try
                    Dim id_samplex As String = GVItemList.GetRowCellValue(i, "id_sample").ToString
                    query_product = query_product + "j.id_sample LIKE ''" + id_samplex + "'' "
                    query_product2 = query_product2 + "a.id_sample LIKE ''" + id_samplex + "'' "
                    If i < (GVItemList.RowCount - 1) Then
                        query_product = query_product + "OR "
                        query_product2 = query_product2 + "OR "
                    End If
                Catch ex As Exception
                End Try
            Next
            query_product = query_product + ")"
            query_product2 = query_product2 + ")"
            Try
                Dim query As String = "CALL generate_sum_sample_so('" + id_sample_so + "', '" + id_comp_from + "', '" + query_product + "', '" + query_product2 + "')"
                execute_non_query(query, True, "", "", "", "")
                'insert who prepared
                insert_who_prepared("64", id_sample_so, id_user)
                '
                FormSampleStockOpname.viewSOWH()
                infoCustom("Sample Stock Opname Number : " & TxtSONumber.Text & " Locked.")
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSampleStockOpname.id_sample_so = id_sample_so
        Dim Report As New ReportSampleStockOpname()

        ReportSampleStockOpname.dt = GCItemList.DataSource

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        
        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        Report.LSONumber.Text = TxtSONumber.Text
        Report.LWH.Text = TxtCodeCompFrom.Text & " - " & TxtNameCompFrom.Text
        Report.LDateCreated.Text = DECreated.Text
        Report.LDateLastUpdated.Text = TxtLastUpdate.Text

        Report.LabelNote.Text = MENote.Text

        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSampleStockOpnameSingle.id_wh = id_comp_from
        FormSampleStockOpnameSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_sample As String = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            deleteDetailBC(id_sample)
            check_but()
            allowDelete()
            Cursor = Cursors.Default
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_samplex <> "0" Then
            BtnDel.Enabled = True
        Else
            BtnDel.Enabled = False
        End If
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub
End Class