Public Class FormViewMatRecWO
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim mat_wo_rec_det_qty_inp As Decimal

    Private Sub FormViewMatRecWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim order_created As String
        Dim query = "SELECT a.id_report_status,a.mat_wo_rec_note,b.id_comp_contact_to as id_comp_from,b.id_mat_wo,a.id_comp_contact_to as id_comp_to,g.season,a.id_mat_wo_rec,a.mat_wo_rec_number,DATE_FORMAT(b.mat_wo_date,'%Y-%m-%d') as mat_wo_datex,b.mat_wo_lead_time,a.delivery_order_date,a.delivery_order_number,b.mat_wo_number,DATE_FORMAT(a.mat_wo_rec_date,'%Y-%m-%d') AS mat_wo_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
        query += "FROM tb_mat_wo_rec a INNER JOIN tb_mat_wo b ON a.id_mat_wo=b.id_mat_wo "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery h ON b.id_delivery=h.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=h.id_season "
        query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp WHERE a.id_mat_wo_rec='" & id_receive & "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Try
            SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
            SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
            SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
            SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
        Catch ex As Exception
        End Try

        TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("mat_wo_rec_number").ToString

        id_order = data.Rows(0)("id_mat_wo").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TECompName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TECompShipToName.Text = data.Rows(0)("comp_to").ToString

        order_created = data.Rows(0)("mat_wo_datex").ToString
        TEOrderDate.Text = view_date_from(order_created, 0)
        TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))

        TERecDate.Text = view_date_from(data.Rows(0)("mat_wo_rec_date").ToString, 0)

        Dim tgl_delivery() As String = data.Rows(0)("delivery_order_date").ToString.Split(" ")
        TEDODate.Text = tgl_delivery(0)

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        MENote.Text = data.Rows(0)("mat_wo_rec_note").ToString

        GConListPurchase.Enabled = True

        TERecNumber.Enabled = False
        view_list_rec()
        view_list_pcs()
    End Sub
    Sub view_list_pcs()
        Dim query = "CALL view_wo_rec_mat_pcs('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data
    End Sub
    Sub view_list_rec()
        Dim query = "CALL view_wo_rec_mat_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub FormViewMatRecWO_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_receive
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "17"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    'view company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Locator
    Sub viewLoactor()
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
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_order
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "17"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub GVRoll_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRoll.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class