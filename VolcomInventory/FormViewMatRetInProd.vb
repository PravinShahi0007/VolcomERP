Public Class FormViewMatRetInProd 
    Public id_mat_prod_ret_in As String = ""
    Public id_prod_order As String = ""
    Public id_prod_order_wo As String = ""
    Public id_comp_contact_from As String = ""
    Dim date_start As Date
    Public id_report_status As String = ""
    Private Sub FormViewMatRetInProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewComp()
        'Enable/Disable
        GroupControlRet.Enabled = True

        'View data
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_prod_ret_in,b.id_prod_order_wo,h.id_prod_order, a.mat_prod_ret_in_date, a.mat_prod_ret_in_note,h.prod_order_number,b.prod_order_wo_number,desg.design_name,e.comp_name,e.comp_number,e.address_primary,a.id_comp_contact_from, "
            query += "a.mat_prod_ret_in_number  "
            query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
            query += "FROM tb_mat_prod_ret_in a "
            query += "INNER JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
            query += "INNER JOIN tb_prod_order h ON b.id_prod_order = h.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = h.id_prod_demand_design "
            query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
            query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
            query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
            query += "WHERE a.id_mat_prod_ret_in = '" & id_mat_prod_ret_in & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Try
                SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
            Catch ex As Exception
            End Try

            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_prod_order_wo = data.Rows(0)("id_prod_order_wo").ToString
            TEWONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEPONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
            TEDesign.Text = data.Rows(0)("design_name").ToString
            Dim start_date_arr() As String = data.Rows(0)("mat_prod_ret_in_date").ToString.Split(" ")
            DERet.Text = start_date_arr(0).ToString
            TxtRetOutNumber.Text = data.Rows(0)("mat_prod_ret_in_number").ToString
            MENote.Text = data.Rows(0)("mat_prod_ret_in_note").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            'Constraint Status
        Catch ex As Exception
            errorConnection()
        End Try
        viewDetailReturn()
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
    Sub viewDetailReturn()
        Dim query As String = "CALL view_mat_prod_ret('" + id_mat_prod_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_prod_ret_in
        FormReportMark.report_mark_type = "47"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub
    Private Sub FormMatRetInDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_prod_ret_in
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "47"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class