Public Class FormPromoZalora

    Private Sub FormPromoZalora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")
    End Sub

    Sub newPropose()
        Cursor = Cursors.WaitCursor
        FormPromoZaloraDet.action = "ins"
        FormPromoZaloraDet.ShowDialog()
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
        Dim cond As String = "  AND (p.propose_created_by>='" + date_from_selected + "' AND p.propose_created_by<='" + date_until_selected + "') "

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
            FormPromoZaloraDet.id = GVData.GetFocusedRowCellValue("id_promo_zalora").tos
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
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPromoZalora_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewData()
    End Sub
End Class