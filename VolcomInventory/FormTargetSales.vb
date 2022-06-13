Public Class FormTargetSales
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()
    Public is_test As String = "-1"
    Public is_load_new As Boolean = False


    Private Sub FormTargetSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-controller")
        viewYearList()
        viewYearPropose()
        If is_test = "1" Then
            createNew()
        End If
    End Sub

    Sub viewYearList()
        viewSearchLookupQueryO(SLEYear, volcomErpApiGetDT(dt_json, 0), "year", "year", "year")
    End Sub

    Sub viewYearPropose()
        viewSearchLookupQueryO(SLEYearPropose, volcomErpApiGetDT(dt_json, 1), "year", "year", "year")
    End Sub

    Private Sub BtnViewPropose_Click(sender As Object, e As EventArgs) Handles BtnViewPropose.Click
        viewPropose()
    End Sub

    Sub refreshProposeList(ByVal is_new_propose As Boolean, ByVal year_propose As String)
        If is_new_propose Then
            dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-controller")
            viewYearPropose()
            SLEYearPropose.EditValue = year_propose
        End If
        viewPropose()
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor
        Dim tahun As String = ""
        Try
            tahun = SLEYearPropose.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT t.id_b_revenue_propose, t.`number`, t.`year`, t.`total`,
        t.created_date, t.id_created_user, e.employee_name AS `created_user`, t.note, pt.proposal_type,
        t.id_report_status, stt.report_status, t.is_confirm  
        FROM tb_b_revenue_propose t
        INNER JOIN tb_m_user u ON u.id_user = t.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = t.id_report_status 
        INNER JOIN tb_lookup_proposal_type pt ON pt.id_proposal_type = t.id_proposal_type
        WHERE t.`year`='" + tahun + "' ORDER BY t.id_b_revenue_propose DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPropose.DataSource = data
        GVPropose.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSales_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTargetSales_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormTargetSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDetail()
        If GVPropose.RowCount > 0 And GVPropose.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormTargetSalesDet.id = GVPropose.GetFocusedRowCellValue("id_b_revenue_propose").ToString
            FormTargetSalesDet.action = "upd"
            FormTargetSalesDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCPropose, "Propose Sales Target List")
        Cursor = Cursors.Default
    End Sub

    Sub createNew()
        Cursor = Cursors.WaitCursor
        FormTargetSalesDet.action = "ins"
        FormTargetSalesDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPropose_DoubleClick(sender As Object, e As EventArgs) Handles GVPropose.DoubleClick
        viewDetail()
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetail()
        End If
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        createNew()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewList()
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim year As String = ""
        Try
            year = SLEYear.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim query As String = "SELECT t.id_store, c.comp_number, c.comp_name,
        SUM(CASE WHEN t.`month`=1 THEN t.b_revenue END) AS `01`,
        SUM(CASE WHEN t.`month`=2 THEN t.b_revenue END) AS `02`,
        SUM(CASE WHEN t.`month`=3 THEN t.b_revenue END) AS `03`,
        SUM(CASE WHEN t.`month`=4 THEN t.b_revenue END) AS `04`,
        SUM(CASE WHEN t.`month`=5 THEN t.b_revenue END) AS `05`,
        SUM(CASE WHEN t.`month`=6 THEN t.b_revenue END) AS `06`,
        SUM(CASE WHEN t.`month`=7 THEN t.b_revenue END) AS `07`,
        SUM(CASE WHEN t.`month`=8 THEN t.b_revenue END) AS `08`,
        SUM(CASE WHEN t.`month`=9 THEN t.b_revenue END) AS `09`,
        SUM(CASE WHEN t.`month`=10 THEN t.b_revenue END) AS `10`,
        SUM(CASE WHEN t.`month`=11 THEN t.b_revenue END) AS `11`,
        SUM(CASE WHEN t.`month`=12 THEN t.b_revenue END) AS `12`,
        SUM(t.b_revenue) AS `total` 
        FROM tb_b_revenue t
        INNER JOIN tb_m_comp c ON c.id_comp = t.id_store
        WHERE t.`year`='" + year + "' AND t.is_active=1
        GROUP BY t.id_store "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintList_Click(sender As Object, e As EventArgs) Handles BtnPrintList.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "SALES TARGET : " + SLEYear.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoBtnHistory_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnHistory.ButtonClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormTargetSalesHistory.id_store = GVData.GetFocusedRowCellValue("id_store").ToString
            FormTargetSalesHistory.ShowDialog()
        End If
    End Sub
End Class