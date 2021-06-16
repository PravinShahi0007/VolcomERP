Public Class FormStockTakePeriodSOH
    Private Sub FormStockTakePeriodSOH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim soh_date As String = Date.Parse(FormStockTakeStorePeriodDet.DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim data_date As DataTable = execute_query("SELECT CONCAT(YEAR('" + soh_date + "'), '-', LPAD(MONTH('" + soh_date + "'), 2, '0'), '-', '01') AS cm_beg_startd, DATE_SUB(CONCAT(YEAR('" + soh_date + "'), '-', LPAD(MONTH('" + soh_date + "'), 2, '0'), '-', '01'), INTERVAL 1 DAY) AS beg_date, YEAR((SELECT beg_date)) AS beg_year, MONTH((SELECT beg_date)) AS beg_month", -1, True, "", "", "", "")

        Dim query As String = "
            SELECT 'no' AS is_select, 0 AS `no`, stc.id_product, p.product_full_code, CONCAT(c.code, ' ', d.design_name, ' ', r.display_name) AS product_name, z.code_detail_name AS size, IFNULL(stc.qty_ttl,0) AS qty
            FROM (
                SELECT a.id_product, SUM(qty_ttl) AS qty_ttl
                FROM (
                    SELECT f.id_wh_drawer, f.id_product, f.qty_ttl
                    FROM tb_storage_fg_" + data_date.Rows(0)("beg_year").ToString + " f
                    WHERE f.month='" + data_date.Rows(0)("beg_month").ToString + "'
                    UNION ALL
                    SELECT f.id_wh_drawer, f.id_product, 
                    SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)), 0)) AS qty_ttl 
                    FROM tb_storage_fg f
                    WHERE f.storage_product_datetime >= '" + data_date.Rows(0)("cm_beg_startd").ToString + " 00:00:00'  AND f.storage_product_datetime <= '" + soh_date + " 23:59:59' 
                    GROUP BY f.id_wh_drawer, f.id_product
                ) a
                INNER JOIN tb_m_wh_drawer drw ON  drw.id_wh_drawer = a.id_wh_drawer
                INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
                INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator AND loc.id_comp IN (SELECT id_comp FROM tb_m_comp WHERE id_store = " + FormStockTakeStorePeriodDet.SLUEStore.EditValue.ToString + ")
                INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp
                GROUP BY a.id_product
            ) stc
            INNER JOIN tb_m_product p ON p.id_product = stc.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design AND d.id_lookup_status_order != 2
            INNER JOIN (
                SELECT c.id_product, d.display_name, d.code_detail_name
                FROM tb_m_product_code AS c
                INNER JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS z ON z.id_product = p.id_product
            INNER JOIN (
                SELECT c.id_design, d.code, d.code_detail_name
                FROM tb_m_design_code AS c
                INNER JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                WHERE d.id_code = 30
            ) AS c ON d.id_design = c.id_design
            INNER JOIN (
                SELECT c.id_design, d.code, d.display_name
                FROM tb_m_design_code AS c
                INNER JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                WHERE d.id_code = 14
            ) AS r ON d.id_design = r.id_design
            HAVING qty != 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            data.Rows(i)("no") = i + 1

            For j = 0 To FormStockTakeStorePeriodDet.id_product.Count - 1
                If data.Rows(i)("id_product").ToString = FormStockTakeStorePeriodDet.id_product(j).ToString Then
                    data.Rows(i)("is_select") = "yes"
                End If
            Next
        Next

        GCSOH.DataSource = data

        GVSOH.BestFitColumns()
    End Sub

    Private Sub FormStockTakePeriodSOH_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        Dim data As DataTable = GCSOH.DataSource

        If CheckEdit1.EditValue Then
            For i = 0 To data.Rows.Count - 1
                data.Rows(i)("is_select") = "yes"
            Next
        Else
            For i = 0 To data.Rows.Count - 1
                data.Rows(i)("is_select") = "no"
            Next
        End If

        GCSOH.DataSource = data
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        GVSOH.ActiveFilterString = "[is_select] = 'yes'"

        FormStockTakeStorePeriodDet.id_product.Clear()

        For i = 0 To GVSOH.RowCount - 1
            FormStockTakeStorePeriodDet.id_product.Add(GVSOH.GetRowCellValue(i, "id_product").ToString)
        Next

        GVSOH.ActiveFilterString = ""

        FormStockTakeStorePeriodDet.CEAll.EditValue = False

        Close()
    End Sub
End Class