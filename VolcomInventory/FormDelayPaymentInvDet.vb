Public Class FormDelayPaymentInvDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_submit As String = "-1"
    Dim rmt As String = "326"
    Public id_comp_group As String = "-1"
    Public action As String = ""

    Private Sub FormDelayPaymentInvDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormDelayPaymentInvDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub


    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            SLEStoreGroup.Enabled = True
            Width = 510
            Height = 200
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If

            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)

            'defult data
            TxtNumber.Text = "[auto generated]"
            Dim curr_date As DateTime = getTimeDB()
            DEDueDate.EditValue = curr_date
            DEDueDate.Properties.MinValue = curr_date
        Else
            'main
            Dim query_c As ClassDelayPayment = New ClassDelayPayment()
            Dim query As String = query_c.queryMain("AND dp.id_delay_payment=" + id + " ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DEDueDate.EditValue = data.Rows(0)("due_date")
            id_comp_group = data.Rows(0)("id_comp_group").ToString
            SLEStoreGroup.EditValue = id_comp_group
            MENote.Text = data.Rows(0)("note").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_submit = data.Rows(0)("is_submit").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString

            'detail
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dd.id_delay_payment_det, dd.id_delay_payment, 
        dd.id_sales_pos, sp.sales_pos_number, CONCAT(dd.comp_number, ' - ', dd.comp_name) AS `store`, 
        sp.sales_pos_date, sp.sales_pos_due_date, CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`, dd.amount, 
        dd.remark 
        FROM tb_delay_payment_det dd
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = dd.id_sales_pos
        WHERE dd.id_delay_payment=" + id + "
        ORDER BY dd.id_delay_payment_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_submit = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Properties.ReadOnly = False
            GVData.OptionsBehavior.ReadOnly = False
            DEDueDate.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            DEDueDate.Enabled = False
        End If

        'reset propose
        If is_view = "-1" And is_submit = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            DEDueDate.Enabled = False
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub
End Class