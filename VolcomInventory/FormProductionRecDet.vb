﻿Imports Microsoft.Office.Interop
Public Class FormProductionRecDet
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_design As String = "-1"
    Dim sample_purc_rec_det_qty_inp As Decimal
    Dim myList(,) As String
    Dim is_start As Boolean = False
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls As String = get_setup_field("bof_xls_rcvqc")
    Dim total_min As Integer = 0
    Dim total_order As Integer = 0
    Dim total_max As Integer = 0
    Dim total_rec As Integer = 0
    Dim total_rec_normal As Integer = 0
    Dim is_special_rec As String = "-1"
    Dim expired_date As DateTime = Nothing
    Dim is_over_tol As String = "2"
    Dim id_prod_over_memo As String = "NULL"
    Dim qty_limit As Integer = 0

    Private Sub FormProductionRecDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BShowOrder.Focus()
        allowDelete()
        view_report_status(LEReportStatus)
        actionLoad()
    End Sub

    Sub load_cat_rec()
        Dim q As String = "SELECT id_pl_category,pl_category FROM tb_lookup_pl_category"
        viewSearchLookupQuery(SLERecType, q, "id_pl_category", "pl_category", "id_pl_category")
    End Sub

    Sub actionLoad()
        load_cat_rec()

        If id_receive = "-1" Then
            Dim q As String = "SELECT NOW() as date_now"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

            If dt.Rows.Count > 0 Then
                DEArrive.Properties.MaxValue = dt.Rows(0)("date_now")
                TEDODate.Properties.MaxValue = dt.Rows(0)("date_now")
            End If

            If Not id_order = "-1" Then 'from waiting list
                view_list_purchase()
                view_po()
                view_barcode_list()
                GConListPurchase.Enabled = True
                GroupControlListBarcode.Enabled = True
                PEView.Enabled = True
                BShowOrder.Enabled = False
            End If

            'new
            TERecDate.Text = view_date(0)
            TERecNumber.Text = ""

            BShowOrder.Enabled = True
            BPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            sample_purc_rec_det_qty_inp = 0

            'info
            If id_order <> "-1" Then
                BtnInfoSrs.Enabled = True
            Else
                BtnInfoSrs.Enabled = False
            End If

            'own source
            Dim id_qc As String = execute_query("SELECT id_qc_dept FROM tb_opt", 0, True, "", "", "", "")
            Dim query_get_comp_name As String = "SELECT b.comp_number, b.comp_name, CONCAT(b.comp_number,'-', b.comp_name) AS `comp_name_combine` FROM tb_m_comp_contact a "
            query_get_comp_name += "INNER JOIN tb_m_comp b ON a.id_comp = b.id_comp "
            query_get_comp_name += "WHERE a.id_comp_contact = '" + id_qc + "' AND b.id_departement = '" + id_departement_user + "'"
            Try
                Dim data_get_comp_name As DataTable = execute_query(query_get_comp_name, -1, True, "", "", "", "")
                TxtCodeCompTo.Text = data_get_comp_name.Rows(0)("comp_number").ToString
                TECompShipToName.Text = data_get_comp_name.Rows(0)("comp_name").ToString
                id_comp_to = id_qc
            Catch ex As Exception
                TxtCodeCompTo.Text = ""
                TECompShipToName.Text = ""
                id_comp_to = "-1"
            End Try
        Else
            'edit
            BShowOrder.Enabled = False
            BMark.Enabled = True

            Dim order_created As String
            Dim query = "SELECT j.id_design,IF(a.delivery_order_date<>'0000-00-00', 'date_normal','date_null') as del_date_type, i.id_sample, (i.design_display_name) AS `design_name`, a.id_report_status,a.prod_order_rec_note,a.id_comp_contact_from as id_comp_from,b.id_prod_order,a.id_comp_contact_to as id_comp_to,g.season,a.id_prod_order_rec,a.prod_order_rec_number
