Public Class FormABGRoyaltyZone
    Private Sub FormABGRoyaltyZone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewYear()
        viewQuarter()
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT YEAR(sp.sales_pos_date) AS `year`
        FROM tb_sales_pos sp
        WHERE sp.id_report_status!=5
        GROUP BY YEAR(sp.sales_pos_date) 
        ORDER BY `year` DESC)"
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
        Cursor = Cursors.Default
    End Sub

    Sub viewQuarter()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_quarter`, 'ALL' AS `quarter`
        UNION ALL
        SELECT '1' AS `id_quarter`, 'QUARTER 1' AS `quarter`
        UNION
        SELECT '2' AS `id_quarter`, 'QUARTER 2' AS `quarter`
        UNION
        SELECT '3' AS `id_quarter`, 'QUARTER 3' AS `quarter`
        UNION 
        SELECT '4' AS `id_quarter`, 'QUARTER 4' AS `quarter` "
        viewSearchLookupQuery(SLEQuarter, query, "id_quarter", "quarter", "id_quarter")
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim year As String = SLEYear.EditValue.ToString
        Dim cond As String = ""
        If SLEQuarter.Text.ToString <> "ALL" Then
            cond = "AND a.quarter=''" + SLEQuarter.Text.ToString + "'' "
        End If
        Dim query As String = "CALL view_abg_royalty_zone('" + year + "', '" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub
End Class