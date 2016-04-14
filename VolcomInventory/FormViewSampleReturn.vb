Public Class FormViewSampleReturn 
    Public id_sample_return As String = "-1"
    Public id_comp_contact_from As String
    Public id_comp_contact_to As String
    Public action As String
    Public id_report_status As String
    Public id_comp_to As String
    Public id_pl_sample_del As String = "-1"
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    'Public code_list, code_list_drawer As New List(Of String)

    'Form
    Private Sub FormViewSampleReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewComp()
        actionLoad()
    End Sub
    Private Sub FormViewSampleReturn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

   

    'View Data
    Sub viewDump()
        Dim query As String = "CALL view_pl_sample_del('" + id_pl_sample_del + "', '2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDump.DataSource = data
        For i As Integer = 0 To (data.Rows.Count - 1)
            If action = "upd" Then
                getAmountReq(data.Rows(i)("id_sample").ToString, False)
            End If
        Next
    End Sub

    'View Company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "WHERE a.id_departement = '" + id_departement_user + "' "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetailBC()
    End Sub

    Sub actionLoad()
        GVRetDetail.OptionsBehavior.AutoExpandAllGroups = True
        'BtnBrowseContactFrom.Enabled = False
        GridColumnQtyRemaining.Visible = False

        'Fetch from db main
        Dim query As String = "SELECT a.id_wh_drawer,rck.id_wh_rack, loc.id_wh_locator, a.id_pl_sample_del, g.pl_sample_del_number, h.id_user, a.id_sample_return, a.id_comp_contact_from , a.id_comp_contact_to,a.sample_return_date, DATE_FORMAT(a.sample_return_date,'%Y-%m-%d') as sample_return_datex,a.sample_return_note, a.sample_return_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, cod_det.code_detail_name as division "
        query += "FROM tb_sample_return a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp  "
        query += "INNER JOIN tb_pl_sample_del g ON a.id_pl_sample_del = g.id_pl_sample_del "
        query += "INNER JOIN tb_sample_requisition h ON h.id_sample_requisition = g.id_sample_requisition "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=h.id_division "
        query += "WHERE a.id_sample_return = '" + id_sample_return + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'tampung ke form
        TEDivision.Text = data.Rows(0)("division").ToString
        id_pl_sample_del = data.Rows(0)("id_pl_sample_del").ToString
        TxtPLSampleDelNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
        TxtCodeUserFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 2)
        TxtNameUserFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        TxtCodeDeptFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 5)
        TxtNameDeptFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 4)
        TxtRetNumber.Text = data.Rows(0)("sample_return_number").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        'id_comp_from = data.Rows(0)("id_comp_from").ToString
        'TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
        'TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString

        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        'Dim start_date_arr() As String = data.Rows(0)("sample_return_date").ToString.Split(" ")
        'Dim tgl_format As Date = start_date_arr(0)
        DERet.Text = view_date_from(data.Rows(0)("sample_return_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sample_return_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        'Group Control
        GroupControlRet.Enabled = True

        'based on sttatus
        id_report_status = data.Rows(0)("id_report_status").ToString

        'comp
        SLEStorage.EditValue = data.Rows(0)("id_comp_to").ToString
        SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
        SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
        SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString


        'Fetch db detail
        viewDetailBC()
        allowDelete()
        viewDetailReturn()
        allow_status()
    End Sub

    Sub allow_status()
        BMark.Enabled = True
        BtnBrowseContactTo.Enabled = False
        GVRetDetail.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        SLEStorage.Enabled = False
        SLELocator.Enabled = False
        SLERack.Enabled = False
        SLEDrawer.Enabled = False
    End Sub
    Sub viewDetailReturn()
        'UPDATED 17 NOVEMBER 2014
        Dim query As String = ""
        query += "CALL view_sample_return('" + id_sample_return + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        viewDump()
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
        cantEdit()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_return
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "14"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub


    Sub isAllowPL(ByVal id_sample As String, ByVal sample_name As String, ByVal id_pl_sample_del_cek As String, ByVal qty_plx As String)
       
    End Sub

    Sub infoPL()
        Cursor = Cursors.WaitCursor
        FormInfoPLSampleDel.id_pl_sample_del = id_pl_sample_del
        FormInfoPLSampleDel.LabelSubTitle.Text = "PL Sample Delivery No : " + TxtPLSampleDelNumber.Text + ""
        FormInfoPLSampleDel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub getAmountReq(ByVal id_sample As String, ByVal is_sum_req As Boolean)
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Try
                'MsgBox(id_sample_requisition_det)
                Dim qty As Decimal = Decimal.Parse(GVRetDetail.GetRowCellValue(i, "sample_return_det_qty").ToString)
                Dim id_sample_data As String = GVRetDetail.GetRowCellValue(i, "id_sample").ToString
                If id_sample_data = id_sample Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDump.FocusedRowHandle = find_row(GVDump, "id_sample", id_sample)
        If Not is_sum_req Then
            'MsgBox(qty_sum.ToString("N2"))
            GVDump.SetFocusedRowCellValue("qty_real_sample", qty_sum.ToString("N2"))
        Else
            ''MsgBox(qty_sum.ToString("N2"))
            'Dim qty_requisition As Decimal = Decimal.Parse(GVDump.GetFocusedRowCellDisplayText("sample_requisition_det_qty").ToString)
            'Dim tot As Decimal = qty_requisition + qty_sum
            'GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_sum.ToString("N2"))
            'GVDetail.SetFocusedRowCellValue("sample_requisition_det_qty", tot.ToString("N2"))
        End If
    End Sub

    Sub cantEdit()
       
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub GVRetDetail_RowCountChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.RowCountChanged

    End Sub

    Private Sub GVRetDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRetDetail.RowClick
        cantEdit()
    End Sub

    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        Dim id_comp As String = ""
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
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    

    Sub allowDelete()
        
    End Sub
End Class