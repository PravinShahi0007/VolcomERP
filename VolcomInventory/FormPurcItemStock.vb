﻿Public Class FormPurcItemStock
    Private Sub FormPurcItemStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCStock.TabPages
            XTCStock.SelectedTabPage = t
        Next t
        XTCStock.SelectedTabPage = XTCStock.TabPages(0)

        Dim dt As DateTime = getTimeDB()
        DESOHUntil.EditValue = dt
        DEFromSC.EditValue = dt
        DEUntilSC.EditValue = dt

        load_unit()
        load_location()

        viewItem()
        viewDept()
        viewCat()
        DESOHUntil.EditValue = getTimeDB()
        '
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Sub load_location()
        Dim query As String = "SELECT 'ALL' AS id_loc_og,'ALL location' AS loc_og 
UNION ALL
SELECT id_loc_og,loc_og FROM `tb_loc_og`"
        viewSearchLookupQuery(SLELocation, query, "id_loc_og", "loc_og", "id_loc_og")
        viewSearchLookupQuery(SLELocStockCard, query, "id_loc_og", "loc_og", "id_loc_og")
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
        SLEUnit.EditValue = "1"
    End Sub

    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT i.id_item, i.item_desc, cat.id_item_cat, cat.item_cat,uom.uom
        FROM tb_item i
        INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom_stock
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat 
        ORDER BY i.item_desc ASC "
        viewSearchLookupQuery(SLEITem, query, "id_item", "item_desc", "id_item")
        SearchLookUpEdit1View.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query_all As String = queryDept(True)

        viewLookupQuery(LEDeptSum, query_all, 0, "departement", "id_departement")
        viewLookupQuery(LEDeptSC, query_all, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Function queryDept(ByVal include_all As Boolean) As String
        Dim query As String = ""
        If include_all Then
            query += "SELECT -1 as id_departement, 'All departement' as departement UNION  SELECT 0 as id_departement, 'Purchasing Storage' as departement UNION "
        End If
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        Return query
    End Function

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        viewLookupQuery(LECatPemakaian, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcItemStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPurcItemStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = LEDeptSum.EditValue.ToString
        Dim cat As String = LECat.EditValue.ToString
        Dim loc As String = SLELocation.EditValue.ToString
        '
        If dept = "-1" Then
            dept = ""
        Else
            dept = "AND i.id_departement=" + dept + ""
        End If
        '
        If loc = "ALL" Then
            loc = ""
        Else
            loc = " AND i.id_loc_og='" & loc & "' "
        End If
        '
        Dim stc As New ClassPurcItemStock()
        stc.additional_where = loc
        Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewSC_Click(sender As Object, e As EventArgs) Handles BtnViewSC.Click
        viewStockCard()
    End Sub

    Sub viewStockCard()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "1997-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim id_dept As String = LEDeptSC.EditValue.ToString
        Dim id_item As String = SLEITem.EditValue.ToString
        Dim loc As String = SLELocStockCard.EditValue.ToString

        Dim query As String = "CALL view_stock_card_item(" + id_dept + ", " + id_item + ", '" + date_from_selected + "', '" + date_until_selected + "','" + loc + "','')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSC.DataSource = data
        GVSC.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentToolStripMenuItem.Click
        If GVSC.RowCount > 0 And GVSC.FocusedRowHandle >= 0 Then
            Dim rmt As String = GVSC.GetFocusedRowCellValue("report_mark_type").ToString
            Dim id_report As String = GVSC.GetFocusedRowCellValue("id_report").ToString
            Dim s As New ClassShowPopUp
            s.id_report = id_report
            s.report_mark_type = rmt
            s.show()
        End If
    End Sub

    Private Sub BStockFisik_Click(sender As Object, e As EventArgs) Handles BStockFisik.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = LEDeptSum.EditValue.ToString
        Dim cat As String = LECat.EditValue.ToString
        Dim loc As String = SLELocation.EditValue.ToString

        If dept = "-1" Then
            dept = ""
        Else
            dept = "AND i.id_departement=" + dept + ""
        End If

        If loc = "ALL" Then
            loc = ""
        Else
            loc = " AND i.id_loc_og='" & loc & "' "
        End If

        Dim stc As New ClassPurcItemStock()
        stc.opt = "fisik"
        stc.additional_where = loc

        Dim query As String = stc.queryGetStock(dept, cat, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BStockCardFisik_Click(sender As Object, e As EventArgs) Handles BStockCardFisik.Click
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "1997-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim id_dept As String = LEDeptSC.EditValue.ToString
        Dim id_item As String = SLEITem.EditValue.ToString
        Dim loc As String = SLELocStockCard.EditValue.ToString

        Dim query As String = "CALL view_stock_card_item(" + id_dept + ", " + id_item + ", '" + date_from_selected + "', '" + date_until_selected + "','" + loc + "','fisik')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSC.DataSource = data
        GVSC.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
        '
        Try
            DEStart.EditValue = New DateTime(DEStart.EditValue.Year, DEStart.EditValue.Month, 1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_pemakaian("zero")
    End Sub

    Sub load_pemakaian(ByVal opt As String)
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim cat As String = ""
        Dim zero_filter As String = ""

        If Not LECatPemakaian.EditValue.ToString = "0" Then
            cat = " AND it.id_item_cat='" & LECatPemakaian.EditValue.ToString & "'"
        End If

        If opt = "zero" Then
            zero_filter = ""
        Else
            zero_filter = " HAVING qty_beg>0 OR amount_beg!=0 OR qty_rec>0 OR qty_used>0 OR qty_rem>0 "
        End If

        Dim q_unit As String = ""
        Dim q_where_unit As String = ""
        Dim q_selisih_unit As String = ""

        If Not SLEUnit.EditValue.ToString = "0" Then
            If SLEUnit.EditValue.ToString = "1" Then
                q_unit = " LEFT JOIN tb_m_departement ON tb_m_departement.id_departement=tb_storage_item.id_departement AND tb_m_departement.`id_coa_tag`='1' "
                q_where_unit = " AND (NOT ISNULL(tb_m_departement.id_departement) OR tb_storage_item.id_departement=0) "
            Else
                q_unit = " INNER JOIN tb_m_departement ON tb_m_departement.id_departement=tb_storage_item.id_departement AND tb_m_departement.`id_coa_tag`='" & SLEUnit.EditValue.ToString & "' "
            End If

            q_selisih_unit = " AND savg.id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        End If

        Dim q As String = "SET @start_date='" & date_start & "';
SET @end_date='" & date_until & "';

SELECT i.`id_item`,itc.item_cat,IFNULL(beg.min_date,rec.min_date) AS min_date,uom.uom,i.`item_desc`
,IFNULL(beg.qty_begs,0) AS qty_beg,IFNULL(beg.harga_satuan_begs,0)  AS harga_satuan_beg,IFNULL(beg.amount_begs,0)  AS amount_beg
,IFNULL(rec.qty_rec,0) AS qty_rec,IFNULL(rec.harga_satuan_rec,0)  AS harga_satuan_rec,IFNULL(rec.amount_rec,0)  AS amount_rec
,IFNULL(used.qty_used,0) AS qty_used,IFNULL(used.harga_satuan_used,0)  AS harga_satuan_used,IFNULL(used.amount_used,0)  AS amount_used
,IFNULL(ending.qty_ending,0) AS qty_rem,IF(IFNULL(ending.qty_ending,0)=0,0,IFNULL(ending.harga_satuan_ending,0)) AS harga_satuan_rem,IF(IFNULL(ending.qty_ending,0)=0,0,IFNULL(ending.amount_ending,0)) AS amount_rem
,IFNULL(req.qty_req,0) AS qty_req,IF(IFNULL(req.qty_req,0)=0,0,IFNULL(req.harga_satuan_req,0)) AS harga_satuan_req,IF(IFNULL(req.qty_req,0)=0,0,IFNULL(req.amount_req,0)) AS amount_req
,IFNULL(rem_book.qty_rem_book,0) AS qty_rem_book,IF(IFNULL(rem_book.qty_rem_book,0)=0,0,IFNULL(rem_book.harga_satuan_rem_book,0)) AS harga_satuan_rem_book,IF(IFNULL(rem_book.qty_rem_book,0)=0,0,IFNULL(rem_book.amount_rem_book,0)) AS amount_rem_book
FROM tb_item i
INNER JOIN tb_item_cat itc ON itc.id_item_cat=i.id_item_cat
INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom_stock " & cat & "
LEFT JOIN
(
	-- begining
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_begs,MIN(storage_item_datetime) as min_date
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_begs
    ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty))*getAvgCostDate(`id_item`,DATE_SUB(@start_date, INTERVAL 1 DAY))+IFNULL(get_amount_selisih_beg(id_item,@start_date),0) AS amount_begs
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_begs
	,getAvgCostDate(`id_item`,DATE_SUB(@start_date, INTERVAL 1 DAY)) AS harga_satuan_begs
    FROM `tb_storage_item` 
     " & q_unit & "
	WHERE DATE(storage_item_datetime)<@start_date AND NOT report_mark_type='154' AND NOT report_mark_type='163' " & q_where_unit & "
	GROUP BY `id_item`
	HAVING qty_begs!=0 OR IFNULL(get_amount_selisih_beg(id_item,@start_date),0)!=0
)beg ON beg.id_item=i.`id_item`
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rec,MIN(storage_item_datetime) AS min_date
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rec
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rec
	FROM `tb_storage_item`
     " & q_unit & "
	WHERE DATE(storage_item_datetime)>=@start_date AND DATE(storage_item_datetime)<=@end_date AND report_mark_type='148'  " & q_where_unit & "
	GROUP BY id_item
	HAVING qty_rec!=0
)rec ON rec.id_item=i.id_item
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS qty_used
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_used
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`) AS amount_used
	FROM `tb_storage_item`
     " & q_unit & "
	WHERE DATE(storage_item_datetime)>=@start_date AND DATE(storage_item_datetime)<=@end_date
	AND NOT report_mark_type='148' AND NOT report_mark_type='154' AND NOT report_mark_type='163' " & q_where_unit & "
	GROUP BY id_item
	HAVING qty_used!=0
)used ON used.id_item=i.id_item
LEFT JOIN
(
	-- ending
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_ending
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_ending
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_ending
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty))*getAvgCostDate(`id_item`,@end_date) AS amount_ending
    ,getAvgCostDate(`id_item`,@end_date) AS harga_satuan_ending
    FROM `tb_storage_item` 
     " & q_unit & "
	WHERE DATE(storage_item_datetime)<=@end_date AND NOT report_mark_type='154' AND NOT report_mark_type='163' " & q_where_unit & "
	GROUP BY `id_item`
)ending ON ending.id_item=i.`id_item`
LEFT JOIN (
	SELECT id_item,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS qty_req
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_req
	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`) AS amount_req
	FROM `tb_storage_item`
    " & q_unit & "
	WHERE DATE(storage_item_datetime)<=@end_date AND (report_mark_type='154' OR report_mark_type='163') " & q_where_unit & "
	GROUP BY id_item
	HAVING qty_req!=0
)req ON req.id_item=i.id_item
LEFT JOIN
(
	-- real ending
	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rem_book
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rem_book
	-- ,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rem_book
	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty))*getAvgCostDate(`id_item`,@end_date) AS amount_rem_book
    ,getAvgCostDate(`id_item`,@end_date) AS harga_satuan_rem_book
    FROM `tb_storage_item` 
    " & q_unit & "
	WHERE DATE(storage_item_datetime)<=@end_date " & q_where_unit & "
	GROUP BY `id_item`
)rem_book ON rem_book.id_item=i.`id_item`
" & zero_filter & "
UNION ALL
SELECT i.`id_item`,itc.item_cat,date_reff AS min_date,uom.uom,CONCAT('Selisih Pembulatan ',i.`item_desc`) AS item_desc
,0 AS qty_beg,0  AS harga_satuan_beg,0  AS amount_beg
,0 AS qty_rec,0 AS harga_satuan_rec,SUM(IF(savg.`id_type`=1,savg.`values`,0)) AS amount_rec
,0 AS qty_used,0  AS harga_satuan_used,0  AS amount_used
,0 AS qty_rem,0 AS harga_satuan_rem,SUM(savg.`values`) AS amount_rem
,0 AS qty_req,0 AS harga_satuan_req,0 AS amount_req
,0 AS qty_rem_book,0 AS harga_satuan_rem_book,0 AS amount_rem_book
FROM tb_storage_item_selisih_avg savg
INNER JOIN tb_item i ON i.`id_item`=savg.`id_item`
INNER JOIN tb_item_cat itc ON itc.id_item_cat=i.id_item_cat
INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom_stock
WHERE DATE(savg.`date_reff`)>=@start_date AND DATE(savg.`date_reff`)<=@end_date " & q_selisih_unit & "
GROUP BY savg.`id_item`
"

        '        q = "SELECT it.`id_item`,it.`item_desc`,IFNULL(beg.min_date,rec.min_date) AS min_date,uom.uom
        ',IFNULL(beg.qty_beg,0)+IFNULL(book_before.qty_req,0) AS qty_beg,IF(IFNULL(beg.qty_beg,0)+IFNULL(book_before.qty_req,0)=0,0,IFNULL(beg.amount_beg,0)+IFNULL(book_before.amount_req,0)) AS amount_beg
        ',IF(IFNULL(beg.qty_beg,0)+IFNULL(book_before.qty_req,0)=0,0,(IF(IFNULL(beg.qty_beg,0)+IFNULL(book_before.qty_req,0)=0,0,IFNULL(beg.amount_beg,0)+IFNULL(book_before.amount_req,0)))/(IFNULL(beg.qty_beg,0)+IFNULL(book_before.qty_req,0))) AS harga_satuan_beg
        '-- ,IFNULL(beg.qty_beg,0) AS qty_beg,IFNULL(beg.harga_satuan_beg,0) AS harga_satuan_beg,IF(IFNULL(beg.qty_beg,0)=0,0,IFNULL(beg.amount_beg,0)) AS amount_beg
        ',IFNULL(rec.qty_rec,0) AS qty_rec,IFNULL(rec.harga_satuan_rec,0) AS harga_satuan_rec,IFNULL(rec.amount_rec,0) AS amount_rec
        ',IFNULL(req.qty_used,0) AS qty_req,IFNULL(req.harga_satuan_used,0) AS harga_satuan_req,IFNULL(req.amount_used,0) AS amount_req
        ',IFNULL(used.qty_used,0) AS qty_used,IFNULL(used.harga_satuan_used,0) AS harga_satuan_used,IFNULL(used.amount_used,0) AS amount_used
        '-- ,IFNULL(rem.qty_rem,0) AS qty_rem,IFNULL(rem.harga_satuan_rem,0) AS harga_satuan_rem,IFNULL(rem.amount_rem,0) AS amount_rem
        ',IFNULL(rem.qty_rem,0) AS qty_rem
        ',IF(IFNULL(rem.qty_rem,0)=0,0,(IF(IFNULL(beg.qty_beg,0)=0,0,IFNULL(beg.amount_beg,0))+IFNULL(rec.amount_rec,0)-IFNULL(used.amount_used,0))/IFNULL(rem.qty_rem,0)) AS harga_satuan_rem
        ',IF(IFNULL(rem.qty_rem,0)=0,0,(IF(IFNULL(beg.qty_beg,0)=0,0,IFNULL(beg.amount_beg,0))+IFNULL(rec.amount_rec,0)-IFNULL(used.amount_used,0))) AS amount_rem
        ',IFNULL(rem_book.qty_rem,0) AS qty_rem_book,IFNULL(rem_book.harga_satuan_rem,0) AS harga_satuan_rem_book,IFNULL(rem_book.amount_rem,0) AS amount_rem_book
        ',itc.item_cat
        'FROM tb_item it
        'INNER JOIN tb_item_cat itc ON itc.id_item_cat=it.id_item_cat
        'INNER JOIN tb_m_uom uom ON uom.id_uom=it.id_uom_stock " & cat & "
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_beg,MIN(storage_item_datetime) as min_date
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_beg
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_beg
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)<'" & date_start & "' " & q_where_unit & "
        '	GROUP BY id_item
        '	" & zero_filter & "
        ')beg ON beg.id_item=it.id_item
        'LEFT JOIN (
        '    -- amountnya ikut, qty tidak
        '	SELECT id_item,IF(SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty))>0,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)),0) AS qty_req
        '	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_req
        '	,IF(SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`),SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`),0) AS amount_req
        '	FROM `tb_storage_item`
        '	LEFT JOIN tb_m_departement ON tb_m_departement.id_departement=tb_storage_item.id_departement AND tb_m_departement.`id_coa_tag`='1' 
        '	WHERE DATE(storage_item_datetime)>=DATE_SUB('" & date_start & "',INTERVAL 1 MONTH) AND DATE(storage_item_datetime)<'" & date_start & "' AND (report_mark_type='154' OR report_mark_type='163')   AND (NOT ISNULL(tb_m_departement.id_departement) OR tb_storage_item.id_departement=0) 
        '	GROUP BY id_item
        '	HAVING amount_req!=0
        ')book_before ON book_before.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_beg,MIN(storage_item_datetime) as min_date
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_beg
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_beg
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)<'" & date_start & "' " & q_where_unit & "
        '	GROUP BY id_item
        '	" & zero_filter & "
        ')beg_real ON beg_real.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rec,MIN(storage_item_datetime) as min_date
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rec
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rec
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)>='" & date_start & "' AND DATE(storage_item_datetime)<='" & date_until & "' AND report_mark_type='148'  " & q_where_unit & "
        '	GROUP BY id_item
        '	HAVING qty_rec!=0
        ')rec ON rec.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS qty_used
        '	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_used
        '	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`) AS amount_used
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)>='" & date_start & "' AND DATE(storage_item_datetime)<='" & date_until & "' AND (report_mark_type='154' OR report_mark_type='163')  " & q_where_unit & "
        '	GROUP BY id_item
        '	HAVING qty_used!=0
        ')req ON req.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS qty_used
        '	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)) AS harga_satuan_used
        '	,SUM(IF(id_storage_category=2,storage_item_qty,-storage_item_qty)*`value`) AS amount_used
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)>='" & date_start & "' AND DATE(storage_item_datetime)<='" & date_until & "' AND NOT report_mark_type='148' AND NOT report_mark_type='154' AND NOT report_mark_type='163'  " & q_where_unit & "
        '	GROUP BY id_item
        '	HAVING qty_used!=0
        ')used ON used.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rem
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rem
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rem
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)<='" & date_until & "' AND NOT report_mark_type='154' AND NOT report_mark_type='163'  " & q_where_unit & "
        '	GROUP BY id_item
        '	HAVING qty_rem!=0
        ')rem ON rem.id_item=it.id_item
        'LEFT JOIN (
        '	SELECT id_item,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS qty_rem
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`)/SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)) AS harga_satuan_rem
        '	,SUM(IF(id_storage_category=1,storage_item_qty,-storage_item_qty)*`value`) AS amount_rem
        '	FROM `tb_storage_item`
        '    " & q_unit & "
        '	WHERE DATE(storage_item_datetime)<='" & date_until & "' " & q_where_unit & "
        '	GROUP BY id_item
        '	HAVING qty_rem!=0
        ')rem_book ON rem_book.id_item=it.id_item
        'WHERE NOT ISNULL(beg.id_item) OR NOT ISNULL(rec.id_item) OR NOT ISNULL(used.id_item) OR NOT ISNULL(rem.id_item)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPemakaian.DataSource = dt
        GVPemakaian.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCPemakaian, "Report Pemakaian " & SLEUnit.Text & " " & "(Periode " & Date.Parse(DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(DEUntil.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        load_pemakaian("")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If GVPemakaian.RowCount > 0 Then
            LEDeptSC.EditValue = "-1"
            DEFromSC.EditValue = Date.Parse(GVPemakaian.GetFocusedRowCellValue("min_date").ToString)
            DEUntilSC.EditValue = DEUntil.EditValue
            SLEITem.EditValue = GVPemakaian.GetFocusedRowCellValue("id_item").ToString
            XTCStock.SelectedTabPageIndex = 1
            viewStockCard()
        End If
    End Sub

    Private Sub BToggleBooking_Click(sender As Object, e As EventArgs) Handles BToggleBooking.Click
        If gridBandBooking.Visible = True Then
            gridBandBooking.Visible = False
            gridBandrembooking.Visible = False
        Else
            gridBandBooking.Visible = True
            gridBandrembooking.Visible = True
        End If
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEUntil.EditValue = New DateTime(DEUntil.EditValue.Year, DEUntil.EditValue.Month, Date.DaysInMonth(DEUntil.EditValue.Year, DEUntil.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewStockKosong_Click(sender As Object, e As EventArgs) Handles BViewStockKosong.Click
        Cursor = Cursors.WaitCursor

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStockKosong()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStockKosong.DataSource = data
        GVStockKosong.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class