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

    Sub refreshProposeList(ByVal is_new_propose As Boolean)
        If is_new_propose Then
            dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-controller")
            viewYearPropose()
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
        t.created_date, t.id_created_user, e.employee_name AS `created_user`, t.note, 
        t.id_report_status, stt.report_status, t.is_confirm  
        FROM tb_b_revenue_propose t
        INNER JOIN tb_m_user u ON u.id_user = t.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = t.id_report_status 
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
End Class