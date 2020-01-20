Public Class FormSetupBudgetOPEXDet
    Public id_pps As String = "-1"
    Public is_rev As String = "2"
    Public is_view As String = "-1"

    Private Sub FormSampleBudgetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        If id_pps = "-1" Then 'new
            TENumber.Text = "[auto_generate]"
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEDateCreated.EditValue = Now
            '
            BtnSave.Visible = True
            BtnPrint.Visible = False
            BMark.Visible = False
            BAttachment.Visible = False
        Else 'view
            Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_b_opex_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
WHERE pps.id_b_opex_pps = '" & id_pps & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                If data.Rows(0)("id_type").ToString = "2" Then
                    is_rev = "1"
                End If
                '
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TECreatedBy.Text = data.Rows(0)("employee_name")
                MENote.Text = data.Rows(0)("note").ToString
                If data.Rows(0)("is_submit").ToString = "1" Then
                    BMark.Text = "Mark"
                Else
                    BMark.Text = "Submit"
                End If
            End If
            '
            BtnSave.Visible = False
            BtnPrint.Visible = True
            BMark.Visible = True
            BAttachment.Visible = True
        End If
        '
        load_before_det()
        load_after_det()
        '
        If is_rev = "1" Then
            XTPBefore.PageVisible = True
            'revision
            If id_pps = "-1" Then 'new
                Try
                    For i As Integer = 0 To FormSetupBudgetOPEX.GVBudgetList.RowCount - 1
                        'before
                        Dim newRow_before As DataRow = (TryCast(GCBefore.DataSource, DataTable)).NewRow()
                        newRow_before("value_before") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "value_expense").ToString
                        newRow_before("year") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "year").ToString
                        newRow_before("item_cat_main") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "item_cat_main").ToString
                        newRow_before("id_item_cat_main") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "id_item_cat_main").ToString
                        TryCast(GCBefore.DataSource, DataTable).Rows.Add(newRow_before)
                        GCBefore.RefreshDataSource()
                        GVBefore.RefreshData()
                        GVBefore.FocusedRowHandle = GVBefore.RowCount - 1
                        'after
                        Dim newRow_after As DataRow = (TryCast(GCAfter.DataSource, DataTable)).NewRow()
                        newRow_after("value_before") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "value_expense").ToString
                        newRow_after("value_after") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "value_expense").ToString
                        newRow_after("year") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "year").ToString
                        newRow_after("item_cat_main") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "item_cat_main").ToString
                        newRow_after("id_item_cat_main") = FormSetupBudgetOPEX.GVBudgetList.GetRowCellValue(i, "id_item_cat_main").ToString
                        TryCast(GCAfter.DataSource, DataTable).Rows.Add(newRow_after)
                        GCAfter.RefreshDataSource()
                        GVAfter.RefreshData()
                        GVAfter.FocusedRowHandle = GVAfter.RowCount - 1
                    Next
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try

            End If

            XTCBeforeAfter.SelectedTabPageIndex = 1
        Else
            XTPBefore.PageVisible = False
            'not revision
            If id_pps = "-1" Then 'new
                'get year
                Dim year_str As String = FormSetupBudgetOPEX.DEYearBudget.Text

                Dim str_code_lokal As String = "SELECT * FROM tb_item_cat_main WHERE id_expense_type='1' AND is_active='1'"
                Dim data_code_lokal As DataTable = execute_query(str_code_lokal, -1, True, "", "", "", "")

                'budget category
                For i As Integer = 0 To data_code_lokal.Rows.Count - 1
                    Dim newRow_after As DataRow = (TryCast(GCAfter.DataSource, DataTable)).NewRow()
                    newRow_after("id_item_cat_main") = data_code_lokal.Rows(i)("id_item_cat_main").ToString
                    newRow_after("item_cat_main") = data_code_lokal.Rows(i)("item_cat_main").ToString
                    newRow_after("year") = year_str
                    newRow_after("value_after") = 0.00
                    TryCast(GCAfter.DataSource, DataTable).Rows.Add(newRow_after)
                    GCAfter.RefreshDataSource()
                    GVAfter.RefreshData()
                Next
            End If
        End If
        '
        If is_view = "1" Then
            BtnPrint.Visible = False
        End If
    End Sub

    Sub load_before_det()
        Dim query As String = "SELECT ppd.id_b_opex_pps_det,ppd.id_item_cat_main,ic.`item_cat_main`,ppd.`year`,ppd.value_before 
FROM `tb_b_opex_pps_det` ppd
INNER JOIN tb_item_cat_main ic ON ic.`id_item_cat_main`=ppd.id_item_cat_main
WHERE ppd.id_b_opex_pps='" & id_pps & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBefore.DataSource = data
        GVBefore.BestFitColumns()
    End Sub

    Sub load_after_det()
        Dim query As String = "SELECT ppd.id_b_opex_pps_det,ppd.id_item_cat_main,ic.`item_cat_main`,ppd.`year`,ppd.value_before,ppd.value_after 
FROM `tb_b_opex_pps_det` ppd
INNER JOIN tb_item_cat_main ic ON ic.`id_item_cat_main`=ppd.id_item_cat_main
WHERE ppd.id_b_opex_pps='" & id_pps & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleBudgetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVAfter.RowCount <= 0 Then
            warningCustom("Please input proposed budget")
        Else
            If is_rev = "1" Then 'revision
                'header
                Dim query As String = "INSERT INTO `tb_b_opex_pps`(`id_type`,`date_created`,`created_by`,`note`,`id_report_status`) 
