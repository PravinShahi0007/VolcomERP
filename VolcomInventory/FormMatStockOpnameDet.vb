Public Class FormMatStockOpnameDet 
    Public id_mat_so As String = "-1"
    Public id_comp_contact As String = "-1"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
    Public id_report_status As String = "1"
    Dim datax As DataTable
    Private Sub FormMatStockOpnameDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        actionLoad()
    End Sub
    Sub actionLoad()
        If id_mat_so = "-1" Then
            id_report_status = "1"
            TESoNumber.Text = header_number_mat("15")
            PCDet.Enabled = False
            GCMatSO.Enabled = False
            BSave.Text = "Prepare"
            TEDate.Text = view_date(0)
            TELastUpd.Text = view_date(0)
            BSave.Visible = True
        Else
            Dim query As String = "SELECT a.id_mat_so,a.id_comp_contact,a.mat_so_number,a.id_report_status,DATE_FORMAT(a.mat_so_date_created,'%Y-%m-%d') AS mat_so_date_created,DATE_FORMAT(a.mat_so_last_update,'%Y-%m-%d') AS mat_so_last_update,b.report_status,a.id_lock FROM tb_mat_so a INNER JOIN tb_lookup_report_status b ON b.id_report_status=a.id_report_status WHERE a.id_mat_so='" & id_mat_so & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TESoNumber.Text = data.Rows(0)("mat_so_number").ToString
            TEDate.Text = view_date_from(data.Rows(0)("mat_so_date_created").ToString, 0)
            TELastUpd.Text = view_date_from(data.Rows(0)("mat_so_last_update").ToString, 0)

            id_report_status = data.Rows(0)("id_report_status").ToString

            id_comp_contact = data.Rows(0)("id_comp_contact").ToString
            TESourceName.Text = get_company_x(get_id_company(id_comp_contact), "1")
            TESourceCode.Text = get_company_x(get_id_company(id_comp_contact), "2")
            MESourceAddress.Text = get_company_x(get_id_company(id_comp_contact), "3")

            id_report_status = data.Rows(0)("id_report_status").ToString

            BSave.Visible = True
            BSave.Text = "Lock"

            BpickSource.Enabled = False
            PCDet.Enabled = True
            GCMatSO.Enabled = True

            If data.Rows(0)("id_lock").ToString = "2" Then
                BSave.Visible = False
                PCDet.Visible = False
            End If
        End If
        allow_status()
        view_inventory_mat()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "52", id_mat_so) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            BDel.Enabled = True
            BSave.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            BDel.Enabled = False
            BSave.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BPrint.Visible = True
        Else
            BPrint.Visible = False
        End If
    End Sub

    Sub view_inventory_mat()
        Try
            If Not id_mat_so = "-1" Then
                Dim queryx As String = "SELECT m_so_d.id_mat_so_det,m_so_d.mat_so_det_qty,m_so_d.mat_so_det_note,m_so_d.id_mat_det,m_so_d.id_pl_category,l_pl_cat.pl_category FROM tb_mat_so_det m_so_d INNER JOIN tb_lookup_pl_category l_pl_cat ON m_so_d.id_pl_category=l_pl_cat.id_pl_category WHERE m_so_d.id_mat_so='" & id_mat_so & "'"
                datax = execute_query(queryx, -1, True, "", "", "", "")
                GCMatSO.DataSource = datax
            End If

            Dim query As String
            query = "CALL view_stock_mat_so('" & id_mat_so & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatList.DataSource = data
            If data.Rows.Count > 0 Then
                If Not id_mat_so = "-1" Then
                    GVMatList.FocusedRowHandle = 0
                    view_so(GVMatList.GetFocusedRowCellValue("id_mat_det").ToString)
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        If System.IO.File.Exists(material_image_path & GVMatList.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PictureEdit1.LoadAsync(material_image_path & GVMatList.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub
    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        view_inventory_mat()
    End Sub

    Private Sub GVMatList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatList.FocusedRowChanged
        If GVMatList.RowCount > 0 Then
            view_image()
            If Not id_mat_so = "-1" Then 'new
                view_so(GVMatList.GetFocusedRowCellValue("id_mat_det").ToString)
            End If
        End If
    End Sub
    Sub view_so(ByVal id_mat_det)
        Dim data_filter As DataRow() = datax.Select("[id_mat_det] ='" & id_mat_det & "'")
        Dim x As DataTable
        x = datax.Copy
        x.Clear()
        For Each datarowx As DataRow In data_filter
            x.ImportRow(datarowx)
        Next

        GCMatSO.DataSource = x.DefaultView
        check_but()
    End Sub
    Private Sub GVMatList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVMatSO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_mat_so = "-1" Then 'prepare
            If id_comp_contact = "-1" Then
                stopCustom("Please choose stock opname source.")
            Else
                Dim query As String = "INSERT INTO tb_mat_so(mat_so_number,mat_so_date_created,mat_so_last_update,id_comp_contact) VALUES('" & addSlashes(TESoNumber.Text) & "',NOW(),NOW(),'" & id_comp_contact & "');SELECT LAST_INSERT_ID(); "
                id_mat_so = execute_query(query, 0, True, "", "", "", "")

                infoCustom("Stock Opname prepared.")

                increase_inc_mat("15")

                actionLoad()
                FormMatStockOpname.view_so()
                FormMatStockOpname.GVMatPR.FocusedRowHandle = find_row(FormMatStockOpname.GVMatPR, "id_mat_so", id_mat_so)
            End If
        Else 'save
            Dim confirm As DialogResult
            Dim id_comp As String = get_id_company(id_comp_contact)
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save and lock this stock opname ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "UPDATE tb_mat_so SET mat_so_last_update=NOW(),id_lock='2' WHERE id_mat_so='" & id_mat_so & "'"
                execute_non_query(query, True, "", "", "", "")
                'update summary
                query = "CALL generate_sum_mat_so('" & id_mat_so & "','" & id_comp & "')"
                execute_non_query(query, True, "", "", "", "")
                '
                insert_who_prepared("52", id_mat_so, id_user)

                Close()
                FormMatStockOpname.view_so()
                FormMatStockOpname.GVMatPR.FocusedRowHandle = find_row(FormMatStockOpname.GVMatPR, "id_mat_so", id_mat_so)
            End If
        End If
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormMatStockOpnameDetQty.id_mat_so = id_mat_so
        FormMatStockOpnameDetQty.id_mat_det = GVMatList.GetFocusedRowCellValue("id_mat_det").ToString
        FormMatStockOpnameDetQty.TEDesc.Text = GVMatList.GetFocusedRowCellValue("mat_det_name").ToString
        FormMatStockOpnameDetQty.TECode.Text = GVMatList.GetFocusedRowCellValue("mat_det_code").ToString
        FormMatStockOpnameDetQty.TESize.Text = GVMatList.GetFocusedRowCellValue("size").ToString
        FormMatStockOpnameDetQty.TEColor.Text = GVMatList.GetFocusedRowCellValue("color").ToString
        FormMatStockOpnameDetQty.TECategory.Text = GVMatList.GetFocusedRowCellValue("mat_cat").ToString
        FormMatStockOpnameDetQty.TELot.Text = GVMatList.GetFocusedRowCellValue("lot").ToString
        FormMatStockOpnameDetQty.TEUOM.Text = GVMatList.GetFocusedRowCellValue("uom").ToString
        FormMatStockOpnameDetQty.ShowDialog()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        FormMatStockOpnameDetQty.id_mat_so = id_mat_so
        FormMatStockOpnameDetQty.id_mat_so_det = GVMatSO.GetFocusedRowCellValue("id_mat_so_det").ToString 'edit
        FormMatStockOpnameDetQty.id_mat_det = GVMatList.GetFocusedRowCellValue("id_mat_det").ToString
        FormMatStockOpnameDetQty.TEDesc.Text = GVMatList.GetFocusedRowCellValue("mat_det_name").ToString
        FormMatStockOpnameDetQty.TECode.Text = GVMatList.GetFocusedRowCellValue("mat_det_code").ToString
        FormMatStockOpnameDetQty.TESize.Text = GVMatList.GetFocusedRowCellValue("size").ToString
        FormMatStockOpnameDetQty.TEColor.Text = GVMatList.GetFocusedRowCellValue("color").ToString
        FormMatStockOpnameDetQty.TECategory.Text = GVMatList.GetFocusedRowCellValue("mat_cat").ToString
        FormMatStockOpnameDetQty.TELot.Text = GVMatList.GetFocusedRowCellValue("lot").ToString
        FormMatStockOpnameDetQty.TEUOM.Text = GVMatList.GetFocusedRowCellValue("uom").ToString
        FormMatStockOpnameDetQty.ShowDialog()
    End Sub

    Sub check_but()
        If GVMatSO.RowCount > 0 Then
            BEdit.Visible = True
            BDel.Visible = True
        Else
            BEdit.Visible = False
            BDel.Visible = False
        End If
    End Sub

    Private Sub FormMatStockOpnameDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancel.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BpickSource.Click
        FormPopUpContact.id_pop_up = "45"
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_so
        FormReportMark.report_mark_type = "52"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatStockOpnameSum.id_mat_so = id_mat_so
        Dim Report As New ReportMatStockOpnameSum()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class