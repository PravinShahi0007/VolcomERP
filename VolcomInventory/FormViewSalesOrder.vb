Public Class FormViewSalesOrder 
    Public action As String
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_store As String = "-1"
    Public id_report_status As String
    Public id_sales_order_det_list As New List(Of String)
    Public id_so_type As String = "-1"
    Public id_comp_contact_par As String = "-1"
    Public id_comp_par As String = "-1"
    Dim id_comp_cat_wh As String = "-1"

    Private Sub FormViewSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        viewSeason()
        actionLoad()
    End Sub

    Sub actionLoad()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BMark.Enabled = True

        'query view based on edit id's
        Dim query As String = "SELECT a.id_so_status, a.id_sales_order, a.id_store_contact_to, (d.id_comp) AS id_store,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_warehouse_contact_to, (wh.id_comp) AS id_comp_par,(wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to, a.id_report_status, f.report_status, "
        query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%Y-%m-%d') AS sales_order_datex, a.id_so_type, IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`, ps.id_prepare_status, ps.prepare_status "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status "
        query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
        query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        TxtReff.Text = data.Rows(0)("fg_so_reff_number").ToString

        id_store = data.Rows(0)("id_store").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString

        id_comp_par = data.Rows(0)("id_comp_par").ToString
        id_comp_contact_par = data.Rows(0)("id_warehouse_contact_to").ToString
        TxtWHCodeTo.Text = data.Rows(0)("warehouse_number_to").ToString
        TxtWHNameTo.Text = data.Rows(0)("warehouse_name_to").ToString

        DEForm.Text = view_date_from(data.Rows(0)("sales_order_datex").ToString, 0)
        TxtSalesOrderNumber.Text = data.Rows(0)("sales_order_number").ToString
        MENote.Text = data.Rows(0)("sales_order_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        TxtPackingStatus.Text = data.Rows(0)("prepare_status").ToString
        'detail2
        viewDetail()
        check_but()
        allow_status()
    End Sub

    Sub viewSeason()
      
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewDelivery()
      
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_order('" + id_sales_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

   
    'sub check_but
    Sub check_but()
        
    End Sub

    Sub allow_status()
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False
        LEStatusSO.Enabled = False
        BtnAttachment.Enabled = True
        TxtSalesOrderNumber.Focus()
    End Sub



    Private Sub FormViewSalesOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            viewDelivery()
        Catch ex As Exception

        End Try
    End Sub


 
    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

  
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_order
        FormReportMark.report_mark_type = "39"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_order
        FormDocumentUpload.report_mark_type = "39"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class