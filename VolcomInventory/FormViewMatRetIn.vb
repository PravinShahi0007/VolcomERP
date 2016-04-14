Public Class FormViewMatRetIn
    Public action As String
    Public id_mat_purc_ret_in As String
    Public id_mat_purc As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_mat_purc_det_list, id_mat_purc_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_purc_ret_in
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "19"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub FormViewMatRetIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewComp()
        actionLoad()
    End Sub
    Sub actionLoad()
        Try
            Dim query As String = "SELECT a.id_report_status, a.id_mat_purc, a.id_mat_purc_ret_in, a.mat_purc_ret_in_date, "
            query += "a.mat_purc_ret_in_note, a.mat_purc_ret_in_number,  "
            query += "b.mat_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
            query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
            query += "FROM tb_mat_purc_ret_in a "
            query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
            query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
            query += "WHERE a.id_mat_purc_ret_in='" + id_mat_purc_ret_in + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Try
                SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
            Catch ex As Exception
            End Try

            TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            Dim start_date_arr() As String = data.Rows(0)("mat_purc_ret_in_date").ToString.Split(" ")
            DERet.Text = start_date_arr(0).ToString
            'Dim start_due_date_arr() As String = data.Rows(0)("sample_purc_ret_in_due_date").ToString.Split(" ")
            ' DERetDueDate.Text = start_due_date_arr(0).ToString
            TxtRetOutNumber.Text = data.Rows(0)("mat_purc_ret_in_number").ToString
            MENote.Text = data.Rows(0)("mat_purc_ret_in_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_mat_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_mat_purc = data.Rows(0)("id_mat_purc").ToString

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
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_in_mat('" + id_mat_purc_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_mat_purc_det_list.Add(data.Rows(i)("id_mat_purc_det").ToString)
            'MsgBox(data.Rows(i)("id_sample_purc_det").ToString)
            id_mat_purc_ret_in_det_list.Add(data.Rows(i)("id_mat_purc_ret_in_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub
    Private Sub FormViewMatRetIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_purc_ret_in
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "19"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class