VALUES('2',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1');SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(query, 0, True, "", "", "", "")

                query = "CALL gen_number('" & id_pps & "','204')"
                execute_non_query(query, True, "", "", "", "")

                'detail
                For i As Integer = 0 To GVAfter.RowCount - 1
                    Dim query_det As String = "INSERT INTO `tb_b_opex_pps_det`(`id_b_opex_pps`,`id_item_cat_main`,`year`,`value_before`,`value_after`)
VALUES ('" & id_pps & "','" & GVAfter.GetRowCellValue(i, "id_item_cat_main").ToString & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_before").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value_after").ToString) & "'); SELECT LAST_INSERT_ID(); "
                    Dim id_det As String = execute_query(query_det, 0, True, "", "", "", "")
                Next

                'submit_who_prepared("204", id_pps, id_user)
                infoCustom("Revise budget created, press submit to continue approval process")

                FormSetupBudgetOPEX.XTCSampleBudget.SelectedTabPageIndex = 1
                FormSetupBudgetOPEX.DEStart.EditValue = Now
                FormSetupBudgetOPEX.DEUntil.EditValue = Now
                FormSetupBudgetOPEX.load_propose()
                'Close()
            Else 'new
                Dim query As String = "INSERT INTO `tb_b_opex_pps`(`id_type`,`date_created`,`created_by`,`note`,`id_report_status`) 
VALUES('1',NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1');SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(query, 0, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_pps & "','203')"
                execute_non_query(query, True, "", "", "", "")
                'detail
                For i As Integer = 0 To GVAfter.RowCount - 1
                    Dim query_det As String = "INSERT INTO `tb_b_opex_pps_det`(`id_b_opex_pps`,id_item_cat_main,`year`,`value_before`,`value_after`)
VALUES ('" & id_pps & "','" & addSlashes(GVAfter.GetRowCellValue(i, "id_item_cat_main").ToString) & "','" & addSlashes(GVAfter.GetRowCellValue(i, "year").ToString) & "',0,'" & decimalSQL(GVAfter.GetRowCellValue(i, "value_after").ToString) & "'); SELECT LAST_INSERT_ID(); "
                    Dim id_det As String = execute_query(query_det, 0, True, "", "", "", "")
                Next
                '
                'submit_who_prepared("203", id_pps, id_user)
                infoCustom("Budget created, press submit to continue approval process")
                load_form()
                '
                FormSetupBudgetOPEX.XTCSampleBudget.SelectedTabPageIndex = 1
                FormSetupBudgetOPEX.DEStart.EditValue = Now
                FormSetupBudgetOPEX.DEUntil.EditValue = Now
                FormSetupBudgetOPEX.load_propose()
                'Close()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If BMark.Text = "Mark" Then
            FormReportMark.id_report = id_pps
            FormReportMark.is_view = is_view
            If is_rev = "1" Then 'revision
                FormReportMark.report_mark_type = "204"
            Else
                FormReportMark.report_mark_type = "203"
            End If

            FormReportMark.ShowDialog()
        Else
            'submit
            'cek sudah ada attachment blm
            Dim query As String = ""
            Dim rmt As String = ""

            If is_rev = "1" Then 'revision
                rmt = "204"
            Else
                rmt = "203"
            End If

            query = "SELECT * FROM tb_doc WHERE id_report='" & id_pps & "' AND report_mark_type='" & rmt & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                query = "UPDATE tb_b_opex_pps SET is_submit='1' WHERE id_b_opex_pps='" & id_pps & "'"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared(rmt, id_pps, id_user)
                '
                load_form()
                infoCustom("Budget submitted")
            Else
                warningCustom("Please upload attachment first.")
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        '
        ReportSetupBudgetOPEX.id_report = id_pps
        ReportSetupBudgetOPEX.dt = GCAfter.DataSource
        Dim Report As New ReportSetupBudgetOPEX()
        Report.LNumber.Text = TENumber.Text
        Report.LNote.Text = MENote.Text
        Report.LPrroposedBy.Text = TECreatedBy.Text
        Report.LCreatedDate.Text = Date.Parse(DEDateCreated.EditValue.ToString).ToString("dd MMMM yyyy")

        If is_rev = "1" Then
            Report.GBBefore.Visible = True
            Report.LType.Text = "Revision"
            Report.report_mark_type = "204"
        Else
            Report.GBBefore.Visible = False
            Report.LType.Text = "Propose new budget"
            Report.report_mark_type = "203"
        End If

        ReportStyleGridview(Report.GVBudgetPropose)
        Report.GVBudgetPropose.AppearancePrint.Row.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetPropose.AppearancePrint.Row.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetPropose.AppearancePrint.Row.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetPropose.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVBudgetPropose.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.is_view = is_view

        If is_rev = "1" Then
            FormDocumentUpload.id_report = id_pps
            FormDocumentUpload.report_mark_type = "204"
        Else
            FormDocumentUpload.id_report = id_pps
            FormDocumentUpload.report_mark_type = "203"
        End If

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAfter_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVAfter.RowStyle
        If Not GVAfter.GetRowCellValue(e.RowHandle, "value_before") = GVAfter.GetRowCellValue(e.RowHandle, "value_after") Then
            e.Appearance.BackColor = Color.Honeydew
            e.Appearance.BackColor2 = Color.Honeydew
            e.Appearance.Font = New Font(GVAfter.Appearance.Row.Font, FontStyle.Bold)
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.Font = New Font(GVAfter.Appearance.Row.Font, FontStyle.Regular)
        End If
    End Sub
End Class