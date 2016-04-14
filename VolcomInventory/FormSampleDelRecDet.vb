Public Class FormSampleDelRecDet 
    Public action As String = "-1"
    Public id_sample_del_rec As String = "-1"
    Public id_report_status As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_sample_del_rec_det_list As New List(Of String)
    Public id_sample_del_rec_det_drawer_list As New List(Of String)
    Public id_sample_del As String = "-1"
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"


    Private Sub FormSampleDelRecDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSampleDelRecDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtNumber.Text = header_number("15")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            XTPInboundItemNew.PageEnabled = False
            allowDelete()

            'From Waiting List
            If id_sample_del <> "-1" Then
                viewSampleDel()
                viewSampleDelDet()
                viewDetailBC()
                viewDetailDrawer()
                GroupControlListItem.Enabled = True
                GroupControlDrawerDetail.Enabled = True
                GroupControlScannedItem.Enabled = True
                BtnInfoSrs.Enabled = True
            End If
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlDrawerDetail.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseSamplePLDel.Enabled = False
            XTPInboundScanNew.PageEnabled = True
            BtnBrowseSamplePLDel.Enabled = False
            BtnInfoSrs.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
            Dim query As String = query_c.queryMain("AND rec.id_sample_del_rec=''" + id_sample_del_rec + "'' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_sample_del = data.Rows(0)("id_sample_del").ToString
            id_sample_del_rec = data.Rows(0)("id_sample_del_rec").ToString
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
            TxtNumber.Text = data.Rows(0)("sample_del_rec_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sample_del_rec_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sample_del_rec_note").ToString
            TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
            TxtSampleDelNumber.Text = data.Rows(0)("sample_del_number").ToString

            ''detail2
            viewDetailBC()
            viewDetail()
            viewDetailDrawer()
            allow_status()
        End If
    End Sub

    Sub viewSampleDel()
        Dim queryx As String = ""
        queryx += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
        queryx += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
        queryx += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, (comp_from.id_comp) AS id_comp_from, "
        queryx += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, (comp_to.id_comp) AS id_comp_to, "
        queryx += "stt.report_status, "
        queryx += "DATE_FORMAT(del.sample_del_date, '%Y-%m-%d') AS sample_del_datex, del.sample_del_note, "
        queryx += "del.id_pl_category, pl_cat.pl_category "
        queryx += "FROM tb_sample_del del "
        queryx += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
        queryx += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
        queryx += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
        queryx += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
        queryx += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
        queryx += "INNER JOIN tb_lookup_pl_category pl_cat ON pl_cat.id_pl_category = del.id_pl_category "
        queryx += "WHERE del.id_sample_del = '" + id_sample_del + "' "
        Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        TxtPLCategory.Text = datax.Rows("0")("pl_category").ToString
        TxtSampleDelNumber.Text = datax.Rows("0")("sample_del_number").ToString
        id_comp_contact_from = datax.Rows("0")("id_comp_contact_from").ToString
        TxtCodeCompFrom.Text = datax.Rows("0")("comp_number_from").ToString
        TxtNameCompFrom.Text = datax.Rows("0")("comp_name_from").ToString
        id_comp_contact_to = datax.Rows("0")("id_comp_contact_to").ToString
        TxtCodeCompTo.Text = datax.Rows("0")("comp_number_to").ToString
        TxtNameCompTo.Text = datax.Rows("0")("comp_name_to").ToString
    End Sub

    Sub viewSampleDelDet()
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryDetail(id_sample_del)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            viewSampleDelDet()
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
            Dim query As String = query_c.queryDetail(id_sample_del_rec)
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_del_rec_det_list.Add(data.Rows(i)("id_sample_del_rec_det").ToString)
                For j As Integer = 0 To data.Rows(i)("sample_del_rec_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                    GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next
            GCItemList.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
        End If
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        If action = "ins" Then
            query += "SELECT ('0') AS id_sample_del_rec_det_drawer, det.id_sample_del_det, "
            query += "drw.id_sample_price, drw.sample_price, "
            query += "SUM(drw.sample_del_det_drawer_qty) AS sample_del_rec_det_drawer_qty, "
            query += "CAST('0' AS DECIMAL(10,2)) AS sample_del_rec_det_drawer_qty_stored "
            query += "FROM tb_sample_del_det_drawer drw "
            query += "INNER JOIN tb_sample_del_det det ON drw.id_sample_del_det = det.id_sample_del_det "
            query += "WHERE det.id_sample_del = '" + id_sample_del + "' "
            query += "GROUP BY drw.id_sample_price "
        ElseIf action = "upd" Then
            Dim query_c As ClassSampleDelRec = New ClassSampleDelRec
            query = query_c.queryDetailCost("AND rec_det.id_sample_del_rec = ''" + id_sample_del_rec + "'' ", "1")
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "61", id_sample_del_rec) Then
            GVItemList.OptionsBehavior.Editable = True
            PanelNavBarcode.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnBrowseContactTo.Enabled = True
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnSave.Enabled = True
        Else
            GVItemList.OptionsBehavior.Editable = False
            PanelNavBarcode.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnBrowseContactTo.Enabled = False
            GVItemList.OptionsCustomization.AllowGroup = True
            BtnSave.Enabled = False
        End If

        'Btn Storage
        If check_storage_report_status(id_report_status) Then
            XTPInboundItemNew.PageEnabled = True
        Else
            XTPInboundItemNew.PageEnabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    '----------Validating
    Private Sub TxtSampleDelNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSampleDelNumber.Validating
        EP_TE_cant_blank(EPForm, TxtSampleDelNumber)
        EPForm.SetIconPadding(TxtSampleDelNumber, 58)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
    End Sub

    '------------GRID ITEM LIST
    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_sample_del_detx As String = "-1"
        Try
            id_sample_del_detx = GVItemList.GetFocusedRowCellValue("id_sample_del_det").ToString
        Catch ex As Exception
        End Try
        GVDrawer.ActiveFilterString = "[id_sample_del_det]='" + id_sample_del_detx + "'"
    End Sub

    '------------BARCODE
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
        GVItemList.SetFocusedRowCellValue("sample_del_rec_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("sample_del_rec_det_amount_ret", tot * Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_ret_price").ToString))

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

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            startScan()
        End If
    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            TxtNumber.Enabled = False
            newRowsBc()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Sub stopScan()
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

        is_scan = False
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        stopScan()
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_samplex As String = "-1"

        Try
            id_samplex = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_sample As String = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

            deleteRowsBc()
            If id_sample <> "" Or id_sample <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_sample)
            End If

            allowDelete()
        End If
    End Sub

    '--------------STORAGE
    Private Sub BtnSaveInStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveInStorage.Click
        Cursor = Cursors.WaitCursor
        Dim sample_del_rec_det_drawer_qty As Decimal = 0.0
        Dim sample_del_rec_det_drawer_qty_stored As Decimal = 0.0
        Dim id_sample_del_rec_det_drawer As String = "-1"
        Try
            sample_del_rec_det_drawer_qty = GVDrawer.GetFocusedRowCellValue("sample_del_rec_det_drawer_qty").ToString
            sample_del_rec_det_drawer_qty_stored = GVDrawer.GetFocusedRowCellValue("sample_del_rec_det_drawer_qty_stored").ToString
            id_sample_del_rec_det_drawer = GVDrawer.GetFocusedRowCellValue("id_sample_del_rec_det_drawer").ToString
        Catch ex As Exception
        End Try

        If sample_del_rec_det_drawer_qty > sample_del_rec_det_drawer_qty_stored Then
            FormSampleStorageIn.id_sample_purc_rec_det = id_sample_del_rec_det_drawer
            FormSampleStorageIn.action = "upd_del_rec"
            FormSampleStorageIn.report_mark_type = "61"
            FormSampleStorageIn.id_report = id_sample_del_rec
            FormSampleStorageIn.ShowDialog()
        Else
            errorCustom("All item for this product has been stored in warehouse")
        End If
        Cursor = Cursors.Default
    End Sub

    '---------------General Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        GVDrawer.ActiveFilter.Clear()

        'cek kesamaan from wh dengan scan
        Dim qty_check As Decimal = 0.0
        Dim id_sample_del_det_cek As String = "-1"
        Dim code_check As String = ""
        Dim is_same_qty As Boolean = True
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query_cek As String = query_c.queryDetail(id_sample_del)
        Dim dtd_temp As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                code_check = GVItemList.GetRowCellValue(i, "code").ToString
                id_sample_del_det_cek = GVItemList.GetRowCellValue(i, "id_sample_del_det").ToString
                qty_check = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_del_rec_det_qty"))
                dtd_temp.DefaultView.RowFilter = "id_sample_del_det = '" + id_sample_del_det_cek + "' "
                Dim data_cek As DataTable = dtd_temp.DefaultView.ToTable
                If qty_check <> data_cek.Rows(0)("sample_del_det_qty") Then
                    is_same_qty = False
                    dtd_temp.Dispose()
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVDrawer.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            stopCustom("Transfer item and scanned item data can't blank")
        ElseIf Not is_same_qty Then
            stopCustom("Qty received not equal to qty delivered, for sample code : " + code_check + ". Please check your input !")
            FormSampleDelRecInfo.GridColumnRecQty.Visible = False
            FormSampleDelRecInfo.GridColumnRemainingQty.Visible = False
            FormSampleDelRecInfo.GridColumnReceivingQty.Visible = True
            FormSampleDelRecInfo.GridColumnReceivingQty.VisibleIndex = 10
            FormSampleDelRecInfo.GridColumnRemark.VisibleIndex = 11
            FormSampleDelRecInfo.is_mode_check = True
            FormSampleDelRecInfo.qty_check = qty_check
            FormSampleDelRecInfo.id_sample_del_det_cek = id_sample_del_det_cek
            infoSrs()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sample_del_rec_number As String = TxtNumber.Text
                Dim sample_del_rec_note As String = MENote.Text.ToString
                If action = "ins" Then
                    'query main table
                    Dim query_main As String = "INSERT tb_sample_del_rec(id_sample_del, sample_del_rec_number, id_comp_contact_from, id_comp_contact_to, sample_del_rec_date, sample_del_rec_note, id_report_status) "
                    query_main += "VALUES('" + id_sample_del + "', '" + sample_del_rec_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), '" + sample_del_rec_note + "', '1'); SELECT LAST_INSERT_ID(); "

                    'Get Id & increment number doc
                    id_sample_del_rec = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc("15")


                    'insert who prepared
                    insert_who_prepared("61", id_sample_del_rec, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_del_rec_det(id_sample_del_det, id_sample_del_rec, id_sample, sample_del_rec_det_qty, sample_del_rec_det_note, id_sample_ret_price, sample_ret_price) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample_del_det As String = GVItemList.GetRowCellValue(j, "id_sample_del_det").ToString
                            Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                            Dim sample_del_rec_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_del_rec_det_qty").ToString)
                            Dim sample_del_rec_det_note As String = GVItemList.GetRowCellValue(j, "sample_del_rec_det_note").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(j, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_ret_price").ToString)

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sample_del_det + "', '" + id_sample_del_rec + "', '" + id_sample + "', '" + sample_del_rec_det_qty + "', '" + sample_del_rec_det_note + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_sample_del_det, a.id_sample_del_rec_det, a.id_sample "
                    query_get_detail_id += "FROM tb_sample_del_rec_det a "
                    query_get_detail_id += "WHERE a.id_sample_del_rec = '" + id_sample_del_rec + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'drawer
                    Dim jum_ins_s As Integer = 0
                    Dim query_drawer As String = ""
                    If GVDrawer.RowCount > 0 Then
                        query_drawer = "INSERT INTO tb_sample_del_rec_det_drawer(id_sample_del_rec_det, id_sample_price,sample_price, sample_del_rec_det_drawer_qty, sample_del_rec_det_drawer_qty_stored) VALUES "
                    End If
                    For s As Integer = 0 To (GVDrawer.RowCount - 1)
                        Dim id_sample_del_det_drawer As String = GVDrawer.GetRowCellValue(s, "id_sample_del_det")
                        Dim id_sample_price As String = GVDrawer.GetRowCellValue(s, "id_sample_price")
                        Dim sample_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "sample_price").ToString)
                        Dim sample_del_rec_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "sample_del_rec_det_drawer_qty").ToString)
                        Dim sample_del_rec_det_drawer_qty_stored As String = decimalSQL(GVDrawer.GetRowCellValue(s, "sample_del_rec_det_drawer_qty_stored").ToString)
                        Dim id_sample_del_rec_det_drawer As String = ""
                        For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_sample_del_det_drawer = data_get_detail_id.Rows(s1)("id_sample_del_det").ToString Then
                                If jum_ins_s > 0 Then
                                    query_drawer += ", "
                                End If
                                query_drawer += "('" + data_get_detail_id.Rows(s1)("id_sample_del_rec_det").ToString + "', '" + id_sample_price + "', '" + sample_price + "', '" + sample_del_rec_det_drawer_qty + "', '" + sample_del_rec_det_drawer_qty_stored + "') "
                                jum_ins_s = jum_ins_s + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVDrawer.RowCount > 0 Then
                        execute_non_query(query_drawer, True, "", "", "", "")
                    End If

                    FormSampleDelRec.viewSampleDelRec()
                    FormSampleDelRec.viewSampleDel()
                    FormSampleDelRec.GVSampleDelRec.FocusedRowHandle = find_row(FormSampleDelRec.GVSampleDelRec, "id_sample_del_rec", id_sample_del_rec)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_sample_del_rec SET id_sample_del='" + id_sample_del + "', sample_del_rec_number = '" + sample_del_rec_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', sample_del_rec_note = '" + sample_del_rec_note + "' WHERE id_sample_del_rec = '" + id_sample_del_rec + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_del_rec_det(id_sample_del_det, id_sample_del_rec, id_sample, sample_del_rec_det_qty, sample_del_rec_det_note, id_sample_ret_price, sample_ret_price) "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample_del_rec_det As String = GVItemList.GetRowCellValue(j, "id_sample_del_rec_det").ToString
                            Dim id_sample_del_det As String = GVItemList.GetRowCellValue(j, "id_sample_del_det").ToString
                            Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(j, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_ret_price").ToString)
                            Dim sample_del_rec_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_del_rec_det_qty").ToString)
                            Dim sample_del_rec_det_note As String = GVItemList.GetRowCellValue(j, "sample_del_rec_det_note").ToString


                            If id_sample_del_rec_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "VALUES('" + id_sample_del_det + "', '" + id_sample_del_rec + "','" + id_sample + "', '" + sample_del_rec_det_qty + "', '" + sample_del_rec_det_note + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_sample_del_rec_det SET id_sample_del_det='" + id_sample_del_det + "', id_sample = '" + id_sample + "', sample_del_rec_det_qty = '" + sample_del_rec_det_qty + "', sample_del_rec_det_note = '" + sample_del_rec_det_note + "', id_sample_ret_price = '" + id_sample_ret_price + "', sample_ret_price = '" + sample_ret_price + "' WHERE id_sample_del_rec_det = '" + id_sample_del_rec_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_sample_del_rec_det_list.Remove(id_sample_del_rec_det)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    FormSampleDelRec.viewSampleDel()
                    FormSampleDelRec.viewSampleDelRec()
                    FormSampleDelRec.GVSampleDelRec.FocusedRowHandle = find_row(FormSampleDelRec.GVSampleDelRec, "id_sample_del_rec", id_sample_del_rec)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSampleDelRec.id_sample_del_rec = id_sample_del_rec
        ReportSampleDelRec.dt = GCItemList.DataSource
        Dim Report As New ReportSampleDelRec()

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

        Report.LabelFrom.Text = TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtNameCompTo.Text
        Report.LabelNo.Text = TxtNumber.Text
        Report.LabelDate.Text = DEForm.Text
        Report.LabelPLCategory.Text = TxtPLCategory.Text
        Report.LabelNote.Text = MENote.Text


        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "61"
        FormReportMark.id_report = id_sample_del_rec
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseSamplePLDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseSamplePLDel.Click
        Cursor = Cursors.WaitCursor
        FormSampleDelRecPop.id_pop_up = "1"
        FormSampleDelRecPop.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "52"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        Cursor = Cursors.WaitCursor
        infoSrs()
        Cursor = Cursors.Default
    End Sub

    Sub infoSrs()
        FormSampleDelRecInfo.LabelSubTitle.Text = "PL Sample Delivery No: " + TxtSampleDelNumber.Text
        FormSampleDelRecInfo.id_sample_del = id_sample_del
        FormSampleDelRecInfo.ShowDialog()
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
       
    End Sub
End Class