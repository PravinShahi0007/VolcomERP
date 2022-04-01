Public Class FormARCollectionAvg
    Private Sub FormARCollectionAvg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewYear()
    End Sub

    Private Sub FormARCollectionAvg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormARCollectionAvg_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormARCollectionAvg_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT 'All' AS `year`)
        UNION
        (SELECT YEAR(sp.sales_pos_date) AS `year`
        FROM tb_sales_pos sp
        WHERE sp.id_report_status!=5
        GROUP BY YEAR(sp.sales_pos_date) 
        ORDER BY `year` DESC)"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If XTCData.SelectedTabPageIndex = 0 Then
            viewSummary()
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            viewDetail()
        End If
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim cond_year As String = ""
        If SLEYear.EditValue.ToString <> "All" Then
            cond_year = "AND YEAR(sp.sales_pos_date)='" + SLEYear.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT cg.id_comp_group,cg.description AS `group_store`,
        AVG(DATEDIFF(r.date_received,sp.sales_pos_date)) AS `idate_pdate`,
        AVG(DATEDIFF(r.date_received, sp.sales_pos_due_date)) AS `ddate_pdate`
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        INNER JOIN (
            SELECT r.id_rec_payment AS `id_bbm`,r.number AS `bbm_number`,rmmax.id_report, rmmax.report_mark_type, r.date_received
            FROM tb_rec_payment r 
            INNER JOIN (
	            SELECT rd.id_report, rd.report_mark_type, MAX(rd.id_rec_payment) AS `id_rec_payment`
	            FROM tb_rec_payment_det rd
	            INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
	            WHERE r.id_report_status=6 AND r.type_rec=1
	            GROUP BY rd.id_report, rd.report_mark_type
            ) rmmax ON rmmax.id_rec_payment = r.id_rec_payment
            WHERE r.id_report_status=6 AND r.type_rec=1
        ) r ON r.id_report = sp.id_sales_pos AND r.report_mark_type = sp.report_mark_type
        WHERE sp.is_close_rec_payment=1
        " + cond_year + "
        GROUP BY cg.id_comp_group
        ORDER BY group_store ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim cond_year As String = ""
        If SLEYear.EditValue.ToString <> "All" Then
            cond_year = "AND YEAR(sp.sales_pos_date)='" + SLEYear.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT cg.id_comp_group,cg.description AS `group_store`, CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,sp.id_sales_pos,sp.sales_pos_number, sp.sales_pos_date, sp.sales_pos_due_date, 
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount,
        r.id_bbm, r.bbm_number, r.date_received, 
        DATEDIFF(r.date_received,sp.sales_pos_date) AS `idate_pdate`,
        DATEDIFF(r.date_received, sp.sales_pos_due_date) AS `ddate_pdate`
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        INNER JOIN (
	        SELECT * FROM (
		        SELECT r.id_rec_payment AS `id_bbm`,r.number AS `bbm_number`,rd.id_report, rd.report_mark_type, r.date_received
		        FROM tb_rec_payment_det rd
		        INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
		        WHERE r.id_report_status=6 AND r.type_rec=1
		        ORDER BY r.id_rec_payment DESC
	        ) r 
	        GROUP BY r.id_report, r.report_mark_type
        ) r ON r.id_report = sp.id_sales_pos AND r.report_mark_type = sp.report_mark_type
        WHERE sp.is_close_rec_payment=1
        " + cond_year + "
        ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class