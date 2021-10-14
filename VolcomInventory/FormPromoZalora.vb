Public Class FormPromoZalora
    Public is_load_new As Boolean = False
    Public id_pop_up As String = "-1"

    Private Sub FormPromoZalora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        'pop up
        If id_pop_up = "1" Then
            WindowState = FormWindowState.Normal
            Dim dt_now_year As DataTable = execute_query("SELECT STR_TO_DATE(CONCAT(YEAR(NOW()),'-01-','01'),'%Y-%m-%d') AS `tgl`", -1, True, "", "", "", "")
            DEFromList.EditValue = dt_now_year.Rows(0)("tgl")
            viewData()
        End If
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetail()
        End If
    End Sub

    Sub newPropose()
        Cursor = Cursors.WaitCursor
        FormPromoZaloraDet.action = "ins"
        FormPromoZaloraDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "  AND (DATE(p.propose_created_date)>='" + date_from_selected + "' AND DATE(p.propose_created_date)<='" + date_until_selected + "') "
        If id_pop_up = "1" Then
            cond += "AND p.id_report_status_recon=6 "
        End If

        Dim pz As New ClassPromoZalora()
        Dim query As String = pz.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormPromoZaloraDet.action = "upd"
            FormPromoZaloraDet.id = GVData.GetFocusedRowCellValue("id_promo_zalora").ToString
            FormPromoZaloraDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCData, "Zalora Promo List")
        Cursor = Cursors.WaitCursor
    End Sub

    Private Sub FormPromoZalora_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If id_pop_up = "-1" Then
            FormMain.show_rb(Name)
            checkFormAccess(Name)
        End If
    End Sub

    Private Sub FormPromoZalora_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If id_pop_up = "-1" Then
            FormMain.hide_rb()
        End If
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewData()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If id_pop_up = "-1" Then
            viewDetail()
        ElseIf id_pop_up = "1" Then
            Cursor = Cursors.WaitCursor
            FormOLStoreSummary.BtnBrowseZaloraPromo.Text = GVData.GetFocusedRowCellValue("promo_name").ToString + " (" + GVData.GetFocusedRowCellValue("discount_code").ToString + ")"
            FormOLStoreSummary.TxtPromoZaloraID.Text = GVData.GetFocusedRowCellValue("id_promo_zalora").ToString
            FormOLStoreSummary.viewDetailZalPrm()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class