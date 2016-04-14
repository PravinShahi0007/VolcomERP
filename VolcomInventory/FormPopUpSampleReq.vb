Public Class FormPopUpSampleReq
    Dim id_sample_requisition As String
    Public id_pop_up As String

    'Form
    Private Sub FormPopUpSampleReq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            viewSampleReq()
        End If
    End Sub


    Private Sub FormPopUpSampleReq_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View Data
    Sub viewSampleReq()
        GVReq.ActiveFilter.Clear()

        Dim query As String = ""
        query += "SELECT i.employee_name, j.departement, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from, (c.id_comp) AS id_comp_from, (c.comp_number) AS comp_code_from, a.id_comp_contact_from,  "
        'query += "(e.comp_name) AS comp_to, f.report_status, a.id_report_status "
        query += "f.report_status, a.id_report_status, IFNULL(jum_pl.tot_pl , 0) AS tot_pl,dvx.code_detail_name as division "
        query += "FROM tb_sample_requisition a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp  "
        'query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact  "
        'query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_m_user h ON a.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_m_departement j ON j.id_departement = i.id_departement "
        query += "LEFT JOIN tb_m_code_detail dvx ON dvx.id_code_detail = a.id_division "
        query += "LEFT JOIN ( "
        query += "SELECT a.id_sample_requisition ,COUNT(a.id_pl_sample_del) AS tot_pl FROM tb_pl_sample_del a WHERE a.id_report_status!='5' GROUP BY a.id_sample_requisition "
        query += ") jum_pl ON jum_pl.id_sample_requisition = a.id_sample_requisition "
        query += "WHERE a.id_report_status = '6' "
        query += "ORDER BY a.id_sample_requisition ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReq.DataSource = data
        GVReq.ActiveFilterString = "[tot_pl]=0"
        If GVReq.RowCount > 0 Then
            'show 
            viewDetail()
            BtnChoose.Enabled = True
        Else
            'hide 
            BtnChoose.Enabled = False
        End If
    End Sub
    Sub viewDetail()
        id_sample_requisition = "-1"
        Try
            id_sample_requisition = GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_sample_req_det('" + id_sample_requisition + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    'GridView
    Private Sub GVReq_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVReq_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVReq.RowClick

    End Sub
    'Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then
            FormSamplePLDelSingle.TxtSRSNumber.Text = GVReq.GetFocusedRowCellValue("sample_requisition_number").ToString
            FormSamplePLDelSingle.id_comp_contact_to = GVReq.GetFocusedRowCellValue("id_comp_contact_from")
            FormSamplePLDelSingle.id_comp_to = GVReq.GetFocusedRowCellValue("id_comp_from")
            FormSamplePLDelSingle.TxtCodeCompTo.Text = GVReq.GetFocusedRowCellValue("comp_code_from").ToString
            FormSamplePLDelSingle.TxtNameCompTo.Text = GVReq.GetFocusedRowCellValue("comp_from").ToString
            FormSamplePLDelSingle.TEDivision.Text = GVReq.GetFocusedRowCellValue("division").ToString
            FormSamplePLDelSingle.id_sample_requisition = GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
            FormSamplePLDelSingle.viewFillEmptyData()
            FormSamplePLDelSingle.GroupControlDrawer.Enabled = True
            FormSamplePLDelSingle.GroupControlDetailSingle.Enabled = True
            FormSamplePLDelSingle.BtnInfoSrs.Enabled = True
            FormSamplePLDelSingle.viewDetailBC()
            FormSamplePLDelSingle.GroupControlScannedItem.Enabled = True
            Close()
        End If
    End Sub

    Private Sub GVReq_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVReq.FocusedRowChanged
        'showMyToolHint()
        viewDetail()
    End Sub

    Private Sub GVReq_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVReq.DoubleClick
        Cursor = Cursors.WaitCursor
        FormInfoSRS.id_sample_requisition = id_sample_requisition
        FormInfoSRS.LabelSubTitle.Text = "Sample Borrow Requisition No : " + GVReq.GetFocusedRowCellValue("sample_requisition_number").ToString + ""
        FormInfoSRS.ShowDialog()
        Cursor = Cursors.Default
    End Sub

  
    Private Sub ToolTipControllerNew_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipControllerNew.GetActiveObjectInfo
        If Not e.SelectedControl Is GCReq Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GCReq.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells

        Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
        Dim text As String = "Double click to see sample borrow requisition"
        info = New DevExpress.Utils.ToolTipControlInfo(o, text)

        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub GVReq_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVReq.ColumnFilterChanged
        If GVReq.RowCount > 0 Then
            'show 
            BtnChoose.Enabled = True
        Else
            'hide 
            BtnChoose.Enabled = False
        End If
    End Sub
End Class