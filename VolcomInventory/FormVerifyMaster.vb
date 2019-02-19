Public Class FormVerifyMaster
    Public id_store As String = "-1"
    Public id_store_contact As String = "-1"

    Private Sub FormVerifyMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormVerifyMaster_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormVerifyMaster_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "92"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewDel()
        GVSalesDelOrder.OptionsBehavior.Editable = True
        CESelAll.Enabled = True
        BtnReset.Visible = False
        BtnView.Enabled = False
        GCSalesDelOrder.DataSource = Nothing
        BtnLoadData.Visible = False
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False

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

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND a.is_use_unique_code='1' AND d.id_comp='" + id_store + "' AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
        If GVSalesDelOrder.RowCount > 0 Then
            GVSalesDelOrder.BestFitColumns()
            BtnLoadData.Visible = True
        Else
            BtnLoadData.Visible = False
        End If
    End Sub

    Private Sub BtnLoadData_Click(sender As Object, e As EventArgs) Handles BtnLoadData.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        GVSalesDelOrder.OptionsBehavior.Editable = False
        CESelAll.Enabled = False
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False

        makeSafeGV(GVSalesDelOrder)
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes'"
        Dim id_del As String = ""
        If GVSalesDelOrder.RowCount <= 0 Then
            stopCustom("No item selected")
        Else
            For i As Integer = 0 To GVSalesDelOrder.RowCount - 1
                If i > 0 Then
                    id_del += "OR "
                End If
                id_del += "d.id_pl_sales_order_del = '" + GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString + "' "
            Next

            'call proc
            Dim delc As New ClassSalesDelOrder()
            Dim data As DataTable = delc.getMasterDelivery(id_del)
            GCData.DataSource = data
            If GVData.RowCount > 0 Then
                GVData.BestFitColumns()
                BtnConfirm.Visible = True
                BtnLoadData.Visible = False
                BtnReset.Visible = True
            Else
                BtnConfirm.Visible = False
                BtnLoadData.Visible = True
                BtnReset.Visible = False
            End If
        End If
        makeSafeGV(GVSalesDelOrder)
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_del As String = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            Dim menu As New ClassShowPopUp()
            menu.id_report = id_del
            menu.report_mark_type = "43"
            menu.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Cursor = Cursors.WaitCursor
        viewDel()
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        If GVSalesDelOrder.RowCount > 0 Then
            Dim cek As String = CESelAll.EditValue.ToString
            For i As Integer = ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder)) To 0 Step -1
                If cek Then
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        If id_store <> "-1" Then
            BtnView.Enabled = True
        Else
            BtnView.Enabled = False
        End If
        GCSalesDelOrder.DataSource = Nothing
        GCData.DataSource = Nothing
        BtnLoadData.Visible = False
        BtnReset.Visible = False
        BtnConfirm.Visible = False
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        If id_store <> "-1" Then
            BtnView.Enabled = True
        Else
            BtnView.Enabled = False
        End If
        GCSalesDelOrder.DataSource = Nothing
        GCData.DataSource = Nothing
        BtnLoadData.Visible = False
        BtnReset.Visible = False
        BtnConfirm.Visible = False
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewDel()
        Cursor = Cursors.Default
    End Sub
End Class