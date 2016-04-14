Public Class FormPopUpPurchaseMat
    Public id_pop_up As String = "-1"
    Public id_purc As String = "-1"
    '1 = Mat Purchase Receive
    '2 = Mat Return Out
    '3 = PR Purchase Mat

    Private Sub FormPopUpPurchaseMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_purc()
        If id_purc <> "-1" Then
            GVMatPurchase.FocusedRowHandle = find_row(GVMatPurchase, "id_mat_purc", id_purc)
        End If
    End Sub
    Sub view_sample_purc()
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_mat_purc, "
        query += "b.id_season,a.id_delivery,i.delivery, "
        query += "b.season, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_purc_number,"
        query += "DATE_FORMAT(a.mat_purc_date,'%d %M %Y') AS mat_purc_date, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_purc_date,INTERVAL a.mat_purc_lead_time DAY),'%d %M %Y') AS mat_purc_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_purc_date,INTERVAL (a.mat_purc_top+a.mat_purc_lead_time) DAY),'%d %M %Y') AS mat_purc_top "
        query += "FROM tb_mat_purc a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season b ON i.id_season = b.id_season "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        If id_pop_up = "5" Then 'revised
            query += "WHERE a.id_report_status = '5' "
        Else
            query += "WHERE a.id_report_status >= '3' AND a.id_report_status != '5' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            'show all
            BSave.Enabled = True
            view_list_purchase(GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_list_purchase(ByVal id_mat_purc As String)
        Dim query = "CALL view_purc_mat_det_limit('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then
            FormMatRecPurcDet.id_order = GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString
            '
            Dim query As String = String.Format("SELECT mat_purc_kurs,id_report_status,mat_purc_vat,id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(mat_purc_date,'%Y-%m-%d') as mat_purc_datex,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note FROM tb_mat_purc WHERE id_mat_purc = '{0}'", GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormMatRecPurcDet.TEPONumber.Text = data.Rows(0)("mat_purc_number").ToString
                FormMatRecPurcDet.id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
                FormMatRecPurcDet.TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")

                FormMatRecPurcDet.id_comp_to = data.Rows(0)("id_comp_contact_ship_to").ToString
                FormMatRecPurcDet.TECompShipToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")
                '
                date_created = data.Rows(0)("mat_purc_datex").ToString
                FormMatRecPurcDet.TEOrderDate.Text = view_date_from(date_created, 0)
                FormMatRecPurcDet.TEEstRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString))

                FormMatRecPurcDet.GConListPurchase.Enabled = True
                FormMatRecPurcDet.view_list_purchase()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "2" Then
            FormMatRetOutDet.id_mat_purc = GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc").ToString

            Dim query As String = String.Format("SELECT mat_purc_kurs,id_report_status,mat_purc_vat,id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(mat_purc_date,'%Y-%m-%d') as mat_purc_datex,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note FROM tb_mat_purc WHERE id_mat_purc = '{0}'", GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormMatRetOutDet.id_comp_contact_from = data.Rows(0)("id_comp_contact_ship_to").ToString
                FormMatRetOutDet.TxtNameCompFrom.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")
                FormMatRetOutDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "2")
                '
                FormMatRetOutDet.TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
                FormMatRetOutDet.id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                FormMatRetOutDet.TxtNameCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
                FormMatRetOutDet.TxtCodeCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "2")
                FormMatRetOutDet.MEAdrressCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")
                FormMatRetOutDet.GroupControlRet.Enabled = True
                FormMatRetOutDet.viewDetailReturn()
                FormMatRetOutDet.deleteRows()
                FormMatRetOutDet.id_mat_purc_det_list.Clear()
                FormMatRetOutDet.id_mat_det_list.Clear()
                For i As Integer = 0 To GVListPurchase.RowCount - 1
                    FormMatRetOutDet.id_mat_det_list.Add(GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString)
                Next
                FormMatRetOutDet.check_but()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "3" Then
            FormMatPRDet.id_purc = GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString
            FormMatPRDet.view_po()
            FormMatPRDet.view_list_purchase()
            FormMatPRDet.GConListPurchase.Enabled = True
            FormMatPRDet.id_rec = "-1"
            FormMatPRDet.TERecNumber.Text = ""
            Close()
        ElseIf id_pop_up = "4" Then
            FormMatRetInDet.id_mat_purc = GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc").ToString

            Dim query As String = String.Format("SELECT mat_purc_kurs,id_report_status,mat_purc_vat,id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(mat_purc_date,'%Y-%m-%d') as mat_purc_datex,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note FROM tb_mat_purc WHERE id_mat_purc = '{0}'", GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormMatRetInDet.TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
                FormMatRetInDet.id_comp_contact_from = data.Rows(0)("id_comp_contact_to").ToString
                FormMatRetInDet.TxtNameCompFrom.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
                FormMatRetInDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "2")
                '
                FormMatRetInDet.id_comp_contact_to = data.Rows(0)("id_comp_contact_ship_to").ToString
                FormMatRetInDet.TxtNameCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")
                FormMatRetInDet.TxtCodeCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "2")
                FormMatRetInDet.MEAdrressCompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "3")
                '
                FormMatRetInDet.GroupControlRet.Enabled = True
                FormMatRetInDet.viewDetailReturn()
                FormMatRetInDet.deleteRows()
                FormMatRetInDet.id_mat_purc_det_list.Clear()
                FormMatRetInDet.check_but()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "5" Then
            FormMatPurchaseDet.id_rev = GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString
            FormMatPurchaseDet.TEPORevNumber.Text = GVMatPurchase.GetFocusedRowCellValue("mat_purc_number").ToString
            'load or not
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to load old purchase?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                FormMatPurchaseDet.action_load_sub(GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
            End If
            '
            Close()
        End If
    End Sub
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpPurchaseMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVMatPurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPurchase.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
    Private Sub GVMatPurchase_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPurchase.RowClick
        view_list_purchase(GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub
End Class