,DATE_FORMAT(b.prod_order_date,'%Y-%m-%d') as prod_order_datex,b.prod_order_lead_time, a.arrive_date
,a.delivery_order_date,a.delivery_order_number,b.prod_order_number
,DATE_FORMAT(a.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date
, f.comp_name AS comp_from, f.comp_number AS comp_from_number,d.comp_name AS comp_to, d.comp_number AS comp_to_number, i.id_sample, po_type.po_type, a.is_over_tol, a.id_prod_over_memo,a.id_pl_category "
            query += "FROM tb_prod_order_rec a "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
            query += "INNER JOIN tb_season_delivery h ON b.id_delivery=h.id_delivery "
            query += "INNER JOIN tb_season g ON g.id_season=h.id_season "
            query += "INNER JOIN tb_prod_demand_design j ON b.id_prod_demand_design = j.id_prod_demand_design "
            query += "INNER JOIN tb_m_design i ON j.id_design = i.id_design "
            query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
            query += " WHERE a.id_prod_order_rec='" & id_receive & "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
            TERecNumber.Text = data.Rows(0)("prod_order_rec_number").ToString
            TxtPOType.Text = data.Rows(0)("po_type").ToString

            id_order = data.Rows(0)("id_prod_order").ToString
            is_over_tol = data.Rows(0)("is_over_tol").ToString
            id_prod_over_memo = data.Rows(0)("id_prod_over_memo").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_from_number").ToString
            TECompName.Text = data.Rows(0)("comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_to_number").ToString
            TECompShipToName.Text = data.Rows(0)("comp_to").ToString
            id_design = data.Rows(0)("id_design").ToString

            order_created = data.Rows(0)("prod_order_datex").ToString
            TEOrderDate.Text = view_date_from(order_created, 0)
            TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("prod_order_lead_time").ToString))

            TERecDate.Text = view_date_from(data.Rows(0)("prod_order_rec_date").ToString, 0)

            Dim tgl_delivery() As String = data.Rows(0)("delivery_order_date").ToString.Split(" ")
            'TEDODate.Text = tgl_delivery(0)

            If data.Rows(0)("del_date_type") = "date_normal" Then
                TEDODate.EditValue = data.Rows(0)("delivery_order_date")
            End If

            DEArrive.EditValue = data.Rows(0)("arrive_date")


            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            SLERecType.EditValue = data.Rows(0)("id_pl_category").ToString


            MENote.Text = data.Rows(0)("prod_order_rec_note").ToString
            pre_viewImages("2", PEView, id_design, False)
            TEDesign.Text = data.Rows(0)("design_name")

            BShowOrder.Enabled = False
            BShowContact2.Enabled = False
            GConListPurchase.Enabled = True
            GroupControlListBarcode.Enabled = True
            PEView.Enabled = True

            TERecNumber.Enabled = False
            view_barcode_list()
            view_list_rec()
            allow_status()
        End If
    End Sub


    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowOrder.Click
        'FormPopUpProd.id_prod_order = id_order
        FormPopUpProd.id_pop_up = "1"
        FormPopUpProd.ShowDialog()
    End Sub

    Sub view_po()
        expired_date = Nothing
        is_over_tol = "2"
        id_prod_over_memo = "NULL"
        qty_limit = 0

        Dim query As String = "SELECT b.id_design,d.id_sample, d.design_name, d.design_display_name, a.id_report_status, a.prod_order_number, a.id_po_type, DATE_FORMAT(a.prod_order_date,'%Y-%m-%d') as prod_order_datex, "
        query += "a.prod_order_lead_time, a.prod_order_note, g.po_type, get_total_po(" + id_order + ", 1) AS `total_order`, get_total_po(" + id_order + ", 2) AS `total_min`, g.po_type, get_total_po(" + id_order + ", 3) AS `total_max`, get_total_po(" + id_order + ", 4) AS `total_rec`, get_total_po(" + id_order + ", 5) AS `total_rec_normal`, a.is_special_rec, a.special_rec_memo "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production "
        query += "WHERE id_prod_order = '{0}' "
        query = String.Format(query, id_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_design = data.Rows(0)("id_design").ToString
        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TEOrderDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString, 0)
        TEEstRecDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString, Integer.Parse(data.Rows(0)("prod_order_lead_time").ToString))
        TEDesign.Text = data.Rows(0)("design_display_name").ToString
        TxtPOType.Text = data.Rows(0)("po_type").ToString
        is_special_rec = data.Rows(0)("is_special_rec").ToString
        total_order = Integer.Parse(data.Rows(0)("total_order").ToString)
        total_min = Integer.Parse(data.Rows(0)("total_min").ToString)
        total_max = Integer.Parse(data.Rows(0)("total_max").ToString)
        total_rec = Integer.Parse(data.Rows(0)("total_rec").ToString)
        total_rec_normal = Integer.Parse(data.Rows(0)("total_rec_normal").ToString)
        pre_viewImages("2", PEView, id_design, False)
        mainVendor()

        'see memo
        Dim qm As String = "SELECT od.id_prod_over_memo, od.qty,ADDTIME(o.created_date,CONCAT(o.lead_time,':00:00')) AS `expired_date`
        FROM tb_prod_over_memo_det od
        INNER JOIN tb_prod_over_memo o ON o.id_prod_over_memo = od.id_prod_over_memo 
        LEFT JOIN tb_prod_order_rec rec ON rec.id_prod_over_memo = o.id_prod_over_memo AND rec.id_prod_order = od.id_prod_order AND rec.id_report_status!=5
        WHERE od.id_prod_order=" + id_order + " AND o.id_report_status=6 AND NOW()<ADDTIME(o.created_date,CONCAT(o.lead_time,':00:00')) AND ISNULL(rec.id_prod_order_rec)
        ORDER BY od.id_prod_over_memo_det ASC "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        If dm.Rows.Count > 0 Then
            expired_date = dm.Rows(0)("expired_date")
            id_prod_over_memo = dm.Rows(0)("id_prod_over_memo").ToString
            '
            SLERecType.EditValue = "6"
            SLERecType.Properties.ReadOnly = True
            '
            qty_limit = dm.Rows(0)("qty")
        End If
    End Sub

    Sub mainVendor()
        'main vendor
        Dim data_vend As DataTable = getMainVendor(id_order)
        Try
            id_comp_from = data_vend.Rows(0)("id_comp_contact").ToString
            TxtCodeCompFrom.Text = data_vend.Rows(0)("comp_number").ToString
            TECompName.Text = data_vend.Rows(0)("comp_name").ToString
        Catch ex As Exception
            id_comp_from = "-1"
            TxtCodeCompFrom.Text = ""
            TECompName.Text = ""
        End Try

    End Sub

    Sub view_list_rec()
        If id_receive = "-1" Then
            Dim query = "CALL view_prod_order_rec_det('" + id_receive + "', '1')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListPurchase.DataSource = data
        Else
            Dim query = "CALL view_prod_order_rec_det('" + id_receive + "', '1')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListPurchase.DataSource = data
            If data.Rows.Count > 0 Then
                For i As Integer = 0 To data.Rows.Count - 1
                    For j As Integer = 0 To data.Rows(i)("prod_order_rec_det_qty") - 1
                        GVBarcode.AddNewRow()
                        GVBarcode.SetFocusedRowCellValue("ean_code", data.Rows(i)("ean_code"))
                        GVBarcode.SetFocusedRowCellValue("id_prod_order_det", data.Rows(i)("id_prod_order_det"))
                        GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    Next
                Next
                GCListPurchase.DataSource = data
                GCBarcode.RefreshDataSource()
                GVBarcode.RefreshData()
            End If
        End If
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRows()
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If get_opt_prod_field("is_must_input_weight") = "1" Then
            If data.Rows.Count > 0 Then
                Dim is_ok_weight As Boolean = True
                For i = 0 To data.Rows.Count - 1
                    If data.Rows(i)("qc_weight") <= 0 Then
                        is_ok_weight = False
                        Exit For
                    End If
                Next

                If is_ok_weight Then
                    GCListPurchase.DataSource = data
                Else
                    warningCustom("Berat belum terinput, mohon input berat terlebih dahulu.")
                End If
            End If
        Else
            GCListPurchase.DataSource = data
        End If
    End Sub

    Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TERecNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERecNumber.Validating
        'Dim query_jml As String
        'query_jml = String.Format("SELECT COUNT(id_prod_order_rec) FROM tb_prod_order_rec WHERE prod_order_rec_number='{0}' AND id_prod_order_rec!='{1}'", TERecNumber.Text, id_receive)
        'Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        'If Not jml < 1 Then
        '    EP_TE_already_used(EPSampleRec, TERecNumber, "1")
        'Else
        '    EP_TE_cant_blank(EPSampleRec, TERecNumber)
        'End If
    End Sub

    Private Sub FormSampleReceiveDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_receive
        If is_over_tol = "1" Then
            FormReportMark.report_mark_type = "127"
        Else
            FormReportMark.report_mark_type = "28"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        'If check_edit_report_status(LEReportStatus.EditValue.ToString, "28", id_receive) Then
        '    BScan.Enabled = True
        '    BDelete.Enabled = True
        '    BSave.Enabled = True
        '    TEDODate.Properties.ReadOnly = False
        '    DEArrive.Properties.ReadOnly = False
        '    TEDONumber.Properties.ReadOnly = False
        '    MENote.Properties.ReadOnly = False
        '    GVListPurchase.OptionsBehavior.Editable = True
        '    BtnInfoSrs.Enabled = True
        '    GVListPurchase.OptionsCustomization.AllowGroup = False
        'Else
        '    BScan.Enabled = False
        '    BDelete.Enabled = False
        '    BSave.Enabled = False
        '    TEDODate.Properties.ReadOnly = True
        '    DEArrive.Properties.ReadOnly = True
        '    TEDONumber.Properties.ReadOnly = True
        '    MENote.Properties.ReadOnly = True
        '    GVListPurchase.OptionsBehavior.Editable = False
        '    BtnInfoSrs.Enabled = False
        '    GVListPurchase.OptionsCustomization.AllowGroup = True
        'End If
        BScan.Enabled = False
        BDelete.Enabled = False
        GVListPurchase.OptionsBehavior.Editable = False
        BtnInfoSrs.Enabled = False
        GVListPurchase.OptionsCustomization.AllowGroup = True

        If LEReportStatus.EditValue.ToString = "1" Then
            BSave.Enabled = True
            TEDODate.Properties.ReadOnly = False
            DEArrive.Properties.ReadOnly = False
            TEDONumber.Properties.ReadOnly = False
            MENote.Properties.ReadOnly = False
        Else
            BSave.Enabled = False
            TEDODate.Properties.ReadOnly = True
            DEArrive.Properties.ReadOnly = True
            TEDONumber.Properties.ReadOnly = True
            MENote.Properties.ReadOnly = True
        End If


        'attachment
        If check_attach_report_status(LEReportStatus.EditValue.ToString, "28", id_receive) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(LEReportStatus.EditValue.ToString) Then
            '
            GridColumnPOQty.OptionsColumn.AllowShowHide = False
            GridColumnRemainingQty.OptionsColumn.AllowShowHide = False
            GridColumnExtra.OptionsColumn.AllowShowHide = False

            GridColumnPOQty.Visible = True
            GridColumnRemainingQty.Visible = True
            GridColumnExtra.Visible = True

            BPrint.Enabled = True

            SLERecType.Properties.ReadOnly = True

            '
        Else
            GridColumnPOQty.OptionsColumn.AllowShowHide = True
            GridColumnRemainingQty.OptionsColumn.AllowShowHide = True
            GridColumnExtra.OptionsColumn.AllowShowHide = True

            GridColumnPOQty.Visible = False
            GridColumnRemainingQty.Visible = False
            GridColumnExtra.Visible = False

            BPrint.Enabled = False

            SLERecType.Properties.ReadOnly = True
        End If

        GVListPurchase.BestFitColumns()

        'bof column
        If bof_column = "1" And LEReportStatus.EditValue.ToString <> "5" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim rmt As String = ""
        '
        If is_over_tol = "1" Then
            rmt = "127"
        Else
            rmt = "28"
        End If
        '
        If Not check_allow_print(LEReportStatus.EditValue.ToString, rmt, id_receive) Then
            warningCustom("Can't print, please complete approval on system first")
        Else
            Cursor = Cursors.WaitCursor
            GVListPurchase.BestFitColumns()
            ReportProductionRec.dt = GCListPurchase.DataSource
            ReportProductionRec.id_receive = id_receive
            ReportProductionRec.rmt = rmt

            Dim Report As New ReportProductionRec()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVListPurchase.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVListPurchase.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVListPurchase)

            'Parse val
            Report.LPONumber.Text = TEPONumber.Text.ToString
            Report.LPOType.Text = TxtPOType.Text.ToString
            Report.LDONumber.Text = TEDONumber.Text.ToString
            Report.LRecNumber.Text = TERecNumber.Text.ToString

            ' 
            Report.LFromName.Text = TECompName.Text.ToString
            ' 
            Report.LToName.Text = TECompShipToName.Text.ToString

            Report.LRecDate.Text = TERecDate.Text.ToString
            Report.LDODate.Text = TEDODate.Text.ToString
            Report.LabelArriveDate.Text = DEArrive.Text.ToString
            Report.LabelRecType.Text = SLERecType.Text.ToString

            Report.LNote.Text = MENote.Text.ToString
            Report.GVListPurchase.OptionsPrint.PrintFooter = False
            Report.LTotalReceived.Text = GVListPurchase.Columns("prod_order_rec_det_qty").SummaryText.ToString
            '
            Dim query As String = "SELECT GROUP_CONCAT(rec.prod_order_rec_number) AS rec_before
