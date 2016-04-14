Public Class FormProductionWOProgress
    Public id_wo As String = "-1"
    Public id_ovh_price As String = "-1"
    Public id_po As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public date_created As String = ""
    Public id_design As String = "-1"

    Private Sub FormProductionWOProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_po(id_po)
        '
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_payment, "
        query += "a.id_prod_order,g.payment,b.id_currency,a.prod_order_wo_note, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to,a.id_comp_contact_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_del_date,DATE_FORMAT(a.prod_order_wo_del_date,'%Y-%m-%d') as prod_order_wo_del_datex, "
        query += "DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex,a.prod_order_wo_lead_time,a.prod_order_wo_top,a.prod_order_wo_vat "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "WHERE a.id_prod_order_wo='" & id_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        id_ovh_price = data.Rows(0)("id_ovh_price").ToString
        LWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
        LWOType.Text = data.Rows(0)("overhead").ToString()
        date_created = data.Rows(0)("prod_order_wo_del_datex").ToString
        LDateDel.Text = view_date_from(date_created, 0)
        date_created = data.Rows(0)("prod_order_wo_datex").ToString
        LLeadTime.Text = data.Rows(0)("prod_order_wo_lead_time").ToString
        LestDateRec.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString))
        '
        query = "SELECT a.id_currency, a.ovh_price, b.overhead as name, b.overhead_code as code,a.id_comp_contact from tb_m_ovh_price a INNER JOIN tb_m_ovh b WHERE a.id_ovh_price='" & id_ovh_price & "'"
        data = execute_query(query, -1, True, "", "", "", "")
        LVendor.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        '
        view_wo()
        view_progress()
        '
    End Sub
    Sub progres_bar(ByVal bar As Decimal)
        PBCWO.Properties.Step = 1
        PBCWO.Properties.ShowTitle = True
        PBCWO.Properties.PercentView = True
        PBCWO.Properties.Minimum = 0
        PBCWO.Properties.Maximum = 10000
        PBCWO.EditValue = bar * 100
        PBCWO.Update()
    End Sub
    Sub view_progress()
        Dim query = "SELECT id_prod_order_wo_prog,prod_order_wo_prog_note,prod_order_wo_prog_percent,DATE_FORMAT(prod_order_wo_prog_date,'%d %M %Y') AS prod_order_wo_prog_date FROM tb_prod_order_wo_prog WHERE id_prod_order_wo='" & id_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNote.DataSource = data
        If data.Rows.Count > 0 Then
            BEdit.Visible = True
            BDelete.Visible = True

            query = String.Format("SELECT MAX(prod_order_wo_prog_percent) as prod_order_wo_prog_percent FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = '{0}'", id_wo)
            data = execute_query(query, -1, True, "", "", "", "")
            progres_bar(Decimal.Parse(data.Rows(0)("prod_order_wo_prog_percent").ToString))
        Else
            BEdit.Visible = False
            BDelete.Visible = False
        End If
    End Sub
    Sub view_wo()
        Dim query = "CALL view_prod_order_wo_det('" & id_wo & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSizeQty.DataSource = data
    End Sub
    Sub load_po(ByVal id_po As String)
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_po)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString
        LDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
        id_design = get_prod_demand_design_x(id_prod_demand_design, "3").ToString
        pre_viewImages("2", PEPic, id_design, False)
        LPONumber.Text = data.Rows(0)("prod_order_number").ToString
    End Sub

    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            pre_viewImages("2", PEPic, id_design, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormProductionWOProgress_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BProgress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BProgress.Click
        Close()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormProductionWOProgressDet.id_wo = id_wo
        FormProductionWOProgressDet.ShowDialog()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        FormProductionWOProgressDet.id_wo = id_wo
        FormProductionWOProgressDet.id_wo_prog = GVNote.GetFocusedRowCellValue("id_prod_order_wo_prog").ToString
        FormProductionWOProgressDet.ShowDialog()
    End Sub

    Private Sub GVNote_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNote.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this progress?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_wo_prog As String = GVNote.GetFocusedRowCellDisplayText("id_prod_order_wo_prog").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_prod_order_wo_prog WHERE id_prod_order_wo_prog = '{0}'", id_wo_prog)
                execute_non_query(query, True, "", "", "", "")
                FormProductionDet.view_wo()
                view_progress()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class