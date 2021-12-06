Public Class FormRetExosDet
    Public action As String
    Public id As String = "-1"
    Public id_store As String = "-1"
    Public id_report_status As String
    Dim date_start As Date
    Dim lead_time_ro As String = "0"
    Public dt As DataTable
    Dim rmt As String = "363"

    Private Sub FormRetExosDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOrderType()
        view_clasification()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewOrderType()
        Dim query As String = "SELECT ot.id_order_type, ot.order_type, ot.description
        FROM tb_lookup_order_type ot
        WHERE ot.type=1
        ORDER BY ot.id_order_type ASC "
        viewLookupQuery(LEOrderType, query, 0, "order_type", "id_order_type")
    End Sub

    Sub view_clasification()
        Dim qry As String = "SELECT * FROM tb_lookup_return_clasification WHERE 1=1 "
        If action = "ins" Then
            qry += "AND is_reguler=1 "
        End If
        viewSearchLookupQuery(SLUEClasification, qry, "id_return_clasification", "return_clasification", "id_return_clasification")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            lead_time_ro = get_setup_field("lead_time_ro")
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`, DATE_ADD(NOW(),INTERVAL " + lead_time_ro + " DAY) AS `tgl_ret`, DATE_ADD(NOW(),INTERVAL 1 MONTH) AS `tgl_del` ", -1, True, "", "", "", "")
            DERetDueDate.EditValue = data.Rows(0)("tgl_ret")
            DEDelDate.EditValue = data.Rows(0)("tgl_del")
            SLUEClasification.EditValue = "1"
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactTo.Enabled = False
            BMark.Enabled = True

            'query view based on edit id's
            Dim r As New ClassRetExos()
            Dim query As String = r.queryMain("AND r.id_ret_exos='" + id + "'", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store = data.Rows(0)("id_store").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_acc").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store").ToString
            DEForm.EditValue = data.Rows(0)("created_date")
            TxtSalesOrderNumber.Text = data.Rows(0)("number").ToString
            MENote.Text = data.Rows(0)("note").ToString
            DERetDueDate.EditValue = data.Rows(0)("return_est_date")
            DEDelDate.EditValue = data.Rows(0)("return_del_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            SLUEClasification.EditValue = data.Rows(0)("id_return_clasification")
            If data.Rows(0)("id_order_type").ToString = "0" Then
                LEOrderType.EditValue = Nothing
            Else
                LEOrderType.ItemIndex = LEOrderType.Properties.GetDataSourceRowIndex("id_order_type", data.Rows(0)("id_order_type").ToString)
            End If


            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Private Sub FormRetExosDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_ret_exos('" + id + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        LEOrderType.Enabled = False
        If check_edit_report_status(id_report_status, rmt, id) Then
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            DERetDueDate.Enabled = False
            DEDelDate.Enabled = True
            TxtCodeCompTo.Properties.ReadOnly = True
        Else
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            DERetDueDate.Enabled = False
            DEDelDate.Enabled = False
            TxtCodeCompTo.Properties.ReadOnly = True
        End If
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "96"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel data changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormRetExosItemList.id_comp = id_store
        FormRetExosItemList.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class