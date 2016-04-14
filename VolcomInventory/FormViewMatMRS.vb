Public Class FormViewMatMRS 
    Public id_mrs As String = "-1"
    Public id_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp_req_from As String = "-1"
    Public id_comp_req_to As String = "-1"
    Public id_report_status_g As String = "-1"
    Public mrs_type As String = "1" '1= other ; 2= mat wo
    '
    Private Sub FormViewMatMRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mrs()
        
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_mrs_date,'%Y-%m-%d') as prod_order_mrs_datex FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        mrs_type = data.Rows(0)("mrs_type").ToString
        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        TEMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString

        TECompName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_req_from), "2")
        TECompToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")
        TECompToCode.Text = get_company_x(get_id_company(id_comp_req_to), "2")

        id_report_status_g = data.Rows(0)("id_report_status").ToString
        TEDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)

        MENote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        If mrs_type = "1" Then 'other
            TEWONumber.Enabled = False
            '
        Else 'mat wo
            TEWONumber.Enabled = True
            '
            id_wo = data.Rows(0)("id_mat_wo").ToString
            query = "SELECT mat_wo_number FROM tb_mat_wo WHERE id_mat_wo='" & id_wo & "'"
            data = execute_query(query, -1, True, "", "", "", "")

            TEWONumber.Text = data.Rows(0)("mat_wo_number").ToString
        End If
    End Sub
    Sub view_mrs()
        Try
            Dim query As String
            query = "CALL view_prod_order_mrs('" & id_mrs & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub FormProductionMRS_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub GVMat_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMat.RowStyle
        If GVMat.GetRowCellValue(e.RowHandle, "qty") > GVMat.GetRowCellValue(e.RowHandle, "qty_all_mat") Then
            'GVMat.FocusedRowHandle()
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Bold)
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Regular)
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mrs
        FormReportMark.report_mark_type = "44"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mrs
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "44"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class