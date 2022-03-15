Public Class FormSNIppsDet
    Public id_pps As String = "-1"
    Public is_view As String = "-1"

    Dim is_submit As String = "-1"

    Private Sub FormSNIppsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        load_head()
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub load_artikel()
        Dim q As String = "SELECT 'no' AS is_check,id_design,id_product,id_sni_pps_budget,budget_desc,budget_value,budget_qty
FROM `tb_sni_pps_budget` b
WHERE b.id_sni_pps='" & id_pps & "' AND NOT ISNULL(b.id_design) AND NOT ISNULL(b.id_product)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBudgetCop.DataSource = dt
        GVBudgetCop.BestFitColumns()
    End Sub

    Sub load_budget_det()
        Dim q As String = "SELECT 'no' AS is_check,id_sni_pps_budget,budget_desc,budget_value,budget_qty
FROM `tb_sni_pps_budget` b
WHERE b.id_sni_pps='" & id_pps & "' AND ISNULL(b.id_design)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBudget.DataSource = dt
        GVBudget.BestFitColumns()
    End Sub

    Sub load_head()
        If id_pps = "-1" Then
            'new

            TENumber.Text = "[auto_generate]"
            TEProposedBy.Text = get_emp(id_employee_user, "2")
            '
            XTPListDesign.PageVisible = True
            XTPProposedList.PageVisible = False
            XTPBudgetPropose.PageVisible = False
        Else
            'edit
            Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,pps.id_report_status,pps.is_submit 
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pps.`id_sni_pps`='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                TEProposedBy.Text = dt.Rows(0)("employee_name").ToString
                DEProposeDate.EditValue = dt.Rows(0)("created_date")
                '
                load_proposed()

                is_submit = dt.Rows(0)("is_submit").ToString
                '
                If is_submit = "1" Then
                    BPrint.Visible = True
                    PCAddBudget.Visible = False
                    PCAddDel.Visible = False
                    BSave.Visible = False
                Else
                    BPrint.Visible = False
                    PCAddBudget.Visible = True
                    PCAddDel.Visible = True
                    BSave.Visible = True
                End If
                '
                If is_view = "1" Then
                    BSave.Visible = False
                    BPrint.Visible = False
                End If

                XTPListDesign.PageVisible = False
                XTPProposedList.PageVisible = True
                XTPBudgetPropose.PageVisible = True
                '
                If is_submit = "1" Then
                    BMark.Text = "Mark"
                Else
                    BMark.Text = "Submit"
                End If
            End If
        End If
    End Sub

    Sub load_pending_kids()
        Dim q As String = "SELECT 'yes' AS is_check,dsg.`id_design`,dsg.`design_code`,dsg.`design_display_name`,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) AS ecop,del.`delivery`,ssn.`season`
