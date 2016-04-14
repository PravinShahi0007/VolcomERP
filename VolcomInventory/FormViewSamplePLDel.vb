Public Class FormViewSamplePLDel

    Public action As String
    Public id_pl_sample_del As String
    Public id_comp_contact_from, id_comp_from As String
    Public id_comp_contact_to, id_comp_to As String
    Public code_list, code_list_drawer, id_sample_list As New List(Of String)
    Dim id_pl_sample_del_det_list As New List(Of String)
    Dim test_old As String
    Public id_report_status As String
    Public id_sample_requisition As String = "-1"
    Public id_sample_requisition_det_style As String
    Dim qty_process As Decimal
    Dim based_on_srs As Boolean = False
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'Form Load
    Private Sub FormViewSamplePLDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccessSingle(Name) 'check access
        viewReportStatus() 'get report status
        actionLoad()
    End Sub
    Sub actionLoad()
        'Fetch from db main
        Dim query As String = "SELECT a.pl_sample_del_duration ,a.id_sample_requisition, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, "
        query += "DATE_FORMAT(a.pl_sample_del_date,'%Y-%m-%d') as pl_sample_del_datex,cod_det.code_detail_name as division "
        query += "FROM tb_pl_sample_del a "
        query += "INNER JOIN tb_sample_requisition samp_req ON samp_req.id_sample_requisition=a.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=samp_req.id_division "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'tampung ke form
        TEDivision.Text = data.Rows(0)("division").ToString
        SPDuration.Text = data.Rows(0)("pl_sample_del_duration").ToString
        TxtSRSNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        TxtPLNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
        DEPL.Text = view_date_from(data.Rows(0)("pl_sample_del_datex").ToString(), 0)
        MENote.Text = data.Rows(0)("pl_sample_del_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_sample_requisition = data.Rows(0)("id_sample_requisition").ToString

        'Group Control
        GroupControlDetailSingle.Enabled = True
        GroupControlDrawer.Enabled = True

        'based on sttatus
        id_report_status = data.Rows(0)("id_report_status").ToString
        If id_report_status = "3" Or id_report_status = "4" Or id_report_status = "6" Then
            BtnPopTo.Enabled = False
            BtnPopFrom.Enabled = False
            BAdd.Enabled = False
            Bdel.Enabled = False
            'GVDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            SPDuration.Properties.ReadOnly = True
        ElseIf id_report_status = "5" Then
            BtnPopTo.Enabled = False
            BtnPopFrom.Enabled = False
            BAdd.Enabled = False
            Bdel.Enabled = False
            'GVDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            GridColumnQtyReq.Visible = False
            'GridColumnQty.Visible = False
            GroupControlDetailSingle.Enabled = False
            GroupControlDrawer.Enabled = False
            SPDuration.Properties.ReadOnly = True
        Else
            If check_edit_report_status(id_report_status, "10", id_pl_sample_del) Then
                'MsgBox("Masih Boleh")
                BtnPopTo.Enabled = True
                BtnPopFrom.Enabled = True
                BAdd.Enabled = True
                Bdel.Enabled = True
                'GVDetail.OptionsBehavior.Editable = True
                MENote.Properties.ReadOnly = False
                SPDuration.Properties.ReadOnly = False
            Else
                'MsgBox("Nggak Boleh")
                BtnPopTo.Enabled = False
                BAdd.Enabled = False
                Bdel.Enabled = False
                'GVDetail.OptionsBehavior.Editable = False
                MENote.Properties.ReadOnly = True
                SPDuration.Properties.ReadOnly = True
            End If
        End If
        'Fetch db detail
        viewFillEmptyData()
        viewDetailBC()
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetailBC()
        
    End Sub

    Sub viewFillEmptyData()
        'Dim query As String = "SELECT ('0') AS id_pl_sample_del_det, ('0') AS id_pl_sample_del,('') AS code_full, ('') AS name, ('') AS size, ('') AS uom, ('0') AS id_storage_sample, ('0') AS id_sample_unique, ('') AS pl_sample_del_det_note "
        Dim query As String = "CALL view_sample_req_det_limit('" + id_sample_requisition + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        viewPLSample()
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_list.Add(data.Rows(i)("id_sample").ToString)
            If action = "upd" Then
                getAmountReq(data.Rows(i)("id_sample_requisition_det").ToString, False)
                Dim qty_pl As Decimal = 0.0
                Try
                    qty_pl = GVDetail.GetFocusedRowCellValue("qty_real_sample_wh")
                Catch ex As Exception
                End Try
                GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_pl)
            End If
        Next
        GVDetail.FocusedRowHandle = 0
    End Sub
    Sub viewFillEmptyDrawer()
        Dim query As String = "SELECT ('0') AS id_pl_sample_del_det, ('0') AS id_sample,('') AS code, ('') AS name, ('0') AS id_wh_drawer, ('') AS wh_locator, ('') AS wh_rack,  ('') AS wh_drawer, ('0') AS pl_sample_del_det_qty, ('') AS pl_sample_del_det_note, ('0') AS qty_all_sample, ('0') AS id_sample_requisition_det, ('') AS uom, ('0') AS id_wh_locator, ('0') AS id_wh_rack, ('0') as id_sample_price, ('0') as sample_price "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        deleteRows()
    End Sub
    'View PL Sample
    Sub viewPLSample()
        Dim query As String = "CALL view_pl_sample_del('" + id_pl_sample_del + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            code_list.Add(data.Rows(i)("id_sample").ToString)
            code_list_drawer.Add(data.Rows(i)("id_wh_drawer").ToString)
            id_pl_sample_del_det_list.Add(data.Rows(i)("id_pl_sample_del_det").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub
    'Gridcontrol Detail EVENT
    'Press Key On Grid Control Detail
    Private Sub GCDetail_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If id_report_status = "1" Or id_report_status = "2" Then
            If e.KeyCode = Keys.Escape Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
            ElseIf e.KeyCode = Keys.F5 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                newRows()
            ElseIf e.KeyCode = Keys.F6 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
             MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
                deleteRows()
            End If
        End If
    End Sub
    'Code Editing & check
    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'Dim i As Integer = sender.FocusedRowHandle
        'If e.Column.FieldName = "code_full" Then
        '    Dim test As String = sender.GetRowCellValue(i, "code_full").ToString
        '    'Try
        '    Dim query As String = "CALL view_pl_sample_del_criteria('" + test + "')"
        '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '    Dim ix As Integer = data.Rows.Count - 1
        '    While (ix >= 0)
        '        If code_list.Contains(data.Rows(ix)("id_sample_unique").ToString) Then
        '            data.Rows.RemoveAt(ix)
        '        End If
        '        ix = ix - 1
        '    End While
        '    If data.Rows.Count > 0 Then 'Code Found
        '        If code_list.Contains(data.Rows("0")("id_sample_unique").ToString) Then
        '            DevExpress.XtraEditors.XtraMessageBox.Show("Code : " + test + ", already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            deleteRows()
        '            'newRows()
        '        Else
        '            Dim id_sample_unique As String = data.Rows("0")("id_sample_unique").ToString
        '            Dim id_pl_sample_del_det As String = "0"
        '            Dim id_storage_sample As String = data.Rows("0")("id_storage_sample").ToString
        '            Dim namex As String = data.Rows("0")("name").ToString
        '            Dim uom As String = data.Rows("0")("uom").ToString
        '            Dim id_pl_sample_del As String = "0"
        '            Dim size As String = data.Rows("0")("size").ToString

        '            If id_pl_sample_del_det = "0" Then 'Baris Baru
        '                code_list.Add(data.Rows("0")("id_sample_unique").ToString)
        '                GVDetail.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det)
        '                GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
        '                GVDetail.SetFocusedRowCellValue("id_storage_sample", id_storage_sample)
        '                GVDetail.SetFocusedRowCellValue("name", namex)
        '                GVDetail.SetFocusedRowCellValue("uom", uom)
        '                GVDetail.SetFocusedRowCellValue("id_pl_sample_del", id_pl_sample_del)
        '                GVDetail.SetFocusedRowCellValue("size", size)
        '                'noEdit()
        '            End If
        '        End If
        '    Else 'Code Not Found
        '        DevExpress.XtraEditors.XtraMessageBox.Show("Product sample not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        deleteRows()
        '        'newRows()
        '    End If
        '    'Catch ex As Exception
        '    'errorCustom(ex.ToString)
        '    'End Try
        'End If
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDrawer.FocusedColumn = GVDrawer.VisibleColumns(0)
        GVDrawer.ShowEditor()
    End Sub
    Sub newRows()
        GVDrawer.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
        cantEdit()
    End Sub
    Sub cantEdit()
      
    End Sub

    
    Private Sub FormViewSamplePLDel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    'Color Cell
    Public Sub test_aw(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("A")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        id_sample_requisition_det_style = GVDetail.GetFocusedRowCellValue("id_sample_requisition_det").ToString
        Dim id_sample_requisition_det_check As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_sample_requisition_det"))
        If id_sample_requisition_det_check = id_sample_requisition_det_style Then
            e.Appearance.BackColor = Color.SpringGreen
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub

    Public Sub test_aw_wht(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("A")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White
    End Sub

    Private Sub RepositoryItemSpinEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_limit As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", "0")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub getAmountReq(ByVal id_sample_requisition_det As String, ByVal is_sum_req As Boolean)
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                'MsgBox(id_sample_requisition_det)
                Dim qty As Decimal = Decimal.Parse(GVDrawer.GetRowCellValue(i, "pl_sample_del_det_qty").ToString)
                Dim id_sample_requisition_det_data As String = GVDrawer.GetRowCellValue(i, "id_sample_requisition_det").ToString
                If id_sample_requisition_det_data = id_sample_requisition_det Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_sample_requisition_det", id_sample_requisition_det)
        If Not is_sum_req Then
            'MsgBox(qty_sum.ToString("N2"))
            GVDetail.SetFocusedRowCellValue("qty_real_sample_wh", qty_sum)
        Else
            'MsgBox(qty_sum.ToString("N2"))
            Dim qty_requisition As Decimal = Decimal.Parse(GVDetail.GetFocusedRowCellDisplayText("sample_requisition_det_qty").ToString)
            Dim tot As Decimal = qty_requisition + qty_sum
            GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_sum)
            GVDetail.SetFocusedRowCellValue("sample_requisition_det_qty", tot)
        End If
    End Sub

    Private Sub SPDuration_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDuration.EditValueChanged
        DEPLReturn.Text = view_date(Integer.Parse(SPDuration.EditValue))
    End Sub

    Private Sub GVDrawer_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        cantEdit()
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub GVDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDetail.RowClick
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub


    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_sample_requisition_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "SELECT (a.sample_requisition_det_qty - IFNULL(SUM(IF(pl.id_report_status='5',0,b.pl_sample_del_det_qty)), 0) ) AS allow_sum "
        query_check += "FROM tb_sample_requisition_det a "
        query_check += "LEFT JOIN tb_pl_sample_del_det b ON a.id_sample_requisition_det = b.id_sample_requisition_det "
        query_check += "LEFT JOIN tb_pl_sample_del pl ON pl.id_pl_sample_del = b.id_pl_sample_del "
        If action = "upd" Then
            query_check += "AND b.id_pl_sample_del !='" + id_pl_sample_del + "' "
        End If
        query_check += "WHERE a.id_sample_requisition_det = '" + id_sample_requisition_det_cek + "'  "
        query_check += "GROUP BY a.id_sample_requisition "
        allow_sum = Decimal.Parse(execute_query(query_check, 0, True, "", "", "", ""))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoSrs()
        Cursor = Cursors.WaitCursor
        FormInfoSRS.id_sample_requisition = id_sample_requisition
        FormInfoSRS.LabelSubTitle.Text = "SRS No : " + TxtSRSNumber.Text + ""
        FormInfoSRS.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
      
    End Sub


    Sub noEdit()
     
    End Sub

    Sub newRowsBc()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
      
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        
    End Sub

   

    Sub allowDelete()
     
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_sample_del
        FormReportMark.report_mark_type = "10"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

End Class