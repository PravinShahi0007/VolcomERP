Public Class FormProductionHO
    Public is_public_form As String = "false"

    Private Sub FormProductionHO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim time_now As DateTime = getTimeDB()
        DEFrom.EditValue = time_now
        DEUntil.EditValue = time_now
        DEFromDetail.EditValue = time_now
        DEUntilDetail.EditValue = time_now

        If is_public_form Then
            BtnViewPending.Visible = False
            PanelControlSendEmail.Visible = False
            GridColumnis_select.Visible = False
        End If
    End Sub

    Private Sub FormProductionHO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionHO_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProductionHO_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        viewRegList("AND (pl.pl_prod_order_date>=""" + date_from_selected + """ AND pl.pl_prod_order_date<=""" + date_until_selected + """) ")
    End Sub

    Sub viewRegList(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_pl_prod_report('" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewPending_Click(sender As Object, e As EventArgs) Handles BtnViewPending.Click
        viewRegList("AND ho_notif=2 ")
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = 33
            m.id_report = GVList.GetFocusedRowCellValue("id_pl_prod_order").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim is_select As String = ""
        If CESelAll.EditValue = True Then
            is_select = "Yes"
        Else
            is_select = "No"
        End If
        For i As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
            GVList.SetRowCellValue(i, "is_select", is_select)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSendEmail_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVList)
        GVList.ActiveFilterString = "[is_select]='Yes'"
        If GVList.RowCount > 0 Then
            Dim id As String = ""
            For i As Integer = 0 To GVList.RowCount - 1
                If i > 0 Then
                    id += "OR "
                End If
                id += "pl.id_pl_prod_order=" + GVList.GetRowCellValue(i, "id_pl_prod_order").ToString + " "
            Next

            'update
            Dim query_upd As String = "UPDATE tb_pl_prod_order pl SET pl.ho_notif=1, pl.ho_notif_date=NOW(), pl.ho_notif_by=" + id_user + " WHERE (" + id + ") "
            execute_non_query(query_upd, True, "", "", "", "")

            Try
                'send email
                Dim em As New ClassSendEmail()
                em.report_mark_type = "33"
                Dim qty As String = Decimal.Parse(GVList.Columns("total_qty").SummaryItem.SummaryValue.ToString).ToString("N0")
                em.par1 = qty
                em.id_report = id
                em.send_email()
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try

            'refresh view
            GCList.DataSource = Nothing
        Else
            stopCustom("No data selected")
        End If
        GVList.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        viewDetail("AND (pl.pl_prod_order_date>=""" + date_from_selected + """ AND pl.pl_prod_order_date<=""" + date_until_selected + """) ")
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_pl_prod_report_det('" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class