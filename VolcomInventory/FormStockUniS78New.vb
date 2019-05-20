Public Class FormStockUniS78New
    Private Sub FormStockUniS78New_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormStockUniS78New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dd.`no`, dd.point,d.design_code AS `code`,d.design_display_name AS `name`,
        prc.id_design_price, prc.design_price, prc.design_price_type, prc.id_design_cat, prc.design_cat,
        SUBSTRING(p.product_full_code, 10, 1) AS `sizetype`,
        g.*
        FROM tb_emp_uni_design_det dd 
        INNER JOIN tb_emp_uni_design ddm ON ddm.id_emp_uni_design = dd.id_emp_uni_design
        INNER JOIN tb_m_design d ON d.id_design = dd.id_design
        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        LEFT JOIN (
	        SELECT p.id_design AS `id_dsg`,
	        SUBSTRING(p.product_full_code, 10, 1) AS `styp`,
	        SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `1`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `2`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `3`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `4`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `5`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `6`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `7`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `8`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty) END) `9`, SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty)  END) `0` ,
	        SUM(IF(g.id_storage_category=2, CONCAT('-', g.storage_product_qty), g.storage_product_qty)) AS `total_qty`
	        FROM 	tb_storage_fg g
	        INNER JOIN tb_m_product p ON p.id_product = g.id_product
	        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
	        WHERE g.id_wh_drawer = 451
	        GROUP BY p.id_design, SUBSTRING(p.product_full_code, 10, 1)
        ) g ON g.id_dsg=p.id_design AND g.styp = SUBSTRING(p.product_full_code, 10, 1)
        LEFT JOIN( 
          Select * FROM ( 
          Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
          price.id_design_price_type, price_type.design_price_type,
          cat.id_design_cat, cat.design_cat
          From tb_m_design_price price 
          INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
          INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
          WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
          ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
          GROUP BY a.id_design 
        ) prc ON prc.id_design = d.id_design 
        WHERE ddm.id_emp_uni_period=15 AND ddm.id_report_status=6  
        GROUP BY p.id_design, SUBSTRING(p.product_full_code, 10, 1)
        ORDER BY dd.`no` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesignList.DataSource = data
        GVDesignList.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVDesignList.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
        GVDesignList.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
        GVDesignList.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
        GVDesignList.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
        GVDesignList.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
        GVDesignList.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
        GVDesignList.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVDesignList.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVDesignList.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
        GVDesignList.RefreshData()
        GVDesignList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        print_raw(GCDesignList, "")
    End Sub
End Class