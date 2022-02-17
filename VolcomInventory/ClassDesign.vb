﻿Public Class ClassDesign
    '***************
    'GENERAL
    '***************
    Public Function queryOldDesignCode(ByVal product_param As String)
        Dim product_arr As String() = Split(product_param, ";")
        Dim query As String = ""
        query += "Select CAST(prod.id_product AS CHAR(15)) AS `id_product`, ('0') AS `id_pl_prod_order_rec_det_unique`, "
        query += "(prod.product_full_code) As `product_code`, ('') As `product_counting_code`, "
        query += "(prod.product_full_code) AS `product_full_code`, (dsg.design_display_name) AS `name`,  cod.display_name AS `size`, cd.class, cd.color, cd.sht,
        ('1') AS `is_old_design`, ('2') AS `is_rec`, "
        query += "(dsg.design_cop) AS `bom_unit_price`, CAST(prc.id_design_price AS CHAR(15)) AS `id_design_price`, prc.design_price, prc.id_design_price_type, prc.design_price_type, prc.id_design_cat, prc.design_cat, ('0') AS `id_sales_return_det_counting`, 2 AS `is_unique_report` "
        query += "From tb_m_product prod "
        query += "JOIN tb_opt o
        INNER JOIN tb_m_product_code cc ON cc.id_product = prod.id_product 
        INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
        query += "INNER Join tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "Left Join( "
        query += "Select * FROM ( "
        query += "Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, price.id_design_price_type, price_type.design_price_type, cat.id_design_cat, cat.design_cat "
        query += "From tb_m_design_price price "
        query += "INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type "
        query += "INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat "
        query += "WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() "
        query += "ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a "
        query += "GROUP BY a.id_design "
        query += ") prc ON prc.id_design = dsg.id_design 
        LEFT JOIN (
		    SELECT dc.id_design, 
		    MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		    MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		    FROM tb_m_design_code dc
		    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		    AND cd.id_code IN (32,30,14, 43)
		    GROUP BY dc.id_design
	    ) cd ON cd.id_design = dsg.id_design "
        query += "WHERE dsg.is_old_design = '1' AND ("
        For i As Integer = 0 To (product_arr.Count - 1)
            If i > 0 Then
                query += "OR "
            End If
            query += "prod.id_product='" + product_arr(i).ToString + "' "
        Next
        query += ") "
        Return query
    End Function

    Public Function queryOldDesignCodeLess(ByVal product_param As String)
        Dim query As String = ""
        query += "Select CAST(prod.id_product AS CHAR(15)) AS `id_product`, ('0') AS `id_pl_prod_order_rec_det_unique`, "
        query += "(prod.product_full_code) As `product_code`, ('') As `product_counting_code`, "
        query += "(prod.product_full_code) AS `product_full_code`, (dsg.design_display_name) AS `name`,  cod.display_name AS `size`, cd.class, cd.color, cd.sht,
        ('1') AS `is_old_design`, ('2') AS `is_rec`, "
        query += "(dsg.design_cop) AS `bom_unit_price`, CAST(prc.id_design_price AS CHAR(15)) AS `id_design_price`, prc.design_price, prc.id_design_price_type, prc.design_price_type, prc.id_design_cat, prc.design_cat, ('0') AS `id_sales_return_det_counting`, 2 AS `is_unique_report` "
        query += "From tb_m_product prod "
        query += "JOIN tb_opt o
        INNER JOIN tb_m_product_code cc ON cc.id_product = prod.id_product 
        INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
        query += "INNER Join tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "Left Join( "
        query += "Select * FROM ( "
        query += "Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, price.id_design_price_type, price_type.design_price_type, cat.id_design_cat, cat.design_cat "
        query += "From tb_m_design_price price "
        query += "INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type "
        query += "INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat "
        query += "WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() "
        query += "ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a "
        query += "GROUP BY a.id_design "
        query += ") prc ON prc.id_design = dsg.id_design 
        LEFT JOIN (
		    SELECT dc.id_design, 
		    MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		    MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		    FROM tb_m_design_code dc
		    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		    AND cd.id_code IN (32,30,14, 43)
		    GROUP BY dc.id_design
	    ) cd ON cd.id_design = dsg.id_design "
        query += "WHERE dsg.is_old_design = '1' AND prod.id_product IN (" + product_param + ") "
        Return query
    End Function

    Public Function queryOldDesignCodeByDrawer(ByVal id_drawer As String)
        Dim query As String = "SELECT 0 AS `id_pl_prod_order_rec_det_unique`,j.id_product, prod.product_full_code AS `product_code`, '' AS `counting_code`, '' AS `product_counting_code`, prod.product_full_code, prod.product_full_code AS `code`,
        d.design_display_name AS `name`, cd.code_detail_name AS `size`, d.design_cop AS `bom_unit_price`,
        SUM(IF(j.id_storage_category=2, CONCAT('-', j.storage_product_qty), j.storage_product_qty)) AS qty,
        2 AS `is_rec`, d.is_old_design,
        prc.id_design_price, prc.design_price, prc.id_design_price_type, prc.design_price_type, prc.id_design_cat, prc.design_cat
        FROM tb_storage_fg j
        INNER JOIN tb_m_product prod ON prod.id_product = j.id_product
        INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        LEFT JOIN( 
          Select * FROM ( 
	          Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	          price.id_design_price_type, price_type.design_price_type,
	          cat.id_design_cat, cat.design_cat
	          From tb_m_design_price price 
	          INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
	          INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	          WHERE price.is_active_wh=1 AND price.design_price_start_date <= NOW() 
  	        ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
          ) a 
          GROUP BY a.id_design 
        ) prc ON prc.id_design = prod.id_design 
        WHERE j.id_wh_drawer=" + id_drawer + " AND d.is_old_design=1
        GROUP BY j.id_product
        HAVING qty>0 "
        Return query
    End Function

    Public Function dataUnregisteredCode(ByVal product_param As String)
        Dim product_arr As String() = Split(product_param, ";")
        Dim query As String = ""
        query += "Select CAST(prod.id_product AS CHAR(15)) AS `id_product`, ('0') AS `id_pl_prod_order_rec_det_unique`, "
        query += "(prod.product_full_code) As `product_code`, prod.product_name AS `name`, cod.display_name AS `size`, ('') As `product_counting_code`, "
        query += "(prod.product_full_code) AS `product_full_code`, ('1') AS `is_old_design`, ('2') AS `is_rec`, "
        query += "(dsg.design_cop) AS `bom_unit_price`, CAST(prc.id_design_price AS CHAR(15)) AS `id_design_price`, prc.design_price, prc.id_design_price_type, prc.design_price_type, prc.id_design_cat, prc.design_cat, ('0') AS `id_sales_return_det_counting`, prod.last_print_unique "
        query += "From tb_m_product prod "
        query += "INNER Join tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "Left Join( "
        query += "Select * FROM ( "
        query += "Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, price.id_design_price_type, price_type.design_price_type, cat.id_design_cat, cat.design_cat "
        query += "From tb_m_design_price price "
        query += "INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type "
        query += "INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat "
        query += "WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() "
        query += "ORDER BY price.design_price_start_date DESC ) a "
        query += "GROUP BY a.id_design "
        query += ") prc ON prc.id_design = dsg.id_design "
        query += "JOIN tb_opt o "
        query += "INNER JOIN tb_m_product_code cc ON cc.id_product = prod.id_product "
        query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
        query += "WHERE dsg.is_old_design = '3' AND ("
        For i As Integer = 0 To (product_arr.Count - 1)
            If i > 0 Then
                query += "OR "
            End If
            query += "prod.id_product='" + product_arr(i).ToString + "' "
        Next
        query += ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim dt As New DataTable
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_design_cat")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try
        For i As Integer = 0 To data.Rows.Count - 1
            Dim range_akhir As Integer = Integer.Parse(data.Rows(i)("last_print_unique").ToString)
            For j As Integer = 1 To range_akhir
                Dim R As DataRow = dt.NewRow
                R("id_product") = data.Rows(i)("id_product").ToString
                R("id_design_cat") = data.Rows(i)("id_design_cat").ToString
                R("id_pl_prod_order_rec_det_unique") = data.Rows(i)("id_pl_prod_order_rec_det_unique").ToString
                R("product_code") = data.Rows(i)("product_code").ToString
                R("name") = data.Rows(i)("name").ToString
                R("size") = data.Rows(i)("size").ToString
                R("product_counting_code") = combine_header_number("", j, 4)
                R("product_full_code") = combine_header_number(data.Rows(i)("product_code").ToString, j, 4)
                R("bom_unit_price") = data.Rows(i)("bom_unit_price")
                R("is_old_design") = 3
                dt.Rows.Add(R)
            Next
        Next
        Return dt
    End Function

    Public Sub updatedTime(ByVal id_design_par As String)
        Dim query As String = "UPDATE tb_m_design Set last_updated=NOW(), updated_by='" + id_user + "' WHERE id_design='" + id_design_par + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub


    '***************
    'LINE LIST
    '***************
    Public Function queryDesignLastPD() As String
        Dim query As String = "CALL view_design_pd_last()"
        Return query
    End Function

    Public Function queryLineList(ByVal id_season_par As String, ByVal id_type_par As String, ByVal show_breakdown_par As Boolean) As String
        If id_type_par = "3" Then
            Dim query As String = ""
            If show_breakdown_par Then
                query = "CALL view_line_list_final('" + id_season_par + "')"
            Else
                query = "CALL view_line_list_final_less('" + id_season_par + "')"
            End If
            Return query
        Else
            Dim query As String = ""
            If show_breakdown_par Then
                query = "CALL view_line_list('" + id_season_par + "', '" + id_type_par + "')"
            Else
                query = "CALL view_line_list_less('" + id_season_par + "', '" + id_type_par + "')"
            End If
            Return query
        End If
    End Function

    Public Function getBreakTotalLineList(ByVal id_type_param As String) As DataTable
        Dim data_band_break As DataTable = Nothing
        Dim query_band_break As String = ""
        If id_type_param = "1" Then
            query_band_break += "SELECT CONCAT(a.display_name,'_Breakdown') AS display_name, "
        ElseIf id_type_param = "2" Then
            query_band_break += "SELECT CONCAT(a.display_name,'_size') AS display_name, "
        ElseIf id_type_param = "3" Then
            query_band_break += "SELECT CONCAT(a.display_name,'_Breakdown_Plan') AS display_name, "
        ElseIf id_type_param = "4" Then
            query_band_break += "SELECT CONCAT(a.display_name,'_qty') AS display_name, "
        ElseIf id_type_param = "5" Then
            query_band_break += "SELECT CONCAT(a.display_name,'_ActRec') AS display_name, "
        End If
        query_band_break += "a.code_detail_name, a.code_row_index, a.code_col_index "
        query_band_break += "FROM tb_m_code_detail a "
        query_band_break += "JOIN tb_opt b "
        query_band_break += "WHERE a.id_code = b.id_code_product_size "
        query_band_break += "ORDER BY a.id_code_detail ASC "
        data_band_break = execute_query(query_band_break, -1, True, "", "", "", "")
        Return data_band_break
    End Function

    Public Function getBreakAllocLineList(ByVal id_type_param As String) As DataTable
        Dim data_band_alloc As DataTable = Nothing
        Dim query_band_alloc As String = ""
        If id_type_param = "1" Then
            query_band_alloc += "SELECT CONCAT(a.display_name, '_',UPPER(c.pd_alloc), ' BREAKDOWN SIZE_Alloc') AS display_name, a.code_detail_name, a.code_row_index, a.code_col_index "
        ElseIf id_type_param = "2" Then
            query_band_alloc += "SELECT CONCAT(a.display_name, '_',UPPER(c.pd_alloc), ' BREAKDOWN SIZE_Alloc_Plan') AS display_name, a.code_detail_name, a.code_row_index, a.code_col_index "
        End If
        query_band_alloc += "FROM tb_m_code_detail a "
        query_band_alloc += "JOIN tb_opt b "
        query_band_alloc += "JOIN tb_lookup_pd_alloc c "
        query_band_alloc += "WHERE a.id_code = b.id_code_product_size "
        query_band_alloc += "UNION ALL "
        If id_type_param = "1" Then
            query_band_alloc += "SELECT CONCAT(a.display_name, '_',UPPER('ACT ORDER SALES'), ' BREAKDOWN SIZE_Alloc') AS display_name, a.code_detail_name, a.code_row_index, a.code_col_index "
        ElseIf id_type_param = "2" Then
            query_band_alloc += "SELECT CONCAT(a.display_name, '_',UPPER('ACT ORDER SALES'), ' BREAKDOWN SIZE_Alloc_Plan') AS display_name, a.code_detail_name, a.code_row_index, a.code_col_index "
        End If
        query_band_alloc += "FROM tb_m_code_detail a "
        query_band_alloc += "JOIN tb_opt b "
        query_band_alloc += "WHERE a.id_code = b.id_code_product_size "
        data_band_alloc = execute_query(query_band_alloc, -1, True, "", "", "", "")
        Return data_band_alloc
    End Function

    Public Sub insertToLineListDet(ByVal id_dsg_param As String, ByVal id_product_param As String)
        Dim query As String = "CALL ins_line_list_alloc('" + id_dsg_param + "','" + id_product_param + "') "
        execute_non_query(query, True, "", "", "", "")
    End Sub


    Public Sub viewLineList(ByVal id_season_param As String, ByVal id_type_param As String, ByVal BGVParam As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView, ByVal GCParam As DevExpress.XtraGrid.GridControl, ByVal data_band_break As DataTable, ByVal data_band_alloc As DataTable, ByVal show_breakdown_par As Boolean)
        'prepare
        GCParam.DataSource = Nothing
        GCParam.RepositoryItems.Clear()
        GCParam.RefreshDataSource()
        BGVParam.ApplyFindFilter("")
        BGVParam.ColumnPanelRowHeight = 40
        BGVParam.Columns.Clear()
        BGVParam.GroupSummary.Clear()
        BGVParam.Bands.Clear()
        BGVParam.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BGVParam.OptionsBehavior.AutoExpandAllGroups = True

        ' Make the group footers always visible.
        BGVParam.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'create band
        Dim band_desc_freeze As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("GENERAL DESCRIPTION")
        band_desc_freeze.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("DETAIL DESCRIPTION")
        band_desc.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_break_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("TOTAL QTY DESIGN") 'diabaikan karena akan dimerge
        band_break_total.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_break As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("TOTAL QTY BREAKDOWN SIZE")
        band_break.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        Dim band_prc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("PRICE/COST")
        band_prc.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_sel As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("")
        band_sel.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        'declare band for merge coluumn
        Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
        Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

        'declare arr to store break sizw column initial
        Dim break_alloc_initial As New List(Of String)



        'query
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.queryLineList(id_season_param, id_type_param, show_breakdown_par)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        'properties column
        BGVParam.BeginUpdate()

        'setup band size total
        band_break.Columns.Add(BGVParam.Columns.AddVisible("brk_1", ""))
        band_break.Columns.Add(BGVParam.Columns.AddVisible("brk_2", ""))
        band_break.Columns.Add(BGVParam.Columns.AddVisible("brk_3", ""))
        band_break.Columns.Add(BGVParam.Columns.AddVisible("brk_4", ""))
        BGVParam.SetColumnPosition(BGVParam.Columns("brk_1"), 0, 0)
        BGVParam.SetColumnPosition(BGVParam.Columns("brk_2"), 1, 0)
        BGVParam.SetColumnPosition(BGVParam.Columns("brk_3"), 2, 0)
        BGVParam.SetColumnPosition(BGVParam.Columns("brk_4"), 3, 0)


        'var bantu utk band dinamis
        Dim i_break As Integer = 0

        For i As Integer = 0 To data.Columns.Count - 1
            'add to band
            If Not data.Columns(i).ColumnName.ToString.Contains("_stts") And Not data.Columns(i).ColumnName.ToString.Contains("_sct") And Not data.Columns(i).ColumnName.ToString.Contains("_Alloc") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_Breakdown") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_Prc") _
            Then
                If data.Columns(i).ColumnName.ToString = "NO" Or data.Columns(i).ColumnName.ToString = "CODE" Or data.Columns(i).ColumnName.ToString = "CODE IMPORT" Or data.Columns(i).ColumnName.ToString = "DESCRIPTION" Then
                    band_desc_freeze.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                Else
                    band_desc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If

                If data.Columns(i).ColumnName.ToString = "EOS" Or data.Columns(i).ColumnName.ToString = "IN STORE DATE" _
                Or data.Columns(i).ColumnName.ToString = "IN STORE DATE ACTUAL" _
                Or data.Columns(i).ColumnName.ToString = "RET DATE" _
                Or data.Columns(i).ColumnName.ToString = "ESTIMATE WH DATE" _
                Then
                    'display format for column date
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy"
                End If

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc") Then
                i_break += 1
                Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)
                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVParam.Bands
                    If group.Caption.ToString = str_arr(1).ToString Then
                        found_band = True
                        If str_arr(0).ToString = "TOTAL" Then
                            group.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                        Else
                            group.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))

                            'size position
                            Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                            BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                        End If
                        Exit For
                    End If
                Next group


                If Not found_band Then
                    If str_arr(0).ToString = "TOTAL" Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("TOTAL QTY " + str_arr(1).ToString)
                        band_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                        band_arr.AddMyMergeBand(band_new)
                    Else
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand(str_arr(1).ToString)
                        band_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                        band_alloc_break.AddMyMergeBand(band_new)

                        'initial to breakdown size
                        Dim band_dyn_name As String = "brk" + i_break.ToString + "_"
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                        band_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                        break_alloc_initial.Add(band_dyn_name + "1")
                        break_alloc_initial.Add(band_dyn_name + "2")
                        break_alloc_initial.Add(band_dyn_name + "3")
                        break_alloc_initial.Add(band_dyn_name + "4")

                        'size position
                        Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                        BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                    End If
                End If

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                BGVParam.GroupSummary.Add(item)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString = "TOTAL QTY_Breakdown" Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 10
                band_break_total.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                BGVParam.GroupSummary.Add(item)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Breakdown") And data.Columns(i).ColumnName.ToString <> "TOTAL QTY_Breakdown" Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 10
                band_break.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                'size position
                'Dim data_filter As DataRow() = data_band_break.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                'BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                'properties
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                BGVParam.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Prc") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_prc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                If data.Columns(i).ColumnName.ToString = "MARK UP_Prc" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 46
                    CType(BGVParam.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0:n2}"
                    item.Tag = 47
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                ElseIf Not data.Columns(i).ColumnName.ToString = "RATE IN RP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE COP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "CURRENCY ORIGIN_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP_Prc" _
                       And Not data.Columns(i).ColumnName.ToString = "MSRP IN RP_Prc" _
                       And Not data.Columns(i).ColumnName.ToString = "TARGET PRICE BASE ON MARKUP_Prc" _
                       And Not data.Columns(i).ColumnName.ToString = "TARGET PRICE_Prc" _
                       And Not data.Columns(i).ColumnName.ToString = "TARGET COST_Prc" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                End If
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_sct") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_sel.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))


                If data.Columns(i).ColumnName.ToString = "Select_sct" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                ElseIf data.Columns(i).ColumnName.ToString = "PROPOSE PRICE STATUS_sct" Or data.Columns(i).ColumnName.ToString = "PROPOSE PRICE NUMBER_sct" Or data.Columns(i).ColumnName.ToString = "id_report_status_sct" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                ElseIf data.Columns(i).ColumnName.ToString = "LAST UPDATED_sct"
                    'display format for column date
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy '/' hh:mm tt"
                End If
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            End If

            'READ ONLY
            If data.Columns(i).ColumnName.ToString = "Select_sct" Then
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ReadOnly = False
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).VisibleIndex = i
            Else
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ReadOnly = True
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).VisibleIndex = i
            End If

            'HIDE CUSTOMIZATION
            If data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "id_sample" _
            Or data.Columns(i).ColumnName.ToString = "id_season" Or data.Columns(i).ColumnName.ToString = "id_delivery" _
            Or data.Columns(i).ColumnName.ToString = "id_delivery_act" Or data.Columns(i).ColumnName.ToString = "id_season_orign" _
            Or data.Columns(i).ColumnName.ToString = "id_country" Or data.Columns(i).ColumnName.ToString = "design_name" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_upd" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_final" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_last" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_last" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_upd_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_final_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_report_status_sct" _
            Then
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ShowInCustomizationForm = False
            End If
            progres_bar_update(i, data.Columns.Count - 1)
        Next

        'dispose column
        BGVParam.Columns("brk_1").Dispose()
        BGVParam.Columns("brk_2").Dispose()
        BGVParam.Columns("brk_3").Dispose()
        BGVParam.Columns("brk_4").Dispose()
        For n_brk As Integer = 0 To (break_alloc_initial.Count - 1)
            BGVParam.Columns(break_alloc_initial(n_brk)).Dispose()
        Next

        'set datasource
        BGVParam.EndUpdate()
        GCParam.DataSource = data

        'merge band
        'band_arr.AddMyMergeBand(band_desc)
        'band_arr.AddMyMergeBand(band_break_total)
        'band_arr.AddMyMergeBand(band_prc)
        'band_arr.AddMyMergeBand(band_sel)
        'Dim helper As New MyPaintHelper(BGVParam, band_arr)


        'hide column
        BGVParam.Columns("id_lookup_status_order").Visible = False
        BGVParam.Columns("id_design").Visible = False
        BGVParam.Columns("id_sample").Visible = False
        BGVParam.Columns("id_season").Visible = False
        BGVParam.Columns("id_delivery").Visible = False
        BGVParam.Columns("id_delivery_act").Visible = False
        BGVParam.Columns("id_season_orign").Visible = False
        BGVParam.Columns("id_country").Visible = False
        BGVParam.Columns("design_name").Visible = False
        BGVParam.Columns("id_prod_demand_design_last").Visible = False
        BGVParam.Columns("id_prod_demand_last").Visible = False
        BGVParam.Columns("design_name").Visible = False
        BGVParam.Columns("id_prod_demand_design_line").Visible = False
        BGVParam.Columns("id_prod_demand_design_line_upd").Visible = False
        BGVParam.Columns("id_prod_demand_design_line_final").Visible = False
        BGVParam.Columns("TARGET PRICE BASE ON MARKUP_Prc").Visible = False
        BGVParam.Columns("id_design_type").Visible = False


        'hide band
        band_break.Visible = False
        'If show_breakdown_par Then
        '    For j As Integer = 0 To band_alloc_break.Length - 1
        '        band_alloc_break(j).Visible = False
        '    Next
        'End If

        'caption break size
        Dim typ As String = ""
        If id_type_param = "1" Then
            typ = "pdd.id_prod_demand_design = d.id_prod_demand_design_line "
        ElseIf id_type_param = "2" Then
            typ = "pdd.id_prod_demand_design = d.id_prod_demand_design_line_upd "
        Else
            typ = "pdd.id_prod_demand_design = d.id_prod_demand_design_line_final "
        End If
        Dim query_caption As String = "SELECT cd.index_size,CONCAT('qty',cd.index_size,'_Breakdown') AS `col`,GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.code_detail_name ASC SEPARATOR '\n') AS `caption` FROM tb_m_code_detail cd
         WHERE cd.id_code='33'
         AND cd.`index_size` IN (
             SELECT cd.`index_size` FROM tb_prod_demand_design pdd 
             INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design =  pdd.id_prod_demand_design
             INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
             INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
             INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
             INNER JOIN tb_m_design d ON d.id_design = p.id_design AND " + typ + "
             WHERE (d.id_season =" + id_season_param + " OR d.id_season_move =" + id_season_param + ")
	          AND pdp.prod_demand_product_qty>0
             GROUP BY cd.`index_size`
         )
         AND cd.`size_type` IN (
             SELECT cd.`size_type` FROM tb_prod_demand_design pdd 
             INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design =  pdd.id_prod_demand_design
             INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
             INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
             INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
             INNER JOIN tb_m_design d ON d.id_design = p.id_design AND " + typ + "
             WHERE (d.id_season =" + id_season_param + " OR d.id_season_move =" + id_season_param + ")
	         AND pdp.prod_demand_product_qty>0
             GROUP BY cd.`size_type`
         )
         GROUP BY cd.index_size "
        Dim data_caption As DataTable = execute_query(query_caption, -1, True, "", "", "", "")
        For c As Integer = 0 To data_caption.Rows.Count - 1
            BGVParam.Columns(data_caption.Rows(c)("col").ToString).Caption = data_caption.Rows(c)("caption").ToString
        Next

        'order BAND
        BGVParam.Bands.MoveTo(1, band_desc_freeze)
        BGVParam.Bands.MoveTo(2, band_desc)
        BGVParam.Bands.MoveTo(97, band_break_total)
        BGVParam.Bands.MoveTo(98, band_break)
        BGVParam.Bands.MoveTo(99, band_prc)
        BGVParam.Bands.MoveTo(100, band_sel)

        'create repository
        Dim riCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        riCheck.ValueChecked = "Yes"
        riCheck.ValueUnchecked = "No"
        GCParam.RepositoryItems.Add(riCheck)
        BGVParam.Columns("Select_sct").ColumnEdit = riCheck
        BGVParam.Columns("Select_sct").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BGVParam.Columns("Select_sct").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        riTE.NullText = "-"
        GCParam.RepositoryItems.Add(riTE)
        BGVParam.Columns("ESTIMATE WH DATE").ColumnEdit = riTE
        BGVParam.Columns("EOS").ColumnEdit = riTE
        BGVParam.Columns("IN STORE DATE").ColumnEdit = riTE
        BGVParam.Columns("RET DATE").ColumnEdit = riTE
        BGVParam.Columns("LAST UPDATED_sct").ColumnEdit = riTE

        'pic repo
        Dim unb_PE As DevExpress.XtraGrid.Columns.GridColumn = BGVParam.Columns.AddVisible("img", "IMAGE")
        unb_PE.UnboundType = DevExpress.Data.UnboundColumnType.Object
        BGVParam.Columns.Add(unb_PE)
        band_desc_freeze.Columns.Add(BGVParam.Columns("img"))
        band_desc_freeze.Columns.MoveTo(1, BGVParam.Columns("img"))
        BGVParam.Columns("img").AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim PE As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        PE.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        GCParam.RepositoryItems.Add(PE)
        BGVParam.Columns("img").ColumnEdit = PE
        BGVParam.Columns("img").Visible = False

        'freeze
        BGVParam.OptionsView.ColumnAutoWidth = False
        band_desc_freeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        ' 'hide PBC & Show GRID
        GCParam.Visible = True
        GCParam.RefreshDataSource()
        BGVParam.RefreshData()

        'clear band array
        band_arr = Nothing
        band_alloc_break = Nothing
        data_band_break = Nothing
        break_alloc_initial.Clear()

        'best Fit
        BGVParam.BestFitColumns()
    End Sub

    '============LINE LIST FINAL & SUMMARY
    Public Sub viewLineListFinal(ByVal id_season_param As String, ByVal id_type_param As String, ByVal BGVParam As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView, ByVal GCParam As DevExpress.XtraGrid.GridControl, ByVal data_band_break As DataTable, ByVal data_band_break_plan As DataTable, ByVal data_band_alloc As DataTable, ByVal data_band_alloc_plan As DataTable, ByVal show_breakdown_par As Boolean)
        'prepare
        GCParam.DataSource = Nothing
        GCParam.RepositoryItems.Clear()
        GCParam.RefreshDataSource()
        BGVParam.ApplyFindFilter("")
        BGVParam.ColumnPanelRowHeight = 40
        BGVParam.Columns.Clear()
        BGVParam.GroupSummary.Clear()
        'BGVParam.PopulateColumns()
        BGVParam.Bands.Clear()
        BGVParam.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BGVParam.OptionsBehavior.AutoExpandAllGroups = True

        ' Make the group footers always visible.
        BGVParam.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'create band
        Dim band_desc_freeze As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("GENERAL DESCRIPTION")
        band_desc_freeze.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("DETAIL DESCRIPTION")
        band_desc.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        Dim band_sel As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("")
        band_sel.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        'plan line list band's
        Dim band_plan As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("PLAN LINE LIST")
        band_plan.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        'actual line list band's
        Dim band_act As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("ACTUAL LINE LIST")
        band_act.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        'final line list band's
        Dim band_final As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVParam.Bands.AddBand("FINAL LINE LIST")
        band_final.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

        'declare band for merge coluumn
        Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
        Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

        'declare arr to store break sizw column initial
        Dim break_alloc_initial As New List(Of String)



        'query
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.queryLineList(id_season_param, id_type_param, show_breakdown_par)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'UPDATED 5 JAN 
        Dim data_band_break_rec As DataTable = query_c.getBreakTotalLineList("5")

        'properties column
        BGVParam.BeginUpdate()


        'var bantu utk band dinamis
        Dim i_break As Integer = 0
        Dim i_break_std As Integer = 0
        Dim i_break_plan As Integer = 0
        Dim i_break_std_plan As Integer = 0
        'Dim jx As Integer = 0
        'Dim gx As Integer = 0
        For i As Integer = 0 To data.Columns.Count - 1
            'add to band
            If Not data.Columns(i).ColumnName.ToString.Contains("_stts") And Not data.Columns(i).ColumnName.ToString.Contains("_sct") And Not data.Columns(i).ColumnName.ToString.Contains("_Alloc") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_Breakdown") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_ActRec") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_Prc") _
            And Not data.Columns(i).ColumnName.ToString.Contains("_Plan") _
            And Not data.Columns(i).ColumnName.ToString = "TOTAL QTY_Breakdown" _
            And Not data.Columns(i).ColumnName.ToString = "TOTAL ACTUAL RECEIVED_ActRec" _
            Then
                If data.Columns(i).ColumnName.ToString = "NO" Or data.Columns(i).ColumnName.ToString = "CODE" Or data.Columns(i).ColumnName.ToString = "CODE IMPORT" Or data.Columns(i).ColumnName.ToString = "DESCRIPTION" Then
                    band_desc_freeze.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                Else
                    band_desc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If

                If data.Columns(i).ColumnName.ToString = "EOS" Or data.Columns(i).ColumnName.ToString = "IN STORE DATE" _
                Or data.Columns(i).ColumnName.ToString = "RET DATE" _
                Or data.Columns(i).ColumnName.ToString = "ESTIMATE WH DATE" _
                Then
                    'display format for column date
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy"
                End If

                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_sct") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_sel.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                If data.Columns(i).ColumnName.ToString = "Select_sct" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                ElseIf data.Columns(i).ColumnName.ToString = "PROPOSE PRICE STATUS_sct" Or data.Columns(i).ColumnName.ToString = "PROPOSE PRICE NUMBER_sct" Or data.Columns(i).ColumnName.ToString = "id_report_status_sct" Then
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                ElseIf data.Columns(i).ColumnName.ToString = "LAST UPDATED_sct" Then
                    'display format for column date
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy '/' hh:mm tt"
                Else
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    If data.Columns(i).ColumnName.ToString = "LOCKED TIME_sct" Or data.Columns(i).ColumnName.ToString = "LOCKED TIME _sct" Or data.Columns(i).ColumnName.ToString = "LOCKED TIME  _sct" Then
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy hh:mm"
                    Else
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMMM yyyy"
                    End If
                End If
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Plan") Then
                '==========NESTED BANDS FOR PLAN=============
                If data.Columns(i).ColumnName.ToString.Contains("_Breakdown_Plan") And data.Columns(i).ColumnName.ToString <> "TOTAL QTY_Breakdown_Plan" Then
                    '------TOTAL BREAKDOWN SIZE PLAN
                    i_break_std_plan += 1
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 15
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_plan.Children
                        If gbc.Caption.ToString = "TOTAL QTY BREAKDOWN SIZE" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_plan.Children.AddBand("TOTAL QTY BREAKDOWN SIZE")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_alloc_break.AddMyMergeBand(bandc_new)

                        'initial to breakdown size
                        Dim band_dyn_name As String = "brk_std_plan_" + i_break_std_plan.ToString + "_"
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                        break_alloc_initial.Add(band_dyn_name + "1")
                        break_alloc_initial.Add(band_dyn_name + "2")
                        break_alloc_initial.Add(band_dyn_name + "3")
                        break_alloc_initial.Add(band_dyn_name + "4")
                    End If

                    'size position
                    Dim data_filter As DataRow() = data_band_break_plan.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                    BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString = "TOTAL QTY_Breakdown_Plan" Then
                    '------TOTAL QTY
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 15
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_plan.Children
                        If gbc.Caption.ToString = "TOTAL QTY" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_plan.Children.AddBand("TOTAL QTY DESIGN")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc_Plan") Then
                    '---------ALLOC
                    i_break_plan += 1
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_plan.Children
                        If gbc.Caption.ToString = str_arr(1).ToString Then
                            found_band_2 = True
                            If str_arr(0).ToString = "TOTAL" Then
                                gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            Else
                                gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                                'size position
                                Dim data_filterx As DataRow() = data_band_alloc_plan.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                                BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                            End If
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        If str_arr(0).ToString = "TOTAL" Then
                            Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_plan.Children.AddBand("TOTAL QTY " + str_arr(1).ToString)
                            bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                            bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            'bandc_new.OptionsBand.ShowCaption = False
                            band_arr.AddMyMergeBand(bandc_new)
                        Else
                            Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_plan.Children.AddBand(str_arr(1).ToString)
                            bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                            band_alloc_break.AddMyMergeBand(bandc_new)

                            'initial to breakdown size
                            Dim band_dyn_name As String = "brk_plan" + i_break.ToString + "_"
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                            break_alloc_initial.Add(band_dyn_name + "1")
                            break_alloc_initial.Add(band_dyn_name + "2")
                            break_alloc_initial.Add(band_dyn_name + "3")
                            break_alloc_initial.Add(band_dyn_name + "4")

                            'size position
                            Dim data_filterx As DataRow() = data_band_alloc_plan.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                            BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                        End If
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                Else
                    '------PRC BAND
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 9
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_plan.Children
                        If gbc.Caption.ToString = "TOTAL PRICE / COST" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_plan.Children.AddBand("TOTAL PRICE / COST")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        'bandc_new.OptionsBand.ShowCaption = False
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                    If data.Columns(i).ColumnName.ToString = "MARK UP_Prc_Plan" Then
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 46
                        CType(BGVParam.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        item.DisplayFormat = "{0:n2}"
                        item.Tag = 47
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    ElseIf Not data.Columns(i).ColumnName.ToString = "RATE IN RP_Prc_Plan" _
                    And Not data.Columns(i).ColumnName.ToString = "CURRENCY ORIGIN_Prc_Plan" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP_Prc_Plan" _
                     And Not data.Columns(i).ColumnName.ToString = "MSRP IN RP_Prc_Plan" _
                     And Not data.Columns(i).ColumnName.ToString = "TARGET PRICE BASE ON MARKUP_Prc_Plan" Then
                        'gx += 1
                        'Console.WriteLine("GX = " + gx.ToString)
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n2}"
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    End If
                End If
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Final") Then
                '==========NESTED BANDS FOR FINAL=============
                If data.Columns(i).ColumnName.ToString = "TOTAL QTY_Breakdown_Final" Then
                    '------TOTAL QTY
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 16
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_final.Children
                        If gbc.Caption.ToString = "TOTAL QTY" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_final.Children.AddBand("TOTAL QTY DESIGN")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                Else
                    '------PRC BAND
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 10
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_final.Children
                        If gbc.Caption.ToString = "TOTAL PRICE / COST" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_final.Children.AddBand("TOTAL PRICE / COST")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        'bandc_new.OptionsBand.ShowCaption = False
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                    If data.Columns(i).ColumnName.ToString = "MARK UP_Prc_Final" Then
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 46
                        CType(BGVParam.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        item.DisplayFormat = "{0:n2}"
                        item.Tag = 47
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    ElseIf Not data.Columns(i).ColumnName.ToString = "RATE IN RP_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP IN RP_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "TARGET PRICE BASE ON MARKUP_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE BOM_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE BOM_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE MANAGEMENT_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE MANAGEMENT_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE PD_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE PD_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "id_cop_status_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "CURRENCY ORIGIN_Prc_Final" _
                    And Not data.Columns(i).ColumnName.ToString = "COP STATUS_Prc_Final" Then
                        'gx += 1
                        'Console.WriteLine("GX = " + gx.ToString)
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n2}"
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    End If
                End If
            Else
                '==========NESTED BANDS FOR ACTUAL=============
                If data.Columns(i).ColumnName.ToString.Contains("_Breakdown") And data.Columns(i).ColumnName.ToString <> "TOTAL QTY_Breakdown" Then
                    '------TOTAL BREAKDOWN SIZE
                    i_break_std += 1
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 10
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_act.Children
                        If gbc.Caption.ToString = "TOTAL QTY BREAKDOWN SIZE" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand("TOTAL QTY BREAKDOWN SIZE")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_alloc_break.AddMyMergeBand(bandc_new)

                        'initial to breakdown size
                        Dim band_dyn_name As String = "brk_std_" + i_break_std.ToString + "_"
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                        break_alloc_initial.Add(band_dyn_name + "1")
                        break_alloc_initial.Add(band_dyn_name + "2")
                        break_alloc_initial.Add(band_dyn_name + "3")
                        break_alloc_initial.Add(band_dyn_name + "4")
                    End If

                    'size position
                    Dim data_filter As DataRow() = data_band_break.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                    BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString = "TOTAL QTY_Breakdown" Then
                    '------TOTAL QTY
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 10
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_act.Children
                        If gbc.Caption.ToString = "TOTAL QTY" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand("TOTAL QTY DESIGN")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_ActRec") And data.Columns(i).ColumnName.ToString <> "TOTAL ACTUAL RECEIVED_ActRec" Then
                    '------TOTAL BREAKDOWN ACTUAL RECEIVED
                    i_break_std += 1
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 7
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_act.Children
                        If gbc.Caption.ToString = "TOTAL ACTUAL RECEIVED BREAKDOWN SIZE" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand("TOTAL ACTUAL RECEIVED BREAKDOWN SIZE")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_alloc_break.AddMyMergeBand(bandc_new)

                        'initial to breakdown size
                        Dim band_dyn_name As String = "brk_act_" + i_break_std.ToString + "_"
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                        BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                        break_alloc_initial.Add(band_dyn_name + "1")
                        break_alloc_initial.Add(band_dyn_name + "2")
                        break_alloc_initial.Add(band_dyn_name + "3")
                        break_alloc_initial.Add(band_dyn_name + "4")
                    End If

                    'size position
                    Dim data_filter As DataRow() = data_band_break_rec.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                    BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString = "TOTAL ACTUAL RECEIVED_ActRec" Then
                    '------TOTAL ACTUAL RECEIVED
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 7
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_final.Children
                        If gbc.Caption.ToString = "TOTAL ACTUAL RECEIVED" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_final.Children.AddBand("TOTAL ACTUAL RECEIVED")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True


                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Alloc") Then
                    '---------ALLOC
                    i_break += 1
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("_"c)
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_act.Children
                        If gbc.Caption.ToString = str_arr(1).ToString Then
                            found_band_2 = True
                            If str_arr(0).ToString = "TOTAL" Then
                                gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            Else
                                gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                                'size position
                                Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                                BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                            End If
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        If str_arr(0).ToString = "TOTAL" Then
                            Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand("TOTAL QTY " + str_arr(1).ToString)
                            bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                            bandc_new.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(1).ToString))
                            'bandc_new.OptionsBand.ShowCaption = False
                            band_arr.AddMyMergeBand(bandc_new)
                        Else
                            Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand(str_arr(1).ToString)
                            bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(0).ToString))
                            band_alloc_break.AddMyMergeBand(bandc_new)

                            'initial to breakdown size
                            Dim band_dyn_name As String = "brk" + i_break.ToString + "_"
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "1", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "2", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "3", ""))
                            bandc_new.Columns.Add(BGVParam.Columns.AddVisible(band_dyn_name + "4", ""))
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "1"), 0, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "2"), 1, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "3"), 2, 0)
                            BGVParam.SetColumnPosition(BGVParam.Columns(band_dyn_name + "4"), 3, 0)
                            break_alloc_initial.Add(band_dyn_name + "1")
                            break_alloc_initial.Add(band_dyn_name + "2")
                            break_alloc_initial.Add(band_dyn_name + "3")
                            break_alloc_initial.Add(band_dyn_name + "4")

                            'size position
                            Dim data_filterx As DataRow() = data_band_alloc.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                            BGVParam.SetColumnPosition(BGVParam.Columns(data.Columns(i).ColumnName.ToString), data_filterx(0)("code_row_index").ToString, data_filterx(0)("code_col_index").ToString)
                        End If
                    End If

                    'properties
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                    BGVParam.GroupSummary.Add(item)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                Else
                    '------PRC BAND
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                    Dim found_band_2 As Boolean = False
                    For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band_act.Children
                        If gbc.Caption.ToString = "TOTAL PRICE / COST" Then
                            found_band_2 = True
                            gbc.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                            Exit For
                        End If
                    Next

                    If Not found_band_2 Then
                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_act.Children.AddBand("TOTAL PRICE / COST")
                        bandc_new.AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                        'bandc_new.OptionsBand.ShowCaption = False
                        bandc_new.Columns.Add(BGVParam.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                        band_arr.AddMyMergeBand(bandc_new)
                    End If
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                    BGVParam.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
                    If data.Columns(i).ColumnName.ToString = "MARK UP_Prc" Then
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.Tag = 48
                        CType(BGVParam.Columns(data.Columns(i).ColumnName.ToString).View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        item.DisplayFormat = "{0:n2}"
                        item.Tag = 49
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    ElseIf Not data.Columns(i).ColumnName.ToString = "RATE IN RP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "MSRP IN RP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "TARGET PRICE BASE ON MARKUP_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE BOM_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE BOM_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE MANAGEMENT_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE MANAGEMENT_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "RATE PD_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "ORGANIC COST RATE PD_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "id_cop_status_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "CURRENCY ORIGIN_Prc" _
                    And Not data.Columns(i).ColumnName.ToString = "COP STATUS_Prc" Then
                        'jx += 1
                        'Console.WriteLine("Jx = " + jx.ToString)
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        BGVParam.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = data.Columns(i).ColumnName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n0}"
                        item.ShowInGroupColumnFooter = BGVParam.Columns(data.Columns(i).ColumnName.ToString)
                        BGVParam.GroupSummary.Add(item)
                    End If
                End If
            End If

            'READ ONLY
            If data.Columns(i).ColumnName.ToString = "Select_sct" Then
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ReadOnly = False
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).VisibleIndex = i
            Else
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ReadOnly = True
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).VisibleIndex = i
            End If

            'HIDE CUSTOMIZATION
            If data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "id_sample" _
            Or data.Columns(i).ColumnName.ToString = "id_season" Or data.Columns(i).ColumnName.ToString = "id_delivery" _
            Or data.Columns(i).ColumnName.ToString = "id_delivery_act" Or data.Columns(i).ColumnName.ToString = "id_season_orign" _
            Or data.Columns(i).ColumnName.ToString = "id_country" Or data.Columns(i).ColumnName.ToString = "design_name" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_upd" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_final" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_last" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_last" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_upd_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_demand_design_line_final_lock" _
            Or data.Columns(i).ColumnName.ToString = "id_report_status" _
            Then
                BGVParam.Columns(data.Columns(i).ColumnName.ToString).OptionsColumn.ShowInCustomizationForm = False
            End If
            progres_bar_update(i, data.Columns.Count - 1)
        Next

        'dispose column breakdown
        For n_brk As Integer = 0 To (break_alloc_initial.Count - 1)
            BGVParam.Columns(break_alloc_initial(n_brk)).Dispose()
        Next

        'parse data
        BGVParam.EndUpdate()
        GCParam.DataSource = data

        'merge bands
        'band_arr.AddMyMergeBand(band_desc_freeze)
        'band_arr.AddMyMergeBand(band_desc)
        'band_arr.AddMyMergeBand(band_sel)
        'Dim helper As New MyPaintHelper(BGVParam, band_arr)


        'hide column
        BGVParam.Columns("id_lookup_status_order").Visible = False
        BGVParam.Columns("id_design").Visible = False
        BGVParam.Columns("id_sample").Visible = False
        BGVParam.Columns("id_season").Visible = False
        BGVParam.Columns("id_delivery").Visible = False
        BGVParam.Columns("id_delivery_act").Visible = False
        BGVParam.Columns("id_season_orign").Visible = False
        BGVParam.Columns("id_country").Visible = False
        BGVParam.Columns("design_name").Visible = False
        BGVParam.Columns("id_prod_demand_design_last").Visible = False
        BGVParam.Columns("id_prod_demand_last").Visible = False
        BGVParam.Columns("design_name").Visible = False
        BGVParam.Columns("id_prod_demand_design_line").Visible = False
        BGVParam.Columns("id_prod_demand_design_line_upd").Visible = False
        BGVParam.Columns("id_prod_demand_design_line_final").Visible = False
        BGVParam.Columns("id_report_status").Visible = False
        BGVParam.Columns("id_cop_status_Prc").Visible = False
        BGVParam.Columns("COP PD").Visible = False
        BGVParam.Columns("PRICE PD").Visible = False
        BGVParam.Columns("MSRP PD").Visible = False
        BGVParam.Columns("MSRP RP PD").Visible = False
        'BGVParam.Columns("RATE BOM_Prc").Visible = False
        'BGVParam.Columns("ORGANIC COST RATE BOM_Prc").Visible = False
        'BGVParam.Columns("RATE MANAGEMENT_Prc").Visible = False
        'BGVParam.Columns("ORGANIC COST RATE MANAGEMENT_Prc").Visible = False
        BGVParam.Columns("RATE PD_Prc").Visible = False
        BGVParam.Columns("ORGANIC COST RATE PD_Prc").Visible = False
        'BGVParam.Columns("COP STATUS_Prc").Visible = False
        BGVParam.Columns("id_design_type").Visible = False


        'hide band
        If show_breakdown_par Then
            For j As Integer = 0 To band_alloc_break.Length - 1
                band_alloc_break(j).Visible = False
            Next
        End If


        'order BAND
        BGVParam.Bands.MoveTo(1, band_desc_freeze)
        BGVParam.Bands.MoveTo(2, band_desc)
        BGVParam.Bands.MoveTo(99, band_sel)

        'create repository
        Dim riCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        riCheck.ValueChecked = "Yes"
        riCheck.ValueUnchecked = "No"
        GCParam.RepositoryItems.Add(riCheck)
        BGVParam.Columns("Select_sct").ColumnEdit = riCheck
        BGVParam.Columns("Select_sct").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BGVParam.Columns("Select_sct").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        riTE.NullText = "-"
        GCParam.RepositoryItems.Add(riTE)
        BGVParam.Columns("ESTIMATE WH DATE").ColumnEdit = riTE
        BGVParam.Columns("EOS").ColumnEdit = riTE
        BGVParam.Columns("LAST UPDATED_sct").ColumnEdit = riTE

        'pic repo
        Dim unb_PE As DevExpress.XtraGrid.Columns.GridColumn = BGVParam.Columns.AddVisible("img", "IMAGE")
        unb_PE.UnboundType = DevExpress.Data.UnboundColumnType.Object
        BGVParam.Columns.Add(unb_PE)
        band_desc_freeze.Columns.Add(BGVParam.Columns("img"))
        band_desc_freeze.Columns.MoveTo(1, BGVParam.Columns("img"))
        BGVParam.Columns("img").AppearanceHeader.Font = New Font(BGVParam.Appearance.Row.Font.FontFamily, BGVParam.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim PE As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        PE.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        GCParam.RepositoryItems.Add(PE)
        BGVParam.Columns("img").ColumnEdit = PE
        BGVParam.Columns("img").Visible = False

        'freeze
        BGVParam.OptionsView.ColumnAutoWidth = False
        band_desc_freeze.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        ' 'hide PBC & Show GRID
        GCParam.Visible = True
        GCParam.RefreshDataSource()
        BGVParam.RefreshData()

        'clear band array
        band_arr = Nothing
        band_alloc_break = Nothing
        data_band_break = Nothing
        break_alloc_initial.Clear()

        'best Fit
        BGVParam.BestFitColumns()
    End Sub

    Public Function getLineActFocus(ByVal type_par As String, ByVal BGVParam As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView) As String
        Dim ret As String = "1"
        Return ret
    End Function

    Public Function getRetCodeQuery(ByVal cond_param As String) As String
        Dim query As String = ""
        query += "SELECT * "
        query += "FROM tb_lookup_ret_code a "
        query += "WHERE a.id_ret_code>'0' "
        If cond_param <> "-1" Then
            query += cond_param
        End If
        query += "ORDER BY a.ret_code ASC "
        Return query
    End Function

    Public Function getCostHistQuery(ByVal id_design_param As String) As String
        Dim query As String = ""
        query += "SELECT a.*, c.employee_name, d.currency "
        query += "FROM tb_prod_demand_log_cost a "
        query += "INNER JOIN tb_m_user b ON a.id_user = b.id_user "
        query += "INNER JOIN tb_m_employee c ON c.id_employee = b.id_employee "
        query += "LEFT JOIN tb_lookup_currency d ON a.id_currency = d.id_currency "
        query += "WHERE a.id_design = '" + id_design_param + "' "
        query += "ORDER BY a.prod_demand_log_cost_time ASC "
        Return query
    End Function

    Public Function getRateStore(ByVal cond_param As String)
        Dim query As String = ""
        query += "SELECT * "
        query += "FROM tb_lookup_store_rate a "
        query += "WHERE a.id_store_rate>'0' "
        If cond_param <> "-1" Then
            query += cond_param
        End If
        query += "ORDER BY a.store_rate ASC "
        Return query
    End Function

    '********************
    'DISTRIBUTION SCHEME
    '********************
    Public Sub loadDS(ByVal id_season_par As String, ByVal id_type_par As String, ByVal GCDS As DevExpress.XtraGrid.GridControl, ByVal GVDS As DevExpress.XtraGrid.Views.Grid.GridView, ByVal id_trans_par As String, ByVal opt As String)
        Dim jum_cek As String = execute_query("SELECT COUNT(*) FROM tb_fg_ds_store WHERE id_season='" + id_season_par + "' ", 0, True, "", "", "", "")
        If jum_cek > 0 Then
            Try
                GCDS.DataSource = Nothing
                GCDS.RepositoryItems.Clear()
                GCDS.RefreshDataSource()
                GVDS.ApplyFindFilter("")
                GVDS.ColumnPanelRowHeight = 40
                GVDS.Columns.Clear()
                GVDS.GroupSummary.Clear()
                GVDS.OptionsBehavior.AutoExpandAllGroups = True

                ' Make the group footers always visible.
                GVDS.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

                Dim query As String = ""
                If opt = "1" Then
                    query = "CALL view_fg_ds('" + id_season_par + "', '" + id_type_par + "')"
                ElseIf opt = "2" Then
                    query = "CALL view_fg_so_reff('" + id_trans_par + "', '" + id_season_par + "') "
                End If
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCDS.DataSource = data

                'visible = false column
                GVDS.Columns("id_product").Visible = False
                GVDS.Columns("id_design").Visible = False
                GVDS.Columns("id_design_price").Visible = False
                If id_type_par = "1" Then
                    GVDS.Columns("VARIANCE#total#").Visible = False
                    GVDS.Columns("ORDER#total#").Visible = False
                    GVDS.Columns("RECEIVING WH#total#").Visible = False
                    GVDS.Columns("RECEIVING WH-NORMAL#total#").Visible = False
                    GVDS.Columns("RECEIVING WH-REJECT MINOR#total#").Visible = False
                    GVDS.Columns("RECEIVING WH-REJECT MAJOR#total#").Visible = False
                    GVDS.Columns("SELECT").Visible = False
                    GVDS.Columns("PRICE").Visible = False
                    'GVDS.Columns("RECEIVING#total#").Visible = False
                    'GVDS.Columns("SOH#total#").Visible = False
                ElseIf id_type_par = "2" Then
                    'GVDS.Columns("RECEIVING#total#").Visible = False
                    'GVDS.Columns("SOH#total#").Visible = False
                    GVDS.Columns("RECEIVING WH-NORMAL#total#").Visible = True
                    GVDS.Columns("RECEIVING WH-REJECT MINOR#total#").Visible = False
                    GVDS.Columns("RECEIVING WH-REJECT MAJOR#total#").Visible = False
                    GVDS.Columns("SELECT").Visible = False
                    GVDS.Columns("PRICE").Visible = False
                ElseIf id_type_par = "3" Then
                    GVDS.Columns("RECEIVING WH#total#").Visible = False

                    'create repository SELECT
                    Dim riCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                    riCheck.ValueChecked = "Yes"
                    riCheck.ValueUnchecked = "No"
                    GCDS.RepositoryItems.Add(riCheck)
                    GVDS.Columns("SELECT").ColumnEdit = riCheck
                    GVDS.Columns("SELECT").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVDS.Columns("SELECT").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                'repository SPIN EDIT
                Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
                riTE.IsFloatValue = False
                riTE.MaxLength = 0
                riTE.MinValue = 0
                riTE.MaxValue = 999999999
                riTE.Buttons.Clear()
                GCDS.RepositoryItems.Add(riTE)


                'change caption
                For j As Integer = 0 To GVDS.Columns.Count - 1
                    Dim col As String = GVDS.Columns(j).FieldName.ToString
                    GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.Font = New Font(GVDS.Appearance.Row.Font.FontFamily, GVDS.Appearance.Row.Font.Size, FontStyle.Bold)
                    GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

                    If col.Contains("#id#") Then
                        Dim str_arr As String() = Split(col.ToString, "#id#")
                        GVDS.Columns(j).Caption = str_arr(0).ToString
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).ColumnEdit = riTE

                        'summary
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).SummaryItem.DisplayFormat = "{0:n0}"
                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = GVDS.Columns(j).FieldName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n0}"
                        item.ShowInGroupColumnFooter = GVDS.Columns(GVDS.Columns(j).FieldName.ToString)
                        GVDS.GroupSummary.Add(item)
                    ElseIf col.Contains("#total#") Then
                        Dim str_arr As String() = Split(col.ToString, "#total#")
                        GVDS.Columns(j).Caption = str_arr(0).ToString
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                        'summary
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).SummaryItem.DisplayFormat = "{0:n0}"
                        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                        item.FieldName = GVDS.Columns(j).FieldName.ToString
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = "{0:n0}"
                        item.ShowInGroupColumnFooter = GVDS.Columns(GVDS.Columns(j).FieldName.ToString)
                        GVDS.GroupSummary.Add(item)

                        'exception
                        If col = "RECEIVING WH#total#" Then
                            GVDS.Columns("RECEIVING WH#total#").Caption = "RECEIVING TOTAL"
                        End If
                    Else
                        If col = "SELECT" Then
                            GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        ElseIf col = "PRICE" Then
                            GVDS.Columns(GVDS.Columns(j).FieldName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            GVDS.Columns(GVDS.Columns(j).FieldName.ToString).DisplayFormat.FormatString = "{0:n2}"
                        Else
                            GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        End If
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    End If

                    'READ ONLY
                    If col = "SELECT" Then
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).OptionsColumn.ReadOnly = False
                    Else
                        GVDS.Columns(GVDS.Columns(j).FieldName.ToString).OptionsColumn.ReadOnly = True
                    End If
                Next

                'static width column
                GVDS.Columns("SIZE").Width = 50

                'group
                GVDS.Columns("CLASS").GroupIndex = 0
                GVDS.Columns("DESCRIPTION").GroupIndex = 1

                'best fit
                'GVDS.BestFitColumns()
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            stopCustom("View is not available for this time.")
            GCDS.DataSource = Nothing
            GCDS.RepositoryItems.Clear()
            GCDS.RefreshDataSource()
            GVDS.ApplyFindFilter("")
            GVDS.ColumnPanelRowHeight = 40
            GVDS.Columns.Clear()
            GVDS.GroupSummary.Clear()
        End If
    End Sub

    '***********************
    'MASTER PRICE FROM EXCEL
    '***********************
    Public Function queryPriceExcelMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT prc.id_fg_price, prc.id_design_price_type, prc.fg_price_number, prc.fg_price_date, DATE_FORMAT(prc.fg_price_date, '%Y-%m-%d') AS fg_price_datex, IF(prc.fg_effective_date = '0000-00-00', prc.fg_price_date, prc.fg_effective_date) fg_effective_date, prc.fg_price_note, prc.id_report_status,stt.report_status "
        query += "FROM tb_fg_price prc "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = prc.id_report_status "
        query += "LEFT JOIN tb_report_mark rm ON rm.id_report = prc.id_fg_price AND rm.report_mark_type=82 AND rm.id_report_status=1 "
        query += "WHERE prc.id_fg_price>0 " + condition
        query += "ORDER BY prc.id_fg_price  " + order_type
        Return query
    End Function

    Public Function queryPriceExcelDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_price('" + id_report_param + "')"
        Return query
    End Function

    Public Function dataMasterSalUnique(ByVal id_store As String) As DataTable
        Dim query As String = "SELECT a.id_product, a.`id_pl_prod_order_rec_det_unique`, a.`full_code`, a.`code`, a.counting, a.`name`, cd.code_detail_name AS `size`, a.`is_old_design`, a.is_unique_report
        FROM (
	        SELECT u.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, 1 AS `qty`, u.is_unique_report
	        FROM tb_m_unique_code u
	        INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
	        WHERE u.id_comp=" + id_store + " AND u.is_unique_report=2
	        GROUP BY u.id_product
	        UNION ALL
	        SELECT u.id_product, c.id_pl_prod_order_rec_det_unique,u.unique_code AS `full_code`, prod.product_full_code AS `code`, RIGHT(u.unique_code,4) AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, IFNULL(SUM(u.qty),0) AS `qty`, u.is_unique_report
	        FROM tb_m_unique_code u
	        INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
	        INNER JOIN tb_pl_prod_order_rec_det_counting c ON c.id_product = u.id_product AND c.pl_prod_order_rec_det_counting = RIGHT(u.unique_code,4)
            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1
	        GROUP BY u.unique_code
            HAVING qty=1
	        UNION ALL
            SELECT deld.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
	        FROM tb_pl_sales_order_del del
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
	        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
	        INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
	        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	        WHERE del.id_report_status=6 AND cc.id_comp=" + id_store + " AND dsg.is_old_design=1
	        GROUP BY deld.id_product
            UNION
            SELECT prod.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
            FROM tb_m_product prod 
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
            WHERE dsg.is_old_design=1 
            GROUP BY prod.id_product
        ) a
        INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = a.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodcode.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function dataMasterCNUnique(ByVal id_store As String) As DataTable
        Dim query As String = "SELECT a.id_product, a.`id_pl_prod_order_rec_det_unique`, a.`full_code`, a.`code`, a.counting, a.`name`, cd.code_detail_name AS `size`, a.`is_old_design`, a.is_unique_report
        FROM (
	        SELECT u.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, 1 AS `qty`, u.is_unique_report
	        FROM tb_m_unique_code u
	        INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
	        WHERE u.id_comp=" + id_store + " AND u.is_unique_report=2
	        GROUP BY u.id_product
	        UNION ALL
	        SELECT u.id_product, c.id_pl_prod_order_rec_det_unique,u.unique_code AS `full_code`, prod.product_full_code AS `code`, RIGHT(u.unique_code,4) AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, IFNULL(SUM(u.qty),0) AS `qty`, u.is_unique_report
            FROM tb_m_unique_code u
            INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
            INNER JOIN tb_pl_prod_order_rec_det_counting c ON c.id_product = u.id_product AND c.pl_prod_order_rec_det_counting = RIGHT(u.unique_code,4)
            LEFT JOIN (
	            SELECT * FROM (
		            SELECT u.id_type, u.unique_code, u.input_date
		            FROM tb_m_unique_code u
		            INNER JOIN tb_pl_sales_order_del_det_counting delc ON delc.id_pl_sales_order_del_det_counting = u.id_pl_sales_order_del_det_counting
		            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND u.id_type=1
		            UNION ALL
		            SELECT u.id_type, u.unique_code, u.input_date
		            FROM tb_m_unique_code u
		            INNER JOIN tb_sales_pos_det_counting salc ON salc.id_sales_pos_det_counting = u.id_sales_pos_det_counting
		            INNER JOIN tb_sales_pos sal ON sal.id_sales_pos = salc.id_sales_pos
		            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND u.id_type=2 AND sal.id_report_status=6
		            UNION ALL
		            SELECT u.id_type, u.unique_code, u.input_date
		            FROM tb_m_unique_code u
		            INNER JOIN tb_sales_pos_det_counting cnc ON cnc.id_sales_pos_det_counting = u.id_sales_pos_det_counting_cn
		            INNER JOIN tb_sales_pos cn ON cn.id_sales_pos = cnc.id_sales_pos
		            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND u.id_type=3 AND cn.id_report_status!=5
		            UNION ALL
		            SELECT u.id_type, u.unique_code, u.input_date
		            FROM tb_m_unique_code u
		            INNER JOIN tb_sales_return_det_counting retc ON retc.id_sales_return_det_counting = u.id_sales_return_det_counting
		            INNER JOIN tb_sales_return_det retd ON retd.id_sales_return_det = retc.id_sales_return_det
		            INNER JOIN tb_sales_return ret ON ret.id_sales_return = retd.id_sales_return
		            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND u.id_type=4 AND ret.id_report_status!=5
		            UNION ALL
		            SELECT u.id_type, u.unique_code, u.input_date
		            FROM tb_m_unique_code u
		            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND u.id_type=5
		            ORDER BY input_date DESC
	            ) a 
	            GROUP BY a.unique_code
            ) lt ON lt.unique_code = u.unique_code
            LEFT JOIN (
                SELECT cnc.full_code
                FROM tb_sales_pos_det_counting cnc
                INNER JOIN tb_sales_pos_det_counting
                INNER JOIN tb_sales_pos cn ON cn.id_sales_pos = cnc.id_sales_pos
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = cn.id_store_contact_from
                WHERE cc.id_comp=" + id_store + " AND (cn.report_mark_type=66 OR cn.report_mark_type=67 OR cn.report_mark_type=118)
                AND (cn.id_report_status<5)  
                GROUP BY cnc.full_code
            ) o ON o.full_code =  u.unique_code
            WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1 AND lt.id_type=2 AND ISNULL(o.`full_code`)
            GROUP BY u.unique_code
	        UNION ALL
	        SELECT deld.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
	        FROM tb_pl_sales_order_del del
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
	        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
	        INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
	        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	        WHERE del.id_report_status=6 AND cc.id_comp=" + id_store + " AND dsg.is_old_design=1
	        GROUP BY deld.id_product
            UNION
            SELECT prod.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
            FROM tb_m_product prod 
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
            WHERE dsg.is_old_design=1 
            GROUP BY prod.id_product
        ) a
        INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = a.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodcode.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryProposeChanges(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT dc.id_changes, dc.number, dc.created_date, dc.note, dc.id_report_status, rs.report_status , dc.is_confirm, dc.is_md
        FROM tb_m_design_changes dc
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = dc.id_report_status
        WHERE dc.id_changes>0 " + condition
        query += "ORDER BY dc.id_changes  " + order_type
        Return query
    End Function

    Public Function queryPCDBodyDetail(ByVal id) As String
        Dim id_code_fg_sht As String = get_setup_field("id_code_fg_sht")

        Dim query As String = "FROM tb_m_design_changes_det det
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = det.id_prod_demand_design
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1
        LEFT JOIN tb_prod_order po ON po.id_prod_order = det.id_prod_order
        INNER JOIN tb_m_design d ON d.id_design = det.id_design
        INNER JOIN tb_season_orign sor ON sor.id_season_orign = d.id_season_orign
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `source_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=5
        ) src_new ON src_new.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `division_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=32
        ) dvs_new ON dvs_new.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `sub_category_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=31
        ) subcat_new ON subcat_new.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `class_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=30
        ) cls_new ON cls_new.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `color_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=14
        ) col_new ON col_new.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `sht_name_new`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=" + id_code_fg_sht + "
        ) sht_new ON sht_new.id_design = d.id_design
        INNER JOIN tb_m_design dr ON dr.id_design = d.id_design_rev_from
        INNER JOIN tb_season_orign sordr ON sordr.id_season_orign = dr.id_season_orign
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `source`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=5
        ) src ON src.id_design = dr.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `division`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=32
        ) dvs ON dvs.id_design = dr.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.code_detail_name AS `sub_category`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=31
        ) subcat ON subcat.id_design = dr.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `class`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=30
        ) cls ON cls.id_design = dr.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `color`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=14
        ) col ON col.id_design = dr.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code, cd.display_name AS `sht_name`
	        FROM tb_m_design_changes_det det
	        INNER JOIN tb_m_design d ON d.id_design = det.id_design
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design_rev_from
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        WHERE det.id_changes=" + id + " AND cd.id_code=" + id_code_fg_sht + "
        ) sht ON sht.id_design = dr.id_design
        LEFT JOIN tb_lookup_cool_storage AS cst ON d.is_cold_storage = cst.id_cool_storage
        LEFT JOIN tb_lookup_cool_storage AS cstdr ON dr.is_cold_storage = cstdr.id_cool_storage
        WHERE det.id_changes=" + id + " "
        Return query
    End Function

    Function checkGWPPrice(ByVal GVItemList As DevExpress.XtraGrid.Views.Grid.GridView) As String
        Dim sku_gwp_no_price As String = ""
        GVItemList.ActiveFilterString = ""
        GVItemList.ActiveFilterString = "StartsWith([code], '8888')"
        If GVItemList.RowCount <= 0 Then
            sku_gwp_no_price = ""
        Else
            'cek gwp
            Dim qgwp As String = "SELECT d.id_design, p.product_full_code,d.design_code, d.design_display_name, IFNULL(prc.design_price,0) AS `design_price`
            FROM tb_m_design d 
            INNER JOIN tb_m_product p ON p.id_design = d.id_design
            INNER JOIN tb_season ss ON ss.id_season = d.id_season
            INNER JOIN tb_range rg ON rg.id_range = ss.id_range
            LEFT JOIN (
	            SELECT p.* , LEFT(pt.design_price_type,1) AS `price_type`, cat.id_design_cat, LEFT(cat.design_cat,1) AS `design_cat`
	            FROM tb_m_design_price p
	            INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
	            INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = pt.id_design_cat
	            WHERE p.id_design_price IN (
		            SELECT MAX(p.id_design_price) FROM tb_m_design_price p
		            WHERE p.design_price_start_date<=NOW() AND is_active_wh=1 AND is_design_cost=0
		            GROUP BY p.id_design
	            )
            ) prc ON prc.id_design = d.id_design
            WHERE d.id_lookup_status_order!=2 AND rg.is_md=2 AND d.id_design>=6327 
            HAVING design_price=0 "
            Dim dgwp As DataTable = execute_query(qgwp, -1, True, "", "", "", "")
            If dgwp.Rows.Count > 0 Then
                For g As Integer = 0 To GVItemList.RowCount - 1
                    Dim dgwp_filter As DataRow() = dgwp.Select("[product_full_code]='" + GVItemList.GetRowCellValue(g, "code").ToString + "'")
                    If dgwp_filter.Length > 0 Then
                        sku_gwp_no_price += dgwp_filter(0)("product_full_code").ToString + " - " + GVItemList.GetRowCellValue(g, "name").ToString + Environment.NewLine
                    End If
                Next
            Else
                sku_gwp_no_price = ""
            End If
        End If
        GVItemList.ActiveFilterString = ""
        Return sku_gwp_no_price
    End Function

    Sub insertLogLineList(ByVal rmt As String, ByVal id_report_trans As String, ByVal is_bulk As Boolean, ByVal user_modified As String, ByVal user_created As String, ByVal number_trans As String, ByVal date_trans As String, ByVal id_design_par As String, ByVal note As String)
        Try
            If is_bulk = False Then
                'single log
                Dim query As String = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note) 
                 VALUES(NOW(), '" + user_modified + "', '" + user_created + "', '" + rmt + "', '" + id_report_trans + "', '" + number_trans + "', '" + date_trans + "', '" + id_design_par + "', '" + note + "') "
                execute_non_query(query, True, "", "", "", "")
            Else
                'bulk 
                Dim query As String = ""
                If rmt = "9" Or rmt = "80" Or rmt = "81" Or rmt = "206" Then
                    'prod demand
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note) 
                    SELECT NOW(), '" + id_user + "', rm.id_user, '" + rmt + "', pd.id_prod_demand,pd.prod_demand_number, pd.prod_demand_date, pdd.id_design, pd.prod_demand_note
                    FROM tb_prod_demand_design pdd 
                    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
                    INNER JOIN tb_report_mark rm ON rm.id_report = pd.id_prod_demand AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    WHERE pdd.id_prod_demand=" + id_report_trans + " AND pdd.is_void=2 "
                ElseIf rmt = "143" Or rmt = "144" Or rmt = "145" Or rmt = "194" Or rmt = "195" Or rmt = "196" Or rmt = "210" Then
                    'PD revisi
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note) 
                    SELECT NOW(), '" + id_user + "', rm.id_user, pdr.report_mark_type, pdr.id_prod_demand_rev, CONCAT(pd.prod_demand_number,'/Rev ',pdr.rev_count), pdr.created_date, pddr.id_design, pdr.note
                    FROM tb_prod_demand_rev pdr
                    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdr.id_prod_demand
                    INNER JOIN tb_report_mark rm ON rm.id_report = pdr.id_prod_demand_rev AND rm.report_mark_type= pdr.report_mark_type AND rm.id_report_status=1
                    INNER JOIN tb_prod_demand_design_rev pddr ON pddr.id_prod_demand_rev = pdr.id_prod_demand_rev
                    WHERE pdr.id_prod_demand_rev=" + id_report_trans + " "
                ElseIf rmt = "22" Then
                    'F.G PO
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', rm.id_user, '" + rmt + "', po.id_prod_order, po.prod_order_number, po.prod_order_date, pdd.id_design, 'PO Created'
                    FROM tb_prod_order po
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    INNER JOIN tb_report_mark rm ON rm.id_report = po.id_prod_order AND rm.report_mark_type=22 AND rm.id_report_status=1
                    WHERE po.id_prod_order=" + id_report_trans + " "
                ElseIf rmt = "28" Or rmt = "127" Then
                    'REC QC
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', IFNULL(rm.id_user, '" + id_user + "'), '" + rmt + "',r.id_prod_order_rec, r.prod_order_rec_number, r.prod_order_rec_date, pdd.id_design, 'Receive in QC'
                    FROM tb_prod_order_rec r
                    LEFT JOIN tb_report_mark rm ON rm.id_report = r.id_prod_order_rec AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = r.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE r.id_prod_order_rec=" + id_report_trans + " "
                ElseIf rmt = "385" Then
                    'QC REPORT 1
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', IFNULL(rm.id_user, '" + id_user + "'),'" + rmt + "', q.id_qc_report1, q.number, q.created_date, pdd.id_design, 'QC Report I'
                    FROM tb_qc_report1 q
                    LEFT JOIN tb_report_mark rm ON rm.id_report = q.id_qc_report1 AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = q.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE q.id_qc_report1=" + id_report_trans + " "
                ElseIf rmt = "31" Then
                    'QC RET OUT
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "' ,IFNULL(rm.id_user, '" + id_user + "'), '" + rmt + "', r.id_prod_order_ret_out, r.prod_order_ret_out_number, r.prod_order_ret_out_date, pdd.id_design, 'QC Return Out'
                    FROM tb_prod_order_ret_out r
                    LEFT JOIN tb_report_mark rm ON rm.id_report = r.id_prod_order_ret_out AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = r.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE r.id_prod_order_ret_out=" + id_report_trans + " "
                ElseIf rmt = "32" Then
                    'QC RET IN
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "' ,IFNULL(rm.id_user, '" + id_user + "'), '" + rmt + "', r.id_prod_order_ret_in, r.prod_order_ret_in_number, r.prod_order_ret_in_date, pdd.id_design, 'QC Return In'
                    FROM tb_prod_order_ret_in r
                    LEFT JOIN tb_report_mark rm ON rm.id_report = r.id_prod_order_ret_in AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = r.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE r.id_prod_order_ret_in=" + id_report_trans + " "
                ElseIf rmt = "105" Or rmt = "224" Then
                    'QC REPORT II
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', IFNULL(rm.id_user, '" + id_user + "'), '" + rmt + "', q.id_prod_fc, q.prod_fc_number, q.prod_fc_date, pdd.id_design, 'QC Report II'
                    FROM tb_prod_fc q
                    LEFT JOIN tb_report_mark rm ON rm.id_report = q.id_prod_fc AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = q.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE q.id_prod_fc=" + id_report_trans + " "
                ElseIf rmt = "33" Then
                    'PL (Handover)
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "' , IFNULL(rm.id_user, '" + id_user + "'), '" + rmt + "', pl.id_pl_prod_order, pl.pl_prod_order_number, pl.pl_prod_order_date, pdd.id_design, 'Packing List (Handover to WH)'
                    FROM tb_pl_prod_order pl
                    LEFT JOIN tb_report_mark rm ON rm.id_report = pl.id_pl_prod_order AND rm.report_mark_type=" + rmt + " AND rm.id_report_status=1
                    INNER JOIN tb_prod_order po ON po.id_prod_order = pl.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE pl.id_pl_prod_order=" + id_report_trans + " "
                ElseIf rmt = "37" Then
                    ' REC IN WH
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', rm.id_user, 37, r.id_pl_prod_order_rec, r.pl_prod_order_rec_number, r.pl_prod_order_rec_date, pdd.id_design, 'Received by WH'
                    FROM tb_pl_prod_order_rec r
                    INNER JOIN tb_report_mark rm ON rm.id_report = r.id_pl_prod_order_rec AND rm.report_mark_type=37 AND rm.id_report_status=1
                    INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = r.id_pl_prod_order
                    INNER JOIN tb_prod_order po ON po.id_prod_order = pl.id_prod_order
                    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                    WHERE r.id_pl_prod_order_rec=" + id_report_trans + " "
                ElseIf rmt = "70" Then
                    'PP New Product
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', rm.id_user, 70, p.id_fg_propose_price, p.fg_propose_price_number, p.fg_propose_price_date, pd.id_design, 'PP New Product'
                    FROM tb_fg_propose_price p
                    INNER JOIN tb_report_mark rm ON rm.id_report = p.id_fg_propose_price AND rm.report_mark_type=70 AND rm.id_report_status=1
                    INNER JOIN tb_fg_propose_price_detail pd ON pd.id_fg_propose_price = p.id_fg_propose_price
                    WHERE p.id_fg_propose_price=" + id_report_trans + " AND pd.is_active=1 "
                ElseIf rmt = "188" Then
                    'PP NEW PRODUCT REVISE
                    query = "INSERT INTO tb_log_line_list(log_date, id_user_modified, id_user_created, report_mark_type, id_report, report_number, report_date, id_design, note)
                    SELECT NOW(), '" + id_user + "', rm.id_user, 188, pr.id_fg_propose_price_rev, CONCAT(p.fg_propose_price_number,'/Rev',pr.rev_count), pr.created_date, prd.id_design, 'PP New Product- Revise'
                    FROM tb_fg_propose_price_rev pr
                    INNER JOIN tb_fg_propose_price p ON p.id_fg_propose_price = pr.id_fg_propose_price
                    INNER JOIN tb_report_mark rm ON rm.id_report = pr.id_fg_propose_price_rev AND rm.report_mark_type=188 AND rm.id_report_status=1
                    INNER JOIN tb_fg_propose_price_rev_det prd ON prd.id_fg_propose_price_rev = pr.id_fg_propose_price_rev
                    WHERE pr.id_fg_propose_price_rev=" + id_report_trans + " "
                End If
                execute_non_query(query, True, "", "", "", "")
            End If
        Catch ex As Exception
            execute_non_query("INSERT INTO tb_log_error(datetime, err, id_user) VALUES(DATE(NOW()), 'Err Log Line List (" + rmt + "/" + id_report_trans + "/" + id_design_par + "):" + ex.ToString + "', '" + id_user + "')", True, "", "", "", "")
        End Try
    End Sub
End Class