,pdl.qty_line_list, IFNULL(pdp.id_prod_demand_product,0) AS id_prod_demand_product
FROM tb_m_design dsg
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design`
INNER JOIN tb_season_delivery del ON del.id_delivery=dsg.`id_delivery` AND dsg.id_season='" & SLESeason.EditValue.ToString & "'
INNER JOIN tb_season ssn ON ssn.id_season=del.id_season
LEFT JOIN 
(
    SELECT spl.id_design FROM `tb_sni_pps_list` spl
    INNER JOIN tb_sni_pps sp ON sp.id_sni_pps=spl.id_sni_pps
    WHERE sp.id_report_status!=5 
)pps ON pps.id_design=dsg.id_design
INNER JOIN
(
    SELECT dsg.`id_design`,SUM(pdp.`prod_demand_product_qty`) AS qty_line_list
    FROM tb_m_design dsg
    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
    INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand=pdd.id_prod_demand AND pd.is_pd=2
    GROUP BY dsg.`id_design`
)pdl ON pdl.id_design=dsg.id_design
LEFT JOIN
(
    SELECT dsg.id_design,pdp.`id_prod_demand_product`
    FROM tb_m_design dsg
    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand=pdd.id_prod_demand AND pd.is_pd=2
    INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
    INNER JOIN tb_m_product p ON p.id_product=pdp.id_product AND p.product_code='931' -- hanya S
    GROUP BY dsg.`id_design`
)pdp ON pdp.id_design=dsg.id_design
WHERE dsg.`id_design` NOT IN (
	SELECT id_design 
	FROM tb_prod_demand_design pdd 
	INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
	WHERE pd.`id_report_status`=6 AND pd.`is_void_pd`!=1 AND pd.`is_pd`=1
	GROUP BY pdd.`id_design`
)
AND ISNULL(pps.id_design) AND dsg.`is_approved`=1 AND dsg.`is_old_design`=2 AND dsg.`id_lookup_status_order`!=2 AND dsg.prod_order_cop_pd>0"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If GVList.RowCount > 0 Then
            BPropose.Visible = True
        End If
    End Sub

    Sub load_proposed()
        Dim q As String = "SELECT 'no' AS is_check,clr.color,IFNULL(p.id_product,0) AS id_product,dsg.`id_design`,dsg.`design_code`,dsg.design_fabrication
,CONCAT(dsg.`design_display_name`,IF(ISNULL(di.value),'',CONCAT(' (',di.value,')'))) AS design_display_name,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) AS ecop
,del.`delivery`,ssn.`season`
,'VOLCOM' AS brand,co.country,ppsl.qty AS qty_line_list,so.season_orign
FROM tb_sni_pps_list `ppsl`
LEFT JOIN tb_m_product p ON p.id_design=ppsl.id_design AND p.product_code='931' -- hanya S
INNER JOIN tb_m_design dsg ON dsg.`id_design`=ppsl.`id_design`
LEFT JOIN tb_m_design_information di ON di.id_design=dsg.id_design AND di.id_design_column=25
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design`
INNER JOIN tb_season_delivery del ON del.id_delivery=dsg.`id_delivery`
INNER JOIN tb_season ssn ON ssn.id_season=del.id_season
INNER JOIN tb_season_orign so ON so.id_season_orign=dsg.id_season_orign
INNER JOIN tb_m_country co ON co.id_country=so.id_country
INNER JOIN 
(
    SELECT dc.id_design,CONCAT(cd.code_detail_name,' (',cd.display_name,')') AS color
    FROM `tb_m_design_code` dc
    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail=dc.id_code_detail
    WHERE cd.id_code='14'
    GROUP BY dc.id_design
) clr ON clr.id_design=dsg.id_design
INNER JOIN
(
    SELECT dsg.`id_design`,SUM(pdp.`prod_demand_product_qty`) AS qty_line_list
    FROM tb_m_design dsg
    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
    INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_design`=pdd.`id_prod_demand_design`
    GROUP BY dsg.`id_design`
)pdl ON pdl.id_design=dsg.id_design
AND dsg.`is_approved`=1 AND dsg.`is_old_design`=2 AND dsg.`id_lookup_status_order`!=2
WHERE ppsl.id_sni_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCProposed.DataSource = dt
        GVProposed.BestFitColumns()
        '
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount = 0 Then
            warningCustom("No design selected")
        Else
            'check ada qty dan ecop dan size S di line sheet
            Dim is_ok As Boolean = True
            For i = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(i, "ecop") <= 0 Or GVList.GetRowCellValue(i, "qty_line_list") <= 0 Or GVList.GetRowCellValue(i, "id_prod_demand_product").ToString = "0" Then
                    is_ok = False
                    Exit For
                End If
            Next

            If Not is_ok Then
                warningCustom("Pastikan data ecop pd purchasing, qty, dan size S sudah terinput")
            Else
                Dim q As String = "INSERT INTO tb_sni_pps(id_season,created_by,created_date) VALUES('" & SLESeason.EditValue.ToString & "','" & id_user & "',NOW()); SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(q, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number('" & id_pps & "','319')", True, "", "", "", "")

                q = "INSERT INTO tb_sni_pps_list(id_sni_pps,id_design,qty,id_prod_demand_product) VALUES"
                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVList.GetRowCellValue(i, "id_design").ToString & "','" & decimalSQL(Decimal.Parse(GVList.GetRowCellValue(i, "qty_line_list").ToString)) & "','" & GVList.GetRowCellValue(i, "id_prod_demand_product").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                '
                load_head()
            End If
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If GVBudget.RowCount = 0 Then
            warningCustom("No budget found.")
        ElseIf GVBudgetCop.RowCount = 0 Then
            warningCustom("No SNI sample selected.")
        Else
            Dim is_zero As Boolean = False
            For i = 0 To GVBudget.RowCount - 1
                If GVBudget.GetRowCellValue(i, "sub_amount") = 0 Then
                    is_zero = True
                    Exit For
                End If
            Next
            '
            If Not is_zero Then
                For i = 0 To GVBudgetCop.RowCount - 1
                    If GVBudgetCop.GetRowCellValue(i, "sub_amount") = 0 Then
                        is_zero = True
                        Exit For
                    End If
                Next
            End If
            '
            If is_zero Then
                warningCustom("Zero amount on budget")
            Else
                'save
                Dim q As String = ""
                q = "DELETE FROM tb_sni_pps_budget WHERE id_sni_pps='" & id_pps & "'"
                execute_non_query(q, True, "", "", "", "")

                q = ""
                For i = 0 To GVBudgetCop.RowCount - 1
                    If Not q = "" Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVBudgetCop.GetRowCellValue(i, "id_design").ToString & "','" & GVBudgetCop.GetRowCellValue(i, "id_product").ToString & "','" & addSlashes(GVBudgetCop.GetRowCellValue(i, "budget_desc").ToString) & "','" & decimalSQL(Decimal.Parse(GVBudgetCop.GetRowCellValue(i, "budget_value").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVBudgetCop.GetRowCellValue(i, "budget_qty").ToString).ToString) & "')"
                Next

                For i = 0 To GVBudget.RowCount - 1
                    If Not q = "" Then
                        q += ","
                    End If
                    q += "('" & id_pps & "',NULL,NULL,'" & addSlashes(GVBudget.GetRowCellValue(i, "budget_desc").ToString) & "','" & decimalSQL(Decimal.Parse(GVBudget.GetRowCellValue(i, "budget_value").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVBudget.GetRowCellValue(i, "budget_qty").ToString).ToString) & "')"
                Next

                q = "INSERT INTO tb_sni_pps_budget(id_sni_pps,id_design,id_product,budget_desc,budget_value,budget_qty) VALUES" & q
                execute_non_query(q, True, "", "", "", "")

                infoCustom("Budget updated")
            End If
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()

    Private Sub GVProposed_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVProposed.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_pending_kids()
    End Sub

    Private Sub BExportList_Click(sender As Object, e As EventArgs) Handles BExportList.Click
        Cursor = Cursors.WaitCursor
        ReportSNIPpsList.id_pps = id_pps
        ReportSNIPpsList.dt = GCProposed.DataSource
        Dim Report As New ReportSNIPpsList()

        GridColumnCEPps.VisibleIndex = "-1"
        GridColumnNo.VisibleIndex = 0

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVProposed.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVProposed.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        Report.GVProposed.AppearancePrint.Row.Font = New Font("Segoe UI", 5, FontStyle.Regular)
        ReportStyleGridview(Report.GVProposed)

        GridColumnCEPps.VisibleIndex = 0
        GridColumnNo.VisibleIndex = "-1"

        'Parse val
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,s.season,c.comp_name,c.address_primary
FROM tb_sni_pps pps
INNER JOIN tb_m_comp c ON c.id_comp=(SELECT id_own_company FROM `tb_opt`)
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_season s ON s.id_season=pps.`id_season`
WHERE pps.id_sni_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        Report.DataSource = dt

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub BGetCOP_Click(sender As Object, e As EventArgs) Handles BGetCOP.Click
        GVProposed.ActiveFilterString = "[is_check]='yes'"

        If GVProposed.RowCount > 0 Then
            Dim id As String = ""
            Dim no_size_s As String = ""
            '
            For i As Integer = 0 To GVProposed.RowCount - 1
                If Not i = 0 Then
                    id += ","
                End If
                id += GVProposed.GetRowCellValue(i, "id_design").ToString
                '
                If GVProposed.GetRowCellValue(i, "id_product").ToString = "0" Then
                    no_size_s += vbNewLine & "- " & GVProposed.GetRowCellValue(i, "design_display_name").ToString
                End If
            Next

            Dim qc As String = "SELECT GROUP_CONCAT(DISTINCT dsg.design_display_name) AS err FROM tb_sni_pps_budget b
INNER JOIN tb_m_design dsg ON dsg.`id_design`=b.`id_design`
WHERE b.id_sni_pps='" & id_pps & "' AND b.id_design IN (" & id & ") 
HAVING NOT ISNULL(err)"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Artikel " & dtc.Rows(0)("err").ToString & " sudah masuk ke dalam budget")
            ElseIf Not no_size_s = "" Then
                warningCustom("Design berikut tidak memiliki size S : " & no_size_s)
            Else
                'check first
                Dim q As String = ""
                For i As Integer = 0 To GVProposed.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVProposed.GetRowCellValue(i, "id_design").ToString & "','" & GVProposed.GetRowCellValue(i, "id_product").ToString & "','Sampel " & GVProposed.GetRowCellValue(i, "design_display_name").ToString & "','" & decimalSQL(Decimal.Parse(GVProposed.GetRowCellValue(i, "ecop").ToString)) & "',6)"
                Next

                If Not q = "" Then
                    'insert
                    q = "INSERT INTO `tb_sni_pps_budget`(`id_sni_pps`,`id_design`,`id_product`,`budget_desc`,`budget_value`,`budget_qty`) VALUES" & q
                    execute_non_query(q, True, "", "", "", "")
                End If

                XTCKidList.SelectedTabPageIndex = 2
            End If
        End If
        GVProposed.ActiveFilterString = ""
    End Sub

    Private Sub XTCKidList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCKidList.SelectedPageChanged
        If XTCKidList.SelectedTabPageIndex = 2 Then
            load_artikel()
            load_budget_det()
            calculate()
        End If
    End Sub

    Sub calculate()
        GVBudget.RefreshData()
        GVBudgetCop.RefreshData()

        TETotalBudget.EditValue = GVBudgetCop.Columns("sub_amount").SummaryItem.SummaryValue + GVBudget.Columns("sub_amount").SummaryItem.SummaryValue
        TEVat.EditValue = Math.Round(TETotalBudget.EditValue * 0.1, 2)
        TEGrandTot.EditValue = Math.Round(TETotalBudget.EditValue * 1.1, 2)

        TETotalQty.EditValue = GVProposed.Columns("qty_line_list").SummaryItem.SummaryValue
        TESNICop.EditValue = Math.Round((GVBudgetCop.Columns("sub_amount").SummaryItem.SummaryValue + GVBudget.Columns("sub_amount").SummaryItem.SummaryValue) / GVProposed.Columns("qty_line_list").SummaryItem.SummaryValue, 2)
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            GVBudgetCop.ActiveFilterString = "[is_check]='yes'"
            For i = GVBudgetCop.RowCount - 1 To 0 Step -1
                GVBudgetCop.DeleteRow(i)
            Next
            GVBudgetCop.ActiveFilterString = ""
            '
            GVBudget.ActiveFilterString = "[is_check]='yes'"
            For i = GVBudget.RowCount - 1 To 0 Step -1
                GVBudget.DeleteRow(i)
            Next
            GVBudget.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVProposed_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProposed.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Cursor = Cursors.WaitCursor
        GVBudget.AddNewRow()
        GVBudget.FocusedRowHandle = GVBudget.RowCount - 1
        '
        GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "is_check", "no")
        '
        GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "budget_qty", 0)
        GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "budget_value", 0)
        '
        GVBudget.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVBudget_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBudget.CellValueChanged
        calculate()
    End Sub

    Private Sub Battach_Click(sender As Object, e As EventArgs) Handles Battach.Click
        Cursor = Cursors.WaitCursor

        Dim rmt As String = "319"

        FormDocumentUpload.id_report = id_pps
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If is_submit = "1" Then
            FormReportMark.report_mark_type = "319"
            FormReportMark.is_view = is_view
            FormReportMark.id_report = id_pps
            FormReportMark.ShowDialog()
        Else
            Dim q As String = "UPDATE tb_sni_pps SET is_submit=1 WHERE id_sni_pps='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            submit_who_prepared("319", id_pps, id_user)
            infoCustom("Budget submitted")
            load_head()
        End If
    End Sub

    Private Sub FormSNIppsDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSNIBudget.id_pps = id_pps
        ReportSNIBudget.tot_qty = GVProposed.Columns("qty_line_list").SummaryItem.SummaryValue
        Dim Report As New ReportSNIBudget()

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub BLoadTemplate_Click(sender As Object, e As EventArgs) Handles BLoadTemplate.Click
        Cursor = Cursors.WaitCursor
        Dim q As String = "SELECT * FROM tb_sni_pps_template WHERE is_active=1"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        For i = 0 To dt.Rows.Count - 1
            GVBudget.AddNewRow()
            GVBudget.FocusedRowHandle = GVBudget.RowCount - 1
            '
            GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "is_check", "no")
            '
            GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "budget_desc", dt.Rows(i)("desc").ToString)
            GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "budget_qty", dt.Rows(i)("qty"))
            GVBudget.SetRowCellValue(GVBudget.RowCount - 1, "budget_value", dt.Rows(i)("value"))
        Next
        Cursor = Cursors.Default
    End Sub
End Class