FROM tb_prod_order_rec rec 
WHERE rec.id_report_status='6' AND rec.`id_prod_order_rec` < '" & id_receive & "' AND rec.`id_prod_order`=(SELECT id_prod_order FROM tb_prod_order_rec WHERE id_prod_order_rec='" & id_receive & "')
GROUP BY rec.`id_prod_order`"
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            If dt.Rows.Count > 0 Then
                Report.LRecBefore.Text = dt.Rows(0)("rec_before").ToString
            Else
                Report.LRecBefore.Text = "-"
            End If
            '
            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        ValidateChildren()
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim rec_date, do_number, do_date, arrive_date, rec_note, rec_stats, id_pl_cat, claim_percent As String
        Dim id_rec_new As String

        'Dim rec_number As String = ""
        'rec_number = ""

        rec_date = ""
        do_number = ""
        do_date = ""
        rec_note = ""
        rec_stats = ""
        arrive_date = ""
        id_pl_cat = ""
        claim_percent = "0.00"

        makeSafeGV(GVListPurchase)
        makeSafeGV(GVBarcode)

        'validasi
        Try
            do_date = DateTime.Parse(TEDODate.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception

        End Try

        If do_date = "" Then
            do_date = "0001-01-01"
        Else
            do_date = DateTime.Parse(TEDODate.EditValue.ToString).ToString("yyyy-MM-dd")
        End If
        rec_date = TERecDate.Text
        Try
            arrive_date = DateTime.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If arrive_date = "" Then
            arrive_date = "0001-01-01"
        Else
            arrive_date = DateTime.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd")
        End If

        do_number = addSlashes(TEDONumber.Text)
        rec_note = addSlashes(MENote.Text)
        rec_stats = LEReportStatus.EditValue
        id_pl_cat = SLERecType.EditValue.ToString

        Try
            If id_pl_cat = "6" Then 'memo
                Dim qclaim As String = "SELECT discount FROM tb_prod_over_memo_det WHERE id_prod_over_memo='" & id_prod_over_memo & "' AND id_prod_order='" & id_order & "'"
                Dim dtclaim As DataTable = execute_query(qclaim, -1, True, "", "", "", "")
                claim_percent = decimalSQL(Decimal.Parse(dtclaim.Rows(0)("discount").ToString).ToString)
            Else
                Dim qclaim As String = "SELECT claim_percent FROM tb_lookup_pl_category WHERE id_pl_category='" & id_pl_cat & "'"
                Dim dtclaim As DataTable = execute_query(qclaim, -1, True, "", "", "", "")
                claim_percent = decimalSQL(Decimal.Parse(dtclaim.Rows(0)("claim_percent").ToString).ToString)
            End If
        Catch ex As Exception
            MsgBox("Claim not found." & ex.ToString)
        End Try

        'search claim percent
        For i As Integer = 0 To GVListPurchase.RowCount - 1
            Try
                If GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString = "" Then
                    err_txt = "1"
                End If
            Catch ex As Exception
            End Try
        Next
        'end of validasi

        'memo
        Dim cond_memo As Boolean = True
        If id_prod_over_memo <> "NULL" Then
            Dim cur_total As Integer = 0
            Try
                cur_total = GVListPurchase.Columns("prod_order_rec_det_qty").SummaryItem.SummaryValue.ToString
            Catch ex As Exception
            End Try
            If cur_total <> qty_limit Then
                cond_memo = False
            End If
        End If

        If id_receive = "-1" Then
            'new
            'rec_number = header_number_prod("3")

            If err_txt = "1" Or Not formIsValidInGroup(EPSampleRec, GroupGeneralHeader) Or id_order = "-1" Then
                errorInput()
            ElseIf do_date = "0001-01-01" Or arrive_date = "0001-01-01"
                warningCustom("Please put proper date on arrive and delivery date")
            ElseIf Not cond_memo Then
                stopCustom("Received should be equal to " + qty_limit.ToString)
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    BSave.Enabled = False
                    Try
                        'insert rec
                        If do_date = "0001-01-01" Then
                            query = String.Format("INSERT INTO tb_prod_order_rec(id_prod_order, delivery_order_number, delivery_order_date, arrive_date, prod_order_rec_date, prod_order_rec_note ,id_report_status, id_comp_contact_to , id_comp_contact_from, is_over_tol, id_prod_over_memo, id_pl_category,claim_percent) VALUES('{0}','{1}',NULL, '{2}',DATE(NOW()),'{3}','{4}','{5}', '{6}','{7}',{8},'{9}','{10}'); SELECT LAST_INSERT_ID(); ", id_order, do_number, arrive_date, rec_note, rec_stats, id_comp_to, id_comp_from, is_over_tol, id_prod_over_memo, id_pl_cat, claim_percent)
                            id_rec_new = execute_query(query, 0, True, "", "", "", "")
                        Else
                            query = String.Format("INSERT INTO tb_prod_order_rec(id_prod_order, delivery_order_number, delivery_order_date, arrive_date, prod_order_rec_date, prod_order_rec_note ,id_report_status, id_comp_contact_to , id_comp_contact_from, is_over_tol, id_prod_over_memo, id_pl_category,claim_percent) VALUES('{0}','{1}','{2}', '{3}',DATE(NOW()),'{4}','{5}','{6}', '{7}', '{8}', {9}, '{10}','{11}'); SELECT LAST_INSERT_ID(); ", id_order, do_number, do_date, arrive_date, rec_note, rec_stats, id_comp_to, id_comp_from, is_over_tol, id_prod_over_memo, id_pl_cat, claim_percent)
                            id_rec_new = execute_query(query, 0, True, "", "", "", "")
                        End If

                        If is_over_tol = "1" Then
                            execute_non_query("CALL gen_number('" & id_rec_new & "','127')", True, "", "", "", "")
                        Else
                            execute_non_query("CALL gen_number('" & id_rec_new & "','28')", True, "", "", "", "")
                        End If

                        'increase_inc_prod("3")

                        'rec detail
                        For i As Integer = 0 To ((GVListPurchase.RowCount - 1) - GetGroupRowCount(GVListPurchase))
                            Try
                                If Not GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString = "" Then
                                    query = String.Format("INSERT INTO tb_prod_order_rec_det(id_prod_order_det,id_prod_order_rec,prod_order_rec_det_qty,prod_order_rec_det_note) VALUES('{0}','{1}','{2}','{3}')", GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString, id_rec_new, decimalSQL(GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_note").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'submit
                        If is_over_tol = "1" Then
                            submit_who_prepared("127", id_rec_new, id_user)
                        Else
                            submit_who_prepared("28", id_rec_new, id_user)
                        End If

                        'end insert who prepared
                        FormProductionRec.view_prod_order_rec()
                        FormProductionRec.view_prod_order()
                        FormProductionRec.GVProdRec.FocusedRowHandle = find_row(FormProductionRec.GVProdRec, "id_prod_order_rec", id_rec_new)
                        FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0
                        id_receive = id_rec_new
                        'TERecNumber.Text = rec_number
                        actionLoad()

                        'export to bof
                        'exportToBOF(False)

                        'extra note import
                        Dim extra_note As String = ""

                        infoCustom("Receive QC telah disimpan.")
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        Else
            'edit
            'rec_number = TERecNumber.Text
            If err_txt = "1" Or Not formIsValidInGroup(EPSampleRec, GroupGeneralHeader) Then
                errorInput()
            ElseIf do_date = "0001-01-01" Or arrive_date = "0001-01-01"
                warningCustom("Please put proper date on arrive and delivery date")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'UPDATE rec
                        'If do_date = "0000-00-00" Then
                        '    query = String.Format("UPDATE tb_prod_order_rec SET delivery_order_number='{0}',delivery_order_date=null, arrive_date='{1}',prod_order_rec_note='{2}',id_report_status='{3}',id_comp_contact_to='{4}', id_comp_contact_from = '{5}',id_pl_category='{7}',claim_percent='{8}' WHERE id_prod_order_rec='{6}'", do_number, arrive_date, rec_note, rec_stats, id_comp_to, id_comp_from, id_receive, id_pl_cat, claim_percent)
                        '    execute_non_query(query, True, "", "", "", "")
                        'Else
                        '    query = String.Format("UPDATE tb_prod_order_rec SET delivery_order_number='{0}',delivery_order_date='{1}', arrive_date='{2}',prod_order_rec_note='{3}',id_report_status='{4}',id_comp_contact_to='{5}', id_comp_contact_from = '{6}',id_pl_category='{8}',claim_percent='{9}' WHERE id_prod_order_rec='{7}'", do_number, do_date, arrive_date, rec_note, rec_stats, id_comp_to, id_comp_from, id_receive, id_pl_cat, claim_percent)
                        '    execute_non_query(query, True, "", "", "", "")
                        'End If

                        ''rec detail
                        'For i As Integer = 0 To ((GVListPurchase.RowCount - 1) - GetGroupRowCount(GVListPurchase))
                        '    query = String.Format("UPDATE tb_prod_order_rec_det SET prod_order_rec_det_qty='{0}',prod_order_rec_det_note='{1}' WHERE id_prod_order_rec_det='{2}'", decimalSQL(GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_note").ToString, GVListPurchase.GetRowCellValue(i, "id_prod_order_rec_det").ToString)
                        '    execute_non_query(query, True, "", "", "", "")
                        'Next

                        'update
                        query = String.Format("UPDATE tb_prod_order_rec SET delivery_order_number='{0}',delivery_order_date='{1}', arrive_date='{2}',prod_order_rec_note='{3}' WHERE id_prod_order_rec='{6}'", do_number, do_date, arrive_date, rec_note, claim_percent, id_receive)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormProductionRec.view_prod_order_rec()
                        FormProductionRec.view_prod_order()
                        FormProductionRec.GVProdRec.FocusedRowHandle = find_row(FormProductionRec.GVProdRec, "id_prod_order_rec", id_receive)
                        FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0
                        actionLoad()

                        'export to bof
                        'exportToBOF(False)

                        infoCustom("Receive QC document updated.")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub GVListPurchase_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    sample_purc_rec_det_qty_inp = GVListPurchase.GetFocusedRowCellDisplayText("prod_order_rec_det_qty").ToString
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    'Cell Value Changed to resrict qty
    Private Sub RepositoryItemSpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim sqty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        '    Dim qty_limit As Decimal = CType(GVListPurchase.GetFocusedRowCellDisplayText("qty").ToString, Decimal)
        '    Dim qty_rec As Decimal = CType(sqty.EditValue.ToString, Decimal)
        '    If (qty_rec > qty_limit) Then
        '        DevExpress.XtraEditors.XtraMessageBox.Show("- Qty issue must be smaller than qty ordered or equal to qty ordered !" + System.Environment.NewLine + "- Not allowed character input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Dim qty_bound As Decimal = qty_rec - 1
        '        If qty_bound < 0 Then
        '            qty_bound = 0
        '        End If
        '        GVListPurchase.SetFocusedRowCellValue("prod_order_rec_det_qty", qty_limit.ToString)
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub GroupGeneralHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupGeneralHeader.Paint

    End Sub

    Private Sub BShowContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "25"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TECompName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompName.Validating
        EP_TE_cant_blank(EPSampleRec, TECompName)
        EPSampleRec.SetIconPadding(TECompName, 30)
    End Sub

    Private Sub TECompShipToName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompShipToName.Validating
        EP_TE_cant_blank(EPSampleRec, TECompShipToName)
        EPSampleRec.SetIconPadding(TECompShipToName, 30)
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
        EP_TE_cant_blank(EPSampleRec, TEPONumber)
        EPSampleRec.SetIconPadding(TEPONumber, 30)
    End Sub

    Private Sub GVListPurchase_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Hidden")
    End Sub

    'DeleteRows
    Sub deleteRows()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCode()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRows()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        Cursor = Cursors.WaitCursor
        MENote.Enabled = False
        TEDONumber.Enabled = False
        TEDODate.Enabled = False
        BShowOrder.Enabled = False
        BShowContact2.Enabled = False
        BSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BCancel.Enabled = False
        GVListPurchase.OptionsBehavior.Editable = False
        ControlBox = False
        view_po()
        newRows()
        Cursor = Cursors.Default
        'allowDelete()
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "ean_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        MENote.Enabled = True
        TEDONumber.Enabled = True
        TEDODate.Enabled = True
        BShowContact2.Enabled = True
        BSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BCancel.Enabled = True
        allowDelete()
        GVListPurchase.OptionsBehavior.Editable = True
        ControlBox = True
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
            deleteRows()
            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_prod_order_det)
            End If
            '
            If GVBarcode.RowCount = 0 Then
                SLERecType.Properties.ReadOnly = False
            End If
            'allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("ean_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        Dim cur_total As Integer = 0
        Try
            cur_total = GVListPurchase.Columns("prod_order_rec_det_qty").SummaryItem.SummaryValue.ToString
        Catch ex As Exception
        End Try

        For i As Integer = 0 To (GVListPurchase.RowCount - 1)
            Dim code As String = GVListPurchase.GetRowCellValue(i, "ean_code").ToString
            id_prod_order_det = GVListPurchase.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("ean_code", "")
            stopCustom("Data not found !")
        Else
            If is_special_rec = "1" Then 'not used
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                countQty(id_prod_order_det)
                newRows()
                SLERecType.Properties.ReadOnly = True
            Else
                If (total_rec_normal + cur_total + 1) <= total_order And SLERecType.EditValue.ToString = "1" Then 'batas order
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                    countQty(id_prod_order_det)
                    newRows()
                    SLERecType.Properties.ReadOnly = True
                ElseIf (total_rec + cur_total + 1) <= total_max And (SLERecType.EditValue.ToString = "5" Or SLERecType.EditValue.ToString = "2" Or SLERecType.EditValue.ToString = "3" Or SLERecType.EditValue.ToString = "4") Then 'batas 2%
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                    countQty(id_prod_order_det)
                    newRows()
                    SLERecType.Properties.ReadOnly = True
                ElseIf SLERecType.EditValue.ToString = "6" Then 'batas memo
                    If id_prod_over_memo <> "NULL" Then 'jika ada memo
                        If getTimeDB() < expired_date Then 'jika masi ada waktu
                            If (cur_total + 1) <= qty_limit Then
                                is_over_tol = "1"
                                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                                GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                                countQty(id_prod_order_det)
                                newRows()
                                SLERecType.Properties.ReadOnly = True
                            Else
                                GVBarcode.SetFocusedRowCellValue("ean_code", "")
                                stopCustom("Received should be equal to " + qty_limit.ToString)
                            End If
                        Else
                            GVBarcode.SetFocusedRowCellValue("ean_code", "")
                            stopCustom("Memo is expired !")
                        End If
                    Else
                        GVBarcode.SetFocusedRowCellValue("ean_code", "")
                        'stopCustom("Maximum receive : " + (total_max - total_rec).ToString)
                        stopCustom("Memo not found for this PO.")
                    End If
                Else
                    If SLERecType.EditValue.ToString = "1" Then
                        GVBarcode.SetFocusedRowCellValue("ean_code", "")
                        stopCustom("Maximum receive normal : " + (total_order - total_rec_normal).ToString)
                    Else
                        GVBarcode.SetFocusedRowCellValue("ean_code", "")
                        stopCustom("Maximum receive dengan toleransi : " + (total_max - total_rec).ToString)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBarcode.CellValueChanged
        'MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "ean_code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("ean_code")
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_sample_purc_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_sample_purc_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Integer = 0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1
            End If
        Next
        GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_prod_order_det", id_prod_order_detx)
        GVListPurchase.SetFocusedRowCellValue("prod_order_rec_det_qty", tot)
        GCListPurchase.RefreshDataSource()
        GVListPurchase.RefreshData()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BShowContact2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowContact2.Click
        FormPopUpContact.id_pop_up = "27"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_receive
        If is_over_tol = "1" Then
            FormDocumentUpload.report_mark_type = "127"
        Else
            FormDocumentUpload.report_mark_type = "28"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        Cursor = Cursors.WaitCursor
        FormPopUpProd.id_pop_up = "6"
        FormPopUpProd.BSave.Visible = False
        FormPopUpProd.id_prod_order = id_order
        FormPopUpProd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVListPurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVListPurchase.FocusedRowChanged
        GCListPurchase.RefreshDataSource()
        GVListPurchase.RefreshData()
    End Sub

    Private Sub TEDONumber_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEDONumber.Validating
        EP_TE_cant_blank(EPSampleRec, TEDONumber)
    End Sub

    Private Sub TEDODate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEDODate.Validating
        EP_DE_cant_blank(EPSampleRec, TEDODate)
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVListPurchase.Columns.Count - 1
                GVListPurchase.Columns(c).Visible = False
            Next
            ColCode.VisibleIndex = 0
            ColQtyRec.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            ColNote.VisibleIndex = 5
            GVListPurchase.OptionsPrint.PrintFooter = False
            GVListPurchase.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\pro_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVListPurchase, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            ColNo.VisibleIndex = 0
            ColCode.VisibleIndex = 1
            GridColumnEANCode.VisibleIndex = 2
            ColName.VisibleIndex = 3
            ColSize.VisibleIndex = 4
            ColQtyRec.VisibleIndex = 5
            ColNote.VisibleIndex = 6
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVListPurchase.OptionsPrint.PrintFooter = True
            GVListPurchase.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_rec_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                ElseIf j = 5 Then 'remark
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_rec_det_note").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub GVListPurchase_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVListPurchase.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TERecNumber.Text.ToString
        End If
    End Sub

    Private Sub DEArrive_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEArrive.Validating
        EP_DE_cant_blank(EPSampleRec, DEArrive)
    End Sub

    Private Sub TEDODate_EditValueChanged(sender As Object, e As EventArgs) Handles TEDODate.EditValueChanged
        Try
            DEArrive.Properties.MinValue = TEDODate.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class