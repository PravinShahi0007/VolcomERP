Public Class FormViewFGSalesOrderReff 
    Public id_fg_so_reff As String = "-1"
    Public id_fg_so_reff_fk As String = "-1"
    Public id_report_status As String = "-1"

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_reff
        FormReportMark.report_mark_type = "75"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_fg_so_reff
        FormDocumentUpload.report_mark_type = "75"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGSalesOrderReffDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewSeason()
        _view_division_fg(LESampleDivision)
        _view_rec_note(LERecNote)
        viewReportStatus()

        actionLoad()
        WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default
    End Sub

    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season_printed_name", "id_season")
    End Sub

    'view del
    Sub viewDel()
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT del.id_delivery, del.delivery FROM tb_season_delivery del WHERE del.id_season = '" + id_season + "' ORDER BY del.delivery ASC "
        viewSearchLookupQuery(SLEDel, query, "id_delivery", "delivery", "id_delivery")
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        Cursor = Cursors.WaitCursor
        viewDel()
        Cursor = Cursors.Default
    End Sub

    'load
    Sub actionLoad()
        BMark.Enabled = True
        Dim query_c As ClassFGSalesOrderReff = New ClassFGSalesOrderReff()
        Dim query As String = query_c.queryMain("AND so.id_fg_so_reff = ''" + id_fg_so_reff + "'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GroupControlList.Enabled = True
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", data.Rows(0)("id_division"))
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        TxtProdDemandNumber.Text = data.Rows(0)("fg_so_reff_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_so_reff_datex").ToString, 0)
        MENote.Text = data.Rows(0)("fg_so_reff_note").ToString
        ButtonEdit1.Text = data.Rows(0)("fg_so_reff_fk_number").ToString
        id_fg_so_reff_fk = data.Rows(0)("id_fg_so_reff_fk").ToString

        viewDetail()
        allow_status()
        check_but()
    End Sub

    Sub viewDetail()
        Dim query_c As ClassDesign = New ClassDesign()
        query_c.loadDS(SLESeason.EditValue.ToString, "3", GCDesign, GVDesign, id_fg_so_reff, "2")
    End Sub

    Sub allow_status()
        'Based on report status
        'MsgBox("Nggak Boleh")
        LESampleDivision.Enabled = False
        LERecNote.Enabled = False
        SLESeason.Enabled = False
        SLEDel.Enabled = False
        MENote.Enabled = False
        ButtonEdit1.Enabled = False
        GVDesign.OptionsBehavior.ReadOnly = True
        BtnAttachment.Enabled = True


    End Sub

    'enable/disable Edit/Delete Detail
    Sub check_but()
   
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Cursor = Cursors.WaitCursor
        check_but()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGSalesOrderReffDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub ButtonEdit1_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        Cursor = Cursors.WaitCursor
        FormPopUpFGSalesOrderReff.id_pop_up = "1"
        FormPopUpFGSalesOrderReff.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormDataReff.id_pop_up = "2"
        FormDataReff.report_mark_type = "74"
        FormDataReff.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class