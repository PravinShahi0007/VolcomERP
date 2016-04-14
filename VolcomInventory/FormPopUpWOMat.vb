Public Class FormPopUpWOMat
    Public id_pop_up As String = "-1"
    Public id_wo As String = "-1"
    '1 = Mat WO Receive
    '2 = Mat WO PR
    '3 = MRS WO
    '4 = Rev WO
    Private Sub FormPopUpWOMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_purc()
        If id_wo <> "-1" Then
            GVMatWO.FocusedRowHandle = find_row(GVMatWO, "id_mat_wo", id_wo)
        End If
    End Sub

    Private Sub FormPopUpWOMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub view_mat_purc()
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_mat_wo, j.overhead, "
        query += "b.id_season,a.id_delivery,i.delivery, "
        query += "b.season, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_wo_number,"
        query += "DATE_FORMAT(a.mat_wo_date,'%d %M %Y') AS mat_wo_date, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_wo_date,INTERVAL a.mat_wo_lead_time DAY),'%d %M %Y') AS mat_wo_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_wo_date,INTERVAL (a.mat_wo_top+a.mat_wo_lead_time) DAY),'%d %M %Y') AS mat_wo_top "
        query += "FROM tb_mat_wo a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season b ON i.id_season = b.id_season "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON j.id_ovh = a.id_ovh "
        If id_pop_up = "4" Then
            query += "WHERE a.id_report_status = '5' "
        Else
            query += "WHERE a.id_report_status >='3' AND a.id_report_status != '5' "
            If id_pop_up = "3" Then
                query += " AND (SELECT COUNT(b.id_pl_mrs) FROM tb_pl_mrs b INNER JOIN tb_prod_order_mrs c ON c.id_prod_order_mrs=b.id_prod_order_mrs WHERE c.id_mat_wo=a.id_mat_wo) = 0"
            End If
        End If
        
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatWO.DataSource = data

        If data.Rows.Count > 0 Then
            'show all
            BSave.Enabled = True
            view_list_wo(GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_list_wo(ByVal id_mat_wo As String)
        Dim query = "CALL view_mat_wo_det('" & id_mat_wo & "')"
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
            FormMatRecWODet.id_order = GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
            '
            Dim query As String = String.Format("SELECT mat_wo_kurs,id_report_status,mat_wo_vat,id_delivery,mat_wo_number,id_comp_contact_to,id_comp_contact_ship_to,id_ovh,id_payment,DATE_FORMAT(mat_wo_date,'%Y-%m-%d') as mat_wo_datex,mat_wo_lead_time,mat_wo_top,id_currency,mat_wo_note FROM tb_mat_wo WHERE id_mat_wo = '{0}'", GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""
            '
            If data.Rows.Count > 0 Then
                FormMatRecWODet.TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString
                FormMatRecWODet.id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
                FormMatRecWODet.TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")

                FormMatRecWODet.id_comp_to = data.Rows(0)("id_comp_contact_ship_to").ToString
                FormMatRecWODet.TECompShipToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")

                date_created = data.Rows(0)("mat_wo_datex").ToString
                FormMatRecWODet.TEOrderDate.Text = view_date_from(date_created, 0)
                FormMatRecWODet.TEEstRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))

                FormMatRecWODet.GConListPurchase.Enabled = True
                FormMatRecWODet.view_list_purchase()
                Close()
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "2" Then
            FormMatPRWODet.id_purc = GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
            FormMatPRWODet.view_po()
            FormMatPRWODet.view_list_purchase()
            FormMatPRWODet.GConListPurchase.Enabled = True
            FormMatPRWODet.id_rec = "-1"
            FormMatPRWODet.TERecNumber.Text = ""
            FormMatPRWODet.TEOVH.Text = GVMatWO.GetFocusedRowCellValue("overhead").ToString
            FormMatPRWODet.allow_rec()
            Close()
        ElseIf id_pop_up = "3" Then 'MRS WO
            '
            Dim query As String = String.Format("SELECT mat_wo_kurs,id_report_status,mat_wo_vat,id_delivery,mat_wo_number,id_comp_contact_to,id_comp_contact_ship_to,id_ovh,id_payment,DATE_FORMAT(mat_wo_date,'%Y-%m-%d') as mat_wo_datex,mat_wo_lead_time,mat_wo_top,id_currency,mat_wo_note FROM tb_mat_wo WHERE id_mat_wo = '{0}'", GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            If data.Rows.Count > 0 Then
                FormMatMRSDet.id_wo = GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
                FormMatMRSDet.TEWONumber.Text = data.Rows(0)("mat_wo_number").ToString

                FormMatMRSDet.id_comp_req_from = data.Rows(0)("id_comp_contact_to").ToString
                FormMatMRSDet.TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
                FormMatMRSDet.TECompCode.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "2")

                FormMatMRSDet.BPickReqFrom.Enabled = False
                FormMatMRSDet.BAddMat.Enabled = False
                FormMatMRSDet.BEditMat.Enabled = False
                FormMatMRSDet.BDelMat.Enabled = False

                FormMatMRSDet.view_list_wo()

                Close()
                '
            Else
                stopCustom("Data is empty.")
            End If
        ElseIf id_pop_up = "4" Then 'Mat WO
            FormMatWODet.id_rev = GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
            FormMatWODet.TEWORevNumber.Text = GVMatWO.GetFocusedRowCellValue("mat_wo_number").ToString
            'load or not
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to load old work order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                FormMatWODet.action_load_rev()
            End If
            '
            Close()
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub
    Private Sub GVMatPurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatWO.FocusedRowChanged
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
        view_list_wo(GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
        view_list_mat_ext(GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
    End Sub
    Sub view_list_mat_ext(ByVal ext As String)
        Dim query = "CALL view_mat_wo_mat('" & ext & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaterial.DataSource = data
    End Sub

    'Private Sub CEShowResultField_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEShowResultField.CheckedChanged
    '    If CEShowResultField.Checked = True Then
    '        Colresult_code.Visible = True
    '        Colresult_code.VisibleIndex = 3
    '        Colresult_name.Visible = True
    '        Colresult_name.VisibleIndex = 4
    '        ColResultSize.Visible = True
    '        ColResultSize.VisibleIndex = 5
    '    Else
    '        Colresult_code.Visible = False
    '        Colresult_name.Visible = False
    '        ColResultSize.Visible = False
    '    End If
    'End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMaterial_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMaterial.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class