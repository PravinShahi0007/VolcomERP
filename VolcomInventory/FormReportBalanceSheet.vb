Public Class FormReportBalanceSheet
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportBalanceSheet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportBalanceSheet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_tag_coa()
        Dim q As String = "SELECT id_coa_tag,tag_description FROM `tb_coa_tag`"
        viewSearchLookupQuery(SLETaxTagCOA, q, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub load_tax_type()
        Dim q As String = "SELECT '0' AS id_tax_report,'ALL PPH' AS tax_report,'1' AS id_type
UNION ALL 
SELECT '-1' AS id_tax_report,'ALL PPN' AS tax_report,'2' AS id_type
UNION ALL 
SELECT id_tax_report,tax_report,id_type FROM tb_lookup_tax_report"
        viewSearchLookupQuery(SLETaxCat, q, "id_tax_report", "tax_report", "id_tax_report")
    End Sub

    Private Sub FormReportBalanceSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DETaxFrom.EditValue = Now
        DETaxUntil.EditValue = Now
        '
        DEMonthlyReport.EditValue = Now
        '
        DEUntil.EditValue = New DateTime(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
        load_unit()
        load_tag_coa()
        load_tax_type()
        SLETaxCat.EditValue = Nothing
        '
        Try
            CreateNodes(TLLedger, "", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub CreateNodes(ByVal tl As DevExpress.XtraTreeList.TreeList, ByVal opt As String, ByVal date_var As Date, ByVal unit As String)
        Dim unit_var As String = ""
        Dim type_var As String = ""

        If Not unit = "0" Then
            unit_var = " AND comp.id_coa_tag='" & unit & "'"
        End If

        If unit = "0" Then
            type_var = " "
        ElseIf unit = "1" Then
            type_var = " AND a.id_coa_type='1'"
        Else
            type_var = " AND a.id_coa_type='2'"
        End If
        '

        tl.ClearNodes()
        tl.BeginUnboundLoad()
        ' Create a root node .
        Dim parentForRootNodes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        'root
        Dim query As String = "SELECT a.id_acc,acc_name,a.id_acc_parent,a.acc_description,CAST(IFNULL(entry.debit,0) AS DECIMAL(13,2)) AS debit,CAST(IFNULL(entry.credit,0) AS DECIMAL(13,2)) AS credit,IFNULL(entry.this_month,0.00) AS this_month,IFNULL(entry.prev_month,0.00) AS prev_month,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,a.id_status,'' as id_all_child,comp.id_comp,comp.comp_name,comp.comp_number FROM tb_a_acc a"
        query += " INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat " & type_var
        query += " INNER JOIN tb_lookup_status c ON a.id_status=c.id_status "
        query += " INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det"
        query += " LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp "
        query += " LEFT JOIN ("
        query += " SELECT atd.id_acc,SUM(atd.debit) AS debit,SUM(atd.credit) AS credit
,SUM(IF(IFNULL(at.date_reference,at.date_created) < DATE_FORMAT('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "' ,'%Y-%m-01') AND IFNULL(at.date_reference,at.date_created) >= DATE_FORMAT(DATE_SUB('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH) ,'%Y-%m-01'),IF(acc.id_dc='2',atd.credit-atd.debit,atd.debit-atd.credit),0)) AS prev_month
,SUM(IF(DATE_FORMAT(IFNULL(at.date_reference,at.date_created),'%m-%Y')=DATE_FORMAT('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "','%m-%Y'),IF(acc.id_dc='2',atd.credit-atd.debit,atd.debit-atd.credit),0)) AS this_month
FROM tb_a_acc_trans_det atd 
INNER JOIN tb_m_comp comp ON comp.id_comp=atd.id_comp
INNER JOIN tb_a_acc acc ON acc.id_acc=atd.id_acc
INNER JOIN tb_a_acc_trans at ON at.id_acc_trans=atd.id_acc_trans AND DATE(at.date_created)<=DATE('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "') " & unit_var & " GROUP BY atd.id_acc"
        query += " ) entry ON entry.id_acc=a.id_acc"
        query += " " & opt

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter As DataRow() = data.Select("[id_acc_parent] is NULL AND [id_status]='1'")

        For i As Integer = 0 To data_filter.Length - 1
            Dim rootNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("prev_month"), data_filter(i)("this_month")}, parentForRootNodes)
            recursive_nodes(data_filter(i)("id_acc").ToString, rootNode, tl, data)
        Next

        ' Create a child node for the node1            
        'tl.AppendNode(New Object() {"Suyama, Michael", "Obere Str. 55", "030-0074263"}, rootNode)
        ' Creating more nodes
        ' ...

        tl.EndUnboundLoad()
        tl.ExpandAll()
    End Sub

    Sub recursive_nodes(ByVal id_acc As String, ByVal parent_nodes As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal tl As DevExpress.XtraTreeList.TreeList, ByVal data_table As DataTable)
        Dim data_filter As DataRow() = data_table.Select("[id_acc_parent]='" & id_acc & "' AND [id_status]='1'")

        If data_filter.Length > 0 Then
            For i As Integer = 0 To data_filter.Length - 1
                Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("prev_month"), data_filter(i)("this_month")}, parent_nodes)
                recursive_nodes(data_filter(i)("id_acc").ToString, newNode, tl, data_table)
                parent_nodes.SetValue("debit", parent_nodes.GetValue("debit") + newNode.GetValue("debit"))
                parent_nodes.SetValue("credit", parent_nodes.GetValue("credit") + newNode.GetValue("credit"))
                parent_nodes.SetValue("this_month", parent_nodes.GetValue("this_month") + newNode.GetValue("this_month"))
                parent_nodes.SetValue("prev_month", parent_nodes.GetValue("prev_month") + newNode.GetValue("prev_month"))

                If data_filter(i)("id_is_det").ToString = "2" Then
                    If parent_nodes.GetValue("id_all_child") = "" Then
                        parent_nodes.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                    Else
                        parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & data_filter(i)("id_acc").ToString)
                    End If
                    newNode.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                Else
                    If Not newNode.GetValue("id_all_child").ToString = "" Then
                        If parent_nodes.GetValue("id_all_child") = "" Then
                            parent_nodes.SetValue("id_all_child", newNode.GetValue("id_all_child").ToString)
                        Else
                            parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & newNode.GetValue("id_all_child").ToString)
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Then
            CreateNodes(TLLedger, "", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 1 Then
            If XTCBS.SelectedTabPageIndex = 0 Then
                CreateNodes(TLBalanceSheet, " WHERE b.is_balance_sheet='1'", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
            ElseIf XTCBS.SelectedTabPageIndex = 1 Then
                load_report(GCAktiva, "1", Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd"), SLEUnit.EditValue.ToString)
                GVAktiva.BestFitColumns()
                GVAktiva.ExpandAllGroups()
                load_report(GCPasiva, "2", Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd"), SLEUnit.EditValue.ToString)
                GVPasiva.BestFitColumns()
                GVPasiva.ExpandAllGroups()
            End If
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            If XTCProfitAndLoss.SelectedTabPageIndex = 0 Then
                CreateNodes(TLProfitAndLoss, " WHERE b.is_profit_loss='1'", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
            ElseIf XTCProfitAndLoss.SelectedTabPageIndex = 1 Then
                load_report_pl(GCProfitAndLoss, Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd"), SLEUnit.EditValue.ToString)
                GVProfitAndLoss.BestFitColumns()
                GVProfitAndLoss.ExpandAllGroups()
            End If
        End If
    End Sub

    Sub load_report(ByVal gc As DevExpress.XtraGrid.GridControl, ByVal opt As String, ByVal date_until As String, ByVal unit As String)
        Dim date_str As String = date_until
        Dim unit_str As String = unit
        Dim query As String = "CALL acc_show_report('" & date_str & "','" & opt & "','" & unit_str & "')"
        gc.DataSource = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Sub load_report_pl(ByVal gc As DevExpress.XtraGrid.GridControl, ByVal date_until As String, ByVal unit_str As String)
        Dim query As String = "CALL acc_report_profit_loss('" & date_until & "','" & unit_str & "')"
        Console.WriteLine(query)
        gc.DataSource = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEUntil.EditValue = New DateTime(DEUntil.EditValue.Year, DEUntil.EditValue.Month, Date.DaysInMonth(DEUntil.EditValue.Year, DEUntil.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCBS_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBS.SelectedPageChanged
        If XTCBS.SelectedTabPageIndex = 1 Then
            SplitterBS.SplitterPosition = SplitterBS.Width / 2
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Then
            print_treelist(TLLedger, "Ledger")
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 1 Then
            If XTCBS.SelectedTabPageIndex = 0 Then
                print_treelist(TLBalanceSheet, "Balance Sheet")
            ElseIf XTCBS.SelectedTabPageIndex = 1 Then
                print_bs()
            End If
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            If XTCProfitAndLoss.SelectedTabPageIndex = 0 Then
                print_treelist(TLProfitAndLoss, "Profit And Loss")
            ElseIf XTCProfitAndLoss.SelectedTabPageIndex = 1 Then
                print_custom(GCProfitAndLoss, "Profit And Loss (Unit : " & SLEUnit.Text & ")" & vbNewLine & "Until : " & Date.Parse(DEUntil.EditValue.ToString).ToString("MMMM yyyy"))
            End If
        End If
    End Sub

    Sub print_bs()
        Cursor = Cursors.WaitCursor
        Dim Report As New ReportBalanceSheet()

        Report.Lunit.Text = SLEUnit.Text
        Report.LUntil1.Text = " Until : " & Date.DaysInMonth(Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).Year, Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).Month).ToString & " " & Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).ToString("MMMM yyyy")
        Report.LUntil2.Text = " Until : " & Date.DaysInMonth(Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).Year, Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).Month).ToString & " " & Date.Parse(DEUntil.EditValue.ToString).AddMonths(-1).ToString("MMMM yyyy")

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub XTCBalanceSheet_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBalanceSheet.SelectedPageChanged
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Or XTCBalanceSheet.SelectedTabPageIndex = 1 Or XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            PCFilterUpper.Visible = True
        Else
            PCFilterUpper.Visible = False
        End If

        If XTCBalanceSheet.SelectedTabPageIndex = 4 Then
            SplitContainerControl1.SplitterPosition = SplitContainerControl1.Width / 2
        End If
    End Sub

    Sub view_pajak()
        If XTPTaxDetail.SelectedTabPageIndex = 0 Then
            If SLETaxCat.Properties.View.GetFocusedRowCellValue("id_type").ToString = "2" Then 'PPN
                GridColumnPPNPPH.Caption = "PPN (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    q_where += " AND atx.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- input manual
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.id_acc AND acc_pph.`is_tax_report`=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE ISNULL(atx.`date_tax_report`) AND atx.`date_reference` AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
-- dari persenan
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,AVG(ied.`tax_percent`) AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`tax_value`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6 AND ied.`tax_percent` > 0
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=(SELECT acc_coa_vat_in FROM tb_opt_purchasing)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
SELECT 'no' AS is_check,bpl.tax_report,bpl.report_mark_type,bpl.id_acc_trans,bpl.inv_number,bpl.jurnal_no,bpl.id_report,bpl.`comp_number`,bpl.`comp_name`,bpl.`npwp_name`,bpl.`npwp`,bpl.`npwp_address`,bpl.`number`,bpl.`date_reference`,bpl.description,bpl.`id_acc_pph`,bpl.`due_date`,bpl.`acc_name`,bpl.`acc_description`,AVG(pph_percent) AS pph_percent,SUM(bpl.`dpp`) AS dpp,SUM(bpl.`pph`) AS pph 
FROM
(
    SELECT rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,((ied.`vat`/ied.value)*100) AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`vat`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ie.`id_acc_vat`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    LEFT JOIN
    ( 
        SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
        FROM tb_a_acc_trans_det atd 
        INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
        INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 
        INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
        WHERE atd.`report_mark_type`='189'
        GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
    ) atx ON atx.id_report=ie.`id_pn_fgpo`
    WHERE ied.`vat`!=0 
    AND ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
    UNION ALL
    SELECT rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,(10) AS pph_percent,SUM((100/10)*ied.`value`) AS dpp,SUM(ied.`value`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    LEFT JOIN
    ( 
        SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
        FROM tb_a_acc_trans_det atd 
        INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
        INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 
        INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
        WHERE atd.`report_mark_type`='189'
        GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
    ) atx ON atx.id_report=ie.`id_pn_fgpo`
    WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
)bpl
GROUP BY bpl.`id_acc_pph`,bpl.id_acc_trans,bpl.report_mark_type
UNION ALL
-- OG
SELECT 'no' AS is_check,rpt.tax_report,148 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,rec.`id_purc_rec` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`purc_order_number` AS number,atx.`date_reference`,rd.item_detail AS description,ie.`pph_account`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ie.`vat_percent` AS pph_percent,SUM(recd.qty*ied.`value`)-ie.disc_value AS dpp,SUM((recd.qty*ied.`value`)*(ie.`vat_percent`/100))-(ie.disc_value*(ie.`vat_percent`/100)) AS pph 
FROM tb_purc_rec_det recd
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec
INNER JOIN tb_purc_order_det ied ON ied.id_purc_order_det=recd.id_purc_order_det
INNER JOIN tb_purc_req_det rd ON rd.id_purc_req_det=ied.id_purc_req_det
INNER JOIN `tb_purc_order` ie ON ie.id_purc_order=ied.id_purc_order AND ie.`vat_percent` > 0 
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=(SELECT acc_coa_vat_in FROM tb_opt_purchasing) AND ie.`id_report_status`=6
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ie.id_comp_contact
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='148'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=recd.`id_purc_rec`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
-- per jurnal kata bu mar
-- GROUP BY ied.id_purc_order_det
GROUP BY atx.id_acc_trans
HAVING NOT ISNULL(jurnal_no)
UNION ALL
-- BUM
SELECT 'no' AS is_check,rpt.tax_report,36 AS report_mark_type,tr.id_acc_trans,atx.`report_number_ref` AS inv_number,tr.acc_trans_number AS jurnal_no,atx.`id_acc_trans` AS id_report,atx.`vendor` AS `comp_number`,atx.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,tr.acc_trans_number AS `number`,tr.`date_reference`,atx.`acc_trans_det_note` AS description,atx.`id_acc`,tr.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,IF(acc_pph.`id_dc`=1,atx.`debit`,atx.`credit`) AS dpp,IF(acc_pph.`id_dc`=1,atx.`debit`,atx.`credit`) AS pph 
FROM tb_a_acc_trans_det atx
INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atx.`id_acc_trans` AND tr.id_report_status=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=atx.id_acc AND acc_pph.is_tax_report=1 AND (tr.`id_bill_type`=25 OR tr.`id_bill_type`=7 OR tr.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
WHERE ISNULL(tr.`date_tax_report`) AND DATE(tr.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(tr.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT 'no' AS is_check,rpt.tax_report,162 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,-1 * SUM(ied.`value`) AS dpp,-1 *SUM(ied.`value`) AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1'
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='162'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_rec_payment`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ied.id_acc,ie.`id_rec_payment`
UNION ALL
-- BBK
SELECT 'no' AS is_check,rpt.tax_report,159 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.id_dc=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='159'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCTaxReport.DataSource = dt
                GVTaxReport.BestFitColumns()
            Else 'PPH
                GridColumnPPNPPH.Caption = "PPH (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    q_where += " AND atx.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- expense input manual
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,-SUM(ied.`amount`) AS dpp,-SUM(ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` 
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc
UNION ALL
-- expense percent
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`pph`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc_pph
UNION ALL
-- bpl
SELECT 'no' AS is_check,rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`pph`) AS pph 
FROM tb_pn_fgpo_det ied
INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='189'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn_fgpo`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_pn_fgpo,ied.id_acc_pph
UNION ALL
-- OG
SELECT 'no' AS is_check,rpt.tax_report,148 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,rec.`id_purc_rec` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`purc_order_number` AS number,atx.`date_reference`,rd.item_detail AS description,ie.`pph_account`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM((recd.qty*(ied.`value`))-ied.discount_for_pph+ied.`gross_up_value`) AS dpp, SUM(ied.pph) AS pph 
FROM tb_purc_rec_det recd
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec
INNER JOIN tb_purc_order_det ied ON ied.id_purc_order_det=recd.id_purc_order_det
INNER JOIN tb_purc_req_det rd ON rd.id_purc_req_det=ied.id_purc_req_det
INNER JOIN `tb_purc_order` ie ON ie.id_purc_order=ied.id_purc_order AND ied.`pph_percent` > 0 
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ie.`pph_account` AND ie.`id_report_status`=6 AND ie.is_close_rec=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ie.id_comp_contact
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='148'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=recd.`id_purc_rec`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
-- per jurnal kata bu mar
-- GROUP BY ied.id_purc_order_det
GROUP BY atx.id_acc_trans
HAVING NOT ISNULL(jurnal_no)
UNION ALL
-- BUM, cash advance BKK, BKM
SELECT 'no' AS is_check,rpt.tax_report,36 AS report_mark_type,tr.id_acc_trans,atx.`report_number_ref` AS inv_number,tr.acc_trans_number AS jurnal_no,atx.`id_acc_trans` AS id_report,atx.`vendor` AS `comp_number`,atx.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,tr.acc_trans_number AS `number`,tr.`date_reference`,atx.`acc_trans_det_note` AS description,atx.`id_acc`,tr.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,(-atx.`debit`+atx.`credit`) AS dpp,(-atx.`debit`+atx.`credit`) AS pph 
FROM tb_a_acc_trans_det atx
INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atx.`id_acc_trans` AND tr.id_report_status=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=atx.id_acc AND acc_pph.is_tax_report=1 AND (tr.`id_bill_type`=25 OR tr.`id_bill_type`=7 OR tr.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
WHERE ISNULL(tr.`date_tax_report`) AND DATE(tr.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(tr.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT 'no' AS is_check,rpt.tax_report,162 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`value`) AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' 
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='162'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_rec_payment`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ied.id_acc,ie.`id_rec_payment`
UNION ALL
-- BBK
SELECT 'no' AS is_check,rpt.tax_report,159 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.id_dc=2
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='159'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn`
WHERE ISNULL(atx.`date_tax_report`) AND DATE(atx.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCTaxReport.DataSource = dt
                GVTaxReport.BestFitColumns()
            End If
            GVTaxReport.BestFitColumns()
            GVTaxReport.ExpandAllGroups()
        ElseIf XTPTaxDetail.SelectedTabPageIndex = 1 Then 'pending transaction
            If SLETaxCat.Properties.View.GetFocusedRowCellValue("id_type").ToString = "2" Then 'PPN pending
                GridColumnPPNPPH.Caption = "PPN (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                Dim where_coa_tag As String = ""

                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    where_coa_tag += " AND ie.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- expense
-- input manual
SELECT rpt.tax_report,157 AS report_mark_type,ie.inv_number AS inv_number,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`date_reff` AS date_reference,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.id_acc AND acc_pph.`is_tax_report`=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
WHERE DATE(ie.`date_reff`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_reff`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
-- dari persenan
SELECT rpt.tax_report,157 AS report_mark_type,ie.inv_number AS inv_number,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`date_reff` AS date_reference,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,AVG(ied.`tax_percent`) AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`tax_value`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 AND ied.`tax_percent` > 0 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=(SELECT acc_coa_vat_in FROM tb_opt_purchasing)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
WHERE DATE(ie.`date_reff`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_reff`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
SELECT bpl.tax_report,bpl.report_mark_type,bpl.inv_number,bpl.id_report,bpl.`comp_number`,bpl.`comp_name`,bpl.`npwp_name`,bpl.`npwp`,bpl.`npwp_address`,bpl.`number`,bpl.`date_reference`,bpl.description,bpl.`id_acc_pph`,bpl.`due_date`,bpl.`acc_name`,bpl.`acc_description`,AVG(pph_percent) AS pph_percent,SUM(bpl.`dpp`) AS dpp,SUM(bpl.`pph`) AS pph 
FROM
(
    SELECT rpt.tax_report,189 AS report_mark_type,ied.inv_number AS inv_number,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`ref_date` AS date_reference,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,((ied.`vat`/ied.value)*100) AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`vat`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`!=6 AND  ie.`id_report_status`!=5  " + where_coa_tag + "
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ie.`id_acc_vat`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    WHERE ied.`vat`!=0 
    AND DATE(ie.`ref_date`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`ref_date`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
    UNION ALL
    SELECT rpt.tax_report,189 AS report_mark_type,ied.inv_number AS inv_number,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`ref_date` AS date_reference,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,(10) AS pph_percent,SUM((100/10)*ied.`value`) AS dpp,SUM(ied.`value`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`!=6 AND  ie.`id_report_status`!=5  " + where_coa_tag + "
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    WHERE DATE(ie.`ref_date`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`ref_date`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
)bpl
GROUP BY bpl.`id_acc_pph`,bpl.id_report,bpl.report_mark_type
UNION ALL
-- BUM
SELECT rpt.tax_report,36 AS report_mark_type,ie.`report_number_ref` AS inv_number,ie.`id_acc_trans` AS id_report,ie.`vendor` AS `comp_number`,ie.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,ieh.acc_trans_number AS `number`,ieh.`date_reference`,ie.`acc_trans_det_note` AS description,ie.`id_acc`,ieh.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,IF(acc_pph.`id_dc`=1,ie.`debit`,ie.`credit`) AS dpp,IF(acc_pph.`id_dc`=1,ie.`debit`,ie.`credit`) AS pph 
FROM tb_a_acc_trans_det ie
INNER JOIN tb_a_acc_trans ieh ON ieh.`id_acc_trans`=ie.`id_acc_trans` AND ieh.id_report_status!=5 AND ieh.id_report_status!=6  " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=ie.id_acc AND acc_pph.is_tax_report=1 AND (ieh.`id_bill_type`=25 OR ieh.`id_bill_type`=7 OR ieh.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
WHERE DATE(ieh.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ieh.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT rpt.tax_report,162 AS report_mark_type,ied.number AS inv_number,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,ie.`date_received` AS date_reference,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,-1 * ied.`value` AS dpp,-1 *ied.`value` AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.id_report_status!=5 AND ie.id_report_status!=6  " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1'
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE DATE(ie.`date_received`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_received`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBK
SELECT rpt.tax_report,159 AS report_mark_type,ied.number AS inv_number,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,ie.`date_payment` AS date_reference,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.id_report_status!=5 AND ie.id_report_status!=6  " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.value<0
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
WHERE DATE(ie.`date_payment`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_payment`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCTaxPending.DataSource = dt
                GVTaxPending.BestFitColumns()
            Else 'PPH pending
                GridColumnPPNPPH.Caption = "PPH (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                Dim where_coa_tag As String = ""

                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    where_coa_tag += " AND ie.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- expense input manual
SELECT rpt.tax_report,157 AS report_mark_type,ie.inv_number AS inv_number,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`date_reff` AS date_reference,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
WHERE DATE(ie.`date_reff`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_reff`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc
UNION ALL
-- expense dari percent
SELECT rpt.tax_report,157 AS report_mark_type,ie.inv_number AS inv_number,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`date_reff` AS date_reference,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`pph`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph` AND ied.pph_percent>0
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
WHERE DATE(ie.`date_reff`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_reff`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc
UNION ALL
-- bpl
SELECT rpt.tax_report,189 AS report_mark_type,ied.inv_number AS inv_number,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,ie.`ref_date` AS date_reference,ied.info_design AS description,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,ied.`value` AS dpp,ied.`pph` AS pph 
FROM tb_pn_fgpo_det ied
INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
WHERE DATE(ie.`ref_date`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`ref_date`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BUM
SELECT rpt.tax_report,36 AS report_mark_type,ie.`report_number_ref` AS inv_number,ie.`id_acc_trans` AS id_report,ie.`vendor` AS `comp_number`,ie.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,ieh.acc_trans_number AS `number`,ieh.`date_reference`,ie.`acc_trans_det_note` AS description,ie.`id_acc`,ieh.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,IF(acc_pph.`id_dc`=1,ie.`debit`,ie.`credit`) AS dpp,IF(acc_pph.`id_dc`=1,ie.`debit`,ie.`credit`) AS pph 
FROM tb_a_acc_trans_det ie
INNER JOIN tb_a_acc_trans ieh ON ieh.`id_acc_trans`=ie.`id_acc_trans` AND ieh.`id_report_status`!=6 AND ieh.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=ie.id_acc AND acc_pph.is_tax_report=1 AND (ieh.`id_bill_type`=25 OR ieh.`id_bill_type`=7 OR ieh.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
WHERE DATE(ieh.`date_reference`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ieh.`date_reference`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT rpt.tax_report,162 AS report_mark_type,ied.number AS inv_number,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,ie.`date_received` AS date_reference,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ied.`value` AS dpp,ied.`value` AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' 
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE DATE(ie.`date_received`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_received`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBK
SELECT rpt.tax_report,159 AS report_mark_type,ied.number AS inv_number,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,ie.`date_payment` AS date_reference,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.`id_report_status`!=6 AND ie.`id_report_status`!=5 " + where_coa_tag + "
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.value<0
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
WHERE DATE(ie.`date_payment`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(ie.`date_payment`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCTaxPending.DataSource = dt
                GVTaxPending.BestFitColumns()
            End If
            GVTaxPending.BestFitColumns()
            GVTaxPending.ExpandAllGroups()
        ElseIf XTPTaxDetail.SelectedTabPageIndex = 2 Then 'tax summary
            If SLETaxCat.Properties.View.GetFocusedRowCellValue("id_type").ToString = "2" Then 'PPN
                GridColumnPPNPPH.Caption = "PPN (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    q_where += " AND atx.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- input manual
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.id_acc AND acc_pph.`is_tax_report`=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
-- dari persenan
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,AVG(ied.`tax_percent`) AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`tax_value`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6 AND ied.`tax_percent` > 0
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=(SELECT acc_coa_vat_in FROM tb_opt_purchasing)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense
UNION ALL
SELECT 'no' AS is_check,bpl.tax_report,bpl.report_mark_type,bpl.id_acc_trans,bpl.inv_number,bpl.jurnal_no,bpl.id_report,bpl.`comp_number`,bpl.`comp_name`,bpl.`npwp_name`,bpl.`npwp`,bpl.`npwp_address`,bpl.`number`,bpl.`date_reference`,bpl.description,bpl.`id_acc_pph`,bpl.`due_date`,bpl.`acc_name`,bpl.`acc_description`,AVG(pph_percent) AS pph_percent,SUM(bpl.`dpp`) AS dpp,SUM(bpl.`pph`) AS pph 
FROM
(
    SELECT rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,((ied.`vat`/ied.value)*100) AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`vat`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ie.`id_acc_vat`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    LEFT JOIN
    ( 
        SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
        FROM tb_a_acc_trans_det atd 
        INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
        INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 
        INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
        WHERE atd.`report_mark_type`='189'
        GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
    ) atx ON atx.id_report=ie.`id_pn_fgpo`
    WHERE ied.`vat`!=0 
    AND DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
    UNION ALL
    SELECT rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,acc_pph.id_acc AS `id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,(10) AS pph_percent,SUM((100/10)*ied.`value`) AS dpp,SUM(ied.`value`) AS pph 
    FROM tb_pn_fgpo_det ied
    INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
    INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc`
    INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
    INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
    LEFT JOIN
    ( 
        SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
        FROM tb_a_acc_trans_det atd 
        INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
        INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 
        INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
        WHERE atd.`report_mark_type`='189'
        GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
    ) atx ON atx.id_report=ie.`id_pn_fgpo`
    WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
    GROUP BY ied.`id_pn_fgpo`
)bpl
GROUP BY bpl.`id_acc_pph`,bpl.id_acc_trans,bpl.report_mark_type
UNION ALL
-- OG
SELECT 'no' AS is_check,rpt.tax_report,148 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,rec.`id_purc_rec` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`purc_order_number` AS number,atx.`date_reference`,rd.item_detail AS description,ie.`pph_account`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ie.`vat_percent` AS pph_percent,SUM(recd.qty*ied.`value`)-ie.disc_value AS dpp,SUM((recd.qty*ied.`value`)*(ie.`vat_percent`/100))-(ie.disc_value*(ie.`vat_percent`/100)) AS pph 
FROM tb_purc_rec_det recd
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec
INNER JOIN tb_purc_order_det ied ON ied.id_purc_order_det=recd.id_purc_order_det
INNER JOIN tb_purc_req_det rd ON rd.id_purc_req_det=ied.id_purc_req_det
INNER JOIN `tb_purc_order` ie ON ie.id_purc_order=ied.id_purc_order AND ie.`vat_percent` > 0 
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=(SELECT acc_coa_vat_in FROM tb_opt_purchasing) AND ie.`id_report_status`=6
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ie.id_comp_contact
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='148'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=recd.`id_purc_rec`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
-- per jurnal kata bu mar
-- GROUP BY ied.id_purc_order_det
GROUP BY atx.id_acc_trans
HAVING NOT ISNULL(jurnal_no)
UNION ALL
-- BUM
SELECT 'no' AS is_check,rpt.tax_report,36 AS report_mark_type,tr.id_acc_trans,atx.`report_number_ref` AS inv_number,tr.acc_trans_number AS jurnal_no,atx.`id_acc_trans` AS id_report,atx.`vendor` AS `comp_number`,atx.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,tr.acc_trans_number AS `number`,tr.`date_reference`,atx.`acc_trans_det_note` AS description,atx.`id_acc`,tr.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent
-- ,IF(acc_pph.`id_dc`=1,atx.`debit`,atx.`credit`) AS dpp
-- ,IF(acc_pph.`id_dc`=1,atx.`debit`,atx.`credit`) AS pph 
,IF(acc_pph.`id_dc`=1,IF(atx.`credit`>0,-atx.`credit`,atx.`debit`),IF(atx.`credit`>0,atx.`credit`,-atx.`debit`)) AS dpp
,IF(acc_pph.`id_dc`=1,IF(atx.`credit`>0,-atx.`credit`,atx.`debit`),IF(atx.`credit`>0,atx.`credit`,-atx.`debit`)) AS pph 
FROM tb_a_acc_trans_det atx
INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atx.`id_acc_trans` AND tr.id_report_status=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=atx.id_acc AND acc_pph.is_tax_report=1 AND (tr.`id_bill_type`=25 OR tr.`id_bill_type`=7 OR tr.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
WHERE DATE(tr.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(tr.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT 'no' AS is_check,rpt.tax_report,162 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,-1 * SUM(ied.`value`) AS dpp,-1 *SUM(ied.`value`) AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1'
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='162'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_rec_payment`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ied.id_acc,ie.`id_rec_payment`
UNION ALL
-- BBK
SELECT 'no' AS is_check,rpt.tax_report,159 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.id_dc=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=2
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=2
    WHERE atd.`report_mark_type`='159'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCActiveTax.DataSource = dt
                GVActiveTax.BestFitColumns()
            Else 'PPH
                GridColumnPPNPPH.Caption = "PPH (%)"
                Dim q_where As String = ""
                Dim q_where_atx As String = ""
                q_where_atx += " AND a.id_acc !='" & get_opt_acc_field("id_acc_skbp") & "' "
                If Not SLETaxCat.EditValue.ToString = "0" And Not SLETaxCat.EditValue.ToString = "-1" Then
                    q_where += " AND acc_pph.id_tax_report='" & SLETaxCat.EditValue.ToString & "' "
                    q_where_atx += " AND a.id_tax_report='" & SLETaxCat.EditValue.ToString & "'"
                End If

                If Not SLETaxTagCOA.EditValue.ToString = "0" Then
                    q_where += " AND atx.id_coa_tag='" & SLETaxTagCOA.EditValue.ToString & "' "
                End If

                Dim q As String = ""
                q = "-- expense input manual
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(-ied.`amount`) AS dpp,SUM(-ied.`amount`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` 
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc
UNION ALL
-- expense percent
SELECT 'no' AS is_check,rpt.tax_report,157 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_item_expense` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.`description`,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM(ied.`amount`) AS dpp,SUM(ied.`pph`) AS pph 
FROM tb_item_expense_det ied
INNER JOIN tb_item_expense ie ON ie.`id_item_expense`=ied.`id_item_expense` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='157'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_item_expense`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_item_expense,ied.id_acc_pph
UNION ALL
-- bpl
SELECT 'no' AS is_check,rpt.tax_report,189 AS report_mark_type,atx.id_acc_trans,ied.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn_fgpo` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`number`,atx.`date_reference`,ied.info_design AS description,ied.`id_acc_pph`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`pph`) AS pph 
FROM tb_pn_fgpo_det ied
INNER JOIN tb_pn_fgpo ie ON ie.`id_pn_fgpo`=ied.`id_pn_fgpo` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc_pph`
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp c ON c.`id_comp`=ie.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='189'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn_fgpo`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ie.id_pn_fgpo,ied.id_acc_pph
UNION ALL
-- OG
SELECT 'no' AS is_check,rpt.tax_report,148 AS report_mark_type,atx.id_acc_trans,ie.inv_number AS inv_number,atx.acc_trans_number AS jurnal_no,rec.`id_purc_rec` AS id_report,c.`comp_number`,c.`comp_name`,c.`npwp_name`,c.`npwp`,c.`npwp_address`,ie.`purc_order_number` AS number,atx.`date_reference`,rd.item_detail AS description,ie.`pph_account`,ie.`due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,ied.`pph_percent` AS pph_percent,SUM((recd.qty*(ied.`value`))-ied.discount_for_pph+ied.`gross_up_value`) AS dpp, SUM(ied.pph) AS pph 
FROM tb_purc_rec_det recd
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec
INNER JOIN tb_purc_order_det ied ON ied.id_purc_order_det=recd.id_purc_order_det
INNER JOIN tb_purc_req_det rd ON rd.id_purc_req_det=ied.id_purc_req_det
INNER JOIN `tb_purc_order` ie ON ie.id_purc_order=ied.id_purc_order AND ied.`pph_percent` > 0 
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ie.`pph_account` AND ie.`id_report_status`=6 AND ie.is_close_rec=1
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ie.id_comp_contact
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='148'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=recd.`id_purc_rec`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
-- per jurnal kata bu mar
-- GROUP BY ied.id_purc_order_det
GROUP BY atx.id_acc_trans
HAVING NOT ISNULL(jurnal_no)
UNION ALL
-- BUM
SELECT 'no' AS is_check,rpt.tax_report,36 AS report_mark_type,tr.id_acc_trans,atx.`report_number_ref` AS inv_number,tr.acc_trans_number AS jurnal_no,atx.`id_acc_trans` AS id_report,atx.`vendor` AS `comp_number`,atx.`vendor` AS `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`
,tr.acc_trans_number AS `number`,tr.`date_reference`,atx.`acc_trans_det_note` AS description,atx.`id_acc`,tr.`date_reference` AS `due_date`,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,(-atx.`debit`+atx.`credit`) AS dpp,(-atx.`debit`+atx.`credit`) AS pph 
FROM tb_a_acc_trans_det atx
INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atx.`id_acc_trans` AND tr.id_report_status=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=atx.id_acc AND acc_pph.is_tax_report=1 AND (tr.`id_bill_type`=25 OR tr.`id_bill_type`=7 OR tr.`id_bill_type`=8)
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
WHERE DATE(tr.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(tr.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
UNION ALL
-- BBM
SELECT 'no' AS is_check,rpt.tax_report,162 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_rec_payment` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_received` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,SUM(ied.`value`) AS dpp,SUM(ied.`value`) AS pph 
FROM tb_rec_payment_det ied
INNER JOIN tb_rec_payment ie ON ie.`id_rec_payment`=ied.`id_rec_payment` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' 
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
-- INNER JOIN tb_sales_pos pos ON ied.`id_report`=pos.`id_sales_pos`
-- INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pos.`id_store_contact_from`
-- INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='162'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_rec_payment`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
GROUP BY ied.id_acc,ie.`id_rec_payment`
UNION ALL
-- BBK
SELECT 'no' AS is_check,rpt.tax_report,159 AS report_mark_type,atx.id_acc_trans,ied.number AS inv_number,atx.acc_trans_number AS jurnal_no,ie.`id_pn` AS id_report,ied.`vendor` AS `comp_number`,ied.`vendor` AS  `comp_name`,'' AS `npwp_name`,'' AS `npwp`,'' AS `npwp_address`,ie.`number`,atx.`date_reference`,ied.note AS description,ied.id_acc AS `id_acc_pph`,ie.`date_payment` AS due_date,acc_pph.`acc_name`,acc_pph.`acc_description`,100 AS pph_percent,ABS(ied.`value`) AS dpp,ABS(ied.`value`) AS pph 
FROM tb_pn_det ied
INNER JOIN tb_pn ie ON ie.`id_pn`=ied.`id_pn` AND ie.`id_report_status`=6
INNER JOIN tb_a_acc acc_pph ON acc_pph.`id_acc`=ied.`id_acc` AND acc_pph.`is_tax_report`='1' AND ied.value<0
INNER JOIN tb_lookup_tax_report rpt ON rpt.id_tax_report=acc_pph.id_tax_report AND rpt.id_type=1
LEFT JOIN
( 
    SELECT atd.id_report,tr.`acc_trans_number`,tr.date_reference,tr.date_tax_report,atd.id_coa_tag,tr.id_acc_trans
    FROM tb_a_acc_trans_det atd 
    INNER JOIN tb_a_acc_trans tr ON tr.`id_acc_trans`=atd.`id_acc_trans`
    INNER JOIN tb_a_acc a ON a.id_acc=atd.id_acc AND a.is_tax_report=1 " & q_where_atx & "
    INNER JOIN tb_lookup_tax_report t ON t.id_tax_report=a.id_tax_report AND t.id_type=1
    WHERE atd.`report_mark_type`='159'
    GROUP BY atd.`id_report`,atd.`id_acc_trans`,atd.id_coa_tag
) atx ON atx.id_report=ie.`id_pn`
WHERE DATE(atx.`date_tax_report`)>='" + Date.Parse(DETaxFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND DATE(atx.`date_tax_report`)<='" + Date.Parse(DETaxUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + q_where + "
"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                GCActiveTax.DataSource = dt
                GVActiveTax.BestFitColumns()
            End If
            GVActiveTax.BestFitColumns()
            GVActiveTax.ExpandAllGroups()
        End If
    End Sub

    Private Sub BViewPajak_Click(sender As Object, e As EventArgs) Handles BViewPajak.Click
        If Not SLETaxCat.EditValue = Nothing Then
            view_pajak()
        End If
    End Sub

    Private Sub BPrintPajak_Click(sender As Object, e As EventArgs) Handles BPrintPajak.Click
        If XTPTaxDetail.SelectedTabPageIndex = 0 Then
            GVTaxReport.Columns("is_check").Visible = False
            GridColumnAlamatNPWP.Visible = False
            Dim font_row_default As New Font(GVTaxReport.AppearancePrint.Row.Font.FontFamily, GVTaxReport.AppearancePrint.Row.Font.Size, GVTaxReport.AppearancePrint.Row.Font.Style)
            Dim font_row_style As New Font("Segoe UI", 6.5, FontStyle.Regular)
            Dim font_row_name As New Font("Segoe UI", 6, FontStyle.Regular)

            GVTaxReport.AppearancePrint.HeaderPanel.Font = font_row_style
            GVTaxReport.AppearancePrint.FooterPanel.Font = font_row_style
            GVTaxReport.AppearancePrint.GroupFooter.Font = font_row_style
            GVTaxReport.AppearancePrint.Row.Font = font_row_style
            GVTaxReport.Columns("comp_name").AppearanceCell.Font = font_row_name
            GVTaxReport.Columns("npwp_name").AppearanceCell.Font = font_row_name
            '
            print_no_footer_custom(GCTaxReport, "TAX REPORT" & vbNewLine & SLETaxCat.Text & vbNewLine & "Periode : (" & Date.Parse(DETaxFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(DETaxUntil.EditValue.ToString).ToString("dd MMMM yyyy") & ")" & vbNewLine & "Unit : " & SLETaxTagCOA.Text)
            '
            GVTaxReport.AppearancePrint.Row.Font = font_row_default
            GVTaxReport.AppearancePrint.HeaderPanel.Font = font_row_default
            GVTaxReport.AppearancePrint.FooterPanel.Font = font_row_default
            GVTaxReport.AppearancePrint.GroupFooter.Font = font_row_default
            GVTaxReport.Columns("comp_name").AppearanceCell.Font = font_row_default
            GVTaxReport.Columns("npwp_name").AppearanceCell.Font = font_row_default
            GridColumnAlamatNPWP.Visible = True
            GVTaxReport.Columns("is_check").Visible = True
        ElseIf XTPTaxDetail.SelectedTabPageIndex = 1 Then

        ElseIf XTPTaxDetail.SelectedTabPageIndex = 2 Then
            GVActiveTax.Columns("is_check").Visible = False
            GVActiveTax.Columns("npwp_address").Visible = False
            Dim font_row_default As New Font(GVActiveTax.AppearancePrint.Row.Font.FontFamily, GVActiveTax.AppearancePrint.Row.Font.Size, GVActiveTax.AppearancePrint.Row.Font.Style)
            Dim font_row_style As New Font("Segoe UI", 6.5, FontStyle.Regular)
            Dim font_row_name As New Font("Segoe UI", 6, FontStyle.Regular)

            GVActiveTax.AppearancePrint.HeaderPanel.Font = font_row_style
            GVActiveTax.AppearancePrint.FooterPanel.Font = font_row_style
            GVActiveTax.AppearancePrint.GroupFooter.Font = font_row_style
            GVActiveTax.AppearancePrint.Row.Font = font_row_style
            GVActiveTax.Columns("comp_name").AppearanceCell.Font = font_row_name
            GVActiveTax.Columns("npwp_name").AppearanceCell.Font = font_row_name
            '
            print_no_footer_custom(GCActiveTax, "TAX REPORT" & vbNewLine & SLETaxCat.Text & vbNewLine & "Periode : (" & Date.Parse(DETaxFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(DETaxUntil.EditValue.ToString).ToString("dd MMMM yyyy") & ")" & vbNewLine & "Unit : " & SLETaxTagCOA.Text & vbNewLine & vbNewLine)
            '
            GVActiveTax.AppearancePrint.Row.Font = font_row_default
            GVActiveTax.AppearancePrint.HeaderPanel.Font = font_row_default
            GVActiveTax.AppearancePrint.FooterPanel.Font = font_row_default
            GVActiveTax.AppearancePrint.GroupFooter.Font = font_row_default
            GVActiveTax.Columns("comp_name").AppearanceCell.Font = font_row_default
            GVActiveTax.Columns("npwp_name").AppearanceCell.Font = font_row_default
            GVActiveTax.Columns("npwp_address").Visible = True
            GVActiveTax.Columns("is_check").Visible = True
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Try
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.opt = "Buku Besar"
            If XTPTaxDetail.SelectedTabPageIndex = 0 Then
                showpopup.report_mark_type = GVTaxReport.GetFocusedRowCellValue("report_mark_type").ToString
                showpopup.id_report = GVTaxReport.GetFocusedRowCellValue("id_report").ToString
            ElseIf XTPTaxDetail.selectedtabpageindex = 1 Then
                showpopup.report_mark_type = GVTaxPending.GetFocusedRowCellValue("report_mark_type").ToString
                showpopup.id_report = GVTaxPending.GetFocusedRowCellValue("id_report").ToString
            ElseIf XTPTaxDetail.SelectedTabPageIndex = 2 Then
                showpopup.report_mark_type = GVActiveTax.GetFocusedRowCellValue("report_mark_type").ToString
                showpopup.id_report = GVActiveTax.GetFocusedRowCellValue("id_report").ToString
            End If
            showpopup.show()
        Catch ex As Exception
            stopCustom("Document Not Found")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ViewJournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewJournalToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTPTaxDetail.SelectedTabPageIndex = 0 Then
            Dim id_acc_trans As String = GVTaxReport.GetFocusedRowCellValue("id_acc_trans").ToString

            If id_acc_trans <> "0" Then
                Dim s As New ClassShowPopUp()

                FormViewJournal.is_enable_view_doc = False
                FormViewJournal.BMark.Visible = False

                s.id_report = id_acc_trans
                s.report_mark_type = "36"

                s.show()
            Else
                warningCustom("Journal not found.")
            End If
        Else
            warningCustom("Journal not found.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BReported_Click(sender As Object, e As EventArgs) Handles BReported.Click
        FormReportBalanceSheetTax.ShowDialog()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVTaxReport.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVTaxReport.RowCount - 1) - GetGroupRowCount(GVTaxReport))
                If cek Then
                    GVTaxReport.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVTaxReport.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub CESelAllActiveTax_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAllActiveTax.CheckedChanged
        If GVActiveTax.RowCount > 0 Then
            Dim cek As String = CESelAllActiveTax.EditValue.ToString
            For i As Integer = 0 To ((GVActiveTax.RowCount - 1) - GetGroupRowCount(GVActiveTax))
                If cek Then
                    GVActiveTax.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVActiveTax.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub BMoveActiveTax_Click(sender As Object, e As EventArgs) Handles BMoveActiveTax.Click
        FormReportBalanceSheetTax.ShowDialog()
    End Sub

    Private Sub DETaxFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DETaxFrom.EditValueChanged
        DETaxUntil.Properties.MinValue = DETaxFrom.EditValue
    End Sub

    Private Sub DETaxUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DETaxUntil.EditValueChanged
        DETaxFrom.Properties.MaxValue = DETaxUntil.EditValue
    End Sub

    Private Sub SBSummary_Click(sender As Object, e As EventArgs) Handles SBSummary.Click
        FormReportBalanceTaxSummary.ShowDialog()
    End Sub

    Private Sub SBSetup_Click(sender As Object, e As EventArgs) Handles SBSetup.Click
        FormReportBalanceTaxSetup.ShowDialog()
    End Sub

    Private Sub SBSummaryPpn_Click(sender As Object, e As EventArgs) Handles SBSummaryPpn.Click
        FormReportBalanceTaxSummaryPpn.ShowDialog()
    End Sub

    Private Sub BViewMonthlyReport_Click(sender As Object, e As EventArgs) Handles BViewMonthlyReport.Click
        If XTCMonthlyReport.SelectedTabPageIndex = 0 Then
            load_report(GCMAktiva, "1", Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd"), "0")
            GVMAktiva.BestFitColumns()
            GVMAktiva.ExpandAllGroups()
            load_report(GCMPasiva, "2", Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd"), "0")
            GVMPasiva.BestFitColumns()
            GVMPasiva.ExpandAllGroups()
        ElseIf XTCMonthlyReport.SelectedTabPageIndex = 1 Then
            load_report_pl(GCMProfitLoss, Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd"), "0")
            GVMProfitLoss.BestFitColumns()
            GVMProfitLoss.ExpandAllGroups()
        ElseIf XTCMonthlyReport.SelectedTabPageIndex = 2 Then
            load_report(GCMBSvsPrevMonth, "-", Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd"), "0_vs_prev_month")
            GVMBSvsPrevMonth.BestFitColumns()
            GVMBSvsPrevMonth.ExpandAllGroups()
        ElseIf XTCMonthlyReport.SelectedTabPageIndex = 3 Then
            load_report_pl(GCMPLvsPrevMonth, Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd"), "0_vs_prev_month_ind")
            GVMPLvsPrevMonth.BestFitColumns()
            GVMPLvsPrevMonth.ExpandAllGroups()
        End If
    End Sub

    Private Sub DEMonthlyReport_EditValueChanged(sender As Object, e As EventArgs) Handles DEMonthlyReport.EditValueChanged
        Try
            DEMonthlyReport.EditValue = New DateTime(DEMonthlyReport.EditValue.Year, DEMonthlyReport.EditValue.Month, Date.DaysInMonth(DEMonthlyReport.EditValue.Year, DEMonthlyReport.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Dim cost As Decimal = 0.00
    Dim cost_total As Decimal = 0.00

    Dim cur_cost As Decimal = 0.00
    Dim cur_tot As Decimal = 0.00

    Dim cur_cost2 As Decimal = 0.00
    Dim cur_tot2 As Decimal = 0.00

    Private Sub GVMAktiva_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVMAktiva.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            cur_tot = 0.00
            cur_cost = 0.00
            cur_tot2 = 0.00
            cur_cost2 = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            cost = GVMAktiva.GetRowCellValue(e.RowHandle, "this_month")
            cost_total = GVMAktiva.GetRowCellValue(e.RowHandle, "total_asset")
            Select Case summaryID
                Case 1 'total summary estimate
                    cur_tot = cost_total
                    cur_cost += cost
                Case 2
                    cur_tot2 = cost_total
                    cur_cost2 += cost
            End Select
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'total summary estimate
                    Dim tot_cur_cost As Decimal = 0.00
                    Try
                        tot_cur_cost = cur_cost / cur_tot
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_cur_cost * 100
                Case 2 'total summary estimate
                    Dim tot_cur_cost2 As Decimal = 0.00
                    Try
                        tot_cur_cost2 = cur_cost2 / cur_tot2
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_cur_cost2 * 100
            End Select
        End If
    End Sub

    Dim pcost As Decimal = 0.00
    Dim pcost_total As Decimal = 0.00

    Dim pcur_cost As Decimal = 0.00
    Dim pcur_tot As Decimal = 0.00

    Dim pcur_cost2 As Decimal = 0.00
    Dim pcur_tot2 As Decimal = 0.00

    Private Sub GVMPasiva_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVMPasiva.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            pcur_tot = 0.00
            pcur_cost = 0.00
            pcur_tot2 = 0.00
            pcur_cost2 = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            pcost = GVMPasiva.GetRowCellValue(e.RowHandle, "this_month")
            pcost_total = GVMPasiva.GetRowCellValue(e.RowHandle, "total_asset")
            Select Case summaryID
                Case 1 'total summary estimate
                    pcur_tot = pcost_total
                    pcur_cost += pcost
                Case 2
                    pcur_tot2 = pcost_total
                    pcur_cost2 += pcost
            End Select
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'total summary estimate
                    Dim tot_cur_cost As Decimal = 0.00
                    Try
                        tot_cur_cost = pcur_cost / pcur_tot
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_cur_cost * 100
                Case 2 'total summary estimate
                    Dim tot_cur_cost2 As Decimal = 0.00
                    Try
                        tot_cur_cost2 = pcur_cost2 / pcur_tot2
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_cur_cost2 * 100
            End Select
        End If
    End Sub

    Dim pl_month_group As Decimal = 0.00
    Dim pl_month_footer As Decimal = 0.00
    '
    Dim pl_month_group_sum As Decimal = 0.00
    Dim pl_month_footer_sum As Decimal = 0.00
    '
    Dim pl_sales_tot As Decimal = 0.00

    Private Sub GVMProfitLoss_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVMProfitLoss.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            pl_month_group = 0.00
            pl_month_footer = 0.00
            '
            pl_month_group_sum = 0.00
            pl_month_footer_sum = 0.00
            pl_sales_tot = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            pl_month_group = GVMProfitLoss.GetRowCellValue(e.RowHandle, "this_month")
            pl_month_footer = GVMProfitLoss.GetRowCellValue(e.RowHandle, "this_month")
            pl_sales_tot = GVMProfitLoss.GetRowCellValue(e.RowHandle, "this_month_sale")
            Select Case summaryID
                Case 1
                    pl_month_group_sum += pl_month_group
                Case 2
                    pl_month_footer_sum += pl_month_footer
            End Select
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    Dim tot_group As Decimal = 0.00
                    Try
                        tot_group = pl_month_group_sum / pl_sales_tot
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_group * 100
                Case 2
                    Dim tot_footer As Decimal = 0.00
                    Try
                        tot_footer = pl_month_footer_sum / pl_sales_tot
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_footer * 100
            End Select
        End If
    End Sub

    Private Sub BPrintMonthlyReport_Click(sender As Object, e As EventArgs) Handles BPrintMonthlyReport.Click
        If XTCMonthlyReport.SelectedTabPageIndex = 0 Then

        ElseIf XTCMonthlyReport.SelectedTabPageIndex = 1 Then
            If GVMProfitLoss.RowCount > 0 Then
                Cursor = Cursors.WaitCursor

                Dim Report As New ReportMonthlyIS()
                Report.dt = GCMProfitLoss.DataSource
                Report.languange = "eng"
                Report.LTitle.Text = "PT. Volcom Indonesia Income Statement for Period Ending " & Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("MMMM yyyy")

                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()

                Cursor = Cursors.Default
            End If
        ElseIf XTCMonthlyReport.SelectedTabPageIndex = 2 Then
            If GVMBSvsPrevMonth.RowCount > 0 Then
                Cursor = Cursors.WaitCursor

                Dim Report As New ReportMonthlyBSvs()
                Report.dt = GCMBSvsPrevMonth.DataSource
                Report.languange = "eng"

                Dim q As String = "SELECT DATE_FORMAT('" & Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd") & "','%M %Y') AS this_month,DATE_FORMAT(DATE_SUB('" & Date.Parse(DEMonthlyReport.EditValue.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH),'%M %Y') AS prev_month "
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

                Report.DataSource = dt

                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()

                Cursor = Cursors.Default
            End If
        End If

    End Sub

    Dim bs_vpm_t_sum As Decimal = 0.00
    Dim bs_vpm_t_group As Decimal = 0.00

    Dim bs_vpm_p_sum As Decimal = 0.00
    Dim bs_vpm_p_group As Decimal = 0.00

    Private Sub GVMBSvsPrevMonth_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVMBSvsPrevMonth.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            bs_vpm_t_sum = 0.00
            bs_vpm_t_group = 0.00
            bs_vpm_p_sum = 0.00
            bs_vpm_p_group = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Select Case summaryID
                Case 1 'group
                    bs_vpm_t_group += GVMBSvsPrevMonth.GetRowCellValue(e.RowHandle, "this_month")
                    bs_vpm_p_group += GVMBSvsPrevMonth.GetRowCellValue(e.RowHandle, "prev_month")
                Case 2 'sum
                    bs_vpm_t_sum += GVMBSvsPrevMonth.GetRowCellValue(e.RowHandle, "this_month")
                    bs_vpm_p_sum += GVMBSvsPrevMonth.GetRowCellValue(e.RowHandle, "prev_month")
            End Select
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'group
                    Dim tot_group As Decimal = 0.00
                    Try
                        tot_group = ((bs_vpm_t_group - bs_vpm_p_group) / bs_vpm_t_group) * 100
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_group
                Case 2 'sum
                    Dim tot_sum As Decimal = 0.00
                    Try
                        tot_sum = ((bs_vpm_t_sum - bs_vpm_p_sum) / bs_vpm_t_sum) * 100
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_sum
            End Select
        End If
    End Sub

    Dim plvsp_this_month_group As Decimal = 0.00
    Dim plvsp_this_month_footer As Decimal = 0.00
    '
    Dim plvsp_prev_month_group As Decimal = 0.00
    Dim plvsp_prev_month_footer As Decimal = 0.00
    '

    Private Sub GVMPLvsPrevMonth_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVMPLvsPrevMonth.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            plvsp_this_month_group = 0.00
            plvsp_this_month_footer = 0.00
            '
            plvsp_prev_month_group = 0.00
            plvsp_prev_month_footer = 0.00
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Select Case summaryID
                Case 1
                    plvsp_this_month_group += GVMPLvsPrevMonth.GetRowCellValue(e.RowHandle, "this_month")
                    plvsp_prev_month_group += GVMPLvsPrevMonth.GetRowCellValue(e.RowHandle, "prev_month")
                Case 2
                    plvsp_this_month_footer += GVMPLvsPrevMonth.GetRowCellValue(e.RowHandle, "this_month")
                    plvsp_prev_month_footer += GVMPLvsPrevMonth.GetRowCellValue(e.RowHandle, "prev_month")
            End Select
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    Dim tot_group As Decimal = 0.00
                    Try
                        tot_group = ((plvsp_this_month_group - plvsp_prev_month_group) / plvsp_this_month_group) * 100
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_group
                Case 2
                    Dim tot_footer As Decimal = 0.00
                    Try
                        tot_footer = ((plvsp_this_month_footer - plvsp_prev_month_footer) / plvsp_this_month_footer) * 100
                    Catch ex As Exception

                    End Try
                    e.TotalValue = tot_footer
            End Select
        End If
    End Sub
End Class